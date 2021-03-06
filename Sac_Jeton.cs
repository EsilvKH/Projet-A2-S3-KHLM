using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Projet_A2_S3
{
    class Sac_Jetons
    {
        private List<Jeton> _listJeton;

        public List<Jeton> ListJeton
        {
            //Geteur seteur
            get { return _listJeton; }
            set { _listJeton = value; }
        }

        public static readonly string[] Lignes = File.ReadAllLines(@"C:\\Temp\Scrabble\Jetons.txt");
        //Permet de créer un texte de chaînes de caractères tirées du fichier Jetons.txt
        public Sac_Jetons()
        {
            //Constructeur par défaut
            _listJeton = new List<Jeton>();
            //Créé une liste et rajoute les jetons trouvés dans le fichié dans la liste
            foreach(string ligne in Lignes)
            {
                Jeton jeton = StringToJeton(ligne);
                //Converti le texte lu en classe jeton
                _listJeton.Add(jeton);
                //Ajoute un jeton à la liste
            }
        }
       
        public static Jeton StringToJeton(string chaîne)
        {
            //Méthode pour découper la chaîne de caractère obtenue.
            string[] sousChaîne = chaîne.Split(';');
            //Après une découpe commadée par le caractère ";", on affecte à chaque jeton les valeurs lues :
            // - Premier caractère : lettre
            // - Deuxième caractère : score
            // - Troisième caractère : nombres de jetons du même type présents dans le jeu
            Jeton jeton = new Jeton(Convert.ToChar(sousChaîne[0]), Convert.ToInt32(sousChaîne[1]), Convert.ToInt32(sousChaîne[2]));
            return jeton;
        }
        public  Jeton retire_jeton(Random r)
        {
            int index=0;
            if(_listJeton[index].Occurrence>0)
            {
                //Génère un index aléatoire et retourne le Jeton de la liste à l'index correspondant.
                index = r.Next(_listJeton.Count);
                _listJeton[index].Occurrence--; //retire une occurrence du jeton dans le jeu
                return _listJeton[index];
                
            }
            else
            {
                //retourne un null si le nombre d'occurrence du jeton dans la partie est déjà à 0;
                return null;
            }

        }

    }
}
