using System.Xml;

namespace Crossmatch
{   
    public class BioBaseXmlParsers
    {
        public static BioBaseDevicePropertyDictionary ParseDevicePropertiesXml(string xmlInput)
        {
            BioBaseDevicePropertyDictionary properties = new BioBaseDevicePropertyDictionary();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlInput);
            XmlNodeList elem = xmlDoc.GetElementsByTagName(BioBaseConstants.DEV_PROP_DEVICE_PROPERTIES);
            if (elem == null)
            {
                throw new BioBaseException("Missing xml element 'DeviceProperties'");
            }
            XmlNodeList propertyNodes = elem[0].ChildNodes;
            foreach (XmlNode node in propertyNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    properties.Add(node.Name, node.InnerText.Trim(BioBaseConstants.trimArray));
                }
            }
            return properties;
        }

        public static BioBaseDeviceInfo[] ParseDeviceInfoXml(ref string xmlInput)
        {
            XmlDocument dom = new XmlDocument();
            dom.LoadXml(xmlInput);
            XmlNodeList devIdentifierList = dom.GetElementsByTagName(BioBaseConstants.DEV_ID_DEVICE_ID_LIST);

            if (devIdentifierList == null)
                throw new BioBaseException("GetDeviceInfo XML bad format");

            XmlNodeList deviceNodes = dom.GetElementsByTagName(BioBaseConstants.DEV_ID_DEVICE);

            BioBaseDeviceInfo[] deviceList = new BioBaseDeviceInfo[deviceNodes.Count];

            int index = 0;
            foreach (XmlNode node in deviceNodes)
            {
                deviceList[index] = new BioBaseDeviceInfo();
                if (node == null)
                    throw new BioBaseException("Missing xml element 'Device'");
                XmlNode temp = node.SelectSingleNode(BioBaseConstants.DEV_ID_MODEL_NAME);
                if (temp == null)
                    throw new BioBaseException("Missing xml element 'ModelName'");

                deviceList[index].ModelName = temp.InnerText.Trim(BioBaseConstants.trimArray);

                temp = node.SelectSingleNode(BioBaseConstants.DEV_ID_SERIAL_NUMBER);
                if (temp == null)
                    throw new BioBaseException("Missing xml element 'SerNum'");

                deviceList[index].SerNum = temp.InnerText.Trim(BioBaseConstants.trimArray);

                temp = node.SelectSingleNode(BioBaseConstants.DEV_ID_INTERFACE);
                if (temp == null)
                    throw new BioBaseException("Missing xml element 'Interface'");

                deviceList[index].Interface = temp.InnerText.Trim(BioBaseConstants.trimArray);

                temp = node.SelectSingleNode(BioBaseConstants.DEV_ID_DEVICE_ID);
                if (temp == null)
                    throw new BioBaseException("Missing xml element 'DeviceId'");

                deviceList[index].DeviceId = temp.InnerText.Trim(BioBaseConstants.trimArray);

                temp = node.SelectSingleNode(BioBaseConstants.DEV_ID_MODALITY_TYPE);
                if (temp == null)
                    throw new BioBaseException("Missing xml element 'Modality'");

                deviceList[index].Modality = temp.InnerText.Trim(BioBaseConstants.trimArray);

                temp = node.SelectSingleNode(BioBaseConstants.DEV_ID_VISUALIZERS);
                if (temp == null)
                    throw new BioBaseException("Missing xml element 'Visualizers'");

                deviceList[index].Visualizers = temp.InnerText.Trim(BioBaseConstants.trimArray);
                index++;
            }
            return deviceList;
        }
             
        public static BioBaseApiProperties ParseApiPropertiesXml(string xmlInput)
        {
            BioBaseApiProperties bbApiProperties = new BioBaseApiProperties();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlInput);
            XmlNodeList xmlApiProperties = xmlDoc.GetElementsByTagName(BioBaseConstants.API_PROP_API_PROPERTIES);
            if (xmlApiProperties == null)
            {
                // error, throw exception
                throw new BioBaseException("Missing xml element 'ApiProperties'");
            }

            XmlNodeList propertyNodes = xmlApiProperties[0].ChildNodes;
            foreach (XmlNode node in propertyNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    if (node.Name == BioBaseConstants.API_PROP_API)
                        bbApiProperties.Api = node.InnerText.Trim(BioBaseConstants.trimArray);
                    else if (node.Name == BioBaseConstants.API_PROP_FILE)
                        bbApiProperties.File = node.InnerText.Trim(BioBaseConstants.trimArray);
                    else if (node.Name == BioBaseConstants.API_PROP_PRODUCT)
                        bbApiProperties.Product = node.InnerText.Trim(BioBaseConstants.trimArray);
                }
            }
            return bbApiProperties;
        }
    }

}
