using System;
using System.Threading.Tasks;

namespace VerusDate.Web.Core
{
    public static class RefreshCore
    {
        public static event Func<Task> RefreshRequestedHead;

        public static event Func<Task> RefreshRequestedMenu;

        public static void RefreshHead()
        {
            RefreshRequestedHead?.Invoke();
        }

        public static void RefreshMenu()
        {
            RefreshRequestedMenu?.Invoke();
        }
    }
}