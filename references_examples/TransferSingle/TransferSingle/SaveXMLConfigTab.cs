using System;
using System.IO;
using System.Xml.Serialization;

namespace TransferSingleApp
{
	// Token: 0x02000014 RID: 20
	internal class SaveXMLConfigTab
	{
		// Token: 0x0600009C RID: 156 RVA: 0x00007BDC File Offset: 0x00005DDC
		public static void Salva_config(ConfiguracionTab configuracion)
		{
			string path = Utiles.ruta_Misdocumentos() + "\\Tab.xml";
			Serializaciones.WriteToFile(configuracion, path);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00007C00 File Offset: 0x00005E00
		public static ConfiguracionTab Lee_Configuracion_de_XML()
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ConfiguracionTab));
			string path = Utiles.ruta_Misdocumentos() + "\\Tab.xml";
			if (!File.Exists(path))
			{
				path = Utiles.ruta_DLL() + "\\Tab.xml";
				if (!File.Exists(path))
				{
					return new ConfiguracionTab();
				}
			}
			StreamReader streamReader = new StreamReader(path);
			ConfiguracionTab configuracionTab = (ConfiguracionTab)xmlSerializer.Deserialize(streamReader);
			streamReader.Close();
			if (configuracionTab == null)
			{
				return new ConfiguracionTab();
			}
			return configuracionTab;
		}
	}
}
