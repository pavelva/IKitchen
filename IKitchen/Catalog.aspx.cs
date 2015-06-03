using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKitchen
{
    public partial class Catalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string sqlCatalog = "select product_id, product_model, product_price, product_install_price, product_desc, product_company, app_name, appType_name, company_name " +
                                "from ((products Join applience on product_type = app_id) Join applience_types on product_type2 = appType_id) Join companys on product_company = company_id " +
                                " where company_id = '2' order by company_name";

            CatalogDataSource.SelectCommand = sqlCatalog;
            CatalogDataSource.DataBind();
        }
    }
}