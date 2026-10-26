using System;
using MiniBanco.ConsoleApp.Exceptions;
using MiniBanco.ConsoleApp.Models;

namespace MiniBanco.ConsoleApp.Models
{
    public abstract class Conta
    {
        public string Titular { get; init; }
        public int Numero { get; init; }
        public static int TotalContasCriadas { get; private set; }
        public decimal Saldo { get; protected set; }
        public List<Transacao> Extrato { get; init; }

        public Conta(string titular, decimal saldoInicial)
        {
            TotalContasCriadas++;

            this.Titular = titular;
            this.Numero = TotalContasCriadas;
            this.Saldo = saldoInicial;
            this.Extrato = new List<Transacao>();
        }

        public void RegistrarTransacao(string descricao, string tipo, decimal valor)
        {
            Transacao novaTransacao = new Transacao(descricao, tipo, valor);
            this.Extrato.Add(novaTransacao);
        }

        public void Depositar(decimal valor, string descricao)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do depósito deve ser maior que zero.");

            this.Saldo += valor;
            this.RegistrarTransacao(descricao, "Deposito", valor);
        }

        public virtual void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do saque deve ser maior que zero.");

            if (this.Saldo < valor)
                throw new SaldoInsuficienteException($"Saldo insuficiente. Disponível: R$ {this.Saldo:F2}");

            this.Saldo -= valor;
            this.RegistrarTransacao("Saque em espécie", "Saque", valor);
        }

        public abstract void ApplyFechamentoMensal();
    }
}
