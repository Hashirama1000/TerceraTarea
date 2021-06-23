using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ej3CRUD
{
    public class Personas
    {
            
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Edad { get; set; }
        public string Correo{ get; set; }
        public string Direccion { get; set; }
    }
}
    

