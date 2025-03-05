using DesadioHospedagemHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesadioHospedagemHotel.Models;
namespace DesadioHospedagemHotel
{
  
    class Program
    {
        static List<Pessoa> hospedes = new List<Pessoa>();
        static List<Suite> suites = new List<Suite>();
        static List<Reserva> reservas = new List<Reserva>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("   Sistema de Hospedagem de Hotel");
                Console.WriteLine("====================================");
                Console.WriteLine("Menu de Opções");
                Console.WriteLine("1 - Cadastrar Hospedes");
                Console.WriteLine("2 - Cadastrar Suite");
                Console.WriteLine("3 - Listar Hospedes");
                Console.WriteLine("4 - Listar Suites");
                Console.WriteLine("5 - Reservar Suite");
                Console.WriteLine("6 - Calcular Valor Diária");
                Console.WriteLine("7 - Sair");
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
                        CadastrarHospedes();
                        break;
                    case 2:
                        CadastrarSuite();
                        break;
                    case 3:
                        ListarHospedes();
                        break;
                    case 4:
                        ListarSuites();
                        break;
                    case 5:
                        ReservarSuite();
                        break;
                    case 6:
                        CalcularValorReserva();
                        break;
                    case 7:
                        Console.WriteLine("Saindo do sistema...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida! Pressione Enter para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public static void CadastrarHospedes()
        {

            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("   Cadastro de Hospedes");
            Console.WriteLine("====================================");
            Console.Write("Digite o nome do hospede: ");
            string nome = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome do hospede não pode ser vazio. Pressione Enter para continuar...");
                Console.ReadLine();
                return;
            }
            Console.Write("Digite o sobrenome do hospede: ");
            string sobrenome = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(sobrenome))
            {
                Console.WriteLine("Sobrenome do hospede não pode ser vazio. Pressione Enter para continuar...");
                Console.ReadLine();
                return;
            }
            Console.Write("Digite o telefone do hospede: ");
            string telefone = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(telefone))
            {
                Console.WriteLine("Telefone do hospede não pode ser vazio. Pressione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            hospedes.Add(new Pessoa(hospedes.Count + 1, nome, sobrenome, telefone));
            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
        }

        public static void CadastrarSuite()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("        Cadastro de Suite");
            Console.WriteLine("====================================");
            Console.Write("Digite o ID da suite: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Digite o tipo(nome) da suite: ");
            string tipoSuite = Console.ReadLine();
            
            Console.Write("Digite a capacidade da suite (1 - 6 Pessoas): ");
            int capacidade = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor da diária da suite: ");
            double valorDiaria = double.Parse(Console.ReadLine());
            
            suites.Add(new Suite(id, tipoSuite, capacidade, valorDiaria));
            Console.WriteLine("Suite cadastrada com sucesso!");


            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
        }

        public static void ListarHospedes()
        {
            Console.Clear();
            if(hospedes.Count == 0)
            {
                Console.WriteLine("Nenhum hospede cadastrado.");
            }
            else
            {
                Console.WriteLine("====================================");
                Console.WriteLine("        Lista de Hospedes");
                Console.WriteLine("====================================");
                foreach(var hospede in hospedes)
                {
                    Console.WriteLine($"-> Nome Completo: {hospede.Nome} {hospede.Sobrenone}\n-> Telefone: {hospede.Telefone}\n\n");
                }
            }
            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();

        }

        public static void ListarSuites()
        {
            Console.Clear();
            if(suites.Count == 0)
            {
                Console.WriteLine("Nenhuma suite cadastrada.");
            }
            else
            {
                Console.WriteLine("====================================");
                Console.WriteLine("        Lista de Suites");
                Console.WriteLine("====================================");
                foreach(var suite in suites)
                {
                    Console.WriteLine($"-> Suite: {suite.TipoSuite}\n-> Capacidade: {suite.Capacidade} Pessoas\n-> Valor Diaria: {suite.ValorDiaria.ToString("C")}\n\n");
                }

            }
            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
        }

