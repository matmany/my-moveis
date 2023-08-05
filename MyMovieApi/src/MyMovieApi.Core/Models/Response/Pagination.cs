using MyMovieApi.Core.Models.Filters;

namespace MyMovieApi.Core.Models.Response
{
public class Pagination<T> : Pagination where T : class
    {
        public T Entity { get; set; }
        public Pagination()
        {
        }

        public Pagination(T entity)
        {
            Entity = entity;
        }

        public IEnumerable<T> SetInformations(IEnumerable<T> list, BaseRequestFilter filter)
        {
            Page = (int)(filter.Page == null ? 1 : filter.Page);
            Total = list.Count();
            PageCount = 1;
            if (filter.Take < Total)
                PageCount = (int)(Total / filter.Take);

            return list.Skip(filter.Skip).Take(filter.Take).ToList();
        }
    }

    public class Pagination
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int PageCount { get; set; }
    }
}