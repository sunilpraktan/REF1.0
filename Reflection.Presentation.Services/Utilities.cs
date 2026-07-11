using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Presentation.Services
{
    public static class Utilities
    {
        public static bool ComparePropertiesTo(this Object a, Object b)
        {
            System.Reflection.PropertyInfo[] properties = a.GetType().GetProperties(); // get all the properties of object a

            foreach (var property in properties)
            {
                var propertyName = property.Name;

                object aValue = a.GetType().GetProperty(propertyName).GetValue(a, null);
                object bValue;

                try // try to get the same property from object b. maybe that property does not exist! 
                {
                    bValue = b.GetType().GetProperty(propertyName).GetValue(b, null);
                }
                catch
                {
                    return false;
                }

                if (propertyName.ToString() == "HasErrors")
                    continue;
                if (aValue == null && bValue == null)
                    continue;

                if (aValue.ToString().Trim() == null && bValue.ToString().Trim() == null)
                    continue;
                if (aValue == bValue)
                    continue;
                if (aValue == null && bValue != null)
                    return false;

                if (aValue != null && bValue == null)
                    return false;

                try
                {
                    if (aValue.ToString().Trim() == bValue.ToString().Trim())
                        continue;
                }
                catch
                {
                    continue;
                }

                if (aValue != null && bValue.ToString().Trim() == null)
                    continue;



                // if properties do not match return false
                if (aValue.GetHashCode() != bValue.GetHashCode())
                {
                    return false;
                }
            }

            return true;
        }
        
        public static bool CompareFieldsTo(this Object a, Object b)
        {
            System.Reflection.FieldInfo[] fields = a.GetType().GetFields(); // get all the properties of object a

            foreach (var field in fields)
            {
                var fieldName = field.Name;

                var aValue = a.GetType().GetField(fieldName).GetValue(a);

                object bValue;

                try // try to get the same property from object b. maybe that property does
                // not exist! 
                {
                    bValue = b.GetType().GetField(fieldName).GetValue(b);
                }
                catch
                {
                    return false;
                }

                if (aValue == null && bValue == null)
                    continue;

                if (aValue == null && bValue != null)
                    return false;

                if (aValue != null && bValue == null)
                    return false;


                // if properties do not match return false
                if (aValue.GetHashCode() != bValue.GetHashCode())
                {
                    return false;
                }
            }

            return true;
        }
        public static bool In<T>(this T source, params T[] list)
        {
            return list.Contains(source);
        }


        //// Condition based Remove Function
        //public static int Remove<T>(this ObservableCollection<T> coll, Func<T, bool> condition)
        //{
        //    var itemsToRemove = coll.Where(condition).ToList();

        //    foreach (var itemToRemove in itemsToRemove)
        //    {
        //        coll.Remove(itemToRemove);
        //    }

        //    return itemsToRemove.Count;
        //}

        //// Condition based Remove Function
        //public static void RemoveAll<T>(this ObservableCollection<T> collection,Func<T, bool> condition)
        //{
        //    for (int i = collection.Count - 1; i >= 0; i--)
        //    {
        //        if (condition(collection[i]))
        //        {
        //            collection.RemoveAt(i);
        //        }
        //    }
        //}

            //  Sort Order by to ObserverableCollection
        public static void Sort<T>(this ObservableCollection<T> observable) where T : IComparable<T>, IEquatable<T>
        {
            List<T> sorted = observable.OrderBy(x => x).ToList();

            int ptr = 0;
            while (ptr < sorted.Count)
            {
                if (!observable[ptr].Equals(sorted[ptr]))
                {
                    T t = observable[ptr];
                    observable.RemoveAt(ptr);
                    observable.Insert(sorted.IndexOf(t), t);
                }
                else
                {
                    ptr++;
                }
            }
        }

        public static string NullIf(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) { return null; }
            return value;
        }

        //Calculate Age from Date
        public static int CalculateAge(DateTime FromDate, DateTime ToDate)
        {
            int age = ToDate.Year - FromDate.Year;
            // Check if the birthday has occurred this year
            if (ToDate.Month < FromDate.Month || (ToDate.Month == FromDate.Month && ToDate.Day < FromDate.Day))
            {
                age--;
            }

            return age;
        }

        public static bool IsNumeric(string str)
        {
            return str.All(c => ".0123456789".Contains(c));
        }
    }

    public static class ObjectCloner
    {
        public static T CloneWithValuesOnly<T>(this T source) where T : new()
        {
            // Create a new instance of the object
            T newObject = new T();

            // Get all properties of the source object
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                // Only copy properties that can be read and written
                if (property.CanWrite && property.CanRead)
                {
                    // Get the value of the property from the source
                    var value = property.GetValue(source);
                    // Set the value on the new object
                    property.SetValue(newObject, value);
                }
            }

            // No event handlers or special logic copied
            return newObject;
        }
    }

    //public static class ObjectClonerSerializer
    //{
    //    public static T CloneWithValuesOnly<T>(this T source)
    //    {
    //        // Serialize the object to JSON (values only)
    //        var json = JsonSerializer.Serialize(source);
    //        // Deserialize back into a new object (no event handlers copied)
    //        return JsonSerializer.Deserialize<T>(json);
    //    }
    //}

}
