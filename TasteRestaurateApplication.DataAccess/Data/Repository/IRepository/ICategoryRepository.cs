using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TasteRestaurantApplication.Models.AllModels;

namespace TasteRestaurateApplication.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<SelectListItem> GetAllDropdownListForCategory();
        void Update(Category categoryToUpdate);
      

    }
}
