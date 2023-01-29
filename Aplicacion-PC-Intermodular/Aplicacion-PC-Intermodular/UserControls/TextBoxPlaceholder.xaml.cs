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

namespace Aplicacion_PC_Intermodular.UserControls
{
    /// <summary>
    /// Interaction logic for TextBoxPlaceholder.xaml
    /// </summary>
    public partial class TextBoxPlaceholder : UserControl
    {
        public TextBoxPlaceholder()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public String Placeholder { get; set; }

        public static DependencyProperty ProtocolNumberProperty =
       DependencyProperty.Register("Placeholder", typeof(string), typeof(TextBoxPlaceholder));
    }
}
