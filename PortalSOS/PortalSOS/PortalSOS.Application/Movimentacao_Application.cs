using PortalSOS.Dommain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSOS.Application
{
    public class Movimentacao_Application
    {
        private readonly PortalSOS.Repositories.Movimentacao_Repositories _repository;
        public Movimentacao_Application()
        {
            this._repository = new Repositories.Movimentacao_Repositories();
        }
        public List<sosportalmovimentacao_Dommain> ListarTodos()
        {
            return this._repository.ListarTodos();
        }
        public void Salvar(sosportalmovimentacao_Dommain dommain)
        {
            this._repository.Salvar(dommain);
        }
        public void Excluir(int id)
        {
            this._repository.Excluir(id);
        }
        public void Atualizar(sosportalmovimentacao_Dommain dommain)
        {
            this._repository.Atualizar(dommain);
        }
        public sosportalmovimentacao_Dommain ListarPorId(int id)
        {
            return this._repository.ListarPorId(id);
        }
    }
}
