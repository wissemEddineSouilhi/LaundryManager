using LaundryManager.Application.Contracts.Services;
using LaundryManager.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace LaundryManager.API.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<List<ArticleTypeDto>>> GetArticleTypes()
        {
            var articleTypes = await _ArticleService.GetArticleTypesAsync();
            return Ok(articleTypes);
        }
    }
}
