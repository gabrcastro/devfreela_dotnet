using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DevFreela.Core.Entities;

namespace DevFreela.Infraestructure.Persistence {

    public class DevFreelaDbContext {

        public DevFreelaDbContext() {
            Projects = new List<Project> {
                new Project("Meu projeto 1", "Descricao 1", 1, 1, 11000),
                new Project("Meu projeto 2", "Descricao 2", 1, 1, 10000),
                new Project("Meu projeto 3", "Descricao 3", 1, 1, 2000),
                new Project("Meu projeto 4", "Descricao 4", 1, 1, 35000),
            };

            Users = new List<User> {
                new User("User 1", "user1@email", new DateTime(1990, 1, 1)),
                new User("User 2", "user2@email", new DateTime(1990, 1, 1)),
                new User("User 3", "user3@email", new DateTime(1990, 1, 1)),
            };

            Skills = new List<Skill> {
                new Skill("C#"),
                new Skill(".NET"),
                new Skill("Angular"),

            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}
