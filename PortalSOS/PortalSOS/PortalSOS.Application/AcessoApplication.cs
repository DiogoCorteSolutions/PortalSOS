using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalSOS.Dommain;

namespace PortalSOS.Application
{
    public class AcessoApplication
    {
        private readonly PortalSOS.Repositories.Acesso_Repositories _repository;

        public AcessoApplication()
        {
            this._repository = new Repositories.Acesso_Repositories();
        }
        public IList<sosportalconfiguracaocliente_Dommain> ListarConfigurcooesPorClienteId(int clienteId)
        {
            return this._repository.ListarConfigurcooesPorClienteId(clienteId);
        }
        public IList<sosportalconfiguracaocliente_Dommain> ListarConfigurcooesPorPessoLoja(int idpessoaloja)
        {
            return this._repository.ListarConfigurcooesPorPessoLoja(idpessoaloja);
        }
        public List<sosportalconfiguracaocliente_Dommain> ListarTodos()
        {
            return this._repository.ListarTodos();
        }
        public void Salvar(sosportalconfiguracaocliente_Dommain dommain)
        {
            this._repository.Salvar(dommain);
        }
        public void Atualizar(sosportalconfiguracaocliente_Dommain dommain)
        {
            this._repository.Atualizar(dommain);
        }
        public void Excluir(int id)
        {
            this._repository.Excluir(id);
        }
        public sosportalconfiguracaocliente_Dommain ListarPorId(int id)
        {
            return this._repository.ListarPorId(id);
        }
    }
}
