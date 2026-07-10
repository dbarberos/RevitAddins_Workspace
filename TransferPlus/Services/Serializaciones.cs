using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Autodesk.Revit.UI;

namespace TransferPlus.Services
{
	// Token: 0x02000017 RID: 23
	public static class Serializaciones
	{
		// Token: 0x060000A2 RID: 162 RVA: 0x00007D88 File Offset: 0x00005F88
		public static string SerializeToString(object obj)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
			string result;
			using (StringWriter stringWriter = new StringWriter())
			{
				xmlSerializer.Serialize(stringWriter, obj);
				result = stringWriter.ToString();
			}
			return result;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00007DD4 File Offset: 0x00005FD4
		public static void WriteToFile(object obj, string path)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
			DirectoryInfo directoryInfo = new DirectoryInfo(Utiles.ruta_Misdocumentos());
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			StreamWriter streamWriter = new StreamWriter(path);
			xmlSerializer.Serialize(streamWriter, obj);
			streamWriter.Close();
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00007E1C File Offset: 0x0000601C
		public static string XmlSerializeToString(this object objectInstance)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(objectInstance.GetType());
			StringBuilder stringBuilder = new StringBuilder();
			using (TextWriter textWriter = new StringWriter(stringBuilder))
			{
				xmlSerializer.Serialize(textWriter, objectInstance);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00007E6C File Offset: 0x0000606C
		public static T XmlDeserializeFromString<T>(string objectData)
		{
			return (T)Serializaciones.XmlDeserializeFromString(objectData, typeof(T));
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00007E84 File Offset: 0x00006084
		public static object XmlDeserializeFromString(string objectData, Type type)
		{
			object result;
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(type);
				object obj;
				using (TextReader textReader = new StringReader(objectData))
				{
					obj = xmlSerializer.Deserialize(textReader);
				}
				result = obj;
			}
			catch (Exception ex)
			{
				TaskDialog.Show("TransferPlus", ex.Message + " Probably you have updated TransferPlus recently");
				result = null;
			}
			return result;
		}
	}
}
