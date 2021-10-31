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
    }
}                            
