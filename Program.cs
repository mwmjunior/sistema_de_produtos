using System;
using System.IO;

namespace SistemaDeProduto {

  class Program {

    static void Main(string[] args) {

      // Declarando arrays 3 arrays vazios para armazenar até 10 elementos das informações dos produtos 
      string[] produtos = new string[10];
      float[] precos = new float[10];
      char[] promocoes = new char[10];

      int escolha;
      int contador = 0;

      do {

        Console.Clear();
        
        //  Menu com várias opções relacionadas à administração de produtos.
        Console.WriteLine("Bem Vindo! Escolha entre as opções abaixo:");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("[1]- Cadastrar Produtos e preços");
        Console.WriteLine("[2]- Listar Produtos");
        Console.WriteLine("[3]- Mostrar Produtos em promoção");
        Console.WriteLine("[4]- Apagar Produto");
        Console.WriteLine("[0]- Sair");
        Console.WriteLine("---------------------------------------------");

        escolha = int.Parse(Console.ReadLine());

        switch (escolha) {
        case 1: 
         // Cadastra produtos e preços                                                
          Console.Clear();
          Console.WriteLine(@"    Cadastrar Produtos"   );
          Console.WriteLine("--------------------------");

          do {
            if (contador < 10) // Permite ao usuário cadastrar até 10 produtos com seus respectivos nome, preço e se o produto está em promoção
            {
              Console.WriteLine($"Escreva o nome do produto: ");
              produtos[contador] = Console.ReadLine();

              Console.WriteLine($"Digite o preço do produto:");
              precos[contador] = float.Parse(Console.ReadLine());

              Console.WriteLine($"O produto está em promoção? (S/N):");
              char resposta = Console.ReadKey().KeyChar;
              Console.WriteLine();

              // Verifica se a resposta é S ou N, 
              if (resposta == 'S' || resposta == 's') 
                {
                   promocoes[contador] = 'S';
                } 
              
              else if (resposta == 'N' || resposta == 'n') 
                {
                   promocoes[contador] = 'N';
                } 
              
              else 
                {
                Console.WriteLine("Opção inválida! A resposta deve ser S ou N.");
                continue; // Volta para o início do loop e pede para o usuário digitar a resposta novamente
                }

              contador++;

              Console.WriteLine("Deseja cadastrar outro produto? (S/N)");
              resposta = Console.ReadKey().KeyChar;
              Console.WriteLine();

              if (resposta == 'N' || resposta == 'n') 
              {
                break;
              }
            } 
            
            else 
            {
              Console.WriteLine("Limite cadastramento de produtos excedido!");
              break;
            }

          } while (true);

          break;

        case 2:
          // Lista os produtos cadastrados
          Console.Clear();
          Console.WriteLine(@"    Listagem de produtos   ");
          Console.WriteLine("----------------------------");


          // Mostra ao usuário a lista de todos os produtos cadastrados
          for (var i = 0; i < contador; i++) {
            Console.WriteLine($"{i}. {produtos[i]}, Valores: {precos[i]:C}, Ofertas: {promocoes[i]}");
          }

           Console.WriteLine();
           Console.Write("Aperte <Enter> para sair... ");
           while (Console.ReadKey(true).Key != ConsoleKey.Enter) {}

          break;


        case 3:
          // Mostra apenas os produtos que estão em promoção
          Console.WriteLine("Mostrar os produtos que vão estar em promoção");
          Console.WriteLine("-----------------------------------------------");

          for (var i = 0; i < contador; i++) {
            if (promocoes[i] == 'S') {
              Console.WriteLine($"{i}. {produtos[i]}, Valores: {precos[i]:C}, Ofertas: {promocoes[i]}");
            }
          }
          
          Console.WriteLine();
          Console.Write("Aperte <Enter> para sair... ");
          while (Console.ReadKey(true).Key != ConsoleKey.Enter) {}
          break;

        case 4:
          // Permite ao usuário remover um produto da lista de produtos cadastrados
          Console.WriteLine("Digite o nome do produto que deseja apagar:");
          string nomeProduto = Console.ReadLine();

          // Busca o índice do produto no array "produtos"
          int indexProduto = Array.IndexOf(produtos, nomeProduto);

          // Verifica se o produto foi encontrado ou não
          if (indexProduto == -1) {
            Console.WriteLine($"O produto {nomeProduto} não está cadastrado.");
          } else {
            // Remove o produto do array, movendo todos os elementos para a esquerda
            for (int i = indexProduto; i < contador; i++) {
              produtos[i] = produtos[i + 1];
              precos[i] = precos[i + 1];
              promocoes[i] = promocoes[i + 1];
            }

            contador--; // Decrementa o contador de produtos cadastrados

            Console.WriteLine($"O produto {nomeProduto} foi apagado com sucesso!");
          }

          break;

        default:
          Console.WriteLine("");
          break;
        }
      } while (escolha != 0); //  Saia do programa ao digitar 0
    }
  }
}