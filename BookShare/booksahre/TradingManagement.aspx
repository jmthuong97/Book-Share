<%@ Page Title="" Language="C#" MasterPageFile="~/masterForm/MainForm.Master" AutoEventWireup="true" CodeBehind="TradingManagement.aspx.cs" Inherits="booksahre.TradingManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/TableData.css" />
    <script src="http://code.jquery.com/jquery-latest.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <input id="currentTab" type="hidden" value="Lending" runat="server" />
                <div class="trading">
                    <ul>
                        <li>
                            <asp:Button ID="lendingBtn" runat="server" Text="Lending" OnClick="lendingBtn_Click" CssClass="select-items" />
                        </li>
                        <li>
                            <asp:Button ID="borrowingBtn" runat="server" Text="Borrowing" OnClick="borrowingBtn_Click" />
                        </li>
                    </ul>
                </div>
                <h3 id="title-trading">Manage user's lending</h3>
                <asp:DropDownList ID="listStatus" runat="server" OnSelectedIndexChanged="listStatus_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <table id="people-table">
                    <thead>
                        <tr>
                            <th>No</th>
                            <th>Title</th>
                            <th>Create Date</th>
                            <th>User borrow</th>
                            <th>Status</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <% if (tradings.Count == 0)
                            { %>
                        <td colspan="6" style="text-align: center">No data</td>
                        <%} %>
                        <% for (int i = 0; i < tradings.Count; i++)
                            { %>
                        <tr>
                            <td><%= i+1 %></td>
                            <td><%= tradings[i].title %></td>
                            <td><%= tradings[i].createDate %></td>
                            <td>
                                <% if (tradings[i].username.Equals("N/A"))
                                    { %>
                                    N/A
                                <%}
                                    else
                                    { %>
                                <a href="Profile.aspx?id=<%= tradings[i].userID %>"><%=tradings[i].username %></a>
                                <%} %>
                            </td>
                            <td><%= getNameStatus(tradings[i].status) %></td>
                            <td id="action">
                                <% if (tradings[i].status == 0 && currentTab.Value.Equals("Lending"))
                                    { %>
                                <input type="button" class="redBtn" value="Delete" data-idtrading="<%=tradings[i].id %>" />
                                <%}
                                    else if (tradings[i].status == 1 && currentTab.Value.Equals("Lending"))
                                    {%>
                                <input type="button" class="greenBtn" style="margin-bottom: 3px;" value="Accept" data-idtrading="<%=tradings[i].id %>" />
                                <input type="button" class="redBtn" value="Reject" data-idtrading="<%=tradings[i].id %>" />
                                <%}
                                    else if (tradings[i].status == 2 && currentTab.Value.Equals("Lending"))
                                    { %>
                                <input type="button" class="greenBtn" value="Complete" data-idtrading="<%=tradings[i].id %>" />
                                <%}
                                    else
                                    { %>
                                N/A
                                <%} %>
                            </td>
                        </tr>
                        <%} %>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script>
        $(document).on('click', '#action input', function () {
            event.preventDefault(); // set form do not reload when submit
            console.log($(this).attr("data-idtrading"));
            doAction($(this).val(), $(this).attr("data-idtrading"));
        });

        function doAction(method, idTrading) {
            $.ajax({
                url: "http://localhost:40621/TradingService.asmx/doActionTrading",
                contentType: 'application/json',
                data: {
                    method: JSON.stringify(method),
                    idTrading: idTrading
                },
                method: 'get',
                success: function (data) {
                    console.log(data.d);
                    <% loadData("Available"); %>
                },
                error: function () {
                    alert('error');
                }
            });
        }
    </script>
</asp:Content>
