namespace DevInHouse.Audaces.Exercises.One.Exceptions;

public class SaldoInsuficienteException : BaseContaException
{
    private const string Mensagem = "A conta {0} não possui saldo suficiente.";
    
    public SaldoInsuficienteException(string numeroConta) : base(
        string.Format(Mensagem, numeroConta),
        numeroConta
    )
    {
        NumeroConta = numeroConta;
    }

    public SaldoInsuficienteException(
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