using LonghornCinemaFinalProject.Models;
using LonghornCinemaFinalProject.DAL;
using System.Data.Entity.Migrations;
using System;
using System.Linq;
using System.Collections.Generic;

namespace LonghornCinemaFinalProject.Migrations
{
    public class ShowingData
    {
        public void SeedShowings(AppDbContext db)
        {
            //test
            Showing s1 = new Showing(); 
            s1.StartTime = new DateTime(2018, 5, 4, 9, 5, 0); // 2018, May 4th, 9:05:00
            s1.EndTime = new DateTime(2018, 5, 4, 11, 14, 0); // 2018, May 4th, 11:14:00
            s1.SpecialEventStatus = SpecialEvent.NotSpecial;
            s1.TheatreNum = Theatre.TheatreOne;
            s1.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Sting");
            db.Showings.AddOrUpdate(s => s.StartTime, s1);
            db.SaveChanges();

            Showing s2 = new Showing();
            s2.StartTime = new DateTime(2018, 5, 4, 11, 45, 0); // 2018, May 4th, 11:45:00
            s2.EndTime = new DateTime(2018, 5, 4, 13, 39, 0); // 2018, May 4th, 1:39:00
            s2.SpecialEventStatus = SpecialEvent.NotSpecial;
            s2.TheatreNum = Theatre.TheatreOne;
            s2.Movie = db.Movies.FirstOrDefault(x => x.Title == "WarGames");
            db.Showings.AddOrUpdate(s => s.StartTime, s2);
            db.SaveChanges();

            Showing s3 = new Showing();
            s3.StartTime = new DateTime(2018, 5, 4, 14, 10, 0); // 2018, May 4th, 2:10:00
            s3.EndTime = new DateTime(2018, 5, 4, 15, 39, 0); // 2018, May 4th, 3:39:00
            s3.SpecialEventStatus = SpecialEvent.NotSpecial;
            s3.TheatreNum = Theatre.TheatreOne;
            s3.Movie = db.Movies.FirstOrDefault(x => x.Title == "Office Space");
            db.Showings.AddOrUpdate(s => s.StartTime, s3);
            db.SaveChanges();

            Showing s4 = new Showing();
            s4.StartTime = new DateTime(2018, 5, 4, 16, 15, 0); // 2018, May 4th, 4:15:00
            s4.EndTime = new DateTime(2018, 5, 4, 18, 15, 0); // 2018, May 4th, 6:15:00
            s4.SpecialEventStatus = SpecialEvent.NotSpecial;
            s4.TheatreNum = Theatre.TheatreOne;
            s4.Movie = db.Movies.FirstOrDefault(x => x.Title == "Diamonds are Forever");
            db.Showings.AddOrUpdate(s => s.StartTime, s4);
            db.SaveChanges();

            Showing s5 = new Showing();
            s5.StartTime = new DateTime(2018, 5, 4, 18, 40, 0); // 2018, May 4th, 6:40:00
            s5.EndTime = new DateTime(2018, 5, 4, 21, 12, 0); // 2018, May 4th, 9:12:00
            s5.SpecialEventStatus = SpecialEvent.NotSpecial;
            s5.TheatreNum = Theatre.TheatreOne;
            s5.Movie = db.Movies.FirstOrDefault(x => x.Title == "West Side Story");
            db.Showings.AddOrUpdate(s => s.StartTime, s5);
            db.SaveChanges();

            Showing s6 = new Showing();
            s6.StartTime = new DateTime(2018, 5, 4, 21, 55, 0); // 2018, May 4th, 9:55:00
            s6.EndTime = new DateTime(2018, 5, 4, 23, 44, 0); // 2018, May 4th, 11:44:00
            s6.SpecialEventStatus = SpecialEvent.NotSpecial;
            s6.TheatreNum = Theatre.TheatreOne;
            s6.Movie = db.Movies.FirstOrDefault(x => x.Title == "Psycho");
            db.Showings.AddOrUpdate(s => s.StartTime, s6);
            db.SaveChanges();

            Showing s7 = new Showing();
            s7.StartTime = new DateTime(2018, 5, 4, 9, 10, 0); // 2018, May 4th, 9:10:00
            s7.EndTime = new DateTime(2018, 5, 4, 11, 29, 0); // 2018, May 4th, 11:29:00
            s7.SpecialEventStatus = SpecialEvent.NotSpecial;
            s7.TheatreNum = Theatre.TheatreTwo;
            s7.Movie = db.Movies.FirstOrDefault(x => x.Title == "Mary Poppins");
            db.Showings.AddOrUpdate(s => s.StartTime, s7);
            db.SaveChanges();

            Showing s8 = new Showing();
            s8.StartTime = new DateTime(2018, 5, 4, 12, 00, 0); // 2018, May 4th, 12:00:00
            s8.EndTime = new DateTime(2018, 5, 4, 13, 37, 0); // 2018, May 4th, 1:37:00
            s8.SpecialEventStatus = SpecialEvent.NotSpecial;
            s8.TheatreNum = Theatre.TheatreTwo;
            s8.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Muppet Movie");
            db.Showings.AddOrUpdate(s => s.StartTime, s8);
            db.SaveChanges();

            Showing s9 = new Showing();
            s9.StartTime = new DateTime(2018, 5, 4, 14, 20, 0); // 2018, May 4th, 2:20:00
            s9.EndTime = new DateTime(2018, 5, 4, 15, 58, 0); // 2018, May 4th, 3:58:00
            s9.SpecialEventStatus = SpecialEvent.NotSpecial;
            s9.TheatreNum = Theatre.TheatreTwo;
            s9.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Princess Bride");
            db.Showings.AddOrUpdate(s => s.StartTime, s9);
            db.SaveChanges();

            Showing s10 = new Showing();
            s10.StartTime = new DateTime(2018, 5, 4, 16, 30, 0); // 2018, May 4th, 4:30:00
            s10.EndTime = new DateTime(2018, 5, 4, 18, 10, 0); // 2018, May 4th, 6:10:00
            s10.SpecialEventStatus = SpecialEvent.NotSpecial;
            s10.TheatreNum = Theatre.TheatreTwo;
            s10.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Lego Movie");
            db.Showings.AddOrUpdate(s => s.StartTime, s10);
            db.SaveChanges();

            Showing s11 = new Showing();
            s11.StartTime = new DateTime(2018, 5, 4, 18, 45, 0); // 2018, May 4th, 6:45:00
            s11.EndTime = new DateTime(2018, 5, 4, 20, 25, 0); // 2018, May 4th, 8:25:00
            s11.SpecialEventStatus = SpecialEvent.NotSpecial;
            s11.TheatreNum = Theatre.TheatreTwo;
            s11.Movie = db.Movies.FirstOrDefault(x => x.Title == "Finding Nemo");
            db.Showings.AddOrUpdate(s => s.StartTime, s11);
            db.SaveChanges();

            Showing s12 = new Showing();
            s12.StartTime = new DateTime(2018, 5, 4, 20, 55, 0); // 2018, May 4th, 8:55:00
            s12.EndTime = new DateTime(2018, 5, 4, 23, 32, 0); // 2018, May 4th, 11:32:00
            s12.SpecialEventStatus = SpecialEvent.NotSpecial;
            s12.TheatreNum = Theatre.TheatreTwo;
            s12.Movie = db.Movies.FirstOrDefault(x => x.Title == "Harry Potter and the Goblet of Fire");
            db.Showings.AddOrUpdate(s => s.StartTime, s12);
            db.SaveChanges();


            Showing s13 = new Showing();
            s13.StartTime = new DateTime(2018, 5, 5, 9, 5, 0); // 2018, May 4th, 9:05:00
            s13.EndTime = new DateTime(2018, 5, 5, 11, 14, 0); // 2018, May 4th, 11:14:00
            s13.SpecialEventStatus = SpecialEvent.NotSpecial;
            s13.TheatreNum = Theatre.TheatreOne;
            s13.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Sting");
            db.Showings.AddOrUpdate(s => s.StartTime, s13);
            db.SaveChanges();

            Showing s14 = new Showing();
            s14.StartTime = new DateTime(2018, 5, 5, 11, 45, 0); // 2018, May 4th, 11:45:00
            s14.EndTime = new DateTime(2018, 5, 5, 13, 39, 0); // 2018, May 4th, 1:39:00
            s14.SpecialEventStatus = SpecialEvent.NotSpecial;
            s14.TheatreNum = Theatre.TheatreOne;
            s14.Movie = db.Movies.FirstOrDefault(x => x.Title == "WarGames");
            db.Showings.AddOrUpdate(s => s.StartTime, s14);
            db.SaveChanges();

            Showing s15 = new Showing();
            s15.StartTime = new DateTime(2018, 5, 5, 14, 10, 0); // 2018, May 4th, 2:10:00
            s15.EndTime = new DateTime(2018, 5, 5, 15, 39, 0); // 2018, May 4th, 3:39:00
            s15.SpecialEventStatus = SpecialEvent.NotSpecial;
            s15.TheatreNum = Theatre.TheatreOne;
            s15.Movie = db.Movies.FirstOrDefault(x => x.Title == "Office Space");
            db.Showings.AddOrUpdate(s => s.StartTime, s15);
            db.SaveChanges();

            Showing s16 = new Showing();
            s16.StartTime = new DateTime(2018, 5, 5, 16, 15, 0); // 2018, May 4th, 4:15:00
            s16.EndTime = new DateTime(2018, 5, 5, 18, 15, 0); // 2018, May 4th, 6:15:00
            s16.SpecialEventStatus = SpecialEvent.NotSpecial;
            s16.TheatreNum = Theatre.TheatreOne;
            s16.Movie = db.Movies.FirstOrDefault(x => x.Title == "Diamonds are Forever");
            db.Showings.AddOrUpdate(s => s.StartTime, s16);
            db.SaveChanges();

            Showing s17 = new Showing();
            s17.StartTime = new DateTime(2018, 5, 5, 18, 40, 0); // 2018, May 4th, 6:40:00
            s17.EndTime = new DateTime(2018, 5, 5, 21, 12, 0); // 2018, May 4th, 9:12:00
            s17.SpecialEventStatus = SpecialEvent.NotSpecial;
            s17.TheatreNum = Theatre.TheatreOne;
            s17.Movie = db.Movies.FirstOrDefault(x => x.Title == "West Side Story");
            db.Showings.AddOrUpdate(s => s.StartTime, s17);
            db.SaveChanges();

            Showing s18 = new Showing();
            s18.StartTime = new DateTime(2018, 5, 5, 21, 55, 0); // 2018, May 4th, 9:55:00
            s18.EndTime = new DateTime(2018, 5, 5, 23, 44, 0); // 2018, May 4th, 11:44:00
            s18.SpecialEventStatus = SpecialEvent.NotSpecial;
            s18.TheatreNum = Theatre.TheatreOne;
            s18.Movie = db.Movies.FirstOrDefault(x => x.Title == "Psycho");
            db.Showings.AddOrUpdate(s => s.StartTime, s18);
            db.SaveChanges();

            Showing s19 = new Showing();
            s19.StartTime = new DateTime(2018, 5, 5, 9, 10, 0); // 2018, May 4th, 9:10:00
            s19.EndTime = new DateTime(2018, 5, 5, 11, 29, 0); // 2018, May 4th, 11:29:00
            s19.SpecialEventStatus = SpecialEvent.NotSpecial;
            s19.TheatreNum = Theatre.TheatreTwo;
            s19.Movie = db.Movies.FirstOrDefault(x => x.Title == "Mary Poppins");
            db.Showings.AddOrUpdate(s => s.StartTime, s19);
            db.SaveChanges();

            Showing s20 = new Showing();
            s20.StartTime = new DateTime(2018, 5, 5, 12, 00, 0); // 2018, May 4th, 12:00:00
            s20.EndTime = new DateTime(2018, 5, 5, 13, 37, 0); // 2018, May 4th, 1:37:00
            s20.SpecialEventStatus = SpecialEvent.NotSpecial;
            s20.TheatreNum = Theatre.TheatreTwo;
            s20.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Muppet Movie");
            db.Showings.AddOrUpdate(s => s.StartTime, s20);
            db.SaveChanges();

            Showing s21 = new Showing();
            s21.StartTime = new DateTime(2018, 5, 5, 14, 20, 0); // 2018, May 4th, 2:20:00
            s21.EndTime = new DateTime(2018, 5, 5, 15, 58, 0); // 2018, May 4th, 3:58:00
            s21.SpecialEventStatus = SpecialEvent.NotSpecial;
            s21.TheatreNum = Theatre.TheatreTwo;
            s21.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Princess Bride");
            db.Showings.AddOrUpdate(s => s.StartTime, s21);
            db.SaveChanges();

            Showing s22 = new Showing();
            s22.StartTime = new DateTime(2018, 5, 5, 16, 30, 0); // 2018, May 4th, 4:30:00
            s22.EndTime = new DateTime(2018, 5, 5, 18, 10, 0); // 2018, May 4th, 6:10:00
            s22.SpecialEventStatus = SpecialEvent.NotSpecial;
            s22.TheatreNum = Theatre.TheatreTwo;
            s22.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Lego Movie");
            db.Showings.AddOrUpdate(s => s.StartTime, s22);
            db.SaveChanges();

            Showing s23 = new Showing();
            s23.StartTime = new DateTime(2018, 5, 5, 18, 45, 0); // 2018, May 4th, 6:45:00
            s23.EndTime = new DateTime(2018, 5, 5, 20, 25, 0); // 2018, May 4th, 8:25:00
            s23.SpecialEventStatus = SpecialEvent.NotSpecial;
            s23.TheatreNum = Theatre.TheatreTwo;
            s23.Movie = db.Movies.FirstOrDefault(x => x.Title == "Finding Nemo");
            db.Showings.AddOrUpdate(s => s.StartTime, s23);
            db.SaveChanges();

            Showing s24 = new Showing();
            s24.StartTime = new DateTime(2018, 5, 5, 20, 55, 0); // 2018, May 4th, 8:55:00
            s24.EndTime = new DateTime(2018, 5, 5, 23, 32, 0); // 2018, May 4th, 11:32:00
            s24.SpecialEventStatus = SpecialEvent.NotSpecial;
            s24.TheatreNum = Theatre.TheatreTwo;
            s24.Movie = db.Movies.FirstOrDefault(x => x.Title == "Harry Potter and the Goblet of Fire");
            db.Showings.AddOrUpdate(s => s.StartTime, s24);
            db.SaveChanges();


            Showing s25 = new Showing();
            s25.StartTime = new DateTime(2018, 5, 6, 9, 5, 0); // 2018, May 4th, 9:05:00
            s25.EndTime = new DateTime(2018, 5, 6, 11, 14, 0); // 2018, May 4th, 11:14:00
            s25.SpecialEventStatus = SpecialEvent.NotSpecial;
            s25.TheatreNum = Theatre.TheatreOne;
            s25.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Sting");
            db.Showings.AddOrUpdate(s => s.StartTime, s25);
            db.SaveChanges();

            Showing s26 = new Showing();
            s26.StartTime = new DateTime(2018, 5, 6, 11, 45, 0); // 2018, May 4th, 11:45:00
            s26.EndTime = new DateTime(2018, 5, 6, 13, 39, 0); // 2018, May 4th, 1:39:00
            s26.SpecialEventStatus = SpecialEvent.NotSpecial;
            s26.TheatreNum = Theatre.TheatreOne;
            s26.Movie = db.Movies.FirstOrDefault(x => x.Title == "WarGames");
            db.Showings.AddOrUpdate(s => s.StartTime, s26);
            db.SaveChanges();

            Showing s27 = new Showing();
            s27.StartTime = new DateTime(2018, 5, 6, 14, 10, 0); // 2018, May 4th, 2:10:00
            s27.EndTime = new DateTime(2018, 5, 6, 15, 39, 0); // 2018, May 4th, 3:39:00
            s27.SpecialEventStatus = SpecialEvent.NotSpecial;
            s27.TheatreNum = Theatre.TheatreOne;
            s27.Movie = db.Movies.FirstOrDefault(x => x.Title == "Office Space");
            db.Showings.AddOrUpdate(s => s.StartTime, s27);
            db.SaveChanges();

            Showing s28 = new Showing();
            s28.StartTime = new DateTime(2018, 5, 6, 16, 15, 0); // 2018, May 4th, 4:15:00
            s28.EndTime = new DateTime(2018, 5, 6, 18, 15, 0); // 2018, May 4th, 6:15:00
            s28.SpecialEventStatus = SpecialEvent.NotSpecial;
            s28.TheatreNum = Theatre.TheatreOne;
            s28.Movie = db.Movies.FirstOrDefault(x => x.Title == "Diamonds are Forever");
            db.Showings.AddOrUpdate(s => s.StartTime, s28);
            db.SaveChanges();

            Showing s29 = new Showing();
            s29.StartTime = new DateTime(2018, 5, 6, 18, 40, 0); // 2018, May 4th, 6:40:00
            s29.EndTime = new DateTime(2018, 5, 6, 21, 12, 0); // 2018, May 4th, 9:12:00
            s29.SpecialEventStatus = SpecialEvent.NotSpecial;
            s29.TheatreNum = Theatre.TheatreOne;
            s29.Movie = db.Movies.FirstOrDefault(x => x.Title == "West Side Story");
            db.Showings.AddOrUpdate(s => s.StartTime, s29);
            db.SaveChanges();

            Showing s30 = new Showing();
            s30.StartTime = new DateTime(2018, 5, 6, 21, 55, 0); // 2018, May 4th, 9:55:00
            s30.EndTime = new DateTime(2018, 5, 6, 23, 44, 0); // 2018, May 4th, 11:44:00
            s30.SpecialEventStatus = SpecialEvent.NotSpecial;
            s30.TheatreNum = Theatre.TheatreOne;
            s30.Movie = db.Movies.FirstOrDefault(x => x.Title == "Psycho");
            db.Showings.AddOrUpdate(s => s.StartTime, s30);
            db.SaveChanges();

            Showing s31 = new Showing();
            s31.StartTime = new DateTime(2018, 5, 6, 9, 10, 0); // 2018, May 4th, 9:10:00
            s31.EndTime = new DateTime(2018, 5, 6, 11, 29, 0); // 2018, May 4th, 11:29:00
            s31.SpecialEventStatus = SpecialEvent.NotSpecial;
            s31.TheatreNum = Theatre.TheatreTwo;
            s31.Movie = db.Movies.FirstOrDefault(x => x.Title == "Mary Poppins");
            db.Showings.AddOrUpdate(s => s.StartTime, s31);
            db.SaveChanges();

            Showing s32 = new Showing();
            s32.StartTime = new DateTime(2018, 5, 6, 12, 00, 0); // 2018, May 4th, 12:00:00
            s32.EndTime = new DateTime(2018, 5, 6, 13, 37, 0); // 2018, May 4th, 1:37:00
            s32.SpecialEventStatus = SpecialEvent.NotSpecial;
            s32.TheatreNum = Theatre.TheatreTwo;
            s32.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Muppet Movie");
            db.Showings.AddOrUpdate(s => s.StartTime, s32);
            db.SaveChanges();

            Showing s33 = new Showing();
            s33.StartTime = new DateTime(2018, 5, 6, 14, 20, 0); // 2018, May 4th, 2:20:00
            s33.EndTime = new DateTime(2018, 5, 6, 15, 58, 0); // 2018, May 4th, 3:58:00
            s33.SpecialEventStatus = SpecialEvent.NotSpecial;
            s33.TheatreNum = Theatre.TheatreTwo;
            s33.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Princess Bride");
            db.Showings.AddOrUpdate(s => s.StartTime, s33);
            db.SaveChanges();

            Showing s34 = new Showing();
            s34.StartTime = new DateTime(2018, 5, 6, 16, 30, 0); // 2018, May 4th, 4:30:00
            s34.EndTime = new DateTime(2018, 5, 6, 18, 10, 0); // 2018, May 4th, 6:10:00
            s34.SpecialEventStatus = SpecialEvent.NotSpecial;
            s34.TheatreNum = Theatre.TheatreTwo;
            s34.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Lego Movie");
            db.Showings.AddOrUpdate(s => s.StartTime, s34);
            db.SaveChanges();

            Showing s35 = new Showing();
            s35.StartTime = new DateTime(2018, 5, 6, 18, 45, 0); // 2018, May 4th, 6:45:00
            s35.EndTime = new DateTime(2018, 5, 6, 20, 25, 0); // 2018, May 4th, 8:25:00
            s35.SpecialEventStatus = SpecialEvent.NotSpecial;
            s35.TheatreNum = Theatre.TheatreTwo;
            s35.Movie = db.Movies.FirstOrDefault(x => x.Title == "Finding Nemo");
            db.Showings.AddOrUpdate(s => s.StartTime, s35);
            db.SaveChanges();

            Showing s36 = new Showing();
            s36.StartTime = new DateTime(2018, 5, 6, 20, 55, 0); // 2018, May 4th, 8:55:00
            s36.EndTime = new DateTime(2018, 5, 6, 23, 32, 0); // 2018, May 4th, 11:32:00
            s36.SpecialEventStatus = SpecialEvent.NotSpecial;
            s36.TheatreNum = Theatre.TheatreTwo;
            s36.Movie = db.Movies.FirstOrDefault(x => x.Title == "Harry Potter and the Goblet of Fire");
            db.Showings.AddOrUpdate(s => s.StartTime, s36);
            db.SaveChanges();


            Showing s37 = new Showing();
            s37.StartTime = new DateTime(2018, 5, 7, 9, 5, 0); // 2018, May 4th, 9:05:00
            s37.EndTime = new DateTime(2018, 5, 7, 11, 14, 0); // 2018, May 4th, 11:14:00
            s37.SpecialEventStatus = SpecialEvent.NotSpecial;
            s37.TheatreNum = Theatre.TheatreOne;
            s37.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Sting");
            db.Showings.AddOrUpdate(s => s.StartTime, s37);
            db.SaveChanges();

            Showing s38 = new Showing();
            s38.StartTime = new DateTime(2018, 5, 7, 11, 45, 0); // 2018, May 4th, 11:45:00
            s38.EndTime = new DateTime(2018, 5, 7, 13, 39, 0); // 2018, May 4th, 1:39:00
            s38.SpecialEventStatus = SpecialEvent.NotSpecial;
            s38.TheatreNum = Theatre.TheatreOne;
            s38.Movie = db.Movies.FirstOrDefault(x => x.Title == "WarGames");
            db.Showings.AddOrUpdate(s => s.StartTime, s38);
            db.SaveChanges();

            Showing s39 = new Showing();
            s39.StartTime = new DateTime(2018, 5, 7, 14, 10, 0); // 2018, May 4th, 2:10:00
            s39.EndTime = new DateTime(2018, 5, 7, 15, 39, 0); // 2018, May 4th, 3:39:00
            s39.SpecialEventStatus = SpecialEvent.NotSpecial;
            s39.TheatreNum = Theatre.TheatreOne;
            s39.Movie = db.Movies.FirstOrDefault(x => x.Title == "Office Space");
            db.Showings.AddOrUpdate(s => s.StartTime, s39);
            db.SaveChanges();

            Showing s40 = new Showing();
            s40.StartTime = new DateTime(2018, 5, 7, 16, 15, 0); // 2018, May 4th, 4:15:00
            s40.EndTime = new DateTime(2018, 5, 7, 18, 15, 0); // 2018, May 4th, 6:15:00
            s40.SpecialEventStatus = SpecialEvent.NotSpecial;
            s40.TheatreNum = Theatre.TheatreOne;
            s40.Movie = db.Movies.FirstOrDefault(x => x.Title == "Diamonds are Forever");
            db.Showings.AddOrUpdate(s => s.StartTime, s40);
            db.SaveChanges();

            Showing s41 = new Showing();
            s41.StartTime = new DateTime(2018, 5, 7, 18, 40, 0); // 2018, May 4th, 6:40:00
            s41.EndTime = new DateTime(2018, 5, 7, 21, 12, 0); // 2018, May 4th, 9:12:00
            s41.SpecialEventStatus = SpecialEvent.NotSpecial;
            s41.TheatreNum = Theatre.TheatreOne;
            s41.Movie = db.Movies.FirstOrDefault(x => x.Title == "West Side Story");
            db.Showings.AddOrUpdate(s => s.StartTime, s41);
            db.SaveChanges();

            Showing s42 = new Showing();
            s42.StartTime = new DateTime(2018, 5, 7, 21, 55, 0); // 2018, May 4th, 9:55:00
            s42.EndTime = new DateTime(2018, 5, 7, 23, 44, 0); // 2018, May 4th, 11:44:00
            s42.SpecialEventStatus = SpecialEvent.NotSpecial;
            s42.TheatreNum = Theatre.TheatreOne;
            s42.Movie = db.Movies.FirstOrDefault(x => x.Title == "Psycho");
            db.Showings.AddOrUpdate(s => s.StartTime, s42);
            db.SaveChanges();

            Showing s43 = new Showing();
            s43.StartTime = new DateTime(2018, 5, 7, 9, 10, 0); // 2018, May 4th, 9:10:00
            s43.EndTime = new DateTime(2018, 5, 7, 11, 29, 0); // 2018, May 4th, 11:29:00
            s43.SpecialEventStatus = SpecialEvent.NotSpecial;
            s43.TheatreNum = Theatre.TheatreTwo;
            s43.Movie = db.Movies.FirstOrDefault(x => x.Title == "Mary Poppins");
            db.Showings.AddOrUpdate(s => s.StartTime, s43);
            db.SaveChanges();

            Showing s44 = new Showing();
            s44.StartTime = new DateTime(2018, 5, 7, 12, 00, 0); // 2018, May 4th, 12:00:00
            s44.EndTime = new DateTime(2018, 5, 7, 13, 37, 0); // 2018, May 4th, 1:37:00
            s44.SpecialEventStatus = SpecialEvent.NotSpecial;
            s44.TheatreNum = Theatre.TheatreTwo;
            s44.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Muppet Movie");
            db.Showings.AddOrUpdate(s => s.StartTime, s44);
            db.SaveChanges();

            Showing s45 = new Showing();
            s45.StartTime = new DateTime(2018, 5, 7, 14, 20, 0); // 2018, May 4th, 2:20:00
            s45.EndTime = new DateTime(2018, 5, 7, 15, 58, 0); // 2018, May 4th, 3:58:00
            s45.SpecialEventStatus = SpecialEvent.NotSpecial;
            s45.TheatreNum = Theatre.TheatreTwo;
            s45.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Princess Bride");
            db.Showings.AddOrUpdate(s => s.StartTime, s45);
            db.SaveChanges();

            Showing s46 = new Showing();
            s46.StartTime = new DateTime(2018, 5, 7, 16, 30, 0); // 2018, May 4th, 4:30:00
            s46.EndTime = new DateTime(2018, 5, 7, 18, 10, 0); // 2018, May 4th, 6:10:00
            s46.SpecialEventStatus = SpecialEvent.NotSpecial;
            s46.TheatreNum = Theatre.TheatreTwo;
            s46.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Lego Movie");
            db.Showings.AddOrUpdate(s => s.StartTime, s46);
            db.SaveChanges();

            Showing s47 = new Showing();
            s47.StartTime = new DateTime(2018, 5, 7, 18, 45, 0); // 2018, May 4th, 6:45:00
            s47.EndTime = new DateTime(2018, 5, 7, 20, 25, 0); // 2018, May 4th, 8:25:00
            s47.SpecialEventStatus = SpecialEvent.NotSpecial;
            s47.TheatreNum = Theatre.TheatreTwo;
            s47.Movie = db.Movies.FirstOrDefault(x => x.Title == "Finding Nemo");
            db.Showings.AddOrUpdate(s => s.StartTime, s47);
            db.SaveChanges();

            Showing s48 = new Showing();
            s48.StartTime = new DateTime(2018, 5, 7, 20, 55, 0); // 2018, May 4th, 8:55:00
            s48.EndTime = new DateTime(2018, 5, 7, 23, 32, 0); // 2018, May 4th, 11:32:00
            s48.SpecialEventStatus = SpecialEvent.NotSpecial;
            s48.TheatreNum = Theatre.TheatreTwo;
            s48.Movie = db.Movies.FirstOrDefault(x => x.Title == "Harry Potter and the Goblet of Fire");
            db.Showings.AddOrUpdate(s => s.StartTime, s48);
            db.SaveChanges();


            Showing s49 = new Showing();
            s49.StartTime = new DateTime(2018, 5, 8, 9, 5, 0); // 2018, May 4th, 9:05:00
            s49.EndTime = new DateTime(2018, 5, 8, 11, 14, 0); // 2018, May 4th, 11:14:00
            s49.SpecialEventStatus = SpecialEvent.NotSpecial;
            s49.TheatreNum = Theatre.TheatreOne;
            s49.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Sting");
            db.Showings.AddOrUpdate(s => s.StartTime, s49);
            db.SaveChanges();

            Showing s50 = new Showing();
            s50.StartTime = new DateTime(2018, 5, 8, 11, 45, 0); // 2018, May 4th, 11:45:00
            s50.EndTime = new DateTime(2018, 5, 8, 13, 39, 0); // 2018, May 4th, 1:39:00
            s50.SpecialEventStatus = SpecialEvent.NotSpecial;
            s50.TheatreNum = Theatre.TheatreOne;
            s50.Movie = db.Movies.FirstOrDefault(x => x.Title == "WarGames");
            db.Showings.AddOrUpdate(s => s.StartTime, s50);
            db.SaveChanges();

            Showing s51 = new Showing();
            s51.StartTime = new DateTime(2018, 5, 8, 14, 10, 0); // 2018, May 4th, 2:10:00
            s51.EndTime = new DateTime(2018, 5, 8, 15, 39, 0); // 2018, May 4th, 3:39:00
            s51.SpecialEventStatus = SpecialEvent.NotSpecial;
            s51.TheatreNum = Theatre.TheatreOne;
            s51.Movie = db.Movies.FirstOrDefault(x => x.Title == "Office Space");
            db.Showings.AddOrUpdate(s => s.StartTime, s51);
            db.SaveChanges();

            Showing s52 = new Showing();
            s52.StartTime = new DateTime(2018, 5, 8, 16, 15, 0); // 2018, May 4th, 4:15:00
            s52.EndTime = new DateTime(2018, 5, 8, 18, 15, 0); // 2018, May 4th, 6:15:00
            s52.SpecialEventStatus = SpecialEvent.NotSpecial;
            s52.TheatreNum = Theatre.TheatreOne;
            s52.Movie = db.Movies.FirstOrDefault(x => x.Title == "Diamonds are Forever");
            db.Showings.AddOrUpdate(s => s.StartTime, s52);
            db.SaveChanges();

            Showing s53 = new Showing();
            s53.StartTime = new DateTime(2018, 5, 8, 18, 40, 0); // 2018, May 4th, 6:40:00
            s53.EndTime = new DateTime(2018, 5, 8, 21, 12, 0); // 2018, May 4th, 9:12:00
            s53.SpecialEventStatus = SpecialEvent.NotSpecial;
            s53.TheatreNum = Theatre.TheatreOne;
            s53.Movie = db.Movies.FirstOrDefault(x => x.Title == "West Side Story");
            db.Showings.AddOrUpdate(s => s.StartTime, s53);
            db.SaveChanges();

            Showing s54 = new Showing();
            s54.StartTime = new DateTime(2018, 5, 8, 21, 55, 0); // 2018, May 4th, 9:55:00
            s54.EndTime = new DateTime(2018, 5, 8, 23, 44, 0); // 2018, May 4th, 11:44:00
            s54.SpecialEventStatus = SpecialEvent.NotSpecial;
            s54.TheatreNum = Theatre.TheatreOne;
            s54.Movie = db.Movies.FirstOrDefault(x => x.Title == "Psycho");
            db.Showings.AddOrUpdate(s => s.StartTime, s54);
            db.SaveChanges();

            Showing s55 = new Showing();
            s55.StartTime = new DateTime(2018, 5, 8, 9, 10, 0); // 2018, May 4th, 9:10:00
            s55.EndTime = new DateTime(2018, 5, 8, 11, 29, 0); // 2018, May 4th, 11:29:00
            s55.SpecialEventStatus = SpecialEvent.NotSpecial;
            s55.TheatreNum = Theatre.TheatreTwo;
            s55.Movie = db.Movies.FirstOrDefault(x => x.Title == "Mary Poppins");
            db.Showings.AddOrUpdate(s => s.StartTime, s55);
            db.SaveChanges();

            Showing s56 = new Showing();
            s56.StartTime = new DateTime(2018, 5, 8, 12, 00, 0); // 2018, May 4th, 12:00:00
            s56.EndTime = new DateTime(2018, 5, 8, 13, 37, 0); // 2018, May 4th, 1:37:00
            s56.SpecialEventStatus = SpecialEvent.NotSpecial;
            s56.TheatreNum = Theatre.TheatreTwo;
            s56.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Muppet Movie");
            db.Showings.AddOrUpdate(s => s.StartTime, s56);
            db.SaveChanges();

            Showing s57 = new Showing();
            s57.StartTime = new DateTime(2018, 5, 8, 14, 20, 0); // 2018, May 4th, 2:20:00
            s57.EndTime = new DateTime(2018, 5, 8, 15, 58, 0); // 2018, May 4th, 3:58:00
            s57.SpecialEventStatus = SpecialEvent.NotSpecial;
            s57.TheatreNum = Theatre.TheatreTwo;
            s57.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Princess Bride");
            db.Showings.AddOrUpdate(s => s.StartTime, s57);
            db.SaveChanges();

            Showing s58 = new Showing();
            s58.StartTime = new DateTime(2018, 5, 8, 16, 30, 0); // 2018, May 4th, 4:30:00
            s58.EndTime = new DateTime(2018, 5, 8, 18, 10, 0); // 2018, May 4th, 6:10:00
            s58.SpecialEventStatus = SpecialEvent.NotSpecial;
            s58.TheatreNum = Theatre.TheatreTwo;
            s58.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Lego Movie");
            db.Showings.AddOrUpdate(s => s.StartTime, s58);
            db.SaveChanges();

            Showing s59 = new Showing();
            s59.StartTime = new DateTime(2018, 5, 8, 18, 45, 0); // 2018, May 4th, 6:45:00
            s59.EndTime = new DateTime(2018, 5, 8, 20, 25, 0); // 2018, May 4th, 8:25:00
            s59.SpecialEventStatus = SpecialEvent.NotSpecial;
            s59.TheatreNum = Theatre.TheatreTwo;
            s59.Movie = db.Movies.FirstOrDefault(x => x.Title == "Finding Nemo");
            db.Showings.AddOrUpdate(s => s.StartTime, s59);
            db.SaveChanges();

            Showing s60 = new Showing();
            s60.StartTime = new DateTime(2018, 5, 8, 20, 55, 0); // 2018, May 4th, 8:55:00
            s60.EndTime = new DateTime(2018, 5, 8, 23, 32, 0); // 2018, May 4th, 11:32:00
            s60.SpecialEventStatus = SpecialEvent.NotSpecial;
            s60.TheatreNum = Theatre.TheatreTwo;
            s60.Movie = db.Movies.FirstOrDefault(x => x.Title == "Harry Potter and the Goblet of Fire");
            db.Showings.AddOrUpdate(s => s.StartTime, s60);
            db.SaveChanges();


            Showing s61 = new Showing();
            s61.StartTime = new DateTime(2018, 5, 9, 9, 5, 0); // 2018, May 4th, 9:05:00
            s61.EndTime = new DateTime(2018, 5, 9, 11, 14, 0); // 2018, May 4th, 11:14:00
            s61.SpecialEventStatus = SpecialEvent.NotSpecial;
            s61.TheatreNum = Theatre.TheatreOne;
            s61.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Sting");
            db.Showings.AddOrUpdate(s => s.StartTime, s61);
            db.SaveChanges();

            Showing s62 = new Showing();
            s62.StartTime = new DateTime(2018, 5, 9, 11, 45, 0); // 2018, May 4th, 11:45:00
            s62.EndTime = new DateTime(2018, 5, 9, 13, 39, 0); // 2018, May 4th, 1:39:00
            s62.SpecialEventStatus = SpecialEvent.NotSpecial;
            s62.TheatreNum = Theatre.TheatreOne;
            s62.Movie = db.Movies.FirstOrDefault(x => x.Title == "WarGames");
            db.Showings.AddOrUpdate(s => s.StartTime, s62);
            db.SaveChanges();

            Showing s63 = new Showing();
            s63.StartTime = new DateTime(2018, 5, 9, 14, 10, 0); // 2018, May 4th, 2:10:00
            s63.EndTime = new DateTime(2018, 5, 9, 15, 39, 0); // 2018, May 4th, 3:39:00
            s63.SpecialEventStatus = SpecialEvent.NotSpecial;
            s63.TheatreNum = Theatre.TheatreOne;
            s63.Movie = db.Movies.FirstOrDefault(x => x.Title == "Office Space");
            db.Showings.AddOrUpdate(s => s.StartTime, s63);
            db.SaveChanges();

            Showing s64 = new Showing();
            s64.StartTime = new DateTime(2018, 5, 9, 16, 15, 0); // 2018, May 4th, 4:15:00
            s64.EndTime = new DateTime(2018, 5, 9, 18, 15, 0); // 2018, May 4th, 6:15:00
            s64.SpecialEventStatus = SpecialEvent.NotSpecial;
            s64.TheatreNum = Theatre.TheatreOne;
            s64.Movie = db.Movies.FirstOrDefault(x => x.Title == "Diamonds are Forever");
            db.Showings.AddOrUpdate(s => s.StartTime, s64);
            db.SaveChanges();

            Showing s65 = new Showing();
            s65.StartTime = new DateTime(2018, 5, 9, 18, 40, 0); // 2018, May 4th, 6:40:00
            s65.EndTime = new DateTime(2018, 5, 9, 21, 12, 0); // 2018, May 4th, 9:12:00
            s65.SpecialEventStatus = SpecialEvent.NotSpecial;
            s65.TheatreNum = Theatre.TheatreOne;
            s65.Movie = db.Movies.FirstOrDefault(x => x.Title == "West Side Story");
            db.Showings.AddOrUpdate(s => s.StartTime, s65);
            db.SaveChanges();

            Showing s66 = new Showing();
            s66.StartTime = new DateTime(2018, 5, 9, 21, 55, 0); // 2018, May 4th, 9:55:00
            s66.EndTime = new DateTime(2018, 5, 9, 23, 44, 0); // 2018, May 4th, 11:44:00
            s66.SpecialEventStatus = SpecialEvent.NotSpecial;
            s66.TheatreNum = Theatre.TheatreOne;
            s66.Movie = db.Movies.FirstOrDefault(x => x.Title == "Psycho");
            db.Showings.AddOrUpdate(s => s.StartTime, s66);
            db.SaveChanges();

            Showing s67 = new Showing();
            s67.StartTime = new DateTime(2018, 5, 9, 9, 10, 0); // 2018, May 4th, 9:10:00
            s67.EndTime = new DateTime(2018, 5, 9, 11, 29, 0); // 2018, May 4th, 11:29:00
            s67.SpecialEventStatus = SpecialEvent.NotSpecial;
            s67.TheatreNum = Theatre.TheatreTwo;
            s67.Movie = db.Movies.FirstOrDefault(x => x.Title == "Mary Poppins");
            db.Showings.AddOrUpdate(s => s.StartTime, s67);
            db.SaveChanges();

            Showing s68 = new Showing();
            s68.StartTime = new DateTime(2018, 5, 9, 12, 00, 0); // 2018, May 4th, 12:00:00
            s68.EndTime = new DateTime(2018, 5, 9, 13, 37, 0); // 2018, May 4th, 1:37:00
            s68.SpecialEventStatus = SpecialEvent.NotSpecial;
            s68.TheatreNum = Theatre.TheatreTwo;
            s68.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Muppet Movie");
            db.Showings.AddOrUpdate(s => s.StartTime, s68);
            db.SaveChanges();

            Showing s69 = new Showing();
            s69.StartTime = new DateTime(2018, 5, 9, 14, 20, 0); // 2018, May 4th, 2:20:00
            s69.EndTime = new DateTime(2018, 5, 9, 15, 58, 0); // 2018, May 4th, 3:58:00
            s69.SpecialEventStatus = SpecialEvent.NotSpecial;
            s69.TheatreNum = Theatre.TheatreTwo;
            s69.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Princess Bride");
            db.Showings.AddOrUpdate(s => s.StartTime, s69);
            db.SaveChanges();

            Showing s70 = new Showing();
            s70.StartTime = new DateTime(2018, 5, 9, 16, 30, 0); // 2018, May 4th, 4:30:00
            s70.EndTime = new DateTime(2018, 5, 9, 18, 10, 0); // 2018, May 4th, 6:10:00
            s70.SpecialEventStatus = SpecialEvent.NotSpecial;
            s70.TheatreNum = Theatre.TheatreTwo;
            s70.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Lego Movie");
            db.Showings.AddOrUpdate(s => s.StartTime, s70);
            db.SaveChanges();

            Showing s71 = new Showing();
            s71.StartTime = new DateTime(2018, 5, 9, 18, 45, 0); // 2018, May 4th, 6:45:00
            s71.EndTime = new DateTime(2018, 5, 9, 20, 25, 0); // 2018, May 4th, 8:25:00
            s71.SpecialEventStatus = SpecialEvent.NotSpecial;
            s71.TheatreNum = Theatre.TheatreTwo;
            s71.Movie = db.Movies.FirstOrDefault(x => x.Title == "Finding Nemo");
            db.Showings.AddOrUpdate(s => s.StartTime, s71);
            db.SaveChanges();

            Showing s72 = new Showing();
            s72.StartTime = new DateTime(2018, 5, 9, 20, 55, 0); // 2018, May 4th, 8:55:00
            s72.EndTime = new DateTime(2018, 5, 9, 23, 32, 0); // 2018, May 4th, 11:32:00
            s72.SpecialEventStatus = SpecialEvent.NotSpecial;
            s72.TheatreNum = Theatre.TheatreTwo;
            s72.Movie = db.Movies.FirstOrDefault(x => x.Title == "Harry Potter and the Goblet of Fire");
            db.Showings.AddOrUpdate(s => s.StartTime, s72);
            db.SaveChanges();


            Showing s73 = new Showing();
            s73.StartTime = new DateTime(2018, 5, 10, 9, 5, 0); // 2018, May 4th, 9:05:00
            s73.EndTime = new DateTime(2018, 5, 10, 11, 14, 0); // 2018, May 4th, 11:14:00
            s73.SpecialEventStatus = SpecialEvent.NotSpecial;
            s73.TheatreNum = Theatre.TheatreOne;
            s73.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Sting");
            db.Showings.AddOrUpdate(s => s.StartTime, s73);
            db.SaveChanges();

            Showing s74 = new Showing();
            s74.StartTime = new DateTime(2018, 5, 10, 11, 45, 0); // 2018, May 4th, 11:45:00
            s74.EndTime = new DateTime(2018, 5, 10, 13, 39, 0); // 2018, May 4th, 1:39:00
            s74.SpecialEventStatus = SpecialEvent.NotSpecial;
            s74.TheatreNum = Theatre.TheatreOne;
            s74.Movie = db.Movies.FirstOrDefault(x => x.Title == "WarGames");
            db.Showings.AddOrUpdate(s => s.StartTime, s74);
            db.SaveChanges();

            Showing s75 = new Showing();
            s75.StartTime = new DateTime(2018, 5, 10, 14, 10, 0); // 2018, May 4th, 2:10:00
            s75.EndTime = new DateTime(2018, 5, 10, 15, 39, 0); // 2018, May 4th, 3:39:00
            s75.SpecialEventStatus = SpecialEvent.NotSpecial;
            s75.TheatreNum = Theatre.TheatreOne;
            s75.Movie = db.Movies.FirstOrDefault(x => x.Title == "Office Space");
            db.Showings.AddOrUpdate(s => s.StartTime, s75);
            db.SaveChanges();

            Showing s76 = new Showing();
            s76.StartTime = new DateTime(2018, 5, 10, 16, 15, 0); // 2018, May 4th, 4:15:00
            s76.EndTime = new DateTime(2018, 5, 10, 18, 15, 0); // 2018, May 4th, 6:15:00
            s76.SpecialEventStatus = SpecialEvent.NotSpecial;
            s76.TheatreNum = Theatre.TheatreOne;
            s76.Movie = db.Movies.FirstOrDefault(x => x.Title == "Diamonds are Forever");
            db.Showings.AddOrUpdate(s => s.StartTime, s76);
            db.SaveChanges();

            Showing s77 = new Showing();
            s77.StartTime = new DateTime(2018, 5, 10, 18, 40, 0); // 2018, May 4th, 6:40:00
            s77.EndTime = new DateTime(2018, 5, 10, 21, 12, 0); // 2018, May 4th, 9:12:00
            s77.SpecialEventStatus = SpecialEvent.NotSpecial;
            s77.TheatreNum = Theatre.TheatreOne;
            s77.Movie = db.Movies.FirstOrDefault(x => x.Title == "West Side Story");
            db.Showings.AddOrUpdate(s => s.StartTime, s77);
            db.SaveChanges();

            Showing s78 = new Showing();
            s78.StartTime = new DateTime(2018, 5, 10, 21, 55, 0); // 2018, May 4th, 9:55:00
            s78.EndTime = new DateTime(2018, 5, 10, 23, 44, 0); // 2018, May 4th, 11:44:00
            s78.SpecialEventStatus = SpecialEvent.NotSpecial;
            s78.TheatreNum = Theatre.TheatreOne;
            s78.Movie = db.Movies.FirstOrDefault(x => x.Title == "Psycho");
            db.Showings.AddOrUpdate(s => s.StartTime, s78);
            db.SaveChanges();

            Showing s79 = new Showing();
            s79.StartTime = new DateTime(2018, 5, 10, 9, 10, 0); // 2018, May 4th, 9:10:00
            s79.EndTime = new DateTime(2018, 5, 10, 11, 29, 0); // 2018, May 4th, 11:29:00
            s79.SpecialEventStatus = SpecialEvent.NotSpecial;
            s79.TheatreNum = Theatre.TheatreTwo;
            s79.Movie = db.Movies.FirstOrDefault(x => x.Title == "Mary Poppins");
            db.Showings.AddOrUpdate(s => s.StartTime, s79);
            db.SaveChanges();

            Showing s80 = new Showing();
            s80.StartTime = new DateTime(2018, 5, 10, 12, 00, 0); // 2018, May 4th, 12:00:00
            s80.EndTime = new DateTime(2018, 5, 10, 13, 37, 0); // 2018, May 4th, 1:37:00
            s80.SpecialEventStatus = SpecialEvent.NotSpecial;
            s80.TheatreNum = Theatre.TheatreTwo;
            s80.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Muppet Movie");
            db.Showings.AddOrUpdate(s => s.StartTime, s80);
            db.SaveChanges();

            Showing s81 = new Showing();
            s81.StartTime = new DateTime(2018, 5, 10, 14, 20, 0); // 2018, May 4th, 2:20:00
            s81.EndTime = new DateTime(2018, 5, 10, 15, 58, 0); // 2018, May 4th, 3:58:00
            s81.SpecialEventStatus = SpecialEvent.NotSpecial;
            s81.TheatreNum = Theatre.TheatreTwo;
            s81.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Princess Bride");
            db.Showings.AddOrUpdate(s => s.StartTime, s81);
            db.SaveChanges();

            Showing s82 = new Showing();
            s82.StartTime = new DateTime(2018, 5, 10, 16, 30, 0); // 2018, May 4th, 4:30:00
            s82.EndTime = new DateTime(2018, 5, 10, 18, 10, 0); // 2018, May 4th, 6:10:00
            s82.SpecialEventStatus = SpecialEvent.NotSpecial;
            s82.TheatreNum = Theatre.TheatreTwo;
            s82.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Lego Movie");
            db.Showings.AddOrUpdate(s => s.StartTime, s82);
            db.SaveChanges();

            Showing s83 = new Showing();
            s83.StartTime = new DateTime(2018, 5, 10, 18, 45, 0); // 2018, May 4th, 6:45:00
            s83.EndTime = new DateTime(2018, 5, 10, 20, 25, 0); // 2018, May 4th, 8:25:00
            s83.SpecialEventStatus = SpecialEvent.NotSpecial;
            s83.TheatreNum = Theatre.TheatreTwo;
            s83.Movie = db.Movies.FirstOrDefault(x => x.Title == "Finding Nemo");
            db.Showings.AddOrUpdate(s => s.StartTime, s83);
            db.SaveChanges();

            Showing s84 = new Showing();
            s84.StartTime = new DateTime(2018, 5, 10, 20, 55, 0); // 2018, May 4th, 8:55:00
            s84.EndTime = new DateTime(2018, 5, 10, 23, 32, 0); // 2018, May 4th, 11:32:00
            s84.SpecialEventStatus = SpecialEvent.NotSpecial;
            s84.TheatreNum = Theatre.TheatreTwo;
            s84.Movie = db.Movies.FirstOrDefault(x => x.Title == "Harry Potter and the Goblet of Fire");
            db.Showings.AddOrUpdate(s => s.StartTime, s84);
            db.SaveChanges();




            // I made this example to exactly echo the first example in the spreadsheet
            // NOTE: keep in mind there are only 12 showings in the seed data -
            //         it might be easier to type them in manually than to create a script
            // removed s1.SeatList(...  because it gets created in the Showing.cs constructor
        }
    }
}