using Havillah.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Havillah.Api.Controllers.Shared
{
    [Controller]
    public abstract class BaseController : ControllerBase
    {
        public Account Account => (Account)HttpContext.Items["Account"]!;
    }

}
