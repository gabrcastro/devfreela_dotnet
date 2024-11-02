using DevDreela.Application.InputModels;
using DevDreela.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDreela.Application.Services.Interfaces {
    public interface IProjectService {
        List<ProjectViewModel> GetAll(string query);
        ProjectDetailsViewModel GetOne(int id);
        int Create(NewProjectInputModel inputModel);
        void Update(UpdateProjecInputtModel inputModel);
        void Delete(int id);
        void CreateComment(CreateCommentInputModel inputModel);
        void Start(int id);
        void Finish(int id);
    }
}
