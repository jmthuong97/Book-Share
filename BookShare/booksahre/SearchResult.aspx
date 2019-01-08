<%@ Page Title="" Language="C#" MasterPageFile="~/masterForm/MainForm.Master" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="booksahre.SearchResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Result for "<%= Request.QueryString["query"] %>":</h3>
    <div class="search-nav">
        <span>Find by: </span>
        <ul class="type-list">
            <% foreach (string type in listQuery)
                { %>
            <li>
                <% if (filter == type)
                    { %>
                <a class="seleted-type" href="<%= string.Format("SearchResult.aspx?query={0}&filter={1}",Request.QueryString["query"], type)%>"><%= type %></a>
                <%}
                    else
                    { %>
                <a class="unseleted-type" href="<%= string.Format("SearchResult.aspx?query={0}&filter={1}",Request.QueryString["query"], type)%>"><%= type %></a>
                <%} %>
            </li>
            <%} %>
        </ul>
    </div>
    <section class="section-center">
        <% for (int j = 0; j < books.Count; j++)
            { %>
        <div class="book-item">
            <a href="BookDetails.aspx?id=<%= books[j].id %>">
                <div class="img">
                    <img src="<%= Request.ApplicationPath + books[j].getImage %>" />
                </div>
                <div class="book-content">
                    <h2><%= books[j].title %></h2>
                    <pre><%= books[j].author %></pre>
                    <p><%= books[j].description %></p>
                </div>
            </a>
        </div>
        <%} %>
        <% if (books.Count == 0)
            { %>
        <div class="not-found-book">
            Book not found
        </div>
        <%} %>
    </section>
    <div class="page">
        <% if (totalPage > 1)
            { %>
        <%for (int i = 1; i < totalPage; i++)
            { %>
        <% if (page == i)
            { %>
        <span class="selected-page"><%= i %></span>
        <%}
            else
            { %>
        <a class="next-page" href="<%= string.Format("SearchResult.aspx?query={0}&filter={1}&page={2}", Request.QueryString["query"], filter , i) %>"><%= i %></a>
        <%} %>
        <%} %>
        <%} %>
    </div>
</asp:Content>
