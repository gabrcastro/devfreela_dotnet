using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels {
    internal class SkillViewModel {
        public SkillViewModel(int id, string description) {
            Id = id;
            Description = description;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
    }
}
