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
    public class Pessoa_Repositories
    {
        //private readonly PortalSOS.Infra.Contexto.DB_Contetxt _context;
        //public Pessoa_Repositories()
        //{
        //    this._context = new Infra.Contexto.DB_Contetxt();
        //}
        ////public IEnumerable<Pessoa_Dommain> ListarTodos()
        ////{
        ////    return this._context.Pessoa;
        ////}
       
        //public sosportalpessoa_Dommain ListarPorCpf(string cpf)
        //{
        //    return this._context.sosportalpessoas.ToList().FirstOrDefault(x => x.CPF == cpf);
        //}
        //public void Salvar(sosportalpessoa_Dommain dommain)
        //{
        //    this._context.sosportalpessoas.Add(dommain);
        //    this._context.SaveChanges();
        //}
        //public void Excluir(int id)
        //{
        //    var filtro = this._context.sosportalpessoas.Find(id);
        //    this._context.Entry(filtro).State = System.Data.Entity.EntityState.Deleted;
        //    this._context.SaveChanges();
        //}
        //public void Atualizar(sosportalpessoa_Dommain dommain)
        //{
        //    this._context.Entry(dommain).State = System.Data.Entity.EntityState.Modified;
        //    this._context.SaveChanges();
        //}
        //public List<sosportalpessoa_Dommain> ListarTodos()
        //{
        //    try
        //    {
        //        var _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        //        /* Criar conexão com banco de dados */
        //        var _connection = new SqlConnection(_connectionString);

        //        /* Abrir conexão */
        //        _connection.Open();

        //        /* Criar comando que vai enviar informações para o banco */
        //        SqlCommand _command = _connection.CreateCommand();

        //        /* Adicionar as informações dentro do comando que vai enviar para o banco */
        //        _command.CommandType = CommandType.StoredProcedure;

        //        /* Recebe o nome da procedure que esta sendo executada */
        //        _command.CommandText = "Usp_Listar_Pessoa";

        //        /* Defini o tempo que a conexão ficará aberta (Em Segundos [7200] = 2 horas) */
        //        _command.CommandTimeout = 7200;

        //        /* Criar um adptador */
        //        var sqlDataAdapter = new SqlDataAdapter(_command);

        //        /* Criar datatable vasia aonde vou adicionar os valores que serão retornados do banco */
        //        var datatable = new DataTable();

        //        /* Mandar comando ir ate o banco buscar os daods e o o adptador preencher a datatable */
        //        sqlDataAdapter.Fill(datatable);

        //        /* Finaliza Conexão com banco de Dados */
        //        _connection.Dispose();
        //        _connection.Close();

        //        var retorno = new List<sosportalpessoa_Dommain>();

        //        /* O foreach varre o datarow e adiciona cada linha em uma lista ate acabar coleção */
        //        foreach (DataRow linha in datatable.Rows)
        //        {
        //            //Adiciona as informações namespace entidade

        //            var entity = new sosportalpessoa_Dommain
        //            {
        //                IdPessoa = int.Parse(linha["IdPessoa"].ToString()),
        //                IdPerfil = int.Parse(linha["IdPerfil"].ToString()),
        //                IdLoja = int.Parse(linha["IdLoja"].ToString()),
        //                Pessoa = linha["Pessoa"].ToString(),
        //                Razao = linha["Razao"].ToString(),
        //                InscMunicipal = linha["InscMunicipal"].ToString(),
        //                Cnpj = linha["Cnpj"].ToString(),
        //                Endereco = linha["Endereco"].ToString(),
        //                N = linha["N"].ToString(),
        //                Compl = linha["Compl"].ToString(),
        //                Bairro = linha["Bairro"].ToString(),
        //                CodMunicipio = linha["CodMunicipio"].ToString(),
        //                Municipio = linha["Municipio"].ToString(),
        //                Cnae = linha["Cnae"].ToString(),
        //                Email = linha["Email"].ToString(),
        //                Cep = linha["Cep"].ToString(),
        //                Uf = linha["Uf"].ToString(),
        //                Telefone = linha["Telefone"].ToString(),
        //                //Perfil = linha["Perfil"].ToString(),
        //                TipodeTel = linha["TipodeTel"].ToString(),
        //                TipoEnd = linha["TipoEnd"].ToString(),
        //                Operadora = linha["Operadora"].ToString(),
        //                Contato = linha["Contato"].ToString(),
        //                CodVenda = linha["CodVenda"].ToString(),
        //                Licenca = linha["Licenca"].ToString(),
        //                Ativacao = linha["Ativacao"].ToString(),
        //                Total = linha["Total"].ToString(),
        //                Obs = linha["Obs"].ToString(),
        //                LimiteCred = linha["LimiteCred"].ToString(),
        //                Status = bool.Parse(linha["Status"].ToString()),
        //                Emitente = linha["Emitente"].ToString(),
        //                Modelo = linha["Modelo"].ToString(),
        //                Serie = linha["Serie"].ToString(),
        //                Classificacao = linha["Classificacao"].ToString(),
        //                CPF = linha["CPF"].ToString(),
        //                Tipo = linha["Tipo"].ToString(),
        //                Representante = linha["Representante"].ToString(),
        //                Ultilizado = linha["Ultilizado"].ToString(),
        //                Senha = linha["Senha"].ToString(),

        //            };

        //            retorno.Add(entity);

        //        }

        //        /* Retorna a tabela preenchida */
        //        return retorno;


        //    }
        //    catch (System.Data.SqlClient.SqlException exception)
        //    {
        //        throw new Exception(message:
        //            exception.Number.ToString() + " - " + exception.Message.ToString() + " - " +
        //            exception.InnerException.ToString());
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception(exception.ToString());
        //    }
        //}
        //public bool ExisteCpf(string cpf)
        //{
        //    return this._context.sosportalpessoas.ToList().Exists(x => x.CPF == cpf);
        //}
        //public sosportalpessoa_Dommain LoginPessoa(string cpf, string senha)
        //{
        //    return this._context.sosportalpessoas.ToList().FirstOrDefault(x => x.CPF.Equals(cpf) && x.Senha.Equals(senha) && x.Status);
        //}
        //public bool Existe(string cpf)
        //{
        //    return this._context.sosportalpessoas.ToList().Exists(x => x.CPF == cpf);
        //}
        //        public sosportalpessoa_Dommain ListarPorId(int id)
        //{
        //    return this._context.sosportalpessoas.Find(id);
        //}
    }
}
