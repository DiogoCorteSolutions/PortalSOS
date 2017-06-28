using PortalSOS.Dommain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSOS.Application
{
    public class ContasAPagar_Application
    {
        private readonly PortalSOS.Repositories.ContasAPagar_Repositories _repository;

        public ContasAPagar_Application()
        {
            this._repository = new Repositories.ContasAPagar_Repositories();
        }

        public List<sosportalcontasapagar_Dommain> ListarTodos()
        {
            return this._repository.ListarTodos();
        }
        public void Salvar(sosportalcontasapagar_Dommain dommain)
        {
            this._repository.Salvar(dommain);

        }
        public void Excluir(int id)
        {
            this._repository.Excluir(id);
        }
        public void Atualizar(sosportalcontasapagar_Dommain dommain)
        {
            this._repository.Atualizar(dommain);
        }
        public sosportalcontasapagar_Dommain ListarPorId(int id)
        {
            return this._repository.ListarPorId(id);
        }


    }




}
