using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesadioHospedagemHotel.Models
{
    class Suite
    {
        public int Id { get; set; } 
        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public double ValorDiaria { get; set; }

        public Suite(int id, string TipoSuite, int Capacidade, double ValorDiaria)
        {
            try
            {
                Id = id;
                if (String.IsNullOrWhiteSpace(TipoSuite))
                {
                    throw new Exception("O tipo da suite não pode ser vazio");
                }
                this.TipoSuite = TipoSuite;

                if (Capacidade <= 0)
                {
                    throw new Exception("A quantidade de pessoas deve ser maior que zero");
                }
                this.Capacidade = Capacidade;

                if (ValorDiaria < 60.00)
                {
                    throw new Exception("O valor da diária deve ser maior que R$ 60,00");
                }
                this.ValorDiaria = ValorDiaria;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao Criar Suite { e.Message}");
            }
        }

        public void ExibirInformacoesSuite()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("      Detalhes da Suite");
            Console.WriteLine("====================================");
            Console.WriteLine($"ID da Suite: {Id}");
            Console.WriteLine($"Suite: {TipoSuite}");
            Console.WriteLine($"Capacidade: {Capacidade}");
            Console.WriteLine($"Valor da Diária: {ValorDiaria.ToString("C")}");
            Console.WriteLine("====================================");
        }

    }
}
