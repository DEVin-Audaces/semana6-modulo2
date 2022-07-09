using System.Runtime.InteropServices;

namespace DevInHouse.Audaces.Exercises.Ten.Domain;

public class Agenda
{
    public string Nome { get; set; }
    public List<Compromisso> Compromissos { get; set; }

    public Agenda(string nome)
    {
        Nome = nome;
        Compromissos = new List<Compromisso>();
    }

    public void AdicionarCompromisso(Compromisso compromisso)
    {
        Compromissos.Add(compromisso);
    }

    public List<Compromisso> ObterCompromissosPorDia(DateOnly dataFiltragem)
    {
        return Compromissos
            .Where(c => c.Dia == dataFiltragem)
            .OrderBy(c => c.Horario)
            .ToList();
    }

    public List<Compromisso> ObterCompromissosHojeFuturos()
    {
        var dataHoraAtual = DateTime.Now;
        var dataAtual = DateOnly.FromDateTime(dataHoraAtual);
        var horaAtual = TimeOnly.FromDateTime(dataHoraAtual);
        
        return Compromissos
            .Where(c => c.Dia == dataAtual)
            .Where(c => c.Horario > horaAtual)
            .OrderBy(c => c.Horario)
            .ToList();
    }
}