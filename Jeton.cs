using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_A2_S3
{
    public class Jeton
    {
        private char _lettre; //caractère de la lettre
        private int _score; //score associé à chaque jeton
        private int _occurrence; //nombre de jeton présent dans le jeu

        public char Lettre
        {
            get { return _lettre; }
        }
        public int Score
        {
            get { return _score; }
        }
        public int Occurrence
        {
            get { return _occurrence; }
            set { _occurrence = value; }
        }

        public Jeton(char lettre, int score, int occurrence)
        {
            this._lettre = lettre;
            this._score = score;
            this._occurrence = occurrence;
        }
        public static Jeton StringToJeton(string chaîne)
        {
            //Découpe une chaîne de caractères selon le caractère ; 
            string[] sousChaîne = chaîne.Split(';');
            //Créée une instance de jeton avec les sous chaînes de la découpe.
            Jeton jeton = new Jeton(Convert.ToChar(sousChaîne[0]), Convert.ToInt32(sousChaîne[1]), Convert.ToInt32(sousChaîne[2]));
            //Exemple Jeton A;1;9 :
            //souschaîne[0]=A , souschaîne[1]=1 , souschaîne[2]=9
            //On rentre ensuite dans le constructeur Jeton(souschaîne[0],souschaîne[1],souschaîne[2])
            return jeton;
        }
        public string toString()
        {
            //Retour de l'instance jeton avec ses trois paramètres
            return $"Lettre : {_lettre} - Score : {_score} - Occurrence : {_occurrence}";
        }
        //Tranforme chaîne de caractères en jetons
    }
}
