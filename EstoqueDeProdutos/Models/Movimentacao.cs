

namespace EstoqueDeProdutos.Models;

public class Movimentacao
{
    public int Id { get; set; }

    public int CodigoProduto { get; set; }

    public string Tipo { get; set; }

    public string Descricao { get; set; }

    public int Quantidade { get; set; }
}