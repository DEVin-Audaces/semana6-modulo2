namespace DevInHouse.Audaces.Exercises.Six.Exceptions;

public class ValorSaqueMaiorLimiteException : Exception
{
    public const string MensagemPadrao = 
        "Valor de saque não pode ser maior que o limite da conta.";
    
    public ValorSaqueMaiorLimiteException() : base(MensagemPadrao)
    {
        
    }
}