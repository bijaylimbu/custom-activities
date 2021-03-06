using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace Ayehu.Thycotic
{
    public class TY_Create_Secret_Template_Field_For_Template : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "";
    
    public string password1 = "";
    
    public string templateId = "";
    
    public string description_p = "";
    
    public string displayName_p = "";
    
    public string editablePermission = "";
    
    public string editRequires = "";
    
    public string fieldSlugName = "";
    
    public string generatePasswordCharacterSet = "";
    
    public string generatePasswordLength = "";
    
    public string hideOnView = "";
    
    public string historyLength = "";
    
    public string isExpirationField = "";
    
    public string isFile = "";
    
    public string isIndexable = "";
    
    public string isNotes = "";
    
    public string isPassword = "";
    
    public string isRequired = "";
    
    public string isUrl = "";
    
    public string mustEncrypt = "";
    
    public string name_p = "";
    
    public string passwordRequirementId = "";
    
    public string passwordTypeFieldId = "";
    
    public string sortOrder = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string _uriBuilderPath;
    
    private string _postData;
    
    private System.Collections.Generic.Dictionary<string, string> _headers;
    
    private System.Collections.Generic.Dictionary<string, string> _queryStringArray;
    
    private string uriBuilderPath {
        get {
            if (string.IsNullOrEmpty(_uriBuilderPath)) {
_uriBuilderPath = string.Format("SecretServer/api/v1/secret-templates/{0}",templateId);
            }
return _uriBuilderPath;
        }
        set {
            this._uriBuilderPath = value;
        }
    }
    
    private string postData {
        get {
            if (string.IsNullOrEmpty(_postData)) {
_postData = string.Format("{{ \"description\": \"{0}\",  \"displayName\": \"{1}\",  \"editablePermission\": \"{2}\",  \"editRequires\": \"{3}\",  \"fieldSlugName\": \"{4}\",  \"generatePasswordCharacterSet\": \"{5}\",  \"generatePasswordLength\": \"{6}\",  \"hideOnView\": \"{7}\",  \"historyLength\": \"{8}\",  \"isExpirationField\": \"{9}\",  \"isFile\": \"{10}\",  \"isIndexable\": \"{11}\",  \"isNotes\": \"{12}\",  \"isPassword\": \"{13}\",  \"isRequired\": \"{14}\",  \"isUrl\": \"{15}\",  \"mustEncrypt\": \"{16}\",  \"name\": \"{17}\",  \"passwordRequirementId\": \"{18}\",  \"passwordTypeFieldId\": \"{19}\",  \"sortOrder\": \"{20}\" }}",description_p,displayName_p,editablePermission,editRequires,fieldSlugName,generatePasswordCharacterSet,generatePasswordLength,hideOnView,historyLength,isExpirationField,isFile,isIndexable,isNotes,isPassword,isRequired,isUrl,mustEncrypt,name_p,passwordRequirementId,passwordTypeFieldId,sortOrder);
            }
return _postData;
        }
        set {
            this._postData = value;
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> headers {
        get {
            if (_headers == null) {
_headers = new Dictionary<string, string>() { {"Authorization","Bearer " + password1} };
            }
return _headers;
        }
        set {
            this._headers = value;
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> queryStringArray {
        get {
            if (_queryStringArray == null) {
_queryStringArray = new Dictionary<string, string>() {  };
            }
return _queryStringArray;
        }
        set {
            this._queryStringArray = value;
        }
    }
    
    public TY_Create_Secret_Template_Field_For_Template() {
    }
    
    public TY_Create_Secret_Template_Field_For_Template(
                string endPoint, 
                string Jsonkeypath, 
                string password1, 
                string templateId, 
                string description_p, 
                string displayName_p, 
                string editablePermission, 
                string editRequires, 
                string fieldSlugName, 
                string generatePasswordCharacterSet, 
                string generatePasswordLength, 
                string hideOnView, 
                string historyLength, 
                string isExpirationField, 
                string isFile, 
                string isIndexable, 
                string isNotes, 
                string isPassword, 
                string isRequired, 
                string isUrl, 
                string mustEncrypt, 
                string name_p, 
                string passwordRequirementId, 
                string passwordTypeFieldId, 
                string sortOrder) {
        this.endPoint = endPoint;
        this.Jsonkeypath = Jsonkeypath;
        this.password1 = password1;
        this.templateId = templateId;
        this.description_p = description_p;
        this.displayName_p = displayName_p;
        this.editablePermission = editablePermission;
        this.editRequires = editRequires;
        this.fieldSlugName = fieldSlugName;
        this.generatePasswordCharacterSet = generatePasswordCharacterSet;
        this.generatePasswordLength = generatePasswordLength;
        this.hideOnView = hideOnView;
        this.historyLength = historyLength;
        this.isExpirationField = isExpirationField;
        this.isFile = isFile;
        this.isIndexable = isIndexable;
        this.isNotes = isNotes;
        this.isPassword = isPassword;
        this.isRequired = isRequired;
        this.isUrl = isUrl;
        this.mustEncrypt = mustEncrypt;
        this.name_p = name_p;
        this.passwordRequirementId = passwordRequirementId;
        this.passwordTypeFieldId = passwordTypeFieldId;
        this.sortOrder = sortOrder;
    }


        public async System.Threading.Tasks.Task<ICustomActivityResult> Execute()
        {

            HttpClient client = new HttpClient();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            UriBuilder UriBuilder = new UriBuilder(endPoint); 
            UriBuilder.Path = uriBuilderPath;
            UriBuilder.Query = AyehuHelper.queryStringBuilder(queryStringArray);
            HttpRequestMessage myHttpRequestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), UriBuilder.ToString());
           
            if (contentType == "application/x-www-form-urlencoded")
                myHttpRequestMessage.Content = AyehuHelper.formUrlEncodedContent(postData);
            else
              if (string.IsNullOrEmpty(postData) == false)
                if (omitJsonEmptyorNull)
                    myHttpRequestMessage.Content = new StringContent(AyehuHelper.omitJsonEmptyorNull(postData), Encoding.UTF8, "application/json");
                else
                    myHttpRequestMessage.Content = new StringContent(postData, Encoding.UTF8, contentType);


            foreach (KeyValuePair<string, string> headeritem in headers)
                client.DefaultRequestHeaders.Add(headeritem.Key, headeritem.Value);

            HttpResponseMessage response = client.SendAsync(myHttpRequestMessage).Result;

            switch (response.StatusCode)
            {
                case HttpStatusCode.NoContent:
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.OK:
                    {
                        if (string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result) == false)
                            return this.GenerateActivityResult(response.Content.ReadAsStringAsync().Result, Jsonkeypath);
                        else
                            return this.GenerateActivityResult("Success");
                    }
                default:
                    {
                        if (string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result) == false)
                            throw new Exception(response.Content.ReadAsStringAsync().Result);
                        else if (string.IsNullOrEmpty(response.ReasonPhrase) == false)
                            throw new Exception(response.ReasonPhrase);
                        else
                            throw new Exception(response.StatusCode.ToString());
                    }
            }
        }

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}