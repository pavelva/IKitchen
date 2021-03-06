﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IKitchen.Convertor {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Convertor.ConvertorSoap")]
    public interface ConvertorSoap {
        
        // CODEGEN: Generating message contract since element name from from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/convert", ReplyAction="*")]
        IKitchen.Convertor.convertResponse convert(IKitchen.Convertor.convertRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/convert", ReplyAction="*")]
        System.Threading.Tasks.Task<IKitchen.Convertor.convertResponse> convertAsync(IKitchen.Convertor.convertRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class convertRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="convert", Namespace="http://tempuri.org/", Order=0)]
        public IKitchen.Convertor.convertRequestBody Body;
        
        public convertRequest() {
        }
        
        public convertRequest(IKitchen.Convertor.convertRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class convertRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string from;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string to;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public double amount;
        
        public convertRequestBody() {
        }
        
        public convertRequestBody(string from, string to, double amount) {
            this.from = from;
            this.to = to;
            this.amount = amount;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class convertResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="convertResponse", Namespace="http://tempuri.org/", Order=0)]
        public IKitchen.Convertor.convertResponseBody Body;
        
        public convertResponse() {
        }
        
        public convertResponse(IKitchen.Convertor.convertResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class convertResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public double convertResult;
        
        public convertResponseBody() {
        }
        
        public convertResponseBody(double convertResult) {
            this.convertResult = convertResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ConvertorSoapChannel : IKitchen.Convertor.ConvertorSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConvertorSoapClient : System.ServiceModel.ClientBase<IKitchen.Convertor.ConvertorSoap>, IKitchen.Convertor.ConvertorSoap {
        
        public ConvertorSoapClient() {
        }
        
        public ConvertorSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ConvertorSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConvertorSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConvertorSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        IKitchen.Convertor.convertResponse IKitchen.Convertor.ConvertorSoap.convert(IKitchen.Convertor.convertRequest request) {
            return base.Channel.convert(request);
        }
        
        public double convert(string from, string to, double amount) {
            IKitchen.Convertor.convertRequest inValue = new IKitchen.Convertor.convertRequest();
            inValue.Body = new IKitchen.Convertor.convertRequestBody();
            inValue.Body.from = from;
            inValue.Body.to = to;
            inValue.Body.amount = amount;
            IKitchen.Convertor.convertResponse retVal = ((IKitchen.Convertor.ConvertorSoap)(this)).convert(inValue);
            return retVal.Body.convertResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<IKitchen.Convertor.convertResponse> IKitchen.Convertor.ConvertorSoap.convertAsync(IKitchen.Convertor.convertRequest request) {
            return base.Channel.convertAsync(request);
        }
        
        public System.Threading.Tasks.Task<IKitchen.Convertor.convertResponse> convertAsync(string from, string to, double amount) {
            IKitchen.Convertor.convertRequest inValue = new IKitchen.Convertor.convertRequest();
            inValue.Body = new IKitchen.Convertor.convertRequestBody();
            inValue.Body.from = from;
            inValue.Body.to = to;
            inValue.Body.amount = amount;
            return ((IKitchen.Convertor.ConvertorSoap)(this)).convertAsync(inValue);
        }
    }
}
