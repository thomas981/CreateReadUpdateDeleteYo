using CRUDOpdracht.Models.Domain;

namespace CRUDOpdracht.Repositories.Interface
{
    public interface IArticleRepository
    {
        Task<Article> CreateAsync(Article article);

        Task<IEnumerable<Article>> GetAllAsync();

        Task<Article> GetByIdAsync(Guid id);

        Task<Article?> UpdateAsync(Guid id, Article article);

        Task<Article?> DeleteAsync(Guid id);

    }
}
