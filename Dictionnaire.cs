using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Projet_A2_S3
{
    class Dictionnaire
    {
        private List<string> _listeDeMots;
        private int[] _longueur;
        private string _langue;
        public List<string> ListeDeMots
        {
            get { return _listeDeMots; }
        }
        public string Langue
        {
            get { return _langue; }
        }
        public int[] Longueur
        {
            get { return _longueur; }
        }
        public static readonly string[] Lignes = File.ReadAllLines(@"C:\\Temp\Scrabble\Francais.txt");//rentrer l'adresse du fichier "Français"
        //on prend le fichier et on met dans chaque case du tableau, les lignes du fichiers
        //Lignes[0] = 2 et Lignes[1] = mots de 2 lettres
        public Dictionnaire(int[] longueur, string langue)
        {
            this._langue = langue;
            this._listeDeMots = new List<string>();
            string[] mots1 = Lignes[1].Split(' ');
            this._longueur[0] += mots1.Length;
            foreach(string m in mots1)
            {
                if (m.Length == _longueur)
                {
                    _listeDeMots.Add(m);
                }
            }
            //on prend les mots de 2 lettres et on les met dans la liste de mots
            foreach(string ligne in Lignes)//on parcourt l'ensemble de mots de même taille
            {                
                if (ligne.Length >2)//on se débarasse des chiffres avec cette condition
                {
                    string[] mots = ligne.Split(' ');//on prend chaque et on met les mots séparés par un espace dans un tableau de string
                    this._longueur[mots[0].Length-2] += mots.Length;
     //on prend le nombre de mots qui sont contenus dans chaque longueur(ensemble de mots de même taille) et on le met dans le tableau d'entier _longueur
                    foreach(string m in mots)//on parcourt les mots un à un
                    {
                        _listeDeMots.Add(m);//on les ajoute à la liste de mots pour reformer notre dictionnaire
                    }
                }
            }
        }
        public bool RechDichoRecursif(string mot)
        {
            return RechDicoRecursif(mot, 0, _listeDeMots.Length);
        }
        public bool RechDicoRecursif(string mot, int debut, int fin)
        {
            int milieu = (debut+fin)/2;//on crée une nouvelle instance de la variable milieu à chaque utilisation de la méthode
            if(debut>fin || mot == null || mot.Length == 0)return false;//si jamais le mot n'est pas trouvé dans la liste on retourne false
            if(_listeDeMots[milieu] == mot) return true;//si jamais le mot est compris dans la liste on retourne true
            if(mot.CompareTo(_listeDeMots[milieu])<0)//on cherche si le mot est à gauche dans la liste
            {
                return RechDicoRecursif(mot, debut, milieu-1);//on relance la recherche en cherchant uniquement à gauche
            }
            if(mot.CompareTo(_listeDeMots[milieu])>0)//on cherche si le mot est à droite dans la liste
            {
                return RechDicoRecursif(mot, milieu+1, fin);//on relance la recherche en cherchant uniquement à droite
            }
        }
        public override string ToString()
        {
            string aff = "La langue est en "+_langue+".";//on crée une variable aff qui regroupe la langue du dictionnaire et le nombre de mots par longueur
            for(int i = 0;i<_longueur.Length;i++)
            {
                aff += "\nIl y a : "+_longueur[i]+" mots de taille "+i+2+".";//on ajoute à la variable aff le texte correspondant au nombre de mots par longueur, ce texte décrit le nombre de mots de même taille 
            }
            return aff;
        }
    }
}
