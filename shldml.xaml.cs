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
using System.Windows.Shapes;

namespace Exercise_plan
{
    /// <summary>
    /// Interaction logic for shldml.xaml
    /// </summary>
    public partial class shldml : Window
    {
        public shldml()
        {
            InitializeComponent();
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            malelose ml = new malelose();
            this.Close();
            ml.Show();
        }
    }

    

}
