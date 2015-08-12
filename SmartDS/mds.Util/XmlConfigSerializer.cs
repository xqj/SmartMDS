﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace mds.Util
{
   public class XmlConfigSerializer
    {
       private static XmlConfigSerializer _instance = new XmlConfigSerializer();
       public static XmlConfigSerializer Instance
       {
           get
           {
               return _instance;
           }
       }
       private XmlConfigSerializer()
       {

       }
       public void Serializer<T>(string file, T data)
       {
           XmlSerializer ser = new XmlSerializer(typeof(T));
           FileStream stream = new FileStream(file, FileMode.OpenOrCreate);
           ser.Serialize(stream, data);
           stream.Close();
       }
       public List<T> Deserialize<T>(string file)
       {
           XmlSerializer ser = new XmlSerializer(typeof(List<T>));
           XmlReaderSettings settings = new XmlReaderSettings();
           settings.ConformanceLevel = ConformanceLevel.Fragment;
           settings.IgnoreWhitespace = true;
           settings.IgnoreComments = true;
           XmlReader reader = XmlReader.Create(file, settings);
           List<T> list = null;
           if (ser.CanDeserialize(reader))
               list = (List<T>)ser.Deserialize(reader);
           return list;
       }
       public T DeserializeSingle<T>(string file)
       {
           XmlSerializer ser = new XmlSerializer(typeof(T));
           XmlReaderSettings settings = new XmlReaderSettings();
           settings.ConformanceLevel = ConformanceLevel.Fragment;
           settings.IgnoreWhitespace = true;
           settings.IgnoreComments = true;
           XmlReader reader = XmlReader.Create(file, settings);
           T instance = default(T);
           if (ser.CanDeserialize(reader))
               instance = (T)ser.Deserialize(reader);
           return instance;
       }
       public  string ToXml<T>(T item)
       {
           XmlSerializer serializer = new XmlSerializer(item.GetType());
           StringBuilder sb = new StringBuilder();
           using (XmlWriter writer = XmlWriter.Create(sb))
           {
               serializer.Serialize(writer, item);
               return sb.ToString();
           }
       }
       public T FromXml<T>(string str)
       {
           XmlSerializer serializer = new XmlSerializer(typeof(T));
           using (XmlReader reader = new XmlTextReader(new StringReader(str)))
           {
               return (T)serializer.Deserialize(reader);
           }
       }
    }
}
