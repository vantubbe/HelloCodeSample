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
    public class BaseController : ApiController
    {
        protected IWriteToExternal Writer { get; set; }

        public BaseController()
        {
            Writer = GetWriter();
        }

        public BaseController(IWriteToExternal writer)
        {
            Writer = writer;
        }

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
