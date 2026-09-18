using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002BD RID: 701
	public class SelectionTemplate
	{
		// Token: 0x06001BFF RID: 7167 RVA: 0x000B3158 File Offset: 0x000B1358
		public SelectionTemplate()
		{
			\u0007\u000D\u0016.\u000A(this, new SheetTemplate());
		}

		// Token: 0x06001C00 RID: 7168 RVA: 0x000B3178 File Offset: 0x000B1378
		public SelectionTemplate(SheetInfo sheet)
		{
			\u0018\u000D\u0016.\u000A(this, false);
			\u0004\u000D\u0016.\u0007(this, \u0004\u001E\u000A.\u000A("Template: ", \u0019\u000D\u0016.\u000A(\u0008\u0007\u0016.\u0007(sheet))));
			\u001D\u000D\u0016.\u0007(this, \u001B\u0007\u0016.\u0007(\u0008\u0007\u0016.\u0007(sheet)));
			\u0007\u000D\u0016.\u000A(this, \u0008\u0007\u0016.\u0007(sheet));
		}

		// Token: 0x170007C7 RID: 1991
		// (get) Token: 0x06001C01 RID: 7169 RVA: 0x000B31D8 File Offset: 0x000B13D8
		// (set) Token: 0x06001C02 RID: 7170 RVA: 0x000B31EC File Offset: 0x000B13EC
		public SheetTemplate Template { get; set; }

		// Token: 0x170007C8 RID: 1992
		// (get) Token: 0x06001C03 RID: 7171 RVA: 0x000B3200 File Offset: 0x000B1400
		// (set) Token: 0x06001C04 RID: 7172 RVA: 0x000B3214 File Offset: 0x000B1414
		public long TemplateSheetId { get; set; }

		// Token: 0x170007C9 RID: 1993
		// (get) Token: 0x06001C05 RID: 7173 RVA: 0x000B3228 File Offset: 0x000B1428
		// (set) Token: 0x06001C06 RID: 7174 RVA: 0x000B323C File Offset: 0x000B143C
		public string Name { get; set; }

		// Token: 0x170007CA RID: 1994
		// (get) Token: 0x06001C07 RID: 7175 RVA: 0x000B3250 File Offset: 0x000B1450
		// (set) Token: 0x06001C08 RID: 7176 RVA: 0x000B3264 File Offset: 0x000B1464
		public bool IsHidden { get; set; }

		// Token: 0x06001C09 RID: 7177 RVA: 0x000B3278 File Offset: 0x000B1478
		internal static List<SelectionTemplate> \u0004()
		{
			List<SelectionTemplate> list = \u000B\u000D\u0016.\u000A();
			List<long> u001F = \u001F\u001B\u0019.\u000A();
			List<SheetInfo>.Enumerator enumerator = \u0017\u0007\u0016.\u000A(\u0014\u0007\u0016.\u000A());
			try
			{
				while (\u000D\u0007\u0016.\u000A(ref enumerator))
				{
					SheetInfo u001F2 = \u0020\u0007\u0016.\u000A(ref enumerator);
					if (!\u001A\u0008\u0019.\u000A(u001F, \u001B\u0007\u0016.\u0007(\u0008\u0007\u0016.\u0007(u001F2))))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionTemplate.\u0004()).MethodHandle;
						}
						\u0001\u000E\u0019.\u000A(u001F, \u001B\u0007\u0016.\u0007(\u0008\u0007\u0016.\u0007(u001F2)));
						SelectionTemplate u000A = \u0016\u000D\u0016.\u000A(u001F2);
						\u0005\u000D\u0016.\u000A(list, u000A);
					}
				}
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x06001C0A RID: 7178 RVA: 0x000B333C File Offset: 0x000B153C
		internal static List<SelectionTemplate> \u0019()
		{
			List<SelectionTemplate> list = \u000B\u000D\u0016.\u000A();
			List<long> u001F = \u001F\u001B\u0019.\u000A();
			List<SheetInfo>.Enumerator enumerator = \u0017\u0007\u0016.\u000A(\u0014\u0007\u0016.\u000A());
			try
			{
				while (\u000D\u0007\u0016.\u000A(ref enumerator))
				{
					SheetInfo u001F2 = \u0020\u0007\u0016.\u000A(ref enumerator);
					if (\u0006\u0004\u0016.\u0007(u001F2) != UpdateStates.Updated)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionTemplate.\u0019()).MethodHandle;
						}
						if (\u0006\u0004\u0016.\u0007(u001F2) != UpdateStates.Modified)
						{
							goto IL_74;
						}
						for (;;)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					if (!\u0006\u000D\u0016.\u0007(u001F2))
					{
						continue;
					}
					for (;;)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					IL_74:
					if (!\u001A\u0008\u0019.\u000A(u001F, \u001B\u0007\u0016.\u0007(\u0008\u0007\u0016.\u0007(u001F2))))
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
						\u0001\u000E\u0019.\u000A(u001F, \u001B\u0007\u0016.\u0007(\u0008\u0007\u0016.\u0007(u001F2)));
						SelectionTemplate u000A = \u0002\u000D\u0016.\u000A();
						\u0005\u000D\u0016.\u000A(list, u000A);
					}
				}
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x04000B4A RID: 2890
		[CompilerGenerated]
		private SheetTemplate \u001F;

		// Token: 0x04000B4B RID: 2891
		[CompilerGenerated]
		private long \u000A;

		// Token: 0x04000B4C RID: 2892
		[CompilerGenerated]
		private string \u0007;

		// Token: 0x04000B4D RID: 2893
		[CompilerGenerated]
		private bool \u001D;
	}
}
