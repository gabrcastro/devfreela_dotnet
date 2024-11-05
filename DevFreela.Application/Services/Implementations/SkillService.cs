using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Services.Implementations {
    internal class SkillService(DevFreelaDbContext context, IConfiguration configuration) : ISkillService
    {
        private readonly string? _connectionString = configuration.GetConnectionString("DefaultConnection");

        public List<SkillViewModel> GetAll()
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open(); // open a connection
            const string query = "SELECT Id, Description FROM Skills";
            return sqlConnection.Query<SkillViewModel>(query).ToList();
            /* USANDO EF ----
             var skills = context.Skills;
             var skillsViewModel = skills
                 .Select(s => new SkillViewModel(s.Id, s.Description))
                 .ToList();

             return skillsViewModel; */
        }
    }
}
