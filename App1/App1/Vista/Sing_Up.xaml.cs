using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.modelo;

namespace App1.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sing_Up : ContentPage
    {
        
        public Sing_Up()
        {
            InitializeComponent();
        }

        public void Button_Registro(object sender, EventArgs e)
        {
            bool verific = VerificarR();
            if (verific == true)
            {
                //Prueba
                Campo_Obligatorio.IsVisible = false;
                wrongMail.IsVisible = false;

                Registrar();
            }
            
        }

        private bool VerificarR()
        {
            string capNombres = txtNombres.Text;
            string capApellidoP = txtApP.Text;
            string capApellidoM = txtApM.Text;
            string capCorreo = txtCorreo.Text;
            string capPass = txtPass.Text;
            string capPass1 = txtPass1.Text;
            string capMatricula = txtMatricula.Text;


            if(capPass != capPass1) 
            {
                pass_incorrecto.Text = "Las contraseñas no coinciden";
            }

          
                //cadena o expresion regular que verifica a un formato de correo electrónico
                string expresion = "^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a - z]{ 2,4})$";
                //verifica que el email ingresado corresponda con la expresion válida
                if (capNombres == null || capApellidoM == null || capApellidoP == null || capCorreo == null || capPass == null || capMatricula == null || capPass1 == null)
                {
                    Campo_Obligatorio.IsVisible = true;
                return false;
                }
                else
                {
                    if (Regex.IsMatch(capCorreo, expresion))
                    {
                        //verifica que la direccion corresponda y que la longitud    de la cadena no esté vacía
                        if (Regex.Replace(capCorreo, expresion, string.Empty).Length == 0)
                        {
                        //habilitar advertencia de correo mal escrito
                        Campo_Obligatorio.IsVisible = true;
                        return false;
                        }
                        else
                        {
                        return true;
                        }
                    }
                    else
                    {
                    wrongMail.IsVisible = true;
                    return false;
                    }
                }
                
        
        }

        public async void Registrar()
        {


            usuario us = new usuario
            {
                Nombre = txtNombres.Text,
                Apellido_Paterno = txtApP.Text,
                Apellido_Materno = txtApM.Text,
                email = txtCorreo.Text,
                password = txtPass.Text,
                Matricula = int.Parse(txtMatricula.Text),
            };

            await App.SQLiteDB.GuardarUsuario(us);
            txtNombres.Text = null;
            txtApP.Text = null;
            txtApM.Text = null;
            txtCorreo.Text = null;
            txtPass.Text = null;
            txtPass1.Text = null;
            txtMatricula.Text = null;

        }
    }
}