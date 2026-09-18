using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.SheetLink.Core.Models;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;
using Syncfusion.UI.Xaml.CellGrid;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.UI.Xaml.Spreadsheet.Helpers;
using Syncfusion.XlsIO;

namespace DiRoots.One.SheetLink.ViewModels
{
	// Token: 0x02000216 RID: 534
	public class PreviewViewModel : ViewModelBase
	{
		// Token: 0x170005C3 RID: 1475
		// (get) Token: 0x0600143E RID: 5182 RVA: 0x000829C0 File Offset: 0x00080BC0
		// (set) Token: 0x0600143F RID: 5183 RVA: 0x000829D4 File Offset: 0x00080BD4
		public SfSpreadsheet SheetControl { get; set; }

		// Token: 0x170005C4 RID: 1476
		// (get) Token: 0x06001440 RID: 5184 RVA: 0x000829E8 File Offset: 0x00080BE8
		public CommandBase UpdateCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.UpdateModel), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005C5 RID: 1477
		// (get) Token: 0x06001441 RID: 5185 RVA: 0x00082A10 File Offset: 0x00080C10
		public CommandBase ResetCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.Reset), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x06001442 RID: 5186 RVA: 0x00082A38 File Offset: 0x00080C38
		public void Initialize(ControlExcelBase controlExcel, Window parentWindow, ProgressModel progressModel)
		{
			this.PW = false;
			\u000A\u000C\u0007.\u001D(this, parentWindow);
			this.VW = progressModel;
			if (this.ZW == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.Initialize(ControlExcelBase, Window, ProgressModel)).MethodHandle;
				}
				if (\u0004\u0009\u0018.\u000A(\u001F\u0009\u0018.\u000A(this)) == null)
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
					this.ZW = \u0008\u0002\u000E.\u001F(controlExcel);
					\u0007\u0009\u0018.\u000A(this.ZW, \u001F\u0009\u0018.\u000A(this));
					\u0019\u0009\u0018.\u000A(\u001F\u0009\u0018.\u000A(this), new WorkbookLoadedEventHandler(this.GZR));
					goto IL_F9;
				}
			}
			if (this.ZW == null)
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
				if (\u0004\u0009\u0018.\u000A(\u001F\u0009\u0018.\u000A(this)) != null)
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
					\u001D\u0009\u0018.\u000A(\u0004\u0009\u0018.\u000A(\u001F\u0009\u0018.\u000A(this)));
				}
			}
			this.ZW = \u0008\u0002\u000E.\u001F(controlExcel);
			\u0007\u0009\u0018.\u000A(this.ZW, \u001F\u0009\u0018.\u000A(this));
			\u000A\u0009\u0018.\u000A(this.ZW, \u000E\u0002\u000E.\u001F);
			IL_F9:
			\u001D\u0002\u0019.\u000A(\u001F\u0009\u0018.\u000A(this), new ContextMenuEventHandler(this.HXR));
		}

		// Token: 0x06001443 RID: 5187 RVA: 0x00082B58 File Offset: 0x00080D58
		private void GZR(object F, WorkbookLoadedEventArgs R)
		{
			\u001D\u0009\u0018.\u000A(\u0004\u0009\u0018.\u000A(\u001F\u0009\u0018.\u000A(this)));
			\u000A\u0009\u0018.\u000A(this.ZW, \u000E\u0002\u000E.\u001F);
		}

		// Token: 0x06001444 RID: 5188 RVA: 0x00082B8C File Offset: 0x00080D8C
		public void OpenFile(string filePath, Window window, ProgressModel progressModel)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\PreviewViewModel.cs", "OpenFile");
			this.PW = true;
			\u000A\u000C\u0007.\u001D(this, window);
			this.VW = progressModel;
			this.XW = filePath;
			if (!\u001A\u0006\u0007.\u000A(this.HL))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.OpenFile(string, Window, ProgressModel)).MethodHandle;
				}
				\u0020\u0008\u000A.\u001F(this.HL);
			}
			this.HL = \u001B\u0015\u001D.\u000A(\u0004\u000F.\u0004(), \u0004\u001E\u000A.\u000A(\u0006\u0013\u0004.\u000A(), ".xlsx"));
			\u0016\u0009\u0018.\u000A(filePath, this.HL, true);
			\u0005\u0009\u0018.\u000A(\u001F\u0009\u0018.\u000A(this), this.HL);
			\u0018\u0009\u0018.\u000A(\u001F\u0009\u0018.\u000A(this), new WorkbookLoadedEventHandler(this.GZR));
			\u0018\u0009\u0018.\u000A(\u001F\u0009\u0018.\u000A(this), new WorkbookLoadedEventHandler(this.FXR));
			\u0019\u0009\u0018.\u000A(\u001F\u0009\u0018.\u000A(this), new WorkbookLoadedEventHandler(this.FXR));
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\PreviewViewModel.cs", "OpenFile");
		}

		// Token: 0x06001445 RID: 5189 RVA: 0x00082CA4 File Offset: 0x00080EA4
		private void FXR(object F, WorkbookLoadedEventArgs R)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\PreviewViewModel.cs", "spreadsheetControl_WorkbookLoadedWithPath");
			\u0015\u0009\u000A.\u000A(\u001F\u0009\u0018.\u000A(this), false);
			IWorkbook u001F = \u0004\u0009\u0018.\u000A(\u001F\u0009\u0018.\u000A(this));
			try
			{
				try
				{
					IEnumerator<IWorksheet> enumerator = \u000F\u0009\u0018.\u000A(\u0003\u001E\u001D.\u000A(u001F));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							IWorksheet worksheet = \u0006\u0009\u0018.\u000A(enumerator);
							string u001F2 = \u0014\u0011\u001D.\u000A(worksheet);
							if (!\u000D\u0008\u000A.\u000A(u001F2, "instructions", true))
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
									RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.FXR(object, WorkbookLoadedEventArgs)).MethodHandle;
								}
								if (!\u000D\u0008\u000A.\u000A(u001F2, "ParamValues", true))
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
									if (!\u000D\u0008\u000A.\u000A(u001F2, "sheet1", true))
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
										ParamExportInfo paramExportInfo = \u001B\u0012.\u000F(worksheet);
										if (paramExportInfo != null)
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
											int num = Enumerable.Count<IRange>(\u0013\u0014\u001D.\u000A(\u0018\u001E\u001D.\u000A(worksheet)));
											int h = Enumerable.Count<IRange>(\u001A\u0014\u001D.\u000A(\u0018\u001E\u001D.\u000A(worksheet)));
											int num2 = \u0019\u0019\u0018.\u000A(paramExportInfo);
											List<ParamExportInfo> list = \u0010\u0002\u000E.\u001F;
											if (\u001D\u0012\u0018.\u000A(paramExportInfo) == ExportTypes.ProjectInformation)
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
												list = \u001B\u0012.\u0003(worksheet, 1);
											}
											else if (\u001D\u0012\u0018.\u000A(paramExportInfo) != ExportTypes.Families)
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
												list = \u001B\u0012.\u0012(worksheet, num2, false);
											}
											if (\u001D\u0012\u0018.\u000A(paramExportInfo) == ExportTypes.ProjectInformation)
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
												this.DXR(worksheet, list);
											}
											else
											{
												if (\u001D\u0012\u0018.\u000A(paramExportInfo) != ExportTypes.AnalyticalModelObjects)
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
													if (\u001D\u0012\u0018.\u000A(paramExportInfo) != ExportTypes.AnnotationObjects)
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
														if (\u001D\u0012\u0018.\u000A(paramExportInfo) != ExportTypes.LineStyles)
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
															if (\u001D\u0012\u0018.\u000A(paramExportInfo) == ExportTypes.ModelObjects)
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
																if (\u001D\u0012\u0018.\u000A(paramExportInfo) != ExportTypes.Families)
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
																	this.DXR(worksheet, num2, num, h, list);
																	continue;
																}
																continue;
															}
														}
													}
												}
												this.DXR(worksheet, num, list);
											}
										}
									}
								}
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
						if (enumerator != null)
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
							\u001F\u0017\u000A.\u000A(enumerator);
						}
					}
					\u000B\u0009\u0018.\u000A(\u0002\u0009\u0018.\u0007(\u001F\u0009\u0018.\u000A(this)), false);
				}
				catch (TaskCanceledException)
				{
				}
				catch (HiddenCellModifiedException f)
				{
					this.RXR(f);
				}
				catch (Exception f2)
				{
					this.RXR(f2);
				}
				\u0015\u0009\u000A.\u000A(\u001F\u0009\u0018.\u000A(this), true);
				\u0018\u0009\u0018.\u000A(\u001F\u0009\u0018.\u000A(this), new WorkbookLoadedEventHandler(this.FXR));
				\u0011\u0015\u000A.\u0007(\u0018\u000B\u0007.\u0007(this), true);
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\PreviewViewModel.cs", "spreadsheetControl_WorkbookLoadedWithPath");
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\PreviewViewModel.cs", "spreadsheetControl_WorkbookLoadedWithPath");
		}

		// Token: 0x06001446 RID: 5190 RVA: 0x00083004 File Offset: 0x00081204
		private void RXR(Exception F)
		{
			PreviewViewModel.\u0012\u0003 u0012_u = new PreviewViewModel.\u0012\u0003();
			u0012_u.\u001F = F;
			\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u0012_u.\u001F, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\PreviewViewModel.cs", "ShowError");
			if (\u0018\u000B\u0007.\u0007(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.RXR(Exception)).MethodHandle;
				}
				if (\u0015\u0007\u0018.\u000A(\u0018\u000B\u0007.\u0007(this)))
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
					Thread u001F = \u0003\u0009\u0018.\u000A(new ThreadStart(u0012_u.\u000A));
					\u0012\u0009\u0018.\u000A(u001F, ApartmentState.STA);
					\u000D\u0016\u0019.\u000A(u001F);
				}
			}
		}

		// Token: 0x06001447 RID: 5191 RVA: 0x00083094 File Offset: 0x00081294
		private void DXR(IWorksheet F, List<ParamExportInfo> R)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\PreviewViewModel.cs", "ShowDifference");
			if (\u0013\u0013\u0007.\u000A(\u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A())) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.DXR(IWorksheet, List<ParamExportInfo>)).MethodHandle;
				}
				ProjectInfo u001F = \u0013\u0013\u0007.\u000A(\u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A()));
				IEnumerable<Parameter> enumerable = \u0015\u001C.\u0002(u001F, false, \u0018\u001B\u0018.\u000A(\u001E\u0004\u0018.\u000A(R, 1)) > 0L);
				Func<Parameter, long> func;
				if ((func = PreviewViewModel.<>c.\u000A) == null)
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
					func = (PreviewViewModel.<>c.\u000A = new Func<Parameter, long>(PreviewViewModel.<>c.\u001F.\u000E));
				}
				IEnumerable<IGrouping<long, Parameter>> enumerable2 = Enumerable.GroupBy<Parameter, long>(enumerable, func);
				Func<IGrouping<long, Parameter>, long> func2;
				if ((func2 = PreviewViewModel.<>c.\u0007) == null)
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
					func2 = (PreviewViewModel.<>c.\u0007 = new Func<IGrouping<long, Parameter>, long>(PreviewViewModel.<>c.\u001F.\u0008));
				}
				Func<IGrouping<long, Parameter>, List<Parameter>> func3;
				if ((func3 = PreviewViewModel.<>c.\u001D) == null)
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
					func3 = (PreviewViewModel.<>c.\u001D = new Func<IGrouping<long, Parameter>, List<Parameter>>(PreviewViewModel.<>c.\u001F.\u001B));
				}
				Dictionary<long, List<Parameter>> u000A = Enumerable.ToDictionary<IGrouping<long, Parameter>, long, List<Parameter>>(enumerable2, func2, func3);
				IEnumerable<Parameter> enumerable3 = \u0015\u001C.\u0002(u001F, true, \u0018\u001B\u0018.\u000A(\u001E\u0004\u0018.\u000A(R, 1)) > 0L);
				Func<Parameter, long> func4;
				if ((func4 = PreviewViewModel.<>c.\u0004) == null)
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
					func4 = (PreviewViewModel.<>c.\u0004 = new Func<Parameter, long>(PreviewViewModel.<>c.\u001F.\u0011));
				}
				IEnumerable<IGrouping<long, Parameter>> enumerable4 = Enumerable.GroupBy<Parameter, long>(enumerable3, func4);
				Func<IGrouping<long, Parameter>, long> func5;
				if ((func5 = PreviewViewModel.<>c.\u0019) == null)
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
					func5 = (PreviewViewModel.<>c.\u0019 = new Func<IGrouping<long, Parameter>, long>(PreviewViewModel.<>c.\u001F.\u001E));
				}
				Func<IGrouping<long, Parameter>, List<Parameter>> func6;
				if ((func6 = PreviewViewModel.<>c.\u0018) == null)
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
					func6 = (PreviewViewModel.<>c.\u0018 = new Func<IGrouping<long, Parameter>, List<Parameter>>(PreviewViewModel.<>c.\u001F.\u0020));
				}
				Dictionary<long, List<Parameter>> u = Enumerable.ToDictionary<IGrouping<long, Parameter>, long, List<Parameter>>(enumerable4, func5, func6);
				int num = 1;
				IEnumerator<ParamExportInfo> enumerator = \u0008\u0009\u0018.\u000A(Enumerable.Skip<ParamExportInfo>(R, 2));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						ParamExportInfo u001D = \u000E\u0009\u0018.\u000A(enumerator);
						Parameter u000A2;
						string u2 = \u0018\u0012.\u001F(u001F, u000A, u, u001D, true, out u000A2);
						IRange u001F2 = \u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(F), num, 3);
						if (\u0003\u000F.\u000B(\u0003\u000B\u001D.\u0007(\u0003\u0014\u001D.\u000A(u001F2)), u000A2, u2))
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
							\u0010\u0009\u0018.\u000A(u001F2, ExcelLineStyle.Thick, ExcelKnownColors.Teal);
							\u0002\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(u001F2), \u000D\u0009\u0018.\u000A());
							\u001C\u0009\u0018.\u000A(\u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(u001F2)), ExcelKnownColors.White);
						}
						num++;
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
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\PreviewViewModel.cs", "ShowDifference");
		}

		// Token: 0x06001448 RID: 5192 RVA: 0x00083344 File Offset: 0x00081544
		private void DXR(IWorksheet F, int R, int D, int H, List<ParamExportInfo> C)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\PreviewViewModel.cs", "ShowDifference");
			List<Document> list = \u0017\u000D.\u0015(\u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A()));
			\u001E\u0009\u0018.\u000A(list, 0, \u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A()));
			for (int i = R + 1; i <= D; i++)
			{
				string u001F = \u0003\u0014\u001D.\u000A(\u000F\u000A\u0004.\u000A(F, i, 1));
				if (\u001A\u0006\u0007.\u000A(u001F))
				{
					IL_39E:
					\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\PreviewViewModel.cs", "ShowDifference");
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.DXR(IWorksheet, int, int, int, List<ParamExportInfo>)).MethodHandle;
				}
				Element element = \u0017\u000D.\u000A\u000A(u001F, list);
				if (element != null)
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
					IEnumerable<Parameter> enumerable = \u0015\u001C.\u0002(element, false, \u0018\u001B\u0018.\u000A(\u001E\u0004\u0018.\u000A(C, 1)) > 0L);
					Func<Parameter, long> func;
					if ((func = PreviewViewModel.<>c.\u0005) == null)
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
						func = (PreviewViewModel.<>c.\u0005 = new Func<Parameter, long>(PreviewViewModel.<>c.\u001F.\u0017));
					}
					IEnumerable<IGrouping<long, Parameter>> enumerable2 = Enumerable.GroupBy<Parameter, long>(enumerable, func);
					Func<IGrouping<long, Parameter>, long> func2;
					if ((func2 = PreviewViewModel.<>c.\u0016) == null)
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
						func2 = (PreviewViewModel.<>c.\u0016 = new Func<IGrouping<long, Parameter>, long>(PreviewViewModel.<>c.\u001F.\u0014));
					}
					Func<IGrouping<long, Parameter>, List<Parameter>> func3;
					if ((func3 = PreviewViewModel.<>c.\u000B) == null)
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
						func3 = (PreviewViewModel.<>c.\u000B = new Func<IGrouping<long, Parameter>, List<Parameter>>(PreviewViewModel.<>c.\u001F.\u0013));
					}
					Dictionary<long, List<Parameter>> u000A = Enumerable.ToDictionary<IGrouping<long, Parameter>, long, List<Parameter>>(enumerable2, func2, func3);
					IEnumerable<Parameter> enumerable3 = \u0015\u001C.\u0002(element, true, \u0018\u001B\u0018.\u000A(\u001E\u0004\u0018.\u000A(C, 1)) > 0L);
					Func<Parameter, long> func4;
					if ((func4 = PreviewViewModel.<>c.\u0002) == null)
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
						func4 = (PreviewViewModel.<>c.\u0002 = new Func<Parameter, long>(PreviewViewModel.<>c.\u001F.\u001A));
					}
					IEnumerable<IGrouping<long, Parameter>> enumerable4 = Enumerable.GroupBy<Parameter, long>(enumerable3, func4);
					Func<IGrouping<long, Parameter>, long> func5;
					if ((func5 = PreviewViewModel.<>c.\u0006) == null)
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
						func5 = (PreviewViewModel.<>c.\u0006 = new Func<IGrouping<long, Parameter>, long>(PreviewViewModel.<>c.\u001F.\u000C));
					}
					Func<IGrouping<long, Parameter>, List<Parameter>> func6;
					if ((func6 = PreviewViewModel.<>c.\u000F) == null)
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
						func6 = (PreviewViewModel.<>c.\u000F = new Func<IGrouping<long, Parameter>, List<Parameter>>(PreviewViewModel.<>c.\u001F.\u0015));
					}
					Dictionary<long, List<Parameter>> u = Enumerable.ToDictionary<IGrouping<long, Parameter>, long, List<Parameter>>(enumerable4, func5, func6);
					int num;
					if (H / 10 != 0)
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
						num = H / 10;
					}
					else
					{
						num = 1;
					}
					int num2 = num;
					for (int j = 1; j <= H; j++)
					{
						if (j % num2 == 0)
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
							object u001F2 = \u001C\u0015\u0007.\u001D(\u001F\u0009\u0018.\u000A(this));
							DispatcherPriority u000A2 = DispatcherPriority.Background;
							Action u2;
							if ((u2 = PreviewViewModel.<>c.\u0012) == null)
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
								u2 = (PreviewViewModel.<>c.\u0012 = new Action(PreviewViewModel.<>c.\u001F.\u0001));
							}
							\u0003\u0015\u0007.\u000A(u001F2, u000A2, u2);
							if (!\u0015\u0007\u0018.\u000A(\u001F\u0009\u0018.\u000A(this)))
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
								throw \u0011\u0009\u0018.\u000A("User cancelled the import");
							}
						}
						ParamExportInfo paramExportInfo = \u001E\u0004\u0018.\u000A(C, j - 1);
						if (!\u001B\u0009\u0018.\u000A(paramExportInfo))
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
							Parameter parameter;
							string text = \u0018\u0012.\u001F(element, u000A, u, paramExportInfo, true, out parameter);
							IRange u001F3 = \u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(F), i, j);
							string text2 = \u0003\u000B\u001D.\u0007(\u0003\u0014\u001D.\u000A(u001F3));
							if (\u001D\u0017\u000A.\u000A(text, text2))
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
								if (parameter != null)
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
									if (!\u0010\u0014\u0007.\u000A(parameter))
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
										if (\u0003\u000F.\u000B(text2, parameter, text))
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
											\u0010\u0009\u0018.\u000A(u001F3, ExcelLineStyle.Thick, ExcelKnownColors.Teal);
											\u0002\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(u001F3), \u000D\u0009\u0018.\u000A());
											\u001C\u0009\u0018.\u000A(\u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(u001F3)), ExcelKnownColors.White);
										}
									}
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
			}
			for (;;)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				goto IL_39E;
			}
		}

		// Token: 0x06001449 RID: 5193 RVA: 0x00083708 File Offset: 0x00081908
		private void DXR(IWorksheet F, int R, List<ParamExportInfo> D)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\PreviewViewModel.cs", "ShowDifference");
			object u001F = \u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A());
			List<Category> list = \u0011\u001C\u0018.\u000A();
			List<Category> list2 = Enumerable.ToList<Category>(Enumerable.Cast<Category>(\u000D\u0001\u001D.\u000A(\u0010\u0001\u001D.\u000A(u001F))));
			\u0020\u0009\u0018.\u000A(list, list2);
			List<Category>.Enumerator enumerator = \u0020\u0002\u0004.\u000A(list2);
			try
			{
				while (\u0011\u0002\u0004.\u000A(ref enumerator))
				{
					Category u001F2 = \u001E\u0002\u0004.\u000A(ref enumerator);
					\u0020\u0009\u0018.\u000A(list, Enumerable.ToList<Category>(Enumerable.Cast<Category>(\u0008\u0001\u001D.\u000A(u001F2))));
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.DXR(IWorksheet, int, List<ParamExportInfo>)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			for (int i = 3; i <= R; i++)
			{
				PreviewViewModel.\u0003\u0003 u0003_u = new PreviewViewModel.\u0003\u0003();
				string u001F3 = \u0003\u0014\u001D.\u000A(\u000F\u000A\u0004.\u000A(F, i, 1));
				if (\u001A\u0006\u0007.\u000A(u001F3))
				{
					IL_210:
					\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\PreviewViewModel.cs", "ShowDifference");
					return;
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
				u0003_u.\u001F = \u0015\u0013\u0007.\u000A(u001F3);
				Category category = Enumerable.FirstOrDefault<Category>(list, new Func<Category, bool>(u0003_u.\u000A));
				if (category != null)
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
					for (int j = 1; j <= \u0008\u0004\u0018.\u000A(D); j++)
					{
						if (!\u001B\u0009\u0018.\u000A(\u001E\u0004\u0018.\u000A(D, j - 1)))
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
							IRange u001F4 = \u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(F), i, j);
							string u001F5 = \u0003\u000B\u001D.\u0007(\u0003\u0014\u001D.\u000A(u001F4));
							string u000A = \u0002\u001C.\u0005(category, \u0014\u0004\u0018.\u0007(\u001E\u0004\u0018.\u000A(D, j - 1)));
							if (\u0002\u001C.\u0003(u001F5, u000A))
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
								\u0010\u0009\u0018.\u000A(u001F4, ExcelLineStyle.Thick, ExcelKnownColors.Teal);
								\u0002\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(u001F4), \u000D\u0009\u0018.\u000A());
								\u001C\u0009\u0018.\u000A(\u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(u001F4)), ExcelKnownColors.White);
							}
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
			}
			for (;;)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				goto IL_210;
			}
		}

		// Token: 0x0600144A RID: 5194 RVA: 0x0008394C File Offset: 0x00081B4C
		private void HXR(object F, ContextMenuEventArgs R)
		{
			if (!this.TW)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.HXR(object, ContextMenuEventArgs)).MethodHandle;
				}
				if (\u0014\u0009\u0018.\u000A(\u0002\u0009\u0018.\u0007(\u001F\u0009\u0018.\u000A(this))) != null)
				{
					\u0001\u0005\u0019.\u000A(\u0010\u000C\u0007.\u000A(\u0014\u0009\u0018.\u000A(\u0002\u0009\u0018.\u0007(\u001F\u0009\u0018.\u000A(this)))), \u0009\u0005\u0019.\u000A());
					this.YXR(\u0014\u0009\u0018.\u000A(\u0002\u0009\u0018.\u0007(\u001F\u0009\u0018.\u000A(this))), \u0013\u0009\u0018.\u000A(), new RoutedEventHandler(this.CXR));
					this.YXR(\u0014\u0009\u0018.\u000A(\u0002\u0009\u0018.\u0007(\u001F\u0009\u0018.\u000A(this))), \u0017\u0009\u0018.\u000A(), new RoutedEventHandler(this.LXR));
					this.TW = true;
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
		}

		// Token: 0x0600144B RID: 5195 RVA: 0x00083A28 File Offset: 0x00081C28
		private void YXR(ContextMenu F, string R, RoutedEventHandler D)
		{
			MenuItem menuItem = \u0002\u0016\u0019.\u000A();
			\u000B\u0016\u0019.\u000A(menuItem, R);
			Image image = \u000C\u0009\u0018.\u000A();
			\u001A\u0009\u0018.\u000A(image, \u0019\u0007\u0019.\u000A(\u0011\u000E\u0004.\u000A("pack://application:,,,/diroots.one;component/SheetLink/Resources/Images/search.png")));
			Image u000A = image;
			\u0005\u0016\u0019.\u000A(menuItem, u000A);
			\u0018\u0016\u0019.\u000A(menuItem, D);
			\u0001\u0005\u0019.\u000A(\u0010\u000C\u0007.\u000A(F), menuItem);
		}

		// Token: 0x0600144C RID: 5196 RVA: 0x00083A84 File Offset: 0x00081C84
		private void CXR(object F, RoutedEventArgs R)
		{
			List<ElementId> list = this.SXR();
			if (\u001A\u0014\u000A.\u000A(list) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.CXR(object, RoutedEventArgs)).MethodHandle;
				}
				\u000D\u001E\u000A.\u000A(\u0010\u001E\u000A.\u0007(\u001F\u0011\u0018.\u000A()), list);
			}
		}

		// Token: 0x0600144D RID: 5197 RVA: 0x00083ACC File Offset: 0x00081CCC
		private void LXR(object F, RoutedEventArgs R)
		{
			List<ElementId> list = this.SXR();
			if (\u001A\u0014\u000A.\u000A(list) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.LXR(object, RoutedEventArgs)).MethodHandle;
				}
				\u000D\u001E\u000A.\u000A(\u0010\u001E\u000A.\u0007(\u001F\u0011\u0018.\u000A()), list);
				\u000E\u0013\u000A.\u000A(\u001F\u0011\u0018.\u000A(), list);
			}
		}

		// Token: 0x0600144E RID: 5198 RVA: 0x00083B24 File Offset: 0x00081D24
		private List<ElementId> SXR()
		{
			object u001F = this.BXR();
			List<string> list = \u0014\u000D\u0007.\u000A();
			List<int>.Enumerator enumerator = \u0009\u0013\u0004.\u000A(u001F);
			try
			{
				while (\u0017\u0013\u0004.\u000A(ref enumerator))
				{
					int u000A = \u0001\u0013\u0004.\u000A(ref enumerator);
					string text = \u001A\u000C\u000A.\u000A(\u0003\u0014\u001D.\u000A(\u000F\u000A\u0004.\u000A(\u0015\u0009\u0018.\u000A(\u001F\u0009\u0018.\u000A(this)), u000A, 1)));
					if (!\u001A\u0006\u0007.\u000A(text))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.SXR()).MethodHandle;
						}
						if (\u001D\u0017\u000A.\u000A(text, "GUID"))
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
							\u001A\u0008\u0007.\u000A(list, text);
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
				((IDisposable)enumerator).Dispose();
			}
			IEnumerable<string> enumerable = list;
			Func<string, Element> func;
			if ((func = PreviewViewModel.<>c.\u0003) == null)
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
				func = (PreviewViewModel.<>c.\u0003 = new Func<string, Element>(PreviewViewModel.<>c.\u001F.\u0009));
			}
			IEnumerable<Element> enumerable2 = Enumerable.Select<string, Element>(enumerable, func);
			Func<Element, bool> func2;
			if ((func2 = PreviewViewModel.<>c.\u001C) == null)
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
				func2 = (PreviewViewModel.<>c.\u001C = new Func<Element, bool>(PreviewViewModel.<>c.\u001F.\u001F\u000A));
			}
			IEnumerable<Element> enumerable3 = Enumerable.Where<Element>(enumerable2, func2);
			Func<Element, ElementId> func3;
			if ((func3 = PreviewViewModel.<>c.\u000D) == null)
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
				func3 = (PreviewViewModel.<>c.\u000D = new Func<Element, ElementId>(PreviewViewModel.<>c.\u001F.\u000A\u000A));
			}
			return Enumerable.ToList<ElementId>(Enumerable.Select<Element, ElementId>(enumerable3, func3));
		}

		// Token: 0x0600144F RID: 5199 RVA: 0x00083C88 File Offset: 0x00081E88
		private List<int> BXR()
		{
			List<int> list = \u0017\u000B\u001D.\u000A();
			if (\u001D\u0017\u000A.\u000A(\u001A\u001A\u001D.\u000A(\u000F\u000A\u0004.\u000A(\u0015\u0009\u0018.\u000A(\u001F\u0009\u0018.\u000A(this)), 2, 1)), "GUID"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.BXR()).MethodHandle;
				}
				if (\u001D\u0017\u000A.\u000A(\u001A\u001A\u001D.\u000A(\u000F\u000A\u0004.\u000A(\u0015\u0009\u0018.\u000A(\u001F\u0009\u0018.\u000A(this)), 3, 1)), "GUID"))
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
					return list;
				}
			}
			List<GridRangeInfo>.Enumerator enumerator = \u0007\u001F\u0005.\u000A(\u001D\u001F\u0005.\u000A(\u0002\u0009\u0018.\u0007(\u001F\u0009\u0018.\u000A(this))));
			try
			{
				while (\u0001\u0009\u0018.\u000A(ref enumerator))
				{
					GridRangeInfo u001F = \u000A\u001F\u0005.\u000A(ref enumerator);
					for (int i = \u001F\u001F\u0005.\u000A(u001F); i <= \u0009\u0009\u0018.\u000A(u001F); i++)
					{
						\u0020\u000B\u001D.\u000A(list, i);
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
			IEnumerable<int> enumerable = Enumerable.Distinct<int>(list);
			Func<int, int> func;
			if ((func = PreviewViewModel.<>c.\u0010) == null)
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
				func = (PreviewViewModel.<>c.\u0010 = new Func<int, int>(PreviewViewModel.<>c.\u001F.\u0007\u000A));
			}
			list = Enumerable.ToList<int>(Enumerable.OrderBy<int, int>(enumerable, func));
			return list;
		}

		// Token: 0x06001450 RID: 5200 RVA: 0x00083DE4 File Offset: 0x00081FE4
		public void UpdateModel()
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\PreviewViewModel.cs", "UpdateModel");
			if (\u001F\u0009\u0018.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.UpdateModel()).MethodHandle;
				}
				Dictionary<DataTable, List<ParamExportInfo>> dictionary = \u0019\u0017\u0018.\u000A();
				if (\u0018\u001F\u0005.\u000A(\u0019\u001F\u0005.\u000A(\u0002\u0009\u0018.\u0007(\u001F\u0009\u0018.\u000A(this)))))
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
					\u0004\u001F\u0005.\u000A(\u0019\u001F\u0005.\u000A(\u0002\u0009\u0018.\u0007(\u001F\u0009\u0018.\u000A(this))));
				}
				\u001B\u0012.\u0002(\u0004\u0009\u0018.\u000A(\u001F\u0009\u0018.\u000A(this)), dictionary, -1);
				if (\u0010\u0017\u0018.\u000A(dictionary) > 0)
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
					\u0020\u0003.\u0019(dictionary, \u0018\u000B\u0007.\u0007(this), this.VW, false);
				}
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\PreviewViewModel.cs", "UpdateModel");
		}

		// Token: 0x06001451 RID: 5201 RVA: 0x00083ECC File Offset: 0x000820CC
		public void Reset()
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\PreviewViewModel.cs", "Reset");
			if (this.PW)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.Reset()).MethodHandle;
				}
				\u0016\u001F\u0005.\u0007(this, this.XW, \u0018\u000B\u0007.\u0007(this), this.VW);
			}
			else if (\u001F\u0009\u0018.\u000A(this) != null)
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
				\u0005\u001F\u0005.\u0007(this, this.ZW, \u0018\u000B\u0007.\u0007(this), this.VW);
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\PreviewViewModel.cs", "Reset");
		}

		// Token: 0x06001452 RID: 5202 RVA: 0x00083F6C File Offset: 0x0008216C
		public void CustomDispose()
		{
			SfSpreadsheet sfSpreadsheet = \u001F\u0009\u0018.\u000A(this);
			if (sfSpreadsheet == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.CustomDispose()).MethodHandle;
				}
			}
			else
			{
				\u0002\u001F\u0005.\u000A(sfSpreadsheet);
			}
			\u000B\u001F\u0005.\u0007(this, \u001C\u0002\u000E.\u001F);
			this.ZW = \u000D\u0002\u000E.\u001F;
			\u0020\u0008\u000A.\u001F(this.HL);
		}

		// Token: 0x040007C9 RID: 1993
		private ProgressModel VW;

		// Token: 0x040007CA RID: 1994
		private SyncfusionControlExcel ZW;

		// Token: 0x040007CB RID: 1995
		private string XW;

		// Token: 0x040007CC RID: 1996
		private string HL;

		// Token: 0x040007CD RID: 1997
		private bool PW;

		// Token: 0x040007CE RID: 1998
		[CompilerGenerated]
		private SfSpreadsheet OW;

		// Token: 0x040007CF RID: 1999
		private bool TW;

		// Token: 0x020008DA RID: 2266
		[CompilerGenerated]
		private sealed class \u0012\u0003
		{
			// Token: 0x060050BD RID: 20669 RVA: 0x001E7838 File Offset: 0x001E5A38
			internal void \u000A()
			{
				\u0004\u000F.\u0016(this.\u001F);
			}

			// Token: 0x04002335 RID: 9013
			public Exception \u001F;
		}

		// Token: 0x020008DB RID: 2267
		[CompilerGenerated]
		private sealed class \u0003\u0003
		{
			// Token: 0x060050BF RID: 20671 RVA: 0x001E7864 File Offset: 0x001E5A64
			internal bool \u000A(Category \u001F)
			{
				return \u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u001F)) == (long)this.\u001F;
			}

			// Token: 0x04002336 RID: 9014
			public int \u001F;
		}
	}
}
