using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x020001FF RID: 511
	internal class \u000C\u000F
	{
		// Token: 0x06001319 RID: 4889 RVA: 0x000717D0 File Offset: 0x0006F9D0
		public \u000C\u000F(string \u001F, List<RevitParameter> \u000A)
		{
			StreamReader u001F = \u001A\u000D\u0018.\u000A(\u001F);
			string u001F2;
			while ((u001F2 = \u0010\u000D\u0018.\u000A(u001F)) != null)
			{
				IEnumerable<string> enumerable = \u000E\u000B\u001D.\u000A(u001F2, \u000C\u000F.\u001F, StringSplitOptions.None);
				Func<string, string> func;
				if ((func = \u000C\u000F.<>c.\u000A) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000F..ctor(string, List<RevitParameter>)).MethodHandle;
					}
					func = (\u000C\u000F.<>c.\u000A = new Func<string, string>(\u000C\u000F.<>c.\u001F.\u001D));
				}
				List<string> list = Enumerable.ToList<string>(Enumerable.ToArray<string>(Enumerable.Select<string, string>(enumerable, func)));
				if (this.\u000A == null)
				{
					for (;;)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					this.\u000A = new DataTable();
					int num = 0;
					List<RevitParameter>.Enumerator enumerator = \u0013\u000D\u0018.\u000A(\u000A);
					try
					{
						while (\u0011\u000D\u0018.\u000A(ref enumerator))
						{
							\u0014\u000D\u0018.\u000A(ref enumerator);
							DataColumn dataColumn = new DataColumn();
							\u0017\u000D\u0018.\u000A(dataColumn, \u001E\u0011\u000A.\u000A(\u001A\u0001\u0010.\u001F()));
							\u0020\u000D\u0018.\u000A(dataColumn, \u0004\u001E\u000A.\u000A("Column", \u000C\u0013\u0007.\u000A(ref num)));
							\u001E\u000D\u0018.\u000A(\u0007\u0012\u0018.\u000A(this.\u000A), dataColumn);
							num++;
						}
						for (;;)
						{
							switch (5)
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
					\u001B\u000D\u0018.\u000A(this.\u000A);
				}
				IEnumerable<string> enumerable2 = list;
				Func<string, bool> func2;
				if ((func2 = \u000C\u000F.<>c.\u0007) == null)
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
					func2 = (\u000C\u000F.<>c.\u0007 = new Func<string, bool>(\u000C\u000F.<>c.\u001F.\u0004));
				}
				if (!Enumerable.All<string>(enumerable2, func2))
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
					object u000A = this.\u000A;
					object[] u000A2 = Enumerable.ToArray<string>(Enumerable.Take<string>(list, \u0008\u000D\u0018.\u000A(\u000A)));
					\u000E\u000D\u0018.\u000A(u000A, u000A2, true);
				}
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
			if (this.\u000A != null)
			{
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				\u000D\u000D\u0018.\u0007(this.\u000A);
			}
			\u001C\u000D\u0018.\u000A(u001F);
		}

		// Token: 0x0600131A RID: 4890 RVA: 0x000719B4 File Offset: 0x0006FBB4
		// Note: this type is marked as 'beforefieldinit'.
		static \u000C\u000F()
		{
			string[] array = \u001B\u001F\u000E.\u001F(1);
			array[0] = "---DRONE---";
			\u000C\u000F.\u001F = array;
		}

		// Token: 0x17000592 RID: 1426
		// (get) Token: 0x0600131B RID: 4891 RVA: 0x000719D8 File Offset: 0x0006FBD8
		// (set) Token: 0x0600131C RID: 4892 RVA: 0x000719EC File Offset: 0x0006FBEC
		public string Name { get; set; }

		// Token: 0x17000593 RID: 1427
		// (get) Token: 0x0600131D RID: 4893 RVA: 0x00071A00 File Offset: 0x0006FC00
		public DataTable \u001D
		{
			get
			{
				return this.\u000A;
			}
		}

		// Token: 0x0400079C RID: 1948
		private static readonly string[] \u001F;

		// Token: 0x0400079D RID: 1949
		private readonly DataTable \u000A;

		// Token: 0x0400079E RID: 1950
		[CompilerGenerated]
		private string \u0007;
	}
}