        public static void ReservarSuite()
        {
            Console.Clear();
            if (suites.Count == 0)
            {
                Console.WriteLine("Não há nenhuma suite disponível para reserva.");
                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Listar suites disponíveis
            Console.WriteLine("Suites disponíveis:");
            foreach (var suite in suites)
            {
                Console.WriteLine($"ID: {suite.Id}, Tipo: {suite.TipoSuite}, Capacidade: {suite.Capacidade}, Valor Diária: {suite.ValorDiaria.ToString("C")}");
            }

            Console.Write("Digite o ID da suite desejada: ");
            if (!int.TryParse(Console.ReadLine(), out int idSuite))
            {
                Console.WriteLine("ID inválido! Pressione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Suite suiteSelecionada = suites.Find(s => s.Id == idSuite);
            if (suiteSelecionada == null)
            {
                Console.WriteLine("Suite não encontrada! Pressione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.Write("Quantos hóspedes ficarão? ");
            if (!int.TryParse(Console.ReadLine(), out int qtdHospedes) || qtdHospedes <= 0)
            {
                Console.WriteLine("Quantidade de hóspedes inválida! Pressione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            if (qtdHospedes > suiteSelecionada.Capacidade)
            {
                Console.WriteLine("A quantidade de hóspedes excede a capacidade da suite! Pressione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            List<Pessoa> hospedesReserva = new List<Pessoa>();
            for (int i = 0; i < qtdHospedes; i++)
            {
                Console.Write($"Digite o nome do hóspede {i + 1}: ");
                string nomeHospede = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nomeHospede))
                {
                    Console.WriteLine("Nome do hóspede não pode ser vazio! Pressione Enter para continuar...");
                    Console.ReadLine();
                    return;
                }

                Pessoa hospede = hospedes.Find(h => h.Nome == nomeHospede);
                if (hospede == null)
                {
                    Console.WriteLine($"Hóspede '{nomeHospede}' não encontrado! Pressione Enter para continuar...");
                    Console.ReadLine();
                    return;
                }
                hospedesReserva.Add(hospede);
            }

            Console.Write("Digite a data de entrada (dd/MM/aaaa): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataEntrada))
            {
                Console.WriteLine("Data de entrada inválida! Pressione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.Write("Digite a data de saída (dd/MM/aaaa): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataSaida) || dataSaida <= dataEntrada)
            {
                Console.WriteLine("Data de saída inválida ou menor que a data de entrada! Pressione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            try
            {
                Reserva reserva = new Reserva(reservas.Count + 1, hospedesReserva, suiteSelecionada, dataEntrada, dataSaida);
                reservas.Add(reserva);
                Console.WriteLine("Reserva efetuada com sucesso!");
                Console.WriteLine($"Reserva criada com ID: {reserva.Id}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao efetuar reserva: {e.Message}");
            }

            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
        }

        public static void CalcularValorReserva()
        {
            Console.Clear();
            if (reservas.Count == 0)
            {
                Console.WriteLine("Nenhuma reserva efetuada.");
                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Listar todas as reservas para facilitar a escolha do usuário
            Console.WriteLine("Reservas cadastradas:");
            foreach (var reserva in reservas)
            {
                Console.WriteLine($"ID: {reserva.Id}, Suite: {reserva.Suite.TipoSuite}, Hóspedes: {reserva.Pessoas.Count}");
            }

            Console.Write("Digite o ID da reserva para calcular o valor total: ");
            if (!int.TryParse(Console.ReadLine(), out int idReserva))
            {
                Console.WriteLine("ID inválido! Pressione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Buscar a reserva pelo ID
            Reserva reservaEncontrada = reservas.Find(r => r.Id == idReserva);
            if (reservaEncontrada == null)
            {
                Console.WriteLine("Reserva não encontrada! Pressione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Chamar o método CalcularValorTotal e exibir o resultado
            decimal valorTotal = reservaEncontrada.CalcularValorTotal();
            Console.WriteLine("====================================");
            Console.WriteLine($"Valor Total da Reserva: {valorTotal.ToString("C")}");
            Console.WriteLine("====================================");
            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
        }

    }
}
