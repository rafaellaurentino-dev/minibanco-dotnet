using System;
using MiniBanco.ConsoleApp.Exceptions;
using MiniBanco.ConsoleApp.Models;
using MiniBanco.ConsoleApp.Services;

namespace MiniBanco.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Conta> bancoDeDadosContas = new List<Conta>();
            bool rodando = true;

            while (rodando)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("======================================================");
                    Console.WriteLine("==  🏦 MINIBANCO DIGITAL - MOTOR DE GESTÃO v1.0 🏦  ==");
                    Console.WriteLine("======================================================");
                    Console.WriteLine("== 1 - Abrir Nova Conta                             ==");
                    Console.WriteLine("== 2 - Registrar Movimentação (Depósito / Saque)    ==");
                    Console.WriteLine("== 3 - Aplicar Fechamento Mensal                    ==");
                    Console.WriteLine("== 4 - Exibir Relatório das Contas                  ==");
                    Console.WriteLine("== 0 - Sair do Sistema                              ==");
                    Console.WriteLine("======================================================");
                    Console.Write("Digite o numero da opção desejada: ");

                    int opcaoMenu = int.Parse(Console.ReadLine() ?? "100");

                    switch (opcaoMenu)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Iniciando abertura de nova conta...");
                            AbrirContaMenu(bancoDeDadosContas);
                            Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal...");
                            Console.ReadKey();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Iniciando registro de movimentação...");
                            RegistrarMovimentacaoMenu(bancoDeDadosContas);
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("Aplicando o fechamento mensal geral...");
                            if (bancoDeDadosContas.Count == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("⚠️ Nenhuma conta aberta para fechar.");
                                Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal...");
                                Console.ReadKey();
                                break;
                            }
                            foreach (Conta c in bancoDeDadosContas) c.ApplyFechamentoMensal();
                            Console.WriteLine("✅ Fechamento mensal aplicado com sucesso!");
                            Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal...");
                            Console.ReadKey();
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("Gerando relatório consolidado do Motor de Análise...");
                            MotorAnalise.ExibirRelatorioGeral(bancoDeDadosContas);
                            Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal...");
                            Console.ReadKey();
                            break;

                        case 0:
                            Console.Clear();
                            rodando = false;
                            Console.WriteLine("Encerrando o sistema... Obrigado por usar o MiniBanco!");
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("⚠️ Opção Inválida! Por favor, escolha um número de 0 a 4.");
                            Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal...");
                            Console.ReadKey();
                            break;

                    }
                }
                catch (SaldoInsuficienteException ex) 
                {   
                    Console.Clear();
                    Console.WriteLine($"❌ ERRO EM OPERAÇÃO: {ex.Message}");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal...");
                    Console.ReadKey();
                }
                catch (ArgumentException ex) 
                { 
                    Console.Clear();
                    Console.WriteLine($"❌ ERRO DE CONTRATO: {ex.Message}");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal...");
                    Console.ReadKey();
                }
                catch (FormatException) 
                { 
                    Console.Clear();
                    Console.WriteLine("❌ ERRO DE DIGITAÇÃO: Use apenas números nos campos corretos.");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal...");
                    Console.ReadKey();
                }
            }
        }
    
        private static (string Nome, decimal SaldoInicial) ColetarDadosBasicos()
        {
            Console.Write("Nome do Titular: ");
            string titular = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(titular))
                throw new ArgumentException("O nome do titular não pode estar em branco.");

            Console.Write("Saldo Inicial: R$ ");
            decimal saldo = decimal.Parse(Console.ReadLine() ?? "0");

            return (titular, saldo);
        }

             private static void AbrirContaMenu(List<Conta> contas)
        {
            int tipo = 0;
            
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("=========== ABERTURA DE CONTA ASSETS ============");
                    Console.WriteLine("==  1 - Corrente | 2 - Poupança | 3 - Salário  ==");
                    Console.WriteLine("=================================================");
                    Console.Write("Escolha o tipo: ");
                    tipo = int.Parse(Console.ReadLine() ?? "0");

                    if (tipo >= 1 && tipo <= 3)
                    {
                        break;
                    }
                    else
                    {
                    Console.Clear();
                    Console.WriteLine("⚠️ Tipo inválido! Escolha apenas 1, 2 ou 3.");
                     Console.WriteLine("Pressione qualquer tecla para voltar ao Menu...");
                    Console.ReadKey();
                    }
                }
                 catch (FormatException) 
                { 
                    Console.Clear();
                    Console.WriteLine("❌ ERRO DE DIGITAÇÃO: Use apenas números nos campos corretos.");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao Menu...");
                    Console.ReadKey();
                }
            }

            Conta novaConta = null!;

            while (true)
            {
                try
                {
                    switch (tipo)
                    {
                        case 1:
                            var DadosCorrente = ColetarDadosBasicos();
                            Console.Write("Limite do Cheque Especial: R$ ");
                            decimal limite = decimal.Parse(Console.ReadLine() ?? "0");
                            novaConta = new ContaCorrente(DadosCorrente.Nome, DadosCorrente.SaldoInicial, limite);
                            break;
                        case 2:
                            var dadosPoupanca = ColetarDadosBasicos();
                            Console.Write("Taxa de Rendimento (%): ");
                            double taxa = double.Parse(Console.ReadLine() ?? "0");
                            novaConta = new ContaPoupanca(dadosPoupanca.Nome, dadosPoupanca.SaldoInicial, taxa);
                            break;
                        case 3:
                            var dadosSalario = ColetarDadosBasicos();
                            Console.Write("Nome da Empresa Empregadora: ");
                            string emp = Console.ReadLine() ?? "";
                            Console.Write("Limite de Saques Gratuitos: ");
                            int limSaques = int.Parse(Console.ReadLine() ?? "0");
                            novaConta = new ContaSalario(dadosSalario.Nome, dadosSalario.SaldoInicial, emp, limSaques);
                            break;
                    }
                    
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.Clear();
                    Console.WriteLine($"❌ ERRO DE VALIDAÇÃO: {ex.Message} \nReiniciando preenchimento...");
                    Console.WriteLine("------------------------------------------------------");
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("❌ ERRO DE DIGITAÇÃO: Formato numérico inválido detectado.\nReiniciando preenchimento...");
                    Console.WriteLine("------------------------------------------------------");
                }
            }

            contas.Add(novaConta!);
            
            Console.Clear();
            Console.WriteLine("======================================================");
            Console.WriteLine("==          🎉 CONTA CRIADA COM SUCESSO! 🎉         ==");
            Console.WriteLine("======================================================");
            Console.WriteLine($" 👤 Titular: {novaConta.Titular}");
            Console.WriteLine($" 🆔 NÚMERO DA CONTA GERADO: {novaConta.Numero}");
            Console.WriteLine($" 💰 Saldo Inicial: R$ {novaConta.Saldo:F2}");
            Console.WriteLine("======================================================");
        }

        private static void RegistrarMovimentacaoMenu(List<Conta> contas)
        {
            if (contas.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("⚠️ Nenhuma conta registrada no sistema para movimentar.");
                Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal...");
                Console.ReadKey();
                return;
            }

            Conta? contaLocalizada = null;

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Digite o número da conta destino (ou 0 para cancelar e voltar): ");
                    int numero = int.Parse(Console.ReadLine() ?? "0");

                    if (numero == 0) return;

                    contaLocalizada = contas.Find(c => c.Numero == numero);
                    
                    if (contaLocalizada != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("⚠️ Conta não encontrada no sistema! Tente outro número.");
                        Console.WriteLine("Pressione qualquer tecla para voltar...");
                        Console.ReadKey();
                    }
                    
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("❌ ERRO: O número da conta deve ser um valor inteiro.");
                    Console.WriteLine("Pressione qualquer tecla para voltar...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine($"\nCliente: {contaLocalizada.Titular} | Saldo Atual: R$ {contaLocalizada.Saldo:F2}");

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("1 - Depósito | 2 - Saque");
                    Console.Write("Escolha a operação: ");
                    int op = int.Parse(Console.ReadLine() ?? "0");

                    if (op != 1 && op != 2)
                    {
                        Console.Clear();
                        Console.WriteLine("⚠️ Opção inválida! Escolha 1 para Depósito ou 2 para Saque.");
                        Console.WriteLine("Pressione qualquer tecla para voltar...");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("Valor: R$ ");
                    decimal valor = decimal.Parse(Console.ReadLine() ?? "0");

                    if (op == 1)
                    {
                        Console.Clear();
                        contaLocalizada.Depositar(valor, "Depósito manual via Console");
                        Console.WriteLine("✅ Depósito efetuado com sucesso! \nPressione qualquer tecla para voltar ao Menu Principal...");
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        contaLocalizada.Sacar(valor);
                        Console.WriteLine("✅ Saque autorizado com sucesso! \nPressione qualquer tecla para voltar ao Menu Principal...");
                        break;
                    }
                    
                }
                catch (SaldoInsuficienteException ex)
                {
                    Console.Clear();
                    Console.WriteLine($"❌ OPERAÇÃO RECUSADA: {ex.Message} Digite novamente.");
                    Console.WriteLine("Pressione qualquer tecla para voltar...");
                    Console.ReadKey();
                }
                catch (ArgumentException ex)
                {
                    Console.Clear();
                    Console.WriteLine($"❌ ERRO DE CONTRATO: {ex.Message} Digite novamente.");
                    Console.WriteLine("Pressione qualquer tecla para voltar...");
                    Console.ReadKey();
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("❌ ERRO DE DIGITAÇÃO: Valor numérico inválido. Tente novamente.");
                    Console.WriteLine("Pressione qualquer tecla para voltar...");
                    Console.ReadKey();
                }
            }
            Console.ReadKey();
        }
    }
}