using DevDreela.Application.InputModels;
using DevDreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces;

public interface IProjectService 
{
    List<ProjectViewModel> GetAll(string query);
    ProjectDetailsViewModel GetOne(int id);
    int Create(NewProjectInputModel inputModel);
    void Update(UpdateProjecInputtModel inputModel);
    void Delete(int id);
    void CreateComment(CreateCommentInputModel inputModel);
    void Start(int id);
    void Finish(int id);
}
