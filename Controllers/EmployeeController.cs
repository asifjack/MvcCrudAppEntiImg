using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MvcCrudApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCrudApp.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext dbContext;
        public  IHostingEnvironment Environment;
        public EmployeeController(ApplicationDbContext dbContext, IHostingEnvironment Environment)
        {
            this.Environment = Environment;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
           List<Employee> employee = dbContext.Employees.ToList();
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        /*
                [HttpPost]
                public IActionResult Create(Employee emp)
                {
                   // Employee emp = new Employee();
                    string dbPath = string.Empty;
                    string Name = Request.Form["Name"];
                    string Email = Request.Form["Email"];
                    string Mobile = Request.Form["Mobile"];
                    string Address = Request.Form["Address"];

                    var files = Request.Form.Files;
                    if (files.Count> 0)
                    {
                        var file = files[0];
                        string data = Environment.WebRootPath;
                        string fullpath = Path.Combine(data,"images",files[0].FileName);
                        dbPath = "images/" + files[0].FileName;
                        FileStream st = new FileStream(fullpath,FileMode.Create);
                        files[0].CopyTo(st);
                    }
                    Employee emps = new Employee()
                    {
                        Name = Name,
                        Email = Email,
                        Mobile = Mobile,
                        Address = Address
                    };
                    emps.Image = dbPath;
                    if (ModelState.IsValid)
                    {
                        dbContext.Employees.Add(emps);
                        dbContext.SaveChanges();
                        return RedirectToAction("index");
                    }
                    else
                    {
                        return View(emp);
                    }
                }*/





        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            string dbPath = string.Empty;
            var files = Request.Form.Files;
            if (files.Count > 0)
            {
                var file = files[0];
                string data = Environment.WebRootPath;
                string fullpath = Path.Combine(data, "images", files[0].FileName);
                dbPath = "images/"+ files[0].FileName;
                FileStream st = new FileStream(fullpath, FileMode.Create);
                files[0].CopyTo(st);
            }
            emp.Image = dbPath;
            if (ModelState.IsValid)
            {
                dbContext.Employees.Add(emp);
                dbContext.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                return View(emp);
            }
        }


        //[HttpPost]
        //public IActionResult Create(Employee emp)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        dbContext.Employees.Add(emp);
        //        dbContext.SaveChanges();
        //        return RedirectToAction("index");
        //    }
        //    else 
        //    {
        //        return View(emp);
        //    }
        //}

        public IActionResult Update(int id)
        {
            var DbCheckEmp =  dbContext.Employees.SingleOrDefault(e => e.Id==id);
            return View(DbCheckEmp);
        }
        [HttpPost]
        public IActionResult Update(Employee emp)
        {
            dbContext.Employees.Update(emp);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        //Delete A Record 
        public IActionResult Delete(int id) 
        {
            var emplCheck =  dbContext.Employees.SingleOrDefault(e=>e.Id==id);
            if (emplCheck !=null)
            {
                dbContext.Employees.Remove(emplCheck);
                dbContext.SaveChanges();
               return RedirectToAction("Index"); 
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }


    }
}

















