using Reflection.BusinessEntity.Settings;
using Reflection.Presentation.Services;
using Reflection.WebServices.Gateway;
using System.IO;

namespace Reflection.Modules.Settings
{
    public class UserPersonalisation //: WindowViewModel<UserLevelSettings>, INotifyPropertyChanged
    {
        WebServiceRepository<UserLevelSettings> repository = new WebServiceRepository<UserLevelSettings>();

        public void SaveCurrentDesktop(string DesktopFile)
        {
            var tempFilePath = System.Environment.CurrentDirectory + "/" + DesktopFile;
            UserLevelSettings uset = new UserLevelSettings();

            if (File.Exists(tempFilePath))
            {
                byte[] FileData = File.ReadAllBytes(tempFilePath);
                uset.UserId = AppSessionState.UserID;
                uset.desktop_file = FileData;
                uset = repository.SaveWithReturnDomainObject<UserLevelSettings>(uset, "UserSetting", "UserSetting", "Reflection.BusinessLogic.UserPersonalisationBL");

            }

        }
    }
}
