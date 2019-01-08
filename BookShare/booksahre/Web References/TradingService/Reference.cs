﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace booksahre.TradingService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="TradingServiceSoap", Namespace="http://tempuri.org/")]
    public partial class TradingService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback NewFeedOperationCompleted;
        
        private System.Threading.SendOrPostCallback getPagesOperationCompleted;
        
        private System.Threading.SendOrPostCallback createTradingOperationCompleted;
        
        private System.Threading.SendOrPostCallback getTradingByIdBookOperationCompleted;
        
        private System.Threading.SendOrPostCallback getListBorrowOperationCompleted;
        
        private System.Threading.SendOrPostCallback getListLendOperationCompleted;
        
        private System.Threading.SendOrPostCallback doActionTradingOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public TradingService() {
            this.Url = global::booksahre.Properties.Settings.Default.booksahre_TradingService_TradingService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event NewFeedCompletedEventHandler NewFeedCompleted;
        
        /// <remarks/>
        public event getPagesCompletedEventHandler getPagesCompleted;
        
        /// <remarks/>
        public event createTradingCompletedEventHandler createTradingCompleted;
        
        /// <remarks/>
        public event getTradingByIdBookCompletedEventHandler getTradingByIdBookCompleted;
        
        /// <remarks/>
        public event getListBorrowCompletedEventHandler getListBorrowCompleted;
        
        /// <remarks/>
        public event getListLendCompletedEventHandler getListLendCompleted;
        
        /// <remarks/>
        public event doActionTradingCompletedEventHandler doActionTradingCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/NewFeed", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Trading[] NewFeed(int page) {
            object[] results = this.Invoke("NewFeed", new object[] {
                        page});
            return ((Trading[])(results[0]));
        }
        
        /// <remarks/>
        public void NewFeedAsync(int page) {
            this.NewFeedAsync(page, null);
        }
        
        /// <remarks/>
        public void NewFeedAsync(int page, object userState) {
            if ((this.NewFeedOperationCompleted == null)) {
                this.NewFeedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNewFeedOperationCompleted);
            }
            this.InvokeAsync("NewFeed", new object[] {
                        page}, this.NewFeedOperationCompleted, userState);
        }
        
        private void OnNewFeedOperationCompleted(object arg) {
            if ((this.NewFeedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NewFeedCompleted(this, new NewFeedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getPages", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int getPages() {
            object[] results = this.Invoke("getPages", new object[0]);
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void getPagesAsync() {
            this.getPagesAsync(null);
        }
        
        /// <remarks/>
        public void getPagesAsync(object userState) {
            if ((this.getPagesOperationCompleted == null)) {
                this.getPagesOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetPagesOperationCompleted);
            }
            this.InvokeAsync("getPages", new object[0], this.getPagesOperationCompleted, userState);
        }
        
        private void OngetPagesOperationCompleted(object arg) {
            if ((this.getPagesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getPagesCompleted(this, new getPagesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/createTrading", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int createTrading(int idOwner, int idBook) {
            object[] results = this.Invoke("createTrading", new object[] {
                        idOwner,
                        idBook});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void createTradingAsync(int idOwner, int idBook) {
            this.createTradingAsync(idOwner, idBook, null);
        }
        
        /// <remarks/>
        public void createTradingAsync(int idOwner, int idBook, object userState) {
            if ((this.createTradingOperationCompleted == null)) {
                this.createTradingOperationCompleted = new System.Threading.SendOrPostCallback(this.OncreateTradingOperationCompleted);
            }
            this.InvokeAsync("createTrading", new object[] {
                        idOwner,
                        idBook}, this.createTradingOperationCompleted, userState);
        }
        
        private void OncreateTradingOperationCompleted(object arg) {
            if ((this.createTradingCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.createTradingCompleted(this, new createTradingCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getTradingByIdBook", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Trading[] getTradingByIdBook(int idBook, int idOwner) {
            object[] results = this.Invoke("getTradingByIdBook", new object[] {
                        idBook,
                        idOwner});
            return ((Trading[])(results[0]));
        }
        
        /// <remarks/>
        public void getTradingByIdBookAsync(int idBook, int idOwner) {
            this.getTradingByIdBookAsync(idBook, idOwner, null);
        }
        
        /// <remarks/>
        public void getTradingByIdBookAsync(int idBook, int idOwner, object userState) {
            if ((this.getTradingByIdBookOperationCompleted == null)) {
                this.getTradingByIdBookOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetTradingByIdBookOperationCompleted);
            }
            this.InvokeAsync("getTradingByIdBook", new object[] {
                        idBook,
                        idOwner}, this.getTradingByIdBookOperationCompleted, userState);
        }
        
        private void OngetTradingByIdBookOperationCompleted(object arg) {
            if ((this.getTradingByIdBookCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getTradingByIdBookCompleted(this, new getTradingByIdBookCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getListBorrow", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public TradingDetail[] getListBorrow(string type, int userId) {
            object[] results = this.Invoke("getListBorrow", new object[] {
                        type,
                        userId});
            return ((TradingDetail[])(results[0]));
        }
        
        /// <remarks/>
        public void getListBorrowAsync(string type, int userId) {
            this.getListBorrowAsync(type, userId, null);
        }
        
        /// <remarks/>
        public void getListBorrowAsync(string type, int userId, object userState) {
            if ((this.getListBorrowOperationCompleted == null)) {
                this.getListBorrowOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetListBorrowOperationCompleted);
            }
            this.InvokeAsync("getListBorrow", new object[] {
                        type,
                        userId}, this.getListBorrowOperationCompleted, userState);
        }
        
        private void OngetListBorrowOperationCompleted(object arg) {
            if ((this.getListBorrowCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getListBorrowCompleted(this, new getListBorrowCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getListLend", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public TradingDetail[] getListLend(string type, int userId) {
            object[] results = this.Invoke("getListLend", new object[] {
                        type,
                        userId});
            return ((TradingDetail[])(results[0]));
        }
        
        /// <remarks/>
        public void getListLendAsync(string type, int userId) {
            this.getListLendAsync(type, userId, null);
        }
        
        /// <remarks/>
        public void getListLendAsync(string type, int userId, object userState) {
            if ((this.getListLendOperationCompleted == null)) {
                this.getListLendOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetListLendOperationCompleted);
            }
            this.InvokeAsync("getListLend", new object[] {
                        type,
                        userId}, this.getListLendOperationCompleted, userState);
        }
        
        private void OngetListLendOperationCompleted(object arg) {
            if ((this.getListLendCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getListLendCompleted(this, new getListLendCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/doActionTrading", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool doActionTrading(string method, int idTrading) {
            object[] results = this.Invoke("doActionTrading", new object[] {
                        method,
                        idTrading});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void doActionTradingAsync(string method, int idTrading) {
            this.doActionTradingAsync(method, idTrading, null);
        }
        
        /// <remarks/>
        public void doActionTradingAsync(string method, int idTrading, object userState) {
            if ((this.doActionTradingOperationCompleted == null)) {
                this.doActionTradingOperationCompleted = new System.Threading.SendOrPostCallback(this.OndoActionTradingOperationCompleted);
            }
            this.InvokeAsync("doActionTrading", new object[] {
                        method,
                        idTrading}, this.doActionTradingOperationCompleted, userState);
        }
        
        private void OndoActionTradingOperationCompleted(object arg) {
            if ((this.doActionTradingCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.doActionTradingCompleted(this, new doActionTradingCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Trading {
        
        private int idField;
        
        private int idOwnerField;
        
        private int idBorrowerField;
        
        private int idBookField;
        
        private int statusBookField;
        
        private bool statusCompleteField;
        
        private System.DateTime createDateField;
        
        private System.DateTime completeDateField;
        
        private Book getBookField;
        
        private User getUserField;
        
        /// <remarks/>
        public int id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public int idOwner {
            get {
                return this.idOwnerField;
            }
            set {
                this.idOwnerField = value;
            }
        }
        
        /// <remarks/>
        public int idBorrower {
            get {
                return this.idBorrowerField;
            }
            set {
                this.idBorrowerField = value;
            }
        }
        
        /// <remarks/>
        public int idBook {
            get {
                return this.idBookField;
            }
            set {
                this.idBookField = value;
            }
        }
        
        /// <remarks/>
        public int statusBook {
            get {
                return this.statusBookField;
            }
            set {
                this.statusBookField = value;
            }
        }
        
        /// <remarks/>
        public bool statusComplete {
            get {
                return this.statusCompleteField;
            }
            set {
                this.statusCompleteField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime createDate {
            get {
                return this.createDateField;
            }
            set {
                this.createDateField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime completeDate {
            get {
                return this.completeDateField;
            }
            set {
                this.completeDateField = value;
            }
        }
        
        /// <remarks/>
        public Book getBook {
            get {
                return this.getBookField;
            }
            set {
                this.getBookField = value;
            }
        }
        
        /// <remarks/>
        public User getUser {
            get {
                return this.getUserField;
            }
            set {
                this.getUserField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Book {
        
        private int idField;
        
        private int idUserField;
        
        private string titleField;
        
        private string authorField;
        
        private string iSBNField;
        
        private string languageField;
        
        private string descriptionField;
        
        private string tagField;
        
        private bool statusField;
        
        private string getImageField;
        
        private string[] getImagesField;
        
        /// <remarks/>
        public int id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public int idUser {
            get {
                return this.idUserField;
            }
            set {
                this.idUserField = value;
            }
        }
        
        /// <remarks/>
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        public string author {
            get {
                return this.authorField;
            }
            set {
                this.authorField = value;
            }
        }
        
        /// <remarks/>
        public string ISBN {
            get {
                return this.iSBNField;
            }
            set {
                this.iSBNField = value;
            }
        }
        
        /// <remarks/>
        public string language {
            get {
                return this.languageField;
            }
            set {
                this.languageField = value;
            }
        }
        
        /// <remarks/>
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public string tag {
            get {
                return this.tagField;
            }
            set {
                this.tagField = value;
            }
        }
        
        /// <remarks/>
        public bool status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        public string getImage {
            get {
                return this.getImageField;
            }
            set {
                this.getImageField = value;
            }
        }
        
        /// <remarks/>
        public string[] getImages {
            get {
                return this.getImagesField;
            }
            set {
                this.getImagesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class TradingDetail {
        
        private int idField;
        
        private int bookIDField;
        
        private string titleField;
        
        private string createDateField;
        
        private int statusField;
        
        private int userIDField;
        
        private string usernameField;
        
        /// <remarks/>
        public int id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public int bookID {
            get {
                return this.bookIDField;
            }
            set {
                this.bookIDField = value;
            }
        }
        
        /// <remarks/>
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        public string createDate {
            get {
                return this.createDateField;
            }
            set {
                this.createDateField = value;
            }
        }
        
        /// <remarks/>
        public int status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        public int userID {
            get {
                return this.userIDField;
            }
            set {
                this.userIDField = value;
            }
        }
        
        /// <remarks/>
        public string username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class User {
        
        private int idField;
        
        private string fullNameField;
        
        private System.DateTime birthdayField;
        
        private string avatarField;
        
        private string userNameField;
        
        private string passwordField;
        
        private string emailField;
        
        private string addressField;
        
        private string phoneNumberField;
        
        private string linkFacebookField;
        
        private int userPointField;
        
        private System.DateTime createDateField;
        
        /// <remarks/>
        public int id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string fullName {
            get {
                return this.fullNameField;
            }
            set {
                this.fullNameField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime birthday {
            get {
                return this.birthdayField;
            }
            set {
                this.birthdayField = value;
            }
        }
        
        /// <remarks/>
        public string avatar {
            get {
                return this.avatarField;
            }
            set {
                this.avatarField = value;
            }
        }
        
        /// <remarks/>
        public string userName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
            }
        }
        
        /// <remarks/>
        public string password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
        
        /// <remarks/>
        public string email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
        
        /// <remarks/>
        public string address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
        
        /// <remarks/>
        public string phoneNumber {
            get {
                return this.phoneNumberField;
            }
            set {
                this.phoneNumberField = value;
            }
        }
        
        /// <remarks/>
        public string linkFacebook {
            get {
                return this.linkFacebookField;
            }
            set {
                this.linkFacebookField = value;
            }
        }
        
        /// <remarks/>
        public int userPoint {
            get {
                return this.userPointField;
            }
            set {
                this.userPointField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime createDate {
            get {
                return this.createDateField;
            }
            set {
                this.createDateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void NewFeedCompletedEventHandler(object sender, NewFeedCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class NewFeedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal NewFeedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Trading[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Trading[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void getPagesCompletedEventHandler(object sender, getPagesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getPagesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getPagesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void createTradingCompletedEventHandler(object sender, createTradingCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class createTradingCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal createTradingCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void getTradingByIdBookCompletedEventHandler(object sender, getTradingByIdBookCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getTradingByIdBookCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getTradingByIdBookCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Trading[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Trading[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void getListBorrowCompletedEventHandler(object sender, getListBorrowCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getListBorrowCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getListBorrowCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public TradingDetail[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((TradingDetail[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void getListLendCompletedEventHandler(object sender, getListLendCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getListLendCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getListLendCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public TradingDetail[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((TradingDetail[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void doActionTradingCompletedEventHandler(object sender, doActionTradingCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class doActionTradingCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal doActionTradingCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591