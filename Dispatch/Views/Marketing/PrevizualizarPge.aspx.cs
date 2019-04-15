using Dispatch.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dispatch.Views.Marketing {
    public partial class PrevizualizarPge : Page {

        public String Texto;
        protected void Page_Load(object sender, EventArgs e) {
            //Carregar item adicionado na sessão
            Texto = Convert.ToString(Session["Texto"]);
            LoadPage();
        }

        public void LoadPage() {
            MessageCtrl Message = new MessageCtrl();
            MessagePge messagePge = new MessagePge();

            Literal.Text = Texto;
        }
    }
}