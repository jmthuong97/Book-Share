<%@ Page Title="" Language="C#" MasterPageFile="~/masterForm/BoxForm.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="booksahre.RegisterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form2" runat="server">
        <input type="text" name="fullname" required="required" placeholder="Name" autocomplete="off" />
        <input type="text" name="username" required="required" placeholder="Username" autocomplete="off" />
        <input type="email" name="email" required="required" placeholder="Email" autocomplete="off" />
        <input type="date" name="birthOfDate" required="required" />
        <input id="pass" type="password" name="password" required="required" placeholder="Password" />
        <input id="re-pass" type="password" name="re-pass" required="required" placeholder="Re-password" onkeyup='check()' />
        <span id='message'></span>
        <asp:Label ID="errorTxt" CssClass="error-message" runat="server" Text=""></asp:Label>
        <asp:Button ID="submit" runat="server" Text="Register" OnClick="submit_Click" />
    </form>
    <p class="message">Already registered? <a href="Login.aspx">Sign In</a></p>
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
