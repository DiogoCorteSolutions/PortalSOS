using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalSOS.Dommain;

namespace PortalSOS.Repositories
{
    public class Acesso_Repositories
    {

        private readonly PortalSOS.Infra.Contexto.DB_Contetxt _context;

        public Acesso_Repositories()
        {
            this._context = new Infra.Contexto.DB_Contetxt();
        }
        public IList<sosportalconfiguracaocliente_Dommain> ListarConfigurcooesPorClienteId(int clienteId)
        {
            var result = this._context.sosportalconfiguracaoclientes.Where(x => x.IdCliente == clienteId && x.Status);

            return result.ToList();
        }
        public IList<sosportalconfiguracaocliente_Dommain> ListarConfigurcooesPorPessoLoja(int pessoaLojaId)
        {
            var result = this._context.sosportalconfiguracaoclientes.Where(x => x.sosportalcliente.IdPessoaLoja == pessoaLojaId && x.Status);

            return result.ToList();
        }
        public List<sosportalconfiguracaocliente_Dommain> ListarTodos()
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
                _command.CommandText = "Usp_ListarTodos_ConfigurcaoCliente";

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

                var retorno = new List<sosportalconfiguracaocliente_Dommain>();

                /* O foreach varre o datarow e adiciona cada linha em uma lista ate acabar coleção */
                foreach (DataRow linha in datatable.Rows)
                {
                    //Adiciona as informações namespace entidade

                    var entity = new sosportalconfiguracaocliente_Dommain
                    {



                        IdConfiguracaoCliente = int.Parse(linha["IdConfiguracaoCliente"].ToString()),
                        IdPerfil = int.Parse(linha["IdPerfil"].ToString()),
                        IdCliente = int.Parse(linha["IdCliente"].ToString()),
                        IdConfiguracao = int.Parse(linha["IdCOnfiguracao"].ToString()),
                        Status = bool.Parse(linha["Status"].ToString()),

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
        public void Salvar(sosportalconfiguracaocliente_Dommain dommain)
        {
            this._context.sosportalconfiguracaoclientes.Add(dommain);
            this._context.SaveChanges();

        }
        public void Atualizar(sosportalconfiguracaocliente_Dommain dommain)
        {
            this._context.Entry(dommain).State = System.Data.Entity.EntityState.Modified;
            this._context.SaveChanges();
        }
        public void Excluir(int id)
        {
            var filto = this._context.sosportalconfiguracaoclientes.Find(id);
            this._context.Entry(filto).State = System.Data.Entity.EntityState.Deleted;
            this._context.SaveChanges();
        }
        public sosportalconfiguracaocliente_Dommain ListarPorId (int id)
        {
            return this._context.sosportalconfiguracaoclientes.Find(id);
        }
    }

}
