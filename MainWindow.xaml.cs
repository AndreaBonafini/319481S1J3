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

namespace WpfApp1
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

        private void btnPoints_Click(object sender, RoutedEventArgs e)
        {
            string[] inputs = new string[4];
            string[] outputs = new string[4];
            int[] numFam = new int[5];
            inputs[0] = txtHand.Text.Substring(0, txtHand.Text.IndexOf("D"));
            inputs[1] = txtHand.Text.Substring(txtHand.Text.IndexOf("D"), txtHand.Text.IndexOf("H") - txtHand.Text.IndexOf("D"));
            inputs[2] = txtHand.Text.Substring(txtHand.Text.IndexOf("H"), txtHand.Text.IndexOf("S") - txtHand.Text.IndexOf("H"));
            inputs[3] = txtHand.Text.Substring(txtHand.Text.IndexOf("S"), txtHand.Text.Length - txtHand.Text.IndexOf("S"));
            for (int i = 0; i < 4; i++)
            {
                inputs[i] = inputs[i].Remove(0, 1);

                if (inputs[i].Contains("J"))
                {
                    numFam[i] += 1;
                }
                if (inputs[i].Contains("Q"))
                {
                    numFam[i] += 2;
                }
                if (inputs[i].Contains("K"))
                {
                    numFam[i] += 3;
                }
                if (inputs[i].Contains("A"))
                {
                    numFam[i] += 4;
                }
                if (inputs[i].Length == 0)
                {
                    numFam[i] += 3;
                }
                if (inputs[i].Length == 1)
                {
                    numFam[i] += 2;
                }
                if (inputs[i].Length == 2)
                {
                    numFam[i] += 1;
                }

                for (int ii = 0; ii <= inputs[i].Length; ii++)
                {
                    if (ii != inputs[i].Length)
                    {
                        outputs[i] += inputs[i].Substring(ii, 1) + " ";
                    }
                    else
                    {
                        outputs[i] += inputs[i].Substring(ii, 0);
                    }
                }
            }

            numFam[4] = numFam[0] + numFam[1] + numFam[2] + numFam[3];
            
               lblOutput.Content = "Cards Dealt\t\tPoints\n" +
                "Clubs: " + outputs[0] + "\t\t" + numFam[0].ToString() + "\n" +
                "Diamonds: " + outputs[1] + "\t" + numFam[1].ToString() + "\n" +
                "Hearts: " + outputs[2] + "\t\t\t" + numFam[2].ToString() + "\n" +
                "Spades: " + outputs[3] + "\t\t" + numFam[3].ToString() + "\n" +
                "Total " + "\t\t\t" + numFam[4].ToString();
        }
    }
}
