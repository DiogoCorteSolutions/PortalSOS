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
    public class Cliente_Repositories
    {
        private readonly PortalSOS.Infra.Contexto.DB_Contetxt _context;
        public Cliente_Repositories()
        {
            this._context = new Infra.Contexto.DB_Contetxt();
        }
        public sosportalcliente_Dommain ListarPorCnpj(string cnpj)
        {
            return this._context.sosportalclientes.ToList().FirstOrDefault(x => x.Cnpj.Equals(cnpj));
        }
        public sosportalcliente_Dommain Login(string cpf, string senha)
        {
            if (cpf.Length <= 14)
                return this._context.sosportalclientes.ToList().FirstOrDefault(x => x.CPF.Equals(cpf) && x.Senha.Equals(senha));// && x.Status);
            else
                return this._context.sosportalclientes.ToList().FirstOrDefault(x => x.Cnpj.Equals(cpf) && x.Senha.Equals(senha));// && x.Status);

                    //var str = this.ListarPorCpf(cpf);
            

            //if (strsenha == null)
            //    strsenha = "0";

            //if (str != null || strsenha != "0")
            //{
            //    if (cpf.Length <= 14)
            //        return this._context.sosportalclientes.ToList().FirstOrDefault(x => x.CPF.Equals(cpf) && x.Senha.Equals(senha));// && x.Status);
            //    else
            //        return this._context.sosportalclientes.ToList().FirstOrDefault(x => x.Cnpj.Equals(cpf) && x.Senha.Equals(senha));// && x.Status);

            //}
            //else if (str != null || strsenha == null)
            //{
            //    return this._context.sosportalclientes.ToList().FirstOrDefault(x => x.CPF == "0" && x.Senha.Equals(senha));// && x.Status);

            //}
            //else
            //{

            //    return this._context.sosportalclientes.ToList().FirstOrDefault(x => x.CPF == "0" && x.Senha.Equals(senha));// && x.Status);
            //}

            //if (cpf.Length <= 14)
            //    return this._context.sosportalclientes.ToList().FirstOrDefault(x => x.CPF.Equals(cpf) && x.Senha.Equals(senha));// && x.Status);
            //else
            //    return this._context.sosportalclientes.ToList().FirstOrDefault(x => x.Cnpj.Equals(cpf) && x.Senha.Equals(senha));// && x.Status);
        }
        public void Salvar(sosportalcliente_Dommain dommain)
        {
            this._context.sosportalclientes.Add(dommain);
            this._context.SaveChanges();
        }
        public void Excluir(int id)
        {
            var filtro = this._context.sosportalclientes.Find(id);
            this._context.Entry(filtro).State = System.Data.Entity.EntityState.Deleted;
            this._context.SaveChanges();
        }
        public void Atualizar(sosportalcliente_Dommain dommain)
        {
            this._context.Entry(dommain).State = System.Data.Entity.EntityState.Modified;
            this._context.SaveChanges();
        }
        public IEnumerable<sosportalcliente_Dommain> ListarTodos()
        {
            return this._context.sosportalclientes;
        }
        //public List<sosportalcliente_Dommain> ListarTodos()
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
        //        _command.CommandText = "USP_Listar_Todos_Clientes";

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

        //        var retorno = new List<sosportalcliente_Dommain>();

        //        /* O foreach varre o datarow e adiciona cada linha em uma lista ate acabar coleção */
        //        foreach (DataRow linha in datatable.Rows)
        //        {
        //            //Adiciona as informações namespace entidade

        //            var entity = new sosportalcliente_Dommain
        //            {
        //                IdCliente = int.Parse(linha["IdCliente"].ToString()),
        //                IdPessoaLoja = int.Parse(linha["IdPessoaLoja"].ToString()),
        //                IdPerfil = int.Parse(linha["IdPerfil"].ToString()),
        //                CPF = (linha["Tipo"].ToString()),
        //                Cnae = (linha["Tipo"].ToString()),
        //                Cnpj = (linha["Tipo"].ToString()),
        //                RazaoSocial = (linha["Tipo"].ToString()),
        //                Pessoa = (linha["Tipo"].ToString()),
        //                Tipo = (linha["Tipo"].ToString()),
        //                Endereco = (linha["Tipo"].ToString()),
        //                Email = (linha["Tipo"].ToString()),
        //                Representante = (linha["Tipo"].ToString()),
        //                Senha = (linha["Tipo"].ToString()),
        //                RG = (linha["Tipo"].ToString()),
        //                Estado = (linha["Tipo"].ToString()),
        //                Cidade = (linha["Tipo"].ToString()),
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
        //public List<sosportalcliente_Dommain> ListarTodos()
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
        //        _command.CommandText = "Usp_Listar_Cliente";

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

        //        var retorno = new List<sosportalcliente_Dommain>();

        //        /* O foreach varre o datarow e adiciona cada linha em uma lista ate acabar coleção */
        //        foreach (DataRow linha in datatable.Rows)
        //        {
        //            //Adiciona as informações namespace entidade

        //            var entity = new sosportalcliente_Dommain
        //            {
        //                IdCliente = int.Parse(linha["IdCliente"].ToString()),
        //                IdPerfil = int.Parse(linha["IdPerfil"].ToString()),
        //                //IdConfiguracaoCliente = int.Parse(linha["IdConfiguracaoCliente"].ToString()),
        //                //IdContato = int.Parse(linha["IdContato"].ToString()),
        //                //IdEndereco = int.Parse(linha["IdEndereco"].ToString()),
        //                Cnpj = linha["Cnpj"].ToString(),
        //                RazaoSocial = linha["RazaoSocial"].ToString(),
        //                Ativacao = linha["Ativacao"].ToString(),
        //                //Datacadastro = DateTime.Parse(linha["Datacadastro"].ToString()),
        //                CodProduto = int.Parse(linha["CodProduto"].ToString()),
        //                Status = bool.Parse(linha["Status"].ToString()),
        //                Cnae = linha["Cnae"].ToString(),
        //                CPF = linha["CPF"].ToString(),
        //                Email = linha["Email"].ToString(),
        //                Senha = linha["Senha"].ToString(),
        //                Emitente = linha["Emitente"].ToString(),
        //                Estadual = linha["Estadual"].ToString(),
        //                InscricaoMunicipal = linha["InscricaoMunicipal"].ToString(),
        //                Licenca = linha["Licenca"].ToString(),
        //                LimiteCred = decimal.Parse(linha["LimiteCred"].ToString()),
        //                Modelo = linha["Modelo"].ToString(),
        //                Obs = linha["Obs"].ToString(),
        //                Pessoa = linha["Pessoa"].ToString(),
        //                Representante = linha["Representante"].ToString(),
        //                RG = linha["RG"].ToString(),
        //                Tipo = linha["Tipo"].ToString(),
        //                Total = int.Parse(linha["Total"].ToString()),
        //                Ultilizado = linha["Ultilizado"].ToString(),

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
        public sosportalcliente_Dommain ListarPorCpf(string cpf)
        {
            return this._context.sosportalclientes.ToList().FirstOrDefault(x => x.CPF == cpf);
        }
        public sosportalcliente_Dommain ListarPorSenha(string senha, string cpf)
        {
            return this._context.sosportalclientes.ToList().FirstOrDefault(x => x.CPF == cpf || x.Senha == senha);
        }
        public bool ExisteSenha(string cpf, string senha)
        {
            return this._context.sosportalclientes.ToList().Exists(x => x.CPF == cpf && x.Senha == senha);
        }
        public sosportalcliente_Dommain ListarPorLojaPaid(int idcliente)
        {
            return this._context.sosportalclientes.ToList().FirstOrDefault(x => x.IdPessoaLoja.Value == idcliente);
        }
        public sosportalcliente_Dommain ListarPorId(int id)
        {
            return this._context.sosportalclientes.Find(id);
        }
        public sosportalcliente_Dommain ListarPorIdPerfil(int idPerfil)
        {
            //return this._context.sosportalclientes.Find(idPerfil);
            return this._context.sosportalclientes.FirstOrDefault(x => x.IdPerfil == idPerfil);
        }
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
        public bool Existe(string cpf)
        {
            return this._context.sosportalclientes.ToList().Exists(x => x.CPF == cpf);
        }
        //public IEnumerable<sosportalcliente_Dommain> ListarPorLojaPaid(string idcliente = null)
        //{

        //    //    return !string.IsNullOrWhiteSpace(idcliente) ?
        //    //        this._context.sos.Pessoa.Where(x => x.Cpf == cpf)
        //    //        : this._context.Pessoa;
        //}

        //public IEnumerable<sosportalcliente_Dommain> ListarPorLojaPaid(int idcliente = null)
        //{
        //    return this.ListarTodos(cpf);

        //}
    }
}
