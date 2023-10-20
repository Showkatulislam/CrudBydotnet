using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace app
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        int id;
   
        protected void Page_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString()); ;

            con = new SqlConnection("Data Source=DESKTOP-QQ4HSET\\SQLEXPRESS01;Initial Catalog=my;Integrated Security=True");
            string strid = HttpContext.Current.Request.QueryString["id"] ?? "5";

            id = Int32.Parse(strid);
            if (!IsPostBack)
            {
                getDepartment();
                setData();
                salary.Focus();

            }
        }



        private void getDepartment()
        {

            string sqlc = "select department_id,department_name from Department order by department_id";
            cmd = new SqlCommand(sqlc, con);

            if (con.State == ConnectionState.Closed)
                con.Open();


            SqlDataReader rdr = cmd.ExecuteReader();
            DropDownList1.DataSource = rdr;
            DropDownList1.DataTextField = "department_name";
            DropDownList1.DataValueField = "department_id";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "Select DepartMent");
            rdr.Close();
            con.Close();
        }




        private void setData()
        {
            string sqlc = "SELECT employee_name,salary,start_data FROM Employee WHERE employee_id =" + id;
            cmd = new SqlCommand(sqlc, con);


            if (con.State == ConnectionState.Closed)
                con.Open();


            cmd = new SqlCommand(sqlc, con);

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlDataReader rdr = cmd.ExecuteReader();


            if (rdr.Read())
            {
                // Display data in your form controls
                name.Text = rdr["employee_name"].ToString();
                salary.Text = rdr["salary"].ToString();
                start_date.Text = rdr["start_data"].ToString();

            }
            rdr.Close();
            con.Close();

        }




        protected void btn_update_click(object sender, EventArgs e)
        {

            if (DropDownList1.SelectedIndex > 0)
            {
                cmd = new SqlCommand($"Update Employee Set employee_name='{name.Text}', department_id='{DropDownList1.SelectedValue}',position='{DropDownList2.SelectedValue}', salary={salary.Text} Where employee_id = {id}", con);

                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    Response.Redirect("/employees");
                }
                else
                {
                    Response.Write("<script>alert('Not inserting record into the table.')</script>");
                }
                con.Close();
            }
            else
            {
                Response.Write("<script>alert('Please choose a department to insert.')</script>");
            }


        }
    }
}