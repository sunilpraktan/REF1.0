using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Presentation.Services
{
    public class MailAccount
    {

        private string _host;
        public string Host
        {
            get { return _host; }
            set
            {
                if (_host != value)
                {
                    _host = value;
                }
            }
        }

        private int _port;
        public int Port
        {
            get { return _port; }
            set
            {
                if (_port != value)
                {
                    _port = value;
                }
            }
        }

        private bool _enableSSL;
        public bool EnableSSL
        {
            get { return _enableSSL; }
            set
            {
                if (_enableSSL != value)
                {
                    _enableSSL = value;
                }
            }
        }

        private int _TimeOut;
        public int TimeOut
        {
            get { return _TimeOut; }
            set
            {
                if (_TimeOut != value)
                {
                    _TimeOut = value;
                }
            }
        }

        private string _deliveryMethod;
        public string DeliveryMethod
        {
            get { return _deliveryMethod; }
            set
            {
                if (_deliveryMethod != value)
                {
                    _deliveryMethod = value;
                }
            }
        }

        private bool _defaultCredentials;
        public bool DefaultCredentials
        {
            get { return _defaultCredentials; }
            set
            {
                if (_defaultCredentials != value)
                {
                    _defaultCredentials = value;
                }
            }
        }

        private string _mailID;
        public string MailID
        {
            get { return _mailID; }
            set
            {
                if (_mailID != value)
                {
                    _mailID = value;
                }
            }
        }

        private string _displayName;
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (_displayName != value)
                {
                    _displayName = value;
                }
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                }
            }
        }

        private string _domain;
        public string Domain
        {
            get { return _domain; }
            set
            {
                if (_domain != value)
                {
                    _domain = value;
                }
            }
        }
    }
}
