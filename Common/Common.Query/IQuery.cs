using Common.Query.Filter;
using MediatR;

namespace Common.Query
{
    public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : class
    {

    }

    public class QueryFilter<TResponse, TParam> : IQuery<TResponse> where TResponse : BaseFilter where TParam : BaseFilterParam
    {
        public TParam FilterParams { set; get; }
        public QueryFilter(TParam filterParam)
        {
            FilterParams = filterParam;
        }
    }
}
