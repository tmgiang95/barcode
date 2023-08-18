using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Applications.Features.Article.DTOs;

namespace Clean.WinF.Applications.Features.Article.Interfaces
{
    public interface IBobbinCommandServices
    {
        Task<ArticleDto> CreateNewArticle(ArticleDto addedArticle);
        Task<ArticleDto> UpdateArticle(ArticleDto updatedArticle);
        Task<ArticleDto> DeleteArticle(ArticleDto deletedArticle);
    }
}
