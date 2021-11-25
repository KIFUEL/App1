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
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();
           
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            List<usuario> result = App.SQLiteDB.GetUsuarioporNombre(txtdatos.Text).Result;
            
            if (result.Count != 0 )
            {
                Lista_alumnos.ItemsSource = result;
            }

        }

        
    }
}