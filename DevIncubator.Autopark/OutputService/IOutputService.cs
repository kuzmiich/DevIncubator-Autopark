using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Class;

namespace DevIncubator.Autopark.OutputService
{
    public interface IOutputService
    {
        List<List<string>> ReadListListCsvElements();
    }
}
