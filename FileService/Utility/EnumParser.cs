using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Utility
{
    public static class EnumParser
    {
        public static T TryParse<T>(string val)
        { 
            object enumeration = null;

            Enum.TryParse(typeof(T), val, true, out enumeration);

            return (T)enumeration;
        }
    }
}
