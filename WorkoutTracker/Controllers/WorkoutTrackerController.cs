using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.DataAccess.Context;
using WorkoutTracker.DataAccess.Models;
using WorkoutTracker.Models;

namespace WorkoutTracker.Controllers
{
    public class WorkoutTrackerController : Controller
    {
        private readonly WorkoutTrackerDBContext _context;
        public WorkoutTrackerController(WorkoutTrackerDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SubmitNewWorkout(int workoutId, string exerciseName, int weight, int reps)
        {
            // we create a viewmodel object because it is used, in this design pattern, to access the database, but it needs a 
            // context object in order to do its job of actually accessing said database for CRUD operations
            WorkoutTrackerViewModel vModel = new WorkoutTrackerViewModel(_context);
            WorkoutTrackerModel model = new();
            // once we have both objects that we need, i use the model object to store the information from the parameter variables
            // and set the model fields equal to each respective variable
            model.WorkoutId = workoutId;
            model.ExerciseName = exerciseName;
            model.Weight = weight;
            model.Repetitions = reps;
            vModel.SaveWorkout(model);
            // it would be great at this point to give some indication of a successful crud operation to the user, 
            // as of now it just returns them to the default view where they put their information in
            return View();
        }
        public IActionResult AllWorkouts()
        {
            return View();
        }
        public IActionResult DisplayAllWorkouts()
        {
            // create a viewmodel object to access its database methods and
            // feed it the context object so that its database methods work

            WorkoutTrackerViewModel vModel = new WorkoutTrackerViewModel(_context);
            //getallworkouts does not require any parameters(workoutId),
            //it simply returns a list of all workouts in the database
            vModel.GetAllWorkouts();

            // use list from getallworkouts to display to the view

            return View(vModel);
        }
       
    }
}
