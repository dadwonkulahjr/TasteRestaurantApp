using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using TasteRestaurantApplication.DataAccess;
using TasteRestaurantApplication.Models.AllModels;
using TasteRestaurateApplication.DataAccess.Repository;
using TasteRestaurateApplication.DataAccess.Repository.IRepository;

namespace TasteRestaurateApplication.DataAccess.Data.Repository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public FoodTypeRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<SelectListItem> GetAllDropdownListForFoodType()
        {
            return _applicationDbContext.FoodType.Select(v => new SelectListItem()
            {
                Text = v.Name,
                Value = v.Id.ToString()
            });
        }
        public void Update(FoodType foodTypeToUpdate)
        {
            var findObjFromDb = _applicationDbContext.FoodType.Find(foodTypeToUpdate.Id);
            if (findObjFromDb != null)
            {
                findObjFromDb.Name = foodTypeToUpdate.Name;
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
