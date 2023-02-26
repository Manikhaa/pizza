using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPizza.Models;
using RazorPagesPizza.Services;

namespace RazorPagesPizza.Pages
{
    public class PizzaModel : PageModel
    {
        public string GlutenFreeText(Pizza pizza)
        {
            return pizza.IsGlutenFree ? "Gluten Free": "Not Glutern Free";
        }
        public List<Pizza> pizzas = new();
        [BindProperty]
        public Pizza NewPizza { get; set; } = new();
        public void OnGet()
        {
            pizzas = PizzaService.GetAll();
        }
        
        public IActionResult onPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            PizzaService.Add(NewPizza);
            return RedirectToAction("Get");
        }
        
        public IActionResult onPostDelete(int id)
        {
            PizzaService.Delete(id);
            return RedirectToAction("Get");
        }
    }
}