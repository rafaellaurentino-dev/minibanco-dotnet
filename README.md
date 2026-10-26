# 🏦 MiniBanco.ConsoleApp: Motor de Gestão de Contas Bancárias

> **Status do Projeto:** ✅ Concluído (100% Funcional)  
> **Módulo:** 2 — Semana 07 | Especialização Back-End [.NET] [T2]  
> **Data de Entrega:** 26/10/2026 até às 22h  
> **Link da Apresentação em Vídeo:**  

---

## 🎯 1. Identificação e Objetivo do Projeto
O **MiniBanco.ConsoleApp** é uma Console Application robusta desenvolvida em C# (.NET 10.0) que simula o motor de processamento central de um banco digital. O sistema gerencia o ciclo de vida de múltiplas categorias de contas, executa movimentações financeiras protegidas por regras de negócios severas e audita dados históricos de transações para calcular o **Índice de Saúde Financeira** de cada cliente, emitindo relatórios estratégicos com ações sugeridas para a gerência corporativa.

O projeto consolida de forma prática os quatro pilares da **Programação Orientada a Objetos (POO)**: Abstração, Encapsulamento, Herança e Polimorfismo, além de tratamento de exceções personalizadas e versionamento profissional com Git/GitHub através de branches dedicadas.

---

## 🛠️ 2. Funcionalidades e Estrutura do Sistema

A solução está fisicamente organizada em uma arquitetura de responsabilidades isoladas:
*   **`Models/`**: Contém o modelo imutável de `Transacao` e a matriz abstrata `Conta`, juntamente com suas subclasses específicas.
*   **`Exceptions/`**: Centraliza todas as exceções customizadas de negócios no arquivo `Exceptions.cs`.
*   **`Services/`**: Hospeda o `MotorAnalise.cs`, responsável por processar as pontuações e relatórios.

### 📊 Regras de Negócio e Regras por Tipo de Conta
1.  **Transação Imutável**: Toda entrada ou saída gera um registro classificado estritamente em `Deposito`, `Saque` ou `Tarifa`. Valores menores ou iguais a zero ou tipos ilegais disparam um `ArgumentException`.
2.  **Conta Corrente**: Possui limite de cheque especial maleável definido na abertura. Seu fechamento mensal desconta uma tarifa fixa de manutenção de R$ 10,00. O saque permite a utilização do saldo somado ao limite.
3.  **Conta Poupança**: Contém atributos de taxa de juros e dia de aniversário. Seu fechamento mensal gera um depósito automático de rendimento calculado sobre a taxa contratual (`saldo × taxa / 100`).
4.  **Conta Salário**: Vincula o nome da empresa empregadora e uma franquia mensal de saques. Se o cliente exceder a quantidade de saques gratuitos, o motor passa a cobrar automaticamente R$ 5,00 de tarifa por saque. Seu fechamento renova a franquia zerando a contagem, sem tarifas de manutenção fixas.
5.  **Geração Sequencial de IDs**: O número de cada conta é gerado de forma totalmente automática a partir de um acumulador estático (`TotalContasCriadas`), blindando o sistema contra chaves duplicadas.

---

## 🧮 3. Algoritmo da Engine de Saúde Financeira
O `MotorAnalise` varre o extrato de cada conta utilizando um **laço tradicional `for`** e converte o comportamento em pontos:
*   Cada `Deposito` adiciona **10 pontos**.
*   Cada `Saque` adiciona **5 pontos**.
*   Cada `Tarifa` adiciona **0 pontos** e é jogada para o subset de **Itens Críticos**.

A fórmula calcula a saúde aplicando um *cast* explícito para `double` para evitar truncamento numérico do compilador, além de conter proteção ativa contra erros de divisão por zero (caso a conta não tenha movimentações):
$$\text{Percentual (\%)} = \left( \frac{\text{Pontuação Obtida}}{\text{Total de Transações} \times 10} \right) \times 100$$

### 📈 Tabela de Classificação Condicional
*   **90% a 100% [ Conta Saudável ]**: Sugere oferta de produtos de investimento e avaliação de aumento de limite.
*   **60% a 89% [ Conta em Atenção ]**: Dispara contato da gerência para orientação financeira e revisão de tarifas.
*   **0% a 59% [ Conta em Risco ]**: Determina o bloqueio imediato de limite e abertura de análise de crédito.

---

## 💻 4. Instruções de Execução

