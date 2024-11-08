﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities {
    public class ProjectComment : BaseEntity {
        
        public ProjectComment(string content, int idProject, int idUser)
        {
            Content = content;
            IdProject = idProject;
            IdUser = idUser;
        }
        
        public ProjectComment(string content, int idProject, Project? project, int idUser, User? user) {
            Content = content;
            IdProject = idProject;
            Project = project;
            IdUser = idUser;
            User = user;
            CreatedAt = DateTime.Now;
        }

        public string Content { get; private set; }
        public int IdProject { get; private set; }
        public Project? Project { get; private set; }
        public int IdUser { get; private set; }
        public User? User { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
