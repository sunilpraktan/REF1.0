using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace Reflection.BusinessEntity.ProjectManagement
{
    public class RND_T010 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        //Scalar
        public string XmlDataDocument_RND_T010_A { get; set; }
        public string XmlDataDocument_RND_T010_B { get; set; }
    }
    public class RND_T010_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("id");
                }
            }
        }
              

        private string _tb_code;
        public string tb_code
        {
            get { return _tb_code; }
            set
            {
                if (_tb_code != value)
                {
                    _tb_code = value;
                    RaisePropertyChanged("tb_code");
                }
            }
        }
              
            
        private string _tb_name;
        public string tb_name
        {
            get { return _tb_name; }
            set
            {
                if (_tb_name != value)
                {
                    _tb_name = value;
                    RaisePropertyChanged("tb_name");
                }
            }
        }
               
            
        private string _status;
        public string status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    RaisePropertyChanged("status");
                }
            }                
        }
            
        private string _ip_address;
        public string ip_address
        {
            get { return _ip_address; }
            set
            {
                if (_ip_address != value)
                {
                    _ip_address = value;
                    RaisePropertyChanged("ip_address");
                }
            }
        }
               
            
        private string _db;
        public string db
        {
            get { return _db; }
            set
            {
                if (_db != value)
                {
                    _db = value;
                    RaisePropertyChanged("db");
                }
            }
        }
             
            
        private string _user_id;
        public string user_id
        {
            get { return _user_id; }
            set
            {
                if (_user_id != value)
                {
                    _user_id = value;
                    RaisePropertyChanged("user_id");
                }
            }
        }
               
            
        private string _password;
        public string password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    RaisePropertyChanged("password");
                }
            }
        }
               
            
        private DateTime? _last_migration;
        public DateTime? last_migration
        {
            get { return _last_migration; }
            set
            {
                if (_last_migration != value)
                {
                    _last_migration = value;
                    RaisePropertyChanged("last_migration");
                }
            }
        }
               
            
        private string _table_name;
        public string table_name
        {
            get { return _table_name; }
            set
            {
                if (_table_name != value)
                {
                    _table_name = value;
                    RaisePropertyChanged("table_name");
                }
            }
        }
              

        #region Default Fields
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }


        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }

        private DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }

        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                _edit_by = value;
                RaisePropertyChanged("edit_by");
            }
        }


        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                _lang_key = value;
                RaisePropertyChanged("lang_key");
            }
        }

        #endregion

        //Scalar
        private int _max_id;
        public int max_id
        {
            get { return _max_id; }
            set
            {
                if (_max_id != value)
                {
                    _max_id = value;
                    RaisePropertyChanged("max_id");
                }
            }
        }
              

        //#region Animation
        //readonly static Random random;
        //static RND_T010_A raceWinner = null;

        //// Instance fields
        //readonly DispatcherTimer timer = new DispatcherTimer();
        //readonly string name;
        //int percentComplete;

        //static RND_T010_A()
        //{
        //    RND_T010_A.random = new Random(DateTime.Now.Millisecond);
        //}
        //public RND_T010_A(string name)
        //{
        //    this.tb_code = name;
        //    this.percentComplete = 0;

        //    this.timer.Tick += this.timer_Tick;
        //}
        //#endregion
        //#region Public Properties

        //public bool IsFinished
        //{
        //    get { return this.PercentComplete >= 100; }
        //}

        //public bool IsWinner
        //{
        //    get { return RND_T010_A.raceWinner == this; }
        //}

        //public string Name
        //{
        //    get { return this.name; }
        //}

        //public int PercentComplete
        //{
        //    get { return this.percentComplete; }
        //    private set
        //    {
        //        if (this.percentComplete == value)
        //            return;

        //        if (value < 0 || value > 100)
        //            throw new ArgumentOutOfRangeException("PercentComplete");

        //        bool wasFinished = this.IsFinished;

        //        this.percentComplete = value;

        //        this.RaisePropertyChanged("PercentComplete");

        //        if (wasFinished != this.IsFinished)
        //        {
        //            if (this.IsFinished && RND_T010_A.raceWinner == null)
        //            {
        //                RND_T010_A.raceWinner = this;
        //                this.RaisePropertyChanged("IsWinner");
        //            }

        //            this.RaisePropertyChanged("IsFinished");
        //        }

        //        // In case this horse was the previous winner and a new race has begun,
        //        // notify the world that the IsWinner property has changed on this horse.
        //        if (wasFinished && value == 0)
        //            this.RaisePropertyChanged("IsWinner");
        //    }
        //}

        //#endregion // Public Properties
        //#region Public Methods

        //public void StartNewSyncData()
        //{
        //    // When a race begins, remove a reference to the previous winner.
        //    if (RND_T010_A.raceWinner != null)
        //        RND_T010_A.raceWinner = null;

        //    // Put the horse back at the start of the track.
        //    this.PercentComplete = 0;

        //    // Give the horse a random "speed" to run at.
        //    this.timer.Interval = TimeSpan.FromMilliseconds(RND_T010_A.random.Next(20, 100));

        //    // Start the DispatcherTimer, which ticks when the horse should "move."
        //    if (!this.timer.IsEnabled)
        //        this.timer.Start();
        //}

        //#endregion // Public Methods	
        //#region timer_Tick

        //void timer_Tick(object sender, EventArgs e)
        //{
        //    if (!this.IsFinished)
        //        ++this.PercentComplete;

        //    if (this.IsFinished)
        //        this.timer.Stop();
        //}

        //#endregion // timer_Tick

    }
    public class RND_T010_A2 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("id");
                }
            }
        }
              

        private string _tb_code;
        public string tb_code
        {
            get { return _tb_code; }
            set
            {
                if (_tb_code != value)
                {
                    _tb_code = value;
                    RaisePropertyChanged("tb_code");
                }
            }
        }
              

        private string _tb_name;
        public string tb_name
        {
            get { return _tb_name; }
            set
            {
                if (_tb_name != value)
                {
                    _tb_name = value;
                    RaisePropertyChanged("tb_name");
                }
            }
        }
               

        private string _status;
        public string status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    RaisePropertyChanged("status");
                }
            }
        }


        private string _ip_address;
        public string ip_address
        {
            get { return _ip_address; }
            set
            {
                if (_ip_address != value)
                {
                    _ip_address = value;
                    RaisePropertyChanged("ip_address");
                }
            }
        }
               

        private string _db;
        public string db
        {
            get { return _db; }
            set
            {
                if (_db != value)
                {
                    _db = value;
                    RaisePropertyChanged("db");
                }
            }
        }
               

        private string _user_id;
        public string user_id
        {
            get { return _user_id; }
            set
            {
                if (_user_id != value)
                {
                    _user_id = value;
                    RaisePropertyChanged("user_id");
                }
            }
        }
               

        private string _password;
        public string password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    RaisePropertyChanged("password");
                }
            }
        }
               

        private DateTime? _last_migration;
        public DateTime? last_migration
        {
            get { return _last_migration; }
            set
            {
                if (_last_migration != value)
                {
                    _last_migration = value;
                    RaisePropertyChanged("last_migration");
                }
            }
        }
               

        private string _table_name;
        public string table_name
        {
            get { return _table_name; }
            set
            {
                if (_table_name != value)
                {
                    _table_name = value;
                    RaisePropertyChanged("table_name");
                }
            }
        }
                

        #region Default Fields
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value;
                    RaisePropertyChanged("active");
                }
            }
        }
               

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                if (_t_status != value)
                {
                    _t_status = value;
                    RaisePropertyChanged("t_status");
                }
            }
        }
                


        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value;
                    RaisePropertyChanged("add_by");
                }
            }
        } 

        private DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value;
                    RaisePropertyChanged("add_date");
                }
            }
        }
                

        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                if (_edit_by != value)
                {
                    _edit_by = value;
                    RaisePropertyChanged("edit_by");
                }
            }
        }
             


        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value;
                    RaisePropertyChanged("edit_date");
                }
            }
        }
               
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value;
                    RaisePropertyChanged("location_Id");
                }
            }               
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value;
                    RaisePropertyChanged("comp_code");
                }
            }
        }
           
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value;
                    RaisePropertyChanged("lang_key");
                }
            }
        }
           
        #endregion

        //Scalar
        private int _max_id;
        public int max_id
        {
            get { return _max_id; }
            set
            {
                if (_max_id != value)
                {
                    _max_id = value;
                    RaisePropertyChanged("max_id");
                }
            }
        }
                

        #region Animation
        readonly static Random random;
        static RND_T010_A2 raceWinner = null;

        // Instance fields
        readonly DispatcherTimer timer = new DispatcherTimer();
        readonly string name;
        int percentComplete;

        static RND_T010_A2()
        {
            RND_T010_A2.random = new Random(DateTime.Now.Millisecond);
        }
        public RND_T010_A2(string name)
        {
            this.tb_code = name;
            this.percentComplete = 0;

            this.timer.Tick += this.timer_Tick;
        }
        #endregion
        #region Public Properties

        public bool IsFinished
        {
            get { return this.PercentComplete >= 100; }
        }

        public bool IsWinner
        {
            get { return RND_T010_A2.raceWinner == this; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public int PercentComplete
        {
            get { return this.percentComplete; }
            private set
            {
                if (this.percentComplete == value)
                    return;

                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("PercentComplete");

                bool wasFinished = this.IsFinished;

                this.percentComplete = value;

                this.RaisePropertyChanged("PercentComplete");

                if (wasFinished != this.IsFinished)
                {
                    if (this.IsFinished && RND_T010_A2.raceWinner == null)
                    {
                        RND_T010_A2.raceWinner = this;
                        this.RaisePropertyChanged("IsWinner");
                    }

                    this.RaisePropertyChanged("IsFinished");
                }

                // In case this horse was the previous winner and a new race has begun,
                // notify the world that the IsWinner property has changed on this horse.
                if (wasFinished && value == 0)
                    this.RaisePropertyChanged("IsWinner");
            }
        }

        #endregion // Public Properties
        #region Public Methods

        public void StartNewSyncData()
        {
            // When a race begins, remove a reference to the previous winner.
            if (RND_T010_A2.raceWinner != null)
                RND_T010_A2.raceWinner = null;

            // Put the horse back at the start of the track.
            this.PercentComplete = 0;

            // Give the horse a random "speed" to run at.
            this.timer.Interval = TimeSpan.FromMilliseconds(RND_T010_A2.random.Next(20, 100));

            // Start the DispatcherTimer, which ticks when the horse should "move."
            if (!this.timer.IsEnabled)
                this.timer.Start();
        }

        #endregion // Public Methods	
        #region timer_Tick

        void timer_Tick(object sender, EventArgs e)
        {
            if (!this.IsFinished)
                ++this.PercentComplete;

            if (this.IsFinished)
                this.timer.Stop();
        }

        #endregion // timer_Tick

    }
    public class RND_T010_B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("id");
                }
            }
        }
               

        private int _Pn;
        public int Pn
        {
            get { return _Pn; }
            set
            {
                if (_Pn != value)
                {
                    _Pn = value;
                    RaisePropertyChanged("Pn");
                }
            }
        }
              
            
        private string _f_name;
        public string f_name
        {
            get { return _f_name; }
            set
            {
                if (_f_name != value)
                {
                    _f_name = value;
                    RaisePropertyChanged("f_name");
                }
            }
        }
               
           
        private string _E_Speed_000;
        public string E_Speed_000
        {
            get { return _E_Speed_000; }
            set
            {
                if (_E_Speed_000 != value)
                {
                    _E_Speed_000 = value;
                    RaisePropertyChanged("E_Speed_000");
                }
            }
        }
               
            
        private string _E_Torque_001;
        public string E_Torque_001
        {
            get { return _E_Torque_001; }
            set
            {
                if (_E_Torque_001 != value)
                {
                    _E_Torque_001 = value;
                    RaisePropertyChanged("E_Torque_001");
                }
            }
        }
               
            
        private string _SFCReset_002;
        public string SFCReset_002
        {
            get { return _SFCReset_002; }
            set
            {
                if (_SFCReset_002 != value)
                {
                    _SFCReset_002 = value;
                    RaisePropertyChanged("SFCReset_002");
                }
            }
        }
              
            
        private string _L_Weight_003;
        public string L_Weight_003
        {
            get { return _L_Weight_003; }
            set
            {
                if (_L_Weight_003 != value)
                {
                    _L_Weight_003 = value;
                    RaisePropertyChanged("L_Weight_003");
                }
            }
        }
                
            
        private string _L_Time_004;
        public string L_Time_004
        {
            get { return _L_Time_004; }
            set
            {
                if (_L_Time_004 != value)
                {
                    _L_Time_004 = value;
                    RaisePropertyChanged("L_Time_004");
                }
            }
        }
              
            
        private string _F_Weight_005;
        public string F_Weight_005
        {
            get { return _F_Weight_005; }
            set
            {
                if (_F_Weight_005 != value)
                {
                    _F_Weight_005 = value;
                    RaisePropertyChanged("F_Weight_005");
                }
            }
        }
               
            
        private string _T_WtrOut_006;
        public string T_WtrOut_006
        {
            get { return _T_WtrOut_006; }
            set
            {
                if (_T_WtrOut_006 != value)
                {
                    _T_WtrOut_006 = value;
                    RaisePropertyChanged("T_WtrOut_006");
                }
            }
        }
               
            
        private string _T_Exhaust_007;
        public string T_Exhaust_007
        {
            get { return _T_Exhaust_007; }
            set
            {
                if (_T_Exhaust_007 != value)
                {
                    _T_Exhaust_007 = value;
                    RaisePropertyChanged("T_Exhaust_007");
                }
            }
               
        }
            
        private string _P_LubOil_008;
        public string P_LubOil_008
        {
            get { return _P_LubOil_008; }
            set
            {
                if (_P_LubOil_008 != value)
                {
                    _P_LubOil_008 = value;
                    RaisePropertyChanged("P_LubOil_008");
                }
            }
        }
                
            
        private string _Not_Prog_009;
        public string Not_Prog_009
        {
            get { return _Not_Prog_009; }
            set
            {
                if (_Not_Prog_009 != value)
                {
                    _Not_Prog_009 = value;
                    RaisePropertyChanged("Not_Prog_009");
                }
            }
        }
              
            
        private string _Not_Prog_010;
        public string Not_Prog_010
        {
            get { return _Not_Prog_010; }
            set
            {
                if (_Not_Prog_010 != value)
                {
                    _Not_Prog_010 = value;
                    RaisePropertyChanged("Not_Prog_010");
                }
            }
        }
                
            
        private string _Not_Prog_011;
        public string Not_Prog_011
        {
            get { return _Not_Prog_011; }
            set
            {
                if (_Not_Prog_011 != value)
                {
                    _Not_Prog_011 = value;
                    RaisePropertyChanged("Not_Prog_011");
                }
            }
        }
                
            
        private string _Not_Prog_012;
        public string Not_Prog_012
        {
            get { return _Not_Prog_012; }
            set
            {
                if (_Not_Prog_012 != value)
                {
                    _Not_Prog_012 = value;
                    RaisePropertyChanged("Not_Prog_012");
                }
            }
        }
             
            
        private string _Not_Prog_013;
        public string Not_Prog_013
        {
            get { return _Not_Prog_013; }
            set
            {
                if (_Not_Prog_013 != value)
                {
                    _Not_Prog_013 = value;
                    RaisePropertyChanged("Not_Prog_013");
                }
            }
        }
                            
        private string _Not_Prog_014;
        public string Not_Prog_014
        {
            get { return _Not_Prog_014; }
            set
            {
                if (_Not_Prog_014 != value)
                {
                    _Not_Prog_014 = value;
                    RaisePropertyChanged("Not_Prog_014");
                }
            }
        }
               
            
        private string _Not_Prog_015;
        public string Not_Prog_015
        {
            get { return _Not_Prog_015; }
            set
            {
                if (_Not_Prog_015 != value)
                {
                    _Not_Prog_015 = value;
                    RaisePropertyChanged("Not_Prog_015");
                }
            }
        }
               
            
        private string _Not_Prog_016;
        public string Not_Prog_016
        {
            get { return _Not_Prog_016; }
            set
            {
                if (_Not_Prog_016 != value)
                {
                    _Not_Prog_016 = value;
                    RaisePropertyChanged("Not_Prog_016");
                }
            }
        }
               
            
        private string _Not_Prog_017;
        public string Not_Prog_017
        {
            get { return _Not_Prog_017; }
            set
            {
                if (_Not_Prog_017 != value)
                {
                    _Not_Prog_017 = value;
                    RaisePropertyChanged("Not_Prog_017");
                }
            }
        }
              
            
        private string _Not_Prog_018;
        public string Not_Prog_018
        {
            get { return _Not_Prog_018; }
            set
            {
                if (_Not_Prog_018 != value)
                {
                    _Not_Prog_018 = value;
                    RaisePropertyChanged("Not_Prog_018");
                }
            }
        }
                
            
        private string _Not_Prog_019;
        public string Not_Prog_019
        {
            get { return _Not_Prog_019; }
            set
            {
                if (_Not_Prog_019 != value)
                {
                    _Not_Prog_019 = value;
                    RaisePropertyChanged("Not_Prog_019");
                }
            }
        }
                
            
        private string _Not_Prog_020;
        public string Not_Prog_020
        {
            get { return _Not_Prog_020; }
            set
            {
                if (_Not_Prog_020 != value)
                {
                    _Not_Prog_020 = value;
                    RaisePropertyChanged("Not_Prog_020");
                }
            }
        }
              
            
        private string _Not_Prog_021;
        public string Not_Prog_021
        {
            get { return _Not_Prog_021; }
            set
            {
                if (_Not_Prog_021 != value)
                {
                    _Not_Prog_021 = value;
                    RaisePropertyChanged("Not_Prog_021");
                }
            }
        }
                
            
        private string _Not_Prog_022;
        public string Not_Prog_022
        {
            get { return _Not_Prog_022; }
            set
            {
                if (_Not_Prog_022 != value)
                {
                    _Not_Prog_022 = value;
                    RaisePropertyChanged("Not_Prog_022");
                }
            }
        }
               
            
        private string _Not_Prog_023;
        public string Not_Prog_023
        {
            get { return _Not_Prog_023; }
            set
            {
                if (_Not_Prog_023 != value)
                {
                    _Not_Prog_023 = value;
                    RaisePropertyChanged("Not_Prog_023");
                }
            }
        }
               
            
        private string _Not_Prog_024;
        public string Not_Prog_024
        {
            get { return _Not_Prog_024; }
            set
            {
                if (_Not_Prog_024 != value)
                {
                    _Not_Prog_024 = value;
                    RaisePropertyChanged("Not_Prog_024");
                }
            }
        }
               
            
        private string _Not_Prog_025;
        public string Not_Prog_025
        {
            get { return _Not_Prog_025; }
            set
            {
                if (_Not_Prog_025 != value)
                {
                    _Not_Prog_025 = value;
                    RaisePropertyChanged("Not_Prog_025");
                }
            }
        }
               
            
        private string _Not_Prog_026;
        public string Not_Prog_026
        {
            get { return _Not_Prog_026; }
            set
            {
                if (_Not_Prog_026 != value)
                {
                    _Not_Prog_026 = value;
                    RaisePropertyChanged("Not_Prog_026");
                }
            }
        }
                
            
        private string _Not_Prog_027;
        public string Not_Prog_027
        {
            get { return _Not_Prog_027; }
            set
            {
                if (_Not_Prog_027 != value)
                {
                    _Not_Prog_027 = value;
                    RaisePropertyChanged("Not_Prog_027");
                }
            }
        }
              
            
        private string _Not_Prog_028;
        public string Not_Prog_028
        {
            get { return _Not_Prog_028; }
            set
            {
                if (_Not_Prog_028 != value)
                {
                    _Not_Prog_028 = value;
                    RaisePropertyChanged("Not_Prog_028");
                }
            }
        }
               
            
        private string _Not_Prog_029;
        public string Not_Prog_029
        {
            get { return _Not_Prog_029; }
            set
            {
                if (_Not_Prog_029 != value)
                {
                    _Not_Prog_029 = value;
                    RaisePropertyChanged("Not_Prog_029");
                }
            }
        }
               
            
        private string _Not_Prog_030;
        public string Not_Prog_030
        {
            get { return _Not_Prog_030; }
            set
            {
                if (_Not_Prog_030 != value)
                {
                    _Not_Prog_030 = value;
                    RaisePropertyChanged("Not_Prog_030");
                }
            }
        }
               
           
        private string _P_Ambient_031;
        public string P_Ambient_031
        {
            get { return _P_Ambient_031; }
            set
            {
                if (_P_Ambient_031 != value)
                {
                    _P_Ambient_031 = value;
                    RaisePropertyChanged("P_Ambient_031");
                }
            }
        }
               
            
        private string _P_WtrIn_032;
        public string P_WtrIn_032
        {
            get { return _P_WtrIn_032; }
            set
            {
                if (_P_WtrIn_032 != value)
                {
                    _P_WtrIn_032 = value;
                    RaisePropertyChanged("P_WtrIn_032");
                }
            }
        }
               
            
        private string _P_WtrOut_033;
        public string P_WtrOut_033
        {
            get { return _P_WtrOut_033; }
            set
            {
                if (_P_WtrOut_033 != value)
                {
                    _P_WtrOut_033 = value;
                    RaisePropertyChanged("P_WtrOut_033");
                }
            }
        }
               
            
        private string _Not_Prog_034;
        public string Not_Prog_034
        {
            get { return _Not_Prog_034; }
            set
            {
                if (_Not_Prog_034 != value)
                {
                    _Not_Prog_034 = value;
                    RaisePropertyChanged("Not_Prog_034");
                }
            }
        }
               
            
        private string _Not_Prog_035;
        public string Not_Prog_035
        {
            get { return _Not_Prog_035; }
            set
            {
                if (_Not_Prog_035 != value)
                {
                    _Not_Prog_035 = value;
                    RaisePropertyChanged("Not_Prog_035");
                }
            }
        }
               
            
        private string _Not_Prog_036;
        public string Not_Prog_036
        {
            get { return _Not_Prog_036; }
            set
            {
                if (_Not_Prog_036 != value)
                {
                    _Not_Prog_036 = value;
                    RaisePropertyChanged("Not_Prog_036");
                }
            }
        }
                
            
        private string _Not_Prog_037;
        public string Not_Prog_037
        {
            get { return _Not_Prog_037; }
            set
            {
                if (_Not_Prog_037 != value)
                {
                    _Not_Prog_037 = value;
                    RaisePropertyChanged("Not_Prog_037");
                }
            }
        }
               
            
        private string _Not_Prog_038;
        public string Not_Prog_038
        {
            get { return _Not_Prog_038; }
            set
            {
                if (_Not_Prog_038 != value)
                {
                    _Not_Prog_038 = value;
                    RaisePropertyChanged("Not_Prog_038");
                }
            }
        }
               
            
        private string _Not_Prog_039;
        public string Not_Prog_039
        {
            get { return _Not_Prog_039; }
            set
            {
                if (_Not_Prog_039 != value)
                {
                    _Not_Prog_039 = value;
                    RaisePropertyChanged("Not_Prog_039");
                }
            }
        }
            
            
        private string _Not_Prog_040;
        public string Not_Prog_040
        {
            get { return _Not_Prog_040; }
            set
            {
                if (_Not_Prog_040 != value)
                {
                    _Not_Prog_040 = value;
                    RaisePropertyChanged("Not_Prog_040");
                }
            }
        }
               
            
        private string _Not_Prog_041;
        public string Not_Prog_041
        {
            get { return _Not_Prog_041; }
            set
            {
                if (_Not_Prog_041 != value)
                {
                    _Not_Prog_041 = value;
                    RaisePropertyChanged("Not_Prog_041");
                }
            }
        }
               
            
        private string _Not_Prog_042;
        public string Not_Prog_042
        {
            get { return _Not_Prog_042; }
            set
            {
                if (_Not_Prog_042 != value)
                {
                    _Not_Prog_042 = value;
                    RaisePropertyChanged("Not_Prog_042");
                }
            }
        }
     
            
        private string _Not_Prog_043;
        public string Not_Prog_043
        {
            get { return _Not_Prog_043; }
            set
            {
                if (_Not_Prog_043 != value)
                {
                    _Not_Prog_043 = value;
                    RaisePropertyChanged("Not_Prog_043");
                }
            }
        }
              
            
        private string _Not_Prog_044;
        public string Not_Prog_044
        {
            get { return _Not_Prog_044; }
            set
            {
                if (_Not_Prog_044 != value)
                {
                    _Not_Prog_044 = value;
                    RaisePropertyChanged("Not_Prog_044");
                }
            }
        }
                
            
        private string _Not_Prog_045;
        public string Not_Prog_045
        {
            get { return _Not_Prog_045; }
            set
            {
                if (_Not_Prog_045 != value)
                {
                    _Not_Prog_045 = value;
                    RaisePropertyChanged("Not_Prog_045");
                }
            }
        }
              
            
        private string _Not_Prog_046;
        public string Not_Prog_046
        {
            get { return _Not_Prog_046; }
            set
            {
                if (_Not_Prog_046 != value)
                {
                    _Not_Prog_046 = value;
                    RaisePropertyChanged("Not_Prog_046");
                }
            }
        }
               
            
        private string _Not_Prog_047;
        public string Not_Prog_047
        {
            get { return _Not_Prog_047; }
            set
            {
                if (_Not_Prog_047 != value)
                {
                    _Not_Prog_047 = value;
                    RaisePropertyChanged("Not_Prog_047");
                }
            }
        }
             
            
        private string _Not_Prog_048;
        public string Not_Prog_048
        {
            get { return _Not_Prog_048; }
            set
            {
                if (_Not_Prog_048 != value)
                {
                    _Not_Prog_048 = value;
                    RaisePropertyChanged("Not_Prog_048");
                }
            }
        }
              
            
        private string _Not_Prog_049;
        public string Not_Prog_049
        {
            get { return _Not_Prog_049; }
            set
            {
                if (_Not_Prog_049 != value)
                {
                    _Not_Prog_049 = value;
                    RaisePropertyChanged("Not_Prog_049");
                }
            }
        }
              
            
        private string _Not_Prog_050;
        public string Not_Prog_050
        {
            get { return _Not_Prog_050; }
            set
            {
                if (_Not_Prog_050 != value)
                {
                    _Not_Prog_050 = value;
                    RaisePropertyChanged("Not_Prog_050");
                }
            }
        }
               
            
        private string _Not_Prog_051;
        public string Not_Prog_051
        {
            get { return _Not_Prog_051; }
            set
            {
                if (_Not_Prog_051 != value)
                {
                    _Not_Prog_051 = value;
                    RaisePropertyChanged("Not_Prog_051");
                }
            }
        }
               
            
        private string _Not_Prog_052;
        public string Not_Prog_052
        {
            get { return _Not_Prog_052; }
            set
            {
                if (_Not_Prog_052 != value)
                {
                    _Not_Prog_052 = value;
                    RaisePropertyChanged("Not_Prog_052");
                }
            }
        }
                
            
        private string _Not_Prog_053;
        public string Not_Prog_053
        {
            get { return _Not_Prog_053; }
            set
            {
                if (_Not_Prog_053 != value)
                {
                    _Not_Prog_053 = value;
                    RaisePropertyChanged("Not_Prog_053");
                }
            }
        }
              
            
        private string _Not_Prog_054;
        public string Not_Prog_054
        {
            get { return _Not_Prog_054; }
            set
            {
                if (_Not_Prog_054 != value)
                {
                    _Not_Prog_054 = value;
                    RaisePropertyChanged("Not_Prog_054");
                }
            }
        }
                
            
        private string _Not_Prog_055;
        public string Not_Prog_055
        {
            get { return _Not_Prog_055; }
            set
            {
                if (_Not_Prog_055 != value)
                {
                    _Not_Prog_055 = value;
                    RaisePropertyChanged("Not_Prog_055");
                }
            }
        }
             
            
        private string _Not_Prog_056;
        public string Not_Prog_056
        {
            get { return _Not_Prog_056; }
            set
            {
                if (_Not_Prog_056 != value)
                {
                    _Not_Prog_056 = value;
                    RaisePropertyChanged("Not_Prog_056");
                }
            }
        }
              
            
        private string _Not_Prog_057;
        public string Not_Prog_057
        {
            get { return _Not_Prog_057; }
            set
            {
                if (_Not_Prog_057 != value)
                {
                    _Not_Prog_057 = value;
                    RaisePropertyChanged("Not_Prog_057");
                }
            }
        }
               
            
        private string _Not_Prog_058;
        public string Not_Prog_058
        {
            get { return _Not_Prog_058; }
            set
            {
                if (_Not_Prog_058 != value)
                {
                    _Not_Prog_058 = value;
                    RaisePropertyChanged("Not_Prog_058");
                }
            }
        }
                
            
        private string _Not_Prog_059;
        public string Not_Prog_059
        {
            get { return _Not_Prog_059; }
            set
            {
                if (_Not_Prog_059 != value)
                {
                    _Not_Prog_059 = value;
                    RaisePropertyChanged("Not_Prog_059");
                }
            }
        }
              
            
        private string _Not_Prog_060;
        public string Not_Prog_060
        {
            get { return _Not_Prog_060; }
            set
            {
                if (_Not_Prog_060 != value)
                {
                    _Not_Prog_060 = value;
                    RaisePropertyChanged("Not_Prog_060");
                }
            }
        }
              
            
        private string _Not_Prog_061;
        public string Not_Prog_061
        {
            get { return _Not_Prog_061; }
            set
            {
                if (_Not_Prog_061 != value)
                {
                    _Not_Prog_061 = value;
                    RaisePropertyChanged("Not_Prog_061");
                }
            }
        }
               
            
        private string _Not_Prog_062;
        public string Not_Prog_062
        {
            get { return _Not_Prog_062; }
            set
            {
                if (_Not_Prog_062 != value)
                {
                    _Not_Prog_062 = value;
                    RaisePropertyChanged("Not_Prog_062");
                }
            }
        }
               
            
        private string _Not_Prog_063;
        public string Not_Prog_063
        {
            get { return _Not_Prog_063; }
            set
            {
                if (_Not_Prog_063 != value)
                {
                    _Not_Prog_063 = value;
                    RaisePropertyChanged("Not_Prog_063");
                }
            }
        }
               
            
        private string _Not_Prog_064;
        public string Not_Prog_064
        {
            get { return _Not_Prog_064; }
            set
            {
                if (_Not_Prog_064 != value)
                {
                    _Not_Prog_064 = value;
                    RaisePropertyChanged("Not_Prog_064");
                }
            }
        }
               
            
        private string _Not_Prog_065;
        public string Not_Prog_065
        {
            get { return _Not_Prog_065; }
            set
            {
                if (_Not_Prog_065 != value)
                {
                    _Not_Prog_065 = value;
                    RaisePropertyChanged("Not_Prog_065");
                }
            }
        }
              
            
        private string _Not_Prog_066;
        public string Not_Prog_066
        {
            get { return _Not_Prog_066; }
            set
            {
                if (_Not_Prog_066 != value)
                {
                    _Not_Prog_066 = value;
                    RaisePropertyChanged("Not_Prog_066");
                }
            }
        }
                
            
        private string _Not_Prog_067;
        public string Not_Prog_067
        {
            get { return _Not_Prog_067; }
            set
            {
                if (_Not_Prog_067 != value)
                {
                    _Not_Prog_067 = value;
                    RaisePropertyChanged("Not_Prog_067");
                }
            }
        }
               
            
        private string _Not_Prog_068;
        public string Not_Prog_068
        {
            get { return _Not_Prog_068; }
            set
            {
                if (_Not_Prog_068 != value)
                {
                    _Not_Prog_068 = value;
                    RaisePropertyChanged("Not_Prog_068");
                }
            }
        }
                
            
        private string _Not_Prog_069;
        public string Not_Prog_069
        {
            get { return _Not_Prog_069; }
            set
            {
                if (_Not_Prog_069 != value)
                {
                    _Not_Prog_069 = value;
                    RaisePropertyChanged("Not_Prog_069");
                }
            }
        }
             
            
        private string _Not_Prog_070;
        public string Not_Prog_070
        {
            get { return _Not_Prog_070; }
            set
            {
                if (_Not_Prog_070 != value)
                {
                    _Not_Prog_070 = value;
                    RaisePropertyChanged("Not_Prog_070");
                }
            }
        }
               
            
        private string _Not_Prog_071;
        public string Not_Prog_071
        {
            get { return _Not_Prog_071; }
            set
            {
                if (_Not_Prog_071 != value)
                {
                    _Not_Prog_071 = value;
                    RaisePropertyChanged("Not_Prog_071");
                }
            }
        }
                
            
        private string _Not_Prog_072;
        public string Not_Prog_072
        {
            get { return _Not_Prog_072; }
            set
            {
                if (_Not_Prog_072 != value)
                {
                    _Not_Prog_072 = value;
                    RaisePropertyChanged("Not_Prog_072");
                }
            }
        }
               
            
        private string _Not_Prog_073;
        public string Not_Prog_073
        {
            get { return _Not_Prog_073; }
            set
            {
                if (_Not_Prog_073 != value)
                {
                    _Not_Prog_073 = value;
                    RaisePropertyChanged("Not_Prog_073");
                }
            }
        }
                
            
        private string _Not_Prog_074;
        public string Not_Prog_074
        {
            get { return _Not_Prog_074; }
            set
            {
                if (_Not_Prog_074 != value)
                {
                    _Not_Prog_074 = value;
                    RaisePropertyChanged("Not_Prog_074");
                }
            }
        }
               
            
        private string _Not_Prog_075;
        public string Not_Prog_075
        {
            get { return _Not_Prog_075; }
            set
            {
                if (_Not_Prog_075 != value)
                {
                    _Not_Prog_075 = value;
                    RaisePropertyChanged("Not_Prog_075");
                }
            }
        }

        private string _Not_Prog_076;
        public string Not_Prog_076
        {
            get { return _Not_Prog_076; }
            set
            {
                if (_Not_Prog_076 != value)
                {
                    _Not_Prog_076 = value;
                    RaisePropertyChanged("Not_Prog_076");
                }
            }
        }

            
        private string _Not_Prog_077;
        public string Not_Prog_077
        {
            get { return _Not_Prog_077; }
            set
            {
                if (_Not_Prog_077 != value)
                {
                    _Not_Prog_077 = value;
                    RaisePropertyChanged("Not_Prog_077");
                }
            }
        }
              
            
        private string _Not_Prog_078;
        public string Not_Prog_078
        {
            get { return _Not_Prog_078; }
            set
            {
                if (_Not_Prog_078 != value)
                {
                    _Not_Prog_078 = value;
                    RaisePropertyChanged("Not_Prog_078");
                }
            }
        }
              
            
        private string _Not_Prog_079;
        public string Not_Prog_079
        {
            get { return _Not_Prog_079; }
            set
            {
                if (_Not_Prog_079 != value)
                {
                    _Not_Prog_079 = value;
                    RaisePropertyChanged("Not_Prog_079");
                }
            }
        }
              
            
        private string _Not_Prog_080;
        public string Not_Prog_080
        {
            get { return _Not_Prog_080; }
            set
            {
                if (_Not_Prog_080 != value)
                {
                    _Not_Prog_080 = value;
                    RaisePropertyChanged("Not_Prog_080");
                }
            }
        }
               
            
        private string _Not_Prog_081;
        public string Not_Prog_081
        {
            get { return _Not_Prog_081; }
            set
            {
                if (_Not_Prog_081 != value)
                {
                    _Not_Prog_081 = value;
                    RaisePropertyChanged("Not_Prog_081");
                }
            }
        }
               
            
        private string _Not_Prog_082;
        public string Not_Prog_082
        {
            get { return _Not_Prog_082; }
            set
            {
                if (_Not_Prog_082 != value)
                {
                    _Not_Prog_082 = value;
                    RaisePropertyChanged("Not_Prog_082");
                }
            }
        }
               
            
        private string _Not_Prog_083;
        public string Not_Prog_083
        {
            get { return _Not_Prog_083; }
            set
            {
                if (_Not_Prog_083 != value)
                {
                    _Not_Prog_083 = value;
                    RaisePropertyChanged("Not_Prog_083");
                }
            }
        }
              
            
        private string _Not_Prog_084;
        public string Not_Prog_084
        {
            get { return _Not_Prog_084; }
            set
            {
                if (_Not_Prog_084 != value)
                {
                    _Not_Prog_084 = value;
                    RaisePropertyChanged("Not_Prog_084");
                }
            }
        }
             
            
        private string _Not_Prog_085;
        public string Not_Prog_085
        {
            get { return _Not_Prog_085; }
            set
            {
                if (_Not_Prog_085 != value)
                {
                    _Not_Prog_085 = value;
                    RaisePropertyChanged("Not_Prog_085");
                }
            }
        }
               
            
        private string _NotProg_086;
        public string NotProg_086
        {
            get { return _NotProg_086; }
            set
            {
                if (_NotProg_086 != value)
                {
                    _NotProg_086 = value;
                    RaisePropertyChanged("NotProg_086");
                }
            }
        }
               
            
        private string _T_WI_PID_087;
        public string T_WI_PID_087
        {
            get { return _T_WI_PID_087; }
            set
            {
                if (_T_WI_PID_087 != value)
                {
                    _T_WI_PID_087 = value;
                    RaisePropertyChanged("T_WI_PID_087");
                }
            }
        }
               
            
        private string _T_WO_PID_088;
        public string T_WO_PID_088
        {
            get { return _T_WO_PID_088; }
            set
            {
                if (_T_WO_PID_088 != value)
                {
                    _T_WO_PID_088 = value;
                    RaisePropertyChanged("T_WO_PID_088");
                }
            }
        }
             
            
        private string _T_HTnkPID_089;
        public string T_HTnkPID_089
        {
            get { return _T_HTnkPID_089; }
            set
            {
                if (_T_HTnkPID_089 != value)
                {
                    _T_HTnkPID_089 = value;
                    RaisePropertyChanged("T_HTnkPID_089");
                }
            }
        }
              
            
        private string _T_PID4_090;
        public string T_PID4_090
        {
            get { return _T_PID4_090; }
            set
            {
                if (_T_PID4_090 != value)
                {
                    _T_PID4_090 = value;
                    RaisePropertyChanged("T_PID4_090");
                }
            }
        }
               
            
        private string _Not_Prog_091;
        public string Not_Prog_091
        {
            get { return _Not_Prog_091; }
            set
            {
                if (_Not_Prog_091 != value)
                {
                    _Not_Prog_091 = value;
                    RaisePropertyChanged("Not_Prog_091");
                }
            }
        }
             
            
        private string _Not_Prog_092;
        public string Not_Prog_092
        {
            get { return _Not_Prog_092; }
            set
            {
                if (_Not_Prog_092 != value)
                {
                    _Not_Prog_092 = value;
                    RaisePropertyChanged("Not_Prog_092");
                }
            }
        }
             
            
        private string _Not_Prog_093;
        public string Not_Prog_093
        {
            get { return _Not_Prog_093; }
            set
            {
                if (_Not_Prog_093 != value)
                {
                    _Not_Prog_093 = value;
                    RaisePropertyChanged("Not_Prog_093");
                }
            }
        }
               
           
        private string _Not_Prog_094;
        public string Not_Prog_094
        {
            get { return _Not_Prog_094; }
            set
            {
                if (_Not_Prog_094 != value)
                {
                    _Not_Prog_094 = value;
                    RaisePropertyChanged("Not_Prog_094");
                }
            }
        }
               
            
        private string _Not_Prog_095;
        public string Not_Prog_095
        {
            get { return _Not_Prog_095; }
            set
            {
                if (_Not_Prog_095 != value)
                {
                    _Not_Prog_095 = value;
                    RaisePropertyChanged("Not_Prog_095");
                }
            }
        }
           
           
        private string _Not_Prog_096;
        public string Not_Prog_096
        {
            get { return _Not_Prog_096; }
            set
            {
                if (_Not_Prog_096 != value)
                {
                    _Not_Prog_096 = value;
                    RaisePropertyChanged("Not_Prog_096");
                }
            }
        }
                
            
        private string _Not_Prog_097;
        public string Not_Prog_097
        {
            get { return _Not_Prog_097; }
            set
            {
                if (_Not_Prog_097 != value)
                {
                    _Not_Prog_097 = value;
                    RaisePropertyChanged("Not_Prog_097");
                }
            }
        }
              
           
        private string _Not_Prog_098;
        public string Not_Prog_098
        {
            get { return _Not_Prog_098; }
            set
            {
                if (_Not_Prog_098 != value)
                {
                    _Not_Prog_098 = value;
                    RaisePropertyChanged("Not_Prog_098");
                }
            }
        }
               
            
        private string _Not_Prog_099;
        public string Not_Prog_099
        {
            get { return _Not_Prog_099; }
            set
            {
                if (_Not_Prog_099 != value)
                {
                    _Not_Prog_099 = value;
                    RaisePropertyChanged("Not_Prog_099");
                }
            }
        }
             
            
        private string _Not_Prog_100;
        public string Not_Prog_100
        {
            get { return _Not_Prog_100; }
            set
            {
                if (_Not_Prog_100 != value)
                {
                    _Not_Prog_100 = value;
                    RaisePropertyChanged("Not_Prog_100");
                }
            }
        }
               
            
        private string _SmkValue_101;
        public string SmkValue_101
        {
            get { return _SmkValue_101; }
            set
            {
                if (_SmkValue_101 != value)
                {
                    _SmkValue_101 = value;
                    RaisePropertyChanged("SmkValue_101");
                }
            }
        }
                
            
        private string _BlowBy_102;
        public string BlowBy_102
        {
            get { return _BlowBy_102; }
            set
            {
                if (_BlowBy_102 != value)
                {
                    _BlowBy_102 = value;
                    RaisePropertyChanged("BlowBy_102");
                }
            }
        }
                
            
        private string _SFCWt_103;
        public string SFCWt_103
        {
            get { return _SFCWt_103; }
            set
            {
                if (_SFCWt_103 != value)
                {
                    _SFCWt_103 = value;
                    RaisePropertyChanged("SFCWt_103");
                }
            }
        }
               
            
        private string _F_Time_104;
        public string F_Time_104
        {
            get { return _F_Time_104; }
            set
            {
                if (_F_Time_104 != value)
                {
                    _F_Time_104 = value;
                    RaisePropertyChanged("F_Time_104");
                }
            }
        }
               
            
        private string _C_Factor_105;
        public string C_Factor_105
        {
            get { return _C_Factor_105; }
            set
            {
                if (_C_Factor_105 != value)
                {
                    _C_Factor_105 = value;
                    RaisePropertyChanged("C_Factor_105");
                }
            }
        }
                
            
        private string _AvgTrq_106;
        public string AvgTrq_106
        {
            get { return _AvgTrq_106; }
            set
            {
                if (_AvgTrq_106 != value)
                {
                    _AvgTrq_106 = value;
                    RaisePropertyChanged("AvgTrq_106");
                }
            }
        }
               
            
        private string _NC_Power_107;
        public string NC_Power_107
        {
            get { return _NC_Power_107; }
            set
            {
                if (_NC_Power_107 != value)
                {
                    _NC_Power_107 = value;
                    RaisePropertyChanged("NC_Power_107");
                }
            }
        }
               
            
        private string _NC_SFC_108;
        public string NC_SFC_108
        {
            get { return _NC_SFC_108; }
            set
            {
                if (_NC_SFC_108 != value)
                {
                    _NC_SFC_108 = value;
                    RaisePropertyChanged("NC_SFC_108");
                }
            }
        }
             
            
        private string _Inj_Qty_109;
        public string Inj_Qty_109
        {
            get { return _Inj_Qty_109; }
            set
            {
                if (_Inj_Qty_109 != value)
                {
                    _Inj_Qty_109 = value;
                    RaisePropertyChanged("Inj_Qty_109");
                }
            }
        }
             
            
        private string _C_Trque_110;
        public string C_Trque_110
        {
            get { return _C_Trque_110; }
            set
            {
                if (_C_Trque_110 != value)
                {
                    _C_Trque_110 = value;
                    RaisePropertyChanged("C_Trque_110");
                }
            }
        }
               
           
        private string _C_Power_111;
        public string C_Power_111
        {
            get { return _C_Power_111; }
            set
            {
                if (_C_Power_111 != value)
                {
                    _C_Power_111 = value;
                    RaisePropertyChanged("C_Power_111");
                }
            }
        }
                
            
        private string _C_SFC_112;
        public string C_SFC_112
        {
            get { return _C_SFC_112; }
            set
            {
                if (_C_SFC_112 != value)
                {
                    _C_SFC_112 = value;
                    RaisePropertyChanged("C_SFC_112");
                }
            }
        } 
              
            
        private string _F_Flow_113;
        public string F_Flow_113
        {
            get { return _F_Flow_113; }
            set
            {
                if (_F_Flow_113 != value)
                {
                    _F_Flow_113 = value;
                    RaisePropertyChanged("F_Flow_113");
                }
            }
        }
                
            
        private string _Fuel_Flow_114;
        public string Fuel_Flow_114
        {
            get { return _Fuel_Flow_114; }
            set
            {
                if (_Fuel_Flow_114 != value)
                {
                    _Fuel_Flow_114 = value;
                    RaisePropertyChanged("Fuel_Flow_114");
                }
            }
        }
               
            
        private string _A_Power_hp_115;
        public string A_Power_hp_115
        {
            get { return _A_Power_hp_115; }
            set
            {
                if (_A_Power_hp_115 != value)
                {
                    _A_Power_hp_115 = value;
                    RaisePropertyChanged("A_Power_hp_115");
                }
            }
        }
               
            
        private string _C_Power_hp_116;
        public string C_Power_hp_116
        {
            get { return _C_Power_hp_116; }
            set
            {
                if (_C_Power_hp_116 != value)
                {
                    _C_Power_hp_116 = value;
                    RaisePropertyChanged("C_Power_hp_116");
                }
            }
        }
               
            
        private string _A_SFC_hp_117;
        public string A_SFC_hp_117
        {
            get { return _A_SFC_hp_117; }
            set
            {
                if (_A_SFC_hp_117 != value)
                {
                    _A_SFC_hp_117 = value;
                    RaisePropertyChanged("A_SFC_hp_117");
                }
            }
        }
                
            
        private string _C_SFC_hp_118;
        public string C_SFC_hp_118
        {
            get { return _C_SFC_hp_118; }
            set
            {
                if (_C_SFC_hp_118 != value)
                {
                    _C_SFC_hp_118 = value;
                    RaisePropertyChanged("C_SFC_hp_118");
                }
            }
        }
                
            
        private string _DiffPress_119;
        public string DiffPress_119
        {
            get { return _DiffPress_119; }
            set
            {
                if (_DiffPress_119 != value)
                {
                    _DiffPress_119 = value;
                    RaisePropertyChanged("DiffPress_119");
                }
            }
        }
               
            
        private string _Not_Prog_120;
        public string Not_Prog_120
        {
            get { return _Not_Prog_120; }
            set
            {
                if (_Not_Prog_120 != value)
                {
                    _Not_Prog_120 = value;
                    RaisePropertyChanged("Not_Prog_120");
                }
            }
        }
                
            
        private string _Not_Prog_121;
        public string Not_Prog_121
        {
            get { return _Not_Prog_121; }
            set
            {
                if (_Not_Prog_121 != value)
                {
                    _Not_Prog_121 = value;
                    RaisePropertyChanged("Not_Prog_121");
                }
            }
        }
               
            
        private string _Not_Prog_122;
        public string Not_Prog_122
        {
            get { return _Not_Prog_122; }
            set
            {
                if (_Not_Prog_122 != value)
                {
                    _Not_Prog_122 = value;
                    RaisePropertyChanged("Not_Prog_122");
                }
            }
        }
               
            
        private string _Strt_Tm_123;
        public string Strt_Tm_123
        {
            get { return _Strt_Tm_123; }
            set
            {
                if (_Strt_Tm_123 != value)
                {
                    _Strt_Tm_123 = value;
                    RaisePropertyChanged("Strt_Tm_123");
                }
            }
        }
              
            
        private string _ToTal_Hrs_124;
        public string ToTal_Hrs_124
        {
            get { return _ToTal_Hrs_124; }
            set
            {
                if (_ToTal_Hrs_124 != value)
                {
                    _ToTal_Hrs_124 = value;
                    RaisePropertyChanged("ToTal_Hrs_124");
                }
            }
        }
                
            
        private string _Alarm_125;
        public string Alarm_125
        {
            get { return _Alarm_125; }
            set
            {
                if (_Alarm_125 != value)
                {
                    _Alarm_125 = value;
                    RaisePropertyChanged("Alarm_125");
                }
            }
        }
                
            
        private string _tb_code;
        public string tb_code
        {
            get { return _tb_code; }
            set
            {
                if (_tb_code != value)
                {
                    _tb_code = value;
                    RaisePropertyChanged("tb_code");
                }
            }
        }
              
            
        private int _tb_rowId;
        public int tb_rowId
        {
            get { return _tb_rowId; }
            set
            {
                if (_tb_rowId != value)
                {
                    _tb_rowId = value;
                    RaisePropertyChanged("tb_rowId");
                }
            }
        }
               
            
        private string _ip_address;
        public string ip_address
        {
            get { return _ip_address; }
            set
            {
                if (_ip_address != value)
                {
                    _ip_address = value;
                    RaisePropertyChanged("ip_address");
                }
            }
        }
               

        private string _project;
        public string project
        {
            get { return _project; }
            set
            {
                if (_project != value)
                {
                    _project = value;
                    RaisePropertyChanged("project");
                }
            }
        }


        private string _eng_model;
        public string eng_model
        {
            get { return _eng_model; }
            set
            {
                if (_eng_model != value)
                {
                    _eng_model = value;
                    RaisePropertyChanged("eng_model");
                }
            }
        }
            

        private string _eng_no;
        public string eng_no
        {
            get { return _eng_no; }
            set
            {
                if (_eng_no != value)
                {
                    _eng_no = value;
                    RaisePropertyChanged("eng_no");
                }
            }
        }
                

        private string _test_type;
        public string test_type
        {
            get { return _test_type; }
            set
            {
                if (_test_type != value)
                {
                    _test_type = value;
                    RaisePropertyChanged("test_type");
                }
            }
                
        }
    }    
    public class RND_T010_B_Flip
    {
        public int id { get; set; }
        public int Pn { get; set; }
        public string f_name { get; set; }
        public string E_Speed_000 { get; set; }
        public string E_Torque_001 { get; set; }
        public string SFCReset_002 { get; set; }
        public string L_Weight_003 { get; set; }
        public string L_Time_004 { get; set; }
        public string F_Weight_005 { get; set; }
        public string T_WtrOut_006 { get; set; }
        public string T_Exhaust_007 { get; set; }
        public string P_LubOil_008 { get; set; }
        public string Not_Prog_009 { get; set; }
        public string Not_Prog_010 { get; set; }
        public string Not_Prog_011 { get; set; }
        public string Not_Prog_012 { get; set; }
        public string Not_Prog_013 { get; set; }
        public string Not_Prog_014 { get; set; }
        public string Not_Prog_015 { get; set; }
        public string Not_Prog_016 { get; set; }
        public string Not_Prog_017 { get; set; }
        public string Not_Prog_018 { get; set; }
        public string Not_Prog_019 { get; set; }
        public string Not_Prog_020 { get; set; }
        public string Not_Prog_021 { get; set; }
        public string Not_Prog_022 { get; set; }
        public string Not_Prog_023 { get; set; }
        public string Not_Prog_024 { get; set; }
        public string Not_Prog_025 { get; set; }
        public string Not_Prog_026 { get; set; }
        public string Not_Prog_027 { get; set; }
        public string Not_Prog_028 { get; set; }
        public string Not_Prog_029 { get; set; }
        public string Not_Prog_030 { get; set; }
        public string P_Ambient_031 { get; set; }
        public string P_WtrIn_032 { get; set; }
        public string P_WtrOut_033 { get; set; }
        public string Not_Prog_034 { get; set; }
        public string Not_Prog_035 { get; set; }
        public string Not_Prog_036 { get; set; }
        public string Not_Prog_037 { get; set; }
        public string Not_Prog_038 { get; set; }
        public string Not_Prog_039 { get; set; }
        public string Not_Prog_040 { get; set; }
        public string Not_Prog_041 { get; set; }
        public string Not_Prog_042 { get; set; }
        public string Not_Prog_043 { get; set; }
        public string Not_Prog_044 { get; set; }
        public string Not_Prog_045 { get; set; }
        public string Not_Prog_046 { get; set; }
        public string Not_Prog_047 { get; set; }
        public string Not_Prog_048 { get; set; }
        public string Not_Prog_049 { get; set; }
        public string Not_Prog_050 { get; set; }
        public string Not_Prog_051 { get; set; }
        public string Not_Prog_052 { get; set; }
        public string Not_Prog_053 { get; set; }
        public string Not_Prog_054 { get; set; }
        public string Not_Prog_055 { get; set; }
        public string Not_Prog_056 { get; set; }
        public string Not_Prog_057 { get; set; }
        public string Not_Prog_058 { get; set; }
        public string Not_Prog_059 { get; set; }
        public string Not_Prog_060 { get; set; }
        public string Not_Prog_061 { get; set; }
        public string Not_Prog_062 { get; set; }
        public string Not_Prog_063 { get; set; }
        public string Not_Prog_064 { get; set; }
        public string Not_Prog_065 { get; set; }
        public string Not_Prog_066 { get; set; }
        public string Not_Prog_067 { get; set; }
        public string Not_Prog_068 { get; set; }
        public string Not_Prog_069 { get; set; }
        public string Not_Prog_070 { get; set; }
        public string Not_Prog_071 { get; set; }
        public string Not_Prog_072 { get; set; }
        public string Not_Prog_073 { get; set; }
        public string Not_Prog_074 { get; set; }
        public string Not_Prog_075 { get; set; }
        public string Not_Prog_076 { get; set; }
        public string Not_Prog_077 { get; set; }
        public string Not_Prog_078 { get; set; }
        public string Not_Prog_079 { get; set; }
        public string Not_Prog_080 { get; set; }
        public string Not_Prog_081 { get; set; }
        public string Not_Prog_082 { get; set; }
        public string Not_Prog_083 { get; set; }
        public string Not_Prog_084 { get; set; }
        public string Not_Prog_085 { get; set; }
        public string NotProg_086 { get; set; }
        public string T_WI_PID_087 { get; set; }
        public string T_WO_PID_088 { get; set; }
        public string T_HTnkPID_089 { get; set; }
        public string T_PID4_090 { get; set; }
        public string Not_Prog_091 { get; set; }
        public string Not_Prog_092 { get; set; }
        public string Not_Prog_093 { get; set; }
        public string Not_Prog_094 { get; set; }
        public string Not_Prog_095 { get; set; }
        public string Not_Prog_096 { get; set; }
        public string Not_Prog_097 { get; set; }
        public string Not_Prog_098 { get; set; }
        public string Not_Prog_099 { get; set; }
        public string Not_Prog_100 { get; set; }
        public string SmkValue_101 { get; set; }
        public string BlowBy_102 { get; set; }
        public string SFCWt_103 { get; set; }
        public string F_Time_104 { get; set; }
        public string C_Factor_105 { get; set; }
        public string AvgTrq_106 { get; set; }
        public string NC_Power_107 { get; set; }
        public string NC_SFC_108 { get; set; }
        public string Inj_Qty_109 { get; set; }
        public string C_Trque_110 { get; set; }
        public string C_Power_111 { get; set; }
        public string C_SFC_112 { get; set; }
        public string F_Flow_113 { get; set; }
        public string Fuel_Flow_114 { get; set; }
        public string A_Power_hp_115 { get; set; }
        public string C_Power_hp_116 { get; set; }
        public string A_SFC_hp_117 { get; set; }
        public string C_SFC_hp_118 { get; set; }
        public string DiffPress_119 { get; set; }
        public string Not_Prog_120 { get; set; }
        public string Not_Prog_121 { get; set; }
        public string Not_Prog_122 { get; set; }
        public string Strt_Tm_123 { get; set; }
        public string ToTal_Hrs_124 { get; set; }
        public string Alarm_125 { get; set; }
        public string tb_code { get; set; }
        public int tb_rowId { get; set; }
        public string ip_address { get; set; }
        public string project { get; set; }
        public string eng_model { get; set; }
        public string eng_no { get; set; }
        public string test_type { get; set; }       
    }
    public class MultipleContext_RND_T010
    {
        public List<RND_T010> MasterEntity { get; set; }
        public ObservableCollection<RND_T010_A> AdminEntity { get; set; }
        public List<RND_T010_B_Flip> DashBoardEntity { get; set; }
        public List<RND_T010_A_P> TestBedNo { get; set; }
        public List<RND_T010_B_P> DAS_DashBoard { get; set; }
    }
}
