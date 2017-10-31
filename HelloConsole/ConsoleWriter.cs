using HelloContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloConsole
{
    public class ConsoleWriter : IWriteToExternal
    {
        public void Write(String content)
        {
            Console.WriteLine(content);
        }
    }
}
