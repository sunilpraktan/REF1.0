using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.ADM.CustomControl
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : WindowElement
    {
        public MessageWindow()
        {
            InitializeComponent();
        }
        public MessageWindow(string ts_code)
        {
            InitializeComponent();
        }
    }
}
