using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace RecipeDatabase.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult FAQ(string id)
        {
            var idParameterText = " The id parameter was not supplied.";
            if (!string.IsNullOrEmpty(id))
            {
                idParameterText = " The id parameter was supplied.";
                if (id == "carrot")
                {
                    idParameterText = " The id parameter was supplied, and it's value was carrot.";
                }
            }
            ViewBag.ParameterText = idParameterText;
            return View();
        }
    }
}
