﻿using DevFreela.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces {
    internal interface ISkillService {
        List<SkillViewModel> GetAll();
    }
}
