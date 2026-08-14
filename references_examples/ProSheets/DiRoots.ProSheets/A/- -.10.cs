using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;

namespace A
{
	// Token: 0x020000C8 RID: 200
	internal static class \u001B\u0020\u0018
	{
		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x06000B12 RID: 2834 RVA: 0x00041784 File Offset: 0x0003F984
		// (set) Token: 0x06000B13 RID: 2835 RVA: 0x00041798 File Offset: 0x0003F998
		public static bool IsScheduleTimerData { get; set; }

		// Token: 0x06000B14 RID: 2836 RVA: 0x000417AC File Offset: 0x0003F9AC
		internal static Schema \u0003(bool \u000C)
		{
			Guid guid;
			if (!\u000C)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0020\u0018.\u0003(bool)).MethodHandle;
				}
				guid = \u001B\u0020\u0018.\u000C;
			}
			else
			{
				guid = \u001B\u0020\u0018.\u0014;
			}
			Guid u000C = guid;
			string text;
			if (!\u000C)
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
				text = "ProSheetsProfileNameSchema";
			}
			else
			{
				text = "ProSheetsSchedulerTimerSchema";
			}
			string u = text;
			string text2;
			if (!\u000C)
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
				text2 = "ProSheetsProfileName";
			}
			else
			{
				text2 = "ProSheetsSchedulerTimerName";
			}
			string u2 = text2;
			Schema schema = \u0016\u000C\u0016.\u0018(u000C);
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
				SchemaBuilder u000C2 = \u0003\u000C\u0016.\u0018(u000C);
				\u0014\u000C\u0016.\u0018(u000C2, u);
				\u0018\u000C\u0016.\u0018(u000C2, u2, \u000A\u001D\u0018.\u0018(\u001A\u0002\u000F.\u000C()));
				schema = \u000C\u000C\u0016.\u0018(u000C2);
			}
			return schema;
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x0004185C File Offset: 0x0003FA5C
		internal static void \u0016(Document \u000C, string \u0018, bool \u0014 = false)
		{
			Schema schema = \u001B\u0020\u0018.\u0003(\u0014);
			string text;
			if (!\u0014)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0020\u0018.\u0016(Document, string, bool)).MethodHandle;
				}
				text = "ProSheetsProfileName";
			}
			else
			{
				text = "ProSheetsSchedulerTimerName";
			}
			string text2 = text;
			string text3;
			if (!\u0014)
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
				text3 = "ProSheetCurrentDataStorage";
			}
			else
			{
				text3 = "SchedulerTimerDataStorage";
			}
			string text4 = text3;
			DataStorage dataStorage = \u001B\u0020\u0018.\u000F(\u000C, \u0001\u000C\u0016.\u0018(schema), text4);
			Transaction transaction = \u001F\u000C\u0016.\u0018(\u000C, "Store String in DataStorage");
			try
			{
				\u0020\u000C\u0016.\u0018(transaction);
				if (dataStorage == null)
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
					dataStorage = \u001C\u000C\u0016.\u0018(\u000C);
					\u001D\u001C\u0016.\u0018(dataStorage, text4);
				}
				Entity entity = \u0013\u000C\u0016.\u0018(dataStorage, schema);
				if (!\u0004\u001C\u0016.\u0018(entity))
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
					entity = \u000D\u000C\u0016.\u0018(schema);
				}
				entity.Set<string>(text2, \u0018);
				\u0012\u000C\u0016.\u0018(dataStorage, entity);
				\u0009\u0007\u0014.\u0018(transaction);
			}
			catch (Exception)
			{
				\u0020\u000D\u0016.\u0018(transaction);
			}
			finally
			{
				if (transaction != null)
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
					\u0020\u001E\u0018.\u0018(transaction);
				}
			}
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x00041980 File Offset: 0x0003FB80
		private static DataStorage \u000F(Document \u000C, Guid \u0018, string \u0014)
		{
			\u001B\u0020\u0018.\u0001\u0020\u0018 u0001_u0020_u = new \u001B\u0020\u0018.\u0001\u0020\u0018();
			u0001_u0020_u.\u000C = \u0014;
			ExtensibleStorageFilter u = \u001A\u001C\u0016.\u0018(\u0018);
			return Enumerable.FirstOrDefault<DataStorage>(Enumerable.Cast<DataStorage>(\u0013\u001D\u0018.\u0014(\u0010\u001D\u0014.\u0014(\u0020\u001D\u0018.\u0018(\u000C), \u000A\u001D\u0018.\u0018(\u0010\u0007\u000F.\u000C())), u)), new Func<DataStorage, bool>(u0001_u0020_u.\u0018));
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x000419E4 File Offset: 0x0003FBE4
		internal static string \u0012(Document \u000C, bool \u0018 = false)
		{
			Schema schema = \u001B\u0020\u0018.\u0003(\u0018);
			string text;
			if (!\u0018)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0020\u0018.\u0012(Document, bool)).MethodHandle;
				}
				text = "ProSheetCurrentDataStorage";
			}
			else
			{
				text = "SchedulerTimerDataStorage";
			}
			string u = text;
			string text2;
			if (!\u0018)
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
				text2 = "ProSheetsProfileName";
			}
			else
			{
				text2 = "ProSheetsSchedulerTimerName";
			}
			string text3 = text2;
			DataStorage dataStorage = \u001B\u0020\u0018.\u000F(\u000C, \u0001\u000C\u0016.\u0018(schema), u);
			if (dataStorage != null)
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
				Entity entity = \u0013\u000C\u0016.\u0018(dataStorage, schema);
				if (\u0004\u001C\u0016.\u0018(entity))
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
					return entity.Get<string>(text3);
				}
			}
			return null;
		}

		// Token: 0x0400053C RID: 1340
		private static Guid \u000C = new Guid("4397e380-9267-4e89-b56f-59e9bec915f8");

		// Token: 0x0400053D RID: 1341
		[CompilerGenerated]
		private static bool \u0018;

		// Token: 0x0400053E RID: 1342
		private static Guid \u0014 = new Guid("0c5b3751-68d5-4376-b626-bdf936bce0e2");

		// Token: 0x020001CA RID: 458
		[CompilerGenerated]
		private sealed class \u0001\u0020\u0018
		{
			// Token: 0x060011E4 RID: 4580 RVA: 0x0005D6AC File Offset: 0x0005B8AC
			internal bool \u0018(DataStorage \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u001E\u0016\u0014.\u0018(\u000C), this.\u000C);
			}

			// Token: 0x04000879 RID: 2169
			public string \u000C;
		}
	}
}
