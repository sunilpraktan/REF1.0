using System;
using System.Collections.Generic;
using System.Windows;
using Reflection.Modules.Navigation;
using Reflection.Presentation.Core.Navigation;
using Reflection.Presentation.Core.ViewModel;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.Presentation.Windows;
using Reflection.Shell.WidgetLibrary;
using NLog;
using Reflection.Shell.Authentication;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.Administration.Views;
using Reflection.Apps.Store.TaskManager;
using Reflection.Apps.Store.Massenger;
using System.Reflection;
using System.IO;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls;
using System.Windows.Controls;
using Reflection.Presentation.Services;
using Reflection.Modules.Settings;
using Reflection.Modules.Settings.Views;
using nRoute.Components.Messaging;

namespace Reflection.Shell.ViewModel
{
    /// <summary>
    /// Shell Window ViewModel
    /// </summary>
    public sealed class ShellViewModel
        : Presentation.ViewModel.ViewModelBase
    {
        #region · Logger ·

        private static Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region · Fields ·

        private WindowState windowState;
        private string userName;

        #region · Commands ·

        private RelayCommand maximizeCommand;
        private RelayCommand minimizeCommand;
        private RelayCommand showWidgetLibraryCommand;
        private RelayCommand showTaskManagerCommand;

        private RelayCommand showMassengerCommand;

        private RelayCommand shutdownCommand;
        private RelayCommand closeSessionCommand;
        private RelayCommand switchDesktopCommand;
        private RelayCommand showDesktopCommand;
        private RelayCommand saveCurrentDesktopCommand;
        private RelayCommand saveAllDesktopsCommand;
        private RelayCommand showAboutBoxCommand;

        #endregion

        #region · Observers ·

        private ChannelObserver<AuthenticationInfo> authenticationObserver;
        private ChannelObserver<ActiveDesktopChangedInfo> activeDesktopObserver;
        private ChannelObserver<NavigatedInfo> navigatedObserver;

        #endregion

        #endregion

        #region · Commands ·
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        /// <summary>
        /// Gets the maximize command.
        /// </summary>
        /// <value>The maximize command.</value>
        public RelayCommand MaximizeCommand
        {
            get
            {
                if (this.maximizeCommand == null)
                {
                    this.maximizeCommand = new RelayCommand(() => OnMaximizeWindow());
                }

                return this.maximizeCommand;
            }
        }

        /// <summary>
        /// Gets the minimize command.
        /// </summary>
        /// <value>The minimize command.</value>
        public RelayCommand MinimizeCommand
        {
            get
            {
                if (this.minimizeCommand == null)
                {
                    this.minimizeCommand = new RelayCommand(() => OnMinimizeWindow());
                }

                return this.minimizeCommand;
            }
        }

        /// <summary>
        /// Gets the switch desktop command
        /// </summary>
        public RelayCommand SwitchDesktopCommand
        {
            get
            {
                if (this.switchDesktopCommand == null)
                {
                    this.switchDesktopCommand = new RelayCommand(() => OnSwitchDesktop());
                }

                return this.switchDesktopCommand;
            }
        }

        /// <summary>
        /// Gets the show desktop command
        /// </summary>
        public RelayCommand ShowDesktopCommand
        {
            get
            {
                if (this.showDesktopCommand == null)
                {
                    this.showDesktopCommand = new RelayCommand(() => OnShowDesktop());
                }

                return this.showDesktopCommand;
            }
        }

        /// <summary>
        /// Gets the save current desktop command.
        /// </summary>
        /// <value>The save desktop command.</value>
        public RelayCommand SaveCurrentDesktopCommand
        {
            get
            {
                if (this.saveCurrentDesktopCommand == null)
                {
                    this.saveCurrentDesktopCommand = new RelayCommand(() => OnSaveCurrentDesktop());
                }

                return this.saveCurrentDesktopCommand;
            }
        }

        /// <summary>
        /// Gets the save all desktops command.
        /// </summary>
        /// <value>The save desktop command.</value>
        public RelayCommand SaveAllDesktopsCommand
        {
            get
            {
                if (this.saveAllDesktopsCommand == null)
                {
                    this.saveAllDesktopsCommand = new RelayCommand(() => OnSaveAllDesktops());
                }

                return this.saveAllDesktopsCommand;
            }
        }

        /// <summary>
        /// Gets the show widget library command.
        /// </summary>
        /// <value>The show widget library command.</value>
        public RelayCommand ShowWidgetLibraryCommand
        {
            get
            {
                if (this.showWidgetLibraryCommand == null)
                {
                    this.showWidgetLibraryCommand = new RelayCommand(() => OnShowWidgetLibrary());
                }

                return this.showWidgetLibraryCommand;
            }
        }

        /// <summary>
        /// Gets the show Task Manager command.
        /// </summary>
        /// <value>The show Task Manager command.</value>
        public RelayCommand ShowTaskManagerCommand
        {
            get
            {
                if (this.showTaskManagerCommand == null)
                {
                    this.showTaskManagerCommand = new RelayCommand(() => OnShowTaskManager());
                }

                return this.showTaskManagerCommand;
            }
        }
        private void OnShowTaskManager()
        {
            SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<TaskManagerView>();
        }
        public RelayCommand ShowMassengerCommand
        {
            get
            {
                if (this.showMassengerCommand == null)
                {
                    this.showMassengerCommand = new RelayCommand(() => OnShowMassenger());
                }
                return this.showMassengerCommand;
            }
        }

        private void OnShowMassenger()
        {
            SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Masseging>();
        }

        /// <summary>
        /// Gets the about box command.
        /// </summary>
        /// <value>The about box command.</value>
        public RelayCommand ShowAboutBoxCommand
        {
            get
            {
                if (this.showAboutBoxCommand == null)
                {
                    this.showAboutBoxCommand = new RelayCommand(() => OnShowAboutBoxCommand());
                }

                return this.showAboutBoxCommand;
            }
        }

        /// <summary>
        /// Gets the shutdown command
        /// </summary>
        public RelayCommand ShutdownCommand
        {
            get
            {
                if (this.shutdownCommand == null)
                {
                    this.shutdownCommand = new RelayCommand(() => OnShutdown());
                }

                return this.shutdownCommand;
            }
        }

        /// <summary>
        /// Gets the log off command
        /// </summary>
        public RelayCommand CloseSessionCommand
        {
            get
            {
                if (this.closeSessionCommand == null)
                {
                    this.closeSessionCommand = new RelayCommand(() => OnCloseSession());
                }

                return this.closeSessionCommand;
            }
        }

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets or sets the state of the window.
        /// </summary>
        /// <value>The state of the window.</value>
        public WindowState WindowState
        {
            get { return this.windowState; }
            set
            {
                if (this.windowState != value)
                {
                    this.windowState = value;
                    this.NotifyPropertyChanged(() => WindowState);
                }
            }
        }

        /// <summary>
        /// Gets the active windows.
        /// </summary>
        /// <value>The active windows.</value>
        public IList<INavigationViewModel> ActiveWindows
        {
            get
            {
                if (SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().HasDesktopActive)
                {
                    return SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().ActiveDesktopWindows;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the logged in user name
        /// </summary>
        public string UserName
        {
            get { return (!String.IsNullOrEmpty(this.userName) ? this.userName : "Administrator"); }
            private set
            {
                this.userName = value;
                //this.NotifyPropertyChanged(() => UserName);
            }
        }

        private string _CurrentCompany;
        /// <summary>
        /// Gets the logged in user name
        /// </summary>
        public string CurrentCompany
        {
            get { return (!String.IsNullOrEmpty(this._CurrentCompany) ? this._CurrentCompany : AppSessionState.OBJ_COMPANY.comp_name); }
            private set
            {
                this._CurrentCompany = value;
                this.NotifyPropertyChanged(() => CurrentCompany);
            }
        }

        private string _CompanyLogo;
        /// <summary>
        /// Gets the logged in user name
        /// </summary>
        public string CompanyLogo
        {
            get { return this._CompanyLogo; }
            private set
            {
                this._CompanyLogo = value;
                this.NotifyPropertyChanged(() => _CompanyLogo);
            }
        }



        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
        /// </summary>
        public ShellViewModel()
            : base()
        {
            this.InitializeObservers();            
            Messenger.Default.Register<NavigateToView>
                (
                    this,
                    (action) => ReceiveMessage(action)
                );
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);            
            Messenger.Default.Register<DocumentViewerPayload>(this, OpenDocumentViewer);
            Messenger.Default.Unregister<DocumentViewerPayload>(this, (mesage) => { });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            //NOTE: show proper user info with all system and other details for user. use samll popup control.
            //UserName = AppSessionState.EmpName + " (UID: " + AppSessionState.EmpId + ") Session Start On: " + System.DateTime.Now.ToString();  // + " HOST/IP: " + AppSessionState.UserSource1 + " MAC_ID: " + AppSessionState.UserSource2;
            UserName = " USER: " + AppSessionState.EmpName + "(" + AppSessionState.UserID + ")";
            CurrentCompany = " COMPANY: " + AppSessionState.OBJ_COMPANY.comp_name.ToUpper();
            CompanyLogo = AppSessionState.LogoUrl;

        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                OnShowWidgetLibrary();
            }
            catch (Exception ex)
            {
            }
        }
        private void OpenDocumentViewer(DocumentViewerPayload obj)
        {
            try
            {
                var docViewer = new ReflectionDocumentViewer(obj);
                docViewer.Width = 1000;
                docViewer.Height = 600;
                docViewer.AllowDrop = true;
                var grid = new Grid();
                grid.Children.Add(docViewer);
                Window window = new Window
                {
                    Title = "Document Viewer",
                    Content = grid,
                    SizeToContent = SizeToContent.WidthAndHeight,
                    ResizeMode = ResizeMode.NoResize,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    AllowDrop = true
                };
                window.Owner = Application.Current.MainWindow;//  Window.GetWindow(this);
                window.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.Debug("Document Viewer cloased ({0})", this.WindowState);
            }
            
        }
                        
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "RESET")
            {
                CurrentCompany = "      COMPANY: " + AppSessionState.OBJ_COMPANY.comp_name.ToUpper();
            }
            //if (msg.Notification == "ADM_M010_S")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<UserSettings>();
            //}
            //if (msg.Notification == "test")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Tax_Master>();
            //}
            //if (msg.Notification == "ACC_M013")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Tax_Master>();                
            //}

            //if (msg.Notification == "ACC_T001")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PaymentEntry>();
            //}
            //if (msg.Notification == "Foreign_Remittance")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ForeignRemittance>();
            //}
            //if (msg.Notification == "ACC_T002")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<JournalVoucher>();
            //}
            //if (msg.Notification == "ACC_M007")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PaymentTerms>();
            //}
            //if (msg.Notification == "TSK_T001_C_EP")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ExpectedPayment>();
            //}
            //if (msg.Notification == "ACC_T005")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ExpectedPayment2>();
            //}
            //else if (msg.Notification == "MM_T001_OpeningStock")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<OpeningStock>();
            //}
            //if (msg.Notification == "PaymentReceipt")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Payment_Reciept>();
            //}
            //else if (msg.Notification == "Current_Stock")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Current_Stock>();
            //}
            //else if (msg.Notification == "Expenses_Voucher")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ExpensesVoucher>();
            //}
            //else if (msg.Notification == "Expenses")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Expenses>();
            //}
            //else if (msg.Notification == "ACC_T003_EC")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Expenses_Commercial>();
            //}
            //else if (msg.Notification == "ACC_T004")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<OpeningBalance>();
            //}
            //else if (msg.Notification == "Tour_Voucher")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<TourVoucher>();
            //}
            //else if (msg.Notification == "MIS_Expence")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_Finance_Expence>();
            //}
          
            //else if (msg.Notification == "StockChecking")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<StockChecking>();
            //}
            ////-----------------------------------------ADM
            //else if (msg.Notification == "ADM_M001")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<GroupCompany>();
            //}
            //else if (msg.Notification == "ADM_M002")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Company_Master>();
            //}
            //else if (msg.Notification == "ADM_M003")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<LocationMaster>();
            //}
            //else if (msg.Notification == "ADM_LAB")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<LabrotaryMaster>();
            //}
            //else if (msg.Notification == "ADM_M008B")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ViewMaster>();
            //}
            //else if (msg.Notification == "ADM_M009")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<RoleMaster>();
            //}
            //else if (msg.Notification == "ADM_M010")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<UserMaster>();
            //}
            //else if (msg.Notification == "ADM_M011")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Warehouse>();
            //}
            //else if (msg.Notification == "ADM_M012")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<CountryMaster>();
            //}
            //else if (msg.Notification == "ADM_M013")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<StateMaster>();
            //}
            //else if (msg.Notification == "ADM_M015")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ItemTypeMaster>();
            //}
            //else if (msg.Notification == "ADM_M016")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SubItemTypeMaster>();
            //}
            //else if (msg.Notification == "ADM_M018")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<CategoryMaster>();
            //}
            //else if (msg.Notification == "ADM_M019")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SubCategoryMaster>();
            //}
            //else if (msg.Notification == "ADM_M022")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ItemMaster>();
            //}
            //else if (msg.Notification == "ADM_M024")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Employee_Master>();
            //}
            //else if (msg.Notification == "ADM_M025")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<DepartmentMaster>();
            //}
            //else if (msg.Notification == "ADM_M026")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<DesignationMaster>();
            //}

            //else if (msg.Notification == "ADM_M028")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PartyMaster>();
            //}

            //else if (msg.Notification == "ADM_M030")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ParameterValueMaster>();
            //}

            //else if (msg.Notification == "ADM_M032")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MakeMaster>();
            //}
            //else if (msg.Notification == "ADM_M033")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ColourMaster>();
            //}
            //else if (msg.Notification == "ADM_M034")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<CatParameterMaster>();
            //}
            //else if (msg.Notification == "ADM_M036")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<AllocationMaster>();
            //}
            //else if (msg.Notification == "ADM_M038_B")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<UOM_Master>();
            //}
            //else if (msg.Notification == "ADM_M038_C")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<UOM_Conversion>();
            //}

            //else if (msg.Notification == "ADM_M043")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<WorkFlowMaster>();
            //}
            ////-----------------------------------------ZADM
            //else if (msg.Notification == "ZADM_M003")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<WireSizeMaster>();
            //}
            //else if (msg.Notification == "ZADM_M004")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<WireTypeMaster>();
            //}

            //else if (msg.Notification == "ZADM_M005")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<UsedIn_Master>();
            //}
            //else if (msg.Notification == "ZADM_M006")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<InkMaster>();
            //}
            //else if (msg.Notification == "ZADM_M007")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ILDMaster>();
            //}
            //else if (msg.Notification == "SearchLabel")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Search_Label>();
            //}
            //else if (msg.Notification == "ZADM_M008")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<TotalLengthMaster>();
            //}
            //else if (msg.Notification == "ZADM_M009")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ModelMaster>();
            //}
            //else if (msg.Notification == "ZADM_M011")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MachineTypeMaster>();
            //}
            //else if (msg.Notification == "ZADM_M012")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MachineSubTypeMaster>();
            //}
            //else if (msg.Notification == "ZADM_M013")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MachineMaster>();
            //}
            //else if (msg.Notification == "ZADM_M014")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<WritingTestMaster>();
            //}
            //else if (msg.Notification == "ZADM_M010")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<FinishGoodMaster>();
            //}
            //else if (msg.Notification == "ZADM_M001")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<BallDiameterMaster>();
            //}
            //else if (msg.Notification == "ZADM_M002")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<BallTypeMaster>();
            //}
            ////else if (msg.Notification == "ZADM_M027")
            ////{
            ////    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<RateMaster>();
            ////}
            ////-----------------------------------------ZCRM
            //else if (msg.Notification == "ZCRM_T001_1")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<AutoSalesInvoiceMultiple>();
            //}
            ////else if (msg.Notification == "ZCRM_T001_2")
            ////{
            ////    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<DeliveryEntry>();
            ////}
            //else if (msg.Notification == "ZCRM_T001_2")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<DeliveryEntryLogistics>();
            //}
            //else if (msg.Notification == "ZCRM_T001_3")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<DeliveryAcknowledement>();
            //}
            //else if (msg.Notification == "Project")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ProjectTenderDocument>();
            //}

            //else if (msg.Notification == "TenderDocUploader")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<TenderDocumentUploader>();
            //}
            //else if (msg.Notification == "InkCatalog")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<InkCatalog>();
            //}

            ////-----------------------------------------ZSCM
            //else if (msg.Notification == "ZSCM_T001_A")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Average_Blank_Weight>();
            //}
            //else if (msg.Notification == "GoodsIssue")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Goods_Issue>();
            //}
            //else if (msg.Notification == "MM_T001")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Goods_Receipt>();
            //}
            //else if (msg.Notification == "MM_T001_PC")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ProductConversion>();
            //}
            //else if (msg.Notification == "MM_T001_GC")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ProductConversion_Essem>();
            //}
            //else if (msg.Notification == "MM_T003_A")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<IndentOrder>();
            //}
            //else if (msg.Notification == "MM_T004_GateEntry")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Gate_Entry>();
            //}
            //else if (msg.Notification == "SEL_T004TOPending")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<TransferOrderPending>();
            //}
            //else if (msg.Notification == "BOM")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Bill_Of_Material>();
            //}
            //else if (msg.Notification == "ENG_T004")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<TDS>();
            //}

            //else if (msg.Notification == "ECRM_T003_A_QC")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<WritingTest2_QC>();
            //}
            ////-----------------------------------------CRM

            //else if (msg.Notification == "AreaCalculator")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<AreaCalculator>();
            //}
            //else if (msg.Notification == "CRM_T001A")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<CatlogMaster>();
            //}
            //else if (msg.Notification == "CRM_T002A")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Supplier_Catalog>();
            //}
            //else if (msg.Notification == "Closure")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Closure>();
            //}
            //else if (msg.Notification == "MIS_Closure")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_Closure>();
            //}
            //else if (msg.Notification == "CRM_T004")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Activity>();
            //}
            //else if (msg.Notification == "PUR_T001_A")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseRequisition>();
            //}
            //else if (msg.Notification == "PUR_T001_A2")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseRequisition2>();
            //}

            //else if (msg.Notification == "PUR_T001_A_CANCEL")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseRequisitionCancel>();
            //}
            //else if (msg.Notification == "PUR_T001_A_Req_Approve")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseRequisitionApprove>();
            //}
            //else if (msg.Notification == "PUR_T002_A")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseOrder>();
            //}
            //else if (msg.Notification == "PUR_T002_A2")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseOrder2>();
            //}
            //else if (msg.Notification == "PUR_T002_G")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseOrderApprove>();
            //}
            //else if (msg.Notification == "SEL_T001")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SalesOrderMaster>();
            //}
            //else if (msg.Notification == "SEL_T099")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Wastage_Entry>();
            //}
            //else if (msg.Notification == "PUR_T006")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ServiceEntrySheet>();
            //}
            //else if (msg.Notification == "PurchaseInternal")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseOrderInternal>();
            //}

            //else if (msg.Notification == "TSK_T001_C")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<CRMActivity2>();
            //}
            //else if (msg.Notification == "SEL_T002")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SalesOrder_DeliverySchedule>();
            //}
            //else if (msg.Notification == "SO_Requirement")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SalesOrder_Requirement>();
            //}
            //else if (msg.Notification == "ADM_M043_D")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Approvals>();
            //}

            //else if (msg.Notification == "SEL_T002_SO_Confirma")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SaleOrder_DeliveryScheduleConfirmation>();
            //}
            ////else if (msg.Notification == "SEL_T002_Req")
            ////{
            ////    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Requirement>();
            ////}
            //else if (msg.Notification == "LOG_T001_A")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Reflection.Modules.SCM.Views.DeliveryNote>();
            //}
            //else if (msg.Notification == "LOG_T001_A_Cons")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<DeliveryNoteConsignee>();
            //}
            ////else if (msg.Notification == "LOG_T001_A_Essem")
            ////{
            ////    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Modules.SCM.Views.DeliveryChallan>();
            ////}
            //else if (msg.Notification == "ECRM_T001_A")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Sample_Analysis>();
            //}
            //else if (msg.Notification == "ECRM_T001_C")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Sample_Response>();
            //}
            //else if (msg.Notification == "ECRM_T002_A")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Quality_Feedback>();
            //}
            //else if (msg.Notification == "ECRM_T002_A_RTQFR")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<RTQFR>();
            //}
            //else if (msg.Notification == "ECRM_T004_A")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PDI_Entry>();
            //}
            //else if (msg.Notification == "ECRM_T004")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PDI_Entry2>();
            //}
            //else if (msg.Notification == "ECRM_T003_A")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<WritingTest>();
            //}
            //else if (msg.Notification == "ECRM_T003_A_2")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<WritingTest2>();
            //}
            //else if (msg.Notification == "SEL_T001_SR")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Sample_Request>();
            //}

            //else if (msg.Notification == "EPR_T001")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ILDChart>();
            //}
            //else if (msg.Notification == "ILDChart2")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ILDChart2>();
            //}
            //else if (msg.Notification == "EPR_T002")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<LabelGeneration>();
            //}
            //else if (msg.Notification == "ESO_T001")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Sorting>();
            //}
            //else if (msg.Notification == "ESO_T001_rpt")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SortingReport>();
            //}
            //else if (msg.Notification == "Sorting2")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Sorting_2>();
            //}
            //else if (msg.Notification == "SortEssem")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SortingEssem>();
            //}

            //else if (msg.Notification == "EPR_T001_Con")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ConversioNote>();
            //}
            //else if (msg.Notification == "EPR_T001_Con2")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ConversionNote2>();
            //}
            //else if (msg.Notification == "EPR_T002_Prod_Entry")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Production_Entry>();
            //}
            //else if (msg.Notification == "EPR_T002_MergeLabel")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MergeLabel>();
            //}
            //else if (msg.Notification == "ECRM_T003_A_PROD")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<WritingTestForProduction>();
            //}
            //else if (msg.Notification == "ECRM_T003_A_PROD_2")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<WritingTestForProduction_2>();
            //}

            //else if (msg.Notification == "SEL_T003")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Sales_Invoice>();
            //}
            //else if (msg.Notification == "ZCRM_T001_Auto")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<AutoSalesInvoice>();
            //}
            //else if (msg.Notification == "SEL_T003_Essem")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Sales_Invoice_Essem1>();
            //}
            ////else if (msg.Notification == "SEL_T003_Export_VM")
            ////{
            ////    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SalesInvoice_Export>();
            ////}
            //else if (msg.Notification == "EPR_T003_SmallCarton")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SmallCarton>();
            //}
            //else if (msg.Notification == "EPR_T003_LocalExportCarton")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<LocalExportCarton>();
            //}
            //else if (msg.Notification == "EPR_T003_Export2")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ExportCarton2>();
            //}
            //else if (msg.Notification == "EPR_T003_Local2")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<LocalCarton2>();
            //}
            //else if (msg.Notification == "EPR_T003_Repacking")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Repacking>();
            //}
            //else if (msg.Notification == "SEL_T003_Performa")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PerformaInvoice>();
            //}
            //else if (msg.Notification == "SEL_T003_DebitCredit")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SalesInvoice_DebitCredit>();
            //}

            //else if (msg.Notification == "SEL_T001_Essem")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SalesOrderEssem1>();
            //}
            //else if (msg.Notification == "PPC_T002")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ProductionEntryMultiple>();
            //}
            //else if (msg.Notification == "PPC_T001")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<JobCart>();
            //}
            //else if (msg.Notification == "Sale_PeriodicReport")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_CRM_Sales1>();
            //}
            //else if (msg.Notification == "MIS_CRM_Report3")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_CRM_Sales3>();
            //}
            //else if (msg.Notification == "MIS_SCM")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_SCM>();
            //}
            //else if (msg.Notification == "MIS_CRM_Report4")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_CRM_Sales4>();
            //}
            //else if (msg.Notification == "MIS_CRM_PurchaseRpt")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_CRM_Purchase>();
            //}
            //else if (msg.Notification == "MIS_CRM_Report5")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_CRM_Sales5>();
            //}
            //else if (msg.Notification == "MIS_CRM_Report6")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_CRM_Sales6>();
            //}
            //else if (msg.Notification == "MIS_CRM_Report7")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_CRM_Sales7>();
            //}
            //else if (msg.Notification == "MIS_Sales_Insurance")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_Sales_Insurance>();
            //}
            //else if (msg.Notification == "MIS_SCM_Report")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_SCM_Report1>();
            //}

            //else if (msg.Notification == "MIS_FinStatement")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_FinancialStatement>();
            //}
            //else if (msg.Notification == "MIS_FinStatement_FG")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_FinstatementFG>();
            //}
            //else if (msg.Notification == "MIS_SCM_Store")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_SCM_Store>();
            //}
            //else if (msg.Notification == "MISFinance_Report")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MISFinance_Payment>();
            //}
            //else if (msg.Notification == "MISFinance_Report2")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MISFinance_Payment2>();
            //}
            //else if (msg.Notification == "MIS_Production")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_Production>();
            //}

            //else if (msg.Notification == "MIS_Pro_Periodic")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_Pro_Periodic>();
            //}

            //else if (msg.Notification == "MIS_BOM_MRP")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_BOM_MRPReport>();
            //}

            //else if (msg.Notification == "MIS_Pro_Periodic")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_CRM_Sales5>();
            //}

            //else if (msg.Notification == "MIS_Pro_MFG")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_Pro_MFG>();
            //}

            //else if (msg.Notification == "SortingReport")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_Sorting_Reports>();
            //}

            //else if (msg.Notification == "SEL_T001_ST")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<StockTransfer>();
            //}
            //else if (msg.Notification == "SEL_T004")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<TransferOrder>();
            //}
            //else if (msg.Notification == "SEL_T001_SSE")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SalesServiceEntry>();
            //}

            ////-----------------------------------------QMS
            //else if (msg.Notification == "QMS_M002")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<QMS_Parameter>();
            //}
            //else if (msg.Notification == "QMS_M003")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Inspector_Qualification>();
            //}
            //else if (msg.Notification == "QMS_M004")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Inspection_Method>();
            //}
            //else if (msg.Notification == "MM_T001_GRN")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Goods_Receipt_Note>();
            //}
            //else if (msg.Notification == "SEL_T001_SE")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Sales_Inquiry>();
            //}
            //else if (msg.Notification == "SEL_T001_QT")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Sales_Quotation>();
            //}
            //else if (msg.Notification == "SEL_T001_QN2")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Sales_Quotation2>();
            //}
            //else if (msg.Notification == "SEL_T001_IN2")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Sales_Inquiry2>();
            //}
            //else if (msg.Notification == "EQCR_T001_RejectionNote")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Rejection_Note>();
            //}
            //else if (msg.Notification == "EQCR_T001")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<QCR>();
            //}

            
            //else if (msg.Notification == "Transactions")
            //{
            //    //SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<EmpresaView>();
            //}
            
            //else if (msg.Notification == "General Master")
            //{
            //    // SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<GeneralMaster>();
            //}
            //else if (msg.Notification == "Call Revision Master")
            //{
            //    // SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<CallRevisionMaster>();
            //}
            ////-------------- Calibration ---------

            //else if (msg.Notification == "Activity Master")
            //{
            //    // SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ActivityMaster>();
            //}
            //else if (msg.Notification == "Call Log")
            //{
            //    //SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<CallLog>();
            //}
            //else if (msg.Notification == "Call Log FeedBack")
            //{
            //    // SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<CallLogFeedBack>();
            //}
            //else if (msg.Notification == "PUR_T005")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseEntry>();
            //}
            //else if (msg.Notification == "PUR_T005_DebitCredit")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseInvoice_DebitCredit>();
            //}

            //else if (msg.Notification == "Sale_PeriodicReport")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SalesOrderReports>();
            //}

            //else if (msg.Notification == "Purchase_PeriodicReport")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseOrderReports>();
            //}

            //else if (msg.Notification == "Purchase_PeriodicReport")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseOrderReports>();
            //}
            //else if (msg.Notification == "PUR_T005_DebitCredit")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseInvoice_DebitCredit>();
            //}
            //else if (msg.Notification == "SEL_T003_DebitCredit")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SalesInvoice_DebitCredit>();
            //}
            ////else if (msg.Notification == "PeriodicReport")
            ////{
            ////    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Logistic_periodicReport>();
            ////}
            //else if (msg.Notification == "ADM_M031")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Parameter_Master>();
            //}
            //else if (msg.Notification == "ESEL_T001_A")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<FormReceivedFrmCustomer>();
            //}
            //else if (msg.Notification == "ZCRM_T002_RI")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Random_Inspection>();
            //}
            //else if (msg.Notification == "ZCRM_T003")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Process_Inspection>();
            //}
            //else if (msg.Notification == "Sale_PeriodicReport2")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_CRM_Sales2>();
            //}
            //else if (msg.Notification == "ZADM_M018")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<FG_DebitCredit>();
            //}
            //else if (msg.Notification == "ECRM_T005")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PostExportTransaction>();
            //}

            //else if (msg.Notification == "ZADM_M018")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<FG_DebitCredit>();
            //}
            //else if (msg.Notification == "ECRM_T005")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PostExportTransaction>();
            //}
            //else if (msg.Notification == "EQCR_T001")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<QCR>();
            //}
            //else if (msg.Notification == "EQCR_T001_RejectionNote")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Rejection_Note>();
            //}
            //else if (msg.Notification == "SEL_T001_SOAck")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SO_Acknowledgement>();
            //}
            //else if (msg.Notification == "MIS_SCM_Indent")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<MIS_SCM_Indent>();
            //}
            //else if (msg.Notification == "Projects")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Projects>();
            //}
            //else if (msg.Notification == "Tasks")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Tasks>();
            //}

            //else if (msg.Notification == "Issues")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Issues>();
            //}
            //else if (msg.Notification == "EPR_T004")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ProdcutionPlan>();
            //}
            
            //else if (msg.Notification == "PPC_T003")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<UltrasonicCleaning>();
            //}
            //else if (msg.Notification == "PurchaseInquiry")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseInquiry>();
            //}
            //else if (msg.Notification == "PurchaseQuotation")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseQuotation>();
            //}
            //else if (msg.Notification == "PUR_T002_A_Qtn_Approve")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseQuotationApprove>();
            //}
            //else if (msg.Notification == "MM_T004_IO")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Inward_Outward>();
            //}
            //else if (msg.Notification == "MM_T004_GP")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Gate_Pass>();
            //}
            //else if (msg.Notification == "MM_T001_GRN_C")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Goods_Receipt_Note_Cash>();
            //}
            //else if (msg.Notification == "MM_T001_GRN_P2P")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Goods_Receipt_Note_P2P>();
            //}
            //else if (msg.Notification == "LOG_T001_A_P2P")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<DeliveryNote_P2P>();
            //}
            //else if (msg.Notification == "EPR_T003_LocalExport")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<LocalExportCarton>();
            //}
            //else if (msg.Notification == "EPR_T003RepackLocal")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<RepackingLocal>();
            //}
            //else if (msg.Notification == "EPR_T002_PE_Counter")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ProductionEntryCounter>();
            //}
            //else if (msg.Notification == "EPR_T003_LocalCarton")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<LocalCarton>();
            //}
            //else if(msg.Notification == "EPR_T005_A")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SampleLabel>();
            //}
            //else if (msg.Notification == "MM_T001_MI_ESSEM")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<GoodsIssue_Essem>();
            //}
            //else if (msg.Notification == "Material_Conversion")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Material_Conversion>();
            //}
             if (msg.Notification == "PUR_T001_A2")
            {
                //SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseRequisition2>(); // old method

                string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.CustomerRelation.dll"); // this one is path option
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Reflection.Modules.CustomerRelation.dll"); // OR this one. both are working path
                Assembly assembly = Assembly.LoadFile(path);
                Type type = assembly.GetType("Reflection.Modules.CustomerRelation.Views.PurchaseRequisition2");
                if (type != null)
                {
                    dynamic instance = Activator.CreateInstance(type);
                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                }
            }
            else if (msg.Notification == "SOT0001")
            {
                //SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PurchaseRequisition2>(); // old method

                string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.CustomerRelation.dll"); // this one is path option
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Reflection.Modules.CustomerRelation.dll"); // OR this one. both are working path
                Assembly assembly = Assembly.LoadFile(path);
                Type type = assembly.GetType("Reflection.Modules.CustomerRelation.Views.SalesOrder");
                if (type != null)
                {
                    dynamic instance = Activator.CreateInstance(type);
                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                }
            }
            //else if (msg.Notification == "MM_T001_GRN2")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<GoodsReceiptNote2>();
            //}
            //else if (msg.Notification == "MM_T001_GRN2_P2P")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<GoodsReceiptNote2_P2P>();
            //}
            //else if (msg.Notification == "MM_T001_MR2")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<GoodsReceipt2>();
            //}
            //else if (msg.Notification == "LOG_T001_A2")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<DeliveryNote2>();
            //}
            //else if (msg.Notification == "LOG_T001_A2_P2P")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<DeliveryNote2_P2P>();
            //}
            //else if (msg.Notification == "EPR_T002_LabelUpdate")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<LabelGenerationUpdate>();
            //}
            //else if (msg.Notification == "MM_S010_PhyStock")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Physical_Stock>();
            //}
            //else if (msg.Notification == "MM_S010_PhyStock1")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Physical_Stock1>();
            //}
            //else if (msg.Notification == "WIP_Consumption")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<WIP_Consumption>();
            //}
            //else if (msg.Notification == "EPR_T002_D_PE_Search")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ProductionEntrySearch>();
            //}
            //else if (msg.Notification == "EPR_T003RepackSmall")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<RepackingSmall>();
            //}
            //else if (msg.Notification == "EPR_T003RepackExport")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<RepackingExport>();
            //}
            //else if (msg.Notification == "EPR_T003SampleCarton")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<SampleCartonPacking>();
            //}

            //else if(msg.Notification == "MM_S010FG1")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<PhysicalStockFG1>();
            //}
            //else if (msg.Notification == "LOG_T001_A_Export")
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<DeliveryNoteExport>();
            //}

        }
        private void ReceiveMessage(NavigateToView msg)
        {
            //
           
            
            if (msg.ViewName == "Master List")
            {
                //SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<TestUserControl>();
            }
            else if (msg.ViewName == "Transactions")
            {
                //SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<EmpresaView>();
            }
            else if (msg.ViewName == "Invoice")
            {
                SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<GroupCompany>();
            }
            else if (msg.ViewName == "ProductionPlan")
            {
                //SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<ProdcutionPlan>();
            }
           
            else 
            {
                //SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Employee3D>();
            }
            //else 
            //{
            //    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<EmployeeMaster>();
            //}
            OnActiveDesktopChanged();
        }
        #endregion

