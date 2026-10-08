using System.Text.Json.Serialization;

namespace EstoqueDeProdutos.Models;

public class DadosEstoque
{
    [JsonPropertyName("estoque")]
    public List<Produto> Estoque { get; set; } = new();
}