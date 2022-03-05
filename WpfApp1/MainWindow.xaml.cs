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
using System.Diagnostics;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            


        Instruction instruction = new("PlaceBoat", LabelInstruction); //"PlaceBoat" "AttackBoat"
            int numRows = 9;
            int numColumns = 9;
            Player Joueur1 = new("Joueur1", (numRows, numColumns));
            int nombreBateauBot = 3;
            Bot bot1 = new((numRows, numColumns), nombreBateauBot);
            string VerticalHorizontal = "Horizontal";
            int etape = 0;
            
            NewBoat.Click += (sender, e) => //bouton pour ajouter des bateau
            {
                etape = 1;
            };

            

            VertHor.Click += (sender, e) => { 
                if (VerticalHorizontal == "Horizontal") {
                    VerticalHorizontal = "Vertical";
                    instruction.SetNomInstruction("Veuillez positionner vos bateaux : Vous avez choisi le positionnement Vertical");
                }
                else{
                    VerticalHorizontal = "Horizontal";
                    instruction.SetNomInstruction("Veuillez positionner vos bateaux : Vous avez choisi le positionnement Horizontal");
                }
            };// Change le positionnement en cas de clique sur le bouton


            for (int row = 0; row < numRows; row++)
            {
                grille.ColumnDefinitions.Add(new ColumnDefinition()); //j'ai appelé la grid grille
                GrilleBoat.ColumnDefinitions.Add(new ColumnDefinition());
                grille.RowDefinitions.Add(new RowDefinition()); //je lui rajoute 9 lignes et 9 colonnes
                GrilleBoat.RowDefinitions.Add(new RowDefinition());
            }
            List<Button> listeBouton = new();
            for (int col = 0; col < numColumns; col++) //je met les boutons
            {
                for (int row = 0; row < numRows; row++)
                {
                    Button button = new();
                    button.Margin = new Thickness(0, 0, 0, 0);
                    button.Name ="bouton" +  col.ToString() + row.ToString();
                   


                    button.Click += (sender, e) => { //Quand on clique sur le bouton (évènement)
                        var button = (Button)sender;
                        Boolean touche = Joueur1.Attack(bot1.BotPlayer, button.Name[0],button.Name[1]); //envoie un missile sur la case
                        Trace.WriteLine($"{button.Name[button.Name.Length-1]} et {button.Name[button.Name.Length-2]}");
                        
                        if (touche) button.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        else button.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    };





                    button.Background = new SolidColorBrush(Color.FromRgb(153,204,255)); //couleur du bouton
                    button.Content = string.Format(" "+row.ToString() + col.ToString());
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    grille.Children.Add(button);//ajoute le bouton dans la grille

                    Button buttonGrilleBoat = new();
                    buttonGrilleBoat.Margin = new Thickness(0, 0, 0,0);
                    buttonGrilleBoat.Click += (sender, e) => { if (etape == 1) {

                        if (VerticalHorizontal == "Vertical") {
                            Boat tmpbateau = new();
                            tmpbateau.AddBoatElement(row - 1, col);
                            tmpbateau.AddBoatElement(row, col);
                            tmpbateau.AddBoatElement(row + 1, col);
                            Joueur1.AddBoat(tmpbateau);
                        }
                        else if (VerticalHorizontal == "Horizontal")
                            {
                                Boat tmpbateau = new();
                                tmpbateau.AddBoatElement(row, col-1);
                                tmpbateau.AddBoatElement(row, col);
                                tmpbateau.AddBoatElement(row, col+1);
                                Joueur1.AddBoat(tmpbateau);

                            }
                        } };//défini ce qu'on fait en cas de click
                    Grid.SetRow(buttonGrilleBoat, row);
                    Grid.SetColumn(buttonGrilleBoat, col);
                    GrilleBoat.Children.Add(buttonGrilleBoat);
                    
                }
            }
        }       
    }

}