### Pré-requisitos
*   [.NET SDK 10.0+](https://microsoft.com) instalado na máquina.

### Como Executar
1. Clone o repositório público:
   ```bash
   git clone [https://github.com](https://github.com/rafaellaurentino-dev/minibanco-dotnet.git)
   ```
2. Navegue até a pasta do projeto executável:
   ```bash
   cd minibanco-dotnet/src/MiniBanco.ConsoleApp
   ```
3. Limpe os resíduos de compilação antigos da memória:
   ```bash
   dotnet clean
   ```
4. Execute o programa:
   ```bash
   dotnet run
   ```

---

## ⚠️ 5. Limitações e Tratamento de Exceções
O sistema é imune a falhas de travamento e encerramento bruto do terminal devido ao uso de persistência local (`while(true)`) e blocos de captura:
*   **`SaldoInsuficienteException`**: Disparada ao tentar sacar valores superiores à capacidade financeira configurada no tipo de conta.
*   **`ArgumentException`**: Bloqueia entradas inválidas em tempo de execução (valores negativos).
*   **`FormatException`**: Captura tentativas de digitação de letras em campos puramente numéricos, emitindo um feedback e repetindo a pergunta sem fechar o console.

---
-------------------------------------------------------------------------------------------------------------------------------



# 🏦 MiniBanco.ConsoleApp: Bank Account Management Engine

> **Project Status:** ✅ Completed (100% Functional)  
> **Module:** 2 — Week 07 | Back-End Specialization [.NET] [T2]  
> **Submission Deadline:** 10/26/2026 by 10:00 PM  
> **Video Presentation Link:**   

---

## 🎯 1. Identification and Project Objective
**MiniBanco.ConsoleApp** is a robust Console Application developed in C# (.NET 10.0) that simulates the core processing engine of a digital bank. The system manages the lifecycle of multiple account categories, executes financial operations protected by strict business rules, and audits historical transaction data to calculate the **Financial Health Index** of each client, generating strategic reports with recommended actions for corporate management.

The project practically consolidates the four pillars of **Object-Oriented Programming (OOP)**: Abstraction, Encapsulation, Inheritance, and Polymorphism, as well as custom business exception handling and professional Git/GitHub version control through dedicated branches.

---

## 🛠️ 2. Features and System Structure

The solution is physically organized into an architecture of isolated responsibilities:
*   **`Models/`**: Contains the immutable `Transacao` model and the abstract base class `Conta`, along with its specific subclasses.
*   **`Exceptions/`**: Centralizes all custom business exceptions in a single `Exceptions.cs` file.
*   **`Services/`**: Hosts `MotorAnalise.cs`, which is responsible for processing scores and generating reports.

### 📊 Business Rules and Account Types Specification
1.  **Immutable Transaction**: Every deposit or withdrawal generates a record strictly classified as `Deposito`, `Saque`, or `Tarifa`. Values less than or equal to zero or illegal types trigger an `ArgumentException`.
2.  **Checking Account (Conta Corrente)**: Includes a flexible overdraft limit defined at opening. Its monthly closure deducts a fixed maintenance fee of R$ 10.00. The withdrawal allows using the balance plus the overdraft limit.
3.  **Savings Account (Conta Poupança)**: Contains interest rate and anniversary day attributes. Its monthly closure generates an automatic yield deposit calculated based on the contractual rate (`balance × rate / 100`).
4.  **Salary Account (Conta Salário)**: Binds the employer company name and a monthly withdrawal allowance. If the client exceeds the amount of free withdrawals, the engine automatically charges a R$ 5.00 fee per withdrawal. Its monthly closure renews the allowance by resetting the count, with no fixed maintenance fees.
5.  **Sequential ID Generation**: Each account number is generated completely automatically from a static accumulator (`TotalContasCriadas`), shielding the system against duplicate keys.

---

## 🧮 3. Financial Health Engine Algorithm
The `MotorAnalise` scans each account's statement using a **traditional `for` loop** and converts customer behavior into points:
*   Each `Deposito` adds **10 points**.
*   Each `Saque` adds **5 points**.
*   Each `Tarifa` adds **0 points** and is pushed to the **Critical Items** subsection.

The formula calculates health by applying an explicit *cast* to `double` to prevent compiler numerical truncation, and includes active protection against division-by-zero errors (in case the account has no transactions):
$$\text{Percentage (\%)} = \left( \frac{\text{Earned Score}}{\text{Total Transactions} \times 10} \right) \times 100$$

### 📈 Conditional Classification Table
*   **90% to 100% [ Healthy Account ]**: Suggests offering investment products and evaluating credit limit increases.
*   **60% to 89% [ Attention Account ]**: Triggers account manager contact for financial guidance and strategic fee review.
*   **0% to 59% [ Risk Account ]**: Mandates the immediate blocking of credit limit increases and opening a credit risk analysis.

---

## 💻 4. Execution Instructions

### Prerequisites
*   [.NET SDK 10.0+](https://microsoft.com) installed on your machine.

### How to Run
1. Clone the public repository:
   ```bash
   git clone [https://github.com](https://github.com/rafaellaurentino-dev/minibanco-dotnet.git)
   ```
2. Navigate to the executable project folder:
   ```bash
   cd minibanco-dotnet/src/MiniBanco.ConsoleApp
   ```
3. Clear old compilation caching from memory:
   ```bash
   dotnet clean
   ```
4. Run the application:
   ```bash
   dotnet run
   ```

---

## ⚠️ 5. Limitations and Exception Handling
The system is fully immune to crashes and abrupt terminal terminations thanks to local persistence loops (`while(true)`) and structured catch blocks:
*   **`SaldoInsuficienteException`**: Triggered when attempting to withdraw values that exceed the financial capacity configured for the account type.
*   **`ArgumentException`**: Blocks invalid runtime inputs (such as negative values or incorrect types).
*   **`FormatException`**: Catches attempts to type alphabetical characters into strictly numerical fields, issuing feedback and repeating the input prompt without closing the console window.

---
---
