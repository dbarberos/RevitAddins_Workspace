using System;
using System.Collections;
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
	// Token: 0x020002A1 RID: 673
	internal class \u000B\u0008 : ExternalEventInfo
	{
		// Token: 0x1400002A RID: 42
		// (add) Token: 0x06001A5A RID: 6746 RVA: 0x000AB34C File Offset: 0x000A954C
		// (remove) Token: 0x06001A5B RID: 6747 RVA: 0x000AB39C File Offset: 0x000A959C
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
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000B\u0008.add_\u001F(TaskFinishedHandler)).MethodHandle;
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
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000B\u0008.remove_\u001F(TaskFinishedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x1700073E RID: 1854
		// (get) Token: 0x06001A5C RID: 6748 RVA: 0x000AB3EC File Offset: 0x000A95EC
		// (set) Token: 0x06001A5D RID: 6749 RVA: 0x000AB400 File Offset: 0x000A9600
		public SheetInfo SelectedSheet { get; set; }

		// Token: 0x1700073F RID: 1855
		// (get) Token: 0x06001A5E RID: 6750 RVA: 0x000AB414 File Offset: 0x000A9614
		// (set) Token: 0x06001A5F RID: 6751 RVA: 0x000AB428 File Offset: 0x000A9628
		public SheetInfo TargetSheet { get; set; }

		// Token: 0x17000740 RID: 1856
		// (get) Token: 0x06001A60 RID: 6752 RVA: 0x000AB43C File Offset: 0x000A963C
		// (set) Token: 0x06001A61 RID: 6753 RVA: 0x000AB450 File Offset: 0x000A9650
		public bool ChangeTemplate { get; set; }

		// Token: 0x17000741 RID: 1857
		// (get) Token: 0x06001A62 RID: 6754 RVA: 0x000AB464 File Offset: 0x000A9664
		// (set) Token: 0x06001A63 RID: 6755 RVA: 0x000AB478 File Offset: 0x000A9678
		public int Numberofsheets { get; set; }

		// Token: 0x17000742 RID: 1858
		// (get) Token: 0x06001A64 RID: 6756 RVA: 0x000AB48C File Offset: 0x000A968C
		// (set) Token: 0x06001A65 RID: 6757 RVA: 0x000AB4A0 File Offset: 0x000A96A0
		public bool DuplicateViews { get; set; }

		// Token: 0x17000743 RID: 1859
		// (get) Token: 0x06001A66 RID: 6758 RVA: 0x000AB4B4 File Offset: 0x000A96B4
		// (set) Token: 0x06001A67 RID: 6759 RVA: 0x000AB4C8 File Offset: 0x000A96C8
		public int DuplicateOption { get; set; } = 1;

		// Token: 0x17000744 RID: 1860
		// (get) Token: 0x06001A68 RID: 6760 RVA: 0x000AB4DC File Offset: 0x000A96DC
		// (set) Token: 0x06001A69 RID: 6761 RVA: 0x000AB4F0 File Offset: 0x000A96F0
		public bool CopyRevisions { get; set; }

		// Token: 0x17000745 RID: 1861
		// (get) Token: 0x06001A6A RID: 6762 RVA: 0x000AB504 File Offset: 0x000A9704
		// (set) Token: 0x06001A6B RID: 6763 RVA: 0x000AB518 File Offset: 0x000A9718
		public bool CopyTitleBlockParameters { get; set; }

		// Token: 0x17000746 RID: 1862
		// (get) Token: 0x06001A6C RID: 6764 RVA: 0x000AB52C File Offset: 0x000A972C
		// (set) Token: 0x06001A6D RID: 6765 RVA: 0x000AB540 File Offset: 0x000A9740
		public bool KeepLegends { get; set; }

		// Token: 0x17000747 RID: 1863
		// (get) Token: 0x06001A6E RID: 6766 RVA: 0x000AB554 File Offset: 0x000A9754
		// (set) Token: 0x06001A6F RID: 6767 RVA: 0x000AB568 File Offset: 0x000A9768
		public bool KeepSchedules { get; set; }

		// Token: 0x06001A70 RID: 6768 RVA: 0x000AB57C File Offset: 0x000A977C
		public override void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\DuplicateSheetEvent.cs", "Execute");
			Document document = \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app));
			ViewInfoCollector viewInfoCollector = \u000E\u0005\u0016.\u000A(document);
			try
			{
				Document document2 = document;
				Func<ViewSheet, bool> filter;
				if ((filter = \u000B\u0008.<>c.\u000A) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000B\u0008.Execute(UIApplication)).MethodHandle;
					}
					filter = (\u000B\u0008.<>c.\u000A = new Func<ViewSheet, bool>(\u000B\u0008.<>c.\u001F.\u0004));
				}
				List<ViewSheet> u000A = Enumerable.ToList<ViewSheet>(document2.CollectElements(filter));
				if (\u0001\u0005\u0016.\u000A(this))
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
					\u000D\u0005\u0016.\u000A(SheetTemplate.\u0006(\u001D\u0004\u0016.\u0007(\u0015\u0005\u0016.\u000A(this)), \u001B\u001D\u0016.\u0007(\u0015\u0005\u0016.\u000A(this)), viewInfoCollector, true));
				}
				else if (\u0007\u0018\u0016.\u000A(document, \u001D\u0004\u0016.\u0007(\u0015\u0005\u0016.\u000A(this))) != null)
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
					\u000D\u0005\u0016.\u000A(SheetTemplate.\u0006(\u001D\u0004\u0016.\u0007(\u0011\u0005\u0016.\u000A(this)), \u001B\u001D\u0016.\u0007(\u0011\u0005\u0016.\u000A(this)), null, false));
				}
				else
				{
					\u000D\u0005\u0016.\u000A(SheetTemplate.\u0006(\u001B\u0007\u0016.\u0007(\u0008\u0007\u0016.\u0007(\u0011\u0005\u0016.\u000A(this))), \u000E\u0007\u0016.\u0007(\u0008\u0007\u0016.\u0007(\u0011\u0005\u0016.\u000A(this))), \u001F\u0003\u000E.\u001F));
				}
				for (int i = 1; i <= \u001B\u0005\u0016.\u000A(this); i++)
				{
					int num = 1;
					string u000A2 = this.\u000F\u0005(\u0011\u0007\u0016.\u0007(\u0011\u0005\u0016.\u000A(this)), num);
					while (this.\u0006\u0005(this.\u000F\u0005(\u0011\u0007\u0016.\u0007(\u0011\u0005\u0016.\u000A(this)), num), u000A))
					{
						num++;
						u000A2 = this.\u000F\u0005(\u0011\u0007\u0016.\u0007(\u0011\u0005\u0016.\u000A(this)), num);
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
					SheetInfo sheetInfo = \u001C\u0005\u0016.\u000A(\u000C\u0018\u0016.\u000A(), \u0015\u0018\u0016.\u000A(viewInfoCollector));
					\u0003\u0005\u0016.\u000A(sheetInfo, u000A2);
					\u001F\u0018\u0016.\u000A(sheetInfo, u000A2);
					\u0012\u0005\u0016.\u0007(sheetInfo, UpdateStates.ToDuplicate);
					\u0001\u0019\u0016.\u000A(sheetInfo, \u0019\u0004\u0016.\u0007(\u0011\u0005\u0016.\u000A(this)));
					\u0009\u0019\u0016.\u000A(sheetInfo, \u0019\u0004\u0016.\u0007(\u0011\u0005\u0016.\u000A(this)));
					\u000F\u0005\u0016.\u000A(sheetInfo, \u0014\u0005\u0016.\u000A(this));
					\u0002\u0005\u0016.\u000A(sheetInfo, \u000C\u0005\u0016.\u000A(this));
					SheetInfo sheetInfo2 = sheetInfo;
					if (\u001A\u0005\u0016.\u000A(this))
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
						long num2;
						if (\u001D\u0004\u0016.\u0007(\u0011\u0005\u0016.\u000A(this)) > 0L)
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
							num2 = \u001D\u0004\u0016.\u0007(\u0011\u0005\u0016.\u000A(this));
						}
						else
						{
							num2 = \u0013\u0005\u0016.\u000A(\u0011\u0005\u0016.\u000A(this));
						}
						long id = num2;
						ViewSheet viewSheet = document.AsElement(id);
						FamilyInstance familyInstance = Enumerable.LastOrDefault<FamilyInstance>(viewSheet.\u0006());
						if (familyInstance != null)
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
							IEnumerable<SelectionParameter> enumerable = \u000B\u0008.\u0003\u0005(familyInstance);
							Func<SelectionParameter, ParameterModel> func;
							if ((func = \u000B\u0008.<>c.\u0007) == null)
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
								func = (\u000B\u0008.<>c.\u0007 = new Func<SelectionParameter, ParameterModel>(\u000B\u0008.<>c.\u001F.\u0019));
							}
							List<ParameterModel> u000A3 = Enumerable.ToList<ParameterModel>(Enumerable.Select<SelectionParameter, ParameterModel>(enumerable, func));
							\u000B\u0008.\u0012\u0005(familyInstance, u000A3, viewSheet, \u0015\u0018\u0016.\u000A(viewInfoCollector));
							\u0016\u0005\u0016.\u000A(sheetInfo2, u000A3);
						}
					}
					IEnumerator<ParameterModel> enumerator = \u0018\u0005\u0016.\u000A(\u0005\u0005\u0016.\u0007(sheetInfo2));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							ParameterModel parameterModel = \u0019\u0005\u0016.\u000A(enumerator);
							ParameterModel u001F = \u0011\u0005\u0016.\u000A(this).\u001D(parameterModel, true);
							if (\u001D\u0005\u0016.\u0007(\u0004\u0005\u0016.\u0007(parameterModel)))
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
								\u001F\u0005\u0016.\u0007(parameterModel, \u000A\u0005\u0016.\u0007(\u0007\u0005\u0016.\u000A()).\u001F(\u0009\u0018\u0016.\u0007(u001F)));
							}
							else
							{
								\u0001\u0018\u0016.\u0007(parameterModel, \u0009\u0018\u0016.\u0007(u001F));
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
								switch (7)
								{
								case 0:
									continue;
								}
								break;
							}
							\u001F\u0017\u000A.\u000A(enumerator);
						}
					}
					sheetInfo2.TO(\u0015\u0018\u0016.\u000A(viewInfoCollector));
					\u0017\u0018\u0016.\u000A(sheetInfo2, \u000C\u0018\u0016.\u000A(), \u0014\u0005\u0016.\u000A(this), \u0017\u0005\u0016.\u000A(this), \u0020\u0005\u0016.\u000A(this));
					if (\u001E\u0005\u0016.\u000A(this))
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
						\u001E\u0018\u0016.\u0007(\u0008\u0004\u0016.\u0007(sheetInfo2), Enumerable.ToList<RevisionData>(\u0013\u0004\u0016.\u0007(\u0008\u0004\u0016.\u0007(\u0011\u0005\u0016.\u000A(this)))));
						\u0011\u0018\u0016.\u0007(\u0008\u0004\u0016.\u0007(sheetInfo2));
					}
					\u001B\u0018\u0016.\u000A(sheetInfo2);
					\u0008\u0018\u0016.\u000A(\u0014\u0007\u0016.\u000A(), sheetInfo2);
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
			catch (Exception u000A4)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A4, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\DuplicateSheetEvent.cs", "Execute");
			}
			TaskFinishedHandler u001F2 = this.\u001F;
			if (u001F2 == null)
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
				\u001C\u0007\u0016.\u000A(u001F2);
			}
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\DuplicateSheetEvent.cs", "Execute");
		}

		// Token: 0x06001A71 RID: 6769 RVA: 0x000ABA84 File Offset: 0x000A9C84
		internal static void \u0012\u0005(FamilyInstance \u001F, IEnumerable<ParameterModel> \u000A, Element \u0007, ITitleBlockService \u001D)
		{
			IEnumerator<ParameterModel> enumerator = \u0018\u0005\u0016.\u000A(\u000A);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ParameterModel u001F = \u0019\u0005\u0016.\u000A(enumerator);
					Parameter u000A = \u0014\u0013\u0007.\u000A(\u001F, \u001F\u0016\u0016.\u0007(\u0004\u0005\u0016.\u0007(u001F)));
					\u0009\u0005\u0016.\u000A(u001F, u000A, null, \u0007);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000B\u0008.\u0012\u0005(FamilyInstance, IEnumerable<ParameterModel>, Element, ITitleBlockService)).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}

		// Token: 0x06001A72 RID: 6770 RVA: 0x000ABB0C File Offset: 0x000A9D0C
		internal static IEnumerable<SelectionParameter> \u0003\u0005(FamilyInstance \u001F)
		{
			List<SelectionParameter> list = \u0016\u0016\u0016.\u000A();
			IEnumerator u001F = \u0018\u0016\u0016.\u000A(\u0005\u0016\u0016.\u000A(\u001F));
			try
			{
				while (\u000A\u0017\u000A.\u000A(u001F))
				{
					\u000B\u0008.\u0005\u0008 u0005_u = new \u000B\u0008.\u0005\u0008();
					u0005_u.\u001F = \u0006\u0003\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F));
					if (\u0010\u0014\u0007.\u000A(u0005_u.\u001F))
					{
						goto IL_A6;
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000B\u0008.\u0003\u0005(FamilyInstance)).MethodHandle;
					}
					if (\u0011\u001F\u001D.\u0007(u0005_u.\u001F) == null)
					{
						goto IL_A6;
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
					if (\u0011\u001F\u001D.\u0007(u0005_u.\u001F) == 4)
					{
						goto IL_A6;
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
					bool flag = !\u0019\u0016\u0016.\u000A(list, new Predicate<SelectionParameter>(u0005_u.\u000A));
					IL_A7:
					if (!flag)
					{
						continue;
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
					if (\u0004\u0016\u0016.\u000A(\u000F\u0003\u000E.\u001F(\u0020\u001F\u001D.\u0007(u0005_u.\u001F))) == -1L)
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
						SelectionParameter selectionParameter = \u001D\u0016\u0016.\u000A(u0005_u.\u001F, SelectionParameterType.Sheet);
						if (\u001E\u000B\u0018.\u000A(\u0020\u001F\u001D.\u0007(u0005_u.\u001F)))
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
							\u0007\u0016\u0016.\u000A(selectionParameter, true);
						}
						\u000A\u0016\u0016.\u000A(list, selectionParameter);
						continue;
					}
					continue;
					IL_A6:
					flag = false;
					goto IL_A7;
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
				IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F);
				if (disposable != null)
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
					\u001F\u0017\u000A.\u000A(disposable);
				}
			}
			return list;
		}

		// Token: 0x06001A73 RID: 6771 RVA: 0x000ABC88 File Offset: 0x000A9E88
		private bool \u0006\u0005(string \u001F, List<ViewSheet> \u000A = null)
		{
			\u000B\u0008.\u0016\u0008 u0016_u = new \u000B\u0008.\u0016\u0008();
			u0016_u.\u001F = \u001F;
			if (\u000A == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000B\u0008.\u0006\u0005(string, List<ViewSheet>)).MethodHandle;
				}
				IEnumerable<ViewSheet> enumerable = Enumerable.ToList<ViewSheet>(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004).CollectElements(null));
				Func<ViewSheet, bool> func;
				if ((func = \u000B\u0008.<>c.\u001D) == null)
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
					func = (\u000B\u0008.<>c.\u001D = new Func<ViewSheet, bool>(\u000B\u0008.<>c.\u001F.\u0018));
				}
				\u000A = Enumerable.ToList<ViewSheet>(Enumerable.Where<ViewSheet>(enumerable, func));
			}
			bool flag = Enumerable.Any<ViewSheet>(\u000A, new Func<ViewSheet, bool>(u0016_u.\u000A));
			if (!flag)
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
				flag = Enumerable.Any<SheetInfo>(\u0014\u0007\u0016.\u000A(), new Func<SheetInfo, bool>(u0016_u.\u0007));
			}
			return flag;
		}

		// Token: 0x06001A74 RID: 6772 RVA: 0x000ABD50 File Offset: 0x000A9F50
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private string \u000F\u0005(string \u001F, int \u000A)
		{
			return \u0002\u0013\u000A.\u000A(\u001F, " Copy ", \u0008\u0005\u0016.\u000A(ref \u000A, "D3", \u001F\u0015\u000A.\u000A()));
		}

		// Token: 0x04000A86 RID: 2694
		[CompilerGenerated]
		private SheetInfo \u001D\u0007;

		// Token: 0x04000A87 RID: 2695
		[CompilerGenerated]
		private SheetInfo \u0004\u0007;

		// Token: 0x04000A88 RID: 2696
		[CompilerGenerated]
		private bool \u0019\u0007;

		// Token: 0x04000A89 RID: 2697
		[CompilerGenerated]
		private int \u0018\u0007;

		// Token: 0x04000A8A RID: 2698
		[CompilerGenerated]
		private bool \u0015\u000A;

		// Token: 0x04000A8B RID: 2699
		[CompilerGenerated]
		private int \u0005\u0007;

		// Token: 0x04000A8C RID: 2700
		[CompilerGenerated]
		private bool \u0009\u000A;

		// Token: 0x04000A8D RID: 2701
		[CompilerGenerated]
		private bool \u0007\u0007;

		// Token: 0x04000A8E RID: 2702
		[CompilerGenerated]
		private bool \u001F\u0007;

		// Token: 0x04000A8F RID: 2703
		[CompilerGenerated]
		private bool \u000A\u0007;

		// Token: 0x02000969 RID: 2409
		[CompilerGenerated]
		private sealed class \u0005\u0008
		{
			// Token: 0x060052C7 RID: 21191 RVA: 0x001EB2A4 File Offset: 0x001E94A4
			internal bool \u000A(SelectionParameter \u001F)
			{
				return \u001B\u0002\u0010.\u000A(\u001F, this.\u001F);
			}

			// Token: 0x040024A2 RID: 9378
			public Parameter \u001F;
		}

		// Token: 0x0200096A RID: 2410
		[CompilerGenerated]
		private sealed class \u0016\u0008
		{
			// Token: 0x060052C9 RID: 21193 RVA: 0x001EB2D4 File Offset: 0x001E94D4
			internal bool \u000A(ViewSheet \u001F)
			{
				return \u000D\u0008\u000A.\u000A(\u0020\u0008\u001D.\u000A(\u001F), this.\u001F, true);
			}

			// Token: 0x060052CA RID: 21194 RVA: 0x001EB2F8 File Offset: 0x001E94F8
			internal bool \u0007(SheetInfo \u001F)
			{
				return \u000D\u0008\u000A.\u000A(\u0011\u0007\u0016.\u0007(\u001F), this.\u001F, true);
			}

			// Token: 0x040024A3 RID: 9379
			public string \u001F;
		}
	}
}
