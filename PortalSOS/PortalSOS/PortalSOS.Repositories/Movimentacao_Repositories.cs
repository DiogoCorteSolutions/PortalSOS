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
    public class Movimentacao_Repositories
    {
        private readonly PortalSOS.Infra.Contexto.DB_Contetxt _context;

        public Movimentacao_Repositories()
        {
            this._context = new Infra.Contexto.DB_Contetxt();
        }
        public List<sosportalmovimentacao_Dommain> ListarTodos()
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
                _command.CommandText = "Usp_Listar_Movimentacao";

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

                var retorno = new List<sosportalmovimentacao_Dommain>();

                /* O foreach varre o datarow e adiciona cada linha em uma lista ate acabar coleção */
                foreach (DataRow linha in datatable.Rows)
                {
                    //Adiciona as informações namespace entidade

                    var entity = new sosportalmovimentacao_Dommain
                    {
                        IdMovimentacao = int.Parse(linha["IdMovimentacao"].ToString()),
                        IdCliente = int.Parse(linha["IdCliente"].ToString()),
                        IdProduto = int.Parse(linha["IdProduto"].ToString()),
                        IdOperacao = int.Parse(linha["IdOperacao"].ToString()),
                        Orcamento = int.Parse(linha["Orcamento"].ToString()),
                        Barras = linha["Barras"].ToString(),
                        Item = linha["Item"].ToString(),
                        Produto = linha["Produto"].ToString(),
                        Grupo = linha["Grupo"].ToString(),
                        SubGrupo = linha["SubGrupo"].ToString(),
                        Linha = linha["Linha"].ToString(),
                        Ncm = linha["Ncm"].ToString(),
                        Aliq = linha["Aliq"].ToString(),
                        RsUnit = linha["RsUnit"].ToString(),
                        DescUnit = linha["DescUnit"].ToString(),
                        DescPorc = linha["DescPorc"].ToString(),
                        RsUnitreal = linha["RsUnitreal"].ToString(),
                        Unid = linha["Unid"].ToString(),
                        Qtd = linha["Qtd"].ToString(),
                        RsTotal = linha["RsTotal"].ToString(),
                        RsTotalReal = linha["RsTotalReal"].ToString(),
                        CodCli = linha["CodCli"].ToString(),
                        CodVeiculo = linha["CodVeiculo"].ToString(),
                        Vendedor = linha["Vendedor"].ToString(),
                        Tipo = linha["Tipo"].ToString(),
                        Data = DateTime.Parse(linha["Data"].ToString()),
                        Hora = DateTime.Parse(linha["Hora"].ToString()),
                        Usuario = linha["Usuario"].ToString(),
                        Unidade = linha["Unidade"].ToString(),
                        Status = bool.Parse(linha["Status"].ToString()),
                        Nf = linha["Nf"].ToString(),
                        Promocao = linha["Promocao"].ToString(),
                        Caixa = linha["Caixa"].ToString(),
                        Turno = linha["Turno"].ToString(),
                        AliquestPorc = linha["AliquestPorc"].ToString(),
                        Aliqfedporc = linha["Aliqfedporc"].ToString(),
                        Aliquestval = linha["Aliquestval"].ToString(),
                        Aliqfedval = linha["Aliqfedval"].ToString(),
                        Atendente = linha["Atendente"].ToString(),
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
        public void Salvar(sosportalmovimentacao_Dommain dommain)
        {
            this._context.sosportalmovimentacaos.Add(dommain);
            this._context.SaveChanges();
        }
        public void Excluir(int id)
        {
            var filtro = this._context.sosportalclientes.Find(id);
            this._context.Entry(filtro).State = System.Data.Entity.EntityState.Deleted;
            this._context.SaveChanges();
        }
        public void Atualizar(sosportalmovimentacao_Dommain dommain)
        {
            this._context.Entry(dommain).State = System.Data.Entity.EntityState.Modified;
            this._context.SaveChanges();
        }
        public sosportalmovimentacao_Dommain ListarPorId(int id)
        {
            return this._context.sosportalmovimentacaos.Find(id);
        }
    }
}
