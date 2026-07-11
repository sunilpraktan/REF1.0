using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Reflection.BusinessEntity
{
    public class InputValidator : ValidationRule
    {
        public string Parameter1 { get; set; }
        public List<string> ListObject { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
            {
                //bool flg = ListObject.Contains(Parameter1);
                string strValue = value.ToString();

                string error = GetErrorMessage(Parameter1, value);
                if (ListObject == null)
                    return new ValidationResult(false, "Invalid input data.");
                else if (value == null)
                {
                    return new ValidationResult(false, "Invalid input data.");
                }
                else if (value == null || value.ToString().Trim() == "" || string.IsNullOrWhiteSpace(value.ToString()) == true || ListObject.FindIndex(x => x.Equals(value.ToString(), StringComparison.OrdinalIgnoreCase)) == -1)
                    return new ValidationResult(false, "Invalid input data.");
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, "Invalid input data.");
            }
        }

        public static string GetErrorMessage(string fieldName, object fieldValue, object nullValue = null)
        {
            string errorMessage = string.Empty;
            if (nullValue != null && nullValue.Equals(fieldValue))
                errorMessage = string.Format("You cannot leave the {0} field empty.", fieldName);
            if (fieldValue == null || string.IsNullOrEmpty(fieldValue.ToString()))
                errorMessage = string.Format("You cannot leave the {0} field empty.", fieldName);
            return errorMessage;
        }

    }

    public class CustomeValidationInput : DependencyObject
    {
        public static string GetParameter1(DependencyObject obj)
        {
            return (string)obj.GetValue(Parameter1Property);
        }
        public static void SetParameter1(DependencyObject obj, string value)
        {
            obj.SetValue(Parameter1Property, value);
        }
        public static readonly DependencyProperty Parameter1Property
          = DependencyProperty.RegisterAttached("Parameter1",
              typeof(string),
              typeof(CustomeValidationInput),
              new UIPropertyMetadata(null, OnAttachedPropertyChanged));

        public static List<string> GetListObject(DependencyObject obj)
        {
            return (List<string>)obj.GetValue(ListObjectProperty);
        }
        public static void SetListObject(DependencyObject obj, List<string> value)
        {
            obj.SetValue(ListObjectProperty, value);
        }
        public static readonly DependencyProperty ListObjectProperty
          = DependencyProperty.RegisterAttached("ListObject",
              typeof(List<string>),
              typeof(CustomeValidationInput),
              new UIPropertyMetadata(null, OnAttachedPropertyChanged));


        static void OnAttachedPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            // array of all fields which allow bindings:
            System.Reflection.FieldInfo[] properties
              = obj.GetType().GetFields(
                    System.Reflection.BindingFlags.Public
                  | System.Reflection.BindingFlags.Static
                  | System.Reflection.BindingFlags.FlattenHierarchy);
            // filter array for DependencyProperties:
            List<DependencyProperty> dependencypropertieslist = new List<DependencyProperty>();
            foreach (System.Reflection.FieldInfo fieldinfo in properties)
                if (fieldinfo.FieldType == typeof(DependencyProperty))
                    dependencypropertieslist.Add((DependencyProperty)fieldinfo.GetValue(null));
            // run through all DependencyProperties:
            foreach (DependencyProperty dp in dependencypropertieslist)
                // has DependencyProperty Binding?
                if (BindingOperations.IsDataBound(obj, dp))
                {
                    // cast Binding:
                    Binding binding = BindingOperations.GetBinding(obj, dp);
                    if (binding != null)
                    {
                        // loop over all ValidationRules:
                        foreach (ValidationRule validationrule in binding.ValidationRules)
                        {
                            // loop over all properties:
                            foreach (System.Reflection.PropertyInfo pi in validationrule.GetType().GetProperties())
                                if (pi.Name.Equals(e.Property.Name))
                                {
                                    // assign value:
                                    pi.SetValue(validationrule, e.NewValue, null);
                                }
                        }
                    }
                }
        }
    }

    public class Wrapper : DependencyObject
    {
        public static readonly DependencyProperty InputValueProperty =
             DependencyProperty.Register("InputValue", typeof(string),
             typeof(Wrapper), new FrameworkPropertyMetadata());

        public string InputValue
        {
            get { return (string)GetValue(InputValueProperty); }
            set { SetValue(InputValueProperty, value); }
        }


    }

    //public class BindingProxy : System.Windows.Freezable
    //{
    //    public static readonly DependencyProperty DataProperty =
    //        DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new PropertyMetadata(null));
    //    protected override Freezable CreateInstanceCore()
    //    {
    //        return new BindingProxy();
    //    }

    //    public object Data
    //    {
    //        get { return (object)GetValue(DataProperty); }
    //        set { SetValue(DataProperty, value); }
    //    }
    //}

    public static class ValidationBehavior
    {
        #region Attached Properties

        public static readonly DependencyProperty HasErrorProperty = DependencyProperty.RegisterAttached(
            "HasError",
            typeof(bool),
            typeof(ValidationBehavior),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, CoerceHasError));

        private static readonly DependencyProperty HasErrorDescriptorProperty = DependencyProperty.RegisterAttached(
            "HasErrorDescriptor",
            typeof(DependencyPropertyDescriptor),
            typeof(ValidationBehavior));

        #endregion

        private static DependencyPropertyDescriptor GetHasErrorDescriptor(DependencyObject d)
        {
            return (DependencyPropertyDescriptor)d.GetValue(HasErrorDescriptorProperty);
        }

        private static void SetHasErrorDescriptor(DependencyObject d, DependencyPropertyDescriptor value)
        {
            d.SetValue(HasErrorDescriptorProperty, value);
        }

        #region Attached Property Getters and setters

        public static bool GetHasError(DependencyObject d)
        {
            return (bool)d.GetValue(HasErrorProperty);
        }

        public static void SetHasError(DependencyObject d, bool value)
        {
            d.SetValue(HasErrorProperty, value);
        }

        #endregion

        #region CallBacks

        private static object CoerceHasError(DependencyObject d, object baseValue)
        {
            var result = (bool)baseValue;
            if (BindingOperations.IsDataBound(d, HasErrorProperty))
            {
                if (GetHasErrorDescriptor(d) == null)
                {
                    var desc = DependencyPropertyDescriptor.FromProperty(System.Windows.Controls.Validation.HasErrorProperty, d.GetType());
                    desc.AddValueChanged(d, OnHasErrorChanged);
                    SetHasErrorDescriptor(d, desc);
                    result = System.Windows.Controls.Validation.GetHasError(d);
                }
            }
            else
            {
                if (GetHasErrorDescriptor(d) != null)
                {
                    var desc = GetHasErrorDescriptor(d);
                    desc.RemoveValueChanged(d, OnHasErrorChanged);
                    SetHasErrorDescriptor(d, null);
                }
            }
            return result;
        }
        private static void OnHasErrorChanged(object sender, EventArgs e)
        {
            var d = sender as DependencyObject;
            if (d != null)
            {
                d.SetValue(HasErrorProperty, d.GetValue(System.Windows.Controls.Validation.HasErrorProperty));
            }
        }

        #endregion
    }
}
