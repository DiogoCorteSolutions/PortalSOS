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
    public class Cofiguracao_Repositories
    {
        private readonly PortalSOS.Infra.Contexto.DB_Contetxt _context;
        private readonly PortalSOS.Repositories.Cliente_Repositories _clienteReposotiry;

        public Cofiguracao_Repositories()
        {
            this._clienteReposotiry = new Cliente_Repositories();
            this._context = new Infra.Contexto.DB_Contetxt();
        }
        public IList<sosportalconfiguracao_Dommain> ListarConfigurcooesPorClienteId(int clienteId, int idperfil)
        {
            var filtroPeril = this._clienteReposotiry.ListarPorId(clienteId).IdPerfil;


            var setidlojaCliente = _clienteReposotiry.ListarPorId(clienteId).IdCliente;
            var setidlojaIdLoja = _clienteReposotiry.ListarPorId(clienteId).IdPessoaLoja;
            var setidPerfil = _clienteReposotiry.ListarPorId(clienteId).IdPerfil;
            var idfinal = _clienteReposotiry.ListarPorId(clienteId).IdPessoaLoja;


            var result = this._context.sosportalconfiguracaos.Where(x =>
                     x.sosportalconfiguracaoclientes.Any(s => s.IdPessoaLoja == clienteId && s.IdPerfil == idperfil));
            return result.ToList();
        }
        public IList<sosportalconfiguracao_Dommain> ListarConfigurcooesPorClienteIdAcesso(int clienteId, int idperfil)
        {
            var filtroPeril = this._clienteReposotiry.ListarPorId(clienteId).IdPerfil;


            var setidlojaCliente = _clienteReposotiry.ListarPorId(clienteId).IdCliente;
            var setidlojaIdLoja = _clienteReposotiry.ListarPorId(clienteId).IdPessoaLoja;
            var setidPerfil = _clienteReposotiry.ListarPorId(clienteId).IdPerfil;
            var idfinal = _clienteReposotiry.ListarPorId(clienteId).IdPessoaLoja;


            var result = this._context.sosportalconfiguracaos.Where(x =>
                     x.sosportalconfiguracaoclientes.Any(s => s.IdPessoaLoja == setidlojaIdLoja && s.IdPerfil == idperfil));
            return result.ToList();
        }
        public bool ExisteConrolle(string controle)
        {
            return this._context.sosportalconfiguracaos.ToList().Exists(x => x.ControllerAction == controle);
        }
        public IList<sosportalconfiguracao_Dommain> ListarConfigurcooesPorLojaId(int idCliente)
        {

            var perfil = _clienteReposotiry.ListarPorId(idCliente).IdPerfil;
            var iddoCliente = _clienteReposotiry.ListarPorId(idCliente).IdPessoaLoja;


            var result = this._context.sosportalconfiguracaos.Where(x =>
                                x.sosportalconfiguracaoclientes.Any(s => s.sosportalcliente.IdPessoaLoja == iddoCliente
                                && s.IdPerfil == perfil));
            return result.ToList();
        }
        public
           List<sosportalcliente_Dommain> ListarMenuPorIdPessoaLoja
           (int idPessoaLoja)
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DB_Contexto_Procedure"].ToString();

                /* Criar conexão com banco de dados */
                var _connection = new SqlConnection(connectionString);

                /* Abrir conexão */
                _connection.Open();

                /* Criar comando que vai enviar informações para o banco */
                SqlCommand _command = _connection.CreateCommand();

                /* Adicionar as informações dentro do comando que vai enviar para o banco */
                _command.CommandType = CommandType.StoredProcedure;

                /* Recebe o nome da procedure que esta sendo executada */
                _command.CommandText = "uspListarPorCompras";

                /* Defini o tempo que a conexão ficará aberta (Em Segundos [7200] = 2 horas) */
                _command.CommandTimeout = 7200;

                //    var _parameterCollection = new SqlCommand();
                var _parameterCollection = new SqlCommand().Parameters;

                /* Adicionar os paramentros no comando */
                _parameterCollection.Add("@IdPessoaLoja", idPessoaLoja);

                /* Criar um adptador */
                var sqlDataAdapter = new SqlDataAdapter(_command);

                /* Criar datatable vasia aonde vou adicionar os valores que serão retornados do banco */
                var dataTable = new DataTable();

                /* Mandar comando ir ate o banco buscar os daods e o o adptador preencher a datatable */
                sqlDataAdapter.Fill(dataTable);

                /* Finaliza Conexão com banco de Dados */
                _connection.Close();
                _connection.Dispose();

                var retorno = new List<sosportalcliente_Dommain>();

                /* O foreach varre o datarow e adiciona cada linha em uma lista ate acabar coleção */
                foreach (DataRow linha in dataTable.Rows)
                {
                    /* Adiciona as informações na entidade */
                    var entity = new sosportalcliente_Dommain
                    {
                        IdCliente = int.Parse(linha["IdCliente"].ToString()),
                        IdPessoaLoja = int.Parse(linha["IdPessoaLoja"].ToString()),
                    };
                    var ent = new sosportalconfiguracaopessoa_Dommain
                    {
                        IdConfiguracao = int.Parse(linha["IdConfiguracao"].ToString()),

                    };

                    var entityFinal = new sosportalperfil_Dommain
                    {
                        IdPerfil = int.Parse(linha["IdPerfil"].ToString()),

                    };
                    var confi = new sosportalconfiguracao_Dommain
                    {
                        IdConfiguracao = int.Parse(linha["IdConfiguracao"].ToString()),
                        ControllerAction = linha["ControllerAction"].ToString(),
                        IdController = int.Parse(linha["IdController"].ToString()),
                    };

                    retorno.Add(entity);
                }

                /* Retorna a tabela preenchida */
                return retorno.ToList();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
        }
        public sosportalconfiguracao_Dommain ListarPorId(int id)
        {
            return this._context.sosportalconfiguracaos.Find(id);
        }
        //public List<sosportalconfiguracao_Dommain> ListarConfigurcooesPorClienteId(int clienteId)
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
        //        _command.CommandText = "Usp_Permissao_Menu ";

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

        //        var retorno = new List<sosportalconfiguracao_Dommain>();

        //        /* O foreach varre o datarow e adiciona cada linha em uma lista ate acabar coleção */
        //        foreach (DataRow linha in datatable.Rows)
        //        {
        //            //Adiciona as informações namespace entidade

        //            var entity = new sosportalconfiguracao_Dommain
        //            {




        //                IdConfiguracao = int.Parse(linha["IdConfiguracao"].ToString()),
        //                Controller = linha["Controller"].ToString(),
        //                IdController = int.Parse(linha["IdController"].ToString()),
        //                ViewName = linha["ViewName"].ToString(),
        //                Status = bool.Parse(linha["Status"].ToString()),

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
        public List<sosportalconfiguracao_Dommain> ListarTodos()
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
                _command.CommandText = "Usp_ListarTodos_Configurcao";

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

                var retorno = new List<sosportalconfiguracao_Dommain>();

                /* O foreach varre o datarow e adiciona cada linha em uma lista ate acabar coleção */
                foreach (DataRow linha in datatable.Rows)
                {
                    //Adiciona as informações namespace entidade

                    var entity = new sosportalconfiguracao_Dommain
                    {
                        IdConfiguracao = int.Parse(linha["IdConfiguracao"].ToString()),
                        ControllerAction = linha["ControllerAction"].ToString(),
                        IdController = int.Parse(linha["IdController"].ToString()),
                        ViewName = linha["ViewName"].ToString(),
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
        public void Salvar(sosportalconfiguracao_Dommain dommain)
        {
            this._context.sosportalconfiguracaos.Add(dommain);
            this._context.SaveChanges();

        }
        public void Atualizar(sosportalconfiguracao_Dommain dommain)
        {
            this._context.Entry(dommain).State = System.Data.Entity.EntityState.Modified;
            this._context.SaveChanges();
        }
        public void Excluir(int id)
        {
            var filto = this._context.sosportalconfiguracaos.Find(id);
            this._context.Entry(filto).State = System.Data.Entity.EntityState.Deleted;
            this._context.SaveChanges();
        }
        public IEnumerable<sosportalconfiguracao_Dommain> ListarActioPorIdController(int idController)
        {
            var filtro = this._context.sosportalconfiguracaos.ToList().Where(x => x.IdController == idController);

            return filtro.ToList();

            //return this._context.sosportalconfiguracaos.Find(idController);
        }
        public List<sosportalconfiguracao_Dommain> ListarTodosConfiguracoes()
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
                _command.CommandText = "Usp_ListarTodos_Configurcao";

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

                var retorno = new List<sosportalconfiguracao_Dommain>();

                /* O foreach varre o datarow e adiciona cada linha em uma lista ate acabar coleção */
                foreach (DataRow linha in datatable.Rows)
                {
                    //Adiciona as informações namespace entidade

                    var entity = new sosportalconfiguracao_Dommain
                    {
                        IdConfiguracao = int.Parse(linha["IdConfiguracao"].ToString()),
                        ControllerAction = linha["ControllerAction"].ToString(),
                        IdController = int.Parse(linha["IdController"].ToString()),
                        ViewName = linha["ViewName"].ToString(),
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
        public bool ExisteAction(string action, int idconctroller)
        {
            return this._context.sosportalconfiguracaos.ToList().Exists(x => x.ControllerAction == action && x.IdController == idconctroller);
        }


        //Metodo Teste
        //public IList<sosportalconfiguracao_Dommain> ListarConfigurcooesPorLojaId(int idCliente)
        //{

        //    var perfil = _clienteReposotiry.ListarPorId(idCliente).IdPerfil;
        //    var iddoCliente = _clienteReposotiry.ListarPorId(idCliente).IdPessoaLoja;


        //    var result = this._context.sosportalconfiguracaos.Where(x =>
        //                        x.sosportalconfiguracaoclientes.Any(s => s.sosportalcliente.IdPessoaLoja == iddoCliente
        //                        && s.IdPerfil == perfil));
        //    return result.ToList();





        //    //  select* from sosportalcliente
        //    //c join sosportalconfiguracaocliente ss on ss.IdCliente = c.IdPessoaLoja
        //    //join sosportalconfiguracao cc on cc.IdConfiguracao = ss.IdConfiguracao
        //    //join sosportalperfil p on p.IdPerfil = c.IdPerfil
        //    //where c.IdPessoaLoja = 33
        //}

        //public IList<sosportalconfiguracao_Dommain> ListarConfigurcooesPorClienteId(int clienteId, int idperfil)
        //{
        //    var filtroPeril = this._clienteReposotiry.ListarPorId(clienteId).IdPerfil;


        //    var setidlojaCliente = _clienteReposotiry.ListarPorId(clienteId).IdCliente;
        //    var setidlojaIdLoja = _clienteReposotiry.ListarPorId(clienteId).IdPessoaLoja;
        //    var setidPerfil = _clienteReposotiry.ListarPorId(clienteId).IdPerfil;


        //    var result = this._context.sosportalconfiguracaos.Where(x =>
        //             x.sosportalconfiguracaoclientes.Any(s => s.IdPessoaLoja == setidlojaIdLoja && s.IdPerfil == idperfil));
        //    return result.ToList();

        //    //var result = this._context.sosportalconfiguracaos.Where(x =>
        //    //        x.sosportalconfiguracaoclientes.Any(s => s.IdCliente == clienteId));
        //    //return result.ToList();
        //}


        //public void ListarConfigurcooesPorClienteIdTEste()
        //{
        //    using (var contexto = new PortalSOS.Infra.Contexto.DB_Contetxt())
        //    {
        //        var query = from s in _context.sosportalclientes
        //                    join c in _context.sosportalconfiguracaoclientes on s.IdCliente equals c.IdCliente
        //                    join b in _context.sosportalconfiguracaos on c.IdConfiguracao equals b.IdConfiguracao
        //                    join p in _context.sosportalperfils on s.IdCliente equals (p.IdPerfil)
        //                    where s.IdCliente.Equals(s.IdCliente) && s.IdPerfil.Equals(p.IdPerfil)
        //                    select new
        //                    {
        //                        s.IdCliente,
        //                        s.IdPessoaLoja,
        //                        s.IdPerfil,
        //                        c.IdConfiguracao,
        //                        b.ControllerAction,
        //                        b.ViewName,
        //                        p.Perfil
        //                    };
        //        query.ToList();

        //    }


        //}
        //public List<ConfiguracaoPorLoja_Dommain> ListarConfigurcooesPorClienteIdTEste(int clienteId, int idPerfil)
        //        {


        //            var query = from s in _context.sosportalclientes
        //                        join c in _context.sosportalconfiguracaoclientes on s.IdCliente equals c.IdCliente
        //                        join b in _context.sosportalconfiguracaos on c.IdConfiguracao equals b.IdConfiguracao
        //                        join p in _context.sosportalperfils   on idPerfil equals(p.IdPerfil)
        //                        where s.IdCliente.Equals(clienteId) && s.IdPerfil.Equals(idPerfil)
        //                        select new { s.IdCliente, s.IdPessoaLoja, s.IdPerfil, c.IdConfiguracao, b.ControllerAction, b.ViewName, p.Perfil};

        //            foreach (var item in query.ToList())
        //            {
        //                var retorno = new ConfiguracaoPorLoja_Dommain
        //                {
        //                    ControllerAction = item.ControllerAction,
        //                    IdCliente = item.IdCliente,
        //                    IdConfiguracao = item.IdConfiguracao,
        //                    IdPerfil = item.IdPerfil,
        //                    Perfil = item.Perfil,
        //                };


        //            }

        //            return ;
        //        }

        //public int IdCliente { get; set; }
        //public int IdPerfil { get; set; }

        //public int IdPessoaLoja { get; set; }
        //public int IdConfiguracao { get; set; }
        //public string ControllerAction { get; set; }
        //public string ViewName { get; set; }
        //public int IdController { get; set; }
        //public string Perfil { get; set; }


        //public IEnumerable<sosportalcliente_Dommain> ListarConfigurcooesPorClienteIdTEste()
        //{
        //    var query = from s in _context.sosportalclientes
        //                join c in _context.sosportalconfiguracaoclientes on s.IdCliente equals c.IdCliente
        //                join b in _context.sosportalconfiguracaos on c.IdConfiguracao equals b.IdConfiguracao
        //                select new { s, c, b };

        //    query.ToList();


        //}

    }
}
