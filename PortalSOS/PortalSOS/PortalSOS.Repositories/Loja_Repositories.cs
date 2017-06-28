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
    public class Loja_Repositories
    {
        private readonly PortalSOS.Infra.Contexto.DB_Contetxt _context;

        //public Loja_Repositories()
        //{
        //    this._context = new Infra.Contexto.DB_Contetxt();
        //}

        ////public IEnumerable<Loja_Dommain> ListarTodos()
        ////{
        ////    return this._context.Loja;
        ////}
        //public sosportalloja_Dommain ListarPorCnpj(string cnpj)
        //{
        //    return this._context.sosportallojas.ToList().FirstOrDefault(x => x.Cnpj.Equals(cnpj));
        //}
        //public sosportalloja_Dommain Login(string cpf, string senha)
        //{
        //    return this._context.sosportallojas.ToList().FirstOrDefault(x => x.CPF.Equals(cpf) && x.Senha.Equals(senha));// && x.Status);
        //}
        //public void Salvar(sosportalloja_Dommain dommain)
        //{
        //    this._context.sosportallojas.Add(dommain);
        //    this._context.SaveChanges();
        //}
        //public void Excluir(int id)
        //{
        //    var filtro = this._context.sosportallojas.Find(id);
        //    this._context.Entry(filtro).State = System.Data.Entity.EntityState.Deleted;
        //    this._context.SaveChanges();
        //}
        //public void Atualizar(sosportalloja_Dommain dommain)
        //{
        //    this._context.Entry(dommain).State = System.Data.Entity.EntityState.Modified;
        //    this._context.SaveChanges();
        //}
        //public List<sosportalloja_Dommain> ListarTodos()
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
        //        _command.CommandText = "Usp_Listar_Loja";

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

        //        var retorno = new List<sosportalloja_Dommain>();

        //        /* O foreach varre o datarow e adiciona cada linha em uma lista ate acabar coleção */
        //        foreach (DataRow linha in datatable.Rows)
        //        {
        //            //Adiciona as informações namespace entidade

        //            var entity = new sosportalloja_Dommain
        //            {
        //                IdLoja = int.Parse(linha["IdLoja"].ToString()),
        //                Cnpj = linha["Cnpj"].ToString(),
        //                NomeFantasia = linha["NomeFantasia"].ToString(),
        //                Telefone = linha["Telefone"].ToString(),
        //                //Datacadastro = DateTime.Parse(linha["Datacadastro"].ToString()),
        //                Endereco = linha["Endereco"].ToString(),
        //                Status = bool.Parse(linha["Status"].ToString()),
        //                Complemento = linha["Complemento"].ToString(),
        //                Numero = linha["Numero"].ToString(),
        //                Cep = linha["Cep"].ToString(),
        //                Senha = linha["Senha"].ToString(),
        //                ResponsavelCadastro = linha["ResponsavelCadastro"].ToString(),
        //                PerfilLoja = linha["PerfilLoja"].ToString(),

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
        //public sosportalloja_Dommain ListarPorCpf(string cpf)
        //{
        //    return this._context.sosportallojas.ToList().FirstOrDefault(x => x.CPF == cpf);
        //}
        //public sosportalloja_Dommain ListarPorId(int id)
        //{
        //    return this._context.sosportallojas.Find(id);
        //}
        //public List<sosportalloja_Dommain> ListarPreCadastro()
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
        //        _command.CommandText = "Usp_listar_Precadastro";

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

        //        var retorno = new List<sosportalloja_Dommain>();

        //        /* O foreach varre o datarow e adiciona cada linha em uma lista ate acabar coleção */
        //        foreach (DataRow linha in datatable.Rows)
        //        {
        //            //Adiciona as informações namespace entidade

        //            var entity = new sosportalloja_Dommain
        //            {
        //                IdLoja = int.Parse(linha["IdLoja"].ToString()),
        //                Cnpj = linha["Cnpj"].ToString(),
        //                NomeFantasia = linha["NomeFantasia"].ToString(),
        //                Telefone = linha["Telefone"].ToString(),
        //                //Datacadastro = DateTime.Parse(linha["Datacadastro"].ToString()),
        //                Endereco = linha["Endereco"].ToString(),
        //                Status = bool.Parse(linha["Status"].ToString()),
        //                Complemento = linha["Complemento"].ToString(),
        //                Numero = linha["Numero"].ToString(),
        //                Cep = linha["Cep"].ToString(),
        //                Senha = linha["Senha"].ToString(),
        //                ResponsavelCadastro = linha["ResponsavelCadastro"].ToString(),
        //                PerfilLoja = linha["PerfilLoja"].ToString(),

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
        //public int ListarTodosPreCad(int idLoja)
        //{
        //    if (idLoja > 0)
        //        return this._context.sosportalpessoas.Where(x => x.IdLoja == idLoja && x.Status).ToList().Count();

        //    return this._context.sosportalpessoas.ToList().Count();
        //}

    }
}
