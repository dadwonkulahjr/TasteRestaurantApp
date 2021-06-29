using System;
using TasteRestaurateApplication.DataAccess.Repository.IRepository;

namespace TasteRestaurateApplication.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IFoodTypeRepository FoodType { get; }
        void Save();
    }
}
