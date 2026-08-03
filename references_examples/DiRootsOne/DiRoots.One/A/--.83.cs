using System;
using System.IO;
using DiRoots.One.Commons.Excel;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.TGDatabaseLayer;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Pdf.Parsing;
using Syncfusion.XlsIO;

namespace A
{
	// Token: 0x02000134 RID: 308
	internal static class \u000F\u0016
	{
		// Token: 0x06000B90 RID: 2960 RVA: 0x000492EC File Offset: 0x000474EC
		internal static void \u001F(SelectedExcel \u001F)
		{
			int num = \u000D\u001B\u001D.\u0007(\u0002\u0003\u0004.\u0007(\u001F));
			if (num == 1)
			{
				\u000F\u0016.\u0007(\u001F);
				return;
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0016.\u001F(SelectedExcel)).MethodHandle;
			}
			if (num != 2)
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
				\u000F\u0016.\u000A(\u001F);
				return;
			}
			\u000F\u0016.\u001D(\u001F);
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x00049344 File Offset: 0x00047544
		private static void \u000A(SelectedExcel \u001F)
		{
			bool flag = true;
			for (;;)
			{
				try
				{
					ExcelEngine excelEngine = \u0008\u001E\u001D.\u000A();
					try
					{
						IApplication u001F = \u000E\u001E\u001D.\u000A(excelEngine);
						\u0010\u001E\u001D.\u000A(u001F, ExcelVersion.Excel2013);
						u001F.\u001F(\u0007\u0018.\u0007<ICustomLogger>());
						\u0019\u001A\u0004.\u000A(\u001C\u001E\u001D.\u000A(\u000D\u001E\u001D.\u000A(u001F), \u0011\u0020\u001D.\u0007(\u001F)));
					}
					finally
					{
						if (excelEngine != null)
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
							if (!true)
							{
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0016.\u000A(SelectedExcel)).MethodHandle;
							}
							\u001F\u0017\u000A.\u000A(excelEngine);
						}
					}
				}
				catch (NullReferenceException u000A)
				{
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\FileValidator.cs", "TestOpenExcelFile");
					if (flag)
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
						if (InteropUtility.\u001F(\u0011\u0020\u001D.\u0007(\u001F), \u0007\u0018.\u0007<ICustomLogger>()))
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
							flag = false;
							continue;
						}
					}
					throw;
				}
				break;
			}
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x00049420 File Offset: 0x00047620
		private static void \u0007(SelectedExcel \u001F)
		{
			try
			{
				WordDocument wordDocument = \u001D\u001A\u0004.\u000A();
				try
				{
					\u0007\u001A\u0004.\u000A(wordDocument, \u0011\u0020\u001D.\u0007(\u001F), FormatType.Docx);
				}
				finally
				{
					if (wordDocument != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0016.\u0007(SelectedExcel)).MethodHandle;
						}
						\u001F\u0017\u000A.\u000A(wordDocument);
					}
				}
			}
			catch (NullReferenceException u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\FileValidator.cs", "TestOpenWordFile");
				throw;
			}
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x0004949C File Offset: 0x0004769C
		private static void \u001D(SelectedExcel \u001F)
		{
			try
			{
				Stream stream = \u0014\u0010\u0004.\u000A(\u0011\u0020\u001D.\u0007(\u001F), FileMode.Open, FileAccess.Read);
				try
				{
					PdfLoadedDocument pdfLoadedDocument = \u001B\u0013\u0004.\u000A(stream);
					try
					{
					}
					finally
					{
						if (pdfLoadedDocument != null)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0016.\u001D(SelectedExcel)).MethodHandle;
							}
							\u001F\u0017\u000A.\u000A(pdfLoadedDocument);
						}
					}
				}
				finally
				{
					if (stream != null)
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
						\u001F\u0017\u000A.\u000A(stream);
					}
				}
			}
			catch (NullReferenceException u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\FileValidator.cs", "TestPdfFile");
				throw;
			}
		}
	}
}
