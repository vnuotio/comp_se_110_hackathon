using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Project_EL.Services
{
    public class CsvDataService
    {
        public List<Models.EnergyDatapointModel> ParseCsvFile(IFormFile fileStream)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                MissingFieldFound = null,
                BadDataFound = null
            };

            using (var stream = fileStream.OpenReadStream())
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Models.EnergyDatapointModel>().ToList();
                return records;
            }
        }
    }
}
