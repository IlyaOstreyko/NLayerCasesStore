using NLayerCasesStore.DAL.EF;
using NLayerCasesStore.DAL.Entities;
using System.Linq;

namespace NLayerCasesStore.WEBMVC
{
    public class IfDBEmpty
    {
        public static void Initialize(CasesStoreContext context)
        {
            if (!context.Cases.Any())
            {
                context.Cases.AddRange(
                    new Case
                    {
                        Model = "iPhone X",
                        Company = "Apple",
                        Color = "Green",
                        Price = 15
                    },
                    new Case
                    {
                        Model = "iPhone 7",
                        Company = "Apple",
                        Color = "Black",
                        Price = 17
                    },
                    new Case
                    {
                        Model = "iPhone 8",
                        Company = "Apple",
                        Color = "Yellow",
                        Price = 16
                    }
                );
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        UserName = "admin",
                        UserMail = "ilyaostreyko@gmail.com",
                        UserPassword = "admin",
                        UserRole = "admin"
                    },
                    new User
                    {
                        UserName = "user",
                        UserMail = "ilya.ostreyko.96@mail.ru",
                        UserPassword = "user",
                        UserRole = "user"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
