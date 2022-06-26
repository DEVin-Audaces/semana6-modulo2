namespace DevInHouse.Audaces.TDD.Example.Exceptions;

public class FilmeJaExisteException : Exception
{
    public const string MensagemPadrao = "O filme {0}({1}) já está cadastrado!";
    public int AnoFilme { get; set; }
    public string NomeFilme { get; set; }
    
    public FilmeJaExisteException(string nome, int ano) : base(string.Format(MensagemPadrao, nome, ano))
    {
        AnoFilme = ano;
        NomeFilme = nome;
    }
}