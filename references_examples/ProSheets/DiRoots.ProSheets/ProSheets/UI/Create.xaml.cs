using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Navigation;
using System.Windows.Threading;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.ProSheets.ViewModels;
using ProSheets.Enums;
using ProSheets.Helpers;
using ProSheets.Models;
using ProSheets.ScheduleAssistant.ViewModel;

namespace ProSheets.UI
{
	// Token: 0x02000086 RID: 134
	public partial class Create : BaseUserControl
	{
		// Token: 0x060007EB RID: 2027 RVA: 0x00028AE4 File Offset: 0x00026CE4
		public Create()
		{
			\u0001\u000D\u0003.\u0018(this);
			\u0007\u0018\u0003.\u0018(this.V, new bool?(true));
			\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.K), \u001C\u0009\u0018.\u0001\u0014);
			\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.K), \u001C\u0009\u0018.\u001B\u0014);
			\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.K), \u001C\u0009\u0018.\u0005\u0014);
			\u0018\u0009\u0014.\u0018(this.FB, \u001C\u001E\u0018.\u0018(\u001C\u0009\u0018.\u0002\u0003, "0"));
			\u0003\u0019\u0018.\u0018(this.QB, \u001C\u0017\u0014.\u0018());
		}

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x060007ED RID: 2029 RVA: 0x00028BBC File Offset: 0x00026DBC
		// (set) Token: 0x060007EE RID: 2030 RVA: 0x00028BD0 File Offset: 0x00026DD0
		public static bool CreateLoaded { get; set; }

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x060007EF RID: 2031 RVA: 0x00028BE4 File Offset: 0x00026DE4
		// (set) Token: 0x060007F0 RID: 2032 RVA: 0x00028BF8 File Offset: 0x00026DF8
		public UI_MainWindow CurrentMainWindow { get; set; }

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x060007F1 RID: 2033 RVA: 0x00028C0C File Offset: 0x00026E0C
		// (set) Token: 0x060007F2 RID: 2034 RVA: 0x00028C20 File Offset: 0x00026E20
		public static bool IsCancelledByUser { get; set; }

		// Token: 0x060007F3 RID: 2035 RVA: 0x00028C34 File Offset: 0x00026E34
		public Task loadCreateControl(Document document, List<SheetInfo> selectedRows, UI_MainWindow uI_MainWindow)
		{
			Create.\u0010\u000A\u0018 u0010_u000A_u;
			u0010_u000A_u.\u0018 = \u0006\u0014\u0003.\u0018();
			u0010_u000A_u.\u0014 = this;
			u0010_u000A_u.\u0016 = selectedRows;
			u0010_u000A_u.\u0003 = uI_MainWindow;
			u0010_u000A_u.\u000C = -1;
			u0010_u000A_u.\u0018.Start<Create.\u0010\u000A\u0018>(ref u0010_u000A_u);
			return \u0010\u0014\u0003.\u0018(ref u0010_u000A_u.\u0018);
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x00028C8C File Offset: 0x00026E8C
		public void SetProfileConfig(ExportTemPlateInfo templateInfo)
		{
			if (!\u001F\u001A\u0018.\u0018(\u000C\u001C\u0003.\u0018(\u000E\u000F\u0003.\u0018())))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.SetProfileConfig(ExportTemPlateInfo)).MethodHandle;
				}
				object e = this.E;
				string text = \u000C\u001C\u0003.\u0018(\u000E\u000F\u0003.\u0018());
				string u;
				if (text == null)
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
					u = \u0005\u001E\u000F.\u000C;
				}
				else
				{
					u = \u000E\u000D\u0003.\u0014(text);
				}
				\u0012\u000B\u0018.\u0018(e, u);
			}
			if (!\u001F\u001A\u0018.\u0018(\u0005\u000D\u0003.\u0018(templateInfo)))
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
				\u0012\u000B\u0018.\u0018(this.E, \u0005\u000D\u0003.\u0018(templateInfo));
			}
			\u0007\u0018\u0003.\u0018(this.D, new bool?(\u001B\u000D\u0003.\u0018(templateInfo)));
			\u0007\u0018\u0003.\u0018(this.V, new bool?(!\u001B\u000D\u0003.\u0018(templateInfo)));
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x00028D5C File Offset: 0x00026F5C
		public void GetProfileConfig(ExportTemPlateInfo templateInfo)
		{
			\u0014\u001C\u0003.\u0018(templateInfo, \u0001\u000B\u0018.\u0018(this.E));
			bool? flag = \u001B\u0001\u0018.\u0018(this.D);
			\u0018\u001C\u0003.\u0018(templateInfo, \u000C\u0007\u0018.\u0018(ref flag));
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x00028D9C File Offset: 0x00026F9C
		private void JR(SheetInfo P, string Q)
		{
			if (!\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(P), Q))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.JR(SheetInfo, string)).MethodHandle;
				}
				return;
			}
			bool flag = true;
			\u0006\u000E\u0018.\u0018(P, "");
			if (\u000F\u0002\u0018.\u0018(Q, "DWF"))
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
				flag = false;
				string u;
				if (\u0001\u0008\u0014.\u0018() != 1)
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
					u = "Portrait";
				}
				else
				{
					u = "Landscape";
				}
				\u0006\u000E\u0018.\u0018(P, u);
			}
			List<List<SheetInfo>> u000C = \u0009\u001C\u0003.\u0018();
			\u001C\u001C\u0003.\u0018(u000C, \u0003\u0007\u0014.\u0018());
			\u001C\u001C\u0003.\u0018(u000C, \u0013\u001C\u0003.\u0018());
			\u001C\u001C\u0003.\u0018(u000C, \u0014\u0007\u0014.\u0018());
			List<List<SheetInfo>>.Enumerator enumerator = \u000D\u001C\u0003.\u0018(u000C);
			try
			{
				while (\u0003\u001C\u0003.\u0018(ref enumerator))
				{
					List<SheetInfo>.Enumerator enumerator2 = \u0018\u000C\u0014.\u0018(\u0012\u001C\u0003.\u0018(ref enumerator));
					try
					{
						while (\u0019\u000E\u0018.\u0018(ref enumerator2))
						{
							SheetInfo sheetInfo = \u000C\u000C\u0014.\u0018(ref enumerator2);
							if (sheetInfo == P)
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
									\u000F\u001C\u0003.\u0018(sheetInfo, \u0011\u0017\u0014.\u0014(P));
									return;
								}
								\u0016\u001C\u0003.\u0018(sheetInfo, \u0011\u0017\u0014.\u0014(P));
								return;
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
						((IDisposable)enumerator2).Dispose();
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

		// Token: 0x060007F7 RID: 2039 RVA: 0x00028F1C File Offset: 0x0002711C
		private void FR()
		{
			if (\u0009\u001E\u0018.\u0018(\u0001\u0017\u0014.\u0018(), "Revit Native"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.FR()).MethodHandle;
				}
				return;
			}
			List<PaperSizeInfo> u000C = \u0015\u001C\u0003.\u0018(new \u000A\u0020\u0018());
			List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
			try
			{
				while (\u0019\u000E\u0018.\u0018(ref enumerator))
				{
					SheetInfo sheetInfo = \u000C\u000C\u0014.\u0018(ref enumerator);
					Create.\u0019\u000A\u0018 u0019_u000A_u = new Create.\u0019\u000A\u0018();
					if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "PDF"))
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
						if (\u0004\u0017\u0014.\u0018(sheetInfo) == null)
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
							\u0005\u000E\u0018.\u0018(sheetInfo, "");
						}
						else
						{
							u0019_u000A_u.\u000C = \u0012\u0002\u0018.\u0018(\u0004\u0017\u0014.\u0018(sheetInfo));
							\u0008\u0002\u0014.\u0018(sheetInfo, \u0004\u0017\u0014.\u0018(sheetInfo));
							if (\u000A\u0017\u0014.\u0018(u0019_u000A_u.\u000C, "x"))
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
								if (sheetInfo.\u0014())
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
									object u000C2 = u0019_u000A_u.\u000C;
									char[] array = \u0020\u0002\u000F.\u000C(1);
									array[0] = 'x';
									List<string> u000C3 = Enumerable.ToList<string>(\u0011\u001C\u0003.\u0018(u000C2, array));
									if (\u0001\u0015\u0014.\u0018(u000C3) == 2)
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
										u0019_u000A_u.\u000C = \u0014\u001E\u0018.\u0018(\u0006\u0005\u0018.\u0018(u000C3, 1), "x", \u0006\u0005\u0018.\u0018(u000C3, 0));
									}
								}
								Create.\u0019\u000A\u0018 u0019_u000A_u2 = u0019_u000A_u;
								PaperSizeInfo paperSizeInfo = \u001F\u001C\u0003.\u0018(u000C, new Predicate<PaperSizeInfo>(u0019_u000A_u.\u0018));
								string u000C4;
								if (paperSizeInfo == null)
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
									u000C4 = \u0005\u001E\u000F.\u000C;
								}
								else
								{
									u000C4 = \u000A\u001C\u0003.\u0003(paperSizeInfo);
								}
								u0019_u000A_u2.\u000C = u000C4;
							}
							else
							{
								Create.\u0019\u000A\u0018 u0019_u000A_u3 = u0019_u000A_u;
								PaperSizeInfo paperSizeInfo2 = \u001F\u001C\u0003.\u0018(u000C, new Predicate<PaperSizeInfo>(u0019_u000A_u.\u0014));
								string u000C5;
								if (paperSizeInfo2 == null)
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
									u000C5 = \u0005\u001E\u000F.\u000C;
								}
								else
								{
									u000C5 = \u000A\u001C\u0003.\u0003(paperSizeInfo2);
								}
								u0019_u000A_u3.\u000C = u000C5;
							}
							if (u0019_u000A_u.\u000C == null)
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
								u0019_u000A_u.\u000C = \u000A\u001C\u0003.\u0014(\u0020\u001C\u0003.\u0018(u000C, 0));
							}
							\u0005\u000E\u0018.\u0018(sheetInfo, u0019_u000A_u.\u000C);
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
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x00029168 File Offset: 0x00027368
		private void RR()
		{
			\u000F\u0020\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.BB));
			\u000F\u0020\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.PB));
			\u001E\u001F\u0018.\u0018(this.PB, new RoutedEventHandler(this.Item_Click));
			\u001E\u001F\u0018.\u000C(this.BB, new RoutedEventHandler(this.ItemOrientation_Click));
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x000291C8 File Offset: 0x000273C8
		private void ItemOrientation_Click(object sender, RoutedEventArgs e)
		{
			string u = \u0001\u0017\u0018.\u0018(\u000D\u0016\u0003.\u0018(\u0013\u0019\u000F.\u000C(sender)));
			bool flag = false;
			bool flag2 = false;
			List<SheetInfo> u000C = Enumerable.ToList<SheetInfo>(Enumerable.Cast<SheetInfo>(\u0014\u000F\u0014.\u0018(this.QB)));
			Action<SheetInfo> u2;
			if ((u2 = Create.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.ItemOrientation_Click(object, RoutedEventArgs)).MethodHandle;
				}
				u2 = (Create.<>c.\u0018 = new Action<SheetInfo>(Create.<>c.\u000C.\u0011));
			}
			\u0020\u0005\u0018.\u0018(u000C, u2);
			List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(u000C);
			try
			{
				while (\u0019\u000E\u0018.\u0018(ref enumerator))
				{
					SheetInfo sheetInfo = \u000C\u000C\u0014.\u0018(ref enumerator);
					if (\u0002\u001C\u0003.\u0018(sheetInfo))
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
						if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "DWF"))
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
									switch (2)
									{
									case 0:
										continue;
									}
									break;
								}
								flag2 = true;
							}
						}
						if (!\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "PDF"))
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
							if (!\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "DWF"))
							{
								continue;
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
						\u0006\u000E\u0018.\u0018(sheetInfo, u);
						bool flag3 = false;
						List<SheetInfo>.Enumerator enumerator2 = \u0018\u000C\u0014.\u0018(\u0003\u0007\u0014.\u0018());
						try
						{
							while (\u0019\u000E\u0018.\u0018(ref enumerator2))
							{
								SheetInfo sheetInfo2 = \u000C\u000C\u0014.\u0018(ref enumerator2);
								if (sheetInfo2 == sheetInfo)
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
									flag3 = true;
									if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "PDF"))
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
										\u000F\u001C\u0003.\u0018(sheetInfo2, u);
									}
									else if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "DWF"))
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
										\u0016\u001C\u0003.\u0018(sheetInfo2, u);
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
							((IDisposable)enumerator2).Dispose();
						}
						\u0013\u0017\u0014.\u0018(1);
						if (!flag3)
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
							enumerator2 = \u0018\u000C\u0014.\u0018(\u0013\u001C\u0003.\u0018());
							try
							{
								while (\u0019\u000E\u0018.\u0018(ref enumerator2))
								{
									SheetInfo sheetInfo3 = \u000C\u000C\u0014.\u0018(ref enumerator2);
									if (sheetInfo3 == sheetInfo)
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
										flag3 = true;
										if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "PDF"))
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
											\u000F\u001C\u0003.\u0018(sheetInfo3, u);
										}
										else if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "DWF"))
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
											\u0016\u001C\u0003.\u0018(sheetInfo3, u);
										}
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
								((IDisposable)enumerator2).Dispose();
							}
						}
						\u0013\u0017\u0014.\u0018(1);
						if (!flag3)
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
							enumerator2 = \u0018\u000C\u0014.\u0018(\u0014\u0007\u0014.\u0018());
							try
							{
								while (\u0019\u000E\u0018.\u0018(ref enumerator2))
								{
									SheetInfo sheetInfo4 = \u000C\u000C\u0014.\u0018(ref enumerator2);
									if (sheetInfo4 == sheetInfo)
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
										if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "PDF"))
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
											\u000F\u001C\u0003.\u0018(sheetInfo4, u);
										}
										else if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "DWF"))
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
											\u0016\u001C\u0003.\u0018(sheetInfo4, u);
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
				enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
				try
				{
					while (\u0019\u000E\u0018.\u0018(ref enumerator))
					{
						SheetInfo sheetInfo5 = \u000C\u000C\u0014.\u0018(ref enumerator);
						if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo5), "PDF"))
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
							\u0006\u000E\u0018.\u0018(sheetInfo5, u);
							bool flag4 = false;
							List<SheetInfo>.Enumerator enumerator2 = \u0018\u000C\u0014.\u0018(\u0003\u0007\u0014.\u0018());
							try
							{
								while (\u0019\u000E\u0018.\u0018(ref enumerator2))
								{
									SheetInfo sheetInfo6 = \u000C\u000C\u0014.\u0018(ref enumerator2);
									if (sheetInfo6 == sheetInfo5)
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
										if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo5), "PDF"))
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
											\u000F\u001C\u0003.\u0018(sheetInfo6, u);
										}
										else if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo5), "DWF"))
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
											\u0016\u001C\u0003.\u0018(sheetInfo6, u);
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
								((IDisposable)enumerator2).Dispose();
							}
							\u0013\u0017\u0014.\u0018(1);
							if (!flag4)
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
								enumerator2 = \u0018\u000C\u0014.\u0018(\u0013\u001C\u0003.\u0018());
								try
								{
									while (\u0019\u000E\u0018.\u0018(ref enumerator2))
									{
										SheetInfo sheetInfo7 = \u000C\u000C\u0014.\u0018(ref enumerator2);
										if (sheetInfo7 == sheetInfo5)
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
											flag4 = true;
											if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo5), "PDF"))
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
												\u000F\u001C\u0003.\u0018(sheetInfo7, u);
											}
											else if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo5), "DWF"))
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
												\u0016\u001C\u0003.\u0018(sheetInfo7, u);
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
									((IDisposable)enumerator2).Dispose();
								}
							}
							\u0013\u0017\u0014.\u0018(1);
							if (!flag4)
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
								enumerator2 = \u0018\u000C\u0014.\u0018(\u0014\u0007\u0014.\u0018());
								try
								{
									while (\u0019\u000E\u0018.\u0018(ref enumerator2))
									{
										SheetInfo sheetInfo8 = \u000C\u000C\u0014.\u0018(ref enumerator2);
										if (sheetInfo8 == sheetInfo5)
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
											if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo5), "PDF"))
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
												\u000F\u001C\u0003.\u0018(sheetInfo8, u);
											}
											else if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo5), "DWF"))
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
												\u0016\u001C\u0003.\u0018(sheetInfo8, u);
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
									((IDisposable)enumerator2).Dispose();
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
					((IDisposable)enumerator).Dispose();
				}
			}
			if (flag2)
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
				enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
				try
				{
					while (\u0019\u000E\u0018.\u0018(ref enumerator))
					{
						SheetInfo sheetInfo9 = \u000C\u000C\u0014.\u0018(ref enumerator);
						if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo9), "DWF"))
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
							\u0006\u000E\u0018.\u0018(sheetInfo9, u);
							bool flag5 = false;
							List<SheetInfo>.Enumerator enumerator2 = \u0018\u000C\u0014.\u0018(\u0003\u0007\u0014.\u0018());
							try
							{
								while (\u0019\u000E\u0018.\u0018(ref enumerator2))
								{
									SheetInfo sheetInfo10 = \u000C\u000C\u0014.\u0018(ref enumerator2);
									if (sheetInfo10 == sheetInfo9)
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
										flag5 = true;
										if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo9), "PDF"))
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
											\u000F\u001C\u0003.\u0018(sheetInfo10, u);
										}
										else if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo9), "DWF"))
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
											\u0016\u001C\u0003.\u0018(sheetInfo10, u);
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
								((IDisposable)enumerator2).Dispose();
							}
							\u0013\u0017\u0014.\u0018(1);
							if (!flag5)
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
								enumerator2 = \u0018\u000C\u0014.\u0018(\u0013\u001C\u0003.\u0018());
								try
								{
									while (\u0019\u000E\u0018.\u0018(ref enumerator2))
									{
										SheetInfo sheetInfo11 = \u000C\u000C\u0014.\u0018(ref enumerator2);
										if (sheetInfo11 == sheetInfo9)
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
											flag5 = true;
											if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo9), "PDF"))
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
												\u000F\u001C\u0003.\u0018(sheetInfo11, u);
											}
											else if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo9), "DWF"))
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
												\u0016\u001C\u0003.\u0018(sheetInfo11, u);
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
							\u0013\u0017\u0014.\u0018(1);
							if (!flag5)
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
								enumerator2 = \u0018\u000C\u0014.\u0018(\u0014\u0007\u0014.\u0018());
								try
								{
									while (\u0019\u000E\u0018.\u0018(ref enumerator2))
									{
										SheetInfo sheetInfo12 = \u000C\u000C\u0014.\u0018(ref enumerator2);
										if (sheetInfo12 == sheetInfo9)
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
											if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo9), "PDF"))
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
												\u000F\u001C\u0003.\u0018(sheetInfo12, u);
											}
											else if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo9), "DWF"))
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
												\u0016\u001C\u0003.\u0018(sheetInfo12, u);
											}
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
									((IDisposable)enumerator2).Dispose();
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
					((IDisposable)enumerator).Dispose();
				}
			}
			try
			{
				\u001E\u001C\u0003.\u0018(\u000D\u000F\u0014.\u0018(this.QB));
				\u0017\u001C\u0003.\u0014(\u001E\u000C\u0014.\u0003(\u0020\u0019\u000F.\u000C(\u0003\u0012\u0014.\u0003(this))));
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x00029C10 File Offset: 0x00027E10
		private void Item_Click(object sender, RoutedEventArgs e)
		{
			this.LR(\u0001\u0017\u0018.\u0018(\u000D\u0016\u0003.\u0018(\u0013\u0019\u000F.\u000C(sender))));
		}

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x060007FB RID: 2043 RVA: 0x00029C3C File Offset: 0x00027E3C
		// (remove) Token: 0x060007FC RID: 2044 RVA: 0x00029C88 File Offset: 0x00027E88
		public event Create.ExportEndedHandler ExportEnded
		{
			[CompilerGenerated]
			add
			{
				Create.ExportEndedHandler exportEndedHandler = this.S;
				Create.ExportEndedHandler exportEndedHandler2;
				do
				{
					exportEndedHandler2 = exportEndedHandler;
					Create.ExportEndedHandler value2 = (Create.ExportEndedHandler)\u001C\u0019\u0018.\u0018(exportEndedHandler2, value);
					exportEndedHandler = Interlocked.CompareExchange<Create.ExportEndedHandler>(ref this.S, value2, exportEndedHandler2);
				}
				while (exportEndedHandler != exportEndedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.add_ExportEnded(Create.ExportEndedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				Create.ExportEndedHandler exportEndedHandler = this.S;
				Create.ExportEndedHandler exportEndedHandler2;
				do
				{
					exportEndedHandler2 = exportEndedHandler;
					Create.ExportEndedHandler value2 = (Create.ExportEndedHandler)\u0013\u0019\u0018.\u0018(exportEndedHandler2, value);
					exportEndedHandler = Interlocked.CompareExchange<Create.ExportEndedHandler>(ref this.S, value2, exportEndedHandler2);
				}
				while (exportEndedHandler != exportEndedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.remove_ExportEnded(Create.ExportEndedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x060007FD RID: 2045 RVA: 0x00029CD4 File Offset: 0x00027ED4
		// (remove) Token: 0x060007FE RID: 2046 RVA: 0x00029D20 File Offset: 0x00027F20
		public event Create.ProgressReceivedHandler ProgressReceived
		{
			[CompilerGenerated]
			add
			{
				Create.ProgressReceivedHandler progressReceivedHandler = this.U;
				Create.ProgressReceivedHandler progressReceivedHandler2;
				do
				{
					progressReceivedHandler2 = progressReceivedHandler;
					Create.ProgressReceivedHandler value2 = (Create.ProgressReceivedHandler)\u001C\u0019\u0018.\u0018(progressReceivedHandler2, value);
					progressReceivedHandler = Interlocked.CompareExchange<Create.ProgressReceivedHandler>(ref this.U, value2, progressReceivedHandler2);
				}
				while (progressReceivedHandler != progressReceivedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.add_ProgressReceived(Create.ProgressReceivedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				Create.ProgressReceivedHandler progressReceivedHandler = this.U;
				Create.ProgressReceivedHandler progressReceivedHandler2;
				do
				{
					progressReceivedHandler2 = progressReceivedHandler;
					Create.ProgressReceivedHandler value2 = (Create.ProgressReceivedHandler)\u0013\u0019\u0018.\u0018(progressReceivedHandler2, value);
					progressReceivedHandler = Interlocked.CompareExchange<Create.ProgressReceivedHandler>(ref this.U, value2, progressReceivedHandler2);
				}
				while (progressReceivedHandler != progressReceivedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.remove_ProgressReceived(Create.ProgressReceivedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x00029D6C File Offset: 0x00027F6C
		public Task ExportFiles(bool isTryAgain)
		{
			Create.\u0007\u000A\u0018 u0007_u000A_u;
			u0007_u000A_u.\u0018 = \u0006\u0014\u0003.\u0018();
			u0007_u000A_u.\u0014 = this;
			u0007_u000A_u.\u0003 = isTryAgain;
			u0007_u000A_u.\u000C = -1;
			u0007_u000A_u.\u0018.Start<Create.\u0007\u000A\u0018>(ref u0007_u000A_u);
			return \u0010\u0014\u0003.\u0018(ref u0007_u000A_u.\u0018);
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x00029DBC File Offset: 0x00027FBC
		private void HR()
		{
			this.OR();
			\u0004\u001C\u0003.\u0018(\u0005\u0014\u0003.\u0014(this), new Create.\u000B\u000A\u0018(this.NR), Array.Empty<object>());
			object u000C = \u0005\u0014\u0003.\u0014(this);
			DispatcherPriority u = DispatcherPriority.Background;
			Action u2;
			if ((u2 = Create.<>c.\u0003) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.HR()).MethodHandle;
				}
				u2 = (Create.<>c.\u0003 = new Action(Create.<>c.\u000C.\u0017));
			}
			\u001B\u0014\u0003.\u0018(u000C, u, u2);
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x00029E38 File Offset: 0x00028038
		private void NR()
		{
			try
			{
				IEnumerable<SheetInfo> enumerable = Enumerable.Cast<SheetInfo>(\u000D\u000F\u0014.\u0018(this.QB));
				IEnumerable<SheetInfo> enumerable2 = enumerable;
				Func<SheetInfo, bool> func;
				if ((func = Create.<>c.\u0016) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Create.NR()).MethodHandle;
					}
					func = (Create.<>c.\u0016 = new Func<SheetInfo, bool>(Create.<>c.\u000C.\u001E));
				}
				if (Enumerable.Count<SheetInfo>(enumerable2, func) != Enumerable.Count<SheetInfo>(enumerable))
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
					UI_MainWindow ui_MainWindow = \u001A\u001C\u0003.\u0018(this);
					bool flag;
					if (ui_MainWindow == null)
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
						flag = false;
					}
					else
					{
						flag = \u001D\u0014\u0003.\u0003(ui_MainWindow);
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
						\u0014\u001A\u0018.\u0018(\u001C\u0009\u0018.\u001A\u0018);
					}
				}
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Create.xaml.cs", "InterruptedByUser");
			}
			Create.ExportEndedHandler s = this.S;
			if (s == null)
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
			\u001D\u001C\u0003.\u0018(s);
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x00029F2C File Offset: 0x0002812C
		private void ZR(int P)
		{
			if (this.U != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.ZR(int)).MethodHandle;
				}
				\u000B\u001C\u0003.\u0018(this.U);
			}
			object u000C = \u0005\u0014\u0003.\u0014(this);
			Delegate u = new Create.\u001A\u000A\u0018(this.MR);
			object[] array = \u0008\u001E\u000F.\u000C(1);
			array[0] = P;
			\u0004\u001C\u0003.\u0018(u000C, u, array);
			object u000C2 = \u0005\u0014\u0003.\u0014(this);
			DispatcherPriority u2 = DispatcherPriority.Background;
			Action u3;
			if ((u3 = Create.<>c.\u000F) == null)
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
				u3 = (Create.<>c.\u000F = new Action(Create.<>c.\u000C.\u0002));
			}
			\u001B\u0014\u0003.\u0018(u000C2, u2, u3);
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x00029FC8 File Offset: 0x000281C8
		private void MR(int P)
		{
			\u0019\u001C\u0003.\u0018(this.JB, \u0007\u001C\u0003.\u0018(\u0010\u001E\u0018.\u0018(ref P)));
			\u0018\u0009\u0014.\u0018(this.FB, \u001C\u001E\u0018.\u0018(\u001C\u0009\u0018.\u0002\u0003, \u0010\u001E\u0018.\u0018(ref P)));
			if (P == 100)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.MR(int)).MethodHandle;
				}
				\u0018\u0009\u0014.\u0018(this.FB, \u001C\u001E\u0018.\u0018(\u001C\u0009\u0018.\u0002\u0003, "100"));
			}
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x0002A048 File Offset: 0x00028248
		private void XR(string P)
		{
			this.OR();
			object u000C = \u0005\u0014\u0003.\u0014(this);
			Delegate u = new Create.\u001D\u000A\u0018(this.YR);
			object[] array = \u0008\u001E\u000F.\u000C(1);
			array[0] = P;
			\u0004\u001C\u0003.\u0018(u000C, u, array);
			object u000C2 = \u0005\u0014\u0003.\u0014(this);
			DispatcherPriority u2 = DispatcherPriority.Background;
			Action u3;
			if ((u3 = Create.<>c.\u0012) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.XR(string)).MethodHandle;
				}
				u3 = (Create.<>c.\u0012 = new Action(Create.<>c.\u000C.\u0004));
			}
			\u001B\u0014\u0003.\u0018(u000C2, u2, u3);
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x0002A0C8 File Offset: 0x000282C8
		private void YR(string P)
		{
			\u0014\u001A\u0018.\u0018(\u0014\u001E\u0018.\u0018(\u001C\u0009\u0018.\u0002\u0018, "\n", P));
			Create.ExportEndedHandler s = this.S;
			if (s == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.YR(string)).MethodHandle;
				}
				return;
			}
			\u001D\u001C\u0003.\u0018(s);
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x0002A114 File Offset: 0x00028314
		private void OR()
		{
			\u001B\u001C\u0003.\u0018(ExportExternalEvent.HandlerInstance, new ExportExternalEvent.ExportNeedsCleanPrinterHandler(this.IR));
			\u0001\u001C\u0003.\u0018(ExportExternalEvent.HandlerInstance, new ExportExternalEvent.ExportFinishedHandler(this.CR));
			\u0008\u001C\u0003.\u0018(ExportExternalEvent.HandlerInstance, new ExportExternalEvent.ShouldClosePDFHandler(this.XR));
			\u0006\u001C\u0003.\u0018(ExportExternalEvent.HandlerInstance, new ExportExternalEvent.ExportProgressHandler(this.ZR));
			\u0010\u001C\u0003.\u0018(ExportExternalEvent.HandlerInstance, new ExportExternalEvent.InterruptedByUserHandler(this.HR));
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x0002A190 File Offset: 0x00028390
		private void CR(DateTime P, DateTime Q, DateTime J, DateTime F, DateTime H, DateTime N, DateTime Z, DateTime M)
		{
			this.OR();
			object u000C = \u0005\u0014\u0003.\u0014(this);
			Delegate u = new Create.\u0004\u000A\u0018(this.TR);
			object[] array = \u0008\u001E\u000F.\u000C(8);
			array[0] = P;
			array[1] = Q;
			array[2] = J;
			array[3] = F;
			array[4] = H;
			array[5] = N;
			array[6] = Z;
			array[7] = M;
			\u0004\u001C\u0003.\u0018(u000C, u, array);
			object u000C2 = \u0005\u0014\u0003.\u0014(this);
			DispatcherPriority u2 = DispatcherPriority.Background;
			Action u3;
			if ((u3 = Create.<>c.\u000D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.CR(DateTime, DateTime, DateTime, DateTime, DateTime, DateTime, DateTime, DateTime)).MethodHandle;
				}
				u3 = (Create.<>c.\u000D = new Action(Create.<>c.\u000C.\u001D));
			}
			\u001B\u0014\u0003.\u0018(u000C2, u2, u3);
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x0002A258 File Offset: 0x00028458
		internal void WR()
		{
			if (this.T)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.WR()).MethodHandle;
				}
				return;
			}
			IEnumerable<SheetInfo> enumerable = \u001C\u0017\u0014.\u0018();
			Func<SheetInfo, bool> func;
			if ((func = Create.<>c.\u001C) == null)
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
				func = (Create.<>c.\u001C = new Func<SheetInfo, bool>(Create.<>c.\u000C.\u001A));
			}
			\u001E\u0011\u0018.\u0017(Enumerable.Count<SheetInfo>(enumerable, func), IocContainer.GetService<ICustomLogger>());
			\u001E\u0011\u0018.\u0002(this.HB, this.NB);
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x0002A2D8 File Offset: 0x000284D8
		private void TR(DateTime P, DateTime Q, DateTime J, DateTime F, DateTime H, DateTime N, DateTime Z, DateTime M)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Create.xaml.cs", "ExportFinished");
			bool flag = true;
			bool u000C = false;
			string u = "";
			string text = \u0015\u0010\u0014.\u0018();
			while (!\u0012\u0006\u0018.\u0018(text))
			{
				text = \u0019\u001E\u0018.\u0018(text);
				if (\u001F\u001A\u0018.\u0018(text))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Create.TR(DateTime, DateTime, DateTime, DateTime, DateTime, DateTime, DateTime, DateTime)).MethodHandle;
					}
					text = \u0015\u0010\u0014.\u0018();
					IL_6E:
					if (\u000F\u0002\u0018.\u0018(\u0005\u000A\u0014.\u0018(this.K), \u001C\u0009\u0018.\u0001\u0014))
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
						flag = false;
					}
					else if (\u000F\u0002\u0018.\u0018(\u0005\u000A\u0014.\u0018(this.K), \u001C\u0009\u0018.\u0005\u0014))
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
						u000C = true;
						u = \u0003\u001A\u0018.\u0018(text, "ProSheets Report.csv");
					}
					else if (\u000F\u0002\u0018.\u0018(\u0005\u000A\u0014.\u0018(this.K), \u001C\u0009\u0018.\u001B\u0014))
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
						u = \u0003\u001A\u0018.\u0018(text, "ProSheets Report.xlsx");
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
						try
						{
							\u0009\u001F\u0018.\u000C(u000C, u, P, Q, J, F, H, N, Z, M);
						}
						catch (Exception u2)
						{
							\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Create.xaml.cs", "ExportFinished");
						}
					}
					\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Showing export completed message", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Create.xaml.cs", "ExportFinished");
					ExportFinished u000C2 = \u001E\u0019\u000F.\u000C;
					IEnumerable<SheetInfo> enumerable = Enumerable.OfType<SheetInfo>(\u0008\u0012\u0014.\u0018(this.QB));
					Func<SheetInfo, bool> func;
					if ((func = Create.<>c.\u0013) == null)
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
						func = (Create.<>c.\u0013 = new Func<SheetInfo, bool>(Create.<>c.\u000C.\u000B));
					}
					if (Enumerable.All<SheetInfo>(enumerable, func))
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
						u000C2 = \u0018\u0013\u0003.\u0018(\u000D\u0009\u0018.\u000E\u0014, "", \u000D\u0009\u0018.\u0019\u0003, \u000D\u0009\u0018.\u0017\u0003, \u0014\u0013\u0003.\u0018(this));
					}
					else
					{
						u000C2 = \u0018\u0013\u0003.\u0018(\u000D\u0009\u0018.\u0005\u0014, text, \u000D\u0009\u0018.\u000C\u0003, \u000D\u0009\u0018.\u0015\u0003, \u0014\u0013\u0003.\u0018(this));
					}
					\u0012\u000A\u0014.\u0018(u000C2, this);
					if (!this.ER(\u001F\u0002\u000F.\u000C))
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
						\u000C\u0013\u0003.\u0018(u000C2);
					}
					\u000E\u001C\u0003.\u0018(u000C2, SizeToContent.Width);
					\u001E\u0007\u0018.\u0014(u000C2);
					\u0005\u001C\u0003.\u0018(this.QB, true);
					if (this.S != null)
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
						\u001D\u001C\u0003.\u0018(this.S);
					}
					\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Create.xaml.cs", "ExportFinished");
					return;
				}
			}
			for (;;)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				goto IL_6E;
			}
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x0002A578 File Offset: 0x00028778
		private void IR()
		{
			\u0004\u001C\u0003.\u0018(\u0005\u0014\u0003.\u0014(this), new Create.\u0002\u000A\u0018(this.SR), Array.Empty<object>());
			object u000C = \u0005\u0014\u0003.\u0014(this);
			DispatcherPriority u = DispatcherPriority.Background;
			Action u2;
			if ((u2 = Create.<>c.\u0009) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.IR()).MethodHandle;
				}
				u2 = (Create.<>c.\u0009 = new Action(Create.<>c.\u000C.\u0019));
			}
			\u001B\u0014\u0003.\u0018(u000C, u, u2);
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x0002A5EC File Offset: 0x000287EC
		private void SR()
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Create.xaml.cs", "ExportNeedsCleanPrinter");
			CleanPrinterQueue u000C = \u0003\u0013\u0003.\u0018();
			\u0012\u000A\u0014.\u0018(u000C, this);
			\u001E\u0007\u0018.\u0014(u000C);
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x0002A628 File Offset: 0x00028828
		private void UR()
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Create.xaml.cs", "ResetToDefaults");
			\u0019\u001C\u0003.\u0018(this.JB, 0.0);
			List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
			try
			{
				while (\u0019\u000E\u0018.\u0018(ref enumerator))
				{
					SheetInfo u000C = \u000C\u000C\u0014.\u0018(ref enumerator);
					\u000C\u0017\u0014.\u0018(u000C, PublishStatus.None);
					\u0018\u0017\u0014.\u0014(u000C, "");
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.UR()).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u0016\u0013\u0003.\u0018();
			\u0002\u0015\u0014.\u0018(false);
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Create.xaml.cs", "ResetToDefaults");
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x0002A6EC File Offset: 0x000288EC
		public void FocusFolderTextBox()
		{
			\u000A\u000B\u0018.\u0014(this.E);
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x0002A708 File Offset: 0x00028908
		private void BtnFileSave_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Create.xaml.cs", "BtnFileSave_Click");
				FolderBrowserDialog folderBrowserDialog = \u0017\u000B\u0018.\u0018();
				try
				{
					\u0015\u000B\u0018.\u0018(folderBrowserDialog, \u0001\u000B\u0018.\u0018(this.E));
					if (\u000F\u0002\u0018.\u0018(\u0011\u000B\u0018.\u0018(folderBrowserDialog).ToString(), "OK"))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(Create.BtnFileSave_Click(object, RoutedEventArgs)).MethodHandle;
						}
						\u0012\u000B\u0018.\u0018(this.E, \u000D\u001E\u0018.\u0018(\u0020\u000B\u0018.\u0018(folderBrowserDialog), "\\"));
						\u0010\u0017\u0014.\u0018(\u0001\u000B\u0018.\u0018(this.E));
						\u0012\u001D\u0014.\u0018(\u0015\u0010\u0014.\u0018());
						\u000F\u0013\u0003.\u0018(\u000E\u000F\u0003.\u0018(), \u0015\u0010\u0014.\u0018());
					}
				}
				finally
				{
					if (folderBrowserDialog != null)
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
						\u0020\u001E\u0018.\u0018(folderBrowserDialog);
					}
				}
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Create.xaml.cs", "BtnFileSave_Click");
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Create.xaml.cs", "BtnFileSave_Click");
			}
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x0002A830 File Offset: 0x00028A30
		private void RdbSameFolder_Checked(object sender, RoutedEventArgs e)
		{
			\u000D\u0013\u0003.\u0018(false);
			\u0012\u0013\u0003.\u0018(\u000E\u000F\u0003.\u0018(), false);
			MainWindowModel mainWindowModel = \u0020\u0019\u000F.\u000C(\u0003\u0012\u0014.\u0003(this));
			if (mainWindowModel == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.RdbSameFolder_Checked(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			ScheduleViewModel scheduleViewModel = \u001E\u000C\u0014.\u0014(mainWindowModel);
			if (scheduleViewModel == null)
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
			\u0017\u001C\u0003.\u0003(scheduleViewModel);
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x0002A894 File Offset: 0x00028A94
		private void RdbSplitFolder_Checked(object sender, RoutedEventArgs e)
		{
			\u000D\u0013\u0003.\u0018(true);
			\u0012\u0013\u0003.\u0018(\u000E\u000F\u0003.\u0018(), true);
			MainWindowModel mainWindowModel = \u0020\u0019\u000F.\u000C(\u0003\u0012\u0014.\u0003(this));
			if (mainWindowModel == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.RdbSplitFolder_Checked(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			ScheduleViewModel scheduleViewModel = \u001E\u000C\u0014.\u0014(mainWindowModel);
			if (scheduleViewModel == null)
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
				return;
			}
			\u0017\u001C\u0003.\u0003(scheduleViewModel);
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x0002A8F8 File Offset: 0x00028AF8
		private void TxtFileSave_TextChanged(object sender, TextChangedEventArgs e)
		{
			string text = \u0001\u000B\u0018.\u0018(this.E);
			string text2;
			if (text == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.TxtFileSave_TextChanged(object, TextChangedEventArgs)).MethodHandle;
				}
				text2 = null;
			}
			else
			{
				text2 = \u000E\u000D\u0003.\u0014(text);
			}
			string text3;
			if ((text3 = text2) == null)
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
				text3 = string.Empty;
			}
			string text4 = text3;
			\u0010\u0017\u0014.\u0018(text4);
			\u000F\u0013\u0003.\u0018(\u000E\u000F\u0003.\u0018(), text4);
			if (\u001F\u001A\u0018.\u0018(text4))
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
				\u0012\u001D\u0014.\u0018(\u0015\u0010\u0014.\u0018());
			}
			MainWindowModel mainWindowModel = \u0020\u0019\u000F.\u000C(\u0003\u0012\u0014.\u0003(this));
			if (mainWindowModel == null)
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
			ScheduleViewModel scheduleViewModel = \u001E\u000C\u0014.\u0014(mainWindowModel);
			if (scheduleViewModel == null)
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
			\u0017\u001C\u0003.\u0003(scheduleViewModel);
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x0002A9B4 File Offset: 0x00028BB4
		private void LR(string P)
		{
			List<SheetInfo> u000C = Enumerable.ToList<SheetInfo>(Enumerable.Cast<SheetInfo>(\u0014\u000F\u0014.\u0018(this.QB)));
			Action<SheetInfo> u;
			if ((u = Create.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.LR(string)).MethodHandle;
				}
				u = (Create.<>c.\u000A = new Action<SheetInfo>(Create.<>c.\u000C.\u0007));
			}
			\u0020\u0005\u0018.\u0018(u000C, u);
			List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(u000C);
			try
			{
				while (\u0019\u000E\u0018.\u0018(ref enumerator))
				{
					SheetInfo sheetInfo = \u000C\u000C\u0014.\u0018(ref enumerator);
					if (\u0002\u001C\u0003.\u0018(sheetInfo))
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
						if (\u000F\u0002\u0018.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "PDF"))
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
							\u0005\u000E\u0018.\u0018(sheetInfo, P);
							\u0008\u0002\u0014.\u0018(sheetInfo, P);
							bool flag = false;
							List<SheetInfo>.Enumerator enumerator2 = \u0018\u000C\u0014.\u0018(\u0003\u0007\u0014.\u0018());
							try
							{
								while (\u0019\u000E\u0018.\u0018(ref enumerator2))
								{
									SheetInfo sheetInfo2 = \u000C\u000C\u0014.\u0018(ref enumerator2);
									if (sheetInfo2 == sheetInfo)
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
										\u001C\u0013\u0003.\u0018(sheetInfo2, P);
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
								((IDisposable)enumerator2).Dispose();
							}
							\u0013\u0017\u0014.\u0018(1);
							if (!flag)
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
								enumerator2 = \u0018\u000C\u0014.\u0018(\u0013\u001C\u0003.\u0018());
								try
								{
									while (\u0019\u000E\u0018.\u0018(ref enumerator2))
									{
										SheetInfo sheetInfo3 = \u000C\u000C\u0014.\u0018(ref enumerator2);
										if (sheetInfo3 == sheetInfo)
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
											flag = true;
											\u001C\u0013\u0003.\u0018(sheetInfo3, P);
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
									((IDisposable)enumerator2).Dispose();
								}
							}
							\u0013\u0017\u0014.\u0018(1);
							if (!flag)
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
								enumerator2 = \u0018\u000C\u0014.\u0018(\u0014\u0007\u0014.\u0018());
								try
								{
									while (\u0019\u000E\u0018.\u0018(ref enumerator2))
									{
										SheetInfo sheetInfo4 = \u000C\u000C\u0014.\u0018(ref enumerator2);
										if (sheetInfo4 == sheetInfo)
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
											flag = true;
											\u001C\u0013\u0003.\u0018(sheetInfo4, P);
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
									((IDisposable)enumerator2).Dispose();
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
				((IDisposable)enumerator).Dispose();
			}
			try
			{
				\u001E\u001C\u0003.\u0018(\u000D\u000F\u0014.\u0018(this.QB));
				\u0017\u001C\u0003.\u0014(\u001E\u000C\u0014.\u0003(\u0020\u0019\u000F.\u000C(\u0003\u0012\u0014.\u0003(this))));
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x0002AC80 File Offset: 0x00028E80
		private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
		{
			List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
			try
			{
				while (\u0019\u000E\u0018.\u0018(ref enumerator))
				{
					\u0013\u0013\u0003.\u0018(\u000C\u000C\u0014.\u0018(ref enumerator), true);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.chkSelectAll_Checked(object, RoutedEventArgs)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u001E\u001C\u0003.\u0018(\u000D\u000F\u0014.\u0018(this.QB));
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x0002AD00 File Offset: 0x00028F00
		private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
		{
			List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
			try
			{
				while (\u0019\u000E\u0018.\u0018(ref enumerator))
				{
					\u0013\u0013\u0003.\u0018(\u000C\u000C\u0014.\u0018(ref enumerator), false);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.chkSelectAll_Unchecked(object, RoutedEventArgs)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u001E\u001C\u0003.\u0018(\u000D\u000F\u0014.\u0018(this.QB));
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x0002AD80 File Offset: 0x00028F80
		private void gridSelectedStatus_Click(object sender, RoutedEventArgs e)
		{
			System.Windows.Controls.CheckBox checkBox = \u0015\u0019\u000F.\u000C(sender);
			if (checkBox != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.gridSelectedStatus_Click(object, RoutedEventArgs)).MethodHandle;
				}
				bool? flag = \u001B\u0001\u0018.\u0018(checkBox);
				bool u = \u000C\u0007\u0018.\u0018(ref flag);
				IEnumerator u000C = \u0016\u000F\u0014.\u0018(\u0014\u000F\u0014.\u0018(this.QB));
				try
				{
					while (\u001F\u001E\u0018.\u0018(u000C))
					{
						\u0013\u0013\u0003.\u0018(\u0017\u0019\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C)), u);
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
					IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C);
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
						\u0020\u001E\u0018.\u0018(disposable);
					}
				}
			}
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x0002AE34 File Offset: 0x00029034
		private void dgFinalGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
		{
			SheetInfo sheetInfo = \u0003\u001D\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.QB));
			if (sheetInfo != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.dgFinalGrid_SelectedCellsChanged(object, SelectedCellsChangedEventArgs)).MethodHandle;
				}
				\u0018\u000F\u0003.\u0018(this.QB, \u0014\u000F\u0003.\u0018());
				string text;
				if (!\u000F\u0002\u0018.\u0018(\u000A\u0013\u0003.\u0014(sheetInfo), "Sheet"))
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
					text = "View";
				}
				else
				{
					text = "Sheet";
				}
				string u = text;
				System.Windows.Controls.MenuItem menuItem = \u000C\u000F\u0003.\u0018();
				\u000E\u0016\u0003.\u0018(menuItem, \u001C\u001E\u0018.\u0018(\u001C\u0009\u0018.\u0004\u0018, u));
				System.Windows.Controls.MenuItem menuItem2 = menuItem;
				\u000F\u0016\u0003.\u0018(menuItem2, this.GR("openfolder.png"));
				\u0008\u0016\u0003.\u0018(menuItem2, new RoutedEventHandler(this.Sheets_MenuItem_Click));
				\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u0006\u0016\u0003.\u0018(this.QB)), menuItem2);
				System.Windows.Controls.MenuItem menuItem3 = \u000C\u000F\u0003.\u0018();
				\u000E\u0016\u0003.\u0018(menuItem3, \u001C\u001E\u0018.\u0018(\u001C\u0009\u0018.\u001D\u0018, u));
				System.Windows.Controls.MenuItem menuItem4 = menuItem3;
				\u000F\u0016\u0003.\u0018(menuItem4, this.GR("deletetable.png"));
				\u0008\u0016\u0003.\u0018(menuItem4, new RoutedEventHandler(this.MenuDeleteItem_Click));
				\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u0006\u0016\u0003.\u0018(this.QB)), menuItem4);
				System.Windows.Controls.MenuItem menuItem5 = \u000C\u000F\u0003.\u0018();
				\u000E\u0016\u0003.\u0018(menuItem5, \u000D\u0009\u0018.\u000D\u0003);
				System.Windows.Controls.MenuItem menuItem6 = menuItem5;
				\u000F\u0016\u0003.\u0018(menuItem6, this.GR("Duplicate.png"));
				\u001E\u001F\u0018.\u0018(menuItem6, new RoutedEventHandler(this.Item_Click));
				\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u0006\u0016\u0003.\u0018(this.QB)), menuItem6);
				System.Windows.Controls.MenuItem menuItem7 = \u000C\u000F\u0003.\u0018();
				\u000E\u0016\u0003.\u0018(menuItem7, \u000D\u0009\u0018.\u001C\u0003);
				System.Windows.Controls.MenuItem menuItem8 = menuItem7;
				\u000F\u0016\u0003.\u0018(menuItem8, this.GR("Duplicate.png"));
				\u001E\u001F\u0018.\u000C(menuItem8, new RoutedEventHandler(this.ItemOrientation_Click));
				\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u0006\u0016\u0003.\u0018(this.QB)), menuItem8);
				System.Windows.Controls.MenuItem menuItem9 = \u000C\u000F\u0003.\u0018();
				\u000E\u0016\u0003.\u0018(menuItem9, \u000D\u0009\u0018.\u0015\u0003);
				System.Windows.Controls.MenuItem menuItem10 = menuItem9;
				\u000F\u0016\u0003.\u0018(menuItem10, this.GR("Retry.png"));
				\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u0006\u0016\u0003.\u0018(this.QB)), menuItem10);
				\u0009\u0013\u0003.\u0018(menuItem10, \u0014\u0013\u0003.\u0018(this));
				return;
			}
			\u0018\u000F\u0003.\u0018(this.QB, \u0011\u0019\u000F.\u000C);
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06000817 RID: 2071 RVA: 0x0002B08C File Offset: 0x0002928C
		public CommandBase RetryCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.RetryFailedPublish), new Predicate<object>(this.ER));
			}
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x0002B0B8 File Offset: 0x000292B8
		private bool ER(object P)
		{
			object u000C = Enumerable.ToList<SheetInfo>(Enumerable.OfType<SheetInfo>(\u0008\u0012\u0014.\u0018(this.QB)));
			Predicate<SheetInfo> u;
			if ((u = Create.<>c.\u0020) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.ER(object)).MethodHandle;
				}
				u = (Create.<>c.\u0020 = new Predicate<SheetInfo>(Create.<>c.\u000C.\u0010));
			}
			return \u0007\u000F\u0014.\u0018(u000C, u);
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x0002B11C File Offset: 0x0002931C
		public void RetryFailedPublish()
		{
			\u0007\u0014\u0003.\u0003(\u001A\u001C\u0003.\u0018(this), true);
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x0002B13C File Offset: 0x0002933C
		private void MenuDeleteItem_Click(object sender, RoutedEventArgs e)
		{
			IEditableCollectionView u000C = \u000D\u000F\u0014.\u0018(this.QB);
			List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(Enumerable.ToList<SheetInfo>(Enumerable.Cast<SheetInfo>(\u0014\u000F\u0014.\u0018(this.QB))));
			try
			{
				while (\u0019\u000E\u0018.\u0018(ref enumerator))
				{
					SheetInfo u = \u000C\u000C\u0014.\u0018(ref enumerator);
					if (\u0015\u0013\u0003.\u0018(u000C))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(Create.MenuDeleteItem_Click(object, RoutedEventArgs)).MethodHandle;
						}
						\u0011\u0013\u0003.\u0018(u000C, u);
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
			\u001E\u001C\u0003.\u0018(\u000D\u000F\u0014.\u0018(this.QB));
			List<SheetInfo> u2 = Enumerable.ToList<SheetInfo>(Enumerable.Cast<SheetInfo>(\u000D\u000F\u0014.\u0018(this.QB)));
			\u001F\u0013\u0003.\u0018(Enumerable.ToList<SheetInfo>(Enumerable.Cast<SheetInfo>(\u000D\u000F\u0014.\u0018(this.QB))));
			\u0017\u001C\u0003.\u0014(\u001E\u000C\u0014.\u0003(\u0020\u0019\u000F.\u000C(\u0003\u0012\u0014.\u0003(this))));
			\u0020\u0013\u0003.\u0018(\u001A\u001C\u0003.\u0018(this), u2);
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x0002B258 File Offset: 0x00029458
		private void Sheets_MenuItem_Click(object sender, RoutedEventArgs e)
		{
			SheetInfo sheetInfo = \u0003\u001D\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.QB));
			if (sheetInfo != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.Sheets_MenuItem_Click(object, RoutedEventArgs)).MethodHandle;
				}
				Element element = \u000F\u000A\u0018.\u001F\u0018(\u0017\u001B\u0014.\u0018(), \u0015\u0005\u0018.\u0014(sheetInfo).\u000C());
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
					\u001F\u0005\u0018.\u0018(\u0011\u0005\u0018.\u0018(), \u0018\u0002\u000F.\u000C(element));
					return;
				}
				string text;
				if (!\u000F\u0002\u0018.\u0018(\u000A\u0013\u0003.\u0014(sheetInfo), "Sheet"))
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
					text = "view";
				}
				else
				{
					text = "sheet";
				}
				string u = text;
				\u0002\u001D\u0018.\u0018(\u001C\u001E\u0018.\u0018(\u001C\u0009\u0018.\u0005, u), 350.0);
			}
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x0002B320 File Offset: 0x00029520
		private Image GR(string P)
		{
			Image result = \u001F\u0019\u000F.\u000C;
			try
			{
				Image image = \u0005\u0016\u0003.\u0018();
				\u001B\u0016\u0003.\u0018(image, \u0017\u0013\u0003.\u0018(\u0005\u000B\u0018.\u0018(\u000D\u001E\u0018.\u0018("/DiRoots.ProSheets;component/Images/", P), UriKind.Relative)));
				result = image;
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x0002B374 File Offset: 0x00029574
		private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			ProcessStartInfo u000C = \u001D\u000C\u0003.\u0018(\u001A\u000C\u0003.\u0018(\u000B\u000C\u0003.\u0018(e)));
			\u0004\u000C\u0003.\u0018(u000C, true);
			\u0002\u000C\u0003.\u0018(u000C);
			\u001D\u000B\u0018.\u0018(e, true);
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x0002B3B0 File Offset: 0x000295B0
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u000C\u0010\u0018.\u0018(\u0018\u0010\u0018.\u0018(\u0014\u0010\u0018.\u0018(this)));
			\u000E\u0007\u0018.\u0018(this);
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x0002B3D8 File Offset: 0x000295D8
		protected override void ApplyLicense(bool isLicenseValid)
		{
			this.T = isLicenseValid;
			if (!this.T)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Create.ApplyLicense(bool)).MethodHandle;
				}
				if (\u0004\u0013\u0003.\u0018())
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
					Func<Task> u000C;
					if ((u000C = Create.<>c.\u001F) == null)
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
						u000C = (Create.<>c.\u001F = new Func<Task>(Create.<>c.\u000C.\u0006));
					}
					\u001E\u0013\u0003.\u0018(\u0002\u0013\u0003.\u0018(u000C));
					\u001E\u0011\u0018.\u0002(this.HB, this.NB);
				}
			}
			\u0014\u0019\u0018.\u0018(this.ZB, isLicenseValid);
			object rb = this.RB;
			Visibility u;
			if (!isLicenseValid)
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
				u = Visibility.Visible;
			}
			else
			{
				u = Visibility.Collapsed;
			}
			\u0008\u0013\u0014.\u0018(rb, u);
			if (!isLicenseValid)
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
				\u0020\u0018\u0003.\u0018(\u001E\u000C\u0014.\u0003(\u0020\u0019\u000F.\u000C(\u0003\u0012\u0014.\u0003(this))), isLicenseValid);
			}
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x0002B4B4 File Offset: 0x000296B4
		private void cmbReport_DropDownClosed(object sender, EventArgs e)
		{
			\u001D\u0013\u0003.\u0018(\u0005\u000A\u0014.\u0018(this.K));
			\u0017\u001C\u0003.\u0014(\u001E\u000C\u0014.\u0003(\u0020\u0019\u000F.\u000C(\u0003\u0012\u0014.\u0003(this))));
		}

		// Token: 0x0400031B RID: 795
		private bool T;

		// Token: 0x0400031C RID: 796
		public static List<string> objFaildFile;

		// Token: 0x0400031D RID: 797
		public static bool ispdfsizes_same = true;

		// Token: 0x0400031E RID: 798
		public static int printed_views = 0;

		// Token: 0x0400031F RID: 799
		public bool IsPDFOrientation_Same = true;

		// Token: 0x04000320 RID: 800
		public bool IsDWFOrientation_Same = true;

		// Token: 0x04000322 RID: 802
		[CompilerGenerated]
		private UI_MainWindow I;

		// Token: 0x04000324 RID: 804
		public bool MenuAdded;

		// Token: 0x04000325 RID: 805
		[CompilerGenerated]
		private Create.ExportEndedHandler S;

		// Token: 0x04000326 RID: 806
		[CompilerGenerated]
		private Create.ProgressReceivedHandler U;

		// Token: 0x02000196 RID: 406
		// (Invoke) Token: 0x06001122 RID: 4386
		public delegate void ExportEndedHandler();

		// Token: 0x02000197 RID: 407
		// (Invoke) Token: 0x06001126 RID: 4390
		public delegate void ProgressReceivedHandler();

		// Token: 0x02000198 RID: 408
		// (Invoke) Token: 0x0600112A RID: 4394
		private delegate void \u0002\u000A\u0018();

		// Token: 0x02000199 RID: 409
		// (Invoke) Token: 0x0600112E RID: 4398
		private delegate void \u0004\u000A\u0018(DateTime startTime, DateTime endTime, DateTime combinePdfStart, DateTime combinePdfEnd, DateTime combineDwfStart, DateTime combineDwfEnd, DateTime combineImgStart, DateTime combineImgEnd);

		// Token: 0x0200019A RID: 410
		// (Invoke) Token: 0x06001132 RID: 4402
		private delegate void \u001D\u000A\u0018(string path);

		// Token: 0x0200019B RID: 411
		// (Invoke) Token: 0x06001136 RID: 4406
		private delegate void \u001A\u000A\u0018(int percent);

		// Token: 0x0200019C RID: 412
		// (Invoke) Token: 0x0600113A RID: 4410
		private delegate void \u000B\u000A\u0018();

		// Token: 0x0200019E RID: 414
		[CompilerGenerated]
		private sealed class \u0019\u000A\u0018
		{
			// Token: 0x0600114D RID: 4429 RVA: 0x0005BD60 File Offset: 0x00059F60
			internal bool \u0018(PaperSizeInfo \u000C)
			{
				return \u001B\u0013\u0018.\u0018(\u0017\u0020\u000F.\u0018(\u000C), this.\u000C, true);
			}

			// Token: 0x0600114E RID: 4430 RVA: 0x0005BD84 File Offset: 0x00059F84
			internal bool \u0014(PaperSizeInfo \u000C)
			{
				return \u001B\u0013\u0018.\u0018(\u001E\u0020\u000F.\u0018(\u000C), this.\u000C, true);
			}

			// Token: 0x04000809 RID: 2057
			public string \u000C;
		}
	}
}
