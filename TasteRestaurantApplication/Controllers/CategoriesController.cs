using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasteRestaurateApplication.DataAccess.Data.Repository.IRepository;

namespace TasteRestaurantApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.Category.GetAll() });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var findObjFromDb = _unitOfWork.Category.GetFirstOrDefaultValue(u => u.Id == id);

            if(findObjFromDb == null)
            {
                return Json(new { success = false, message = "Error in deleting the data." });
            }

            _unitOfWork.Category.Remove(findObjFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }


    }
}
