namespace DevInHouse.Audaces.Exercises.One.Exceptions;

public class ValorSaqueAcimaLimiteException : BaseContaException
{
    private const string Mensagem = "Valor de saque acima do limite para a conta {0}.";
    
    public ValorSaqueAcimaLimiteException(string numeroConta) : base(
        string.Format(Mensagem, numeroConta),
        numeroConta
    )
    {
        NumeroConta = numeroConta;
    }

    public ValorSaqueAcimaLimiteException(
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