using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Project_EL.Services;
using Microsoft.Extensions.Logging;

namespace Project_EL.Controllers
{
    [Controller]
    public class EnergyDataController : Controller
    {
        private readonly ILogger<EnergyDataController> _logger;

        public EnergyDataController(ILogger<EnergyDataController> logger)
        {
            _logger = logger;
        }

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
            Console.WriteLine("Entering UploadCSV");

            CsvDataService csvDataService = new();

            if (file == null || file.Length == 0)
            {
                Console.WriteLine("erroriin men22i");
                // Handle the error scenario where the file is not provided or is empty
                return View("Error", "No file selected or file is empty.");
            }

            try
            {
                var records = csvDataService.ParseCsvFile(file);
                // Log the number of records processed
                Console.WriteLine($"Processed {records.Count} EnergyDataPoints.");

                // Further processing or passing the data to the view
                return View("Results", records);
            }
            catch (Exception ex)
            {
                // Handle other exceptions'
                Console.WriteLine("erroriin meni");
                return View("Error", ex.Message);
            }
        }
    }
}
