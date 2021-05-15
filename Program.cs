using System;

namespace ProjetoProdutosConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int u = 0;
            int i = 0;
            int tamanhoArray = 10;
            string opcao;
            string[] nomeProduto = new string[tamanhoArray];
            float[] preco = new float[tamanhoArray];
            bool[] promocao = new bool[tamanhoArray];
            bool refazerMenu = false;

            Console.WriteLine("Olá bem vindo ao supermercado online!");
            while (refazerMenu == false)
            {
                Menu();
                Console.Write("\nDigite: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {

                    case "1":
                        CadastrarProduto(nomeProduto, preco, promocao, refazerMenu, i, u);
                        i++;
                        break;

                    case "2":
                        ListarProdutos(nomeProduto, preco, promocao, i, u);
                        break;
                    case "0":
                    Console.WriteLine("\n- - - Seção encerrada - - -\n");
                        refazerMenu = true;
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida!");
                        break;
                }
            }
        }


        static void Menu()
        {
            Console.WriteLine($@"
===========================
|- - - - - MENU - - - - - |
|=========================|
| 1 - Cadastrar Produto   |
| 2 - Listar Produtos     |
| 0 - Sair                |
===========================");
        }


        static void CadastrarProduto(string[] nomeProduto, float[] preco, bool[] promocao, bool refazerMenu, int i, int u)
        {
            string respostaPromocao;

            string respostaRepetir;

            bool refazerCadastro = false;

            do
            {
                if (i < 2)
                {
                    Console.WriteLine($"{i + 1}º cadastro");

                    Console.Write("Insira o nome do produto: ");
                    nomeProduto[i] = Console.ReadLine();

                    Console.Write("Insira o valor do produto: ");
                    preco[i] = float.Parse(Console.ReadLine());

                    Console.WriteLine("O produto está em promoção? (s) se sim e (n) se não");
                    respostaPromocao = Console.ReadLine().ToLower();

                    switch (respostaPromocao)
                    {
                        case "s":
                            promocao[i] = true;
                            break;
                        default:
                            promocao[i] = false;
                            break;
                    }

                    Console.WriteLine("Quer adicionar mais algum produto? (s) se sim e (n) se não");
                    respostaRepetir = Console.ReadLine().ToLower();
                    if (respostaRepetir != "s")
                    {
                        refazerCadastro = true;
                        i++;
                    }

                    else
                    {
                        switch (i > 2)
                        {
                            case true:
                                Console.WriteLine("Número máximo de produtos atingido!");
                                break;
                            default:
                                break;
                        }

                        refazerMenu = false;
                        i++;
                    }
                }

                else
                {
                    Console.WriteLine("Número máximo de produtos atingido!");
                    refazerCadastro = true;
                    refazerMenu = false;
                }

            } while (refazerCadastro == false);
        }


        static void ListarProdutos(string[] nomeProduto, float[] preco, bool[] promocao, int i, int u)
        {
            if (i > 0)
            {
                for (u = 0; u < i + 1; u++)
                {
                    if (u < i)
                    {
                        Console.WriteLine($@"
========================================
|   Nome   |   Valor   |   Promoção    |
========================================
    {nomeProduto[u]}          {preco[u]}           {(promocao[u] ? "Sim" : "Não")}");
                    }
                }
            }
            else
            {
               Console.WriteLine("\nNenhum produto Cadastrado");
               i ++; 
            }
        }
    }
}

