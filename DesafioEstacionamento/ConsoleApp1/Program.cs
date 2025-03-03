using System;
using System.Collections.Generic;

namespace Estacionamento
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) // Loop infinito até o usuário escolher sair
            {
                Console.Clear();
                Console.WriteLine("==============================");
                Console.WriteLine("  SISTEMA DE ESTACIONAMENTO ");
                Console.WriteLine("==============================");
                Console.WriteLine("Selecione uma opção: ");
                Console.WriteLine("1 - Adicionar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Sair");
                Console.Write("Digite a opção desejada: ");

                // Lendo a entrada do usuário
                if (!int.TryParse(Console.ReadLine(), out int opcao))
                {
                    Console.WriteLine("Opção inválida! Pressione Enter para continuar...");
                    Console.ReadLine();
                    continue; // Volta para o menu
                }

                switch (opcao)
                {
                    case 1:
                        Veiculo.AdicionarVeiculo();
                        break;
                    case 2:
                        Veiculo.RemoverVeiculo();
                        break;
                    case 3:
                        Veiculo.ListarVeiculos();
                        break;
                    case 4:
                        Console.WriteLine("Saindo do sistema...");
                        return; // Encerra o programa
                    default:
                        Console.WriteLine("Opção inválida! Pressione Enter para continuar...");
                        break;
                }

                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine(); // Aguarda o usuário antes de voltar ao menu
            }
        }
    }
}
