using DevInHouse.Audaces.TDD.Example.Exceptions;

namespace DevInHouse.Audaces.TDD.Example.Dominio;

public class CatalogoFilmes
{
    private List<Filme> Filmes { get; set; } = new();

    public void AdicionaFilme(string nome, int ano)
    {
        if (nome == null) throw new ArgumentNullException(nameof(nome), "O nome não pode ser nulo");
        
        if (Filmes.Any(f => f.Nome == nome && f.Ano == ano))
        {
            throw new FilmeJaExisteException(nome, ano);
        }
        
        Filmes.Add(new Filme
        {
            Ano = ano,
            Nome = nome
        });
    }
    
    public void RemoverFilme(string nome, int ano)
    {
        if (!Filmes.Any(f => f.Nome == nome && f.Ano == ano))
        {
            throw new FilmeNaoEncontrado(nome, ano);
        }

        var index = Filmes.FindIndex(f => f.Nome == nome && f.Ano == ano);

        if (index >= 0)
        {
            Filmes.RemoveAt(index);
        }
    }

    public List<Filme> ObterCatalogoFilmes(int? ano = null)
    {
        if (!Filmes.Any())
        {
            throw new CatalogoVazioException();
        }
        
        if (ano == null)
        {
            return Filmes;
        }

        return Filmes.Where(f => f.Ano == ano).ToList();
    }
}