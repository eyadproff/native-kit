namespace Crossmatch
{
    public class BioBaseDeviceInfo
    {
        private string modalityField;

        private string modelNameField;

        private string serNumField;

        private string interfaceField;

        private string deviceIdField;

        private string visualizersField;

        public string Modality
        {
            get
            {
                return this.modalityField;
            }
            set
            {
                this.modalityField = value;
            }
        }

        public string ModelName
        {
            get
            {
                return this.modelNameField;
            }
            set
            {
                this.modelNameField = value;
            }
        }

        public string SerNum
        {
            get
            {
                return this.serNumField;
            }
            set
            {
                this.serNumField = value;
            }
        }

        public string Interface
        {
            get
            {
                return this.interfaceField;
            }
            set
            {
                this.interfaceField = value;
            }
        }

        public string DeviceId
        {
            get
            {
                return this.deviceIdField;
            }
            set
            {
                this.deviceIdField = value;
            }
        }

        public string Visualizers
        {
            get
            {
                return this.visualizersField;
            }
            set
            {
                this.visualizersField = value;
            }
        }
    }
}
