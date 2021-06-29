using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using TasteRestaurantApplication.DataAccess;
using TasteRestaurantApplication.Models.AllModels;
using TasteRestaurateApplication.DataAccess.Repository;
using TasteRestaurateApplication.DataAccess.Repository.IRepository;

namespace TasteRestaurateApplication.DataAccess.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategoryRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<SelectListItem> GetAllDropdownListForCategory()
        {
            return _applicationDbContext.Category.Select(v => new SelectListItem()
            {
                Text = v.Name,
                Value = v.Id.ToString()
            });
        }

        public void Update(Category categoryToUpdate)
        {
            var findObjFromDb = _applicationDbContext.Category.Find(categoryToUpdate.Id);
            if(findObjFromDb != null)
            {
                findObjFromDb.Name = categoryToUpdate.Name;
                findObjFromDb.DisplayOrder = categoryToUpdate.DisplayOrder;

                _applicationDbContext.SaveChanges();
            }
        }
    }
}
