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
        private int[,] poids=new int[15,15];//Crée une matrice qui initialise le poids de chaque case
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
        public bool Test_PlateauBis(string mot, int ligne, int colonne, char direction, Dictionnaire Dico)
        {
            bool appartient = true;
            //Il peut être placé sur le plateau en vertical ou horizontal
            if (!placement(mot, ligne, colonne, direction)) appartient= false;
            //Il appartient au dictionnaire
            if (!dico(mot,Dico)) appartient=false;
            //Les lettres de la main utiles au mot appartiennent bien à la main 
            //if (!main(mot)) return false;
            //Tous les mots qui se croisent sont éligibles
            //if (!mots()) return false;
            return appartient;
        }
        public bool placement(string mot, int ligne, int colonne, char direction)
        {
            bool plac = true;
            if (direction == 'v')
            {
                for (int i = 0; i < mot.Length; i++)
                {
                    if (colonne + i > _plateauMat.GetLength(2))
                    {
                        plac = false;
                    }
                    if (_plateauMat[ligne, colonne+i] == null)
                    {
                        plac = false;

                    }
                }
            }
            if (direction == 'h')
            {
                for(int j = 0; j < mot.Length; j++)
                {
                    if (ligne + j > _plateauMat.GetLength(1))
                    {
                        plac = false;
                    }
                    if (_plateauMat[ligne+j, colonne] == null)
                    {
                        plac = false;
                    }
                }
            }
            return plac;
        } //Bon
        
        public bool dico(string mot, Dictionnaire Dico)
        {
            bool présence = false;
            for(int m=0; m< Dico.ListeDeMots.Count; m++)
            {
                if (Dico.ListeDeMots[m] == mot)
                {
                    présence = true;
                }
            }
            return présence;
            //Modifié le 15/12 à 19h50 Kerian
        }
        
        public Jeton[,] TextToPlateau(string[] Lignes, Sac_Jetons sacjeton)//cette méthode permet de passer un texte de plateau en matrice de Jetons
        {
            if(sacjeton != null && Lignes !=null)
            {
                for(int i = 0; i < Lignes.Length; i++)//on parcourt les lignes du tableau de texte
            {
                List<string> charList = Lignes[i].Split(';').ToList();//on crée une liste de string et on sépare les char avec split en fonction des ; puis on ajoute chaque mot au tableau
                for (int j = 0; j < charList.Count; j++)//on parcourt les mots (découpés selon string.Split(";") de la liste de texte et les colonnes de la matrices jetons
                {
                    char LettreTxt = Convert.ToChar(charList[j]);
                    Jeton jeton = sacjeton.ListJeton.FirstOrDefault(x => x.Lettre == LettreTxt);//on reconnaît le jeton selon le caractère lu dans le tableau
                    jeton.Occurrence--; //retire une occurrence du Jeton dans la partie
                    PlateauMat[i, j] = jeton;//on affecte la valeur du jeton trouvé dans la case i;j de la matrice
                }
            }
            }
            else Jeton[,] PlateauMat[,] = new Jeton[15,15]; 
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
        public void PlateauSurConsole()
        {
            for(int i=0;i<15;i++)
            {
                for(int j=0;j<15;j++)
                {
                   switch poids[i,j]
                   {
                           case ...
                               //Ecrire les différents cas du poids.
                               Console.Background=ConsoleColor.Red;
                           break;
                           //Ecrire matrice d'int, 
                           Console.resetColor
                   }
                }
            }
            
            
        }



    }
}
