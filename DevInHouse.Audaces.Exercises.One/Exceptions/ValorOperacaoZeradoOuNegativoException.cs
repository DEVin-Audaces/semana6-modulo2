namespace DevInHouse.Audaces.Exercises.One.Exceptions;

public class ValorOperacaoZeradoOuNegativoException : Exception
{
    private const string Mensagem = "O valor da operação não pode ser zerado ou negativo.";
    
    public ValorOperacaoZeradoOuNegativoException() : base(
        Mensagem
    )
    {
    }

    public ValorOperacaoZeradoOuNegativoException(
        Exception innerException
    ) : base(
        Mensagem,
        innerException
    )
    {
    }
}