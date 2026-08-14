using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using DiRoots.One.Commons.Logs;
using ProSheets;

namespace A
{
	// Token: 0x02000062 RID: 98
	internal static class \u001A\u0009\u0018
	{
		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000517 RID: 1303 RVA: 0x000195D4 File Offset: 0x000177D4
		// (set) Token: 0x06000518 RID: 1304 RVA: 0x000195E8 File Offset: 0x000177E8
		public static int CreationThresholdLimit { get; set; } = 300000;

		// Token: 0x06000519 RID: 1305 RVA: 0x000195FC File Offset: 0x000177FC
		public static void \u0014(string \u000C)
		{
			Logger u000C = \u0006\u001E\u0014.\u0018(\u0008\u001E\u0014.\u0018(\u000A\u0006\u0018.\u0018(Environment.SpecialFolder.LocalApplicationData), "DiRoots", "ProSheets", "Log"), "PdfMover");
			\u001E\u001E\u0014.\u0018(u000C, "PDF thread started", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PDFThread.cs", "DoStuff");
			\u001E\u001E\u0014.\u0018(u000C, \u000D\u001E\u0018.\u0018("Version Build ", \u000C), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PDFThread.cs", "DoStuff");
			\u001E\u001E\u0014.\u0018(u000C, \u000D\u001E\u0018.\u0018("Plugin Version: ", \u0001\u0017\u0018.\u0018(\u000C\u001F\u0014.\u0018(\u0018\u001F\u0014.\u0018(\u0014\u001F\u0014.\u0018(\u000A\u001D\u0018.\u0018(\u0007\u001A\u000F.\u000C())))))), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PDFThread.cs", "DoStuff");
			for (;;)
			{
				\u0013\u0017\u0014.\u0018(1000);
				for (;;)
				{
					IL_AE:
					List<PDFFile>.Enumerator enumerator = \u0010\u001E\u0014.\u0018(Enumerable.ToList<PDFFile>(\u001A\u0009\u0018.\u0018));
					try
					{
						while (\u0015\u001E\u0014.\u0018(ref enumerator))
						{
							PDFFile pdffile = \u0007\u001E\u0014.\u0018(ref enumerator);
							try
							{
								\u001E\u001E\u0014.\u0018(u000C, "=================================================", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PDFThread.cs", "DoStuff");
								\u001E\u001E\u0014.\u0018(u000C, \u000D\u001E\u0018.\u0018("Temp Path: ", \u0004\u001E\u0014.\u0018(pdffile)), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PDFThread.cs", "DoStuff");
								\u001E\u001E\u0014.\u0018(u000C, \u000D\u001E\u0018.\u0018("Destination Path: ", \u001D\u001E\u0014.\u0018(pdffile)), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PDFThread.cs", "DoStuff");
								\u0013\u0017\u0014.\u0018(100);
								while (!\u000C\u001A\u0018.\u0018(\u0004\u001E\u0014.\u0018(pdffile)))
								{
									if (\u000B\u001E\u0014.\u0018(pdffile) % 1000 == 0)
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
											RuntimeMethodHandle runtimeMethodHandle = methodof(\u001A\u0009\u0018.\u0014(string)).MethodHandle;
										}
										if (\u0003\u001F\u0018.\u0014())
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
											\u001E\u001E\u0014.\u0018(u000C, "File is not created.Error occurred in printer.", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PDFThread.cs", "DoStuff");
											\u0002\u001E\u0014.\u0018(\u001A\u0009\u0018.\u0018, pdffile);
											goto IL_AE;
										}
									}
									\u0013\u0017\u0014.\u0018(100);
									PDFFile u000C2 = pdffile;
									\u0019\u001E\u0014.\u0018(u000C2, \u000B\u001E\u0014.\u0018(u000C2) + 100);
									if (\u000B\u001E\u0014.\u0018(pdffile) > \u001A\u001E\u0014.\u0018())
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
										\u001E\u001E\u0014.\u0018(u000C, "File is not created. Waiting time exceeds the allowed threshold limit", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PDFThread.cs", "DoStuff");
										\u0002\u001E\u0014.\u0018(\u001A\u0009\u0018.\u0018, pdffile);
										goto IL_AE;
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
								\u001E\u001E\u0014.\u0018(u000C, "File now exists at temp path.", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PDFThread.cs", "DoStuff");
								\u0013\u0017\u0014.\u0018(200);
								try
								{
									int num = 10000;
									int num2 = 0;
									while (!\u001A\u0009\u0018.\u0003(\u0004\u001E\u0014.\u0018(pdffile)))
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
										if (num2 >= num)
										{
											for (;;)
											{
												switch (3)
												{
												case 0:
													continue;
												}
												goto IL_2C2;
											}
										}
										else
										{
											\u0013\u0017\u0014.\u0018(100);
											num2 += 100;
											if (num2 % 1000 == 0)
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
												if (\u0003\u001F\u0018.\u0014())
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
													\u001E\u001E\u0014.\u0018(u000C, "Error occurred in printer. Waiting time exceeds the allowed threshold limit", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PDFThread.cs", "DoStuff");
													\u0002\u001E\u0014.\u0018(\u001A\u0009\u0018.\u0018, pdffile);
													goto IL_AE;
												}
											}
										}
									}
									IL_2C2:;
								}
								catch (Exception u)
								{
									\u0017\u001E\u0014.\u0018(u000C, u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PDFThread.cs", "DoStuff");
								}
								\u001E\u001E\u0014.\u0018(u000C, "Preparing to move file to destination path.", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PDFThread.cs", "DoStuff");
								\u0019\u001E\u0014.\u0018(pdffile, 0);
								while (\u001A\u0009\u0018.\u0016(\u0004\u001E\u0014.\u0018(pdffile)))
								{
									\u0013\u0017\u0014.\u0018(100);
									if (\u000B\u001E\u0014.\u0018(pdffile) % 1000 == 0)
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
										if (\u0003\u001F\u0018.\u0014())
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
											\u001E\u001E\u0014.\u0018(u000C, "File not created.Error occurred in printer.", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PDFThread.cs", "DoStuff");
											\u0002\u001E\u0014.\u0018(\u001A\u0009\u0018.\u0018, pdffile);
											goto IL_AE;
										}
									}
									PDFFile u000C3 = pdffile;
									\u0019\u001E\u0014.\u0018(u000C3, \u000B\u001E\u0014.\u0018(u000C3) + 100);
									if (\u000B\u001E\u0014.\u0018(pdffile) > \u001A\u001E\u0014.\u0018())
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
										\u001E\u001E\u0014.\u0018(u000C, "Error occurred while moving file. Waiting time exceeds the allowed threshold limit", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PDFThread.cs", "DoStuff");
										\u0002\u001E\u0014.\u0018(\u001A\u0009\u0018.\u0018, pdffile);
										goto IL_AE;
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
								try
								{
									\u000D\u0020\u0014.\u0018(\u0004\u001E\u0014.\u0018(pdffile), \u001D\u001E\u0014.\u0018(pdffile), true);
									\u000C\u0020\u0014.\u0018(\u0004\u001E\u0014.\u0018(pdffile));
								}
								catch (Exception u2)
								{
									\u0017\u001E\u0014.\u0018(u000C, u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PDFThread.cs", "DoStuff");
								}
								\u0002\u001E\u0014.\u0018(\u001A\u0009\u0018.\u0018, pdffile);
								\u001E\u001E\u0014.\u0018(u000C, "File moved successfully.", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PDFThread.cs", "DoStuff");
							}
							catch (Exception u3)
							{
								\u0017\u001E\u0014.\u0018(u000C, u3, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PDFThread.cs", "DoStuff");
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
						break;
					}
					finally
					{
						((IDisposable)enumerator).Dispose();
					}
				}
			}
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x00019AD8 File Offset: 0x00017CD8
		public static bool \u0003(string \u000C)
		{
			if (\u0001\u001E\u0014.\u0018(\u001B\u001E\u0014.\u0018(\u000C)) > 0L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001A\u0009\u0018.\u0003(string)).MethodHandle;
				}
				return true;
			}
			return false;
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x00019B10 File Offset: 0x00017D10
		public static bool \u0016(string \u000C)
		{
			FileStream fileStream = \u0019\u001A\u000F.\u000C;
			try
			{
				fileStream = \u000E\u001E\u0014.\u0018(\u001B\u001E\u0014.\u0018(\u000C), FileMode.Open, FileAccess.Read, FileShare.None);
			}
			catch (IOException)
			{
				return true;
			}
			finally
			{
				if (fileStream != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001A\u0009\u0018.\u0016(string)).MethodHandle;
					}
					\u0005\u001E\u0014.\u0018(fileStream);
				}
			}
			return false;
		}

		// Token: 0x040001D5 RID: 469
		[CompilerGenerated]
		private static int \u000C;

		// Token: 0x040001D6 RID: 470
		public static List<PDFFile> \u0018 = \u0011\u001E\u0014.\u0018();
	}
}
