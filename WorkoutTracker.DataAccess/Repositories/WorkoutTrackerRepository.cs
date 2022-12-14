using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.DataAccess.Context;
using WorkoutTracker.DataAccess.Models;

namespace WorkoutTracker.DataAccess.Repositories
{
    public class WorkoutTrackerRepository
    {
        private readonly WorkoutTrackerDBContext _context;
        public WorkoutTrackerRepository(WorkoutTrackerDBContext context)
        {
            _context = context;
        }
        public int Create(WorkoutTrackerModel model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return model.WorkoutId;
        }
        public void Update(WorkoutTrackerModel model)
        {
            WorkoutTrackerModel existingExercise = _context.workoutTrackerModels.Find(model.WorkoutId)!;
            existingExercise.ExerciseName = model.ExerciseName;
            existingExercise.Weight = model.Weight;
            existingExercise.Repetitions = model.Repetitions;
            _context.SaveChanges();
        }
        public void Delete(int workoutId)
        {
            WorkoutTrackerModel existingExercise = _context.workoutTrackerModels.Find(workoutId)!;
            _context.Remove(existingExercise);
            _context.SaveChanges();
        }
        public List<WorkoutTrackerModel> GetAllExercises()
        {
            List<WorkoutTrackerModel> exerciseList = _context.workoutTrackerModels.ToList();
            return exerciseList;
        }
        public WorkoutTrackerModel GetById(int id)
        {
            WorkoutTrackerModel exerciseFinder = _context.workoutTrackerModels.Find(id)!;
            return exerciseFinder;
        }
    }
}
