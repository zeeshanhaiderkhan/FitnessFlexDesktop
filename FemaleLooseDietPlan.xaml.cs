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
using System.Windows.Shapes;

namespace FitnessFlex
{
    /// <summary>
    /// Interaction logic for FemaleLooseDietPlan.xaml
    /// </summary>
    public partial class FemaleLooseDietPlan : Window
    {
        public FemaleLooseDietPlan()
        {
            InitializeComponent();
            MealName.ItemsSource = LoadCollectionData();
        }

        public class mealname
        {
            public String Name { get; set; }
            public String Timing { get; set; }
            public String Meal_Details { get; set; }
        }

        private List<mealname> LoadCollectionData()
        {
            List<mealname> meal1 = new List<mealname>();
            meal1.Add(new mealname()
            {
                Name = "BreakFast",
                Timing = "6am - 9am",
                Meal_Details = " 1 Hardboiled egg, 2 slices of wholemeal toast, 1 small glass of orange juice"

            });

            meal1.Add(new mealname()
            {
                Name = "Morning Snack",
                Timing = "9am - 12am",
                Meal_Details = "1 cup low-fat yogurt, 1 cup chopped kiwifruits"

            });

            meal1.Add(new mealname()
            {
                Name = "Lunch",
                Timing = "12am - 3pm",
                Meal_Details = "Chicken sandwich made with 2 slices of wheat bread, 3 slices of roasted chicken, lettuce, tomato slices, and mustard. 1 whole pear, 1 glass of skim milk"

            });

            meal1.Add(new mealname()
            {
                Name = "Evening Snack",
                Timing = "3pm - 6am",
                Meal_Details = "1 apple, 2 teaspoons of peanut butter"

            });

            meal1.Add(new mealname()
            {
                Name = "Dinner",
                Timing = "6pm - 9pm",
                Meal_Details = "1 cup cooked brown rice, 1 cup steamed vegetables topped with 1 teaspoon of butter, 1 cup fruit punch"

            });

            return meal1;



        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            FitnessFlex.Select_Gender sg = new Select_Gender();
            this.Close();
            sg.Show();
        }

        private void save_pdf_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    this.IsEnabled = false;
                    this.save_pdf.Visibility = Visibility.Hidden;
                    this.back.Visibility = Visibility.Hidden;
                    PrintDialog printDialog = new PrintDialog();
                    if ((bool)printDialog.ShowDialog())
                    {
                        printDialog.PrintVisual(MealName, "PrintInvoice_" + DateTime.Now.ToString());
                    }
                }
                finally
                {
                    this.back.Visibility = Visibility.Visible;
                    this.IsEnabled = true;
                    this.save_pdf.Visibility = Visibility.Visible;
                }
            
        }
    }
}
