using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TasteRestaurateApplication.DataAccess.Data.Repository.IRepository;

namespace TasteRestaurantApplication.Pages.Admin.FoodType
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public Models.AllModels.FoodType FoodType { get; set; }
        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult OnGet(int? id)
        {
            FoodType = new();
            if (id != null)
            {
                //Retrieved the user from the database!
                //if found
                FoodType = _unitOfWork.FoodType.GetFirstOrDefaultValue(c => c.Id == id);
                if (FoodType == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if(FoodType.Id == 0)
            {
                _unitOfWork.FoodType.Add(FoodType);
            }
            else
            {
                _unitOfWork.FoodType.Update(FoodType);
            }

            _unitOfWork.Save();
            return RedirectToPage("./Index");


        }
    }
}
