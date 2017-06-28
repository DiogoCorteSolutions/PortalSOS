using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalSOS.Dommain;

namespace PortalSOS.Application
{
    public class Contato_Application
    {
        private readonly PortalSOS.Repositories.Contato_Repositories _contatoApp;

        public Contato_Application()
        {
            this._contatoApp = new Repositories.Contato_Repositories();
        }

        public IEnumerable<sosportalcontato_Dommain> ListarTodos()
        {
            return this._contatoApp.ListarTodos();
        }
        public void Excluir(int id)
        {
            this._contatoApp.Excluir(id);
        }
        //public void Atualizar(sosportalcontato_Dommain dommain)
        //{
        //    this._contatoApp.Atualizar(dommain.IdContato);
        //}
    }
}
