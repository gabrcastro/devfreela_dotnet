using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevDreela.Application.InputModels {
    public class CreateCommentInputModel {
        public string Content {  get; set; }
        public int IdProject { get; set; }
        public Project? Project { get; set; }
        public int IdUser { get; set; }
        public User? User { get; set; }
    }
}
