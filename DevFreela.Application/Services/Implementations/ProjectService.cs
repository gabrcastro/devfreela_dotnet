using DevDreela.Application.InputModels;
using DevDreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DevFreela.Application.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Services.Implementations;

public class ProjectService(DevFreelaDbContext context, IConfiguration configuration) : IProjectService {

    private readonly string? _connectionString = configuration.GetConnectionString("DefaultConnection");
    
    List<ProjectViewModel> IProjectService.GetAll(string query) {
        var projects = context.Projects;
        var projectsViewModel = projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
            .ToList();

        return projectsViewModel;
    }

    ProjectDetailsViewModel IProjectService.GetOne(int id) {
        var project = context.Projects
            .Include(p => p.Client)
            .Include(p => p.Freelancer)
            .SingleOrDefault(p => p.Id == id);

        if (project == null) throw new Exception("Project not found");

        var projectDetailsViewModel = new ProjectDetailsViewModel(
            project.Id,
            project.Title,
            project.Description,
            project.TotalCost,
            project.StartedAt,
            project.FinishedAt,
            project.Client.Id,
            project.Freelancer.Id
        );

        return projectDetailsViewModel;
    }

    int IProjectService.Create(NewProjectInputModel inputModel) {
        
        var clientExists = context.Users.Any(u => u.Id == inputModel.IdClient);
        var freelancerExists = context.Users.Any(u => u.Id == inputModel.IdFreelancer);

        if (!clientExists) throw new Exception("Client ID not found.");
        if (!freelancerExists) throw new Exception("Freelancer ID not found.");
        
        var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);
        context.Projects.Add(project);
        context.SaveChanges(); // Persistir definitivamente
        return project.Id;
    }

    void IProjectService.CreateComment(CreateCommentInputModel inputModel) {
        var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.Project, inputModel.IdUser, inputModel.User);
        context.ProjectComments.Add(comment);
        context.SaveChanges();

    }

    void IProjectService.Delete(int id) {
        var project = context.Projects.SingleOrDefault(p => p.Id == id);
        if (project != null) {
            project.Cancel();
            context.SaveChanges();

        }
    }
    
    void IProjectService.Update(UpdateProjecInputtModel inputModel) {
        var project = context.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

        if (project == null) {
            throw new KeyNotFoundException($"Project with ID {inputModel.Id} not found.");
        }

        project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
        context.SaveChanges();

    }

    void IProjectService.Finish(int id) {
        var project = context.Projects.SingleOrDefault(p => p.Id == id);
        if (project != null) {
            project.Finish();
            context.SaveChanges();

        }
    }

    void IProjectService.Start(int id) {
        var project = context.Projects.SingleOrDefault(p => p.Id == id);
        
        if (project == null) return;
        
        project.Start();
        //context.SaveChanges();
        
        using var sqlConnection = new SqlConnection(_connectionString);
        sqlConnection.Open();
        const string query = "UPDATE Projects SET Status = @status, StartedAt = @startedAt WHERE Id = @id";
        sqlConnection.Execute(query,
            new { status = project.Status, startedAt = project.StartedAt, id = project.Id });

    }
}
