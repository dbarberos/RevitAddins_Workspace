using System;
using System.Collections.Generic;
using System.IO;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using DiRoots.One.SheetGen;

namespace A
{
	// Token: 0x020002C3 RID: 707
	internal static class \u001A\u001B
	{
		// Token: 0x06001CBD RID: 7357 RVA: 0x000B67BC File Offset: 0x000B49BC
		private static Schema \u001F()
		{
			SchemaBuilder u001F = \u000F\u001A\u0004.\u000A(new Guid("65C3FF1A-467F-4F85-BDF2-74BA706FDF77"));
			\u0006\u001A\u0004.\u000A(u001F, 1);
			\u0007\u001B\u0016.\u000A(u001F, 2);
			\u000A\u001B\u0016.\u000A(u001F, "www.diroots.com");
			\u0016\u001A\u0004.\u000A(\u0002\u001A\u0004.\u000A(u001F, "Filename", \u001E\u0011\u000A.\u000A(\u001A\u0001\u0010.\u001F())), "File name");
			\u0016\u001A\u0004.\u000A(\u0002\u001A\u0004.\u000A(u001F, "Folder", \u001E\u0011\u000A.\u000A(\u001A\u0001\u0010.\u001F())), "Original file folder path");
			\u0016\u001A\u0004.\u000A(\u000B\u001A\u0004.\u000A(u001F, "Data", \u001E\u0011\u000A.\u000A(\u0005\u0018\u000E.\u001F())), "Stored file data");
			\u0005\u001A\u0004.\u000A(u001F, "SheetGen_SheetInfo");
			return \u0018\u001A\u0004.\u000A(u001F);
		}

		// Token: 0x06001CBE RID: 7358 RVA: 0x000B688C File Offset: 0x000B4A8C
		internal static void \u000A(Element \u001F, SheetInfo \u000A)
		{
			try
			{
				Schema u001F = \u001A\u001B.\u001F();
				List<SheetInfo> u001F2 = \u001D\u000B\u0016.\u000A();
				\u0008\u0018\u0016.\u000A(u001F2, \u000A);
				string u000A = \u001A\u001B.\u0007<List<SheetInfo>>(u001F2);
				string u001F3 = "";
				\u0004\u001B\u0016.\u000A(u001F3, u000A);
				byte[] array = \u001D\u001B\u0016.\u000A(u001F3);
				\u0007\u0001\u001D.\u000A(u001F3);
				string text = "-";
				string text2 = "-";
				Entity entity = \u0010\u001A\u0004.\u000A(u001F);
				entity.Set<string>(\u000D\u001A\u0004.\u000A(u001F, "Filename"), text2);
				entity.Set<string>(\u000D\u001A\u0004.\u000A(u001F, "Folder"), text);
				entity.Set<IList<byte>>(\u000D\u001A\u0004.\u000A(u001F, "Data"), array);
				\u001C\u001A\u0004.\u000A(\u001F, entity);
			}
			catch (Exception u000A2)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Models\\Storage.cs", "SetDataToElement");
			}
		}

		// Token: 0x06001CBF RID: 7359 RVA: 0x000B695C File Offset: 0x000B4B5C
		private static string \u0007<\u001F>(\u001F \u001F)
		{
			string result;
			try
			{
				StringWriter stringWriter = \u0018\u001B\u0016.\u000A();
				\u0019\u001B\u0016.\u000A(\u0008\u001A\u0004.\u000A(\u001E\u0011\u000A.\u000A(typeof(\u001F).TypeHandle)), stringWriter, \u001F);
				result = \u001A\u000C\u000A.\u000A(stringWriter);
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Models\\Storage.cs", "Serialize");
				throw;
			}
			return result;
		}
	}
}
