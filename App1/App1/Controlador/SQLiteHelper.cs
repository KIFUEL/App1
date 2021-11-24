using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App1.modelo;
using System.Threading.Tasks;
using System.Linq;

namespace App1.Data
{
    public class SQLiteHelper
    {
        //conexion con la base de datos 
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
        //aqui van los metodos controladores de la base

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


        //region metodos login
       public Task<List<usuario>> GetUsuariosValido(string email, string password)
        {
            return db.QueryAsync<usuario>("SELECT * FROM usuario WHERE email = '" + email + "' AND password = '" + password + "'" ) ;
        }

        /// <summary>
        /// Recupero usuario por nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Task<List<usuario>> GetUsuarioporNombre(string nombre)
        {
            return db.QueryAsync<usuario>("SELECT * FROM usuario WHERE nombre = '" + nombre + "'");
        }

    }
}                            
