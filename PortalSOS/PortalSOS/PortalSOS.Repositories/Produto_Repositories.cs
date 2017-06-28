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
    public class Produto_Repositories
    {
        private readonly PortalSOS.Infra.Contexto.DB_Contexto_Procedure dbContextProcedure;
        private readonly PortalSOS.Infra.Contexto.DB_Contetxt _context;
        public Produto_Repositories()
        {
            this.dbContextProcedure = new Infra.Contexto.DB_Contexto_Procedure();
            this._context = new Infra.Contexto.DB_Contetxt();
        }
        public List<sosportalproduto_Dommain> ListarTodos()
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

                /* Criar conexão com banco de dados */
                var _connection = new SqlConnection(connectionString);

                /* Abrir conexão */
                _connection.Open();

                /* Criar comando que vai enviar informações para o banco */
                SqlCommand _command = _connection.CreateCommand();

                /* Adicionar as informações dentro do comando que vai enviar para o banco */
                _command.CommandType = CommandType.StoredProcedure;

                /* Recebe o nome da procedure que esta sendo executada */
                _command.CommandText = "Usp_Listar_Produto";

                /* Defini o tempo que a conexão ficará aberta (Em Segundos [7200] = 2 horas) */
                _command.CommandTimeout = 7200;

                /* Criar um adptador */
                var sqlDataAdapter = new SqlDataAdapter(_command);

                /* Criar datatable vasia aonde vou adicionar os valores que serão retornados do banco */
                var dataTable = new DataTable();

                /* Mandar comando ir ate o banco buscar os daods e o o adptador preencher a datatable */
                sqlDataAdapter.Fill(dataTable);

                /* Finaliza Conexão com banco de Dados */
                _connection.Close();
                _connection.Dispose();

                var retorno = new List<sosportalproduto_Dommain>();

                /* O foreach varre o datarow e adiciona cada linha em uma lista ate acabar coleção */
                foreach (DataRow linha in dataTable.Rows)
                {
                    /* Adiciona as informações na entidade */
                    var entity = new sosportalproduto_Dommain
                    {
                        IdProduto = int.Parse(linha["IdProduto"].ToString()),
                        IdPerfil = int.Parse(linha["IdPerfil"].ToString()),
                        Atualizado = DateTime.Parse(linha["Atualizado"].ToString()),
                        Barras = linha["Barras"].ToString(),
                        Ref = linha["Ref"].ToString(),
                        Forn = linha["Forn"].ToString(),
                        Cfop = linha["Cfop"].ToString(),
                        Prod = linha["Prod"].ToString(),
                        Unidade = linha["Unidade"].ToString(),
                        CodGen = linha["CodGen"].ToString(),
                        Gen = linha["Gen"].ToString(),
                        Sub = linha["Sub"].ToString(),
                        Linha = linha["Linha"].ToString(),
                        ValidDias = linha["ValidDias"].ToString(),
                        ValidData = DateTime.Parse(linha["ValidData"].ToString()),
                        Lote = linha["Lote"].ToString(),
                        Cor = linha["Cor"].ToString(),
                        Tipo = linha["Tipo"].ToString(),
                        Atual = linha["Atual"].ToString(),
                        Minimo = linha["Minimo"].ToString(),
                        Ideial = linha["Ideial"].ToString(),
                        Bruto = linha["Bruto"].ToString(),
                        Ucom = linha["Ucom"].ToString(),
                        Ncm = linha["Ncm"].ToString(),
                        Utrib = linha["Utrib"].ToString(),
                        Ubal = linha["Ubal"].ToString(),
                        Validade = linha["Validade"].ToString(),
                        Ali = linha["Ali"].ToString(),
                        Stat = linha["Stat"].ToString(),
                        Cust = linha["Cust"].ToString(),
                        Descricao = linha["Descricao"].ToString(),
                        Subtri = linha["Subtri"].ToString(),
                        Ipi = linha["Ipi"].ToString(),
                        Dificms = linha["Dificms"].ToString(),
                        Custoimp = linha["Custoimp"].ToString(),
                        Comissadi = linha["Comissadi"].ToString(),
                        Mgven = linha["Mgven"].ToString(),
                        Varejo = linha["Varejo"].ToString(),
                        Atacado = linha["Atacado"].ToString(),
                        Mgvenajus = linha["Mgvenajus"].ToString(),
                        Vavtot = linha["Vavtot"].ToString(),
                        Imagem = linha["Imagem"].ToString(),
                        Tam = linha["Tam"].ToString(),
                        //Flex = linha["Flex"].ToString(),
                        AlisetPorc = linha["AlisetPorc"].ToString(),
                        Aliestval = linha["Aliestval"].ToString(),
                        AlifedPorc = linha["AlifedPorc"].ToString(),
                        Alifedval = linha["Alifedval"].ToString(),
                        desccncm = linha["desccncm"].ToString(),
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
        public void Salvar(sosportalproduto_Dommain dommain)
        {
            this._context.sosportalprodutoes.Add(dommain);
            this._context.SaveChanges();
        }
        public void Excluir(int id)
        {
            var filtro = this._context.sosportalprodutoes.Find(id);
            this._context.Entry(filtro).State = System.Data.Entity.EntityState.Deleted;
            this._context.SaveChanges();
        }
        public void Atualizar(sosportalproduto_Dommain dommain)
        {
            this._context.Entry(dommain).State = System.Data.Entity.EntityState.Modified;
            this._context.SaveChanges();
        }
        public sosportalproduto_Dommain ListarPorId(int id)
        {
            return this._context.sosportalprodutoes.Find(id);
        }

    }
}
