using System;

namespace Assignment
{
    class Program
    {
        static EventCoordinator eCoord;


        //add code check valid name
        public static bool checkValidName(string userInput)
        {
            bool checkValid = false;
            char[] checkName = userInput.ToCharArray();

            for (int i = 0; i < checkName.Length; i++)
            {
                if (char.IsLetter(checkName[0])) // check prevent userInput just a space
                {
                    if (char.IsLetter(checkName[i]) || checkName[i] == ' ')
                    {
                        checkValid = true;
                    }
                }

            }
            return checkValid;
        }

        //add code check valid phone number
        public static bool checkValidFone(string userInput)
        {
            bool checkValid = false;
            char[] checkFone = userInput.ToCharArray();

            for (int i = 0; i < checkFone.Length; i++)
            {
                if (char.IsDigit(checkFone[i]))
                {
                    checkValid = true;
                }

            }
            return checkValid;
        }

        // add code check valid Date
        
        public static bool checkValidDay(int day)
        {
            if (day < 1 || day > 31) { return false; }
            return true;
        }

        public static bool checkValidMonth(int day, int month)
        {
            if (month < 1 || month > 12) { return false; }
            else
            {
                if (month % 2 == 0 && day == 31) { return false; }

            }
            return true;
        }

        public static bool checkValidYear(int year)
        {
            if (year < 2021 || year > 2025) { return false; }
            return true;
        }

        public static bool checkValidHour(int hour)
        {
            if (hour < 0 || hour > 23) { return false; }
            return true;
        }

        public static bool checkValidMinute(int min)
        {
            if (min < 0 || min > 59) { return false; }
            return true;
        }


