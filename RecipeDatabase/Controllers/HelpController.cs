using Microsoft.AspNetCore.Mvc;

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
            return Content("Hello! Here is the FAQ." + idParameterText);
        }
    }
}
