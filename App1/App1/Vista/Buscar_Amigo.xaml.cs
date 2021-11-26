﻿using App1.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Buscar_Amigo : ContentPage
    {
        public Buscar_Amigo()
        {
            InitializeComponent();
           
        }

        public async void Buscar_Persona()
        {
           
            List<usuario> result = App.SQLiteDB.GetUsuarioporNombre(txtdatos.Text,"Alumno").Result;

            if (result.Count != 0)
            {
                Lista_alumnos.ItemsSource = result;
            }
            else
            {
                await DisplayAlert("Alerta", "No se encontraron Usuarios registrados", "OK");
            }
        }
        private void Button_Clicked (object sender, EventArgs e)
        {
            Buscar_Persona();
        }


    }
}