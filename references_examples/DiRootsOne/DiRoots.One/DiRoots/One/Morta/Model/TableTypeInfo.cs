using System;
using A;
using DiRoots.One.Morta.Model.Base;

namespace DiRoots.One.Morta.Model
{
	// Token: 0x020001BA RID: 442
	public class TableTypeInfo : BaseInfo
	{
		// Token: 0x0600107D RID: 4221 RVA: 0x000688AC File Offset: 0x00066AAC
		public TableTypeInfo()
		{
		}

		// Token: 0x0600107E RID: 4222 RVA: 0x000688C0 File Offset: 0x00066AC0
		public TableTypeInfo(string name)
		{
			\u0010\u0007\u0018.\u001D(this, name);
			if (\u001A\u0006\u0007.\u000A(name))
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(TableTypeInfo..ctor(string)).MethodHandle;
				}
				\u0010\u0007\u0018.\u001D(this, "No Type");
			}
		}

		// Token: 0x0600107F RID: 4223 RVA: 0x00068904 File Offset: 0x00066B04
		public override bool Equals(object obj)
		{
			if (obj != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TableTypeInfo.Equals(object)).MethodHandle;
				}
				if (!\u0001\u001F\u001D.\u000A(\u0003\u0011\u000A.\u001D(this), \u0003\u0011\u000A.\u0007(obj)))
				{
					TableTypeInfo u001F = \u001A\u0016\u000E.\u001F(obj);
					return \u0008\u0013\u000A.\u000A(\u0003\u0007\u0018.\u001D(this), \u0003\u0007\u0018.\u0007(u001F));
				}
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			return false;
		}

		// Token: 0x06001080 RID: 4224 RVA: 0x0006896C File Offset: 0x00066B6C
		internal static TableTypeInfo \u0002()
		{
			TableTypeInfo tableTypeInfo = \u001F\u0005\u0018.\u000A("No Type");
			\u0012\u0007\u0018.\u000A(tableTypeInfo, "No Type");
			return tableTypeInfo;
		}

		// Token: 0x06001081 RID: 4225 RVA: 0x00068990 File Offset: 0x00066B90
		public override int GetHashCode()
		{
			string text = \u0003\u0007\u0018.\u001D(this);
			if (text == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(TableTypeInfo.GetHashCode()).MethodHandle;
				}
				return 0;
			}
			return \u001B\u0013\u000A.\u000A(text);
		}

		// Token: 0x04000686 RID: 1670
		public static string NoType;
	}
}
