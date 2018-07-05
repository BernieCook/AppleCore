using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppleCore.Web.Pages
{
    public class FormPostModel : PageModel
    {
        public string Message { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public void OnGet()
        {
            Message = "Ready to post?";
        }
        public IActionResult OnPost(
            FormPostModel formPostModel)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
    
    public class FormPostModelValidator : AbstractValidator<FormPostModel>
    {
        public FormPostModelValidator()
        {
            RuleFor(m => m.FirstName)
                .NotEmpty().WithMessage("Please enter a value for the first name.");
        }
    }
}
