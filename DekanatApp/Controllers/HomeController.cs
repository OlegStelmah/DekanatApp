using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DekanatApp.Data;
using DekanatApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using DekanatApp.Models;

namespace DekanatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly Kpi_StudentsContext _context;

        public HomeController()
        {
            _context = new Kpi_StudentsContext();
        }

        public IActionResult Index()
        {
            return RedirectToAction("Contracts");
        }
  
        public async Task<IActionResult> Contracts(int? studentId)
        {
            ViewData["Message"] = "Your Contracts page.";
       
            ViewBag.Students = _context.Persons.Select(e => new ListItem { Id = e.StudentId, Text = $"{e.Name} {e.Surname}"}).ToList();

            var list = new List<SqlParameter>
            {
                new SqlParameter("@StudentId", SqlDbType.Int) {Value = studentId ?? -1},

            };

            var models = await _context.ExecuteStoredProcedureAsync<ContractModel>("GetStudentsContracts", list);

            return View(models);
        }

        public async Task<IActionResult> TeachPlans(int? facultyId)
        {
            ViewData["Message"] = "Your Teach Plans page.";

            ViewBag.Faculties = _context.Faculties
                .Select(e => new ListItem {Id = e.FacultyId, Text = e.FacultyName}).ToList();

            var list = new List<SqlParameter>
            {
                new SqlParameter("@FacultyId", SqlDbType.Int) {Value = facultyId ?? -1},

            };

            var models = await _context.ExecuteStoredProcedureAsync<TeachPlanModel>("GetTeachPlans", list);

            return View(models);
        }

        public async Task<IActionResult> Diplomas(int? groupId)
        {
            ViewData["Message"] = "Your Diplomas page.";

            ViewBag.Groups = _context.Groups
                .Select(e => new ListItem { Id = e.GroupId, Text = e.GroupCode }).ToList();

            var list = new List<SqlParameter>
            {
                new SqlParameter("@GroupId", SqlDbType.Int) {Value = groupId ?? -1},

            };

            var models = await _context.ExecuteStoredProcedureAsync<DiplomasMarksModel>("GetDiplomas", list);

            return View(models);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
