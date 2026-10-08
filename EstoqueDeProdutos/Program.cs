using EstoqueDeProdutos.Models;
using EstoqueDeProdutos.Services;
using System.Text.Json;

string caminhoArquivo = "Dados/estoque.json";

string json = File.ReadAllText(caminhoArquivo);

JsonSerializerOptions opcoes = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
};

DadosEstoque? dados = JsonSerializer.Deserialize<DadosEstoque>(json, opcoes);

if (dados == null || dados.Estoque == null)
{
    Console.WriteLine("Não foi possível carregar os produtos do estoque.");
    return;
}

EstoqueService estoqueService = new EstoqueService(dados.Estoque);

bool continuar = true;

while (continuar)
{
    Console.WriteLine();
    Console.WriteLine("===== CONTROLE DE ESTOQUE =====");
    Console.WriteLine("1 - Listar produtos");
    Console.WriteLine("2 - Realizar movimentação");
    Console.WriteLine("0 - Sair");
    Console.WriteLine();

    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine()!;

    switch (opcao)
    {
        case "1":

            Console.WriteLine();
            Console.WriteLine("===== PRODUTOS =====");

            foreach (Produto produto in dados.Estoque)
            {
                Console.WriteLine(
                    $"{produto.CodigoProduto} - " +
                    $"{produto.DescricaoProduto} - " +
                    $"Estoque: {produto.Estoque}");
            }

            break;

        case "2":

            Console.WriteLine();
            Console.WriteLine("===== NOVA MOVIMENTAÇÃO =====");

            Console.Write("Digite o código do produto: ");
            int codigoProduto = int.Parse(Console.ReadLine()!);

            Console.Write("Digite o tipo (ENTRADA/SAIDA): ");
            string tipo = Console.ReadLine()!;

            Console.Write("Digite a descrição da movimentação: ");
            string descricao = Console.ReadLine()!;

            Console.Write("Digite a quantidade: ");
            int quantidade = int.Parse(Console.ReadLine()!);

            try
            {
                int estoqueFinal = estoqueService.RealizarMovimentacao(
                    codigoProduto,
                    tipo,
                    descricao,
                    quantidade);

                Console.WriteLine();
                Console.WriteLine("Movimentação realizada com sucesso!");
                Console.WriteLine($"Estoque final: {estoqueFinal}");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Erro: {ex.Message}");
            }

            break;

        case "0":

            continuar = false;
            Console.WriteLine("Sistema encerrado.");

            break;

        default:

            Console.WriteLine("Opção inválida.");

            break;
    }
}