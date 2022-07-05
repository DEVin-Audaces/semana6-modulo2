using DevInHouse.Audaces.Exercises.One.Exceptions;

namespace DevInHouse.Audaces.Exercises.One.Domain;

public class Conta
{
    public string Numero { get; set; }
    public decimal Saldo { get; set; }
    public decimal LimiteSaque { get; set; }
    public bool Operacional { get; set; }

    public Conta(string numero, decimal saldo, decimal limiteSaque, bool operacional)
    {
        Numero = numero;
        Saldo = saldo;
        LimiteSaque = limiteSaque;
        Operacional = operacional;
    }

    private void VerificaContaEstaOperacional()
    {
        if (!Operacional) throw new ContaException(Numero);
    }

    // funcionalidades
    public decimal ObterSaldo()
    {
        VerificaContaEstaOperacional();

        return Saldo;
    }
    
    public void Depositar(decimal valor)
    {
        VerificaContaEstaOperacional();

        if (valor <= 0)
        {
            throw new ValorOperacaoZeradoOuNegativoException();
        }

        Saldo += valor;
    }
    
    public void Sacar(decimal valor)
    {
        VerificaContaEstaOperacional();

        if (valor <= 0)
        {
            throw new ValorOperacaoZeradoOuNegativoException();
        }

        if (valor > Saldo)
        {
            throw new SaldoInsuficienteException(Numero);
        }

        if (valor > LimiteSaque)
        {
            throw new ValorSaqueAcimaLimiteException(Numero);
        }

        Saldo -= valor;
    }
    
}