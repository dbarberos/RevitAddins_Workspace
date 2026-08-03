using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Commons.ViewModel;
using ProSheets.Enums;
using ProSheets.Helpers;
using ProSheets.Models;
using ProSheets.ScheduleAssistant.UI;
using ProSheets.UI;

namespace ProSheets
{
	// Token: 0x0200005C RID: 92
	public class ExportExternalEvent : IExternalEventHandler, IDocumentValidator
	{
		// Token: 0x1400000D RID: 13
		// (add) Token: 0x0600044E RID: 1102 RVA: 0x00017168 File Offset: 0x00015368
		// (remove) Token: 0x0600044F RID: 1103 RVA: 0x000171B4 File Offset: 0x000153B4
		public event ExportExternalEvent.ExportFinishedHandler ExportFinished
		{
			[CompilerGenerated]
			add
			{
				ExportExternalEvent.ExportFinishedHandler exportFinishedHandler = this.\u000C;
				ExportExternalEvent.ExportFinishedHandler exportFinishedHandler2;
				do
				{
					exportFinishedHandler2 = exportFinishedHandler;
					ExportExternalEvent.ExportFinishedHandler value2 = (ExportExternalEvent.ExportFinishedHandler)\u001C\u0019\u0018.\u0018(exportFinishedHandler2, value);
					exportFinishedHandler = Interlocked.CompareExchange<ExportExternalEvent.ExportFinishedHandler>(ref this.\u000C, value2, exportFinishedHandler2);
				}
				while (exportFinishedHandler != exportFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportExternalEvent.add_ExportFinished(ExportExternalEvent.ExportFinishedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ExportExternalEvent.ExportFinishedHandler exportFinishedHandler = this.\u000C;
				ExportExternalEvent.ExportFinishedHandler exportFinishedHandler2;
				do
				{
					exportFinishedHandler2 = exportFinishedHandler;
					ExportExternalEvent.ExportFinishedHandler value2 = (ExportExternalEvent.ExportFinishedHandler)\u0013\u0019\u0018.\u0018(exportFinishedHandler2, value);
					exportFinishedHandler = Interlocked.CompareExchange<ExportExternalEvent.ExportFinishedHandler>(ref this.\u000C, value2, exportFinishedHandler2);
				}
				while (exportFinishedHandler != exportFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportExternalEvent.remove_ExportFinished(ExportExternalEvent.ExportFinishedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000450 RID: 1104 RVA: 0x00017200 File Offset: 0x00015400
		// (remove) Token: 0x06000451 RID: 1105 RVA: 0x0001724C File Offset: 0x0001544C
		public event ExportExternalEvent.ExportReportHandler ExportReport
		{
			[CompilerGenerated]
			add
			{
				ExportExternalEvent.ExportReportHandler exportReportHandler = this.\u0018;
				ExportExternalEvent.ExportReportHandler exportReportHandler2;
				do
				{
					exportReportHandler2 = exportReportHandler;
					ExportExternalEvent.ExportReportHandler value2 = (ExportExternalEvent.ExportReportHandler)\u001C\u0019\u0018.\u0018(exportReportHandler2, value);
					exportReportHandler = Interlocked.CompareExchange<ExportExternalEvent.ExportReportHandler>(ref this.\u0018, value2, exportReportHandler2);
				}
				while (exportReportHandler != exportReportHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportExternalEvent.add_ExportReport(ExportExternalEvent.ExportReportHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ExportExternalEvent.ExportReportHandler exportReportHandler = this.\u0018;
				ExportExternalEvent.ExportReportHandler exportReportHandler2;
				do
				{
					exportReportHandler2 = exportReportHandler;
					ExportExternalEvent.ExportReportHandler value2 = (ExportExternalEvent.ExportReportHandler)\u0013\u0019\u0018.\u0018(exportReportHandler2, value);
					exportReportHandler = Interlocked.CompareExchange<ExportExternalEvent.ExportReportHandler>(ref this.\u0018, value2, exportReportHandler2);
				}
				while (exportReportHandler != exportReportHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportExternalEvent.remove_ExportReport(ExportExternalEvent.ExportReportHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06000452 RID: 1106 RVA: 0x00017298 File Offset: 0x00015498
		// (remove) Token: 0x06000453 RID: 1107 RVA: 0x000172E4 File Offset: 0x000154E4
		public event ExportExternalEvent.ExportNeedsCleanPrinterHandler ExportNeedsCleanPrinter
		{
			[CompilerGenerated]
			add
			{
				ExportExternalEvent.ExportNeedsCleanPrinterHandler exportNeedsCleanPrinterHandler = this.\u0014;
				ExportExternalEvent.ExportNeedsCleanPrinterHandler exportNeedsCleanPrinterHandler2;
				do
				{
					exportNeedsCleanPrinterHandler2 = exportNeedsCleanPrinterHandler;
					ExportExternalEvent.ExportNeedsCleanPrinterHandler value2 = (ExportExternalEvent.ExportNeedsCleanPrinterHandler)\u001C\u0019\u0018.\u0018(exportNeedsCleanPrinterHandler2, value);
					exportNeedsCleanPrinterHandler = Interlocked.CompareExchange<ExportExternalEvent.ExportNeedsCleanPrinterHandler>(ref this.\u0014, value2, exportNeedsCleanPrinterHandler2);
				}
				while (exportNeedsCleanPrinterHandler != exportNeedsCleanPrinterHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportExternalEvent.add_ExportNeedsCleanPrinter(ExportExternalEvent.ExportNeedsCleanPrinterHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ExportExternalEvent.ExportNeedsCleanPrinterHandler exportNeedsCleanPrinterHandler = this.\u0014;
				ExportExternalEvent.ExportNeedsCleanPrinterHandler exportNeedsCleanPrinterHandler2;
				do
				{
					exportNeedsCleanPrinterHandler2 = exportNeedsCleanPrinterHandler;
					ExportExternalEvent.ExportNeedsCleanPrinterHandler value2 = (ExportExternalEvent.ExportNeedsCleanPrinterHandler)\u0013\u0019\u0018.\u0018(exportNeedsCleanPrinterHandler2, value);
					exportNeedsCleanPrinterHandler = Interlocked.CompareExchange<ExportExternalEvent.ExportNeedsCleanPrinterHandler>(ref this.\u0014, value2, exportNeedsCleanPrinterHandler2);
				}
				while (exportNeedsCleanPrinterHandler != exportNeedsCleanPrinterHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportExternalEvent.remove_ExportNeedsCleanPrinter(ExportExternalEvent.ExportNeedsCleanPrinterHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000454 RID: 1108 RVA: 0x00017330 File Offset: 0x00015530
		// (remove) Token: 0x06000455 RID: 1109 RVA: 0x0001737C File Offset: 0x0001557C
		public event ExportExternalEvent.ExportProgressHandler ExportProgress
		{
			[CompilerGenerated]
			add
			{
				ExportExternalEvent.ExportProgressHandler exportProgressHandler = this.\u0003;
				ExportExternalEvent.ExportProgressHandler exportProgressHandler2;
				do
				{
					exportProgressHandler2 = exportProgressHandler;
					ExportExternalEvent.ExportProgressHandler value2 = (ExportExternalEvent.ExportProgressHandler)\u001C\u0019\u0018.\u0018(exportProgressHandler2, value);
					exportProgressHandler = Interlocked.CompareExchange<ExportExternalEvent.ExportProgressHandler>(ref this.\u0003, value2, exportProgressHandler2);
				}
				while (exportProgressHandler != exportProgressHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportExternalEvent.add_ExportProgress(ExportExternalEvent.ExportProgressHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ExportExternalEvent.ExportProgressHandler exportProgressHandler = this.\u0003;
				ExportExternalEvent.ExportProgressHandler exportProgressHandler2;
				do
				{
					exportProgressHandler2 = exportProgressHandler;
					ExportExternalEvent.ExportProgressHandler value2 = (ExportExternalEvent.ExportProgressHandler)\u0013\u0019\u0018.\u0018(exportProgressHandler2, value);
					exportProgressHandler = Interlocked.CompareExchange<ExportExternalEvent.ExportProgressHandler>(ref this.\u0003, value2, exportProgressHandler2);
				}
				while (exportProgressHandler != exportProgressHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportExternalEvent.remove_ExportProgress(ExportExternalEvent.ExportProgressHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x06000456 RID: 1110 RVA: 0x000173C8 File Offset: 0x000155C8
		// (remove) Token: 0x06000457 RID: 1111 RVA: 0x00017414 File Offset: 0x00015614
		public event ExportExternalEvent.InterruptedByUserHandler InterruptedByUser
		{
			[CompilerGenerated]
			add
			{
				ExportExternalEvent.InterruptedByUserHandler interruptedByUserHandler = this.\u0016;
				ExportExternalEvent.InterruptedByUserHandler interruptedByUserHandler2;
				do
				{
					interruptedByUserHandler2 = interruptedByUserHandler;
					ExportExternalEvent.InterruptedByUserHandler value2 = (ExportExternalEvent.InterruptedByUserHandler)\u001C\u0019\u0018.\u0018(interruptedByUserHandler2, value);
					interruptedByUserHandler = Interlocked.CompareExchange<ExportExternalEvent.InterruptedByUserHandler>(ref this.\u0016, value2, interruptedByUserHandler2);
				}
				while (interruptedByUserHandler != interruptedByUserHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportExternalEvent.add_InterruptedByUser(ExportExternalEvent.InterruptedByUserHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ExportExternalEvent.InterruptedByUserHandler interruptedByUserHandler = this.\u0016;
				ExportExternalEvent.InterruptedByUserHandler interruptedByUserHandler2;
				do
				{
					interruptedByUserHandler2 = interruptedByUserHandler;
					ExportExternalEvent.InterruptedByUserHandler value2 = (ExportExternalEvent.InterruptedByUserHandler)\u0013\u0019\u0018.\u0018(interruptedByUserHandler2, value);
					interruptedByUserHandler = Interlocked.CompareExchange<ExportExternalEvent.InterruptedByUserHandler>(ref this.\u0016, value2, interruptedByUserHandler2);
				}
				while (interruptedByUserHandler != interruptedByUserHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportExternalEvent.remove_InterruptedByUser(ExportExternalEvent.InterruptedByUserHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x06000458 RID: 1112 RVA: 0x00017460 File Offset: 0x00015660
		// (remove) Token: 0x06000459 RID: 1113 RVA: 0x000174AC File Offset: 0x000156AC
		public event ExportExternalEvent.ShouldClosePDFHandler ShouldClosePDF
		{
			[CompilerGenerated]
			add
			{
				ExportExternalEvent.ShouldClosePDFHandler shouldClosePDFHandler = this.\u000F;
				ExportExternalEvent.ShouldClosePDFHandler shouldClosePDFHandler2;
				do
				{
					shouldClosePDFHandler2 = shouldClosePDFHandler;
					ExportExternalEvent.ShouldClosePDFHandler value2 = (ExportExternalEvent.ShouldClosePDFHandler)\u001C\u0019\u0018.\u0018(shouldClosePDFHandler2, value);
					shouldClosePDFHandler = Interlocked.CompareExchange<ExportExternalEvent.ShouldClosePDFHandler>(ref this.\u000F, value2, shouldClosePDFHandler2);
				}
				while (shouldClosePDFHandler != shouldClosePDFHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportExternalEvent.add_ShouldClosePDF(ExportExternalEvent.ShouldClosePDFHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ExportExternalEvent.ShouldClosePDFHandler shouldClosePDFHandler = this.\u000F;
				ExportExternalEvent.ShouldClosePDFHandler shouldClosePDFHandler2;
				do
				{
					shouldClosePDFHandler2 = shouldClosePDFHandler;
					ExportExternalEvent.ShouldClosePDFHandler value2 = (ExportExternalEvent.ShouldClosePDFHandler)\u0013\u0019\u0018.\u0018(shouldClosePDFHandler2, value);
					shouldClosePDFHandler = Interlocked.CompareExchange<ExportExternalEvent.ShouldClosePDFHandler>(ref this.\u000F, value2, shouldClosePDFHandler2);
				}
				while (shouldClosePDFHandler != shouldClosePDFHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportExternalEvent.remove_ShouldClosePDF(ExportExternalEvent.ShouldClosePDFHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x0600045A RID: 1114 RVA: 0x000174F8 File Offset: 0x000156F8
		// (set) Token: 0x0600045B RID: 1115 RVA: 0x0001750C File Offset: 0x0001570C
		public bool IsScheduleExport { get; set; }

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x0600045C RID: 1116 RVA: 0x00017520 File Offset: 0x00015720
		// (set) Token: 0x0600045D RID: 1117 RVA: 0x00017534 File Offset: 0x00015734
		public ProgessBarWindow ProgressBarWindow { get; set; }

		// Token: 0x0600045E RID: 1118 RVA: 0x00017548 File Offset: 0x00015748
		public void Execute(UIApplication app)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ExportExternalEvent.cs", "Execute");
			ExportExternalEvent.IsExporting = true;
			UIDocument uidocument = \u001F\u001F\u0014.\u0018(app);
			Document u = \u0017\u0005\u0018.\u0014(\u001F\u001F\u0014.\u0018(app));
			\u0020\u0015\u0014.\u0018(\u0004\u0005\u0018.\u0018().GetService<ActiveDocumentHandler>(false), this);
			object u000C = \u0009\u0015\u0014.\u0018(\u000A\u0015\u0014.\u0018(uidocument));
			EventHandler<FailuresProcessingEventArgs> u2;
			if ((u2 = ExportExternalEvent.\u0015\u0009\u0018.\u000C) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportExternalEvent.Execute(UIApplication)).MethodHandle;
				}
				u2 = (ExportExternalEvent.\u0015\u0009\u0018.\u000C = new EventHandler<FailuresProcessingEventArgs>(\u0008\u001F\u0018.\u000C));
			}
			\u0017\u0015\u0014.\u0018(u000C, u2);
			\u0011\u0015\u0014.\u0018(\u0015\u0015\u0014.\u0018(uidocument), \u0007\u0004\u0018.\u0018());
			\u001F\u0015\u0014.\u0018(this, uidocument, u);
			\u0020\u0015\u0014.\u0018(\u0004\u0005\u0018.\u0018().GetService<ActiveDocumentHandler>(false), \u000B\u001A\u000F.\u000C);
			object u000C2 = \u0009\u0015\u0014.\u0018(\u000A\u0015\u0014.\u0018(uidocument));
			EventHandler<FailuresProcessingEventArgs> u3;
			if ((u3 = ExportExternalEvent.\u0015\u0009\u0018.\u000C) == null)
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
				u3 = (ExportExternalEvent.\u0015\u0009\u0018.\u000C = new EventHandler<FailuresProcessingEventArgs>(\u0008\u001F\u0018.\u000C));
			}
			\u0013\u0015\u0014.\u0018(u000C2, u3);
			ExportExternalEvent.IsExporting = false;
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ExportExternalEvent.cs", "Execute");
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00017670 File Offset: 0x00015870
		public bool IsValid(ActiveDocumentHandler documentHandler)
		{
			return false;
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x00017680 File Offset: 0x00015880
		public bool ExportFiles(UIDocument uiDoc, Document objDoc)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ExportExternalEvent.cs", "ExportFiles");
			if (\u0013\u001E\u0014.\u0018(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportExternalEvent.ExportFiles(UIDocument, Document)).MethodHandle;
				}
				this.\u000D = \u001C\u001E\u0014.\u0018();
				\u0012\u001E\u0014.\u0018(this, \u000D\u001E\u0014.\u0018());
				\u001C\u000B\u0018.\u0014(\u001E\u0015\u0014.\u0018(this), this.\u000D);
				\u000F\u001E\u0014.\u0018(\u001E\u0015\u0014.\u0018(this));
				\u0016\u001E\u0014.\u0018(this.\u000D, \u001E\u0015\u0014.\u0018(this));
				\u0003\u001E\u0014.\u0018(this.\u000D, \u0002\u0005\u0018.\u0018(\u001C\u0017\u0014.\u0018()), "Processing");
			}
			\u0018\u001E\u0014.\u0018(\u0014\u001E\u0014.\u0018());
			\u0002\u0015\u0014.\u0018(false);
			\u0019\u0011\u0018.\u0003();
			DateTime u = \u0019\u0015\u0014.\u0018();
			DateTime u2 = \u0019\u0015\u0014.\u0018();
			DateTime u3 = \u0019\u0015\u0014.\u0018();
			DateTime u4 = \u0019\u0015\u0014.\u0018();
			DateTime u000F = \u0019\u0015\u0014.\u0018();
			DateTime u5 = \u0019\u0015\u0014.\u0018();
			DateTime u000D = \u0019\u0015\u0014.\u0018();
			DateTime u001C = \u0019\u0015\u0014.\u0018();
			\u001D\u0015\u0014.\u0018(false);
			\u0004\u0015\u0014.\u0018("");
			bool flag = false;
			Create.printed_views = 0;
			\u0013\u001F\u0018.\u000C();
			\u0005\u001F\u0018 u0005_u001F_u = new \u0005\u001F\u0018(IocContainer.GetService<ICustomLogger>());
			\u0001\u001F\u0018 u0001_u001F_u = new \u0001\u001F\u0018();
			try
			{
				bool flag2 = Enumerable.Any<RevitLinkInstance>(\u000F\u000A\u0018.\u0016\u0018<RevitLinkInstance>(objDoc));
				\u0016\u0020\u0018 u0016_u0020_u = \u0004\u001A\u000F.\u000C;
				if (flag2)
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
					u0016_u0020_u = new \u0016\u0020\u0018(uiDoc);
				}
				Create.objFaildFile = \u0011\u0002\u0018.\u0018();
				\u000F\u000A\u0018 u000F_u000A_u = new \u000F\u000A\u0018();
				string text = string.Empty;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				List<string> u000C = \u0011\u0002\u0018.\u0018();
				List<SheetInfo>.Enumerator enumerator;
				if (\u0007\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "PDF"))
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
					if (\u000B\u0017\u0014.\u0018())
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
						u3 = \u0019\u0015\u0014.\u0018();
						string text2 = "";
						enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
						try
						{
							while (\u0019\u000E\u0018.\u0018(ref enumerator))
							{
								SheetInfo u000C2 = \u000C\u000C\u0014.\u0018(ref enumerator);
								if (\u000F\u0002\u0018.\u0018(\u0010\u0020\u0014.\u0014(u000C2), "PDF"))
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
									text2 = \u0004\u0017\u0014.\u0018(u000C2);
									goto IL_23F;
								}
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
						}
						finally
						{
							((IDisposable)enumerator).Dispose();
						}
						IL_23F:
						string text3 = "";
						enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
						try
						{
							while (\u0019\u000E\u0018.\u0018(ref enumerator))
							{
								SheetInfo u000C3 = \u000C\u000C\u0014.\u0018(ref enumerator);
								if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(u000C3), "PDF"))
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
									text3 = \u0011\u0017\u0014.\u0014(u000C3);
									goto IL_2B6;
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
						finally
						{
							((IDisposable)enumerator).Dispose();
						}
						IL_2B6:
						if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0014.\u0018(), "Revit Native"))
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
							\u001B\u0017\u0014.\u0018(\u000D\u0015\u0014.\u0018(), true);
							List<View> list = \u000C\u001E\u0014.\u0018();
							enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
							try
							{
								while (\u0019\u000E\u0018.\u0018(ref enumerator))
								{
									SheetInfo u000C4 = \u000C\u000C\u0014.\u0018(ref enumerator);
									\u000E\u0017\u0014.\u0018(list, \u000F\u000A\u0018.\u0014\u0014(objDoc, \u001D\u001A\u000F.\u000C(\u0003\u0004\u0018.\u0018(objDoc, \u0015\u0005\u0018.\u0014(u000C4)))));
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
							\u001F\u0017\u0014.\u0018(\u000D\u0015\u0014.\u0018(), list);
							\u000F\u000A\u0018 u000F_u000A_u2 = u000F_u000A_u;
							string u6 = ".pdf";
							string u7 = text;
							string u8 = text2;
							string u9 = text3;
							IEnumerable<SheetInfo> enumerable = \u001C\u0017\u0014.\u0018();
							Func<SheetInfo, bool> func;
							if ((func = ExportExternalEvent.<>c.\u0018) == null)
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
								func = (ExportExternalEvent.<>c.\u0018 = new Func<SheetInfo, bool>(ExportExternalEvent.<>c.\u000C.\u0016));
							}
							flag3 = u000F_u000A_u2.\u000C\u0014(objDoc, u6, u7, u8, u9, Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable, func)), true);
							\u001B\u0017\u0014.\u0018(\u000D\u0015\u0014.\u0018(), false);
						}
						else
						{
							for (;;)
							{
								flag3 = u000F_u000A_u.\u0011\u0018(objDoc, ".pdf", text2, text3);
								\u0010\u0017\u0014.\u0018(\u0006\u0017\u0014.\u0018());
								if (!\u0016\u0017\u0014.\u0018())
								{
									break;
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
								\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Combined PDF - PDF24 failed and ask the user to clean printer", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ExportExternalEvent.cs", "ExportFiles");
								if (flag)
								{
									break;
								}
								for (;;)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									break;
								}
								flag = true;
								\u0002\u0017\u0014.\u0018(this.\u0014);
								if (!\u001E\u0017\u0014.\u0018())
								{
									break;
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
								\u001D\u0015\u0014.\u0018(false);
								\u0004\u0015\u0014.\u0018("");
							}
						}
						u4 = \u0019\u0015\u0014.\u0018();
					}
				}
				if (\u0007\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "DWF"))
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
					if (\u0017\u0017\u0014.\u0018())
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
						u000F = \u0019\u0015\u0014.\u0018();
						string u10 = "";
						enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
						try
						{
							while (\u0019\u000E\u0018.\u0018(ref enumerator))
							{
								SheetInfo u000C5 = \u000C\u000C\u0014.\u0018(ref enumerator);
								if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(u000C5), "DWF"))
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
									u10 = \u0011\u0017\u0014.\u0014(u000C5);
									goto IL_51C;
								}
							}
							for (;;)
							{
								switch (5)
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
						IL_51C:
						\u001B\u0017\u0014.\u0018(\u000D\u0015\u0014.\u0018(), true);
						object u000C6 = \u001C\u0017\u0014.\u0018();
						Predicate<SheetInfo> u11;
						if ((u11 = ExportExternalEvent.<>c.\u0014) == null)
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
							u11 = (ExportExternalEvent.<>c.\u0014 = new Predicate<SheetInfo>(ExportExternalEvent.<>c.\u000C.\u000F));
						}
						ExportExternalEvent.\u0013(\u0005\u0017\u0014.\u0018(u000C6, u11));
						flag4 = u000F_u000A_u.\u0015\u0018(objDoc, u10);
						\u0010\u0017\u0014.\u0018(\u0006\u0017\u0014.\u0018());
						\u001B\u0017\u0014.\u0018(\u000D\u0015\u0014.\u0018(), false);
						u5 = \u0019\u0015\u0014.\u0018();
					}
				}
				string u000C7 = \u0001\u0017\u0014.\u0018();
				if (\u0007\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "Image"))
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
					if (\u0020\u0017\u0014.\u0018())
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
						\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Canceled by user and will show message", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ExportExternalEvent.cs", "ExportFiles");
						u000D = \u0019\u0015\u0014.\u0018();
						flag5 = u000F_u000A_u.\u0017\u0018(objDoc);
						\u0010\u0017\u0014.\u0018(\u0006\u0017\u0014.\u0018());
						u001C = \u0019\u0015\u0014.\u0018();
					}
				}
				int num = 0;
				int num2 = 0;
				enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
				try
				{
					while (\u0019\u000E\u0018.\u0018(ref enumerator))
					{
						SheetInfo sheetInfo = \u000C\u000C\u0014.\u0018(ref enumerator);
						\u0009\u0017\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
						\u001F\u0017\u0014.\u0018(\u000D\u0015\u0014.\u0018(), \u001A\u001A\u000F.\u000C);
						int u12 = num * 100 / \u0002\u0005\u0018.\u0018(\u001C\u0017\u0014.\u0018());
						ExportExternalEvent.ExportProgressHandler u13 = this.\u0003;
						if (u13 == null)
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
						}
						else
						{
							\u000D\u0017\u0014.\u0018(u13, u12);
						}
						ProgressModel u000D2 = this.\u000D;
						if (u000D2 == null)
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
						}
						else
						{
							Delegate @delegate = \u0012\u0017\u0014.\u0014(u000D2);
							if (@delegate == null)
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
							}
							else
							{
								object[] array = \u0008\u001E\u000F.\u000C(1);
								array[0] = num;
								\u000F\u0017\u0014.\u0018(@delegate, array);
							}
						}
						if (\u0005\u0015\u0014.\u0018())
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
							\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Canceled by user and will show message", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ExportExternalEvent.cs", "ExportFiles");
							goto IL_E65;
						}
						View view = \u001D\u001A\u000F.\u000C(\u0003\u0004\u0018.\u0018(objDoc, \u0015\u0005\u0018.\u0014(sheetInfo)));
						if (view != null)
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
							bool flag6 = false;
							if (!\u001F\u001A\u0018.\u0018(\u001F\u000E\u0018.\u0018(sheetInfo)))
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
								text = \u000C\u000A\u0018.\u001A(objDoc, sheetInfo, view);
							}
							if (\u001F\u001A\u0018.\u0018(\u001F\u000E\u0018.\u0018(sheetInfo)))
							{
								goto IL_793;
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
							if (\u000F\u0002\u0018.\u0018(text, string.Empty))
							{
								for (;;)
								{
									switch (6)
									{
									case 0:
										continue;
									}
									goto IL_793;
								}
							}
							IL_79E:
							bool flag7 = false;
							string u14 = \u0014\u001E\u0018.\u0018(text, ".", \u0015\u000C\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo)));
							if (!\u0007\u0017\u0014.\u0018(u000C, u14))
							{
								goto IL_7F0;
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
							if (\u000B\u0017\u0014.\u0018())
							{
								goto IL_7F0;
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
							flag7 = true;
							IL_7F9:
							if (!flag7)
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
								if (!\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "PDF"))
								{
									goto IL_9D2;
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
								if (\u000B\u0017\u0014.\u0018())
								{
									goto IL_9D2;
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
								\u0009\u0017\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
								if (\u001A\u0017\u0014.\u0018(u000C7, "Revit Native"))
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
									\u001F\u0017\u0014.\u0018(\u000D\u0015\u0014.\u0018(), \u000F\u000A\u0018.\u0014\u0014(objDoc, view));
									\u000F\u000A\u0018 u000F_u000A_u3 = u000F_u000A_u;
									string u15 = ".pdf";
									string u16 = text;
									string u17 = \u0004\u0017\u0014.\u0018(sheetInfo);
									string u18 = \u0011\u0017\u0014.\u0014(sheetInfo);
									List<SheetInfo> list2 = \u001D\u0017\u0014.\u0018();
									\u0007\u000E\u0018.\u0018(list2, sheetInfo);
									flag6 = u000F_u000A_u3.\u000C\u0014(objDoc, u15, u16, u17, u18, list2, false);
									if (\u001A\u0003\u0014.\u0018(view) != 6)
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
										Create.printed_views++;
									}
								}
								else
								{
									for (;;)
									{
										flag6 = u000F_u000A_u.\u000D\u0018(objDoc, view, ".pdf", text, \u0004\u0017\u0014.\u0018(sheetInfo), \u0011\u0017\u0014.\u0014(sheetInfo), sheetInfo);
										if (!\u0016\u0017\u0014.\u0018())
										{
											break;
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
										\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Single PDF - PDF24 error", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ExportExternalEvent.cs", "ExportFiles");
										if (flag)
										{
											goto IL_9BF;
										}
										for (;;)
										{
											switch (5)
											{
											case 0:
												continue;
											}
											break;
										}
										flag = true;
										\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Single PDF - Show clean message", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ExportExternalEvent.cs", "ExportFiles");
										\u0002\u0017\u0014.\u0018(this.\u0014);
										if (!\u001E\u0017\u0014.\u0018())
										{
											goto IL_9BF;
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
										\u001D\u0015\u0014.\u0018(false);
										\u0004\u0015\u0014.\u0018("");
									}
									if (\u001A\u0003\u0014.\u0018(view) != 6)
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
										Create.printed_views++;
									}
								}
								IL_9BF:
								\u000E\u0015\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
								IL_CE7:
								\u0013\u0017\u0014.\u0018(200);
								goto IL_CF1;
								IL_9D2:
								if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "DWF"))
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
									if (!\u0017\u0017\u0014.\u0018())
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
										\u0009\u0017\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
										\u001F\u0017\u0014.\u0018(\u000D\u0015\u0014.\u0018(), \u000F\u000A\u0018.\u0014\u0014(objDoc, view));
										ExportExternalEvent.\u0013(sheetInfo);
										\u000F\u000A\u0018 u000F_u000A_u4 = u000F_u000A_u;
										View u19 = view;
										string u20;
										if (!\u0015\u0017\u0014.\u0018())
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
											u20 = ".dwf";
										}
										else
										{
											u20 = ".dwfx";
										}
										flag6 = u000F_u000A_u4.\u001C\u0018(objDoc, u19, u20, text, \u0011\u0017\u0014.\u0014(sheetInfo), sheetInfo);
										\u000E\u0015\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
										goto IL_CE7;
									}
								}
								if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "DWG"))
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
									\u0009\u0017\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
									\u001F\u0017\u0014.\u0018(\u000D\u0015\u0014.\u0018(), \u000F\u000A\u0018.\u0014\u0014(objDoc, view));
									IEnumerable<SheetInfo> enumerable2 = \u001C\u0017\u0014.\u0018();
									Func<SheetInfo, bool> func2;
									if ((func2 = ExportExternalEvent.<>c.\u0003) == null)
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
										func2 = (ExportExternalEvent.<>c.\u0003 = new Func<SheetInfo, bool>(ExportExternalEvent.<>c.\u000C.\u0012));
									}
									bool u21 = Enumerable.Count<SheetInfo>(enumerable2, func2) == num2 + 1;
									flag6 = u0005_u001F_u.\u0009(objDoc, view, text, sheetInfo, u21);
									num2++;
									\u000E\u0015\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
									goto IL_CE7;
								}
								if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "DGN"))
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
									\u0009\u0017\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
									flag6 = u0001_u001F_u.\u0016(objDoc, view, text, sheetInfo);
									\u000E\u0015\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
									goto IL_CE7;
								}
								if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "NWC"))
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
									\u0009\u0017\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
									flag6 = u000F_u000A_u.\u000E\u0018(objDoc, view, text, sheetInfo);
									\u000E\u0015\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
									goto IL_CE7;
								}
								if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "Image"))
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
									if (!\u0020\u0017\u0014.\u0018())
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
										\u0009\u0017\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
										flag6 = u000F_u000A_u.\u001E\u0018(objDoc, view, text, sheetInfo);
										\u000E\u0015\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
										goto IL_CE7;
									}
								}
								if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "IFC"))
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
									\u0009\u0017\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
									flag6 = u000F_u000A_u.\u001B\u0018(objDoc, view, text, sheetInfo, false, u0016_u0020_u);
									\u000E\u0015\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
									goto IL_CE7;
								}
								if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "XML"))
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
									\u0009\u0017\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
									flag6 = \u0002\u0011\u0018.\u000C(view, text, sheetInfo);
									\u000E\u0015\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
									goto IL_CE7;
								}
								goto IL_CE7;
							}
							IL_CF1:
							num++;
							u12 = num * 100 / \u0002\u0005\u0018.\u0018(\u001C\u0017\u0014.\u0018());
							ExportExternalEvent.ExportProgressHandler u22 = this.\u0003;
							if (u22 == null)
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
							}
							else
							{
								\u000D\u0017\u0014.\u0018(u22, u12);
							}
							ProgressModel u000D3 = this.\u000D;
							if (u000D3 == null)
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
							}
							else
							{
								Delegate delegate2 = \u0012\u0017\u0014.\u0014(u000D3);
								if (delegate2 == null)
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
								}
								else
								{
									object[] array2 = \u0008\u001E\u000F.\u000C(1);
									array2[0] = num;
									\u000F\u0017\u0014.\u0018(delegate2, array2);
								}
							}
							if (!flag7)
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
								if (flag5 || flag4 || flag3 || flag6)
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
									\u0018\u0017\u0014.\u0014(sheetInfo, \u001C\u0009\u0018.\u000C\u0003);
									\u000C\u0017\u0014.\u0018(sheetInfo, PublishStatus.Success);
								}
								else
								{
									if (\u0016\u0017\u0014.\u0018())
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
										\u0018\u0017\u0014.\u0014(sheetInfo, \u000D\u001E\u0018.\u0018(\u001C\u0009\u0018.\u0018\u0003, \u0003\u0017\u0014.\u0018()));
									}
									else if (\u001F\u001A\u0018.\u0018(\u0014\u0017\u0014.\u0018(sheetInfo)))
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
										\u0018\u0017\u0014.\u0014(sheetInfo, \u001C\u0009\u0018.\u0014\u0003);
									}
									\u000C\u0017\u0014.\u0018(sheetInfo, PublishStatus.Failed);
								}
							}
							else
							{
								\u0018\u0017\u0014.\u0014(sheetInfo, \u001C\u0009\u0018.\u0003\u0003);
								\u000C\u0017\u0014.\u0018(sheetInfo, PublishStatus.Failed);
							}
							\u000E\u0015\u0014.\u0018(sheetInfo, \u0019\u0015\u0014.\u0018());
							continue;
							IL_7F0:
							\u0019\u0017\u0014.\u0018(u000C, u14);
							goto IL_7F9;
							IL_793:
							text = \u001E\u000E\u0018.\u0014(sheetInfo);
							goto IL_79E;
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
				IL_E65:
				if (u0016_u0020_u != null)
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
					u0016_u0020_u.\u0012();
				}
				if (\u0005\u0015\u0014.\u0018())
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
					ExportExternalEvent.InterruptedByUserHandler u23 = this.\u0016;
					if (u23 == null)
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
					}
					else
					{
						\u001B\u0015\u0014.\u0018(u23);
					}
				}
				else if (\u0001\u0015\u0014.\u0018(Create.objFaildFile) > 0)
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
					string text4 = string.Empty;
					List<string>.Enumerator enumerator2 = \u0008\u0015\u0014.\u0018(Create.objFaildFile);
					try
					{
						while (\u0010\u0015\u0014.\u0018(ref enumerator2))
						{
							string u24 = \u0006\u0015\u0014.\u0018(ref enumerator2);
							text4 = \u0014\u001E\u0018.\u0018(text4, "\n", u24);
						}
						for (;;)
						{
							switch (5)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					finally
					{
						((IDisposable)enumerator2).Dispose();
					}
					\u0007\u0015\u0014.\u0018(this.\u000F, text4);
				}
				else
				{
					u2 = \u0019\u0015\u0014.\u0018();
					ExportExternalEvent.ExportFinishedHandler u000C8 = this.\u000C;
					if (u000C8 == null)
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
					}
					else
					{
						\u000B\u0015\u0014.\u0018(u000C8, u, u2, u3, u4, u000F, u5, u000D, u001C);
					}
				}
				ExportExternalEvent.ExportReportHandler u25 = this.\u0018;
				if (u25 == null)
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
				}
				else
				{
					\u001A\u0015\u0014.\u0018(u25, u, u2, u3, u4, u000F, u5, u000D, u001C);
				}
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ExportExternalEvent.cs", "ExportFiles");
			}
			catch (Exception u26)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u26, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ExportExternalEvent.cs", "ExportFiles");
			}
			\u001D\u0015\u0014.\u0018(false);
			\u0004\u0015\u0014.\u0018("");
			\u0002\u0015\u0014.\u0018(false);
			ProgessBarWindow progessBarWindow = \u001E\u0015\u0014.\u0018(this);
			if (progessBarWindow == null)
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
			}
			else
			{
				\u000B\u000B\u0018.\u0003(progessBarWindow);
			}
			return true;
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00018728 File Offset: 0x00016928
		private static void \u0013(SheetInfo \u000C)
		{
			PageOrientationType u000C;
			if (!\u000C.\u0014())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportExternalEvent.\u0013(SheetInfo)).MethodHandle;
				}
				u000C = 0;
			}
			else
			{
				u000C = 1;
			}
			\u0009\u001E\u0014.\u0018(u000C);
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x0001875C File Offset: 0x0001695C
		public static void CreateEvent()
		{
			if (ExportExternalEvent.HandlerInstance == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportExternalEvent.CreateEvent()).MethodHandle;
				}
				ExportExternalEvent.HandlerInstance = \u0020\u001E\u0014.\u0018();
				ExportExternalEvent.HandlerEvent = \u000A\u001E\u0014.\u0018(ExportExternalEvent.HandlerInstance);
			}
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x000187A0 File Offset: 0x000169A0
		public string GetName()
		{
			return "Export External Event";
		}

		// Token: 0x04000171 RID: 369
		public static ExternalEvent HandlerEvent;

		// Token: 0x04000172 RID: 370
		public static ExportExternalEvent HandlerInstance;

		// Token: 0x04000173 RID: 371
		[CompilerGenerated]
		private ExportExternalEvent.ExportFinishedHandler \u000C;

		// Token: 0x04000174 RID: 372
		[CompilerGenerated]
		private ExportExternalEvent.ExportReportHandler \u0018;

		// Token: 0x04000175 RID: 373
		[CompilerGenerated]
		private ExportExternalEvent.ExportNeedsCleanPrinterHandler \u0014;

		// Token: 0x04000176 RID: 374
		[CompilerGenerated]
		private ExportExternalEvent.ExportProgressHandler \u0003;

		// Token: 0x04000177 RID: 375
		[CompilerGenerated]
		private ExportExternalEvent.InterruptedByUserHandler \u0016;

		// Token: 0x04000178 RID: 376
		[CompilerGenerated]
		private ExportExternalEvent.ShouldClosePDFHandler \u000F;

		// Token: 0x04000179 RID: 377
		public static bool IsExporting;

		// Token: 0x0400017A RID: 378
		[CompilerGenerated]
		private bool \u0012;

		// Token: 0x0400017B RID: 379
		private ProgressModel \u000D;

		// Token: 0x0400017C RID: 380
		[CompilerGenerated]
		private ProgessBarWindow \u001C;

		// Token: 0x02000171 RID: 369
		// (Invoke) Token: 0x0600109A RID: 4250
		public delegate void ExportFinishedHandler(DateTime startTime, DateTime endTime, DateTime combinePdfStart, DateTime combinePdfEnd, DateTime combineDwfStart, DateTime combineDwfEnd, DateTime combineImgStart, DateTime combineImgEnd);

		// Token: 0x02000172 RID: 370
		// (Invoke) Token: 0x0600109E RID: 4254
		public delegate void ExportReportHandler(DateTime startTime, DateTime endTime, DateTime combinePdfStart, DateTime combinePdfEnd, DateTime combineDwfStart, DateTime combineDwfEnd, DateTime combineImgStart, DateTime combineImgEnd);

		// Token: 0x02000173 RID: 371
		// (Invoke) Token: 0x060010A2 RID: 4258
		public delegate void ExportNeedsCleanPrinterHandler();

		// Token: 0x02000174 RID: 372
		// (Invoke) Token: 0x060010A6 RID: 4262
		public delegate void ExportProgressHandler(int percent);

		// Token: 0x02000175 RID: 373
		// (Invoke) Token: 0x060010AA RID: 4266
		public delegate void InterruptedByUserHandler();

		// Token: 0x02000176 RID: 374
		// (Invoke) Token: 0x060010AE RID: 4270
		public delegate void ShouldClosePDFHandler(string path);

		// Token: 0x02000177 RID: 375
		[CompilerGenerated]
		private static class \u0015\u0009\u0018
		{
			// Token: 0x040007A1 RID: 1953
			public static EventHandler<FailuresProcessingEventArgs> \u000C;
		}
	}
}
