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
            
            
            Sac_Jetons sacJeton = new Sac_Jetons();
            Jeton jetonRand = sacJeton.retire_jeton(new Random());
            Dictionnaire dico = new Dictionnaire("Francais", 4);
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
