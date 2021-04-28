using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace CRUD_OPERATION
{
    public partial class Contacts : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-HQJJ4HJ;Initial Catalog=ASPCRUD;Persist Security Info=True;User ID=admins;Password=admins");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Btn_Delete.Enabled = false;
                FillGridView();
            }
        }

        protected void Btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            hfcontactID.Value = "";
            txtName.Text = txtMobile.Text = txtAddress.Text = "";
            LblSuccessMessage.Text = LblErrorMessage.Text = "";
            Btn_Save.Text = "Save";
            Btn_Delete.Enabled = false;

        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }

            SqlCommand sqlcmd = new SqlCommand("ContactCreateOrUpdate", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@ContactID", (hfcontactID.Value == "" ? 0 : Convert.ToInt32(hfcontactID.Value)));
            sqlcmd.Parameters.AddWithValue("@Names", txtName.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Addresss", txtAddress.Text.Trim());
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            string ContactID = hfcontactID.Value;
            Clear();
            if (ContactID == "")
                LblSuccessMessage.Text = "save SuccessFully";
            else
                LblSuccessMessage.Text = "Updated  SuccessFully";
            FillGridView();
        }

        void FillGridView()
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();

                SqlDataAdapter sqlda = new SqlDataAdapter("ContactViewAll", sqlcon);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                sqlcon.Close();
                gvContact.DataSource = dtbl;
                gvContact.DataBind();


            }

        }
        protected void lnk_OnClick(object sender, EventArgs e)
        {
            int ContactID = Convert.ToInt32((sender as LinkButton).CommandArgument);

                 if (sqlcon.State == ConnectionState.Closed)

                sqlcon.Open();

            SqlDataAdapter sqlda = new SqlDataAdapter("ContactViewByID", sqlcon);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@ContactID", ContactID);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlcon.Close();

            hfcontactID.Value = ContactID.ToString();
            txtName.Text = dtbl.Rows[0]["Names"].ToString();
            txtMobile.Text = dtbl.Rows[0]["Mobile"].ToString();
            txtAddress.Text = dtbl.Rows[0]["Addresss"].ToString();
            Btn_Save.Text = "Update";
            Btn_Delete.Enabled = true;

        }

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)

                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("ContactDeleteByID",sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@ContactID",Convert.ToInt32(hfcontactID.Value));
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            Clear();
            FillGridView();
            LblSuccessMessage.Text = "Deleted Successfully";
            
        }
    }
}