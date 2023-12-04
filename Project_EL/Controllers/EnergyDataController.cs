using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Http;

namespace Project_EL.Controllers
{
    public class EnergyDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadCSV(IFormFile file)
        {

            Services.CsvDataService csvDataService = new();

            if (file == null || file.Length == 0)
            {
                // Handle the error scenario where the file is not provided or is empty
                return View("Error", "No file selected or file is empty.");
            }

            try
            {
                var records = csvDataService.ParseCsvFile(file);
                // Further processing or passing the data to the view
                return View("Results", records);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                return View("Error", ex.Message);
            }
        }
    }
}
