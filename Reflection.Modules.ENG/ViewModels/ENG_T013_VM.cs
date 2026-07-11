using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Reflection.BusinessEntity.ENG;
using Reflection.BusinessEntity.ADM;
using System.Collections.Generic;

namespace Reflection.Modules.ENG.ViewModels
{
    public class ENG_T013_VM : WorkspaceViewModel<ENG_T005>
    {
        bool NewRecord = true;

        WebServiceRepository<ENG_T005> REPO = new WebServiceRepository<ENG_T005>();
        WebServiceRepository<MC_ENG_BE> REPO_MC = new WebServiceRepository<MC_ENG_BE>();
        WebServiceRepository<MC_ENG_BE> REPO_MC_TEMP = new WebServiceRepository<MC_ENG_BE>();
        WebServiceRepository<MC_ADM_M0126> REPO_MC_VC = new WebServiceRepository<MC_ADM_M0126>();
        //WebServiceRepository<MC_ADM_M0126> REPO_MC_VC_TEMP = new WebServiceRepository<MC_ADM_M0126>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region Enumerables Initialization

        private IEnumerable _VALUE_LIST;
        public IEnumerable VALUE_LIST
        {
            get { return _VALUE_LIST; }
            set
            {
                _VALUE_LIST = value;
                RaisePropertyChanged("VALUE_LIST");
            }
        }

        #endregion

        #region Relay Command Decleration
        public RelayCommand<object> cmdAdd { get; private set; }
        public RelayCommand<object> cmdSave { get; private set; }
        public RelayCommand<object> cmdConvertDays { get; private set; }

        private string _inputDays = string.Empty;

        private string _outputResult = string.Empty;
        #endregion

