using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Services;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.SheetGen;
using DiRoots.One.SheetGen.Core.Helpers;
using DiRoots.One.SheetGen.Core.Models;
using DiRoots.One.SheetGen.Core.Services;
using DiRoots.One.SheetGen.Data;
using DiRoots.One.SheetGen.Models;
using DiRoots.One.SheetGen.Services;
using DiRoots.Revit.DataCollectors;

namespace A
{
	// Token: 0x0200029D RID: 669
	internal class \u000A\u0008 : \u001F\u001B<SheetInfo>
	{
		// Token: 0x06001A1F RID: 6687 RVA: 0x000A81D4 File Offset: 0x000A63D4
		public \u000A\u0008(\u0015\u001A \u001F, ISheetNumberValidationService \u000A, ICancellationManagerService \u0007, ICustomLogger \u001D, \u000B\u000C \u0004, ISheetFinalRenumberingService \u0019) : base(\u001F, \u000A, \u0007, \u001D, \u0019)
		{
			\u0008\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\CreateSheetsEvent.cs", ".ctor");
			this.\u001C\u000A = \u0004;
			this.\u0010\u000A = new SheetAndViewCreationHelper();
			\u0005\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\CreateSheetsEvent.cs", ".ctor");
		}

		// Token: 0x1700072F RID: 1839
		// (get) Token: 0x06001A20 RID: 6688 RVA: 0x000A823C File Offset: 0x000A643C
		// (set) Token: 0x06001A21 RID: 6689 RVA: 0x000A8250 File Offset: 0x000A6450
		public IEnumerable<ProjectInformationParameterModel> ProjectInformationToProcess { get; set; } = Array.Empty<ProjectInformationParameterModel>();

		// Token: 0x17000730 RID: 1840
		// (get) Token: 0x06001A22 RID: 6690 RVA: 0x000A8264 File Offset: 0x000A6464
		// (set) Token: 0x06001A23 RID: 6691 RVA: 0x000A8278 File Offset: 0x000A6478
		public bool IsDelete { get; internal set; }

		// Token: 0x17000731 RID: 1841
		// (get) Token: 0x06001A24 RID: 6692 RVA: 0x000A828C File Offset: 0x000A648C
		// (set) Token: 0x06001A25 RID: 6693 RVA: 0x000A82A0 File Offset: 0x000A64A0
		public bool ApplyTemplateVisibility { get; set; }

		// Token: 0x17000732 RID: 1842
		// (get) Token: 0x06001A26 RID: 6694 RVA: 0x000A82B4 File Offset: 0x000A64B4
		// (set) Token: 0x06001A27 RID: 6695 RVA: 0x000A82C8 File Offset: 0x000A64C8
		public bool UseApiSheetDuplication { get; set; }

		// Token: 0x17000733 RID: 1843
		// (get) Token: 0x06001A28 RID: 6696 RVA: 0x000A82DC File Offset: 0x000A64DC
		// (set) Token: 0x06001A29 RID: 6697 RVA: 0x000A82F0 File Offset: 0x000A64F0
		public bool BenchmarkPerformance { get; set; }

		// Token: 0x17000734 RID: 1844
		// (get) Token: 0x06001A2A RID: 6698 RVA: 0x000A8304 File Offset: 0x000A6504
		private \u0015\u001A \u0015\u0018
		{
			get
			{
				return \u0005\u0003\u000E.\u001F(this.\u001E\u0007);
			}
		}

