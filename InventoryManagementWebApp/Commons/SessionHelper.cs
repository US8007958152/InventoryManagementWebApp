using Entities.Users;
using Newtonsoft.Json;

namespace InventoryWebApp.Commons
{
    public static class SessionHelper
    {
        public static void SetSession(this ISession session,UserProfile userProfile)
        {
            string jsonString = JsonConvert.SerializeObject(userProfile);
            session.SetString("UserProfile",jsonString);
        }
        public static UserProfile GetSession(this ISession session)
        {
            string jsonString = session.GetString("UserProfile");
            UserProfile userProfile= string.IsNullOrEmpty(jsonString) ? null: JsonConvert.DeserializeObject<UserProfile>(jsonString);
            return userProfile;
        }
        public static void RemoveSession(this ISession session)
        {
            session.Remove("UserProfile");
        }
    }
}
