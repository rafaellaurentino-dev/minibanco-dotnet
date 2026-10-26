using System;
using MiniBanco.ConsoleApp.Exceptions;
using MiniBanco.ConsoleApp.Models;

namespace MiniBanco.ConsoleApp.Models
{
    public class Transacao
    {
        public string Descricao { get; init; }
        public string Tipo { get; init; }
        public decimal Valor { get; init; }

        public Transacao(string descricao, string tipo, decimal valor)
        {
            if (tipo != "Deposito" && tipo != "Saque" && tipo != "Tarifa")
                throw new ArgumentException("O tipo de transação deve ser estritamente: Deposito ou Saque.");

            if (valor <= 0)
                throw new ArgumentException("O valor da transação deve ser maior que zero.");

            Descricao = descricao;
            Tipo = tipo;
            Valor = valor;
        }
    }
}
