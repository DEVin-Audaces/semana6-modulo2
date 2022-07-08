namespace DevInHouse.Audaces.Exercises.Six.Exceptions;

public class ContaNaoOperacionalException : Exception
{
    private const string MensagemPadrao = "Conta {0} não operacional";
    
    public string NumeroConta { get; set; }

    public ContaNaoOperacionalException(string numeroConta) 
        : base(string.Format(MensagemPadrao, numeroConta))
    {
        NumeroConta = numeroConta;
    }
}