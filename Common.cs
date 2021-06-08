using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_list
{
    class Common
    {// the method of how to store user details inside the windows form application came from here https://stackoverflow.com/questions/14599127/session-for-windows-forms-application-in-c-sharp
     //it works by storing the details in a common class that all pages in the application can call to 

        public static string UserName;
        public static int uID;
    }
}
