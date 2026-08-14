using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.SheetGen;
using DiRoots.One.SheetGen.Core.Services;
using DiRoots.One.SheetGen.Data;
using DiRoots.One.SheetGen.Delegates;
using DiRoots.Revit.DataCollectors;

namespace A
{
	// Token: 0x020002A0 RID: 672
	internal class \u0018\u0008 : ExternalEventInfo
	{
		// Token: 0x14000029 RID: 41
		// (add) Token: 0x06001A44 RID: 6724 RVA: 0x000AAB48 File Offset: 0x000A8D48
		// (remove) Token: 0x06001A45 RID: 6725 RVA: 0x000AAB98 File Offset: 0x000A8D98
		public event TaskFinishedHandler \u001F
		{
			[CompilerGenerated]
			add
			{
				TaskFinishedHandler taskFinishedHandler = this.\u001F;
				TaskFinishedHandler taskFinishedHandler2;
				do
				{
					taskFinishedHandler2 = taskFinishedHandler;
					TaskFinishedHandler value2 = \u000A\u0003\u000E.\u001F(\u000F\u001E\u000A.\u000A(taskFinishedHandler2, value));
					taskFinishedHandler = Interlocked.CompareExchange<TaskFinishedHandler>(ref this.\u001F, value2, taskFinishedHandler2);
				}
				while (taskFinishedHandler != taskFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0008.add_\u001F(TaskFinishedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				TaskFinishedHandler taskFinishedHandler = this.\u001F;
				TaskFinishedHandler taskFinishedHandler2;
				do
				{
					taskFinishedHandler2 = taskFinishedHandler;
					TaskFinishedHandler value2 = \u000A\u0003\u000E.\u001F(\u0012\u001E\u000A.\u000A(taskFinishedHandler2, value));
					taskFinishedHandler = Interlocked.CompareExchange<TaskFinishedHandler>(ref this.\u001F, value2, taskFinishedHandler2);
				}
				while (taskFinishedHandler != taskFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0008.remove_\u001F(TaskFinishedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x17000736 RID: 1846
		// (get) Token: 0x06001A46 RID: 6726 RVA: 0x000AABE8 File Offset: 0x000A8DE8
		// (set) Token: 0x06001A47 RID: 6727 RVA: 0x000AABFC File Offset: 0x000A8DFC
		public List<SheetInfo> TargetSheets { get; set; }

		// Token: 0x17000737 RID: 1847
		// (get) Token: 0x06001A48 RID: 6728 RVA: 0x000AAC10 File Offset: 0x000A8E10
		// (set) Token: 0x06001A49 RID: 6729 RVA: 0x000AAC24 File Offset: 0x000A8E24
		public int NumberOfSheets { get; set; }

		// Token: 0x17000738 RID: 1848
		// (get) Token: 0x06001A4A RID: 6730 RVA: 0x000AAC38 File Offset: 0x000A8E38
		// (set) Token: 0x06001A4B RID: 6731 RVA: 0x000AAC4C File Offset: 0x000A8E4C
		public bool DuplicateViews { get; set; }

		// Token: 0x17000739 RID: 1849
		// (get) Token: 0x06001A4C RID: 6732 RVA: 0x000AAC60 File Offset: 0x000A8E60
		// (set) Token: 0x06001A4D RID: 6733 RVA: 0x000AAC74 File Offset: 0x000A8E74
		public int ViewDuplicateOption { get; set; }

		// Token: 0x1700073A RID: 1850
		// (get) Token: 0x06001A4E RID: 6734 RVA: 0x000AAC88 File Offset: 0x000A8E88
		// (set) Token: 0x06001A4F RID: 6735 RVA: 0x000AAC9C File Offset: 0x000A8E9C
		public bool CopyRevisions { get; set; }

		// Token: 0x1700073B RID: 1851
		// (get) Token: 0x06001A50 RID: 6736 RVA: 0x000AACB0 File Offset: 0x000A8EB0
		// (set) Token: 0x06001A51 RID: 6737 RVA: 0x000AACC4 File Offset: 0x000A8EC4
		public bool KeepLegends { get; set; }

		// Token: 0x1700073C RID: 1852
		// (get) Token: 0x06001A52 RID: 6738 RVA: 0x000AACD8 File Offset: 0x000A8ED8
		// (set) Token: 0x06001A53 RID: 6739 RVA: 0x000AACEC File Offset: 0x000A8EEC
		public bool KeepSchedules { get; set; }

		// Token: 0x1700073D RID: 1853
		// (get) Token: 0x06001A54 RID: 6740 RVA: 0x000AAD00 File Offset: 0x000A8F00
		// (set) Token: 0x06001A55 RID: 6741 RVA: 0x000AAD14 File Offset: 0x000A8F14
		public bool CopyTitleBlockParameters { get; set; }

		// Token: 0x06001A56 RID: 6742 RVA: 0x000AAD28 File Offset: 0x000A8F28
		public override void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\DuplicateSheetBulkEvent.cs", "Execute");
			Document document = \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app));
			try
			{
				List<ViewSheet> list = Enumerable.ToList<ViewSheet>(document.CollectElements(null));
				ViewInfoCollector viewInfoCollector = \u000E\u0005\u0016.\u000A(document);
				IEnumerable<ViewSheet> enumerable = list;
				Func<ViewSheet, bool> func;
				if ((func = \u0018\u0008.<>c.\u000A) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0008.Execute(UIApplication)).MethodHandle;
					}
					func = (\u0018\u0008.<>c.\u000A = new Func<ViewSheet, bool>(\u0018\u0008.<>c.\u001F.\u0004));
				}
				List<ViewSheet> u000A = Enumerable.ToList<ViewSheet>(Enumerable.Where<ViewSheet>(enumerable, func));
				List<SheetInfo>.Enumerator enumerator = \u0017\u0007\u0016.\u000A(\u0010\u0005\u0016.\u000A(this));
				try
				{
					while (\u000D\u0007\u0016.\u000A(ref enumerator))
					{
						SheetInfo u001F = \u0020\u0007\u0016.\u000A(ref enumerator);
						try
						{
							if (\u0007\u0018\u0016.\u000A(document, \u001B\u0007\u0016.\u0007(\u0008\u0007\u0016.\u0007(u001F))) != null)
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
								\u000D\u0005\u0016.\u000A(SheetTemplate.\u0006(\u001B\u0007\u0016.\u0007(\u0008\u0007\u0016.\u0007(u001F)), \u000E\u0007\u0016.\u0007(\u0008\u0007\u0016.\u0007(u001F)), viewInfoCollector));
							}
							else
							{
								\u000D\u0005\u0016.\u000A(SheetTemplate.\u0006(\u001D\u0004\u0016.\u0007(u001F), \u001B\u001D\u0016.\u0007(u001F), viewInfoCollector, false));
							}
							for (int i = 1; i <= \u000E\u0018\u0016.\u000A(this); i++)
							{
								int num = 1;
								string u000A2 = this.\u000F\u0005(\u0011\u0007\u0016.\u0007(u001F), num);
								while (this.\u0006\u0005(this.\u000F\u0005(\u0011\u0007\u0016.\u0007(u001F), num), u000A))
								{
									num++;
									u000A2 = this.\u000F\u0005(\u0011\u0007\u0016.\u0007(u001F), num);
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
								SheetInfo sheetInfo = \u001C\u0005\u0016.\u000A(\u000C\u0018\u0016.\u000A(), \u0015\u0018\u0016.\u000A(viewInfoCollector));
								\u0003\u0005\u0016.\u000A(sheetInfo, u000A2);
								\u001F\u0018\u0016.\u000A(sheetInfo, u000A2);
								\u0012\u0005\u0016.\u0007(sheetInfo, UpdateStates.ToDuplicate);
								\u0001\u0019\u0016.\u000A(sheetInfo, \u0019\u0004\u0016.\u0007(u001F));
								\u0009\u0019\u0016.\u000A(sheetInfo, \u0019\u0004\u0016.\u0007(u001F));
								\u000F\u0005\u0016.\u000A(sheetInfo, \u001A\u0018\u0016.\u000A(this));
								\u0002\u0005\u0016.\u000A(sheetInfo, \u0006\u0005\u0016.\u000A(this));
								SheetInfo sheetInfo2 = sheetInfo;
								if (\u000B\u0005\u0016.\u000A(this))
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
									ViewSheet viewSheet = document.AsElement(\u001D\u0004\u0016.\u0007(u001F));
									FamilyInstance familyInstance;
									if (viewSheet == null)
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
										familyInstance = \u0002\u0003\u000E.\u001F;
									}
									else
									{
										familyInstance = Enumerable.LastOrDefault<FamilyInstance>(viewSheet.\u0006());
									}
									FamilyInstance familyInstance2 = familyInstance;
									if (familyInstance2 != null)
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
										IEnumerable<SelectionParameter> enumerable2 = \u000B\u0008.\u0003\u0005(familyInstance2);
										Func<SelectionParameter, ParameterModel> func2;
										if ((func2 = \u0018\u0008.<>c.\u0007) == null)
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
											func2 = (\u0018\u0008.<>c.\u0007 = new Func<SelectionParameter, ParameterModel>(\u0018\u0008.<>c.\u001F.\u0019));
										}
										List<ParameterModel> u000A3 = Enumerable.ToList<ParameterModel>(Enumerable.Select<SelectionParameter, ParameterModel>(enumerable2, func2));
										\u000B\u0008.\u0012\u0005(familyInstance2, u000A3, viewSheet, \u0015\u0018\u0016.\u000A(viewInfoCollector));
										\u0016\u0005\u0016.\u000A(sheetInfo2, u000A3);
									}
								}
								IEnumerator<ParameterModel> enumerator2 = \u0018\u0005\u0016.\u000A(\u0005\u0005\u0016.\u0007(sheetInfo2));
								try
								{
									while (\u000A\u0017\u000A.\u000A(enumerator2))
									{
										ParameterModel parameterModel = \u0019\u0005\u0016.\u000A(enumerator2);
										ParameterModel parameterModel2 = u001F.\u001D(parameterModel, true);
										if (parameterModel2 != null)
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
											if (\u001D\u0005\u0016.\u0007(\u0004\u0005\u0016.\u0007(parameterModel)))
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
												\u001F\u0005\u0016.\u0007(parameterModel, \u000A\u0005\u0016.\u0007(\u0007\u0005\u0016.\u000A()).\u001F(\u0009\u0018\u0016.\u0007(parameterModel2)));
											}
											else
											{
												\u0001\u0018\u0016.\u0007(parameterModel, \u0009\u0018\u0016.\u0007(parameterModel2));
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
									if (enumerator2 != null)
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
										\u001F\u0017\u000A.\u000A(enumerator2);
									}
								}
								sheetInfo2.TO(\u0015\u0018\u0016.\u000A(viewInfoCollector));
								\u0017\u0018\u0016.\u000A(sheetInfo2, \u000C\u0018\u0016.\u000A(), \u001A\u0018\u0016.\u000A(this), \u0013\u0018\u0016.\u000A(this), \u0014\u0018\u0016.\u000A(this));
								if (\u0020\u0018\u0016.\u000A(this))
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
									\u001E\u0018\u0016.\u0007(\u0008\u0004\u0016.\u0007(sheetInfo2), Enumerable.ToList<RevisionData>(\u0013\u0004\u0016.\u0007(\u0008\u0004\u0016.\u0007(u001F))));
									\u0011\u0018\u0016.\u0007(\u0008\u0004\u0016.\u0007(sheetInfo2));
								}
								\u001B\u0018\u0016.\u000A(sheetInfo2);
								\u0008\u0018\u0016.\u000A(\u0014\u0007\u0016.\u000A(), sheetInfo2);
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
						catch (Exception u000A4)
						{
							\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A4, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\DuplicateSheetBulkEvent.cs", "Execute");
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
			catch (Exception u000A5)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A5, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\DuplicateSheetBulkEvent.cs", "Execute");
			}
			TaskFinishedHandler u001F2 = this.\u001F;
			if (u001F2 == null)
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
				\u001C\u0007\u0016.\u000A(u001F2);
			}
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\DuplicateSheetBulkEvent.cs", "Execute");
		}

