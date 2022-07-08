namespace DevInHouse.Audaces.Exercises.Six.Exceptions;

public class ValorSaqueMaiorSaldoException : Exception
{
    public const string MensagemPadrao = "Valor de saque não pode ser maior que o existente no saldo.";
    
    public ValorSaqueMaiorSaldoException() : base(MensagemPadrao)
    {
        
    }
}