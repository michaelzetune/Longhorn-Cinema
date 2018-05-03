using LonghornCinemaFinalProject.Models;
using LonghornCinemaFinalProject.DAL;
using System.Data.Entity.Migrations;
using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace LonghornCinemaFinalProject.Migrations
{
    public class UserData
    {
        public void SeedUsers(AppDbContext db)
        {
            //create a user manager and a role manager to use for this method
            AppUserManager UserManager = new AppUserManager(new UserStore<AppUser>(db));

            AppUser c1 = db.Users.FirstOrDefault(u => u.Email == "cbaker@example.com");
            if (c1 == null)
            {
                c1 = new AppUser();
                c1.UserName = "cbaker@example.com";
                c1.LastName = "Baker";
                c1.FirstName = "Christopher";
                c1.Email = "cbaker@example.com";
                c1.Birthday = new DateTime(1949, 11, 23);
                c1.StreetAddress = "1245 Lake Anchorage Blvd.";
                c1.City = "Austin";
                c1.State = "TX";
                c1.ZipCode = 78705;
                c1.PhoneNumber = "5125550180";
                c1.PopcornPointsBalance = 110;
                var result = UserManager.Create(c1, "hello1");
                db.SaveChanges();
                c1 = db.Users.First(u => u.UserName == "cbaker@example.com");
            }

            if (UserManager.IsInRole(c1.Id, "Customer") == false)
            {
                UserManager.AddToRole(c1.Id, "Customer");
            }

            db.SaveChanges();

            

            AppUser c2 = db.Users.FirstOrDefault(u => u.Email == "banker@longhorn.net");
            if (c2 == null)
            {
                c2 = new AppUser();
                c2.UserName = "banker@longhorn.net";
                c2.LastName = "Banks";
                c2.FirstName = "Michelle";
                c2.Email = "banker@longhorn.net";
                c2.Birthday = new DateTime(1962, 11, 27);
                c2.StreetAddress = "1300 Tall Pine Lane";
                c2.City = "Austin";
                c2.State = "TX";
                c2.ZipCode = 78712;
                c2.PhoneNumber = "5125550183";
                c2.PopcornPointsBalance = 40;
                var result = UserManager.Create(c2, "potato");
                db.SaveChanges();
                c2 = db.Users.First(c => c.UserName == "banker@longhorn.net");
            }
            if (UserManager.IsInRole(c2.Id, "Customer") == false)
            {
                UserManager.AddToRole(c2.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c3 = db.Users.FirstOrDefault(u => u.Email == "franco@example.com");
            if (c3 == null)
            {
                c3 = new AppUser();
                c3.UserName = "franco@example.com";
                c3.LastName = "Broccolo";
                c3.FirstName = "Franco";
                c3.Email = "franco@example.com";
                c3.Birthday = new DateTime(1992, 10, 11);
                c3.StreetAddress = "62 Browning Road";
                c3.City = "Austin";
                c3.State = "TX";
                c3.ZipCode = 78704;
                c3.PhoneNumber = "5125550128";
                c3.PopcornPointsBalance = 30;
                var result = UserManager.Create(c3, "painting");
                db.SaveChanges();
                c3 = db.Users.First(c => c.UserName == "franco@example.com");
            }
            if (UserManager.IsInRole(c3.Id, "Customer") == false)
            {
                UserManager.AddToRole(c3.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c4 = db.Users.FirstOrDefault(u => u.Email == "wchang@example.com");
            if (c4 == null)
            {
                c4 = new AppUser();
                c4.UserName = "wchang@example.com";
                c4.LastName = "Chang";
                c4.FirstName = "Wendy";
                c4.Email = "wchang@example.com";
                c4.Birthday = new DateTime(1997, 5, 16);
                c4.StreetAddress = "202 Bellmont Hall";
                c4.City = "Round Rock";
                c4.State = "TX";
                c4.ZipCode = 78681;
                c4.PhoneNumber = "5125550133";
                c4.PopcornPointsBalance = 0;
                var result = UserManager.Create(c4, "texas1");
                db.SaveChanges();
                c4 = db.Users.First(c => c.UserName == "wchang@example.com");
            }
            if (UserManager.IsInRole(c4.Id, "Customer") == false)
            {
                UserManager.AddToRole(c4.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c5 = db.Users.FirstOrDefault(u => u.Email == "limchou@gogle.com");
            if (c5 == null)
            {
                c5 = new AppUser();
                c5.UserName = "limchou@gogle.com";
                c5.LastName = "Chou";
                c5.FirstName = "Lim";
                c5.Email = "limchou@gogle.com";
                c5.Birthday = new DateTime(1970, 4, 6);
                c5.StreetAddress = "1600 Teresa Lane";
                c5.City = "Austin";
                c5.State = "TX";
                c5.ZipCode = 78705;
                c5.PhoneNumber = "5125550102";
                c5.PopcornPointsBalance = 40;
                var result = UserManager.Create(c5, "Anchorage");
                db.SaveChanges();
                c5 = db.Users.First(c => c.UserName == "limchou@gogle.com");
            }
            if (UserManager.IsInRole(c5.Id, "Customer") == false)
            {
                UserManager.AddToRole(c5.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c6 = db.Users.FirstOrDefault(u => u.Email == "shdixon@aoll.com");
            if (c6 == null)
            {
                c6 = new AppUser();
                c6.UserName = "shdixon@aoll.com";
                c6.LastName = "Dixon";
                c6.FirstName = "Shan";
                c6.Email = "shdixon@aoll.com";
                c6.Birthday = new DateTime(1984, 1, 12);
                c6.StreetAddress = "234 Holston Circle";
                c6.City = "Austin";
                c6.State = "TX";
                c6.ZipCode = 78712;
                c6.PhoneNumber = "5125550146";
                c6.PopcornPointsBalance = 20;
                var result = UserManager.Create(c6, "pepperoni");
                db.SaveChanges();
                c6 = db.Users.First(c => c.UserName == "shdixon@aoll.com");
            }
            if (UserManager.IsInRole(c6.Id, "Customer") == false)
            {
                UserManager.AddToRole(c6.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c7 = db.Users.FirstOrDefault(u => u.Email == "j.b.evans@aheca.org");
            if (c7 == null)
            {
                c7 = new AppUser();
                c7.UserName = "j.b.evans@aheca.org";
                c7.LastName = "Evans";
                c7.FirstName = "Jim Bob";
                c7.Email = "j.b.evans@aheca.org";
                c7.Birthday = new DateTime(1959, 9, 9);
                c7.StreetAddress = "506 Farrell Circle";
                c7.City = "Georgetown";
                c7.State = "TX";
                c7.ZipCode = 78628;
                c7.PhoneNumber = "5125550170";
                c7.PopcornPointsBalance = 50;
                var result = UserManager.Create(c7, "longhorns");
                db.SaveChanges();
                c7 = db.Users.First(c => c.UserName == "j.b.evans@aheca.org");
            }
            if (UserManager.IsInRole(c7.Id, "Customer") == false)
            {
                UserManager.AddToRole(c7.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c8 = db.Users.FirstOrDefault(u => u.Email == "feeley@penguin.org");
            if (c8 == null)
            {
                c8 = new AppUser();
                c8.UserName = "feeley@penguin.org";
                c8.LastName = "Feeley";
                c8.FirstName = "Lou Ann";
                c8.Email = "feeley@penguin.org";
                c8.Birthday = new DateTime(2001, 1, 12);
                c8.StreetAddress = "600 S 8th Street W";
                c8.City = "Austin";
                c8.State = "TX";
                c8.ZipCode = 78746;
                c8.PhoneNumber = "5125550105";
                c8.PopcornPointsBalance = 170;
                var result = UserManager.Create(c8, "aggies");
                db.SaveChanges();
                c8 = db.Users.First(c => c.UserName == "feeley@penguin.org");
            }
            if (UserManager.IsInRole(c8.Id, "Customer") == false)
            {
                UserManager.AddToRole(c8.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c9 = db.Users.FirstOrDefault(u => u.Email == "tfreeley@minnetonka.ci.us");
            if (c9 == null)
            {
                c9 = new AppUser();
                c9.UserName = "tfreeley@minnetonka.ci.us";
                c9.LastName = "Freeley";
                c9.FirstName = "Tesa";
                c9.Email = "tfreeley@minnetonka.ci.us";
                c9.Birthday = new DateTime(1991, 2, 4);
                c9.StreetAddress = "4448 Fairview Ave.";
                c9.City = "Horseshoe Bay";
                c9.State = "TX";
                c9.ZipCode = 78657;
                c9.PhoneNumber = "5125550114";
                c9.PopcornPointsBalance = 160;
                var result = UserManager.Create(c9, "raiders");
                db.SaveChanges();
                c9 = db.Users.First(c => c.UserName == "tfreeley@minnetonka.ci.us");
            }
            if (UserManager.IsInRole(c9.Id, "Customer") == false)
            {
                UserManager.AddToRole(c9.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c10 = db.Users.FirstOrDefault(u => u.Email == "mgarcia@gogle.com");
            if (c10 == null)
            {
                c10 = new AppUser();
                c10.UserName = "mgarcia@gogle.com";
                c10.LastName = "Garcia";
                c10.FirstName = "Margaret";
                c10.Email = "mgarcia@gogle.com";
                c10.Birthday = new DateTime(1991, 10, 2);
                c10.StreetAddress = "594 Longview";
                c10.City = "Austin";
                c10.State = "TX";
                c10.ZipCode = 78727;
                c10.PhoneNumber = "5125550155";
                c10.PopcornPointsBalance = 10;
                var result = UserManager.Create(c10, "mustangs");
                db.SaveChanges();
                c10 = db.Users.First(c => c.UserName == "mgarcia@gogle.com");
            }
            if (UserManager.IsInRole(c10.Id, "Customer") == false)
            {
                UserManager.AddToRole(c10.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c11 = db.Users.FirstOrDefault(u => u.Email == "chaley@thug.com");
            if (c11 == null)
            {
                c11 = new AppUser();
                c11.UserName = "chaley@thug.com";
                c11.LastName = "Haley";
                c11.FirstName = "Charles";
                c11.Email = "chaley@thug.com";
                c11.Birthday = new DateTime(1974, 7, 10);
                c11.StreetAddress = "One Cowboy Pkwy";
                c11.City = "Austin";
                c11.State = "TX";
                c11.ZipCode = 78712;
                c11.PhoneNumber = "5125550116";
                c11.PopcornPointsBalance = 40;
                var result = UserManager.Create(c11, "onetime");
                db.SaveChanges();
                c11 = db.Users.First(c => c.UserName == "chaley@thug.com");
            }
            if (UserManager.IsInRole(c11.Id, "Customer") == false)
            {
                UserManager.AddToRole(c11.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c12 = db.Users.FirstOrDefault(u => u.Email == "jeffh@sonic.com");
            if (c12 == null)
            {
                c12 = new AppUser();
                c12.UserName = "jeffh@sonic.com";
                c12.LastName = "Hampton";
                c12.FirstName = "Jeffrey";
                c12.Email = "jeffh@sonic.com";
                c12.Birthday = new DateTime(2004, 3, 10);
                c12.StreetAddress = "337 38th St.";
                c12.City = "San Marcos";
                c12.State = "TX";
                c12.ZipCode = 78666;
                c12.PhoneNumber = "5125550150";
                c12.PopcornPointsBalance = 150;
                var result = UserManager.Create(c12, "hampton1");
                db.SaveChanges();
                c12 = db.Users.First(c => c.UserName == "jeffh@sonic.com");
            }
            if (UserManager.IsInRole(c12.Id, "Customer") == false)
            {
                UserManager.AddToRole(c12.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c13 = db.Users.FirstOrDefault(u => u.Email == "wjhearniii@umich.org");
            if (c13 == null)
            {
                c13 = new AppUser();
                c13.UserName = "wjhearniii@umich.org";
                c13.LastName = "Hearn";
                c13.FirstName = "John";
                c13.Email = "wjhearniii@umich.org";
                c13.Birthday = new DateTime(1950, 8, 5);
                c13.StreetAddress = "4225 North First";
                c13.City = "Austin";
                c13.State = "TX";
                c13.ZipCode = 78705;
                c13.PhoneNumber = "5125550196";
                c13.PopcornPointsBalance = 0;
                var result = UserManager.Create(c13, "jhearn22");
                db.SaveChanges();
                c13 = db.Users.First(c => c.UserName == "wjhearniii@umich.org");
            }
            if (UserManager.IsInRole(c13.Id, "Customer") == false)
            {
                UserManager.AddToRole(c13.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c14 = db.Users.FirstOrDefault(u => u.Email == "ahick@yaho.com");
            if (c14 == null)
            {
                c14 = new AppUser();
                c14.UserName = "ahick@yaho.com";
                c14.LastName = "Hicks";
                c14.FirstName = "Anthony";
                c14.Email = "ahick@yaho.com";
                c14.Birthday = new DateTime(2004, 12, 8);
                c14.StreetAddress = "32 NE Garden Ln., Ste 910";
                c14.City = "Austin";
                c14.State = "TX";
                c14.ZipCode = 78712;
                c14.PhoneNumber = "5125550188";
                c14.PopcornPointsBalance = 60;
                var result = UserManager.Create(c14, "hickhickup");
                db.SaveChanges();
                c14 = db.Users.First(c => c.UserName == "ahick@yaho.com");
            }
            if (UserManager.IsInRole(c14.Id, "Customer") == false)
            {
                UserManager.AddToRole(c14.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c15 = db.Users.FirstOrDefault(u => u.Email == "ingram@jack.com");
            if (c15 == null)
            {
                c15 = new AppUser();
                c15.UserName = "ingram@jack.com";
                c15.LastName = "Ingram";
                c15.FirstName = "Brad";
                c15.Email = "ingram@jack.com";
                c15.Birthday = new DateTime(2001, 9, 5);
                c15.StreetAddress = "6548 La Posada Ct.";
                c15.City = "New York";
                c15.State = "NY";
                c15.ZipCode = 10101;
                c15.PhoneNumber = "5125550116";
                c15.PopcornPointsBalance = 20;
                var result = UserManager.Create(c15, "ingram2015");
                db.SaveChanges();
                c15 = db.Users.First(c => c.UserName == "ingram@jack.com");
            }
            if (UserManager.IsInRole(c15.Id, "Customer") == false)
            {
                UserManager.AddToRole(c15.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c16 = db.Users.FirstOrDefault(u => u.Email == "toddj@yourmom.com");
            if (c16 == null)
            {
                c16 = new AppUser();
                c16.UserName = "toddj@yourmom.com";
                c16.LastName = "Jacobs";
                c16.FirstName = "Todd";
                c16.Email = "toddj@yourmom.com";
                c16.Birthday = new DateTime(1999, 1, 20);
                c16.StreetAddress = "4564 Elm St.";
                c16.City = "Austin";
                c16.State = "TX";
                c16.ZipCode = 78729;
                c16.PhoneNumber = "5125550166";
                c16.PopcornPointsBalance = 170;
                var result = UserManager.Create(c16, "toddy25");
                db.SaveChanges();
                c16 = db.Users.First(c => c.UserName == "toddj@yourmom.com");
            }
            if (UserManager.IsInRole(c16.Id, "Customer") == false)
            {
                UserManager.AddToRole(c16.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c17 = db.Users.FirstOrDefault(u => u.Email == "thequeen@aska.net");
            if (c17 == null)
            {
                c17 = new AppUser();
                c17.UserName = "thequeen@aska.net";
                c17.LastName = "Lawrence";
                c17.FirstName = "Victoria";
                c17.Email = "thequeen@aska.net";
                c17.Birthday = new DateTime(2000, 4, 14);
                c17.StreetAddress = "6639 Butterfly Ln.";
                c17.City = "Beverly Hills";
                c17.State = "CA";
                c17.ZipCode = 90210;
                c17.PhoneNumber = "5125550173";
                c17.PopcornPointsBalance = 130;
                var result = UserManager.Create(c17, "something");
                db.SaveChanges();
                c17 = db.Users.First(c => c.UserName == "thequeen@aska.net");
            }
            if (UserManager.IsInRole(c17.Id, "Customer") == false)
            {
                UserManager.AddToRole(c17.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c18 = db.Users.FirstOrDefault(u => u.Email == "linebacker@gogle.com");
            if (c18 == null)
            {
                c18 = new AppUser();
                c18.UserName = "linebacker@gogle.com";
                c18.LastName = "Lineback";
                c18.FirstName = "Erik";
                c18.Email = "linebacker@gogle.com";
                c18.Birthday = new DateTime(2003, 12, 2);
                c18.StreetAddress = "1300 Netherland St";
                c18.City = "Austin";
                c18.State = "TX";
                c18.ZipCode = 78758;
                c18.PhoneNumber = "5125550167";
                c18.PopcornPointsBalance = 60;
                var result = UserManager.Create(c18, "Password1");
                db.SaveChanges();
                c18 = db.Users.First(c => c.UserName == "linebacker@gogle.com");
            }
            if (UserManager.IsInRole(c18.Id, "Customer") == false)
            {
                UserManager.AddToRole(c18.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c19 = db.Users.FirstOrDefault(u => u.Email == "elowe@netscare.net");
            if (c19 == null)
            {
                c19 = new AppUser();
                c19.UserName = "elowe@netscare.net";
                c19.LastName = "Lowe";
                c19.FirstName = "Ernest";
                c19.Email = "elowe@netscare.net";
                c19.Birthday = new DateTime(1977, 12, 7);
                c19.StreetAddress = "3201 Pine Drive";
                c19.City = "New Braunfels";
                c19.State = "TX";
                c19.ZipCode = 78130;
                c19.PhoneNumber = "5125550187";
                c19.PopcornPointsBalance = 20;
                var result = UserManager.Create(c19, "aclfest2017");
                db.SaveChanges();
                c19 = db.Users.First(c => c.UserName == "elowe@netscare.net");
            }
            if (UserManager.IsInRole(c19.Id, "Customer") == false)
            {
                UserManager.AddToRole(c19.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c20 = db.Users.FirstOrDefault(u => u.Email == "cluce@gogle.com");
            if (c20 == null)
            {
                c20 = new AppUser();
                c20.UserName = "cluce@gogle.com";
                c20.LastName = "Luce";
                c20.FirstName = "Chuck";
                c20.Email = "cluce@gogle.com";
                c20.Birthday = new DateTime(1949, 3, 16);
                c20.StreetAddress = "2345 Rolling Clouds";
                c20.City = "Cactus";
                c20.State = "TX";
                c20.ZipCode = 79013;
                c20.PhoneNumber = "5125550141";
                c20.PopcornPointsBalance = 180;
                var result = UserManager.Create(c20, "nothinggood");
                db.SaveChanges();
                c20 = db.Users.First(c => c.UserName == "cluce@gogle.com");
            }
            if (UserManager.IsInRole(c20.Id, "Customer") == false)
            {
                UserManager.AddToRole(c20.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c21 = db.Users.FirstOrDefault(u => u.Email == "mackcloud@george.com");
            if (c21 == null)
            {
                c21 = new AppUser();
                c21.UserName = "mackcloud@george.com";
                c21.LastName = "MacLeod";
                c21.FirstName = "Jennifer";
                c21.Email = "mackcloud@george.com";
                c21.Birthday = new DateTime(1947, 2, 21);
                c21.StreetAddress = "2504 Far West Blvd.";
                c21.City = "Marble Falls";
                c21.State = "TX";
                c21.ZipCode = 78654;
                c21.PhoneNumber = "5125550185";
                c21.PopcornPointsBalance = 170;
                var result = UserManager.Create(c21, "whatever");
                db.SaveChanges();
                c21 = db.Users.First(c => c.UserName == "mackcloud@george.com");
            }
            if (UserManager.IsInRole(c21.Id, "Customer") == false)
            {
                UserManager.AddToRole(c21.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c22 = db.Users.FirstOrDefault(u => u.Email == "cmartin@beets.com");
            if (c22 == null)
            {
                c22 = new AppUser();
                c22.UserName = "cmartin@beets.com";
                c22.LastName = "Markham";
                c22.FirstName = "Elizabeth";
                c22.Email = "cmartin@beets.com";
                c22.Birthday = new DateTime(1972, 3, 20);
                c22.StreetAddress = "7861 Chevy Chase";
                c22.City = "Kissimmee";
                c22.State = "FL";
                c22.ZipCode = 34741;
                c22.PhoneNumber = "5125550134";
                c22.PopcornPointsBalance = 100;
                var result = UserManager.Create(c22, "whocares");
                db.SaveChanges();
                c22 = db.Users.First(c => c.UserName == "cmartin@beets.com");
            }
            if (UserManager.IsInRole(c22.Id, "Customer") == false)
            {
                UserManager.AddToRole(c22.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c23 = db.Users.FirstOrDefault(u => u.Email == "clarence@yoho.com");
            if (c23 == null)
            {
                c23 = new AppUser();
                c23.UserName = "clarence@yoho.com";
                c23.LastName = "Martin";
                c23.FirstName = "Clarence";
                c23.Email = "clarence@yoho.com";
                c23.Birthday = new DateTime(1992, 7, 19);
                c23.StreetAddress = "87 Alcedo St.";
                c23.City = "Austin";
                c23.State = "TX";
                c23.ZipCode = 78709;
                c23.PhoneNumber = "5125550151";
                c23.PopcornPointsBalance = 130;
                var result = UserManager.Create(c23, "xcellent");
                db.SaveChanges();
                c23 = db.Users.First(c => c.UserName == "clarence@yoho.com");
            }
            if (UserManager.IsInRole(c23.Id, "Customer") == false)
            {
                UserManager.AddToRole(c23.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c24 = db.Users.FirstOrDefault(u => u.Email == "gregmartinez@drdre.com");
            if (c24 == null)
            {
                c24 = new AppUser();
                c24.UserName = "gregmartinez@drdre.com";
                c24.LastName = "Martinez";
                c24.FirstName = "Gregory";
                c24.Email = "gregmartinez@drdre.com";
                c24.Birthday = new DateTime(1947, 5, 28);
                c24.StreetAddress = "8295 Sunset Blvd.";
                c24.City = "Red Rock";
                c24.State = "TX";
                c24.ZipCode = 78662;
                c24.PhoneNumber = "5125550120";
                c24.PopcornPointsBalance = 20;
                var result = UserManager.Create(c24, "snowsnow");
                db.SaveChanges();
                c24 = db.Users.First(c => c.UserName == "gregmartinez@drdre.com");
            }
            if (UserManager.IsInRole(c24.Id, "Customer") == false)
            {
                UserManager.AddToRole(c24.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c25 = db.Users.FirstOrDefault(u => u.Email == "cmiller@bob.com");
            if (c25 == null)
            {
                c25 = new AppUser();
                c25.UserName = "cmiller@bob.com";
                c25.LastName = "Miller";
                c25.FirstName = "Charles";
                c25.Email = "cmiller@bob.com";
                c25.Birthday = new DateTime(1990, 10, 15);
                c25.StreetAddress = "8962 Main St.";
                c25.City = "South Padre Island";
                c25.State = "TX";
                c25.ZipCode = 78597;
                c25.PhoneNumber = "5125550198";
                c25.PopcornPointsBalance = 20;
                var result = UserManager.Create(c25, "mydogspot");
                db.SaveChanges();
                c25 = db.Users.First(c => c.UserName == "cmiller@bob.com");
            }
            if (UserManager.IsInRole(c25.Id, "Customer") == false)
            {
                UserManager.AddToRole(c25.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c26 = db.Users.FirstOrDefault(u => u.Email == "knelson@aoll.com");
            if (c26 == null)
            {
                c26 = new AppUser();
                c26.UserName = "knelson@aoll.com";
                c26.LastName = "Nelson";
                c26.FirstName = "Kelly";
                c26.Email = "knelson@aoll.com";
                c26.Birthday = new DateTime(1971, 7, 13);
                c26.StreetAddress = "2601 Red River";
                c26.City = "Disney";
                c26.State = "OK";
                c26.ZipCode = 74340;
                c26.PhoneNumber = "5125550177";
                c26.PopcornPointsBalance = 110;
                var result = UserManager.Create(c26, "spotmydog");
                db.SaveChanges();
                c26 = db.Users.First(c => c.UserName == "knelson@aoll.com");
            }
            if (UserManager.IsInRole(c26.Id, "Customer") == false)
            {
                UserManager.AddToRole(c26.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c27 = db.Users.FirstOrDefault(u => u.Email == "joewin@xfactor.com");
            if (c27 == null)
            {
                c27 = new AppUser();
                c27.UserName = "joewin@xfactor.com";
                c27.LastName = "Nguyen";
                c27.FirstName = "Joe";
                c27.Email = "joewin@xfactor.com";
                c27.Birthday = new DateTime(1984, 3, 17);
                c27.StreetAddress = "1249 4th SW St.";
                c27.City = "Del Rio";
                c27.State = "TX";
                c27.ZipCode = 78841;
                c27.PhoneNumber = "5125550174";
                c27.PopcornPointsBalance = 150;
                var result = UserManager.Create(c27, "joejoejoe");
                db.SaveChanges();
                c27 = db.Users.First(c => c.UserName == "joewin@xfactor.com");
            }
            if (UserManager.IsInRole(c27.Id, "Customer") == false)
            {
                UserManager.AddToRole(c27.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c28 = db.Users.FirstOrDefault(u => u.Email == "orielly@foxnews.cnn");
            if (c28 == null)
            {
                c28 = new AppUser();
                c28.UserName = "orielly@foxnews.cnn";
                c28.LastName = "O'Reilly";
                c28.FirstName = "Bill";
                c28.Email = "orielly@foxnews.cnn";
                c28.Birthday = new DateTime(1959, 7, 8);
                c28.StreetAddress = "8800 Gringo Drive";
                c28.City = "Austin";
                c28.State = "TX";
                c28.ZipCode = 78746;
                c28.PhoneNumber = "5125550167";
                c28.PopcornPointsBalance = 190;
                var result = UserManager.Create(c28, "billyboy");
                db.SaveChanges();
                c28 = db.Users.First(c => c.UserName == "orielly@foxnews.cnn");
            }
            if (UserManager.IsInRole(c28.Id, "Customer") == false)
            {
                UserManager.AddToRole(c28.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c29 = db.Users.FirstOrDefault(u => u.Email == "ankaisrad@gogle.com");
            if (c29 == null)
            {
                c29 = new AppUser();
                c29.UserName = "ankaisrad@gogle.com";
                c29.LastName = "Radkovich";
                c29.FirstName = "Anka";
                c29.Email = "ankaisrad@gogle.com";
                c29.Birthday = new DateTime(1966, 5, 19);
                c29.StreetAddress = "1300 Elliott Pl";
                c29.City = "Austin";
                c29.State = "TX";
                c29.ZipCode = 78712;
                c29.PhoneNumber = "5125550151";
                c29.PopcornPointsBalance = 120;
                var result = UserManager.Create(c29, "radgirl");
                db.SaveChanges();
                c29 = db.Users.First(c => c.UserName == "ankaisrad@gogle.com");
            }
            if (UserManager.IsInRole(c29.Id, "Customer") == false)
            {
                UserManager.AddToRole(c29.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c30 = db.Users.FirstOrDefault(u => u.Email == "megrhodes@freserve.co.uk");
            if (c30 == null)
            {
                c30 = new AppUser();
                c30.UserName = "megrhodes@freserve.co.uk";
                c30.LastName = "Rhodes";
                c30.FirstName = "Megan";
                c30.Email = "megrhodes@freserve.co.uk";
                c30.Birthday = new DateTime(1965, 3, 12);
                c30.StreetAddress = "4587 Enfield Rd.";
                c30.City = "Austin";
                c30.State = "TX";
                c30.ZipCode = 78705;
                c30.PhoneNumber = "5125550133";
                c30.PopcornPointsBalance = 190;
                var result = UserManager.Create(c30, "meganr34");
                db.SaveChanges();
                c30 = db.Users.First(c => c.UserName == "megrhodes@freserve.co.uk");
            }
            if (UserManager.IsInRole(c30.Id, "Customer") == false)
            {
                UserManager.AddToRole(c30.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c31 = db.Users.FirstOrDefault(u => u.Email == "erynrice@aoll.com");
            if (c31 == null)
            {
                c31 = new AppUser();
                c31.UserName = "erynrice@aoll.com";
                c31.LastName = "Rice";
                c31.FirstName = "Eryn";
                c31.Email = "erynrice@aoll.com";
                c31.Birthday = new DateTime(1975, 4, 28);
                c31.StreetAddress = "3405 Rio Grande";
                c31.City = "Austin";
                c31.State = "TX";
                c31.ZipCode = 78785;
                c31.PhoneNumber = "5125550196";
                c31.PopcornPointsBalance = 190;
                var result = UserManager.Create(c31, "ricearoni");
                db.SaveChanges();
                c31 = db.Users.First(c => c.UserName == "erynrice@aoll.com");
            }
            if (UserManager.IsInRole(c31.Id, "Customer") == false)
            {
                UserManager.AddToRole(c31.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c32 = db.Users.FirstOrDefault(u => u.Email == "jorge@noclue.com");
            if (c32 == null)
            {
                c32 = new AppUser();
                c32.UserName = "jorge@noclue.com";
                c32.LastName = "Rodriguez";
                c32.FirstName = "Jorge";
                c32.Email = "jorge@noclue.com";
                c32.Birthday = new DateTime(1953, 12, 8);
                c32.StreetAddress = "6788 Cotter Street";
                c32.City = "Littlefield";
                c32.State = "TX";
                c32.ZipCode = 79339;
                c32.PhoneNumber = "5125550141";
                c32.PopcornPointsBalance = 20;
                var result = UserManager.Create(c32, "jrod2017");
                db.SaveChanges();
                c32 = db.Users.First(c => c.UserName == "jorge@noclue.com");
            }
            if (UserManager.IsInRole(c32.Id, "Customer") == false)
            {
                UserManager.AddToRole(c32.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c33 = db.Users.FirstOrDefault(u => u.Email == "mrrogers@lovelyday.com");
            if (c33 == null)
            {
                c33 = new AppUser();
                c33.UserName = "mrrogers@lovelyday.com";
                c33.LastName = "Rogers";
                c33.FirstName = "Allen";
                c33.Email = "mrrogers@lovelyday.com";
                c33.Birthday = new DateTime(1973, 4, 22);
                c33.StreetAddress = "4965 Oak Hill";
                c33.City = "Austin";
                c33.State = "TX";
                c33.ZipCode = 78733;
                c33.PhoneNumber = "5125550189";
                c33.PopcornPointsBalance = 100;
                var result = UserManager.Create(c33, "rogerthat");
                db.SaveChanges();
                c33 = db.Users.First(c => c.UserName == "mrrogers@lovelyday.com");
            }
            if (UserManager.IsInRole(c33.Id, "Customer") == false)
            {
                UserManager.AddToRole(c33.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c34 = db.Users.FirstOrDefault(u => u.Email == "stjean@athome.com");
            if (c34 == null)
            {
                c34 = new AppUser();
                c34.UserName = "stjean@athome.com";
                c34.LastName = "Saint-Jean";
                c34.FirstName = "Olivier";
                c34.Email = "stjean@athome.com";
                c34.Birthday = new DateTime(1995, 2, 19);
                c34.StreetAddress = "255 Toncray Dr.";
                c34.City = "Austin";
                c34.State = "TX";
                c34.ZipCode = 78755;
                c34.PhoneNumber = "5125550152";
                c34.PopcornPointsBalance = 250;
                var result = UserManager.Create(c34, "bunnyhop");
                db.SaveChanges();
                c34 = db.Users.First(c => c.UserName == "stjean@athome.com");
            }
            if (UserManager.IsInRole(c34.Id, "Customer") == false)
            {
                UserManager.AddToRole(c34.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c35 = db.Users.FirstOrDefault(u => u.Email == "saunders@pen.com");
            if (c35 == null)
            {
                c35 = new AppUser();
                c35.UserName = "saunders@pen.com";
                c35.LastName = "Saunders";
                c35.FirstName = "Sarah";
                c35.Email = "saunders@pen.com";
                c35.Birthday = new DateTime(1978, 2, 19);
                c35.StreetAddress = "332 Avenue C";
                c35.City = "Austin";
                c35.State = "TX";
                c35.ZipCode = 78701;
                c35.PhoneNumber = "5125550146";
                c35.PopcornPointsBalance = 40;
                var result = UserManager.Create(c35, "penguin12");
                db.SaveChanges();
                c35 = db.Users.First(c => c.UserName == "saunders@pen.com");
            }
            if (UserManager.IsInRole(c35.Id, "Customer") == false)
            {
                UserManager.AddToRole(c35.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c36 = db.Users.FirstOrDefault(u => u.Email == "willsheff@email.com");
            if (c36 == null)
            {
                c36 = new AppUser();
                c36.UserName = "willsheff@email.com";
                c36.LastName = "Sewell";
                c36.FirstName = "William";
                c36.Email = "willsheff@email.com";
                c36.Birthday = new DateTime(2004, 12, 23);
                c36.StreetAddress = "2365 51st St.";
                c36.City = "El Paso";
                c36.State = "TX";
                c36.ZipCode = 79953;
                c36.PhoneNumber = "5125550192";
                c36.PopcornPointsBalance = 200;
                var result = UserManager.Create(c36, "alaskaboy");
                db.SaveChanges();
                c36 = db.Users.First(c => c.UserName == "willsheff@email.com");
            }
            if (UserManager.IsInRole(c36.Id, "Customer") == false)
            {
                UserManager.AddToRole(c36.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c37 = db.Users.FirstOrDefault(u => u.Email == "sheffiled@gogle.com");
            if (c37 == null)
            {
                c37 = new AppUser();
                c37.UserName = "sheffiled@gogle.com";
                c37.LastName = "Sheffield";
                c37.FirstName = "Martin";
                c37.Email = "sheffiled@gogle.com";
                c37.Birthday = new DateTime(1960, 5, 8);
                c37.StreetAddress = "3886 Avenue A";
                c37.City = "Balmorhea";
                c37.State = "TX";
                c37.ZipCode = 79718;
                c37.PhoneNumber = "5125550131";
                c37.PopcornPointsBalance = 130;
                var result = UserManager.Create(c37, "martin1234");
                db.SaveChanges();
                c37 = db.Users.First(c => c.UserName == "sheffiled@gogle.com");
            }
            if (UserManager.IsInRole(c37.Id, "Customer") == false)
            {
                UserManager.AddToRole(c37.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c38 = db.Users.FirstOrDefault(u => u.Email == "johnsmith187@aoll.com");
            if (c38 == null)
            {
                c38 = new AppUser();
                c38.UserName = "johnsmith187@aoll.com";
                c38.LastName = "Smith";
                c38.FirstName = "John";
                c38.Email = "johnsmith187@aoll.com";
                c38.Birthday = new DateTime(1955, 6, 25);
                c38.StreetAddress = "23 Hidden Forge Dr.";
                c38.City = "Austin";
                c38.State = "TX";
                c38.ZipCode = 78760;
                c38.PhoneNumber = "5125550190";
                c38.PopcornPointsBalance = 130;
                var result = UserManager.Create(c38, "smitty444");
                db.SaveChanges();
                c38 = db.Users.First(c => c.UserName == "johnsmith187@aoll.com");
            }
            if (UserManager.IsInRole(c38.Id, "Customer") == false)
            {
                UserManager.AddToRole(c38.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c39 = db.Users.FirstOrDefault(u => u.Email == "dustroud@mail.com");
            if (c39 == null)
            {
                c39 = new AppUser();
                c39.UserName = "dustroud@mail.com";
                c39.LastName = "Stroud";
                c39.FirstName = "Dustin";
                c39.Email = "dustroud@mail.com";
                c39.Birthday = new DateTime(1967, 7, 26);
                c39.StreetAddress = "1212 Rita Rd";
                c39.City = "Austin";
                c39.State = "TX";
                c39.ZipCode = 78734;
                c39.PhoneNumber = "5125550157";
                c39.PopcornPointsBalance = 90;
                var result = UserManager.Create(c39, "dustydusty");
                db.SaveChanges();
                c39 = db.Users.First(c => c.UserName == "dustroud@mail.com");
            }
            if (UserManager.IsInRole(c39.Id, "Customer") == false)
            {
                UserManager.AddToRole(c39.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c40 = db.Users.FirstOrDefault(u => u.Email == "estuart@anchor.net");
            if (c40 == null)
            {
                c40 = new AppUser();
                c40.UserName = "estuart@anchor.net";
                c40.LastName = "Stuart";
                c40.FirstName = "Eric";
                c40.Email = "estuart@anchor.net";
                c40.Birthday = new DateTime(1947, 12, 4);
                c40.StreetAddress = "5576 Toro Ring";
                c40.City = "Kyle";
                c40.State = "TX";
                c40.ZipCode = 78640;
                c40.PhoneNumber = "5125550191";
                c40.PopcornPointsBalance = 170;
                var result = UserManager.Create(c40, "stewball");
                db.SaveChanges();
                c40 = db.Users.First(c => c.UserName == "estuart@anchor.net");
            }
            if (UserManager.IsInRole(c40.Id, "Customer") == false)
            {
                UserManager.AddToRole(c40.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c41 = db.Users.FirstOrDefault(u => u.Email == "peterstump@noclue.com");
            if (c41 == null)
            {
                c41 = new AppUser();
                c41.UserName = "peterstump@noclue.com";
                c41.LastName = "Stump";
                c41.FirstName = "Peter";
                c41.Email = "peterstump@noclue.com";
                c41.Birthday = new DateTime(1974, 7, 10);
                c41.StreetAddress = "1300 Kellen Circle";
                c41.City = "Philadelphia";
                c41.State = "PA";
                c41.ZipCode = 19123;
                c41.PhoneNumber = "5125550136";
                c41.PopcornPointsBalance = 50;
                var result = UserManager.Create(c41, "slowwind");
                db.SaveChanges();
                c41 = db.Users.First(c => c.UserName == "peterstump@noclue.com");
            }
            if (UserManager.IsInRole(c41.Id, "Customer") == false)
            {
                UserManager.AddToRole(c41.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c42 = db.Users.FirstOrDefault(u => u.Email == "jtanner@mustang.net");
            if (c42 == null)
            {
                c42 = new AppUser();
                c42.UserName = "jtanner@mustang.net";
                c42.LastName = "Tanner";
                c42.FirstName = "Jeremy";
                c42.Email = "jtanner@mustang.net";
                c42.Birthday = new DateTime(1944, 1, 11);
                c42.StreetAddress = "4347 Almstead";
                c42.City = "Austin";
                c42.State = "TX";
                c42.ZipCode = 78747;
                c42.PhoneNumber = "5125550170";
                c42.PopcornPointsBalance = 190;
                var result = UserManager.Create(c42, "tanner5454");
                db.SaveChanges();
                c42 = db.Users.First(c => c.UserName == "jtanner@mustang.net");
            }
            if (UserManager.IsInRole(c42.Id, "Customer") == false)
            {
                UserManager.AddToRole(c42.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c43 = db.Users.FirstOrDefault(u => u.Email == "taylordjay@aoll.com");
            if (c43 == null)
            {
                c43 = new AppUser();
                c43.UserName = "taylordjay@aoll.com";
                c43.LastName = "Taylor";
                c43.FirstName = "Allison";
                c43.Email = "taylordjay@aoll.com";
                c43.Birthday = new DateTime(1990, 11, 14);
                c43.StreetAddress = "467 Nueces St.";
                c43.City = "Austin";
                c43.State = "TX";
                c43.ZipCode = 78712;
                c43.PhoneNumber = "5125550160";
                c43.PopcornPointsBalance = 110;
                var result = UserManager.Create(c43, "allyrally");
                db.SaveChanges();
                c43 = db.Users.First(c => c.UserName == "taylordjay@aoll.com");
            }
            if (UserManager.IsInRole(c43.Id, "Customer") == false)
            {
                UserManager.AddToRole(c43.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c44 = db.Users.FirstOrDefault(u => u.Email == "rtaylor@gogle.com");
            if (c44 == null)
            {
                c44 = new AppUser();
                c44.UserName = "rtaylor@gogle.com";
                c44.LastName = "Taylor";
                c44.FirstName = "Rachel";
                c44.Email = "rtaylor@gogle.com";
                c44.Birthday = new DateTime(1976, 1, 18);
                c44.StreetAddress = "345 Longview Dr.";
                c44.City = "Austin";
                c44.State = "TX";
                c44.ZipCode = 78758;
                c44.PhoneNumber = "5125550127";
                c44.PopcornPointsBalance = 160;
                var result = UserManager.Create(c44, "taylorbaylor");
                db.SaveChanges();
                c44 = db.Users.First(c => c.UserName == "rtaylor@gogle.com");
            }
            if (UserManager.IsInRole(c44.Id, "Customer") == false)
            {
                UserManager.AddToRole(c44.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c45 = db.Users.FirstOrDefault(u => u.Email == "teefrank@noclue.com");
            if (c45 == null)
            {
                c45 = new AppUser();
                c45.UserName = "teefrank@noclue.com";
                c45.LastName = "Tee";
                c45.FirstName = "Frank";
                c45.Email = "teefrank@noclue.com";
                c45.Birthday = new DateTime(1998, 9, 6);
                c45.StreetAddress = "5590 Lavell Dr";
                c45.City = "Austin";
                c45.State = "TX";
                c45.ZipCode = 78729;
                c45.PhoneNumber = "5125550161";
                c45.PopcornPointsBalance = 70;
                var result = UserManager.Create(c45, "teeoff22");
                db.SaveChanges();
                c45 = db.Users.First(c => c.UserName == "teefrank@noclue.com");
            }
            if (UserManager.IsInRole(c45.Id, "Customer") == false)
            {
                UserManager.AddToRole(c45.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c46 = db.Users.FirstOrDefault(u => u.Email == "ctucker@alphabet.co.uk");
            if (c46 == null)
            {
                c46 = new AppUser();
                c46.UserName = "ctucker@alphabet.co.uk";
                c46.LastName = "Tucker";
                c46.FirstName = "Clent";
                c46.Email = "ctucker@alphabet.co.uk";
                c46.Birthday = new DateTime(1943, 2, 25);
                c46.StreetAddress = "312 Main St.";
                c46.City = "Round Rock";
                c46.State = "TX";
                c46.ZipCode = 78665;
                c46.PhoneNumber = "5125550106";
                c46.PopcornPointsBalance = 150;
                var result = UserManager.Create(c46, "tucksack1");
                db.SaveChanges();
                c46 = db.Users.First(c => c.UserName == "ctucker@alphabet.co.uk");
            }
            if (UserManager.IsInRole(c46.Id, "Customer") == false)
            {
                UserManager.AddToRole(c46.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c47 = db.Users.FirstOrDefault(u => u.Email == "avelasco@yoho.com");
            if (c47 == null)
            {
                c47 = new AppUser();
                c47.UserName = "avelasco@yoho.com";
                c47.LastName = "Velasco";
                c47.FirstName = "Allen";
                c47.Email = "avelasco@yoho.com";
                c47.Birthday = new DateTime(1985, 9, 10);
                c47.StreetAddress = "679 W. 4th";
                c47.City = "Cedar Park";
                c47.State = "TX";
                c47.ZipCode = 78613;
                c47.PhoneNumber = "5125550170";
                c47.PopcornPointsBalance = 0;
                var result = UserManager.Create(c47, "meow88");
                db.SaveChanges();
                c47 = db.Users.First(c => c.UserName == "avelasco@yoho.com");
            }
            if (UserManager.IsInRole(c47.Id, "Customer") == false)
            {
                UserManager.AddToRole(c47.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c48 = db.Users.FirstOrDefault(u => u.Email == "vinovino@grapes.com");
            if (c48 == null)
            {
                c48 = new AppUser();
                c48.UserName = "vinovino@grapes.com";
                c48.LastName = "Vino";
                c48.FirstName = "Janet";
                c48.Email = "vinovino@grapes.com";
                c48.Birthday = new DateTime(1985, 2, 7);
                c48.StreetAddress = "189 Grape Road";
                c48.City = "Lockhart";
                c48.State = "TX";
                c48.ZipCode = 78644;
                c48.PhoneNumber = "5125550128";
                c48.PopcornPointsBalance = 160;
                var result = UserManager.Create(c48, "vinovino");
                db.SaveChanges();
                c48 = db.Users.First(c => c.UserName == "vinovino@grapes.com");
            }
            if (UserManager.IsInRole(c48.Id, "Customer") == false)
            {
                UserManager.AddToRole(c48.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c49 = db.Users.FirstOrDefault(u => u.Email == "westj@pioneer.net");
            if (c49 == null)
            {
                c49 = new AppUser();
                c49.UserName = "westj@pioneer.net";
                c49.LastName = "West";
                c49.FirstName = "Jake";
                c49.Email = "westj@pioneer.net";
                c49.Birthday = new DateTime(1976, 1, 9);
                c49.StreetAddress = "RR 3287";
                c49.City = "Austin";
                c49.State = "TX";
                c49.ZipCode = 78705;
                c49.PhoneNumber = "2025550170";
                c49.PopcornPointsBalance = 70;
                var result = UserManager.Create(c49, "gowest");
                db.SaveChanges();
                c49 = db.Users.First(c => c.UserName == "westj@pioneer.net");
            }
            if (UserManager.IsInRole(c49.Id, "Customer") == false)
            {
                UserManager.AddToRole(c49.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c50 = db.Users.FirstOrDefault(u => u.Email == "winner@hootmail.com");
            if (c50 == null)
            {
                c50 = new AppUser();
                c50.UserName = "winner@hootmail.com";
                c50.LastName = "Winthorpe";
                c50.FirstName = "Louis";
                c50.Email = "winner@hootmail.com";
                c50.Birthday = new DateTime(1953, 4, 19);
                c50.StreetAddress = "2500 Padre Blvd";
                c50.City = "Austin";
                c50.State = "TX";
                c50.ZipCode = 78747;
                c50.PhoneNumber = "2025550141";
                c50.PopcornPointsBalance = 150;
                var result = UserManager.Create(c50, "louielouie");
                db.SaveChanges();
                c50 = db.Users.First(c => c.UserName == "winner@hootmail.com");
            }
            if (UserManager.IsInRole(c50.Id, "Customer") == false)
            {
                UserManager.AddToRole(c50.Id, "Customer");
            }
            db.SaveChanges();

            AppUser c51 = db.Users.FirstOrDefault(u => u.Email == "rwood@voyager.net");
            if (c51 == null)
            {
                c51 = new AppUser();
                c51.UserName = "rwood@voyager.net";
                c51.LastName = "Wood";
                c51.FirstName = "Reagan";
                c51.Email = "rwood@voyager.net";
                c51.Birthday = new DateTime(2002, 12, 28);
                c51.StreetAddress = "447 Westlake Dr.";
                c51.City = "Austin";
                c51.State = "TX";
                c51.ZipCode = 78753;
                c51.PhoneNumber = "2025550128";
                c51.PopcornPointsBalance = 20;
                var result = UserManager.Create(c51, "woodyman1");
                db.SaveChanges();
                c51 = db.Users.First(c => c.UserName == "rwood@voyager.net");
            }
            if (UserManager.IsInRole(c51.Id, "Customer") == false)
            {
                UserManager.AddToRole(c51.Id, "Customer");
            }
            db.SaveChanges();

            AppUser e1 = db.Users.FirstOrDefault(u => u.Email == "t.jacobs@longhorncinema.com");
            if (e1 == null)
            {
                e1 = new AppUser();
                e1.UserName = "t.jacobs@longhorncinema.com";
                e1.LastName = "Jacobs";
                e1.FirstName = "Todd";
                e1.Email = "t.jacobs@longhorncinema.com";
                e1.Birthday = new DateTime(1958, 4, 25);
                e1.StreetAddress = "4564 Elm St.";
                e1.City = "Georgetown";
                e1.State = "TX";
                e1.ZipCode = 78628;
                e1.PhoneNumber = "9074653365";
                e1.PopcornPointsBalance = 0;
                var result = UserManager.Create(e1, "society");
                db.SaveChanges();
                e1 = db.Users.First(e => e.UserName == "t.jacobs@longhorncinema.com");
            }
            if (UserManager.IsInRole(e1.Id, "Employee") == false)
            {
                UserManager.AddToRole(e1.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e2 = db.Users.FirstOrDefault(u => u.Email == "e.rice@longhorncinema.com");
            if (e2 == null)
            {
                e2 = new AppUser();
                e2.UserName = "e.rice@longhorncinema.com";
                e2.LastName = "Rice";
                e2.FirstName = "Eryn";
                e2.Email = "e.rice@longhorncinema.com";
                e2.Birthday = new DateTime(1959, 7, 2);
                e2.StreetAddress = "3405 Rio Grande";
                e2.City = "Austin";
                e2.State = "TX";
                e2.ZipCode = 78746;
                e2.PhoneNumber = "9073876657";
                e2.PopcornPointsBalance = 0;
                var result = UserManager.Create(e2, "ricearoni");
                db.SaveChanges();
                e2 = db.Users.First(e => e.UserName == "e.rice@longhorncinema.com");
            }
            if (UserManager.IsInRole(e2.Id, "Employee") == false)
            {
                UserManager.AddToRole(e2.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e3 = db.Users.FirstOrDefault(u => u.Email == "b.ingram@longhorncinema.com");
            if (e3 == null)
            {
                e3 = new AppUser();
                e3.UserName = "b.ingram@longhorncinema.com";
                e3.LastName = "Ingram";
                e3.FirstName = "Brad";
                e3.Email = "b.ingram@longhorncinema.com";
                e3.Birthday = new DateTime(1962, 8, 25);
                e3.StreetAddress = "6548 La Posada Ct.";
                e3.City = "Austin";
                e3.State = "TX";
                e3.ZipCode = 78705;
                e3.PhoneNumber = "9074678821";
                e3.PopcornPointsBalance = 0;
                var result = UserManager.Create(e3, "ingram45");
                db.SaveChanges();
                e3 = db.Users.First(e => e.UserName == "b.ingram@longhorncinema.com");
            }
            if (UserManager.IsInRole(e3.Id, "Employee") == false)
            {
                UserManager.AddToRole(e3.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e4 = db.Users.FirstOrDefault(u => u.Email == "a.taylor@longhorncinema.com");
            if (e4 == null)
            {
                e4 = new AppUser();
                e4.UserName = "a.taylor@longhorncinema.com";
                e4.LastName = "Taylor";
                e4.FirstName = "Allison";
                e4.Email = "a.taylor@longhorncinema.com";
                e4.Birthday = new DateTime(1964, 9, 2);
                e4.StreetAddress = "467 Nueces St.";
                e4.City = "Austin";
                e4.State = "TX";
                e4.ZipCode = 78727;
                e4.PhoneNumber = "9074748452";
                e4.PopcornPointsBalance = 0;
                var result = UserManager.Create(e4, "nostalgic");
                db.SaveChanges();
                e4 = db.Users.First(e => e.UserName == "a.taylor@longhorncinema.com");
            }
            if (UserManager.IsInRole(e4.Id, "Employee") == false)
            {
                UserManager.AddToRole(e4.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e5 = db.Users.FirstOrDefault(u => u.Email == "g.martinez@longhorncinema.com");
            if (e5 == null)
            {
                e5 = new AppUser();
                e5.UserName = "g.martinez@longhorncinema.com";
                e5.LastName = "Martinez";
                e5.FirstName = "Gregory";
                e5.Email = "g.martinez@longhorncinema.com";
                e5.Birthday = new DateTime(1992, 3, 30);
                e5.StreetAddress = "8295 Sunset Blvd.";
                e5.City = "Austin";
                e5.State = "TX";
                e5.ZipCode = 78712;
                e5.PhoneNumber = "9078746718";
                e5.PopcornPointsBalance = 0;
                var result = UserManager.Create(e5, "fungus");
                db.SaveChanges();
                e5 = db.Users.First(e => e.UserName == "g.martinez@longhorncinema.com");
            }
            if (UserManager.IsInRole(e5.Id, "Employee") == false)
            {
                UserManager.AddToRole(e5.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e6 = db.Users.FirstOrDefault(u => u.Email == "m.sheffield@longhorncinema.com");
            if (e6 == null)
            {
                e6 = new AppUser();
                e6.UserName = "m.sheffield@longhorncinema.com";
                e6.LastName = "Sheffield";
                e6.FirstName = "Martin";
                e6.Email = "m.sheffield@longhorncinema.com";
                e6.Birthday = new DateTime(1996, 12, 29);
                e6.StreetAddress = "3886 Avenue A";
                e6.City = "San Marcos";
                e6.State = "TX";
                e6.ZipCode = 78666;
                e6.PhoneNumber = "9075479167";
                e6.PopcornPointsBalance = 0;
                var result = UserManager.Create(e6, "longhorns");
                db.SaveChanges();
                e6 = db.Users.First(e => e.UserName == "m.sheffield@longhorncinema.com");
            }
            if (UserManager.IsInRole(e6.Id, "Employee") == false)
            {
                UserManager.AddToRole(e6.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e7 = db.Users.FirstOrDefault(u => u.Email == "j.macleod@longhorncinema.com");
            if (e7 == null)
            {
                e7 = new AppUser();
                e7.UserName = "j.macleod@longhorncinema.com";
                e7.LastName = "MacLeod";
                e7.FirstName = "Jennifer";
                e7.Email = "j.macleod@longhorncinema.com";
                e7.Birthday = new DateTime(1997, 6, 10);
                e7.StreetAddress = "2504 Far West Blvd.";
                e7.City = "Austin";
                e7.State = "TX";
                e7.ZipCode = 78705;
                e7.PhoneNumber = "9074748138";
                e7.PopcornPointsBalance = 0;
                var result = UserManager.Create(e7, "smitty");
                db.SaveChanges();
                e7 = db.Users.First(e => e.UserName == "j.macleod@longhorncinema.com");
            }
            if (UserManager.IsInRole(e7.Id, "Employee") == false)
            {
                UserManager.AddToRole(e7.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e8 = db.Users.FirstOrDefault(u => u.Email == "j.tanner@longhorncinema.com");
            if (e8 == null)
            {
                e8 = new AppUser();
                e8.UserName = "j.tanner@longhorncinema.com";
                e8.LastName = "Tanner";
                e8.FirstName = "Jeremy";
                e8.Email = "j.tanner@longhorncinema.com";
                e8.Birthday = new DateTime(1970, 8, 12);
                e8.StreetAddress = "4347 Almstead";
                e8.City = "Austin";
                e8.State = "TX";
                e8.ZipCode = 78712;
                e8.PhoneNumber = "9074590929";
                e8.PopcornPointsBalance = 0;
                var result = UserManager.Create(e8, "tanman");
                db.SaveChanges();
                e8 = db.Users.First(e => e.UserName == "j.tanner@longhorncinema.com");
            }
            if (UserManager.IsInRole(e8.Id, "Employee") == false)
            {
                UserManager.AddToRole(e8.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e9 = db.Users.FirstOrDefault(u => u.Email == "m.rhodes@longhorncinema.com");
            if (e9 == null)
            {
                e9 = new AppUser();
                e9.UserName = "m.rhodes@longhorncinema.com";
                e9.LastName = "Rhodes";
                e9.FirstName = "Megan";
                e9.Email = "m.rhodes@longhorncinema.com";
                e9.Birthday = new DateTime(1970, 12, 18);
                e9.StreetAddress = "4587 Enfield Rd.";
                e9.City = "Austin";
                e9.State = "TX";
                e9.ZipCode = 78729;
                e9.PhoneNumber = "9073744746";
                e9.PopcornPointsBalance = 0;
                var result = UserManager.Create(e9, "countryrhodes");
                db.SaveChanges();
                e9 = db.Users.First(e => e.UserName == "m.rhodes@longhorncinema.com");
            }
            if (UserManager.IsInRole(e9.Id, "Employee") == false)
            {
                UserManager.AddToRole(e9.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e10 = db.Users.FirstOrDefault(u => u.Email == "e.stuart@longhorncinema.com");
            if (e10 == null)
            {
                e10 = new AppUser();
                e10.UserName = "e.stuart@longhorncinema.com";
                e10.LastName = "Stuart";
                e10.FirstName = "Eric";
                e10.Email = "e.stuart@longhorncinema.com";
                e10.Birthday = new DateTime(1971, 3, 11);
                e10.StreetAddress = "5576 Toro Ring";
                e10.City = "Austin";
                e10.State = "TX";
                e10.ZipCode = 78758;
                e10.PhoneNumber = "9078178335";
                e10.PopcornPointsBalance = 0;
                var result = UserManager.Create(e10, "stewboy");
                db.SaveChanges();
                e10 = db.Users.First(e => e.UserName == "e.stuart@longhorncinema.com");
            }
            if (UserManager.IsInRole(e10.Id, "Employee") == false)
            {
                UserManager.AddToRole(e10.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e11 = db.Users.FirstOrDefault(u => u.Email == "c.miller@longhorncinema.com");
            if (e11 == null)
            {
                e11 = new AppUser();
                e11.UserName = "c.miller@longhorncinema.com";
                e11.LastName = "Miller";
                e11.FirstName = "Charles";
                e11.Email = "c.miller@longhorncinema.com";
                e11.Birthday = new DateTime(1972, 7, 20);
                e11.StreetAddress = "8962 Main St.";
                e11.City = "Austin";
                e11.State = "TX";
                e11.ZipCode = 78709;
                e11.PhoneNumber = "9077458615";
                e11.PopcornPointsBalance = 0;
                var result = UserManager.Create(e11, "squirrel");
                db.SaveChanges();
                e11 = db.Users.First(e => e.UserName == "c.miller@longhorncinema.com");
            }
            if (UserManager.IsInRole(e11.Id, "Employee") == false)
            {
                UserManager.AddToRole(e11.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e12 = db.Users.FirstOrDefault(u => u.Email == "r.taylor@longhorncinema.com");
            if (e12 == null)
            {
                e12 = new AppUser();
                e12.UserName = "r.taylor@longhorncinema.com";
                e12.LastName = "Taylor";
                e12.FirstName = "Rachel";
                e12.Email = "r.taylor@longhorncinema.com";
                e12.Birthday = new DateTime(1972, 12, 20);
                e12.StreetAddress = "345 Longview Dr.";
                e12.City = "Austin";
                e12.State = "TX";
                e12.ZipCode = 78746;
                e12.PhoneNumber = "9074512631";
                e12.PopcornPointsBalance = 0;
                var result = UserManager.Create(e12, "swansong");
                db.SaveChanges();
                e12 = db.Users.First(e => e.UserName == "r.taylor@longhorncinema.com");
            }
            if (UserManager.IsInRole(e12.Id, "Employee") == false)
            {
                UserManager.AddToRole(e12.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e13 = db.Users.FirstOrDefault(u => u.Email == "v.lawrence@longhorncinema.com");
            if (e13 == null)
            {
                e13 = new AppUser();
                e13.UserName = "v.lawrence@longhorncinema.com";
                e13.LastName = "Lawrence";
                e13.FirstName = "Victoria";
                e13.Email = "v.lawrence@longhorncinema.com";
                e13.Birthday = new DateTime(1973, 4, 28);
                e13.StreetAddress = "6639 Butterfly Ln.";
                e13.City = "Austin";
                e13.State = "TX";
                e13.ZipCode = 78712;
                e13.PhoneNumber = "9079457399";
                e13.PopcornPointsBalance = 0;
                var result = UserManager.Create(e13, "lottery");
                db.SaveChanges();
                e13 = db.Users.First(e => e.UserName == "v.lawrence@longhorncinema.com");
            }
            if (UserManager.IsInRole(e13.Id, "Employee") == false)
            {
                UserManager.AddToRole(e13.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e14 = db.Users.FirstOrDefault(u => u.Email == "a.rogers@longhorncinema.com");
            if (e14 == null)
            {
                e14 = new AppUser();
                e14.UserName = "a.rogers@longhorncinema.com";
                e14.LastName = "Rogers";
                e14.FirstName = "Allen";
                e14.Email = "a.rogers@longhorncinema.com";
                e14.Birthday = new DateTime(1978, 6, 21);
                e14.StreetAddress = "4965 Oak Hill";
                e14.City = "Austin";
                e14.State = "TX";
                e14.ZipCode = 78705;
                e14.PhoneNumber = "9078752943";
                e14.PopcornPointsBalance = 0;
                var result = UserManager.Create(e14, "evanescent");
                db.SaveChanges();
                e14 = db.Users.First(e => e.UserName == "a.rogers@longhorncinema.com");
            }
            if (UserManager.IsInRole(e14.Id, "Employee") == false)
            {
                UserManager.AddToRole(e14.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e15 = db.Users.FirstOrDefault(u => u.Email == "e.markham@longhorncinema.com");
            if (e15 == null)
            {
                e15 = new AppUser();
                e15.UserName = "e.markham@longhorncinema.com";
                e15.LastName = "Markham";
                e15.FirstName = "Elizabeth";
                e15.Email = "e.markham@longhorncinema.com";
                e15.Birthday = new DateTime(1990, 5, 21);
                e15.StreetAddress = "7861 Chevy Chase";
                e15.City = "Austin";
                e15.State = "TX";
                e15.ZipCode = 78785;
                e15.PhoneNumber = "9074579845";
                e15.PopcornPointsBalance = 0;
                var result = UserManager.Create(e15, "monty3");
                db.SaveChanges();
                e15 = db.Users.First(e => e.UserName == "e.markham@longhorncinema.com");
            }
            if (UserManager.IsInRole(e15.Id, "Employee") == false)
            {
                UserManager.AddToRole(e15.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e16 = db.Users.FirstOrDefault(u => u.Email == "c.baker@longhorncinema.com");
            if (e16 == null)
            {
                e16 = new AppUser();
                e16.UserName = "c.baker@longhorncinema.com";
                e16.LastName = "Baker";
                e16.FirstName = "Christopher";
                e16.Email = "c.baker@longhorncinema.com";
                e16.Birthday = new DateTime(1993, 3, 16);
                e16.StreetAddress = "1245 Lake Anchorage Blvd.";
                e16.City = "Cedar Park";
                e16.State = "TX";
                e16.ZipCode = 78613;
                e16.PhoneNumber = "9075571146";
                e16.PopcornPointsBalance = 0;
                var result = UserManager.Create(e16, "hecktour");
                db.SaveChanges();
                e16 = db.Users.First(e => e.UserName == "c.baker@longhorncinema.com");
            }
            if (UserManager.IsInRole(e16.Id, "Employee") == false)
            {
                UserManager.AddToRole(e16.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e17 = db.Users.FirstOrDefault(u => u.Email == "s.saunders@longhorncinema.com");
            if (e17 == null)
            {
                e17 = new AppUser();
                e17.UserName = "s.saunders@longhorncinema.com";
                e17.LastName = "Saunders";
                e17.FirstName = "Sarah";
                e17.Email = "s.saunders@longhorncinema.com";
                e17.Birthday = new DateTime(1997, 1, 5);
                e17.StreetAddress = "332 Avenue C";
                e17.City = "Austin";
                e17.State = "TX";
                e17.ZipCode = 78733;
                e17.PhoneNumber = "9073497810";
                e17.PopcornPointsBalance = 0;
                var result = UserManager.Create(e17, "rankmary");
                db.SaveChanges();
                e17 = db.Users.First(e => e.UserName == "s.saunders@longhorncinema.com");
            }
            if (UserManager.IsInRole(e17.Id, "Employee") == false)
            {
                UserManager.AddToRole(e17.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e18 = db.Users.FirstOrDefault(u => u.Email == "w.sewell@longhorncinema.com");
            if (e18 == null)
            {
                e18 = new AppUser();
                e18.UserName = "w.sewell@longhorncinema.com";
                e18.LastName = "Sewell";
                e18.FirstName = "William";
                e18.Email = "w.sewell@longhorncinema.com";
                e18.Birthday = new DateTime(1986, 5, 25);
                e18.StreetAddress = "2365 51st St.";
                e18.City = "Austin";
                e18.State = "TX";
                e18.ZipCode = 78755;
                e18.PhoneNumber = "9074510084";
                e18.PopcornPointsBalance = 0;
                var result = UserManager.Create(e18, "walkamile");
                db.SaveChanges();
                e18 = db.Users.First(e => e.UserName == "w.sewell@longhorncinema.com");
            }
            if (UserManager.IsInRole(e18.Id, "Employee") == false)
            {
                UserManager.AddToRole(e18.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e19 = db.Users.FirstOrDefault(u => u.Email == "j.mason@longhorncinema.com");
            if (e19 == null)
            {
                e19 = new AppUser();
                e19.UserName = "j.mason@longhorncinema.com";
                e19.LastName = "Mason";
                e19.FirstName = "Jack";
                e19.Email = "j.mason@longhorncinema.com";
                e19.Birthday = new DateTime(1986, 6, 6);
                e19.StreetAddress = "444 45th St";
                e19.City = "Austin";
                e19.State = "TX";
                e19.ZipCode = 78701;
                e19.PhoneNumber = "9018833432";
                e19.PopcornPointsBalance = 0;
                var result = UserManager.Create(e19, "changalang");
                db.SaveChanges();
                e19 = db.Users.First(e => e.UserName == "j.mason@longhorncinema.com");
            }
            if (UserManager.IsInRole(e19.Id, "Employee") == false)
            {
                UserManager.AddToRole(e19.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e20 = db.Users.FirstOrDefault(u => u.Email == "j.jackson@longhorncinema.com");
            if (e20 == null)
            {
                e20 = new AppUser();
                e20.UserName = "j.jackson@longhorncinema.com";
                e20.LastName = "Jackson";
                e20.FirstName = "Jack";
                e20.Email = "j.jackson@longhorncinema.com";
                e20.Birthday = new DateTime(1986, 10, 16);
                e20.StreetAddress = "222 Main";
                e20.City = "Austin";
                e20.State = "TX";
                e20.ZipCode = 78760;
                e20.PhoneNumber = "9075554545";
                e20.PopcornPointsBalance = 0;
                var result = UserManager.Create(e20, "offbeat");
                db.SaveChanges();
                e20 = db.Users.First(e => e.UserName == "j.jackson@longhorncinema.com");
            }
            if (UserManager.IsInRole(e20.Id, "Employee") == false)
            {
                UserManager.AddToRole(e20.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e21 = db.Users.FirstOrDefault(u => u.Email == "m.nguyen@longhorncinema.com");
            if (e21 == null)
            {
                e21 = new AppUser();
                e21.UserName = "m.nguyen@longhorncinema.com";
                e21.LastName = "Nguyen";
                e21.FirstName = "Mary";
                e21.Email = "m.nguyen@longhorncinema.com";
                e21.Birthday = new DateTime(1988, 4, 5);
                e21.StreetAddress = "465 N. Bear Cub";
                e21.City = "Austin";
                e21.State = "TX";
                e21.ZipCode = 78734;
                e21.PhoneNumber = "9075524141";
                e21.PopcornPointsBalance = 0;
                var result = UserManager.Create(e21, "landus");
                db.SaveChanges();
                e21 = db.Users.First(e => e.UserName == "m.nguyen@longhorncinema.com");
            }
            if (UserManager.IsInRole(e21.Id, "Employee") == false)
            {
                UserManager.AddToRole(e21.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e22 = db.Users.FirstOrDefault(u => u.Email == "s.barnes@longhorncinema.com");
            if (e22 == null)
            {
                e22 = new AppUser();
                e22.UserName = "s.barnes@longhorncinema.com";
                e22.LastName = "Barnes";
                e22.FirstName = "Susan";
                e22.Email = "s.barnes@longhorncinema.com";
                e22.Birthday = new DateTime(1993, 2, 22);
                e22.StreetAddress = "888 S. Main";
                e22.City = "Kyle";
                e22.State = "TX";
                e22.ZipCode = 78640;
                e22.PhoneNumber = "9556662323";
                e22.PopcornPointsBalance = 0;
                var result = UserManager.Create(e22, "rhythm");
                db.SaveChanges();
                e22 = db.Users.First(e => e.UserName == "s.barnes@longhorncinema.com");
            }
            if (UserManager.IsInRole(e22.Id, "Employee") == false)
            {
                UserManager.AddToRole(e22.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e23 = db.Users.FirstOrDefault(u => u.Email == "l.jones@longhorncinema.com");
            if (e23 == null)
            {
                e23 = new AppUser();
                e23.UserName = "l.jones@longhorncinema.com";
                e23.LastName = "Jones";
                e23.FirstName = "Lester";
                e23.Email = "l.jones@longhorncinema.com";
                e23.Birthday = new DateTime(1996, 6, 29);
                e23.StreetAddress = "999 LeBlat";
                e23.City = "Austin";
                e23.State = "TX";
                e23.ZipCode = 78747;
                e23.PhoneNumber = "9886662222";
                e23.PopcornPointsBalance = 0;
                var result = UserManager.Create(e23, "kindly");
                db.SaveChanges();
                e23 = db.Users.First(e => e.UserName == "l.jones@longhorncinema.com");
            }
            if (UserManager.IsInRole(e23.Id, "Employee") == false)
            {
                UserManager.AddToRole(e23.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e24 = db.Users.FirstOrDefault(u => u.Email == "h.garcia@longhorncinema.com");
            if (e24 == null)
            {
                e24 = new AppUser();
                e24.UserName = "h.garcia@longhorncinema.com";
                e24.LastName = "Garcia";
                e24.FirstName = "Hector";
                e24.Email = "h.garcia@longhorncinema.com";
                e24.Birthday = new DateTime(1997, 5, 13);
                e24.StreetAddress = "777 PBR Drive";
                e24.City = "Austin";
                e24.State = "TX";
                e24.ZipCode = 78712;
                e24.PhoneNumber = "9221114444";
                e24.PopcornPointsBalance = 0;
                var result = UserManager.Create(e24, "instrument");
                db.SaveChanges();
                e24 = db.Users.First(e => e.UserName == "h.garcia@longhorncinema.com");
            }
            if (UserManager.IsInRole(e24.Id, "Employee") == false)
            {
                UserManager.AddToRole(e24.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e25 = db.Users.FirstOrDefault(u => u.Email == "c.silva@longhorncinema.com");
            if (e25 == null)
            {
                e25 = new AppUser();
                e25.UserName = "c.silva@longhorncinema.com";
                e25.LastName = "Silva";
                e25.FirstName = "Cindy";
                e25.Email = "c.silva@longhorncinema.com";
                e25.Birthday = new DateTime(1997, 12, 29);
                e25.StreetAddress = "900 4th St";
                e25.City = "Austin";
                e25.State = "TX";
                e25.ZipCode = 78758;
                e25.PhoneNumber = "9221113333";
                e25.PopcornPointsBalance = 0;
                var result = UserManager.Create(e25, "arched");
                db.SaveChanges();
                e25 = db.Users.First(e => e.UserName == "c.silva@longhorncinema.com");
            }
            if (UserManager.IsInRole(e25.Id, "Employee") == false)
            {
                UserManager.AddToRole(e25.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e26 = db.Users.FirstOrDefault(u => u.Email == "m.lopez@longhorncinema.com");
            if (e26 == null)
            {
                e26 = new AppUser();
                e26.UserName = "m.lopez@longhorncinema.com";
                e26.LastName = "Lopez";
                e26.FirstName = "Marshall";
                e26.Email = "m.lopez@longhorncinema.com";
                e26.Birthday = new DateTime(1996, 11, 4);
                e26.StreetAddress = "90 SW North St";
                e26.City = "Austin";
                e26.State = "TX";
                e26.ZipCode = 78729;
                e26.PhoneNumber = "9234442222";
                e26.PopcornPointsBalance = 0;
                var result = UserManager.Create(e26, "median");
                db.SaveChanges();
                e26 = db.Users.First(e => e.UserName == "m.lopez@longhorncinema.com");
            }
            if (UserManager.IsInRole(e26.Id, "Employee") == false)
            {
                UserManager.AddToRole(e26.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e27 = db.Users.FirstOrDefault(u => u.Email == "b.larson@longhorncinema.com");
            if (e27 == null)
            {
                e27 = new AppUser();
                e27.UserName = "b.larson@longhorncinema.com";
                e27.LastName = "Larson";
                e27.FirstName = "Bill";
                e27.Email = "b.larson@longhorncinema.com";
                e27.Birthday = new DateTime(1999, 11, 14);
                e27.StreetAddress = "1212 N. First Ave";
                e27.City = "Round Rock";
                e27.State = "TX";
                e27.ZipCode = 78665;
                e27.PhoneNumber = "9795554444";
                e27.PopcornPointsBalance = 0;
                var result = UserManager.Create(e27, "approval");
                db.SaveChanges();
                e27 = db.Users.First(e => e.UserName == "b.larson@longhorncinema.com");
            }
            if (UserManager.IsInRole(e27.Id, "Employee") == false)
            {
                UserManager.AddToRole(e27.Id, "Employee");
            }
            db.SaveChanges();

            AppUser e28 = db.Users.FirstOrDefault(u => u.Email == "s.rankin@longhorncinema.com");
            if (e28 == null)
            {
                e28 = new AppUser();
                e28.UserName = "s.rankin@longhorncinema.com";
                e28.LastName = "Rankin";
                e28.FirstName = "Suzie";
                e28.Email = "s.rankin@longhorncinema.com";
                e28.Birthday = new DateTime(1999, 12, 17);
                e28.StreetAddress = "23 Polar Bear Road";
                e28.City = "Austin";
                e28.State = "TX";
                e28.ZipCode = 78712;
                e28.PhoneNumber = "9893336666";
                e28.PopcornPointsBalance = 0;
                var result = UserManager.Create(e28, "decorate");
                db.SaveChanges();
                e28 = db.Users.First(e => e.UserName == "s.rankin@longhorncinema.com");
            }
            if (UserManager.IsInRole(e28.Id, "Employee") == false)
            {
                UserManager.AddToRole(e28.Id, "Employee");
            }
            db.SaveChanges();

            AppUser m1 = db.Users.FirstOrDefault(u => u.Email == "ben@longhorncinema.com");
            if (m1 == null)
            {
                m1 = new AppUser();
                m1.UserName = "ben@longhorncinema.com";
                m1.LastName = "Manager";
                m1.FirstName = "Ben";
                m1.Email = "ben@longhorncinema.com";
                m1.Birthday = new DateTime(1985, 01, 01);
                m1.StreetAddress = "123 Manager Street";
                m1.City = "Austin";
                m1.State = "TX";
                m1.ZipCode = 78705;
                m1.PhoneNumber = "5123333333";
                m1.PopcornPointsBalance = 0;
                var result = UserManager.Create(m1, "Abc123!");
                db.SaveChanges();
                m1 = db.Users.First(m => m.UserName == "ben@longhorncinema.com");
            }
            if (UserManager.IsInRole(m1.Id, "Manager") == false)
            {
                UserManager.AddToRole(m1.Id, "Manager");
            }
            db.SaveChanges();

            AppUser m2 = db.Users.FirstOrDefault(u => u.Email == "michael@longhorncinema.com");
            if (m2 == null)
            {
                m2 = new AppUser();
                m2.UserName = "michael@longhorncinema.com";
                m2.LastName = "Manager";
                m2.FirstName = "Michael";
                m2.Email = "michael@longhorncinema.com";
                m2.Birthday = new DateTime(1985, 01, 01);
                m2.StreetAddress = "123 Manager Street";
                m2.City = "Austin";
                m2.State = "TX";
                m2.ZipCode = 78705;
                m2.PhoneNumber = "5123333333";
                m2.PopcornPointsBalance = 0;
                var result = UserManager.Create(m2, "Abc123!");
                db.SaveChanges();
                m2 = db.Users.First(m => m.UserName == "michael@longhorncinema.com");
            }
            if (UserManager.IsInRole(m2.Id, "Manager") == false)
            {
                UserManager.AddToRole(m2.Id, "Manager");
            }
            db.SaveChanges();

            AppUser m3 = db.Users.FirstOrDefault(u => u.Email == "sam@longhorncinema.com");
            if (m3 == null)
            {
                m3 = new AppUser();
                m3.UserName = "sam@longhorncinema.com";
                m3.LastName = "Manager";
                m3.FirstName = "Sam";
                m3.Email = "sam@longhorncinema.com";
                m3.Birthday = new DateTime(1985, 01, 01);
                m3.StreetAddress = "123 Manager Street";
                m3.City = "Austin";
                m3.State = "TX";
                m3.ZipCode = 78705;
                m3.PhoneNumber = "5123333333";
                m3.PopcornPointsBalance = 0;
                var result = UserManager.Create(m3, "Abc123!");
                db.SaveChanges();
                m3 = db.Users.First(m => m.UserName == "sam@longhorncinema.com");
            }
            if (UserManager.IsInRole(m3.Id, "Manager") == false)
            {
                UserManager.AddToRole(m3.Id, "Manager");
            }
            db.SaveChanges();
        }
    }
}