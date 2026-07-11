using Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Markup;

namespace Reflection.Presentation.Resources
{
    //[MarkupExtensionReturnType(typeof(string))] 
    public class ReflectionResourcesRefExtension : ResourcesRefExtension
    {
        static ReflectionResourcesRefExtension()
        {
            RD = new ResourceDictionary()
                     {
                         Source = new Uri("pack://application:,,,/Reflection.Presentation.Resources;component/GeneralResourceDictionary.xaml")
                     };
        }
    }
}
