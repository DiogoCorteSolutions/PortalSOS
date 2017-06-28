using PortalSOS.Dommain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSOS.Application
{
    public class TipoOperacao_Application
    {
        private readonly PortalSOS.Repositories.TipoOperacao_Repositories _tipoOpApp;
        public TipoOperacao_Application()
        {
            this._tipoOpApp = new Repositories.TipoOperacao_Repositories();
        }
        public List<sosportaltipooperacao_Dommain> ListarTodos()
        {
            return this._tipoOpApp.ListarTodos();
        }
        public void Salvar(sosportaltipooperacao_Dommain dommain)
        {
            this._tipoOpApp.Salvar(dommain);
        }
        public void Excluir(int id)
        {
            this._tipoOpApp.Excluir(id);
        }
        public void Atualizar(sosportaltipooperacao_Dommain dommain)
        {
            this._tipoOpApp.Atualizar(dommain);
        }
        public sosportaltipooperacao_Dommain ListarPorId(int id)
        {
            return this._tipoOpApp.ListarPorId(id);
        }
    }
}
