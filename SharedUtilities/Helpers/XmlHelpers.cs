using System.Xml;
using System.Xml.Serialization;

namespace SharedUtilities.Helpers
{
    public class XmlHelpers
    {
        public static T ToClass<T>(string xmlString)
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(new StringReader(xmlString));
        }

        public static string FromClass<T>(T toSerialize)
        {
            var xmlSerializer = new XmlSerializer(toSerialize.GetType());
            using var textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, toSerialize);
            return textWriter.ToString();
        }

        public static async Task<string> GetValueFromXmlElement(string xmlString, string requiredValue)
        {
            return await GetValueFromXml(xmlString, requiredValue, XmlNodeType.Element);
        }

        public static async Task<string> GetValueFromXmlAttribute(string xmlString, string requiredValue)
        {
            return await GetValueFromXml(xmlString, requiredValue, XmlNodeType.Attribute);
        }

        static async Task<string> GetValueFromXml(string xmlString, string requiredValue, XmlNodeType nodeType)
        {
            var settings = new XmlReaderSettings
            {
                Async = true
            };

            var stringReader = new StringReader(xmlString);
            using var reader = XmlReader.Create(stringReader, settings);
            while (await reader.ReadAsync())
            {
                if (reader.NodeType != nodeType)
                    continue;

                if (reader.Name == requiredValue)
                {
                    return await reader.ReadElementContentAsStringAsync();
                }
            }
            return string.Empty;
        }
    }
}
