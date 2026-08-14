using System;
using System.IO;
using System.Xml.Serialization;
using A;
using DiRoots.One.Commons.Profiles;
using DiRoots.One.TGDatabaseLayer.StyleMapping;
using Newtonsoft.Json;

namespace DiRoots.One.TableGen.Models
{
	// Token: 0x02000184 RID: 388
	[Serializable]
	public class StyleMappingProfileTemplate : ProfileTemplate
	{
		// Token: 0x06000E6E RID: 3694 RVA: 0x0005BDEC File Offset: 0x00059FEC
		public StyleMappingProfileTemplate()
		{
		}

		// Token: 0x06000E6F RID: 3695 RVA: 0x0005BE00 File Offset: 0x0005A000
		public StyleMappingProfileTemplate(StyleMappingDto profile)
		{
			\u000D\u000E\u0019.\u000A(this, \u000E\u000D\u0004.\u000A(profile, Formatting.None));
		}

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x06000E70 RID: 3696 RVA: 0x0005BE24 File Offset: 0x0005A024
		// (set) Token: 0x06000E71 RID: 3697 RVA: 0x0005BE38 File Offset: 0x0005A038
		public string ProfileJson { get; set; }

		// Token: 0x06000E72 RID: 3698 RVA: 0x0005BE4C File Offset: 0x0005A04C
		public StyleMappingDto ToStyleMappingProfile()
		{
			if (\u001A\u0006\u0007.\u000A(\u0010\u000E\u0019.\u000A(this)))
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingProfileTemplate.ToStyleMappingProfile()).MethodHandle;
				}
				return \u001F\u000D\u0004.\u000A();
			}
			StyleMappingDto result;
			try
			{
				result = JsonConvert.DeserializeObject<StyleMappingDto>(\u0010\u000E\u0019.\u000A(this));
			}
			catch
			{
				result = \u001F\u000D\u0004.\u000A();
			}
			return result;
		}

		// Token: 0x06000E73 RID: 3699 RVA: 0x0005BEB4 File Offset: 0x0005A0B4
		public override ProfileTemplate Clone()
		{
			XmlSerializer u001F = \u0008\u001A\u0004.\u000A(\u0003\u0011\u000A.\u001D(this));
			MemoryStream memoryStream = \u0003\u0002\u001D.\u000A();
			\u000E\u001A\u0004.\u000A(u001F, memoryStream, this);
			\u0005\u0002\u001D.\u000A(memoryStream, 0L);
			return \u001B\u0005\u000E.\u001F(\u000E\u000E\u0019.\u000A(u001F, memoryStream));
		}
	}
}
