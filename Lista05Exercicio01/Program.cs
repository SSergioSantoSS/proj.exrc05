using Dapper;
using Lista05Exercicio01.Controllers;
using Lista05Exercicio01.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lista05Exercicio01
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n SISTEMA DE CONTROLE DE TURMAS E ALUNOS");

            var turmaController = new TurmaController();
            var alunoController = new AlunoController();
           
                

            

            Console.WriteLine("\n(1)Cadastrar Turma");
            Console.WriteLine("\n(2)Atualizar Turma");
            Console.WriteLine("\n(3)Excluir Turma");
            Console.WriteLine("\n(4)Consultar Turma");
            Console.WriteLine("\n(5)Cadastrar Aluno");
            Console.WriteLine("\n(6)Atualizar Aluno");
            Console.WriteLine("\n(7)Excluir Aluno");
            Console.WriteLine("\n(8)Consultar Aluno");
            Console.WriteLine("\n(9)Cadastrar Aluno por Turma");
            Console.WriteLine("\n(0) Sair");
            try
            {
                Console.Write("\nESCOLHA A OPÇÃO DESEJADA: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        turmaController.CadastrarTurma();
                        Main(args);
                        break;

                    case 2:
                        turmaController.AtualizarTurma();
                        Main(args);
                        break;

                    case 3:
                        turmaController.ExcluirTurma();
                        Main(args);
                        break;

                    case 4:
                        turmaController.ConsultarTurmas();
                        Main(args);
                        break;

                    case 5:
                        alunoController.CadastrarAluno();
                        Main(args);
                        break;

                    case 6:
                        alunoController.AtualizarAluno();
                        Main(args);
                        break;

                    case 7:
                        alunoController.ExcluirAluno();
                        Main(args);
                        break;

                    case 8:
                        alunoController.ConsultarAluno();
                        Main(args);
                        break;

                    case 9:
                        alunoController.ConsultarAlunoPorTurma();
                        Main(args);
                        break;

                    case 0:
                        Console.WriteLine("\nFim do Programa!");
                        break;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("\nERRO : " + e.Message);
            }
            Console.ReadKey();


        }   
    }
}
