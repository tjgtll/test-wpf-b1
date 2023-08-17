using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.IO;
using b1_task1;
using Microsoft.EntityFrameworkCore;

string path = @"test\";
int filesCount = 100;
int lineCount = 100000;
string menuMes =    $"1 - создать {filesCount} файлов c {lineCount} случайными строками\n" +
                    $"2 - обьеденить все файлы в один файл(output.txt)\n" +
                    $"3 - имортировать значения из remove.txt в таблицу\n";
var fileManager = new FileManager(path);

while (true)
{
    Console.WriteLine(menuMes);
    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("Вы выбрали вариант 1.");
            fileManager.CreateFiles(filesCount, lineCount);
            break;
        case "2":
            Console.WriteLine("Вы выбрали вариант 2. Введите строку для поиска. " +
                "\n(При пустом вводе все строки попадут в remove.txt)");
            var input = Console.ReadLine();
            fileManager.CombineMultipleFilesIntoSingleFileWithDelete(input);
            break;
        case "3":
            Console.WriteLine("Вы выбрали вариант 3.");
            using (var dbContext = new RandomDbContext())
            {
                fileManager.ImportData("remove.txt", dbContext);
            }
            break;
        case "4":
            Console.WriteLine("Вы выбрали вариант 4.");
            return;
        default:
            Console.Clear();
            Console.WriteLine("Некорректный выбор.");
            break;
    }
}