		// Token: 0x06001A57 RID: 6743 RVA: 0x000AB240 File Offset: 0x000A9440
		private bool \u0006\u0005(string \u001F, List<ViewSheet> \u000A = null)
		{
			\u0018\u0008.\u0019\u0008 u0019_u = new \u0018\u0008.\u0019\u0008();
			u0019_u.\u001F = \u001F;
			if (\u000A == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0008.\u0006\u0005(string, List<ViewSheet>)).MethodHandle;
				}
				IEnumerable<ViewSheet> enumerable = \u000E\u0013.\u001F<ViewSheet>(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004));
				Func<ViewSheet, bool> func;
				if ((func = \u0018\u0008.<>c.\u001D) == null)
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
					func = (\u0018\u0008.<>c.\u001D = new Func<ViewSheet, bool>(\u0018\u0008.<>c.\u001F.\u0018));
				}
				\u000A = Enumerable.ToList<ViewSheet>(Enumerable.Where<ViewSheet>(enumerable, func));
			}
			bool flag = Enumerable.Any<ViewSheet>(\u000A, new Func<ViewSheet, bool>(u0019_u.\u000A));
			if (!flag)
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
				flag = Enumerable.Any<SheetInfo>(\u0014\u0007\u0016.\u000A(), new Func<SheetInfo, bool>(u0019_u.\u0007));
			}
			return flag;
		}

		// Token: 0x06001A58 RID: 6744 RVA: 0x000AB300 File Offset: 0x000A9500
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private string \u000F\u0005(string \u001F, int \u000A)
		{
			return \u0002\u0013\u000A.\u000A(\u001F, " Copy ", \u0008\u0005\u0016.\u000A(ref \u000A, "D3", \u001F\u0015\u000A.\u000A()));
		}

		// Token: 0x04000A7D RID: 2685
		[CompilerGenerated]
		private List<SheetInfo> \u0012\u000A;

		// Token: 0x04000A7E RID: 2686
		[CompilerGenerated]
		private int \u000C\u000A;

		// Token: 0x04000A7F RID: 2687
		[CompilerGenerated]
		private bool \u0015\u000A;

		// Token: 0x04000A80 RID: 2688
		[CompilerGenerated]
		private int \u0001\u000A;

		// Token: 0x04000A81 RID: 2689
		[CompilerGenerated]
		private bool \u0009\u000A;

		// Token: 0x04000A82 RID: 2690
		[CompilerGenerated]
		private bool \u001F\u0007;

		// Token: 0x04000A83 RID: 2691
		[CompilerGenerated]
		private bool \u000A\u0007;

		// Token: 0x04000A84 RID: 2692
		[CompilerGenerated]
		private bool \u0007\u0007;

		// Token: 0x02000967 RID: 2407
		[CompilerGenerated]
		private sealed class \u0019\u0008
		{
			// Token: 0x060052BF RID: 21183 RVA: 0x001EB1D0 File Offset: 0x001E93D0
			internal bool \u000A(ViewSheet \u001F)
			{
				return \u000D\u0008\u000A.\u000A(\u0020\u0008\u001D.\u000A(\u001F), this.\u001F, true);
			}

			// Token: 0x060052C0 RID: 21184 RVA: 0x001EB1F4 File Offset: 0x001E93F4
			internal bool \u0007(SheetInfo \u001F)
			{
				return \u000D\u0008\u000A.\u000A(\u0011\u0007\u0016.\u0007(\u001F), this.\u001F, true);
			}

			// Token: 0x0400249D RID: 9373
			public string \u001F;
		}
	}
}
