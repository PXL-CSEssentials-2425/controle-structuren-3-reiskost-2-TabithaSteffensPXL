using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace reiskost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
          InitializeComponent();
        }
    private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            string destination = destinationTextBox.Text;
            double baseFlightPrice = double.Parse(baseFlightTextBox.Text);
            double basePrice = double.Parse(basePriceTextBox.Text);   
            int numberPeople = int.Parse(numberOfPersonsTextBox.Text);
            int numberDays = int.Parse(numberOfDaysTextBox.Text);
            double discountPercentage = double.Parse(reductionPercentageTextBox.Text);
            
            double flightClass = double.Parse(flightClassTextBox.Text);
            switch (flightClass)
            {
                case 1:
                    flightClass = 1.2;
                    break;
                case 2:
                    flightClass = 1.0;
                    break;
                case 3:
                    flightClass = 0.8;
                    break;
                default:
                    break;
            }

            double flightPrice = (baseFlightPrice * flightClass) * numberPeople;
            double priceStay;
            if (numberPeople == 3)
            {
                priceStay = basePrice * numberPeople * 0.5;
            } else if (numberPeople >= 4)
            {
                priceStay = basePrice * numberPeople * 0.3;
            } else
            {
                priceStay = basePrice * numberPeople;
            }
            double totalPrice = flightPrice + priceStay;
            double discountAmount = totalPrice * (discountPercentage / 100);
            double finalPrice = totalPrice - discountAmount;
            resultTextBox.Text = $@"REISKOST VOLGENS BESTELLING NAAR {destination}

                Totale vluchtkost:  {flightPrice:c}
                Totale verblijfkost: {priceStay:c}
                Totale reisprijs; {totalPrice:c}
                Korting: {discountAmount:c}

                Te Betalen: {finalPrice:c}";
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            destinationTextBox.Clear();
            flightClassTextBox.Clear();
            baseFlightTextBox.Clear();
            numberOfDaysTextBox.Clear();
            numberOfPersonsTextBox.Clear();
            reductionPercentageTextBox.Clear();
            basePriceTextBox.Clear();
            resultTextBox.Clear();
            destinationTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}