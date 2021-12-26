using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabCoreD02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace LabCoreD02.Controllers
{
    public class employeeController : Controller
    {
        EmpContext db;
        public employeeController(EmpContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Employees.Include(n=>n.departments).ToList());
        }
        public IActionResult create()
        {
            SelectList st = new SelectList(db.Departments.ToList(), "id", "dept_name");
            ViewBag.departments = st;
            return View();
        }
        [HttpPost]
        public IActionResult create(Employee em)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(em);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                SelectList st = new SelectList(db.Departments.ToList(), "id", "dept_name");
                ViewBag.departments = st;
                return View();
            }
        }
        public IActionResult delete(int id)
        {
            Employee em = db.Employees.Where(n => n.id == id).SingleOrDefault();
            db.Employees.Remove(em);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult update(int id)
        {
            Employee em = db.Employees.Where(n => n.id == id).SingleOrDefault();
            SelectList st = new SelectList(db.Departments.ToList(), "id", "dept_name");
            ViewBag.departments = st;
            return View(em);

        }

        [HttpPost]
        public IActionResult update(Employee e)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                SelectList st = new SelectList(db.Departments.ToList(), "id", "dept_name");
                ViewBag.departments = st;
                return View();
            }
        }
    }
}
