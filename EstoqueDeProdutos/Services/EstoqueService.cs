using EstoqueDeProdutos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstoqueDeProdutos.Services;

public class EstoqueService
{
    private readonly List<Produto> _produtos;
    private readonly List<Movimentacao> _movimentacoes;

    public EstoqueService(List<Produto> produtos)
    {
        _produtos = produtos;
        _movimentacoes = new List<Movimentacao>();
    }

    public int RealizarMovimentacao(

    int codigoProduto,
    string tipo,
    string descricao,
    int quantidade)

    {
        Produto? produto = _produtos
            .FirstOrDefault(p => p.CodigoProduto == codigoProduto);

        if (produto == null)
        {
            throw new Exception("Produto não encontrado.");
        }

        if (quantidade <= 0)
        {
            throw new Exception("A quantidade deve ser maior que zero.");
        }

        if (tipo.ToUpper() == "ENTRADA")
        {
            produto.Estoque += quantidade;
        }
        else if (tipo.ToUpper() == "SAIDA")
        {
            if (quantidade > produto.Estoque)
            {
                throw new Exception("Estoque insuficiente.");
            }

            produto.Estoque -= quantidade;
        }
        else
        {
            throw new Exception("Tipo de movimentação inválido.");
        }

        Movimentacao movimentacao = new Movimentacao
        {
            Id = _movimentacoes.Count + 1,
            CodigoProduto = codigoProduto,
            Tipo = tipo,
            Descricao = descricao,
            Quantidade = quantidade
        };

        _movimentacoes.Add(movimentacao);

        return produto.Estoque;
    }
}