        #region · Command Actions ·

        /// <summary>
        /// Handles the show widget library command action
        /// </summary>
        private void OnShowWidgetLibrary()
        {
            SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<WidgetLibraryView>();
            //ServiceLocator.Current.GetInstance<IVirtualDesktopManager>().Show<WidgetLibraryView>;
        }

        /// <summary>
        /// Handles the switch desktop command action
        /// </summary>
        private void OnSwitchDesktop()
        {
            //ServiceLocator.Current.GetInstance<IVirtualDesktopManager>().SwitchDesktop();
            SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().SwitchDesktop();
        }

        /// <summary>
        /// Handles the show desktop command
        /// </summary>
        private void OnShowDesktop()
        {
            //ServiceLocator.Current.GetInstance<IVirtualDesktopManager>().ShowDesktop();
            //SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().ShowDesktop();
            SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<UserSettings>();
         }

        /// <summary>
        /// Handles the save current desktop command action
        /// </summary>
        private void OnSaveCurrentDesktop()
        {
            //ServiceLocator.Current.GetInstance<IVirtualDesktopManager>().SaveCurrentDesktop();
            SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().SaveCurrentDesktop();
            UserPersonalisation up = new UserPersonalisation();
            up.SaveCurrentDesktop("VirtualDesktop01.xaml");
        }

