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

namespace Reflection.Presentation.Services//.HtmlEditor.Controls
{
    /// <summary>
    /// Interaction logic for RichTextDisplayEditor.xaml
    /// </summary>
    public partial class RichTextDisplayEditor : UserControl
    {
        public static readonly DependencyProperty TextProperty =
          DependencyProperty.Register("Text", typeof(string), typeof(RichTextDisplayEditor),
          new PropertyMetadata(string.Empty));

        public RichTextDisplayEditor()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return GetValue(TextProperty) as string; }
            set
            {
                SetValue(TextProperty, value);
            }
        }
    }
}
