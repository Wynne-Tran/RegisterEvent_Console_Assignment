using System;
namespace Assignment
{
    public class RSVP
    {
        private string registerDate;
        private int registerId;
        private int customerId;
        private string customerFname;
        private string customerLname;
        private int eventId;


        public RSVP(int regId, int cusId, string fname, string lname, int eveId)
        {
            registerDate = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
            registerId = regId;
            customerId = cusId;
            customerFname = fname;
            customerLname = lname;
            eventId = eveId;

        }

        public int getregId() { return registerId; }
        public int getcusId() { return customerId; }
        public int geteveId() { return eventId; }
        
        


        public override string ToString()
        {
            string s = "-----------Register Infomation----------";
            s = s + "\nRegister Day: " + registerDate;
            s = s + "\nRegister Number: " + registerId;
            s = s + "\nRegister Name: " + customerFname + " " + customerLname;
            s = s + "\nEven ID: " + eventId;
            return s;
        }
    }
}
