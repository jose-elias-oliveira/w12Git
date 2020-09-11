using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace W12Git.Classes
{
    public class Message
    {

        public static void MensagemRedirect(string mensagem, string redirect)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;

            if ((!page.ClientScript.IsClientScriptBlockRegistered("alert")))
            {
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", $"<script type='text/javascript'> alert('{mensagem}'); window.location.href='{redirect}' </script>");
            }

        }
    }
}