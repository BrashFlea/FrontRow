using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontRowCMS2.Models;
using FrontRowCMS2.Models.Home;
using FrontRowCMS2.Models.Secondary;

namespace FrontRowCMS2.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            //Look for proff that database has been seeded
            if (context.History.Any())
            {
                return; //Skip initialization if already been seeded
            }

            #region Site-Wide Initialization
            ///FOOTER
            context.Footer.Add(new Footer { ContactEmail = "info@yfut.org", ContactPhone = "801-528-1214", MailingAddressLine1 = "POB 160301", MailingAddressLine2 = "Clearfield, UT 84016",
                ShelterAddressLine1 = "2760 S. Adams Ave", ShelterAddressLine2 = "Ogden, UT 84403", HomeImage = "page_1.png", InstagramLink = "",
                TwitterLink = "", TumblrLink = "", FacebookLink = ""
            });
            context.SaveChanges();

            ///USERS
            //context.User.Add(new User { Username = "admin", Password = "", Email = "admin@yfut.org" });

            #endregion

            #region Home Page Initialization
            //Home Page


            #endregion

            #region Secondary Page Initialization
            ///HISTORY SECTION
            context.History.Add(new History { TextArea1 = "Located in the heart of downtown Ogden, Youth Futures opened Utah's first homeless Residential Support Temporary Youth Shelter on February 20, 2015. Youth Futures provides shelter and drop-in services to all youth ages 12-17, and will not exclude any youth who falls within these age ranges, regardless of circumstance. We provide 14 temporary overnight shelter beds and day-time drop-in services to youth, as well as intensive case management to help youth become re-united with family or self-sufficiently contributing to our community. Weekly outreach efforts assist in building rapport with street youth, ensuring they receive food and other basic necessities and educating them about options to living in unsafe conditions. Youth are guided in a loving, supportive and productive way, encouraging their own personal path for a healthy future.",
                TextArea2 = "Youth Futures was founded by Kristen Mitchell and Scott Catuccio, who had been conceptually planning to provide shelter and case management services to youth for over six years. It was identified that there was a lack of shelter services for the estimated 5,000 youth who experience homelessness for at least one night a year in Utah, so Scott and Kristen began researching other states that provide shelter services to youth. It was quickly identified that the largest barrier to providing services to homeless youth in Utah was a law prohibiting the opening of shelter facilities for youth.",
                Image1 = "history_kristen_scott.jpg", Image2 = "history_shelter.jpg", Image3 = "history_kristen.jpg",
                Caption1 = "Kristen and Scott", Caption2 = "The shelter home", Caption3 = "Kristen"
            });
            context.SaveChanges();

            //OUTREACH
            context.Outreach.Add(new Outreach
            {
                Image = "outreach_header.jpg",
                TextArea1 = "STREET",
                TextArea2 = "OUTREACH",
                TextArea3 = "Street Outreach is designed to meet the clients where they are on the street to build rapport and encourage youth to access drop-in and shelter services. This program offers, case management, hygiene items, food, sleeping bags, and other essential items as needed. Street Outreach currently take place once per week on Wednesdays. The team visits the same Ogden, Utah locations every week:"
            });
            context.SaveChanges();

            var Table = new OutreachTable[]
            {
                new OutreachTable{ OutreachID = 1, Location = "Jefferson Park" },
                new OutreachTable{ OutreachID = 1, Location = "Basketball Court at Bonneville Park" },
                new OutreachTable{ OutreachID = 1, Location = "Marchall White Center Park" },
                new OutreachTable{ OutreachID = 1, Location = "Under the Ogden River Bridge (sporadic)" },
                new OutreachTable{ OutreachID = 1, Location = "Lorin Farr Skate Park" },
                new OutreachTable{ OutreachID = 1, Location = "Lantern House Homeless Shelter" }
            };
            foreach(OutreachTable o in Table)
            {
                context.OutreachTable.Add(o);
            }
            context.SaveChanges();

            ///DIRECTORS
            var directors = new Person[]
            {
                new Person{Image="",Name="SCOTT CATUCCIO",Title1="Board President",Title2="President, A3 Utah",Email="scott.catuccio@gmail.com",Type=PersonType.Director},
                new Person{Image="",Name="KRISTEN MITCHELL",Title1="Board Vice President",Title2="Executive Director, Youth Futures",Email="kristen@yfut.org",Type=PersonType.Director},
                new Person{Image="",Name="ALYSON DEUSSEN",Title1="Board Secretary",Title2="Ouelessebougou Utah Alliance",Email="alysondeussen@gmail.com",Type=PersonType.Director}
            };
            foreach(Person d in directors)
            {
                context.Persons.Add(d);
            }
            context.SaveChanges();

            ///STAFF
            var staff = new Person[]
            {
                new Person{Image="staff_justine.jpg",Name="JUSTINE MURRAY",Title1="Program Manager, Youth Futures",Title2="President, A3 Utah",Email="jmurray@yfut.org",Type=PersonType.Staff},
                new Person{Image="staff_susan.jpg",Name="SUSAN MCBRIDE",Title1="Floor Staff Co-Lead, Youth Futures",Title2="Executive Director, Youth Futures",Email="kristen@yfut.org",Type=PersonType.Staff},
                new Person{Image="staff_alyson.jpg",Name="ALYSON DEUSSEN",Title1="Floor Staff Co-Lead, Youth Futures",Title2="Ouelessebougou Utah Alliance",Email="aallred@yfut.org",Type=PersonType.Staff}
            };
            foreach (Person s in staff)
            {
                context.Persons.Add(s);
            }
            context.SaveChanges();

            //LIST OF NEEDS
            context.Needs.Add(new Needs { Title = "LIST OF NEEDS",
                                          TextArea1 = "MOST IMPORTANT NEEDS (In order of priority) \n Cash donations \n Printer Paper \n Canned meat & Jerky \n Scotch tape \n Bus tokens or passes \n Earbud Headphones \n Cinch bags \n Batteries \n Sweat Pants \n Pajama Bottoms \n Sports bras \n Trail mix individuals \n Toilet Paper \n Condoms \n Tampons \n Carabiners \n Paper plates and cups \n Men's and Women's Underwear \n Socks \n Kleenex individuals \n Undershirts, S M L XL \n Garbage bags 30 Gallon \n Garbage sacks small bathroom \n Lip balm \n Ziploc bags, quart and gallon \n Energy Bars \n Heavy duty plastic storage bins that won't melt if heated in shed",
                                          TextArea2 = "MISC. NEEDS \n Minivan \n NEW Printer \n GIFT CARDS FOR \n Walmart \n Fun things to do \n Grocery store \n Maverick \n Restaurants \n Movies \n Bus passes or tokens \n Phone minutes \n Beauty salons/ haircuts \n For shoe stores \n Lagoon passes",
                                          TextArea3 = "HOUSEHOLD FURNISHINGS NEEDS \n NEW pots and pans \n New Couches \n VOLUNTEERS \n Mentors \n Educators \n Group activity facilitators \n Meal preparers / providers \n Tutors \n Life skills trainers \n Beauticians \n Street Outreach Workers \n Artists for classes \n Yard work \n Interior painters \n REPAIR NEEDS \n Concrete or pavers 1500 sq.feet \n Cement sidewalk repair & labor"
            });
            context.SaveChanges();

            //Calendar
            context.Calendar.Add(new Calendar { Name = "Calendar" });
            context.SaveChanges();

            //CalendarMonths
            context.CalendarMonths.Add(new CalendarMonths { CalenderID = 1,
                                                            Month = "March",
                                                            Year = "2017"});
            context.SaveChanges();

            //CalendarEvents
            context.CalendarEvents.Add(new CalendarEvents { MonthID = 1,
                                                            Day = "March 8, 2017",
                                                            What = "Weber State Youth Charity Dinner",
                                                            When = "03/8/2017 7:00-9:00 pm",
                                                            Where = "Weber State University, Browning Center, Ballroom C",
                                                            Info = "Youth Futures is hosting it’s 6th Annual Charity Dinner Auction at the Meydenbauer Center in Bellevue, WA. Join us for an evening of glamor and geekery, hosted by Mike “Gabe” Krahulik and Jerry “Tycho” Holkins of Penny Arcade and featuring auction items from every corner of the nerd (and non-nerd) universe."
            });


            #endregion


        }
    }
}
