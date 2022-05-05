using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NorthwindCore.Application.Mapping
{
    public static class Extension
    {
        public static T Changer<T>(this object source)
        {
            T hedef = Activator.CreateInstance<T>();
            Type kaynak = source.GetType();

            PropertyInfo[] kaynakProps = kaynak.GetProperties();
            PropertyInfo[] hedefProps = typeof(T).GetProperties();

            foreach (PropertyInfo pi in kaynakProps)
            {
                object value = pi.GetValue(source);
                PropertyInfo hp = hedefProps.FirstOrDefault(x => x.Name == pi.Name);

                hp.SetValue(hedef, value);
            }

            return hedef;
        }
    }
}
