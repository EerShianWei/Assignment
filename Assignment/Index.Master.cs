using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment
{
    public partial class Index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TreeView1_TreeNodeDataBound(object sender, TreeNodeEventArgs e)
        {
            SiteMapNode node = (SiteMapNode)e.Node.DataItem;
            if(node["imageUrl"] != null)
            {
                e.Node.ImageUrl = System.IO.Path.Combine("~/assets/", node["imageUrl"]);
            }
        }
    }
}