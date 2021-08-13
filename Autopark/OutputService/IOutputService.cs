using System.Collections.Generic;

namespace Autopark.OutputService
{
    public interface IOutputService
    {
        List<List<string>> ReadLineCsvElements();
    }
}
