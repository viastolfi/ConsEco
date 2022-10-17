﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IHM
{
    /// <summary>
    /// Logique d'interaction pour UCEcheancier.xaml
    /// </summary>
    public partial class UCEcheancier : UserControl
    {
        public Navigator Nav => (App.Current as App).Navigator;

        public UCEcheancier()
        {
            InitializeComponent();
        }

        private void Button_Click_Ajouter_Echeance(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo(Navigator.PART_AJOUTER_ECHEANCE);
        }

        private void Button_Click_Supprimer_Echeance(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo(Navigator.PART_SUPPRIMER_ECHEANCE);
        }
    }
}
