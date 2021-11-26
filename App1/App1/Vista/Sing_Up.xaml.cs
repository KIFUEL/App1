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
                Campo_Obligatorio.Text = " ";
                Registrar();
                Navigation.PushAsync(new login());
            }
            else
            {
                Campo_Obligatorio.Text = "Rellena los campos obligatorios";
            }
            
        }
        private Boolean email_bien_escrito(String email)
        {
            if (string.IsNullOrEmpty(txtCorreo.Text) != true)
            {
                String expresion;
                expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (Regex.IsMatch(email, expresion))
                {
                    if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }

        private bool VerificarR()
        {
            bool Respuesta;
            if (string.IsNullOrEmpty(txtNombres.Text))
            {
                Respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtApP.Text))
            {
                Respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtApM.Text))
            {
                Respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtCorreo.Text))
            {

                Respuesta = false;
            }

            else if (string.IsNullOrEmpty(txtPass.Text))
            {
                Respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtPass1.Text))
            {
                Respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtMatricula.Text))
            {
                Respuesta = false;
            }else if (string.IsNullOrEmpty(selector_usuario.SelectedItem as string))
            {
                Respuesta = false;
            }
            else
            {
                Respuesta = true;
            }

             if (email_bien_escrito(txtCorreo.Text) == false )
            {
                wrongMail.Text = "El correo no es valido";
                Respuesta = false;
            }
            else
            {
              
                wrongMail.Text = " ";
            }
            if (txtPass.Text != txtPass1.Text)
            {
                pass_incorrecto.Text = "La contraseña no es valida";
                Respuesta = false;
            }
            else
            {
                
                pass_incorrecto.Text = " ";
            }
            
            if (string.IsNullOrEmpty(selector_usuario.SelectedItem as string))
            {
                Tipo_Usuario_obligatorio.Text = "Eliga una opcion";
            }
            else
            {
                Tipo_Usuario_obligatorio.Text = "";
            }
            return Respuesta;
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
                Tipo_Usuario = selector_usuario.SelectedItem as string,
                Matricula = txtMatricula.Text,
            };

            await App.SQLiteDB.GuardarUsuario(us);
            txtNombres.Text = "";
            txtApP.Text = "";
            txtApM.Text = "";
            txtCorreo.Text = "";
            txtPass.Text = "";
            txtPass1.Text = "";
            txtMatricula.Text = "";
            await DisplayAlert("Registro", "El regristro ha sido exitoso", "OK");

        }
    }
}