namespace DevInHouse.Audaces.Exercises.Ten.Exceptions;

public class DuracaoInvalidaException : Exception
{
    private const string Mensagem = "A duração {0} do compromisso não pode ser maior que 4 horas.";

    public TimeSpan Duracao { get; private set; } 
    
    public DuracaoInvalidaException(TimeSpan duracao) : base(
        string.Format(Mensagem, duracao)
    )
    {
        Duracao = duracao;
    }
}