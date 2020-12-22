using Newtonsoft.Json;

namespace VerusDate.Shared.Helper
{
    public static class ClassHelper
    {
        public static T1 Cast<T1>(this object obj) where T1 : class
        {
            return JsonConvert.DeserializeObject<T1>(JsonConvert.SerializeObject(obj));
        }
    }
}