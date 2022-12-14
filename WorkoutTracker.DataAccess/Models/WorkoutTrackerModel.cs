using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.DataAccess.Models
{
    public class WorkoutTrackerModel
    { 
        public int WorkoutId { get; set; }
        public string ExerciseName { get; set; } = "";
        public decimal Weight { get; set; }
        public int Intensity { get; set; }
        public int Repetitions { get; set; }
        public string Notes { get; set; } = "";
    }
}
