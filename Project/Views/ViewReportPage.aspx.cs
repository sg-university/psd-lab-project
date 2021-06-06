using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Report;
using Project.Controllers;
using Project.Dataset;

namespace Project.Views
{
    public partial class ViewReportPage : System.Web.UI.Page
    {

        ReportController reportController = new ReportController();
        protected void Page_Load(object sender, EventArgs e)
        {
            MemberTransactionReport memberReport = new MemberTransactionReport();
            reportViewer.ReportSource = memberReport;
            memberReport.SetDataSource(reportController.createDataSet());

        }
    }
}