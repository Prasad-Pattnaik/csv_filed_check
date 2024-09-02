using csv_required_check.Services;
using System;
using System.IO;


namespace csv_required_check
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new CsvReaderService();
            int totalRecords;
            int nonNullFieldCount;

            using (var fileStream = new FileStream("Files//data.csv", FileMode.Open))
            {
                bool isValid = processor.ValidateAndCountNonNullFields("ResourceType1_File.csv", fileStream, out totalRecords, out nonNullFieldCount);

                Console.WriteLine($"Total records: {totalRecords}");
                Console.WriteLine($"Total non-null fields: {nonNullFieldCount}");
                Console.WriteLine($"Records are valid: {isValid}");
            }
        }
    }
}