using System;
using MiniBanco.ConsoleApp.Exceptions;
using MiniBanco.ConsoleApp.Models;

namespace MiniBanco.ConsoleApp.Models
{
    public class ContaPoupanca : Conta
    {
        public double TaxaRendimentoMensal { get; init; }

        public ContaPoupanca(string titular, decimal saldoInicial, double taxa) 
            : base(titular, saldoInicial)
        {
            this.TaxaRendimentoMensal = taxa;
        }

        public override void ApplyFechamentoMensal()
        {
            decimal rendimento = this.Saldo * (decimal)(this.TaxaRendimentoMensal / 100.0);
            this.Saldo += rendimento;
            this.RegistrarTransacao($"Rendimento Poupança — Taxa: {this.TaxaRendimentoMensal}%", "Deposito", rendimento);
        }
    }
}
