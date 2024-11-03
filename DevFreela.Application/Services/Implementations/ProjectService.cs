using DevDreela.Application.InputModels;
using DevDreela.Application.Services.Interfaces;
using DevDreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDreela.Application.Services.Implementations {
    public class ProjectService : IProjectService {

        private readonly DevFreelaDbContext _context;
        public ProjectService(DevFreelaDbContext context) {
            _context = context;
        }

        int IProjectService.Create(NewProjectInputModel inputModel) {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);
            _context.Projects.Add(project);

            return project.Id;
        }

        void IProjectService.CreateComment(CreateCommentInputModel inputModel) {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);
            _context.ProjectComments.Add(comment);
        }

        void IProjectService.Delete(int id) {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project != null) {
                project.Cancel();
            }
        }

        void IProjectService.Finish(int id) {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project != null) {
                project.Finish();
            }
        }

        List<ProjectViewModel> IProjectService.GetAll(string query) {
            var projects = _context.Projects;
            var projectsViewModel = projects
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();

            return projectsViewModel;
        }

        ProjectDetailsViewModel IProjectService.GetOne(int id) {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt
            );

            return projectDetailsViewModel;
        }

        void IProjectService.Start(int id) {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project != null) {
                project.Start();
            }
        }

        void IProjectService.Update(UpdateProjecInputtModel inputModel) {
            var project = _context.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            if (project == null) {
                throw new KeyNotFoundException($"Project with ID {inputModel.Id} not found.");
            }

            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
        }
    }
}
