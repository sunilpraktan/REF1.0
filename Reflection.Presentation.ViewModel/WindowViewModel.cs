using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Reflection.Presentation.Core.ViewModel;
using Reflection.Presentation.Core.Windows;
using NLog;
using GalaSoft.MvvmLight.Command;
using System.Timers;
using System.Windows.Threading;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows;
using Reflection.Presentation.Common;

namespace Reflection.Presentation.ViewModel
{
    public abstract class WindowViewModel<TEntity>
        : NavigationViewModel, IWindowViewModel where TEntity : class, new()
    {
        public bool ErrorExist;
        //public bool is_save;
        //public bool is_remove;
        //public bool is_discard;
        //public bool is_view;
        //public bool is_print;
        //public bool is_mail;

        public bool Add;
        public bool Edit;
        public bool Delete;
        public bool Discard;
        public bool View;
        public bool Print;
        public bool Mail;


        #region · Logger ·

        private static Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region · Inner Types ·

        [Serializable]
        protected enum InquiryActionResultType
        {
            DataFetched,
            RequestedNew,
            DataNotFound
        }

        protected sealed class InquiryActionResult<TResult>
            where TResult : class
        {
            #region · Properties ·

            public TResult Data
            {
                get;
                set;
            }

            public InquiryActionResultType Result
            {
                get;
                set;
            }

            #endregion

            #region · Constructors ·

            public InquiryActionResult()
            {
            }

            #endregion
        }

        #endregion

        #region · PropertyChangedEventArgs Cached Instances ·

        private static readonly PropertyChangedEventArgs ViewModeChangedArgs = CreateArgs<WindowViewModel<TEntity>>(x => x.ViewMode);
        private static readonly PropertyChangedEventArgs StatusMessageChangedArgs = CreateArgs<WindowViewModel<TEntity>>(x => x.StatusMessage);
        private static readonly PropertyChangedEventArgs NotificationMessageChangedArgs = CreateArgs<WindowViewModel<TEntity>>(x => x.NotificationMessage);

        #endregion

        #region · Events ·

        /// <summary>
        /// Occurs when view mode is changed.
        /// </summary>
        public event EventHandler ViewModeChanged;

        #endregion

        #region · Fields ·

        private TEntity originalEntity;
        private string statusMessage;
        private string notificationMessage;
        private TEntity entity;
        private ViewModeType viewMode;
        private PropertyStateCollection<TEntity> propertyStates;

        #region · Commands ·

        //private RelayCommand inquiryCommand;
        private RelayCommand createDataCommand;
        private RelayCommand saveDataCommand;
        private RelayCommand exportDataCommand;
        private RelayCommand removeDataCommand;
        private RelayCommand discardCommand;
        private RelayCommand printCommand;
        private RelayCommand flipCommand;
        private RelayCommand helpCommand;
        private RelayCommand fevoriteCommand;


        #endregion

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets the property state collection
        /// </summary>
        public PropertyStateCollection<TEntity> PropertyStates
        {
            get
            {
                if (this.propertyStates == null)
                {
                    this.propertyStates = new PropertyStateCollection<TEntity>();
                }

                return this.propertyStates;
            }
        }

        /// <summary>
        /// Gets or sets the state of the smart part.
        /// </summary>
        /// <value>The state of the smart part.</value>
        public ViewModeType ViewMode
        {
            get { return this.viewMode; }
            set
            {
                if (this.viewMode != value)
                {
                    this.viewMode = value;
                    try
                    {
                        this.OnViewModeChanged();
                    }
                    catch
                    {
#warning TODO: This is done to prevent DataGrid erroros when discarding changes on new records
                    }
                }
            }
        }


        /// <summary>
        /// Gets or sets the status message text
        /// </summary>
        public string StatusMessage
        {
            get { return this.statusMessage; }
            set
            {
                if (this.statusMessage != value)
                {
                    this.statusMessage = value;
                    this.NotifyPropertyChanged(StatusMessageChangedArgs);
                }
            }
        }

        /// <summary>
        /// Gets or sets the notification message text
        /// </summary>
        public string NotificationMessage
        {
            get { return this.notificationMessage; }
            set
            {
                if (this.notificationMessage != value)
                {
                    this.notificationMessage = value;
                    this.NotifyPropertyChanged(NotificationMessageChangedArgs);
                }
            }
        }

        #endregion

        #region · Protected Properties ·

        /// <summary>
        /// Gets or sets the data model.
        /// </summary>
        /// <value>The data model.</value>
        protected TEntity Entity
        {
            get { return this.entity; }
            private set
            {
                if (!Object.ReferenceEquals(this.entity, value))
                {
                    this.entity = value;
                }
            }
        }

        protected TEntity OriginalEntity
        {
            get { return this.originalEntity; }
            set { this.originalEntity = value; }
        }

        #endregion

        #region · Constructors ·

        protected WindowViewModel()
            : base()
        {
            this.InitializePropertyStates();

            this.Entity = new TEntity();
            this.ViewMode = ViewModeType.ViewOnly;
            //CinchSingleClickCommand = new ICommand<object, EventToCommandArgs>(CanExecuteSingleCinch, ExecuteSingleCinch);
            //CinchDoubleClickCommand = new ICommand<object, EventToCommandArgs>(CanExecuteDoubleCinch, ExecuteDoubleCinch);
            //myClickWaitTimer.Stop();
        }
        #endregion

        #region · Command Actions ·

        #region · Inquiry ·


        protected virtual bool CanCreateData()
        {
            return true; //(this.ViewMode == ViewModeType.ViewOnly);
        }

        //protected void OnInquiryData()
        //{
        //    InquiryActionResult<TEntity> result = new InquiryActionResult<TEntity>
        //    {
        //        Result = InquiryActionResultType.DataNotFound
        //    };

        //    this.ViewMode = ViewModeType.Busy;
        //    this.StatusMessage = "Obteniendo datos, espere por favor ...";

        //    Task task = Task.Factory.StartNew
        //    (
        //        (o) =>
        //        {
        //            Logger.Debug("Obteniendo datos '{0}'", this.Entity.ToString());

        //            this.OnInquiryAction(result);
        //        }, result
        //    );

        //    task.ContinueWith
        //    (
        //        (t) =>
        //        {
        //            Logger.Debug("Error al obtener datos '{0}'", t.Exception.InnerException.ToString());

        //            this.OnInquiryActionFailed();

        //            Exception exception = null;
        //            this.OriginalEntity = null;

        //            if (t.Exception.InnerException != null)
        //            {
        //                exception = t.Exception.InnerException;
        //            }
        //            else
        //            {
        //                exception = t.Exception;
        //            }

        //            this.NotificationMessage = exception.Message;
        //        },
        //        CancellationToken.None,
        //        TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.AttachedToParent,
        //        TaskScheduler.FromCurrentSynchronizationContext()
        //    );

        //    task.ContinueWith
        //    (
        //        _ =>
        //        {
        //            Logger.Debug("Datos obtenidos correctamente '{0}'", this.Entity.ToString());

        //            this.StatusMessage = null;
        //            this.OnInquiryActionComplete(result);
        //        },
        //        CancellationToken.None,
        //        TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.AttachedToParent,
        //        TaskScheduler.FromCurrentSynchronizationContext()
        //    );
        //}

        protected void OnCreateData()
        {
            InquiryActionResult<TEntity> result = new InquiryActionResult<TEntity>
            {
                Result = InquiryActionResultType.DataNotFound
            };

            this.ViewMode = ViewModeType.Busy;
            this.StatusMessage = "Loading data, please wait ...";

            this.OnCreateAction(result);


        }
        //protected abstract void OnInquiryAction(InquiryActionResult<TEntity> result);
        protected abstract void OnSaveAction(InquiryActionResult<TEntity> result);
        //protected abstract void OnExportAction(InquiryActionResult<TEntity> result);
        protected abstract void OnCreateAction(InquiryActionResult<TEntity> result);
        protected abstract void OnRemoveAction(InquiryActionResult<TEntity> result);
        protected abstract void OnDiscardAction(InquiryActionResult<TEntity> result);
        protected abstract void OnPrintAction(InquiryActionResult<TEntity> result);
        protected abstract void OnFlipAction(InquiryActionResult<TEntity> result);
        protected abstract void OnHelpAction(InquiryActionResult<TEntity> result);
        protected abstract void OnFevoriteAction(InquiryActionResult<TEntity> result);


        protected virtual void OnInquiryActionComplete(InquiryActionResult<TEntity> result)
        {
            switch (result.Result)
            {
                case InquiryActionResultType.DataNotFound:
                    this.OriginalEntity = null;

                    this.ResetDataModel();

                    this.ViewMode = ViewModeType.ViewOnly;
                    break;

                case InquiryActionResultType.RequestedNew:
                    throw new InvalidOperationException("Requested New is not valid on this type of ViewModel");

                case InquiryActionResultType.DataFetched:
                    this.ResetDataModel(result.Data);

                    this.OriginalEntity = this.entity;
                    this.ViewMode = ViewModeType.ViewOnly;
                    break;
            }
        }

        protected virtual void OnInquiryActionFailed()
        {
            this.ViewMode = ViewModeType.ViewOnly;
        }

        #endregion

        #endregion

        #region · Overriden Methods ·

        /// <summary>
        /// Called when the related view is being closed.
        /// </summary>
        public override void Close()
        {
            Logger.Debug("Cerrar ventana '{0}'", this.GetType());

            if (this.originalEntity != null)
            {
                this.originalEntity = null;
            }
            if (this.entity != null)
            {
                this.entity = null;
            }
            if (this.propertyStates != null)
            {
                this.propertyStates.Clear();
                this.propertyStates = null;
            }

            //this.inquiryCommand = null;
            this.statusMessage = null;
            this.notificationMessage = null;

            base.Close();
        }

        #endregion

        #region · DataModel Reset Methods ·

        protected void ResetDataModel()
        {
            Logger.Debug("Resetar model '{0}'", this.GetType());
            this.ResetDataModel(new TEntity());
            Logger.Debug("Model reseteado '{0}'", this.GetType());
        }

        protected virtual void ResetDataModel(TEntity model)
        {
            this.OnResetingDataModel(this.Entity, model);

            this.OriginalEntity = null;
            this.Entity = model;

            this.OnResetedDataModel(model);
        }

        protected virtual void OnResetingDataModel(TEntity oldModel, TEntity newModel)
        {
        }

        protected virtual void OnResetedDataModel(TEntity newModel)
        {
            this.NotifyAllPropertiesChanged();
        }

        #endregion

        #region · Protected Methods ·

        protected virtual void InitializePropertyStates()
        {
        }

        protected virtual void OnViewModeChanged()
        {
            if (this.ViewModeChanged != null)
            {
                this.ViewModeChanged(this, new EventArgs());
            }

            this.NotifyPropertyChanged(ViewModeChangedArgs);
        }

        protected virtual void UpdateAllowedUserActions()
        {

        }

        protected override void NotifyPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args != StatusMessageChangedArgs)
            {
                this.StatusMessage = null;
            }
            if (args != NotificationMessageChangedArgs)
            {
                this.NotificationMessage = null;
            }

