# 🧮 MiniBanco.ConsoleApp: Motor de Gestão de Contas Bancárias

> **Status do Projeto:** 🚧 Em Desenvolvimento (Fase 1: Infraestrutura e Modelagem)  
> **Módulo:** 2 — Semana 07 | Especialização Back-End [.NET] [T2]  
> **Data de Entrega:** 26/10/2026 até às 22h  

---

## 🎯 Objetivo do Projeto

O **MiniBanco.ConsoleApp** é uma engine (motor de processamento) desenvolvida via Console Application em C# (.NET 10.0) com foco em simular o núcleo de operações de um banco digital. O grande diferencial técnico deste sistema é a sua capacidade de gerenciar regras de negócios altamente específicas para diferentes categorias de contas, além de auditar o histórico de movimentações para emitir um **Índice de Saúde Financeira** automatizado para a gerência corporativa.

O escopo foi desenhado para consolidar conceitos avançados de **Programação Orientada a Objetos (POO)**, tratamento estrito de exceções e arquitetura limpa de código.

---

## 🛠️ Tecnologias e Conceitos de POO Aplicados

O motor foi estruturado utilizando recursos robustos do ecossistema .NET:

*   **Arquitetura e Organização:** Separação estrita de responsabilidades em pastas físicas (`Models`, `Exceptions`, `Services`).
*   **Abstração e Herança (`:`):** Criação de uma matriz abstrata (`Conta`) que ramifica comportamentos para subclasses dedicadas (`ContaCorrente`, `ContaPoupanca`, `ContaSalario`).
*   **Polimorfismo Dinâmico (`virtual` / `override`):** Sobrescrita de métodos centrais de movimentação (`Sacar`) e encerramento de ciclo de vida (`AplicarFechamentoMensal`) para responder dinamicamente de acordo com o tipo da instância.
*   **Encapsulamento Rígido:** Proteção de estados críticos do sistema (como o `Saldo`) usando modificadores de acesso controlados (`protected set`), impedindo corrupção de dados fora do escopo permitido.
*   **Tratamento de Exceções Customizadas:** Engenharia de tratamento de falhas operacionais através da criação da classe `SaldoInsuficienteException` e blindagem do menu interativo com blocos `try/catch`.

---

## 📊 Regras de Negócio Iniciais (Engine)

O motor analisa e processa as contas com base nos seguintes pilares funcionais:

1.  **Modelo de Transação Contábil:** Toda entrada e saída gera um objeto imutável de transação mapeado entre três categorias estritas: `Deposito`, `Saque` ou `Tarifa`.
2.  **Tratamento por Categoria:**
    *   **Conta Corrente:** Possui limite de cheque especial embutido de R\$ 500,00 e taxa de manutenção mensal fixa.
    *   **Conta Poupança:** Executa cálculos de rentabilidade com base em taxas mensais indexadas.
    *   **Conta Salário:** Monitora o volume de saques mensais gratuitos, aplicando tarifas automáticas em caso de excesso de movimentação.
3.  **Engine de Saúde Financeira:** Algoritmo que converte o comportamento do cliente (depósitos vs. tarifas) em pontuações de engajamento, gerando relatórios de risco corporativo.

---

## 💻 Pré-requisitos para Execução

Para rodar este motor de processamento em seu ambiente local, você precisará de:
*   [.NET SDK 10.0+](https://microsoft.com) instalado.

---

## 🧭 Próximos Passos (Plano de Desenvolvimento)

- [x] Configuração inicial do repositório e arquivo `.gitignore`.
- [x] Criação do escopo e estrutura do `README.md` inicial.
- [ ] Implementação das classes de domínio na pasta `Models/`.
- [ ] Criação das Exceções Customizadas e validação de contratos.
- [ ] Desenvolvimento do Motor de Análise Condicional (`Services/`).
- [ ] Montagem da interface de console (`Program.cs`) e validações de input.
- [ ] Atualização final da documentação com instruções de uso detalhadas e link da gravação de vídeo.


---------------------------------------------------------------------------------------------------------------------------------------------------------------


# 🧮 MiniBanco.ConsoleApp: Bank Account Management Engine

> **Project Status:** 🚧 Under Development (Phase 1: Infrastructure and Modeling)  
> **Module:** 2 — Week 07 | Back-End Specialization [.NET] [T2]  
> **Submission Deadline:** October 26, 2026, by 10:00 PM  

---

## 🎯 Project Objective

**MiniBanco.ConsoleApp** is a processing engine developed as a C# Console Application (.NET 10.0) aimed at simulating the core operations of a digital bank. The primary technical highlight of this system is its ability to manage highly specific business rules for different account categories, as well as auditing transaction histories to generate an automated **Financial Health Index** for corporate management.

The project scope was designed to consolidate advanced concepts of **Object-Oriented Programming (OOP)**, strict exception handling, and clean code architecture.

---

## 🛠️ Applied Technologies and OOP Concepts

The engine was structured using robust features of the .NET ecosystem:

*   **Architecture and Organization:** Strict separation of concerns into physical folders (`Models`, `Exceptions`, `Services`).
*   **Abstraction and Inheritance (`:`):** Creation of an abstract base class (`Conta`) that branches behaviors into dedicated subclasses (`ContaCorrente`, `ContaPoupanca`, `ContaSalario`).
*   **Dynamic Polymorphism (`virtual` / `override`):** Overriding core transaction methods (`Sacar`) and end-of-lifecycle methods (`AplicarFechamentoMensal`) to respond dynamically according to the instance type.
*   **Rigid Encapsulation:** Protection of critical system states (such as `Saldo`) using controlled access modifiers (`protected set`), preventing data corruption outside the allowed scope.
*   **Custom Exception Handling:** Fault-tolerant software engineering through the creation of the `SaldoInsuficienteException` class and safeguarding the interactive menu with `try/catch` blocks.

---

## 📊 Initial Business Rules (Engine)

The engine analyzes and processes accounts based on the following functional pillars:

1.  **Accounting Transaction Model:** Every entry and exit generates an immutable transaction object mapped into three strict categories: `Deposito` (Deposit), `Saque` (Withdrawal), or `Tarifa` (Fee).
2.  **Category-Specific Handling:**
    *   **Checking Account (Conta Corrente):** Includes a built-in overdraft limit (Cheque Especial) of R\$ 500.00 and a fixed monthly maintenance fee.
    *   **Savings Account (Conta Poupança):** Executes profitability calculations based on indexed monthly rates.
    *   **Salary Account (Conta Salário):** Monitors the volume of free monthly withdrawals, automatically applying fees if the allowed limit is exceeded.
3.  **Financial Health Engine:** An algorithm that converts customer behavior (deposits vs. fees) into engagement scores, generating corporate risk reports.

---

## 💻 Prerequisites for Execution

To run this processing engine in your local environment, you will need:
*   [.NET SDK 10.0+](https://microsoft.com) installed.

---

## 🧭 Next Steps (Development Plan)

- [x] Initial repository configuration and `.gitignore` file.
- [x] Scope creation and structure of the initial `README.md`.
- [ ] Implementation of domain classes in the `Models/` folder.
- [ ] Creation of Custom Exceptions and contract validation.
- [ ] Development of the Conditional Analysis Engine (`Services/`).
- [ ] Assembly of the console interface (`Program.cs`) and input validations.
- [ ] Final documentation update with detailed usage instructions and video recording link.
