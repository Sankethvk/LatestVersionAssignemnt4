using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace EventManagementDataLayer
{
    public class eventmngmtdatalayer
    {
        EventManagementEntities eventmanagemententities = new EventManagementEntities();
        UsersTable userobj = new UsersTable();
        BookingStatu statusobj = new BookingStatu();
        public string InsertUser(UsersTable usersdata)
        {
            eventmanagemententities.UsersTables.Add(usersdata);
            eventmanagemententities.SaveChanges();
            return "User inerted";
        }
        public string InsertEvent(EventsTable eventdata)
        {
            eventmanagemententities.EventsTables.Add(eventdata);
            eventmanagemententities.SaveChanges();
            return "booking successfull";
        }
        public string InsertFlowers(FlowerOrder flowerdata)
        {
            eventmanagemententities.FlowerOrders.Add(flowerdata);
            eventmanagemententities.SaveChanges();
            return "flower order inserted";
        }
        public string InsertFood(FoodOrder fooddata)
        {
            eventmanagemententities.FoodOrders.Add(fooddata);
            eventmanagemententities.SaveChanges();
            return "food order inserted";
        }
        public DataTable getBookingstatus()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source = LAPTOP-TG0AKH7V\SQLEXPRESS; Initial Catalog = EventManagement; Integrated Security = True");
            SqlCommand sqlCommand = new SqlCommand("select booking_id,book_date,status from BookingStatus,EventsTable", sqlConnection);
            sqlConnection.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            sqlConnection.Close();
            return dt;


            
        }
        public string ValidationUserLogin(string ui_email, string ui_password)
        {
            
            SqlConnection sqlConnection = new SqlConnection(@"Data Source = LAPTOP-TG0AKH7V\SQLEXPRESS; Initial Catalog = EventManagement; Integrated Security = True");
            SqlCommand sqlCommand = new SqlCommand("select * from UsersTable where email = '" + ui_email+"' and password ='" + ui_password +"'" , sqlConnection);
            sqlConnection.Open();
            SqlDataReader sdr = sqlCommand.ExecuteReader();
            
            if (sdr.Read())
            {
                sqlConnection.Close();
                return "Success";
            }
            else
            {
                sqlConnection.Close();
                return "Fail";

            }
            
            
        }
        public string ConfirmBooking(int user_id,int event_id)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source = LAPTOP-TG0AKH7V\SQLEXPRESS; Initial Catalog = EventManagement; Integrated Security = True");
            SqlCommand sqlCommand = new SqlCommand("select COUNT(*) from FoodOrder where user_id=" + user_id+ "and event_id=" + event_id, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sdr = sqlCommand.ExecuteReader();
           
            DataTable dt = new DataTable();
            
            dt.Load(sdr);
            sqlConnection.Close();
            SqlCommand sqlCommand1 = new SqlCommand("select COUNT(*) from FlowerOrder where user_id=" + user_id + "and event_id=" + event_id, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sdr1 = sqlCommand.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(sdr1);
            sqlConnection.Close();
            int foodcount = Convert.ToInt32(dt.Rows[0][0]);
            int flowercount = Convert.ToInt32(dt1.Rows[0][0]);

            if(foodcount == 1 && flowercount == 1)
            {
                return "False";
            }
            else if(foodcount == 0 && flowercount == 0)
            {
                statusobj.food_request = true;
                statusobj.food_request = true;
                statusobj.status = "Pending";

            }
            else if(foodcount == 1 && flowercount == 0)
            {
                statusobj.food_request = false;
                statusobj.flower_request = true;
                statusobj.status = "Pending";

            }
            else
            {
                statusobj.food_request = true;
                statusobj.flower_request = false;
                statusobj.status = "Pending";

            }
            statusobj.user_id = user_id;
            eventmanagemententities.BookingStatus.Add(statusobj);
            eventmanagemententities.SaveChanges();
            return "True";




        }
    }
}
