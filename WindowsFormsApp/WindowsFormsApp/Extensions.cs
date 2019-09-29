using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    public static class Extensions
    {
        public static bool IsEmpty(this string str)
        {
            return str?.Length == 0;
        }
    }
}
