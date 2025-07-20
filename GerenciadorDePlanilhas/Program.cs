using System;
using System.Collections.Generic;
using System.Globalization;

namespace PlanilhaFinanceira
{
    enum TipoTransacao
    {
        Receita,
        Despesa
    }

    class Transacao
    {
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoTransacao Tipo { get; set; }

        public override string ToString()
        {
            string tipoTexto = Tipo == TipoTransacao.Receita ? "Receita" : "Despesa";
            return $"{Data:dd/MM/yyyy} | {tipoTexto,-7} | {Descricao,-20} | R$ {Valor,8:F2}";
        }
    }

    class Program
    {
        static List<Transacao> transacoes = new();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n=== GERENCIADOR DE PLANILHA FINANCEIRA ===");
                Console.WriteLine("1. Adicionar Receita");
                Console.WriteLine("2. Adicionar Despesa");
                Console.WriteLine("3. Listar Transações");
                Console.WriteLine("4. Mostrar Saldo Atual");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": AdicionarTransacao(TipoTransacao.Receita); break;
                    case "2": AdicionarTransacao(TipoTransacao.Despesa); break;
                    case "3": ListarTransacoes(); break;
                    case "4": MostrarSaldo(); break;
                    case "5":
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static void AdicionarTransacao(TipoTransacao tipo)
        {
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Valor (use vírgula ou ponto): ");
            if (!decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                Console.WriteLine("Valor inválido.");
                return;
            }

            Console.Write("Data (dd/MM/yyyy): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
            {
                Console.WriteLine("Data inválida.");
                return;
            }

            if (tipo == TipoTransacao.Despesa && valor > 0)
                valor = -valor;

            transacoes.Add(new Transacao
            {
                Data = data,
                Descricao = descricao,
                Valor = valor,
                Tipo = tipo
            });

            Console.WriteLine("Transação adicionada com sucesso!");
        }

        static void ListarTransacoes()
        {
            if (transacoes.Count == 0)
            {
                Console.WriteLine("Nenhuma transação registrada.");
                return;
            }

            Console.WriteLine("\nData       | Tipo    | Descrição           | Valor");
            Console.WriteLine("--------------------------------------------------------");
            foreach (var t in transacoes)
            {
                Console.WriteLine(t);
            }
        }

        static void MostrarSaldo()
        {
            decimal saldo = 0;
            foreach (var t in transacoes)
                saldo += t.Valor;

            Console.WriteLine($"\nSaldo atual: R$ {saldo:F2}");
        }
    }
}
