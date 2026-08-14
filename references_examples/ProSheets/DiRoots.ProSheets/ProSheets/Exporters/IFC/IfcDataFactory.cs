using System;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using BIM.IFC.Export.UI;

namespace ProSheets.Exporters.IFC
{
	// Token: 0x020000EC RID: 236
	public static class IfcDataFactory
	{
		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x06000BBC RID: 3004 RVA: 0x00047EE0 File Offset: 0x000460E0
		public static IFCExportConfigurationsMap ConfigurationsMapForCustom
		{
			get
			{
				if (IfcDataFactory.\u000C == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(IfcDataFactory.get_ConfigurationsMapForCustom()).MethodHandle;
					}
					IfcDataFactory.\u000C = \u0001\u0017\u0016.\u0018();
					\u0008\u0017\u0016.\u0018(IfcDataFactory.\u000C);
				}
				return IfcDataFactory.\u000C;
			}
		}

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x06000BBD RID: 3005 RVA: 0x00047F24 File Offset: 0x00046124
		public static IFCExportConfigurationsMap ConfigurationsMapForDefault
		{
			get
			{
				if (IfcDataFactory.\u0018 == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(IfcDataFactory.get_ConfigurationsMapForDefault()).MethodHandle;
					}
					IfcDataFactory.\u0018 = \u0001\u0017\u0016.\u0018();
					\u001B\u0017\u0016.\u0018(IfcDataFactory.\u0018);
				}
				return IfcDataFactory.\u0018;
			}
		}

		// Token: 0x06000BBE RID: 3006 RVA: 0x00047F68 File Offset: 0x00046168
		public static IFCExportConfiguration GetConfiguration(string setupName)
		{
			IfcDataFactory.\u0004\u0011\u0018 u0004_u0011_u = new IfcDataFactory.\u0004\u0011\u0018();
			u0004_u0011_u.\u000C = setupName;
			IFCExportConfiguration ifcexportConfiguration = Enumerable.FirstOrDefault<IFCExportConfiguration>(\u0006\u0004\u0003.\u0018(\u0005\u0017\u0016.\u0018()), new Func<IFCExportConfiguration, bool>(u0004_u0011_u.\u0018));
			if (ifcexportConfiguration == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcDataFactory.GetConfiguration(string)).MethodHandle;
				}
				ifcexportConfiguration = Enumerable.FirstOrDefault<IFCExportConfiguration>(\u0006\u0004\u0003.\u0018(\u0008\u0004\u0003.\u0018()), new Func<IFCExportConfiguration, bool>(u0004_u0011_u.\u0014));
			}
			return ifcexportConfiguration;
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x00047FE0 File Offset: 0x000461E0
		public static void Init(Document document)
		{
			\u0007\u0011\u0018.\u000C(\u000A\u001D\u0018.\u0018(\u0001\u0010\u000F.\u000C()), "TheDocument", document);
		}

		// Token: 0x06000BC0 RID: 3008 RVA: 0x00048008 File Offset: 0x00046208
		public static void Clear()
		{
			IfcDataFactory.\u000C = \u0008\u0010\u000F.\u000C;
			IfcDataFactory.\u0018 = \u0008\u0010\u000F.\u000C;
		}

		// Token: 0x0400056F RID: 1391
		private static IFCExportConfigurationsMap \u000C;

		// Token: 0x04000570 RID: 1392
		private static IFCExportConfigurationsMap \u0018;

		// Token: 0x020001ED RID: 493
		[CompilerGenerated]
		private sealed class \u0004\u0011\u0018
		{
			// Token: 0x06001247 RID: 4679 RVA: 0x0005FDA0 File Offset: 0x0005DFA0
			internal bool \u0018(IFCExportConfiguration \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u0018\u001F\u000F.\u0018(\u000C), this.\u000C);
			}

			// Token: 0x06001248 RID: 4680 RVA: 0x0005FDC4 File Offset: 0x0005DFC4
			internal bool \u0014(IFCExportConfiguration \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u0018\u001F\u000F.\u0018(\u000C), this.\u000C);
			}

			// Token: 0x040008DF RID: 2271
			public string \u000C;
		}
	}
}
