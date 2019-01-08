using booksahre.TradingService;
using booksahre.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace booksahre
{
    public partial class TradingManagement : System.Web.UI.Page
    {
        public List<TradingDetail> tradings;

        protected void Page_Load(object sender, EventArgs e)
        {
            // set title for page
            Page.Title = "Trading management - BookShare";

            if (Session["username"] == null) Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                changeTab("Lending");
            }
        }

        public void loadData(string status)
        {
            TradingService.TradingService tradingservice = new TradingService.TradingService();
            UserService.User user = (UserService.User)Session["currentUser"];

            if (currentTab.Value.Equals("Lending"))
            {
                tradings = tradingservice.getListLend(status, user.id).ToList();
            }
            else
            {
                tradings = tradingservice.getListBorrow(status, user.id).ToList();
            }
        }

        public void changeTab(string nameTab)
        {
            List<ListItem> items = new List<ListItem>();
            if (nameTab.Equals("Lending"))
            {
                items.Add(new ListItem("Available", "Available"));
                items.Add(new ListItem("Pending", "Pending"));
                items.Add(new ListItem("Lending", "Lending"));
                items.Add(new ListItem("Complete", "Complete"));
                listStatus.Items.Clear();
                listStatus.Items.AddRange(items.ToArray());
                currentTab.Value = "Lending";
                loadData("Available");
            }
            else
            {
                items.Add(new ListItem("Pending", "Pending"));
                items.Add(new ListItem("Borrowing", "Borrowing"));
                items.Add(new ListItem("Complete", "Complete"));
                listStatus.Items.Clear();
                listStatus.Items.AddRange(items.ToArray());
                currentTab.Value = "Borrowing";
                loadData("Pending");
            }
        }

        public string getNameStatus(int status)
        {
            if (currentTab.Value.Equals("Lending"))
            {
                switch (status)
                {
                    case 0:
                        return "Borrowing";
                    case 1:
                        return "Confirming";
                    case 2:
                        return "Books borrowed";
                    case 3:
                        return "Finished";
                }
            }
            else
            {
                switch (status)
                {
                    case 1:
                        return "Pending";
                    case 2:
                        return "Borrowing";
                    case 3:
                        return "Finished";
                }
            }
            return "N/A";
        }

        protected void listStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = listStatus.SelectedItem.Value;
            loadData(status);
            //Label1.Text = tradings[0].title;
        }

        protected void lendingBtn_Click(object sender, EventArgs e)
        {

            changeTab("Lending");
            lendingBtn.CssClass = "select-items";
            borrowingBtn.CssClass = "";
        }

        protected void borrowingBtn_Click(object sender, EventArgs e)
        {
            changeTab("Borrowing");
            borrowingBtn.CssClass = "select-items";
            lendingBtn.CssClass = "";
        }
    }
}