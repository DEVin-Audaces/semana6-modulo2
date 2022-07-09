using DevInHouse.Audaces.Exercises.Ten.Domain;
using DevInHouse.Audaces.Exercises.Ten.Exceptions;
using Xunit;

namespace DevInHouse.Audaces.Exercises.Ten.Tests;

public class AgendaTests
{
    private Agenda CriarAgendaPadrao()
    {
        return new Agenda("Agenda Audaces");
    } 
    
    private void InserirRegistrosPadroes(Agenda agenda)
    {
        var compromissos = new[]
        {
            new Compromisso(
                new DateOnly(2022, 7, 8),
                new TimeOnly(20, 30, 0),
                TimeSpan.FromHours(1),
                "Compromisso 1",
                "Compromisso 1"
            ),
            new Compromisso(
                new DateOnly(2022, 7, 8),
                new TimeOnly(22, 30, 0),
                TimeSpan.FromHours(2),
                "Compromisso 2",
                "Compromisso 2"
            ),
            new Compromisso(
                new DateOnly(2022, 7, 9),
                new TimeOnly(9, 30, 0),
                TimeSpan.FromHours(1),
                "Compromisso 3",
                "Compromisso 3"
            ),
            new Compromisso(
                new DateOnly(2022, 7, 15),
                new TimeOnly(12, 00, 0),
                TimeSpan.FromHours(1),
                "Compromisso 4",
                "Compromisso 4"
            ),
            new Compromisso(
                new DateOnly(2022, 12, 31),
                new TimeOnly(21, 00, 0),
                TimeSpan.FromHours(3),
                "Compromisso 5",
                "Compromisso 5"
            ),
        };

        foreach (var compromisso in compromissos)
        {
            agenda.AdicionarCompromisso(
                compromisso
            );
        }
    } 
    
    [Fact]
    public void Deveria_Criar_Compromisso()
    {
        // configuração
        var dia = DateOnly.FromDateTime(DateTime.Now);
        var horario = new TimeOnly(21, 0, 0);
        var duracao = TimeSpan.FromHours(2);
        var nome = "Apresentação do projeto";
        var descricao = "Apresentação do projeto";
        
        // execução
        var compromisso = new Compromisso(
            dia,
            horario,
            duracao,
            nome,
            descricao
        );
        var agenda = CriarAgendaPadrao();
        agenda.AdicionarCompromisso(compromisso);
        
        // validação
        Assert.All(
            agenda.Compromissos,
            a => Assert.Equal(a.Nome, compromisso.Nome)
        );
        Assert.NotNull(compromisso);
        Assert.Equal(dia, compromisso.Dia);
        Assert.Equal(horario, compromisso.Horario);
        Assert.Equal(duracao, compromisso.Duracao);
    }

    [Fact]
    public void Nao_Deveria_Criar_Compromisso_Com_Duracao_Invalida()
    {
        Assert.Throws<DuracaoInvalidaException>(() =>
        {
            // configuração
            var dia = DateOnly.FromDateTime(DateTime.Now);
            var horario = new TimeOnly(21, 0, 0);
            var duracao = TimeSpan.FromHours(5);
            var nome = "Apresentação do projeto";
            var descricao = "Apresentação do projeto";

            // execução
            var compromisso = new Compromisso(
                dia,
                horario,
                duracao,
                nome,
                descricao
            );
            var agenda = CriarAgendaPadrao();
            agenda.AdicionarCompromisso(compromisso);
        });
    }
    
    [Theory]
    [InlineData(8, 7, 2022)]
    [InlineData(20, 7, 2022)]
    [InlineData(28, 7, 2022)]
    public void Deveria_Obter_Compromisso_Por_Dia(int dia, int mes, int ano)
    {
        // configuração
        var dataFiltragem = new DateOnly(ano, mes, dia);
        var agenda = CriarAgendaPadrao();
        InserirRegistrosPadroes(agenda);

        // execução
        var listaPorDia = agenda.ObterCompromissosPorDia(dataFiltragem);

        // validação
        Assert.All(
            listaPorDia,
            a => Assert.Equal(a.Dia, dataFiltragem)
        );
    }

    [Fact]
    public void Deveria_Obter_Compromisso_Futuros_Do_Dia()
    {
        // configuração
        var dataHoraAtual = DateTime.Now;
        var agenda = CriarAgendaPadrao();
        
        //compromisso passado
        var compromissoPassadoNome = "Compromisso passado"; 
        agenda.AdicionarCompromisso(new Compromisso(
            DateOnly.FromDateTime(dataHoraAtual),
            TimeOnly.FromDateTime(dataHoraAtual).Add(-TimeSpan.FromHours(1)),
            TimeSpan.FromHours(2),
            compromissoPassadoNome,
            compromissoPassadoNome
        ));
        
        //compromisso futúro
        var compromissoFuturoNome = "Compromisso futuro"; 
        agenda.AdicionarCompromisso(new Compromisso(
            DateOnly.FromDateTime(dataHoraAtual),
            TimeOnly.FromDateTime(dataHoraAtual).Add(TimeSpan.FromHours(1)),
            TimeSpan.FromHours(2),
            compromissoFuturoNome,
            compromissoFuturoNome
        ));
        
        // execução
        var listaFuturosCompromissos = agenda.ObterCompromissosHojeFuturos();

        // validação
        Assert.Single(listaFuturosCompromissos);
        Assert.All(
            listaFuturosCompromissos,
            c => Assert.Equal(c.Nome, compromissoFuturoNome)
        );
    }
}