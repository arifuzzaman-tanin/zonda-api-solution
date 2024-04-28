using Zonda.Application.Common.Bases;

namespace Zonda.Application.Common.Mappings
{
    public static class MappingExtensions
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageIndex, int pageSize)
           => PaginatedList<TDestination>.CreateAsync(queryable, pageIndex, pageSize);
    }
}
