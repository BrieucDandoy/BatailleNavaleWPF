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
            InitializeComponent();
            int numRows = 9;
            int numColumns = 9;

            for (int row = 0; row < numRows; row++)
            {
                grille.ColumnDefinitions.Add(new ColumnDefinition());
                grille.RowDefinitions.Add(new RowDefinition());
            }
            for (int col = 0; col < numColumns; col++)
            {
                for (int row = 0; row < numRows; row++)
                {
                    Button button = new Button();
                    button.Margin = new Thickness(0, 0, 0, 0);
                    
                    button.Click += (sender, e) => {
                    
                    button.IsEnabled = false;
                    };
                    
                    button.IsEnabledChanged += (sender, e) => { button.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0)); };



                    button.Background = new SolidColorBrush(Color.FromRgb(153,204,255));
                    button.Content = string.Format(" ");
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    grille.Children.Add(button);
                }
            }


        }
    }

}
