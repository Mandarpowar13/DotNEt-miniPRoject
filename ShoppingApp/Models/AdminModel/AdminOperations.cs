

using System;
using System.Data.SqlClient;


namespace ShoppingApp.Models.AdminModel
{
    public class AdminOperations
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShopingWebsite;Integrated Security=True");


        public int addnewAdmin(AdminPoco admin) {
            int c = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = " insert into admin values(@ad_id, @ad_name, @ad_password);";

                cmd.CommandType = System.Data.CommandType.Text;


                SqlParameter p1 = new SqlParameter("@ad_id", System.Data.SqlDbType.VarChar, 20);
                p1.Value = admin.ad_id;
                cmd.Parameters.Add(p1);

                SqlParameter p2 = new SqlParameter("@ad_name", System.Data.SqlDbType.VarChar, 30);
                p2.Value = admin.ad_name;
                cmd.Parameters.Add(p2);

                SqlParameter p3 = new SqlParameter("@ad_password", System.Data.SqlDbType.VarChar, 30);
                p3.Value = admin.ad_password;
                cmd.Parameters.Add(p3);



                con.Open();
                c = cmd.ExecuteNonQuery();
            }
            catch(Exception ex) {
                c = -1;
            }
            finally { con.Close(); }




            return c;
        } 
    }
}
