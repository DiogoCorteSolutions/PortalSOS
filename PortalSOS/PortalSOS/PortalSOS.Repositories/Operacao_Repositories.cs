using PortalSOS.Dommain;
using PortalSOS.Infra.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSOS.Repositories
{
    public class Operacao_Repositories
    {
        private readonly PortalSOS.Infra.Contexto.DB_Contetxt _context;

        public Operacao_Repositories()
        {
            this._context = new Infra.Contexto.DB_Contetxt();
        }
        public List<sosportaloperacao_Dommain> ListarTodos()
        {
            try
            {
                var _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

                /* Criar conexão com banco de dados */
                var _connection = new SqlConnection(_connectionString);

                /* Abrir conexão */
                _connection.Open();

                /* Criar comando que vai enviar informações para o banco */
                SqlCommand _command = _connection.CreateCommand();

                /* Adicionar as informações dentro do comando que vai enviar para o banco */
                _command.CommandType = CommandType.StoredProcedure;

                /* Recebe o nome da procedure que esta sendo executada */
                _command.CommandText = "Usp_Listar_Operacao";

                /* Defini o tempo que a conexão ficará aberta (Em Segundos [7200] = 2 horas) */
                _command.CommandTimeout = 7200;

                /* Criar um adptador */
                var sqlDataAdapter = new SqlDataAdapter(_command);

                /* Criar datatable vasia aonde vou adicionar os valores que serão retornados do banco */
                var datatable = new DataTable();

                /* Mandar comando ir ate o banco buscar os daods e o o adptador preencher a datatable */
                sqlDataAdapter.Fill(datatable);

                /* Finaliza Conexão com banco de Dados */
                _connection.Dispose();
                _connection.Close();

                var retorno = new List<sosportaloperacao_Dommain>();

                /* O foreach varre o datarow e adiciona cada linha em uma lista ate acabar coleção */
                foreach (DataRow linha in datatable.Rows)
                {
                    //Adiciona as informações namespace entidade

                    var entity = new sosportaloperacao_Dommain
                    {
                        IdOperacao = int.Parse(linha["IdOperacao"].ToString()),
                        IdTipoOperacao = int.Parse(linha["IdTipoOperacao"].ToString()),
                        Operacao = linha["Operacao"].ToString(),
                        Tipo = linha["Tipo"].ToString(),
                        Valor = linha["Valor"].ToString(),
                        Ref = linha["Ref"].ToString(),
                        Ident = linha["Ident"].ToString(),
                        Status = bool.Parse(linha["Status"].ToString()),
                        Alteracao = linha["Alteracao"].ToString(),
                        Caixa = linha["Caixa"].ToString(),
                        Turno = linha["Turno"].ToString(),

                    };

                    retorno.Add(entity);

                }

                /* Retorna a tabela preenchida */
                return retorno;


            }
            catch (System.Data.SqlClient.SqlException exception)
            {
                throw new Exception(message:
                    exception.Number.ToString() + " - " + exception.Message.ToString() + " - " +
                    exception.InnerException.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
        }
        public void Salvar(sosportaloperacao_Dommain dommain)
        {
            this._context.sosportaloperacaos.Add(dommain);
            this._context.SaveChanges();
        }
        public void Excluir(int id)
        {
            var filtro = this._context.sosportaloperacaos.Find(id);
            this._context.Entry(filtro).State = System.Data.Entity.EntityState.Deleted;
            this._context.SaveChanges();
        }
        public void Atualizar(sosportaloperacao_Dommain dommain)
        {
            this._context.Entry(dommain).State = System.Data.Entity.EntityState.Modified;
            this._context.SaveChanges();
        }
        public sosportaloperacao_Dommain ListarPorId(int id)
        {
            return this._context.sosportaloperacaos.Find(id);
        }
    }
}
