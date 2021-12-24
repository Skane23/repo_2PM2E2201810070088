using PM2E2201810070088.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM2E2201810070088.Controles
{
   public class DataBaseSQLite
    {
        readonly SQLiteAsyncConnection db;

        //constructor de la clase DataBaseSQLite
        public DataBaseSQLite(string pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<Sitios>().Wait();
        }

        //Operaciones crud de sqlite
        //Read List way
        public Task<List<Sitios>> ObtenerListaSitios()
        {
            return db.Table<Sitios>().ToListAsync();
        }

        //read one by one 
        public Task<Sitios> ObtenerSitios(int pcodigo)
        {
            return db.Table<Sitios>()
                .Where(i => i.id == pcodigo)
                .FirstOrDefaultAsync();
        }

        //Create o update personas
        public Task<int> GrabarSitios(Sitios s)
        {
            if (s.id != 0)
            {
                return db.UpdateAsync(s);
            }
            else
            {
                return db.InsertAsync(s);
            }

        }



        //delete
        public Task<int> EliminarSitios(Sitios s)
        {
            return db.DeleteAsync(s);
        }


    }
}
