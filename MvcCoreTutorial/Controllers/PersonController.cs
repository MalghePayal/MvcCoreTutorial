using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using MvcCoreTutorial.Models.Domain;

namespace MvcCoreTutorial.Controllers
{
    public class PersonController : Controller
    {
        private readonly DatabaseContext _ctx;
        public PersonController(DatabaseContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddPerson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {

            if (!ModelState.IsValid)
            {
                return View();

            }
            try
            {
                _ctx.Person.Add(person);
                _ctx.SaveChanges();
                TempData["msg"] = " Added Successfully !!!";
                return RedirectToAction("AddPerson");
            }
            catch (Exception)
            {
                TempData["msg"] = " Could Not Added !!!";
                return View();
                throw;
            }


        }

        public IActionResult DisplayPersons()
        {

            var Persons = _ctx.Person.ToList();
            return View(Persons);

        }

        public IActionResult EditPerson(int id )
        {
            try
            {
                var person = _ctx.Person.Find(id);
                if (person!=null)
                {
                    return View(person);
                }

            }
            catch (Exception ex)
            {

               
            }
            return RedirectToAction("DisplayPersons");
        }
        [HttpPost]
        public IActionResult EditPerson(Person person)
        {

            if (!ModelState.IsValid)
            {
                return View();

            }
            try
            {
                _ctx.Person.Update(person);
                _ctx.SaveChanges();
                TempData["msg"] = " Updated Successfully !!!";
                return RedirectToAction("DisplayPersons");
            }
            catch (Exception ex)
            {
                TempData["msg"] = " Could Not Update !!!";
                return View();
               
            }


        }
        public IActionResult DeletePerson(int id)
        {
            try
            {
                var person = _ctx.Person.Find(id);
                if (person != null)
                {
                    return View(person);
                }

            }
            catch (Exception ex)
            {


            }
            return RedirectToAction("DisplayPersons");
        }
        [HttpPost]
        public IActionResult DeletePerson(Person person)
        {

            if (!ModelState.IsValid)
            {
                return View();

            }
            try
            {
                _ctx.Person.Remove(person);
                _ctx.SaveChanges();
                TempData["msg"] = " Deleted Successfully !!!";
                return RedirectToAction("DisplayPersons");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could Not Delete !!!";
                return View();

            }


        }
    }
}
