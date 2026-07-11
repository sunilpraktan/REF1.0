using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class ReflectionServiceRepository
    {
        public static byte[] InvokeGetDataMethod(string Request, string RequestOption, string RequestPath)
        {
            byte[] response = null;
            Type type = Type.GetType(RequestPath);
            if (type != null)
            {
                dynamic instance = Activator.CreateInstance(type);
                response = instance.GetData(Request, RequestOption);
            }
            return response;
        }
        
        public static byte[] InvokeInsertMethod(byte[] RequestStream, string Request, string RequestOption, string RequestPath)
        {
            byte[] response = null;
            Type type = Type.GetType(RequestPath);
            if (type != null)
            {
                dynamic instance = Activator.CreateInstance(type);
                response = instance.Insert(RequestStream,Request, RequestOption);
            }
            return response;
        }

        public static byte[] InvokeUpdateMethod(byte[] RequestStream, string Request, string RequestOption, string RequestPath)
        {
            byte[] response = null;
            Type type = Type.GetType(RequestPath);
            if (type != null)
            {
                dynamic instance = Activator.CreateInstance(type);
                response = instance.Update(RequestStream,Request, RequestOption);
            }
            return response;
        }

        public static byte[] InvokeDeleteMethod(string Request, string RequestOption, string RequestPath)
        {
            byte[] response = null;
            Type type = Type.GetType(RequestPath);
            if (type != null)
            {
                dynamic instance = Activator.CreateInstance(type);
                response = instance.Delete(Request, RequestOption);
            }
            return response;
        }

















        public static byte[] InvokeGetDataMethodTemp(string Request, string RequestOption, string RequestPath)
        {
            byte[] result = null;
            //Assembly assembly = Assembly.LoadFile("Reflection.BusinessLogic.dll");
            //Type type = assembly.GetType("Reflection.BusinessLogic.Class1");
            Type type = Type.GetType(RequestPath);
            if (type != null)
            {
                MethodInfo methodInfo = type.GetMethod(RequestOption);
                if (methodInfo != null)
                {
                    //object result = null;
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    object classInstance = Activator.CreateInstance(type, null);
                    if (parameters.Length == 0)
                    {
                        //This works fine
                        result = (byte[])methodInfo.Invoke(classInstance, null);
                    }
                    else
                    {
                        object[] parametersArray = new object[] { Request };

                        //The invoke does NOT work it throws "Object does not match target type"             
                        result = (byte[])methodInfo.Invoke(classInstance, parametersArray);
                    }
                }
            }

            //// second option Start
            //Type type2 = Type.GetType("POC_Object.Class1", true);
            //dynamic instance = Activator.CreateInstance(type);
            //var response = instance.Test("ssss");
            //// second option End


            return result;
        }
    }
}
