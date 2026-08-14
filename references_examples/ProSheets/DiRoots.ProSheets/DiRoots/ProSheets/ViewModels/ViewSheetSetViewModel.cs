using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.ViewModels;
using ProSheets.Extensions;
using ProSheets.Helper;
using ProSheets.Helpers;
using ProSheets.Models;
using ProSheets.RVTExternalEventHandler;
using ProSheets.UI;
using ProSheets.UI.CommonData;

namespace DiRoots.ProSheets.ViewModels
{
	// Token: 0x02000032 RID: 50
	public class ViewSheetSetViewModel : ViewModelBase
	{
		// Token: 0x06000237 RID: 567 RVA: 0x0000C2E4 File Offset: 0x0000A4E4
		public ViewSheetSetViewModel(Document document)
		{
			this.\u000A\u0014 = document;
			\u0003\u0014\u0014.\u0018(this, this.\u0008\u001C());
			\u0018\u0014\u0014.\u0018(this, Enumerable.FirstOrDefault<BatchAction>(\u0014\u0014\u0014.\u0018(this)));
			this.\u0006\u001C();
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000238 RID: 568 RVA: 0x0000C328 File Offset: 0x0000A528
		// (set) Token: 0x06000239 RID: 569 RVA: 0x0000C33C File Offset: 0x0000A53C
		private CreateViewSheetSetEvent createSheetSetEvent { get; set; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600023A RID: 570 RVA: 0x0000C350 File Offset: 0x0000A550
		// (set) Token: 0x0600023B RID: 571 RVA: 0x0000C364 File Offset: 0x0000A564
		private AddToViewSheetSetEvent addExistsViewSheetEvent { get; set; }

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x0600023C RID: 572 RVA: 0x0000C378 File Offset: 0x0000A578
		// (remove) Token: 0x0600023D RID: 573 RVA: 0x0000C3C4 File Offset: 0x0000A5C4
		public event ViewSheetSetViewModel.CheckedChangedDelegate CheckedChangedEvent
		{
			[CompilerGenerated]
			add
			{
				ViewSheetSetViewModel.CheckedChangedDelegate checkedChangedDelegate = this.\u0004\u0014;
				ViewSheetSetViewModel.CheckedChangedDelegate checkedChangedDelegate2;
				do
				{
					checkedChangedDelegate2 = checkedChangedDelegate;
					ViewSheetSetViewModel.CheckedChangedDelegate value2 = (ViewSheetSetViewModel.CheckedChangedDelegate)\u001C\u0019\u0018.\u0018(checkedChangedDelegate2, value);
					checkedChangedDelegate = Interlocked.CompareExchange<ViewSheetSetViewModel.CheckedChangedDelegate>(ref this.\u0004\u0014, value2, checkedChangedDelegate2);
				}
				while (checkedChangedDelegate != checkedChangedDelegate2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewSheetSetViewModel.add_CheckedChangedEvent(ViewSheetSetViewModel.CheckedChangedDelegate)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ViewSheetSetViewModel.CheckedChangedDelegate checkedChangedDelegate = this.\u0004\u0014;
				ViewSheetSetViewModel.CheckedChangedDelegate checkedChangedDelegate2;
				do
				{
					checkedChangedDelegate2 = checkedChangedDelegate;
					ViewSheetSetViewModel.CheckedChangedDelegate value2 = (ViewSheetSetViewModel.CheckedChangedDelegate)\u0013\u0019\u0018.\u0018(checkedChangedDelegate2, value);
					checkedChangedDelegate = Interlocked.CompareExchange<ViewSheetSetViewModel.CheckedChangedDelegate>(ref this.\u0004\u0014, value2, checkedChangedDelegate2);
				}
				while (checkedChangedDelegate != checkedChangedDelegate2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewSheetSetViewModel.remove_CheckedChangedEvent(ViewSheetSetViewModel.CheckedChangedDelegate)).MethodHandle;
				}
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600023E RID: 574 RVA: 0x0000C410 File Offset: 0x0000A610
		// (set) Token: 0x0600023F RID: 575 RVA: 0x0000C424 File Offset: 0x0000A624
		public ObservableCollection<ViewSheetSetInfo> Sets
		{
			get
			{
				return this.\u001F\u0014;
			}
			set
			{
				this.\u001F\u0014 = value;
				\u0011\u0010\u0018.\u0018(this, "Sets");
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000240 RID: 576 RVA: 0x0000C444 File Offset: 0x0000A644
		// (set) Token: 0x06000241 RID: 577 RVA: 0x0000C458 File Offset: 0x0000A658
		public List<BatchAction> SaveSetOptions { get; set; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000242 RID: 578 RVA: 0x0000C46C File Offset: 0x0000A66C
		// (set) Token: 0x06000243 RID: 579 RVA: 0x0000C480 File Offset: 0x0000A680
		public BatchAction SelectedSetOption
		{
			get
			{
				return this.\u0011\u0014;
			}
			set
			{
				this.\u0011\u0014 = value;
				this.OnPropertyChanged<BatchAction>(new Func<BatchAction>(this.\u000C\u0013), "SelectedSetOption");
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000244 RID: 580 RVA: 0x0000C4AC File Offset: 0x0000A6AC
		// (set) Token: 0x06000245 RID: 581 RVA: 0x0000C4C0 File Offset: 0x0000A6C0
		public int SelectedSetActionIndex
		{
			get
			{
				return this.\u0015\u0014;
			}
			set
			{
				this.\u0015\u0014 = value;
				this.OnPropertyChanged<int>(new Func<int>(this.\u0018\u0013), "SelectedSetActionIndex");
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000246 RID: 582 RVA: 0x0000C4EC File Offset: 0x0000A6EC
		// (set) Token: 0x06000247 RID: 583 RVA: 0x0000C500 File Offset: 0x0000A700
		public int SelectedSetIndex
		{
			get
			{
				return this.\u0017\u0014;
			}
			set
			{
				this.\u0017\u0014 = value;
				this.OnPropertyChanged<int>(new Func<int>(this.\u0014\u0013), "SelectedSetIndex");
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000248 RID: 584 RVA: 0x0000C52C File Offset: 0x0000A72C
		// (set) Token: 0x06000249 RID: 585 RVA: 0x0000C540 File Offset: 0x0000A740
		public List<ISetViewInfo> Víews { get; set; }

		// Token: 0x0600024A RID: 586 RVA: 0x0000C554 File Offset: 0x0000A754
		private void \u0006\u001C()
		{
			\u0016\u0014\u0014.\u0018(this, this.\u0001\u001C());
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000C570 File Offset: 0x0000A770
		private List<BatchAction> \u0008\u001C()
		{
			List<BatchAction> list = \u0009\u0014\u0014.\u0018();
			BatchAction batchAction = \u001C\u0014\u0014.\u0018();
			\u0012\u0019\u0018.\u0018(batchAction, \u000D\u0009\u0018.\u0020\u0018);
			\u000F\u0019\u0018.\u0018(batchAction, 0);
			\u0013\u0014\u0014.\u0018(batchAction, true);
			\u000F\u0014\u0014.\u0018(list, batchAction);
			BatchAction batchAction2 = \u001C\u0014\u0014.\u0018();
			\u0012\u0019\u0018.\u0018(batchAction2, \u000D\u0009\u0018.\u001F\u0018);
			\u000F\u0019\u0018.\u0018(batchAction2, 0);
			\u000D\u0014\u0014.\u0018(batchAction2, 0.7);
			\u000F\u0014\u0014.\u0018(list, batchAction2);
			BatchAction batchAction3 = \u001C\u0014\u0014.\u0018();
			\u0012\u0019\u0018.\u0018(batchAction3, \u000D\u0009\u0018.\u0011\u0018);
			\u000F\u0019\u0018.\u0018(batchAction3, 0);
			\u000D\u0014\u0014.\u0018(batchAction3, 0.7);
			\u000F\u0014\u0014.\u0018(list, batchAction3);
			BatchAction batchAction4 = \u001C\u0014\u0014.\u0018();
			\u0012\u0019\u0018.\u0018(batchAction4, \u000D\u0009\u0018.\u0020\u0003);
			\u000F\u0019\u0018.\u0018(batchAction4, 0);
			\u000D\u0014\u0014.\u0018(batchAction4, 0.7);
			\u0012\u0014\u0014.\u0018(batchAction4, false);
			\u000F\u0014\u0014.\u0018(list, batchAction4);
			return list;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0000C644 File Offset: 0x0000A844
		private ObservableCollection<ViewSheetSetInfo> \u0001\u001C()
		{
			IEnumerable<ViewSheetSet> enumerable = \u000F\u000A\u0018.\u0016\u0018<ViewSheetSet>(this.\u000A\u0014);
			Func<ViewSheetSet, ViewSheetSetInfo> func;
			if ((func = ViewSheetSetViewModel.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewSheetSetViewModel.\u0001\u001C()).MethodHandle;
				}
				func = (ViewSheetSetViewModel.<>c.\u0018 = new Func<ViewSheetSet, ViewSheetSetInfo>(ViewSheetSetViewModel.<>c.\u000C.\u001C));
			}
			List<ViewSheetSetInfo> u000C = Enumerable.ToList<ViewSheetSetInfo>(Enumerable.Select<ViewSheetSet, ViewSheetSetInfo>(enumerable, func));
			ViewSheetSetInfo viewSheetSetInfo = \u0011\u0014\u0014.\u0018(\u000D\u0009\u0018.\u0013\u0018, \u0012\u001D\u000F.\u000C);
			\u001F\u0014\u0014.\u0018(viewSheetSetInfo, false);
			\u0020\u0014\u0014.\u0018(u000C, 0, viewSheetSetInfo);
			return \u000A\u0014\u0014.\u0018(u000C);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000C6C8 File Offset: 0x0000A8C8
		[BindableMethod("SaveSet")]
		public void SaveSet()
		{
			if (\u000C\u0016\u0014.\u0018(this) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewSheetSetViewModel.SaveSet()).MethodHandle;
				}
				BatchAction batchAction = \u0014\u0003\u0014.\u0018(this);
				bool flag;
				if (batchAction == null)
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
					flag = false;
				}
				else
				{
					flag = \u000E\u0003\u0014.\u0018(batchAction);
				}
				if (!flag)
				{
					try
					{
						if (this.\u0020\u0014 == null)
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
							try
							{
								this.\u0020\u0014 = \u0005\u0003\u0014.\u0018(this.\u000A\u0014);
							}
							catch (Exception)
							{
								\u001B\u0003\u0014.\u0018(\u001C\u0009\u0018.\u0018\u0016, \u0001\u000C\u0014.\u0018(this), 400.0);
								return;
							}
						}
						IEnumerable<ISetViewInfo> enumerable = \u000B\u000E\u0018.\u0003(this);
						Func<ISetViewInfo, bool> func;
						if ((func = ViewSheetSetViewModel.<>c.\u0014) == null)
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
							func = (ViewSheetSetViewModel.<>c.\u0014 = new Func<ISetViewInfo, bool>(ViewSheetSetViewModel.<>c.\u000C.\u0013));
						}
						List<ISetViewInfo> list = Enumerable.ToList<ISetViewInfo>(Enumerable.Where<ISetViewInfo>(enumerable, func));
						if (!Enumerable.Any<ISetViewInfo>(list))
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
							\u0017\u0014\u0014.\u0018(\u001C\u0009\u0018.\u000E, \u0001\u000C\u0014.\u0018(this));
						}
						else
						{
							if (\u000F\u0002\u0018.\u0018(\u000F\u0007\u0018.\u0018(\u0014\u0003\u0014.\u0018(this)), \u000D\u0009\u0018.\u001F\u0018))
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
								ViewSheetSetViewModel.\u0003\u0009\u0018 u0003_u0009_u = new ViewSheetSetViewModel.\u0003\u0009\u0018();
								u0003_u0009_u.\u000C = \u0001\u0003\u0014.\u0018();
								\u001B\u0007\u0018.\u0018(u0003_u0009_u.\u000C, \u0001\u000C\u0014.\u0018(this));
								\u0008\u0003\u0014.\u0018(u0003_u0009_u.\u000C, \u0001\u0014\u0014.\u0014(this));
								\u0002\u0014\u0014.\u0014(u0003_u0009_u.\u000C, WindowStartupLocation.CenterOwner);
								\u001E\u0007\u0018.\u0014(u0003_u0009_u.\u000C);
								if (\u0003\u0003\u0014.\u0018(u0003_u0009_u.\u000C))
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
									if (!\u001F\u001A\u0018.\u0018(\u0020\u0003\u0014.\u0014(u0003_u0009_u.\u000C)))
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
										ViewSheetSet viewSheetSet = Enumerable.FirstOrDefault<ViewSheetSet>(\u000F\u000A\u0018.\u0016\u0018<ViewSheetSet>(this.\u000A\u0014), new Func<ViewSheetSet, bool>(u0003_u0009_u.\u0018));
										if (viewSheetSet != null)
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
											this.\u0005\u001C(list, viewSheetSet, true);
											goto IL_6E9;
										}
										bool u = false;
										ViewSet viewSet = \u0006\u0003\u0014.\u0018();
										List<ISetViewInfo>.Enumerator enumerator = \u0010\u0003\u0014.\u0018(list);
										try
										{
											while (\u001D\u0003\u0014.\u0018(ref enumerator))
											{
												ISetViewInfo u000C = \u0007\u0003\u0014.\u0018(ref enumerator);
												View view = \u0018\u0002\u000F.\u000C(\u0003\u0004\u0018.\u0018(this.\u000A\u0014, \u0019\u0003\u0014.\u0018(u000C)));
												if (view != null)
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
													\u000B\u0003\u0014.\u0018(viewSet, view);
													if (\u001A\u0003\u0014.\u0018(view) != 5)
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
														if (\u001A\u0003\u0014.\u0018(view) != 122)
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
															if (\u001A\u0003\u0014.\u0018(view) != 123)
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
													u = true;
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
										\u0004\u0003\u0014.\u0018(this.\u0020\u0014, 2);
										ViewSheetSetting viewSheetSetting = \u0002\u0003\u0014.\u0018(this.\u0020\u0014);
										\u0017\u0003\u0014.\u0018(viewSheetSetting, \u001E\u0003\u0014.\u0018(viewSheetSetting));
										\u0011\u0003\u0014.\u0018(\u0015\u0003\u0014.\u0018(viewSheetSetting), viewSet);
										if (\u0003\u0003\u0014.\u0018(u0003_u0009_u.\u000C))
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
											CreateViewSheetSetEvent createViewSheetSetEvent = \u001F\u0003\u0014.\u0018();
											\u000A\u0003\u0014.\u0018(createViewSheetSetEvent, \u0020\u0003\u0014.\u0014(u0003_u0009_u.\u000C));
											\u0009\u0003\u0014.\u0018(createViewSheetSetEvent, \u0001\u000C\u0014.\u0018(this));
											\u0013\u0003\u0014.\u0018(createViewSheetSetEvent, u);
											\u001C\u0003\u0014.\u0018(createViewSheetSetEvent, viewSheetSetting);
											\u000D\u0003\u0014.\u0018(createViewSheetSetEvent, this.\u0020\u0014);
											\u0012\u0003\u0014.\u0018(this, createViewSheetSetEvent);
											\u000F\u0003\u0014.\u0018(\u0016\u0003\u0014.\u0018(this), new CreateViewSheetSetEvent.TaskFinishedHandler(this.\u001B\u001C));
											\u0019\u0014\u0014.\u0018(\u0007\u0014\u0014.\u0018(), \u0016\u0003\u0014.\u0018(this));
											\u001A\u0014\u0014.\u0018(\u000B\u0014\u0014.\u0018());
											goto IL_6E9;
										}
										goto IL_6E9;
									}
								}
								if (\u0003\u0003\u0014.\u0018(u0003_u0009_u.\u000C))
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
									\u0017\u0014\u0014.\u0018(\u001C\u0009\u0018.\u0018\u0018, \u0001\u000C\u0014.\u0018(this));
								}
							}
							else if (\u000F\u0002\u0018.\u0018(\u000F\u0007\u0018.\u0018(\u0014\u0003\u0014.\u0018(this)), \u000D\u0009\u0018.\u0020\u0003))
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
								IEnumerable<ViewSheetSetInfo> enumerable2 = Enumerable.Skip<ViewSheetSetInfo>(\u0001\u0014\u0014.\u0014(this), 1);
								Func<ViewSheetSetInfo, bool> func2;
								if ((func2 = ViewSheetSetViewModel.<>c.\u0003) == null)
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
									func2 = (ViewSheetSetViewModel.<>c.\u0003 = new Func<ViewSheetSetInfo, bool>(ViewSheetSetViewModel.<>c.\u000C.\u0009));
								}
								List<ViewSheetSetInfo> list2 = Enumerable.ToList<ViewSheetSetInfo>(Enumerable.Where<ViewSheetSetInfo>(enumerable2, func2));
								if (Enumerable.Any<ViewSheetSetInfo>(list2))
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
									List<ViewSheetSetInfo>.Enumerator enumerator2 = \u0018\u0003\u0014.\u0018(list2);
									try
									{
										while (\u0005\u0014\u0014.\u0018(ref enumerator2))
										{
											ViewSheetSetInfo u2 = \u000C\u0003\u0014.\u0018(ref enumerator2);
											\u000E\u0014\u0014.\u0018(\u0001\u0014\u0014.\u0014(this), u2);
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
									\u001B\u0014\u0014.\u0014(\u0008\u0014\u0014.\u0018(\u0001\u0014\u0014.\u0014(this), 0), \u000D\u0009\u0018.\u0013\u0018);
									\u001F\u0014\u0014.\u0018(\u0008\u0014\u0014.\u0018(\u0001\u0014\u0014.\u0014(this), 0), false);
									\u0012\u0014\u0014.\u0018(Enumerable.Last<BatchAction>(\u0014\u0014\u0014.\u0018(this)), false);
									\u0006\u0014\u0014.\u0018(this, 0);
									IEnumerable<ViewSheetSetInfo> enumerable3 = list2;
									Func<ViewSheetSetInfo, long> func3;
									if ((func3 = ViewSheetSetViewModel.<>c.\u0016) == null)
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
										func3 = (ViewSheetSetViewModel.<>c.\u0016 = new Func<ViewSheetSetInfo, long>(ViewSheetSetViewModel.<>c.\u000C.\u000A));
									}
									DeleteElementExternalEvent u3 = \u0010\u0014\u0014.\u0018(Enumerable.ToList<long>(Enumerable.Select<ViewSheetSetInfo, long>(enumerable3, func3)));
									\u0019\u0014\u0014.\u0018(\u0007\u0014\u0014.\u0018(), u3);
									\u001A\u0014\u0014.\u0018(\u000B\u0014\u0014.\u0018());
									ViewSheetSetViewModel.CheckedChangedDelegate u0004_u = this.\u0004\u0014;
									if (u0004_u == null)
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
										\u001D\u0014\u0014.\u0018(u0004_u);
									}
								}
							}
							else
							{
								List<ViewSheetSet> list3 = \u000F\u000A\u0018.\u0016\u0018<ViewSheetSet>(this.\u000A\u0014);
								if (Enumerable.Any<ViewSheetSet>(list3))
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
									ViewSheetSetViewModel.\u0016\u0009\u0018 u0016_u0009_u = new ViewSheetSetViewModel.\u0016\u0009\u0018();
									AddToViewSheetSetWindow addToViewSheetSetWindow = \u0004\u0014\u0014.\u0018();
									\u001B\u0007\u0018.\u0018(addToViewSheetSetWindow, \u0001\u000C\u0014.\u0018(this));
									\u0002\u0014\u0014.\u0014(addToViewSheetSetWindow, WindowStartupLocation.CenterOwner);
									IEnumerable<ViewSheetSet> enumerable4 = list3;
									Func<ViewSheetSet, string> func4;
									if ((func4 = ViewSheetSetViewModel.<>c.\u000F) == null)
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
										func4 = (ViewSheetSetViewModel.<>c.\u000F = new Func<ViewSheetSet, string>(ViewSheetSetViewModel.<>c.\u000C.\u0020));
									}
									List<string> list4 = Enumerable.ToList<string>(Enumerable.Select<ViewSheetSet, string>(enumerable4, func4));
									\u0003\u0019\u0018.\u0018(addToViewSheetSetWindow.NR, list4);
									\u0016\u0007\u0018.\u0018(addToViewSheetSetWindow.NR, Enumerable.FirstOrDefault<string>(list4));
									\u001E\u0007\u0018.\u0014(addToViewSheetSetWindow);
									if (\u001E\u0014\u0014.\u0018(addToViewSheetSetWindow))
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
										object u000C2 = \u0012\u0007\u0018.\u0018(addToViewSheetSetWindow.NR);
										u0016_u0009_u.\u000C = \u0014\u0004\u000F.\u000C(u000C2);
										if (u0016_u0009_u.\u000C != null)
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
											ViewSheetSet viewSheetSet2 = Enumerable.FirstOrDefault<ViewSheetSet>(\u000F\u000A\u0018.\u0016\u0018<ViewSheetSet>(this.\u000A\u0014), new Func<ViewSheetSet, bool>(u0016_u0009_u.\u0018));
											if (viewSheetSet2 != null)
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
												this.\u0005\u001C(list, viewSheetSet2, false);
											}
										}
									}
								}
								else
								{
									\u0017\u0014\u0014.\u0018(\u001C\u0009\u0018.\u000C\u0018, \u0001\u000C\u0014.\u0018(this));
								}
							}
							IL_6E9:;
						}
					}
					catch (Exception u4)
					{
						\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u4, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ViewModels\\ViewSheetSetViewModel.cs", "SaveSet");
					}
					finally
					{
						\u0015\u0014\u0014.\u0018(this, 0);
					}
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
			}
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000CE60 File Offset: 0x0000B060
		private void \u001B\u001C()
		{
			if (\u0016\u0003\u0014.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewSheetSetViewModel.\u001B\u001C()).MethodHandle;
				}
				if (\u000F\u0016\u0014.\u0018(\u0016\u0003\u0014.\u0018(this)))
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
					if (\u0016\u0016\u0014.\u0018(\u0016\u0003\u0014.\u0018(this)))
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
						\u001B\u0003\u0014.\u0018(\u001C\u0009\u0018.\u0014\u0018, \u0001\u000C\u0014.\u0018(this), 350.0);
					}
					else
					{
						\u001B\u0003\u0014.\u0018(\u001C\u0009\u0018.\u0003\u0018, \u0001\u000C\u0014.\u0018(this), 250.0);
					}
				}
			}
			ViewSheetSetInfo u = \u0011\u0014\u0014.\u0018(\u0003\u0016\u0014.\u0014(\u0016\u0003\u0014.\u0018(this)), \u0015\u0003\u0014.\u0018(\u0014\u0016\u0014.\u0014(\u0016\u0003\u0014.\u0018(this))));
			\u0018\u0016\u0014.\u0018(\u0001\u0014\u0014.\u0014(this), u);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000CF40 File Offset: 0x0000B140
		private void \u0005\u001C(List<ISetViewInfo> \u000C, ViewSheetSet \u0018, bool \u0014 = false)
		{
			try
			{
				bool u = false;
				ViewSet viewSet = \u0006\u0003\u0014.\u0018();
				List<ISetViewInfo>.Enumerator enumerator = \u0010\u0003\u0014.\u0018(\u000C);
				try
				{
					while (\u001D\u0003\u0014.\u0018(ref enumerator))
					{
						ISetViewInfo u000C = \u0007\u0003\u0014.\u0018(ref enumerator);
						View view = \u0018\u0002\u000F.\u000C(\u0003\u0004\u0018.\u0018(this.\u000A\u0014, \u0019\u0003\u0014.\u0018(u000C)));
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
							if (!true)
							{
								RuntimeMethodHandle runtimeMethodHandle = methodof(ViewSheetSetViewModel.\u0005\u001C(List<ISetViewInfo>, ViewSheetSet, bool)).MethodHandle;
							}
							\u000B\u0003\u0014.\u0018(viewSet, view);
							if (\u001A\u0003\u0014.\u0018(view) != 5)
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
								if (\u001A\u0003\u0014.\u0018(view) != 122)
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
									if (\u001A\u0003\u0014.\u0018(view) != 123)
									{
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
							u = true;
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
					((IDisposable)enumerator).Dispose();
				}
				\u0004\u0003\u0014.\u0018(this.\u0020\u0014, 2);
				ViewSheetSetting u2 = \u0002\u0003\u0014.\u0018(this.\u0020\u0014);
				AddToViewSheetSetEvent addToViewSheetSetEvent = \u0002\u0016\u0014.\u0018();
				\u0017\u0016\u0014.\u0018(addToViewSheetSetEvent, \u001E\u0016\u0014.\u0018(\u0018));
				\u0015\u0016\u0014.\u0018(addToViewSheetSetEvent, \u0001\u000C\u0014.\u0018(this));
				\u0011\u0016\u0014.\u0018(addToViewSheetSetEvent, u2);
				\u001F\u0016\u0014.\u0018(addToViewSheetSetEvent, u);
				\u0020\u0016\u0014.\u0018(addToViewSheetSetEvent, viewSet);
				\u000A\u0016\u0014.\u0018(addToViewSheetSetEvent, this.\u0020\u0014);
				\u0009\u0016\u0014.\u0018(addToViewSheetSetEvent, \u0014);
				\u0013\u0016\u0014.\u0018(addToViewSheetSetEvent, \u0018);
				\u001C\u0016\u0014.\u0018(this, addToViewSheetSetEvent);
				\u000D\u0016\u0014.\u0018(\u0012\u0016\u0014.\u0018(this), new AddToViewSheetSetEvent.TaskFinishedHandler(this.\u000E\u001C));
				\u0019\u0014\u0014.\u0018(\u0007\u0014\u0014.\u0018(), \u0012\u0016\u0014.\u0018(this));
				\u001A\u0014\u0014.\u0018(\u000B\u0014\u0014.\u0018());
			}
			catch (Exception u3)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u3, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ViewModels\\ViewSheetSetViewModel.cs", "UpdateExitsViewSheetSet");
			}
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000D120 File Offset: 0x0000B320
		private void \u000E\u001C()
		{
			if (\u0012\u0016\u0014.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewSheetSetViewModel.\u000E\u001C()).MethodHandle;
				}
				if (\u0007\u0016\u0014.\u0018(\u0012\u0016\u0014.\u0018(this)))
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
					ViewSheetSetInfo viewSheetSetInfo = Enumerable.First<ViewSheetSetInfo>(Enumerable.Skip<ViewSheetSetInfo>(\u0001\u0014\u0014.\u0014(this), 1), new Func<ViewSheetSetInfo, bool>(this.\u0003\u0013));
					if (viewSheetSetInfo != null)
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
						\u000B\u0016\u0014.\u0018(viewSheetSetInfo, \u0015\u0003\u0014.\u0018(\u0019\u0016\u0014.\u0014(\u0012\u0016\u0014.\u0018(this))));
					}
					if (\u001A\u0016\u0014.\u0014(\u0012\u0016\u0014.\u0018(this)))
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
						if (\u0004\u0016\u0014.\u0018(\u0012\u0016\u0014.\u0018(this)))
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
							\u0002\u001D\u0018.\u0018(\u001C\u0009\u0018.\u0014\u0018, 350.0);
						}
						else
						{
							\u001B\u0003\u0014.\u0018(\u000D\u0009\u0018.\u001C\u0018, \u0001\u000C\u0014.\u0018(this), 260.0);
						}
						\u001D\u0016\u0014.\u0018(this, viewSheetSetInfo);
						return;
					}
					if (\u0004\u0016\u0014.\u0018(\u0012\u0016\u0014.\u0018(this)))
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
						\u001B\u0003\u0014.\u0018(\u000D\u0009\u0018.\u0012\u0018, \u0001\u000C\u0014.\u0018(this), 350.0);
						return;
					}
					\u001B\u0003\u0014.\u0018(\u000D\u0009\u0018.\u000D\u0018, \u0001\u000C\u0014.\u0018(this), 250.0);
				}
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000D28C File Offset: 0x0000B48C
		[BindableMethod("ViewSetClicked")]
		public void ViewSetClicked(ViewSheetSetInfo set)
		{
			ViewSheetSetViewModel.\u000F\u0009\u0018 u000F_u0009_u = new ViewSheetSetViewModel.\u000F\u0009\u0018();
			u000F_u0009_u.\u000C = set;
			if (u000F_u0009_u.\u000C != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewSheetSetViewModel.ViewSetClicked(ViewSheetSetInfo)).MethodHandle;
				}
				ViewSheetSetInfo viewSheetSetInfo = Enumerable.First<ViewSheetSetInfo>(\u0001\u0014\u0014.\u0014(this));
				ViewSheetSetInfo viewSheetSetInfo2 = viewSheetSetInfo;
				int num = 1;
				if (u000F_u0009_u.\u000C == viewSheetSetInfo2)
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
					\u0001\u0016\u0014.\u0018(Enumerable.ToList<ViewSheetSetInfo>(\u0001\u0014\u0014.\u0014(this)), new Action<ViewSheetSetInfo>(u000F_u0009_u.\u0018));
				}
				else
				{
					\u001F\u0014\u0014.\u0018(viewSheetSetInfo2, false);
				}
				IEnumerable<ViewSheetSetInfo> enumerable = Enumerable.Skip<ViewSheetSetInfo>(\u0001\u0014\u0014.\u0014(this), num);
				Func<ViewSheetSetInfo, bool> func;
				if ((func = ViewSheetSetViewModel.<>c.\u0012) == null)
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
					func = (ViewSheetSetViewModel.<>c.\u0012 = new Func<ViewSheetSetInfo, bool>(ViewSheetSetViewModel.<>c.\u000C.\u001F));
				}
				int num2 = Enumerable.Count<ViewSheetSetInfo>(enumerable, func);
				\u0012\u0014\u0014.\u0018(Enumerable.Last<BatchAction>(\u0014\u0014\u0014.\u0018(this)), true);
				if (num2 == 0)
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
					if (\u0008\u0016\u0014.\u0018(viewSheetSetInfo2))
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
						\u001B\u0014\u0014.\u0014(viewSheetSetInfo, \u000D\u0009\u0018.\u0009\u0018);
						\u001F\u0014\u0014.\u0018(viewSheetSetInfo2, true);
						\u001F\u0014\u0014.\u0018(viewSheetSetInfo, true);
					}
					else
					{
						\u001B\u0014\u0014.\u0014(viewSheetSetInfo, \u000D\u0009\u0018.\u0013\u0018);
						\u001F\u0014\u0014.\u0018(viewSheetSetInfo, false);
						\u0012\u0014\u0014.\u0018(Enumerable.Last<BatchAction>(\u0014\u0014\u0014.\u0018(this)), false);
					}
				}
				if (\u0010\u0016\u0014.\u0018(\u0001\u0014\u0014.\u0014(this)) > num)
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
					if (num2 == 1)
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
						object u000C = viewSheetSetInfo;
						IEnumerable<ViewSheetSetInfo> enumerable2 = Enumerable.Skip<ViewSheetSetInfo>(\u0001\u0014\u0014.\u0014(this), num);
						Func<ViewSheetSetInfo, bool> func2;
						if ((func2 = ViewSheetSetViewModel.<>c.\u000D) == null)
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
							func2 = (ViewSheetSetViewModel.<>c.\u000D = new Func<ViewSheetSetInfo, bool>(ViewSheetSetViewModel.<>c.\u000C.\u0011));
						}
						\u001B\u0014\u0014.\u0014(u000C, \u0006\u0016\u0014.\u0018(Enumerable.First<ViewSheetSetInfo>(enumerable2, func2)));
						\u001F\u0014\u0014.\u0018(viewSheetSetInfo, true);
					}
					else if (num2 == \u0010\u0016\u0014.\u0018(\u0001\u0014\u0014.\u0014(this)) - num)
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
						\u001B\u0014\u0014.\u0014(viewSheetSetInfo, \u000D\u0009\u0018.\u0009\u0018);
						\u001F\u0014\u0014.\u0018(viewSheetSetInfo2, true);
						\u001F\u0014\u0014.\u0018(viewSheetSetInfo, true);
					}
					else if (num2 > 1)
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
						\u001B\u0014\u0014.\u0014(viewSheetSetInfo, \u000D\u0009\u0018.\u000A\u0018);
						\u001F\u0014\u0014.\u0018(viewSheetSetInfo, true);
					}
				}
			}
			\u0006\u0014\u0014.\u0018(this, 0);
			ViewSheetSetViewModel.CheckedChangedDelegate u0004_u = this.\u0004\u0014;
			if (u0004_u == null)
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
				return;
			}
			\u001D\u0014\u0014.\u0018(u0004_u);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000D4D8 File Offset: 0x0000B6D8
		[BindableMethod("OnSelectionChangedSetList")]
		public void OnSelectionChangedSetList()
		{
			\u0006\u0014\u0014.\u0018(this, 0);
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000D4EC File Offset: 0x0000B6EC
		[CompilerGenerated]
		private BatchAction \u000C\u0013()
		{
			return \u0014\u0003\u0014.\u0018(this);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000D504 File Offset: 0x0000B704
		[CompilerGenerated]
		private int \u0018\u0013()
		{
			return \u000C\u0016\u0014.\u0018(this);
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000D51C File Offset: 0x0000B71C
		[CompilerGenerated]
		private int \u0014\u0013()
		{
			return \u001B\u0016\u0014.\u0018(this);
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000D534 File Offset: 0x0000B734
		[CompilerGenerated]
		private bool \u0003\u0013(ViewSheetSetInfo \u000C)
		{
			return \u001B\u0013\u0018.\u0018(\u0006\u0016\u0014.\u0018(\u000C), \u0005\u0016\u0014.\u0018(\u0012\u0016\u0014.\u0018(this)), true);
		}

		// Token: 0x04000101 RID: 257
		private Document \u000A\u0014;

		// Token: 0x04000102 RID: 258
		private PrintManager \u0020\u0014;

		// Token: 0x04000103 RID: 259
		private ObservableCollection<ViewSheetSetInfo> \u001F\u0014;

		// Token: 0x04000104 RID: 260
		private BatchAction \u0011\u0014;

		// Token: 0x04000105 RID: 261
		private int \u0015\u0014;

		// Token: 0x04000106 RID: 262
		private int \u0017\u0014;

		// Token: 0x04000107 RID: 263
		[CompilerGenerated]
		private CreateViewSheetSetEvent \u001E\u0014;

		// Token: 0x04000108 RID: 264
		[CompilerGenerated]
		private AddToViewSheetSetEvent \u0002\u0014;

		// Token: 0x04000109 RID: 265
		[CompilerGenerated]
		private ViewSheetSetViewModel.CheckedChangedDelegate \u0004\u0014;

		// Token: 0x0400010A RID: 266
		[CompilerGenerated]
		private List<BatchAction> \u001D\u0014;

		// Token: 0x0400010B RID: 267
		[CompilerGenerated]
		private List<ISetViewInfo> \u001A\u0014;

		// Token: 0x02000162 RID: 354
		// (Invoke) Token: 0x06001063 RID: 4195
		public delegate void CheckedChangedDelegate();

		// Token: 0x02000164 RID: 356
		[CompilerGenerated]
		private sealed class \u0003\u0009\u0018
		{
			// Token: 0x06001070 RID: 4208 RVA: 0x0005A79C File Offset: 0x0005899C
			internal bool \u0018(ViewSheetSet \u000C)
			{
				return \u001B\u0013\u0018.\u0018(\u001E\u0016\u0014.\u0018(\u000C), \u0020\u0003\u0014.\u0014(this.\u000C), true);
			}

			// Token: 0x04000791 RID: 1937
			public NewNameWindow \u000C;
		}

		// Token: 0x02000165 RID: 357
		[CompilerGenerated]
		private sealed class \u0016\u0009\u0018
		{
			// Token: 0x06001072 RID: 4210 RVA: 0x0005A7DC File Offset: 0x000589DC
			internal bool \u0018(ViewSheetSet \u000C)
			{
				return \u001B\u0013\u0018.\u0018(\u001E\u0016\u0014.\u0018(\u000C), this.\u000C, true);
			}

			// Token: 0x04000792 RID: 1938
			public string \u000C;
		}

		// Token: 0x02000166 RID: 358
		[CompilerGenerated]
		private sealed class \u000F\u0009\u0018
		{
			// Token: 0x06001074 RID: 4212 RVA: 0x0005A814 File Offset: 0x00058A14
			internal void \u0018(ViewSheetSetInfo \u000C)
			{
				\u001F\u0014\u0014.\u0018(\u000C, \u0008\u0016\u0014.\u0018(this.\u000C));
			}

			// Token: 0x04000793 RID: 1939
			public ViewSheetSetInfo \u000C;
		}
	}
}
