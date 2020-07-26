using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigDiz_WCF_Service
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            var valuePath = Path.Text;
            var valueAngle = 0;
            try
            {
                valueAngle = int.Parse(Angle.Text);
            }
            catch (Exception)
            {
                Result.Text = "Incorrect value in Angle";
                return;
            }
            var client = new WCF_Service();
            Result.Text = client.RotateAllPhotoInFolder(valuePath, valueAngle);
        }
    }
}