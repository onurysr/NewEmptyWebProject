using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewEmptyWebProject.Models
{
    public static class RoleModels //Identity Klasörünün içini Doldurduktan sonra burayı yaptık
    {
        public static string Admin = "Admin"; //görev atamsı değil sadece isim olarak admin değişkenine admin user'a user dedik.
        public static string User = "User";
        public static string Passive = "Passive";

        public static ICollection<string> Roles => new List<string> { Admin, User,Passive }; //Listeye entegre ettik.
    }
}
