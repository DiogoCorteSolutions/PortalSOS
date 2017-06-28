using PortalSOS.Dommain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSOS.Application
{
    public class Perfil_Application
    {
        private readonly PortalSOS.Repositories.Perfil_Repositories _repository;

        public Perfil_Application()
        {
            this._repository = new Repositories.Perfil_Repositories();
        }

        public List<sosportalperfil_Dommain> ListarTodos()
        {
            return this._repository.ListarTodos();
        }
        public void Salvar(sosportalperfil_Dommain dommain)
        {
            this._repository.Salvar(dommain);
        }
        public void Excluir(int id)
        {
            this._repository.Excluir(id);
        }
        public void Atualizar(sosportalperfil_Dommain dommain)
        {
            this._repository.Atualizar(dommain);
        }
        public sosportalperfil_Dommain ListarPorId(int id)
        {
            return this._repository.ListarPorId(id);
        }
        public bool ExistePerfilSegm (string perfil)
        {
            return this._repository.ExistePerfilSegm(perfil);
        }
    }

}
