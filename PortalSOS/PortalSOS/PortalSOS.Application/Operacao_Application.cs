using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalSOS.Dommain;

namespace PortalSOS.Application
{
    public class Operacao_Application
    {
        private readonly PortalSOS.Repositories.Operacao_Repositories _repository;
        public Operacao_Application()
        {
            this._repository = new Repositories.Operacao_Repositories();
        }

        public List<sosportaloperacao_Dommain> ListarTodos()
        {
            return this._repository.ListarTodos();
        }
        public void Salvar(sosportaloperacao_Dommain dommain)
        {
            this._repository.Salvar(dommain);
        }
        public void Excluir(int id)
        {
            this._repository.Excluir(id);

        }
        public void Atualizar(sosportaloperacao_Dommain dommain)
        {
            this._repository.Atualizar(dommain);
        }
        public sosportaloperacao_Dommain ListarPorId(int id)
        {
            return this._repository.ListarPorId(id);
        }
    }
}
