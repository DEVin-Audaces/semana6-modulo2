using DevInHouse.Audaces.Exercises.Ten.Exceptions;

namespace DevInHouse.Audaces.Exercises.Ten.Domain;

public class Compromisso
{
    private const int HorasLimiteDuracao = 4; 
    
    public DateOnly Dia { get; }
    public TimeOnly Horario { get; }
    public TimeSpan Duracao { get; }
    public string Nome { get; }
    public string Descricao { get; }

    public Compromisso(DateOnly dia, TimeOnly horario, TimeSpan duracao, string nome, string descricao)
    {
        Dia = dia;
        Horario = horario;
        Nome = nome;
        Descricao = descricao;

        if (duracao > TimeSpan.FromHours(HorasLimiteDuracao))
        {
            throw new DuracaoInvalidaException(duracao);
        }
        
        Duracao = duracao;
    }
}