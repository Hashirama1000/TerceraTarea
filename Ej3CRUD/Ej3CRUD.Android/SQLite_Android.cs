using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ej3CRUD.Droid;


[assembly: Dependency(typeof(SQLite_Android))]
namespace Ej3CRUD.Droid
{
         class SQLite_Android : ISQLite
        {
            SQLiteConnection con;
            public SQLiteConnection GetConnectionWithCreateDatabase()
            {
                string fileName = "Database.db";
                string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string path = Path.Combine(documentPath, fileName);
                con = new SQLiteConnection(path);
                con.CreateTable<Personas>();
                return con;
            }
            public bool SavePersonas(Personas persona)
            {
                bool res = false;
                try
                {
                    con.Insert(persona);
                    res = true;
                }
                catch (Exception ex)
                {
                    res = false;
                }
                return res;
            }
            public List<Personas> GetPersonas()
            {
                string sql = "SELECT * FROM Personas";
                List<Personas> personas = con.Query<Personas>(sql);
                return personas;
            }
            public bool UpdatePersonas(Personas persona)
            {
                bool res = false;
                try
                {
                    string sql = $"UPDATE Personas SET Nombre='{persona.Nombre}',Apellido='{persona.Apellido}',Edad='{persona.Edad}',Correo='{persona.Correo}'," +
                                    $"Direccion='{persona.Direccion}' WHERE Id={persona.Id}";
                    con.Execute(sql);
                    res = true;
                }
                catch (Exception ex)
                {

                }
                return res;
            }
            public void DeletePersonas(int Id)
            {
                string sql = $"DELETE FROM Personas WHERE Id={Id}";
                con.Execute(sql);
            }

         
        }
    }

