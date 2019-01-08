<%@ Page Title="" Language="C#" MasterPageFile="~/masterForm/BoxForm.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="booksahre.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <input id="old-pass" type="password" name="oldPassword" required="required" placeholder="Old Password" />
        <input id="pass" type="password" name="password" required="required" placeholder="Password" />
        <input id="re-pass" type="password" name="re-pass" required="required" placeholder="Re-password" onkeyup='check()' />
        <span id='message'></span>
        <asp:Label ID="errorTxt" CssClass="error-message" runat="server" Text=""></asp:Label>
        <asp:Button ID="changeBtn" runat="server" Text="Change Password" OnClick="changeBtn_Click"/>
    </form>
    <script>
        function check() {
            if (document.getElementById('pass').value === document.getElementById('re-pass').value) {
                document.getElementById('message').style.color = 'green';
                document.getElementById('message').innerHTML = 'Confirm password correct.';
            } else {
                document.getElementById('message').style.color = 'red';
                document.getElementById('message').innerHTML = 'These passwords do not match. Retry?';
            }
        }
    </script>
</asp:Content>
