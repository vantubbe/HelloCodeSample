using HelloContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloBusiness
{
    /// <summary>
    /// Business class for hello world.
    /// </summary>
    /// <seealso cref="HelloContracts.IHello" />
    public class HelloWorldBusiness : IHello
    {
        private const string helloWorld = "Hello World";

        /// <summary>
        /// Hello world method.
        /// </summary>
        /// <returns>Hello World string.</returns>
        public string HelloWorld()
        {
            return helloWorld;
        }
    }
}
