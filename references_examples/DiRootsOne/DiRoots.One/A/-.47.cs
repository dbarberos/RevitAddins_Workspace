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

namespace A
{
	// Token: 0x020000A3 RID: 163
	internal class \u000D\u0004 : ExternalEventInfo
	{
		// Token: 0x0600069C RID: 1692 RVA: 0x00025F2C File Offset: 0x0002412C
		public \u000D\u0004()
		{
			\u0009\u0004\u001D.\u000A(this, true);
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x0600069D RID: 1693 RVA: 0x00025F48 File Offset: 0x00024148
		// (set) Token: 0x0600069E RID: 1694 RVA: 0x00025F5C File Offset: 0x0002415C
		public ViewsCreationHandler ViewsCreationHandler { get; set; }

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x0600069F RID: 1695 RVA: 0x00025F70 File Offset: 0x00024170
		// (set) Token: 0x060006A0 RID: 1696 RVA: 0x00025F84 File Offset: 0x00024184
		public SectionAndElevationUserSettings SectionAndElevationUserSettings { get; private set; }

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x060006A1 RID: 1697 RVA: 0x00025F98 File Offset: 0x00024198
		// (set) Token: 0x060006A2 RID: 1698 RVA: 0x00025FAC File Offset: 0x000241AC
		public CalloutUserSettings CalloutUserSettings { get; private set; }

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x060006A3 RID: 1699 RVA: 0x00025FC0 File Offset: 0x000241C0
		// (set) Token: 0x060006A4 RID: 1700 RVA: 0x00025FD4 File Offset: 0x000241D4
		private SectionOrElevationView SectionOrElevationView { get; set; }

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x060006A5 RID: 1701 RVA: 0x00025FE8 File Offset: 0x000241E8
		// (set) Token: 0x060006A6 RID: 1702 RVA: 0x00025FFC File Offset: 0x000241FC
		private List<ModelSpatialElement> SelectedSpatialElements { get; set; }

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x00026010 File Offset: 0x00024210
		// (set) Token: 0x060006A8 RID: 1704 RVA: 0x00026024 File Offset: 0x00024224
		public SpatialElementsSchema SpatialElementsSchema { get; set; }

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x060006A9 RID: 1705 RVA: 0x00026038 File Offset: 0x00024238
		// (set) Token: 0x060006AA RID: 1706 RVA: 0x0002604C File Offset: 0x0002424C
		public bool EventCanceled { get; set; }

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x060006AB RID: 1707 RVA: 0x00026060 File Offset: 0x00024260
		// (set) Token: 0x060006AC RID: 1708 RVA: 0x00026074 File Offset: 0x00024274
		public Document CurrentDocument { get; set; }

		// Token: 0x060006AD RID: 1709 RVA: 0x00026088 File Offset: 0x00024288
		public override void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Core\\ExternalEvents\\UpdateViewsEvent.cs", "Execute");
			\u0001\u0005\u001D.\u000A(this, \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app)));
			this.\u0007 = new \u0013\u001D(\u0020\u0005\u001D.\u000A(this));
			IEnumerable<ModelRoom> enumerable = \u000E\u0008\u0007.\u0007(\u000C\u0005\u001D.\u000A(this));
			Func<ModelRoom, bool> func;
			if ((func = \u000D\u0004.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u0004.Execute(UIApplication)).MethodHandle;
				}
				func = (\u000D\u0004.<>c.\u000A = new Func<ModelRoom, bool>(\u000D\u0004.<>c.\u001F.\u0018));
			}
			\u0015\u0005\u001D.\u000A(this, Enumerable.ToList<ModelSpatialElement>(Enumerable.Cast<ModelSpatialElement>(Enumerable.Where<ModelRoom>(enumerable, func))));
			object u001F = \u001E\u0005\u001D.\u000A(this);
			IEnumerable<ModelSpace> enumerable2 = \u0008\u0008\u0007.\u0007(\u000C\u0005\u001D.\u000A(this));
			Func<ModelSpace, bool> func2;
			if ((func2 = \u000D\u0004.<>c.\u0007) == null)
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
				func2 = (\u000D\u0004.<>c.\u0007 = new Func<ModelSpace, bool>(\u000D\u0004.<>c.\u001F.\u0005));
			}
			\u001B\u0019\u001D.\u000A(u001F, Enumerable.Where<ModelSpace>(enumerable2, func2));
			\u0013\u0005\u001D.\u000A(this, \u0010\u0019\u001D.\u000A(\u001A\u0005\u001D.\u000A()));
			\u0012\u0019\u001D.\u000A(\u0011\u0005\u001D.\u000A(this), \u0014\u0005\u001D.\u000A(\u001E\u0005\u001D.\u000A(this)));
			TransactionGroup transactionGroup = \u0009\u0017\u0007.\u000A(\u0020\u0005\u001D.\u000A(this), \u0017\u0005\u001D.\u000A());
			try
			{
				\u0001\u0017\u0007.\u000A(transactionGroup);
				this.\u0013\u0019(transactionGroup);
				Transaction transaction = \u001D\u0014\u0007.\u000A(\u0020\u0005\u001D.\u000A(this), "SectionCreator_SaveSpatialElements");
				try
				{
					\u0007\u0014\u0007.\u000A(transaction);
					List<ModelSpatialElement>.Enumerator enumerator = \u0002\u001C\u0007.\u000A(\u001E\u0005\u001D.\u000A(this));
					try
					{
						while (\u0004\u001C\u0007.\u000A(ref enumerator))
						{
							\u001A\u0010\u0007.\u000A(\u000B\u001C\u0007.\u000A(ref enumerator));
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
					\u001B\u0001\u000A.\u000A(transaction);
				}
				finally
				{
					if (transaction != null)
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
						\u001F\u0017\u000A.\u000A(transaction);
					}
				}
				if (Enumerable.Any<ViewsReport>(\u0004\u0009\u0007.\u001D(\u0011\u0005\u001D.\u000A(this))))
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
					this.\u0020\u0019();
				}
				ProgressBarWindow progressBarWindow = \u001F\u0009\u0007.\u001D(\u0011\u0005\u001D.\u000A(this));
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
				}
				else
				{
					\u0019\u000B\u0007.\u0007(progressBarWindow);
				}
				\u000C\u0017\u0007.\u000A(transactionGroup);
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u001E\u000A\u0007.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Core\\ExternalEvents\\UpdateViewsEvent.cs", "Execute");
				\u001A\u0017\u0007.\u000A(transactionGroup);
			}
			finally
			{
				if (transactionGroup != null)
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
					\u001F\u0017\u000A.\u000A(transactionGroup);
				}
			}
			this.\u001A\u0019();
			\u000F\u0012\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Core\\ExternalEvents\\UpdateViewsEvent.cs", "Execute");
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x00026364 File Offset: 0x00024564
		private void \u0013\u0019(TransactionGroup \u001F)
		{
			List<ModelSpatialElement>.Enumerator enumerator = \u0002\u001C\u0007.\u000A(\u001E\u0005\u001D.\u000A(this));
			try
			{
				while (\u0004\u001C\u0007.\u000A(ref enumerator))
				{
					ModelSpatialElement modelSpatialElement = \u000B\u001C\u0007.\u000A(ref enumerator);
					\u001F\u0018\u001D.\u000A(\u0011\u0005\u001D.\u000A(this), \u0018\u000E\u0007.\u000A("{0} {1}", \u001A\u0005\u001D.\u000A(), \u001D\u000D\u0007.\u0007(modelSpatialElement)));
					\u0005\u0019\u001D.\u000A(\u0011\u0005\u001D.\u000A(this));
					if (Enumerable.Any<string>(\u0020\u0008\u0007.\u0007(\u0011\u0008\u0007.\u000A(modelSpatialElement))))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u0004.\u0013\u0019(TransactionGroup)).MethodHandle;
						}
						this.\u0015\u0019(\u001F, modelSpatialElement);
					}
					if (Enumerable.Any<string>(\u001E\u0008\u0007.\u0007(\u0011\u0008\u0007.\u000A(modelSpatialElement))))
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
						Transaction transaction;
						\u000F\u0019\u001D.\u000A(\u0011\u0005\u001D.\u000A(this), transaction = \u001D\u0014\u0007.\u000A(\u0020\u0005\u001D.\u000A(this), "Creating_Sections"));
						Transaction transaction2 = transaction;
						try
						{
							try
							{
								\u0007\u0014\u0007.\u000A(\u000F\u0009\u0007.\u001D(\u0011\u0005\u001D.\u000A(this)));
								this.\u000C\u0019(\u0011\u0005\u001D.\u000A(this), modelSpatialElement);
								\u001B\u0001\u000A.\u000A(\u000F\u0009\u0007.\u001D(\u0011\u0005\u001D.\u000A(this)));
							}
							catch (Exception u)
							{
								\u0004\u0019\u001D.\u000A(\u0011\u0005\u001D.\u000A(this), \u001F, modelSpatialElement, \u0009\u0005\u001D.\u000A(this).ToString(), u);
								continue;
							}
							\u0005\u0010\u0007.\u000A(modelSpatialElement, 0);
						}
						finally
						{
							if (transaction2 != null)
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
								\u001F\u0017\u000A.\u000A(transaction2);
							}
						}
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

		// Token: 0x060006AF RID: 1711 RVA: 0x00026540 File Offset: 0x00024740
		private void \u001A\u0019()
		{
			if (\u0014\u0019\u001D.\u0007(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u0004.\u001A\u0019()).MethodHandle;
				}
				if (!Enumerable.Any<ViewsReport>(\u0004\u0009\u0007.\u001D(\u0011\u0005\u001D.\u000A(this))))
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
					ShowMessage u001F = \u0020\u0019\u001D.\u000A(\u001F\u0016\u001D.\u000A(), MessageBoxButtons.OK);
					\u000C\u000E\u0007.\u0007(u001F, \u0019\u000A\u001D.\u000A());
					\u0020\u0014\u000A.\u0007(u001F, WindowStartupLocation.CenterOwner);
					\u0018\u0020\u000A.\u0007(u001F);
				}
			}
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x000265B8 File Offset: 0x000247B8
		private void \u000C\u0019(ViewsCreationHandler \u001F, ModelSpatialElement \u000A)
		{
			IEnumerable<ElevationMarker> enumerable = \u0005\u0016\u001D.\u000A(\u0011\u0008\u0007.\u000A(\u000A), \u0020\u0005\u001D.\u000A(this));
			Func<ElevationMarker, ElementId> func;
			if ((func = \u000D\u0004.<>c.\u001D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u0004.\u000C\u0019(ViewsCreationHandler, ModelSpatialElement)).MethodHandle;
				}
				func = (\u000D\u0004.<>c.\u001D = new Func<ElevationMarker, ElementId>(\u000D\u0004.<>c.\u001F.\u0016));
			}
			List<ElementId> list = Enumerable.ToList<ElementId>(Enumerable.Select<ElevationMarker, ElementId>(enumerable, func));
			List<View> list3;
			List<View>.Enumerator enumerator;
			if (Enumerable.Any<ElementId>(list))
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
				\u0004\u0016\u001D.\u000A(this, SectionOrElevationView.Elevation);
				List<View> list2 = \u001C\u000D\u0007.\u000A(\u0011\u0008\u0007.\u000A(\u000A), \u0020\u0005\u001D.\u000A(this));
				\u001D\u0016\u001D.\u000A(this, \u0008\u001D\u001D.\u000A(Enumerable.First<View>(list2)));
				\u0020\u000D\u0007.\u000A(list2, new Action<View>(this.\u001F\u0018));
				\u0018\u0016\u001D.\u000A(list, new Action<ElementId>(this.\u000A\u0018));
				SectionData u = \u0008\u001D.\u001B(\u001D\u0019\u001D.\u000A(\u000A), \u0007\u0016\u001D.\u000A(this), \u000C\u0009\u0007.\u001D(\u000A));
				List<ViewsReport> u001F;
				list3 = Enumerable.ToList<View>(\u001D\u0019\u001D.\u000A(\u000A).\u0004(\u001E\u0001\u000A.\u000A(\u000C\u0019\u001D.\u000A(\u0016\u000D\u0007.\u000A(\u000A))), \u001F, \u0020\u0005\u001D.\u000A(this), u, \u0007\u0016\u001D.\u000A(this), out u001F, false));
				this.\u0008\u0019(u001F);
				enumerator = \u0018\u0010\u0007.\u000A(list3);
				try
				{
					while (\u0007\u0010\u0007.\u000A(ref enumerator))
					{
						View u001F2 = \u0019\u0010\u0007.\u000A(ref enumerator);
						this.\u0009\u0019(u001F2);
						\u001A\u0019\u001D.\u000A(u001F2, \u0007\u0016\u001D.\u000A(this));
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
				List<ElevationMarker> list4 = this.\u0010\u0019(list3);
				\u000A\u0016\u001D.\u000A(\u0011\u0008\u0007.\u000A(\u000A), Enumerable.ToList<Element>(Enumerable.OfType<Element>(list3)));
				\u0019\u0016\u001D.\u000A(\u0011\u0008\u0007.\u000A(\u000A), Enumerable.ToList<Element>(Enumerable.OfType<Element>(list4)));
				return;
			}
			\u0004\u0016\u001D.\u000A(this, SectionOrElevationView.Section);
			List<View> list5 = \u001C\u000D\u0007.\u000A(\u0011\u0008\u0007.\u000A(\u000A), \u0020\u0005\u001D.\u000A(this));
			\u001D\u0016\u001D.\u000A(this, \u0008\u001D\u001D.\u000A(Enumerable.First<View>(list5)));
			\u0020\u000D\u0007.\u000A(list5, new Action<View>(this.\u0007\u0018));
			SectionData u2 = \u0008\u001D.\u001B(\u001D\u0019\u001D.\u000A(\u000A), \u0007\u0016\u001D.\u000A(this), \u000C\u0009\u0007.\u001D(\u000A));
			list3 = Enumerable.ToList<View>(\u001D\u0019\u001D.\u000A(\u000A).\u001D(\u0011\u0005\u001D.\u000A(this), u2, \u0020\u0005\u001D.\u000A(this), \u0007\u0016\u001D.\u000A(this), false));
			enumerator = \u0018\u0010\u0007.\u000A(list3);
			try
			{
				while (\u0007\u0010\u0007.\u000A(ref enumerator))
				{
					View u001F3 = \u0019\u0010\u0007.\u000A(ref enumerator);
					this.\u0009\u0019(u001F3);
					\u001A\u0019\u001D.\u000A(u001F3, \u0007\u0016\u001D.\u000A(this));
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
			\u000A\u0016\u001D.\u000A(\u0011\u0008\u0007.\u000A(\u000A), Enumerable.ToList<Element>(Enumerable.OfType<Element>(list3)));
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x000268B8 File Offset: 0x00024AB8
		private void \u0015\u0019(TransactionGroup \u001F, ModelSpatialElement \u000A)
		{
			Transaction transaction;
			\u000F\u0019\u001D.\u000A(\u0011\u0005\u001D.\u000A(this), transaction = \u001D\u0014\u0007.\u000A(\u0020\u0005\u001D.\u000A(this), "Creating_Callouts"));
			Transaction transaction2 = transaction;
			try
			{
				try
				{
					\u0007\u0014\u0007.\u000A(\u000F\u0009\u0007.\u001D(\u0011\u0005\u001D.\u000A(this)));
					object u001F = Enumerable.ToList<View>(Enumerable.OfType<View>(Enumerable.Select<string, Element>(\u0020\u0008\u0007.\u0007(\u0011\u0008\u0007.\u000A(\u000A)), new Func<string, Element>(this.\u001D\u0018))));
					List<View> list = \u0006\u0019\u001D.\u000A();
					List<View>.Enumerator enumerator = \u0018\u0010\u0007.\u000A(u001F);
					try
					{
						while (\u0007\u0010\u0007.\u000A(ref enumerator))
						{
							View u001F2 = \u0019\u0010\u0007.\u000A(ref enumerator);
							\u0006\u0016\u001D.\u000A(this, \u001B\u001D\u001D.\u000A(u001F2));
							\u0011\u0001\u000A.\u000A(\u0020\u0005\u001D.\u000A(this), \u0002\u001E\u000A.\u0007(u001F2));
							List<ViewsReport> u001F3;
							View view = \u001D\u0019\u001D.\u000A(\u000A).\u000A(\u0020\u0005\u001D.\u000A(this), \u001E\u0001\u000A.\u000A(\u000C\u0019\u001D.\u000A(\u0016\u000D\u0007.\u000A(\u000A))), \u0002\u0016\u001D.\u000A(this), out u001F3, \u000C\u0009\u0007.\u001D(\u000A));
							this.\u0001\u0019(view);
							this.\u0008\u0019(u001F3);
							\u0015\u0019\u001D.\u000A(view, \u0002\u0016\u001D.\u000A(this));
							\u000B\u0016\u001D.\u000A(list, view);
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
						if (!true)
						{
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u0004.\u0015\u0019(TransactionGroup, ModelSpatialElement)).MethodHandle;
						}
					}
					finally
					{
						((IDisposable)enumerator).Dispose();
					}
					object u001F4 = \u0011\u0008\u0007.\u000A(\u000A);
					IEnumerable<View> enumerable = list;
					Func<View, string> func;
					if ((func = \u000D\u0004.<>c.\u0004) == null)
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
						func = (\u000D\u0004.<>c.\u0004 = new Func<View, string>(\u000D\u0004.<>c.\u001F.\u000B));
					}
					\u0016\u0016\u001D.\u000A(u001F4, Enumerable.ToList<string>(Enumerable.Select<View, string>(enumerable, func)));
					\u001B\u0001\u000A.\u000A(\u000F\u0009\u0007.\u001D(\u0011\u0005\u001D.\u000A(this)));
				}
				catch (Exception u)
				{
					\u0004\u0019\u001D.\u000A(\u0011\u0005\u001D.\u000A(this), \u001F, \u000A, \u001E\u0014\u0007.\u000A(), u);
				}
				\u0013\u0010\u0007.\u000A(\u000A, 0);
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
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x00026AF8 File Offset: 0x00024CF8
		private List<ElevationMarker> \u0010\u0019(List<View> \u001F)
		{
			\u000D\u0004.\u0003\u0004 u0003_u = new \u000D\u0004.\u0003\u0004();
			u0003_u.\u000A = \u001F;
			IEnumerable<Element> enumerable = this.\u0007.\u000A(-2000535L);
			Func<Element, bool> func;
			if ((func = \u000D\u0004.<>c.\u0019) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u0004.\u0010\u0019(List<View>)).MethodHandle;
				}
				func = (\u000D\u0004.<>c.\u0019 = new Func<Element, bool>(\u000D\u0004.<>c.\u001F.\u0002));
			}
			IEnumerable<ElevationMarker> enumerable2 = Enumerable.OfType<ElevationMarker>(Enumerable.Where<Element>(enumerable, func));
			u0003_u.\u001F = \u000A\u0018\u001D.\u000A(\u001E\u0011\u000A.\u000A(\u0006\u001F\u000E.\u001F()));
			return Enumerable.ToList<ElevationMarker>(Enumerable.Where<ElevationMarker>(enumerable2, new Func<ElevationMarker, bool>(u0003_u.\u001D)));
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x00026B9C File Offset: 0x00024D9C
		private void \u0001\u0019(View \u001F)
		{
			List<SpatialElementParameter>.Enumerator enumerator = \u000F\u0018\u001D.\u000A(\u0002\u000B\u0007.\u000A(\u001A\u0016\u0007.\u000A(\u0002\u0016\u001D.\u000A(this))));
			try
			{
				while (\u0019\u0018\u001D.\u000A(ref enumerator))
				{
					SpatialElementParameter u001F = \u0006\u0018\u001D.\u000A(ref enumerator);
					Parameter parameter = \u0014\u0013\u0007.\u000A(\u001F, \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u0007(\u0006\u000A\u001D.\u001D(u001F))));
					if (parameter == null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u0004.\u0001\u0019(View)).MethodHandle;
						}
					}
					else
					{
						\u0016\u0018\u001D.\u001D(parameter, \u0005\u0018\u001D.\u000A(u001F));
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

		// Token: 0x060006B4 RID: 1716 RVA: 0x00026C50 File Offset: 0x00024E50
		private void \u0009\u0019(View \u001F)
		{
			List<SpatialElementParameter>.Enumerator enumerator = \u000F\u0018\u001D.\u000A(\u0002\u000B\u0007.\u000A(\u001F\u001E\u0007.\u000A(\u0007\u0016\u001D.\u000A(this))));
			try
			{
				while (\u0019\u0018\u001D.\u000A(ref enumerator))
				{
					SpatialElementParameter u001F = \u0006\u0018\u001D.\u000A(ref enumerator);
					if (!\u0010\u0014\u0007.\u000A(\u0006\u000A\u001D.\u001D(u001F)))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u0004.\u0009\u0019(View)).MethodHandle;
						}
						Parameter parameter = \u0014\u0013\u0007.\u000A(\u001F, \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u0007(\u0006\u000A\u001D.\u001D(u001F))));
						if (parameter == null)
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
							\u0016\u0018\u001D.\u001D(parameter, \u0005\u0018\u001D.\u000A(u001F));
						}
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

		// Token: 0x060006B5 RID: 1717 RVA: 0x00026D20 File Offset: 0x00024F20
		private void \u0008\u0019(List<ViewsReport> \u001F)
		{
			if (Enumerable.Any<ViewsReport>(\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u0004.\u0008\u0019(List<ViewsReport>)).MethodHandle;
				}
				List<ViewsReport>.Enumerator enumerator = \u0004\u0018\u001D.\u000A(\u001F);
				try
				{
					while (\u0007\u0018\u001D.\u000A(ref enumerator))
					{
						ViewsReport u000A = \u001D\u0018\u001D.\u000A(ref enumerator);
						\u001D\u0009\u0007.\u000A(\u0004\u0009\u0007.\u001D(\u0011\u0005\u001D.\u000A(this)), u000A);
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

		// Token: 0x060006B6 RID: 1718 RVA: 0x00026DAC File Offset: 0x00024FAC
		private void \u0020\u0019()
		{
			\u0018\u0020\u000A.\u0007(\u0003\u0018\u001D.\u000A(\u001C\u0018\u001D.\u000A(Enumerable.ToList<Report>(Enumerable.Cast<Report>(\u0004\u0009\u0007.\u001D(\u0011\u0005\u001D.\u000A(this)))), \u001E\u0011\u000A.\u000A(\u0008\u0007\u000E.\u001F()), 1100), true));
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x00026E00 File Offset: 0x00025000
		[CompilerGenerated]
		private void \u001F\u0018(View \u001F)
		{
			\u0011\u0001\u000A.\u000A(\u0020\u0005\u001D.\u000A(this), \u0002\u001E\u000A.\u0007(\u001F));
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x00026E28 File Offset: 0x00025028
		[CompilerGenerated]
		private void \u000A\u0018(ElementId \u001F)
		{
			\u0011\u0001\u000A.\u000A(\u0020\u0005\u001D.\u000A(this), \u001F);
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00026E48 File Offset: 0x00025048
		[CompilerGenerated]
		private void \u0007\u0018(View \u001F)
		{
			\u0011\u0001\u000A.\u000A(\u0020\u0005\u001D.\u000A(this), \u0002\u001E\u000A.\u0007(\u001F));
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x00026E70 File Offset: 0x00025070
		[CompilerGenerated]
		private Element \u001D\u0018(string \u001F)
		{
			return \u000C\u0008\u0007.\u000A(\u0020\u0005\u001D.\u000A(this), \u001F);
		}

		// Token: 0x040002A0 RID: 672
		private \u0013\u001D \u0007;

		// Token: 0x040002A1 RID: 673
		[CompilerGenerated]
		private ViewsCreationHandler \u0019;

		// Token: 0x040002A2 RID: 674
		[CompilerGenerated]
		private SectionAndElevationUserSettings \u0018;

		// Token: 0x040002A3 RID: 675
		[CompilerGenerated]
		private CalloutUserSettings \u0005;

		// Token: 0x040002A4 RID: 676
		[CompilerGenerated]
		private SectionOrElevationView \u0002;

		// Token: 0x040002A5 RID: 677
		[CompilerGenerated]
		private List<ModelSpatialElement> \u0006;

		// Token: 0x040002A6 RID: 678
		[CompilerGenerated]
		private SpatialElementsSchema \u000F;

		// Token: 0x040002A7 RID: 679
		[CompilerGenerated]
		private bool \u000D;

		// Token: 0x040002A8 RID: 680
		[CompilerGenerated]
		private Document \u0010;

		// Token: 0x020007CB RID: 1995
		[CompilerGenerated]
		private sealed class \u0003\u0004
		{
			// Token: 0x06004CAC RID: 19628 RVA: 0x001DCAB4 File Offset: 0x001DACB4
			internal bool \u001D(ElevationMarker \u001F)
			{
				IEnumerable<ElementId> enumerable = \u0012\u0018\u0007.\u000A(\u001F, this.\u001F);
				Func<ElementId, bool> func;
				if ((func = this.\u0007) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u0004.\u0003\u0004.\u001D(ElevationMarker)).MethodHandle;
					}
					func = (this.\u0007 = new Func<ElementId, bool>(this.\u0004));
				}
				return Enumerable.Any<ElementId>(enumerable, func);
			}

			// Token: 0x06004CAD RID: 19629 RVA: 0x001DCB08 File Offset: 0x001DAD08
			internal bool \u0004(ElementId \u001F)
			{
				\u000D\u0004.\u001C\u0004 u001C_u = new \u000D\u0004.\u001C\u0004();
				u001C_u.\u001F = \u001F;
				return Enumerable.Any<View>(this.\u000A, new Func<View, bool>(u001C_u.\u000A));
			}

			// Token: 0x04001FAE RID: 8110
			public ElementClassFilter \u001F;

			// Token: 0x04001FAF RID: 8111
			public List<View> \u000A;

			// Token: 0x04001FB0 RID: 8112
			public Func<ElementId, bool> \u0007;
		}

		// Token: 0x020007CC RID: 1996
		[CompilerGenerated]
		private sealed class \u001C\u0004
		{
			// Token: 0x06004CAF RID: 19631 RVA: 0x001DCB50 File Offset: 0x001DAD50
			internal bool \u000A(View \u001F)
			{
				return \u0011\u0016\u001D.\u000A(\u0002\u001E\u000A.\u0007(\u001F), this.\u001F);
			}

			// Token: 0x04001FB1 RID: 8113
			public ElementId \u001F;
		}
	}
}
