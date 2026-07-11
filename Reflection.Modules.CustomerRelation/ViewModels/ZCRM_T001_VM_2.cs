using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.ObjectModel;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class ZCRM_T001_VM_2 : WorkspaceViewModel<ZCRM_T001_A>
    {

        #region Declaration

        bool isNewRecord = true;
        WebServiceRepository<ZCRM_T001_A> repository = new WebServiceRepository<ZCRM_T001_A>();
        WebServiceRepository<MultipleContextACC_T001_A> repository_MC = new WebServiceRepository<MultipleContextACC_T001_A>();
        WebServiceRepository<MultipleContextACC_T001_A> repository_MCTemp = new WebServiceRepository<MultipleContextACC_T001_A>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContextACC_T001_A _MC = new MultipleContextACC_T001_A();
        public MultipleContextACC_T001_A MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value; RaisePropertyChanged("MC");
                }
            }
        }

        private MultipleContextACC_T001_A _MCTemp = new MultipleContextACC_T001_A();
        public MultipleContextACC_T001_A MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value; RaisePropertyChanged("MCTemp");
                }
            }
        }

        private ZCRM_T001_A _MasterEntity;
        public ZCRM_T001_A MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                    value.BeginEdit();
                }
            }
        }

        private ZCRM_T001_A _MasterEntityTemp;
        public ZCRM_T001_A MasterEntityTemp
        {
            get { return _MasterEntityTemp; }
            set
            {
                if (_MasterEntityTemp != value)
                {
                    _MasterEntityTemp = value; RaisePropertyChanged("MasterEntityTemp");
                    value.BeginEdit();
                }
            }
        }

        private ObservableCollection<ZCRM_T001_B> _ItemsEntity;
        public ObservableCollection<ZCRM_T001_B> ItemsEntity
        {
            get
            {
                return _ItemsEntity;
            }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                   // _ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }

        private ObservableCollection<ENVELOPE> _dgEnvelope;
        public ObservableCollection<ENVELOPE> dgEnvelope
        {
            get { return _dgEnvelope; }
            set
            {
                if (_dgEnvelope != value)
                {
                    _dgEnvelope = value;


                    RaisePropertyChanged("dgEnvelope");

                }
            }
        }
        #endregion

        #region ICollectionView

      
        #endregion

        #region StringList


        #endregion

        #region RelayCommand
        public RelayCommand CmdForBrowseFile { get; private set; }

        public RelayCommand<object> CmdForReadFile { get; private set; }
        #endregion

        #region Constructor
        public ZCRM_T001_VM_2()
          : base()
        {
            MasterEntity = new ZCRM_T001_A();
            MasterEntityTemp = new ZCRM_T001_A();
            MC = new MultipleContextACC_T001_A();
            MCTemp = new MultipleContextACC_T001_A();

            CmdForBrowseFile = new RelayCommand(Browse);
            //CmdForReadFile = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Load(cmdPara); });


        }


        #endregion

        #region LoadInitialData


        #endregion
        #region UserDefineFunction
        private void Browse()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".XML";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                MasterEntity.Selectfile = filename;
            }

        }

        //private void Load(object partyList)
        //{
        //    //Convert.ToString(SelectedACC_T001_A.supplier_id.ToString() //change party id

        //    if (MasterEntity.Selectfile != "")

        //    {
        //        var list2 = "";
        //        MasterEntity.checkall = false;
        //        dgEnvelope = new ObservableCollection<ENVELOPE>();
        //        IList list = partyList as IList;
        //        string Name = MasterEntity.Selectfile;
        //        ObjectSerializationService obj = new ObjectSerializationService();
        //        if (System.IO.Path.GetExtension(Name).ToString().ToUpper() == ".XML")
        //        {

        //            List<ENVELOPE> ListInv = new List<ENVELOPE>();
        //            ENVELOPE env = new ENVELOPE();
        //            try
        //            {
        //                XDocument xmldoc = XDocument.Load(Name);
        //                //List<ENVELOPE> lstEnv= new List<ENVELOPE> ();
        //                var query = from p in xmldoc.Elements("ENVELOPE").Elements()
        //                            select p;



        //                //env.selectall = true;
        //                foreach (var record in query)
        //                {
        //                    if (record.Name == "MDCUSTOMER")
        //                    {
        //                        env.Customer_name = record.Value;

        //                    }
        //                    else if (record.Name == "MDCUSTOMERCODE")
        //                    {
        //                        env.PartyId = record.Value;
        //                        try
        //                        {
        //                            if (env.PartyId != null)
        //                            {
        //                                string curr_code;
        //                                curr_code = (from o in MCTemp.partyDetails where o.PartyId == env.PartyId select o.curr_code).First();

        //                                env.wa_code = (from o in MCTemp.LocationDetails where o.warehouse_id == curr_code select o.warehouse_id).First();

        //                                env.Warehouse_Name = (from o in MCTemp.LocationDetails where o.warehouse_id == curr_code select o.Warehouse_Name).First();

        //                            }
        //                        }
        //                        catch (Exception E) { }

        //                    }

        //                    else if (record.Name == "MDINVNO")
        //                    {
        //                        env.inv_no = record.Value;
        //                    }
        //                    else if (record.Name == "MDINVDATE")
        //                    {
        //                        env.inv_dt = record.Value;
        //                    }
        //                    else if (record.Name == "MDPONO")
        //                    {
        //                        env.pono = record.Value;

        //                    }
        //                    else if (record.Name == "MDPODATE")
        //                    {
        //                        env.po_dt = record.Value;
        //                    }
        //                    else if (record.Name == "MDPARTNO")
        //                    {
        //                        //if (record.Value.Contains("("))
        //                        //{

        //                        //    record.Value = record.Value.Substring(0, record.Value.LastIndexOf("("));

        //                        //}
        //                        env.MDPARTNO = record.Value.Trim();
        //                    }
        //                    else if (record.Name == "MDITEMSHWETANAME")
        //                    {
        //                        env.MDITEMSHWETANAME = record.Value.Trim();
        //                    }
        //                    else if (record.Name == "MDITEMNAME")
        //                    {
        //                        env.item_name = record.Value;
        //                    }
        //                    else if (record.Name == "MDUNIT")
        //                    {
        //                        env.unit_name = record.Value;
        //                    }
        //                    else if (record.Name == "MDQTY")
        //                    {
        //                        env.qty = (record.Value); ;
        //                    }
        //                    else if (record.Name == "MDRATE")
        //                    {
        //                        env.unit_price = (record.Value); ;
        //                    }

        //                    else if (record.Name == "MDVALUE")
        //                    {
        //                        env.sub_total = (record.Value);
        //                    }
        //                    else if (record.Name == "MDGROSS")
        //                    {
        //                        try
        //                        {
        //                            if (MC_temp.custSoPoWithItemsList.Count() > 0)
        //                            {
        //                                string sono = "";
        //                                sono = (from o in MC_temp.custSoPoWithItemsList where o.description == env.MDITEMSHWETANAME && o.doc_no == env.pono select o.so_no).First();
        //                                if (sono == "") { sono = null; }

        //                                if (sono != null)
        //                                {
        //                                    env.sono = sono;
        //                                }
        //                            }
        //                        }
        //                        catch (Exception E) { }

        //                        try
        //                        {
        //                            if (MC_temp.ScheduleListWithItems.Count() > 0)
        //                            {
        //                                string schno = "";
        //                                schno = (from o in MC_temp.ScheduleListWithItems where o.item_srno == env.MDITEMSHWETANAME select o.sch_no).First();
        //                                if (schno == "") { schno = null; }

        //                                if (schno != null)
        //                                {
        //                                    env.sch_no = schno;
        //                                }
        //                            }
        //                        }
        //                        catch (Exception E) { }

        //                        env.amount_total = Convert.ToString(Math.Abs(Convert.ToDecimal(record.Value)));
        //                        env.boxqty = "0";
        //                        env.docket_no = "";
        //                        env.company_id = AppSessionState.comp_code;
        //                        dgenvelope.Add(env);
        //                        env = new ENVELOPE();

        //                    }

        //                }
        //            }


        //            catch
        //            {
        //                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //                showMessageService.ButtonSetup = DialogButton.Ok;
        //                showMessageService.Caption = "Message";
        //                showMessageService.Text = String.Format("The Syntax of File is incorrect ", this.Title);
        //                showMessageService.ShowMessage();
        //                SelectedACC_T001_A.Selectfile = "";
        //            }
        //        }

        //        try
        //        {
        //            DataGridCollectionss = CollectionViewSource.GetDefaultView(dgenvelope);
        //            DataGridCollectionss.Filter = new Predicate<object>(Filter1);

        //            SelectedACC_T001_A.xdoc_ACC_T001_A = obj.ObjectToXML(dgenvelope);

        //            string request = "";
        //            try
        //            {
        //                request = AppSessionState.comp_code + "@" + AppSessionState.location_Id + "@" + SelectedACC_T001_A.xdoc_ACC_T001_A + "@" + SelectedACC_T001_A.PartyId;
        //            }
        //            catch
        //            {
        //            }
        //            MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextACC_T001_A>(MC, "ACC_T001_A_Data", "AutoSalesInvoice", "CRM", "PLCDetails", 0, request);
        //            List<PLC> Selectedpartylist = list.Cast<PLC>().ToList();
        //            Selectedpartylist = MC.PLC.ToList<PLC>();
        //            if (Selectedpartylist.Count > 0)
        //            {
        //                for (int i = 0; i < Selectedpartylist.Count; i++)
        //                {
        //                    if (Selectedpartylist[i].ItemId == null || Selectedpartylist[i].unit_id == null)
        //                    {

        //                        if (dgenvelope[i].MDPARTNO == Selectedpartylist[i].CstmrItmCod)
        //                        {
        //                            dgenvelope[i].item_name = "";
        //                        }

        //                    }

        //                }
        //            }

        //        }
        //        catch (Exception e)
        //        {
        //        }
        //    }
        //    else
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format("Please Select Customer", this.Title);
        //        showMessageService.ShowMessage();
        //        dgenvelope = new ObservableCollection<ENVELOPE>();

        //    }
        //}
        

        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<ZCRM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<ZCRM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<ZCRM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<ZCRM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<ZCRM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<ZCRM_T001_A> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<ZCRM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnSaveAction(InquiryActionResult<ZCRM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<ZCRM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZCRM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZCRM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZCRM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZCRM_T001_A> result)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
