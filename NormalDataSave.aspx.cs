using Dependency.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dependency
{
    public partial class NormalDataSave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strType = ConfigurationManager.AppSettings["DBType"];
                EmployeeBLL objBL = new EmployeeBLL();
                dg.DataSource = objBL.GetAll(strType);

                dg.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            System.Data.DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Name"); dt.Columns.Add("Marks");
            DataRow _ravi = dt.NewRow();
            _ravi["Name"] = "ravi"; _ravi["Marks"] = "500";
            dt.Rows.Add(_ravi);
            string strType = ConfigurationManager.AppSettings["DBType"];
            EmployeeBLL objBL = new EmployeeBLL();
            dg.DataSource = objBL.SaveOrUpdate(strType,dt);

            dg.DataBind();

        }
    }
}