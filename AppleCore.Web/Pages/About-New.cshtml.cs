using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppleCore.Web.Pages
{
    public class AboutNewModel : PageModel
    {
        public string Message { get; set; }
        public string SubHeading { get; set; }
        
        public string AddressLineOne { get; set; }

        [Required]
        public string AddressLineTwo { get; set; }

        public void OnGet()
        {
            Message = "GET -> Your application description page. More copy.";
            SubHeading = "Some subheading";
            AddressLineOne = null;
        }

        public IActionResult OnPost(
            AboutNewModel aboutNewModel)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }

    public class AboutNewModelValidator : AbstractValidator<AboutNewModel>
    {
        public AboutNewModelValidator()
        {
            RuleFor(m => m.AddressLineOne)
                .NotEmpty().WithMessage("You're missing an address 1 entry.");
        }
    }
}
