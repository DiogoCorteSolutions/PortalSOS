using PortalSOS.Dommain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSOS.Application
{
    public class ContasAReceber_Application
    {
        private readonly PortalSOS.Repositories.ContasAReceber_Repositories _repository;

        public ContasAReceber_Application()
        {
            this._repository = new Repositories.ContasAReceber_Repositories();
        }
        public List<sosportalcontasareceber_Dommain> ListarTodos()
        {
            return this._repository.ListarTodos();
        }
        public void Salvar(sosportalcontasareceber_Dommain dommain)
        {
            this._repository.Salvar(dommain);

        }
        public void Excluir(int id)
        {
            this._repository.Excluir(id);
        }
        public void Atualizar(sosportalcontasareceber_Dommain dommain)
        {
            this._repository.Atualizar(dommain);
        }
        public sosportalcontasareceber_Dommain ListarPorId(int id)
        {
            return this._repository.ListarPorId(id);
        }
    }
}
