using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
//using GalaSoft.MvvmLight.Command;
//using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services.ViewModel;
//using Reflection.Presentation.ViewModel;
//using Reflection.WebServices.Gateway;

namespace Reflection.Presentation.Services
{
    #region Model
   
    #endregion

    /// <summary>
    /// Interaction logic for LoggingControl.xaml
    /// </summary>
    public partial class LoggingControl : UserControl, INotifyPropertyChanged
    {
        
        public LoggingControl()
        {          
            InitializeComponent();
            //this.DataContext = new COM_T002_VM();
        }
     

        #region "DependencyProperty"
        public static readonly DependencyProperty DocumentTypeProperty =
        DependencyProperty.Register("DocumentType", typeof(string), typeof(LoggingControl),
        new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty DocumentNameProperty =
        DependencyProperty.Register("DocumentName", typeof(string), typeof(LoggingControl),
        new PropertyMetadata(string.Empty));


        public static readonly DependencyProperty ParentIDProperty =
          DependencyProperty.Register("ParentID", typeof(int?), typeof(LoggingControl),
          new PropertyMetadata(0));

        public string DocumentType
        {
            get { return GetValue(DocumentTypeProperty) as string; }
            set
            {
                SetValue(DocumentTypeProperty, value);
            }
        }
        public string DocumentName
        {
            get { return GetValue(DocumentNameProperty) as string; }
            set
            {
                SetValue(DocumentNameProperty, value);
            }
        }
        public int? ParentID
        {
            get { return GetValue(ParentIDProperty) as int?; }
            set
            {
                SetValue(ParentIDProperty, value);
               
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
            //ValidateAsync();
        }



        //private string _intChildRowIndex;
        //public string intChildRowIndex
        //{
        //    get
        //    {
        //        return _intChildRowIndex;
        //    }
        //    set
        //    {
        //        if (_intChildRowIndex != value)
        //        {
        //            _intChildRowIndex = value;
        //        }
        //    }
        //}

        private void btnMessage_Click(object sender, RoutedEventArgs e)
        {           
            CLEAR();
            if (ParentID != 0)
            {
                txtsub1.Text = "Re:" + ParentID;         
                this.popupMsg.IsOpen = !this.popupMsg.IsOpen;
            }
        }


        private void btnFollower_Click(object sender, RoutedEventArgs e)
        {
            CLEAR();
            if (ParentID!=0 )
            {
                txtsub2.Text = "<div>Invitation to follow " + DocumentName + " - " + ParentID + "<div>";
                rtb.Text = "<div>You have been invited to follow " + DocumentName + " - " + ParentID + "<div>";

                this.popupFollower.IsOpen = !this.popupFollower.IsOpen;           
            }
            
        }
        private void CLEAR()
        {   
            if (MCUser != null) { MCUser.SelectedItems = null; MCUser.Text = ""; MCUser.Tag = ""; }
            if (MCPartyEmployee != null) { MCPartyEmployee.SelectedItems = null; MCPartyEmployee.Text = ""; MCPartyEmployee.Tag = ""; }
            if (MCFollower != null) { MCFollower.SelectedItems = null; MCFollower.Text = ""; MCFollower.Tag = ""; }
            if (MCPartyFollo != null) { MCPartyFollo.SelectedItems = null; MCPartyFollo.Text = ""; MCPartyFollo.Tag = ""; }
            rtb.Text = "";
            txtsub2.Text = "";
            rtb1.Text = "";
            txtsub1.Text = "";
        }

       
    }
}
