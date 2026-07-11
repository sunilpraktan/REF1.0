//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Reflection.Presentation.Services
//{
//    public sealed class ValidIntegerAttribute : ValidationAttribute
//    {
//        public override bool IsValid(object value)
//        {
//            int num1;
//            var required = new RequiredAttribute();
//            //return required.IsValid(Convert.ToInt32(value));
//            return required.IsValid(int.TryParse(value.ToString(), out num1));
//        }

//    }
//}
