﻿using System;
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

namespace CSharp_FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly string[] options = { "Hi" , "Bye" , "Shahd" , "rabea", "rabaa" };


        public MainWindow()
        {
            InitializeComponent();
            bindListBox();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void bindListBox()
        {
            MyListBox.ItemsSource = options;
        }
        private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //<TextBox HorizontalAlignment="Left" Height="25" Margin="600,100,0,0" TextWrapping="Wrap" Text="  Year " VerticalAlignment="Top" Width="130" FontSize="18" TextChanged="TextBox_TextChanged_2" Foreground="SeaGreen"/>
            MessageBox.Show(MyListBox.SelectedItem.ToString());


        }
    }
}
