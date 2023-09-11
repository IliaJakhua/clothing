using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using clothing.Models;
using clothing.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace clothing.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly APIcontext _context;
        public ValuesController(APIcontext context)
        {
            _context = context;
        }



        [HttpGet]
        
        public JsonResult Create(Clothe clothes)
        {

            var existing = _context.Clothes.FirstOrDefault(x => x.BrandName == clothes.BrandName && x.ClotheTypes == clothes.ClotheTypes);
            if (existing == null)
            {
                _context.Clothes.Add(clothes);
            }
            else
            {
                existing.Quantity += clothes.Quantity;
            }

            _context.SaveChanges();
            return new JsonResult(Ok(clothes));

        }
            
        [HttpGet]
        public IActionResult Get([FromQuery] ClothesSearchModel model)
        {

            var filteredClothes = _context.Clothes
                .Where(x =>
                    (model.ClotheTypes == null || model.ClotheTypes == x.ClotheTypes) &&
                    (model.BrandName == null || model.BrandName == x.BrandName)
                )
                .ToList();


            return new JsonResult(Ok(filteredClothes));

        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] ClothesDeleteModel delete)
        {
            var existing = _context.Clothes.FirstOrDefault(x => x.BrandName == delete.BrandName && x.ClotheTypes == delete.ClotheTypes);
            if (existing != null)
            {
                existing.Quantity-= delete.Quantity;
                if(existing.Quantity <= 0)
                {
                    _context.Clothes.Remove(existing);
                }
                _context.SaveChanges();
                return new JsonResult(Ok());
            }
            return new JsonResult(Ok("Not correct info"));
        }



    }
}
