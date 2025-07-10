using LaundryManager.Application.Contracts.Services;
using LaundryManager.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace LaundryManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _ArticleService;
        public ArticleController(IArticleService articleService)
        {
            _ArticleService = articleService;
        }

        [HttpGet("GetArticleTypes")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<ArticleTypeDto>))]
        public async Task<IActionResult> GetArticleTypes()
        {
            var articleTypes = await _ArticleService.GetArticleTypesAsync();
            return Ok(articleTypes);
        }
    }
}
