using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E2201810070088.Modelos
{
    public class Sitios
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string descripcion { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string fotografia { get; set; }

    }
}
