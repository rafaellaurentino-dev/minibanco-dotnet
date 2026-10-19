using System;
//using MiniBanco.ConsoleApp.Exceptions;
//using MiniBanco.ConsoleApp.Models;

namespace MiniBanco.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            bool rodando = true;

            while (rodando)
            {
                try
                {
                    Console.WriteLine("\n======================================================");
                    Console.WriteLine("==  🏦 MINIBANCO DIGITAL - MOTOR DE GESTÃO v1.0 🏦  ==");
                    Console.WriteLine("======================================================");
                    Console.WriteLine("== 1 - Abrir Nova Conta                             ==");
                    Console.WriteLine("== 2 - Registrar Movimentação (Depósito / Saque)    ==");
                    Console.WriteLine("== 3 - Aplicar Fechamento Mensal                    ==");
                    Console.WriteLine("== 4 - Exibir Relatório das Contas                  ==");
                    Console.WriteLine("== 0 - Sair do Sistema                              ==");
                    Console.WriteLine("------------------------------------------------------");
                    Console.Write("  Digite a opção desejada: ");

                    int opcaoMenu = int.Parse(Console.ReadLine() ?? "100");

                    Console.WriteLine("\n------------------------------------------------------\n");

                    switch (opcaoMenu)
                    {
                        case 1:
                            Console.WriteLine("Iniciando abertura de nova conta...");
                            break;

                        case 2:
                            Console.WriteLine("Iniciando registro de movimentação...");
                            break;

                        case 3:
                            Console.WriteLine("Aplicando o fechamento mensal geral...");
                            break;

                        case 4:
                            Console.WriteLine("Gerando relatório consolidado do Motor de Análise...");
                            break;

                        case 0:
                            rodando = false;
                            Console.WriteLine("Encerrando o Motor do MiniBanco. Até breve!");
                            break;

                        default:
                            Console.WriteLine("⚠️ Opção Inválida! Por favor, escolha um número de 0 a 4.");
                            break;

                    }
                }
                catch
                {

                }
            }
        }
    }
}
