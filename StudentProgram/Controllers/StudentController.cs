using StudentProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentProgram.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentDBHandle dBHandle = new StudentDBHandle();
            ModelState.Clear();
            return View(dBHandle.GetStudents());
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel student)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid) {
                    StudentDBHandle dBHandle = new StudentDBHandle();

                    if (dBHandle.AddStudent(student)) {
                        ViewBag.Message= "STUDENT DETAILS ADDED SUCCESSFULLY.";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            StudentDBHandle dBHandle = new StudentDBHandle();
            return View(dBHandle.GetStudents().Find( student => student.id==id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentModel student)
        {
            try
            {
                // TODO: Add update logic here
                StudentDBHandle dBHandle = new StudentDBHandle();
                dBHandle.UpdateDetails(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                StudentDBHandle dBHandle = new StudentDBHandle();
                if (dBHandle.DeleteStudent(id)) {
                    ViewBag.AlertMsg = "STUDENT REMOVE SUCCESSFULLY.";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
