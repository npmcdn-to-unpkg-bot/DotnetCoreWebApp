using System;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public abstract class BaseController : Controller
    {
    
        ///Accepts a delegate of type IActionResult and invokes it. A IAction result is then returned.
        ///Sibbling Controller classes which return a IActionResult should wrap all their body code in this method so that all controller exceptions can be handled in one central place: here. There should not                       
        protected IActionResult ExecuteExceptionsHandledActionResult(Func<IActionResult> codeToExecute)
        {
            IActionResult result = null;
            try
            {
                result = codeToExecute.Invoke();
            }catch(Exception ex)
            {                
                string error = Error.BuildExceptionDetail(ex, new StringBuilder()).ToString();
                //Log it
            }
            return View();
        } 

        ///Accepts a delegate of type Task<IActionResult> and invokes it. A IAction result is then returned.
        ///Sibbling Controller classes which return a Task<IActionResult> should wrap all their body code in this method so that all controller exceptions can be handled in one central place: here. There should not                       
        protected async Task<IActionResult> ExecuteExceptionsHandledAsyncActionResult(Func<Task<IActionResult>> codeToExecute)
        {
            IActionResult result;
            try
            {
                result = await codeToExecute.Invoke();
            }catch(Exception ex)
            {                
                string error = Error.BuildExceptionDetail(ex, new StringBuilder()).ToString();
                //Log it
            }
            return View();
        } 
    }
}