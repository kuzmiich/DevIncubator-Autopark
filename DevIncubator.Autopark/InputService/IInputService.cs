using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Class;

namespace DevIncubator.Autopark.InputService
{
    public interface IInputService
    {
        void WriteEnumerable<T>(IEnumerable<T> enumerable);
    }
}
