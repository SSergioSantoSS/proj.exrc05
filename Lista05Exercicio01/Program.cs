using Lista05Exercicio01.Controllers;
using System;

namespace Lista05Exercicio01
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n SISTEMA DE CONTROLE DE TURMAS E ALUNOS);
           
                var turmaController = new TurmaController();
            turmaController.CadastrarTurma();
            


            
        }
    }
}
