namespace HospitalManagementSystem.Core.CommonUtilites;

public class Result
{
    public bool IsSuccess { get; }
    public Error Error { get; }

    public Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, default);
    public static Result Failure(Error error) => new(false, error);
}
