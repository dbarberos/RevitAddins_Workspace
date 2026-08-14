using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Cad;
using ProSheets.Models;

namespace A
{
	// Token: 0x020000E3 RID: 227
	internal class \u0005\u001F\u0018
	{
		// Token: 0x06000B8B RID: 2955 RVA: 0x000466B4 File Offset: 0x000448B4
		public \u0005\u001F\u0018(ICustomLogger \u000C)
		{
			this.\u000C = \u000C;
			if (\u0007\u0011\u0016.\u0018())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0005\u001F\u0018..ctor(ICustomLogger)).MethodHandle;
				}
				this.\u0003 = \u0019\u0011\u0016.\u0018();
				if (this.\u0003)
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
					this.\u0014 = new AutoCadApp(this.\u000C);
				}
			}
		}

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x06000B8C RID: 2956 RVA: 0x0004671C File Offset: 0x0004491C
		// (set) Token: 0x06000B8D RID: 2957 RVA: 0x00046730 File Offset: 0x00044930
		public static List<ExportDWGSettings> DWGSettings { get; set; }

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x06000B8E RID: 2958 RVA: 0x00046744 File Offset: 0x00044944
		// (set) Token: 0x06000B8F RID: 2959 RVA: 0x00046758 File Offset: 0x00044958
		public static List<string> DWGSettingNames { get; set; }

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06000B90 RID: 2960 RVA: 0x0004676C File Offset: 0x0004496C
		// (set) Token: 0x06000B91 RID: 2961 RVA: 0x00046780 File Offset: 0x00044980
		public static string SelectedSettingName { get; set; }

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06000B92 RID: 2962 RVA: 0x00046794 File Offset: 0x00044994
		// (set) Token: 0x06000B93 RID: 2963 RVA: 0x000467A8 File Offset: 0x000449A8
		public static bool MergedViews { get; set; }

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06000B94 RID: 2964 RVA: 0x000467BC File Offset: 0x000449BC
		// (set) Token: 0x06000B95 RID: 2965 RVA: 0x000467D0 File Offset: 0x000449D0
		public static bool BindImages { get; set; }

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x06000B96 RID: 2966 RVA: 0x000467E4 File Offset: 0x000449E4
		// (set) Token: 0x06000B97 RID: 2967 RVA: 0x000467F8 File Offset: 0x000449F8
		public static bool CleanPCP { get; set; }

		// Token: 0x06000B98 RID: 2968 RVA: 0x0004680C File Offset: 0x00044A0C
		public bool \u0009(Document \u000C, View \u0018, string \u0014, SheetInfo \u0003, bool \u0016)
		{
			\u0005\u001F\u0018.\u001B\u001F\u0018 u001B_u001F_u = new \u0005\u001F\u0018.\u001B\u001F\u0018();
			u001B_u001F_u.\u000C = this;
			\u000D\u0004\u0018.\u0018(this.\u000C, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DwgExporter.cs", "ExportDWG");
			bool result = false;
			try
			{
				string u000C = \u001F\u0010\u0014.\u0018(\u0003, \u0018, \u0015\u0010\u0014.\u0018(), "DWG", \u0014, ".dwg", \u0011\u0010\u0014.\u0018());
				if (!\u001F\u001A\u0018.\u0018(\u0014\u0017\u0014.\u0018(\u0003)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0005\u001F\u0018.\u0009(Document, View, string, SheetInfo, bool)).MethodHandle;
					}
					return false;
				}
				if (this.\u0018 == null)
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
					\u001F\u0002\u0014.\u0018(\u000F\u000A\u0018.\u0016\u0018<ExportDWGSettings>(\u000C));
					List<ExportDWGSettings>.Enumerator enumerator = \u000A\u0002\u0014.\u0018(\u0020\u0002\u0014.\u0018());
					try
					{
						while (\u0013\u0002\u0014.\u0018(ref enumerator))
						{
							ExportDWGSettings u000C2 = \u0009\u0002\u0014.\u0018(ref enumerator);
							if (\u000F\u0002\u0018.\u0018(\u001E\u0016\u0014.\u0018(u000C2), \u0014\u0015\u0016.\u0018()))
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
								this.\u0018 = \u0013\u001F\u0003.\u0018(u000C2);
								goto IL_10D;
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
				}
				IL_10D:
				if (this.\u0018 == null)
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
					this.\u0018 = \u0018\u0015\u0016.\u0018();
				}
				\u000E\u0011\u0016.\u0018(this.\u0018, !\u000C\u0015\u0016.\u0018());
				List<ElementId> list = \u0007\u0004\u0018.\u0018();
				\u0014\u0008\u0014.\u0018(list, \u0009\u0002\u0018.\u0018(\u0018));
				List<ElementId> u = list;
				\u0008\u0017\u0018.\u0018(this.\u000C, "Start export - Single DWG", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DwgExporter.cs", "ExportDWG");
				result = \u0005\u0011\u0016.\u0018(\u000C, \u0019\u001E\u0018.\u0018(u000C), \u0014, u, this.\u0018);
				\u0008\u0017\u0018.\u0018(this.\u000C, "End export - Single DWG", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DwgExporter.cs", "ExportDWG");
				if (!\u0007\u0011\u0016.\u0018())
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
					\u0008\u0017\u0018.\u0018(this.\u000C, "BindImages is disabled.", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DwgExporter.cs", "ExportDWG");
				}
				else if (!this.\u0003)
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
					\u0008\u0017\u0018.\u0018(this.\u000C, "AutoCAD is not installed. Skipping binding.", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DwgExporter.cs", "ExportDWG");
				}
				else
				{
					\u0008\u0017\u0018.\u0018(this.\u000C, "Binding Images: Start", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DwgExporter.cs", "ExportDWG");
					string u2 = \u0019\u000C\u0014.\u0018(\u0019\u001E\u0018.\u0018(u000C), "\\", \u0014, ".dwg");
					\u001B\u0011\u0016.\u0018(this.\u0014, u2);
					this.\u000A(\u0019\u001E\u0018.\u0018(u000C), false, this.\u0014);
					\u0001\u0011\u0016.\u0018(this.\u0014);
					if (\u0016)
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
						\u0008\u0017\u0018.\u0018(this.\u000C, "Binding Images: Check and close AutoCAD", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DwgExporter.cs", "ExportDWG");
						\u0008\u0011\u0016.\u0018(this.\u0014);
						\u0008\u0017\u0018.\u0018(this.\u000C, "Binding Images: Removing images", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DwgExporter.cs", "ExportDWG");
						u001B_u001F_u.\u0018 = this.\u0020();
						\u0006\u0011\u0016.\u0018(new Action(u001B_u001F_u.\u0014));
					}
					\u0008\u0017\u0018.\u0018(this.\u000C, "Binding Images: End", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DwgExporter.cs", "ExportDWG");
				}
				if (\u0010\u0011\u0016.\u0018())
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
					string u000C3 = \u001F\u0010\u0014.\u0018(\u0003, \u0018, \u0015\u0010\u0014.\u0018(), "DWG", \u0014, ".pcp", \u0011\u0010\u0014.\u0018());
					if (\u000C\u001A\u0018.\u0018(u000C3))
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
						\u000C\u0020\u0014.\u0018(u000C3);
					}
				}
				\u0017\u001E\u0018.\u0018(this.\u000C, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DwgExporter.cs", "ExportDWG");
			}
			catch (Exception ex)
			{
				\u001E\u001E\u0018.\u0018(this.\u000C, ex, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DwgExporter.cs", "ExportDWG");
				\u0018\u0017\u0014.\u0014(\u0003, \u000A\u0001\u0018.\u0018(ex));
			}
			return result;
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x00046BDC File Offset: 0x00044DDC
		private void \u000A(string \u000C, bool \u0018, AutoCadApp \u0014)
		{
			string u000C = \u0019\u001E\u0018.\u0018(\u001C\u0015\u0014.\u0018(\u0001\u0004\u0014.\u0018()));
			FileInfo u000C2 = \u001B\u001E\u0014.\u0018(\u0003\u001A\u0018.\u0018(\u0008\u001E\u0014.\u0018(\u000A\u0006\u0018.\u0018(Environment.SpecialFolder.LocalApplicationData), "DiRoots", "ProSheets", "Temp"), "Script.scr"));
			try
			{
				string text = \u0010\u000B\u0014.\u0018(\u0020\u0020\u0014.\u0018(u000C2), "\\", "\\\\");
				string u = \u0010\u000B\u0014.\u0018(\u0003\u001A\u0018.\u0018(u000C, "DiRoots.ProSheets.Cad.dll"), "\\", "\\\\");
				StreamWriter streamWriter = \u0016\u0015\u0016.\u0018(text, false);
				try
				{
					\u0008\u000F\u0003.\u0018(streamWriter, "(vl-load-com)");
					object u000C3 = streamWriter;
					string[] array = \u000C\u0002\u000F.\u000C(5);
					array[0] = "(defun c:ToggleOLETextDialog (/ prefs) (setq prefs (vla-get-Preferences (vlax-get-acad-object))) (vla-put-DisplayOLEScale (vla-get-System prefs) ";
					int num = 1;
					string text2;
					if (!\u0018)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0005\u001F\u0018.\u000A(string, bool, AutoCadApp)).MethodHandle;
						}
						text2 = ":vlax-false";
					}
					else
					{
						text2 = ":vlax-true";
					}
					array[num] = text2;
					array[2] = ") (princ \"OLE Text Scaling is now ";
					int num2 = 3;
					string text3;
					if (!\u0018)
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
						text3 = "OFF.";
					}
					else
					{
						text3 = "ON.";
					}
					array[num2] = text3;
					array[4] = "\"))";
					\u0008\u000F\u0003.\u0018(u000C3, \u000F\u001D\u0018.\u0018(array));
					\u0008\u000F\u0003.\u0018(streamWriter, "(if (= (getvar \"Secureload\") 1) (command \"Secureload\" 0))");
					\u0008\u000F\u0003.\u0018(streamWriter, \u0014\u001E\u0018.\u0018("(command \"netload\" \"", u, "\")"));
					\u0008\u000F\u0003.\u0018(streamWriter, "(c:ToggleOLETextDialog)");
					\u0008\u000F\u0003.\u0018(streamWriter, \u0014\u001E\u0018.\u0018("(RunLisp \"", \u0010\u000B\u0014.\u0018(\u000C, "\\", "\\\\"), "\")"));
					\u0008\u000F\u0003.\u0018(streamWriter, "(if (= (getvar \"Secureload\") 0) (command \"Secureload\" 1))");
				}
				finally
				{
					if (streamWriter != null)
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
						\u0020\u001E\u0018.\u0018(streamWriter);
					}
				}
				\u0003\u0015\u0016.\u0018(\u0014, text);
			}
			catch (Exception u2)
			{
				\u001E\u001E\u0018.\u0018(this.\u000C, u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DwgExporter.cs", "CreateScript");
			}
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x00046DC8 File Offset: 0x00044FC8
		private List<string> \u0020()
		{
			List<string> result = \u0011\u0002\u0018.\u0018();
			string u000C = \u0012\u0015\u0016.\u0018();
			try
			{
				result = \u000F\u0015\u0016.\u0018(u000C);
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(this.\u000C, u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DwgExporter.cs", "DeserializeImageFilePaths");
			}
			this.\u001F(u000C);
			return result;
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x00046E24 File Offset: 0x00045024
		private void \u001F(string \u000C)
		{
			try
			{
				\u000C\u0020\u0014.\u0018(\u000C);
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(this.\u000C, u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DwgExporter.cs", "DeleteJsonFile");
			}
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x00046E64 File Offset: 0x00045064
		private void \u0011(List<string> \u000C)
		{
			List<string>.Enumerator enumerator = \u0008\u0015\u0014.\u0018(\u000C);
			try
			{
				IL_A1:
				while (\u0010\u0015\u0014.\u0018(ref enumerator))
				{
					string text = \u0006\u0015\u0014.\u0018(ref enumerator);
					for (int i = 0; i < 5; i++)
					{
						try
						{
							if (\u000C\u001A\u0018.\u0018(text))
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
									RuntimeMethodHandle runtimeMethodHandle = methodof(\u0005\u001F\u0018.\u0011(List<string>)).MethodHandle;
								}
								\u000C\u0020\u0014.\u0018(text);
								\u0008\u0017\u0018.\u0018(this.\u000C, \u0014\u001E\u0018.\u0018("Binding Images: ", text, " Removed"), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DwgExporter.cs", "DeleteImageFiles");
							}
							goto IL_A1;
						}
						catch (Exception u)
						{
							\u0013\u0017\u0014.\u0018(3000);
							\u001E\u001E\u0018.\u0018(this.\u000C, u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DwgExporter.cs", "DeleteImageFiles");
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
					switch (4)
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

		// Token: 0x0400055C RID: 1372
		private readonly ICustomLogger \u000C;

		// Token: 0x0400055D RID: 1373
		private DWGExportOptions \u0018;

		// Token: 0x0400055E RID: 1374
		private readonly AutoCadApp \u0014;

		// Token: 0x0400055F RID: 1375
		private readonly bool \u0003;

		// Token: 0x04000560 RID: 1376
		[CompilerGenerated]
		private static List<ExportDWGSettings> \u0016;

		// Token: 0x04000561 RID: 1377
		[CompilerGenerated]
		private static List<string> \u000F;

		// Token: 0x04000562 RID: 1378
		[CompilerGenerated]
		private static string \u0012;

		// Token: 0x04000563 RID: 1379
		[CompilerGenerated]
		private static bool \u000D;

		// Token: 0x04000564 RID: 1380
		[CompilerGenerated]
		private static bool \u001C;

		// Token: 0x04000565 RID: 1381
		[CompilerGenerated]
		private static bool \u0013;

		// Token: 0x020001DE RID: 478
		[CompilerGenerated]
		private sealed class \u001B\u001F\u0018
		{
			// Token: 0x06001227 RID: 4647 RVA: 0x0005E570 File Offset: 0x0005C770
			internal void \u0014()
			{
				this.\u000C.\u0011(this.\u0018);
			}

			// Token: 0x040008A9 RID: 2217
			public \u0005\u001F\u0018 \u000C;

			// Token: 0x040008AA RID: 2218
			public List<string> \u0018;
		}
	}
}
