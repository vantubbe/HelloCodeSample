using HelloContracts;
using System;
using System.Configuration;
using System.Web.Http;

namespace HelloAPI.Controllers
{
    /// <summary>
    /// Main hello controller
    /// </summary>
    /// <seealso cref="HelloAPI.Controllers.BaseController" />
    public class HelloController : BaseController
    {
        private IHello _helloBusiness;

        /// <summary>
        /// Initializes a new instance of the <see cref="HelloController"/> class.
        /// </summary>
        public HelloController()
            : base()
        {
            _helloBusiness = new HelloBusiness.HelloWorldBusiness();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HelloController"/> class.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public HelloController(IWriteToExternal writer)
            : base(writer)
        {
            _helloBusiness = new HelloBusiness.HelloWorldBusiness();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HelloController"/> class.
        /// </summary>
        /// <param name="helloBusiness">The hello business.</param>
        /// <param name="writer">The writer.</param>
        public HelloController(IHello helloBusiness, IWriteToExternal writer)
            : base(writer)
        {
            _helloBusiness = helloBusiness;
        }

        /// <summary>
        /// Gets .
        /// </summary>
        /// <returns></returns>
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
