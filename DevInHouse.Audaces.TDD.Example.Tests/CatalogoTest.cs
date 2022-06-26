using DevInHouse.Audaces.TDD.Example.Dominio;
using DevInHouse.Audaces.TDD.Example.Exceptions;

namespace DevInHouse.Audaces.TDD.Example.Tests;

public class CatalogoTest
{
    [Fact]
    public void Deveria_Criar_Filme()
    {
        var catalogo = new CatalogoFilmes();

        var nomeEsperado = "Deadpool";
        var anoEsperado = 2016;
        
        catalogo.AdicionaFilme(nomeEsperado, anoEsperado);
        
        Assert.Single(catalogo.ObterCatalogoFilmes());
    }
    
    [Fact]
    public void Deveria_Lancar_Exception_Ao_Criar_Filme_Sem_Nome()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var catalogo = new CatalogoFilmes();

            var anoEsperado = 2016;

            catalogo.AdicionaFilme(null, anoEsperado);
        });
    }
    
    [Fact]
    public void Deveria_Remover_Filme()
    {
        var catalogo = new CatalogoFilmes();

        catalogo.AdicionaFilme("Deadpool", 2016);
        catalogo.AdicionaFilme("Deadpool 2", 2018);
        
        catalogo.RemoverFilme("Deadpool", 2016);

        Assert.Single(catalogo.ObterCatalogoFilmes());
    }
    
    [Fact]
    public void Deveria_Lancar_Exception_Ao_Remover_Caso_Filme_Nao_Exista()
    {
        Assert.Throws<FilmeNaoEncontrado>(() =>
        {
            var catalogo = new CatalogoFilmes();

            catalogo.AdicionaFilme("Deadpool", 2016);
            catalogo.AdicionaFilme("Deadpool 2", 2018);

            catalogo.RemoverFilme("Thor", 2011);
        });
    }
    
    [Fact]
    public void Deveria_Lancar_Exception_Ao_Criar_Filme_Duplicado()
    {
        Assert.Throws<FilmeJaExisteException>(() =>
        {
            var catalogo = new CatalogoFilmes();

            var filmeEsperado = "Deadpool";
            var anoEsperado = 2016;

            catalogo.AdicionaFilme(filmeEsperado, anoEsperado);
            // deve ocasionar a exception
            catalogo.AdicionaFilme(filmeEsperado, anoEsperado);
        });
    }
    
    [Fact]
    public void Deveria_Lancar_Exception_Ao_Listar_Catalogo_Vazio()
    {
        Assert.Throws<CatalogoVazioException>(() =>
        {
            var catalogo = new CatalogoFilmes();

            catalogo.ObterCatalogoFilmes();
        });
    }
    
    [Fact]
    public void Deveria_Listar_Catalogo_Com_Um_Item()
    {
        var catalogo = new CatalogoFilmes();

        var nomeEsperado = "Deadpool";
        var anoEsperado = 2016;
        catalogo.AdicionaFilme(nomeEsperado, anoEsperado);

        var lista = catalogo.ObterCatalogoFilmes();
        
        Assert.Single(lista);
        Assert.Collection(
            lista,
            f => Assert.True(f.Ano == anoEsperado && f.Nome == nomeEsperado)
        );
    }
    
    [Theory]
    [InlineData(2016)]
    [InlineData(2017)]
    [InlineData(2022)]
    public void Deveria_Listar_Catalogo_Por_Ano(int anoFiltro)
    {
        var catalogo = new CatalogoFilmes();

        catalogo.AdicionaFilme("Deadpool", 2016);
        catalogo.AdicionaFilme("Liga da Justiça", 2017);
        catalogo.AdicionaFilme("Sem saída", 2022);

        var lista = catalogo.ObterCatalogoFilmes(anoFiltro);
        
        Assert.All(
            lista,
            f => Assert.Equal(f.Ano, anoFiltro)
        );
    }
    
    // Implementando nova funcionalidade
    [Fact]
    public void Deveria_Listar_Catalogo_Por_Texto_Busca()
    {
        Assert.True(true);
    }
}