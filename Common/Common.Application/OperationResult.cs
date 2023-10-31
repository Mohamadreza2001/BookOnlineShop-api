﻿namespace Common.Application
{
    public class OperationResult<TData>
    {
        public const string SuccessMessage = "Successfully done";
        public const string ErrorMessage = "Failed to finish the operation";

        public string Message { get; set; }
        public string Title { get; set; } = null;
        public OperationResultStatus Status { get; set; }
        public TData Data { get; set; }
        public static OperationResult<TData> Success(TData data)
        {
            return new OperationResult<TData>()
            {
                Status = OperationResultStatus.Success,
                Message = SuccessMessage,
                Data = data,
            };
        }
        public static OperationResult<TData> NotFound()
        {
            return new OperationResult<TData>()
            {
                Status = OperationResultStatus.NotFound,
                Title = "NotFound",
                Data = default(TData),
            };
        }
        public static OperationResult<TData> Error(string message = ErrorMessage)
        {
            return new OperationResult<TData>()
            {
                Status = OperationResultStatus.Error,
                Title = "Something went wrong",
                Data = default(TData),
                Message = message
            };
        }
    }
    public class OperationResult
    {
        public const string SuccessMessage = "Successfully done";
        public const string ErrorMessage = "Failed to finish the operation";
        public const string NotFoundMessage = "Not found";
        public string Message { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public OperationResultStatus Status { get; set; }

        public static OperationResult Error()
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Error,
                Message = ErrorMessage,
            };
        }
        public static OperationResult NotFound(string message)
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.NotFound,
                Message = message,
            };
        }
        public static OperationResult NotFound()
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.NotFound,
                Message = NotFoundMessage,
            };
        }
        public static OperationResult Error(string message)
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Error,
                Message = message,
            };
        }
        public static OperationResult Error(string message, OperationResultStatus status)
        {
            return new OperationResult()
            {
                Status = status,
                Message = message,
            };
        }
        public static OperationResult Success()
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Success,
                Message = SuccessMessage,
            };
        }
        public static OperationResult Success(string message)
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Success,
                Message = message,
            };
        }
    }


    public enum OperationResultStatus
    {
        Error = 10,
        Success = 200,
        NotFound = 404
    }
}
