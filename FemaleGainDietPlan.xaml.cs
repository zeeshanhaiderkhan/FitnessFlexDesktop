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
    /// Interaction logic for FemaleGainDietPlan.xaml
    /// </summary>
    public partial class FemaleGainDietPlan : Window
    {
        public FemaleGainDietPlan()
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
                Meal_Details = "Banana smoothie made with 1 ripe banana, 1 cup of skim milk and 1 tablespoon of peanut butter. 1 slice of wheat bread, 2 scrambled eggs"

            });

            meal1.Add(new mealname()
            {
                Name = "Morning Snack",
                Timing = "9am - 12am",
                Meal_Details = "10 Whole grain crackers with 2 tablespoons of hummus"

            });

            meal1.Add(new mealname()
            {
                Name = "Lunch",
                Timing = "12am - 3pm",
                Meal_Details = "1 Cup of cooked brown rice, 85 grams of grilled fish, 1 cup boiled spinach and sweet potatoes, handful of fresh or frozen berries"

            });

            meal1.Add(new mealname()
            {
                Name = "Evening Snack",
                Timing = "3pm - 6am",
                Meal_Details = "1 Slice wheat bread, 28 grams of fat-free cheese, 1 cup low-fat skim milk"

            });

            meal1.Add(new mealname()
            {
                Name = "Dinner",
                Timing = "6pm - 9pm",
                Meal_Details = "Pasta salad made with 1 cup whole wheat pasta, ½ cup chicken cubes, 1/4th cup cheese, diced bell pepper and tomatoes. 1 orange"

            });

            return meal1;



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

        private void back_Click(object sender, RoutedEventArgs e)
        {
            FitnessFlex.Select_Gender sg = new Select_Gender();
            this.Close();
            sg.Show();
        }
    }
}
