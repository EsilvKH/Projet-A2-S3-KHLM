﻿using System;
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

        public static readonly string[] Lignes = File.ReadAllLines(@"C:\\Temp\Scrabble\InstancePlateau.txt"); //on prend le fichier et à chaque retour à la ligne on enregistre comme case d'un tableau de string
        

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
        public bool Test_Plateau(string mot,int ligne, int colonne, char direction)
        {
            //Il peut être placé sur le plateau en vertical ou horizontal
            if(!placement(mot, ligne, colonne, direction))return false;
            //Il appartient au dictionnaire
            if(!dico(mot))return false;
            //Les lettres de la main utiles au mot appartiennent bien à la main 
            if(!main(mot))return false;
            //Tous les mots qui se croisent sont éligibles
            if(!mots())return false;
        }
        public bool placement(string mot, int ligne, int colonne, char direction)
        {
            bool plac = true;
            if(direction == 'v')
            {
              for(int i = 0; i<mot.Length;i++)
              {
                  if(_plateauMat[ligne,colonne] != null)
                  {
                      //je me suis arrêté là
                  }
              }
            }
        }
        public Jeton[,] TextToPlateau(string[] Lignes, Sac_Jetons sacjeton)//cette méthode permet de passer un texte de plateau en matrice de Jetons
        {
            for(int i = 0; i < Lignes.Length; i++)//on parcourt le tableau de texte
            {
                List<string> charList = Lignes[i].Split(';').ToList();//on crée une liste de string et on sépare les char avec split en fonction des ;
                for (int j = 0; j < charList.Count; j++)//on parcourt 
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
                        affichage += "_ ";
                    }
                }
                Console.WriteLine();
            }
            return affichage;
        }



    }
}
