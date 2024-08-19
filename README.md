<h1>Projeto Cálculo do CDB</h1> 

<p align="center">
  <img src="https://img.shields.io/static/v1?label=.NET&message=CODE&color=blue&style=for-the-badge&logo=.NET"/>
  <img src="https://img.shields.io/static/v1?label=ANGULAR&message=framework&color=blue&style=for-the-badge&logo=ANGULAR"/>
  <img src="https://img.shields.io/static/v1?label=XUNIT&message=TEST&color=blue&style=for-the-badge&logo=XUNIT"/> 
  <img src="https://img.shields.io/static/v1?label=nodejs&message=framework&color=blue&style=for-the-badge&logo=NODEJS"/>
  <img src="https://img.shields.io/static/v1?label=typescript&message=framework&color=blue&style=for-the-badge&logo=TYPESCRIPT"/>
</p>

> Status do Projeto: :heavy_check_mark: concluido 

### Tópicos 

:small_blue_diamond: [Descrição do projeto](#descrição-do-projeto)

:small_blue_diamond: [Funcionalidades](#funcionalidades)
 
:small_blue_diamond: [Pré-requisitos](#pré-requisitos)

:small_blue_diamond: [Como rodar a aplicação](#como-rodar-a-aplicação-arrow_forward)

:small_blue_diamond: [Como rodar os testes](#como-rodar-os-testes)
 
## Descrição do projeto 

<p align="justify">
  <b>Teste/Case - Desafio do Cálculo do CDB</b>
  
O objetivo da solução criada é implementar um sistema que permita a avaliação de investimentos em CDB (Certificado de Depósito Bancário) com base em parâmetros fornecidos pelo usuário. Mais especificamente, a solução deve:


1. Permitir ao usuário:
	Informar um valor monetário inicial positivo.
	Informar um prazo em meses para o resgate do investimento.

2. Calcular e apresentar:
	Resultado Bruto: O valor total acumulado ao final do prazo informado, considerando a fórmula de capitalização mensal.
	Resultado Líquido: O valor bruto menos o imposto aplicável, conforme a tabela de impostos definida.

3. Implementar:
	Uma tela web que possibilite ao usuário fornecer os dados necessários e visualizar os resultados.
	Uma Web API que receba os dados da tela web e execute os cálculos necessários com base na fórmula fornecida e na tabela de impostos.
	 
</p>

1. API Rest que calcula o investimento CDB, com os seguintes parâmetros de entrada:  

- Valor: numérico (decimal, positivo)
- PrazoEmMeses: numérico (inteiro, positivo)

2. Portal Web com a tela principal com os mesmos campos do item 1. e um botão 'Calcular'.


<H2>Aplicação de SOLID</H2>

**Single Responsibility Principle (SRP)**: Cada classe tem uma única responsabilidade. Por exemplo, InvestimentoRequest apenas encapsula os dados de entrada, enquanto InvestimentoCDB faz o cálculo.

**Open/Closed Principle (OCP)**: InvestimentoCDB está aberta para extensão, mas fechada para modificação. Se, por exemplo, você precisar de um novo tipo de cálculo de investimento, basta criar uma nova classe que implemente IInvestimento.

**Liskov Substitution Principle (LSP)**: Ao usar a interface IInvestimento, é garantido que qualquer implementação pode substituir a original sem quebrar o código.

**Interface Segregation Principle (ISP)**: IInvestimento é uma interface simples e específica, não obrigando classes a implementar métodos que não necessitam.

**Dependency Inversion Principle (DIP)**: A lógica de cálculo depende da abstração (IInvestimento), permitindo que a implementação concreta seja injetada em tempo de execução.



## Funcionalidades

API: Org.CalculoCDB.Api
- POST - /InvestimentoCDB - Calcula o valor bruto, valor líquido e valor da taxa (JSON);


Web: Org.CalculoCDB.Web
- Tela principal - Calcula o valor bruto, valor líquido e valor da taxa;

## Pré-requisitos

<H2>API</H2>
- [.NET] 5.0; 
- [Swagger] 5.6.3;
- [XUnit] 2.4.1;

<H2>Web</H2>
- [Typescript] 5.5.4;
- [Angular] 18.2.0; 

## Como rodar a aplicação :arrow_forward:

<H2>API</H2>

No terminal, clone o projeto: 

```
git clone https://github.com/wvitorhugo/calculo-cdb.git
```

Abra a solução src\Org.CalculoCDB.sln no Visual Studio.

Verifique se todos os pacotes NuGet foram restaurados corretamente. Se necessário, "Restore NuGet Packages".


1. **Defina o projeto da API como projeto de inicialização:**
   - Clique com o botão direito no projeto da API (Org.CalculoCDB.Api) e selecione ""Set as StartUp Project".

2. **Execute a API:**
   - Pressione F5 ou clique em "Start" no Visual Studio para iniciar a API.

3. **Verifique se a API está em execução corretamente:**
   - Abra um navegador e acesse `https://localhost:44334/swagger/index.html` para confirmar se a API está respondendo como esperado pelo Swagger.
   

<H2>Web</H2>

Abra o diretório src\Org.CalculoCDB.Web\ no Terminal.

1. **Instale as dependências do projeto:**

```
npm install
```

No terminal, inicie server: 

```
ng serve
```

Acesse a aplicação no browser na url: http://localhost:4200/: 
 

## Como rodar os testes da API 

Abra a solução src\Org.CalculoCDB.sln no Visual Studio.

1. No menu 'Test', clique em 'Run All Tests';

2. Visualize no 'Test Explorer'

 

## Licença 

The [MIT License]() (MIT)

Copyright :copyright: 2024 - Projeto Calculo CDB