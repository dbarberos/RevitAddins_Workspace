using System;
using System.Collections.Generic;
using System.Linq;
using A;
using DiRoots.One.Commons.ExtensibleStorage;
using DiRoots.RoomPro.Interfaces;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x0200007B RID: 123
	[Schema("49080A7B-9E30-48D8-B8E0-7D9A0A99A7F4", "StoredNamingConfigurationSettingsData")]
	[Serializable]
	public sealed class NamingConfigurationSettings : IModelSettings, IRevitEntity, IEquatable<NamingConfigurationSettings>
	{
		// Token: 0x1700015A RID: 346
		// (get) Token: 0x0600055B RID: 1371 RVA: 0x0001FBEC File Offset: 0x0001DDEC
		// (set) Token: 0x0600055C RID: 1372 RVA: 0x0001FC00 File Offset: 0x0001DE00
		[Field]
		public bool UseProjectParameters { get; set; }

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x0600055D RID: 1373 RVA: 0x0001FC14 File Offset: 0x0001DE14
		// (set) Token: 0x0600055E RID: 1374 RVA: 0x0001FC28 File Offset: 0x0001DE28
		[Field]
		public bool UseFieldSeparator { get; set; }

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x0600055F RID: 1375 RVA: 0x0001FC3C File Offset: 0x0001DE3C
		// (set) Token: 0x06000560 RID: 1376 RVA: 0x0001FC50 File Offset: 0x0001DE50
		[Field]
		public string FieldSeparator { get; set; }

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000561 RID: 1377 RVA: 0x0001FC64 File Offset: 0x0001DE64
		// (set) Token: 0x06000562 RID: 1378 RVA: 0x0001FC78 File Offset: 0x0001DE78
		[Field]
		public List<NamingParameter> ElementNameComponents { get; set; } = new List<NamingParameter>();

		// Token: 0x06000563 RID: 1379 RVA: 0x0001FC8C File Offset: 0x0001DE8C
		public bool Equals(NamingConfigurationSettings other)
		{
			if (other == null)
			{
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationSettings.Equals(NamingConfigurationSettings)).MethodHandle;
				}
				return false;
			}
			bool flag = \u0017\u0016\u0007.\u001D(this);
			if (\u0010\u001F\u001D.\u000A(ref flag, \u0017\u0016\u0007.\u0007(other)))
			{
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				flag = \u001E\u0016\u0007.\u001D(this);
				if (\u0010\u001F\u001D.\u000A(ref flag, \u001E\u0016\u0007.\u0007(other)))
				{
					for (;;)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					if (\u000D\u001F\u001D.\u000A(\u001B\u0016\u0007.\u001D(this), \u001B\u0016\u0007.\u0007(other)))
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
						return Enumerable.SequenceEqual<NamingParameter>(\u001C\u0016\u0007.\u001D(this), \u001C\u0016\u0007.\u0007(other));
					}
				}
			}
			return false;
		}
	}
}
