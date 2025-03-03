using System;
using System.Collections.Generic;

namespace Estacionamento
{
    class Veiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string Ano { get; set; }

        // Lista estática para armazenar os veículos
        private static List<Veiculo> veiculos = new List<Veiculo>();

        // Construtor principal
        public Veiculo(string marca, string modelo, string placa, string cor, string ano)
        {
            Marca = marca;
            Modelo = modelo;
            Placa = placa;
            Cor = cor;
            Ano = ano;
        }

        // Construtor vazio opcional
        public Veiculo() { }

        // Método para adicionar um veículo
        public static void AdicionarVeiculo()
        {
            Console.Write("Informe a marca do veículo: ");
            string marca = Console.ReadLine();
            Console.Write("Informe o modelo do veículo: ");
            string modelo = Console.ReadLine();
            Console.Write("Informe a placa do veículo: ");
            string placa = Console.ReadLine();
            Console.Write("Informe a cor do veículo: ");
            string cor = Console.ReadLine();
            Console.Write("Informe o ano do veículo: ");
            string ano = Console.ReadLine();

            // Criar e adicionar o veículo à lista
            Veiculo veiculo = new Veiculo(marca, modelo, placa, cor, ano);
            veiculos.Add(veiculo);

            Console.WriteLine("Veículo adicionado com sucesso!\n");
        }

        public static void RemoverVeiculo()
        {
            if (veiculos.Count == 0)
            {
                Console.WriteLine("Nenhum veículo cadastrado para remover.");
                return;
            }

            Console.WriteLine("Informe a placa do veículo que deseja remover: ");
            string placa = Console.ReadLine();

            foreach (var veiculo in veiculos)
            {
                if (veiculo.Placa == placa)
                {
                    veiculos.Remove(veiculo);
                    Console.WriteLine("Veículo removido com sucesso!\n");
                    return;
                }
            }

            Console.WriteLine("Veículo não encontrado!\n");
        }


        // Método para listar os veículos
        public static void ListarVeiculos()
        {
            if (veiculos.Count == 0)
            {
                Console.WriteLine("Nenhum veículo cadastrado.");
                return;
            }

            Console.WriteLine("\nLista de veículos cadastrados:");
            foreach (Veiculo veiculo in veiculos)
            {
                Console.WriteLine($"Marca: {veiculo.Marca}, Modelo: {veiculo.Modelo}, Placa: {veiculo.Placa}, Cor: {veiculo.Cor}, Ano: {veiculo.Ano}\n");
            }
        }
    }
}
