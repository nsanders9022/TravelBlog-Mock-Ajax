using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelBlog.Controllers
{
    public class PeopleController : Controller
    {
        private TravelBlogContext db = new TravelBlogContext();
        public IActionResult Index()
        {
            return View(db.People.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisPerson = db.People.FirstOrDefault(people => people.PersonId == id);
            ViewBag.Experiences = db.People
                .Include(person => person.PeopleExperiences)
                .ThenInclude(peopleExperiences => peopleExperiences.Experience)
                .Where(person => person.PersonId == id).ToList();
            return View(thisPerson);
        }

        public IActionResult Create()
        {
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "Name");
            ViewBag.ExperienceId = new SelectList(db.Experiences, "ExperienceId", "Title", "Description");
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(Person person)
        //{
        //    db.People.Add(person);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult NewPerson (string newName)
        {
            Person newPerson = new Person(newName);
            db.People.Add(newPerson);
            db.SaveChanges();
            return Json(Url.Action("Index", "People"));
        }

        public IActionResult Edit(int id)
        {
            var thisPerson = db.People.FirstOrDefault(people => people.PersonId == id);
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name");
            return View(thisPerson);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            db.Entry(person).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisPerson = db.People.FirstOrDefault(people => people.PersonId == id);
            return View(thisPerson);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPerson = db.People.FirstOrDefault(people => people.PersonId == id);
            db.People.Remove(thisPerson);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}