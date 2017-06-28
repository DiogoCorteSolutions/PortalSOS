using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSOS.Infra.Contexto
{
  public  class DB_Contexto_Procedure
    { 
        #region Métodos Privados

        /// <summary>
        /// Método de conexão com banco de dados
        /// </summary>
        private SqlConnection _connection;

        /// <summary>
        /// Método de conexão com banco de dados
        /// </summary>
        /// <returns>Retorna a string de conexão</returns>
        private SqlConnection CreateConnection(int value = 0)
        {
            switch (value)
            {
                case 0:
                    _connection = new SqlConnection(
                        ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                    break;

                default:
                    _connection = new SqlConnection(
                        ConfigurationManager.ConnectionStrings["DefaultConnection" + value].ToString());
                    break;
            }

            return _connection;
        }

        /// <summary>
        /// Paramentros que serão enviados ao banco
        /// </summary>
        private SqlParameterCollection _parameterCollection = new SqlCommand().Parameters;

        /// <summary>
        /// Criar comando que recebe o nome da procedure e os tipos
        /// </summary>
        /// <param name="commandType">Comandos</param>
        /// <param name="nomeProcedure">Nome da procedure</param>
        /// <returns>Retorna os comandos</returns>
        private SqlCommand CreateCommand(CommandType commandType, string procedure, int value = 0)
        {
            /* Criar conexão com banco de dados */
            _connection = this.CreateConnection(value);

            /* Abrir conexão */
            _connection.Open();

            /* Criar comando que vai enviar informações para o banco */
            SqlCommand _command = _connection.CreateCommand();

            /* Adicionar as informações dentro do comando que vai enviar para o banco */
            _command.CommandType = commandType;

            /* Recebe o nome da procedure que esta sendo executada */
            _command.CommandText = procedure;

            /* Defini o tempo que a conexão ficará aberta (Em Segundos [7200] = 2 horas) */
            _command.CommandTimeout = 7200;

            /* Adicionar os paramentros no comando */
            foreach (SqlParameter item in _parameterCollection)
            {
                /* Adicona o parametro e o valor */
                _command.Parameters.Add(new SqlParameter(item.ParameterName, item.Value));
            }

            /* Executar o comando, manda o comando ate o banco com as informações */
            return _command;
        }

        #endregion Métodos Privados

        #region Métodos Publicos

        /// <summary>
        /// Método que limpa os parametros
        /// </summary>
        public void CleanParameter()
        {
            this._parameterCollection.Clear();
        }

        /// <summary>
        /// Método adicona paramentros dentro da coleção de paramentro
        /// </summary>
        /// <param name="parametro">recebe os parametros passado na procedure</param>
        /// <param name="valor">valor passado na procedure</param>
        public void AddParameter(string parameters, object value)
        {
            try
            {
                this._parameterCollection.Add(new SqlParameter(parameters, value));
            }
            catch (System.Data.SqlClient.SqlException exception)
            {
                throw new Exception(message: exception.Number.ToString() + " - " + exception.Message.ToString() + " - " + exception.InnerException.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
        }

        /// <summary>
        /// Método executa persistencia no banco de dados (Inserir, Atualiza e Excluir)
        /// Método executa a manipulação da procedure no banco
        /// Usado para insert, delete e update
        /// </summary>
        /// <param name="commandType">é um enum</param>
        /// <param name="nomeProcedure">recebe o nome da procedure</param>
        /// <returns>retorna um objeto</returns>
        public object RunCommand(CommandType commandType, string procedure, int value = 0)
        {
            try
            {
                /* Recebe os paramentros en envia para o banco*/
                SqlCommand _command = this.CreateCommand(commandType, procedure, value);

                var retorno = _command.ExecuteScalar();

                /* Finaliza Conexão com banco de Dados */
                this._connection.Close();
                this._connection.Dispose();

                /* Executar o comando, manda o comando ate o banco com as informações */
                return retorno;
            }
            catch (System.Data.SqlClient.SqlException exception)
            {
                throw new Exception(message: exception.Number.ToString() + " - " + exception.Message.ToString() + " - " + exception.InnerException.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
        }

        /// <summary>
        /// Método consulta informações na base de dados
        /// </summary>
        /// <param name="commandType">é um enum</param>
        /// <param name="nomeProcedure">recebe o nome da procedure</param>
        /// <returns>retorna um objeto</returns>
        public DataTable RunConsultation(CommandType commandType, string procedure, int value = 0)
        {
            try
            {
                /* Recebe os paramentros en envia para o banco*/
                SqlCommand _command = this.CreateCommand(commandType, procedure, value);

                /* Criar um adptador */
                var sqlDataAdapter = new SqlDataAdapter(_command);

                /* Criar datatable vasia aonde vou adicionar os valores que serão retornados do banco */
                var dataTable = new DataTable();

                /* Mandar comando ir ate o banco buscar os daods e o o adptador preencher a datatable */
                sqlDataAdapter.Fill(dataTable);

                /* Finaliza Conexão com banco de Dados */
                this._connection.Close();
                this._connection.Dispose();

                /* Retorna a tabela preenchida */
                return dataTable;
            }
            catch (System.Data.SqlClient.SqlException exception)
            {
                throw new Exception(message: exception.Number.ToString() + " - " + exception.Message.ToString() + " - " + exception.InnerException.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
        }

        public void Dispose()
        {
            this.CreateConnection().Close();
            this.CreateConnection().Dispose();
        }

        #endregion Métodos Publicos
    }
}
