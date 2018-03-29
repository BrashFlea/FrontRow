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
            context.Database.EnsureDeleted();
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
                TextArea = "<div class=\"container - fluid\">\n\t< div class=\"row outreach_text\">\n\t\t<section class=\"col-xs-12\">\n\t\t\t<p class=\"mont_regular_22_darkgray\">Street Outreach is designed to meet the clients where they are on the street to build rapport and encourage youth to access drop-in and shelter services.This program offers, case management, hygiene items, food, sleeping bags, and other essential items as needed.Street Outreach currently take place once per week on Wednesdays.The team visits the same Ogden, Utah locations every week:</p>\n\t\t</section>\n\t</div>\n</div>\n\n<div class=\"container-fluid\">\n\t<div class=\"row outreach_bullet\">\n\t\t<section class=\"col-xs-12 col-md-6\">\n\t\t\t<ul>\n\t\t\t\t<li>Jefferson Park</li>\n\t\t\t\t<li>Marchall White Center Park</li>\n\t\t\t\t<li>Lorin Farr Skate Park</li>\n\t\t\t</ul>\n\t\t</section>\n\n\t\t<section class=\"col-xs-12 col-md-6\">\n\t\t\t<ul>\n\t\t\t\t<li>Basketball Court at Bonneville Park</li>\n\t\t\t\t<li>Under the Ogden River Bridge(sporadic)</li>\n\t\t\t\t<li>Lantern House Homeless Shelter</li>\n\t\t\t</ul>\n\t\t</section>\n\t</div>\n</div>"
            });
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
            context.Needs.Add(new Needs { TextArea = "<div class=\"container - fluid needs\">\n\t< div class=\"row donate_help\">\n\t\t<div class=\"col-xs-12\">\n\t\t\t<p>LIST OF NEEDS</p>\n\t\t</div>\n\t</div>\n\n\t<div class=\"row\">\n\t\t<div class=\"col-xs-12 col-md-4 needs_list\">\n\t\t\t<p class=\"needs_subheader\">\n\t\t\t\tMOST IMPORTANT NEEDS\n\t\t\t\t(In order of priority)\n\t\t\t</p>\n\t\t\t<ul>\n\t\t\t\t<li>Cash donations</li>\n\t\t\t\t<li>Printer Paper</li>\n\t\t\t\t<li>Canned meat & Jerky</li>\n\t\t\t\t<li>Scotch tape</li>\n\t\t\t\t<li>Bus tokens or passes</li>\n\t\t\t\t<li>Earbud Headphones</li>\n\t\t\t\t<li>Cinch bags</li>\n\t\t\t\t<li>Batteries</li>\n\t\t\t\t<li>Sweat Pants</li>\n\t\t\t\t<li>Pajama Bottoms</li>\n\t\t\t\t<li>Sports bras</li>\n\t\t\t\t<li>Trail mix individuals</li>\n\t\t\t\t<li>Toilet Paper</li>\n\t\t\t\t<li>Condoms</li>\n\t\t\t\t<li>Tampons</li>\n\t\t\t\t<li>Carabiners</li>\n\t\t\t\t<li>Paper plates and cups</li>\n\t\t\t\t<li>Men's and Women's Underwear</li>\n\t\t\t\t<li>Socks</li>\n\t\t\t\t<li>Kleenex individuals</li>\n\t\t\t\t<li>Undershirts, S M L XL</li>\n\t\t\t\t<li>Garbage bags 30 Gallon</li>\n\t\t\t\t<li>Garbage sacks small bathroom</li>\n\t\t\t\t<li>Lip balm</li>\n\t\t\t\t<li>Ziploc bags, quart and gallon</li>\n\t\t\t\t<li>Energy Bars</li>\n\t\t\t\t<li>Heavy duty plastic storage bins that won\'t melt if heated in shed</li>\n\t\t\t</ul>\n\t\t</div>\n\n\t\t<div class=\"col-xs-12 col-md-4 needs_list\">\n\t\t\t<p class=\"needs_subheader\">MISC.NEEDS</p>\n\t\t\t<ul>\n\t\t\t\t<li>Minivan</li>\n\t\t\t\t<li>NEW Printer</li>\n\t\t\t</ul>\n\t\t\t<p class=\"needs_subheader\">GIFT CARDS FOR</p>\n\t\t\t<ul>\n\t\t\t\t<li>Walmart</li>\n\t\t\t\t<li>Fun things to do</li>\n\t\t\t\t<li>Grocery store</li>\n\t\t\t\t<li>Maverick</li>\n\t\t\t\t<li>Restaurants</li>\n\t\t\t\t<li>Movies</li>\n\t\t\t\t<li>Bus passes or tokens</li>\n\t\t\t\t<li>Phone minutes </li>\n\t\t\t\t<li>Beauty salons/haircuts</li>\n\t\t\t\t<li>For shoe stores</li>\n\t\t\t\t<li>Lagoon passes</li>\n\t\t\t</ul>\n\t\t</div>\n\n\t\t<div class=\"col-xs-12 col-md-4 needs_list\">\n\t\t\t<p class=\"needs_subheader\">HOUSEHOLD FURNISHINGS NEEDS</p>\n\t\t\t<ul>\n\t\t\t\t<li>NEW pots and pans</li>\n\t\t\t\t<li>New Couches</li>\n\t\t\t</ul>\n\t\t\t<p class=\"needs_subheader\">VOLUNTEERS</p>\n\t\t\t<ul>\n\t\t\t\t<li>Mentors</li>\n\t\t\t\t<li>Educators</li>\n\t\t\t\t<li>Group activity facilitators</li>\n\t\t\t\t<li>Meal preparers/providers</li>\n\t\t\t\t<li>Tutors</li>\n\t\t\t\t<li>Life skills trainers</li>\n\t\t\t\t<li>Beauticians</li>\n\t\t\t\t<li>Street Outreach Workers</li>\n\t\t\t\t<li>Artists for classes</li>\n\t\t\t\t<li>Yard work</li>\n\t\t\t\t<li>Interior painters</li>\n\t\t\t</ul>\n\t\t\t<p class=\"needs_subheader\">REPAIR NEEDS</p>\n\t\t\t<ul>\n\t\t\t\t<li>Concrete or pavers 1500 sq.feet</li>\n\t\t\t\t<li>Cement sidewalk repair& labor</li>\n\t\t\t</ul>\n\t\t</div>\n\t</div>\n</div>"
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
