using CRUDOpdracht.Data;
using CRUDOpdracht.Models.Domain;
using CRUDOpdracht.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CRUDOpdracht.Repositories.Implementation
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ArticleRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Article> CreateAsync(Article article)
        {
            await dbContext.Articles.AddAsync(article);
            await dbContext.SaveChangesAsync();

            return article;

        }
        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            var articles = await dbContext.Articles.ToListAsync();

            return articles;

        }
        public async Task<Article> GetByIdAsync(Guid id)
        {
            var article = await dbContext.Articles.FirstOrDefaultAsync(n => n.Id == id);

            return article;

        }

        public async Task<Article?> UpdateAsync(Guid id, Article article)
        {
            var articleSingle = await dbContext.Articles.FirstOrDefaultAsync(n => n.Id == id);

            if (articleSingle == null) 
            {
                return null;
            }

            articleSingle.Sku = article.Sku;
            articleSingle.Name = article.Name;
            articleSingle.Price = article.Price;

            await dbContext.SaveChangesAsync();

            return articleSingle;
        }

        public async Task<Article?> DeleteAsync(Guid id)
        {
            var articleSingle = await dbContext.Articles.FirstOrDefaultAsync(n => n.Id == id);

            if (articleSingle == null)
            {
                return null;
            }

            dbContext.Articles.Remove(articleSingle);
            await dbContext.SaveChangesAsync();

            return articleSingle;
        }

    }
}
