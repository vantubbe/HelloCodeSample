using HelloContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloBusiness
{
    public class HelloWorldBusiness : IHello
    {
        private const string helloWorld = "Hello World";

        public string HelloWorld()
        {
            return helloWorld;
        }
    }
}
