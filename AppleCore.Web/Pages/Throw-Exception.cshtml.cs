using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppleCore.Web.Pages
{
    public class ThrowExceptionModel : PageModel
    {
        public void OnGet()
        {
            throw new ArgumentNullException();
        }
    }
}
