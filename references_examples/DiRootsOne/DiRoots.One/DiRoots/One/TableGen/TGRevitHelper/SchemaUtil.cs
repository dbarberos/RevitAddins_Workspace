using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.Dto;

namespace DiRoots.One.TableGen.TGRevitHelper
{
	// Token: 0x02000135 RID: 309
	public static class SchemaUtil
	{
		// Token: 0x06000B94 RID: 2964 RVA: 0x00049540 File Offset: 0x00047740
		internal static Schema \u001F(bool \u001F = true)
		{
			Guid u001F;
			\u0003\u001A\u0004.\u000A(ref u001F, \u0004\u0002.\u0018);
			Schema schema = \u0012\u001A\u0004.\u000A(u001F);
			if (\u001F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SchemaUtil.\u001F(bool)).MethodHandle;
				}
				if (schema == null)
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
					SchemaBuilder u001F2 = \u000F\u001A\u0004.\u000A(u001F);
					\u0006\u001A\u0004.\u000A(u001F2, 1);
					\u0016\u001A\u0004.\u000A(\u0002\u001A\u0004.\u000A(u001F2, "Filename", \u001E\u0011\u000A.\u000A(\u001A\u0001\u0010.\u001F())), "File name");
					\u0016\u001A\u0004.\u000A(\u0002\u001A\u0004.\u000A(u001F2, "Folder", \u001E\u0011\u000A.\u000A(\u001A\u0001\u0010.\u001F())), "Original file folder path");
					\u0016\u001A\u0004.\u000A(\u000B\u001A\u0004.\u000A(u001F2, "Data", \u001E\u0011\u000A.\u000A(\u0005\u0018\u000E.\u001F())), "Stored file data");
					\u0005\u001A\u0004.\u000A(u001F2, \u0004\u0002.\u0005);
					schema = \u0018\u001A\u0004.\u000A(u001F2);
				}
			}
			return schema;
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x00049630 File Offset: 0x00047830
		internal static void \u000A(Element \u001F, DiRoots.One.TGDatabaseLayer.SelectedExcel \u000A)
		{
			SchemaUtil.\u000A(\u001F, \u0003\u0017\u0004.\u000A(\u000A));
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x0004964C File Offset: 0x0004784C
		internal static void \u000A(Element \u001F, DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel \u000A)
		{
			try
			{
				Schema u001F = SchemaUtil.\u001F(true);
				List<DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel> list = \u001C\u0017\u0004.\u000A();
				\u0012\u0017\u0004.\u000A(list, \u000A);
				List<DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel> u = list;
				XmlSerializer u001F2 = \u0008\u001A\u0004.\u000A(\u001E\u0011\u000A.\u000A(\u0004\u0018\u000E.\u001F()));
				byte[] array = \u001A\u0007\u000E.\u001F;
				MemoryStream memoryStream = \u0003\u0002\u001D.\u000A();
				try
				{
					\u000E\u001A\u0004.\u000A(u001F2, memoryStream, u);
					array = \u000B\u0002\u001D.\u000A(memoryStream);
				}
				finally
				{
					if (memoryStream != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SchemaUtil.\u000A(Element, DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel)).MethodHandle;
						}
						\u001F\u0017\u000A.\u000A(memoryStream);
					}
				}
				string text = "-";
				string text2 = "-";
				Entity entity = \u0010\u001A\u0004.\u000A(u001F);
				entity.Set<string>(\u000D\u001A\u0004.\u000A(u001F, "Filename"), text2);
				entity.Set<string>(\u000D\u001A\u0004.\u000A(u001F, "Folder"), text);
				entity.Set<IList<byte>>(\u000D\u001A\u0004.\u000A(u001F, "Data"), array);
				\u001C\u001A\u0004.\u000A(\u001F, entity);
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\SchemaUtil.cs", "SetDataToElement");
			}
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x00049768 File Offset: 0x00047968
		internal static DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel \u0007(Element \u001F)
		{
			DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel result = \u0018\u0018\u000E.\u001F;
			try
			{
				Schema schema = SchemaUtil.\u001F(true);
				if (schema == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SchemaUtil.\u0007(Element)).MethodHandle;
					}
					return \u0018\u0018\u000E.\u001F;
				}
				Entity entity = \u0017\u001A\u0004.\u000A(\u001F, schema);
				if (\u0020\u001A\u0004.\u000A(entity) == null)
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
					return \u0018\u0018\u000E.\u001F;
				}
				byte[] u000A = Enumerable.ToArray<byte>(entity.Get<IList<byte>>(\u000D\u001A\u0004.\u000A(schema, "Data")));
				List<DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel> u001F = SchemaUtil.\u0018(\u0018\u000B\u001D.\u000A(\u001E\u001A\u0004.\u000A(), u000A));
				if (\u0011\u001A\u0004.\u000A(u001F) > 0)
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
					result = \u001B\u001A\u0004.\u000A(u001F, 0);
				}
			}
			catch (Exception u000A2)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\SchemaUtil.cs", "GetDataFromElement");
			}
			return result;
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x00049858 File Offset: 0x00047A58
		internal static List<DiRoots.One.TGDatabaseLayer.SelectedExcel> \u001D(Document \u001F)
		{
			return \u0014\u001A\u0004.\u000A(SchemaUtil.\u0004(\u001F));
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x00049874 File Offset: 0x00047A74
		internal static List<DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel> \u0004(Document \u001F)
		{
			List<DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel> list = \u001C\u0017\u0004.\u000A();
			IEnumerable<View> elements = \u001F.GetElements<View>();
			Func<View, bool> func;
			if ((func = SchemaUtil.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SchemaUtil.\u0004(Document)).MethodHandle;
				}
				func = (SchemaUtil.<>c.\u000A = new Func<View, bool>(SchemaUtil.<>c.\u001F.\u0007));
			}
			List<View>.Enumerator enumerator = \u0018\u0010\u0007.\u000A(Enumerable.ToList<View>(Enumerable.Where<View>(elements, func)));
			try
			{
				while (\u0007\u0010\u0007.\u000A(ref enumerator))
				{
					View u001F = \u0019\u0010\u0007.\u000A(ref enumerator);
					DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel selectedExcel = SchemaUtil.\u0007(u001F);
					if (SchemaUtil.\u0019(u001F, selectedExcel))
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
						\u0004\u0014\u0004.\u000A(selectedExcel, \u0005\u001E\u000A.\u000A(u001F));
						\u0012\u0017\u0004.\u000A(list, selectedExcel);
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x00049950 File Offset: 0x00047B50
		private static bool \u0019(View \u001F, DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel \u000A)
		{
			if (\u000A == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SchemaUtil.\u0019(View, DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel)).MethodHandle;
				}
				return false;
			}
			if (!\u001A\u0006\u0007.\u000A(\u0020\u0020\u0004.\u000A(\u000A)))
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
				if (\u0008\u0013\u000A.\u000A(\u0012\u0010\u0007.\u000A(\u001F), \u0020\u0020\u0004.\u000A(\u000A)))
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
					\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), \u0002\u0013\u000A.\u000A("View found with UniqueId(", \u0020\u0020\u0004.\u000A(\u000A), ")"), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\SchemaUtil.cs", "IsViewLinkedToSelectedExcel");
					\u0014\u0017\u0004.\u000A(\u000A, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F)));
					return true;
				}
			}
			if (\u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F)) == \u0017\u0020\u0004.\u000A(\u000A))
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
				\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), \u0017\u0006\u0007.\u000A("View found with ElementId({0})", \u0017\u0020\u0004.\u000A(\u000A)), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\SchemaUtil.cs", "IsViewLinkedToSelectedExcel");
				return true;
			}
			if (\u0008\u0013\u000A.\u000A(\u001C\u001C\u0007.\u0007(\u001F).ToString(), \u0013\u001A\u0004.\u000A(\u000A)))
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
				if (\u0008\u0013\u000A.\u000A(\u0016\u0018.\u000A(\u001F), \u0012\u0011\u0004.\u000A(\u000A)))
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
					\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), \u0002\u0013\u000A.\u000A("View found with Name(", \u0012\u0011\u0004.\u000A(\u000A), ")"), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\SchemaUtil.cs", "IsViewLinkedToSelectedExcel");
					\u0014\u0017\u0004.\u000A(\u000A, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F)));
					return true;
				}
			}
			\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "No view found", "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\SchemaUtil.cs", "IsViewLinkedToSelectedExcel");
			return false;
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x00049B08 File Offset: 0x00047D08
		private static List<DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel> \u0018(string \u001F)
		{
			try
			{
				StringReader u000A = \u000C\u001A\u0004.\u000A(\u001F);
				return \u0019\u0018\u000E.\u001F(\u001A\u001A\u0004.\u000A(\u0008\u001A\u0004.\u000A(\u001E\u0011\u000A.\u000A(\u0004\u0018\u000E.\u001F())), u000A));
			}
			catch (Exception u000A2)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\SchemaUtil.cs", "Deserialize");
			}
			return \u001C\u0017\u0004.\u000A();
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x00049B78 File Offset: 0x00047D78
		internal static string \u0005()
		{
			return new \u000E\u000E\u000A("DiRootsOne", "TableGen", \u0007\u0018.\u0007<ICustomLogger>()).\u0010;
		}

		// Token: 0x06000B9D RID: 2973 RVA: 0x00049BA4 File Offset: 0x00047DA4
		internal static string \u0016(string \u001F)
		{
			return \u001C\u000B\u001D.\u0007(\u001B\u0015\u001D.\u000A(SchemaUtil.\u0005(), \u001F), "file:\\", "");
		}
	}
}
