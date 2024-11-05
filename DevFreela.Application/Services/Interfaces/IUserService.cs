using DevDreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces;

public interface IUserService
{
    List<UserViewModel> GetAll(string query);
    UserViewModel GetById(int id);
    int Create(NewUserInputModel inputModel);
    void Update(UpdateUserInputModel inputModel);
    void Delete(int id);
}