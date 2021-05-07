using Lista05Exercicio01.Entities;
using Lista05Exercicio01.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Lista05Exercicio01.Controllers
{
    public class TurmaController
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBExerc05;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void CadastrarTurma()
        {
            try
            {
                Console.WriteLine("\n CADASTRO DA TURMA");

                var turma = new Turma();

                Console.WriteLine("\n Por favor, informe o nome da turma");
                turma.Nome = Console.ReadLine();

                Console.WriteLine("\nPor favor, informe a data de inicio da turma");
                turma.DataInicio = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("\nPor favor, Informe a data do fim da turma");
                turma.DataFim = DateTime.Parse(Console.ReadLine());


                var turmaRepository = new TurmaRepository();


                turmaRepository.ConnectionString = connectionString;
                turmaRepository.Inserir(turma);

                Console.WriteLine("\n TURMA CADASTRADA COM SUCESSO!");
            }
            catch (SqlException e)
            {
                Console.WriteLine("\n CADASTRO NÃO REALIZADO!");
                Console.WriteLine("\nCÓDIGO DO ERRO: " + e.Number);

                if (e.Number == 8152)
                {
                    Console.WriteLine("\n LIMITE DE CARACTERES EXCEDIDO.");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("\nERRO: " + e.Message);

            }



        }
        public void AtualizarTurma()
        {
            try
            {
                Console.WriteLine("\n ATUALIZAR TURMA");



                Console.WriteLine("\n Por favor, informe o ID da turma");
                var idTurma = Guid.Parse(Console.ReadLine());

                var turmaRepository = new TurmaRepository();
                turmaRepository.ConnectionString = connectionString;

                var turma = turmaRepository.ObterPorId(idTurma);

                if (turma != null)
                {
                    Console.WriteLine("\n Por favor, informe o nome da turma");
                    turma.Nome = Console.ReadLine();

                    Console.WriteLine("\nPor favor, informe a data de inicio da turma");
                    turma.DataInicio = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("\nPor favor, Informe a data do fim da turma");
                    turma.DataFim = DateTime.Parse(Console.ReadLine());

                    turmaRepository.Alterar(turma);

                    Console.WriteLine("\nTURMA ATUALIZADA COM SUCESSO!");
                }
                else
                {
                    Console.WriteLine("\nTURMA NÃO ENCINTRADA. POR FAVOR, TENTE NOVAMENTE.");

                }


            }

            catch (Exception e)
            {
               
           
                    Console.WriteLine("\nErro: " + e.Message);
            

            }





        }

        public void ExcluirTurma()
        {
            try
            {
                Console.WriteLine("\nEXCLUSÃO DE TURMA\n");

                Console.Write("Informe o ID da turma: ");
                var idTurma = Guid.Parse(Console.ReadLine());

                
                var turmaRepository = new TurmaRepository();
                turmaRepository.ConnectionString = connectionString;

               
                var turma = turmaRepository.ObterPorId(idTurma);

                
                if (turma != null)
                {
                    
                    turmaRepository.Excluir(turma);

                    Console.WriteLine("\nTurma excluída com sucesso!.");
                }
                else
                {
                    Console.WriteLine("\nTurma não encontrada. Por favor, tente novamente.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        public void ConsultarTurmas()
        {
            try
            {
                var turmaRepository = new TurmaRepository();
                turmaRepository.ConnectionString = connectionString;

                var turmas = turmaRepository.ObterTodos();

                foreach (var item in turmas)
                {
                    Console.Write("\n Id da turma .......................: " + item.IdTurma);
                    Console.Write("\n Nome da turma .....................: " + item.Nome);
                    Console.Write("\n Data de início da turma ...........: " + item.DataInicio);
                    Console.WriteLine("\n Data do fim da turma ............ " + item.DataFim);
                    
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("\n Erro: " + e.Message);

            }
        }

    }


}
