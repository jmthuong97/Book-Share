<%@ Page Title="" Language="C#" MasterPageFile="~/masterForm/MainForm.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="booksahre.BookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" media="screen" href="css/uploadbook.css" />
    <script src="http://code.jquery.com/jquery-latest.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="book-title">
        <h2><%=book.title %></h2>
    </div>
    <div class="rate-book">
        <div class="rate">
            <select id="rate">
                <option value="1">1 Star</option>
                <option value="2">2 Star</option>
                <option value="3">3 Star</option>
                <option value="4">4 Star</option>
                <option value="5">5 Star</option>
            </select>
            <div id="star">
                <span class="fa fa-star checked"></span>
                <span class="fa fa-star checked"></span>
                <span class="fa fa-star checked"></span>
                <span class="fa fa-star"></span>
                <span class="fa fa-star"></span>
            </div>
        </div>
    </div>
    <div class="title-upload" style="background: #F9F7F4;">
        <i class="fas fa-info"><b>List of lenders</b></i>
        <div style="clear: both;">
        </div>
        <div class="slides-container">
            <% for (int i = 0; i < tradings.Count; i++)
                { %>
            <div class="info-book">
                <div class="elements">
                    <div class="title trading"><i class="fas fa-user"></i>Name</div>
                    <div class="input-trading">
                        <a href="Profile.aspx?id=<%= tradings[i].getUser.id%>">
                            <input type="text" value="<%= tradings[i].getUser.fullName %>" readonly="" /></a>
                    </div>
                    <div class="borrow-book">
                        <input type="button" value="Borrow" data-idtrading="<%= tradings[i].id %>" />
                    </div>
                </div>
                <div class="elements">
                    <div class="title"><i class="fas fa-envelope"></i>Email</div>
                    <div class="input">
                        <input type="email" name="email" value="<%= tradings[i].getUser.email %>" readonly="" />
                    </div>
                </div>
                <div class="elements">
                    <div class="title"><i class="fas fa-address-card"></i>Address</div>
                    <div class="input">
                        <input type="text" value="<%= tradings[i].getUser.address %>" readonly="" />
                    </div>
                </div>
                <div class="elements">
                    <div class="title"><i class="fas fa-phone-square"></i>Phone number</div>
                    <div class="input">
                        <input type="text" value="<%= tradings[i].getUser.phoneNumber %>" readonly="" />
                    </div>
                </div>
                <div class="elements">
                    <div class="title"><i class="fab fa-facebook"></i>Facebook</div>
                    <div class="input">
                        <input type="text" value="<%= tradings[i].getUser.linkFacebook %>" readonly="" />
                    </div>
                </div>
                <div class="elements">
                    <div class="title"><i class="fa fa-calendar"></i>Upload date</div>
                    <div class="input">
                        <input type="text" value="<%= tradings[i].createDate %>" readonly="" />
                    </div>
                </div>
            </div>
            <%} %>
        </div>
        <div class="indicator">
            <button id="prev" onclick="plusSlides(-1)">&#10094; Prev</button>
            <button id="next" onclick="plusSlides(1)">Next &#10095;</button>
        </div>
    </div>
    <div class="cover-book">
        <% for (int c = 0; c < covers.Count; c++)
            { %>
        <img src="<%= rootPath + covers[c] %>" />
        <%} %>
    </div>
    <div class="info-book">
        <div class="scrollhere"></div>
        <div class="elements">
            <div class="title"><i class="fas fa-barcode"></i>ISBN</div>
            <div class="input">
                <input type="number" value="<%=book.ISBN %>" readonly="readonly" />
            </div>
        </div>
        <div class="elements">
            <div class="title"><i class="fas fa-file-signature"></i>Title</div>
            <div class="input">
                <input id="title" type="text" value="<%=book.title %>" readonly="readonly" />
            </div>
        </div>
        <div class="elements">
            <div class="title"><i class="fas fa-user-tie"></i>Author</div>
            <div class="input">
                <input id="author" type="text" value="<%=book.author %>" readonly="readonly" />
            </div>
        </div>
        <div class="elements">
            <div class="title"><i class="fas fa-tags"></i>Tag</div>
            <div class="input">
                <input id="tag" type="text" value="<%=book.tag %>" readonly="readonly" />
            </div>
        </div>
        <div class="elements">
            <div class="title"><i class="fas fa-language"></i>Language</div>
            <div class="input">
                <input id="language" type="text" value="<%=book.language %>" readonly="readonly" />
            </div>
        </div>
        <div class="elements">
            <div class="title"><i class="fas fa-pen"></i>Description</div>
            <div class="input">
                <textarea id="description" readonly="readonly" style="border: none;"><%=book.description %></textarea>
            </div>
        </div>
    </div>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="review-book">
                    <asp:DropDownList ID="selectTop" AutoPostBack="true" OnSelectedIndexChanged="selectTop_SelectedIndexChanged" runat="server">
                        <asp:ListItem Value="10" Text="Top 10 reviews"></asp:ListItem>
                        <asp:ListItem Value="20" Text="Top 20 reviews"></asp:ListItem>
                        <asp:ListItem Value="30" Text="Top 30 reviews"></asp:ListItem>
                        <asp:ListItem Value="40" Text="Top 40 reviews"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <img src="img/loader.gif" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div class="content-review">
                        <div id="content-article">
                            <% for (int j = 0; j < reviews.Count; j++)
                                { %>
                            <article>
                                <b><a href="Profile.aspx?id=<%= reviews[j].idUser%>"><%= reviews[j].username %></a></b>
                                <p><%= reviews[j].CreateDate.ToString("MM/dd/yyyy") %></p>
                                <textarea readonly="readonly"><%= reviews[j].content %></textarea>
                            </article>
                            <%} %>
                        </div>
                        <div class="title-upload">
                            <i class="fas fa-user"><b><a href="Profile.aspx"><%=user.userName %></a></b></i>
                            <p><%=currentDate.ToString("MM/dd/yyyy") %></p>
                            <textarea id="contentReview" placeholder="Write reivew here..." required="" runat="server"></textarea>
                            <asp:Button ID="sendReview" runat="server" Text="Review" OnClick="sendReview_Click" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script>
        var slideIndex = 0;
        showSlides(slideIndex);

        function plusSlides(n) {
            showSlides(slideIndex += n);
        }

        function showSlides(n) {
            var i;
            var slides = document.getElementsByClassName("info-book");
            var length = slides.length - 1;
            console.log(slideIndex);
            var prev = document.getElementById("prev");
            var next = document.getElementById("next");
            if (n === length - 1) {
                next.disabled = true;
                next.style.d
            } else {
                next.disabled = false;
            }
            if (n === 0) {
                prev.disabled = true;
            } else {
                prev.disabled = false;
            }
            for (i = 0; i < length; i++) {

                slides[i].style.display = "none";
            }
            console.log(slideIndex);
            slides[slideIndex].style.display = "block";
        }

        $(document).on('click', '.borrow-book input', function () {
            var idTrading = $(this).attr("data-idTrading");
            var currentIdUser = <%= user.id %>;
            $.ajax({
                url: "http://localhost:40621/TradingService.asmx/doBorrowBook",
                contentType: 'application/json',
                data: {
                    idTrading: idTrading,
                    idUser: currentIdUser
                },
                method: 'get',
                success: function (data) {
                    console.log(data.d);
                    if(data.d==true){
                        window.location.href = "TradingManagement.aspx";
                    }
                },
                error: function () {
                    alert('error');
                }
            });
        });
    </script>
</asp:Content>
