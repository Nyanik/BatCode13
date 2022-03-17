using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace BatCode13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("^[0-9]{12}$");
            string stcode = tbCode.Text;
            int KontNum;
            if (regex.IsMatch(tbCode.Text))
            {                
                tbCode.IsEnabled = false;
                int chet = 0;
                int nechet = 0;
                
                string KontNumStr;
                for (int i = 0; i < 12; i += 2)
                {
                    chet += Convert.ToInt32(stcode[i]);
                }
                for (int i = 1; i < 12; i += 2)
                {
                    nechet += Convert.ToInt32(stcode[i]);
                }                
                KontNum = chet + nechet;
                
                KontNum = 10 - Convert.ToInt32(KontNumStr);
                if (KontNum == 10)
                {
                    KontNum = 0;
                }
                StackPanel spKontNum = new StackPanel() 
                {                    
                    Height = 100                   
                };
                TextBlock tbKontNum = new TextBlock()
                {
                    Text = KontNum + "",
                    
                };
                spKontNum.Children.Add(tbKontNum);
                spBarCode.Children.Add(spKontNum);                
            }

            string binaryCode = "101";
           
            for (int i = 0; i < binaryCode.Length; i++)
            {
                if (binaryCode[i] == '1')
                {
                    Rectangle r = new Rectangle() 
                    {
                        Stroke = Brushes.Black,
                        StrokeThickness = 2,
                        SnapsToDevicePixels = true,
                        Height = 100
                    };
                    spBarCode.Children.Add(r);
                }
                else
                {
                    Rectangle r = new Rectangle()  
                    {
                        Stroke = Brushes.White,
                        StrokeThickness = 2,
                        SnapsToDevicePixels = true,
                        Height = 100
                    };
                    spBarCode.Children.Add(r);  
                }
            }
            binaryCode = "";
            
            
        }
    }
}
