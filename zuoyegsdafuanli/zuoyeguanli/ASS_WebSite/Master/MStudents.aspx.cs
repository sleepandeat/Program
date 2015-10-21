using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_MStudents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataBind();
        UpdatePanel1.Update();
        DetailsView1.DataBind();

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "0")
        {
            return;
        }
        GridView1.DataBind();
        UpdatePanel1.Update();
    }


    protected void btn_OK_Click(object sender, EventArgs e)
    {

    }
    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        GridView1.DataBind();
        UpdatePanel1.Update();
    }
    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        GridView1.DataBind();
        UpdatePanel1.Update();
    }
    protected void DetailsView1_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
    {
        GridView1.DataBind();
        UpdatePanel1.Update();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (GridView1.SelectedRow != null)
        {
            DetailsView1.PageIndex = GridView1.SelectedRow.DataItemIndex;
            DetailsView1.DataBind();
            udpdv1.Update();
        }
    }
}
