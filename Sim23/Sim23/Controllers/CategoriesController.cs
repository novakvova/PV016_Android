using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sim23.Data;
using Sim23.Data.Entites;
using Sim23.Helpers;
using Sim23.Models;

namespace Sim23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppEFContext _appEFContext;

        public CategoriesController(IMapper mapper, AppEFContext appEFContext)
        {
            _mapper = mapper;
            _appEFContext = appEFContext;
        }
        [HttpGet("list")]
        public async Task<IActionResult> Get()
        {
            var model = await _appEFContext.Categories
                .Where(x=>x.IsDeleted==false)
                .OrderBy(x=>x.Priority)
                .Select(x=>_mapper.Map<CategoryItemViewModel>(x))
                .ToListAsync();
           
            return Ok(model);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CategoryCreateItemVM model)
        {
            try
            {
                var cat = _mapper.Map<CategoryEntity>(model);
                cat.Image = ImageWorker.SaveImage(model.ImageBase64);
                await _appEFContext.Categories.AddAsync(cat);
                await _appEFContext.SaveChangesAsync();
                return Ok(_mapper.Map<CategoryItemViewModel>(cat));

            }catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
