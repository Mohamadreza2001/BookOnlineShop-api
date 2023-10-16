using Common.Query.Filter;

namespace Common.Query
{
    public class QueryFilter<TResponse, TParam> : IQuery<TResponse> where TResponse : BaseFilter where TParam : BaseFilterParam
    {
        public TParam FilterParams { set; get; }
        public QueryFilter(TParam filterParam)
        {
            FilterParams = filterParam;
        }
    }
}
