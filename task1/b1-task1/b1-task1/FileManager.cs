using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b1_task1
{
    public class FileManager
    {
        private string path;
        public FileManager(string path)
        {
            this.path = path;
        }

        public void CombineMultipleFilesIntoSingleFileWithDelete(string search)
        {
            int totalLinesRemoved = 0;
            string[] inputFilePaths = Directory.GetFiles(path);
           
            using (StreamWriter writer = new StreamWriter(path + "output.txt"))
            using (StreamWriter removed = new StreamWriter(path + "remove.txt"))
            {
                foreach (string filePath in inputFilePaths[0.. 100])
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        int linesRemoved = 0;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(search))
                            {
                                linesRemoved++;
                                totalLinesRemoved++;
                                removed.WriteLine(line);
                            }
                            else
                            {
                                writer.WriteLine(line);
                            }
                        }
                        Console.WriteLine($"Удалено {linesRemoved} строк содержащих '{search}' из '{filePath}'.");
                    }
                }
            }
            Console.WriteLine($"Всего удалено: {totalLinesRemoved}, удаленные сохраненны в remove.txt");
        }

        public void CreateFiles(int filesCount, int lineCount)
        {
            Console.WriteLine("{0} созданно из {1}",0,filesCount);
            var rdg = new RandomDataGenerator();
            for (int i = 1; i <= filesCount; i++)
            {
                string filePath = path + i + ".txt";

                using (StreamWriter sw = File.CreateText(filePath))
                {
                    for (int j = 0; j < lineCount; j++)
                    {
                        var date = rdg.RandomDateTime(-5).ToString("dd.MM.yyyy");
                        double randomDouble = rdg.RandomDouble();
                        string latinSymbols = rdg.RandomLatin();
                        string russianSymbols = rdg.RandomRussian();
                        int randomInt = rdg.RandomInt();
                        
                        sw.WriteLine($"{date}||{latinSymbols}||{russianSymbols}||{randomInt}||{randomDouble:0.00000000}");
                    }
                }
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine("{0} созданно из {1}",i,filesCount);
            }
        }


        public void ImportData(string filePath, DbContext dbContext)
        {
            using (var reader = new StreamReader(path + filePath))
            {
                var totalLines = File.ReadLines(path + filePath).Count();

                int importedCount = 0;
                string line;
                Console.WriteLine($"Импортированно {0} из {totalLines}",0);
                while ((line = reader.ReadLine()) != null)
                {
                    var fields = line.Split("||");

                    var newItem = new DateModel
                    {
                        DateTime = DateTime.ParseExact(fields[0], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                        Latin = fields[1],
                        Russian = fields[2],
                        RandomInt = int.Parse(fields[3]),
                        RandomDouble = double.Parse(fields[4])
                    };

                    var insertSql = $"INSERT INTO random_date (DateTimeRandom, LatinRandom, RussianRandom, IntRandom, DoubleRandom) " +
                                    $"VALUES ('{DateTime.ParseExact(fields[0], "dd.MM.yyyy", CultureInfo.InvariantCulture)}', " +
                                    $"'{fields[1]}', N'{fields[2]}', " +
                                    $"{int.Parse(fields[3])}, {double.Parse(fields[4])})";

                    dbContext.Database.ExecuteSqlRaw(insertSql);
                    importedCount++;
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine($"Импортированно {importedCount} из {totalLines}");
                }
                dbContext.SaveChanges();
                Console.WriteLine($"Импортированно: {importedCount}.");
            }
        }

    }
}
