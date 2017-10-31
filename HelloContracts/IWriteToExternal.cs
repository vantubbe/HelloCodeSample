using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloContracts
{
    public interface IWriteToExternal
    {
        Boolean Write(string content);
    }

    public enum WriterType
    {
        Console = 0,
        Database = 1
    }
}
