
using System.Globalization;
using DevInHouse.Audaces.Exercises.Ten.Domain;

while (true)
{
    
    // Criação
    var agenda = new Agenda("Agenda Audaces");
    
    var dataString = Console.ReadLine();

    var data = DateOnly.FromDateTime(DateTime.Parse(dataString));
    
    var horarioString = Console.ReadLine();
    var horario = TimeOnly.FromDateTime(DateTime.Parse(horarioString));
    
    var duracao = TimeSpan.Parse("02:00:00");

    var compromisso = new Compromisso(
        data,
        horario,
        duracao,
        "Compromisso 1",
        "Compromisso 1"
    );
    agenda.AdicionarCompromisso(compromisso);
    
    
    
    // Exibição
    foreach (var com in agenda.ObterCompromissosHojeFuturos())
    {
        Console.WriteLine("Compromisso:");
        Console.WriteLine($"{com.Nome}");
        Console.WriteLine($"{com.Dia}");
        Console.WriteLine($"{com.Horario.ToLongTimeString()}");
        Console.WriteLine($"{com.Duracao}");
    }
}