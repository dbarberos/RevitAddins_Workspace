using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.RoomPro.Enums;
using DiRoots.RoomPro.Models;
using DiRoots.RoomPro.UI.Windows.ProgressWindows;
using DiRoots.SpatialElementViews.Models;

namespace A
{
	// Token: 0x0200009F RID: 159
	internal class \u0016\u0004 : ExternalEventInfo
	{
		// Token: 0x06000662 RID: 1634 RVA: 0x00024760 File Offset: 0x00022960
		public \u0016\u0004()
		{
			\u0009\u0004\u001D.\u000A(this, true);
			\u0001\u0004\u001D.\u000A(this, new List<ViewsReport>());
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000663 RID: 1635 RVA: 0x00024788 File Offset: 0x00022988
		// (set) Token: 0x06000664 RID: 1636 RVA: 0x0002479C File Offset: 0x0002299C
		public ViewsCreationHandler ViewsCreationHandler { get; set; }

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000665 RID: 1637 RVA: 0x000247B0 File Offset: 0x000229B0
		// (set) Token: 0x06000666 RID: 1638 RVA: 0x000247C4 File Offset: 0x000229C4
		public SectionAndElevationUserSettings SectionAndElevationUserSettings { get; set; }

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000667 RID: 1639 RVA: 0x000247D8 File Offset: 0x000229D8
		// (set) Token: 0x06000668 RID: 1640 RVA: 0x000247EC File Offset: 0x000229EC
		public CalloutUserSettings CalloutUserSettings { get; set; }

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000669 RID: 1641 RVA: 0x00024800 File Offset: 0x00022A00
		// (set) Token: 0x0600066A RID: 1642 RVA: 0x00024814 File Offset: 0x00022A14
		public bool CreateCallouts { get; set; }

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x0600066B RID: 1643 RVA: 0x00024828 File Offset: 0x00022A28
		// (set) Token: 0x0600066C RID: 1644 RVA: 0x0002483C File Offset: 0x00022A3C
		public bool CreateSectionOrElevation { get; set; }

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x0600066D RID: 1645 RVA: 0x00024850 File Offset: 0x00022A50
		// (set) Token: 0x0600066E RID: 1646 RVA: 0x00024864 File Offset: 0x00022A64
		public SectionOrElevationView SectionOrElevationView { get; set; }

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x0600066F RID: 1647 RVA: 0x00024878 File Offset: 0x00022A78
		// (set) Token: 0x06000670 RID: 1648 RVA: 0x0002488C File Offset: 0x00022A8C
		public List<ModelSpatialElement> SelectedSpatialElements { get; set; }

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000671 RID: 1649 RVA: 0x000248A0 File Offset: 0x00022AA0
		// (set) Token: 0x06000672 RID: 1650 RVA: 0x000248B4 File Offset: 0x00022AB4
		public SpatialElementsSchema SpatialElementsSchema { get; set; }

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000673 RID: 1651 RVA: 0x000248C8 File Offset: 0x00022AC8
		// (set) Token: 0x06000674 RID: 1652 RVA: 0x000248DC File Offset: 0x00022ADC
		public List<ViewsReport> Reports { get; set; }

		// Token: 0x06000675 RID: 1653 RVA: 0x000248F0 File Offset: 0x00022AF0
		public override void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Core\\ExternalEvents\\CreateViewsEvent.cs", "Execute");
			Document document = \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app));
			this.\u0007 = new \u0013\u001D(document);
			IEnumerable<ModelRoom> enumerable = \u000E\u0008\u0007.\u0007(\u0011\u0019\u001D.\u000A(this));
			Func<ModelRoom, bool> func;
			if ((func = \u0016\u0004.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0004.Execute(UIApplication)).MethodHandle;
				}
				func = (\u0016\u0004.<>c.\u000A = new Func<ModelRoom, bool>(\u0016\u0004.<>c.\u001F.\u0018));
			}
			\u001E\u0019\u001D.\u000A(this, Enumerable.ToList<ModelSpatialElement>(Enumerable.Cast<ModelSpatialElement>(Enumerable.Where<ModelRoom>(enumerable, func))));
			object u001F = \u001F\u0019\u001D.\u000A(this);
			IEnumerable<ModelSpace> enumerable2 = \u0008\u0008\u0007.\u0007(\u0011\u0019\u001D.\u000A(this));
			Func<ModelSpace, bool> func2;
			if ((func2 = \u0016\u0004.<>c.\u0007) == null)
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
				func2 = (\u0016\u0004.<>c.\u0007 = new Func<ModelSpace, bool>(\u0016\u0004.<>c.\u001F.\u0005));
			}
			\u001B\u0019\u001D.\u000A(u001F, Enumerable.Where<ModelSpace>(enumerable2, func2));
			TransactionGroup transactionGroup = \u0009\u0017\u0007.\u000A(document, \u0008\u0019\u001D.\u000A());
			try
			{
				\u0001\u0017\u0007.\u000A(transactionGroup);
				List<ModelSpatialElement>.Enumerator enumerator = \u0002\u001C\u0007.\u000A(\u001F\u0019\u001D.\u000A(this));
				try
				{
					while (\u0004\u001C\u0007.\u000A(ref enumerator))
					{
						ModelSpatialElement modelSpatialElement = \u000B\u001C\u0007.\u000A(ref enumerator);
						\u000D\u0019\u001D.\u000A(this, \u0010\u0019\u001D.\u000A(\u000E\u0019\u001D.\u000A()));
						if (\u001C\u0019\u001D.\u000A(this))
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
							this.\u000D\u0019(document, transactionGroup, modelSpatialElement);
							this.\u000E\u0019(modelSpatialElement);
						}
						if (\u0003\u0019\u001D.\u000A(this))
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
							SectionData sectionData = \u0008\u001D.\u001B(\u001D\u0019\u001D.\u000A(modelSpatialElement), \u000B\u0019\u001D.\u000A(this), \u000C\u0009\u0007.\u001D(modelSpatialElement));
							\u0012\u0019\u001D.\u000A(\u0018\u0019\u001D.\u000A(this), \u000E\u0004\u0007.\u000A(\u000C\u0004\u0007.\u000A(sectionData)) + 1);
							if (Enumerable.Any<Boundary>(\u000C\u0004\u0007.\u000A(sectionData)))
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
								Transaction transaction;
								\u000F\u0019\u001D.\u000A(\u0018\u0019\u001D.\u000A(this), transaction = \u001D\u0014\u0007.\u000A(document, "CreatingSectionElevation"));
								Transaction transaction2 = transaction;
								try
								{
									\u0007\u0014\u0007.\u000A(\u000F\u0009\u0007.\u001D(\u0018\u0019\u001D.\u000A(this)));
									\u000F\u0009\u0007.\u001D(\u0018\u0019\u001D.\u000A(this)).\u001D(new \u0003\u001D());
									List<View> list = \u0006\u0019\u001D.\u000A();
									List<ElevationMarker> list2 = \u0002\u0019\u001D.\u000A();
									this.\u001C\u0019(\u0018\u0019\u001D.\u000A(this), document, sectionData, modelSpatialElement, ref list, ref list2);
									List<SpatialElementParameter> u = \u0002\u000B\u0007.\u000A(\u001F\u001E\u0007.\u000A(\u000B\u0019\u001D.\u000A(this)));
									this.\u0003\u0019(modelSpatialElement, list, u);
									this.\u0004 = true;
									object u001F2 = \u001E\u0008\u0007.\u0007(\u0011\u0008\u0007.\u000A(modelSpatialElement));
									IEnumerable<View> enumerable3 = list;
									Func<View, string> func3;
									if ((func3 = \u0016\u0004.<>c.\u001D) == null)
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
										func3 = (\u0016\u0004.<>c.\u001D = new Func<View, string>(\u0016\u0004.<>c.\u001F.\u0016));
									}
									\u0016\u0019\u001D.\u000A(u001F2, Enumerable.ToList<string>(Enumerable.Select<View, string>(enumerable3, func3)));
									object u001F3 = \u001B\u0008\u0007.\u0007(\u0011\u0008\u0007.\u000A(modelSpatialElement));
									IEnumerable<ElevationMarker> enumerable4 = list2;
									Func<ElevationMarker, string> func4;
									if ((func4 = \u0016\u0004.<>c.\u0004) == null)
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
										func4 = (\u0016\u0004.<>c.\u0004 = new Func<ElevationMarker, string>(\u0016\u0004.<>c.\u001F.\u000B));
									}
									\u0016\u0019\u001D.\u000A(u001F3, Enumerable.ToList<string>(Enumerable.Select<ElevationMarker, string>(enumerable4, func4)));
									\u0005\u0019\u001D.\u000A(\u0018\u0019\u001D.\u000A(this));
									\u001B\u0001\u000A.\u000A(\u000F\u0009\u0007.\u001D(\u0018\u0019\u001D.\u000A(this)));
								}
								catch (Exception ex)
								{
									\u000D\u0011\u000A.\u0007(\u001E\u000A\u0007.\u000A(), ex, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Core\\ExternalEvents\\CreateViewsEvent.cs", "Execute");
									\u0004\u0019\u001D.\u000A(\u0018\u0019\u001D.\u000A(this), transactionGroup, modelSpatialElement, \u0019\u0019\u001D.\u000A(this).ToString(), ex);
									this.\u0017\u0019();
									continue;
								}
								finally
								{
									if (transaction2 != null)
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
										\u001F\u0017\u000A.\u000A(transaction2);
									}
								}
								this.\u000E\u0019(modelSpatialElement);
							}
							else
							{
								ViewsReport viewsReport = \u0015\u0014\u0007.\u000A();
								\u000C\u0014\u0007.\u000A(viewsReport, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001D\u0019\u001D.\u000A(modelSpatialElement))));
								\u0013\u0014\u0007.\u000A(viewsReport, \u001A\u0014\u0007.\u0007(\u0016\u0018\u0007.\u0007(\u001D\u0019\u001D.\u000A(modelSpatialElement), -1006900L)));
								\u0017\u0014\u0007.\u000A(viewsReport, \u0007\u000D\u0007.\u0007(modelSpatialElement));
								\u0020\u0014\u0007.\u000A(viewsReport, ReportStates.Warning);
								\u0011\u0014\u0007.\u000A(viewsReport, \u0012\u0013\u0007.\u000A());
								\u0008\u0014\u0007.\u000A(viewsReport, \u0007\u0019\u001D.\u000A());
								ViewsReport u000A = viewsReport;
								\u000E\u0014\u0007.\u000A(\u000A\u0019\u001D.\u000A(this), u000A);
							}
						}
						this.\u0017\u0019();
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
				Transaction transaction3 = \u001D\u0014\u0007.\u000A(document, "DiRoots_SectionCreator_SaveSpatialElements");
				try
				{
					\u0007\u0014\u0007.\u000A(transaction3);
					enumerator = \u0002\u001C\u0007.\u000A(\u001F\u0019\u001D.\u000A(this));
					try
					{
						while (\u0004\u001C\u0007.\u000A(ref enumerator))
						{
							\u001A\u0010\u0007.\u000A(\u000B\u001C\u0007.\u000A(ref enumerator));
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
					\u001B\u0001\u000A.\u000A(transaction3);
				}
				finally
				{
					if (transaction3 != null)
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
						\u001F\u0017\u000A.\u000A(transaction3);
					}
				}
				\u000C\u0017\u0007.\u000A(transactionGroup);
				this.\u0012\u0019();
			}
			catch (Exception u000A2)
			{
				\u000D\u0011\u000A.\u0007(\u001E\u000A\u0007.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Core\\ExternalEvents\\CreateViewsEvent.cs", "Execute");
				\u001A\u0017\u0007.\u000A(transactionGroup);
				this.\u0017\u0019();
			}
			finally
			{
				if (transactionGroup != null)
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
					\u001F\u0017\u000A.\u000A(transactionGroup);
				}
			}
			\u000F\u0012\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Core\\ExternalEvents\\CreateViewsEvent.cs", "Execute");
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x00024ED8 File Offset: 0x000230D8
		private void \u0012\u0019()
		{
			\u0013\u0019\u001D.\u000A(\u000A\u0019\u001D.\u000A(this), new Action<ViewsReport>(this.\u0014\u0019));
			if (Enumerable.Any<ViewsReport>(\u0004\u0009\u0007.\u001D(\u0018\u0019\u001D.\u000A(this))))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0004.\u0012\u0019()).MethodHandle;
				}
				this.\u0020\u0019();
			}
			if (\u0014\u0019\u001D.\u0007(this))
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
				if (!Enumerable.Any<ViewsReport>(\u0004\u0009\u0007.\u001D(\u0018\u0019\u001D.\u000A(this))))
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
					ShowMessage u001F = \u0020\u0019\u001D.\u000A(\u0017\u0019\u001D.\u000A(), MessageBoxButtons.OK);
					\u000C\u000E\u0007.\u0007(u001F, \u0019\u000A\u001D.\u000A());
					\u0020\u0014\u000A.\u0007(u001F, WindowStartupLocation.CenterOwner);
					\u0018\u0020\u000A.\u0007(u001F);
				}
			}
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x00024F90 File Offset: 0x00023190
		private void \u0003\u0019(ModelSpatialElement \u001F, List<View> \u000A, List<SpatialElementParameter> \u0007)
		{
			List<View>.Enumerator enumerator = \u0018\u0010\u0007.\u000A(\u000A);
			try
			{
				while (\u0007\u0010\u0007.\u000A(ref enumerator))
				{
					View view = \u0019\u0010\u0007.\u000A(ref enumerator);
					this.\u001B\u0019(\u001D\u0019\u001D.\u000A(\u001F), view, \u0007, false);
					\u001A\u0019\u001D.\u000A(view, \u000B\u0019\u001D.\u000A(this));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0004.\u0003\u0019(ModelSpatialElement, List<View>, List<SpatialElementParameter>)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x00025010 File Offset: 0x00023210
		private unsafe void \u001C\u0019(ViewsCreationHandler \u001F, Document \u000A, SectionData \u0007, ModelSpatialElement \u001D, ref List<View> \u0004, ref List<ElevationMarker> \u0019)
		{
			SectionOrElevationView sectionOrElevationView = \u0019\u0019\u001D.\u000A(this);
			if (sectionOrElevationView == SectionOrElevationView.Elevation)
			{
				List<ViewsReport> u001F;
				\u0004 = Enumerable.ToList<View>(\u001D\u0019\u001D.\u000A(\u001D).\u0004(\u001E\u0001\u000A.\u000A(\u000C\u0019\u001D.\u000A(\u0016\u000D\u0007.\u000A(\u001D))), \u001F, \u000A, \u0007, \u000B\u0019\u001D.\u000A(this), out u001F, true));
				\u0019 = this.\u0010\u0019(\u0004);
				this.\u0008\u0019(u001F);
				return;
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0004.\u001C\u0019(ViewsCreationHandler, Document, SectionData, ModelSpatialElement, List<View>*, List<ElevationMarker>*)).MethodHandle;
			}
			if (sectionOrElevationView != SectionOrElevationView.Section)
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
				return;
			}
			\u0004 = Enumerable.ToList<View>(\u001D\u0019\u001D.\u000A(\u001D).\u001D(\u001F, \u0007, \u000A, \u000B\u0019\u001D.\u000A(this), true));
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x000250C8 File Offset: 0x000232C8
		private void \u000D\u0019(Document \u001F, TransactionGroup \u000A, ModelSpatialElement \u0007)
		{
			\u0012\u0019\u001D.\u000A(\u0018\u0019\u001D.\u000A(this), 1);
			\u001F\u0018\u001D.\u000A(\u0018\u0019\u001D.\u000A(this), \u001E\u0007\u0007.\u000A("[1/1] {0} {1} {2}", \u000E\u0019\u001D.\u000A(), \u001E\u0014\u0007.\u000A(), \u001D\u000D\u0007.\u0007(\u0007)));
			Transaction transaction;
			\u000F\u0019\u001D.\u000A(\u0018\u0019\u001D.\u000A(this), transaction = \u001D\u0014\u0007.\u000A(\u001F, \u0009\u0019\u001D.\u000A()));
			Transaction transaction2 = transaction;
			try
			{
				\u0007\u0014\u0007.\u000A(\u000F\u0009\u0007.\u001D(\u0018\u0019\u001D.\u000A(this)));
				\u000F\u0009\u0007.\u001D(\u0018\u0019\u001D.\u000A(this)).\u001D(new \u0003\u001D());
				List<ViewsReport> u001F;
				View view = \u001D\u0019\u001D.\u000A(\u0007).\u000A(\u001F, \u001E\u0001\u000A.\u000A(\u000C\u0019\u001D.\u000A(\u0016\u000D\u0007.\u000A(\u0007))), \u0001\u0019\u001D.\u000A(this), out u001F, \u000C\u0009\u0007.\u001D(\u0007));
				List<SpatialElementParameter> u = \u0002\u000B\u0007.\u000A(\u001A\u0016\u0007.\u000A(\u0001\u0019\u001D.\u000A(this)));
				this.\u001B\u0019(\u001D\u0019\u001D.\u000A(\u0007), view, u, true);
				this.\u0008\u0019(u001F);
				\u0015\u0019\u001D.\u000A(view, \u0001\u0019\u001D.\u000A(this));
				this.\u001D = true;
				\u001A\u0008\u0007.\u000A(\u0020\u0008\u0007.\u0007(\u0011\u0008\u0007.\u000A(\u0007)), \u0012\u0010\u0007.\u000A(view));
				\u0005\u0019\u001D.\u000A(\u0018\u0019\u001D.\u000A(this));
				\u001B\u0001\u000A.\u000A(\u000F\u0009\u0007.\u001D(\u0018\u0019\u001D.\u000A(this)));
			}
			catch (Exception u2)
			{
				\u0004\u0019\u001D.\u000A(\u0018\u0019\u001D.\u000A(this), \u000A, \u0007, \u001E\u0014\u0007.\u000A(), u2);
			}
			finally
			{
				if (transaction2 != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0004.\u000D\u0019(Document, TransactionGroup, ModelSpatialElement)).MethodHandle;
					}
					\u001F\u0017\u000A.\u000A(transaction2);
				}
			}
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x00025290 File Offset: 0x00023490
		private List<ElevationMarker> \u0010\u0019(List<View> \u001F)
		{
			\u0016\u0004.\u0018\u0004 u0018_u = new \u0016\u0004.\u0018\u0004();
			u0018_u.\u000A = \u001F;
			IEnumerable<Element> enumerable = this.\u0007.\u000A(-2000535L);
			Func<Element, bool> func;
			if ((func = \u0016\u0004.<>c.\u0019) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0004.\u0010\u0019(List<View>)).MethodHandle;
				}
				func = (\u0016\u0004.<>c.\u0019 = new Func<Element, bool>(\u0016\u0004.<>c.\u001F.\u0002));
			}
			IEnumerable<ElevationMarker> enumerable2 = Enumerable.OfType<ElevationMarker>(Enumerable.Where<Element>(enumerable, func));
			u0018_u.\u001F = \u000A\u0018\u001D.\u000A(\u001E\u0011\u000A.\u000A(\u0006\u001F\u000E.\u001F()));
			return Enumerable.ToList<ElevationMarker>(Enumerable.Where<ElevationMarker>(enumerable2, new Func<ElevationMarker, bool>(u0018_u.\u001D)));
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x00025334 File Offset: 0x00023534
		private void \u000E\u0019(ModelSpatialElement \u001F)
		{
			if (this.\u001D)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0004.\u000E\u0019(ModelSpatialElement)).MethodHandle;
				}
				\u0013\u0010\u0007.\u000A(\u001F, 0);
			}
			if (this.\u0004)
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
				\u0005\u0010\u0007.\u000A(\u001F, 0);
			}
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x0002537C File Offset: 0x0002357C
		private void \u0008\u0019(List<ViewsReport> \u001F)
		{
			if (Enumerable.Any<ViewsReport>(\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0004.\u0008\u0019(List<ViewsReport>)).MethodHandle;
				}
				List<ViewsReport>.Enumerator enumerator = \u0004\u0018\u001D.\u000A(\u001F);
				try
				{
					while (\u0007\u0018\u001D.\u000A(ref enumerator))
					{
						ViewsReport u000A = \u001D\u0018\u001D.\u000A(ref enumerator);
						\u000E\u0014\u0007.\u000A(\u000A\u0019\u001D.\u000A(this), u000A);
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
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x00025400 File Offset: 0x00023600
		private void \u001B\u0019(SpatialElement \u001F, View \u000A, List<SpatialElementParameter> \u0007, bool \u001D = false)
		{
			string text = "";
			if (\u001D)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0004.\u001B\u0019(SpatialElement, View, List<SpatialElementParameter>, bool)).MethodHandle;
				}
				text = \u001E\u0014\u0007.\u000A();
			}
			else
			{
				text = this.\u001E\u0019(text);
			}
			this.\u0011\u0019(\u001F, \u000A, \u0007, text);
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x00025448 File Offset: 0x00023648
		private void \u0011\u0019(SpatialElement \u001F, View \u000A, List<SpatialElementParameter> \u0007, string \u001D)
		{
			List<SpatialElementParameter>.Enumerator enumerator = \u000F\u0018\u001D.\u000A(\u0007);
			try
			{
				while (\u0019\u0018\u001D.\u000A(ref enumerator))
				{
					SpatialElementParameter u001F = \u0006\u0018\u001D.\u000A(ref enumerator);
					Parameter parameter = \u0014\u0013\u0007.\u000A(\u000A, \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u0007(\u0006\u000A\u001D.\u001D(u001F))));
					if (parameter != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0004.\u0011\u0019(SpatialElement, View, List<SpatialElementParameter>, string)).MethodHandle;
						}
						if (\u0010\u0014\u0007.\u000A(parameter))
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
							if (\u0011\u001F\u001D.\u0007(parameter) == 3)
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
								\u0016\u0018\u001D.\u0007(parameter, \u0005\u0018\u001D.\u000A(u001F));
								continue;
							}
							\u0018\u0018\u001D.\u000A(parameter, \u0005\u0018\u001D.\u000A(u001F));
							continue;
						}
					}
					ViewsReport viewsReport = \u0015\u0014\u0007.\u000A();
					\u000C\u0014\u0007.\u000A(viewsReport, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F)));
					\u0013\u0014\u0007.\u000A(viewsReport, \u001A\u0014\u0007.\u0007(\u0016\u0018\u0007.\u0007(\u001F, -1006900L)));
					\u0017\u0014\u0007.\u000A(viewsReport, \u0014\u0014\u0007.\u000A(\u001F));
					\u0020\u0014\u0007.\u000A(viewsReport, ReportStates.Error);
					\u0011\u0014\u0007.\u000A(viewsReport, \u001D);
					ViewsReport viewsReport2 = viewsReport;
					object u001F2 = viewsReport2;
					string u000A;
					if (parameter != null)
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
						u000A = \u0017\u0006\u0007.\u000A(\u0002\u0018\u001D.\u000A(), \u000F\u000A\u001D.\u0007(u001F));
					}
					else
					{
						u000A = \u0017\u0006\u0007.\u000A(\u000B\u0018\u001D.\u000A(), \u000F\u000A\u001D.\u0007(u001F));
					}
					\u0008\u0014\u0007.\u000A(u001F2, u000A);
					\u001D\u0009\u0007.\u000A(\u0004\u0009\u0007.\u001D(\u0018\u0019\u001D.\u000A(this)), viewsReport2);
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
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x000255E4 File Offset: 0x000237E4
		private string \u001E\u0019(string \u001F)
		{
			SectionOrElevationView sectionOrElevationView = \u0019\u0019\u001D.\u000A(this);
			if (sectionOrElevationView != SectionOrElevationView.Elevation)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0004.\u001E\u0019(string)).MethodHandle;
				}
				if (sectionOrElevationView != SectionOrElevationView.Section)
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
					\u001F = \u0012\u0018\u001D.\u000A();
				}
			}
			else
			{
				\u001F = \u0012\u0013\u0007.\u000A();
			}
			return \u001F;
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x0002563C File Offset: 0x0002383C
		private void \u0020\u0019()
		{
			\u0018\u0020\u000A.\u0007(\u0003\u0018\u001D.\u000A(\u001C\u0018\u001D.\u000A(Enumerable.ToList<Report>(Enumerable.Cast<Report>(Enumerable.Distinct<ViewsReport>(\u0004\u0009\u0007.\u001D(\u0018\u0019\u001D.\u000A(this)), new \u0008\u0004()))), \u001E\u0011\u000A.\u000A(\u0008\u0007\u000E.\u001F()), 1100), true));
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x0002569C File Offset: 0x0002389C
		private void \u0017\u0019()
		{
			\u000D\u0018\u001D.\u000A(\u001F\u0009\u0007.\u001D(\u0018\u0019\u001D.\u000A(this)), false);
			ProgressBarWindow progressBarWindow = \u001F\u0009\u0007.\u001D(\u0018\u0019\u001D.\u000A(this));
			if (progressBarWindow == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0004.\u0017\u0019()).MethodHandle;
				}
				return;
			}
			\u0019\u000B\u0007.\u0007(progressBarWindow);
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x000256EC File Offset: 0x000238EC
		[CompilerGenerated]
		private void \u0014\u0019(ViewsReport \u001F)
		{
			\u001D\u0009\u0007.\u000A(\u0004\u0009\u0007.\u001D(\u0018\u0019\u001D.\u000A(this)), \u001F);
		}

		// Token: 0x0400028A RID: 650
		private \u0013\u001D \u0007;

		// Token: 0x0400028B RID: 651
		private bool \u001D;

		// Token: 0x0400028C RID: 652
		private bool \u0004;

		// Token: 0x0400028D RID: 653
		[CompilerGenerated]
		private ViewsCreationHandler \u0019;

		// Token: 0x0400028E RID: 654
		[CompilerGenerated]
		private SectionAndElevationUserSettings \u0018;

		// Token: 0x0400028F RID: 655
		[CompilerGenerated]
		private CalloutUserSettings \u0005;

		// Token: 0x04000290 RID: 656
		[CompilerGenerated]
		private bool \u0016;

		// Token: 0x04000291 RID: 657
		[CompilerGenerated]
		private bool \u000B;

		// Token: 0x04000292 RID: 658
		[CompilerGenerated]
		private SectionOrElevationView \u0002;

		// Token: 0x04000293 RID: 659
		[CompilerGenerated]
		private List<ModelSpatialElement> \u0006;

		// Token: 0x04000294 RID: 660
		[CompilerGenerated]
		private SpatialElementsSchema \u000F;

		// Token: 0x04000295 RID: 661
		[CompilerGenerated]
		private List<ViewsReport> \u0012;

		// Token: 0x020007C5 RID: 1989
		[CompilerGenerated]
		private sealed class \u0018\u0004
		{
			// Token: 0x06004C96 RID: 19606 RVA: 0x001DC800 File Offset: 0x001DAA00
			internal bool \u001D(ElevationMarker \u001F)
			{
				IEnumerable<ElementId> enumerable = \u0012\u0018\u0007.\u000A(\u001F, this.\u001F);
				Func<ElementId, bool> func;
				if ((func = this.\u0007) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0004.\u0018\u0004.\u001D(ElevationMarker)).MethodHandle;
					}
					func = (this.\u0007 = new Func<ElementId, bool>(this.\u0004));
				}
				return Enumerable.Any<ElementId>(enumerable, func);
			}

			// Token: 0x06004C97 RID: 19607 RVA: 0x001DC854 File Offset: 0x001DAA54
			internal bool \u0004(ElementId \u001F)
			{
				\u0016\u0004.\u0005\u0004 u0005_u = new \u0016\u0004.\u0005\u0004();
				u0005_u.\u001F = \u001F;
				return Enumerable.Any<View>(this.\u000A, new Func<View, bool>(u0005_u.\u000A));
			}

			// Token: 0x04001FA0 RID: 8096
			public ElementClassFilter \u001F;

			// Token: 0x04001FA1 RID: 8097
			public List<View> \u000A;

			// Token: 0x04001FA2 RID: 8098
			public Func<ElementId, bool> \u0007;
		}

		// Token: 0x020007C6 RID: 1990
		[CompilerGenerated]
		private sealed class \u0005\u0004
		{
			// Token: 0x06004C99 RID: 19609 RVA: 0x001DC89C File Offset: 0x001DAA9C
			internal bool \u000A(View \u001F)
			{
				return \u0011\u0016\u001D.\u000A(\u0002\u001E\u000A.\u0007(\u001F), this.\u001F);
			}

			// Token: 0x04001FA3 RID: 8099
			public ElementId \u001F;
		}
	}
}
