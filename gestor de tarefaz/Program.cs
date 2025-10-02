using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorDeTarefas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Interacao.MostrarMenu();
        }
    }

    public class Interacao
    {
        public static void MostrarMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== Menu ===");
                Console.WriteLine("1 - Adicionar tarefa");
                Console.WriteLine("2 - Listar tarefas");
                Console.WriteLine("3 - Gerir tarefa");
                Console.WriteLine("4 - Sair");
                Console.Write(": ");

                if (int.TryParse(Console.ReadLine(), out int escolha))
                {
                    switch (escolha)
                    {
                        case 1:
                            TarefaRepositorio.AdicionarTarefa();
                            break;
                        case 2:
                            TarefaRepositorio.VerTarefas();
                            break;
                        case 3:
                            Gestor.TarefaGestor();
                            break;
                        case 4:
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Digite um número válido!");
                }
            }
        }
    }

  
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Estado { get; set; }
    }

    public static class TarefaRepositorio
    {
        private static List<Tarefa> tarefas = new List<Tarefa>();
        private static int proximoId = 1;

        public static void AdicionarTarefa()
        {
            Console.Write("Titulo: ");
            string titulo = Console.ReadLine();

            Console.Write("Descrição (Opcional): ");
            string descricao = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(descricao))
            {
                descricao = "(Sem descrição)";
            }

            Console.Write("Estado: ");
            string estado = Console.ReadLine();

            var tarefa = new Tarefa
            {
                Id = proximoId++,
                Titulo = titulo,
                Descricao = descricao,
                Estado = estado
            };

            tarefas.Add(tarefa);

            Console.WriteLine("Tarefa criada!");
        }

        public static void VerTarefas()
        {
            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa.");
                return;
            }

            Console.WriteLine("\n=== Lista de Tarefas ===");
            foreach (var t in tarefas)
            {
                Console.WriteLine($"[{t.Id}] {t.Titulo} - {t.Descricao} - {t.Estado}");
            }
        }

        public static void Alterar()
        {
            Console.WriteLine("ID: ");
            int AlterarID = int.Parse(Console.ReadLine());
            foreach (var t in tarefas)
            {
                if(t.Id == AlterarID)
                {
                    Console.WriteLine("Estado: ");
                    string novoEsatado = Console.ReadLine();
                    t.Estado = novoEsatado;
                    Console.WriteLine("Estado alterado");
                }
                else
                {
                    Console.WriteLine("Terefa não encontrada");
                    Gestor.TarefaGestor();
                }
            }
        }


        public static void Remover()
        {
            Console.WriteLine("ID: ");
            int RemoverID = int.Parse(Console.ReadLine());

            Tarefa tarefaRemover = tarefas.FirstOrDefault(t => t.Id == RemoverID);
            if (tarefaRemover == null)
            {
                tarefas.Remove(tarefaRemover);
                Console.WriteLine("Tarefa removida");
                Gestor.TarefaGestor();
            } else
            {
                Console.WriteLine("Tarefa não encontrada");
                Gestor.TarefaGestor();
            }

            Gestor.TarefaGestor();
        }

        public static void Pesquisar()
        {
            Console.WriteLine("ID: ");
            int Procurar = int.Parse(Console.ReadLine());

            Tarefa ProcurarTarefa = tarefas.FirstOrDefault(t => t.Id == Procurar);
            if (tarefas.Contains(ProcurarTarefa))
            {
                foreach (var t in tarefas)
                {
                    Console.WriteLine($"[{t.Id}] {t.Titulo} - {t.Descricao} - {t.Estado}");
                }
                Gestor.TarefaGestor();
            }
            else
            {
                Console.WriteLine("ID inválido");
                Gestor.TarefaGestor();
            }

            Gestor.TarefaGestor();
        }

    }



    public class Gestor
    {
        public static void TarefaGestor()
        {
            while (true)
            {
                Console.WriteLine("\n=== Menu ===");
                Console.WriteLine("1 - Alterar Estado");
                Console.WriteLine("2 - Remover tarefa");
                Console.WriteLine("3 - Pesquisar tarefa");
                Console.WriteLine("4 - voltar");
                Console.Write(": ");

                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            TarefaRepositorio.Alterar();
                            break;
                        case 2:
                            TarefaRepositorio.Remover();
                            break;
                        case 3:
                            TarefaRepositorio.Pesquisar();
                            break;
                        case 4:
                            Interacao.MostrarMenu();
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Digite um número válido!");
                }
            }
        }

    
    }
}