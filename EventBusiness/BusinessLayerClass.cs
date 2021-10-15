using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManagementDataLayer;
using System.Data;

namespace EventBusiness
{
    public class BusinessLayerClass
    {
        eventmngmtdatalayer datalayerobj = new eventmngmtdatalayer();

        public string InsertUser(UsersTable usersdata)
        {
            string msg = datalayerobj.InsertUser(usersdata);
            return msg;
        }
        public string InsertEvents(EventsTable eventdata)
        {
            string msg = datalayerobj.InsertEvent(eventdata);
            return msg;
        }
        public string InsertFlowers(FlowerOrder flowerdata)
        {
            string msg = datalayerobj.InsertFlowers(flowerdata);
            return msg;
        }
        public string InsertFood(FoodOrder fooddata)
        {
            string msg = datalayerobj.InsertFood(fooddata);
            return msg;
        }
        public DataTable getBookingstatus()
        {
            return datalayerobj.getBookingstatus();
        }
        public string ValidationUserLogin(string email,string password)
        {

            return datalayerobj.ValidationUserLogin(email,password);
        }
        public string ConfirmBooking(int user_id, int event_id)
        {
            return datalayerobj.ConfirmBooking(user_id, event_id);
        }

    }
}
