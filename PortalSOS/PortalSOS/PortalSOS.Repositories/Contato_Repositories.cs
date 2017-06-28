using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalSOS.Dommain;

namespace PortalSOS.Repositories
{
    public class Contato_Repositories
    {
        private readonly PortalSOS.Infra.Contexto.DB_Contetxt _context;

        public Contato_Repositories()
        {
            this._context = new Infra.Contexto.DB_Contetxt();
        }

        public void Salvar(sosportalcontato_Dommain dommain)
        {
            this._context.sosportalcontatoes.Add(dommain);
            this._context.SaveChanges();
        }
        public void Excluir(int id)
        {
            var filtro = this._context.sosportalclientes.Find(id);
            this._context.Entry(filtro).State = System.Data.Entity.EntityState.Deleted;
            this._context.SaveChanges();
        }
        public void Atualizar(sosportalcontato_Dommain dommain)
        {
            this._context.Entry(dommain).State = System.Data.Entity.EntityState.Modified;
            this._context.SaveChanges();
        }
        public IEnumerable<sosportalcontato_Dommain> ListarTodos()
        {
            return this._context.sosportalcontatoes;
        }
        public sosportalcontato_Dommain ListarPorId(int id)
        {
            return this._context.sosportalcontatoes.Find(id);
        }

    }
}
