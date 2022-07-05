using DevInHouse.Audaces.Exercises.One.Domain;

var contas = new []
{
    new Conta("1234", 5000, 1000, true),
    new Conta("3456", 15000, 5000, false),
    new Conta("7890", 80, 500, true),
};

while (true)
{
    Console.WriteLine("Selecione a conta: ");
    for (var i = 1; i < contas.Length + 1; i++)
    {
        var item = contas.ElementAt(i - 1);
        
        Console.WriteLine($"{i} - Conta {item.Numero}");
    }
    
    var indiceValido = int.TryParse(Console.ReadLine(), out var indiceSelecionado);

    if (!indiceValido || indiceSelecionado > 3)
    {
        Console.WriteLine($"Indice inválido {Environment.NewLine}");
        continue;
    }

    var contaSelecionada = contas.ElementAt(indiceSelecionado - 1);
    
    Console.WriteLine($"{Environment.NewLine}Selecione a operação (1 - Consultar Limite, 2 - Sacar, 3 - Depositar): ");
    
    var operacaoValida = int.TryParse(Console.ReadLine(), out var operacaoSelecionada);
    
    if (!operacaoValida || operacaoSelecionada > 3)
    {
        Console.WriteLine($"Operação inválido {Environment.NewLine}");
        continue;
    }

    try
    {
        switch (operacaoSelecionada)
        {
            case 1:
                Console.WriteLine($"Saldo: {contaSelecionada.ObterSaldo()}");
                break;
            case 2:
                Console.WriteLine("Informe um valor para saque:");
                var valorValido = decimal.TryParse(Console.ReadLine(), out var valorSaque);

                if (!valorValido)
                {
                    Console.WriteLine($"Valor inválido {Environment.NewLine}");
                    continue;
                }
                
                contaSelecionada.Sacar(valorSaque);
                
                Console.WriteLine($"Novo saldo após saque: {contaSelecionada.ObterSaldo()}");
                break;
            case 3:
                Console.WriteLine("Informe um valor para depositar:");
                var valorDepositoValido = decimal.TryParse(Console.ReadLine(), out var valorDeposito);

                if (!valorDepositoValido)
                {
                    Console.WriteLine($"Valor inválido {Environment.NewLine}");
                    continue;
                }
                
                contaSelecionada.Depositar(valorDeposito);
                
                Console.WriteLine($"Novo saldo após depósito: {contaSelecionada.ObterSaldo()}");
                break;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exceção {e.GetType().Name} capturada com a mensagem {e.Message} {Environment.NewLine}");
        continue;
    }
    
    Console.WriteLine(Environment.NewLine);
}

