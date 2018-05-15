using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBInitializer
{
    public class ShopDBInitializer : DropCreateDatabaseAlways<ShopDbContext>
    {
        protected override void Seed(ShopDbContext context)
        {
            IList<Item> items = new List<Item>();

            IList<User> users = new List<User>();

            #region Users
            User admin = new User { UserName = "admin",
                                     FirstName ="Pepe",
                                     LastName ="Jins",
                                     Password = "123",
                                     PasswordConfirm = "123",
                                     Email = "mashak@sela.co.il",
                                     Image = ImageToByteArray.ImageByteArray("bob"),
                DOB =new DateTime(1980,01,10) };
            users.Add(admin);

            User superAdmin = new User { UserName = "super_admin", FirstName = "Michael", LastName = "Bobov", Password = "777", PasswordConfirm = "777", Email = "mashak@sela.co.il", DOB = new DateTime(1979, 01, 05) };
            users.Add(superAdmin);

            User user1 = new User { UserName = "bob",  FirstName = "Bob", LastName = "Silent", Password = "12345", PasswordConfirm = "12345", Email = "mashak@sela.co.il", DOB = new DateTime(1989, 10, 04) };
            users.Add(user1);

            User user2 = new User { UserName = "jay",  FirstName = "Jay", LastName = "Pupkin", Password = "54321", PasswordConfirm = "54321", Email = "mashak@sela.co.il", DOB = new DateTime(1969, 01, 04) };
            users.Add(user1);

            #endregion

            #region Items

            items.Add(new Item
            {
                ItemId = 1,
                Name = "Glock 17",
                ShortDescription = "The Glock pistol",
                LongDescription = "The Glock pistol, sometimes referred to by the manufacturer as a Glock 'Safe Action' pistol and colloquially as a Glock, is a series of polymer-framed, short recoil-operated, locked-breech semi-automatic pistols designed and produced by Glock Ges.m.b.H., located in Deutsch-Wagram, Austria. It entered Austrian military and police service by 1982 after it was the top performer on an exhaustive series of reliability and safety tests.",
                Price = 1100,
                Owner = user1,
                TimeCreation = new DateTime(2018,04,01),
                Image1 = ImageToByteArray.ImageByteArray("1.jpg",1),
                Image2 = ImageToByteArray.ImageByteArray("2.jpg",1),
                Image3 = ImageToByteArray.ImageByteArray("3.jpg",1)
            });
            items.Add(new Item
            {
                ItemId = 2,
                Name = "Colt",
                ShortDescription = "Colt Navy 51 Squarebeck",
                LongDescription= "The Colt Revolving Belt Pistol of Naval Caliber (i.e., .36 cal), later known as the Colt 1851 Navy or Navy Revolver, is a cap and ball revolver that was designed by Samuel Colt between 1847 and 1850. Colt first called this Revolver the Ranger model; but the designation Navy quickly took over",
                Price = 1500,
                Owner = user2,
                TimeCreation = new DateTime(2017, 01, 01),
                Image1 = ImageToByteArray.ImageByteArray("1.jpg", 2),
                Image2 = ImageToByteArray.ImageByteArray("2.jpg", 2),
                Image3 = ImageToByteArray.ImageByteArray("3.jpg", 2)

            });
            items.Add(new Item
            {
                ItemId = 3,
                Name = "PPSh-41",
                ShortDescription = "Shpagin machine pistol",
                LongDescription= "The PPSh-41 (pistolet-pulemyot Shpagina; Russian: Пистолет-пулемёт Шпагина;); is a Soviet submachine gun designed by Georgy Shpagin as a cheap, reliable, and simplified alternative to the PPD-40. Common nicknames are 'pe - pe - sha' (Russian: ППШ) from its three-letter prefix and 'papasha' (Russian: папаша), meaning 'daddy'.",
                Price = 1850,
                Owner = admin  ,
                TimeCreation = new DateTime(1999, 01, 01),
                Image1 = ImageToByteArray.ImageByteArray("1.jpg", 3),
                Image2 = ImageToByteArray.ImageByteArray("2.jpg", 3),
                Image3 = ImageToByteArray.ImageByteArray("3.jpg", 3)
            });
            items.Add(new Item
            {
                ItemId = 4,
                Name = "Luger",
                ShortDescription = "The Pistole Parabellum",
                LongDescription= "The Pistole Parabellum is a toggle-locked recoil-operated semi-automatic pistol produced in several models and by several nations from 1898 to 1948. The design was first patented by Georg Luger as an improvement upon the Borchardt Automatic Pistol, and was produced as the Parabellum Automatic Pistol, Borchardt-Luger System by the German arms manufacturer Deutsche Waffen- und Munitionsfabriken (DWM)",
                Price = 1350,
                Owner = superAdmin,
                TimeCreation = new DateTime(1987, 01, 01),
                Image1 = ImageToByteArray.ImageByteArray("1.jpg", 4),
                Image2 = ImageToByteArray.ImageByteArray("2.jpg", 4),
                Image3 = ImageToByteArray.ImageByteArray("3.jpg", 4)
            });
            items.Add(new Item
            {
                ItemId = 5,
                Name = "Winchester",
                ShortDescription = "Winchester Model 1894",
                LongDescription= "The Winchester Model 1894 rifle (also known as the Winchester 94 or Model 94) is a lever-action repeating rifle that became one of the most famous and popular hunting rifles of all time. It was designed by John Browning in 1894 and originally chambered to fire two metallic black powder cartridges, the .32-40 Winchester and .38-55 Winchester. It was the first rifle to chamber the smokeless powder round, the .30 WCF (Winchester Center Fire, in time becoming known as the .30-30) in 1895.",
                Price = 2222,
                Owner = user1,
                TimeCreation = new DateTime(1999, 01, 01),
                Image1 = ImageToByteArray.ImageByteArray("1.jpg", 5),
                Image2 = ImageToByteArray.ImageByteArray("2.jpg", 5),
                Image3 = ImageToByteArray.ImageByteArray("3.jpg", 5)
            });
            items.Add(new Item
            {
                ItemId = 6,
                Name = "Thompson",
                ShortDescription = "The Thompson submachine gun",
                LongDescription= "The Thompson submachine gun is an American submachine gun, invented by John T. Thompson in 1918, that became infamous during the Prohibition era, becoming a signature weapon of various organized crime syndicates in the United States. It was a common sight in the media of the time, being used by both law enforcement officers and criminals.",
                Price = 1440,
                Owner = user2,
                TimeCreation = new DateTime(1979, 01, 01),
                Image1 = ImageToByteArray.ImageByteArray("1.jpg", 6),
                Image2 = ImageToByteArray.ImageByteArray("2.jpg", 6),
                Image3 = ImageToByteArray.ImageByteArray("3.jpg", 6)
            });
            items.Add(new Item
            {
                ItemId = 7,
                Name = "Nagant",
                ShortDescription = "The Nagant M1895 Revolver",
                LongDescription= "The Nagant M1895 Revolver was a seven-shot, gas-seal revolver designed and produced by Belgian industrialist Léon Nagant for the Russian Empire.",
                Price = 1050,
                Owner = superAdmin,
                TimeCreation = new DateTime(2011, 01, 01),
                Image1 = ImageToByteArray.ImageByteArray("1.jpg", 7),
                Image2 = ImageToByteArray.ImageByteArray("2.jpg", 7),
                Image3 = ImageToByteArray.ImageByteArray("3.jpg", 7)
            });
            items.Add(new Item
            {
                ItemId = 8,
                Name = "Mauser",
                ShortDescription = "The Mauser C96 (Construktion 96)",
                LongDescription= "The Mauser C96 (Construktion 96) is a semi-automatic pistol that was originally produced by German arms manufacturer Mauser from 1896 to 1937",
                Price = 2343,
                Owner = user2,
                TimeCreation = new DateTime(2007, 01, 01),
                Image1 = ImageToByteArray.ImageByteArray("1.jpg", 8),
                Image2 = ImageToByteArray.ImageByteArray("2.jpg", 8),
                Image3 = ImageToByteArray.ImageByteArray("3.jpg", 8)
            });
            items.Add(new Item
            {
                ItemId = 9,
                Name = "TT",
                ShortDescription = "Russian semi-automatic pistol",
                LongDescription= "It was developed in the early 1930s by Fedor Tokarev as a service pistol for the Soviet military to replace the Nagant M1895 revolver that had been in use since Tsarist times, though it ended up being used in conjunction with rather than replacing the M1895. It served until 1952",
                Price = 970,
                Owner = admin,
                TimeCreation = new DateTime(2002, 01, 01),
                Image1 = ImageToByteArray.ImageByteArray("1.jpg", 9),
                Image2 = ImageToByteArray.ImageByteArray("2.jpg", 9),
                Image3 = ImageToByteArray.ImageByteArray("3.jpg", 9)
            });
            items.Add(new Item
            {
                ItemId = 10,
                Name = "M1911",
                ShortDescription = "Colt M1911",
                Price = 990,
                LongDescription= "The M1911 is a single-action, semi-automatic, magazine-fed, recoil-operated pistol chambered for the .45 ACP cartridge.[1] It served as the standard-issue sidearm for the United States Armed Forces from 1911 to 1986. It was widely used in World War I, World War II, the Korean War, and the Vietnam War",
                Owner = user1,
                TimeCreation = new DateTime(2000, 01, 01),
                Image1 = ImageToByteArray.ImageByteArray("1.jpg", 10),
                Image2 = ImageToByteArray.ImageByteArray("2.jpg", 10),
                Image3 = ImageToByteArray.ImageByteArray("3.jpg", 10)
            });
            items.Add(new Item
            {
                ItemId = 11,
                Name = "Desert Eagle",
                ShortDescription = "The IMI Desert Eagle",
                LongDescription= "The IMI Desert Eagle is a semi-automatic handgun notable for chambering the largest centerfire cartridge of any magazine-fed, self-loading pistol. Magnum Research Inc. (MRI) designed and developed the Desert Eagle. The design was refined and the pistols were manufactured by Israel Military Industries until 1995, when MRI shifted the manufacturing contract to Saco Defense in Saco, Maine.",
                Price = 1500,
                Owner = user2,
                TimeCreation = new DateTime(2009, 01, 01),
                Image1 = ImageToByteArray.ImageByteArray("1.jpg", 11),
                Image2 = ImageToByteArray.ImageByteArray("2.jpg", 11),
                Image3 = ImageToByteArray.ImageByteArray("3.jpg", 11)
            });
            items.Add(new Item
            {
                ItemId = 12,
                Name = "Uzi",
                ShortDescription = "The Uzi submachine gun",
                Price = 2127,
                LongDescription= "The Uzi (Hebrew: עוזי‬, officially cased as UZI) is a family of Israeli open-bolt, blowback-operated submachine guns. Smaller variants are considered to be machine pistols. The Uzi was one of the first weapons to use a telescoping bolt design which allows the magazine to be housed in the pistol grip for a shorter weapon.",
                Owner = superAdmin,
                TimeCreation = new DateTime(2014, 01, 01),
                Image1 = ImageToByteArray.ImageByteArray("1.jpg", 12),
                Image2 = ImageToByteArray.ImageByteArray("2.jpg", 12),
                Image3 = ImageToByteArray.ImageByteArray("3.jpg", 12)
            });
            #endregion

            foreach (var item in items)
               context.Items.Add(item);
            foreach (var user in users)
                context.Users.Add(user);
        }
    }
}
