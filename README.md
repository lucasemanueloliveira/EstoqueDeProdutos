# Controle de Movimentação de Estoque

Solução desenvolvida em **C#/.NET** como parte de um desafio técnico proposto durante um processo seletivo.

## Sobre o projeto

O desafio consiste em desenvolver um programa capaz de realizar movimentações de estoque dos produtos armazenados em um arquivo JSON, permitindo registrar **entradas e saídas de mercadorias** no depósito.

Cada movimentação deve possuir:

- Um número identificador único.
- Uma descrição para identificar o tipo de movimentação realizada.
- A quantidade movimentada.
- A identificação do produto movimentado.

Ao final de cada movimentação, a aplicação deve apresentar a **quantidade final disponível em estoque** para o produto movimentado.

## Funcionalidades

A aplicação permite:

- Consultar os produtos disponíveis no estoque.
- Realizar movimentações de entrada de mercadorias.
- Realizar movimentações de saída de mercadorias.
- Identificar cada movimentação por meio de um número único.
- Registrar uma descrição para a movimentação.
- Atualizar a quantidade disponível do produto.
- Exibir o estoque final após cada movimentação.

## Estrutura dos dados

Os produtos são armazenados inicialmente em um arquivo JSON contendo informações como código, descrição e quantidade em estoque.

Exemplo:

```json
{
  "estoque": [
    {
      "codigoProduto": 101,
      "descricaoProduto": "Caneta Azul",
      "estoque": 150
    }
  ]
}
```

## Exemplo de movimentação

Considerando o produto:

```text
Código: 101
Produto: Caneta Azul
Estoque inicial: 150
```

Após uma movimentação de **entrada de 20 unidades**:

```text
Movimentação: 001
Tipo: Entrada
Quantidade: 20

Estoque final: 170
```

Em uma movimentação de **saída de 30 unidades**:

```text
Movimentação: 002
Tipo: Saída
Quantidade: 30

Estoque final: 140
```

## Tecnologias utilizadas

- C#
- .NET
- JSON
- System.Text.Json
- Programação Orientada a Objetos
- Git
- GitHub

## Estrutura do projeto

```text
SistemaDeVendas/
│
├── Models/
│
├── Program.cs
│
├── estoque.json
│
└── README.md
```

## Como executar

1. Clone o repositório.
2. Abra o projeto no Visual Studio.
3. Compile a aplicação.
4. Execute o projeto.
5. Selecione o produto e informe os dados da movimentação.

## Objetivo

Este projeto foi desenvolvido para atender ao segundo requisito apresentado no desafio técnico, demonstrando a implementação de operações de **entrada e saída de estoque**, identificação de movimentações e atualização do saldo de produtos utilizando **C#/.NET**.
