using HelloContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloBusiness
{
    /// <summary>
    /// Writer for the console.
    /// </summary>
    /// <seealso cref="HelloContracts.IWriteToExternal" />
    public class ConsoleWriter : IWriteToExternal
    {
        /// <summary>
        /// Writes the specified content to the console.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>Whether the content was written successfully.</returns>
        public bool Write(string content)
        {
            Console.WriteLine(content);
            return true;
        }
    }
}
