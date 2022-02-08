namespace Crossmatch
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class BioBaseApiProperties
    {
        [System.Xml.Serialization.XmlElement("Api", IsNullable = false)]
        private string apiField;

        [System.Xml.Serialization.XmlElement("File", IsNullable = false)]
        private string fileField;

        [System.Xml.Serialization.XmlElement("Product", IsNullable = false)]
        private string productField;

        public string Api
        {
            get
            {
                return this.apiField;
            }
            set
            {
                this.apiField = value;
            }
        }

        public string File
        {
            get
            {
                return this.fileField;
            }
            set
            {
                this.fileField = value;
            }
        }

        public string Product
        {
            get
            {
                return this.productField;
            }
            set
            {
                this.productField = value;
            }
        }
    }
}
