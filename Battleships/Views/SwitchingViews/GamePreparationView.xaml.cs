using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Battleships.Views.SwitchingViews
{
    /// <summary>
    /// Interaction logic for GamePreparation.xaml
    /// </summary>
    public partial class GamePreparationView : UserControl
    {
        public GamePreparationView()
        {
            InitializeComponent();

            for (var rowIndex = 0; rowIndex < 10; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < 10; columnIndex++)
                {
                    var items = new List<Image>();
                    var imageSource = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/media/battleship.png".Trim()));
                    var image = new Image { Source = imageSource };
                    Grid.SetRow(image, rowIndex);
                    Grid.SetColumn(image, columnIndex);
                    items.Add(image);
                    ItemsCollection.ItemsSource = items;

                    /*var items = new List<Border>();
                    var whiteBorder = new Border
                    {
                        BorderBrush = Brushes.White,
                        BorderThickness = new Thickness(1)
                    };
                    Grid.SetRow(whiteBorder, rowIndex);
                    Grid.SetColumn(whiteBorder, columnIndex);
                    Battlefield.Children.Add(whiteBorder);*/
                }
            }
        }


    }
}