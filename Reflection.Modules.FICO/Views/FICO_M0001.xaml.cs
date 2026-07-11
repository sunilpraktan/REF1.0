using System;
using System.Windows;
using System.Windows.Controls;
using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FICO_M0027.xaml
    /// </summary>
    public partial class FICO_M0001 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public FICO_M0001(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new FICO_M0001_VM(ts_code);
            InitializeComponent();
        }
        //public FICO_M0001(string ts_code, string doc_no)
        //{
        //    InitializeComponent();
        //    this.DataContext = new FICO_M0001_VM(ts_code, doc_no);
        //    Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        //    Tbmaster.SelectionChanged += TabControl_SelectionChanged;
        //}

        

    }
}