        /// <summary>
        /// Handles the save all desktops command action
        /// </summary>
        private void OnSaveAllDesktops()
        {
            //ServiceLocator.Current.GetInstance<IVirtualDesktopManager>().SaveAllDesktops();
            SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().SaveAllDesktops();
        }

        /// <summary>
        /// Handles the shutdown command action
        /// </summary>
        private void OnShutdown()
        {
            Logger.Debug("Finalizando la sesión");
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Closes the session
        /// </summary>
        private void OnCloseSession()
        {
            
        }

        /// <summary>
        /// Maximizes the window.
        /// </summary>
        private void OnMaximizeWindow()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }

            Logger.Debug("shating down ({0})", this.WindowState);
        }

        /// <summary>
        /// Handles the minimize window command action
        /// </summary>
        private void OnMinimizeWindow()
        {
            this.WindowState = WindowState.Minimized;
        }

        private void OnShowAboutBoxCommand()
        {
            
        }

        #endregion

        #region · Observer Initialization ·

        private void InitializeObservers()
        {
            Logger.Debug("Inicializing observers");
            this.WindowState = WindowState.Maximized;
            // Authentication Observer
            //this.authenticationObserver = new ChannelObserver<AuthenticationInfo>(
            //    (l) => OnAuthenticationAction(l));

            // Subscribe on the UI Thread
            //this.authenticationObserver.Subscribe(ThreadOption.BackgroundThread);

            //Active desktop changed observer
            this.activeDesktopObserver = new ChannelObserver<ActiveDesktopChangedInfo>(
                (l) => OnActiveDesktopChanged(l));

            // Subscribe on the UI Thread
            this.activeDesktopObserver.Subscribe(ThreadOption.UIThread);

            // Navigation observers

            // Navigated observer
            //this.navigatedObserver = new ChannelObserver<NavigatedInfo>(
            //    (l) => OnNavigated(l));

            //this.navigatedObserver.Subscribe(ThreadOption.BackgroundThread);

        }

        #endregion

        #region · Observer Actions ·

        private void OnAuthenticationAction(AuthenticationInfo info)
        {
            switch (info.Action)
            {
                case AuthenticationAction.LogOn:
                    break;

                //case AuthenticationAction.LoggedIn:
                //    this.Invoke(() => { this.UserName = info.UserId; });
                //    break;

                //case AuthenticationAction.LogOut:
                //    this.Invoke(() => { this.UserName = info.UserId; });
                //    break;
            }
        }

        private void OnActiveDesktopChanged(ActiveDesktopChangedInfo info)
        {
            Logger.Debug("Cambiando el escritorio activo");

            //this.RaisePropertyChanged(() => ActiveWindows);
            this.NotifyPropertyChanged(() => ActiveWindows);
        }
        private void OnActiveDesktopChanged()
        {
            Logger.Debug("Cambiando el escritorio activo");

            //this.RaisePropertyChanged(() => ActiveWindows);
            this.NotifyPropertyChanged(() => ActiveWindows);
        }
        private void OnNavigated(NavigatedInfo info)
        {

            this.CreateRecentNavigationEntry(info);
        }

        #endregion

        #region · Windows 7 Taskbar ·

        private void CreateRecentNavigationEntry(NavigatedInfo value)
        {
            //if (value.Request.NavigationMode == NavigateMode.New)
            //{
            //    this.Dispatcher.BeginInvoke(
            //        (Action)delegate
            //        {
            //            if (App.RunningOnWin7)
            //            {
            //                JumpList jl = JumpList.GetJumpList(Application.Current);

            //                if (jl != null)
            //                {
            //                    if (jl.JumpItems.Count >= 10)
            //                    {
            //                        jl.JumpItems.Clear();
            //                    }

            //                    var q = jl.JumpItems.OfType<JumpTask>().Where(t => t.Arguments.Equals(value.Request.RequestUrl));

            //                    if (q.Count() == 0)
            //                    {
            //                        jl.JumpItems.Add
            //                        (
            //                            new JumpTask
            //                            {
            //                                CustomCategory = "Recent",
            //                                Title = value.Title,
            //                                Arguments = value.Request.RequestUrl,
            //                                IconResourcePath = null,
            //                                IconResourceIndex = -1,
            //                                Description = null,
            //                                WorkingDirectory =
            //                                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            //                            }
            //                        );

            //                        jl.Apply();
            //                    }
            //                }
            //            }
            //        }, DispatcherPriority.Background);
            //}
        }

        #endregion
    }
}

