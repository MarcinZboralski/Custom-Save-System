using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace AdwancedSaveSystem.SaveSystem
{
    [Serializable]
    public class ASSCore
    {
        public static ASSCore istance;
        public Stream stream;
        
        public ASSDictonary<string, object> SaveDictonary;

        private BinaryFormatter binaryFormatter = new BinaryFormatter();
        private XmlSerializer xmlSerializer = new XmlSerializer(typeof(ASSDictonary<string,object>));
        private ASSDictonary<string, object> loadeDictonary;

        public ASSCore()
        {
            istance = this;
        }

        public ASSCore(Stream stream, ASSDictonary<string, object> saveDictonary)
        {
            istance = this;

            this.stream = stream;
            SaveDictonary = saveDictonary;
        }

        public void Serialize(FileStream stream,TypeOfSerializaton typeOfSerializaton,ASSDictonary<string,object> toSave)
        {
            using (stream)
            {
                switch (typeOfSerializaton)
                {
                    case TypeOfSerializaton.Binary:
                        binaryFormatter.Serialize(stream,toSave);
                        break;
                    case TypeOfSerializaton.XML:
                        xmlSerializer.Serialize(stream,toSave);
                        break;
                }
            }
        }

        public void Deserialize(FileStream stream,TypeOfSerializaton typeOfSerializaton,out ASSDictonary<string,object> loaded)
        { 
            using (stream)
            {
               
                switch (typeOfSerializaton)
                {
                    case TypeOfSerializaton.Binary:
                        loadeDictonary = (ASSDictonary<string,object>)binaryFormatter.Deserialize(stream);
                        break;
                    case TypeOfSerializaton.XML:
                        loadeDictonary = (ASSDictonary<string,object>)binaryFormatter.Deserialize(stream);
                        break;
                }
            }

            loaded = loadeDictonary;
        }

        public void SerializeXML(string path)
        {
            using (stream = new FileStream(path,FileMode.CreateNew))
            {
                xmlSerializer.Serialize(stream,SaveDictonary);
            }
        }

        public void SerializeXML(string path,ASSDictonary<string,object> toSave)
        {
            using (stream = new FileStream(path,FileMode.CreateNew))
            {
                xmlSerializer.Serialize(stream,toSave);
            }
        }

        public void DeserializeXML(string path)
        {
            using (stream = new FileStream(path,FileMode.Open))
            {
                SaveDictonary = (ASSDictonary<string,object>)xmlSerializer.Deserialize(stream);
            }
        }

        public void DeserializeXML(string path,out ASSDictonary<string,object> loadedFile)
        {
            using (stream = new FileStream(path,FileMode.Open))
            {
                loadedFile = (ASSDictonary<string,object>)xmlSerializer.Deserialize(stream);
            }
        }

        public void SerializeBinary(string path)
        {
            using (stream = new FileStream(path,FileMode.CreateNew))
            {
                binaryFormatter.Serialize(stream,SaveDictonary);
            }
        }

        public void SerializeBinary(string path,ASSDictonary<string,object> toSave)
        {
            using (stream = new FileStream(path,FileMode.CreateNew))
            {
                binaryFormatter.Serialize(stream,toSave);
            }
        }

        public void DeserializeBinary(string path)
        {
            using (stream = new FileStream(path,FileMode.Open))
            {
                SaveDictonary = (ASSDictonary<string,object>)binaryFormatter.Deserialize(stream);
            }
        }

        public void DeserializeBinary(string path,out ASSDictonary<string,object> loadedFile)
        {
            using (stream = new FileStream(path,FileMode.Open))
            {
                loadedFile = (ASSDictonary<string,object>)binaryFormatter.Deserialize(stream);
            }
        }
    }

    public enum TypeOfSerializaton
    {
        Binary,
        XML
    }
}
