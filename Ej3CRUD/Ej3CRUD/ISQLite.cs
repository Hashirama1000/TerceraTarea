using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ej3CRUD
{
    public interface ISQLite
    {
        SQLiteConnection GetConnectionWithCreateDatabase();

        bool SavePersonas(Personas persona);

        List<Personas> GetPersonas();

        bool UpdatePersonas(Personas persona);
        void DeletePersonas(int Id);
    }
}




