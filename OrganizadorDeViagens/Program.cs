using System;
using System.Collections.Generic;

namespace OrganizadorDeViagens
{
    class Viagem
    {
        public string Destino { get; set; }
        public DateTime DataPartida { get; set; }
        public int NumeroDias { get; set; }

        public override string ToString()
        {
            return $"Destino: {Destino}, Partida: {DataPartida:dd/MM/yyyy}, Duração: {NumeroDias} dia(s)";
        }
    }

    class Program
    {
        static List<Viagem> viagens = new();

        static void Main()
        {
            var sair = 0;

            while (sair == 1)
            {
                Console.WriteLine("\n=== ORGANIZADOR DE VIAGENS ===");
                Console.WriteLine("1. Adicionar nova viagem");
                Console.WriteLine("2. Listar viagens");
                Console.WriteLine("3. Sair");
                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarViagem();
                        break;

                    case "2":
                        ListarViagens();
                        break;

                    case "3":
                        Console.WriteLine("Saindo...");
                        sair = 1;
                        return;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static void AdicionarViagem()
        {
            Console.Write("Digite o destino: ");
            string destino = Console.ReadLine();

            Console.Write("Digite a data de partida (dd/MM/yyyy): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataPartida))
            {
                Console.WriteLine("Data inválida.");
                return;
            }

            Console.Write("Digite o número de dias: ");
            if (!int.TryParse(Console.ReadLine(), out int numeroDias))
            {
                Console.WriteLine("Número de dias inválido.");
                return;
            }

            viagens.Add(new Viagem
            {
                Destino = destino,
                DataPartida = dataPartida,
                NumeroDias = numeroDias
            });

            Console.WriteLine("Viagem adicionada com sucesso!");
        }

        static void ListarViagens()
        {
            if (viagens.Count == 0)
            {
                Console.WriteLine("Nenhuma viagem cadastrada.");
                return;
            }

            Console.WriteLine("\n== Lista de Viagens ==");
            foreach (var viagem in viagens)
            {
                Console.WriteLine(viagem);
            }
        }
    }
}
