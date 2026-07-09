using System;
using System.IO;
using System.Xml.Serialization;

namespace TransferSingleApp
{
	// Token: 0x02000013 RID: 19
	internal class SaveXMLConfigs
	{
		// Token: 0x06000099 RID: 153 RVA: 0x00007B58 File Offset: 0x00005D58
		public static void Salva_config(Configuraciones configuracion)
		{
			string path = Utiles.ruta_Misdocumentos() + "\\Configuration.xml";
			Serializaciones.WriteToFile(configuracion, path);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00007B7C File Offset: 0x00005D7C
		public static Configuraciones Lee_Configuracion_de_XML()
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Configuraciones));
			string path = Utiles.ruta_Misdocumentos() + "\\Configuration.xml";
			if (!File.Exists(path))
			{
				return new Configuraciones();
			}
			StreamReader streamReader = new StreamReader(path);
			Configuraciones configuraciones = (Configuraciones)xmlSerializer.Deserialize(streamReader);
			streamReader.Close();
			if (configuraciones == null)
			{
				return new Configuraciones();
			}
			return configuraciones;
		}
	}
}
