﻿using App1.modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;


using Xamarin.Forms.Xaml;

namespace App1.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage

    {


        private bool Verificar()
        {
            bool Respuesta;
            if (string.IsNullOrEmpty(txtcorreo.Text))
            {
                Respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                Respuesta = false;
            }
            else
            {
                Respuesta = true;
            }

            if (email_bien_escrito(txtcorreo.Text) == false)
            {
                label_correo.Text = "El correo no es valido";
                Respuesta = false;
            }
            else
            {

                label_correo.Text = " ";
            }

            return Respuesta;
        }

        private Boolean email_bien_escrito(String email)
        {
            if (string.IsNullOrEmpty(txtcorreo.Text) != true)
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
        public login()
        {
            InitializeComponent();
            
        }

  
        
        
        public async void Button_Clicked(object sender, EventArgs e)
        {

            if (Verificar() == true)
            {
                List<usuario> result = App.SQLiteDB.GetUsuariosValido(txtcorreo.Text, txtPassword.Text).Result;

                if (result.Count == 0)
                {
                    await DisplayAlert("Alerta", "Email o Password Incorrectos.", "OK");
                }
                else if (result.Count == 1)
                {
                    await Navigation.PushAsync(new iniciopagina());
                }
                else if (result.Count >= 1)
                {
                    await DisplayAlert("Alerta", "Existe más de una cuenta registada, favor de solicitar la correción de la cuenta.", "OK");
                    //await Navigation.PushAsync(new DuplicateAccountSendEmail());
                }
            }
        }
    }
}