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
    /// Interaction logic for shldfg.xaml
    /// </summary>
    public partial class shldfg : Window
    {
        public shldfg()
        {
            InitializeComponent();
        }
        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            femalegain fg = new femalegain();
            this.Close();
            fg.Show();
        }

    }
}