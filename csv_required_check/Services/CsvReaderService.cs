using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;


namespace csv_required_check.Services
{
    public class CsvReaderService
    {
        public bool ValidateAndCountNonNullFields(string filename, Stream data, out int totalRecords, out int nonNullFieldCount)
        {
            totalRecords = 0;
            nonNullFieldCount = 0;

            try
            {
                var resourceType = GetResourceName(filename);
                var reader = new StreamReader(data);
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();

                    
                    var recordType = Type.GetType($"Common.CsvModels.{resourceType}_CSV, Common");
                    var records = csv.GetRecords(recordType);

                    var validationResults = new List<ValidationResult>();
                    foreach (var record in records)
                    {
                        totalRecords++;
                        var context = new ValidationContext(record, serviceProvider: null, items: null);
                        bool isValid = Validator.TryValidateObject(record, context, validationResults, true);

                        if (!isValid)
                        {
                            foreach (var validationResult in validationResults)
                            {
                                Console.WriteLine(validationResult.ErrorMessage);
                            }
                        }
                        else
                        {
                            var properties = record.GetType().GetProperties();
                            foreach (var prop in properties)
                            {
                                var value = prop.GetValue(record);
                                if (value != null && !string.IsNullOrEmpty(value.ToString()))
                                {
                                    nonNullFieldCount++;
                                }
                            }
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private string GetResourceName(string filename)
        {
            
            return Path.GetFileNameWithoutExtension(filename).Split('_')[0];
        }
    }
}