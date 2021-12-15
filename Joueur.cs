using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_A2_S3
{
    public class Joueur
    {
        private string nom;
        private int score;
        //private string[] motsTrouvés;
        private List<string> motsTrouvés;
        
        public string Nom
        {
            get { return nom; }
            set { nom = value; } //Nécessaire car on va créer deux personnages donc on doit pouvoir modifier la caractéristique nom
        }

        public Joueur(string nom)
        {
            this.nom = nom;
            this.score = 0; ///le score est initialisé à 0
            this.motsTrouvés = new List<string>(0);///Il n'y a pas de valeur saisie en début d'exercice donc on met 0 en length
        }
        public Joueur()
        {

        }
        public void Add_Mot(string mot)
        {
            motsTrouvés[motsTrouvés.Count + 1] = mot;
            ///pour une liste de taille n, le n+1eme mot de la liste est égal à la variable mot rentré en paramètre 
        }
        public override string ToString()
        {
            //Affiche le nom du joeur son score et la totalité des mots qu'il a trouvé
            string affichage =
                "Nom :" + nom + '\n'
                + "Score associé : " + score + '\n'
                + "Mots trouvés : "+'\n';
            for(int i = 0; i < motsTrouvés.Count; i++)
            {
                affichage = affichage + motsTrouvés[i]+'\n';
            }
            return affichage;
        }
        public void Add_Score(int val)
        {
            //édite le score pour l'augmenter de la valeur
            score = score + val;
        }
        ///La Classe jeton est nécessaire pour créer ces deux méthodes.
        //public void Add_Main_Courante(Jeton monjeton)
        //public void Remove_Main_Courante(Jeton monjeton)
    }
}
