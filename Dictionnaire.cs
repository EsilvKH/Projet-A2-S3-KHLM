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
        private int _longueur;
        private string _langue;
        public List<string> ListeDeMots
        {
            get { return _listeDeMots; }
        }
        public string Langue
        {
            get { return _langue; }
        }
        public int Longueur
        {
            get { return _longueur; }
        }
        public static readonly string[] Lignes = File.ReadAllLines(@"C:\\Temp\Scrabble\Francais.txt");
        public Dictionnaire(int longueur, string langue)
        {
            this._langue = langue;
            this._longueur = longueur;
            this._listeDeMots = new List<string>();
            foreach(string ligne in Lignes)
            {
                if (ligne.Length >1)
                {
                    string[] mots = ligne.Split(' ');
                    foreach(string m in mots)
                    {
                        if (m.Length == _longueur)
                        {
                            _listeDeMots.Add(m);
                        }
                    }
                }
            }
        }
        public override string ToString()
        {
            return $"";
        }

    }

}
