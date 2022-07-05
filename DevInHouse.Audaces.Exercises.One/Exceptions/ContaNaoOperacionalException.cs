namespace DevInHouse.Audaces.Exercises.One.Exceptions;

public class ContaException : BaseContaException
{
    private const string Mensagem = "A conta {0} não está operacional.";
    
    public ContaException(string numeroConta) : base(
        string.Format(Mensagem, numeroConta),
        numeroConta
    )
    {
        NumeroConta = numeroConta;
    }

    public ContaException(
        string numeroConta, 
        Exception innerException
    ) : base(
        string.Format(Mensagem, numeroConta),
        numeroConta,
        innerException
    )
    {
        NumeroConta = numeroConta;
    }
}