        #region Variable Decleration
        IShowMessageViewService sms;
        private MC_ENG_BE _MC;
        public MC_ENG_BE MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MC_ENG_BE _MC_TEMP;
        public MC_ENG_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); }
        }
        private ENG_T005 _MasterEntity;
        public ENG_T005 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                }
            }
        }

        private ObservableCollection<ENG_T005_A> _OperationEntity;
        public ObservableCollection<ENG_T005_A> OperationEntity
        {
            get { return _OperationEntity; }
            set
            {
                if (_OperationEntity != value)
                {
                    _OperationEntity = value;
                    //OperationEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
                    RaisePropertyChanged("OperationEntity");
                }
            }
        }


        private ObservableCollection<ENG_T005_B> _CharEntity;
        public ObservableCollection<ENG_T005_B> CharEntity
        {
            get { return _CharEntity; }
            set
            {
                if (_CharEntity != value)
                {
                    _CharEntity = value;
                    CharEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForCharEntity);
                    RaisePropertyChanged("CharEntity");
                }
            }
        }

        private ENG_T005_A _ENG_T005_A_OBJ;
        public ENG_T005_A ENG_T005_A_OBJ
        {
            get
            {
                return _ENG_T005_A_OBJ;
            }
            set
            {
                if (_ENG_T005_A_OBJ != value)
                {
                    _ENG_T005_A_OBJ = value;
                    RaisePropertyChanged("ENG_T005_A_OBJ");
                }
            }
        }

        private ADM_M0126 _CLASS_OBJ;
        public ADM_M0126 CLASS_OBJ // Class Object
        {
            get
            { return _CLASS_OBJ; }
            set
            {
                if (_CLASS_OBJ != value)
                {
                    _CLASS_OBJ = value;
                    RaisePropertyChanged("CLASS_OBJ");
                }
            }
        }
        private ADM_M0127 _CLASS_CHAR_OBJ;
        public ADM_M0127 CLASS_CHAR_OBJ // Class Char object from List
        {
            get
            { return _CLASS_CHAR_OBJ; }
            set
            {
                if (_CLASS_CHAR_OBJ != value)
                {
                    _CLASS_CHAR_OBJ = value;
                    RaisePropertyChanged("CLASS_CHAR_OBJ");
                    FilterClassCharValues(_CLASS_CHAR_OBJ);
                }
            }
        }
        private ObservableCollection<ADM_M0127> _VCEntity;
        public ObservableCollection<ADM_M0127> VCEntity
        {
            get { return _VCEntity; }
            set
            {
                if (_VCEntity != value)
                {
                    _VCEntity = value; RaisePropertyChanged("VCEntity");
                }
            }
        }
        // This is Master Object of main char with ref_class and vc_code null. it will get use to add new char with blank default values which needs to be added on this screen for VC.
        private ENG_T005_B _ENG_T005_B_OBJ_M;
        public ENG_T005_B ENG_T005_B_OBJ_M
        {
            get
            {
                return _ENG_T005_B_OBJ_M;
            }
            set
            {
                if (_ENG_T005_B_OBJ_M != value)
                {
                    _ENG_T005_B_OBJ_M = value;
                    RaisePropertyChanged("ENG_T005_B_OBJ_M");
                }
            }
        }
        private ENG_T005_B _ENG_T005_B_OBJ;
        public ENG_T005_B ENG_T005_B_OBJ
        {
            get
            {
                return _ENG_T005_B_OBJ;
            }
            set
            {
                if (_ENG_T005_B_OBJ != value)
                {
                    _ENG_T005_B_OBJ = value; RaisePropertyChanged("ENG_T005_B_OBJ");
                    LOAD_VC_INFO(_ENG_T005_B_OBJ);
                }
            }
        }

        private STD_LIST_BE _STD_LIST_OBJ;
        public STD_LIST_BE STD_LIST_OBJ
        {
            get
            {
                return _STD_LIST_OBJ;
            }
            set
            {
                if (_STD_LIST_OBJ != value)
                {
                    _STD_LIST_OBJ = value;
                    RaisePropertyChanged(nameof(STD_LIST_OBJ));
                }
            }
        }

        

        private MC_ADM_M0126 _MC_VC;
        public MC_ADM_M0126 MC_VC
        {
            get { return _MC_VC; }
            set { _MC_VC = value; RaisePropertyChanged("MC_VC"); }
        }

        private IEnumerable _VALUE_COLLECTION;
        public IEnumerable VALUE_COLLECTION
        {
            get { return _VALUE_COLLECTION; }
            set
            {
                _VALUE_COLLECTION = value;

                RaisePropertyChanged("VALUE_COLLECTION");
            }
        }
        public string InputDays
        {
            get => _inputDays;
            set
            {
                _inputDays = value;
                RaisePropertyChanged(nameof(_inputDays));
            }
        }
        public string OutputResult
        {
            get => _outputResult;
            set
            {
                _outputResult = value;
                RaisePropertyChanged(nameof(OutputResult));
            }
        }
        #endregion

        #region Constructor
        public ENG_T013_VM(string ts_code, STD_LIST_BE STD_OBJ) : base()
        {
            STD_LIST_OBJ = new STD_LIST_BE();
            STD_LIST_OBJ = STD_OBJ;
            ENG_T005_B_OBJ_M = new ENG_T005_B();
            VCEntity = new ObservableCollection<ADM_M0127>();
            CLASS_OBJ = new ADM_M0126();
            CLASS_CHAR_OBJ = new ADM_M0127();
            MC_VC = new MC_ADM_M0126();
            MasterEntity = new ENG_T005();
            CharEntity = new ObservableCollection<ENG_T005_B>();
            OperationEntity = new ObservableCollection<ENG_T005_A>();
            MC = new MC_ENG_BE();
            MC_TEMP = new MC_ENG_BE();
            sms = this.GetViewService<IShowMessageViewService>();
            CharEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForCharEntity);

            CommandInitialisation();

            if (STD_LIST_OBJ != null)
            {
                if (STD_LIST_OBJ.request_type == "VC" && STD_LIST_OBJ.request == "VC")
                {
                    LOAD_DOCUMENT(STD_LIST_OBJ);
                }
            }
        }
        #endregion

        #region User Define Methods

        #region CharEntity Methods
        private void CommandInitialisation()
        {
            #region Relay Command Initalization
            cmdAdd = new RelayCommand<object>(items => { if (items == null) { return; } AddVC(items); });
            cmdSave = new RelayCommand<object>(items => { if (items == null) { return; } SaveVC(items); });
            cmdConvertDays = new RelayCommand<object>(items => { if (items == null) { return; } ConvertDays(items); });
            #endregion
        }
        private void LoadInitialData(STD_LIST_BE STD_OBJ)
        {
            //try
            //{

            //    string Request = "LOAD_INI_VC" + "!@" + AppSessionState.client + "!@" + STD_OBJ.comp_code + "!@" + STD_OBJ.location_id + "!@" + STD_OBJ.doc_cat + "!@" + STD_OBJ.type_code; // type_code=task_list_type_vm
            //    MC = REPO_MC.GetDataWithReturnDomainObject<MC_ENG_BE>(MC, Request, "ENG_T005_BL", "ENG", "LoadInitialData", 0, "");

            //    #region Enumerables & AutoSuggest Initalization

            //    VALUE_LIST = MC.VCHAR_LIST;

            //}
            //catch (Exception ex)
            //{
            //    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            //}
        }
        private bool Validation()
        {
           
            if (OperationEntity.Count < 1)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Operation Code In Operation Tab");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        private void Logging()
        {
            MasterEntity.ts_code = "TS99";
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private void AddVC(object InputValue)
        {
            try
            {
                if (ValidationVC() == true)
                {
                    MC_VC.VC_LIST = new List<ADM_M0126>();
                    CLASS_OBJ.short_text = "";
                    foreach (var item in VCEntity) // Assign the rage description to vc code and char
                    {
                        item.char_value = item.char_value.Trim();
                        if(item.ind_interval=="Y" || item.ind_interval == "1" || item.ind_interval == "y")
                        {
                            item.char_value = item.char_value.Replace(" ", "");
                        }
                        CLASS_OBJ.short_text = (CLASS_OBJ.short_text ?? " - ") + item.char_value;
                    }
                    CLASS_OBJ.short_text = (CLASS_OBJ.short_text ?? "").TrimStart(',', '-','/');
                    CLASS_OBJ.short_text = UIServices.RemoveDuplicates(CLASS_OBJ.short_text);
                    

                    MC_VC.VC_LIST.Add(CLASS_OBJ);
                    MC_VC.VC_VALUE_LIST = VCEntity;
                    MC_VC = REPO_MC_VC.SaveWithReturnDomainObject<MC_ADM_M0126>(MC_VC, "ADM_M0126_BL", "ADM");
                    if(MC_VC!= null)
                    {
                        if (MC_VC.VC_LIST.Count > 0)
                        {
                            var obj_vc = CharEntity.Where(x => x.vc_code == MC_VC.VC_LIST[0].vc_code).FirstOrDefault();
                            if (obj_vc == null) // If not exists for this char
                            {
                                ENG_T005_B NEW_OBJ = new ENG_T005_B();
                                ENG_T005_B_OBJ_M.CopyPropertiesTo(NEW_OBJ); // assign template to new row with vc_code assignment.
                                NEW_OBJ.vc_code = MC_VC.VC_LIST[0].vc_code; // assign newly created vc_code
                                CLASS_OBJ = MC_VC.VC_LIST[0];
                                NEW_OBJ.vc_name = CLASS_OBJ.short_text;
                                NEW_OBJ.spec_info = CLASS_OBJ.short_text;
                                CharEntity.Add(NEW_OBJ);
                            }
                            //else // NOTE: both loop have same code. NOTE: commented on 18/12/2023, check and then correct.
                            //{
                            //    ENG_T005_B NEW_OBJ = new ENG_T005_B();
                            //    ENG_T005_B_OBJ_M.CopyPropertiesTo(NEW_OBJ); // assign template to new row with vc_code assignment.
                            //    NEW_OBJ.vc_code = MC_VC.VC_LIST[0].vc_code; // assign newly created vc_code
                            //    CLASS_OBJ = MC_VC.VC_LIST[0];
                            //    NEW_OBJ.vc_name = CLASS_OBJ.short_text;
                            //    CharEntity.Add(NEW_OBJ);
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void SaveVC(object InputValue)
        {
            try
            {
                Logging();
                MasterEntity.XDOC_A = obj.ObjectToXML(OperationEntity);
                MasterEntity.XDOC_B = obj.ObjectToXML(CharEntity);
                MasterEntity = REPO.UpdateWithReturnDomainObject<ENG_T005>(MasterEntity, "ENG_T005_BL", "ENG");
                SetBusinessEntitiesAfterLoad();
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private bool ValidationVC()
        {
            try
            {
                foreach (var o in VCEntity)
                {
                    int flag = 0;
                    if (string.IsNullOrWhiteSpace(o.char_value))
                    {
                        flag++;
                    }
                    //else if (Utilities.IsNumeric(o.char_value))
                    //{
                    //    flag++;
                    //    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Input Numeric valus", this.Title); sms.ShowMessage();
                    //}
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Input all Char values", this.Title); sms.ShowMessage();
            }
            return true;
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                // Remove and shifted to constructor because of Dialog Window.
                //if (STD_LIST_OBJ != null)
                //{
                //    if (STD_LIST_OBJ.request_type == "VC" && STD_LIST_OBJ.request == "VC")
                //    {
                //        LOAD_DOCUMENT(STD_LIST_OBJ);
                //    }
                //}
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        private void SC_ENG_T005_A(object InputValue)
        {
            try
            {
                ENG_T005_A_OBJ = (ENG_T005_A)InputValue;
            }
            catch (Exception ex) { }
        }
        private void SC_ENG_T005_B(object InputValue)
        {
            try
            {
                ENG_T005_B_OBJ = (ENG_T005_B)InputValue;
            }
            catch (Exception ex) { }
        }
       
        private void LOAD_DOCUMENT(STD_LIST_BE ParameterObject)
        {
            string Request = "";
            if (ParameterObject != null)
            {
                Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + (ParameterObject.comp_code ?? "") + "!@" + (ParameterObject.location_id ?? "") + "!@" + (ParameterObject.doc_cat ?? "") + "!@" + (ParameterObject.doc_type ?? "") + "!@" + (ParameterObject.doc_no ?? "") + "!@" + (ParameterObject.request ?? "") + "!@" + (ParameterObject.char_code ?? "") + "!@" + (ParameterObject.op_no ?? "") + "!@" + (ParameterObject.class_code ?? "") + "!@" + (ParameterObject.class_no ?? "") + "!@DEP" + "!@DEP";
                NewRecord = false;

                MC = REPO_MC_TEMP.GetDataWithReturnDomainObject<MC_ENG_BE>(MC_TEMP, Request, "ENG_T005_BL", "ENG", "LoadDocumentByDocumentNumber", 0, "");

                if (MC.MasterEntityTask != null && CharEntity != null && MC.OperationEntity != null) // All 3 collection must with one record otherwise cannot process.
                {
                    if (MC.MasterEntityTask.Count > 0 && MC.OperationEntity.Count > 0 && MC.CharEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntityTask[0];
                        OperationEntity = MC.OperationEntity;
                        if (MC.CharEntity.Count == 1) // if no entry exist for dependency char or it is first time then assign directly.
                        {
                            //ENG_T005_B_OBJ_M = MC.CharEntity[0];
                            //ENG_T005_B_OBJ_M.CopyPropertiesTo<ENG_T005_B>(MC.CharEntity[0]);
                            MC.CharEntity[0].CopyPropertiesTo(ENG_T005_B_OBJ_M);
                        }
                        else
                        {
                            MC.CharEntity.Where(x => x.vc_code == null).ToList()[0].CopyPropertiesTo(ENG_T005_B_OBJ_M);
                            //ENG_T005_B_OBJ_M = MC.CharEntity.Where(x => x.vc_code != null).ToList()[0];
                            //ReflectionFunctionService.CopyPropertiesTo<ENG_T005_B>(MC.CharEntity.Where(x => x.vc_code != null).ToList()[0], ENG_T005_B_OBJ_M);
                        }
                        ENG_T005_B_OBJ_M.id = null; // it is required for new char entry
                        MasterEntity.class_code = ENG_T005_B_OBJ_M.class_code;
                        MasterEntity.class_name = ENG_T005_B_OBJ_M.class_name;
                        
                        MC.CharEntity.Remove(MC.CharEntity.Where(x => x.vc_code == null).ToList()[0]); // remove main Master Dependency char
                        CharEntity = MC.CharEntity;
                        
                        ////Following null assigment not required because it already blank and readonly in Inspection plan because of dependency char property
                        //ENG_T005_B_OBJ_M.target_value = null;
                        //ENG_T005_B_OBJ_M.low_limit = null;
                        //ENG_T005_B_OBJ_M.up_limit = null;
                        //ENG_T005_B_OBJ_M.low_tol_limit = null;
                        //ENG_T005_B_OBJ_M.up_tol_limit = null;
                        //ENG_T005_B_OBJ_M.spec_info = null;

                        VCEntity = MC.VC_VALUE_LIST;
                        VALUE_COLLECTION = MC.CHAR_VALUE_LIST;
                        if (MC.VC_LIST != null)
                        {
                            if (MC.VC_LIST.Count > 0)
                            {
                                CLASS_OBJ = MC.VC_LIST[0];
                            }
                        }
                        
                    }
                }
            }
        }
        private void LOAD_VC_INFO(ENG_T005_B ParameterObject) // NOTE: Not in use because single record can be enough as all rows will be same except vc_code. 
        {
            string Request = "";
            if (ParameterObject != null)
            {

                Request = "LOAD_VC_INFO" + "!@" + AppSessionState.client + "!@" + (ParameterObject.comp_code ?? "") + "!@" + (ENG_T005_B_OBJ.ref_class ?? "") + "!@" + ENG_T005_B_OBJ.vc_code;
                
                MC_VC = REPO_MC_VC.GetDataWithReturnDomainObject<MC_ADM_M0126>(MC_VC, Request, "ADM_M0126_BL", "ADM", "LOAD", 0, "");

                if (MC_VC.VC_VALUE_LIST != null && MC_VC.VC_LIST != null) 
                {
                    if (MC_VC.VC_VALUE_LIST.Count > 0)
                    {
                        VCEntity = MC_VC.VC_VALUE_LIST;
                    }
                    if (MC_VC.VC_LIST.Count > 0)
                    {
                        CLASS_OBJ = MC_VC.VC_LIST[0];
                    }
                    //ENG_T005_B_OBJ.short_text = null;
                    //foreach (var item in VCEntity)
                    //{
                    //    ENG_T005_B_OBJ.short_text = (ENG_T005_B_OBJ.short_text ?? "") + "/" + item.char_value;
                    //}
                    //ENG_T005_B_OBJ.short_text = (ENG_T005_B_OBJ.short_text ?? "").TrimStart(',','/');
                    //ENG_T005_B_OBJ.short_text = UIServices.RemoveDuplicates(ENG_T005_B_OBJ.short_text);
                }
                
            }
        }
        private void FilterClassCharValues(object InputValue) // On selection chage of ADM_M0127, it should filter char values for pupup if available.
        {
            try
            {
                if (CLASS_CHAR_OBJ != null && MC != null)
                {
                    if (CLASS_CHAR_OBJ != null && MC.CHAR_VALUE_LIST != null)
                    {
                        VALUE_COLLECTION = MC.CHAR_VALUE_LIST.Where(x => x.char_code == CLASS_CHAR_OBJ.char_code).ToList();
                    }
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
        private void ConvertDays(object items)
        {

            var item = CLASS_CHAR_OBJ.char_value;
            if (item == null || string.IsNullOrWhiteSpace(item.ToString()))
            {
                OutputResult = "";
                return;
            }

            string inputDays = item.ToString();
            string[] parts = inputDays.Split('-');
            List<string> results = new List<string>();

            // ✅ Loop through each split value
            foreach (var part in parts)
            {
                if (int.TryParse(part, out int days))
                {
                    results.Add(ConvertDaysToYearsMonthsDays(days)); // Convert each input separately
                }
            }

            // ✅ Join results with " - " separator and assign result
            //OutputResult = string.Join(" - ", results);
            string varData = string.Join(" - ", results);
            //if (!string.IsNullOrWhiteSpace(varData) && CLASS_CHAR_OBJ.unit_code == "Days")
            //{ OutputResult = varData + "Yrs"; }
            //RaisePropertyChanged(nameof(OutputResult)); // ✅ Add this at the end of ConvertDays()

            if (!string.IsNullOrWhiteSpace(varData) && CLASS_CHAR_OBJ.unit_code == "Days")
            {
                CLASS_CHAR_OBJ.text_info = varData + "Yrs";
            }

        }
        private string ConvertDaysToYearsMonthsDays(int totalDays)
        {
            int daysInYear = 365;
            int years = totalDays / daysInYear;
            int remainingDays = totalDays % daysInYear;

            int[] monthDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int months = 0;

            //for (int i = 0; i < monthDays.Length; i++)
            //{
            //    if (remainingDays >= monthDays[i])
            //    {
            //        remainingDays -= monthDays[i];
            //        months++;
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            //return $"{years}y, {months}m, {remainingDays}d";
            return $"{years}";
        }
        private void DeleteInspCharEntityRow(object InputValue)
        {
            try
            {
                if (ENG_T005_B_OBJ != null || ENG_T005_B_OBJ.id == 0)
                {
                    if (CharEntity.Count > 0)
                    {
                        // eed to remove unique
                        //CharEntity.Remove(CharEntity.Where(x => x.op_no == ENG_T005_B_OBJ.op_no && x.char_code == ENG_T005_B_OBJ.char_code).Single());
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        #endregion



        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<ENG_T005> result)
        {
            MasterEntity = new ENG_T005();
            CharEntity = new ObservableCollection<ENG_T005_B>();
            OperationEntity = new ObservableCollection<ENG_T005_A>();
            CharEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForCharEntity);
            NewRecord = true;
        }
        protected override void OnDiscardAction(InquiryActionResult<ENG_T005> result)
        {

        }
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            {
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MC_TEMP.ATTACHMENT_LIST, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            }
        }
        private void OperationAttachments(object InputValue)
        {}
        protected override void OnFevoriteAction(InquiryActionResult<ENG_T005> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ENG_T005> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ENG_T005> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ENG_T005> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<ENG_T005> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<ENG_T005> result)
        {
            try
            {
                if (Validation() == true)
                {
                    Logging();
                    MasterEntity.XDOC_A = obj.ObjectToXML(OperationEntity);
                    MasterEntity.XDOC_B = obj.ObjectToXML(CharEntity);

                    this.MasterEntity.EndEdit();
                    MasterEntity = REPO.UpdateWithReturnDomainObject<ENG_T005>(MasterEntity, "ENG_T005_BL", "ENG");
                    SetBusinessEntitiesAfterLoad();
                    if (MasterEntity.doc_no != null || MasterEntity.doc_no != "" && MasterEntity.active == "1")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record saved Successfully ........");
                        showMessageService.ShowMessage();
                    }
                    NewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void SetBusinessEntitiesAfterLoad()
        {

            if (MasterEntity.XDOC_B != null)
            {
                CharEntity.Clear();
                MC.CharEntity = (ObservableCollection<ENG_T005_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_B, MC.CharEntity);
                MC.CharEntity.Remove(MC.CharEntity.Where(x => x.vc_code == null).ToList()[0]); // remove main Master Dependency char
                //Remove all other than selected char code
                for (int i = MC.CharEntity.Count - 1; i >= 0; i--)
                {
                    if (string.IsNullOrWhiteSpace(MC.CharEntity[i].vc_code))
                    {
                        MC.CharEntity.Remove(MC.CharEntity[i]);
                    }
                }

                CharEntity = MC.CharEntity;
            }
            else
            {
                MC.CharEntity = new ObservableCollection<ENG_T005_B>();
            }
        }

        protected override void OnRefreshCommand(InquiryActionResult<ENG_T005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ENG_T005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ENG_T005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ENG_T005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ENG_T005> result)
        {
            throw new NotImplementedException();
        }
        #endregion

       

        #region Event Handler
        private void CollectionChangedNotifyForCharEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add && ENG_T005_B_OBJ_M != null)
                {
                    foreach (ENG_T005_B item in e.NewItems)
                    {
                        item.id = 0;
                        item.active = "1";
                        item.char_no = ENG_T005_B_OBJ_M.char_no; //CharEntity.Count;
                        item.line_id = CharEntity.Count;
                        item.comp_code = ENG_T005_B_OBJ_M.comp_code; // NOTE: Replaced ENG_T005_A_OBJ by ENG_T005_B_OBJ_M on 28/12/2023
                        item.location_id = ENG_T005_B_OBJ_M.location_id; // NOTE: Replaced ENG_T005_A_OBJ by ENG_T005_B_OBJ_M on 28/12/2023
                        item.client = AppSessionState.client;
                        item.t_status = "01";
                        item.valid_from = MasterEntity.valid_from;
                        item.line_id = CharEntity.Count;
                        item.op_no = ENG_T005_B_OBJ_M.op_no; // NOTE: Replaced ENG_T005_A_OBJ by ENG_T005_B_OBJ_M on 28/12/2023
                        item.line_id_op = ENG_T005_B_OBJ_M.line_id_op;
                        //item.line_id_op = ENG_T005_B_OBJ_M.line_id; // NOTE: Replaced ENG_T005_A_OBJ by ENG_T005_B_OBJ_M on 28/12/2023
                        item.op_row_id = ENG_T005_B_OBJ_M.op_row_id; // NOTE: Replaced ENG_T005_A_OBJ by ENG_T005_B_OBJ_M on 28/12/2023
                        item.samp_pro_char = ENG_T005_B_OBJ_M.samp_pro_char;
                        item.doc_no = MasterEntity.doc_no;
                        item.doc_cat = MasterEntity.doc_cat;
                        item.doc_type = MasterEntity.doc_type;

                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove) //NOTE: use this section to remove dependant entries. like if Operation remove then all char data need to remove from Char Entity
                {
                    ENG_T005_B temp = (ENG_T005_B)e.OldItems[0];
                    var itemToRemove1 = OperationEntity.Where(x => (x.op_no == temp.op_no && x.op_no == "")).ToList();

                    foreach (var a in itemToRemove1)
                    {
                        if (a.op_no == "")
                        {
                            OperationEntity.Remove(a);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        #endregion
    }
}
