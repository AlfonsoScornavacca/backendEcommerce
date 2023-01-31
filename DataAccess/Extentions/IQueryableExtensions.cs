using DataAccess.Entities;
using System.Xml;

namespace DataAccess.Extentions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int PageSize, int PageNumber) =>
            PageSize > 0 && PageNumber > 0
                ? query.Skip((PageNumber - 1) * PageSize).Take(PageSize)
                : query.Take(10);
        public static IQueryable<Product> FilterByName(this IQueryable<Product> query, string? name) =>
        string.IsNullOrEmpty(name) 
            ? query 
            : query.Where(s => s.Name.Contains(name));
    }
}
