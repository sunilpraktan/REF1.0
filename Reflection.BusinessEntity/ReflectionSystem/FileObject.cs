using System;
using System.ComponentModel;

namespace Reflection.BusinessEntity.ReflectionSystem
{
    [Serializable]
    public class FileObject2 : INotifyPropertyChanged
    {
        #region Private Fields

        private string _filePath;
        private int _index;
        private bool _isUploaded;
        private string _newFileName;

        #endregion

        #region Properties
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                    OnPropertyChanged("FilePath");
                }
            }
        }

        public int Index
        {
            get { return _index; }
            set
            {
                if (_index != value)
                {
                    _index = value;
                    OnPropertyChanged("Index");
                }
            }
        }

        public bool IsUploaded
        {
            get { return _isUploaded; }
            set
            {
                if (_isUploaded != value)
                {
                    _isUploaded = value;
                    OnPropertyChanged("IsUploaded");
                }
            }
        }

        public string NewFileName
        {
            get { return _newFileName; }
            set
            {
                if (_newFileName != value)
                {
                    _newFileName = value;
                    OnPropertyChanged("NewFileName");
                }
            }
        }

        #endregion

        public FileObject2()
        { }

        public FileObject2(int index, string filePath)
        {
            _filePath = filePath;
            _index = index;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
