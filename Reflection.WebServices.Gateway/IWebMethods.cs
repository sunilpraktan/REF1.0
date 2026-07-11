using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.WebServices.Gateway
{
    public interface IWebMethods<TDomainObject>
    {
        string Save<T>(TDomainObject domainObj, string RequestOption, string Module);
        TDomainObject SaveWithReturnDomainObject<T>(TDomainObject domainObj, string RequestOption, string Module);
        string Update<T>(TDomainObject domainObj, string RequestOption, string Module);
        //TDomainObject Update<TDomainObject>(TDomainObject domainObj, string RequestOption, string Module);
        string Delete(string request, string RequestOption, string Module);
        string Delete(int request, string RequestOption, string Module);
        string GetData(string Request, string RequestOption, string Module);
        List<TDomainObject> GetDataWithReturnDomainObject(string request, string RequestOption, string Module);
        List<TDomainObject> GetDataWithReturnDomainObject<T>(List<TDomainObject> domainObj, string Request, string RequestOption, string Module);

    }
}
