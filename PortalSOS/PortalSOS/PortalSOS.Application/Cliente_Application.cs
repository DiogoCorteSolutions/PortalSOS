using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalSOS.Dommain;

namespace PortalSOS.Application
{
    public class Cliente_Application
    {
        private readonly PortalSOS.Repositories.Cliente_Repositories _repository;

        public Cliente_Application()
        {
            this._repository = new Repositories.Cliente_Repositories();
        }
        public sosportalcliente_Dommain ListarPorLojaPaid(int idcliente)
        {
            return this._repository.ListarPorLojaPaid(idcliente);
        }

        //public List<sosportalcliente_Dommain> ListarTodos()
        //{
        //    return this._repository.ListarTodos();
        //}
        public IEnumerable<sosportalcliente_Dommain> ListarTodos()
        {
            return this._repository.ListarTodos();
        }
        //public IEnumerable<sosportalloja_Dommain> ListarTodosPreCad()
        //{
        //    return this._repository.ListarTodosPreCad();
        //}
        public sosportalcliente_Dommain Login(string cpf, string senha)

        {
            return this._repository.Login(cpf, senha);
        }
        public void Salvar(sosportalcliente_Dommain dommain)
        {
            this._repository.Salvar(dommain);
        }
        public void Excluir(int id)
        {
            this._repository.Excluir(id);
        }
        public void Atualizar(sosportalcliente_Dommain dommain)
        {
            this._repository.Atualizar(dommain);
        }
        public sosportalcliente_Dommain ListarPorId(int id)
        {
            return this._repository.ListarPorId(id);
        }
        public sosportalcliente_Dommain ListarPorIdPerfil(int idPerfil)
        {
            return this._repository.ListarPorIdPerfil(idPerfil);
        }
        public sosportalcliente_Dommain ListarPorCpf(string cpf)
        {
            return this._repository.ListarPorCpf(cpf);
        }
        //public int ListarTodosPreCad(int idLoja)
        //{
        //    return this._repository.ListarTodosPreCad(idLoja);
        //}

        public bool Existe(string cpf)
        {
            return this._repository.Existe(cpf);
        }
    }
}
