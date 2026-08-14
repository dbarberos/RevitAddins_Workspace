using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x02000041 RID: 65
	internal class \u0002\u000A
	{
		// Token: 0x0600020A RID: 522 RVA: 0x0000A6F8 File Offset: 0x000088F8
		public \u0002\u000A(XYZ \u001F, XYZ \u000A, bool \u0007 = false)
		{
			if (\u0007)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u000A..ctor(XYZ, XYZ, bool)).MethodHandle;
				}
				this.\u0018(\u001F, \u000A);
				this.\u0005();
			}
			else if (\u0016\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u001F), 5) == \u0016\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u000A), 5))
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
				\u000F\u001F\u0007.\u0007(this, 1.0);
				\u0002\u001F\u0007.\u0007(this, 0.0);
				\u0005\u001F\u0007.\u0007(this, -\u000D\u001F\u0007.\u000A(\u001F));
				\u0003\u001F\u0007.\u000A(this, double.PositiveInfinity);
			}
			else
			{
				double num = (\u001C\u001F\u0007.\u000A(\u000A) - \u001C\u001F\u0007.\u000A(\u001F)) / (\u000D\u001F\u0007.\u000A(\u000A) - \u000D\u001F\u0007.\u000A(\u001F));
				double num2 = \u001C\u001F\u0007.\u000A(\u001F) - num * \u000D\u001F\u0007.\u000A(\u001F);
				num = \u0016\u001F\u0007.\u000A(num, 5);
				num2 = \u0016\u001F\u0007.\u000A(num2, 5);
				if (num > 0.0)
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
					\u000F\u001F\u0007.\u0007(this, -1.0);
					\u0002\u001F\u0007.\u0007(this, num);
					\u0005\u001F\u0007.\u0007(this, -num2);
				}
				else if (num < 0.0)
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
					\u000F\u001F\u0007.\u0007(this, 1.0);
					\u0002\u001F\u0007.\u0007(this, -num);
					\u0005\u001F\u0007.\u0007(this, num2);
				}
				else
				{
					\u000F\u001F\u0007.\u0007(this, 0.0);
					\u0002\u001F\u0007.\u0007(this, 1.0);
					\u0005\u001F\u0007.\u0007(this, -\u001C\u001F\u0007.\u000A(\u001F));
				}
				\u0003\u001F\u0007.\u000A(this, \u0016\u001F\u0007.\u000A(-\u0012\u001F\u0007.\u0007(this) / \u0006\u001F\u0007.\u0007(this), 1));
			}
			\u000F\u001F\u0007.\u0007(this, \u0016\u001F\u0007.\u000A(\u0012\u001F\u0007.\u0007(this), 5));
			\u0002\u001F\u0007.\u0007(this, \u0016\u001F\u0007.\u000A(\u0006\u001F\u0007.\u0007(this), 5));
			\u0005\u001F\u0007.\u0007(this, \u0016\u001F\u0007.\u000A(\u000B\u001F\u0007.\u0007(this), 5));
			\u0004\u001F\u0007.\u000A(this, \u0019\u001F\u0007.\u000A(\u0018\u001F\u0007.\u0007(this)));
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0000A900 File Offset: 0x00008B00
		public \u0002\u000A(Face \u001F)
		{
			XYZ u000A = \u000E\u001F\u0007.\u000A(\u0012\u0009\u0010.\u001F(\u001F));
			XYZ u001F = \u0010\u001F\u0007.\u000A(\u0012\u0009\u0010.\u001F(\u001F));
			this.\u0018(u001F, u000A);
			this.\u0005();
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600020D RID: 525 RVA: 0x0000A960 File Offset: 0x00008B60
		// (set) Token: 0x0600020E RID: 526 RVA: 0x0000A974 File Offset: 0x00008B74
		public double a { get; set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600020F RID: 527 RVA: 0x0000A988 File Offset: 0x00008B88
		// (set) Token: 0x06000210 RID: 528 RVA: 0x0000A99C File Offset: 0x00008B9C
		public double b { get; set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000211 RID: 529 RVA: 0x0000A9B0 File Offset: 0x00008BB0
		// (set) Token: 0x06000212 RID: 530 RVA: 0x0000A9C4 File Offset: 0x00008BC4
		public double c { get; set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000213 RID: 531 RVA: 0x0000A9D8 File Offset: 0x00008BD8
		// (set) Token: 0x06000214 RID: 532 RVA: 0x0000A9EC File Offset: 0x00008BEC
		public double Slope { get; set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000215 RID: 533 RVA: 0x0000AA00 File Offset: 0x00008C00
		// (set) Token: 0x06000216 RID: 534 RVA: 0x0000AA14 File Offset: 0x00008C14
		public double Angle { get; set; }

		// Token: 0x06000217 RID: 535 RVA: 0x0000AA28 File Offset: 0x00008C28
		private void \u0018(XYZ \u001F, XYZ \u000A)
		{
			\u000F\u001F\u0007.\u0007(this, \u000D\u001F\u0007.\u000A(\u000A));
			\u0002\u001F\u0007.\u0007(this, \u001C\u001F\u0007.\u000A(\u000A));
			\u0005\u001F\u0007.\u0007(this, \u000D\u001F\u0007.\u000A(\u001F) * \u0012\u001F\u0007.\u0007(this) + \u001C\u001F\u0007.\u000A(\u001F) * \u0006\u001F\u0007.\u0007(this));
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0000AA7C File Offset: 0x00008C7C
		private void \u0005()
		{
			double num;
			if (\u0008\u001F\u0007.\u000A(\u0012\u001F\u0007.\u0007(this)) <= \u0002\u000A.\u001F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u000A.\u0005()).MethodHandle;
				}
				if (\u0008\u001F\u0007.\u000A(\u0006\u001F\u0007.\u0007(this)) >= \u0002\u000A.\u001F)
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
					num = \u0006\u001F\u0007.\u0007(this);
					goto IL_EF;
				}
			}
			if (\u0008\u001F\u0007.\u000A(\u0012\u001F\u0007.\u0007(this)) >= \u0002\u000A.\u001F)
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
				if (\u0008\u001F\u0007.\u000A(\u0006\u001F\u0007.\u0007(this)) <= \u0002\u000A.\u001F)
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
					num = \u0012\u001F\u0007.\u0007(this);
					goto IL_EF;
				}
			}
			double num2;
			if (\u0008\u001F\u0007.\u000A(\u0016\u001F\u0007.\u000A(\u0012\u001F\u0007.\u0007(this), 6)) >= \u0008\u001F\u0007.\u000A(\u0016\u001F\u0007.\u000A(\u0006\u001F\u0007.\u0007(this), 6)))
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
				num2 = \u0006\u001F\u0007.\u0007(this);
			}
			else
			{
				num2 = \u0012\u001F\u0007.\u0007(this);
			}
			num = num2;
			IL_EF:
			\u000F\u001F\u0007.\u0007(this, \u0012\u001F\u0007.\u0007(this) / num);
			\u0002\u001F\u0007.\u0007(this, \u0006\u001F\u0007.\u0007(this) / num);
			\u0005\u001F\u0007.\u0007(this, \u000B\u001F\u0007.\u0007(this) / num);
			\u000F\u001F\u0007.\u0007(this, \u0016\u001F\u0007.\u000A(\u0012\u001F\u0007.\u0007(this), 6));
			\u0002\u001F\u0007.\u0007(this, \u0016\u001F\u0007.\u000A(\u0006\u001F\u0007.\u0007(this), 6));
			\u0005\u001F\u0007.\u0007(this, \u0016\u001F\u0007.\u000A(\u000B\u001F\u0007.\u0007(this), 6));
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000ABEC File Offset: 0x00008DEC
		public bool \u0016(\u0002\u000A \u001F, double \u000A = 0.0001)
		{
			if (\u0008\u001F\u0007.\u000A(\u0012\u001F\u0007.\u001D(\u001F) - \u0012\u001F\u0007.\u0007(this)) <= \u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u000A.\u0016(\u0002\u000A, double)).MethodHandle;
				}
				if (\u0008\u001F\u0007.\u000A(\u0006\u001F\u0007.\u001D(\u001F) - \u0006\u001F\u0007.\u0007(this)) <= \u000A)
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
					if (\u0008\u001F\u0007.\u000A(\u000B\u001F\u0007.\u001D(\u001F) - \u000B\u001F\u0007.\u0007(this)) <= \u000A)
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
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000AC74 File Offset: 0x00008E74
		internal static XYZ \u000B(\u0002\u000A \u001F, \u0002\u000A \u000A)
		{
			double num = \u0012\u001F\u0007.\u001D(\u001F) * \u0006\u001F\u0007.\u001D(\u000A) - \u0012\u001F\u0007.\u001D(\u000A) * \u0006\u001F\u0007.\u001D(\u001F);
			if (\u0008\u001F\u0007.\u000A(num) <= \u0002\u000A.\u001F)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u000A.\u000B(\u0002\u000A, \u0002\u000A)).MethodHandle;
				}
				return null;
			}
			double u001F = (\u0006\u001F\u0007.\u001D(\u000A) * \u000B\u001F\u0007.\u001D(\u001F) - \u0006\u001F\u0007.\u001D(\u001F) * \u000B\u001F\u0007.\u001D(\u000A)) / num;
			double u000A = (\u0012\u001F\u0007.\u001D(\u001F) * \u000B\u001F\u0007.\u001D(\u000A) - \u0012\u001F\u0007.\u001D(\u000A) * \u000B\u001F\u0007.\u001D(\u001F)) / num;
			return \u001B\u001F\u0007.\u000A(u001F, u000A, 0.0);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000AD28 File Offset: 0x00008F28
		internal static double \u0002(\u0002\u000A \u001F, double \u000A)
		{
			return \u000B\u001F\u0007.\u001D(\u001F) + \u000A * \u0011\u001F\u0007.\u000A(\u0012\u001F\u0007.\u001D(\u001F) * \u0012\u001F\u0007.\u001D(\u001F) + \u0006\u001F\u0007.\u001D(\u001F) * \u0006\u001F\u0007.\u001D(\u001F));
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000AD6C File Offset: 0x00008F6C
		internal static \u0002\u000A \u0006(\u0002\u000A \u001F, double \u000A)
		{
			\u0002\u000A u0002_u000A = \u0002\u000A.\u001C(\u001F);
			\u0005\u001F\u0007.\u001D(u0002_u000A, \u000B\u001F\u0007.\u001D(\u001F) + \u000A * \u0011\u001F\u0007.\u000A(\u0012\u001F\u0007.\u001D(\u001F) * \u0012\u001F\u0007.\u001D(\u001F) + \u0006\u001F\u0007.\u001D(\u001F) * \u0006\u001F\u0007.\u001D(\u001F)));
			return u0002_u000A;
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000ADBC File Offset: 0x00008FBC
		internal static double \u000F(\u0002\u000A \u001F, double \u000A)
		{
			return \u000B\u001F\u0007.\u001D(\u001F) - \u000A * \u0011\u001F\u0007.\u000A(\u0012\u001F\u0007.\u001D(\u001F) * \u0012\u001F\u0007.\u001D(\u001F) + \u0006\u001F\u0007.\u001D(\u001F) * \u0006\u001F\u0007.\u001D(\u001F));
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000AE00 File Offset: 0x00009000
		internal static \u0002\u000A \u0012(\u0002\u000A \u001F, double \u000A)
		{
			\u0002\u000A u0002_u000A = \u0002\u000A.\u001C(\u001F);
			\u0005\u001F\u0007.\u001D(u0002_u000A, \u000B\u001F\u0007.\u001D(\u001F) - \u000A * \u0011\u001F\u0007.\u000A(\u0012\u001F\u0007.\u001D(\u001F) * \u0012\u001F\u0007.\u001D(\u001F) + \u0006\u001F\u0007.\u001D(\u001F) * \u0006\u001F\u0007.\u001D(\u001F)));
			return u0002_u000A;
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0000AE50 File Offset: 0x00009050
		internal static double \u0003(\u0002\u000A \u001F, \u0002\u000A \u000A)
		{
			return \u0008\u001F\u0007.\u000A(\u000B\u001F\u0007.\u001D(\u001F) - \u000B\u001F\u0007.\u001D(\u000A)) / \u0011\u001F\u0007.\u000A(\u0012\u001F\u0007.\u001D(\u001F) * \u0012\u001F\u0007.\u001D(\u001F) + \u0006\u001F\u0007.\u001D(\u001F) * \u0006\u001F\u0007.\u001D(\u001F));
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0000AEA0 File Offset: 0x000090A0
		private static \u0002\u000A \u001C(\u0002\u000A \u001F)
		{
			\u0002\u000A u0002_u000A = new \u0002\u000A(\u001B\u001F\u0007.\u000A(0.0, 0.0, 0.0), \u001B\u001F\u0007.\u000A(1.0, 0.0, 0.0), false);
			\u000F\u001F\u0007.\u001D(u0002_u000A, \u0012\u001F\u0007.\u001D(\u001F));
			\u0002\u001F\u0007.\u001D(u0002_u000A, \u0006\u001F\u0007.\u001D(\u001F));
			\u0005\u001F\u0007.\u001D(u0002_u000A, \u000B\u001F\u0007.\u001D(\u001F));
			return u0002_u000A;
		}

		// Token: 0x040000EA RID: 234
		private static readonly double \u001F = 1E-06;

		// Token: 0x040000EB RID: 235
		[CompilerGenerated]
		private double \u000A;

		// Token: 0x040000EC RID: 236
		[CompilerGenerated]
		private double \u0007;

		// Token: 0x040000ED RID: 237
		[CompilerGenerated]
		private double \u001D;

		// Token: 0x040000EE RID: 238
		[CompilerGenerated]
		private double \u0004;

		// Token: 0x040000EF RID: 239
		[CompilerGenerated]
		private double \u0019;
	}
}
