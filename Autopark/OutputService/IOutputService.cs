using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autopark.Entity.Models;

namespace Autopark.OutputService
{
    public interface IOutputService
    {
        List<List<string>> ReadLineCsvElements();
    }
}
