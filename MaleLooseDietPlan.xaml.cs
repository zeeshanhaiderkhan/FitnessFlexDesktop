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
    /// Interaction logic for MaleLooseDietPlan.xaml
    /// </summary>
    public partial class MaleLooseDietPlan : Window
    {
        public MaleLooseDietPlan()
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
                Meal_Details = "2 slices of whole grain toast, 2 tablespoons of butter, 2 hardboiled eggs, 1/2 cup melon, 170 ml orange juice"

            });

            meal1.Add(new mealname()
            {
                Name = "Morning Snack",
                Timing = "9am - 12am",
                Meal_Details = "1 cup low-fat yogurt, 1/2 cup fresh or frozen berries"

            });

            meal1.Add(new mealname()
            {
                Name = "Lunch",
                Timing = "12am - 3pm",
                Meal_Details = " cup cooked brown rice, 85 grams baked or roasted chicken breast, salad made with lettuce, carrots, onions, tomatoes and olives"

            });

            meal1.Add(new mealname()
            {
                Name = "Evening Snack",
                Timing = "3pm - 6am",
                Meal_Details = " 1/2 cup of mixed nuts and dried fruits"

            });

            meal1.Add(new mealname()
            {
                Name = "Dinner",
                Timing = "6pm - 9pm",
                Meal_Details = "140 grams of baked sweet potato topped with 1 teaspoon of butter, 1/2 cup steamed broccoli, 1 orange"

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
