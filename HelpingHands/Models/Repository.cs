using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace HelpingHands.Models
{
    public class Repository
    {
        string k = ConfigurationManager.ConnectionStrings["km"].ToString();
        public int Add(Users obj)
        {
            SqlConnection con=new SqlConnection(k);
            SqlCommand cmd = new SqlCommand("proc_add", con);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Uid",obj.Uid);
            cmd.Parameters.AddWithValue("@Uname", obj.UserName);
            cmd.Parameters.AddWithValue("@Pwd", obj.Password);
            cmd.Parameters.AddWithValue("@Cpwd", obj.ConfirmPassword);
            cmd.Parameters.AddWithValue("@Gender", obj.Gender);
            cmd.Parameters.AddWithValue("@Languages", obj.Languages);
            cmd.Parameters.AddWithValue("@State", obj.State);
            cmd.Parameters.AddWithValue("@City", obj.City);
            cmd.Parameters.AddWithValue("@BGroup", obj.BloodGroup);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            con.Open();
            int i=cmd.ExecuteNonQuery();
            return i;
             
        }
        public List<Users> Get()
        {
            SqlConnection con = new SqlConnection(k);
            SqlCommand cmd = new SqlCommand("select * from Users",con);
            List<Users> obj = new List<Users>();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                obj.Add(new Users
                {
                    Uid = Convert.ToInt32(dr["Uid"]),
                    UserName=Convert.ToString(dr["UserName"]),
                    Password=Convert.ToString(dr["Password"]),
                    ConfirmPassword=Convert.ToString(dr["ConfirmPassword"]),
                    Gender = Convert.ToString(dr["Gender"]),
                    Languages = Convert.ToString(dr["Languages"]),
                    State = Convert.ToString(dr["State"]),
                    City = Convert.ToString(dr["City"]),
                    BloodGroup = Convert.ToString(dr["BGroup"]),
                    Phone = Convert.ToInt64(dr["Phone"]),
                    Email = Convert.ToString(dr["Email"])
                });
            }
            return obj;
        }
        public int Update(Users obj)
        {
            SqlConnection con = new SqlConnection(k);
            SqlCommand cmd = new SqlCommand("proc_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Uid", obj.Uid);
            cmd.Parameters.AddWithValue("@Uname", obj.UserName);
            cmd.Parameters.AddWithValue("@Pwd", obj.Password);
            cmd.Parameters.AddWithValue("@Cpwd", obj.ConfirmPassword);
            cmd.Parameters.AddWithValue("@Gender", obj.Gender);
            cmd.Parameters.AddWithValue("@Languages", obj.Languages);
            cmd.Parameters.AddWithValue("@State", obj.State);
            cmd.Parameters.AddWithValue("@City", obj.City);
            cmd.Parameters.AddWithValue("@BGroup", obj.BloodGroup);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            return i;
        }

        public bool LoginCheck(login obj)
        {
            SqlConnection con = new SqlConnection(k);
            bool s= false;
            SqlCommand cmd = new SqlCommand("Select count(*) from Users where Email='"+obj.Email+"' and Password='"+obj.Password+"'", con);
            con.Open();
            s=Convert.ToBoolean(cmd.ExecuteScalar());
            con.Close();
            return s;
        }
        public int Delete(int Uid)
        {
            SqlConnection con = new SqlConnection(k);
            SqlCommand cmd = new SqlCommand("Delete from Users where Uid='"+Uid+"'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            return i;
        }
        
    }
}