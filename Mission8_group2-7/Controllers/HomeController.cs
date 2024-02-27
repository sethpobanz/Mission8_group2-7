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
        public IActionResult NameOfQuadPageHere()
        {
            ViewBag.Tasks = _repo.Tasks.FirstOrDefault();

            return View();
        }

        [HttpGet]
        public IActionResult NameOfFormPageHere() 
        { 
            return View(new NameOfModelHere());
        }

        [HttpPost]
        public IActionResult NameOfFormPageHere(NameOfModelHere response)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(response);
            }

            return RedirectToAction("NameOfQuadViewHere");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.ModelNameHere.Single(x => x.ModelPKHere == id);

            return View("NameOfFormPageHere", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(ModelNameHere updatedTask)
        {
            
            if (ModelState.IsValid)
            {
                _repo.AddTask(updatedTask);
            }

            return RedirectToAction("NameOfQuadViewHere");
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
