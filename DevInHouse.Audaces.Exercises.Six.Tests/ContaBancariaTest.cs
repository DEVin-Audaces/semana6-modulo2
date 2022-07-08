using DevInHouse.Audaces.Exercises.Six.Exceptions;
using Xunit;

namespace DevInHouse.Audaces.Exercises.Six.Tests;

public class ContaBancariaTest
{
    private const string NumeroContaPadrao = "1234";
    private const decimal SaldoBase = 5000;
    private const decimal LimiteSaque = 500;

    private ContaBancaria CriarContaBancariaOperacional(bool operacional)
    {
        return new ContaBancaria(
            "1234",
            SaldoBase,
            LimiteSaque,
            operacional
        );
    }

    [Fact]
    public void Deveria_Cadastrar_Conta()
    {
        // Preparação
        var conta = CriarContaBancariaOperacional(true);

        // Validação do resultado
        Assert.NotNull(conta);
        Assert.Equal(conta.Numero, NumeroContaPadrao);
    }

    [Fact]
    public void Deveria_Efetuar_Deposito()
    {
        // Preparação
        var valorDeposito = 500;
        var valorEsperado = 5500;
        var conta = CriarContaBancariaOperacional(true);

        // Execução
        conta.Depositar(valorDeposito);

        // Validação do resultado
        Assert.Equal(conta.Saldo, valorEsperado);
    }

    [Fact]
    public void Nao_Deveria_Efetuar_Deposito_Em_Conta_NaoOperacional()
    {
        Assert.Throws<ContaNaoOperacionalException>(() =>
        {
            // Preparação
            var valorDeposito = 500;
            var conta = CriarContaBancariaOperacional(false);

            // Execução
            conta.Depositar(valorDeposito);
        });
    }

    [Fact]
    public void Deveria_Efetuar_Saque()
    {
        // Preparação
        var valorSaque = 300;
        var valorEsperado = SaldoBase - valorSaque; //4700

        var conta = CriarContaBancariaOperacional(true);

        // Execução
        conta.Sacar(valorSaque);

        // Validação do resultado
        Assert.Equal(conta.Saldo, valorEsperado);
    }

    [Fact]
    public void Nao_Deveria_Efetuar_Saque_Quando_Valor_Eh_Maior_Que_Saldo()
    {
        Assert.Throws<ValorSaqueMaiorSaldoException>(() =>
        {
            // Preparação
            var valorSaque = SaldoBase + 100;

            var conta = CriarContaBancariaOperacional(true);

            // Execução
            conta.Sacar(valorSaque);
        });
    }
    
    [Fact]
    public void Nao_Deveria_Efetuar_Saque_Quando_Valor_Maior_LimiteSaque()
    {
        Assert.Throws<ValorSaqueMaiorLimiteException>(() =>
        {
            // Preparação
            var valorSaque = LimiteSaque + 100;

            var conta = CriarContaBancariaOperacional(true);

            // Execução
            conta.Sacar(valorSaque);
        });
    }
}