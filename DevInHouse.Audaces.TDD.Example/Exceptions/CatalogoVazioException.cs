namespace DevInHouse.Audaces.TDD.Example.Exceptions;

public class CatalogoVazioException : Exception
{
    public CatalogoVazioException() : base("O catálogo está vazio!")
    {
    }
}