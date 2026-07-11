using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.HRMS;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using System.ComponentModel;
using Reflection.Presentation.Services.Convertors;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Specialized;
using Microsoft.Win32;
using System.IO;
using System.Reflection;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Core.VirtualDesktops;

namespace Reflection.Modules.HRMS.ViewModels
{
    public class HRM_M001_VM : WorkspaceViewModel<ADM_M024>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M024>> repository = new WebServiceRepository<List<ADM_M024>>();
        WebServiceRepository<MultipleContext_HRM_M001> repository_MC = new WebServiceRepository<MultipleContext_HRM_M001>();
        WebServiceRepository<MultipleContext_HRM_M001> repository_MCTemp = new WebServiceRepository<MultipleContext_HRM_M001>();
        ObjectSerializationService obj = new ObjectSerializationService();



        #region Variable Declaration
        private ADM_M024 _MasterEntity;
        public ADM_M024 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                    RaisePropertyChanged("MasterEntity");

                }
            }
        }
        private ADM_M024_P _Employees;
        public ADM_M024_P Employees
        {
            get { return _Employees; }
            set
            {
                if (_Employees != value)
                {
                    _Employees = value;
                    RaisePropertyChanged("Employees");
                  
                }
            }
        }

        private List<ADM_M024_P> _FlipGridData;
        public List<ADM_M024_P> FlipGridData
        {
            get { return _FlipGridData; }
            set
            {
                if (_FlipGridData != value)
                {
                    _FlipGridData = value;
                    RaisePropertyChanged("FlipGridData");
                }
            }
        }

        private MultipleContext_HRM_M001 _MC;
        public MultipleContext_HRM_M001 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_HRM_M001 _MCTemp;
        public MultipleContext_HRM_M001 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private int _selectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _selectedTabControlIndex; }
            set
            {
                if (_selectedTabControlIndex != value)
                {
                    _selectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }
        private string _name;
        public string name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value; RaisePropertyChanged("name");
                }
            }
        }
       
        private int _dgEmployeeMaster;
        public int dgEmployeeMaster
        {
            get
            {
                return _dgEmployeeMaster;
            }
            set
            {
                if (_dgEmployeeMaster != value)
                {
                    _dgEmployeeMaster = value;
                    RaisePropertyChanged("dgEmployeeMaster");
                }
            }
        }
      
        #endregion

        #region ICollectionView          

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        #endregion

        #region RelayComand
        public RelayCommand<object> CmdforSummery { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand OpenCommand { get; private set; }
        public RelayCommand<object> CommandViewDocument { get; private set; }

        #endregion

        #region Constructor

        public HRM_M001_VM() : base()
        {
            MasterEntity = new ADM_M024();
            Employees = new ADM_M024_P();

            MC = new MultipleContext_HRM_M001();
            MCTemp = new MultipleContext_HRM_M001();

            CmdforSummery = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ViewSummery(cmdPara, "FlipGridReference"); });

            CommandViewDocument = new RelayCommand<object>(items => { if (items == null) { return; } ViewEmployee(items); });

            LoadInitialData();

            //Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        //private void NotificationMessageReceived(NotificationMessage msg)
        //{
        //    if (msg.Notification == "Load Employee BackFlip Record")
        //    {
        //        List<ADM_M024> Temp = (List<ADM_M024>)msg.Sender;
        //        var itemToRemove = MasterEntity1.Where(r => r.EmpId == Temp[0].EmpId).FirstOrDefault();
        //        MasterEntity1.Remove(itemToRemove);
        //        MasterEntity1.Insert(0, Temp[0]);
        //        DataGridCollection = CollectionViewSource.GetDefaultView(MasterEntity1);
        //        DataGridCollection.Refresh();
        //    }
        //}

        #endregion




        #region User Defined Methods
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_HRM_M001>(MC, Request, "EmployeeMaster", "HRMS", "LoadInitialData", 0, "");


                FlipGridData = MC.BackFlipEntity;


                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }

        private void ViewSummery(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                ADM_M024_P ParameterEntityObject = null;

                //Request = ParameterObject.ToString();
                 
                    if (((IEnumerable)ParameterObject).Cast<ADM_M024_P>().Count() > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ADM_M024_P>().ToList()[0];
                        
                        if (MC.BackFlipEntity.Count > 0)
                        {
                            Employees = ParameterEntityObject;
                            name = Employees.sal_code + " " + Employees.EmpFName + " " + Employees.EmpMName + " " + Employees.EmpLName;
                        }
                        SelectedTabControlIndex = 0;
                        //isNewRecord = false;
                    }
                

            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }

        private void ViewEmployee(object InputValue)
        {
            try
            {
                ADM_M024_P POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }

                AppSessionState.ViewTitle = "";
                AppSessionState.ViewTitle = "Employee";
                AppSessionState.TransValue = POPUPEntityObject.EmpId;
                AppSessionState.TransValueType = POPUPEntityObject.EmpId;
                AppSessionState.TransParameter = "NO";
                AppSessionState.ViewOtherRecordAllowed = false;

                string userAuth = "Reflection.Modules.HRMS.Views.Employee_View"; // this one is path option
                string path1 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.HRMS.dll");
                Assembly assembly = Assembly.LoadFile(path1);
                Type type = assembly.GetType(userAuth);
                if (type != null)
                {
                    dynamic instance = Activator.CreateInstance(type);
                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DefaultValues()
        {
            MasterEntity.active = true;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;
        }


        #endregion


        #region Abstract Command Actions

        protected override void OnCreateAction(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnSaveAction(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M024> result)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Filters

        #region Filters For DataGrid   

        private string _filterString;
        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                RaisePropertyChanged("FilterString");
                FilterCollection();
            }
        }
        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterString.ToLower())
                             );
                }
                return true;
            }
            return false;
        }

        


        #endregion

        #endregion


    }
}
