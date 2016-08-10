using Microsoft.AspNetCore.Mvc;
using TestProject.Models;

namespace WebApplication.Controllers
{
    public abstract class BaseController : Controller
    {
         protected ChinookSqlServer2008DbContext _chinookContext;
        protected BaseController(ChinookSqlServer2008DbContext chinookContext)
        {
             _chinookContext = chinookContext;
        }
    }
}