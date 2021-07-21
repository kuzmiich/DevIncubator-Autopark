using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autopark.Entity.Models;

namespace Autopark.InputService
{
    public interface IInputService
    {
        void WriteEnumerable<T>(IEnumerable<T> enumerable);
    }
}
