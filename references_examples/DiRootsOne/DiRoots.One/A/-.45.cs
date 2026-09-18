using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.RoomPro.Models;

namespace A
{
	// Token: 0x02000091 RID: 145
	internal class \u000A\u0004 : \u0020\u001D<SpatialElementsSchema>
	{
		// Token: 0x06000647 RID: 1607 RVA: 0x00023104 File Offset: 0x00021304
		public \u000A\u0004(Document \u001F)
		{
			\u0019\u001D\u001D.\u000A(this, \u001F);
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000648 RID: 1608 RVA: 0x00023120 File Offset: 0x00021320
		// (set) Token: 0x06000649 RID: 1609 RVA: 0x00023134 File Offset: 0x00021334
		public Document Document { get; set; }

		// Token: 0x0600064A RID: 1610 RVA: 0x00023148 File Offset: 0x00021348
		public SpatialElementsSchema \u000A()
		{
			\u0011\u0003\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Helpers\\SpatialElementsSchemaLoader.cs", "LoadSchema");
			SpatialElementsSchema u001F = \u0018\u001D\u001D.\u000A(new \u0013\u001D(\u0005\u001D\u001D.\u000A(this)).\u0017());
			SpatialElementsSchema spatialElementsSchema = this.\u0004();
			List<ModelSpatialElement> u000A = Enumerable.ToList<ModelSpatialElement>(Enumerable.OfType<ModelSpatialElement>(\u000E\u0008\u0007.\u0007(spatialElementsSchema)));
			List<ModelSpatialElement> u000A2 = Enumerable.ToList<ModelSpatialElement>(Enumerable.OfType<ModelSpatialElement>(\u0008\u0008\u0007.\u0007(spatialElementsSchema)));
			this.\u0007(u001F, u000A, true);
			this.\u0007(u001F, u000A2, false);
			\u000F\u0012\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Helpers\\SpatialElementsSchemaLoader.cs", "LoadSchema");
			return spatialElementsSchema;
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x000231E8 File Offset: 0x000213E8
		private void \u0007(SpatialElementsSchema \u001F, List<ModelSpatialElement> \u000A, bool \u0007)
		{
			List<ModelSpatialElement> list;
			if (!\u0007)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0004.\u0007(SpatialElementsSchema, List<ModelSpatialElement>, bool)).MethodHandle;
				}
				if (\u001F == null)
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
					list = \u000D\u0007\u000E.\u001F;
				}
				else
				{
					List<ModelSpace> list2 = \u0008\u0008\u0007.\u001D(\u001F);
					if (list2 == null)
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
						list = \u000D\u0007\u000E.\u001F;
					}
					else
					{
						list = Enumerable.ToList<ModelSpatialElement>(Enumerable.OfType<ModelSpatialElement>(list2));
					}
				}
			}
			else if (\u001F == null)
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
				list = \u000D\u0007\u000E.\u001F;
			}
			else
			{
				List<ModelRoom> list3 = \u000E\u0008\u0007.\u001D(\u001F);
				if (list3 == null)
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
					list = \u000D\u0007\u000E.\u001F;
				}
				else
				{
					list = Enumerable.ToList<ModelSpatialElement>(Enumerable.OfType<ModelSpatialElement>(list3));
				}
			}
			List<ModelSpatialElement> list4 = list;
			List<ModelSpatialElement>.Enumerator enumerator = \u0002\u001C\u0007.\u000A(\u000A);
			try
			{
				while (\u0004\u001C\u0007.\u000A(ref enumerator))
				{
					\u000A\u0004.\u001F\u0004 u001F_u = new \u000A\u0004.\u001F\u0004();
					u001F_u.\u001F = \u000B\u001C\u0007.\u000A(ref enumerator);
					ModelSpatialElement u000A;
					if ((u000A = \u0002\u001D\u001D.\u000A(u001F_u.\u001F)) == null)
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
						if (\u001F != null)
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
							if (list4 != null)
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
								if (\u000B\u001D\u001D.\u000A(list4, new Predicate<ModelSpatialElement>(u001F_u.\u000A)))
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
									u000A = \u0016\u001D\u001D.\u000A(list4, new Predicate<ModelSpatialElement>(u001F_u.\u0007));
								}
							}
						}
					}
					this.\u001D(u001F_u.\u001F, u000A);
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x00023364 File Offset: 0x00021564
		private void \u001D(ModelSpatialElement \u001F, ModelSpatialElement \u000A)
		{
			if (\u000A == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0004.\u001D(ModelSpatialElement, ModelSpatialElement)).MethodHandle;
				}
				return;
			}
			\u0013\u0010\u0007.\u000A(\u001F, \u0012\u001D\u001D.\u000A(\u000A));
			\u0005\u0010\u0007.\u000A(\u001F, \u000F\u001D\u001D.\u000A(\u000A));
			\u0019\u001C\u0007.\u000A(\u001F, \u0016\u000D\u0007.\u000A(\u000A));
			\u0006\u001D\u001D.\u000A(\u001F, \u0011\u0008\u0007.\u000A(\u000A));
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x000233C0 File Offset: 0x000215C0
		private SpatialElementsSchema \u0004()
		{
			\u0013\u001D u0013_u001D = new \u0013\u001D(\u0005\u001D\u001D.\u000A(this));
			SpatialElementsSchema spatialElementsSchema = \u000E\u001D\u001D.\u000A();
			List<ModelRoom> list = u0013_u001D.\u0005();
			List<ModelRoom> list2;
			if (list == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0004.\u0004()).MethodHandle;
				}
				list2 = null;
			}
			else
			{
				list2 = Enumerable.ToList<ModelRoom>(list);
			}
			List<ModelRoom> u000A;
			if ((u000A = list2) == null)
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
				u000A = \u0010\u001D\u001D.\u000A();
			}
			\u000D\u001D\u001D.\u000A(spatialElementsSchema, u000A);
			List<ModelSpace> list3 = u0013_u001D.\u0016();
			List<ModelSpace> list4;
			if (list3 == null)
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
				list4 = null;
			}
			else
			{
				list4 = Enumerable.ToList<ModelSpace>(list3);
			}
			List<ModelSpace> u000A2;
			if ((u000A2 = list4) == null)
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
				u000A2 = \u001C\u001D\u001D.\u000A();
			}
			\u0003\u001D\u001D.\u000A(spatialElementsSchema, u000A2);
			return spatialElementsSchema;
		}

		// Token: 0x04000261 RID: 609
		[CompilerGenerated]
		private Document \u001F;

		// Token: 0x020007BF RID: 1983
		[CompilerGenerated]
		private sealed class \u001F\u0004
		{
			// Token: 0x06004C6F RID: 19567 RVA: 0x001DC2F4 File Offset: 0x001DA4F4
			internal bool \u000A(ModelSpatialElement \u001F)
			{
				return \u0018\u0018\u0007.\u0007(\u001F) == \u0018\u0018\u0007.\u0007(this.\u001F);
			}

			// Token: 0x06004C70 RID: 19568 RVA: 0x001DC318 File Offset: 0x001DA518
			internal bool \u0007(ModelSpatialElement \u001F)
			{
				return \u0018\u0018\u0007.\u0007(\u001F) == \u0018\u0018\u0007.\u0007(this.\u001F);
			}

			// Token: 0x04001F82 RID: 8066
			public ModelSpatialElement \u001F;
		}
	}
}
