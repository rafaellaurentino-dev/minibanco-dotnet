using System;
using MiniBanco.ConsoleApp.Models;

namespace MiniBanco.ConsoleApp.Services
{
    public static class MotorAnalise
    {
        public static void ExibirRelatorioGeral(List<Conta> contas)
        {
            Console.WriteLine("\n===========================================================");
            Console.WriteLine("== 📊 RELATÓRIO DO MOTOR DE ANÁLISE, SAÚDE FINANCEIRA 📊 ==");
            Console.WriteLine("===========================================================");

            if (contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta aberta até o momento.");
                return;
            }

            int index = 1;
            foreach (Conta conta in contas)
            {
                Console.WriteLine($"\n[{index}/{contas.Count}] PROCESSANDO CONTA");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("> DADOS DA CONTA:");
                Console.WriteLine($"- Titular: {conta.Titular} | Conta: {conta.Numero}");
                if (conta is ContaCorrente contaCorrente)
                {
                    Console.WriteLine("- Tipo: Conta Corrente");
                    Console.WriteLine($"- Limite do Cheque Especial: R$ {contaCorrente.LimiteChequeEspecial}");
                }
                else if (conta is ContaPoupanca poupanca)
                {   
                    Console.WriteLine("- Tipo: Conta Poupança");
                    Console.WriteLine($"- Taxa de Rendimento: {poupanca.TaxaRendimentoMensal}% ");
                }
                else if (conta is ContaSalario salario)
                {
                    Console.WriteLine("- Tipo: Conta Salario");
                    Console.WriteLine($"- Empresa Empregadora: {salario.Empregador} | Limite de Saques: {salario.LimiteSaquesMensais}");
                }
                
                Console.WriteLine($"- Saldo Atual: R$ {conta.Saldo}");

                int pontuacaoObtida = 0;
                int totalTransacoes = conta.Extrato.Count;

                 Console.WriteLine("\n> TRANSAÇÕES:");
                if (totalTransacoes == 0)
                {
                    Console.WriteLine("- Nenhuma transação no período.");
                }
                else
                {
                    for (int i = 0; i < totalTransacoes; i++)
                    {
                        Transacao t = conta.Extrato[i];
                        int pontosDaTransacao = 0;

                        if (t.Tipo == "Deposito")
                        {
                            pontosDaTransacao = 10;
                            pontuacaoObtida += 10;
                            Console.WriteLine($"  [ OK ] {t.Descricao,-30} \n- Deposito: R$ {t.Valor} ({pontosDaTransacao} pts)");
                        }
                        else if (t.Tipo == "Saque")
                        {
                            pontosDaTransacao = 5;
                            pontuacaoObtida += 5;
                            Console.WriteLine($"  [ OK ] {t.Descricao,-30} \n- Saque: R$ {t.Valor} ({pontosDaTransacao} pts)");
                        }
                        else if (t.Tipo == "Tarifa")
                        {
                            pontosDaTransacao = 0;
                            Console.WriteLine($"  [ ⚠️  ] {t.Descricao,-30} \n- Tarifa: R$ {t.Valor} ({pontosDaTransacao} pts)");
                        }
                    }
                }

                double percentualSaude = 100.0;
                int pontuacaoMaxima = totalTransacoes * 10;

                if (totalTransacoes > 0)
                {
                    percentualSaude = ((double)pontuacaoObtida / pontuacaoMaxima) * 100;
                }

                string classificacaoFinal = "";
                string acaoRecomendada = "";

                if (percentualSaude >= 90.0)
                {
                    classificacaoFinal = "[ CONTA SAUDÁVEL ]";
                    acaoRecomendada = "🟢 Nenhuma pendência identificada. Oferecer produtos de investimento ao cliente e avaliar aumento de limite.";
                }
                else if (percentualSaude >= 60.0)
                {
                    classificacaoFinal = "[ CONTA EM ATENÇÃO ]";
                    acaoRecomendada = "🟡 Contato imediato da gerência para orientação financeira e revisão estratégica de tarifas aplicadas.";
                }
                else
                {
                    classificacaoFinal = "[ CONTA EM RISCO ]";
                    acaoRecomendada = "🔴 ATENÇÃO: Bloquear qualquer aumento de limite de crédito imediatamente e abrir análise de risco de crédito.";
                }

                Console.WriteLine("\n> RESUMO DA PONTUAÇÃO:");
                Console.WriteLine($"  - Pontuação Atingida: {pontuacaoObtida} de {pontuacaoMaxima} pontos possíveis");
                Console.WriteLine($"  - Índice de Saúde: {percentualSaude:F1}%");
                Console.WriteLine($"  - Classificação Final: {classificacaoFinal}");
                Console.WriteLine("\n> RELATÓRIO DE PENDÊNCIAS E RECOMENDAÇÕES DA GERÊNCIA:");
                Console.WriteLine($"  {acaoRecomendada}");
                Console.WriteLine("-----------------------------------------------------------");
                index++;
            }
            Console.WriteLine("\n============= FIM DO PROCESSAMENTO DE CONTAS ==============");
        }
    }
}
