using System;
using A;
using DiRoots.One.Commons;

namespace SheetLinkOld
{
	// Token: 0x0200001A RID: 26
	[Serializable]
	public class TemPlateInfo
	{
		// Token: 0x060000D3 RID: 211 RVA: 0x00004A20 File Offset: 0x00002C20
		internal static bool \u001F(string \u001F)
		{
			try
			{
				if (XMLUtility.DeserialiseInfo<TemPlateInfo>(\u001F) != null)
				{
					for (;;)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(TemPlateInfo.\u001F(string)).MethodHandle;
					}
					return true;
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Models\\Templates\\TemplateInfo.cs", "IsOldTemplate");
			}
			return false;
		}
	}
}
