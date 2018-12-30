using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalRecall.Core.Interfaces
{
    public interface IFileRepository
    {
        string CreateDirectory(string name, string path = "");
        string CreateFile(string path, string name);
    }
}
