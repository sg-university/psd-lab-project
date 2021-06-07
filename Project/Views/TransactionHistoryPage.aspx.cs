using Project.Controllers;
using Project.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views
{
    public partial class TransactionHistoryPage : System.Web.UI.Page
    {
        ReportController ReportController = new ReportController();
        protected void Page_Load(object sender, EventArgs e)
        {
            MemberTransactionReport memberReport = new MemberTransactionReport();
            reportViewer.ReportSource = memberReport;
            memberReport.SetDataSource(ReportController.createDataSet());

        }
    }
}