        //
        public static void deleteCustomer()
        {
            int id;
            Console.Clear();
            Console.WriteLine(eCoord.customerList());
            Console.Write("Please enter a customer id to delete:");
            id = getIntChoice();
            if (eCoord.deleteCustomer(id))
            {
                eCoord.deleteRegCustomer(id);
                Console.WriteLine("Customer with id {0} deleted..", id);
                Console.WriteLine("Evens were booking by customer with id {0} deleted too..", id);
            }
            else
            {
                Console.WriteLine("Customer with id {0} was not found..", id);
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }


        public static void viewCustomers()
        {
            Console.Clear();
            Console.WriteLine(eCoord.customerList());
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        public static void viewSpecificCustomer()
        {
            int id;
            string cust;
            Console.Clear();
            Console.WriteLine(eCoord.customerList());
            Console.Write("Please enter a customer id to View:");
            id = getIntChoice();
            Console.Clear();
            cust = eCoord.getCustomerInfoById(id);
            Console.WriteLine(cust);
            Console.WriteLine("\nPress any key to continue return to the previous menu.");
            Console.ReadKey();
        }

        public static void addCustomer()
        {
            string fname, lname, phone;

            Console.Clear();
            Console.WriteLine("-----------Add Customer----------");
            Console.Write("Please enter the customer's first name:");
            fname = Console.ReadLine();
            while (checkValidName(fname) == false)
            {
                Console.Write("Please enter a valid first name:");
                fname = Console.ReadLine();
            }
            Console.Write("Please enter the customer's last name:");
            lname = Console.ReadLine();
            while (checkValidName(lname) == false)
            {
                Console.Write("Please enter a valid last name:");
                lname = Console.ReadLine();
            }
            Console.Write("Please enter the customer's phone:");
            phone = Console.ReadLine();
            while (checkValidFone(phone) == false || phone.Length != 10)
            {
                Console.Write("Please enter a valid phone (10 digits):");
                phone = Console.ReadLine();
            }
            if (eCoord.addCustomer(fname, lname, phone))
            {
                Console.WriteLine("Customer successfully added..");
            }
            else
            {
                Console.WriteLine("Customer was not added..");
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }


        public static void addEvent()
        {
            string eventName, venue;
            Date eventDate;
            int maxAttendees;
            int day, month, year, hour, minute;

            Console.Clear();
            Console.WriteLine("-----------Add Event----------");
            Console.Write("Please enter the name of the Event:");
            eventName = Console.ReadLine();
            while (checkValidName(eventName) == false)
            {
                Console.Write("Please enter a valid event name:");
                eventName = Console.ReadLine();
            }
            Console.Write("Please enter venue for the event:");
            venue = Console.ReadLine();
            while (checkValidName(venue) == false)
            {
                Console.Write("Please enter a valid venue:");
                venue = Console.ReadLine();
            }
            Console.Write("Please enter the Day of the event:");
            day = getIntChoice();
            Console.Write("Please enter the Month of the event (as an integer):");
            month = getIntChoice();
            while (checkValidDay (day) == false)
            {
                Console.Write("Please enter the valid Day of the event:");
                day = getIntChoice();
            }
            while(checkValidMonth(day, month) == false)
                {
                Console.Write("Please enter the valid Month of the event:");
                month = getIntChoice();
            }
            Console.Write("Please enter the Year of the event (2021 - 2025): ");
            year = getIntChoice();
            while (checkValidYear(year) == false)
            {
                Console.Write("Please enter the valid  year of the event (2021 - 2025):");
                year = getIntChoice();
            }
            Console.Write("Please enter the Hour the event starts in 24 hour format:");
            hour = getIntChoice();
            while (checkValidHour(hour) == false)
            {
                Console.Write("Please enter the valid  hour of the event:");
                hour = getIntChoice();
            }
            Console.Write("Please enter the Minute the event starts:");
            minute = getIntChoice();
            while (checkValidMinute(minute) == false)
            {
                Console.Write("Please enter the valid  minute of the event:");
                minute = getIntChoice();
            }

            eventDate = new Date(day, month, year, hour, minute);
            Console.Write("Please enter the maximum number of attendees:");
            maxAttendees = getIntChoice();
            while (maxAttendees <= 0)
            {
                Console.Write("the maximum number of attendees must larger than 0:");
                maxAttendees = getIntChoice();
            }
            if (eCoord.addEvent(eventName, venue, eventDate, maxAttendees))
            {
                Console.WriteLine("Event successfully added..");
            }
            else
            {
                Console.WriteLine("The event was not added..");
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }


        public static void viewEvents()
        {
            Console.Clear();
            Console.WriteLine(eCoord.eventList());
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        public static void viewSpecificEvent()
        {
            int id;
            string ev;
            Console.Clear();
            Console.WriteLine(eCoord.eventList());
            Console.Write("Please enter an event id to View:");
            id = getIntChoice();
            Console.Clear();
            ev = eCoord.getEventInfoById(id);
            Console.WriteLine(ev);
            Console.WriteLine("\nPress any key to continue return to the previous menu.");
            Console.ReadKey();
        }

        //add code for adding register (RSVP)
        public static void addRegister()
        {
            int customerId, eventId;
            Console.Clear();
            Console.WriteLine(eCoord.customerList());
            Console.WriteLine(eCoord.eventList());
            Console.WriteLine("-----------Add Register----------");
            Console.Write("Please enter customer ID from Customer List: ");
            customerId = getIntChoice();
            Console.Write("Please enter event ID from Even List: ");
            eventId = getIntChoice();
            
            if (eCoord.addRegister(customerId, eventId)) // add register
            {
                Console.WriteLine("Register successfully added..");
                eCoord.addAttendee(customerId, eventId); // add attendee
                Console.WriteLine("Attendee successfully added..");
            }
            else
            {
                Console.WriteLine("Customer was not added..");
                Console.WriteLine("Please check customer ID, event ID or available place again...");

            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        //add code for viewing register (RSVP)
        public static void viewRegisters()
        {
            int id;
            string ev;
            Console.Clear();
            Console.WriteLine(eCoord.registerList());
            Console.Write("Please enter an register id to View:");
            id = getIntChoice();
            Console.Clear();
            ev = eCoord.getRegisterInfoById(id);
            Console.WriteLine(ev);
            Console.WriteLine("\nPress any key to continue return to the previous menu.");
            Console.ReadKey();
        }

        
        public static string customerMenu()
        {
            string s = "Andrew's Event Management Limited.\n";
            s += "Customer Menu.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Add Customer \n";
            s += "2: View Customers \n";
            s += "3: View Customer Details \n";
            s += "4: Delete Customer\n";
            s += "5: Return to the main menu.";
            return s;
        }

        public static string eventMenu()
        {
            string s = "Andrew's Event Management Limited.\n";
            s += "Event Menu.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Add Event \n";
            s += "2: View all Events \n";
            s += "3: View Event Details \n";
            s += "4: Return to the main menu.";
            return s;
        }

        public static string registrationMenu()
        {
            string s = "Andrew's Event Management Limited.\n";
            s += "Event Registration Menu.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: RSVP for event \n";
            s += "2: View RSVPs \n";
            s += "3: Return to the main menu.";
            return s;
        }

        public static string mainMenu()
        {
            string s = "Andrew's Event Management Limited.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Customer Options \n";
            s += "2: Event Options \n";
            s += "3: RSVP for Event \n";
            s += "4: Exit";
            return s;
        }


        public static void runCustomerMenu()
        {
            string menu = customerMenu();
            int choice = getValidChoice(5, menu);
            while (choice != 5)
            {
                if (choice == 1) { addCustomer(); }
                if (choice == 2) { viewCustomers(); }
                if (choice == 3) { viewSpecificCustomer(); }
                if (choice == 4) { deleteCustomer(); }
                choice = getValidChoice(5, menu);
            }
        }

        public static void runEventMenu()
        {
            string menu = eventMenu();
            int choice = getValidChoice(4, menu);
            while (choice != 4)
            {
                if (choice == 1) { addEvent(); }
                if (choice == 2) { viewEvents(); }
                if (choice == 3) { viewSpecificEvent(); }

                choice = getValidChoice(4, menu);
            }
        }

        public static void runRegistrationMenu()
        {
            string menu = registrationMenu();
            int choice = getValidChoice(3, menu);
            while (choice != 3)
            {
                if (choice == 1) { addRegister(); } //add method addRegister()
                if (choice == 2) { viewRegisters(); } // add method viewRegisters()

                choice = getValidChoice(3, menu);
            }
        }


        public static int getValidChoice(int max, string menu)
        {
            int choice;
            Console.Clear();
            Console.WriteLine(menu);
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > max))
            {
                Console.Clear();
                Console.WriteLine(menu);
                Console.WriteLine("Please enter a valid choice:");
            }
            return choice;
        }

        public static int getIntChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter an integer:");
            }
            return choice;
        }


        public static void runProgram()
        {
            string menu = mainMenu();
            int choice = getValidChoice(4, menu);
            while (choice != 4)
            {
                if (choice == 1) { runCustomerMenu(); }
                if (choice == 2) { runEventMenu(); }
                if (choice == 3) { runRegistrationMenu(); }

                choice = getValidChoice(4, menu);
            }
        }

        static void Main(string[] args)
        {
            Console.Clear();
            eCoord = new EventCoordinator(200, 1000, 101, 5000, 100, 10000); // add data for RSVPManager
            runProgram();
            Console.WriteLine("Thank you for using Andrew's Event Management Limited System. ");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

    }

}

