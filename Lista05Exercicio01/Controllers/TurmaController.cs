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

                if (e.Number ==8152)
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

                    turmaRepository.Change(turma);
                }

                


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

    }
    

}
