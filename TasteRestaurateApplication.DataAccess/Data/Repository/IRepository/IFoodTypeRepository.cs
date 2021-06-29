using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TasteRestaurantApplication.Models.AllModels;

namespace TasteRestaurateApplication.DataAccess.Repository.IRepository
{
    public interface IFoodTypeRepository : IRepository<FoodType>
    {
        IEnumerable<SelectListItem> GetAllDropdownListForFoodType();
        void Update(FoodType foodTypeToUpdate);
      

    }
}
