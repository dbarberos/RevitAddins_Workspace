namespace {{Namespace}}.Helpers;

/// <summary>
/// Wrapper para resultados de operaciones que pueden fallar de forma controlada.
/// </summary>
public record OperationResult<T>(bool Success, T Value = default, string ErrorMessage = null)
{
    public static OperationResult<T> Ok(T value) => new(true, value);
    public static OperationResult<T> Fail(string error) => new(false, ErrorMessage: error);
    public static OperationResult<T> Fail(Exception ex) => new(false, ErrorMessage: ex.Message);
}

/// <summary>
/// VersiÃ³n sin valor de retorno.
/// </summary>
public record OperationResult(bool Success, string ErrorMessage = null)
{
    public static OperationResult Ok() => new(true);
    public static OperationResult Fail(string error) => new(false, error);
    public static OperationResult Fail(Exception ex) => new(false, ex.Message);
}
