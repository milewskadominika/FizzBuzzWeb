using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using FizzBuzzWeb.Forms;


namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public FizzBuzzForm FizzBuzz { set; get; }
        
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

     
        public String Result = "";

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Result = Logika();
                return Page();
            }
            return RedirectToPage("./Privacy");
        }

        public String Logika()
        {
            
            if(FizzBuzz.Number % 3 == 0)
            {
                Result += "Fizz";
            }
            if (FizzBuzz.Number % 5 == 0)
            {
                Result += "Buzz";
            }
            if (FizzBuzz.Number % 3 != 0 && FizzBuzz.Number % 5 != 0)
            {
                Result = $"Liczba: {FizzBuzz.Number} nie spełnia kryteriów FizzBuzz";
            }
            if (FizzBuzz.Number is not int || FizzBuzz.Number < 1 || FizzBuzz.Number > 1000)
            {
                Result = "";
            }

            return Result;
        }

    }
}