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
            //context.User.Add(new User { Username = "admin", Password = "", Email = "admin@yfut.org" });

            #endregion

            #region Home Page Initialization
            //Home Page

            context.Header.Add(new Header { BackgroundImage = "home_header.png", PhoneNumber = "(801) 528-1214", TitleText = "14 WARM BEDS. YOUTH 12-17. YOUR TEMPORARY HOME <span class=\"quicksand - dark - 38 - lightgreen\">:) </span>" });
            context.SaveChanges();

            context.Services.Add(new FrontRowCMS2.Models.Home.Services {
                MainText = "Our programming is divided into three main areas. Each program area has specific components to meet the needs of the youth in need.",
                Service1 = new LinkSubContent { Title = "Overnight Shelter", Description = "Located in the heart of downtown Ogden, Utah, Youth Futures provides emergency shelter, temporary residence and supportive services for runaway, homeless, unaccompanied and at-risk youth ages 12-17.  The shelter is open 24 hours per day.", Image = "house_icon.png", Link = "/secondary#sheltersMain" },
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
                TextArea2 = "During the first full year of operations (February 20, 2015-March 31, 2016), our Residential Support Temporary Youth Shelter has:"
            });
            var OperationSubContent = new TextSubContent[]
            {
                new TextSubContent{Image="history_meal.svg", Description="Served 7,085 meals; 3 meals a day and 2 snacks for shelter and drop-in youth. Opened the resource room 354 times with access to basic nec-essities including clothing, hygiene items, back packs, blankets, sleeping bags, basic medical supplies, etc.", ContentType="Operation"},
                new TextSubContent{Image="history_hand.svg", Description="Conducted more than 245 street outreach hours and provided items from the resource room to street youth.", ContentType="Operation"},
                new TextSubContent{Image="house_icon2.png", Description="Provided 1,535 shelter night stays and 511 drop in services including case management, connections to health care, mental health care and group therapy, facilitation with other youth service providers, computer access, showers, laundry facilities, etc.", ContentType="Operation"}
            };
            foreach (TextSubContent t in OperationSubContent)
            {
                context.TextSubContent.Add(t);
            }
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

            //MEDIA
            context.MediaEvents.Add(new MediaEvent
            {
                Title = "America First Provides an 'Assist' to Homeless Shelter",
                Time = "03/18/2015 10:03 pm",
                Image = "media_check.jpg",
                Caption = "Youth Futures",
                Description = "Yahoo"
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
                TextArea2 = "Your generosity helps keep the doors open and the lights on, providing a sanctuary for those in need. Please consider a donation."
            });
            var DonateSubContent = new TextSubContent[]
            {
                new TextSubContent{Image="donate_dollar.svg", Description="Monetary donations are our biggest need right now. Recurring PayPal donations can be scheduled from our website, even $10 makes a difference.", ContentType="Donate"},
                new TextSubContent{Image="shoppingcart_icon.png", Description="Donate through rewards programs: Amazon Smile, Smiths Community Rewards, or United Way, Federal and State Employee contributions, LoveUTGiveUT", ContentType="Donate"},
                new TextSubContent{Image="donate_hand.svg", Description="Donate your time as a volunteer to help with needs around the shelter! Sign up here.", ContentType="Donate"}
            };
            foreach (TextSubContent t in DonateSubContent)
            {
                context.TextSubContent.Add(t);
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