		// Token: 0x06001A2B RID: 6699 RVA: 0x000A8320 File Offset: 0x000A6520
		public override void Execute(UIApplication app)
		{
			try
			{
				if (\u0009\u0007\u0016.\u000A(this))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0008.Execute(UIApplication)).MethodHandle;
					}
					this.\u000E\u000A = \u000A\u001D\u0016.\u000A(\u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app)));
					this.\u0015\u0018.\u0006(this.\u000E\u000A);
					\u000E\u0011\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), "ApplyTemplateVisibilityOptimization is enabled.", "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\CreateSheetsEvent.cs", "Execute");
				}
				if (\u001F\u001D\u0016.\u000A(this))
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
					this.\u0003\u000A = new \u001E\u001A(\u0015\u0007\u0016.\u000A(this), \u0009\u0007\u0016.\u000A(this));
				}
				this.\u001B\u000A = \u0001\u0007\u0016.\u000A(\u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app)));
				\u000C\u0007\u0016.\u000A(this.\u0015\u0018, \u0015\u0007\u0016.\u000A(this));
				this.\u000B\u0019(app);
			}
			catch (OperationCanceledException u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\CreateSheetsEvent.cs", "Execute");
			}
			catch (Exception u000A2)
			{
				\u001A\u0007\u0016.\u000A(\u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app)), "Reset Templates", new Action(this.\u0005\u0005), new Action<Exception>(this.\u0016\u0005));
				\u000F\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\CreateSheetsEvent.cs", "Execute");
				\u000D\u0014\u0004.\u000A(\u0013\u0007\u0016.\u000A(), u000A2, true);
			}
		}

		// Token: 0x06001A2C RID: 6700 RVA: 0x000A8494 File Offset: 0x000A6694
		protected override void \u000B\u0019(UIApplication \u001F)
		{
			\u000A\u0008.\u001A\u000E u001A_u000E = new \u000A\u0008.\u001A\u000E();
			u001A_u000E.\u001F = this;
			\u001E\u001A u0003_u000A = this.\u0003\u000A;
			if (u0003_u000A == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0008.\u000B\u0019(UIApplication)).MethodHandle;
				}
			}
			else
			{
				u0003_u000A.\u0019();
			}
			\u0008\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\CreateSheetsEvent.cs", "ExecuteInternal");
			u001A_u000E.\u001D = \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(\u001F));
			IEnumerable<SheetInfo> enumerable = \u0004\u001D\u0016.\u000A(this);
			Func<SheetInfo, bool> func;
			if ((func = \u000A\u0008.<>c.\u000A) == null)
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
				func = (\u000A\u0008.<>c.\u000A = new Func<SheetInfo, bool>(\u000A\u0008.<>c.\u001F.\u000F));
			}
			List<SheetInfo> list = Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable, func));
			u001A_u000E.\u000A = \u001D\u001D\u0016.\u000A(list);
			u001A_u000E.\u0007 = 0;
			if (!\u0007\u001D\u0016.\u000A(this))
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
				\u000A\u0008.\u000C\u000E u000C_u000E = new \u000A\u0008.\u000C\u000E();
				u000C_u000E.\u001D = u001A_u000E;
				this.\u001F\u0005(u000C_u000E.\u001D.\u001D);
				base.\u001C\u0016(list);
				u000C_u000E.\u001D.\u000A = \u001D\u001D\u0016.\u000A(list);
				if (u000C_u000E.\u001D.\u000A == 0)
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
					\u0005\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\CreateSheetsEvent.cs", "ExecuteInternal");
					return;
				}
				TransactionGroup transactionGroup = \u0009\u0017\u0007.\u000A(u000C_u000E.\u001D.\u001D, "SheetGen_ApplyModifications");
				try
				{
					\u0001\u0017\u0007.\u000A(transactionGroup);
					\u001E\u001A u0003_u000A2 = this.\u0003\u000A;
					if (u0003_u000A2 == null)
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
						u0003_u000A2.\u0018();
					}
					\u001A\u0007\u0016.\u000A(u000C_u000E.\u001D.\u001D, "Create Temp Template", new Action(u000C_u000E.\u001D.\u0004), \u0018\u0003\u000E.\u001F);
					IEnumerable<SheetInfo> enumerable2 = list;
					Func<SheetInfo, bool> func2;
					if ((func2 = \u000A\u0008.<>c.\u0007) == null)
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
						func2 = (\u000A\u0008.<>c.\u0007 = new Func<SheetInfo, bool>(\u000A\u0008.<>c.\u001F.\u0012));
					}
					IEnumerable<SheetInfo> u001F = Enumerable.Where<SheetInfo>(enumerable2, func2);
					this.\u0009\u0018(u001F, new Action<SheetInfo>(u000C_u000E.\u001D.\u0019));
					\u001E\u001A u0003_u000A3 = this.\u0003\u000A;
					if (u0003_u000A3 == null)
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
						u0003_u000A3.\u0005();
					}
					\u000A\u0008.\u000C\u000E u000C_u000E2 = u000C_u000E;
					Action<\u0011\u000C<SheetInfo>> u001F2;
					if (!this.\u0008\u000A)
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
						u001F2 = new Action<\u0011\u000C<SheetInfo>>(u000C_u000E.\u001D.\u0005);
					}
					else
					{
						u001F2 = new Action<\u0011\u000C<SheetInfo>>(u000C_u000E.\u001D.\u0018);
					}
					u000C_u000E2.\u001F = u001F2;
					\u000A\u0008.\u000C\u000E u000C_u000E3 = u000C_u000E;
					IEnumerable<SheetInfo> enumerable3 = list;
					Func<SheetInfo, bool> func3;
					if ((func3 = \u000A\u0008.<>c.\u001D) == null)
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
						func3 = (\u000A\u0008.<>c.\u001D = new Func<SheetInfo, bool>(\u000A\u0008.<>c.\u001F.\u0003));
					}
					u000C_u000E3.\u000A = Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable3, func3));
					this.\u000F\u0019(u000C_u000E.\u001D.\u001D, u000C_u000E.\u000A, new Action<\u0011\u000C<SheetInfo>>(u000C_u000E.\u0004));
					\u001E\u001A u0003_u000A4 = this.\u0003\u000A;
					if (u0003_u000A4 == null)
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
						u0003_u000A4.\u000B();
					}
					\u000A\u0008.\u000C\u000E u000C_u000E4 = u000C_u000E;
					IEnumerable<SheetInfo> enumerable4 = list;
					Func<SheetInfo, bool> func4;
					if ((func4 = \u000A\u0008.<>c.\u0004) == null)
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
						func4 = (\u000A\u0008.<>c.\u0004 = new Func<SheetInfo, bool>(\u000A\u0008.<>c.\u001F.\u001C));
					}
					u000C_u000E4.\u0007 = Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable4, func4));
					this.\u0002\u0019(u000C_u000E.\u001D.\u001D, u000C_u000E.\u0007, new Action<SheetInfo>(u000C_u000E.\u001D.\u0016));
					IEnumerable<SheetInfo> enumerable5 = list;
					Func<SheetInfo, bool> func5;
					if ((func5 = \u000A\u0008.<>c.\u0019) == null)
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
						func5 = (\u000A\u0008.<>c.\u0019 = new Func<SheetInfo, bool>(\u000A\u0008.<>c.\u001F.\u000D));
					}
					List<SheetInfo> sheets = Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable5, func5));
					this.\u0017\u0007.ApplySheetNumbers<SheetInfo>(u000C_u000E.\u001D.\u001D, sheets, this.\u0011\u0007);
					if (this.\u000E\u000A != null)
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
						\u001E\u001A u0003_u000A5 = this.\u0003\u000A;
						if (u0003_u000A5 == null)
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
							u0003_u000A5.\u0002();
						}
						\u001A\u0007\u0016.\u000A(u000C_u000E.\u001D.\u001D, "Reset Templates", new Action(this.\u000E\u000A.RestoreTemplates), new Action<Exception>(u000C_u000E.\u001D.\u000B));
						\u001A\u0007\u0016.\u000A(u000C_u000E.\u001D.\u001D, "ReApply ViewPort Position", new Action(u000C_u000E.\u0019), new Action<Exception>(u000C_u000E.\u001D.\u0002));
						\u001E\u001A u0003_u000A6 = this.\u0003\u000A;
						if (u0003_u000A6 == null)
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
						}
						else
						{
							u0003_u000A6.\u0006();
						}
					}
					\u0009\u0004\u001D.\u000A(this, \u000C\u0017\u0007.\u000A(transactionGroup) == 3);
					base.\u000F\u0016(\u0014\u0019\u001D.\u0007(this), \u0007\u001D\u0016.\u000A(this));
					goto IL_516;
				}
				finally
				{
					if (transactionGroup != null)
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
						\u001F\u0017\u000A.\u000A(transactionGroup);
					}
				}
			}
			TransactionGroup transactionGroup2 = \u0009\u0017\u0007.\u000A(u001A_u000E.\u001D, "SheetGen_DeleteSheets");
			try
			{
				\u0001\u0017\u0007.\u000A(transactionGroup2);
				IEnumerable<SheetInfo> enumerable6 = list;
				Func<SheetInfo, bool> func6;
				if ((func6 = \u000A\u0008.<>c.\u0018) == null)
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
					func6 = (\u000A\u0008.<>c.\u0018 = new Func<SheetInfo, bool>(\u000A\u0008.<>c.\u001F.\u0010));
				}
				IEnumerable<SheetInfo> u001F3 = Enumerable.Where<SheetInfo>(enumerable6, func6);
				this.\u0009\u0018(u001F3, new Action<SheetInfo>(u001A_u000E.\u0006));
				\u0009\u0004\u001D.\u000A(this, \u000C\u0017\u0007.\u000A(transactionGroup2) == 3);
				base.\u000F\u0016(\u0014\u0019\u001D.\u0007(this), \u0007\u001D\u0016.\u000A(this));
			}
			finally
			{
				if (transactionGroup2 != null)
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
					\u001F\u0017\u000A.\u000A(transactionGroup2);
				}
			}
			IL_516:
			\u001E\u001A u0003_u000A7 = this.\u0003\u000A;
			if (u0003_u000A7 == null)
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
			}
			else
			{
				u0003_u000A7.\u000F(\u0002\u0013\u000A.\u000A(\u0020\u0005\u0004.\u000A(\u001A\u0007\u001D.\u000A(\u001F)), "-", \u0014\u0009\u0007.\u0007(u001A_u000E.\u001D)));
			}
			\u0005\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\CreateSheetsEvent.cs", "ExecuteInternal");
		}

		// Token: 0x06001A2D RID: 6701 RVA: 0x000A8A48 File Offset: 0x000A6C48
		private void \u0001\u0018(Document \u001F, List<SheetInfo> \u000A)
		{
			List<SheetInfo>.Enumerator enumerator = \u0017\u0007\u0016.\u000A(\u000A);
			try
			{
				while (\u000D\u0007\u0016.\u000A(ref enumerator))
				{
					List<ViewInfo>.Enumerator enumerator2 = \u0008\u001D\u0016.\u000A(\u001B\u001D\u0016.\u0007(\u0020\u0007\u0016.\u000A(ref enumerator)));
					try
					{
						while (\u0019\u001D\u0016.\u000A(ref enumerator2))
						{
							ViewInfo u001F = \u000E\u001D\u0016.\u000A(ref enumerator2);
							if (\u0010\u001D\u0016.\u000A(u001F))
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
									RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0008.\u0001\u0018(Document, List<SheetInfo>)).MethodHandle;
								}
								Viewport viewport = \u001F.AsElement(\u000D\u001D\u0016.\u000A(u001F));
								if (viewport != null)
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
									\u001C\u001D\u0016.\u000A(u001F, false);
									\u000F\u001D\u0016.\u000A(viewport, \u0012\u001D\u0016.\u000A(\u0003\u001D\u0016.\u000A(u001F)));
									if (\u0006\u001D\u0016.\u000A(u001F) != null)
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
										\u0002\u001D\u0016.\u000A(viewport, \u0006\u001D\u0016.\u000A(u001F));
										\u0016\u001D\u0016.\u000A(viewport, \u000B\u001D\u0016.\u000A(u001F));
										\u0005\u001D\u0016.\u000A(u001F, \u0020\u0009\u0010.\u001F);
										\u0018\u001D\u0016.\u000A(u001F, 0.0);
									}
								}
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
						((IDisposable)enumerator2).Dispose();
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
		}

		// Token: 0x06001A2E RID: 6702 RVA: 0x000A8BB4 File Offset: 0x000A6DB4
		private void \u0009\u0018(IEnumerable<SheetInfo> \u001F, Action<SheetInfo> \u000A)
		{
			IEnumerator<SheetDeletionResult> enumerator = \u0015\u001D\u0016.\u000A(\u0001\u001D\u0016.\u0007(this.\u001C\u000A.\u0004(\u001F, this.\u0014\u0007)));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					SheetDeletionResult u001F = \u000C\u001D\u0016.\u000A(enumerator);
					SheetInfo sheetInfo = \u0019\u0003\u000E.\u001F(\u001A\u001D\u0016.\u000A(u001F));
					if (\u000A != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0008.\u0009\u0018(IEnumerable<SheetInfo>, Action<SheetInfo>)).MethodHandle;
						}
						\u0013\u001D\u0016.\u000A(\u000A, sheetInfo);
					}
					if (\u0014\u001D\u0016.\u0007(u001F))
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
						\u0017\u001D\u0016.\u000A(\u0014\u0007\u0016.\u000A(), sheetInfo);
					}
					else
					{
						\u0011\u001D\u0016.\u000A(this.\u0011\u0007, \u001F\u001B<SheetInfo>.\u000B\u0005(sheetInfo, \u0020\u001D\u0016.\u000A(u001F), \u001E\u001D\u0016.\u000A(u001F)));
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}

		// Token: 0x06001A2F RID: 6703 RVA: 0x000A8CA8 File Offset: 0x000A6EA8
		protected override void \u0002\u0019(Document \u001F, IEnumerable<SheetInfo> \u000A, Action<SheetInfo> \u0007)
		{
			\u000A\u0008.\u0015\u000E u0015_u000E = new \u000A\u0008.\u0015\u000E();
			u0015_u000E.\u001F = this;
			u0015_u000E.\u000A = \u001F;
			IEnumerator<SheetInfo> enumerator = \u0016\u0004\u0016.\u000A(\u000A);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u000A\u0008.\u0001\u000E u0001_u000E = new \u000A\u0008.\u0001\u000E();
					u0001_u000E.\u001D = u0015_u000E;
					u0001_u000E.\u001F = \u0005\u0004\u0016.\u000A(enumerator);
					\u0018\u0004\u0016.\u000A(this.\u0014\u0007);
					\u0013\u001D\u0016.\u000A(\u0007, u0001_u000E.\u001F);
					string u000A = \u001E\u0020\u001D.\u000A("SheetGen_ApplyModification", \u0011\u0007\u0016.\u0007(u0001_u000E.\u001F), "-", \u0019\u0004\u0016.\u0007(u0001_u000E.\u001F));
					\u0008\u0008\u000A u0008_u0008_u000A = base.\u0012\u0016("");
					u0001_u000E.\u000A = false;
					u0001_u000E.\u0007 = false;
					TransactionStatus u001F = \u0004\u0004\u0016.\u000A(u0001_u000E.\u001D.\u000A, u000A, u0008_u0008_u000A, new Action(u0001_u000E.\u0004), new Action<Exception>(u0001_u000E.\u0019));
					if (u0001_u000E.\u000A)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0008.\u0002\u0019(Document, IEnumerable<SheetInfo>, Action<SheetInfo>)).MethodHandle;
						}
						\u0007\u0004\u0016.\u000A(u0001_u000E.\u001F, SheetTemplate.\u0006(\u001D\u0004\u0016.\u0007(u0001_u000E.\u001F), \u001B\u001D\u0016.\u0007(u0001_u000E.\u001F), null, false));
					}
					\u001F\u0004\u0016.\u0007(\u000A\u0004\u0016.\u0007(u0008_u0008_u000A));
					if (u001F.\u0018())
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
						if (!u0001_u000E.\u0007)
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
							this.\u0006\u0019(u0001_u000E.\u001D.\u000A, u0001_u000E.\u001F, \u0009\u001D\u0016.\u000A(u0008_u0008_u000A));
						}
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}

		// Token: 0x06001A30 RID: 6704 RVA: 0x000A8E64 File Offset: 0x000A7064
		protected void \u001F\u0005(Document \u001F)
		{
			\u000A\u0008.\u0009\u000E u0009_u000E = new \u000A\u0008.\u0009\u000E();
			u0009_u000E.\u000A = this;
			u0009_u000E.\u001F = Enumerable.ToList<ProjectInformationParameterModel>(\u0002\u0004\u0016.\u000A(this));
			if (!Enumerable.Any<ProjectInformationParameterModel>(u0009_u000E.\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0008.\u001F\u0005(Document)).MethodHandle;
				}
				return;
			}
			u0009_u000E.\u0007 = base.\u0012\u0016("");
			TransactionStatus u001F = \u0004\u0004\u0016.\u000A(\u001F, "SheetGen - Apply Modifications", u0009_u000E.\u0007, new Action(u0009_u000E.\u001D), new Action<Exception>(u0009_u000E.\u0004));
			\u001F\u0004\u0016.\u0007(\u000A\u0004\u0016.\u0007(u0009_u000E.\u0007));
			if (u001F.\u0018())
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
				object u001F2 = u0009_u000E.\u001F;
				Action<ProjectInformationParameterModel> u000A;
				if ((u000A = \u000A\u0008.<>c.\u0016) == null)
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
					u000A = (\u000A\u0008.<>c.\u0016 = new Action<ProjectInformationParameterModel>(\u000A\u0008.<>c.\u001F.\u0008));
				}
				\u000B\u0004\u0016.\u000A(u001F2, u000A);
				\u0011\u001D\u0016.\u000A(this.\u0011\u0007, \u001F\u001B<SheetInfo>.\u000D\u0016(\u0009\u001D\u0016.\u000A(u0009_u000E.\u0007)));
			}
		}

		// Token: 0x06001A31 RID: 6705 RVA: 0x000A8F6C File Offset: 0x000A716C
		protected override void \u0006\u0019(Document \u001F, SheetInfo \u000A, string \u0007)
		{
			base.\u0006\u0019(\u001F, \u000A, \u0007);
			if (\u0006\u0004\u0016.\u0007(\u000A) == UpdateStates.Modified)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0008.\u0006\u0019(Document, SheetInfo, string)).MethodHandle;
				}
				\u000A.OO();
			}
		}

		// Token: 0x06001A32 RID: 6706 RVA: 0x000A8FA8 File Offset: 0x000A71A8
		internal static bool \u000A\u0005(Document \u001F)
		{
			IEnumerable<ViewSheet> enumerable = Enumerable.ToList<ViewSheet>(\u001F.CollectElementsOfCategory(-2003100L, null));
			Func<ViewSheet, bool> func;
			if ((func = \u000A\u0008.<>c.\u000B) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0008.\u000A\u0005(Document)).MethodHandle;
				}
				func = (\u000A\u0008.<>c.\u000B = new Func<ViewSheet, bool>(\u000A\u0008.<>c.\u001F.\u001B));
			}
			if (Enumerable.Any<ViewSheet>(enumerable, func))
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
				bool? flag = \u0018\u0020\u000A.\u0007(\u0020\u0019\u001D.\u000A(\u000F\u0004\u0016.\u000A(), MessageBoxButtons.OKCancel));
				return \u0012\u0015\u000A.\u000A(ref flag);
			}
			return true;
		}

		// Token: 0x06001A33 RID: 6707 RVA: 0x000A9034 File Offset: 0x000A7234
		private unsafe void \u0007\u0005(SheetInfo \u001F, out bool \u000A)
		{
			\u000A\u0008.\u001F\u0008 u001F_u = new \u000A\u0008.\u001F\u0008();
			u001F_u.\u001F = this;
			u001F_u.\u0007 = \u001F;
			\u0008\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\CreateSheetsEvent.cs", "ModifyExistingSheet");
			\u000A = false;
			Document document = \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004);
			Element u001F = \u0007\u0018\u0016.\u000A(document, \u001D\u0004\u0016.\u0007(u001F_u.\u0007));
			u001F_u.\u000A = \u0015\u001D\u000E.\u001F(u001F);
			if (u001F_u.\u000A == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0008.\u0007\u0005(SheetInfo, bool*)).MethodHandle;
				}
				\u0005\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\CreateSheetsEvent.cs", "ModifyExistingSheet");
				return;
			}
			SheetStoredData sheetStoredData = \u000A\u0018\u0016.\u000A();
			\u001F\u0018\u0016.\u000A(u001F_u.\u0007, \u0020\u0008\u001D.\u000A(u001F_u.\u000A));
			object u = u001F_u.\u0007;
			object u2 = u001F_u.\u0007;
			object u000A = u001F_u.\u000A;
			string text;
			if (!\u001A\u0006\u0007.\u000A(\u0019\u0004\u0016.\u0007(u001F_u.\u0007)))
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
				text = \u0019\u0004\u0016.\u0007(u001F_u.\u0007);
			}
			else
			{
				text = "Unnamed";
			}
			string text2;
			\u0011\u0013\u0007.\u000A(u000A, text2 = text);
			string u000A2;
			\u0009\u0019\u0016.\u000A(u2, u000A2 = text2);
			\u0001\u0019\u0016.\u000A(u, u000A2);
			this.\u001E\u0007.\u0002(u001F_u.\u0007, u001F_u.\u000A);
			if (\u0015\u0019\u0016.\u000A(u001F_u.\u0007))
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
				IEnumerator<ElementId> enumerator = \u000B\u0013\u0007.\u000A(\u000C\u0019\u0016.\u000A(u001F_u.\u000A));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						ElementId u000A3 = \u0016\u0013\u0007.\u000A(enumerator);
						\u0011\u0001\u000A.\u000A(document, u000A3);
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
					if (enumerator != null)
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
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
				\u001A\u0019\u0016.\u0007(u001F_u.\u0007, false);
			}
			IEnumerable<ViewInfo> enumerable = \u001B\u001D\u0016.\u0007(u001F_u.\u0007);
			Func<ViewInfo, bool> func;
			if ((func = \u000A\u0008.<>c.\u0002) == null)
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
				func = (\u000A\u0008.<>c.\u0002 = new Func<ViewInfo, bool>(\u000A\u0008.<>c.\u001F.\u0011));
			}
			if (Enumerable.Any<ViewInfo>(enumerable, func))
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
				\u000A = true;
			}
			List<ViewInfo>.Enumerator enumerator2 = \u0008\u001D\u0016.\u000A(\u001B\u001D\u0016.\u0007(u001F_u.\u0007));
			try
			{
				while (\u0019\u001D\u0016.\u000A(ref enumerator2))
				{
					ViewInfo viewInfo = \u000E\u001D\u0016.\u000A(ref enumerator2);
					Element element = SheetAndViewCreationHelper.\u0004(document, \u000D\u001D\u0016.\u000A(viewInfo));
					if (element == null)
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
						ViewSheet viewSheet = document.AsElement(\u001B\u0007\u0016.\u0007(\u0008\u0007\u0016.\u0007(u001F_u.\u0007)));
						if (viewSheet != null)
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
							\u0013\u0019\u0016.\u000A(this.\u001B\u000A, viewInfo, viewSheet);
						}
					}
					if (\u001A\u0006\u0007.\u000A(\u0014\u0019\u0016.\u0007(\u0002\u0019\u0016.\u0007(viewInfo))))
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
						if (\u0007\u0003\u000E.\u001F(element) == null)
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
							if (\u001D\u0003\u000E.\u001F(element) == null)
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
								if (\u0004\u0003\u000E.\u001F(element) == null)
								{
									continue;
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
						}
						Viewport viewport = \u0007\u0003\u000E.\u001F(element);
						if (viewport != null)
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
							XYZ u001F2 = \u0005\u0019\u0016.\u000A(viewport);
							\u0019\u0019\u0016.\u0007(viewInfo, \u0018\u0019\u0016.\u000A(u001F2));
						}
						else
						{
							ScheduleSheetInstance scheduleSheetInstance = \u001D\u0003\u000E.\u001F(element);
							if (scheduleSheetInstance != null)
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
								BoundingBoxXYZ u001F3 = \u0002\u0004\u0007.\u000A(scheduleSheetInstance, u001F_u.\u000A);
								XYZ u001F4 = \u0003\u0007\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F3), \u000B\u0004\u0007.\u000A(u001F3)), 0.5);
								\u0019\u0019\u0016.\u0007(viewInfo, \u0018\u0019\u0016.\u000A(u001F4));
							}
							else
							{
								PanelScheduleSheetInstance panelScheduleSheetInstance = \u0004\u0003\u000E.\u001F(element);
								if (panelScheduleSheetInstance != null)
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
									BoundingBoxXYZ u001F5 = \u0002\u0004\u0007.\u000A(panelScheduleSheetInstance, u001F_u.\u000A);
									XYZ u001F6 = \u0003\u0007\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F5), \u000B\u0004\u0007.\u000A(u001F5)), 0.5);
									\u0019\u0019\u0016.\u0007(viewInfo, \u0018\u0019\u0016.\u000A(u001F6));
								}
							}
						}
						\u000C\u0004\u0016.\u0007(viewInfo, 0L);
						\u0017\u0019\u0016.\u0007(viewInfo, \u0002\u0019\u0016.\u0007(viewInfo));
						\u0020\u0019\u0016.\u0007(viewInfo, UpdateStates.Updated);
						\u0011\u0001\u000A.\u000A(document, \u0002\u001E\u000A.\u0007(element));
					}
					else
					{
						ViewportStoredData viewportStoredData;
						if (element == null)
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
							viewportStoredData = null;
						}
						else
						{
							viewportStoredData = element.\u000A<ViewportStoredData>();
						}
						ViewportStoredData viewportStoredData2;
						if ((viewportStoredData2 = viewportStoredData) == null)
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
							\u0011\u0019\u0016.\u0007(viewportStoredData2 = \u001E\u0019\u0016.\u000A(), \u0002\u0005\u0018.\u000A().ToString());
						}
						ViewportStoredData viewportStoredData3 = viewportStoredData2;
						\u001A\u0008\u0007.\u000A(\u001B\u0019\u0016.\u000A(sheetStoredData), \u0008\u0019\u0016.\u0007(viewportStoredData3));
						if (\u000E\u0019\u0016.\u0007(viewInfo))
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
							\u001C\u001D\u0016.\u000A(viewInfo, true);
							View view = \u0005\u001F\u000E.\u001F(SheetAndViewCreationHelper.\u0004(document, \u000B\u0019\u0016.\u0007(\u0002\u0019\u0016.\u0007(viewInfo))));
							if (view != null)
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
								if (\u001D\u0019\u0016.\u0007(viewInfo) != 5)
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
									if (\u001D\u0019\u0016.\u0007(viewInfo) != 123)
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
										ElementId elementId = \u0012\u0015\u0010.\u001F;
										if (\u001C\u001C\u0007.\u0007(view) == 11)
										{
											goto IL_554;
										}
										for (;;)
										{
											switch (3)
											{
											case 0:
												continue;
											}
											break;
										}
										if (\u001D\u0019\u0016.\u0007(viewInfo) == 5)
										{
											goto IL_554;
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
										if (\u001D\u0019\u0016.\u0007(viewInfo) == 123)
										{
											for (;;)
											{
												switch (5)
												{
												case 0:
													continue;
												}
												goto IL_554;
											}
										}
										else if (\u0010\u0019\u0016.\u000A(this.\u0010\u000A, document, view))
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
											string u001D = \u0004\u001E\u000A.\u000A(" - Sheet ", \u0006\u000B\u001D.\u000A(\u0020\u0008\u001D.\u000A(u001F_u.\u000A)));
											ViewTemplateUtils u000E_u000A = this.\u000E\u000A;
											if (u000E_u000A == null)
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
												View u000A4 = view;
												Action<Exception> u3;
												if ((u3 = u001F_u.\u0019) == null)
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
													u3 = (u001F_u.\u0019 = new Action<Exception>(u001F_u.\u0018));
												}
												\u000D\u0019\u0016.\u0007(u000E_u000A, u000A4, u3);
											}
											View view2 = \u001C\u0019\u0016.\u000A(this.\u0010\u000A, document, view, u001D, 2);
											ViewTemplateUtils u000E_u000A2 = this.\u000E\u000A;
											if (u000E_u000A2 == null)
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
												\u0003\u0019\u0016.\u0007(u000E_u000A2, view, view2);
											}
											elementId = \u0002\u001E\u000A.\u0007(view2);
											Collector.\u0004.\u0019(view2);
										}
										else
										{
											elementId = \u001E\u0001\u000A.\u000A(\u000B\u0019\u0016.\u0007(\u0002\u0019\u0016.\u0007(viewInfo)));
										}
										IL_663:
										if (\u001B\u001B\u001D.\u000A(elementId, \u0012\u0015\u0010.\u001F))
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
											if (\u0007\u0003\u000E.\u001F(element) == null)
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
												if (\u001D\u0003\u000E.\u001F(element) == null)
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
													if (\u0004\u0003\u000E.\u001F(element) == null)
													{
														Viewport viewport2 = this.\u001D\u0005(document, \u0002\u001E\u000A.\u0007(u001F_u.\u000A), view, elementId, \u0012\u001D\u0016.\u000A(\u0003\u001D\u0016.\u000A(viewInfo)));
														if (\u0012\u0019\u0016.\u000A(viewInfo) != -1L)
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
															\u000F\u0019\u0016.\u000A(viewport2, \u001E\u0001\u000A.\u000A(\u0012\u0019\u0016.\u000A(viewInfo)));
														}
														viewport2.\u001F(viewportStoredData3);
														\u0006\u0019\u0016.\u000A(viewport2, \u0001\u0004\u0016.\u000A(viewInfo));
														\u000A\u0008.\u0004\u0005(document, viewInfo, viewport2);
														\u000C\u0004\u0016.\u0007(viewInfo, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(viewport2)));
														\u001A\u0004\u0016.\u000A(viewInfo, \u000B\u001E\u000A.\u000A(elementId));
														continue;
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
											}
											bool flag = false;
											ViewPortType viewPortType = element.\u001F();
											if (viewPortType == ViewPortType.PanelScheduleInstance)
											{
												goto IL_6EE;
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
											if (viewPortType == ViewPortType.ScheduleInstance)
											{
												for (;;)
												{
													switch (1)
													{
													case 0:
														continue;
													}
													goto IL_6EE;
												}
											}
											IL_6F1:
											XYZ xyz = \u0020\u0009\u0010.\u001F;
											if (!flag)
											{
												Viewport u001F7 = \u0007\u0003\u000E.\u001F(element);
												ViewportRotation u000A5 = \u0004\u0019\u0016.\u000A(u001F7);
												\u0006\u0019\u0016.\u000A(u001F7, 0);
												xyz = \u0005\u0019\u0016.\u000A(u001F7);
												\u0019\u0019\u0016.\u0007(viewInfo, \u0018\u0019\u0016.\u000A(xyz));
												Viewport viewport3 = this.\u001D\u0005(document, \u0002\u001E\u000A.\u0007(u001F_u.\u000A), view, elementId, xyz);
												viewport3.\u001F(viewportStoredData3);
												\u0006\u0019\u0016.\u000A(viewport3, u000A5);
												\u000A\u0008.\u0004\u0005(document, viewInfo, viewport3);
												\u0011\u0001\u000A.\u000A(document, \u0002\u001E\u000A.\u0007(u001F7));
												\u000C\u0004\u0016.\u0007(viewInfo, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(viewport3)));
												\u001A\u0004\u0016.\u000A(viewInfo, \u000B\u001E\u000A.\u000A(elementId));
												continue;
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
											bool flag2 = false;
											if (viewPortType == ViewPortType.PanelScheduleInstance)
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
												flag2 = true;
											}
											if (!flag2)
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
												ScheduleSheetInstance u001F8 = \u001D\u0003\u000E.\u001F(element);
												BoundingBoxXYZ u001F9 = \u0002\u0004\u0007.\u000A(u001F8, u001F_u.\u000A);
												xyz = \u0003\u0007\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F9), \u000B\u0004\u0007.\u000A(u001F9)), 0.5);
												ViewportRotation u000A6 = \u0016\u0019\u0016.\u000A(u001F8);
												\u0019\u0019\u0016.\u0007(viewInfo, \u0018\u0019\u0016.\u000A(xyz));
												\u0011\u0001\u000A.\u000A(document, \u0002\u001E\u000A.\u0007(u001F8));
												Viewport u001F10 = this.\u001D\u0005(document, \u0002\u001E\u000A.\u0007(u001F_u.\u000A), view, elementId, xyz);
												u001F10.\u001F(viewportStoredData3);
												\u0006\u0019\u0016.\u000A(u001F10, u000A6);
												\u000C\u0004\u0016.\u0007(viewInfo, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F10)));
												\u001A\u0004\u0016.\u000A(viewInfo, \u000B\u001E\u000A.\u000A(elementId));
												continue;
											}
											PanelScheduleSheetInstance u001F11 = \u0004\u0003\u000E.\u001F(element);
											BoundingBoxXYZ u001F12 = \u0002\u0004\u0007.\u000A(u001F11, u001F_u.\u000A);
											xyz = \u0003\u0007\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F12), \u000B\u0004\u0007.\u000A(u001F12)), 0.5);
											\u0019\u0019\u0016.\u0007(viewInfo, \u0018\u0019\u0016.\u000A(xyz));
											\u0011\u0001\u000A.\u000A(document, \u0002\u001E\u000A.\u0007(u001F11));
											Viewport u001F13 = this.\u001D\u0005(document, \u0002\u001E\u000A.\u0007(u001F_u.\u000A), view, elementId, xyz);
											u001F13.\u001F(viewportStoredData3);
											\u000C\u0004\u0016.\u0007(viewInfo, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F13)));
											\u001A\u0004\u0016.\u000A(viewInfo, \u000B\u001E\u000A.\u000A(elementId));
											continue;
											IL_6EE:
											flag = true;
											goto IL_6F1;
										}
										continue;
										IL_554:
										elementId = \u001E\u0001\u000A.\u000A(\u000B\u0019\u0016.\u0007(\u0002\u0019\u0016.\u0007(viewInfo)));
										goto IL_663;
									}
								}
								ElementId elementId2 = \u001E\u0001\u000A.\u000A(\u000B\u0019\u0016.\u0007(\u0002\u0019\u0016.\u0007(viewInfo)));
								if (\u001B\u001B\u001D.\u000A(elementId2, \u0012\u0015\u0010.\u001F))
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
									Element u001F14 = SheetAndViewCreationHelper.\u0004(document, \u000D\u001D\u0016.\u000A(viewInfo));
									if (\u0007\u0003\u000E.\u001F(u001F14) == null)
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
										if (\u001D\u0003\u000E.\u001F(u001F14) == null)
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
											if (\u0004\u0003\u000E.\u001F(u001F14) != null)
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
											}
											else
											{
												if (\u001D\u0019\u0016.\u0007(viewInfo) == 123)
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
													PanelScheduleSheetInstance u001F15 = \u0007\u0019\u0016.\u000A(document, elementId2, u001F_u.\u000A);
													u001F15.\u001F(viewportStoredData3);
													BoundingBoxXYZ u001F16 = \u0002\u0004\u0007.\u000A(u001F15, u001F_u.\u000A);
													XYZ u001F17 = \u0001\u001D\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F16), \u000B\u0004\u0007.\u000A(u001F16)), 2.0);
													\u000F\u0018\u0007.\u000A(document, \u0002\u001E\u000A.\u0007(u001F15), \u001B\u001F\u0007.\u000A(\u001F\u0019\u0016.\u0007(\u0003\u001D\u0016.\u000A(viewInfo)) - \u000D\u001F\u0007.\u000A(u001F17), \u0009\u0004\u0016.\u0007(\u0003\u001D\u0016.\u000A(viewInfo)) - \u001C\u001F\u0007.\u000A(u001F17), 0.0));
													\u000C\u0004\u0016.\u0007(viewInfo, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F15)));
													\u001A\u0004\u0016.\u000A(viewInfo, \u000B\u001E\u000A.\u000A(elementId2));
													continue;
												}
												ScheduleSheetInstance u001F18 = \u000A\u0019\u0016.\u000A(document, \u0002\u001E\u000A.\u0007(u001F_u.\u000A), elementId2, \u0012\u001D\u0016.\u000A(\u0003\u001D\u0016.\u000A(viewInfo)));
												u001F18.\u001F(viewportStoredData3);
												BoundingBoxXYZ u001F19 = \u0002\u0004\u0007.\u000A(u001F18, u001F_u.\u000A);
												XYZ u001F20 = \u0001\u001D\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F19), \u000B\u0004\u0007.\u000A(u001F19)), 2.0);
												\u000F\u0018\u0007.\u000A(document, \u0002\u001E\u000A.\u0007(u001F18), \u001B\u001F\u0007.\u000A(\u001F\u0019\u0016.\u0007(\u0003\u001D\u0016.\u000A(viewInfo)) - \u000D\u001F\u0007.\u000A(u001F20), \u0009\u0004\u0016.\u0007(\u0003\u001D\u0016.\u000A(viewInfo)) - \u001C\u001F\u0007.\u000A(u001F20), 0.0));
												\u0015\u0004\u0016.\u000A(u001F18, \u0001\u0004\u0016.\u000A(viewInfo));
												\u000C\u0004\u0016.\u0007(viewInfo, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F18)));
												\u001A\u0004\u0016.\u000A(viewInfo, \u000B\u001E\u000A.\u000A(elementId2));
												continue;
											}
										}
									}
									bool flag3 = false;
									ViewPortType viewPortType2 = u001F14.\u001F();
									if (viewPortType2 == ViewPortType.PanelScheduleInstance)
									{
										goto IL_ACF;
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
									if (viewPortType2 == ViewPortType.ScheduleInstance)
									{
										for (;;)
										{
											switch (2)
											{
											case 0:
												continue;
											}
											goto IL_ACF;
										}
									}
									IL_AD2:
									if (flag3)
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
										bool flag4 = false;
										if (viewPortType2 == ViewPortType.PanelScheduleInstance)
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
											flag4 = true;
										}
										if (!flag4)
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
											if (\u001D\u0019\u0016.\u0007(viewInfo) == 123)
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
												ScheduleSheetInstance u001F21 = \u001D\u0003\u000E.\u001F(u001F14);
												BoundingBoxXYZ u001F22 = \u0002\u0004\u0007.\u000A(u001F21, u001F_u.\u000A);
												XYZ u001F23 = \u0003\u0007\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F22), \u000B\u0004\u0007.\u000A(u001F22)), 0.5);
												\u0019\u0019\u0016.\u0007(viewInfo, \u0018\u0019\u0016.\u000A(u001F23));
												\u0011\u0001\u000A.\u000A(document, \u0002\u001E\u000A.\u0007(u001F21));
												PanelScheduleSheetInstance u001F24 = \u0007\u0019\u0016.\u000A(document, elementId2, u001F_u.\u000A);
												u001F24.\u001F(viewportStoredData3);
												BoundingBoxXYZ u001F25 = \u0002\u0004\u0007.\u000A(u001F24, u001F_u.\u000A);
												XYZ u001F26 = \u0001\u001D\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F25), \u000B\u0004\u0007.\u000A(u001F25)), 2.0);
												\u000F\u0018\u0007.\u000A(document, \u0002\u001E\u000A.\u0007(u001F24), \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F23) - \u000D\u001F\u0007.\u000A(u001F26), \u001C\u001F\u0007.\u000A(u001F23) - \u001C\u001F\u0007.\u000A(u001F26), 0.0));
												\u000C\u0004\u0016.\u0007(viewInfo, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F24)));
												\u001A\u0004\u0016.\u000A(viewInfo, \u000B\u001E\u000A.\u000A(elementId2));
												continue;
											}
											ScheduleSheetInstance u001F27 = \u001D\u0003\u000E.\u001F(u001F14);
											BoundingBoxXYZ u001F28 = \u0002\u0004\u0007.\u000A(u001F27, u001F_u.\u000A);
											XYZ xyz2 = \u0003\u0007\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F28), \u000B\u0004\u0007.\u000A(u001F28)), 0.5);
											\u0019\u0019\u0016.\u0007(viewInfo, \u0018\u0019\u0016.\u000A(xyz2));
											ViewportRotation u000A7 = \u0016\u0019\u0016.\u000A(u001F27);
											\u0011\u0001\u000A.\u000A(document, \u0002\u001E\u000A.\u0007(u001F27));
											ScheduleSheetInstance u001F29 = \u000A\u0019\u0016.\u000A(document, \u0002\u001E\u000A.\u0007(u001F_u.\u000A), elementId2, xyz2);
											u001F29.\u001F(viewportStoredData3);
											BoundingBoxXYZ u001F30 = \u0002\u0004\u0007.\u000A(u001F29, u001F_u.\u000A);
											XYZ u001F31 = \u0001\u001D\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F30), \u000B\u0004\u0007.\u000A(u001F30)), 2.0);
											\u000F\u0018\u0007.\u000A(document, \u0002\u001E\u000A.\u0007(u001F29), \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(xyz2) - \u000D\u001F\u0007.\u000A(u001F31), \u001C\u001F\u0007.\u000A(xyz2) - \u001C\u001F\u0007.\u000A(u001F31), 0.0));
											\u0015\u0004\u0016.\u000A(u001F29, u000A7);
											\u000C\u0004\u0016.\u0007(viewInfo, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F29)));
											\u001A\u0004\u0016.\u000A(viewInfo, \u000B\u001E\u000A.\u000A(elementId2));
											continue;
										}
										else
										{
											if (\u001D\u0019\u0016.\u0007(viewInfo) == 123)
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
												PanelScheduleSheetInstance u001F32 = \u0004\u0003\u000E.\u001F(u001F14);
												BoundingBoxXYZ u001F33 = \u0002\u0004\u0007.\u000A(u001F32, u001F_u.\u000A);
												XYZ u001F34 = \u0003\u0007\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F33), \u000B\u0004\u0007.\u000A(u001F33)), 0.5);
												\u0019\u0019\u0016.\u0007(viewInfo, \u0018\u0019\u0016.\u000A(u001F34));
												\u0011\u0001\u000A.\u000A(document, \u0002\u001E\u000A.\u0007(u001F32));
												PanelScheduleSheetInstance u001F35 = \u0007\u0019\u0016.\u000A(document, elementId2, u001F_u.\u000A);
												u001F35.\u001F(viewportStoredData3);
												BoundingBoxXYZ u001F36 = \u0002\u0004\u0007.\u000A(u001F35, u001F_u.\u000A);
												XYZ u001F37 = \u0001\u001D\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F36), \u000B\u0004\u0007.\u000A(u001F36)), 2.0);
												\u000F\u0018\u0007.\u000A(document, \u0002\u001E\u000A.\u0007(u001F35), \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F34) - \u000D\u001F\u0007.\u000A(u001F37), \u001C\u001F\u0007.\u000A(u001F34) - \u001C\u001F\u0007.\u000A(u001F37), 0.0));
												\u000C\u0004\u0016.\u0007(viewInfo, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F35)));
												\u001A\u0004\u0016.\u000A(viewInfo, \u000B\u001E\u000A.\u000A(elementId2));
												continue;
											}
											PanelScheduleSheetInstance u001F38 = \u0004\u0003\u000E.\u001F(u001F14);
											BoundingBoxXYZ u001F39 = \u0002\u0004\u0007.\u000A(u001F38, u001F_u.\u000A);
											XYZ xyz3 = \u0003\u0007\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F39), \u000B\u0004\u0007.\u000A(u001F39)), 0.5);
											\u0019\u0019\u0016.\u0007(viewInfo, \u0018\u0019\u0016.\u000A(xyz3));
											\u0011\u0001\u000A.\u000A(document, \u0002\u001E\u000A.\u0007(u001F38));
											ScheduleSheetInstance u001F40 = \u000A\u0019\u0016.\u000A(document, \u0002\u001E\u000A.\u0007(u001F_u.\u000A), elementId2, xyz3);
											u001F40.\u001F(viewportStoredData3);
											BoundingBoxXYZ u001F41 = \u0002\u0004\u0007.\u000A(u001F40, u001F_u.\u000A);
											XYZ u001F42 = \u0001\u001D\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F41), \u000B\u0004\u0007.\u000A(u001F41)), 2.0);
											\u000F\u0018\u0007.\u000A(document, \u0002\u001E\u000A.\u0007(u001F40), \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(xyz3) - \u000D\u001F\u0007.\u000A(u001F42), \u001C\u001F\u0007.\u000A(xyz3) - \u001C\u001F\u0007.\u000A(u001F42), 0.0));
											\u000C\u0004\u0016.\u0007(viewInfo, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F40)));
											\u001A\u0004\u0016.\u000A(viewInfo, \u000B\u001E\u000A.\u000A(elementId2));
											continue;
										}
									}
									else
									{
										Viewport u001F43 = \u0007\u0003\u000E.\u001F(u001F14);
										XYZ xyz4 = \u0005\u0019\u0016.\u000A(u001F43);
										\u0019\u0019\u0016.\u0007(viewInfo, \u0018\u0019\u0016.\u000A(xyz4));
										ViewportRotation u000A8 = \u0004\u0019\u0016.\u000A(u001F43);
										\u0011\u0001\u000A.\u000A(document, \u0002\u001E\u000A.\u0007(u001F43));
										if (\u001D\u0019\u0016.\u0007(viewInfo) == 123)
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
											PanelScheduleSheetInstance u001F44 = \u0007\u0019\u0016.\u000A(document, elementId2, u001F_u.\u000A);
											u001F44.\u001F(viewportStoredData3);
											BoundingBoxXYZ u001F45 = \u0002\u0004\u0007.\u000A(u001F44, u001F_u.\u000A);
											XYZ u001F46 = \u0001\u001D\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F45), \u000B\u0004\u0007.\u000A(u001F45)), 2.0);
											\u000F\u0018\u0007.\u000A(document, \u0002\u001E\u000A.\u0007(u001F44), \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(xyz4) - \u000D\u001F\u0007.\u000A(u001F46), \u001C\u001F\u0007.\u000A(xyz4) - \u001C\u001F\u0007.\u000A(u001F46), 0.0));
											\u000C\u0004\u0016.\u0007(viewInfo, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F44)));
											\u001A\u0004\u0016.\u000A(viewInfo, \u000B\u001E\u000A.\u000A(elementId2));
											continue;
										}
										ScheduleSheetInstance u001F47 = \u000A\u0019\u0016.\u000A(document, \u0002\u001E\u000A.\u0007(u001F_u.\u000A), elementId2, xyz4);
										u001F47.\u001F(viewportStoredData3);
										BoundingBoxXYZ u001F48 = \u0002\u0004\u0007.\u000A(u001F47, u001F_u.\u000A);
										XYZ u001F49 = \u0001\u001D\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F48), \u000B\u0004\u0007.\u000A(u001F48)), 2.0);
										\u000F\u0018\u0007.\u000A(document, \u0002\u001E\u000A.\u0007(u001F47), \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(xyz4) - \u000D\u001F\u0007.\u000A(u001F49), \u001C\u001F\u0007.\u000A(xyz4) - \u001C\u001F\u0007.\u000A(u001F49), 0.0));
										\u0015\u0004\u0016.\u000A(u001F47, u000A8);
										\u000C\u0004\u0016.\u0007(viewInfo, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F47)));
										\u001A\u0004\u0016.\u000A(viewInfo, \u000B\u001E\u000A.\u000A(elementId2));
										continue;
									}
									IL_ACF:
									flag3 = true;
									goto IL_AD2;
								}
							}
						}
						else
						{
							element.\u001F(viewportStoredData3);
						}
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
				((IDisposable)enumerator2).Dispose();
			}
			List<ElementId> list = \u001C\u0013\u000A.\u000A();
			List<RevisionData>.Enumerator enumerator3 = \u0014\u0004\u0016.\u000A(\u0013\u0004\u0016.\u0007(\u0008\u0004\u0016.\u0007(u001F_u.\u0007)));
			try
			{
				while (\u001B\u0004\u0016.\u000A(ref enumerator3))
				{
					RevisionData u001F50 = \u0017\u0004\u0016.\u000A(ref enumerator3);
					if (!\u0020\u0004\u0016.\u000A(u001F50))
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
						if (\u001E\u0004\u0016.\u000A(u001F50))
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
							Revision u001F51 = \u0011\u0004\u0016.\u0007(u001F50).\u001F();
							\u0003\u0010\u0007.\u000A(list, \u0002\u001E\u000A.\u0007(u001F51));
						}
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
				((IDisposable)enumerator3).Dispose();
			}
			if (\u000E\u0004\u0016.\u0007(\u0008\u0004\u0016.\u0007(u001F_u.\u0007)) != null)
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
				List<RevisionCloudInfo> list2 = Enumerable.ToList<RevisionCloudInfo>(Enumerable.Where<RevisionCloudInfo>(RevisionCloudInfo.\u001D(document), new Func<RevisionCloudInfo, bool>(u001F_u.\u0005)));
				if (\u0010\u0004\u0016.\u000A(list2) > 0)
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
					object u001F52 = document;
					IEnumerable<RevisionCloudInfo> enumerable2 = list2;
					Func<RevisionCloudInfo, ElementId> func2;
					if ((func2 = \u000A\u0008.<>c.\u0006) == null)
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
						func2 = (\u000A\u0008.<>c.\u0006 = new Func<RevisionCloudInfo, ElementId>(\u000A\u0008.<>c.\u001F.\u001E));
					}
					\u0003\u0009\u001D.\u000A(u001F52, Enumerable.ToList<ElementId>(Enumerable.Select<RevisionCloudInfo, ElementId>(enumerable2, func2)));
				}
			}
			u001F_u.\u0004 = Enumerable.ToList<ElementId>(\u000D\u0004\u0016.\u000A(u001F_u.\u000A));
			u001F_u.\u001D = Enumerable.ToList<ElementId>(\u001C\u0004\u0016.\u000A(u001F_u.\u000A));
			u001F_u.\u0004 = Enumerable.ToList<ElementId>(Enumerable.Where<ElementId>(u001F_u.\u0004, new Func<ElementId, bool>(u001F_u.\u0016)));
			list = Enumerable.ToList<ElementId>(Enumerable.Where<ElementId>(list, new Func<ElementId, bool>(u001F_u.\u000B)));
			\u0003\u0004\u0016.\u000A(u001F_u.\u000A, list);
			\u0012\u0004\u0016.\u000A(u001F_u.\u0007, true);
			u001F_u.\u0007.\u001F(UpdateStates.Updated);
			u001F_u.\u000A.\u001F(sheetStoredData);
			\u0005\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\CreateSheetsEvent.cs", "ModifyExistingSheet");
		}

		// Token: 0x06001A34 RID: 6708 RVA: 0x000AA6CC File Offset: 0x000A88CC
		private Viewport \u001D\u0005(Document \u001F, ElementId \u000A, View \u0007, ElementId \u001D, XYZ \u0004)
		{
			View u = \u0004\u0019\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u001F, \u001D));
			Viewport viewport = \u001D\u0018\u0016.\u000A(\u001F, \u000A, \u001D, \u0004);
			if (viewport == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0008.\u001D\u0005(Document, ElementId, View, ElementId, XYZ)).MethodHandle;
				}
				ViewTemplateUtils u000E_u000A = this.\u000E\u000A;
				if (u000E_u000A == null)
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
					\u0004\u0018\u0016.\u0007(u000E_u000A, \u0007, u);
				}
				viewport = \u001D\u0018\u0016.\u000A(\u001F, \u000A, \u001D, \u0004);
			}
			return viewport;
		}

		// Token: 0x06001A35 RID: 6709 RVA: 0x000AA73C File Offset: 0x000A893C
		private static void \u0004\u0005(Document \u001F, ViewInfo \u000A, Viewport \u0007)
		{
			Viewport viewport = \u0007\u0003\u000E.\u001F(\u0007\u0018\u0016.\u000A(\u001F, \u0019\u0018\u0016.\u000A(\u000A)));
			if (viewport == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0008.\u0004\u0005(Document, ViewInfo, Viewport)).MethodHandle;
				}
				return;
			}
			\u0007\u000C.\u001E(viewport, \u0007, \u000A);
		}

		// Token: 0x06001A36 RID: 6710 RVA: 0x000AA780 File Offset: 0x000A8980
		private unsafe void \u0019\u0005(\u0011\u000C<SheetInfo> \u001F, int \u000A, ref int \u0007)
		{
			SheetInfo u001F;
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0008.\u0019\u0005(\u0011\u000C<SheetInfo>, int, int*)).MethodHandle;
				}
				u001F = null;
			}
			else
			{
				u001F = \u0018\u0018\u0016.\u0007(\u001F);
			}
			base.\u0003\u0016(u001F, \u000A, ref \u0007);
		}

		// Token: 0x06001A37 RID: 6711 RVA: 0x000AA7B8 File Offset: 0x000A89B8
		private void \u0018\u0005(\u0011\u000C<SheetInfo> \u001F, int \u000A, ref int \u0007)
		{
			this.\u0003\u000A.\u0016(\u001F);
			base.\u0003\u0016(\u0018\u0018\u0016.\u001D(\u001F), \u000A, ref \u0007);
		}

		// Token: 0x06001A38 RID: 6712 RVA: 0x000AA7E4 File Offset: 0x000A89E4
		[CompilerGenerated]
		private void \u0005\u0005()
		{
			ViewTemplateUtils u000E_u000A = this.\u000E\u000A;
			if (u000E_u000A == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0008.\u0005\u0005()).MethodHandle;
				}
				return;
			}
			\u0005\u0018\u0016.\u000A(u000E_u000A);
		}

		// Token: 0x06001A39 RID: 6713 RVA: 0x000AA814 File Offset: 0x000A8A14
		[CompilerGenerated]
		private void \u0016\u0005(Exception \u001F)
		{
			\u000F\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), \u001F, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\CreateSheetsEvent.cs", "Execute");
		}

		// Token: 0x04000A6C RID: 2668
		private \u001E\u001A \u0003\u000A;

		// Token: 0x04000A6D RID: 2669
		private readonly \u000B\u000C \u001C\u000A;

		// Token: 0x04000A6E RID: 2670
		private static string \u000D\u000A;

		// Token: 0x04000A6F RID: 2671
		private readonly SheetAndViewCreationHelper \u0010\u000A;

		// Token: 0x04000A70 RID: 2672
		private ViewTemplateUtils \u000E\u000A;

		// Token: 0x04000A71 RID: 2673
		private readonly bool \u0008\u000A;

		// Token: 0x04000A72 RID: 2674
		private ViewLocationService \u001B\u000A;

		// Token: 0x04000A73 RID: 2675
		[CompilerGenerated]
		private IEnumerable<ProjectInformationParameterModel> \u0011\u000A;

		// Token: 0x04000A74 RID: 2676
		[CompilerGenerated]
		private bool \u001E\u000A;

		// Token: 0x04000A75 RID: 2677
		[CompilerGenerated]
		private bool \u0020\u000A;

		// Token: 0x04000A76 RID: 2678
		[CompilerGenerated]
		private bool \u0017\u000A;

		// Token: 0x04000A77 RID: 2679
		[CompilerGenerated]
		private bool \u0014\u000A;

		// Token: 0x0200095E RID: 2398
		[CompilerGenerated]
		private sealed class \u001A\u000E
		{
			// Token: 0x0600529F RID: 21151 RVA: 0x001EACA8 File Offset: 0x001E8EA8
			internal void \u0004()
			{
				ViewTemplateUtils u000E_u000A = this.\u001F.\u000E\u000A;
				if (u000E_u000A == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0008.\u001A\u000E.\u0004()).MethodHandle;
					}
					return;
				}
				\u0012\u0002\u0010.\u000A(u000E_u000A);
			}

			// Token: 0x060052A0 RID: 21152 RVA: 0x001EACE0 File Offset: 0x001E8EE0
			internal void \u0019(SheetInfo \u001F)
			{
				this.\u001F.\u0003\u0016(\u001F, this.\u000A, ref this.\u0007);
			}

			// Token: 0x060052A1 RID: 21153 RVA: 0x001EAD08 File Offset: 0x001E8F08
			internal void \u0018(\u0011\u000C<SheetInfo> \u001F)
			{
				this.\u001F.\u0018\u0005(\u001F, this.\u000A, ref this.\u0007);
			}

			// Token: 0x060052A2 RID: 21154 RVA: 0x001EAD30 File Offset: 0x001E8F30
			internal void \u0005(\u0011\u000C<SheetInfo> \u001F)
			{
				this.\u001F.\u0019\u0005(\u001F, this.\u000A, ref this.\u0007);
			}

			// Token: 0x060052A3 RID: 21155 RVA: 0x001EAD58 File Offset: 0x001E8F58
			internal void \u0016(SheetInfo \u001F)
			{
				this.\u001F.\u0003\u0016(\u001F, this.\u000A, ref this.\u0007);
			}

			// Token: 0x060052A4 RID: 21156 RVA: 0x001EAD80 File Offset: 0x001E8F80
			internal void \u000B(Exception \u001F)
			{
				\u000F\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this.\u001F), \u001F, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\CreateSheetsEvent.cs", "ExecuteInternal");
			}

			// Token: 0x060052A5 RID: 21157 RVA: 0x001EADAC File Offset: 0x001E8FAC
			internal void \u0002(Exception \u001F)
			{
				\u000F\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this.\u001F), \u001F, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\CreateSheetsEvent.cs", "ExecuteInternal");
			}

			// Token: 0x060052A6 RID: 21158 RVA: 0x001EADD8 File Offset: 0x001E8FD8
			internal void \u0006(SheetInfo \u001F)
			{
				this.\u001F.\u0003\u0016(\u001F, this.\u000A, ref this.\u0007);
			}

			// Token: 0x0400247F RID: 9343
			public \u000A\u0008 \u001F;

			// Token: 0x04002480 RID: 9344
			public int \u000A;

			// Token: 0x04002481 RID: 9345
			public int \u0007;

			// Token: 0x04002482 RID: 9346
			public Document \u001D;
		}

		// Token: 0x0200095F RID: 2399
		[CompilerGenerated]
		private sealed class \u000C\u000E
		{
			// Token: 0x060052A8 RID: 21160 RVA: 0x001EAE14 File Offset: 0x001E9014
			internal void \u0004(\u0011\u000C<SheetInfo> \u001F)
			{
				\u0003\u0002\u0010.\u000A(this.\u001F, \u001F);
			}

			// Token: 0x060052A9 RID: 21161 RVA: 0x001EAE30 File Offset: 0x001E9030
			internal void \u0019()
			{
				this.\u001D.\u001F.\u0001\u0018(this.\u001D.\u001D, Enumerable.ToList<SheetInfo>(Enumerable.Concat<SheetInfo>(this.\u000A, this.\u0007)));
			}

			// Token: 0x04002483 RID: 9347
			public Action<\u0011\u000C<SheetInfo>> \u001F;

			// Token: 0x04002484 RID: 9348
			public List<SheetInfo> \u000A;

			// Token: 0x04002485 RID: 9349
			public List<SheetInfo> \u0007;

			// Token: 0x04002486 RID: 9350
			public \u000A\u0008.\u001A\u000E \u001D;
		}

		// Token: 0x02000960 RID: 2400
		[CompilerGenerated]
		private sealed class \u0015\u000E
		{
			// Token: 0x04002487 RID: 9351
			public \u000A\u0008 \u001F;

			// Token: 0x04002488 RID: 9352
			public Document \u000A;
		}

		// Token: 0x02000961 RID: 2401
		[CompilerGenerated]
		private sealed class \u0001\u000E
		{
			// Token: 0x060052AC RID: 21164 RVA: 0x001EAE9C File Offset: 0x001E909C
			internal void \u0004()
			{
				this.\u001D.\u001F.\u0007\u0005(this.\u001F, out this.\u000A);
			}

			// Token: 0x060052AD RID: 21165 RVA: 0x001EAEC8 File Offset: 0x001E90C8
			internal void \u0019(Exception \u001F)
			{
				this.\u0007 = true;
				this.\u001D.\u001F.\u0006\u0019(this.\u001D.\u000A, this.\u001F, \u001F);
			}

			// Token: 0x04002489 RID: 9353
			public SheetInfo \u001F;

			// Token: 0x0400248A RID: 9354
			public bool \u000A;

			// Token: 0x0400248B RID: 9355
			public bool \u0007;

			// Token: 0x0400248C RID: 9356
			public \u000A\u0008.\u0015\u000E \u001D;
		}

		// Token: 0x02000962 RID: 2402
		[CompilerGenerated]
		private sealed class \u0009\u000E
		{
			// Token: 0x060052AF RID: 21167 RVA: 0x001EAF14 File Offset: 0x001E9114
			internal void \u001D()
			{
				List<ProjectInformationParameterModel>.Enumerator enumerator = \u0010\u0002\u0010.\u000A(this.\u001F);
				try
				{
					while (\u001C\u0002\u0010.\u000A(ref enumerator))
					{
						ProjectInformationParameterModel projectInformationParameterModel = \u000D\u0002\u0010.\u000A(ref enumerator);
						Parameter parameter = projectInformationParameterModel.\u000A(\u001C\u0007\u001D.\u000A());
						if (parameter != null)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0008.\u0009\u000E.\u001D()).MethodHandle;
							}
							parameter.\u0019(projectInformationParameterModel);
							\u001C\u000B\u0016.\u000A(projectInformationParameterModel, UpdateStates.Updated);
						}
					}
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
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}

			// Token: 0x060052B0 RID: 21168 RVA: 0x001EAFA4 File Offset: 0x001E91A4
			internal void \u0004(Exception \u001F)
			{
				object u001F = this.\u001F;
				Action<ProjectInformationParameterModel> u000A;
				if ((u000A = \u000A\u0008.<>c.\u0005) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0008.\u0009\u000E.\u0004(Exception)).MethodHandle;
					}
					u000A = (\u000A\u0008.<>c.\u0005 = new Action<ProjectInformationParameterModel>(\u000A\u0008.<>c.\u001F.\u000E));
				}
				\u000B\u0004\u0016.\u000A(u001F, u000A);
				\u0011\u001D\u0016.\u000A(this.\u000A.\u0011\u0007, \u001F\u001B<SheetInfo>.\u000D\u0016(\u0009\u001D\u0016.\u000A(this.\u0007)));
			}

			// Token: 0x0400248D RID: 9357
			public List<ProjectInformationParameterModel> \u001F;

			// Token: 0x0400248E RID: 9358
			public \u000A\u0008 \u000A;

			// Token: 0x0400248F RID: 9359
			public \u0008\u0008\u000A \u0007;
		}

		// Token: 0x02000963 RID: 2403
		[CompilerGenerated]
		private sealed class \u001F\u0008
		{
			// Token: 0x060052B2 RID: 21170 RVA: 0x001EB028 File Offset: 0x001E9228
			internal void \u0018(Exception \u001F)
			{
				\u000F\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this.\u001F), \u001F, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\CreateSheetsEvent.cs", "ModifyExistingSheet");
			}

			// Token: 0x060052B3 RID: 21171 RVA: 0x001EB054 File Offset: 0x001E9254
			internal bool \u0005(RevisionCloudInfo \u001F)
			{
				if (\u001A\u0008\u0019.\u000A(\u0002\u000F\u0002.\u000A(\u001F), \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(this.\u000A))))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0008.\u001F\u0008.\u0005(RevisionCloudInfo)).MethodHandle;
					}
					return \u0014\u000E\u0007.\u000A(\u000E\u0004\u0016.\u0007(\u0008\u0004\u0016.\u0007(this.\u0007)), \u0016\u000F\u0002.\u000A(\u001F));
				}
				return false;
			}

			// Token: 0x060052B4 RID: 21172 RVA: 0x001EB0C0 File Offset: 0x001E92C0
			internal bool \u0016(ElementId \u001F)
			{
				return !\u0014\u000E\u0007.\u000A(this.\u001D, \u001F);
			}

			// Token: 0x060052B5 RID: 21173 RVA: 0x001EB0E0 File Offset: 0x001E92E0
			internal bool \u000B(ElementId \u001F)
			{
				return !\u0014\u000E\u0007.\u000A(this.\u0004, \u001F);
			}

			// Token: 0x04002490 RID: 9360
			public \u000A\u0008 \u001F;

			// Token: 0x04002491 RID: 9361
			public ViewSheet \u000A;

			// Token: 0x04002492 RID: 9362
			public SheetInfo \u0007;

			// Token: 0x04002493 RID: 9363
			public List<ElementId> \u001D;

			// Token: 0x04002494 RID: 9364
			public List<ElementId> \u0004;

			// Token: 0x04002495 RID: 9365
			public Action<Exception> \u0019;
		}
	}
}
