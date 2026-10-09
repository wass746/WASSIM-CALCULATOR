using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WASSIM_CALCULATOR
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        double premierNombre = 0;
        string operateur = "";
        bool nouveauNombre = true;

        public MainWindow()
        {
            InitializeComponent();

            TB_Display.Text = "0";
        }


        // =========================
        // CHIFFRES
        // =========================

        private void BTN_0_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("0");
        }

        private void BTN_1_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("1");
        }

        private void BTN_2_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("2");
        }

        private void BTN_3_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("3");
        }

        private void BTN_4_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("4");
        }

        private void BTN_5_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("5");
        }

        private void BTN_6_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("6");
        }

        private void BTN_7_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("7");
        }

        private void BTN_8_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("8");
        }

        private void BTN_9_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("9");
        }


        // =========================
        // AJOUTER UN CHIFFRE
        // =========================

        private void AjouterChiffre(string chiffre)
        {
            // Si on vient de lancer la calculatrice
            // ou qu'on vient d'utiliser un opérateur
            if (nouveauNombre)
            {
                TB_Display.Text = chiffre;
                nouveauNombre = false;
            }
            else
            {
                // Remplace le 0 au début
                if (TB_Display.Text == "0")
                {
                    TB_Display.Text = chiffre;
                }
                else
                {
                    TB_Display.Text += chiffre;
                }
            }
        }


        // =========================
        // POINT
        // =========================

        private void BTN_Point_Click(object sender, RoutedEventArgs e)
        {
            if (nouveauNombre)
            {

                nouveauNombre = false;
            }
            else
            {

                {

                }
            }
        }


        // =========================
        // C
        // =========================

        private void BTN_C_Click(object sender, RoutedEventArgs e)
        {
            TB_Display.Text = "0";
            premierNombre = 0;
            operateur = "";
            nouveauNombre = true;
        }


        // =========================
        // PLUS
        // =========================

        private void BTN_Plus_Click(object sender, RoutedEventArgs e)
        {
            ChoisirOperateur("+");
        }


        // =========================
        // MOINS
        // =========================

        private void BTN_Moins_Click(object sender, RoutedEventArgs e)
        {
            ChoisirOperateur("-");
        }


        // =========================
        // MULTIPLICATION
        // =========================

        private void BTN_Multiplication_Click(object sender, RoutedEventArgs e)
        {
            ChoisirOperateur("*");
        }


        // =========================
        // DIVISION
        // =========================

        private void BTN_Division_Click(object sender, RoutedEventArgs e)
        {
            ChoisirOperateur("/");
        }


        // =========================
        // CHOISIR OPERATEUR
        // =========================

        private void ChoisirOperateur(string nouvelOperateur)
        {
            double.TryParse(TB_Display.Text, out premierNombre);

            operateur = nouvelOperateur;

            nouveauNombre = true;
        }


        // =========================
        // EGAL
        // =========================

        private void BTN_Egal_Click(object sender, RoutedEventArgs e)
        {
            double deuxiemeNombre;

            if (!double.TryParse(TB_Display.Text, out deuxiemeNombre))
            {
                return;
            }

            double resultat = 0;

            if (operateur == "+")
            {
                resultat = premierNombre + deuxiemeNombre;
            }
            else if (operateur == "-")
            {
                resultat = premierNombre - deuxiemeNombre;
            }
            else if (operateur == "*")
            {
                resultat = premierNombre * deuxiemeNombre;
            }
            else if (operateur == "/")
            {
                if (deuxiemeNombre == 0)
                {
                    TB_Display.Text = "Erreur";
                    nouveauNombre = true;
                    return;
                }

                resultat = premierNombre / deuxiemeNombre;
            }

            TB_Display.Text = resultat.ToString();

            nouveauNombre = true;
        }


        // =========================
        // AFFICHER UN RESULTAT (fonctions)
        // =========================

        private void AfficherResultat(double valeur)
        {
            if (double.IsNaN(valeur) || double.IsInfinity(valeur))
            {
                TB_Display.Text = "Erreur";
            }
            else
            {
                // Arrondi pour éviter les résultats du genre sin(180) = 1,2E-16
                TB_Display.Text = Math.Round(valeur, 10).ToString();
            }

            nouveauNombre = true;
        }


        // =========================
        // SIN (en degrés)
        // =========================

        private void BTN_Sin_Click(object sender, RoutedEventArgs e)
        {
            double nombre;

            if (!double.TryParse(TB_Display.Text, out nombre))
            {
                return;
            }

            double radians = nombre * Math.PI / 180.0;

            AfficherResultat(Math.Sin(radians));
        }


        // =========================
        // COS (en degrés)
        // =========================

        private void BTN_Cos_Click(object sender, RoutedEventArgs e)
        {
            double nombre;

            if (!double.TryParse(TB_Display.Text, out nombre))
            {
                return;
            }

            double radians = nombre * Math.PI / 180.0;

            AfficherResultat(Math.Cos(radians));
        }


        // =========================
        // TAN (en degrés)
        // =========================

        private void BTN_Tan_Click(object sender, RoutedEventArgs e)
        {
            double nombre;

            if (!double.TryParse(TB_Display.Text, out nombre))
            {
                return;
            }

            double radians = nombre * Math.PI / 180.0;

            // tan n'existe pas à 90°, 270°... (là où cos vaut 0)
            if (Math.Abs(Math.Cos(radians)) < 1e-10)
            {
                TB_Display.Text = "Erreur";
                nouveauNombre = true;
                return;
            }

            AfficherResultat(Math.Tan(radians));
        }


        // =========================
        // RACINE CARREE
        // =========================

        private void BTN_Racine_Click(object sender, RoutedEventArgs e)
        {
            double nombre;

            if (!double.TryParse(TB_Display.Text, out nombre))
            {
                return;
            }

            // Pas de racine carrée d'un nombre négatif
            if (nombre < 0)
            {
                TB_Display.Text = "Erreur";
                nouveauNombre = true;
                return;
            }

            AfficherResultat(Math.Sqrt(nombre));
        }

    }
}