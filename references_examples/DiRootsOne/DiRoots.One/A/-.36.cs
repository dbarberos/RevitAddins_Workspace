using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media.Media3D;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x02000049 RID: 73
	internal class \u0011\u000A : \u001E\u000A
	{
		// Token: 0x06000254 RID: 596 RVA: 0x0000BE50 File Offset: 0x0000A050
		public \u0011\u000A()
		{
			this.\u000A = new List<Line>();
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000BE80 File Offset: 0x0000A080
		internal \u0011\u000A(IList<XYZ> \u001F)
		{
			\u0002\u000A\u0007.\u000A(this.\u001D, \u001F);
			this.\u000A = new List<Line>();
			for (int i = 0; i < \u000F\u000A\u0007.\u000A(this.\u001D); i++)
			{
				int num = i + 1;
				if (num >= \u000F\u000A\u0007.\u000A(this.\u001D))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u000A..ctor(IList<XYZ>)).MethodHandle;
					}
					num = 0;
				}
				if (\u0006\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, i), \u0016\u000A\u0007.\u000A(this.\u001D, num)) > this.\u0007)
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
					\u000B\u0007\u0007.\u000A(this.\u000A, \u0002\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, i), \u0016\u000A\u0007.\u000A(this.\u001D, num)));
				}
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

		// Token: 0x06000256 RID: 598 RVA: 0x0000BF70 File Offset: 0x0000A170
		internal \u0011\u000A(IEnumerable<Line> \u001F)
		{
			this.\u000A = Enumerable.ToList<Line>(\u001F);
			this.\u001D = this.\u000A.\u0007();
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000257 RID: 599 RVA: 0x0000BFB4 File Offset: 0x0000A1B4
		public double \u000B
		{
			get
			{
				return \u0017\u000A.\u001D(\u0016\u000A\u0007.\u000A(this.\u001D, 0), \u0016\u000A\u0007.\u000A(this.\u001D, 1));
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000258 RID: 600 RVA: 0x0000BFE4 File Offset: 0x0000A1E4
		public double \u0002
		{
			get
			{
				return \u0017\u000A.\u001D(\u0016\u000A\u0007.\u000A(this.\u001D, 1), \u0016\u000A\u0007.\u000A(this.\u001D, 2));
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000259 RID: 601 RVA: 0x0000C014 File Offset: 0x0000A214
		public List<Line> \u0006
		{
			get
			{
				return this.\u000A;
			}
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000C028 File Offset: 0x0000A228
		public \u0011\u000A \u0019(Vector3D \u001F)
		{
			for (int i = 0; i < \u000F\u000A\u0007.\u000A(this.\u001D); i++)
			{
				\u0008\u000A\u0007.\u000A(this.\u001D, i, \u001B\u000A\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, i).\u0004(), \u001F).\u0019());
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u000A.\u0019(Vector3D)).MethodHandle;
			}
			return this;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000C094 File Offset: 0x0000A294
		public \u0011\u000A \u0019(XYZ \u001F)
		{
			for (int i = 0; i < \u000F\u000A\u0007.\u000A(this.\u001D); i++)
			{
				\u0008\u000A\u0007.\u000A(this.\u001D, i, \u000F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, i), \u001F));
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u000A.\u0019(XYZ)).MethodHandle;
			}
			return this;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000C0F0 File Offset: 0x0000A2F0
		public \u0011\u000A \u0018(double \u001F)
		{
			List<XYZ> u001F = \u000B\u000A\u0007.\u000A();
			int num = \u000F\u000A\u0007.\u000A(this.\u001D);
			for (int i = 0; i < num; i++)
			{
				int num2 = i - 1;
				if (num2 < 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u000A.\u0018(double)).MethodHandle;
					}
					num2 += num;
				}
				int u000A = (i + 1) % num;
				XYZ u001F2 = \u001F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, i), \u0016\u000A\u0007.\u000A(this.\u001D, num2));
				\u0007\u000A\u0007.\u000A(u001F2);
				XYZ u000A2 = \u0012\u0007\u0007.\u000A(\u0003\u0007\u0007.\u000A(u001F2, \u001F), base.\u0008());
				XYZ u = \u000F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, num2), u000A2);
				XYZ u001D = \u000F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, i), u000A2);
				XYZ u000A3 = \u0012\u0007\u0007.\u000A(\u0003\u0007\u0007.\u000A(\u0007\u000A\u0007.\u000A(\u001F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, u000A), \u0016\u000A\u0007.\u000A(this.\u001D, i))), \u001F), base.\u0008());
				XYZ u2 = \u000F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, i), u000A3);
				XYZ u3 = \u000F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, u000A), u000A3);
				XYZ u000A4;
				XYZ xyz;
				\u0017\u000A.\u0007(out u000A4, out xyz, u, u001D, u2, u3);
				\u0005\u000A\u0007.\u000A(u001F, u000A4);
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
			return new \u0011\u000A(u001F);
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000C268 File Offset: 0x0000A468
		public \u0011\u000A \u0018(double \u001F, double \u000A, double \u0007, double \u001D)
		{
			List<XYZ> u001F = \u000B\u000A\u0007.\u000A();
			List<double> list = \u0010\u0007\u0007.\u000A();
			\u000D\u0007\u0007.\u000A(list, \u001F);
			\u000D\u0007\u0007.\u000A(list, \u000A);
			\u000D\u0007\u0007.\u000A(list, \u0007);
			\u000D\u0007\u0007.\u000A(list, \u001D);
			List<double> u001F2 = list;
			int num = \u000F\u000A\u0007.\u000A(this.\u001D);
			for (int i = 0; i < num; i++)
			{
				int num2 = i - 1;
				if (num2 < 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u000A.\u0018(double, double, double, double)).MethodHandle;
					}
					num2 += num;
				}
				int u000A = (i + 1) % num;
				double u000A2 = \u001C\u0007\u0007.\u000A(u001F2, i);
				double u000A3 = \u001C\u0007\u0007.\u000A(u001F2, u000A);
				XYZ u000A4 = \u0012\u0007\u0007.\u000A(\u0003\u0007\u0007.\u000A(\u0007\u000A\u0007.\u000A(\u001F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, i), \u0016\u000A\u0007.\u000A(this.\u001D, num2))), u000A2), base.\u0008());
				XYZ u = \u000F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, num2), u000A4);
				XYZ u001D = \u000F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, i), u000A4);
				XYZ u000A5 = \u0012\u0007\u0007.\u000A(\u0003\u0007\u0007.\u000A(\u0007\u000A\u0007.\u000A(\u001F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, u000A), \u0016\u000A\u0007.\u000A(this.\u001D, i))), u000A3), base.\u0008());
				XYZ u2 = \u000F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, i), u000A5);
				XYZ u3 = \u000F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, u000A), u000A5);
				XYZ u000A6;
				XYZ xyz;
				\u0017\u000A.\u0007(out u000A6, out xyz, u, u001D, u2, u3);
				\u0005\u000A\u0007.\u000A(u001F, u000A6);
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
			return new \u0011\u000A(u001F);
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000C420 File Offset: 0x0000A620
		public \u0011\u000A \u0018(double \u001F, double \u000A, double \u0007, double \u001D, double \u0004, double \u0019)
		{
			List<XYZ> u001F = \u000B\u000A\u0007.\u000A();
			List<double> list = \u0010\u0007\u0007.\u000A();
			\u000D\u0007\u0007.\u000A(list, \u001F);
			\u000D\u0007\u0007.\u000A(list, \u000A);
			\u000D\u0007\u0007.\u000A(list, \u0007);
			\u000D\u0007\u0007.\u000A(list, \u0019);
			\u000D\u0007\u0007.\u000A(list, \u0004);
			\u000D\u0007\u0007.\u000A(list, \u001D);
			List<double> u001F2 = list;
			int num = \u000F\u000A\u0007.\u000A(this.\u001D);
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				int num3 = i - 1;
				if (num3 < 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u000A.\u0018(double, double, double, double, double, double)).MethodHandle;
					}
					num3 += num;
				}
				int u000A = (i + 1) % num;
				if (i == num / 2)
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
					num2++;
				}
				double u000A2 = \u001C\u0007\u0007.\u000A(u001F2, num2);
				double u000A3 = \u001C\u0007\u0007.\u000A(u001F2, num2 + 1);
				XYZ u000A4 = \u0012\u0007\u0007.\u000A(\u0003\u0007\u0007.\u000A(\u0007\u000A\u0007.\u000A(\u001F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, i), \u0016\u000A\u0007.\u000A(this.\u001D, num3))), u000A2), base.\u0008());
				XYZ u = \u000F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, num3), u000A4);
				XYZ u001D = \u000F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, i), u000A4);
				XYZ u000A5 = \u0012\u0007\u0007.\u000A(\u0003\u0007\u0007.\u000A(\u0007\u000A\u0007.\u000A(\u001F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, u000A), \u0016\u000A\u0007.\u000A(this.\u001D, i))), u000A3), base.\u0008());
				XYZ u2 = \u000F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, i), u000A5);
				XYZ u3 = \u000F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, u000A), u000A5);
				XYZ u000A6;
				XYZ xyz;
				\u0017\u000A.\u0007(out u000A6, out xyz, u, u001D, u2, u3);
				\u0005\u000A\u0007.\u000A(u001F, u000A6);
				num2++;
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
			return new \u0011\u000A(u001F);
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000C610 File Offset: 0x0000A810
		public \u0011\u000A \u0005(double \u001F)
		{
			\u0011\u000A.\u0008\u000A u0008_u000A = new \u0011\u000A.\u0008\u000A();
			u0008_u000A.\u001F = \u001F;
			u0008_u000A.\u000A = this;
			return new \u0011\u000A(Enumerable.ToList<XYZ>(Enumerable.Select<XYZ, XYZ>(this.\u001D, new Func<XYZ, XYZ>(u0008_u000A.\u0007))));
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000C658 File Offset: 0x0000A858
		public \u0011\u000A \u0016(double \u001F, XYZ \u000A)
		{
			\u0011\u000A.\u001B\u000A u001B_u000A = new \u0011\u000A.\u001B\u000A();
			u001B_u000A.\u001F = \u001F;
			u001B_u000A.\u000A = \u000A;
			return new \u0011\u000A(Enumerable.ToList<XYZ>(Enumerable.Select<XYZ, XYZ>(base.\u0010, new Func<XYZ, XYZ>(u001B_u000A.\u0007))));
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000C6A0 File Offset: 0x0000A8A0
		public XYZ \u000F()
		{
			IEnumerable<XYZ> u = base.\u0010;
			Func<XYZ, double> func;
			if ((func = \u0011\u000A.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u000A.\u000F()).MethodHandle;
				}
				func = (\u0011\u000A.<>c.\u000A = new Func<XYZ, double>(\u0011\u000A.<>c.\u001F.\u0003));
			}
			double u001F = Enumerable.Sum<XYZ>(u, func) / 4.0;
			IEnumerable<XYZ> u2 = base.\u0010;
			Func<XYZ, double> func2;
			if ((func2 = \u0011\u000A.<>c.\u0007) == null)
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
				func2 = (\u0011\u000A.<>c.\u0007 = new Func<XYZ, double>(\u0011\u000A.<>c.\u001F.\u001C));
			}
			double u000A = Enumerable.Sum<XYZ>(u2, func2) / 4.0;
			return \u001B\u001F\u0007.\u000A(u001F, u000A, 0.0);
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000C74C File Offset: 0x0000A94C
		public XYZ \u0012()
		{
			IEnumerable<XYZ> u = base.\u0010;
			Func<XYZ, double> func;
			if ((func = \u0011\u000A.<>c.\u001D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u000A.\u0012()).MethodHandle;
				}
				func = (\u0011\u000A.<>c.\u001D = new Func<XYZ, double>(\u0011\u000A.<>c.\u001F.\u000D));
			}
			double u001F = Enumerable.Sum<XYZ>(u, func) / 4.0;
			IEnumerable<XYZ> u2 = base.\u0010;
			Func<XYZ, double> func2;
			if ((func2 = \u0011\u000A.<>c.\u0004) == null)
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
				func2 = (\u0011\u000A.<>c.\u0004 = new Func<XYZ, double>(\u0011\u000A.<>c.\u001F.\u0010));
			}
			double u000A = Enumerable.Sum<XYZ>(u2, func2) / 4.0;
			IEnumerable<XYZ> u3 = base.\u0010;
			Func<XYZ, double> func3;
			if ((func3 = \u0011\u000A.<>c.\u0019) == null)
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
				func3 = (\u0011\u000A.<>c.\u0019 = new Func<XYZ, double>(\u0011\u000A.<>c.\u001F.\u000E));
			}
			double u4 = Enumerable.Sum<XYZ>(u3, func3) / 4.0;
			return \u001B\u001F\u0007.\u000A(u001F, u000A, u4);
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000C834 File Offset: 0x0000AA34
		public bool \u0003(\u0011\u000A \u001F)
		{
			if (this.\u000D(\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u000A.\u0003(\u0011\u000A)).MethodHandle;
				}
				return true;
			}
			List<Line> u001F = Enumerable.ToList<Line>(this.\u0006);
			List<Line> u001F2 = Enumerable.ToList<Line>(\u001F.\u0006);
			for (int i = 0; i < \u000E\u0007\u0007.\u0007(u001F); i++)
			{
				for (int j = 0; j < \u000E\u0007\u0007.\u0007(u001F2); j++)
				{
					if (\u0008\u0007\u0007.\u000A(u001F, i).\u000D(\u0008\u0007\u0007.\u000A(u001F2, j)))
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
						return true;
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
			for (;;)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			return false;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000C8E4 File Offset: 0x0000AAE4
		public bool \u001C(\u0011\u000A \u001F)
		{
			List<Line> u001F = Enumerable.ToList<Line>(this.\u0006);
			List<Line> u001F2 = Enumerable.ToList<Line>(\u001F.\u0006);
			for (int i = 0; i < \u000E\u0007\u0007.\u0007(u001F); i++)
			{
				for (int j = 0; j < \u000E\u0007\u0007.\u0007(u001F2); j++)
				{
					if (\u0008\u0007\u0007.\u000A(u001F, i).\u000D(\u0008\u0007\u0007.\u000A(u001F2, j)))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u000A.\u001C(\u0011\u000A)).MethodHandle;
						}
						return true;
					}
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
			for (;;)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			return false;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public bool \u000D(\u0011\u000A \u001F)
		{
			XYZ u001F = this.\u0012();
			XYZ u001F2 = \u001F.\u0012();
			IEnumerable<XYZ> u = base.\u0010;
			Func<XYZ, double> func;
			if ((func = \u0011\u000A.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u000A.\u000D(\u0011\u000A)).MethodHandle;
				}
				func = (\u0011\u000A.<>c.\u0018 = new Func<XYZ, double>(\u0011\u000A.<>c.\u001F.\u0008));
			}
			double num = Enumerable.Min<XYZ>(u, func);
			IEnumerable<XYZ> u2 = base.\u0010;
			Func<XYZ, double> func2;
			if ((func2 = \u0011\u000A.<>c.\u0005) == null)
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
				func2 = (\u0011\u000A.<>c.\u0005 = new Func<XYZ, double>(\u0011\u000A.<>c.\u001F.\u001B));
			}
			double num2 = Enumerable.Min<XYZ>(u2, func2);
			IEnumerable<XYZ> u3 = base.\u0010;
			Func<XYZ, double> func3;
			if ((func3 = \u0011\u000A.<>c.\u0016) == null)
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
				func3 = (\u0011\u000A.<>c.\u0016 = new Func<XYZ, double>(\u0011\u000A.<>c.\u001F.\u0011));
			}
			double num3 = Enumerable.Max<XYZ>(u3, func3);
			IEnumerable<XYZ> u4 = base.\u0010;
			Func<XYZ, double> func4;
			if ((func4 = \u0011\u000A.<>c.\u000B) == null)
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
				func4 = (\u0011\u000A.<>c.\u000B = new Func<XYZ, double>(\u0011\u000A.<>c.\u001F.\u001E));
			}
			double num4 = Enumerable.Max<XYZ>(u4, func4);
			IEnumerable<XYZ> u5 = \u001F.\u0010;
			Func<XYZ, double> func5;
			if ((func5 = \u0011\u000A.<>c.\u0002) == null)
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
				func5 = (\u0011\u000A.<>c.\u0002 = new Func<XYZ, double>(\u0011\u000A.<>c.\u001F.\u0020));
			}
			double num5 = Enumerable.Min<XYZ>(u5, func5);
			IEnumerable<XYZ> u6 = \u001F.\u0010;
			Func<XYZ, double> func6;
			if ((func6 = \u0011\u000A.<>c.\u0006) == null)
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
				func6 = (\u0011\u000A.<>c.\u0006 = new Func<XYZ, double>(\u0011\u000A.<>c.\u001F.\u0017));
			}
			double num6 = Enumerable.Min<XYZ>(u6, func6);
			IEnumerable<XYZ> u7 = \u001F.\u0010;
			Func<XYZ, double> func7;
			if ((func7 = \u0011\u000A.<>c.\u000F) == null)
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
				func7 = (\u0011\u000A.<>c.\u000F = new Func<XYZ, double>(\u0011\u000A.<>c.\u001F.\u0014));
			}
			double num7 = Enumerable.Max<XYZ>(u7, func7);
			IEnumerable<XYZ> u8 = \u001F.\u0010;
			Func<XYZ, double> func8;
			if ((func8 = \u0011\u000A.<>c.\u0012) == null)
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
				func8 = (\u0011\u000A.<>c.\u0012 = new Func<XYZ, double>(\u0011\u000A.<>c.\u001F.\u0013));
			}
			double num8 = Enumerable.Max<XYZ>(u8, func8);
			if (\u000D\u001F\u0007.\u000A(u001F) > num5)
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
				if (\u000D\u001F\u0007.\u000A(u001F) < num7)
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
					if (\u001C\u001F\u0007.\u000A(u001F) > num6)
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
						if (\u001C\u001F\u0007.\u000A(u001F) < num8)
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
							return true;
						}
					}
				}
			}
			if (\u000D\u001F\u0007.\u000A(u001F2) > num)
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
				if (\u000D\u001F\u0007.\u000A(u001F2) < num3)
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
					if (\u001C\u001F\u0007.\u000A(u001F2) > num2)
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
						if (\u001C\u001F\u0007.\u000A(u001F2) < num4)
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
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x040000FF RID: 255
		private readonly List<Line> \u000A;

		// Token: 0x04000100 RID: 256
		private readonly double \u0007 = 0.0328084;

		// Token: 0x02000775 RID: 1909
		[CompilerGenerated]
		private sealed class \u0008\u000A
		{
			// Token: 0x06004AD0 RID: 19152 RVA: 0x001D7C70 File Offset: 0x001D5E70
			internal XYZ \u0007(XYZ \u001F)
			{
				return \u000F\u0007\u0007.\u000A(\u001F, \u0009\u0007\u0007.\u000A(this.\u001F, this.\u000A.\u0008()));
			}

			// Token: 0x04001E01 RID: 7681
			public double \u001F;

			// Token: 0x04001E02 RID: 7682
			public \u0011\u000A \u000A;
		}

		// Token: 0x02000776 RID: 1910
		[CompilerGenerated]
		private sealed class \u001B\u000A
		{
			// Token: 0x06004AD2 RID: 19154 RVA: 0x001D7CB4 File Offset: 0x001D5EB4
			internal XYZ \u0007(XYZ \u001F)
			{
				return \u000F\u0007\u0007.\u000A(\u001F, \u0009\u0007\u0007.\u000A(this.\u001F, this.\u000A));
			}

			// Token: 0x04001E03 RID: 7683
			public double \u001F;

			// Token: 0x04001E04 RID: 7684
			public XYZ \u000A;
		}
	}
}
