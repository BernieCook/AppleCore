using CuttingEdge.Conditions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppleCore.Web.Pages.SubFolder
{
    public class TakeParameterModel : PageModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        
        public void OnGet(
            int id,
            string firstName,
            string surname)
        {
            Condition.Requires(id, "id").IsGreaterThan(0);
            Condition.Requires(firstName, "firstName").IsNotNullOrWhiteSpace();

            Id = id;
            FirstName = firstName;
            Surname = surname;

            // Great article: https://www.learnrazorpages.com/razor-pages/routing
        }
    }
}
