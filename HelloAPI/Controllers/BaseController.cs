using HelloBusiness;
using HelloContracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloAPI.Controllers
{
    /// <summary>
    /// Base hello controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class BaseController : ApiController
    {
        protected IWriteToExternal Writer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        public BaseController()
        {
            Writer = GetWriter();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public BaseController(IWriteToExternal writer)
        {
            Writer = writer;
        }

        /// <summary>
        /// Gets the writer specified in the config.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private IWriteToExternal GetWriter()
        {
            WriterType writeType = (WriterType)Enum.Parse(
                    typeof(WriterType), 
                    ConfigurationManager.AppSettings["WriterType"]);

            switch(writeType)
            {
                case WriterType.Console:
                    return new ConsoleWriter();
                case WriterType.Database:
                    throw new NotImplementedException();
                default:
                    return new ConsoleWriter();
            }
        }
    }
}
