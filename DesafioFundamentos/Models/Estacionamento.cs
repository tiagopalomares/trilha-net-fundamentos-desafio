using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
     public class Veiculo
    {
        public string Placa { get; set; }
        public string NomeCarro { get; set; }

        public Veiculo(string placa, string nomeCarro)
        {
            Placa = placa;
            NomeCarro = nomeCarro;
        }
    }

    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();
         private List<string> nomesDeCarros = new List<string>
        {
            "Civic", "Corolla", "Fiesta", "Golf", "Meriva", "Palio", "Uno", "Fox", "Jetta", "Passat"
        };

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // Implementado
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
             if (veiculos.Any(x => x.Placa.ToUpper() == placa.ToUpper()))
              {
                 Console.WriteLine("Esse veículo já está cadastrado.");
             }
             else
              {
               // Seleciona um nome de carro aleatoriamente
                Random random = new Random();
                int indiceAleatorio = random.Next(nomesDeCarros.Count);
                string nomeCarro = nomesDeCarros[indiceAleatorio];

                veiculos.Add(new Veiculo(placa, nomeCarro));
                Console.WriteLine($"{nomeCarro} de placa {placa} estacionado com sucesso.");
             }
            
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // Implementado
            string placa = Console.ReadLine();
            var veiculo = veiculos.FirstOrDefault(x => x.Placa.ToUpper() == placa.ToUpper());

            // Verifica se o veículo existe
            if (veiculo != null)
            {
                Console.WriteLine("Digite a quantidade de horas adicionais que o veículo permaneceu estacionado: \nOBS se você ficou apenas 1 hora digite 0");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // Implementado
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas;

                // TODO: Remover a placa digitada da lista de veículos
                // Implementado
                veiculos.Remove(veiculo);

                Console.WriteLine($"O veículo {veiculo.NomeCarro} de placa {veiculo.Placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Count == 0)
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
            else
            {
                Console.WriteLine("Veículos estacionados:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Carro: {veiculo.NomeCarro}, Placa: {veiculo.Placa}");
                }
            }
        }
    }
}
