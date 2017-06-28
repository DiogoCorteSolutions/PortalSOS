using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalSOS.Dommain;

namespace PortalSOS.Application
{
    public class UF_Application
    {
        private readonly PortalSOS.Repositories.Uf_Repositories _repository;
        public UF_Application()
        {
            this._repository = new Repositories.Uf_Repositories();
        }
        public IEnumerable<sosportaluf_Dommain> ListarTodos()
        {
            return this._repository.ListarTodos();
        }
        public sosportaluf_Dommain ListarPorId(int id)
        {
            return this._repository.ListarPorId(id);
        }
        public void Salvar(sosportaluf_Dommain dommain)
        {
            this._repository.Salvar(dommain);
        }
        public void Atualizar(sosportaluf_Dommain dommain)
        {
            this._repository.Atualizar(dommain);
        }
        public void Excluir(int id)
        {
            this._repository.Excluir(id);
        }

    }

}
