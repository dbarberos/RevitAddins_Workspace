using System;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.ExtensibleStorage;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x0200007C RID: 124
	[Schema("1B839AB0-E85F-4772-BD55-0C598DCD04DD", "StoredNamingParameterData")]
	public sealed class NamingParameter : IRevitEntity, IEquatable<NamingParameter>, IComparable<NamingParameter>
	{
		// Token: 0x06000564 RID: 1380 RVA: 0x0001FD3C File Offset: 0x0001DF3C
		public NamingParameter()
		{
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x0001FD74 File Offset: 0x0001DF74
		public NamingParameter(string name, NamingParameterType type = NamingParameterType.CustomField)
		{
			\u0008\u001F\u001D.\u000A(this, name);
			\u000E\u001F\u001D.\u000A(this, (int)type);
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x0001FDBC File Offset: 0x0001DFBC
		public NamingParameter(Parameter parameter, NamingParameterType type)
		{
			\u0017\u001F\u001D.\u000A(this, \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(parameter)));
			\u0008\u001F\u001D.\u000A(this, \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u0007(parameter)));
			\u001B\u001F\u001D.\u000A(this, \u0011\u001F\u001D.\u0007(parameter));
			\u000E\u001F\u001D.\u000A(this, (int)type);
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000567 RID: 1383 RVA: 0x0001FE34 File Offset: 0x0001E034
		// (set) Token: 0x06000568 RID: 1384 RVA: 0x0001FE48 File Offset: 0x0001E048
		[Field]
		public long Id { get; set; } = -1L;

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000569 RID: 1385 RVA: 0x0001FE5C File Offset: 0x0001E05C
		// (set) Token: 0x0600056A RID: 1386 RVA: 0x0001FE70 File Offset: 0x0001E070
		[Field]
		public string Name { get; set; } = "";

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x0600056B RID: 1387 RVA: 0x0001FE84 File Offset: 0x0001E084
		// (set) Token: 0x0600056C RID: 1388 RVA: 0x0001FE98 File Offset: 0x0001E098
		[Field]
		public string Value { get; set; } = "";

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x0600056D RID: 1389 RVA: 0x0001FEAC File Offset: 0x0001E0AC
		// (set) Token: 0x0600056E RID: 1390 RVA: 0x0001FEC0 File Offset: 0x0001E0C0
		[Field]
		public int Type { get; set; }

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x0600056F RID: 1391 RVA: 0x0001FED4 File Offset: 0x0001E0D4
		// (set) Token: 0x06000570 RID: 1392 RVA: 0x0001FEE8 File Offset: 0x0001E0E8
		[Field]
		public int StorageType { get; set; } = 3;

		// Token: 0x06000571 RID: 1393 RVA: 0x0001FEFC File Offset: 0x0001E0FC
		public int CompareTo(NamingParameter other)
		{
			return \u0013\u001F\u001D.\u000A(\u0020\u0013\u0007.\u001D(this), \u0020\u0013\u0007.\u0007(other));
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x0001FF20 File Offset: 0x0001E120
		public bool Equals(NamingParameter other)
		{
			long num = \u0015\u001F\u001D.\u001D(this);
			if (\u000C\u001F\u001D.\u000A(ref num, \u0015\u001F\u001D.\u0007(other)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingParameter.Equals(NamingParameter)).MethodHandle;
				}
				if (\u000D\u001F\u001D.\u000A(\u0020\u0013\u0007.\u001D(this), \u0020\u0013\u0007.\u0007(other)))
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
					int num2 = \u000E\u000F\u0007.\u001D(this);
					return \u001A\u001F\u001D.\u000A(ref num2, \u000E\u000F\u0007.\u0007(other));
				}
			}
			return false;
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x0001FF9C File Offset: 0x0001E19C
		public override bool Equals(object obj)
		{
			if (obj != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingParameter.Equals(object)).MethodHandle;
				}
				if (!\u0001\u001F\u001D.\u000A(\u0003\u0011\u000A.\u001D(this), \u0003\u0011\u000A.\u0007(obj)))
				{
					NamingParameter u001F = \u0004\u0007\u000E.\u001F(obj);
					if (\u0015\u001F\u001D.\u001D(this) == \u0015\u001F\u001D.\u0007(u001F))
					{
						for (;;)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							break;
						}
						if (\u0008\u0013\u000A.\u000A(\u0020\u0013\u0007.\u001D(this), \u0020\u0013\u0007.\u0007(u001F)))
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
							return \u000E\u000F\u0007.\u001D(this) == \u000E\u000F\u0007.\u0007(u001F);
						}
					}
					return false;
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

		// Token: 0x06000574 RID: 1396 RVA: 0x00020040 File Offset: 0x0001E240
		public override int GetHashCode()
		{
			long num = \u0015\u001F\u001D.\u001D(this);
			int num2 = \u0007\u000A\u001D.\u000A(ref num);
			string text = \u0020\u0013\u0007.\u001D(this);
			int? num3;
			int? num4;
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingParameter.GetHashCode()).MethodHandle;
				}
				\u000B\u0007\u000E.\u001F(ref num3);
				num4 = num3;
			}
			else
			{
				num4 = new int?(\u001B\u0013\u000A.\u000A(text));
			}
			int? num5 = num4;
			int? num6;
			if (!\u000A\u000A\u001D.\u000A(ref num5))
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
				\u000B\u0007\u000E.\u001F(ref num3);
				num6 = num3;
			}
			else
			{
				num6 = new int?(num2 ^ \u0009\u001F\u001D.\u000A(ref num5));
			}
			int? num7 = num6;
			if (!\u000A\u000A\u001D.\u000A(ref num7))
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
				int num8 = 0;
				num2 = \u000E\u000F\u0007.\u001D(this);
				return num8 ^ \u001F\u000A\u001D.\u000A(ref num2);
			}
			return \u0009\u001F\u001D.\u000A(ref num7);
		}
	}
}
