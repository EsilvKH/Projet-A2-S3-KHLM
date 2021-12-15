using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_A2_S3
{
    class Jeu
    {
        private Dictionnaire mondico;
        private Plateau monPlateau;
        private Sac_Jeton monsac_jeton;
        
        public static string[]AttributionDictionnaire(string Langue)
        {
            string[] LignesDictionnaire = File.ReadAllLines(@"C:\\Temp\Scrabble\"+Langue+".txt");
            return LignesDictionnaire;
        }
        public static string[]AttributionPlateau(string FichierPlateau)
        {
            string[] LignesPlateau = File.ReadAllLines(@"C:\\Temp\Scrabble\"+FichierPlateau+".txt");
            return LignesPlateau;
        }
        public static string[]AttributionSacJeton(string FichierJeton)
        {
            string[] LignesSacJeton = File.ReadAllLines(@"C:\\Temp\Scrabble\"+FichierJeton+".txt");
            return LignesSacJeton;
        }
        public static readonly string[] Lignes = File.ReadAllLines(@"C:\\Temp\Scrabble\Jetons.txt");
        
    }
}
