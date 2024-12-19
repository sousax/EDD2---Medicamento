using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjMedicamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Medicamentos medicamentos = new Medicamentos();
            int opcao;

            do
            {
                Console.WriteLine("\nSelecione uma opcao:");
                Console.WriteLine("0. Finalizar processo");
                Console.WriteLine("1. Cadastrar medicamento");
                Console.WriteLine("2. Consultar medicamento (e)");
                Console.WriteLine("3. Consultar medicamento (analítico)");
                Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
                Console.WriteLine("5. Vender medicamento (abater do lote mais antigo)");
                Console.WriteLine("6. Listar medicamentos (sintético)");
                Console.Write("Opcao: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarMedicamento(medicamentos);
                        break;

                    case 2:
                        ConsultarMedicamentoSintetico(medicamentos);
                        break;

                    case 3:
                        ConsultarMedicamentoAnalitico(medicamentos);
                        break;

                    case 4:
                        ComprarLote(medicamentos);
                        break;

                    case 5:
                        VenderMedicamento(medicamentos);
                        break;

                    case 6:
                        ListarMedicamentosSintetico(medicamentos);
                        break;

                    case 0:
                        Console.WriteLine("Encerrando...");
                        break;

                    default:
                        Console.WriteLine("Opcao invalida! Tente novamente.");
                        break;
                }
            } while (opcao != 0);
        }

        static void CadastrarMedicamento(Medicamentos medicamentos)
        {
            Console.Write("Digite o ID do medicamento: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do medicamento: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o laboratorio do medicamento: ");
            string laboratorio = Console.ReadLine();

            Medicamento medicamento = new Medicamento(id, nome, laboratorio);
            medicamentos.Adicionar(medicamento);

            Console.WriteLine("Medicamento cadastrado com sucesso!");
        }

        static void ConsultarMedicamentoSintetico(Medicamentos medicamentos)
        {
            Console.Write("Digite o ID do medicamento: ");
            int id = int.Parse(Console.ReadLine());

            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento(id, null, null));

            if (medicamento.getId() != 0)
            {
                Console.WriteLine($"ID: {medicamento.getId()}, Nome: {medicamento.getNome()}, Laboratorio: {medicamento.getLaboratorio()}, Quantidade Disponível: {medicamento.QtdeDisponivel()}");
            }
            else
            {
                Console.WriteLine("Medicamento nao encontrado.");
            }
        }

        static void ConsultarMedicamentoAnalitico(Medicamentos medicamentos)
        {
            Console.Write("Digite o ID do medicamento: ");
            int id = int.Parse(Console.ReadLine());

            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento(id, null, null));

            if (medicamento.getId() != 0)
            {
                Console.WriteLine($"ID: {medicamento.getId()}, Nome: {medicamento.getNome()}, Laboratorio: {medicamento.getLaboratorio()}, Quantidade Disponível: {medicamento.QtdeDisponivel()}");

                foreach (var lote in medicamento.Lotes)
                {
                    Console.WriteLine($"  Lote ID: {lote.getId()}, Quantidade: {lote.getQtde()}, Vencimento: {lote.getVenc():dd/MM/yyyy}");
                }
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
        }

        static void ComprarLote(Medicamentos medicamentos)
        {
            Console.Write("Digite o ID do medicamento: ");
            int id = int.Parse(Console.ReadLine());

            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento(id, null, null));

            if (medicamento.getId() != 0)
            {
                Console.Write("Digite o ID do lote: ");
                int loteId = int.Parse(Console.ReadLine());

                Console.Write("Digite a quantidade do lote: ");
                int qtde = int.Parse(Console.ReadLine());

                Console.Write("Digite a data de vencimento do lote (dd/MM/yyyy): ");
                DateTime venc = DateTime.Parse(Console.ReadLine());

                Lote lote = new Lote(loteId, qtde, venc);
                medicamento.Comprar(lote);

                Console.WriteLine("Lote comprado e adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
        }

        static void VenderMedicamento(Medicamentos medicamentos)
        {
            Console.Write("Digite o ID do medicamento: ");
            int id = int.Parse(Console.ReadLine());

            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento(id, null, null));

            if (medicamento.getId() != 0)
            {
                Console.Write("Digite a quantidade a ser vendida: ");
                int qtde = int.Parse(Console.ReadLine());

                if (medicamento.Vender(qtde))
                {
                    Console.WriteLine("Venda realizada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não há quantidade suficiente disponível para venda.");
                }
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
        }

        static void ListarMedicamentosSintetico(Medicamentos medicamentos)
        {
            foreach (var medicamento in medicamentos.getListaMedicamentos())
            {
                Console.WriteLine($"ID: {medicamento.getId()}, Nome: {medicamento.getNome()}, Laboratorio: {medicamento.getLaboratorio()}, Quantidade Disponível: {medicamento.QtdeDisponivel()}");
            }
        }
    }
}
    

