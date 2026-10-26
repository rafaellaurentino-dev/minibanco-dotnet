using System;
using MiniBanco.ConsoleApp.Exceptions;
using MiniBanco.ConsoleApp.Models;

namespace MiniBanco.ConsoleApp.Models
{
    public class ContaCorrente : Conta
    {
        public decimal LimiteChequeEspecial { get; init; }

        public ContaCorrente(string titular, decimal saldoInicial, decimal limite) 
            : base(titular, saldoInicial)
        {
            this.LimiteChequeEspecial = limite;
        }

        public override void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do saque deve ser maior que zero.");

            if ((this.Saldo + this.LimiteChequeEspecial) < valor)
                throw new SaldoInsuficienteException($"Saque recusado. Valor excede o saldo e o limite de cheque especial. Disponível total: R$ {(this.Saldo + this.LimiteChequeEspecial):F2}");

            this.Saldo -= valor;
            this.RegistrarTransacao("Saque em Conta Corrente", "Saque", valor);
        }

        public override void ApplyFechamentoMensal()
        {
            decimal tarifa = 10.00m;
            this.Saldo -= tarifa;
            this.RegistrarTransacao("Tarifa de Manutenção Mensal", "Tarifa", tarifa);
        }
    }
}
