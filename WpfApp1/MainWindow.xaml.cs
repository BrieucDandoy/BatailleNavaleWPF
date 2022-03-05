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
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string action = "PlaceBoat"; //"PlaceBoat" "AttackBoat"
            InitializeComponent();
            int numRows = 9;
            int numColumns = 9;
            Player Joueur1 = new("Joueur1", (numRows, numColumns));
            Bot bot1 = new((numRows, numColumns));
            List<Boat> ListeBateau = new();
            List<Tuple<int,int>> ListeBoatElement = new();

            AddOrAttack.Content = "Add Boat";
            AddOrAttack.Click += (sender, e) =>
            {
                if (action == "AttackBoat")
                {
                    AddOrAttack.Content = "Attaquer";
                    action = "PlaceBoat";
                }
                else if (action == "PlaceBoat")
                {
                    action = "AttackBoat"; //on fait apparaitre un bouton
                    AddOrAttack.Content = "Add Boat";
                    Button NewBoat = new();
                    NewBoat.Content = "Nouveau Bateau";
                    NewBoat.Click +=(sender, e) => 
                    {
                        if (ListeBateau.Any()) { Joueur1.AddBoat(ListeBateau[0]);
                        ListeBateau.Remove(ListeBateau[0]);
                        }//On ajoute le bateau à la liste
                       
                    };
                    Button Validate = new();
                    Validate.Content = "Valider";


                }
            };
            
            
                


            for (int row = 0; row < numRows; row++)
            {
                grille.ColumnDefinitions.Add(new ColumnDefinition()); //j'ai appelé la grid grille
                grille.RowDefinitions.Add(new RowDefinition()); //je lui rajoute 9 lignes et 9 colonnes
            }
            for (int col = 0; col < numColumns; col++) //je met les boutons
            {
                for (int row = 0; row < numRows; row++)
                {
                    Button button = new Button();
                    button.Margin = new Thickness(0, 0, 0, 0);
                    
                    button.Click += (sender, e) => { //Quand on clique sur le bouton (évènement)
                        if (action == "AttackBoat")
                        {
                            Joueur1.Attack(bot1.BotPlayer, row, col);//envoie un missile sur la case
                        }
                        else if (action == "PlaceBoat")
                        {   
                            Tuple <int,int> tmpTuple = new(row, col);
                            ListeBoatElement.Add(tmpTuple);
                        }
                    button.IsEnabled = false; //désactive le bouton
                    };
                    
                    button.IsEnabledChanged += (sender, e) => { button.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0)); };



                    button.Background = new SolidColorBrush(Color.FromRgb(153,204,255)); //couleur du bouton
                    button.Content = string.Format(" ");
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    grille.Children.Add(button);//ajoute le bouton dans la grille
                }
            }


        }
    }

}
