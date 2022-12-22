using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.DataAccess.Models;

namespace WorkoutTracker.DataAccess.Context
{
    public class WorkoutTrackerDBContext : DbContext
    {
        public WorkoutTrackerDBContext()
        {
                
        }
        public WorkoutTrackerDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<WorkoutTrackerModel> workoutTrackerModels { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WorkoutTrackerModel>(
                entity =>
                {
                    entity.HasKey(e => e.WorkoutId);
                    entity.Property(e => e.WorkoutId);

                    entity.Property(e => e.ExerciseName);
                    entity.Property(e => e.Weight);
                    entity.Property(e => e.Repetitions);
                    entity.Property(e => e.Intensity);
                    entity.Property(e => e.Notes).IsRequired(required:false);
                }
                );
        }
    }
}
