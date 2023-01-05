﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Banque : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Nom { get; private set; }
        public string UrlSite { get; private set; }
        public string UrlLogo { get; private set; }
        public List<Compte> ListeDesComptes 
        {
            get => listeDesComptes;
            set
            {
                if (listeDesComptes != value)
                {
                    listeDesComptes = value;
                    OnPropertyChanged(nameof(ListeDesComptes));
                }
            } 
        }
        private List<Compte> listeDesComptes = new List<Compte>();

        [JsonConstructor]
        public Banque(string nom, string urlSite, string urlLogo)
        {
            Nom = nom;
            UrlSite = urlSite;
            UrlLogo = urlLogo;
        }

        public Banque(string nom, string urlSite, string urlLogo, List<Compte> lescomptes)
        {
            Nom = nom;
            UrlSite = urlSite;
            UrlLogo = urlLogo;
            ListeDesComptes = lescomptes;
        }

        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public void AjouterCompte(Compte compte)
        {
            ListeDesComptes.Add(compte);
        }

        public void SupprimerCompte(Compte compte)
        {
            ListeDesComptes.Remove(compte);
        }

        public bool ExisteCompte(string s)
        {
            foreach (Compte compte in ListeDesComptes)
            {
                if (compte.Nom.Equals(s))
                    return true;
            }
            return false;
        }
        public Compte ReturnCompte(string s)
        {
            foreach (Compte compte in ListeDesComptes)
            {
                if (compte.Nom.Equals(s))
                    return compte;
            }
            throw new KeyNotFoundException();
        }

        public override string ToString()
        {
            return Nom + " " + UrlSite + " " + UrlLogo;
        }

    }
}