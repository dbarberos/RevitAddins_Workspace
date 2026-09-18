using System;
using DiRoots.One.Commons.Interfaces;
using Microsoft.Win32;
using ProSheets.Helpers;

namespace A
{
	// Token: 0x020000D0 RID: 208
	internal class \u0013\u001F\u0018
	{
		// Token: 0x06000B3A RID: 2874 RVA: 0x00042D94 File Offset: 0x00040F94
		public static void \u000C()
		{
			try
			{
				\u0013\u001F\u0018.\u0018(\u0008\u0009\u0016.\u0018(-2147483647, 512), "SOFTWARE\\PDFPRINT");
				\u0013\u001F\u0018.\u0018(\u0008\u0009\u0016.\u0018(-2147483647, 256), "SOFTWARE\\PDF24");
				\u0013\u001F\u0018.\u0014();
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Helper\\RegistryHandler.cs", "SetPDF24Settings");
			}
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x00042E08 File Offset: 0x00041008
		private static void \u0018(RegistryKey \u000C, string \u0018)
		{
			if (\u000E\u0009\u0016.\u0018(\u000C, \u0018, true) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001F\u0018.\u0018(RegistryKey, string)).MethodHandle;
				}
				\u0001\u0009\u0016.\u0018(\u000C\u000A\u0016.\u0018(\u000C, \u0018));
			}
			if (\u000E\u0009\u0016.\u0018(\u000C, \u000D\u001E\u0018.\u0018(\u0018, "\\Services"), true) == null)
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
				\u0001\u0009\u0016.\u0018(\u000C\u000A\u0016.\u0018(\u000C, \u000D\u001E\u0018.\u0018(\u0018, "\\Services")));
			}
			if (\u000E\u0009\u0016.\u0018(\u000C, \u000D\u001E\u0018.\u0018(\u0018, "\\Services\\diroots.prosheets"), true) == null)
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
				\u0001\u0009\u0016.\u0018(\u000C\u000A\u0016.\u0018(\u000C, \u000D\u001E\u0018.\u0018(\u0018, "\\Services\\diroots.prosheets")));
			}
			RegistryKey registryKey = \u000E\u0009\u0016.\u0018(\u000C, \u0018, true);
			if (registryKey != null)
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
				\u0005\u0009\u0016.\u0018(registryKey, "NoTrayIcon", 1, 4);
				\u0001\u0009\u0016.\u0018(registryKey);
			}
			RegistryKey registryKey2 = \u000E\u0009\u0016.\u0018(\u000C, \u000D\u001E\u0018.\u0018(\u0018, "\\Services\\diroots.prosheets"), true);
			if (registryKey2 != null)
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
				\u001B\u0009\u0016.\u0018(registryKey2, "AutoSaveDir", "%localappdata%\\DiRoots\\ProSheets\\Temp\\PDF");
				\u001B\u0009\u0016.\u0018(registryKey2, "AutoSaveFileCmd", "");
				\u001B\u0009\u0016.\u0018(registryKey2, "AutoSaveFilename", "$fileName");
				\u0005\u0009\u0016.\u0018(registryKey2, "AutoSaveOpenDir", 0, 4);
				\u0005\u0009\u0016.\u0018(registryKey2, "AutoSaveOverwriteFile", 1, 4);
				\u0005\u0009\u0016.\u0018(registryKey2, "AutoSaveShowProgress", 0, 4);
				\u0005\u0009\u0016.\u0018(registryKey2, "AutoSaveUseFileChooser", 0, 4);
				\u0005\u0009\u0016.\u0018(registryKey2, "AutoSaveUseFileCmd", 0, 4);
				\u001B\u0009\u0016.\u0018(registryKey2, "FilenameErasements", "");
				\u001B\u0009\u0016.\u0018(registryKey2, "Handler", "autoSave");
				\u0005\u0009\u0016.\u0018(registryKey2, "LoadInCreatorIfOpen", 0, 4);
				\u001B\u0009\u0016.\u0018(registryKey2, "ShellCmd", "");
				\u001B\u0009\u0016.\u0018(registryKey2, "Port", "\\\\.\\pipe\\PDFPrint - diroots.prosheets");
				\u0001\u0009\u0016.\u0018(registryKey2);
			}
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x00042FF4 File Offset: 0x000411F4
		public static void \u0014()
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Helper\\RegistryHandler.cs", "CheckExportTempPath");
			try
			{
				\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "checking PDFPRINT in Current User registry", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Helper\\RegistryHandler.cs", "CheckExportTempPath");
				\u0013\u001F\u0018.\u0014(\u0008\u0009\u0016.\u0018(-2147483647, 512), "SOFTWARE\\PDFPRINT");
				\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "checking PDF24 in Current User registry", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Helper\\RegistryHandler.cs", "CheckExportTempPath");
				\u0013\u001F\u0018.\u0014(\u0008\u0009\u0016.\u0018(-2147483647, 256), "SOFTWARE\\PDF24");
				\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "checking PDFPRINT in in LocalMachine registry", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Helper\\RegistryHandler.cs", "CheckExportTempPath");
				\u0013\u001F\u0018.\u0014(\u0008\u0009\u0016.\u0018(-2147483646, 256), "SOFTWARE\\PDFPRINT");
				\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "checking PDF24 in in LocalMachine registry", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Helper\\RegistryHandler.cs", "CheckExportTempPath");
				\u0013\u001F\u0018.\u0014(\u0008\u0009\u0016.\u0018(-2147483646, 256), "SOFTWARE\\PDF24");
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Helper\\RegistryHandler.cs", "CheckExportTempPath");
			}
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Helper\\RegistryHandler.cs", "CheckExportTempPath");
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x00043130 File Offset: 0x00041330
		private static void \u0014(RegistryKey \u000C, string \u0018)
		{
			try
			{
				RegistryKey registryKey = \u000E\u0009\u0016.\u0018(\u000C, \u000D\u001E\u0018.\u0018(\u0018, "\\Services\\diroots.prosheets"), false);
				if (registryKey != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001F\u0018.\u0014(RegistryKey, string)).MethodHandle;
					}
					object obj = \u0018\u000A\u0016.\u0018(registryKey, "AutoSaveDir");
					object service = IocContainer.GetService<ICustomLogger>();
					string u000C;
					if (obj == null)
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
						u000C = \u0005\u001E\u000F.\u000C;
					}
					else
					{
						u000C = \u0001\u0017\u0018.\u0018(obj);
					}
					string u;
					if (!\u001F\u001A\u0018.\u0018(u000C))
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
						u = \u0001\u0017\u0018.\u0018(obj);
					}
					else
					{
						u = "Path not found";
					}
					\u0008\u0017\u0018.\u0018(service, u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Helper\\RegistryHandler.cs", "CheckExportTempPath");
				}
			}
			catch (Exception u2)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Helper\\RegistryHandler.cs", "CheckExportTempPath");
			}
		}
	}
}
