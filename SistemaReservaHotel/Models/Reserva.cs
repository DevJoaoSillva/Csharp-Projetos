using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesadioHospedagemHotel.Models;

namespace DesadioHospedagemHotel.Models
{
    class Reserva
    {
        public int Id { get; set; }
        public string TipoSuite { get; set; }
        public int QuantidadePessoas { get; set; }
        public double ValorDiaria { get; set; }
        public List<Pessoa> Pessoas { get; set; }
        public Suite Suite { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }

        public Reserva(int id, List<Pessoa> pessoas, Suite suite, DateTime dataEntrada, DateTime dataSaida)
        {
            try
            {
                if (pessoas.Count > suite.Capacidade)
                {
                    throw new Exception("A quantidade de pessoas é excede que a capacidade da suite");
                }
                if (dataEntrada >= dataSaida)
                {
                    throw new Exception("A data de entrada não pode ser maior que a data de saída");
                }
                if (pessoas == null || pessoas.Count == 0)
                {
                    throw new Exception("A reserva deve conter pelo menos um hóspede.");
                }
                if(suite == null)
                {
                    throw new Exception("A reserva deve conter uma suite.");
                }

                Id = Id;
                Pessoas = pessoas;
                Suite = suite;
                DataEntrada = dataEntrada;
                DataSaida = dataSaida;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao criar reserva: {e.Message}");
            }
        }

        public decimal CalcularValorTotal()
        {
            int diasHospedados = (DataSaida - DataEntrada).Days;
            decimal valorTotal = diasHospedados * (decimal)ValorDiaria;

            if(diasHospedados >= 10)
            {
                valorTotal *= 0.90M;
            }

            return valorTotal;
        }

        public void ExibirReserva()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("       Relatório de Reserva");
            Console.WriteLine("====================================");
            Console.WriteLine($"ID da Reserva: {Id}");
            Console.WriteLine($"Suite: {Suite.TipoSuite}");
            Console.WriteLine($"Quantidade de Hospedes: {QuantidadePessoas}");
            Console.WriteLine($"Valor da Diária: {ValorDiaria.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Data de Entrada: {DataEntrada.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Data de Saída: {DataSaida.ToString("dd/MM/yyyy")}");

            foreach(var pessoa in Pessoas)
            {
                Console.WriteLine($" - {pessoa.Nome}");
            }

            Console.WriteLine($"Valor Total da Reserva: {CalcularValorTotal():F2}");
            Console.WriteLine("====================================");

        }


        

        

        

    }
}

