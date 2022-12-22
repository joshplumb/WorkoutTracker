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
        [HttpGet]
        public IActionResult Index()
        {
            WorkoutTrackerViewModel model = new WorkoutTrackerViewModel(_context);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int workoutId, string exerciseName, decimal weight, int intensity, int repetitions, string notes)
        {
            WorkoutTrackerViewModel model = new WorkoutTrackerViewModel(_context);
            WorkoutTrackerModel anythingyoulike = new(workoutId, exerciseName, weight, intensity, repetitions, notes);
            model.SaveWorkout(anythingyoulike);
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update(int iD)
        {
            WorkoutTrackerViewModel model = new(_context, iD);
            return View(model);
        }
        public IActionResult Delete(int workoutId)
        {
            WorkoutTrackerViewModel model = new(_context);
            if(workoutId > 0)
            {
                model.RemoveWorkout(workoutId);
            }
            return View("Index", model);
        }
    }
}
