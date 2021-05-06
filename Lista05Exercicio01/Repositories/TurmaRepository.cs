using Lista05Exercicio01.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using System.Linq;

namespace Lista05Exercicio01.Repositories
{
   public class TurmaRepository
    {

        public string ConnectionString { get; set; }

        public void Inserir(Turma turma)
        {
            var sql = @"
                        INSETR INTO TURMA ( IdTURMA, NOME, DATAINICIO, DATAFIM)
                        VALUES (NewId(), @NOME, @DATAINICIO, @DATAFIM)
                       ";
            
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, turma);
            }
            
        }

        public void Alterar(Turma turma)
        {

            var sql = @"
                       UPDATE TURMA SET
                       NOME = @NOME,
                       DATAINICIO = @DATAINICIO,
                       DATAFIM = @DATAFIM
                        WHERE
                       IdTURMA = @IdTURMA
                       ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, turma);
            }

        }

        public void Excluir(Turma turma)
        {

            var sql = @"
                        DELETE FROM TURMA
                        WHERE IdTURMA = @IdTURMA
                       ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, turma);
            }

        }

        public List<Turma> ObterTodos()
        {
            var sql = @"

                        SELECT * FROM TURMA ORDER BY NOME
                       ";
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<Turma>(sql).ToList();
            }

        }

        public Turma ObterPorId(Guid IdTurma)
        {
            var sql = @" SELECT *  FROM TURMA
                        WHERE
                            IdTURMA = @IdTURMA ";

            using ( var connection = new SqlConnection (ConnectionString))
            {
                return connection.Query<Turma>(sql, new { IdTurma }).FirstOrDefault();
            }
        }
    }
}
