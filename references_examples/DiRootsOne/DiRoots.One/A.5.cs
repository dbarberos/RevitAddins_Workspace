using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media.Media3D;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x02000046 RID: 70
	internal class \u000D\u000A : \u001E\u000A
	{
		// Token: 0x06000243 RID: 579 RVA: 0x0000B828 File Offset: 0x00009A28
		public \u000D\u000A(IEnumerable<Arc> \u001F)
		{
			this.\u001F = Enumerable.ToList<Arc>(\u001F);
			this.\u001D = this.\u001F.\u0007();
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000B85C File Offset: 0x00009A5C
		public \u000D\u000A(List<XYZ> \u001F)
		{
			\u0002\u000A\u0007.\u000A(this.\u001D, \u001F);
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000245 RID: 581 RVA: 0x0000B87C File Offset: 0x00009A7C
		public List<Arc> \u0004
		{
			get
			{
				return this.\u001F;
			}
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000B890 File Offset: 0x00009A90
		public \u000D\u000A \u0019(Vector3D \u001F)
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u000A.\u0019(Vector3D)).MethodHandle;
			}
			return this;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000B8FC File Offset: 0x00009AFC
		public \u000D\u000A \u0018(double \u001F)
		{
			List<Arc> u001F = \u0009\u000A\u0007.\u000A();
			List<Arc>.Enumerator enumerator = \u0001\u000A\u0007.\u000A(this.\u001F);
			try
			{
				while (\u0011\u000A\u0007.\u000A(ref enumerator))
				{
					Arc u001F2 = \u0015\u000A\u0007.\u000A(ref enumerator);
					double num = \u000C\u000A\u0007.\u000A(u001F2);
					XYZ u001F3 = \u001A\u000A\u0007.\u000A(u001F2);
					double u000A = num - \u001F;
					try
					{
						Arc u000A2 = \u0017\u000A\u0007.\u000A(u001F3, u000A, 0.0, 3.141592653589793, \u0013\u000A\u0007.\u000A(u001F2), \u0014\u000A\u0007.\u000A(u001F2));
						\u0020\u000A\u0007.\u000A(u001F, u000A2);
					}
					catch (Exception u000A3)
					{
						\u000D\u0011\u000A.\u0007(\u001E\u000A\u0007.\u000A(), u000A3, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\SpatialElementViews\\Helpers\\Polygon\\ArcedPolygon.cs", "Offset");
					}
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u000A.\u0018(double)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return new \u000D\u000A(u001F);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000B9E8 File Offset: 0x00009BE8
		public \u000D\u000A \u0005(double \u001F)
		{
			List<Arc> u001F = \u0009\u000A\u0007.\u000A();
			List<Arc>.Enumerator enumerator = \u0001\u000A\u0007.\u000A(this.\u001F);
			try
			{
				while (\u0011\u000A\u0007.\u000A(ref enumerator))
				{
					Arc u001F2 = \u0015\u000A\u0007.\u000A(ref enumerator);
					double num = \u000C\u000A\u0007.\u000A(u001F2);
					XYZ u001F3 = \u001F\u0007\u0007.\u000A(\u001A\u000A\u0007.\u000A(u001F2), \u001B\u001F\u0007.\u000A(0.0, 0.0, \u001F));
					double u000A = num;
					try
					{
						Arc u000A2 = \u0017\u000A\u0007.\u000A(u001F3, u000A, 0.0, 3.141592653589793, \u0013\u000A\u0007.\u000A(u001F2), \u0014\u000A\u0007.\u000A(u001F2));
						\u0020\u000A\u0007.\u000A(u001F, u000A2);
					}
					catch (Exception u000A3)
					{
						\u000D\u0011\u000A.\u0007(\u001E\u000A\u0007.\u000A(), u000A3, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\SpatialElementViews\\Helpers\\Polygon\\ArcedPolygon.cs", "OffsetAlongNormal");
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u000A.\u0005(double)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return new \u000D\u000A(u001F);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000BAF8 File Offset: 0x00009CF8
		public \u000D\u000A \u0016(double \u001F, XYZ \u000A)
		{
			\u000D\u000A.\u001C\u000A u001C_u000A = new \u000D\u000A.\u001C\u000A();
			u001C_u000A.\u001F = \u001F;
			u001C_u000A.\u000A = \u000A;
			return new \u000D\u000A(Enumerable.ToList<XYZ>(Enumerable.Select<XYZ, XYZ>(base.\u0010, new Func<XYZ, XYZ>(u001C_u000A.\u0007))));
		}

		// Token: 0x040000FC RID: 252
		private readonly List<Arc> \u001F;

		// Token: 0x02000773 RID: 1907
		[CompilerGenerated]
		private sealed class \u001C\u000A
		{
			// Token: 0x06004ABF RID: 19135 RVA: 0x001D7ACC File Offset: 0x001D5CCC
			internal XYZ \u0007(XYZ \u001F)
			{
				return \u000F\u0007\u0007.\u000A(\u001F, \u0009\u0007\u0007.\u000A(this.\u001F, this.\u000A));
			}

			// Token: 0x04001DF1 RID: 7665
			public double \u001F;

			// Token: 0x04001DF2 RID: 7666
			public XYZ \u000A;
		}
	}
}
