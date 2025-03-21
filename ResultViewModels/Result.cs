namespace MyResultViews;

public class ResultViewModels<T>
{
    public T Data { get; set; }
    public List<string> Erros { get; set; } = new ();

    public ResultViewModels  (T data)
    {
        Data = data;
    }
    public ResultViewModels (string error)
    {
        Erros.Add(error);
    }

    public ResultViewModels (T data, List<string> errors)
    {
        Data = data;
        Erros = errors;
    }
    public ResultViewModels(List<string> errors)
    {
        Erros = errors;
    }
} 