using Lista05Exercicio01.Entities;
using Lista05Exercicio01.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;

namespace Lista05Exercicio01.Controllers
{
   public class AlunoController
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBExerc05;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void CadastrarAluno()
        {
            try
            {
                Console.WriteLine("\n CADASTRO DE ALUNO \n ");

                var aluno = new  Aluno();

                Console.Write("\n Informe o nome do aluno ....: ");
                aluno.Nome = Console.ReadLine();

                Console.Write("\n Informe a matrícula do aluno ....: ");
                aluno.Matricula = Console.ReadLine();

                Console.Write("\n Informe o cpf do aluno ....: ");
                aluno.Cpf = Console.ReadLine();

                Console.Write("\n Informe o Id da turma ....: ");
                aluno.IdTurma = Guid.Parse(Console.ReadLine());

                var alunoRepository = new AlunoRepository();

                alunoRepository.ConnectionString = connectionString;
                alunoRepository.Inserir(aluno);

                Console.WriteLine("\n Aluno cadastrado com sucesso! ");
            }
            catch (SqlException e) 
            {
                Console.WriteLine("\n Não foi possível realizar o cadastro do aluno. ");
                Console.WriteLine(" Código do erro: " + e.Number);

                if (e.Number == 8152)
                {
                    Console.WriteLine(" O limite de caracteres permitido para um campo foi excedido. ");
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine("\n Erro: " + e.Message);
            }
        }


       
        public void AtualizarAluno()
        {
            try
            {
                Console.WriteLine("\n ATUALIZAÇÃO DO ALUNO \n ");

                Console.Write(" Informe o ID do aluno: ");
                var idaluno = Guid.Parse(Console.ReadLine());

                
                var alunoRepository = new AlunoRepository();
                alunoRepository.ConnectionString = connectionString;

                var aluno = alunoRepository.ObterPorId(idaluno);

                
                if (aluno != null)
                {
                    Console.Write("\n Informe o nome do aluno ....: ");
                    aluno.Nome = Console.ReadLine();

                    Console.Write("\n Informe a matrícula do aluno ....: ");
                    aluno.Matricula = Console.ReadLine();

                    Console.Write("\n Informe o cpf do aluno ....: ");
                    aluno.Cpf = Console.ReadLine();

                    Console.Write("\n Informe o Id da turma ....: ");
                    aluno.IdTurma = Guid.Parse(Console.ReadLine());

                    
                    alunoRepository.Alterar(aluno);
                    Console.WriteLine("\n Aluno atualizado com sucesso. ");
                }
                else
                {
                    Console.WriteLine("\n Aluno não encontrado. Por favor, tente novamente. ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n Erro: " + e.Message);
            }
        }

        
        public void ExcluirAluno()
        {
            try
            {
                Console.WriteLine("\n EXCLUSÃO DE ALUNO \n ");

                Console.Write(" Informe o ID do aluno: ");
                var idaluno = Guid.Parse(Console.ReadLine());

                
                var alunoRepository = new AlunoRepository();
                alunoRepository.ConnectionString = connectionString;

                
                var aluno = alunoRepository.ObterPorId(idaluno);

                
                if (aluno != null)
                {
                   
                    alunoRepository.Excluir(aluno);

                    Console.WriteLine("\n Aluno excluído com sucesso. ");
                }
                else
                {
                    Console.WriteLine("\n Aluno não encontrado. Por favor tente novamente. ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n Erro: " + e.Message);
            }
        }

       
        public void ConsultarAluno()
        {
            try
            {
                var alunoRepository = new AlunoRepository();
                alunoRepository.ConnectionString = connectionString;

                var aluno = alunoRepository.ObterTodos();

                foreach (var item  in  aluno )
                {
                    Console.Write("\n Id do aluno .......................: " + item.IdAluno);
                    Console.Write("\n Nome do aluno .....................: " + item.Nome);
                    Console.Write("\n Matrícula do aluno ...........: " + item.Matricula);
                    Console.Write("\n Cpf do aluno ............ " + item.Cpf);
                    Console.WriteLine("\n Id da turma do aluno ............ " + item.IdTurma);
                   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n Erro: " + e.Message);
            }
        }

        public void ConsultarAlunoPorTurma()
        {
            try
            {
                Console.WriteLine("\nCONSULTA DE Alunos POR Turma\n");

                Console.Write("Informe o Id da Turma..: ");
                var idTurma = Guid.Parse(Console.ReadLine());

                var alunoRepository = new AlunoRepository();
                alunoRepository.ConnectionString = connectionString;

               
                var alunos = alunoRepository.ObterPorTurma(idTurma);

                foreach (var item in alunos)
                {
                    Console.WriteLine("Id do Aluno...: " + item.IdAluno);
                    Console.WriteLine("Nome................: " + item.Nome);
                    Console.WriteLine("Matricula...........: " + item.Matricula);
                    Console.WriteLine("Cpf.................: " + item.Cpf);
                    Console.WriteLine("Id da Turma.......: " + item.IdTurma);
                   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

    }
}

