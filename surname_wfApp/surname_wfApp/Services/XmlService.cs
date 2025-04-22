using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using surname_wfApp.Models;

namespace surname_wfApp.Services
{
    public class XmlService
    {
        public async Task SaveComponentAsync<T>(string filePath, List<T> components)
        {
            await Task.Run(() =>
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, components);
                }
            });
        }

        public async Task<List<T>> LoadComponentAsync<T>(string filePath)
        {
            return await Task.Run(() =>
            {
                if (!File.Exists(filePath)) return new List<T>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                using (StreamReader reader = new StreamReader(filePath))
                {
                    return (List<T>?)serializer.Deserialize(reader) ?? new List<T>();

                }
            });
        }
    }
}
