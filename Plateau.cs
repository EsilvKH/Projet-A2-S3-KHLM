using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace Projet_A2_S3
{
    class Plateau
    {
        private Jeton[,] _plateauMat;
        public Jeton[,] PlateauMat
        {
            get
            {
                return _plateauMat;
            }
            set
            {
                _plateauMat = value;
            }
        }

        public static readonly string[] Lignes = File.ReadAllLines(@"C:\\Temp\Scrabble\InstancePlateau.txt"); //Empêcher de la modifier

        public Plateau(Sac_Jetons sacJeton)
        {
            if (Lignes != null)
            {
                _plateauMat = TextToPlateau(Lignes, sacJeton);
            }
            else
            {
                _plateauMat = new Jeton[15, 15];//Plateau vide
            }
        }
        private Jeton[,] TextToPlateau(string[] Lignes, Sac_Jetons sacjeton)
        {
            for(int i = 0; i < Lignes.Length; i++)
            {
                List<string> charList = Lignes[i].Split(';').ToList();
                for (int j = 0; j < charList.Count; j++)
                {
                    char LettreTxt = Convert.ToChar(charList[j]);
                    Jeton jeton = sacjeton.ListJeton.FirstOrDefault(x => x.Lettre == LettreTxt);
                    PlateauMat[i, j] = jeton;
                }
            }
            return PlateauMat;
        }
        public override string ToString()
        {
            string affichage = null;
            for(int i=0; i < 15; i++)
            {
                for(var j = 0; j < 15; j++)
                {
                    if (PlateauMat[i, j] != null)
                    {
                        affichage += PlateauMat[i, j].ToString() + " ";
                    }
                    else
                    {
                        affichage += "| ";
                    }
                }
            }
            return affichage;
        }



    }
}
