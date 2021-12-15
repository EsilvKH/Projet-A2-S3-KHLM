using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;




namespace Projet_A2_S3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rentrez le nom du Joueur 1");
            string nomJoueur1 = Convert.ToString(Console.ReadLine());
            Joueur Joueur1 = new Joueur(nomJoueur1);
            
            Console.WriteLine("Rentrez le nom du Joueur 2");
            string nomJoueur2 = Convert.ToString(Console.ReadLine());
            Joueur Joueur2 = new Joueur(nomJoueur2);
            //On créé deux instances de la classe joueur.
            
            static void AjouterMainCouranteJ1(Jeton[] MainCouranteJoueur1,Sac_Jetons Sac)
            {
                int compteurDajout = 0;
                int[] tableauIndicesVides = new int[7] {1,1,1,1,1,1,1 }; //On créé un table de longueur 7 où 1 représente la présence d'un jeton et 0 l'absence
                for(int i=0; i < MainCouranteJoueur1.Length; i++)
                {
                    if (MainCouranteJoueur1[i] == null)
                    {
                        compteurDajout++;
                        tableauIndicesVides[i] = 0;//Si la case est null, on affecte 0 à la case du tableau
                    }
                }
                while (compteurDajout > 0)
                {
                    for(int j=0; j < 7; j++)
                    {
                        if (tableauIndicesVides[j] == 0)
                        {
                            Random r = new Random();//On tire un jeton au hasard de la classe Sac_Jetons
                            int entier = r.Next(26);
                            MainCouranteJoueur1[j]= Sac.retire_jeton(r);
                        }
                    }
                }
                
            }
            static void AjouterMainCouranteJ2(Jeton[] MainCouranteJoueur2, Sac_Jetons Sac)
            {
                int compteurDajout = 0;
                int[] tableauIndicesVides = new int[7] { 1, 1, 1, 1, 1, 1, 1 }; //On créé un table de longueur 7 où 1 représente la présence d'un jeton et 0 l'absence
                for (int i = 0; i < MainCouranteJoueur2.Length; i++)
                {
                    if (MainCouranteJoueur2[i] == null)
                    {
                        compteurDajout++;
                        tableauIndicesVides[i] = 0;//Si la case est null, on affecte 0 à la case du tableau
                    }
                }
                while (compteurDajout > 0)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (tableauIndicesVides[j] == 0)
                        {
                            Random r = new Random();//On tire un jeton au hasard de la classe Sac_Jetons
                            int entier = r.Next(26);
                            MainCouranteJoueur2[j] = Sac.retire_jeton(r);
                        }
                    }
                }

            }
            
            Sac_Jetons sacJeton = new Sac_Jetons();
            Jeton jetonRand = sacJeton.retire_jeton(new Random());
            Dictionnaire dico = new Dictionnaire(4,"Francais");
            Plateau plateau = new Plateau(sacJeton);
            Console.ReadLine();


            /*List<Jeton> sacJeton = new List<Jeton>();
            string[] lignes = File.ReadAllLines(@"C:\\Temp\Scrabble\Jeton.Txt");
            foreach(string ligne in lignes)
            {
                Jeton jeton = Jeton.StringToJeton(ligne);


            }
            //sacJetons.Add(jeton);
            //je sais pas à quoi ça sert lol
            */
        }
    }
}
