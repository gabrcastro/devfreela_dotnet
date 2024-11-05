using DevDreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infraestructure.Persistence;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Services.Implementations;

public class UserService(DevFreelaDbContext context, IConfiguration configuration) : IUserService
{
    
    private readonly string? _connectionString = configuration.GetConnectionString("DefaultConnection");

    public List<UserViewModel> GetAll(string query)
    {
        var users = context.Users;
        var usersViewModel = users.Select(u => new UserViewModel(u.Id, u.FullName, u.Email, u.BirthDate))
            .ToList();
        
        return usersViewModel;
    }

    public UserViewModel GetById(int id)
    {
        var user = context.Users.SingleOrDefault(u => u.Id == id);
        if (user == null) throw new Exception("User not found");
        var userViewModel = new UserViewModel(
            user.Id,
            user.FullName,
            user.Email,
            user.BirthDate
        );
        
        return userViewModel;
    }

    public int Create(NewUserInputModel inputModel)
    {
        var user = new User(inputModel.FullName, inputModel.Email, inputModel.Birthday);
        context.Users.Add(user);
        context.SaveChanges();
        return user.Id;
    }

    public void Update(UpdateUserInputModel inputModel)
    {
        var user = context.Users.SingleOrDefault(u => u.Id == inputModel.Id);
        if (user == null) return;
        
        user.Update(inputModel.FullName, inputModel.Email, inputModel.Birthday, inputModel.Active);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = context.Users.SingleOrDefault(u => u.Id == id);
        if (user == null) return;
        user.Disable();
        context.SaveChanges();
    }
}