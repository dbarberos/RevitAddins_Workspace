using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.SheetGen.Data;
using DiRoots.One.SheetGen.Messaging;
using DiRoots.One.SheetGen.Models.Interfaces;
using DiRoots.One.SheetGen.Profiles;
using DiRoots.One.SheetGen.Services;
using DiRoots.One.SheetGen.UI.Behaviors;
using DiRoots.One.SheetGen.ViewModels;
using DiRoots.One.TemplateTransfer;
using DiRoots.One.UIBehaviours.Behaviors;
using DiRoots.One.ViewRange;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002D7 RID: 727
	public class ViewManager : DiRootsWindow, IViewManager, IProgressBarReporter, IExecutable, IComponentConnector, IStyleConnector
	{
		// Token: 0x06001E01 RID: 7681 RVA: 0x000BCEC8 File Offset: 0x000BB0C8
		public ViewManager()
		{
			\u001C\u000C\u0007.\u0007(this, \u0011\u0015\u0005.\u000A());
			\u0010\u0013\u0016.\u000A(this);
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\ViewManager.xaml.cs", ".ctor");
			ViewsSelectionBehavior viewsSelectionBehavior = new ViewsSelectionBehavior();
			\u000F\u0009\u000A.\u000A(viewsSelectionBehavior, DataGridSelectionBehavior<ViewManagerView>.SelectedItemsProperty, new Binding("SelectedViews"));
			\u0002\u0009\u000A.\u000A(\u0006\u0009\u000A.\u000A(this.MU), viewsSelectionBehavior);
			ViewsTempSelectionBehavior viewsTempSelectionBehavior = new ViewsTempSelectionBehavior();
			\u000F\u0009\u000A.\u000A(viewsTempSelectionBehavior, DataGridSelectionBehavior<ViewManagerView>.SelectedItemsProperty, new Binding("SelectedViewTemplate"));
			\u0002\u0009\u000A.\u000A(\u0006\u0009\u000A.\u000A(this.CW), viewsTempSelectionBehavior);
			\u000D\u0013\u0016.\u000A(ParametersManagerService.\u0008, \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004));
			\u001C\u0013\u0016.\u000A(this, new ViewManagerViewModel(this));
			\u0017\u001A\u000A.\u0007(this, \u0003\u0013\u0016.\u000A(this));
			\u0017\u001A\u000A.\u001D(this.BW, \u0007\u000C\u000A.\u001D(this));
			\u0017\u001A\u000A.\u001D(this.DR, \u0007\u000C\u000A.\u001D(this));
			\u0005\u001B\u000A.\u0018.\u001D<object>(\u0010\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)), new Action<object>(\u0010\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)).RefreshViews), Context.RefreshViews);
			\u0016\u000C\u0007.\u000A(this, "");
			\u0003\u0011\u0016.\u000A(this);
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\ViewManager.xaml.cs", ".ctor");
		}

		// Token: 0x17000849 RID: 2121
		// (get) Token: 0x06001E02 RID: 7682 RVA: 0x000BD024 File Offset: 0x000BB224
		// (set) Token: 0x06001E03 RID: 7683 RVA: 0x000BD038 File Offset: 0x000BB238
		public bool IsOpenedFromSheetGen { get; set; }

		// Token: 0x1700084A RID: 2122
		// (get) Token: 0x06001E04 RID: 7684 RVA: 0x000BD04C File Offset: 0x000BB24C
		// (set) Token: 0x06001E05 RID: 7685 RVA: 0x000BD060 File Offset: 0x000BB260
		public ViewManagerViewModel ViewManagerViewModels { get; set; }

		// Token: 0x1700084B RID: 2123
		// (get) Token: 0x06001E06 RID: 7686 RVA: 0x000BD074 File Offset: 0x000BB274
		// (set) Token: 0x06001E07 RID: 7687 RVA: 0x000BD088 File Offset: 0x000BB288
		internal static ViewManager CurrentViewManagerWindow { get; set; }

		// Token: 0x1700084C RID: 2124
		// (get) Token: 0x06001E08 RID: 7688 RVA: 0x000BD09C File Offset: 0x000BB29C
		// (set) Token: 0x06001E09 RID: 7689 RVA: 0x000BD0B0 File Offset: 0x000BB2B0
		public bool IsSheetGenOpen { get; set; }

		// Token: 0x06001E0A RID: 7690 RVA: 0x000BD0C4 File Offset: 0x000BB2C4
		private void dgViews_Sorting(object sender, DataGridSortingEventArgs e)
		{
			ListCollectionView u001F = \u000F\u0009\u0010.\u001F(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.MU)));
			int num = \u0005\u0005\u000E.\u001F(\u0004\u0015\u000A.\u001D(\u000D\u0009\u000A.\u000A(e), \u0011\u0013.\u001F));
			if (num != 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.dgViews_Sorting(object, DataGridSortingEventArgs)).MethodHandle;
				}
				if (num != 1)
				{
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
			}
			ListSortDirection? listSortDirection = \u001B\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e));
			ListSortDirection listSortDirection2 = ListSortDirection.Ascending;
			if (\u0008\u0009\u000A.\u000A(ref listSortDirection) == listSortDirection2 & \u000E\u0009\u000A.\u000A(ref listSortDirection))
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
				\u0010\u0009\u000A.\u000A(u001F, new \u0017\u0011(false, \u0010\u000B\u0019.\u001D(\u000D\u0009\u000A.\u000A(e))));
				\u001C\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e), new ListSortDirection?(ListSortDirection.Descending));
			}
			else
			{
				\u0010\u0009\u000A.\u000A(u001F, new \u0017\u0011(true, \u0010\u000B\u0019.\u001D(\u000D\u0009\u000A.\u000A(e))));
				\u001C\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e), new ListSortDirection?(ListSortDirection.Ascending));
			}
			\u0003\u0009\u000A.\u000A(e, true);
		}

		// Token: 0x06001E0B RID: 7691 RVA: 0x000BD1CC File Offset: 0x000BB3CC
		private bool OCR(string F, ViewManagerView R)
		{
			bool result = true;
			bool flag = false;
			IEnumerator<ViewManagerView> enumerator = \u0011\u0013\u0016.\u000A(\u001E\u0013\u0016.\u0007(\u0010\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this))));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ViewManagerView u001F = \u001B\u0013\u0016.\u000A(enumerator);
					if (\u0008\u0013\u000A.\u000A(\u0007\u000B\u0016.\u000A(u001F), \u0007\u000B\u0016.\u000A(R)))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.OCR(string, ViewManagerView)).MethodHandle;
						}
						if (\u0014\u0016\u0016.\u0007(u001F) == \u0014\u0016\u0016.\u0007(R))
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
					if (\u000D\u0008\u000A.\u000A(\u0007\u000B\u0016.\u000A(u001F), F, true))
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
						if (\u0014\u0016\u0016.\u0007(u001F) == \u0014\u0016\u0016.\u0007(R))
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
							flag = true;
							goto IL_E2;
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
			IL_E2:
			if (\u001A\u0006\u0007.\u000A(F))
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
				result = false;
				\u0005\u0013\u0019.\u000A(\u0008\u0013\u0016.\u000A(), this, 250.0);
			}
			if (flag)
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
				result = false;
				\u0005\u0013\u0019.\u000A(\u0017\u0006\u0007.\u000A(\u000E\u0013\u0016.\u000A(), \u001C\u0002\u0016.\u000A(R)), this, 250.0);
			}
			return result;
		}

		// Token: 0x06001E0C RID: 7692 RVA: 0x000BD334 File Offset: 0x000BB534
		private void dgViews_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			this.BS = \u0003\u001C\u000E.\u001F;
		}

		// Token: 0x06001E0D RID: 7693 RVA: 0x000BD34C File Offset: 0x000BB54C
		private void DataGridCell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DataGridCell dataGridCell = \u001E\u0012\u000E.\u001F(sender);
			if (dataGridCell != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.DataGridCell_PreviewMouseLeftButtonDown(object, MouseButtonEventArgs)).MethodHandle;
				}
				object u001F = \u001A\u0001\u0018.\u000A(dataGridCell);
				if (\u0009\u0015\u0010.\u001F(u001F) != null)
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
					if (!\u001F\u0001\u0010.\u001F(u001F))
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
						this.BS = dataGridCell;
					}
				}
			}
		}

		// Token: 0x06001E0E RID: 7694 RVA: 0x000BD3B4 File Offset: 0x000BB5B4
		private void dgViews_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
		{
			bool flag = false;
			if (this.BS != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.dgViews_BeginningEdit(object, DataGridBeginningEditEventArgs)).MethodHandle;
				}
				flag = true;
			}
			if (\u0014\u0013\u0016.\u000A(\u0010\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this))))
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
				flag = true;
				\u0017\u0013\u0016.\u0007(\u0010\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)), false);
			}
			if (flag)
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
				\u000C\u0020\u0016.\u000A(e, true);
				\u0008\u000B\u0019.\u000A(this.MU);
				\u0008\u000B\u0019.\u000A(this.MU);
				return;
			}
			\u0020\u0013\u0016.\u000A(\u0010\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)), true);
		}

		// Token: 0x06001E0F RID: 7695 RVA: 0x000BD460 File Offset: 0x000BB660
		private void CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
		{
			bool flag = true;
			bool flag2 = false;
			ViewManagerView viewManagerView = \u001A\u001C\u000E.\u001F(\u0004\u0001\u0007.\u0007(\u001E\u000B\u0019.\u000A(e)));
			if (\u0011\u000B\u0019.\u000A(e) == DataGridEditAction.Commit)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.CellEditEnding(object, DataGridCellEditEndingEventArgs)).MethodHandle;
				}
				ViewManager.\u0016\u0011 u0016_u = new ViewManager.\u0016\u0011();
				TextBox u001F = \u000A\u000D\u000E.\u001F;
				string u001F2 = "";
				DataGridColumn u001F3 = \u000E\u000B\u0019.\u000A(e);
				u0016_u.\u001F = \u0015\u0018\u000E.\u001F(u001F3);
				if (u0016_u.\u001F != null)
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
					DataGridBoundColumn u001F4 = u0016_u.\u001F;
					bool flag3;
					if (u001F4 == null)
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
						flag3 = (null != null);
					}
					else
					{
						flag3 = (\u0010\u000B\u0019.\u0007(u001F4) != null);
					}
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
						u001F = \u0008\u000A\u000E.\u001F(\u001B\u000B\u0019.\u000A(e));
						try
						{
							u001F2 = \u0010\u000B\u0019.\u001D(u0016_u.\u001F);
						}
						catch (Exception u000A)
						{
							\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\ViewManager.xaml.cs", "CellEditEnding");
						}
						if (\u0008\u0013\u000A.\u000A(u001F2, "View Name"))
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
							string text = \u0003\u000B\u0019.\u0007(u001F);
							object u001F5 = text;
							char[] array = \u001C\u0007\u000E.\u001F(13);
							\u001B\u000B\u001D.\u000A(array, fieldof(\u0001\u001B\u000A.\u0016).FieldHandle);
							if (\u0013\u000F\u0007.\u0007(u001F5, array) != -1)
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
								\u0005\u0013\u0019.\u000A(\u0019\u001A\u0016.\u000A(), this, 250.0);
								\u000F\u000B\u0019.\u000A(e, true);
							}
							if (flag)
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
								if (!this.OCR(\u0003\u000B\u0019.\u0007(u001F), viewManagerView))
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
									flag = false;
									\u000F\u000B\u0019.\u000A(e, true);
								}
								else
								{
									flag2 = viewManagerView.\u0007(text, false);
								}
							}
						}
						else
						{
							Type u001F6 = \u001E\u0011\u000A.\u000A(\u0007\u000D\u000E.\u001F());
							DataGridBoundColumn u001F7 = u0016_u.\u001F;
							Type u000A2;
							if (u001F7 == null)
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
								u000A2 = \u001D\u000D\u000E.\u001F;
							}
							else
							{
								DataTemplate dataTemplate = \u0004\u001A\u0016.\u0007(u001F7);
								if (dataTemplate == null)
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
									u000A2 = \u001D\u000D\u000E.\u001F;
								}
								else
								{
									FrameworkElementFactory frameworkElementFactory = \u001D\u001A\u0016.\u000A(dataTemplate);
									if (frameworkElementFactory == null)
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
										u000A2 = \u001D\u000D\u000E.\u001F;
									}
									else
									{
										FrameworkElementFactory frameworkElementFactory2 = \u0007\u001A\u0016.\u000A(frameworkElementFactory);
										if (frameworkElementFactory2 == null)
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
											u000A2 = \u001D\u000D\u000E.\u001F;
										}
										else
										{
											u000A2 = \u000A\u001A\u0016.\u000A(frameworkElementFactory2);
										}
									}
								}
							}
							SelectionParameter selectionParameter;
							if (\u001F\u001A\u0016.\u000A(u001F6, u000A2))
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
								selectionParameter = Enumerable.FirstOrDefault<SelectionParameter>(\u0020\u001B\u0016.\u0007(ParametersManagerService.\u0008), new Func<SelectionParameter, bool>(u0016_u.\u000A));
							}
							else
							{
								selectionParameter = Enumerable.FirstOrDefault<SelectionParameter>(\u0020\u001B\u0016.\u0007(ParametersManagerService.\u0008), new Func<SelectionParameter, bool>(u0016_u.\u0007));
							}
							if (selectionParameter == null)
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
							if (\u0008\u0013\u000A.\u000A(\u001F\u0016\u0016.\u0007(selectionParameter), \u0010\u000B\u0019.\u001D(u0016_u.\u001F)))
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
								if (!\u001D\u0005\u0016.\u0007(selectionParameter))
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
									if (!\u000A\u0006\u0016.\u0007(selectionParameter))
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
										if (!\u001A\u0006\u0007.\u000A(\u0003\u000B\u0019.\u0007(u001F)))
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
											string u000A3 = \u0018\u0006\u001D.\u0007(\u0009\u0013\u0016.\u000A());
											try
											{
												StorageType storageType = \u0001\u0013\u0016.\u000A(selectionParameter);
												if (storageType != 1)
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
													if (storageType != 2)
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
														u000A3 = \u0018\u0006\u001D.\u0007(\u000C\u0013\u0016.\u000A());
														List<Parameter> u000A4 = \u000C\u0002\u0016.\u000A(\u001F\u000B\u0016.\u0007(viewManagerView), false);
														if (!\u001A\u0013\u0016.\u000A(viewManagerView.\u001F(selectionParameter, \u000A\u0003\u0016.\u001D(selectionParameter) == SelectionParameterType.ProjectInformation).\u000A(u000A4), \u0003\u000B\u0019.\u0007(u001F), \u0011\u0015\u0005.\u000A()))
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
															flag = false;
															\u000F\u000B\u0019.\u000A(e, true);
															\u0005\u0013\u0019.\u000A(\u001F\u001F\u0019.\u000A(), this, 250.0);
														}
													}
												}
												else
												{
													u000A3 = \u0018\u0006\u001D.\u0007(\u0015\u0013\u0016.\u000A());
													\u000D\u000B\u001D.\u000A(\u0003\u000B\u0019.\u0007(u001F));
												}
											}
											catch (Exception)
											{
												flag = false;
												\u0005\u0013\u0019.\u000A(\u0017\u0006\u0007.\u000A(\u0013\u0013\u0016.\u000A(), u000A3), this, 250.0);
												\u000F\u000B\u0019.\u000A(e, true);
											}
										}
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
											ParameterModel parameterModel;
											if ((parameterModel = viewManagerView.\u001F(selectionParameter, \u000A\u0003\u0016.\u001D(selectionParameter) == SelectionParameterType.ProjectInformation)) != null)
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
												if (\u000A\u0003\u0016.\u001D(selectionParameter) == SelectionParameterType.ProjectInformation)
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
													flag2 = viewManagerView.\u000A(parameterModel, \u0003\u000B\u0019.\u0007(u001F));
												}
												else
												{
													List<ViewManagerView>.Enumerator enumerator = \u001A\u0016\u0016.\u000A(Enumerable.ToList<ViewManagerView>(Enumerable.Cast<ViewManagerView>(\u0009\u0006\u0007.\u0007(this.MU))));
													try
													{
														while (\u0020\u0016\u0016.\u000A(ref enumerator))
														{
															ViewManagerView u001F8 = \u0013\u0016\u0016.\u000A(ref enumerator);
															parameterModel = u001F8.\u001F(selectionParameter, false);
															if (parameterModel != null)
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
																flag2 = u001F8.\u000A(parameterModel, \u0003\u000B\u0019.\u0007(u001F));
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
												}
											}
										}
									}
								}
							}
						}
					}
				}
				if (flag2 || flag)
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
					\u0013\u0016\u0019.\u000A(this.MU, new EventHandler<DataGridCellEditEndingEventArgs>(this.CellEditEnding));
					\u0014\u0016\u0019.\u000A(this.MU, DataGridEditingUnit.Row, true);
					\u0017\u0016\u0019.\u000A(this.MU, new EventHandler<DataGridCellEditEndingEventArgs>(this.CellEditEnding));
				}
				else if (\u0008\u0013\u000A.\u000A(u001F2, "View Name"))
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
					if (\u001D\u0017\u000A.\u000A(\u0003\u000B\u0019.\u0007(u001F), \u0007\u000B\u0016.\u000A(viewManagerView)))
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
						\u001A\u0015\u0007.\u000A(u001F, \u0007\u000B\u0016.\u000A(viewManagerView));
						\u0008\u000B\u0019.\u000A(this.MU);
						\u0008\u000B\u0019.\u000A(this.MU);
					}
				}
			}
			\u0020\u0013\u0016.\u000A(\u0010\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)), false);
		}

		// Token: 0x06001E10 RID: 7696 RVA: 0x000BDA80 File Offset: 0x000BBC80
		public void ExecutionFinished(bool isDelete = false)
		{
			\u000E\u0015\u0007.\u000A(this.JR, 100.0);
			\u000F\u0015\u0007.\u000A(this.JW, \u0004\u001E\u000A.\u000A(\u0007\u0018\u0019.\u000A(), " 100%"));
			if (!isDelete)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.ExecutionFinished(bool)).MethodHandle;
				}
				\u0005\u0013\u0019.\u000A(\u001A\u000E\u001D.\u000A(), this, 250.0);
			}
			\u000E\u0015\u0007.\u000A(this.JR, 0.0);
			\u000F\u0015\u0007.\u000A(this.JW, \u0004\u001E\u000A.\u000A(\u0007\u0018\u0019.\u000A(), " 0%"));
		}

		// Token: 0x06001E11 RID: 7697 RVA: 0x000BDB20 File Offset: 0x000BBD20
		public void ExcutionFailed()
		{
			\u000E\u0015\u0007.\u000A(this.JR, 0.0);
			\u000F\u0015\u0007.\u000A(this.JW, \u0004\u001E\u000A.\u000A(\u0007\u0018\u0019.\u000A(), " 0%"));
		}

		// Token: 0x06001E12 RID: 7698 RVA: 0x000BDB60 File Offset: 0x000BBD60
		public void ReportProgress(int percent, string currentName, UpdateStates status)
		{
			\u000E\u0015\u0007.\u000A(this.JR, \u000E\u0016\u0019.\u000A(percent));
			string text = \u000E\u0019\u001D.\u000A();
			if (status == UpdateStates.ToTrash)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.ReportProgress(int, string, UpdateStates)).MethodHandle;
				}
				text = \u0016\u001A\u0016.\u000A();
			}
			else if (status == UpdateStates.ToDuplicate)
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
				text = \u0005\u001A\u0016.\u000A();
			}
			else if (status == UpdateStates.Modified)
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
				text = \u0018\u001A\u0016.\u000A();
			}
			object jw = this.JW;
			string u001F = "{0} {1}% - {2} {3}";
			object[] array = \u0004\u0015\u0010.\u001F(4);
			array[0] = \u0007\u0018\u0019.\u000A();
			array[1] = percent;
			array[2] = text;
			array[3] = currentName;
			\u000F\u0015\u0007.\u000A(jw, \u001C\u0015\u001D.\u000A(u001F, array));
		}

		// Token: 0x06001E13 RID: 7699 RVA: 0x000BDC14 File Offset: 0x000BBE14
		private void CheckAllViews(object sender, RoutedEventArgs e)
		{
			CheckBox checkBox = \u0011\u000A\u000E.\u001F(sender);
			if (checkBox != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.CheckAllViews(object, RoutedEventArgs)).MethodHandle;
				}
				object u001F = \u0010\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this));
				bool? flag = \u0003\u0015\u000A.\u000A(checkBox);
				\u000B\u001A\u0016.\u000A(u001F, \u0012\u0015\u000A.\u000A(ref flag));
			}
		}

		// Token: 0x06001E14 RID: 7700 RVA: 0x000BDC68 File Offset: 0x000BBE68
		private void wndViewManager_Closed(object sender, EventArgs e)
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\ViewManager.xaml.cs", "wndViewManager_Closed");
			if (\u001D\u0011\u0016.\u000A() == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.wndViewManager_Closed(object, EventArgs)).MethodHandle;
				}
				\u0014\u0020\u0016.\u000A(\u0006\u001A\u0016.\u000A());
			}
			\u0003\u0011\u0016.\u000A(\u0009\u001C\u000E.\u001F);
			\u0012\u0011\u0016.\u000A(\u001F\u000D\u000E.\u001F);
			\u0005\u001B\u000A.\u0018.\u0004<object>(\u0007\u000C\u000A.\u001D(this), Context.RefreshViews);
			\u0005\u001B\u000A.\u0018.\u0004<object>(\u0007\u000C\u000A.\u001D(this), Context.ProfileLoadedVM);
			if (\u001D\u0011\u0016.\u000A() == null)
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
				\u000E\u001B\u000A.\u0004.Unregister<IViewManager>();
				\u001B\u0020\u0016.\u000A(ParametersManagerService.\u0008);
				\u0008\u0020\u0016.\u000A(\u0007\u0005\u0016.\u000A());
				\u000E\u0020\u0016.\u000A(Collector.\u0004);
				\u001C\u0020\u0016.\u000A(\u000D\u0020\u0016.\u000A());
				\u0010\u0020\u0016.\u000A(DocumentAccessProvider.\u0004);
				\u0003\u0020\u0016.\u000A(\u0005\u001B\u000A.\u0018);
				\u0004\u000F\u001D.\u000A(\u000E\u001B\u000A.\u0004);
				\u000E\u001B\u000A.\u0004 = \u000D\u001C\u000E.\u001F;
			}
			\u0002\u001A\u0016.\u000A(\u0006\u001A\u0016.\u000A());
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\ViewManager.xaml.cs", "wndViewManager_Closed");
		}

		// Token: 0x06001E15 RID: 7701 RVA: 0x000BDD9C File Offset: 0x000BBF9C
		private void DataGrid_Unloaded(object sender, RoutedEventArgs e)
		{
			\u0014\u0016\u0019.\u000A(this.MU, DataGridEditingUnit.Row, true);
		}

		// Token: 0x06001E16 RID: 7702 RVA: 0x000BDDBC File Offset: 0x000BBFBC
		private void cmbViewType_DropDownOpened(object sender, EventArgs e)
		{
			\u0014\u0016\u0019.\u000A(this.MU, DataGridEditingUnit.Row, true);
		}

		// Token: 0x06001E17 RID: 7703 RVA: 0x000BDDDC File Offset: 0x000BBFDC
		private void wndViewManager_Loaded(object sender, RoutedEventArgs e)
		{
			\u000F\u0015\u0007.\u000A(this.JW, \u0004\u001E\u000A.\u000A(\u0007\u0018\u0019.\u000A(), " 0%"));
		}

		// Token: 0x06001E18 RID: 7704 RVA: 0x000BDE08 File Offset: 0x000BC008
		private void HeaderCheckBox_Click(object sender, RoutedEventArgs e)
		{
			ViewManager.\u000B\u0011 u000B_u = new ViewManager.\u000B\u0011();
			ViewManager.\u000B\u0011 u000B_u2 = u000B_u;
			bool? flag = \u0003\u0015\u000A.\u000A(\u0011\u000A\u000E.\u001F(sender));
			u000B_u2.\u001F = \u0019\u0020\u000A.\u000A(ref flag);
			ICollectionView collectionView = \u0012\u001A\u0016.\u0007(\u0010\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)));
			if (collectionView == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.HeaderCheckBox_Click(object, RoutedEventArgs)).MethodHandle;
				}
			}
			else
			{
				ParallelEnumerable.ForAll<ViewManagerView>(ParallelEnumerable.AsParallel<ViewManagerView>(Enumerable.Cast<ViewManagerView>(collectionView)), new Action<ViewManagerView>(u000B_u.\u000A));
			}
			object u001F = \u0010\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this));
			IEnumerable<ViewManagerView> enumerable = Enumerable.Cast<ViewManagerView>(\u0012\u001A\u0016.\u0007(\u0010\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this))));
			Func<ViewManagerView, bool> func;
			if ((func = ViewManager.<>c.\u000A) == null)
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
				func = (ViewManager.<>c.\u000A = new Func<ViewManagerView, bool>(ViewManager.<>c.\u001F.\u0019));
			}
			\u000F\u001A\u0016.\u0007(u001F, Enumerable.Count<ViewManagerView>(enumerable, func));
		}

		// Token: 0x06001E19 RID: 7705 RVA: 0x000BDEEC File Offset: 0x000BC0EC
		private void CheckBox_Click(object sender, RoutedEventArgs e)
		{
			ViewManager.\u0002\u0011 u0002_u = new ViewManager.\u0002\u0011();
			ViewManager.\u0002\u0011 u0002_u2 = u0002_u;
			bool? flag = \u0003\u0015\u000A.\u000A(\u0011\u000A\u000E.\u001F(sender));
			u0002_u2.\u001F = \u0019\u0020\u000A.\u000A(ref flag);
			\u0003\u001A\u0016.\u000A(Enumerable.ToList<ViewManagerView>(Enumerable.Cast<ViewManagerView>(\u0009\u0006\u0007.\u0007(this.ICR<DataGrid>(\u0011\u000A\u000E.\u001F(sender))))), new Action<ViewManagerView>(u0002_u.\u000A));
			object u001F = \u0010\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this));
			IEnumerable<ViewManagerView> enumerable = Enumerable.Cast<ViewManagerView>(\u0012\u001A\u0016.\u0007(\u0010\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this))));
			Func<ViewManagerView, bool> func;
			if ((func = ViewManager.<>c.\u0007) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.CheckBox_Click(object, RoutedEventArgs)).MethodHandle;
				}
				func = (ViewManager.<>c.\u0007 = new Func<ViewManagerView, bool>(ViewManager.<>c.\u001F.\u0018));
			}
			\u000F\u001A\u0016.\u0007(u001F, Enumerable.Count<ViewManagerView>(enumerable, func));
			this.TCR();
		}

		// Token: 0x06001E1A RID: 7706 RVA: 0x000BDFC4 File Offset: 0x000BC1C4
		private void TCR()
		{
			ICollectionView collectionView = \u0012\u001A\u0016.\u0007(\u0010\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)));
			IEnumerable<ViewManagerView> enumerable;
			if (collectionView == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.TCR()).MethodHandle;
				}
				enumerable = \u0001\u001C\u000E.\u001F;
			}
			else
			{
				enumerable = Enumerable.Cast<ViewManagerView>(collectionView);
			}
			IEnumerable<ViewManagerView> enumerable2 = enumerable;
			IEnumerable<ViewManagerView> enumerable3 = enumerable2;
			Func<ViewManagerView, bool> func;
			if ((func = ViewManager.<>c.\u001D) == null)
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
				func = (ViewManager.<>c.\u001D = new Func<ViewManagerView, bool>(ViewManager.<>c.\u001F.\u0005));
			}
			if (Enumerable.All<ViewManagerView>(enumerable3, func))
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
				\u000D\u000C\u0007.\u000A(this.LW, new bool?(true));
				return;
			}
			IEnumerable<ViewManagerView> enumerable4 = enumerable2;
			Func<ViewManagerView, bool> func2;
			if ((func2 = ViewManager.<>c.\u0004) == null)
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
				func2 = (ViewManager.<>c.\u0004 = new Func<ViewManagerView, bool>(ViewManager.<>c.\u001F.\u0016));
			}
			if (Enumerable.Any<ViewManagerView>(enumerable4, func2))
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
				object lw = this.LW;
				bool? u000A;
				\u001B\u000A\u000E.\u001F(ref u000A);
				\u000D\u000C\u0007.\u000A(lw, u000A);
				return;
			}
			\u000D\u000C\u0007.\u000A(this.LW, new bool?(false));
		}

		// Token: 0x06001E1B RID: 7707 RVA: 0x000BE0C0 File Offset: 0x000BC2C0
		private F ICR<F>(DependencyObject F) where F : DependencyObject
		{
			if (F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.ICR(DependencyObject)).MethodHandle;
				}
				return default(F);
			}
			DependencyObject dependencyObject = \u0019\u0001\u0007.\u000A(F);
			if (dependencyObject == null)
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
				return default(F);
			}
			F f = dependencyObject as F;
			if (f != null)
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
				return f;
			}
			return this.ICR<F>(dependencyObject);
		}

		// Token: 0x06001E1C RID: 7708 RVA: 0x000BE138 File Offset: 0x000BC338
		private void dgViews_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				DependencyObject dependencyObject = \u000A\u0007\u000E.\u001F(\u0018\u0001\u0007.\u000A(e));
				while (dependencyObject != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.dgViews_MouseRightButtonDown(object, MouseButtonEventArgs)).MethodHandle;
					}
					if (\u001E\u0012\u000E.\u001F(dependencyObject) != null)
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
					if (\u0020\u0012\u000E.\u001F(dependencyObject) != null)
					{
						for (;;)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							goto IL_59;
						}
					}
					else
					{
						dependencyObject = \u0019\u0001\u0007.\u000A(dependencyObject);
					}
				}
				IL_59:
				if (dependencyObject != null)
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
					if (\u0020\u0012\u000E.\u001F(dependencyObject) != null)
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
						if (\u001E\u0012\u000E.\u001F(dependencyObject) != null)
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
							\u000A\u0016\u0019.\u000A(this.MU, \u0005\u000A\u000E.\u001F(\u0009\u0018\u0005.\u001D(this.MU, "rowContextMenu")));
							\u0005\u0009\u0005.\u000A(\u001F\u0016\u0019.\u000A(this.MU), this.MU);
							\u0009\u001A\u0019.\u000A(\u001F\u0016\u0019.\u000A(this.MU), true);
							\u0019\u0013\u000A.\u000A(e, true);
							goto IL_13C;
						}
						goto IL_13C;
					}
				}
				\u000A\u0016\u0019.\u000A(this.MU, \u0005\u000A\u000E.\u001F(\u0009\u0018\u0005.\u001D(this.MU, "headerContextMenu")));
				\u0005\u0009\u0005.\u000A(\u001F\u0016\u0019.\u000A(this.MU), this.MU);
				\u0009\u001A\u0019.\u000A(\u001F\u0016\u0019.\u000A(this.MU), true);
				\u0019\u0013\u000A.\u000A(e, true);
				IL_13C:;
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\ViewManager.xaml.cs", "dgViews_MouseRightButtonDown");
			}
		}

		// Token: 0x06001E1D RID: 7709 RVA: 0x000BE2BC File Offset: 0x000BC4BC
		private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			TabControl tabControl = \u0001\u001F\u000E.\u001F(\u0015\u001D\u0005.\u000A(e));
			if (tabControl != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.tabControl_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				int num = \u0012\u000C\u000A.\u000A(tabControl);
				if (num != 2)
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
					if (num != 3)
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
						return;
					}
					if (this.ZU == null)
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
						this.ZU = \u001C\u001A\u0016.\u000A(this);
						\u0014\u001A\u000A.\u000A(this.KW, this.ZU);
					}
				}
				else if (this.XU == null)
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
					this.XU = \u000D\u001A\u0016.\u000A(this);
					\u0014\u001A\u000A.\u000A(this.WW, this.XU);
					return;
				}
			}
		}

		// Token: 0x06001E1E RID: 7710 RVA: 0x000BE37C File Offset: 0x000BC57C
		protected override void ApplyLicense(bool isLicenseValid)
		{
			\u0015\u0009\u000A.\u000A(this.RW, isLicenseValid);
			\u0015\u0009\u000A.\u000A(this.WW, isLicenseValid);
			\u0015\u0009\u000A.\u000A(this.KW, isLicenseValid);
		}

		// Token: 0x06001E1F RID: 7711 RVA: 0x000BE3B0 File Offset: 0x000BC5B0
		private void dgViewTemp_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				DependencyObject dependencyObject = \u000A\u0007\u000E.\u001F(\u0018\u0001\u0007.\u000A(e));
				while (dependencyObject != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.dgViewTemp_MouseRightButtonDown(object, MouseButtonEventArgs)).MethodHandle;
					}
					if (\u001E\u0012\u000E.\u001F(dependencyObject) != null)
					{
						break;
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
					if (\u0020\u0012\u000E.\u001F(dependencyObject) != null)
					{
						for (;;)
						{
							switch (3)
							{
							case 0:
								continue;
							}
							goto IL_59;
						}
					}
					else
					{
						dependencyObject = \u0019\u0001\u0007.\u000A(dependencyObject);
					}
				}
				IL_59:
				if (\u001E\u0012\u000E.\u001F(dependencyObject) != null)
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
					\u0005\u0009\u0005.\u000A(\u001F\u0016\u0019.\u000A(this.CW), this.CW);
					\u0009\u001A\u0019.\u000A(\u001F\u0016\u0019.\u000A(this.CW), true);
					\u0019\u0013\u000A.\u000A(e, true);
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\ViewManager.xaml.cs", "dgViewTemp_MouseRightButtonDown");
			}
		}

		// Token: 0x06001E20 RID: 7712 RVA: 0x000BE488 File Offset: 0x000BC688
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/viewmanager.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001E21 RID: 7713 RVA: 0x000BE4D0 File Offset: 0x000BC6D0
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		internal Delegate TDR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x06001E22 RID: 7714 RVA: 0x000BE4E8 File Offset: 0x000BC6E8
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.IU = \u0015\u001C\u000E.\u001F(R);
				\u0016\u0015\u0007.\u0007(this.IU, new EventHandler(this.wndViewManager_Closed));
				\u0011\u000C\u000A.\u0007(this.IU, new RoutedEventHandler(this.wndViewManager_Loaded));
				return;
			case 3:
				this.W = \u000F\u001C\u000E.\u001F(R);
				return;
			case 4:
				this.QU = \u001A\u0015\u0010.\u001F(R);
				\u001B\u000C\u000A.\u0007(this.QU, new SelectionChangedEventHandler(this.tabControl_SelectionChanged));
				return;
			case 5:
				this.AU = \u000C\u0015\u0010.\u001F(R);
				return;
			case 6:
				this.KD = \u000B\u000A\u000E.\u001F(R);
				return;
			case 7:
				this.GU = \u000B\u000A\u000E.\u001F(R);
				return;
			case 8:
				this.NS = \u000B\u000A\u000E.\u001F(R);
				return;
			case 9:
				this.MS = \u000B\u000A\u000E.\u001F(R);
				return;
			case 10:
				this.VS = \u0019\u0009\u0010.\u001F(R);
				return;
			case 11:
				this.ZS = \u000B\u000A\u000E.\u001F(R);
				return;
			case 12:
				this.JD = \u001E\u0001\u0010.\u001F(R);
				return;
			case 13:
				this.UD = \u0005\u0009\u0010.\u001F(R);
				return;
			case 14:
				this.MU = \u0020\u0001\u0010.\u001F(R);
				\u0004\u0002\u0019.\u000A(this.MU, new EventHandler<DataGridBeginningEditEventArgs>(this.dgViews_BeginningEdit));
				\u0017\u0016\u0019.\u000A(this.MU, new EventHandler<DataGridCellEditEndingEventArgs>(this.CellEditEnding));
				\u0007\u0002\u0019.\u000A(this.MU, new MouseButtonEventHandler(this.dgViews_MouseRightButtonDown));
				\u0003\u0001\u0007.\u000A(this.MU, new MouseButtonEventHandler(this.dgViews_PreviewMouseLeftButtonDown));
				\u001F\u001F\u0007.\u000A(this.MU, new DataGridSortingEventHandler(this.dgViews_Sorting));
				\u001E\u0004\u0005.\u000A(this.MU, new RoutedEventHandler(this.DataGrid_Unloaded));
				return;
			case 15:
				\u0010\u0015\u000A.\u000A(\u0016\u0009\u0010.\u001F(R), new RoutedEventHandler(this.CheckAllViews));
				return;
			case 16:
				this.FW = \u0010\u000A\u000E.\u001F(R);
				return;
			case 17:
				this.JU = \u000B\u000A\u000E.\u001F(R);
				\u0010\u001A\u0016.\u000A(this.JU, new EventHandler(this.cmbViewType_DropDownOpened));
				return;
			case 18:
				this.KR = \u001A\u000A\u000E.\u001F(R);
				return;
			case 19:
				this.RW = \u000C\u0015\u0010.\u001F(R);
				return;
			case 20:
				this.DW = \u000B\u000A\u000E.\u001F(R);
				return;
			case 21:
				this.HW = \u001E\u0001\u0010.\u001F(R);
				return;
			case 22:
				this.YW = \u0005\u0009\u0010.\u001F(R);
				return;
			case 23:
				this.CW = \u0020\u0001\u0010.\u001F(R);
				\u0004\u0002\u0019.\u000A(this.CW, new EventHandler<DataGridBeginningEditEventArgs>(this.dgViews_BeginningEdit));
				\u0017\u0016\u0019.\u000A(this.CW, new EventHandler<DataGridCellEditEndingEventArgs>(this.CellEditEnding));
				\u0007\u0002\u0019.\u000A(this.CW, new MouseButtonEventHandler(this.dgViewTemp_MouseRightButtonDown));
				\u001E\u0004\u0005.\u000A(this.CW, new RoutedEventHandler(this.DataGrid_Unloaded));
				return;
			case 24:
				this.LW = \u0016\u0009\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.LW, new RoutedEventHandler(this.HeaderCheckBox_Click));
				return;
			case 26:
				this.SW = \u0010\u000A\u000E.\u001F(R);
				return;
			case 27:
				this.DR = \u000B\u000A\u000E.\u001F(R);
				return;
			case 28:
				this.BW = \u000B\u000A\u000E.\u001F(R);
				return;
			case 29:
				this.UW = \u001A\u000A\u000E.\u001F(R);
				return;
			case 30:
				this.WW = \u000C\u0015\u0010.\u001F(R);
				return;
			case 31:
				this.KW = \u000C\u0015\u0010.\u001F(R);
				return;
			case 32:
				this.JR = \u0013\u000A\u000E.\u001F(R);
				return;
			case 33:
				this.JW = \u001B\u0001\u0010.\u001F(R);
				return;
			case 34:
				this.EW = \u0013\u000A\u000E.\u001F(R);
				return;
			case 35:
				this.NW = \u001A\u000A\u000E.\u001F(R);
				return;
			case 36:
				this.MW = \u001A\u000A\u000E.\u001F(R);
				return;
			case 37:
				this.YL = \u001E\u0001\u0010.\u001F(R);
				return;
			case 38:
				this.ZD = \u001E\u0001\u0010.\u001F(R);
				return;
			}
			this.R = true;
		}

		// Token: 0x06001E23 RID: 7715 RVA: 0x000BE924 File Offset: 0x000BCB24
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IStyleConnector.AQ(int F, object R)
		{
			if (F == 2)
			{
				EventSetter eventSetter = \u001B\u0001\u0007.\u000A();
				\u0008\u0001\u0007.\u000A(eventSetter, UIElement.PreviewMouseLeftButtonDownEvent);
				\u000E\u0001\u0007.\u000A(eventSetter, new MouseButtonEventHandler(this.DataGridCell_PreviewMouseLeftButtonDown));
				\u000D\u0001\u0007.\u000A(\u0010\u0001\u0007.\u000A(\u000C\u000A\u000E.\u001F(R)), eventSetter);
				return;
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.AQ(int, object)).MethodHandle;
			}
			if (F != 25)
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
				return;
			}
			\u0010\u0015\u000A.\u000A(\u0016\u0009\u0010.\u001F(R), new RoutedEventHandler(this.CheckBox_Click));
		}

		// Token: 0x06001E24 RID: 7716 RVA: 0x000BE9AC File Offset: 0x000BCBAC
		void IViewManager.TG()
		{
			\u0009\u0001\u0007.\u001D(this);
		}

		// Token: 0x06001E25 RID: 7717 RVA: 0x000BE9C0 File Offset: 0x000BCBC0
		void IViewManager.IG(EventHandler F)
		{
			\u0016\u0015\u0007.\u001D(this, F);
		}

		// Token: 0x06001E26 RID: 7718 RVA: 0x000BE9D4 File Offset: 0x000BCBD4
		void IViewManager.QG(EventHandler F)
		{
			\u0012\u001E\u0016.\u000A(this, F);
		}

		// Token: 0x06001E27 RID: 7719 RVA: 0x000BE9E8 File Offset: 0x000BCBE8
		Window IViewManager.AG()
		{
			return \u000D\u0011\u0016.\u0007(this);
		}

		// Token: 0x06001E28 RID: 7720 RVA: 0x000BEA00 File Offset: 0x000BCC00
		void IViewManager.GG(Window F)
		{
			\u000C\u000E\u0007.\u001D(this, F);
		}

		// Token: 0x06001E29 RID: 7721 RVA: 0x000BEA14 File Offset: 0x000BCC14
		WindowState IViewManager.FFR()
		{
			return \u0011\u0004\u0005.\u0007(this);
		}

		// Token: 0x06001E2A RID: 7722 RVA: 0x000BEA2C File Offset: 0x000BCC2C
		void IViewManager.RFR(WindowState F)
		{
			\u0019\u0005\u001D.\u001D(this, F);
		}

		// Token: 0x04000C42 RID: 3138
		internal ViewRangeControl ZU;

		// Token: 0x04000C43 RID: 3139
		internal TemplateTransfers XU;

		// Token: 0x04000C44 RID: 3140
		[CompilerGenerated]
		private bool PU;

		// Token: 0x04000C45 RID: 3141
		[CompilerGenerated]
		private ViewManagerViewModel OU;

		// Token: 0x04000C47 RID: 3143
		[CompilerGenerated]
		private bool TU;

		// Token: 0x04000C48 RID: 3144
		private DataGridCell BS;

		// Token: 0x04000C49 RID: 3145
		internal ViewManager IU;

		// Token: 0x04000C4A RID: 3146
		internal ProfileUserControl W;

		// Token: 0x04000C4B RID: 3147
		internal TabControl QU;

		// Token: 0x04000C4C RID: 3148
		internal TabItem AU;

		// Token: 0x04000C4D RID: 3149
		internal ComboBox KD;

		// Token: 0x04000C4E RID: 3150
		internal ComboBox GU;

		// Token: 0x04000C4F RID: 3151
		internal ComboBox NS;

		// Token: 0x04000C50 RID: 3152
		internal ComboBox MS;

		// Token: 0x04000C51 RID: 3153
		internal LeftStripButton VS;

		// Token: 0x04000C52 RID: 3154
		internal ComboBox ZS;

		// Token: 0x04000C53 RID: 3155
		internal Button JD;

		// Token: 0x04000C54 RID: 3156
		internal WatermarkTextBox UD;

		// Token: 0x04000C55 RID: 3157
		internal DataGrid MU;

		// Token: 0x04000C56 RID: 3158
		internal DataGridTextColumn FW;

		// Token: 0x04000C57 RID: 3159
		internal ComboBox JU;

		// Token: 0x04000C58 RID: 3160
		internal Label KR;

		// Token: 0x04000C59 RID: 3161
		internal TabItem RW;

		// Token: 0x04000C5A RID: 3162
		internal ComboBox DW;

		// Token: 0x04000C5B RID: 3163
		internal Button HW;

		// Token: 0x04000C5C RID: 3164
		internal WatermarkTextBox YW;

		// Token: 0x04000C5D RID: 3165
		internal DataGrid CW;

		// Token: 0x04000C5E RID: 3166
		internal CheckBox LW;

		// Token: 0x04000C5F RID: 3167
		internal DataGridTextColumn SW;

		// Token: 0x04000C60 RID: 3168
		internal ComboBox DR;

		// Token: 0x04000C61 RID: 3169
		internal ComboBox BW;

		// Token: 0x04000C62 RID: 3170
		internal Label UW;

		// Token: 0x04000C63 RID: 3171
		internal TabItem WW;

		// Token: 0x04000C64 RID: 3172
		internal TabItem KW;

		// Token: 0x04000C65 RID: 3173
		internal ProgressBar JR;

		// Token: 0x04000C66 RID: 3174
		internal TextBlock JW;

		// Token: 0x04000C67 RID: 3175
		internal ProgressBar EW;

		// Token: 0x04000C68 RID: 3176
		internal Label NW;

		// Token: 0x04000C69 RID: 3177
		internal Label MW;

		// Token: 0x04000C6A RID: 3178
		internal Button YL;

		// Token: 0x04000C6B RID: 3179
		internal Button ZD;

		// Token: 0x04000C6C RID: 3180
		private bool R;

		// Token: 0x020009B3 RID: 2483
		[CompilerGenerated]
		private sealed class \u0016\u0011
		{
			// Token: 0x06005395 RID: 21397 RVA: 0x001ED1E4 File Offset: 0x001EB3E4
			internal bool \u000A(SelectionParameter \u001F)
			{
				if (\u0008\u0013\u000A.\u000A(\u001F\u0016\u0016.\u0007(\u001F), \u0010\u000B\u0019.\u001D(this.\u001F)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.\u0016\u0011.\u000A(SelectionParameter)).MethodHandle;
					}
					return \u000A\u0003\u0016.\u001D(\u001F) == SelectionParameterType.ProjectInformation;
				}
				return false;
			}

			// Token: 0x06005396 RID: 21398 RVA: 0x001ED230 File Offset: 0x001EB430
			internal bool \u0007(SelectionParameter \u001F)
			{
				if (\u0008\u0013\u000A.\u000A(\u001F\u0016\u0016.\u0007(\u001F), \u0010\u000B\u0019.\u001D(this.\u001F)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManager.\u0016\u0011.\u0007(SelectionParameter)).MethodHandle;
					}
					return \u000A\u0003\u0016.\u001D(\u001F) != SelectionParameterType.ProjectInformation;
				}
				return false;
			}

			// Token: 0x04002531 RID: 9521
			public DataGridBoundColumn \u001F;
		}

		// Token: 0x020009B4 RID: 2484
		[CompilerGenerated]
		private sealed class \u000B\u0011
		{
			// Token: 0x06005398 RID: 21400 RVA: 0x001ED294 File Offset: 0x001EB494
			internal void \u000A(ViewManagerView \u001F)
			{
				\u0019\u0015\u0016.\u000A(\u001F, this.\u001F);
			}

			// Token: 0x04002532 RID: 9522
			public bool \u001F;
		}

		// Token: 0x020009B5 RID: 2485
		[CompilerGenerated]
		private sealed class \u0002\u0011
		{
			// Token: 0x0600539A RID: 21402 RVA: 0x001ED2C4 File Offset: 0x001EB4C4
			internal void \u000A(ViewManagerView \u001F)
			{
				\u0019\u0015\u0016.\u000A(\u001F, this.\u001F);
			}

			// Token: 0x04002533 RID: 9523
			public bool \u001F;
		}
	}
}
