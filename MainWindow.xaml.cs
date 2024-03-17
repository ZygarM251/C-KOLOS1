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

namespace Laboratorium1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello");
        }

        private void Oblicz_Click(object sender, RoutedEventArgs e)
        {
            double r, h, wynik;
            try
            {
                r = Convert.ToDouble(txtPromien.Text);
                h = Convert.ToDouble(txtWysokosc.Text);
                if (r >= 0 && h >= 0)
                {

                    if (chkObjętość.IsChecked == true && chkPole.IsChecked == false)
                    {
                        switch (cbxRodzajBryły1.SelectedIndex)
                        {
                            case 0:
                                wynik = Math.PI * Math.Pow(r, 2) * h;
                                break;
                            case 1:
                                wynik = 1.0 / 3.0 * Math.PI * Math.Pow(r, 2) * h;
                                break;
                            case 2:
                                wynik = 4.0 / 3.0 * Math.PI * Math.Pow(r, 2) * h;
                                break;
                            default:
                                wynik = 0;
                                break;
                        }
                        // lblWynik.Content = wynik.ToString("F2");
                        lblWynik.Content = $"Objętość {cbxRodzajBryły1.SelectionBoxItem} wynosi {wynik:F2} m^3 ";
                    }
                    else if (chkPole.IsChecked == true && chkObjętość.IsChecked == false)
                    {
                        switch (cbxRodzajBryły1.SelectedIndex)
                        {
                            case 0:
                                wynik = 2 * Math.PI * r * h;
                                break;
                            case 1:
                                wynik = 1.0 / 5.0 * Math.PI * Math.Pow(r, 2) * h;
                                break;
                            case 2:
                                wynik = 4.0 * Math.PI * Math.Pow(r, 2);
                                break;
                            default:
                                wynik = 0;
                                break;
                        }
                        // lblWynik.Content = wynik.ToString("F2");
                        lblWynik.Content = $"Pole {cbxRodzajBryły1.SelectionBoxItem} wynosi {wynik:F2} m^3 ";
                    }
                    else
                    {
                        MessageBox.Show("Wybierz jedno pole do liczenia");
                    }

                }
                else 
                {
                    MessageBox.Show("Wprowadzone wartości są niepoprawne");
                }
                
            }
            catch { MessageBox.Show("Zły Foramt"); }
        }

        private void cbxRodzajBryły1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxRodzajBryły1.SelectedIndex==2)
            {
                txtWysokosc.Visibility = Visibility.Hidden;
            }
            else
            {
                txtWysokosc.Visibility = Visibility.Visible;
            }
        }

        private void btnZamknij_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno?", "Pytanie", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
            
        }
    }
}
