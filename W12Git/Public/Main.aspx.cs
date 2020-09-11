using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using W12Git.Classes;
using W12Git.Models;

namespace W12Git.Public
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try { 

            List <Repositorios>  repos= new GitAPIBusiness().procuraReps(txtPesquisar.Text);

            rptRepositorios.DataSource = repos;
            rptRepositorios.DataBind();

            }
            catch(Exception err)
            {
                Response.Redirect("Error.aspx?erro=" + err.Message.ToString());
            }

}




    }
}