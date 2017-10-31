using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloContracts
{
    /// <summary>
    /// Interface for writing to an external source.
    /// </summary>
    public interface IWriteToExternal
    {
        Boolean Write(string content);
    }

    /// <summary>
    /// Writer source types.
    /// </summary>
    public enum WriterType
    {
        Console = 0,
        Database = 1
    }
}
