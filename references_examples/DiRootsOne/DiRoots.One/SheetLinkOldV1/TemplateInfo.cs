using System;
using A;
using DiRoots.One.Commons;

namespace SheetLinkOldV1
{
	// Token: 0x02000019 RID: 25
	[Serializable]
	public class TemplateInfo
	{
		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x00004998 File Offset: 0x00002B98
		// (set) Token: 0x060000CF RID: 207 RVA: 0x00004984 File Offset: 0x00002B84
		public string TypeSelection { get; set; }

		// Token: 0x060000D1 RID: 209 RVA: 0x000049AC File Offset: 0x00002BAC
		internal static bool \u001F(string \u001F)
		{
			try
			{
				if (XMLUtility.DeserialiseInfo<TemplateInfo>(\u001F) != null)
				{
					for (;;)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(TemplateInfo.\u001F(string)).MethodHandle;
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
