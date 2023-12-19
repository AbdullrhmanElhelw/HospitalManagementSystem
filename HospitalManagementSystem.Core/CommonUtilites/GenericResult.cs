namespace HospitalManagementSystem.Core.CommonUtilites;

public class GenericResult<T>(bool isSuccess, T data, Error error) where T : class
{
    public bool IsSuccess { get; } = isSuccess;
    public T Data { get; } = data;
    public Error Error { get; } = error;

    public static GenericResult<T> Success(T data) => new(true, data,default!);
    public static GenericResult<T> Failure(Error error) => new(false, default!, error);
}
