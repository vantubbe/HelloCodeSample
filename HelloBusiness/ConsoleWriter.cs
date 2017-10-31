using HelloContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloBusiness
{
    public class ConsoleWriter : IWriteToExternal
    {
        public bool Write(string content)
        {
            Console.WriteLine(content);
            return true;
        }
    }
}
