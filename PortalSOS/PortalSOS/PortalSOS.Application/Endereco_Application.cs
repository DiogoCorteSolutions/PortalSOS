using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalSOS.Dommain;

namespace PortalSOS.Application
{
    public class Endereco_Application
    {
        private readonly PortalSOS.Repositories.Endereco_Repositories _repository;

        public Endereco_Application()
        {
            this._repository = new Repositories.Endereco_Repositories();
        }

        public IEnumerable<sosportalendereco_Dommain> ListarTodos()
        {
            return this._repository.ListarTodos();
        }
        public void Salvar(sosportalendereco_Dommain dommain)
        {
            this._repository.Salvar(dommain);
        }
        public void Excluir(int id)
        {
            this._repository.Excluir(id);
        }
        public void Atualizar(sosportalendereco_Dommain dommain)
        {
            this._repository.Atualizar(dommain);
        }
        public sosportalendereco_Dommain ListarPorId(int id)
        {
            return this._repository.ListarPorId(id);
        }
    }
}
