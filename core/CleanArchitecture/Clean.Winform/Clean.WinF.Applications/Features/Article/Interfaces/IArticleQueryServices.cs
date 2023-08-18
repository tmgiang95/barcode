using Clean.WinF.Applications.Features.Article.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.WinF.Applications.Features.Article.Interfaces
{
    public interface IBobbinQueryServices
    {
        Task<ArticleDto> GetArticleById(int id);
        Task<ArticleDto> GetArticleByName(string articleName);
        Task<ArticleDto> GetArticleByCode(string articleNumber);
        Task<ArticleDto> GetAllArticles();
        Task<IEnumerable<ArticleDto>> ListAllAsync();
    }
}
