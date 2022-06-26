namespace DevInHouse.Audaces.TDD.Example.Exceptions;

public class FilmeNaoEncontrado : Exception
{
    public const string MensagemPadrao = "O filme {0}({1}) não foi encontrado no catálogo!";
    public int AnoFilme { get; set; }
    public string NomeFilme { get; set; }
    
    public FilmeNaoEncontrado(string nome, int ano) : base(string.Format(MensagemPadrao, nome, ano))
    {
        AnoFilme = ano;
        NomeFilme = nome;
    }
}