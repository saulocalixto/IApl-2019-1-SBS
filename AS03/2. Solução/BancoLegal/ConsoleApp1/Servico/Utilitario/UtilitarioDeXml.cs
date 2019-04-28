using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace BancoLegal.Servico.Utilitario
{
    public class UtilitarioDeXml<T>
    {
        XmlSerializer xmlSerializer;

        public UtilitarioDeXml()
        {
            xmlSerializer = new XmlSerializer(typeof(T));
        }

        public string ObjetoParaString(T objeto)
        {
            using (var xml = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(xml))
                {
                    xmlSerializer.Serialize(writer, objeto);

                    return xml.ToString();
                }
            }
        }

        public List<T> XmlParaObjetos(List<string> linhas)
        {
            List<T> lista = new List<T>();
            foreach (var linha in linhas)
            {
                using (var xml = new StringReader(linha))
                {
                    using (XmlTextReader reader = new XmlTextReader(xml))
                    {
                        lista.Add(((T)xmlSerializer.Deserialize(reader)));
                    }
                }
            }

            return lista;
        }
    }
}
