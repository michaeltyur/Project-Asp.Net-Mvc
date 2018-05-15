using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL
{
   public static class ApplicationStateExtension
    {
        public static T GetSetApplicationState<T>(this HttpApplicationState appState,string userName, string objectName, T objectValue)
        {
            appState.Lock();
            object obj = appState[userName + "/" + objectName];
            if (appState[userName + "/" + objectName] == null)
            {
                obj = objectValue;
                return default(T);
            }
            else return (T)obj;
             
        }
        public static IEnumerable<object> GetAllApplicationState<T>(this HttpApplicationState appState )
        {
            appState.Lock();
            String[] keys = new String[appState.Count];
            keys = appState.AllKeys;

            foreach (var key in keys)
            {
                yield return appState[key];
            }
        }
    }
}
