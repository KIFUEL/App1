using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
//base de datos

namespace App1.modelo
{
    //tabla usuario creada
    public class usuario
    {
        [PrimaryKey, AutoIncrement]
        public int IDusuario { get; set; }
        [MaxLength(64)]
        public string Nombre { get; set; }
        [MaxLength(64), NotNull]
        public string Apellido_Materno { get; set; }
        [MaxLength(64), NotNull]
        public string Apellido_Paterno { get; set; }
        [MaxLength(64)]
        public string Intereses { get; set; }
        [MaxLength(512)]
        public string Direccion { get; set; }
        [MaxLength(264)]
        public string email { get; set; }
        [MaxLength(264)]
        public int Matricula { get; set; }
        [MaxLength(64)]
        public string password { get; set; }
        
    }

   

}
