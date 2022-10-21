﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Banque;

namespace Model
{
    public class Inscrit
    {

        public Inscrit(string id, string nom, string prenom, string mail, string mdp)
        {
            Id = id;
            Nom = nom;
            Mail = mail;
            Prenom = prenom;
            Mdp = mdp;
     
        }
        


        public Inscrit(string id, string nom, string mail, string prenom, string mdp, double soldeTotal)
        {
            Id = id;
            Nom = nom;
            Mail = mail;
            Prenom = prenom;
            Mdp = mdp;
            SoldeTotal = soldeTotal;
        }
        public Inscrit(string id, string nom, string mail, string prenom, string mdp, double soldeTotal,List<Banque>lesbanques)
        {
            Id = id;
            Nom = nom;
            Mail = mail;
            Prenom = prenom;
            Mdp = mdp;
            SoldeTotal = soldeTotal;
            LesBanques = lesbanques;
        }
        public string Id { get; private set; }
        public string Nom { get; private set; }
        public string Mail { get; private set; }
        public string Prenom { get; private set; }
        public string Mdp { get; private set; }
        public double SoldeTotal { get; private set; }
        public Devises Dev { get; private set; }
        private List<Banque> LesBanques { get; set; } = new List<Banque>();

     

        public void ajouterBanque(Banque banque)
        {
            LesBanques.Add(banque);
        }

        public void SupprimerBanque(Banque banque)
        {
            LesBanques.Remove(banque);
        }

        public void ChoisirDevise(Devises devise)
        {
            Dev = devise;
        }

    }
}
