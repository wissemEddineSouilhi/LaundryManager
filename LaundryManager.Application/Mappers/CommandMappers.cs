using LaundryManager.Application.Dtos;
using LaundryManager.Domain.Entities;

namespace LaundryManager.Application.Mappers
{
    public static class CommandMappers
    {
        public static List<CommandDto> MapCommandsToDtos(IEnumerable<Command> currentUserCommands, IList<ArticleType> articleTypes)
        {
            return currentUserCommands.Select(
                            c => new CommandDto
                            {
                                Id = c.Id,
                                Reason = c.Reason,
                                Comment = c.Comment,
                                StatusName = c.Status?.Name!,
                                Articles = c.Articles.Select(a => new ArticleDto
                                {
                                    Name = a.Name,
                                    Description = a.Description,
                                    ArticleTypeId = a.ArticleTypeId,
                                    ArticleTypeName = articleTypes.Single(at => at.Id == a.ArticleTypeId).Name,
                                    Quantity = a.Qauntity,
                                }).ToList(),
                            }).ToList();
        }
    }
}
