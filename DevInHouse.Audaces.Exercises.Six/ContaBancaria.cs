using DevInHouse.Audaces.Exercises.Six.Exceptions;

namespace DevInHouse.Audaces.Exercises.Six;

public class ContaBancaria
{
    public string Numero { get; set; }
    public decimal Saldo { get; set; }
    public decimal LimiteSaque { get; set; }
    public bool Operacional { get; set; }

    public ContaBancaria(
        string numero, 
        decimal saldo, 
        decimal limiteSaque, 
        bool operacional
    )
    {
        Numero = numero;
        Saldo = saldo;
        LimiteSaque = limiteSaque;
        Operacional = operacional;
    }

    private void VerificaTipoContaParaOperacao()
    {
        if (!Operacional)
        {
            throw new ContaNaoOperacionalException(Numero);
        }
    }

    public void Depositar(decimal valorDeposito)
    {
        VerificaTipoContaParaOperacao();
         
        Saldo += valorDeposito;
    }

    public void Sacar(decimal valorSaque)
    {
        VerificaTipoContaParaOperacao();

        if (valorSaque > Saldo)
        {
            throw new ValorSaqueMaiorSaldoException();
        }

        if (valorSaque > LimiteSaque)
        {
            throw new ValorSaqueMaiorLimiteException();
        }
        
        Saldo -= valorSaque;
    }
}