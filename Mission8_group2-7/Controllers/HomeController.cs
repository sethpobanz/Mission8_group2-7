using Microsoft.AspNetCore.Mvc;
using Mission8_group2_7.Models;
using System.Diagnostics;

namespace Mission8_group2_7.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }

        [HttpGet]
        public IActionResult Quadrant()
        {
            ViewBag.Tasks = _repo.Tasks.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult Form() 
        { 
            return View(new TaskModel());
        }

        [HttpPost]
        public IActionResult Form(TaskModel response)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(response);
            }

            return RedirectToAction("Quadrant");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Tasks.Single(x => x.Id == id);

            return View("Form", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(TaskModel updatedTask)
        {
            
            if (ModelState.IsValid)
            {
                _repo.AddTask(updatedTask);
            }

            return RedirectToAction("Quadrant");
        }



        public IActionResult Index()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
