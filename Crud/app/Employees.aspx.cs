using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace app
{
    public partial class Employees : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-QQ4HSET\\SQLEXPRESS01;Initial Catalog=my;Integrated Security=True");
            if (!IsPostBack)
            {
                dataLoad();
                getDepartment();
            }

        }


        //load Data action
        private void dataLoad(string data = "")
        {
            string sqlc;
            sqlc = "SELECT Employee.employee_id, Employee.employee_name,Department.department_name,Employee.position,Employee.salary,Employee.start_data FROM Department INNER JOIN Employee  ON Employee.department_id = Department.department_id";
            if (data != "")
            {
                sqlc = $"SELECT Employee.employee_id, Employee.employee_name,Department.department_name,Employee.position,Employee.salary,Employee.start_data FROM Department INNER JOIN Employee  ON Employee.department_id = Department.department_id WHERE Department.department_name='{data}' order by Employee.start_data";
            }
            cmd = new SqlCommand(sqlc, con);

            if (con.State == ConnectionState.Closed)
                con.Open();


            SqlDataReader rdr = cmd.ExecuteReader();
            gridData.DataSource = rdr;
            gridData.DataBind();
            con.Close();
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



        //edit action 
        protected void btn_click_edit(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            int recordID = Convert.ToInt32(deleteButton.CommandArgument);
            Response.Redirect("/EditEmployee?id=" + recordID);
        }


        //delete action 
        protected void btn_click_delete(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            int recordID = Convert.ToInt32(deleteButton.CommandArgument);

            string sqlc = "DELETE FROM Employee WHERE employee_id = @RecordID";
            cmd = new SqlCommand(sqlc, con);


            if (con.State == ConnectionState.Closed)
                con.Open();

            cmd.Parameters.AddWithValue("@RecordID", recordID);
            cmd.ExecuteNonQuery();

            dataLoad();

            con.Close();

        }


        //search by department
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            dataLoad(DropDownList1.SelectedItem.Text);

        }
    }
}