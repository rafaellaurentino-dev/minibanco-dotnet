using System;
using MiniBanco.ConsoleApp.Exceptions;
using MiniBanco.ConsoleApp.Models;

namespace MiniBanco.ConsoleApp.Models
{
    public class ContaSalario : Conta
    {
        public string Empregador { get; init; }
        public int LimiteSaquesMensais { get; init; }
        private int _saquesRealizadosNoMes;

        public ContaSalario(string titular, decimal saldoInicial, string empregador, int limiteSaques) 
            : base(titular, saldoInicial)
        {
            this.Empregador = empregador;
            this.LimiteSaquesMensais = limiteSaques;
            this._saquesRealizadosNoMes = 0;
        }

        public override void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do saque deve ser maior que zero.");

            decimal custoTransacao = 0;
            this._saquesRealizadosNoMes++;

            if (this._saquesRealizadosNoMes > this.LimiteSaquesMensais)
            {
                custoTransacao = 5.00m;
                Console.WriteLine($"⚠️ Alerta: Limite de saques gratuitos excedido! Tarifa de R$ {custoTransacao} aplicada.");
            }

            if (this.Saldo < (valor + custoTransacao))
            {
                this._saquesRealizadosNoMes--;
                throw new Exceptions.SaldoInsuficienteException($"Saldo insuficiente para cobrir o saque e a tarifa de R$ {custoTransacao}.");
            }

            this.Saldo -= valor;
            this.RegistrarTransacao("Saque Conta Salário", "Saque", valor);

            if (custoTransacao > 0)
            {
                this.Saldo -= custoTransacao;
                this.RegistrarTransacao("Tarifa sobre Saque Excedente", "Tarifa", custoTransacao);
            }
        }

        public override void ApplyFechamentoMensal()
        {
            this._saquesRealizadosNoMes = 0;
            this.RegistrarTransacao("Fechamento Mensal: Franquia de saques renovada", "Tarifa", 0.0000001m);
        }
    }
}
