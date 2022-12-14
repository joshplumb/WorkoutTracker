using WorkoutTracker.DataAccess.Context;
using WorkoutTracker.DataAccess.Models;
using WorkoutTracker.DataAccess.Repositories;

namespace WorkoutTracker.Models
{
    public class WorkoutTrackerViewModel
    {
        private readonly WorkoutTrackerRepository _Repo;
        public List<WorkoutTrackerModel> WorkoutList { get; set; }
        public WorkoutTrackerModel CurrentWorkout { get; set; }
        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; } = "";
        public WorkoutTrackerViewModel(WorkoutTrackerDBContext context)
        {
            _Repo = new WorkoutTrackerRepository(context);
            WorkoutList = GetAllWorkouts()!;
            CurrentWorkout = WorkoutList.FirstOrDefault()!;
        }
        public WorkoutTrackerViewModel(WorkoutTrackerDBContext context, int workoutId)
        {
            _Repo = new WorkoutTrackerRepository(context);
            WorkoutList = GetAllWorkouts()!;
            CurrentWorkout = workoutId > 0 ? GetWorkout(workoutId) : new WorkoutTrackerModel();
        }
        public void SaveWorkout(WorkoutTrackerModel model)
        {
            if(model.WorkoutId > 0)
            {
                _Repo.Update(model);
            }
            else
            {
                model.WorkoutId = _Repo.Create(model);
            }
            WorkoutList = GetAllWorkouts()!;
            CurrentWorkout = GetWorkout(model.WorkoutId);
        }
        public void RemoveWorkout(int workoutId)
        {
            _Repo.Delete(workoutId);
            WorkoutList = GetAllWorkouts()!;
            CurrentWorkout = WorkoutList.FirstOrDefault()!;
        }
        public WorkoutTrackerModel GetWorkout(int workoutId)
        {
            return _Repo.GetById(workoutId);
        }
        public List<WorkoutTrackerModel>? GetAllWorkouts()
        {
            return _Repo.GetAllExercises();
        }
    }
}
