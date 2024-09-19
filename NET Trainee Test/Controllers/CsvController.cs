using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Linq;
using NET_Trainee_Test.Data;
using NET_Trainee_Test.Models;

namespace NET_Trainee_Test.Controllers
{
    public class CsvController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CsvController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
          
            var people = _context.People.ToList();
            return View(people);
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                   
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,  
                        MissingFieldFound = null  
                    };

                    using (var csv = new CsvReader(reader, config))
                    {
                        var records = csv.GetRecords<Person>().ToList();
                        _context.People.AddRange(records);
                        _context.SaveChanges();
                    }
                }
            }

           
            var updatedPeople = _context.People.ToList();
            return View(updatedPeople);
        }

       
        [HttpPost]
        public IActionResult Edit(int id, string field, string value)
        {
            var person = _context.People.Find(id);
            if (person != null)
            {
                switch (field)
                {
                    case "name":
                        person.Name = value;
                        break;
                    case "dateOfBirth":
                        if (DateTime.TryParse(value, out DateTime dob))
                            person.DateOfBirth = dob;
                        break;
                    case "phone":
                        person.Phone = value;
                        break;
                    case "salary":
                        if (decimal.TryParse(value, out decimal salary))
                            person.Salary = salary;
                        break;
                    case "married":
                        if (bool.TryParse(value, out bool married))
                            person.Married = married;
                        break;
                }
                _context.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Запис не знайдено" });
        }

        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var person = _context.People.Find(id);
            if (person != null)
            {
                _context.People.Remove(person);
                _context.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Запис не знайдено" });
        }
    }
}
