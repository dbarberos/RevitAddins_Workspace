using System;
using System.IO;
using System.Reflection;

namespace TransferPlus.Services
{
	// Token: 0x0200002A RID: 42
	internal static class Utiles
	{
		// Token: 0x060001A3 RID: 419 RVA: 0x00015A94 File Offset: 0x00013C94
		public static string ruta_imagenes()
		{
			string[] array = Assembly.GetExecutingAssembly().Location.Split(new char[]
			{
				'\\'
			});
			string str = "";
			int num = 0;
			do
			{
				str = str + array[num] + "\\";
				num++;
			}
			while (num + 1 < array.Length);
			return str + "Imagenes\\";
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00015AE5 File Offset: 0x00013CE5
		public static string ruta_Misdocumentos()
		{
			return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Utiles.document_folder_name;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00015AF8 File Offset: 0x00013CF8
		public static string ruta_DLL()
		{
			return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00015B09 File Offset: 0x00013D09
		public static string ruta_ParametrosCompartidos()
		{
			return Utiles.ruta_Misdocumentos() + Utiles.archivo_parametros_compartidos;
		}

		// Token: 0x04000168 RID: 360
		public static string Generic_JO_Folder = "\\JOTools";

		// Token: 0x04000169 RID: 361
		public static string RevitVersion = "2024";

		// Token: 0x0400016A RID: 362
		public static string document_folder_name = Utiles.Generic_JO_Folder + "\\TransferSingle" + Utiles.RevitVersion;

		// Token: 0x0400016B RID: 363
		public static string archivo_parametros_compartidos = "\\TransferSingle.txt";
	}
}