            this.UpdateAllowedUserActions();
            base.NotifyPropertyChanged(args);
        }

        #endregion



        /// <summary>
        /// Gets the inquiry data command
        /// </summary>
        //public RelayCommand InquiryCommand
        //{
        //    get
        //    {
        //        if (this.inquiryCommand == null)
        //        {
        //            this.inquiryCommand = new RelayCommand
        //            (
        //                () => OnInquiryData(),
        //                () => CanInquiryData()
        //            );
        //        }

        //        return this.inquiryCommand;
        //    }
        //}
        protected virtual bool CanInquiryData()
        {
            return true;// (this.ViewMode == ViewModeType.ViewOnly);
        }
        public RelayCommand CreateDataCommand
        {
            get
            {
                if (this.createDataCommand == null)
                {
                    this.createDataCommand = new RelayCommand
                    (
                        () => OnCreateData(),
                        () => CanCreateData()
                    );
                }

                return this.createDataCommand;
            }
        }
        public RelayCommand SaveDataCommand
        {
            get
            {
                if (this.saveDataCommand == null)
                {
                    this.saveDataCommand = new RelayCommand
                    (
                        () => OnSaveData(),
                        () => CanSaveData()
                    );
                }

                return this.saveDataCommand;
            }
        }
        internal bool _IsSaveValid;
        public bool IsSaveValid
        {
            get { return _IsSaveValid; }
            set
            {
                _IsSaveValid = value;
            }
        }
        protected virtual bool CanSaveData()
        {
            //return true;// (this.ViewMode == ViewModeType.ViewOnly);
            //-----------------------------------------
            //if (Add == false) // Temparory If loop Commented and return true in every case by Sunil on 25/01/2018 as material issue not working save button.
            //    return !ErrorExist;
            //else
                return true;
            //-----------------------------------------

            //if (ErrorExist == false )
            //{
            //    if (Add == true )
            //    {
            //        return true;
            //    }
            //    else 
            //        return false;
            //}
            //else
            //    return false;
            //-----------------------------------------
            //    if (ErrorExist == false && Add == true)
            //    {               
            //        return true;               
            //    }
            //    else if (ErrorExist == false && Edit == true)
            //    {
            //        return true;
            //    }
            //    return false;
        }

        protected void OnSaveData()
        {
            if (Mouse.OverrideCursor == null)
            {
                CursorControl.SetBusyState();
                InquiryActionResult<TEntity> result = new InquiryActionResult<TEntity>
                {
                    Result = InquiryActionResultType.DataNotFound
                };

                this.ViewMode = ViewModeType.Busy;
                this.StatusMessage = "Saving changes, please wait ...";

                this.OnSaveAction(result);
            }
        }
        public RelayCommand ExportDataCommand
        {
            get
            {
                if (this.exportDataCommand == null)
                {
                    this.exportDataCommand = new RelayCommand
                    (
                        () => OnExportData(),
                        () => CanExportData()
                    );
                }

                return this.exportDataCommand;
            }
        }
        protected virtual bool CanExportData()
        {
            return true;
        }
        protected void OnExportData()
        {
            //InquiryActionResult<TEntity> result = new InquiryActionResult<TEntity>
            //{
            //    Result = InquiryActionResultType.DataNotFound
            //};

            //this.ViewMode = ViewModeType.Busy;
            //this.StatusMessage = "Loading data, please wait ...";

            //this.OnExportAction(result);
        }



        public RelayCommand RemoveDataCommand
        {
            get
            {
                if (this.removeDataCommand == null)
                {
                    this.removeDataCommand = new RelayCommand
                    (
                        () => OnRemoveData(),
                        () => CanRemoveData()
                    );
                }

                return this.removeDataCommand;
            }
        }
        protected virtual bool CanRemoveData()
        {
            //return Delete ; //(this.ViewMode == ViewModeType.ViewOnly);
            return true;
        }
        protected void OnRemoveData()
        {
            InquiryActionResult<TEntity> result = new InquiryActionResult<TEntity>
            {
                Result = InquiryActionResultType.DataNotFound
            };

            this.ViewMode = ViewModeType.Busy;
            this.StatusMessage = "Loading data, please wait ...";

            this.OnRemoveAction(result);
        }

        public RelayCommand DiscardCommand
        {
            //get { throw new NotImplementedException(); }
            get
            {
                if (this.discardCommand == null)
                {
                    this.discardCommand = new RelayCommand
                    (
                        () => OnDiscardData(),
                        () => CanDiscardData()
                    );
                }

                return this.discardCommand;
            }
        }
        protected virtual bool CanDiscardData()
        {
            // return Discard; //(this.ViewMode == ViewModeType.ViewOnly);
            return true;
        }
        protected void OnDiscardData()
        {
            InquiryActionResult<TEntity> result = new InquiryActionResult<TEntity>
            {
                Result = InquiryActionResultType.DataNotFound
            };

            this.ViewMode = ViewModeType.Busy;
            this.StatusMessage = "Loading data, please wait ...";

            this.OnDiscardAction(result);
        }
        public RelayCommand PrintCommand
        {
            get
            {
                if (this.printCommand == null)
                {
                    this.printCommand = new RelayCommand
                    (
                        () => OnPrintReport(),
                        () => CanPrintReport()
                    );
                }

                return this.printCommand;
            }
        }
        protected void OnPrintReport()
        {
            if (Mouse.OverrideCursor == null)
            {
                CursorControl.SetBusyState();
                InquiryActionResult<TEntity> result = new InquiryActionResult<TEntity>
                {
                    Result = InquiryActionResultType.DataNotFound
                };

                this.ViewMode = ViewModeType.Busy;
                this.StatusMessage = "Loading data, please wait ...";

                this.OnPrintAction(result);
            }
        }
        protected virtual bool CanPrintReport()
        {
            // return Print; //(this.ViewMode == ViewModeType.ViewOnly);
            return true;
        }
        public RelayCommand FlipCommand
        {
            //get { throw new NotImplementedException(); }
            get
            {
                if (this.flipCommand == null)
                {
                    this.flipCommand = new RelayCommand
                    (
                        () => OnFlipCommand(),
                        () => CanFlipCommand()
                    );
                }

                return this.flipCommand;
            }

        }

        protected void OnFlipCommand()
        {
            InquiryActionResult<TEntity> result = new InquiryActionResult<TEntity>
            {
                Result = InquiryActionResultType.DataNotFound
            };

            this.ViewMode = ViewModeType.Busy;
            this.StatusMessage = "Loading data, please wait ...";

            this.OnFlipAction(result);


        }
        protected virtual bool CanFlipCommand()
        {
            // return Print; //(this.ViewMode == ViewModeType.ViewOnly);
            return true;
        }

        public RelayCommand HelpCommand
        {
            //get { throw new NotImplementedException(); }
            get
            {
                return this.helpCommand;
            }
        }

        public RelayCommand FevoriteCommand
        {
            get
            {
                if (this.fevoriteCommand == null)
                {
                    this.fevoriteCommand = new RelayCommand
                    (
                        () => OnFevoriteCommand(),
                        () => CanFevoriteCommand()
                    );
                }

                return this.fevoriteCommand;
            }
        }
        #region OnRefreshCommand
        protected abstract void OnRefreshCommand(InquiryActionResult<TEntity> result);
        private RelayCommand refreshCommand;
        public RelayCommand RefreshCommand
        {
            get
            {
                if (this.refreshCommand == null)
                {
                    this.refreshCommand = new RelayCommand
                    (
                        () => OnRefreshCommand(),
                        () => CanRefreshCommand()
                    );
                }

                return this.refreshCommand;
            }
        }
        protected void OnRefreshCommand()
        {
            InquiryActionResult<TEntity> result = new InquiryActionResult<TEntity>
            {
                Result = InquiryActionResultType.DataNotFound
            };

            this.ViewMode = ViewModeType.Busy;
            this.StatusMessage = "Loading data, please wait ...";

            this.OnRefreshCommand(result);
        }
        protected virtual bool CanRefreshCommand()
        {
            return true;
        }
        #endregion
        #region OnLedgerViewCommand
        protected abstract void OnLedgerViewCommand(InquiryActionResult<TEntity> result);
        private RelayCommand ledgerViewCommand;
        public RelayCommand LedgerViewCommand
        {
            get
            {
                if (this.ledgerViewCommand == null)
                {
                    this.ledgerViewCommand = new RelayCommand
                    (
                        () => OnLedgerViewCommand(),
                        () => CanLedgerViewCommand()
                    );
                }

                return this.ledgerViewCommand;
            }
        }
        protected void OnLedgerViewCommand()
        {
            InquiryActionResult<TEntity> result = new InquiryActionResult<TEntity>
            {
                Result = InquiryActionResultType.DataNotFound
            };

            this.ViewMode = ViewModeType.Busy;
            this.StatusMessage = "Loading data, please wait ...";

            this.OnLedgerViewCommand(result);
        }
        protected virtual bool CanLedgerViewCommand()
        {
            return true;
        }
        #endregion
        #region OnValidateCommand
        protected abstract void OnValidateCommand(InquiryActionResult<TEntity> result);
        private RelayCommand validateCommand;
        public RelayCommand ValidateCommand
        {
            get
            {
                if (this.validateCommand == null)
                {
                    this.validateCommand = new RelayCommand
                    (
                        () => OnValidateCommand(),
                        () => CanValidateCommand()
                    );
                }

                return this.validateCommand;
            }
        }
        protected void OnValidateCommand()
        {
            InquiryActionResult<TEntity> result = new InquiryActionResult<TEntity>
            {
                Result = InquiryActionResultType.DataNotFound
            };

            this.ViewMode = ViewModeType.Busy;
            this.StatusMessage = "Loading data, please wait ...";

            this.OnValidateCommand(result);
        }
        protected virtual bool CanValidateCommand()
        {
            return true;
        }
        #endregion
        #region OnTraceCommand
        protected abstract void OnTraceCommand(InquiryActionResult<TEntity> result);
        private RelayCommand traceCommand;
        public RelayCommand TraceCommand
        {
            get
            {
                if (this.traceCommand == null)
                {
                    this.traceCommand = new RelayCommand
                    (
                        () => OnTraceCommand(),
                        () => CanTraceCommand()
                    );
                }
                return this.traceCommand;
            }
        }
        protected void OnTraceCommand()
        {
            InquiryActionResult<TEntity> result = new InquiryActionResult<TEntity>
            {
                Result = InquiryActionResultType.DataNotFound
            };

            this.ViewMode = ViewModeType.Busy;
            this.StatusMessage = "Loading data, please wait ...";

            this.OnTraceCommand(result);
        }
        protected virtual bool CanTraceCommand()
        {
            return true;
        }
        #endregion
        #region OnMailCommand
        protected abstract void OnMailCommand(InquiryActionResult<TEntity> result);
        private RelayCommand mailCommand;
        public RelayCommand MailCommand
        {
            get
            {
                if (this.mailCommand == null)
                {
                    this.mailCommand = new RelayCommand
                    (
                        () => OnMailCommand(),
                        () => CanMailCommand()
                    );
                }
                return this.mailCommand;
            }
        }
        protected void OnMailCommand()
        {
            InquiryActionResult<TEntity> result = new InquiryActionResult<TEntity>
            {
                Result = InquiryActionResultType.DataNotFound
            };

            this.ViewMode = ViewModeType.Busy;
            this.StatusMessage = "Loading data, please wait ...";

            this.OnMailCommand(result);
        }
        protected virtual bool CanMailCommand()
        {
            return true;
        }
        #endregion

        protected void OnFevoriteCommand()
        {
            InquiryActionResult<TEntity> result = new InquiryActionResult<TEntity>
            {
                Result = InquiryActionResultType.DataNotFound
            };

            this.ViewMode = ViewModeType.Busy;
            this.StatusMessage = "Loading data, please wait ...";

            this.OnFevoriteAction(result);


        }
        protected virtual bool CanFevoriteCommand()
        {
            // return Print; //(this.ViewMode == ViewModeType.ViewOnly);
            return true;
        }

        //Code by Kalpesh
        //private static DispatcherTimer myClickWaitTimer =
        //    new DispatcherTimer(
        //            new TimeSpan(0, 0, 0, 0, 150),
        //            DispatcherPriority.Background,
        //            mouseWaitTimer_Tick,
        //            Dispatcher.CurrentDispatcher);

        //private static void mouseWaitTimer_Tick(object sender, EventArgs e)
        //{
        //    myClickWaitTimer.Stop();

        //    Debug.WriteLine("Single Click Executed");//PerformActionA
        //}

        //public ICommand CinchSingleClickCommand { get; private set; }
        //public ICommand CinchDoubleClickCommand { get; private set; }
  
        //private void ExecuteDoubleCinch(EventToCommandArgs obj)
        //{
        //    if (obj.EventArgs is MouseEventArgs)
        //    {
        //        myClickWaitTimer.Stop();
        //        Debug.WriteLine("Double Click Executed");//PerformActionB
        //        var mouseEvent = obj.EventArgs as MouseEventArgs;
        //        mouseEvent.Handled = true;
        //    }
        //}

        //private bool CanExecuteDoubleCinch(object arg)
        //{
        //    return true;
        //}

        //private void ExecuteSingleCinch(EventToCommandArgs obj)
        //{
        //    if (!(obj.EventArgs is MouseEventArgs))
        //    {
        //        myClickWaitTimer.Start();
        //        var mouseEvent = obj.EventArgs as RoutedEventArgs;
        //        mouseEvent.Handled = true;
        //    }
        //}

        //private bool CanExecuteSingleCinch(object arg)
        //{
        //    return true;
        //}

    }
}
