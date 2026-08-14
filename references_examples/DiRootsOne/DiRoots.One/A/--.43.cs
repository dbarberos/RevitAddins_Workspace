using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Revit.Extensions;

namespace A
{
	// Token: 0x020000E5 RID: 229
	internal static class \u0018\u0018
	{
		// Token: 0x06000889 RID: 2185 RVA: 0x00034180 File Offset: 0x00032380
		internal static void \u001F(Document \u001F)
		{
			object u001F = Enumerable.ToList<ImageType>(\u001F.GetElements<ImageType>());
			List<ElementId> u001F2 = \u0019\u0018.\u001D(\u001F);
			List<ElementId> list = \u001C\u0013\u000A.\u000A();
			List<ImageType>.Enumerator enumerator = \u0010\u0009\u001D.\u000A(u001F);
			try
			{
				while (\u001C\u0009\u001D.\u000A(ref enumerator))
				{
					ImageType u001F3 = \u000D\u0009\u001D.\u000A(ref enumerator);
					if (\u0014\u001E\u001D.\u000A(\u0005\u001E\u000A.\u000A(u001F3), "TableGen_Import"))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0018.\u001F(Document)).MethodHandle;
						}
						if (\u0014\u000E\u0007.\u000A(u001F2, \u0002\u001E\u000A.\u0007(u001F3)))
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
							\u0003\u0010\u0007.\u000A(list, \u0002\u001E\u000A.\u0007(u001F3));
						}
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
			if (\u001A\u0014\u000A.\u000A(list) > 0)
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
				\u0003\u0009\u001D.\u000A(\u001F, list);
			}
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x00034268 File Offset: 0x00032468
		internal static FilledRegionType \u000A(Document \u001F)
		{
			IEnumerable<FilledRegionType> elements = \u001F.GetElements<FilledRegionType>();
			IEnumerable<FilledRegionType> enumerable = elements;
			Func<FilledRegionType, bool> func;
			if ((func = \u0018\u0018.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0018.\u000A(Document)).MethodHandle;
				}
				func = (\u0018\u0018.<>c.\u000A = new Func<FilledRegionType, bool>(\u0018\u0018.<>c.\u001F.\u001D));
			}
			FilledRegionType filledRegionType = Enumerable.FirstOrDefault<FilledRegionType>(enumerable, func);
			if (filledRegionType == null)
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
				IEnumerator<FilledRegionType> enumerator = \u0017\u0009\u001D.\u000A(elements);
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						if (\u000F\u000C\u001D.\u0007(\u0005\u001E\u000A.\u000A(filledRegionType = \u0020\u0009\u001D.\u000A(enumerator)), "Solid"))
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
							goto IL_B4;
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
					if (enumerator != null)
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
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
				IL_B4:
				if (filledRegionType != null)
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
					filledRegionType = \u0014\u0004\u000E.\u001F(\u001E\u0009\u001D.\u000A(filledRegionType, "TableGenSolid"));
				}
			}
			FillPatternElement fillPatternElement = \u0011\u0009\u001D.\u000A(\u001F, 0, "Solid fill");
			if (fillPatternElement == null)
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
				try
				{
					ElementId u000A = \u001B\u0009\u001D.\u000A(3);
					fillPatternElement = \u0013\u0004\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u001F, u000A));
				}
				catch (Exception u000A2)
				{
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\RevitHelper.cs", "GetFilledRegionType");
				}
			}
			if (fillPatternElement == null)
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
				List<FillPatternElement> u001F = Enumerable.ToList<FillPatternElement>(\u001F.GetElements<FillPatternElement>());
				if (\u0008\u0009\u001D.\u000A(u001F) > 0)
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
					fillPatternElement = \u000E\u0009\u001D.\u000A(u001F, 0);
				}
			}
			if (fillPatternElement != null)
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
				if (filledRegionType != null)
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
					Parameter parameter = \u0016\u0018\u0007.\u0007(filledRegionType, -1002115L);
					if (parameter != null)
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
						\u0019\u0018\u0007.\u000A(parameter, \u0002\u001E\u000A.\u0007(fillPatternElement));
					}
					parameter = \u0016\u0018\u0007.\u0007(filledRegionType, -1002114L);
					if (parameter != null)
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
						\u0019\u0018\u0007.\u000A(parameter, \u0002\u001E\u000A.\u0007(fillPatternElement));
					}
					\u0016\u0018.\u001D(filledRegionType, fillPatternElement);
				}
			}
			return filledRegionType;
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x00034484 File Offset: 0x00032684
		internal static ICollection<ElementId> \u0007(Document \u001F, Document \u000A, ICollection<ElementId> \u0007)
		{
			CopyPasteOptions copyPasteOptions = \u001A\u0009\u001D.\u000A();
			\u0013\u0009\u001D.\u000A(copyPasteOptions, new \u0005\u0018());
			return \u0014\u0009\u001D.\u000A(\u001F, \u0007, \u000A, \u0019\u0005\u0007.\u000A(), copyPasteOptions);
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x000344B8 File Offset: 0x000326B8
		internal static View3D \u001D(Document \u001F)
		{
			View u001F = \u0004\u0013\u000A.\u0007(\u001F);
			if (\u000C\u0009\u001D.\u000A(u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0018.\u001D(Document)).MethodHandle;
				}
				View3D view3D = \u0017\u0004\u000E.\u001F(u001F);
				if (view3D != null)
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
					return view3D;
				}
			}
			IEnumerable<View3D> elements = \u001F.GetElements<View3D>();
			Func<View3D, bool> func;
			if ((func = \u0018\u0018.<>c.\u0007) == null)
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
				func = (\u0018\u0018.<>c.\u0007 = new Func<View3D, bool>(\u0018\u0018.<>c.\u001F.\u0004));
			}
			View3D view3D2 = \u0017\u0004\u000E.\u001F(Enumerable.FirstOrDefault<View3D>(elements, func));
			if (view3D2 != null)
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
				return view3D2;
			}
			return null;
		}
	}
}
