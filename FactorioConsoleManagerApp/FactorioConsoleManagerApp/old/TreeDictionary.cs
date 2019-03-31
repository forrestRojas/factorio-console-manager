using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.IO;
using System.Text;

namespace FactorioConsoleManagerApp.old
{
    /// <summary>
    /// Represents an Appsettings File Model.
    /// </summary>
    public class TreeDictionary<T> : DynamicObject
    {
        private T Value;
        private Dictionary<object, TreeDictionary<T>> SubDirectories;

        public TreeDictionary()
        {
            SubDirectories = new Dictionary<object, TreeDictionary<T>>();
        }

        public override bool TryGetMember(GetMemberBinder binder, out Object result)
        {
            if (!SubDirectories.ContainsKey(binder.Name))
                SubDirectories[binder.Name] = new TreeDictionary<T>();

            result = SubDirectories[binder.Name];
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, Object value)
        {
            if (!SubDirectories.ContainsKey(binder.Name))
                SubDirectories[binder.Name] = new TreeDictionary<T>();

            SubDirectories[binder.Name].Value = (T)value;
            return true;
        }

        //public override string ToString()
        //{
        //    return Value.ToString();
        //}

        public int Count()
        {
            return SubDirectories.Count + 1;
        }

        public bool ContainsKey(object key)
        {
            return SubDirectories.ContainsKey(key);
        }
    }
}
