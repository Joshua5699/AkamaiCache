﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.296.
// 
#pragma warning disable 1591

namespace AkamaiCache.AkamaiServiceRef {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="PurgeApiSOAPBinding", Namespace="http://www.akamai.com/purge")]
    public partial class PurgeApi : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback purgeRequestOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public PurgeApi() {
            this.Url = global::AkamaiCache.Properties.Settings.Default.AkamaiCache_AkamaiServiceRef_PurgeApi;
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
        public event purgeRequestCompletedEventHandler purgeRequestCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://www.akamai.com/purge", ResponseNamespace="http://www.akamai.com/purge")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public PurgeResult purgeRequest(string name, string pwd, string network, string[] opt, string[] uri) {
            object[] results = this.Invoke("purgeRequest", new object[] {
                        name,
                        pwd,
                        network,
                        opt,
                        uri});
            return ((PurgeResult)(results[0]));
        }
        
        /// <remarks/>
        public void purgeRequestAsync(string name, string pwd, string network, string[] opt, string[] uri) {
            this.purgeRequestAsync(name, pwd, network, opt, uri, null);
        }
        
        /// <remarks/>
        public void purgeRequestAsync(string name, string pwd, string network, string[] opt, string[] uri, object userState) {
            if ((this.purgeRequestOperationCompleted == null)) {
                this.purgeRequestOperationCompleted = new System.Threading.SendOrPostCallback(this.OnpurgeRequestOperationCompleted);
            }
            this.InvokeAsync("purgeRequest", new object[] {
                        name,
                        pwd,
                        network,
                        opt,
                        uri}, this.purgeRequestOperationCompleted, userState);
        }
        
        private void OnpurgeRequestOperationCompleted(object arg) {
            if ((this.purgeRequestCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.purgeRequestCompleted(this, new purgeRequestCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://www.akamai.com/purge")]
    public partial class PurgeResult {
        
        private int resultCodeField;
        
        private string resultMsgField;
        
        private string sessionIDField;
        
        private int estTimeField;
        
        private int uriIndexField;
        
        private string[] modifiersField;
        
        /// <remarks/>
        public int resultCode {
            get {
                return this.resultCodeField;
            }
            set {
                this.resultCodeField = value;
            }
        }
        
        /// <remarks/>
        public string resultMsg {
            get {
                return this.resultMsgField;
            }
            set {
                this.resultMsgField = value;
            }
        }
        
        /// <remarks/>
        public string sessionID {
            get {
                return this.sessionIDField;
            }
            set {
                this.sessionIDField = value;
            }
        }
        
        /// <remarks/>
        public int estTime {
            get {
                return this.estTimeField;
            }
            set {
                this.estTimeField = value;
            }
        }
        
        /// <remarks/>
        public int uriIndex {
            get {
                return this.uriIndexField;
            }
            set {
                this.uriIndexField = value;
            }
        }
        
        /// <remarks/>
        public string[] modifiers {
            get {
                return this.modifiersField;
            }
            set {
                this.modifiersField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void purgeRequestCompletedEventHandler(object sender, purgeRequestCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class purgeRequestCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal purgeRequestCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public PurgeResult Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((PurgeResult)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591