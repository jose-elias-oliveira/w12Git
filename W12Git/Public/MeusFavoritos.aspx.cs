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
    public partial class MeusFavoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<Repositorios> favoritos = new GitAPIBusiness().getFavoritos();
                rptFavoritos.DataSource = favoritos;
                rptFavoritos.DataBind();

            }
        }



    }
}