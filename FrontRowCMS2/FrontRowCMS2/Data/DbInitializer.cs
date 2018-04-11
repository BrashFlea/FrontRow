using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontRowCMS2.Models;
using FrontRowCMS2.Models.Home;
using FrontRowCMS2.Models.Secondary;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FrontRowCMS2.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            //TODO: REMOVE BEFORE PRODUCTION
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
            var user = new ApplicationUser
            {
                Email = "admin@test.com",
                UserName = "admin@test.com"
            };

            userManager.CreateAsync(user, "Test123$");

            context.SaveChangesAsync();

            #endregion

            #region Home Page Initialization
            //Home Page

            context.Header.Add(new Header { BackgroundImage = "home_header.png", PhoneNumber = "(801) 528-1214", TitleText = "14 WARM BEDS. YOUTH 12-17. YOUR TEMPORARY HOME <span class=\"quicksand - dark - 38 - lightgreen\">:) </span>" });
            context.SaveChanges();

            context.Services.Add(new FrontRowCMS2.Models.Home.Services {
                MainText = "Our programming is divided into three main areas. Each program area has specific components to meet the needs of the youth in need.",
                Service1 = new LinkSubContent { Title = "Overnight Shelter", Description = "Located in the heart of downtown Ogden, Utah, Youth Futures provides emergency shelter, temporary residence and supportive services for runaway, homeless, unaccompanied and at-risk youth ages 12-17.  The shelter is open 24 hours per day.", Image = "house_icon.png", Link = "/secondary#historyBanner" },
                Service2 = new LinkSubContent { Title = "Drop In Services", Description = "Available to any youth ages 12-18. Drop-in services allow for the youth to access food, clothing, hygiene items, laundry facilities, computer stations, and case management. Drop-in hours are 6:30 am to 8:00 pm every day of the week.", Image = "door_icon.png", Link = "/secondary#dropinsMain" },
                Service3 = new LinkSubContent { Title = "Street Outreach", Description = "Youth Futures’ Street Outreach is conducted once per week and provides outreach and crisis services to youth in Ogden City, Utah. ", Image = "van_icon.png", Link = "/secondary#outreachBanner" }
            });
            context.SaveChanges();


            context.Purpose.Add(new Purpose { BackgroundImage = "purpose.png", TextArea1 = "To provide unaccompanied, runaway and homeless youth with a safe and nurturing environment where they can develop the needed skills to become active, healthy, successful members of our future world.",
                TextArea2 = "<p><span class=\"alt-color\">7,085</span> MEALS SERVED. <span class=\"alt-color\">511</span> DROP-IN SERVICES.</p><p><span class=\"alt-color\">245</span> STREET OUTREACH HOURS. <span class=\"alt-color\">64</span> SHELTERED YOUTH.</p>", PartnerImage1 = "mckaydee_hospital.png", PartnerImage2 = "the_group_logo.png", PartnerImage3 = "giv_development.png" });
            context.SaveChanges();

            context.BottomHomePage.Add(new BottomHomePage {
                Service1 = new LinkSubContent { Title = "Apply To Volunteer", Description = "Make your mark where it matters. Vestibulum rutrum quam vitae fringilla tincidunt. Suspendisse.", Image = "hand_icon.png", Link = "/secondary#donateMain" },
                Service2 = new LinkSubContent { Title = "Youth Stories", Description = "Vestibulum rutrum quam vitae fringilla tincidunt. Suspendisse nec tortor urna.", Image = "girl_icon.png", Link = "#" },
                Service3 = new LinkSubContent { Title = "Events", Description = "Vestibulum rutrum quam vitae fringilla tincidunt. Suspendisse nec tortor urna.", Image = "calendar_icon.png", Link = "/secondary#calendarMain" }

            });

            #endregion

            #region Secondary Page Initialization
            //SECONDARY PAGE HEADER
            context.SecondaryHeader.Add(new SecondaryHeader
            {
                TitleText = "Have questions? Send us a text!",
                PhoneNumber = "(801) 528-1214",
                BackgroundImage = "history_header.jpg",
                ImageText1 = "Youth Futures",
                ImageText2 = "History"
            });
            context.SaveChanges();

            ///HISTORY SECTION
            context.History.Add(new History { TextArea1 = "Located in the heart of downtown Ogden, Youth Futures opened Utah's first homeless Residential Support Temporary Youth Shelter on February 20, 2015. Youth Futures provides shelter and drop-in services to all youth ages 12-17, and will not exclude any youth who falls within these age ranges, regardless of circumstance. We provide 14 temporary overnight shelter beds and day-time drop-in services to youth, as well as intensive case management to help youth become re-united with family or self-sufficiently contributing to our community. Weekly outreach efforts assist in building rapport with street youth, ensuring they receive food and other basic necessities and educating them about options to living in unsafe conditions. Youth are guided in a loving, supportive and productive way, encouraging their own personal path for a healthy future.",
                TextArea2 = "Youth Futures was founded by Kristen Mitchell and Scott Catuccio, who had been conceptually planning to provide shelter and case management services to youth for over six years. It was identified that there was a lack of shelter services for the estimated 5,000 youth who experience homelessness for at least one night a year in Utah, so Scott and Kristen began researching other states that provide shelter services to youth. It was quickly identified that the largest barrier to providing services to homeless youth in Utah was a law prohibiting the opening of shelter facilities for youth.",
                Image1 = "history_kristen_scott.jpg", Image2 = "history_shelter.jpg", Image3 = "history_kristen.jpg",
                Caption1 = "Kristen and Scott", Caption2 = "The shelter home", Caption3 = "Kristen"
            });
            context.SaveChanges();

            //OPERATION
            context.Operation.Add(new Operation
            {
                TextArea1 = "During the 2014 Legislative Session, HB132 was passed, which allowed for rewriting the prohibitive law and drafting licensing procedures for residential support programs for temporary homeless youth shelter in Utah. Youth Futures and other homeless youth service providers participated in the rules writing process. The licensing rules enrolled on October 22, 2014, and the founders began to set-up the facility for licensing. Youth Futures received the first license for homeless youth shelter granted in the State of Utah under the new law. ",
                TextArea2 = "During the first full year of operations (February 20, 2015-March 31, 2016), our Residential Support Temporary Youth Shelter has:",
                Operation1 = new TextSubContent { Image = "history_meal.svg", Description = "Served 7,085 meals; 3 meals a day and 2 snacks for shelter and drop-in youth. Opened the resource room 354 times with access to basic nec-essities including clothing, hygiene items, back packs, blankets, sleeping bags, basic medical supplies, etc.", ContentType = "Operation" },
                Operation2 = new TextSubContent { Image = "history_hand.svg", Description = "Conducted more than 245 street outreach hours and provided items from the resource room to street youth.", ContentType = "Operation" },
                Operation3 = new TextSubContent { Image = "house_icon2.png", Description = "Provided 1,535 shelter night stays and 511 drop in services including case management, connections to health care, mental health care and group therapy, facilitation with other youth service providers, computer access, showers, laundry facilities, etc.", ContentType = "Operation" }
            });
            context.SaveChanges();

            //OUTREACH
            context.Outreach.Add(new Outreach
            {
                Image = "outreach_header.jpg",
                TextArea = "<div class=\"container-fluid\">\n\t <div class=\"row outreach_text\">\n\t\t<section class=\"col-xs-12\">\n\t\t\t<p class=\"mont_regular_22_darkgray\">Street Outreach is designed to meet the clients where they are on the street to build rapport and encourage youth to access drop-in and shelter services.This program offers, case management, hygiene items, food, sleeping bags, and other essential items as needed.Street Outreach currently take place once per week on Wednesdays.The team visits the same Ogden, Utah locations every week:</p>\n\t\t</section>\n\t</div>\n</div>\n\n<div class=\"container-fluid\">\n\t<div class=\"row outreach_bullet\">\n\t\t<ul class=\"row\">\n\t\t\t<li class=\"col-md-6\">Jefferson Park</li>\n\t\t\t<li class=\"col-md-6\">Marchall White Center Park</li>\n\t\t\t<li class=\"col-md-6\">Lorin Farr Skate Park</li>\n\t\t\t<li class=\"col-md-6\">Basketball Court at Bonneville Park</li>\n\t\t\t<li class=\"col-md-6\">Under the Ogden River Bridge(sporadic)</li>\n\t\t\t<li class=\"col-md-6\">Lantern House Homeless Shelter</li>\n\t\t</ul>\n\t</div>\n</div>"
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

            //MEDIA
            context.MediaEvent.Add(new MediaEvent
            {
                Title = "America First Provides an 'Assist' to Homeless Shelter",
                Time = "03/18/2015 10:03 pm",
                Image = "media_check.jpg",
                Image_Title = "America First Check",
                Caption = "At right, from left to right: Kristen Mitchell, executive director of Youth Futures Utah and Scott Tuccio, president of the Board of Directorsof Youth Futures Utah, stand with Nicole Cypers, public relations and social media manager for America First Credit Union, at the Weber State basketball game for a check presentation in the amount of $3,400 on Saturday, March 7 at Weber State University.",
                Description1 = "OGDEN, Utah--America First Credit Union awarded Youth Futures Utah, a homeless shelter for youth, with $3,400 during the Weber State University basketball game. America First paid the organization $10 for each assist the Weber State University basketball team completed throughout the 2014 – 2015 season. With 340 assists, the donation amounted to $3,400 in total for the newly-opened youth homeless organization, located in Ogden, Utah.",
                Description2 = "Youth Futures Utah is a 501(c)3 organization committed to the well-being of the youth of Utah. The mission of Youth Futures Utah is to provide shelter, support, resources and guidance to homeless, unaccompanied and runaway youth in Utah. Youth Futures connects each youth with food, housing and resources to build the skills needed to support a healthy future."
            });
            context.SaveChanges();

            //DONOR
            var donor = new Donor[]
            {
                //PLATINUM
                new Donor{Level=DonorType.Platinum, Name="MILLER FAMILY FOUNDATION LARRY H. & GAIL", Year="2015 & 2016"},
                new Donor{Level=DonorType.Platinum, Name="IVY LANE PEDIATRICS", Year="2016"},
                new Donor{Level=DonorType.Platinum, Name="SORENSON LEGACY FOUNDATION", Year="2015"},
                new Donor{Level=DonorType.Platinum, Name="MILLER FAMILY FOUNDATION LARRY H. & GAIL", Year="2015 & 2016"},
                new Donor{Level=DonorType.Platinum, Name="IVY LANE PEDIATRICS", Year="2016"},
                new Donor{Level=DonorType.Platinum, Name="SORENSON LEGACY FOUNDATION", Year="2015"},

                //GOLD
                new Donor{Level=DonorType.Gold, Name="MILLER FAMILY FOUNDATION LARRY H. & GAIL", Year="2015 & 2016"},
                new Donor{Level=DonorType.Gold, Name="IVY LANE PEDIATRICS", Year="2016"},
                new Donor{Level=DonorType.Gold, Name="SORENSON LEGACY FOUNDATION", Year="2015"},
                new Donor{Level=DonorType.Gold, Name="MILLER FAMILY FOUNDATION LARRY H. & GAIL", Year="2015 & 2016"},
                new Donor{Level=DonorType.Gold, Name="IVY LANE PEDIATRICS", Year="2016"},
                new Donor{Level=DonorType.Gold, Name="SORENSON LEGACY FOUNDATION", Year="2015"},

                //SILVER
                new Donor{Level=DonorType.Silver, Name="MILLER FAMILY FOUNDATION LARRY H. & GAIL", Year="2015 & 2016"},
                new Donor{Level=DonorType.Silver, Name="IVY LANE PEDIATRICS", Year="2016"},
                new Donor{Level=DonorType.Silver, Name="SORENSON LEGACY FOUNDATION", Year="2015"},
                new Donor{Level=DonorType.Silver, Name="MILLER FAMILY FOUNDATION LARRY H. & GAIL", Year="2015 & 2016"},
                new Donor{Level=DonorType.Silver, Name="IVY LANE PEDIATRICS", Year="2016"},
                new Donor{Level=DonorType.Silver, Name="SORENSON LEGACY FOUNDATION", Year="2015"},

                //BRONZE
                new Donor{Level=DonorType.Bronze, Name="MILLER FAMILY FOUNDATION LARRY H. & GAIL", Year="2015 & 2016"},
                new Donor{Level=DonorType.Bronze, Name="IVY LANE PEDIATRICS", Year="2016"},
                new Donor{Level=DonorType.Bronze, Name="SORENSON LEGACY FOUNDATION", Year="2015"},
                new Donor{Level=DonorType.Bronze, Name="MILLER FAMILY FOUNDATION LARRY H. & GAIL", Year="2015 & 2016"},
                new Donor{Level=DonorType.Bronze, Name="IVY LANE PEDIATRICS", Year="2016"},
                new Donor{Level=DonorType.Bronze, Name="SORENSON LEGACY FOUNDATION", Year="2015"}
            };
            foreach (Donor d in donor)
            {
                context.Donor.Add(d);
            }
            context.SaveChanges();

            //DONATE
            context.Donate.Add(new Donate
            {
                TextArea1 = "HOW CAN YOU HELP?",
                TextArea2 = "	Your generosity helps keep the doors open and the lights on, providing a sanctuary for those in need. Please consider a donation. ",
                Donate1 = new TextSubContent { Image = "donate_dollar.svg", Description = "Monetary donations are our biggest need right now. Recurring PayPal donations can be scheduled from our website, even $10 makes a difference.", ContentType = "Donate" },
                Donate2 = new TextSubContent { Image = "shoppingcart_icon.png", Description = "Donate through rewards programs: Amazon Smile, Smiths Community Rewards, or United Way, Federal and State Employee contributions, LoveUTGiveUT", ContentType = "Donate" },
                Donate3 = new TextSubContent { Image = "donate_hand.svg", Description = "Donate your time as a volunteer to help with needs around the shelter! Sign up here.", ContentType = "Donate" }
            });
            context.SaveChanges();

            //LIST OF NEEDS
            context.Needs.Add(new Needs { TextArea = "<div class=\"container-fluid needs\">\n\t <div class=\"row donate_help\">\n\t\t<div class=\"col-xs-12\">\n\t\t\t<p>LIST OF NEEDS</p>\n\t\t</div>\n\t</div>\n\n\t<div class=\"row\">\n\t\t<div class=\"col-xs-12 col-md-4 needs_list\">\n\t\t\t<p class=\"needs_subheader\">\n\t\t\t\tMOST IMPORTANT NEEDS\n\t\t\t\t(In order of priority)\n\t\t\t</p>\n\t\t\t<ul>\n\t\t\t\t<li>Cash donations</li>\n\t\t\t\t<li>Printer Paper</li>\n\t\t\t\t<li>Canned meat & Jerky</li>\n\t\t\t\t<li>Scotch tape</li>\n\t\t\t\t<li>Bus tokens or passes</li>\n\t\t\t\t<li>Earbud Headphones</li>\n\t\t\t\t<li>Cinch bags</li>\n\t\t\t\t<li>Batteries</li>\n\t\t\t\t<li>Sweat Pants</li>\n\t\t\t\t<li>Pajama Bottoms</li>\n\t\t\t\t<li>Sports bras</li>\n\t\t\t\t<li>Trail mix individuals</li>\n\t\t\t\t<li>Toilet Paper</li>\n\t\t\t\t<li>Condoms</li>\n\t\t\t\t<li>Tampons</li>\n\t\t\t\t<li>Carabiners</li>\n\t\t\t\t<li>Paper plates and cups</li>\n\t\t\t\t<li>Men's and Women's Underwear</li>\n\t\t\t\t<li>Socks</li>\n\t\t\t\t<li>Kleenex individuals</li>\n\t\t\t\t<li>Undershirts, S M L XL</li>\n\t\t\t\t<li>Garbage bags 30 Gallon</li>\n\t\t\t\t<li>Garbage sacks small bathroom</li>\n\t\t\t\t<li>Lip balm</li>\n\t\t\t\t<li>Ziploc bags, quart and gallon</li>\n\t\t\t\t<li>Energy Bars</li>\n\t\t\t\t<li>Heavy duty plastic storage bins that won\'t melt if heated in shed</li>\n\t\t\t</ul>\n\t\t</div>\n\n\t\t<div class=\"col-xs-12 col-md-4 needs_list\">\n\t\t\t<p class=\"needs_subheader\">MISC.NEEDS</p>\n\t\t\t<ul>\n\t\t\t\t<li>Minivan</li>\n\t\t\t\t<li>NEW Printer</li>\n\t\t\t</ul>\n\t\t\t<p class=\"needs_subheader\">GIFT CARDS FOR</p>\n\t\t\t<ul>\n\t\t\t\t<li>Walmart</li>\n\t\t\t\t<li>Fun things to do</li>\n\t\t\t\t<li>Grocery store</li>\n\t\t\t\t<li>Maverick</li>\n\t\t\t\t<li>Restaurants</li>\n\t\t\t\t<li>Movies</li>\n\t\t\t\t<li>Bus passes or tokens</li>\n\t\t\t\t<li>Phone minutes </li>\n\t\t\t\t<li>Beauty salons/haircuts</li>\n\t\t\t\t<li>For shoe stores</li>\n\t\t\t\t<li>Lagoon passes</li>\n\t\t\t</ul>\n\t\t</div>\n\n\t\t<div class=\"col-xs-12 col-md-4 needs_list\">\n\t\t\t<p class=\"needs_subheader\">HOUSEHOLD FURNISHINGS NEEDS</p>\n\t\t\t<ul>\n\t\t\t\t<li>NEW pots and pans</li>\n\t\t\t\t<li>New Couches</li>\n\t\t\t</ul>\n\t\t\t<p class=\"needs_subheader\">VOLUNTEERS</p>\n\t\t\t<ul>\n\t\t\t\t<li>Mentors</li>\n\t\t\t\t<li>Educators</li>\n\t\t\t\t<li>Group activity facilitators</li>\n\t\t\t\t<li>Meal preparers/providers</li>\n\t\t\t\t<li>Tutors</li>\n\t\t\t\t<li>Life skills trainers</li>\n\t\t\t\t<li>Beauticians</li>\n\t\t\t\t<li>Street Outreach Workers</li>\n\t\t\t\t<li>Artists for classes</li>\n\t\t\t\t<li>Yard work</li>\n\t\t\t\t<li>Interior painters</li>\n\t\t\t</ul>\n\t\t\t<p class=\"needs_subheader\">REPAIR NEEDS</p>\n\t\t\t<ul>\n\t\t\t\t<li>Concrete or pavers 1500 sq.feet</li>\n\t\t\t\t<li>Cement sidewalk repair& labor</li>\n\t\t\t</ul>\n\t\t</div>\n\t</div>\n</div>"
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
