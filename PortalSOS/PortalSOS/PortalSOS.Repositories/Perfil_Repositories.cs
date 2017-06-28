﻿using PortalSOS.Dommain;
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

    public class Perfil_Repositories
    {
        private readonly PortalSOS.Infra.Contexto.DB_Contetxt _context;
        public Perfil_Repositories()
        {
            this._context = new Infra.Contexto.DB_Contetxt();
        }
        public List<sosportalperfil_Dommain> ListarTodos()
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
                _command.CommandText = "Usp_Listar_Perfil";

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

                var retorno = new List<sosportalperfil_Dommain>();

                /* O foreach varre o datarow e adiciona cada linha em uma lista ate acabar coleção */
                foreach (DataRow linha in datatable.Rows)
                {
                    //Adiciona as informações namespace entidade

                    var entity = new sosportalperfil_Dommain
                    {
                        IdPerfil = int.Parse(linha["IdPerfil"].ToString()),
                        Perfil = linha["Perfil"].ToString(),
                        Status = bool.Parse(linha["Status"].ToString()),
                        DataCadastro = DateTime.Parse(linha["DataCadastro"].ToString()),
                        DataAlteracao = DateTime.Parse(linha["DataAlteracao"].ToString()),
                        DescricaoTipo = linha["DescricaoTipo"].ToString(),
                        Tipo = int.Parse(linha["Tipo"].ToString()),


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
            //}


        }
        public void Salvar(sosportalperfil_Dommain dommain)
        {
            this._context.sosportalperfils.Add(dommain);
            this._context.SaveChanges();
        }
        public void Excluir(int id)
        {
            var filtro = this._context.sosportalperfils.Find(id);
            this._context.Entry(filtro).State = System.Data.Entity.EntityState.Deleted;
            this._context.SaveChanges();
        }
        public void Atualizar(sosportalperfil_Dommain dommain)
        {
            this._context.Entry(dommain).State = System.Data.Entity.EntityState.Modified;
            this._context.SaveChanges();
        }
        public sosportalperfil_Dommain ListarPorId(int id)
        {
            return this._context.sosportalperfils.Find(id);
        }
        public bool ExistePerfilSegm(string perfil)
        {
            return this._context.sosportalperfils.ToList().Exists(x => x.Perfil == perfil);
        }
    }
}
