using HelloContracts;
using System;
using System.Configuration;
using System.Web.Http;

namespace HelloAPI.Controllers
{
    public class HelloController : BaseController
    {
        private IHello _helloBusiness;

        public HelloController()
            : base()
        {
            _helloBusiness = new HelloBusiness.HelloWorldBusiness();
        }

        public HelloController(IWriteToExternal writer)
            : base(writer)
        {
            _helloBusiness = new HelloBusiness.HelloWorldBusiness();
        }

        public HelloController(IHello helloBusiness, IWriteToExternal writer)
            : base(writer)
        {
            _helloBusiness = helloBusiness;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(_helloBusiness.HelloWorld());
        }

        [HttpPost]
        public IHttpActionResult Post()
        {
            bool isWrittenSuccess = false;

            try
            {
                isWrittenSuccess = Writer.Write(_helloBusiness.HelloWorld());
            }
            catch(Exception ex)
            {
                return this.InternalServerError(ex);
            }

            if (isWrittenSuccess)
                return this.Ok();
            else
                return this.BadRequest("Error writing to external.");
        }
    }
}
