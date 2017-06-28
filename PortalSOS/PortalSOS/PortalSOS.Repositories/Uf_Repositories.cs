using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalSOS.Dommain;

namespace PortalSOS.Repositories
{
    public class Uf_Repositories
    {
        private readonly PortalSOS.Infra.Contexto.DB_Contetxt _context;
        public Uf_Repositories()
        {
            this._context = new Infra.Contexto.DB_Contetxt();
        }
        public sosportaluf_Dommain ListarPorId(int id)
        {
            return this._context.sosportalufs.Find(id);
        }
        public IEnumerable<sosportaluf_Dommain> ListarTodos()
        {
            return this._context.sosportalufs;
        }
        public void Salvar(sosportaluf_Dommain dommain)
        {
            this._context.sosportalufs.Add(dommain);
            this._context.SaveChanges();

        }
        public void Atualizar(sosportaluf_Dommain dommain)
        {
            this._context.Entry(dommain).State = System.Data.Entity.EntityState.Modified;
            this._context.SaveChanges();
        }
        public void Excluir(int id)
        {
            var filto = this._context.sosportalufs.Find(id);
            this._context.Entry(filto).State = System.Data.Entity.EntityState.Deleted;
            this._context.SaveChanges();
        }


    }
}
