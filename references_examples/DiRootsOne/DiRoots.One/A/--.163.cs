using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.SheetGen;
using DiRoots.One.SheetGen.Data;
using DiRoots.One.SheetGen.Delegates;
using DiRoots.One.SheetGen.DI.Interfaces;
using DiRoots.One.SheetGen.Messaging;
using DiRoots.One.SheetGen.Models;
using DiRoots.One.UIBehaviours.Win32;

namespace A
{
	// Token: 0x020002A3 RID: 675
	internal class \u0011\u0008 : ExternalEventInfo
	{
		// Token: 0x06001A7C RID: 6780 RVA: 0x000ABEC8 File Offset: 0x000AA0C8
		public \u0011\u0008()
		{
			Process u001F = \u0019\u001B\u0019.\u000A();
			this.\u000B\u0007 = \u0004\u001B\u0019.\u000A(u001F);
			this.\u0002\u0007 = new ObservableCollection<Report>();
		}

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x06001A7E RID: 6782 RVA: 0x000ABF1C File Offset: 0x000AA11C
		// (remove) Token: 0x06001A7F RID: 6783 RVA: 0x000ABF6C File Offset: 0x000AA16C
		public event ManageViewsProgressHandler \u0006\u0007
		{
			[CompilerGenerated]
			add
			{
				ManageViewsProgressHandler manageViewsProgressHandler = this.\u0006\u0007;
				ManageViewsProgressHandler manageViewsProgressHandler2;
				do
				{
					manageViewsProgressHandler2 = manageViewsProgressHandler;
					ManageViewsProgressHandler value2 = \u0011\u0003\u000E.\u001F(\u000F\u001E\u000A.\u000A(manageViewsProgressHandler2, value));
					manageViewsProgressHandler = Interlocked.CompareExchange<ManageViewsProgressHandler>(ref this.\u0006\u0007, value2, manageViewsProgressHandler2);
				}
				while (manageViewsProgressHandler != manageViewsProgressHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.add_\u0006\u0007(ManageViewsProgressHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ManageViewsProgressHandler manageViewsProgressHandler = this.\u0006\u0007;
				ManageViewsProgressHandler manageViewsProgressHandler2;
				do
				{
					manageViewsProgressHandler2 = manageViewsProgressHandler;
					ManageViewsProgressHandler value2 = \u0011\u0003\u000E.\u001F(\u0012\u001E\u000A.\u000A(manageViewsProgressHandler2, value));
					manageViewsProgressHandler = Interlocked.CompareExchange<ManageViewsProgressHandler>(ref this.\u0006\u0007, value2, manageViewsProgressHandler2);
				}
				while (manageViewsProgressHandler != manageViewsProgressHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.remove_\u0006\u0007(ManageViewsProgressHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x06001A80 RID: 6784 RVA: 0x000ABFBC File Offset: 0x000AA1BC
		// (remove) Token: 0x06001A81 RID: 6785 RVA: 0x000AC00C File Offset: 0x000AA20C
		public event ManageViewsFinishedHandler \u000F\u0007
		{
			[CompilerGenerated]
			add
			{
				ManageViewsFinishedHandler manageViewsFinishedHandler = this.\u000F\u0007;
				ManageViewsFinishedHandler manageViewsFinishedHandler2;
				do
				{
					manageViewsFinishedHandler2 = manageViewsFinishedHandler;
					ManageViewsFinishedHandler value2 = \u001B\u0003\u000E.\u001F(\u000F\u001E\u000A.\u000A(manageViewsFinishedHandler2, value));
					manageViewsFinishedHandler = Interlocked.CompareExchange<ManageViewsFinishedHandler>(ref this.\u000F\u0007, value2, manageViewsFinishedHandler2);
				}
				while (manageViewsFinishedHandler != manageViewsFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.add_\u000F\u0007(ManageViewsFinishedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ManageViewsFinishedHandler manageViewsFinishedHandler = this.\u000F\u0007;
				ManageViewsFinishedHandler manageViewsFinishedHandler2;
				do
				{
					manageViewsFinishedHandler2 = manageViewsFinishedHandler;
					ManageViewsFinishedHandler value2 = \u001B\u0003\u000E.\u001F(\u0012\u001E\u000A.\u000A(manageViewsFinishedHandler2, value));
					manageViewsFinishedHandler = Interlocked.CompareExchange<ManageViewsFinishedHandler>(ref this.\u000F\u0007, value2, manageViewsFinishedHandler2);
				}
				while (manageViewsFinishedHandler != manageViewsFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.remove_\u000F\u0007(ManageViewsFinishedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x1700074A RID: 1866
		// (get) Token: 0x06001A82 RID: 6786 RVA: 0x000AC05C File Offset: 0x000AA25C
		// (set) Token: 0x06001A83 RID: 6787 RVA: 0x000AC070 File Offset: 0x000AA270
		public List<ViewManagerView> ViewsToProcess { get; set; }

		// Token: 0x1700074B RID: 1867
		// (get) Token: 0x06001A84 RID: 6788 RVA: 0x000AC084 File Offset: 0x000AA284
		// (set) Token: 0x06001A85 RID: 6789 RVA: 0x000AC098 File Offset: 0x000AA298
		public ObservableCollection<ViewManagerView> AllViews { get; set; }

		// Token: 0x1700074C RID: 1868
		// (get) Token: 0x06001A86 RID: 6790 RVA: 0x000AC0AC File Offset: 0x000AA2AC
		// (set) Token: 0x06001A87 RID: 6791 RVA: 0x000AC0C0 File Offset: 0x000AA2C0
		public ObservableCollection<ViewManagerView> AllViewTemplate { get; set; }

		// Token: 0x1700074D RID: 1869
		// (get) Token: 0x06001A88 RID: 6792 RVA: 0x000AC0D4 File Offset: 0x000AA2D4
		// (set) Token: 0x06001A89 RID: 6793 RVA: 0x000AC0E8 File Offset: 0x000AA2E8
		public bool IsDelete { get; set; }

		// Token: 0x1700074E RID: 1870
		// (get) Token: 0x06001A8A RID: 6794 RVA: 0x000AC0FC File Offset: 0x000AA2FC
		// (set) Token: 0x06001A8B RID: 6795 RVA: 0x000AC110 File Offset: 0x000AA310
		internal static bool IsWorking { get; set; } = false;

		// Token: 0x1700074F RID: 1871
		// (get) Token: 0x06001A8C RID: 6796 RVA: 0x000AC124 File Offset: 0x000AA324
		// (set) Token: 0x06001A8D RID: 6797 RVA: 0x000AC138 File Offset: 0x000AA338
		internal static string ErrorMessage { get; set; } = "";

		// Token: 0x17000750 RID: 1872
		// (get) Token: 0x06001A8E RID: 6798 RVA: 0x000AC14C File Offset: 0x000AA34C
		// (set) Token: 0x06001A8F RID: 6799 RVA: 0x000AC160 File Offset: 0x000AA360
		public List<ParameterModel> ProjectInformationToProcess { get; internal set; }

		// Token: 0x17000751 RID: 1873
		// (get) Token: 0x06001A90 RID: 6800 RVA: 0x000AC174 File Offset: 0x000AA374
		// (set) Token: 0x06001A91 RID: 6801 RVA: 0x000AC188 File Offset: 0x000AA388
		public Window VMWindow { get; internal set; }

		// Token: 0x06001A92 RID: 6802 RVA: 0x000AC19C File Offset: 0x000AA39C
		private static void \u000D\u0005(IntPtr \u001F)
		{
			\u0006\u0016\u0016.\u000A(\u001F, 16U, 0, 0);
		}

		// Token: 0x06001A93 RID: 6803 RVA: 0x000AC1B8 File Offset: 0x000AA3B8
		public override void Execute(UIApplication app)
		{
			\u0011\u0008.\u000F\u0008 u000F_u;
			u000F_u.\u0004 = this;
			\u000F\u0016\u0016.\u000A(true);
			UIDocument u001F = \u0020\u0013\u000A.\u000A(app);
			Document document = \u0011\u0020\u000A.\u0007(u001F);
			SheetAndViewCreationHelper u000A = \u0016\u000B\u0016.\u000A();
			List<ViewManagerView> u001F2 = \u0005\u000B\u0016.\u000A();
			List<long> list = \u001F\u001B\u0019.\u000A();
			this.\u000E\u0005(u001F2, list);
			List<UIView> u = Enumerable.ToList<UIView>(\u0017\u0010\u0007.\u000A(u001F));
			ViewManagerView u001F3 = \u0010\u0003\u000E.\u001F;
			this.\u0010\u0005(u001F, document, ref u001F2, list, u, ref u001F3);
			TransactionStatus transactionStatus = 0;
			Transaction u001F4 = \u000E\u0003\u000E.\u001F;
			\u0008\u0008\u000A u001F5 = \u0008\u0003\u000E.\u001F;
			if (\u0019\u000B\u0016.\u000A(\u0018\u000B\u0016.\u000A(this)) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.Execute(UIApplication)).MethodHandle;
				}
				this.\u001B\u0005(document, ref transactionStatus, ref u001F4, ref u001F5);
			}
			u000F_u.\u0007 = 0;
			u000F_u.\u001F = 0;
			u000F_u.\u000A = \u0004\u000B\u0016.\u000A(u001F2);
			u000F_u.\u001D = 10;
			TransactionGroup transactionGroup = \u000E\u000E\u001D.\u000A(document);
			try
			{
				\u0011\u0008.\u0012\u0008 u0012_u = new \u0011\u0008.\u0012\u0008();
				\u0010\u000E\u001D.\u000A(transactionGroup, "ViewManager_ApplyModifications");
				u0012_u.\u001F = \u001D\u000B\u0016.\u000A();
				List<ViewManagerView>.Enumerator enumerator = \u001A\u0016\u0016.\u000A(u001F2);
				try
				{
					while (\u0020\u0016\u0016.\u000A(ref enumerator))
					{
						ViewManagerView viewManagerView = \u0013\u0016\u0016.\u000A(ref enumerator);
						try
						{
							Transaction transaction;
							u001F4 = (transaction = \u001D\u0014\u0007.\u000A(document, \u0004\u001E\u000A.\u000A("ViewManager_ApplyModifications", \u0007\u000B\u0016.\u000A(viewManagerView))));
							try
							{
								string text;
								this.\u0017\u0005(u001F4, out u001F5, out text);
								\u0007\u0014\u0007.\u000A(u001F4);
								this.\u0002\u0016(viewManagerView, ref u000F_u);
								if (\u000A\u000B\u0016.\u0007(viewManagerView) == UpdateStates.Updated)
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
									if (\u000A\u000B\u0016.\u0007(viewManagerView) == UpdateStates.ToTrash)
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
										this.\u000C\u0005(document, u0012_u.\u001F, viewManagerView);
									}
									else
									{
										if (\u000A\u000B\u0016.\u0007(viewManagerView) != UpdateStates.ToAdd)
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
											if (\u000A\u000B\u0016.\u0007(viewManagerView) != UpdateStates.ToDuplicate)
											{
												goto IL_1DB;
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
										this.\u0008\u0005(document, u000A, viewManagerView);
									}
									IL_1DB:
									if (\u000A\u000B\u0016.\u0007(viewManagerView) != UpdateStates.Modified)
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
										if (\u000A\u000B\u0016.\u0007(viewManagerView) != UpdateStates.NameModified)
										{
											goto IL_235;
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
									if (\u001F\u000B\u0016.\u0007(viewManagerView) != null)
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
										this.\u0004\u0016(\u001F\u000B\u0016.\u0007(viewManagerView), viewManagerView);
									}
									\u0001\u0016\u0016.\u0007(viewManagerView, UpdateStates.Updated);
									IL_235:
									transactionStatus = \u001B\u0001\u000A.\u000A(u001F4);
								}
							}
							finally
							{
								if (transaction != null)
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
									\u001F\u0017\u000A.\u000A(transaction);
								}
							}
						}
						catch (Exception u001F6)
						{
							if (transactionStatus != null)
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
								if (transactionStatus != 5)
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
									if (transactionStatus != 2)
									{
										continue;
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
							}
							\u0001\u0016\u0016.\u0007(viewManagerView, \u0009\u0016\u0016.\u000A(viewManagerView));
							this.\u001F\u0016(viewManagerView, \u0003\u001A\u000A.\u000A(u001F6), ReportStates.Error);
						}
						finally
						{
							\u001F\u0004\u0016.\u0007(\u000A\u0004\u0016.\u0007(u001F5));
							if (transactionStatus != 5)
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
								if (transactionStatus != 2)
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
							\u0001\u0016\u0016.\u0007(viewManagerView, \u0009\u0016\u0016.\u000A(viewManagerView));
							this.\u001F\u0016(viewManagerView, \u0009\u001D\u0016.\u000A(u001F5), ReportStates.Error);
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
				transactionStatus = \u000C\u0017\u0007.\u000A(transactionGroup);
				if (transactionStatus == 3)
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
					\u0009\u0004\u001D.\u000A(this, true);
					if (\u000C\u0016\u0016.\u000A(\u001C\u0003\u000E.\u001F(\u0015\u0016\u0016.\u000A(this))))
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
						if (\u0003\u0016\u0016.\u000A(this))
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
							enumerator = \u001A\u0016\u0016.\u000A(u001F2);
							try
							{
								while (\u0020\u0016\u0016.\u000A(ref enumerator))
								{
									ViewManagerView u001F7 = \u0013\u0016\u0016.\u000A(ref enumerator);
									this.\u001D\u0016(\u0014\u0016\u0016.\u0007(u001F7), \u0017\u0016\u0016.\u000A(u001F7));
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
							ILoadData service = \u000E\u001B\u000A.\u0004.GetService<ILoadData>(false);
							\u001E\u0016\u0016.\u000A(service, true);
							\u0011\u0016\u0016.\u000A(service, true);
							\u001B\u0016\u0016.\u000A(service, u0012_u.\u001F);
							\u0010\u0016\u0016.\u000A(\u000A\u0004\u0016.\u0007(u001F5), true);
							\u0008\u0016\u0016.\u000A(\u0014\u0007\u0016.\u000A(), new Predicate<SheetInfo>(u0012_u.\u000A));
							\u000E\u0016\u0016.\u000A(service);
							\u0010\u0016\u0016.\u000A(\u000A\u0004\u0016.\u0007(u001F5), false);
							object u001F8 = \u0014\u0007\u0016.\u000A();
							Comparison<SheetInfo> u000A2;
							if ((u000A2 = \u0011\u0008.<>c.\u000A) == null)
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
								u000A2 = (\u0011\u0008.<>c.\u000A = new Comparison<SheetInfo>(\u0011\u0008.<>c.\u001F.\u001D));
							}
							\u000D\u0016\u0016.\u000A(u001F8, u000A2);
							\u0005\u001B\u000A.\u0018.\u0019<object>(\u001C\u0016\u0016.\u000A(), Context.RefreshSheets);
						}
					}
				}
			}
			finally
			{
				if (transactionGroup != null)
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
					\u001F\u0017\u000A.\u000A(transactionGroup);
				}
			}
			ManageViewsFinishedHandler u000F_u2 = this.\u000F\u0007;
			if (u000F_u2 == null)
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
				\u0012\u0016\u0016.\u000A(u000F_u2, \u0003\u0016\u0016.\u000A(this), \u0014\u0019\u001D.\u0007(this), this.\u0002\u0007);
			}
			\u000F\u0016\u0016.\u000A(false);
		}

		// Token: 0x06001A94 RID: 6804 RVA: 0x000AC73C File Offset: 0x000AA93C
		private unsafe void \u0010\u0005(UIDocument \u001F, Document \u000A, ref List<ViewManagerView> \u0007, List<long> \u001D, List<UIView> \u0004, ref ViewManagerView \u0019)
		{
			\u0011\u0008.\u0003\u0008 u0003_u = new \u0011\u0008.\u0003\u0008();
			u0003_u.\u001F = \u000A;
			u0003_u.\u000A = \u001D;
			if (\u001A\u0008\u0019.\u000A(u0003_u.\u000A, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u0004\u0013\u000A.\u0007(u0003_u.\u001F)))))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u0010\u0005(UIDocument, Document, List<ViewManagerView>*, List<long>, List<UIView>, ViewManagerView*)).MethodHandle;
				}
				UIView uiview = Enumerable.FirstOrDefault<UIView>(\u0004, new Func<UIView, bool>(u0003_u.\u0007));
				if (uiview != null)
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
					\u001D\u0010\u0007.\u0007(\u001F, \u0004\u0019\u000E.\u001F(\u0011\u0017\u000A.\u0007(u0003_u.\u001F, \u0008\u000E\u0007.\u000A(uiview))));
					return;
				}
				ViewManagerView viewManagerView = Enumerable.FirstOrDefault<ViewManagerView>(\u0002\u000B\u0016.\u000A(this), new Func<ViewManagerView, bool>(u0003_u.\u001D));
				if (viewManagerView != null)
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
					\u001D\u0010\u0007.\u0007(\u001F, \u0004\u0019\u000E.\u001F(\u0011\u0017\u000A.\u0007(u0003_u.\u001F, \u001E\u0001\u000A.\u000A(\u0017\u0016\u0016.\u000A(viewManagerView)))));
					return;
				}
				\u0019 = Enumerable.FirstOrDefault<ViewManagerView>(\u0007, new Func<ViewManagerView, bool>(u0003_u.\u0004));
				if (\u0019 != null)
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
					\u0001\u0016\u0016.\u0007(\u0019, UpdateStates.Updated);
					\u0007 = Enumerable.ToList<ViewManagerView>(Enumerable.Where<ViewManagerView>(\u0007, new Func<ViewManagerView, bool>(u0003_u.\u0019)));
					this.\u001F\u0016(\u0019, \u000B\u000B\u0016.\u000A(), ReportStates.Warning);
				}
			}
		}

