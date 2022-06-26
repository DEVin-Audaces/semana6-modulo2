namespace DevInHouse.Audaces.Exceptions.Examples;

public class ExemploException : Exception
{
    public string ExemploProp { get; set; }
    
    public ExemploException(string message, string valor) : base(message)
    {
        ExemploProp = valor;
    }
}