using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesadioHospedagemHotel.Models
{
    class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenone { get; set; }
        public string Telefone { get; set; }

        public Pessoa(int id, string Nome, string Sobrenome, string Telefone)
        {
            try
            {
                Id = id;
                if (String.IsNullOrWhiteSpace(Nome))
                {
                    throw new Exception("O Nome do hospede não pode ser vazio");
                }
                this.Nome = Nome;

                if (String.IsNullOrWhiteSpace(Sobrenome))
                {
                    throw new Exception("O Sobrenome do Hospede não pode ser vazio");
                }
                this.Sobrenone = Sobrenone;

                if (String.IsNullOrWhiteSpace(Telefone))
                {
                    throw new Exception("O telefone do hospede não pode ser vazio");
                }
                this.Telefone = Telefone;

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao Criar Hospede { e.Message}");
            }
        }

        public void ExibirInformacoes()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("      Detalhes do Hospede");
            Console.WriteLine("====================================");
            Console.WriteLine($"ID da Hospede: {Id}");
            Console.WriteLine($"Nome: {Nome} {Sobrenone}");
            Console.WriteLine($"Telefone: {Telefone}");
            Console.WriteLine("====================================");
        }


    }
}
