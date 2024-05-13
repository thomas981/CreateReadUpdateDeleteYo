using CRUDOpdracht.Data;
using CRUDOpdracht.Models.Domain;
using CRUDOpdracht.Models.DTO;
using CRUDOpdracht.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOpdracht.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository articleRepository;

        public ArticlesController(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(CreateArticleRequestDto request)
        {
            // Map DTO to Domain Model
            var article = new Article
            {
                // Id gets created automatically
                Sku = request.Sku,
                Name = request.Name,
                Price = request.Price
            };

            // Use method in Repository for abstraction
            await articleRepository.CreateAsync(article);

            // Domain model to DTO
            var response = new ArticleDto
            {
                Id = article.Id,
                Sku = article.Sku,
                Name = article.Name,
                Price = article.Price

            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> IndexArticles()
        {
            var articles = await articleRepository.GetAllAsync();

            var response = articles.Select(article => new ArticleDto()
            {
                Id = article.Id,
                Sku = article.Sku,
                Name = article.Name,
                Price = article.Price
            }).ToList();

            return Ok(response);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> IndexArticleById(Guid id)
        {
            var article = await articleRepository.GetByIdAsync(id);

            if (article == null)
            {
                return NotFound(new { Message = $"Article {id} not found" });
            }
            var response = new ArticleDto
            {
                Id = article.Id,
                Sku = article.Sku,
                Name = article.Name,
                Price = article.Price
            };

            return Ok(response);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateArticle(Guid id, UpdateArticleRequestDto request)
        {
            var article = new Article
            {
                Sku = request.Sku,
                Name = request.Name,
                Price = request.Price
            };

            article = await articleRepository.UpdateAsync(id, article);

            var response = new ArticleDto
            {
                Id = article.Id,
                Sku = article.Sku,
                Name = article.Name,
                Price = article.Price
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteArticle(Guid id)
        {
            var article = await articleRepository.DeleteAsync(id);

            if (article == null)
            {
                return NotFound(new { Message = "Not found" });
            }
            return Ok();

        }
    }
}
