using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AssDAL;

public partial class Master_MTeachers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (GridView1.SelectedRow != null)
        {
            DetailsView1.PageIndex = GridView1.SelectedRow.DataItemIndex;
            DetailsView1.DataBind();
        }
    }
}
