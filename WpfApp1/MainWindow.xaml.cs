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
            Instruction instruction;
            instruction.SetNomInstruction("PlaceBoat"); //"PlaceBoat" "AttackBoat"
            InitializeComponent();
            int numRows = 9;
            int numColumns = 9;
            Player Joueur1 = new("Joueur1", (numRows, numColumns));
            Bot bot1 = new((numRows, numColumns));
            List<Boat> ListeBateau = new();
            List<Tuple<int,int>> ListeBoatElement = new();

            
            NewBoat.Click += (sender, e) =>
            {


                
            };
            
            
                


            for (int row = 0; row < numRows; row++)
            {
                grille.ColumnDefinitions.Add(new ColumnDefinition()); //j'ai appelé la grid grille
                GrilleBoat.ColumnDefinitions.Add(new ColumnDefinition());
                grille.RowDefinitions.Add(new RowDefinition()); //je lui rajoute 9 lignes et 9 colonnes
                GrilleBoat.RowDefinitions.Add(new RowDefinition());
            }
            for (int col = 0; col < numColumns; col++) //je met les boutons
            {
                for (int row = 0; row < numRows; row++)
                {
                   
                    Button button = new Button();
                    button.Margin = new Thickness(0, 0, 0, 0);
                    
                    button.Click += (sender, e) => { //Quand on clique sur le bouton (évènement)
                    Joueur1.Attack(bot1.BotPlayer, row, col);//envoie un missile sur la case
                    button.IsEnabled = false; //désactive le bouton
                    };
                    
                    button.IsEnabledChanged += (sender, e) => { button.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0)); };



                    button.Background = new SolidColorBrush(Color.FromRgb(153,204,255)); //couleur du bouton
                    button.Content = string.Format(" ");
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    grille.Children.Add(button);//ajoute le bouton dans la grille

                    Button buttonGrilleBoat = new();
                    buttonGrilleBoat.Margin = new Thickness(0, 0, 0,0);
                    buttonGrilleBoat.Click += (sender, e) => { };//défini ce qu'on fait en cas de click
                    Grid.SetRow(buttonGrilleBoat, row);
                    Grid.SetColumn(buttonGrilleBoat, col);
                    GrilleBoat.Children.Add(buttonGrilleBoat);

                }


            }


        }
    }

}
