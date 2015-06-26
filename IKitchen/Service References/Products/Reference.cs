﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IKitchen.Products {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Item", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class Item : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int productIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string appNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string productModelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string companyNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descField;
        
        private int priceField;
        
        private int installPriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string imgURLField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int productID {
            get {
                return this.productIDField;
            }
            set {
                if ((this.productIDField.Equals(value) != true)) {
                    this.productIDField = value;
                    this.RaisePropertyChanged("productID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string appName {
            get {
                return this.appNameField;
            }
            set {
                if ((object.ReferenceEquals(this.appNameField, value) != true)) {
                    this.appNameField = value;
                    this.RaisePropertyChanged("appName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string productModel {
            get {
                return this.productModelField;
            }
            set {
                if ((object.ReferenceEquals(this.productModelField, value) != true)) {
                    this.productModelField = value;
                    this.RaisePropertyChanged("productModel");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string companyName {
            get {
                return this.companyNameField;
            }
            set {
                if ((object.ReferenceEquals(this.companyNameField, value) != true)) {
                    this.companyNameField = value;
                    this.RaisePropertyChanged("companyName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string desc {
            get {
                return this.descField;
            }
            set {
                if ((object.ReferenceEquals(this.descField, value) != true)) {
                    this.descField = value;
                    this.RaisePropertyChanged("desc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public int price {
            get {
                return this.priceField;
            }
            set {
                if ((this.priceField.Equals(value) != true)) {
                    this.priceField = value;
                    this.RaisePropertyChanged("price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public int installPrice {
            get {
                return this.installPriceField;
            }
            set {
                if ((this.installPriceField.Equals(value) != true)) {
                    this.installPriceField = value;
                    this.RaisePropertyChanged("installPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string imgURL {
            get {
                return this.imgURLField;
            }
            set {
                if ((object.ReferenceEquals(this.imgURLField, value) != true)) {
                    this.imgURLField = value;
                    this.RaisePropertyChanged("imgURL");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Products.ProductsSoap")]
    public interface ProductsSoap {
        
        // CODEGEN: Generating message contract since element name getItemResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getItem", ReplyAction="*")]
        IKitchen.Products.getItemResponse getItem(IKitchen.Products.getItemRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getItem", ReplyAction="*")]
        System.Threading.Tasks.Task<IKitchen.Products.getItemResponse> getItemAsync(IKitchen.Products.getItemRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getItemRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getItem", Namespace="http://tempuri.org/", Order=0)]
        public IKitchen.Products.getItemRequestBody Body;
        
        public getItemRequest() {
        }
        
        public getItemRequest(IKitchen.Products.getItemRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class getItemRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int productId;
        
        public getItemRequestBody() {
        }
        
        public getItemRequestBody(int productId) {
            this.productId = productId;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getItemResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getItemResponse", Namespace="http://tempuri.org/", Order=0)]
        public IKitchen.Products.getItemResponseBody Body;
        
        public getItemResponse() {
        }
        
        public getItemResponse(IKitchen.Products.getItemResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class getItemResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public IKitchen.Products.Item getItemResult;
        
        public getItemResponseBody() {
        }
        
        public getItemResponseBody(IKitchen.Products.Item getItemResult) {
            this.getItemResult = getItemResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ProductsSoapChannel : IKitchen.Products.ProductsSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductsSoapClient : System.ServiceModel.ClientBase<IKitchen.Products.ProductsSoap>, IKitchen.Products.ProductsSoap {
        
        public ProductsSoapClient() {
        }
        
        public ProductsSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductsSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductsSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductsSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        IKitchen.Products.getItemResponse IKitchen.Products.ProductsSoap.getItem(IKitchen.Products.getItemRequest request) {
            return base.Channel.getItem(request);
        }
        
        public IKitchen.Products.Item getItem(int productId) {
            IKitchen.Products.getItemRequest inValue = new IKitchen.Products.getItemRequest();
            inValue.Body = new IKitchen.Products.getItemRequestBody();
            inValue.Body.productId = productId;
            IKitchen.Products.getItemResponse retVal = ((IKitchen.Products.ProductsSoap)(this)).getItem(inValue);
            return retVal.Body.getItemResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<IKitchen.Products.getItemResponse> IKitchen.Products.ProductsSoap.getItemAsync(IKitchen.Products.getItemRequest request) {
            return base.Channel.getItemAsync(request);
        }
        
        public System.Threading.Tasks.Task<IKitchen.Products.getItemResponse> getItemAsync(int productId) {
            IKitchen.Products.getItemRequest inValue = new IKitchen.Products.getItemRequest();
            inValue.Body = new IKitchen.Products.getItemRequestBody();
            inValue.Body.productId = productId;
            return ((IKitchen.Products.ProductsSoap)(this)).getItemAsync(inValue);
        }
    }
}
