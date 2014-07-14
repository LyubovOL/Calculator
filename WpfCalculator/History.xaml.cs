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

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Window
    {
        public History(string[] history)
        {
            InitializeComponent();
            if (history == null)
                HistoryBlock.Text = String.Empty;
            else
            {
                foreach (var str in history)
                {
                    if(str != "")
                        HistoryBlock.Text += String.Format("{0}{1}", str, Environment.NewLine);
                }
            }
        }
    }
}
