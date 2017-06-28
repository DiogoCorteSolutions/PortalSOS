using PortalSOS.Dommain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSOS.Application
{
    public class Produto_Application
    {
        private readonly PortalSOS.Repositories.Produto_Repositories _repository;

        public Produto_Application()
        {
            this._repository = new Repositories.Produto_Repositories();
        }
        public List<sosportalproduto_Dommain> ListarTodos()
        {
            return this._repository.ListarTodos();
        }
        public void Excluir(int id)
        {
            this._repository.Excluir(id);
        }
        public void Salvar(sosportalproduto_Dommain dommain)
        {
            this._repository.Salvar(dommain);
        }
        public void Atualizar(sosportalproduto_Dommain dommain)
        {
            this._repository.Atualizar(dommain);
        }
        public sosportalproduto_Dommain ListarPorId(int id)
        {
            return this._repository.ListarPorId(id);
        }
    }
}
