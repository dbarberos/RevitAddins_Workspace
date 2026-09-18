using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using ProSheets.Models;

namespace ProSheets.Services.IFC
{
	// Token: 0x020000A5 RID: 165
	public class IfcClassificationManager
	{
		// Token: 0x06000999 RID: 2457 RVA: 0x0003B23C File Offset: 0x0003943C
		private static Schema \u0009()
		{
			Schema schema = \u0016\u000C\u0016.\u0018(IfcClassificationManager.\u0018);
			if (schema == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcClassificationManager.\u0009()).MethodHandle;
				}
				SchemaBuilder u000C = \u0003\u000C\u0016.\u0018(IfcClassificationManager.\u0018);
				\u0014\u000C\u0016.\u0018(u000C, "IFCClassification");
				\u0018\u000C\u0016.\u0018(u000C, "ClassificationName", \u000A\u001D\u0018.\u0018(\u001A\u0002\u000F.\u000C()));
				\u0018\u000C\u0016.\u0018(u000C, "ClassificationSource", \u000A\u001D\u0018.\u0018(\u001A\u0002\u000F.\u000C()));
				\u0018\u000C\u0016.\u0018(u000C, "ClassificationEdition", \u000A\u001D\u0018.\u0018(\u001A\u0002\u000F.\u000C()));
				\u0018\u000C\u0016.\u0018(u000C, "ClassificationEditionDate_Day", \u000A\u001D\u0018.\u0018(\u0006\u0007\u000F.\u000C()));
				\u0018\u000C\u0016.\u0018(u000C, "ClassificationEditionDate_Month", \u000A\u001D\u0018.\u0018(\u0006\u0007\u000F.\u000C()));
				\u0018\u000C\u0016.\u0018(u000C, "ClassificationEditionDate_Year", \u000A\u001D\u0018.\u0018(\u0006\u0007\u000F.\u000C()));
				\u0018\u000C\u0016.\u0018(u000C, "ClassificationLocation", \u000A\u001D\u0018.\u0018(\u001A\u0002\u000F.\u000C()));
				\u0018\u000C\u0016.\u0018(u000C, "ClassificationFieldName", \u000A\u001D\u0018.\u0018(\u001A\u0002\u000F.\u000C()));
				schema = \u000C\u000C\u0016.\u0018(u000C);
			}
			return schema;
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0003B374 File Offset: 0x00039574
		private static Schema \u000A()
		{
			return \u0016\u000C\u0016.\u0018(IfcClassificationManager.\u000C);
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0003B390 File Offset: 0x00039590
		public static void DeleteObsoleteSchemas(Document document)
		{
			Schema schema = IfcClassificationManager.\u000A();
			if (schema != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcClassificationManager.DeleteObsoleteSchemas(Document)).MethodHandle;
				}
				Schema u000C = IfcClassificationManager.\u0009();
				IList<IfcClassificationSettings> list;
				if (\u000D\u001A\u0003.\u0018(document, schema, out list))
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
					try
					{
						Transaction u000C2 = \u001F\u000C\u0016.\u0018(document, "Upgrade saved IFC classification");
						\u0020\u000C\u0016.\u0018(u000C2);
						object u000C3 = IfcClassificationManager.\u0020(document, schema);
						IList<ElementId> list2 = \u0007\u0004\u0018.\u0018();
						IEnumerator<DataStorage> enumerator = \u000A\u000C\u0016.\u0018(u000C3);
						try
						{
							while (\u001F\u001E\u0018.\u0018(enumerator))
							{
								DataStorage u000C4 = \u0009\u000C\u0016.\u0018(enumerator);
								Entity entity = \u0013\u000C\u0016.\u0018(u000C4, schema);
								DataStorage u000C5 = \u001C\u000C\u0016.\u0018(document);
								Entity entity2 = \u000D\u000C\u0016.\u0018(u000C);
								string text = entity.Get<string>("ClassificationName");
								if (text != null)
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
									entity2.Set<string>("ClassificationName", text);
								}
								string text2 = entity.Get<string>("ClassificationSource");
								if (text2 != null)
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
									entity2.Set<string>("ClassificationSource", text2);
								}
								string text3 = entity.Get<string>("ClassificationEdition");
								if (text3 != null)
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
									entity2.Set<string>("ClassificationEdition", text3);
								}
								int num = entity.Get<int>("ClassificationEditionDate_Day");
								int num2 = entity.Get<int>("ClassificationEditionDate_Month");
								int num3 = entity.Get<int>("ClassificationEditionDate_Year");
								entity2.Set<int>("ClassificationEditionDate_Day", num);
								entity2.Set<int>("ClassificationEditionDate_Month", num2);
								entity2.Set<int>("ClassificationEditionDate_Year", num3);
								string text4 = entity.Get<string>("ClassificationLocation");
								if (text4 != null)
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
									entity2.Set<string>("ClassificationLocation", text4);
								}
								\u0012\u000C\u0016.\u0018(u000C5, entity2);
								\u001F\u0004\u0018.\u0018(list2, \u0009\u0002\u0018.\u0018(u000C4));
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
							if (enumerator != null)
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
								\u0020\u001E\u0018.\u0018(enumerator);
							}
						}
						if (\u0013\u001E\u0018.\u0018(list2) > 0)
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
							\u000F\u000C\u0016.\u0018(document, list2);
						}
						\u0009\u0007\u0014.\u0018(u000C2);
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x0003B5F0 File Offset: 0x000397F0
		private static IList<DataStorage> \u0020(Document \u000C, Schema \u0018)
		{
			IfcClassificationManager.\u0020\u0020\u0018 u0020_u0020_u = new IfcClassificationManager.\u0020\u0020\u0018();
			u0020_u0020_u.\u000C = \u0018;
			FilteredElementCollector filteredElementCollector = \u0020\u001D\u0018.\u0018(\u000C);
			\u0010\u001D\u0014.\u0014(filteredElementCollector, \u000A\u001D\u0018.\u0018(\u0010\u0007\u000F.\u000C()));
			Func<DataStorage, bool> func = new Func<DataStorage, bool>(u0020_u0020_u.\u0018);
			return Enumerable.ToList<DataStorage>(Enumerable.Where<DataStorage>(Enumerable.Cast<DataStorage>(filteredElementCollector), func));
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x0003B64C File Offset: 0x0003984C
		public static void UpdateClassification(Document document, IfcClassificationSettings classification)
		{
			Schema schema = IfcClassificationManager.\u0009();
			if (schema != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcClassificationManager.UpdateClassification(Document, IfcClassificationSettings)).MethodHandle;
				}
				Transaction u000C = \u001F\u000C\u0016.\u0018(document, "Update saved IFC classification");
				\u0020\u000C\u0016.\u0018(u000C);
				IList<DataStorage> u000C2 = IfcClassificationManager.\u0020(document, schema);
				if (\u001D\u000C\u0016.\u0018(u000C2) > 0)
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
					List<ElementId> list = \u0007\u0004\u0018.\u0018();
					IEnumerator<DataStorage> enumerator = \u000A\u000C\u0016.\u0018(u000C2);
					try
					{
						while (\u001F\u001E\u0018.\u0018(enumerator))
						{
							DataStorage u000C3 = \u0009\u000C\u0016.\u0018(enumerator);
							\u0014\u0008\u0014.\u0018(list, \u0009\u0002\u0018.\u0018(u000C3));
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
								switch (3)
								{
								case 0:
									continue;
								}
								break;
							}
							\u0020\u001E\u0018.\u0018(enumerator);
						}
					}
					\u000F\u000C\u0016.\u0018(document, list);
				}
				object u000C4 = \u001C\u000C\u0016.\u0018(document);
				Entity entity = \u000D\u000C\u0016.\u0018(schema);
				if (\u0010\u0001\u0003.\u0014(classification) != null)
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
					entity.Set<string>("ClassificationName", \u0010\u0001\u0003.\u0014(classification));
				}
				if (\u0019\u0001\u0003.\u0014(classification) != null)
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
					entity.Set<string>("ClassificationSource", \u0019\u0001\u0003.\u0014(classification));
				}
				if (\u001A\u0001\u0003.\u0014(classification) != null)
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
					entity.Set<string>("ClassificationEdition", \u001A\u0001\u0003.\u0014(classification));
				}
				\u001E\u000C\u0016.\u0014(classification);
				Entity entity2 = entity;
				string text = "ClassificationEditionDate_Day";
				DateTime dateTime = \u001E\u000C\u0016.\u0014(classification);
				entity2.Set<int>(text, \u0004\u000C\u0016.\u0018(ref dateTime));
				Entity entity3 = entity;
				string text2 = "ClassificationEditionDate_Month";
				dateTime = \u001E\u000C\u0016.\u0014(classification);
				entity3.Set<int>(text2, \u0002\u000C\u0016.\u0018(ref dateTime));
				Entity entity4 = entity;
				string text3 = "ClassificationEditionDate_Year";
				dateTime = \u001E\u000C\u0016.\u0014(classification);
				entity4.Set<int>(text3, \u0017\u000C\u0016.\u0018(ref dateTime));
				if (\u0015\u000C\u0016.\u0014(classification) != null)
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
					entity.Set<string>("ClassificationLocation", \u0015\u000C\u0016.\u0014(classification));
				}
				if (\u0011\u000C\u0016.\u0014(classification) != null)
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
					entity.Set<string>("ClassificationFieldName", \u0011\u000C\u0016.\u0014(classification));
				}
				\u0012\u000C\u0016.\u0018(u000C4, entity);
				\u0009\u0007\u0014.\u0018(u000C);
			}
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x0003B870 File Offset: 0x00039A70
		public unsafe static bool GetSavedClassifications(Document document, Schema schema, out IList<IfcClassificationSettings> classifications)
		{
			IList<IfcClassificationSettings> list = \u0018\u0018\u0016.\u0018();
			bool result = false;
			if (schema == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcClassificationManager.GetSavedClassifications(Document, Schema, IList<IfcClassificationSettings>*)).MethodHandle;
				}
				schema = IfcClassificationManager.\u0009();
			}
			if (schema != null)
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
				Schema schema2 = IfcClassificationManager.\u000A();
				IList<DataStorage> u000C = IfcClassificationManager.\u0020(document, schema);
				int i = 0;
				while (i < \u001D\u000C\u0016.\u0018(u000C))
				{
					Entity entity = \u0013\u000C\u0016.\u0018(\u000C\u0018\u0016.\u0018(u000C, i), schema);
					\u001A\u000C\u0016.\u0018(list, \u000B\u000C\u0016.\u0018());
					\u0007\u0001\u0003.\u0014(\u0006\u000C\u0016.\u0018(list, i), entity.Get<string>(\u0010\u000C\u0016.\u0018(schema, "ClassificationName")));
					\u000B\u0001\u0003.\u0014(\u0006\u000C\u0016.\u0018(list, i), entity.Get<string>(\u0010\u000C\u0016.\u0018(schema, "ClassificationSource")));
					\u001D\u0001\u0003.\u0014(\u0006\u000C\u0016.\u0018(list, i), entity.Get<string>(\u0010\u000C\u0016.\u0018(schema, "ClassificationEdition")));
					int day = entity.Get<int>(\u0010\u000C\u0016.\u0018(schema, "ClassificationEditionDate_Day"));
					int month = entity.Get<int>(\u0010\u000C\u0016.\u0018(schema, "ClassificationEditionDate_Month"));
					int year = entity.Get<int>(\u0010\u000C\u0016.\u0018(schema, "ClassificationEditionDate_Year"));
					try
					{
						\u0005\u000C\u0016.\u0014(\u0006\u000C\u0016.\u0018(list, i), new DateTime(year, month, day));
					}
					catch
					{
						object u000C2 = \u0006\u000C\u0016.\u0018(list, i);
						DateTime dateTime = \u0019\u0015\u0014.\u0018();
						\u0005\u000C\u0016.\u0014(u000C2, \u000E\u000C\u0016.\u0018(ref dateTime));
					}
					\u001B\u000C\u0016.\u0014(\u0006\u000C\u0016.\u0018(list, i), entity.Get<string>(\u0010\u000C\u0016.\u0018(schema, "ClassificationLocation")));
					if (schema2 == null)
					{
						goto IL_1C2;
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
					if (\u0008\u000C\u0016.\u0018(\u0001\u000C\u0016.\u0018(schema), \u0001\u000C\u0016.\u0018(schema2)))
					{
						for (;;)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							goto IL_1C2;
						}
					}
					IL_1E7:
					result = true;
					i++;
					continue;
					IL_1C2:
					\u0007\u000C\u0016.\u0014(\u0006\u000C\u0016.\u0018(list, i), entity.Get<string>(\u0010\u000C\u0016.\u0018(schema, "ClassificationFieldName")));
					goto IL_1E7;
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
			if (\u0019\u000C\u0016.\u0018(list) == 0)
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
				\u001A\u000C\u0016.\u0018(list, \u000B\u000C\u0016.\u0018());
			}
			classifications = list;
			return result;
		}

		// Token: 0x0400047F RID: 1151
		private static Guid \u000C = new Guid("2CC3F098-1D06-4771-815D-D39128193A14");

		// Token: 0x04000480 RID: 1152
		private static Guid \u0018 = new Guid("9A5A28C2-DDAC-4828-8B8A-3EE97118017A");

		// Token: 0x04000481 RID: 1153
		private static string \u0014;

		// Token: 0x04000482 RID: 1154
		private static string \u0003;

		// Token: 0x04000483 RID: 1155
		private static string \u0016;

		// Token: 0x04000484 RID: 1156
		private static string \u000F;

		// Token: 0x04000485 RID: 1157
		private static string \u0012;

		// Token: 0x04000486 RID: 1158
		private static string \u000D;

		// Token: 0x04000487 RID: 1159
		private static string \u001C;

		// Token: 0x04000488 RID: 1160
		private static string \u0013;

		// Token: 0x020001B8 RID: 440
		[CompilerGenerated]
		private sealed class \u0020\u0020\u0018
		{
			// Token: 0x060011A2 RID: 4514 RVA: 0x0005D048 File Offset: 0x0005B248
			internal bool \u0018(DataStorage \u000C)
			{
				if (\u0013\u000C\u0016.\u0018(\u000C, this.\u000C) != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(IfcClassificationManager.\u0020\u0020\u0018.\u0018(DataStorage)).MethodHandle;
					}
					return \u0004\u001C\u0016.\u0018(\u0013\u000C\u0016.\u0018(\u000C, this.\u000C));
				}
				return false;
			}

			// Token: 0x04000850 RID: 2128
			public Schema \u000C;
		}
	}
}
