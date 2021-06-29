using TasteRestaurantApplication.DataAccess;
using TasteRestaurateApplication.DataAccess.Data.Repository.IRepository;
using TasteRestaurateApplication.DataAccess.Repository.IRepository;

namespace TasteRestaurateApplication.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            Category = new CategoryRepository(_applicationDbContext);
            FoodType = new FoodTypeRepository(_applicationDbContext);
        }
        public ICategoryRepository Category { get; private set; }

        public IFoodTypeRepository FoodType { get; private set; }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
