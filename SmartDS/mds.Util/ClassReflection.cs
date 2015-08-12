using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.Util
{
    public class ClassReflection
    {

        public static List<T> GetList<T>(Dictionary<int, string> columns, List<string> result, char split) where T : new()
        {
             List<T> list = new List<T>();
            result.ForEach(a => {
                string[] values=a.Split(',');
                T t = new T();
                 Type type = t.GetType();
                foreach(var kv in columns){
                    var propertiy= type.GetProperty(kv.Value);
                    propertiy.SetValue(t,values[kv.Key],null);
                }
                list.Add(t);
            });
            return list;
        }

        public static T Get<T>(Dictionary<int, string> columns, string data, char split) where T : new()
        {
            
            T t = new T();
            if (string.IsNullOrEmpty(data))
                return default(T);
            string[] values = data.Split(split);
            Type type = t.GetType();
            foreach (var kv in columns)
            {
                var propertiy = type.GetProperty(kv.Value);
                propertiy.SetValue(t, values[kv.Key], null);
            }
            return t;
        }

        public static bool IsEquals<T>(T item, string propertyName, string configName)
        {
            Type type = typeof(T);
            var propertiy = type.GetProperty(propertyName);
            var pro=propertiy.GetValue(item, null);
            var isEquals = false;
            if (pro != null)
            {
                if (pro.ToString() == configName)
                    isEquals = true;
            }
            return isEquals;
        }
        public static Object CreateIntanceSafe(string classFullName)
        {
            try
            {
                Type classObject = Type.GetType(classFullName, true);
                var serviceClass = Activator.CreateInstance(classObject);
                return serviceClass;
            }
            catch {
                return null;
            }
        }
    }
}
