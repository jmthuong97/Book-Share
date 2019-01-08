﻿<%@ Page Title="" Language="C#" MasterPageFile="~/masterForm/MainForm.Master" AutoEventWireup="true" CodeBehind="UploadBook.aspx.cs" Inherits="booksahre.UploadBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" media="screen" href="css/uploadbook.css" />
    <script src="http://code.jquery.com/jquery-latest.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title-upload">
        <i class="fas fa-plus-square"><b>Upload Book</b></i>
    </div>
    <form id="uploadBook" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="upload-image">
            <asp:HiddenField ID="isExist" runat="server" Value="False"/>
            <p>Upload images (Book cover) here:</p>
            <br />
            Cover 1:
                    <asp:FileUpload ID="cover1" runat="server" accept="image/png, image/jpeg" required="" /><br />
            Cover 2:
                    <asp:FileUpload ID="cover2" runat="server" accept="image/png, image/jpeg" /><br />
            Cover 3:
                    <asp:FileUpload ID="cover3" runat="server" accept="image/png, image/jpeg" /><br />
            Cover 4:
                    <asp:FileUpload ID="cover4" runat="server" accept="image/png, image/jpeg" /><br />
            Cover 5:
                    <asp:FileUpload ID="cover5" runat="server" accept="image/png, image/jpeg" />
        </div>
        <div class="info-book">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="elements">
                        <div class="title"><i class="fas fa-barcode"></i>ISBN</div>
                        <div class="input">
                            <asp:TextBox ID="isbn" runat="server" OnTextChanged="isbn_TextChanged" AutoPostBack="true" Width="90%" autocomplete="off" placeholder="ISBN"></asp:TextBox>
                            <input id="idBookTxt" type="hidden" runat="server" />
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>
                                    <img src="img/loader.gif" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>
                    <div class="elements">
                        <div class="title"><i class="fas fa-file-signature"></i>Title</div>
                        <div class="input">
                            <input id="title" type="text" placeholder="Title Book" required="" runat="server" />
                        </div>
                    </div>
                    <div class="elements">
                        <div class="title"><i class="fas fa-user-tie"></i>Author</div>
                        <div class="input">
                            <input id="author" type="text" placeholder="Author Book" required="" runat="server" />
                        </div>
                    </div>
                    <div class="elements">
                        <div class="title"><i class="fas fa-tags"></i>Tag</div>
                        <div class="input">
                            <input id="tag" type="text" placeholder="Tag Book" required="" runat="server" />
                        </div>
                    </div>
                    <div class="elements">
                        <div class="title"><i class="fas fa-language"></i>Language</div>
                        <div class="input">
                            <input id="language" type="text" placeholder="Language Book" required="" runat="server" />
                        </div>
                    </div>
                    <div class="elements">
                        <div class="title"><i class="fas fa-pen"></i>Description</div>
                        <div class="input">
                            <textarea id="description" required="required" style="border: none;" runat="server"></textarea>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="title-upload">
            <i class="fas fa-info"><b>Information of lender</b></i>
        </div>
        <div class="info-book">
            <div class="elements">
                <div class="title"><i class="fas fa-envelope"></i>Email</div>
                <div class="input">
                    <input type="text" id="email" placeholder="Email" value="" readonly="readonly" runat="server" />
                </div>
            </div>
            <div class="elements">
                <div class="title"><i class="fas fa-address-card"></i>Address</div>
                <div class="input">
                    <input type="text" id="address" placeholder="Address" value="" readonly="readonly" runat="server" />
                </div>
            </div>
            <div class="elements">
                <div class="title"><i class="fas fa-phone-square"></i>Phone number</div>
                <div class="input">
                    <input type="text" id="phonenumber" placeholder="Phone Number" value="" readonly="readonly" runat="server" />
                </div>
            </div>
            <div class="elements">
                <div class="title"><i class="fab fa-facebook"></i>Link facebook</div>
                <div class="input">
                    <input type="text" id="linkFacebook" placeholder="Link Facebook" value="" readonly="readonly" runat="server" />
                </div>
            </div>
            <div class="elements" style="border: none;">
                <div class="title"><i class="fas fa-gavel"></i>Rules</div>
                <div class="input">
                    <textarea rows="6" cols="50" name="rules" readonly="readonly"></textarea><br />
                    <div class="check-rules">
                        <asp:CheckBox ID="checkRules" runat="server" required="" />I have read, and agree to abide by the bookshare.com website rules.
                    </div>
                </div>
            </div>
        </div>
        <div class="uploadBtn">
            <asp:Button ID="uploadBtn" runat="server" Text="Upload" disabled="" OnClick="uploadBtn_Click" />
        </div>
    </form>
    <script>
        document.getElementById("ctl00_ContentPlaceHolder1_checkRules").addEventListener("change", function () {
            document.getElementById("ctl00_ContentPlaceHolder1_uploadBtn").disabled = !this.checked;
            var check = $("#ctl00_ContentPlaceHolder1_title").is('[disabled=disabled]');
            if (check == true) $(".upload-image input").attr('disabled', 'disabled');
            else $(".upload-image input").attr('disabled', false);
        });
    </script>
</asp:Content>
