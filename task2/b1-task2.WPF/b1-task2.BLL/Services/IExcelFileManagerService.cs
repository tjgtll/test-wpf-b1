using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b1_task2.BLL.Services
{
    public interface IExcelFileManagerService
    {
        string ImportFile(Stream fileStream, string filePath, string fileName);
    }
}
