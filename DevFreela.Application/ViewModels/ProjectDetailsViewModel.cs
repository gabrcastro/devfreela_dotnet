using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDreela.Application.ViewModels {
    public class ProjectDetailsViewModel {
        public ProjectDetailsViewModel(int id, string title, string description, decimal totalCost, DateTime? startedAt, DateTime? finisheddAt) {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinisheddAt = finisheddAt;
        }

        public ProjectDetailsViewModel(int id, string title, string description, decimal? totalCost, DateTime? startedAt, DateTime finishedAt) {
            Id = id;
            Title = title;
            Description = description;
            TotalCost1 = totalCost;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinisheddAt { get; private set; }
        public decimal? TotalCost1 { get; }
        public DateTime FinishedAt { get; }
    }
}
