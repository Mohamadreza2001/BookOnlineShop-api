using Common.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Common.AspNetCore
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected ApiResult CommandResult(OperationResult result)
        {
            return new ApiResult()
            {
                IsSuccess = result.Status == OperationResultStatus.Success,
                MetaData = new()
                {
                    Message = result.Message,
                    AppStatusCode = result.Status.MapOperationStatus()
                },
            };
        }

        protected ApiResult<TData> CommandResult<TData>(OperationResult<TData> result,
            HttpStatusCode statusCode = HttpStatusCode.OK, string locationUrl = null)
        {
            bool isSuccess = result.Status == OperationResultStatus.Success;
            if (isSuccess)
            {
                HttpContext.Response.StatusCode = (int)statusCode;
                if (!string.IsNullOrWhiteSpace(locationUrl))
                {
                    HttpContext.Response.Headers.Add("location", locationUrl);
                }
            }

            return new ApiResult<TData>()
            {
                IsSuccess = isSuccess,
                Data = isSuccess ? result.Data : default!,
                MetaData = new()
                {
                    Message = result.Message,
                    AppStatusCode = result.Status.MapOperationStatus()
                },
            };
        }

        protected ApiResult<TData> QueryResult<TData>(TData result)
        {
            return new ApiResult<TData>()
            {
                IsSuccess = true,
                Data = result,
                MetaData = new()
                {
                    Message = "Successfully done",
                    AppStatusCode = AppStatusCode.Success,
                },
            };
        }
    }
}
