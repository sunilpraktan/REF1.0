using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;


namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class ECRM_T005_VM : WorkspaceViewModel<ECRM_T005>
    {
        bool blNew = true;
        WebServiceRepository<ECRM_T005> repository = new WebServiceRepository<ECRM_T005>();
        WebServiceRepository<MultipleContext_ECRM_T005> repositoryM = new WebServiceRepository<MultipleContext_ECRM_T005>();
        MultipleContext_ECRM_T005 MCTemp = new MultipleContext_ECRM_T005();

        private ICollectionView _dataGridCollection;
        private int _dgSelectedIndex;
        private string _filterString;
        private string _filterStringInvoice;
        private string _filterStringAgent;
        private string _filterStringBank;
        private string _filterStringBank1;
        private string _filterStringAirline;

        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private ICollectionView _CollectionInvoice;
        public ICollectionView CollectionInvoice
        {
            get { return _CollectionInvoice; }
            set { _CollectionInvoice = value; RaisePropertyChanged("CollectionInvoice"); }
        }

        private ICollectionView _CollectionAgent;
        public ICollectionView CollectionAgent
        {
            get { return _CollectionAgent; }
            set { _CollectionAgent = value; RaisePropertyChanged("CollectionAgent"); }
        }

        private ICollectionView _CollectionBank;
        public ICollectionView CollectionBank
        {
            get { return _CollectionBank; }
            set { _CollectionBank = value; RaisePropertyChanged("CollectionBank"); }
        }

        private ICollectionView _CollectionBank1;
        public ICollectionView CollectionBank1
        {
            get { return _CollectionBank1; }
            set { _CollectionBank1 = value; RaisePropertyChanged("CollectionBank1"); }
        }

        private ICollectionView _CollectionAirline;
        public ICollectionView CollectionAirline
        {
            get { return _CollectionAirline; }
            set { _CollectionAirline = value; RaisePropertyChanged("CollectionAirline"); }
        }
      
        #endregion

        #region RelayCommand
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandGoodsDetails
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandInvoice
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedCommandAgent
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedCommandBank
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandBank1
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedCommandAirline
        {
            get;
            private set;
        }

        public RelayCommand TextChangedCommand
        {
            get;
            private set;
        }
        #endregion

        #region ECRM_T005
        private List<ECRM_T005> _SelectedList;
        public List<ECRM_T005> SelectedList
        {
            get { return _SelectedList; }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;
                    RaisePropertyChanged("SelectedList");
                }
            }
        }

        private ECRM_T005 _SelectedECRM_T005;
        public ECRM_T005 SelectedECRM_T005
        {
            get
            {
                this.ErrorExist = _SelectedECRM_T005.HasErrors;
                return _SelectedECRM_T005;
            }
            set
            {
                if (_SelectedECRM_T005 != value)
                {
                    _SelectedECRM_T005 = value;
                    this.ErrorExist = _SelectedECRM_T005.HasErrors;
                    RaisePropertyChanged("SelectedECRM_T005");
                    value.BeginEdit();
                }
            }
        }


        #endregion

        #region ECRM_T005
        private static ObservableCollection<ECRM_T005> _GoodsDetails = new ObservableCollection<ECRM_T005>();
        public ObservableCollection<ECRM_T005> GoodsDetails
        {
            get { return _GoodsDetails; }
            set
            {
                if (_GoodsDetails != value)
                {
                    _GoodsDetails = value;

                    RaisePropertyChanged("GoodsDetails");
                }
            }
        }
        #endregion     

        #region SEL_T003_A_Popup poup Invoice
        private List<SEL_T003_A_Popup> _SelectedInvoiceList;
        public List<SEL_T003_A_Popup> SelectedInvoiceList
        {
            get { return _SelectedInvoiceList; }
            set
            {
                if (_SelectedInvoiceList != value)
                {
                    _SelectedInvoiceList = value;
                    RaisePropertyChanged("SelectedInvoiceList");
                }
            }
        }
        #endregion

        #region ADM_M027_PopUp Agent
        private List<ADM_M027_PopUp> _SelectedAgentList;
        public List<ADM_M027_PopUp> SelectedAgentList
        {
            get { return _SelectedAgentList; }
            set
            {
                if (_SelectedAgentList != value)
                {
                    _SelectedAgentList = value;
                    RaisePropertyChanged("SelectedAgentList");
                }
            }
        }
        #endregion

        #region ACC_M004_Popup poup Bank
        private List<ACC_M004_Popup> _SelectedBankList;
        public List<ACC_M004_Popup> SelectedBankList
        {
            get { return _SelectedBankList; }
            set
            {
                if (_SelectedBankList != value)
                {
                    _SelectedBankList = value;
                    RaisePropertyChanged("SelectedBankList");
                }
            }
        }
        #endregion

        #region ACC_M004_Popup poup Bank1
        private List<ACC_M004_Popup> _SelectedBankList1;
        public List<ACC_M004_Popup> SelectedBankList1
        {
            get { return _SelectedBankList1; }
            set
            {
                if (_SelectedBankList1 != value)
                {
                    _SelectedBankList1 = value;
                    RaisePropertyChanged("SelectedBankList1");
                }
            }
        }
        #endregion

        #region ACC_M004_Popup poup Airline
        private List<ZADM_M019_Popup> _SelectedAirlineList;
        public List<ZADM_M019_Popup> SelectedAirlineList
        {
            get { return _SelectedAirlineList; }
            set
            {
                if (_SelectedAirlineList != value)
                {
                    _SelectedAirlineList = value;
                    RaisePropertyChanged("SelectedAirlineList");
                }
            }
        }
        #endregion

        public int dgSelectedIndex
        {
            get
            {
                return _dgSelectedIndex;
            }
            set
            {
                if (_dgSelectedIndex != value)
                {
                    _dgSelectedIndex = value;
                    RaisePropertyChanged("dgSelectedIndex");
                }
            }
        }

        MultipleContext_ECRM_T005 _MC = new MultipleContext_ECRM_T005();
        public MultipleContext_ECRM_T005 MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value;

                    RaisePropertyChanged("MC");
                }
            }
        }

         #region 
        public ECRM_T005_VM()
            : base()
        {
            SelectedList = new List<ECRM_T005>();
            SelectedECRM_T005 = new ECRM_T005();
            SelectedInvoiceList = new List<SEL_T003_A_Popup>();
            SelectedAgentList = new List<ADM_M027_PopUp>();
            SelectedBankList = new List<ACC_M004_Popup>();
            SelectedBankList1 = new List<ACC_M004_Popup>();
            SelectedAirlineList = new List<ZADM_M019_Popup>();
            
            GoodsDetails = new ObservableCollection<ECRM_T005>();

            MC = new MultipleContext_ECRM_T005();
           
            SelectedECRM_T005.ValidateAsync().Wait();           

            SelectionChangedCommand = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedList(items);
            });

            SelectionChangedCommandGoodsDetails = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
               // GetSelectedGoodDetails(items);
                GetSelectedList(items);
               
            });

            SelectionChangedCommandInvoice = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedInvoice(items);
              });

            SelectionChangedCommandAgent= new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }

                GetSelectedAgent(items);
            });

            SelectionChangedCommandBank = new RelayCommand<IList>(
          items =>
          {
              if (items == null)
              {
                  return;
              }

              GetSelectedBank(items);
          });

            SelectionChangedCommandBank1 = new RelayCommand<IList>(
         items =>
         {
             if (items == null)
             {
                 return;
             }

             GetSelectedBank1(items);
         });

            SelectionChangedCommandAirline = new RelayCommand<IList>(
         items =>
         {
             if (items == null)
             {
                 return;
             }

             GetSelectedAirline(items);
         });
            TextChangedCommand = new RelayCommand(GetSelectedValues);         
           
            
        SelectedECRM_T005.InvDate = DateTime.Now.Date;
        SelectedECRM_T005.air_way_billdt = DateTime.Now.Date;
        SelectedECRM_T005.ref_date = DateTime.Now.Date;
        SelectedECRM_T005.dcinv_frwd_cust_dt = DateTime.Now.Date;
        SelectedECRM_T005.dcpck_frwd_cust_dt = DateTime.Now.Date;
        SelectedECRM_T005.dcair_frwd_cust_dt = DateTime.Now.Date;
        SelectedECRM_T005.dcinsur_frwd_cust_dt = DateTime.Now.Date;
        SelectedECRM_T005.dccertif_cust_dt = DateTime.Now.Date;
        SelectedECRM_T005.dbinv_frwd_bnk_dt = DateTime.Now.Date;
        SelectedECRM_T005.dbpck_frwd_bnk_dt = DateTime.Now.Date;
        SelectedECRM_T005.dbair_frwd_bnk_dt = DateTime.Now.Date;
        SelectedECRM_T005.dbinsur_frwd_bnk_dt = DateTime.Now.Date;
        SelectedECRM_T005.dbcertif_bnk_dt = DateTime.Now.Date;
        SelectedECRM_T005.brc_dt = DateTime.Now.Date;
        SelectedECRM_T005.brc_appl_dt = DateTime.Now.Date;
        SelectedECRM_T005.brc_recv_dt = DateTime.Now.Date;
        SelectedECRM_T005.shipp_bill_dt = DateTime.Now.Date;
        SelectedECRM_T005.mate_recp_dt = DateTime.Now.Date;
        SelectedECRM_T005.realization_dt = DateTime.Now.Date;
        SelectedECRM_T005.nform_dt = DateTime.Now.Date;
        SelectedECRM_T005.user_source1 = AppSessionState.UserSource1;
        SelectedECRM_T005.user_source2 = AppSessionState.UserSource2;
        SelectedECRM_T005.userid = AppSessionState.UserID;
        SelectedECRM_T005.client = AppSessionState.client;
        LoadInitialData();
          
        }

        #endregion
        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ECRM_T005> tSelectedItemsList = list.Cast<ECRM_T005>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedECRM_T005 = (ECRM_T005)tSelectedItemsList[0];
                blNew = false;
            }
        }
        private void GetSelectedGoodDetails(IList IssueList)
        {
            try
            {
                IList list = IssueList as IList;

                List<ECRM_T005> SelectedItemsList2 = list.Cast<ECRM_T005>().ToList();
                if (SelectedItemsList2.Count > 0)
                {
                    SelectedECRM_T005 = (ECRM_T005)SelectedItemsList2[0];
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T005>(MCTemp, "ECRM_T005_Data", "PostExportTransaction", "CRM", "LoadAll", 0, "");
                    MC.GoodsDetails = MCTemp.GoodsDetails;
                    GoodsDetails = new ObservableCollection<ECRM_T005>();
                    blNew = false;
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
        private void GetSelectedInvoice(IList InvoiceList)
        {
            IList list = InvoiceList as IList;
            List<SEL_T003_A_Popup> GetSelectedInvoiceTemp = list.Cast<SEL_T003_A_Popup>().ToList();

            if (GetSelectedInvoiceTemp.Count > 0)
            {
                SelectedECRM_T005.inv_no = GetSelectedInvoiceTemp[0].bill_doc;
                SelectedECRM_T005.InvDate = GetSelectedInvoiceTemp[0].doc_date;
                SelectedECRM_T005.adv_licenc_no = GetSelectedInvoiceTemp[0].adv_lic_nm;
                SelectedECRM_T005.epcg_licenc_no = GetSelectedInvoiceTemp[0].epcg_nm;
                //SelectedECRM_T005.rs_inv = GetSelectedInvoiceTemp[0].invoice_amt;       
                SelectedECRM_T005.exrate = Math.Round(GetSelectedInvoiceTemp[0].exc_rate, 2);
                SelectedECRM_T005.curr = GetSelectedInvoiceTemp[0].doc_curr;
                SelectedECRM_T005.acode =GetSelectedInvoiceTemp[0].cf_agent.ToString();
                SelectedECRM_T005.acode_name = GetSelectedInvoiceTemp[0].cf_agent_nm;
                SelectedECRM_T005.dispch_mode = GetSelectedInvoiceTemp[0].trans_mode;
                SelectedECRM_T005.final_destn_contry = GetSelectedInvoiceTemp[0].dest_con_nm;
                SelectedECRM_T005.final_destn_port = GetSelectedInvoiceTemp[0].port_final;
                SelectedECRM_T005.gross_wt = GetSelectedInvoiceTemp[0].wt_gross;
                SelectedECRM_T005.net_wt = GetSelectedInvoiceTemp[0].wt_net;
                SelectedECRM_T005.air_way_billno = GetSelectedInvoiceTemp[0].lr_no;
                SelectedECRM_T005.air_way_billdt = GetSelectedInvoiceTemp[0].lr_date;
                SelectedECRM_T005.exchange_rate =Math.Round( GetSelectedInvoiceTemp[0].exc_rate,2);
                SelectedECRM_T005.fc_inv = GetSelectedInvoiceTemp[0].invoice_amt;
                GetSelectedValues();
            }

        }
        private void GetSelectedAgent(IList AgentList)
        {
            IList list = AgentList as IList;
            List<ADM_M027_PopUp> GetSelectedAgentTemp = list.Cast<ADM_M027_PopUp>().ToList();

            if (GetSelectedAgentTemp.Count > 0)
            {
                SelectedECRM_T005.acode = GetSelectedAgentTemp[0].ContInfoId.ToString();
                SelectedECRM_T005.acode_name = GetSelectedAgentTemp[0].PersnFName;
            }

        }
        private void GetSelectedBank(IList BankList)
        {
            IList list = BankList as IList;
            List<ACC_M004_Popup> GetSelectedBankTemp = list.Cast<ACC_M004_Popup>().ToList();

            if (GetSelectedBankTemp.Count > 0)
            {                
                SelectedECRM_T005.brc_appl_bank = GetSelectedBankTemp[0].bank_name;
            }

        }
        private void GetSelectedBank1(IList BankList1)
        {
            IList list = BankList1 as IList;
            List<ACC_M004_Popup> GetSelectedBankTemp = list.Cast<ACC_M004_Popup>().ToList();

            if (GetSelectedBankTemp.Count > 0)
            {
                SelectedECRM_T005.brc_recv_bank = GetSelectedBankTemp[0].bank_name;
            }

        }
        private void GetSelectedAirline(IList AirlineList)
        {
            IList list = AirlineList as IList;
            List<ZADM_M019_Popup> GetSelectedAirlineTemp = list.Cast<ZADM_M019_Popup>().ToList();

            if (GetSelectedAirlineTemp.Count > 0)
            {
                SelectedECRM_T005.air_line = GetSelectedAirlineTemp[0].airline;
            }

        }
        private void GetSelectedValues()
        {

            SelectedECRM_T005.rs_inv =Math.Round(SelectedECRM_T005.fc_inv * SelectedECRM_T005.exchange_rate,2);
            SelectedECRM_T005.rs_fob = Math.Round(SelectedECRM_T005.fc_inv * SelectedECRM_T005.exchange_rate, 2);
            SelectedECRM_T005.fc_fob = SelectedECRM_T005.fc_inv;

            //shippng bill details
            SelectedECRM_T005.rs_fob = SelectedECRM_T005.rs_fob - SelectedECRM_T005.rs_freight - SelectedECRM_T005.rs_insur - SelectedECRM_T005.rs_comm ;
            SelectedECRM_T005.fc_fob = Math.Round(SelectedECRM_T005.rs_fob / SelectedECRM_T005.exchange_rate, 2);

            //Bank Realization certificate
            SelectedECRM_T005.rs_fob = SelectedECRM_T005.rs_fob - SelectedECRM_T005.bnk_chrg_comm - SelectedECRM_T005.other_chrg - SelectedECRM_T005.short_pay;
            SelectedECRM_T005.fc_fob = Math.Round(SelectedECRM_T005.rs_fob / SelectedECRM_T005.exchange_rate, 2);

            SelectedECRM_T005.inv_rs=SelectedECRM_T005.rs_fob ;
            SelectedECRM_T005.inv_fc = SelectedECRM_T005.fc_fob;

            //Convert into FC 
            SelectedECRM_T005.fc_freight = Math.Round(SelectedECRM_T005.rs_freight / SelectedECRM_T005.exchange_rate, 2);
            SelectedECRM_T005.fc_insur = Math.Round(SelectedECRM_T005.rs_insur / SelectedECRM_T005.exchange_rate, 2);
            SelectedECRM_T005.fc_comm = Math.Round(SelectedECRM_T005.rs_comm / SelectedECRM_T005.exchange_rate, 2);
            SelectedECRM_T005.fc_import_allw = Math.Round(SelectedECRM_T005.rs_import_allw / SelectedECRM_T005.exchange_rate, 2);

            SelectedECRM_T005.bnk_chrg_comm_fc = Math.Round(SelectedECRM_T005.bnk_chrg_comm / SelectedECRM_T005.exchange_rate, 2);
            SelectedECRM_T005.other_chrg_fc = Math.Round(SelectedECRM_T005.other_chrg / SelectedECRM_T005.exchange_rate, 2);
            SelectedECRM_T005.short_pay_fc = Math.Round(SelectedECRM_T005.short_pay / SelectedECRM_T005.exchange_rate, 2);

        }
        private void LoadInitialData()
        {
            try
            {
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T005>(MC, "ECRM_T005_Data", "PostExportTransaction", "CRM", "LoadAll", 0, "");
                SelectedList = MC.PostDetails;

                GoodsDetails = new ObservableCollection<ECRM_T005>();

                CollectionInvoice = CollectionViewSource.GetDefaultView(MC.Invoice);
                CollectionInvoice.Filter = new Predicate<object>(FilterInvoice);

                CollectionAgent = CollectionViewSource.GetDefaultView(MC.Agent);
                CollectionAgent.Filter = new Predicate<object>(FilterAgent);

                CollectionBank = CollectionViewSource.GetDefaultView(MC.Bank);
                CollectionBank.Filter = new Predicate<object>(FilterBank);

                CollectionBank1 = CollectionViewSource.GetDefaultView(MC.Bank);
                CollectionBank1.Filter = new Predicate<object>(FilterBank1);

                CollectionAirline = CollectionViewSource.GetDefaultView(MC.Airline);
                CollectionAirline.Filter = new Predicate<object>(FilterAirline);

                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
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

        #region · Command Actions ·

        protected override void OnSaveAction(InquiryActionResult<ECRM_T005> result)
        {
            try
            {
                this.SelectedECRM_T005.EndEdit();
                ObjectSerializationService objSer = new ObjectSerializationService();

                SelectedECRM_T005.add_by = AppSessionState.UserID;
                SelectedECRM_T005.plant = Convert.ToString(AppSessionState.location_Id);
                SelectedECRM_T005.company_id = AppSessionState.comp_code;
             //   SelectedECRM_T005.PlantName = AppSessionState.Location;

                if (blNew == true)
                {
                    //SelectedECRM_T005.XmlDataDocument_ECRM_T005 = objSer.ObjectToXML(GoodsDetails);
                    SelectedECRM_T005.XmlDataDocument_ECRM_T005 = objSer.ObjectToXML(SelectedECRM_T005);
                    SelectedECRM_T005 = repository.SaveWithReturnDomainObject<ECRM_T005>(SelectedECRM_T005, "PostExportTransaction", "CRM");
                    SelectedList.Add(SelectedECRM_T005);
                    _dataGridCollection.Refresh();
                    blNew = false;
                }
                else if (blNew == false)
                {
                    SelectedECRM_T005.XmlDataDocument_ECRM_T005 = objSer.ObjectToXML(SelectedECRM_T005);
                    SelectedECRM_T005 = repository.UpdateWithReturnDomainObject<ECRM_T005>(SelectedECRM_T005, "PostExportTransaction", "CRM");
                    //SelectedList.Add(SelectedECRM_T005);                     
                }

                _dataGridCollection.Refresh();

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
        protected override void OnCreateAction(InquiryActionResult<ECRM_T005> result)
        {
            blNew = true;

            GoodsDetails = new ObservableCollection<ECRM_T005>();
            GoodsDetails.Clear();

            _dataGridCollection.Refresh();
            SelectedECRM_T005 = new ECRM_T005();
            //SelectedECRM_T005.client = AppSessionState.client;
            SelectedECRM_T005.InvDate = DateTime.Now.Date;
            SelectedECRM_T005.air_way_billdt = DateTime.Now.Date;
            SelectedECRM_T005.ref_date = DateTime.Now.Date;
            SelectedECRM_T005.dcinv_frwd_cust_dt = DateTime.Now.Date;
            SelectedECRM_T005.dcpck_frwd_cust_dt = DateTime.Now.Date;
            SelectedECRM_T005.dcair_frwd_cust_dt = DateTime.Now.Date;
            SelectedECRM_T005.dcinsur_frwd_cust_dt = DateTime.Now.Date;
            SelectedECRM_T005.dccertif_cust_dt = DateTime.Now.Date;
            SelectedECRM_T005.dbinv_frwd_bnk_dt = DateTime.Now.Date;
            SelectedECRM_T005.dbpck_frwd_bnk_dt = DateTime.Now.Date;
            SelectedECRM_T005.dbair_frwd_bnk_dt = DateTime.Now.Date;
            SelectedECRM_T005.dbinsur_frwd_bnk_dt = DateTime.Now.Date;
            SelectedECRM_T005.dbcertif_bnk_dt = DateTime.Now.Date;
            SelectedECRM_T005.brc_dt = DateTime.Now.Date;
            SelectedECRM_T005.brc_appl_dt = DateTime.Now.Date;
            SelectedECRM_T005.brc_recv_dt = DateTime.Now.Date;
            SelectedECRM_T005.shipp_bill_dt = DateTime.Now.Date;
            SelectedECRM_T005.mate_recp_dt = DateTime.Now.Date;
            SelectedECRM_T005.realization_dt = DateTime.Now.Date;
            SelectedECRM_T005.nform_dt = DateTime.Now.Date;  
        }
        protected override void OnRemoveAction(InquiryActionResult<ECRM_T005> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text =
                String.Format(
                    "This record will delete forever '{0}'",
                        this.Title);

            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {            

                this.SelectedECRM_T005.EndEdit();
                ObjectSerializationService objSer = new ObjectSerializationService();
                SelectedECRM_T005.XmlDataDocument_ECRM_T005 = objSer.ObjectToXML(SelectedECRM_T005);
                string xdoc = objSer.ObjectToXML(SelectedECRM_T005);
                string response = repository.Delete(SelectedECRM_T005.id, "PostExportTransaction", "CRM");
                SelectedList.Remove(SelectedECRM_T005);
                SelectedECRM_T005 = new ECRM_T005();
                GoodsDetails = new ObservableCollection<ECRM_T005>();
                GoodsDetails.Clear();
                _dataGridCollection.Refresh();
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ECRM_T005> result)
        {
            SelectedECRM_T005.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ECRM_T005> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ECRM_T005> result)
        {
            SelectedList = SelectedList;
            SelectedECRM_T005 = SelectedECRM_T005;
        }
        protected override void OnHelpAction(InquiryActionResult<ECRM_T005> result)
        {
            SelectedList = SelectedList;
            SelectedECRM_T005 = SelectedECRM_T005;
        }
        protected override void OnPrintAction(InquiryActionResult<ECRM_T005> result)
        {
            SelectedList = SelectedList;
            SelectedECRM_T005 = SelectedECRM_T005;
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ECRM_T005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ECRM_T005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ECRM_T005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ECRM_T005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ECRM_T005> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters For Invoice
        private void FilterCollectionInvoice()
        {
            if (_CollectionInvoice != null)
            {
                _CollectionInvoice.Refresh();
            }
        }
        public string FilterStringInvoice
        {
            get { return _filterStringInvoice; }
            set
            {
                _filterStringInvoice = value;
                RaisePropertyChanged("FilterStringInvoice");
                FilterCollectionInvoice();
            }
        }
        public bool FilterInvoice(object obj)
        {
            var data = obj as SEL_T003_A_Popup;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringInvoice))
                {
                    return (data.bill_doc != null && data.bill_doc.ToString().ToLower().Contains(_filterStringInvoice.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Agent
        private void FilterCollectionAgent()
        {
            if (_CollectionAgent != null)
            {
                _CollectionAgent.Refresh();
            }
        }
        public string FilterStringAgent
        {
            get { return _filterStringAgent; }
            set
            {
                _filterStringAgent = value;
                RaisePropertyChanged("FilterStringAgent");
                FilterCollectionAgent();
            }
        }
        public bool FilterAgent(object obj)
        {
            var data = obj as ADM_M027_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringAgent))
                {
                    return (data.PersnFName != null && data.PersnFName.ToString().ToLower().Contains(_filterStringAgent.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Bank
        private void FilterCollectionBank()
        {
            if (_CollectionBank != null)
            {
                _CollectionBank.Refresh();
            }
        }
        public string FilterStringBank
        {
            get { return _filterStringBank; }
            set
            {
                _filterStringBank = value;
                RaisePropertyChanged("FilterStringBank");
                FilterCollectionBank();
            }
        }
        public bool FilterBank(object obj)
        {
            var data = obj as ACC_M004_Popup;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringBank))
                {
                    return (data.bank_name != null && data.bank_name.ToString().ToLower().Contains(_filterStringBank.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Bank1
        private void FilterCollectionBank1()
        {
            if (_CollectionBank1 != null)
            {
                _CollectionBank1.Refresh();
            }
        }
        public string FilterStringBank1
        {
            get { return _filterStringBank1; }
            set
            {
                _filterStringBank1 = value;
                RaisePropertyChanged("FilterStringBank1");
                FilterCollectionBank1();
            }
        }
        public bool FilterBank1(object obj)
        {
            var data = obj as ACC_M004_Popup;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringBank1))
                {
                    return (data.bank_name != null && data.bank_name.ToString().ToLower().Contains(_filterStringBank1.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Airline
        private void FilterCollectionAirline()
        {
            if (_CollectionAirline != null)
            {
                _CollectionAirline.Refresh();
            }
        }
        public string FilterStringAirline
        {
            get { return _filterStringAirline; }
            set
            {
                _filterStringAirline = value;
                RaisePropertyChanged("FilterStringAirline");
                FilterCollectionAirline();
            }
        }
        public bool FilterAirline(object obj)
        {
            var data = obj as ZADM_M019_Popup;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringAirline))
                {
                    return (data.airline != null && data.airline.ToString().ToLower().Contains(_filterStringAirline.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region "Filter for Back Content Datagrid"
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
            var data = obj as ECRM_T005;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.inv_no != null && data.inv_no.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.InvDate != null && data.InvDate.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.adv_licenc_no != null && data.adv_licenc_no.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.epcg_licenc_no != null && data.epcg_licenc_no.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }

        
        #endregion

    }
}
