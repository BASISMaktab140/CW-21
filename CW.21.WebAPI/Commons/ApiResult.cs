namespace CW21.Presentation.Commons;

public class ApiResult<T>
{
    public bool IsSuccess { get; private set; }
    public T? Data { get; private set; }
    public string? Message { get; private set; }
    public int StatusCode { get; private set; }

    private ApiResult() { }

    public static ApiResult<T> Success(T data, string? message = null, int statusCode = 200)
    {
        return new ApiResult<T> { IsSuccess = true, Data = data, StatusCode = statusCode, Message = message };
    }

    public static ApiResult<T> Failure(string message, int statusCode = 400)
    {
        return new ApiResult<T> { IsSuccess = false, Message = message, StatusCode = statusCode };
    }
}

// non-generic version for Delete / void operations
public class ApiResult
{
    public bool IsSuccess { get; private set; }
    public string? Message { get; private set; }
    public int StatusCode { get; private set; }

    private ApiResult() { }

    public static ApiResult Success(string? message = null, int statusCode = 200)
        => new ApiResult { IsSuccess = true, StatusCode = statusCode, Message = message };

    public static ApiResult Failure(string message, int statusCode = 400)
        => new ApiResult { IsSuccess = false, Message = message, StatusCode = statusCode };
}