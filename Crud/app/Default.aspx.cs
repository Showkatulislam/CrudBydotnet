using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Xml.Linq;

namespace app
{
    public partial class _Default : Page
    {

        SqlConnection con;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString()); ;
            con = new SqlConnection("Data Source=DESKTOP-QQ4HSET\\SQLEXPRESS01;Initial Catalog=my;Integrated Security=True");

            if (!IsPostBack)
            {
                getDepartment();
                salary.Focus();

            }

        }

        //load department data
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
        }


        //Insert Employee action
        protected void btn_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex > 0)
            {
                cmd = new SqlCommand($"Insert Into Employee Values('{name.Text}', '{DropDownList1.SelectedValue}','{DropDownList2.SelectedValue}', {salary.Text},'{start_date.Text}')", con);

                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    Response.Redirect("/employees");
                }
                else
                {
                    Response.Write("<script>alert(' inserting record into the table.')</script>");
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