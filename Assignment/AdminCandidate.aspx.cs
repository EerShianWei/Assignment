using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment
{
    public partial class AdminCandidate : System.Web.UI.Page
    {
        private readonly String str = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Refresh();
            }
        }

        private void Refresh()
        {
            SqlConnection conn = new SqlConnection(str);
            string sql = "SELECT EmployeeID, LastName + ' ' + FirstName AS EmpName, Title FROM Employees";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            ViewState["Paging"] = dt;
            GridCandidate.DataSource = dt;
            GridCandidate.DataBind();

            conn.Close();
        }

        protected void Candidate_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            GridCandidate.PageIndex = e.NewPageIndex;
            GridCandidate.DataSource = ViewState["Paging"];
            Refresh();
        }

        protected SortDirection CurrentSortDirecion
        {
            get
            {
                if(ViewState["sortDirection"] == null)
                {
                    ViewState["sortDirection"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["sortDirection"];
            }
            set
            {
                ViewState["sortDirection"] = value;
            }
        }

        protected void Candidate_Sorting(object sender, GridViewSortEventArgs e)
        {
/*            DataTable dt = (DataTable)ViewState["dirState"];
            if(dt.Rows.Count > 0)
            {
                if(Convert.ToString(ViewState["sortdr"]) == "Asc")
                {
                    dt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdr"] = "Desc";
                }
                else
                {
                    dt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdr"] = "Asc";
                }
                GridCandidate.DataSource = dt;
                GridCandidate.DataBind();
            }*/
            if(CurrentSortDirecion == SortDirection.Ascending)
            {
                CurrentSortDirecion = SortDirection.Descending;
                SortGridView(e.SortExpression, " Desc");
            }
            else
            {
                CurrentSortDirecion = SortDirection.Descending;
                SortGridView(e.SortExpression, " Asc");
            }
        }

        private void SortGridView(string sort, string direction)
        {
            dynamic dt = ViewState["Paging"];
            DataTable dtsort = dt;
            DataView dv = new DataView(dtsort);
            dv.Sort = sort + direction;

            GridCandidate.DataSource = dv;
            GridCandidate.DataBind();
        }
    }
}