using DevInHouse.Audaces.Exceptions.Examples;

static void TentaAlterarConteudoArquivo()
{
    Console.WriteLine($"{Environment.NewLine}Executando TentaAlterarConteudoArquivo");
    
    try
    {
        var arquivo = "TesteArquivo.txt";
        var conteudoAtual = File.ReadAllText(arquivo);

        Console.WriteLine($"Conteudo atual do arquivo: {conteudoAtual}");

        using var writer = File.AppendText(arquivo);
        writer.WriteLine("tentando adicionar conteudo no arquivo");
        
        writer.Close();
    }
    catch (Exception e)
    {
        Console.WriteLine($"Tipo exceção: {e.GetType().Name}" +
                          $"{Environment.NewLine}" +
                          $"Mensagem: {e.Message}");
    }
}

static void TentaLerConteudoArquivo()
{
    Console.WriteLine($"{Environment.NewLine}Executando TentaLerConteudoArquivo");
    
    try
    {
        var arquivo = "TesteArquivoNaoExistente.txt";
        var conteudoAtual = File.ReadAllText(arquivo);

        Console.WriteLine($"Conteudo atual do arquivo: {conteudoAtual}");
    }
    catch (Exception e)
    {
        Console.WriteLine($"Tipo exceção: {e.GetType().Name}" +
                          $"{Environment.NewLine}" +
                          $"Mensagem: {e.Message}");
    }
}

static void TentaLerPosicaoArray()
{
    try
    {
        Console.WriteLine($"{Environment.NewLine}Executando TentaLerPosicaoArray");

        var array = new[] { 10, 20, 35, 40 };

        Console.WriteLine($"Array: {array}");

        Console.WriteLine("Tentando ler posição 0 -> ");
        var conteudoPosicao0 = array[0];
        Console.WriteLine($"Conteúdo: {conteudoPosicao0}");
        
        Console.WriteLine("Tentando ler posição 5 -> ");
        var conteudoPosicao5 = array[5];
        Console.WriteLine($"Conteúdo: {conteudoPosicao5}");
    }
    catch (IndexOutOfRangeException e)
    {
        Console.WriteLine($"Exceção {e.GetType().Name} capturada de forma específica");
    }
    catch (Exception e)
    {
        Console.WriteLine(@$"Exceção: {e.GetType().Name} capturada de forma genérica");
    }
}

static void TentaAcessarPropriedadeEmReferenciaNulla()
{
    try
    {
        Console.WriteLine($"{Environment.NewLine}Executando TentaAcessarPropriedadeEmReferenciaNulla");
        
        var obj = new ClasseExemplo()
        {
            Nome = "teste"
        };
        
        Console.WriteLine($"Nome do obj {obj.Nome}");

        obj = null;
        
        Console.WriteLine($"Nome do obj {obj.Nome}");

    }
    catch (NullReferenceException e)
    {
        Console.WriteLine($"Exceção {e.GetType().Name} capturada de forma específica");
    }
}

static void LancarExceptionPersonalizada()
{
    try
    {
        var senha = "123abc";

        Console.WriteLine("Digite a senha de acesso: ");
        var senhaObtida = Console.ReadLine();

        if (senha != senhaObtida)
        {
            throw new ExemploException("A senha não corresponde", senhaObtida);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exceção {e.GetType().Name} capturada com message: {e.Message}");
    }
}


TentaLerConteudoArquivo();
TentaAlterarConteudoArquivo();
TentaLerPosicaoArray();
TentaAcessarPropriedadeEmReferenciaNulla();
LancarExceptionPersonalizada();

Console.ReadLine();