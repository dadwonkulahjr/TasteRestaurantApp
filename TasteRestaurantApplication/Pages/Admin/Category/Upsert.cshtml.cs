using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TasteRestaurateApplication.DataAccess.Data.Repository.IRepository;

namespace TasteRestaurantApplication.Pages.Admin.Category
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public Models.AllModels.Category Category { get; set; }
        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult OnGet(int? id)
        {
            Category = new();
            if (id != null)
            {
                //Retrieved the user from the database!
                //if found
                Category = _unitOfWork.Category.GetFirstOrDefaultValue(c => c.Id == id);
                if (Category == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if(Category.Id == 0)
            {
                _unitOfWork.Category.Add(Category);
            }
            else
            {
                _unitOfWork.Category.Update(Category);
            }

            _unitOfWork.Save();
            return RedirectToPage("./Index");


        }
    }
}
