using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App1.modelo;
using System.Threading.Tasks;

namespace App1.Data
{
    public class SQLiteHelper
    {
        //aqui van los metodos controladores de la base
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<usuario>().Wait();
        }

        public Task<int> GuardarUsuario(usuario us)
        {
            if (us.IDusuario ==0)
            {
                return db.InsertAsync(us);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Recupera todos los alumnos
        /// </summary>
        /// <returns></returns>
        public Task<List<usuario>> GetUsuariosAsync() 
        {
            return db.Table<usuario>().ToListAsync();
        }

        /// <summary>
        /// Recupera alumno por ID
        /// </summary>
        /// <param name="IDusuario">ID del alumno que se requeire </param>
        /// <returns></returns>
        public Task<usuario> GetUsuariotoID(int IDusuario)
        {
            return db.Table<usuario>().Where(a => a.IDusuario == IDusuario).FirstOrDefaultAsync();
        }
    }
}                            