		// Token: 0x06001A95 RID: 6805 RVA: 0x000AC898 File Offset: 0x000AAA98
		private void \u000E\u0005(List<ViewManagerView> \u001F, List<long> \u000A)
		{
			List<ViewManagerView>.Enumerator enumerator = \u001A\u0016\u0016.\u000A(\u000F\u000B\u0016.\u000A(this));
			try
			{
				while (\u0020\u0016\u0016.\u000A(ref enumerator))
				{
					ViewManagerView viewManagerView = \u0013\u0016\u0016.\u000A(ref enumerator);
					if (\u000A\u000B\u0016.\u0007(viewManagerView) != UpdateStates.Updated)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u000E\u0005(List<ViewManagerView>, List<long>)).MethodHandle;
						}
						\u0006\u000B\u0016.\u000A(\u001F, viewManagerView);
					}
					if (\u000A\u000B\u0016.\u0007(viewManagerView) == UpdateStates.ToTrash)
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
						if (\u0017\u0016\u0016.\u000A(viewManagerView) > 0L)
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
							\u0001\u000E\u0019.\u000A(\u000A, \u0017\u0016\u0016.\u000A(viewManagerView));
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

		// Token: 0x06001A96 RID: 6806 RVA: 0x000AC954 File Offset: 0x000AAB54
		private void \u0008\u0005(Document \u001F, SheetAndViewCreationHelper \u000A, ViewManagerView \u0007)
		{
			if (\u001F\u000B\u0016.\u0007(\u0007) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u0008\u0005(Document, SheetAndViewCreationHelper, ViewManagerView)).MethodHandle;
				}
				if (\u0012\u000B\u0016.\u0007(\u0007))
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
					this.\u0013\u0005(\u001F, \u0007);
				}
				else
				{
					this.\u0014\u0005(\u001F, \u000A, \u0007);
				}
				\u0001\u0016\u0016.\u0007(\u0007, UpdateStates.Updated);
			}
		}

		// Token: 0x06001A97 RID: 6807 RVA: 0x000AC9AC File Offset: 0x000AABAC
		private unsafe void \u001B\u0005(Document \u001F, ref TransactionStatus \u000A, ref Transaction \u0007, ref \u0008\u0008\u000A \u001D)
		{
			try
			{
				Transaction transaction;
				\u0007 = (transaction = \u0013\u0001\u000A.\u000A(\u001F));
				Transaction transaction2 = transaction;
				try
				{
					string u000A;
					this.\u0017\u0005(\u0007, out \u001D, out u000A);
					\u0017\u0001\u000A.\u000A(\u0007, u000A);
					IEnumerator<ProjectInformationParameterModel> enumerator = \u0008\u000B\u0016.\u000A(Enumerable.OfType<ProjectInformationParameterModel>(\u0018\u000B\u0016.\u000A(this)));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							ProjectInformationParameterModel u001F = \u000E\u000B\u0016.\u000A(enumerator);
							Parameter parameter = u001F.\u000A(\u001C\u0007\u001D.\u000A());
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
									RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u001B\u0005(Document, TransactionStatus*, Transaction*, \u0008\u0008\u000A*)).MethodHandle;
								}
								if (\u001D\u0005\u0016.\u0007(\u0004\u0005\u0016.\u0007(u001F)))
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
									\u0006\u0018\u0007.\u000A(parameter, \u001B\u000B\u0016.\u000A(\u0012\u0003\u000E.\u001F(\u0009\u0018\u0016.\u0007(u001F))));
									\u001F\u0005\u0016.\u0007(u001F, \u000A\u0005\u0016.\u0007(\u0007\u0005\u0016.\u000A()).\u001F((long)\u001B\u000B\u0016.\u000A(\u0012\u0003\u000E.\u001F(\u0009\u0018\u0016.\u0007(u001F)))));
								}
								else
								{
									this.\u0011\u0005(u001F, parameter);
								}
								\u001C\u000B\u0016.\u000A(u001F, UpdateStates.Updated);
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
								switch (4)
								{
								case 0:
									continue;
								}
								break;
							}
							\u001F\u0017\u000A.\u000A(enumerator);
						}
					}
					\u000A = \u001B\u0001\u000A.\u000A(\u0007);
				}
				finally
				{
					if (transaction2 != null)
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
						\u001F\u0017\u000A.\u000A(transaction2);
					}
				}
			}
			catch (Exception u001F2)
			{
				IEnumerator<ProjectInformationParameterModel> enumerator = \u0008\u000B\u0016.\u000A(Enumerable.OfType<ProjectInformationParameterModel>(\u0018\u000B\u0016.\u000A(this)));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						\u001C\u000B\u0016.\u000A(\u000E\u000B\u0016.\u000A(enumerator), UpdateStates.Modified);
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
				this.\u001E\u0005(\u0003\u001A\u000A.\u000A(u001F2));
			}
			finally
			{
				\u001F\u0004\u0016.\u0007(\u000A\u0004\u0016.\u0007(\u001D));
				if (\u000A != 5)
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
					if (\u000A != 2)
					{
						goto IL_241;
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
				List<ParameterModel>.Enumerator enumerator2 = \u0010\u000B\u0016.\u000A(\u0018\u000B\u0016.\u000A(this));
				try
				{
					while (\u0003\u000B\u0016.\u000A(ref enumerator2))
					{
						\u001C\u000B\u0016.\u000A(\u000D\u0003\u000E.\u001F(\u000D\u000B\u0016.\u000A(ref enumerator2)), UpdateStates.Modified);
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
				this.\u001E\u0005(\u0009\u001D\u0016.\u000A(\u001D));
				IL_241:;
			}
		}

		// Token: 0x06001A98 RID: 6808 RVA: 0x000ACC90 File Offset: 0x000AAE90
		private void \u0011\u0005(ProjectInformationParameterModel \u001F, Parameter \u000A)
		{
			try
			{
				this.\u0020\u0005(\u001F, \u000A);
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\ManageViewsEvent.cs", "ParameterModification");
			}
		}

		// Token: 0x06001A99 RID: 6809 RVA: 0x000ACCD4 File Offset: 0x000AAED4
		private void \u001E\u0005(string \u001F)
		{
			object u0002_u = this.\u0002\u0007;
			FailedViewReport failedViewReport = \u0014\u000B\u0016.\u000A();
			\u0017\u000B\u0016.\u000A(failedViewReport, "Project Informations Parameters");
			\u0020\u000B\u0016.\u000A(failedViewReport, "N/A");
			\u001E\u000B\u0016.\u000A(failedViewReport, \u001F);
			\u0020\u0014\u0007.\u000A(failedViewReport, ReportStates.Error);
			\u0011\u000B\u0016.\u000A(u0002_u, failedViewReport);
		}

		// Token: 0x06001A9A RID: 6810 RVA: 0x000ACD18 File Offset: 0x000AAF18
		private void \u0020\u0005(ParameterModel \u001F, Parameter \u000A)
		{
			switch (\u0011\u001F\u001D.\u0007(\u000A))
			{
			case 1:
			{
				double u000A = (double)\u000D\u000B\u001D.\u000A(\u001A\u000B\u0016.\u0007(\u0009\u0018\u0016.\u0007(\u001F)));
				\u0002\u0018\u0007.\u000A(\u000A, u000A);
				return;
			}
			case 2:
			{
				double u000A2 = \u0013\u000B\u0016.\u000A(\u000A, \u001A\u000B\u0016.\u0007(\u0009\u0018\u0016.\u0007(\u001F)), \u0011\u0015\u0005.\u000A(), false);
				\u0002\u0018\u0007.\u000A(\u000A, u000A2);
				return;
			}
			case 3:
			{
				string u000A3 = \u001A\u000B\u0016.\u0007(\u0009\u0018\u0016.\u0007(\u001F));
				\u0016\u0018\u001D.\u0007(\u000A, u000A3);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x06001A9B RID: 6811 RVA: 0x000ACDAC File Offset: 0x000AAFAC
		private unsafe void \u0017\u0005(Transaction \u001F, out \u0008\u0008\u000A \u000A, out string \u0007)
		{
			FailureHandlingOptions failureHandlingOptions = \u0006\u0014\u0007.\u000A(\u001F);
			\u0007 = "ViewManager_ApplyProjectInformationModifications";
			\u0008\u0008\u000A u0008_u0008_u000A = new \u0008\u0008\u000A();
			\u0001\u000B\u0016.\u000A(u0008_u0008_u000A, \u0007);
			IntPtr u000B_u = this.\u000B\u0007;
			WindowInterceptor.ProcessWindow u000A;
			if ((u000A = \u0011\u0008.\u0006\u0008.\u001F) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u0017\u0005(Transaction, \u0008\u0008\u000A*, string*)).MethodHandle;
				}
				u000A = (\u0011\u0008.\u0006\u0008.\u001F = new WindowInterceptor.ProcessWindow(\u0011\u0008.\u000D\u0005));
			}
			\u000C\u000B\u0016.\u000A(u0008_u0008_u000A, \u0015\u000B\u0016.\u000A(u000B_u, u000A));
			\u000A = u0008_u0008_u000A;
			\u0002\u0014\u0007.\u000A(failureHandlingOptions, \u000A);
			\u000B\u0014\u0007.\u000A(\u001F, failureHandlingOptions);
		}

		// Token: 0x06001A9C RID: 6812 RVA: 0x000ACE2C File Offset: 0x000AB02C
		private void \u0014\u0005(Document \u001F, SheetAndViewCreationHelper \u000A, ViewManagerView \u0007)
		{
			ElementId elementId = \u000A\u0002\u0016.\u000A(\u000A, \u001F, \u001F\u000B\u0016.\u0007(\u0007), \u0007\u000B\u0016.\u000A(\u0007), \u0007\u0002\u0016.\u000A(\u0007));
			\u001F\u0002\u0016.\u0007(\u0007, \u000B\u001E\u000A.\u000A(elementId));
			\u0009\u000B\u0016.\u0007(\u0007, \u0005\u001F\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u001F, elementId)));
			if (\u001F\u000B\u0016.\u0007(\u0007) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u0014\u0005(Document, SheetAndViewCreationHelper, ViewManagerView)).MethodHandle;
				}
				this.\u0004\u0016(\u001F\u000B\u0016.\u0007(\u0007), \u0007);
				this.\u0007\u0016(\u001F\u000B\u0016.\u0007(\u0007));
			}
		}

		// Token: 0x06001A9D RID: 6813 RVA: 0x000ACEBC File Offset: 0x000AB0BC
		private void \u0013\u0005(Document \u001F, ViewManagerView \u000A)
		{
			View u000A = \u001F\u000B\u0016.\u0007(\u000A);
			ElementId elementId = Enumerable.First<ElementId>(\u001D\u0002\u0016.\u000A(\u001F, \u0002\u001E\u000A.\u0007(\u001F\u000B\u0016.\u0007(\u000A)), \u001B\u001F\u0007.\u000A(0.0, 0.0, 0.0)));
			\u001F\u0002\u0016.\u0007(\u000A, \u000B\u001E\u000A.\u000A(elementId));
			\u0009\u000B\u0016.\u0007(\u000A, \u0005\u001F\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u001F, elementId)));
			\u0011\u0013\u0007.\u000A(\u001F\u000B\u0016.\u0007(\u000A), \u0007\u000B\u0016.\u000A(\u000A));
			this.\u001A\u0005(\u000A, u000A);
		}

		// Token: 0x06001A9E RID: 6814 RVA: 0x000ACF54 File Offset: 0x000AB154
		private void \u001A\u0005(ViewManagerView \u001F, View \u000A)
		{
			bool flag = false;
			ElementId u000A = \u001E\u0001\u000A.\u000A(-1006965L);
			List<ElementId> list = Enumerable.ToList<ElementId>(\u0005\u0002\u0016.\u000A(\u000A));
			if (\u0014\u000E\u0007.\u000A(list, u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u001A\u0005(ViewManagerView, View)).MethodHandle;
				}
				\u0018\u0002\u0016.\u000A(list, u000A);
				flag = true;
			}
			\u0004\u0002\u0016.\u000A(\u000A, list);
			\u0019\u0002\u0016.\u000A(\u001F\u000B\u0016.\u0007(\u001F), \u000A);
			if (flag)
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
				\u0003\u0010\u0007.\u000A(list, u000A);
				\u0004\u0002\u0016.\u000A(\u000A, list);
			}
		}

		// Token: 0x06001A9F RID: 6815 RVA: 0x000ACFDC File Offset: 0x000AB1DC
		private void \u000C\u0005(Document \u001F, List<SheetInfo> \u000A, ViewManagerView \u0007)
		{
			\u0002\u0002\u0016.\u0007(this, true);
			\u0016\u0002\u0016.\u000A(\u0002\u000B\u0016.\u000A(this), \u0007);
			\u0016\u0002\u0016.\u000A(\u000B\u0002\u0016.\u000A(this), \u0007);
			if (\u0017\u0016\u0016.\u000A(\u0007) > 0L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u000C\u0005(Document, List<SheetInfo>, ViewManagerView)).MethodHandle;
				}
				if (\u001F\u000B\u0016.\u0007(\u0007) != null)
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
					if (\u0012\u000B\u0016.\u0007(\u0007))
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
						this.\u000A\u0016(\u001F, \u0007);
					}
				}
			}
			if (\u0017\u0016\u0016.\u000A(\u0007) > 0L)
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
				if (\u001F\u000B\u0016.\u0007(\u0007) != null)
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
					if (\u000C\u0020\u000A.\u0007(\u001F\u000B\u0016.\u0007(\u0007)))
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
						this.\u0015\u0005(\u001F, \u000A, \u0007);
					}
				}
			}
		}

		// Token: 0x06001AA0 RID: 6816 RVA: 0x000AD0B0 File Offset: 0x000AB2B0
		private void \u0015\u0005(Document \u001F, List<SheetInfo> \u000A, ViewManagerView \u0007)
		{
			\u0011\u0008.\u001C\u0008 u001C_u = new \u0011\u0008.\u001C\u0008();
			u001C_u.\u001F = \u0007;
			ICollection<ElementId> collection = \u0011\u0001\u000A.\u000A(\u001F, \u0002\u001E\u000A.\u0007(\u001F\u000B\u0016.\u0007(u001C_u.\u001F)));
			if (\u000A\u0008\u0019.\u000A(collection) > 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u0015\u0005(Document, List<SheetInfo>, ViewManagerView)).MethodHandle;
				}
				IEnumerable<ElementId> enumerable = collection;
				Func<ElementId, bool> func;
				if ((func = u001C_u.\u000A) == null)
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
					func = (u001C_u.\u000A = new Func<ElementId, bool>(u001C_u.\u0007));
				}
				IEnumerator<ElementId> enumerator = \u000B\u0013\u0007.\u000A(Enumerable.Where<ElementId>(enumerable, func));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						ElementId u = \u0016\u0013\u0007.\u000A(enumerator);
						this.\u0001\u0005(\u000A, u001C_u.\u001F, u);
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
		}

		// Token: 0x06001AA1 RID: 6817 RVA: 0x000AD198 File Offset: 0x000AB398
		private void \u0001\u0005(List<SheetInfo> \u001F, ViewManagerView \u000A, ElementId \u0007)
		{
			\u0011\u0008.\u000D\u0008 u000D_u = new \u0011\u0008.\u000D\u0008();
			u000D_u.\u001F = \u0007;
			ViewManagerView viewManagerView = Enumerable.FirstOrDefault<ViewManagerView>(\u0002\u000B\u0016.\u000A(this), new Func<ViewManagerView, bool>(u000D_u.\u000A));
			if (viewManagerView != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u0001\u0005(List<SheetInfo>, ViewManagerView, ElementId)).MethodHandle;
				}
				\u0016\u0002\u0016.\u000A(\u0002\u000B\u0016.\u000A(this), viewManagerView);
				this.\u001F\u0016(viewManagerView, \u0006\u0002\u0016.\u000A(\u0007\u000B\u0016.\u000A(\u000A), \u000F\u0002\u0016.\u000A()), ReportStates.Warning);
				return;
			}
			this.\u0009\u0005(\u001F, \u000A, u000D_u.\u001F);
		}

		// Token: 0x06001AA2 RID: 6818 RVA: 0x000AD224 File Offset: 0x000AB424
		private void \u0009\u0005(List<SheetInfo> \u001F, ViewManagerView \u000A, ElementId \u0007)
		{
			\u0011\u0008.\u0010\u0008 u0010_u = new \u0011\u0008.\u0010\u0008();
			u0010_u.\u001F = \u0007;
			if (\u000C\u0016\u0016.\u000A(\u001C\u0003\u000E.\u001F(\u0015\u0016\u0016.\u000A(this))))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u0009\u0005(List<SheetInfo>, ViewManagerView, ElementId)).MethodHandle;
				}
				List<SheetInfo> list = \u0014\u0007\u0016.\u000A();
				IEnumerable<SheetInfo> enumerable;
				if (list == null)
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
					enumerable = null;
				}
				else
				{
					enumerable = Enumerable.Where<SheetInfo>(list, new Func<SheetInfo, bool>(u0010_u.\u0007));
				}
				IEnumerable<SheetInfo> enumerable2;
				if ((enumerable2 = enumerable) != null)
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
					IEnumerator<SheetInfo> enumerator = \u0016\u0004\u0016.\u000A(enumerable2);
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							SheetInfo u001F = \u0005\u0004\u0016.\u000A(enumerator);
							this.\u001F\u0016(\u000A, \u0006\u0002\u0016.\u000A(\u0002\u0013\u000A.\u000A(\u0011\u0007\u0016.\u0007(u001F), " - ", \u0019\u0004\u0016.\u0007(u001F)), \u0003\u0002\u0016.\u000A()), ReportStates.Warning);
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
					\u0012\u0002\u0016.\u000A(\u001F, enumerable2);
				}
			}
		}

		// Token: 0x06001AA3 RID: 6819 RVA: 0x000AD330 File Offset: 0x000AB530
		private void \u001F\u0016(ViewManagerView \u001F, string \u000A, ReportStates \u0007)
		{
			object u0002_u = this.\u0002\u0007;
			FailedViewReport failedViewReport = \u0014\u000B\u0016.\u000A();
			\u0017\u000B\u0016.\u000A(failedViewReport, \u0007\u000B\u0016.\u000A(\u001F));
			\u0020\u000B\u0016.\u000A(failedViewReport, \u001C\u0002\u0016.\u000A(\u001F));
			\u001E\u000B\u0016.\u000A(failedViewReport, \u000A);
			\u0020\u0014\u0007.\u000A(failedViewReport, \u0007);
			\u0011\u000B\u0016.\u000A(u0002_u, failedViewReport);
		}

		// Token: 0x06001AA4 RID: 6820 RVA: 0x000AD37C File Offset: 0x000AB57C
		private void \u000A\u0016(Document \u001F, ViewManagerView \u000A)
		{
			\u0011\u0008.\u000E\u0008 u000E_u = new \u0011\u0008.\u000E\u0008();
			u000E_u.\u001F = \u000A;
			ICollection<ElementId> collection = \u0011\u0001\u000A.\u000A(\u001F, \u0002\u001E\u000A.\u0007(\u001F\u000B\u0016.\u0007(u000E_u.\u001F)));
			if (\u000A\u0008\u0019.\u000A(collection) > 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u000A\u0016(Document, ViewManagerView)).MethodHandle;
				}
				IEnumerable<ElementId> enumerable = collection;
				Func<ElementId, bool> func;
				if ((func = u000E_u.\u000A) == null)
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
					func = (u000E_u.\u000A = new Func<ElementId, bool>(u000E_u.\u0007));
				}
				IEnumerator<ElementId> enumerator = \u000B\u0013\u0007.\u000A(Enumerable.Where<ElementId>(enumerable, func));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						\u0011\u0008.\u0008\u0008 u0008_u = new \u0011\u0008.\u0008\u0008();
						u0008_u.\u001F = \u0016\u0013\u0007.\u000A(enumerator);
						ViewManagerView viewManagerView = Enumerable.FirstOrDefault<ViewManagerView>(\u000B\u0002\u0016.\u000A(this), new Func<ViewManagerView, bool>(u0008_u.\u000A));
						if (viewManagerView != null)
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
							\u0016\u0002\u0016.\u000A(\u000B\u0002\u0016.\u000A(this), viewManagerView);
							this.\u001F\u0016(viewManagerView, "", ReportStates.Warning);
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
			}
		}

		// Token: 0x06001AA5 RID: 6821 RVA: 0x000AD4AC File Offset: 0x000AB6AC
		private void \u0007\u0016(View \u001F)
		{
			Collector u = Collector.\u0004;
			bool flag;
			if (u == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u0007\u0016(View)).MethodHandle;
				}
				flag = (null != null);
			}
			else
			{
				flag = (\u000E\u0002\u0016.\u001D(u) != null);
			}
			if (!flag)
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
			ViewData viewData = \u0014\u0002\u0016.\u000A();
			\u0017\u0002\u0016.\u000A(viewData, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F)));
			\u0020\u0002\u0016.\u0007(viewData, \u0005\u001E\u000A.\u000A(\u001F));
			\u001E\u0002\u0016.\u000A(viewData, \u001C\u001C\u0007.\u0007(\u001F));
			ViewData viewData2 = viewData;
			if (\u001B\u001B\u001D.\u000A(\u0011\u0002\u0016.\u000A(\u001F), \u0012\u0015\u0010.\u001F))
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
				Element element = \u0011\u0017\u000A.\u0007(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004), \u0011\u0002\u0016.\u000A(\u001F));
				if (element != null)
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
					\u001B\u0002\u0016.\u0007(viewData2, \u0005\u001E\u000A.\u000A(element));
				}
			}
			if (\u001C\u001C\u0007.\u0007(\u001F) == 5)
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
				if (!\u0008\u0002\u0016.\u000A(\u0001\u001D\u000E.\u001F(\u001F)))
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
					\u000D\u0002\u0016.\u000A(\u0010\u0002\u0016.\u000A(\u000E\u0002\u0016.\u0007(Collector.\u0004), \u001C\u001C\u0007.\u0007(\u001F)), viewData2);
					return;
				}
			}
			else
			{
				\u000D\u0002\u0016.\u000A(\u0010\u0002\u0016.\u000A(\u000E\u0002\u0016.\u0007(Collector.\u0004), \u001C\u001C\u0007.\u0007(\u001F)), viewData2);
			}
		}

		// Token: 0x06001AA6 RID: 6822 RVA: 0x000AD5F8 File Offset: 0x000AB7F8
		private void \u001D\u0016(ViewType \u001F, long \u000A)
		{
			\u0011\u0008.\u001B\u0008 u001B_u = new \u0011\u0008.\u001B\u0008();
			u001B_u.\u001F = \u000A;
			List<ViewData> list = \u0010\u0002\u0016.\u000A(\u000E\u0002\u0016.\u0007(Collector.\u0004), \u001F);
			if (list == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u001D\u0016(ViewType, long)).MethodHandle;
				}
				return;
			}
			\u0013\u0002\u0016.\u000A(list, new Predicate<ViewData>(u001B_u.\u000A));
		}

		// Token: 0x06001AA7 RID: 6823 RVA: 0x000AD654 File Offset: 0x000AB854
		private void \u0004\u0016(View \u001F, ViewManagerView \u000A)
		{
			string text = \u0007\u000B\u0016.\u000A(\u000A);
			string text2;
			if (!\u001A\u0006\u0007.\u000A(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u0004\u0016(View, ViewManagerView)).MethodHandle;
				}
				text2 = text;
			}
			else
			{
				text2 = \u0005\u001E\u000A.\u000A(\u001F);
			}
			text = text2;
			if (\u001D\u0017\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), text))
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
				\u0011\u0013\u0007.\u000A(\u001F, text);
			}
			\u0001\u0002\u0016.\u0007(\u000A, text);
			\u0015\u0002\u0016.\u0007(\u000A, text);
			List<Parameter> u = \u000C\u0002\u0016.\u000A(\u001F, false);
			IEnumerable<ParameterModel> enumerable = \u001A\u0002\u0016.\u0007(\u000A);
			Func<ParameterModel, bool> func;
			if ((func = \u0011\u0008.<>c.\u0007) == null)
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
				func = (\u0011\u0008.<>c.\u0007 = new Func<ParameterModel, bool>(\u0011\u0008.<>c.\u001F.\u0004));
			}
			IEnumerator<ParameterModel> enumerator = \u0018\u0005\u0016.\u000A(Enumerable.Where<ParameterModel>(enumerable, func));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ParameterModel u001D = \u0019\u0005\u0016.\u000A(enumerator);
					this.\u0019\u0016(\u001F, \u000A, u, u001D);
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
		}

		// Token: 0x06001AA8 RID: 6824 RVA: 0x000AD760 File Offset: 0x000AB960
		private void \u0019\u0016(View \u001F, ViewManagerView \u000A, List<Parameter> \u0007, ParameterModel \u001D)
		{
			if (\u0007\u0006\u0016.\u0007(\u001D))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u0019\u0016(View, ViewManagerView, List<Parameter>, ParameterModel)).MethodHandle;
				}
				\u0011\u0008.\u000B\u0016(\u001F, \u0007, \u001D);
				return;
			}
			if (\u000A\u0006\u0016.\u0007(\u0004\u0005\u0016.\u0007(\u001D)))
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
				if (\u001F\u0006\u0016.\u000A(\u000A))
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
					\u0011\u0008.\u0016\u0016(\u001F, \u001D);
					return;
				}
			}
			if (\u0009\u0002\u0016.\u0007(\u0004\u0005\u0016.\u0007(\u001D)))
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
				\u0011\u0008.\u0005\u0016(\u001F, \u0007, \u001D);
				return;
			}
			this.\u0018\u0016(\u001F, \u0007, \u001D);
		}

		// Token: 0x06001AA9 RID: 6825 RVA: 0x000AD800 File Offset: 0x000ABA00
		private void \u0018\u0016(View \u001F, List<Parameter> \u000A, ParameterModel \u0007)
		{
			try
			{
				Parameter parameter = \u0007.\u000A(\u000A);
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u0018\u0016(View, List<Parameter>, ParameterModel)).MethodHandle;
					}
					if (!\u0010\u0014\u0007.\u000A(parameter))
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
						this.\u0020\u0005(\u0007, parameter);
					}
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\ManageViewsEvent.cs", "SetDefaultParameter");
			}
		}

		// Token: 0x06001AAA RID: 6826 RVA: 0x000AD878 File Offset: 0x000ABA78
		private static void \u0005\u0016(View \u001F, List<Parameter> \u000A, ParameterModel \u0007)
		{
			Parameter parameter = \u0007.\u000A(\u000A);
			if (parameter != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u0005\u0016(View, List<Parameter>, ParameterModel)).MethodHandle;
				}
				if (!\u0010\u0014\u0007.\u000A(parameter))
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
					ParameterIdValue parameterIdValue = \u0003\u0003\u000E.\u001F(\u0009\u0018\u0016.\u0007(\u0007));
					if (parameterIdValue != null)
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
						if (\u001D\u0006\u0016.\u0007(parameterIdValue) > 0L)
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
							ElementId u000A = \u001E\u0001\u000A.\u000A(\u001D\u0006\u0016.\u0007(parameterIdValue));
							\u0019\u0018\u0007.\u000A(parameter, u000A);
							return;
						}
					}
					\u0019\u0018\u0007.\u000A(parameter, Constants.InvalidElementId);
				}
			}
		}

		// Token: 0x06001AAB RID: 6827 RVA: 0x000AD918 File Offset: 0x000ABB18
		private static void \u0016\u0016(View \u001F, ParameterModel \u000A)
		{
			long u001F = -1L;
			if (\u001D\u0006\u0016.\u0007(\u0003\u0003\u000E.\u001F(\u0009\u0018\u0016.\u0007(\u000A))) != 0L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u0016\u0016(View, ParameterModel)).MethodHandle;
				}
				u001F = \u001D\u0006\u0016.\u0007(\u0003\u0003\u000E.\u001F(\u0009\u0018\u0016.\u0007(\u000A)));
			}
			try
			{
				\u0004\u0006\u0016.\u000A(\u001F, \u001E\u0001\u000A.\u000A(u001F));
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\ManageViewsEvent.cs", "SetViewTemplateParameter");
			}
		}

		// Token: 0x06001AAC RID: 6828 RVA: 0x000AD9A8 File Offset: 0x000ABBA8
		private static void \u000B\u0016(View \u001F, List<Parameter> \u000A, ParameterModel \u0007)
		{
			Parameter parameter = \u0007.\u000A(\u000A);
			if (parameter != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u000B\u0016(View, List<Parameter>, ParameterModel)).MethodHandle;
				}
				if (!\u0010\u0014\u0007.\u000A(parameter))
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
					if (\u0011\u001F\u001D.\u0007(parameter) != 4)
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
						\u0006\u0018\u0007.\u000A(parameter, \u001B\u000B\u0016.\u000A(\u0012\u0003\u000E.\u001F(\u0009\u0018\u0016.\u0007(\u0007))));
						return;
					}
					ParameterIdValue parameterIdValue = \u0003\u0003\u000E.\u001F(\u0009\u0018\u0016.\u0007(\u0007));
					if (parameterIdValue != null)
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
						long num = \u001D\u0006\u0016.\u0007(parameterIdValue);
						if (num == 0L)
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
							num = -1L;
						}
						\u0019\u0018\u0007.\u000A(parameter, \u001E\u0001\u000A.\u000A(num));
					}
				}
			}
		}

		// Token: 0x06001AAD RID: 6829 RVA: 0x000ADA6C File Offset: 0x000ABC6C
		[CompilerGenerated]
		private unsafe void \u0002\u0016(ViewManagerView \u001F, ref \u0011\u0008.\u000F\u0008 \u000A)
		{
			int u000A = \u000A.\u001F * 100 / \u000A.\u000A;
			if (\u000A.\u0007 == \u000A.\u001D)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u0002\u0016(ViewManagerView, \u0011\u0008.\u000F\u0008*)).MethodHandle;
				}
				ManageViewsProgressHandler u0006_u = this.\u0006\u0007;
				if (u0006_u == null)
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
					\u0019\u0006\u0016.\u000A(u0006_u, u000A, \u0007\u000B\u0016.\u000A(\u001F), \u000A\u000B\u0016.\u0007(\u001F));
				}
			}
			int num = \u000A.\u001F;
			\u000A.\u001F = num + 1;
			if (\u000A.\u0007 < \u000A.\u001D)
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
				num = \u000A.\u0007;
				\u000A.\u0007 = num + 1;
				return;
			}
			\u000A.\u0007 = 0;
		}

		// Token: 0x04000A92 RID: 2706
		private readonly IntPtr \u000B\u0007;

		// Token: 0x04000A93 RID: 2707
		private readonly ObservableCollection<Report> \u0002\u0007;

		// Token: 0x04000A96 RID: 2710
		[CompilerGenerated]
		private List<ViewManagerView> \u0012\u0007;

		// Token: 0x04000A97 RID: 2711
		[CompilerGenerated]
		private ObservableCollection<ViewManagerView> \u0003\u0007;

		// Token: 0x04000A98 RID: 2712
		[CompilerGenerated]
		private ObservableCollection<ViewManagerView> \u001C\u0007;

		// Token: 0x04000A99 RID: 2713
		[CompilerGenerated]
		private bool \u001E\u000A;

		// Token: 0x04000A9A RID: 2714
		[CompilerGenerated]
		private static bool \u000D\u0007;

		// Token: 0x04000A9B RID: 2715
		[CompilerGenerated]
		private static string \u0010\u0007;

		// Token: 0x04000A9C RID: 2716
		[CompilerGenerated]
		private List<ParameterModel> \u0011\u000A;

		// Token: 0x04000A9D RID: 2717
		[CompilerGenerated]
		private Window \u000E\u0007;

		// Token: 0x0200096B RID: 2411
		[CompilerGenerated]
		private static class \u0006\u0008
		{
			// Token: 0x040024A4 RID: 9380
			public static WindowInterceptor.ProcessWindow \u001F;
		}

		// Token: 0x0200096D RID: 2413
		[CompilerGenerated]
		[StructLayout(LayoutKind.Auto)]
		private struct \u000F\u0008
		{
			// Token: 0x040024A8 RID: 9384
			public int \u001F;

			// Token: 0x040024A9 RID: 9385
			public int \u000A;

			// Token: 0x040024AA RID: 9386
			public int \u0007;

			// Token: 0x040024AB RID: 9387
			public int \u001D;

			// Token: 0x040024AC RID: 9388
			public \u0011\u0008 \u0004;
		}

		// Token: 0x0200096E RID: 2414
		[CompilerGenerated]
		private sealed class \u0012\u0008
		{
			// Token: 0x060052D0 RID: 21200 RVA: 0x001EB3A4 File Offset: 0x001E95A4
			internal bool \u000A(SheetInfo \u001F)
			{
				return \u001E\u0002\u0010.\u000A(this.\u001F, \u001F);
			}

			// Token: 0x040024AD RID: 9389
			public List<SheetInfo> \u001F;
		}

		// Token: 0x0200096F RID: 2415
		[CompilerGenerated]
		private sealed class \u0003\u0008
		{
			// Token: 0x060052D2 RID: 21202 RVA: 0x001EB3D4 File Offset: 0x001E95D4
			internal bool \u0007(UIView \u001F)
			{
				if (\u001B\u001B\u001D.\u000A(\u0008\u000E\u0007.\u000A(\u001F), \u0002\u001E\u000A.\u0007(\u0004\u0013\u000A.\u0007(this.\u001F))))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u0003\u0008.\u0007(UIView)).MethodHandle;
					}
					return !\u001A\u0008\u0019.\u000A(this.\u000A, \u000B\u001E\u000A.\u000A(\u0008\u000E\u0007.\u000A(\u001F)));
				}
				return false;
			}

			// Token: 0x060052D3 RID: 21203 RVA: 0x001EB43C File Offset: 0x001E963C
			internal bool \u001D(ViewManagerView \u001F)
			{
				if (\u000A\u000B\u0016.\u0007(\u001F) != UpdateStates.ToTrash)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u0003\u0008.\u001D(ViewManagerView)).MethodHandle;
					}
					if (\u000A\u000B\u0016.\u0007(\u001F) != UpdateStates.ToDuplicate)
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
						return !\u001A\u0008\u0019.\u000A(this.\u000A, \u0017\u0016\u0016.\u000A(\u001F));
					}
				}
				return false;
			}

			// Token: 0x060052D4 RID: 21204 RVA: 0x001EB498 File Offset: 0x001E9698
			internal bool \u0004(ViewManagerView \u001F)
			{
				return \u0017\u0016\u0016.\u000A(\u001F) == \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u0004\u0013\u000A.\u0007(this.\u001F)));
			}

			// Token: 0x060052D5 RID: 21205 RVA: 0x001EB4CC File Offset: 0x001E96CC
			internal bool \u0019(ViewManagerView \u001F)
			{
				return \u0017\u0016\u0016.\u000A(\u001F) != \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u0004\u0013\u000A.\u0007(this.\u001F)));
			}

			// Token: 0x040024AE RID: 9390
			public Document \u001F;

			// Token: 0x040024AF RID: 9391
			public List<long> \u000A;
		}

		// Token: 0x02000970 RID: 2416
		[CompilerGenerated]
		private sealed class \u001C\u0008
		{
			// Token: 0x060052D7 RID: 21207 RVA: 0x001EB518 File Offset: 0x001E9718
			internal bool \u0007(ElementId \u001F)
			{
				return \u000B\u001E\u000A.\u000A(\u001F) != \u0017\u0016\u0016.\u000A(this.\u001F);
			}

			// Token: 0x040024B0 RID: 9392
			public ViewManagerView \u001F;

			// Token: 0x040024B1 RID: 9393
			public Func<ElementId, bool> \u000A;
		}

		// Token: 0x02000971 RID: 2417
		[CompilerGenerated]
		private sealed class \u000D\u0008
		{
			// Token: 0x060052D9 RID: 21209 RVA: 0x001EB554 File Offset: 0x001E9754
			internal bool \u000A(ViewManagerView \u001F)
			{
				return \u0017\u0016\u0016.\u000A(\u001F) == \u000B\u001E\u000A.\u000A(this.\u001F);
			}

			// Token: 0x040024B2 RID: 9394
			public ElementId \u001F;
		}

		// Token: 0x02000972 RID: 2418
		[CompilerGenerated]
		private sealed class \u0010\u0008
		{
			// Token: 0x060052DB RID: 21211 RVA: 0x001EB58C File Offset: 0x001E978C
			internal bool \u0007(SheetInfo \u001F)
			{
				IEnumerable<ViewInfo> enumerable = \u001B\u001D\u0016.\u0007(\u001F);
				Func<ViewInfo, bool> func;
				if ((func = this.\u000A) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0008.\u0010\u0008.\u0007(SheetInfo)).MethodHandle;
					}
					func = (this.\u000A = new Func<ViewInfo, bool>(this.\u001D));
				}
				return Enumerable.Any<ViewInfo>(enumerable, func);
			}

			// Token: 0x060052DC RID: 21212 RVA: 0x001EB5DC File Offset: 0x001E97DC
			internal bool \u001D(ViewInfo \u001F)
			{
				return \u000D\u001D\u0016.\u000A(\u001F) == \u000B\u001E\u000A.\u000A(this.\u001F);
			}

			// Token: 0x040024B3 RID: 9395
			public ElementId \u001F;

			// Token: 0x040024B4 RID: 9396
			public Func<ViewInfo, bool> \u000A;
		}

		// Token: 0x02000973 RID: 2419
		[CompilerGenerated]
		private sealed class \u000E\u0008
		{
			// Token: 0x060052DE RID: 21214 RVA: 0x001EB614 File Offset: 0x001E9814
			internal bool \u0007(ElementId \u001F)
			{
				return \u000B\u001E\u000A.\u000A(\u001F) != \u0017\u0016\u0016.\u000A(this.\u001F);
			}

			// Token: 0x040024B5 RID: 9397
			public ViewManagerView \u001F;

			// Token: 0x040024B6 RID: 9398
			public Func<ElementId, bool> \u000A;
		}

		// Token: 0x02000974 RID: 2420
		[CompilerGenerated]
		private sealed class \u0008\u0008
		{
			// Token: 0x060052E0 RID: 21216 RVA: 0x001EB650 File Offset: 0x001E9850
			internal bool \u000A(ViewManagerView \u001F)
			{
				return \u0017\u0016\u0016.\u000A(\u001F) == \u000B\u001E\u000A.\u000A(this.\u001F);
			}

			// Token: 0x040024B7 RID: 9399
			public ElementId \u001F;
		}

		// Token: 0x02000975 RID: 2421
		[CompilerGenerated]
		private sealed class \u001B\u0008
		{
			// Token: 0x060052E2 RID: 21218 RVA: 0x001EB688 File Offset: 0x001E9888
			internal bool \u000A(ViewData \u001F)
			{
				return \u000B\u0019\u0016.\u0007(\u001F) == this.\u001F;
			}

			// Token: 0x040024B8 RID: 9400
			public long \u001F;
		}
	}
}
