using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.TableGen.TGRevitHelper;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.StyleMapping;

namespace DiRoots.One.TableGen.UI
{
	// Token: 0x0200015C RID: 348
	public class UI_PleaseWait : DiRootsWindow, IComponentConnector
	{
		// Token: 0x06000D22 RID: 3362 RVA: 0x00055260 File Offset: 0x00053460
		public UI_PleaseWait(Document document)
		{
			\u001C\u000C\u0007.\u0007(this, \u0007\u0018.\u0007<ICustomLogger>());
			\u0011\u0002\u0019.\u000A(this);
			this.ID = document;
			\u001B\u0002\u0019.\u000A(true);
		}

		// Token: 0x06000D23 RID: 3363 RVA: 0x000552A0 File Offset: 0x000534A0
		public bool InitializeSync()
		{
			try
			{
				List<SelectedExcel> list = SchemaUtil.\u001D(this.ID);
				\u0001\u0007\u0019.\u000A(list, \u0004\u0002.\u0016(list));
				\u0005\u0002.\u001D(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()), list);
				this.QD = \u0003\u000B\u0004.\u000A();
				List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(list);
				try
				{
					while (\u0001\u0005\u0004.\u000A(ref enumerator))
					{
						SelectedExcel selectedExcel = \u001F\u0016\u0004.\u000A(ref enumerator);
						if (\u000E\u0016\u0004.\u000A(selectedExcel))
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(UI_PleaseWait.InitializeSync()).MethodHandle;
							}
							if (!\u0020\u001B\u0004.\u001D(selectedExcel))
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
								\u001A\u0016\u0004.\u000A(this.QD, selectedExcel);
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
				if (\u000C\u001B\u0004.\u000A(this.QD) == 0)
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
					\u001B\u0002\u0019.\u000A(false);
					return false;
				}
			}
			catch (Exception)
			{
				\u001B\u0002\u0019.\u000A(false);
				return false;
			}
			return true;
		}

		// Token: 0x06000D24 RID: 3364 RVA: 0x000553B0 File Offset: 0x000535B0
		private void Window_ContentRendered(object sender, EventArgs e)
		{
			this.OHR(this.QD);
		}

		// Token: 0x06000D25 RID: 3365 RVA: 0x000553CC File Offset: 0x000535CC
		private void OHR(List<SelectedExcel> F)
		{
			\u000E\u0019\u0019.\u000A(\u0003\u0019\u0019.\u000A(), \u0008\u0019\u0019.\u000A());
			\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "AutoSync processing", "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\UI\\Windows\\UI_PleaseWait.xaml.cs", "ProcessExcels");
			\u0014\u001A\u000A.\u000A(this.NR, \u0017\u001D\u0019.\u000A());
			List<SelectedExcel> u001F = \u0003\u000B\u0004.\u000A();
			List<\u0020\u0019> list = \u0007\u000B\u0019.\u000A();
			StyleMappingDto styleMappingDto = \u0001\u0004\u000E.\u001F;
			string u000A = string.Empty;
			try
			{
				\u0010\u0016.\u000D\u0016 u000D_u = \u0010\u0016.\u0007(this.ID);
				if (u000D_u != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(UI_PleaseWait.OHR(List<SelectedExcel>)).MethodHandle;
					}
					styleMappingDto = \u0019\u0018\u0019.\u0007(u000D_u);
					u000A = \u001D\u0018\u0019.\u000A(u000D_u);
				}
			}
			catch (Exception u000A2)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\UI\\Windows\\UI_PleaseWait.xaml.cs", "ProcessExcels");
			}
			bool flag;
			if (styleMappingDto == null)
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
				flag = \u0001\u0004\u0004.\u0007(\u0009\u0004\u0004.\u001D(styleMappingDto));
			}
			bool u = flag;
			DecimalSymbolOption decimalSymbolOption;
			if (styleMappingDto == null)
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
				decimalSymbolOption = DecimalSymbolOption.UseSystemSettings;
			}
			else
			{
				decimalSymbolOption = \u0016\u0010\u0004.\u000A(\u0009\u0004\u0004.\u001D(styleMappingDto));
			}
			DecimalSymbolOption u000A3 = decimalSymbolOption;
			\u001C\u0016 u001D = \u001C\u0016.\u0005(this.ID, u000A3);
			List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(F);
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					SelectedExcel selectedExcel = \u001F\u0016\u0004.\u000A(ref enumerator);
					\u001C\u0016\u0004.\u0007(selectedExcel, ActionTypes.Update);
					\u001A\u0016\u0004.\u000A(u001F, selectedExcel);
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
			int num = 1;
			int num2 = \u000C\u001B\u0004.\u000A(u001F);
			\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "AutoSync enter reading files!", "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\UI\\Windows\\UI_PleaseWait.xaml.cs", "ProcessExcels");
			\u000A\u0018\u0019.\u000A(\u0016\u001E\u0004.\u000A());
			enumerator = \u000A\u0016\u0004.\u000A(u001F);
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					SelectedExcel selectedExcel2 = \u001F\u0016\u0004.\u000A(ref enumerator);
					UI_PleaseWait.\u0003\u000B u0003_u000B = new UI_PleaseWait.\u0003\u000B();
					u0003_u000B.\u000A = this;
					u0003_u000B.\u001F = num * 100 / num2;
					this.AHR(u0003_u000B.\u001F);
					num++;
					if (\u001A\u0011\u0004.\u001D(selectedExcel2))
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
						if (\u000D\u001B\u001D.\u0007(\u0002\u0003\u0004.\u0007(selectedExcel2)) == 0)
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
							if (\u000A\u001E\u001D.\u000A(\u000A\u001B\u0004.\u001D(selectedExcel2)) == 0)
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
						if (\u000D\u001B\u0004.\u001D(selectedExcel2, \u0006\u0020\u001D.\u0007(selectedExcel2), false))
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
							if (\u0019\u0010\u0004.\u0007(selectedExcel2) == ActionTypes.Delete)
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
								\u0020\u0019 u0020_u = new \u0020\u0019();
								\u0004\u0020\u001D.\u000A(u0020_u, selectedExcel2);
								\u001F\u000B\u0019.\u000A(list, u0020_u);
							}
							else
							{
								try
								{
									\u0020\u0019 u0020_u2 = \u0006\u0016.\u001F(selectedExcel2, \u000A\u000B\u0019.\u0007(\u0003\u0019\u0019.\u000A()), new Action(u0003_u000B.\u0007), u001D, u);
									if (u0020_u2 != null)
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
										\u001F\u000B\u0019.\u000A(list, u0020_u2);
									}
									else
									{
										\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "No data found", "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\UI\\Windows\\UI_PleaseWait.xaml.cs", "ProcessExcels");
									}
								}
								catch (Exception u000A4)
								{
									\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A4, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\UI\\Windows\\UI_PleaseWait.xaml.cs", "ProcessExcels");
								}
							}
							\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), \u0004\u001E\u000A.\u000A("AutoSync processing file:", \u0011\u0020\u001D.\u0007(selectedExcel2)), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\UI\\Windows\\UI_PleaseWait.xaml.cs", "ProcessExcels");
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
				((IDisposable)enumerator).Dispose();
			}
			\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "AutoSync exit reading files!", "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\UI\\Windows\\UI_PleaseWait.xaml.cs", "ProcessExcels");
			if (\u001E\u0002\u0019.\u000A(list) > 0)
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
				if (!\u0004\u0013\u001D.\u0007(\u000A\u000B\u0019.\u0007(\u0003\u0019\u0019.\u000A())))
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
					\u0003\u0019\u0019.\u000A().\u001D += this.QHR;
					\u0003\u0019\u0019.\u000A().\u0007 += this.GHR;
					\u0010\u0019\u0019.\u000A(\u0003\u0019\u0019.\u000A(), true);
					\u000D\u0019\u0019.\u0007(\u0003\u0019\u0019.\u000A(), false);
					\u001C\u0019\u0019.\u0007(\u0003\u0019\u0019.\u000A(), false);
					\u0019\u000B\u0019.\u000A(\u0003\u0019\u0019.\u000A(), list);
					\u0004\u000B\u0019.\u0007(\u0003\u0019\u0019.\u000A(), styleMappingDto);
					\u001D\u000B\u0019.\u0007(\u0003\u0019\u0019.\u000A(), u000A);
					\u0011\u001E\u000A.\u000A(\u000F\u0019\u0019.\u000A());
					return;
				}
			}
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x00055870 File Offset: 0x00053A70
		private void GHR()
		{
			\u0018\u000B\u0019.\u000A(\u001C\u0015\u0007.\u0007(this), new Action(this.VL), DispatcherPriority.Background);
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x00055898 File Offset: 0x00053A98
		private void VL()
		{
			\u0003\u0019\u0019.\u000A().\u0007 -= this.GHR;
			\u0003\u0019\u0019.\u000A().\u001D -= this.QHR;
			\u000E\u0015\u0007.\u000A(this.JR, \u000E\u0016\u0019.\u000A(100));
			\u0014\u001A\u000A.\u000A(this.NR, \u0004\u001E\u000A.\u000A(\u0007\u0018\u0019.\u000A(), " 100%"));
			\u001B\u0002\u0019.\u000A(false);
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06000D28 RID: 3368 RVA: 0x00055914 File Offset: 0x00053B14
		private void QHR(int F, string R)
		{
			UI_PleaseWait.\u001C\u000B u001C_u000B = new UI_PleaseWait.\u001C\u000B();
			u001C_u000B.\u001F = this;
			u001C_u000B.\u000A = F;
			u001C_u000B.\u0007 = R;
			\u0018\u000B\u0019.\u000A(\u001C\u0015\u0007.\u0007(this), new Action(u001C_u000B.\u001D), DispatcherPriority.Background);
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x00055958 File Offset: 0x00053B58
		private void AHR(int F)
		{
			\u000E\u0015\u0007.\u000A(this.JR, \u000E\u0016\u0019.\u000A(F));
			object nr = this.NR;
			string[] array = \u001B\u001F\u000E.\u001F(5);
			array[0] = "[1/2] ";
			array[1] = \u0017\u001D\u0019.\u000A();
			array[2] = " ";
			array[3] = \u000C\u0013\u0007.\u000A(ref F);
			array[4] = "%";
			\u0014\u001A\u000A.\u000A(nr, \u0014\u0006\u001D.\u000A(array));
			object u001F = \u001C\u0015\u0007.\u0007(this);
			DispatcherPriority u000A = DispatcherPriority.Background;
			Action u;
			if ((u = UI_PleaseWait.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_PleaseWait.AHR(int)).MethodHandle;
				}
				u = (UI_PleaseWait.<>c.\u000A = new Action(UI_PleaseWait.<>c.\u001F.\u0007));
			}
			\u0003\u0015\u0007.\u000A(u001F, u000A, u);
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x00055A04 File Offset: 0x00053C04
		private void AHR(int F, string R)
		{
			\u000E\u0015\u0007.\u000A(this.JR, \u000E\u0016\u0019.\u000A(F));
			object nr = this.NR;
			string[] array = \u001B\u001F\u000E.\u001F(5);
			array[0] = "[2/2] ";
			int num = 1;
			string text;
			if (!\u0016\u000B\u0019.\u000A())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_PleaseWait.AHR(int, string)).MethodHandle;
				}
				text = \u0004\u001E\u000A.\u000A(\u0007\u0018\u0019.\u000A(), " ");
			}
			else
			{
				text = \u0005\u000B\u0019.\u000A();
			}
			array[num] = text;
			array[2] = \u000C\u0013\u0007.\u000A(ref F);
			array[3] = "% - ";
			array[4] = R;
			\u0014\u001A\u000A.\u000A(nr, \u0014\u0006\u001D.\u000A(array));
		}

		// Token: 0x06000D2B RID: 3371 RVA: 0x00055A9C File Offset: 0x00053C9C
		private void Window_Closing(object sender, CancelEventArgs e)
		{
			\u001B\u0002\u0019.\u000A(false);
		}

		// Token: 0x06000D2C RID: 3372 RVA: 0x00055AB0 File Offset: 0x00053CB0
		private void DiRootsWindow_Closed(object sender, EventArgs e)
		{
			\u000A\u0002\u0019.\u000A(\u000A\u000B\u0019.\u0007(\u0003\u0019\u0019.\u000A()));
			\u0003\u0019\u0019.\u000A().\u0007 -= this.GHR;
			\u0003\u0019\u0019.\u000A().\u001D -= this.QHR;
		}

		// Token: 0x06000D2D RID: 3373 RVA: 0x00055B00 File Offset: 0x00053D00
		private void DiRootsWindow_Loaded(object sender, RoutedEventArgs e)
		{
			\u0014\u001A\u000A.\u000A(this.NR, \u0004\u001E\u000A.\u000A(\u0007\u0018\u0019.\u000A(), " 0%"));
		}

		// Token: 0x06000D2E RID: 3374 RVA: 0x00055B2C File Offset: 0x00053D2C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_PleaseWait.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/tablegen/tablegen/ui/windows/ui_pleasewait.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06000D2F RID: 3375 RVA: 0x00055B74 File Offset: 0x00053D74
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0016\u0015\u0007.\u0007(\u0004\u0005\u000E.\u001F(R), new EventHandler(this.DiRootsWindow_Closed));
				\u0017\u0015\u0007.\u0007(\u0004\u0005\u000E.\u001F(R), new CancelEventHandler(this.Window_Closing));
				\u0020\u0002\u0019.\u000A(\u0004\u0005\u000E.\u001F(R), new EventHandler(this.Window_ContentRendered));
				\u0011\u000C\u000A.\u0007(\u0004\u0005\u000E.\u001F(R), new RoutedEventHandler(this.DiRootsWindow_Loaded));
				return;
			case 2:
				this.KR = \u001B\u0001\u0010.\u001F(R);
				return;
			case 3:
				this.JR = \u0013\u000A\u000E.\u001F(R);
				return;
			case 4:
				this.NR = \u001A\u000A\u000E.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x04000539 RID: 1337
		private readonly Document ID;

		// Token: 0x0400053A RID: 1338
		private List<SelectedExcel> QD = new List<SelectedExcel>();

		// Token: 0x0400053B RID: 1339
		internal TextBlock KR;

		// Token: 0x0400053C RID: 1340
		internal ProgressBar JR;

		// Token: 0x0400053D RID: 1341
		internal Label NR;

		// Token: 0x0400053E RID: 1342
		private bool R;

		// Token: 0x0200083C RID: 2108
		[CompilerGenerated]
		private sealed class \u0003\u000B
		{
			// Token: 0x06004E30 RID: 20016 RVA: 0x001E002C File Offset: 0x001DE22C
			internal void \u0007()
			{
				this.\u000A.AHR(this.\u001F);
			}

			// Token: 0x040020DB RID: 8411
			public int \u001F;

			// Token: 0x040020DC RID: 8412
			public UI_PleaseWait \u000A;
		}

		// Token: 0x0200083D RID: 2109
		[CompilerGenerated]
		private sealed class \u001C\u000B
		{
			// Token: 0x06004E32 RID: 20018 RVA: 0x001E0060 File Offset: 0x001DE260
			internal void \u001D()
			{
				this.\u001F.AHR(this.\u000A, this.\u0007);
			}

			// Token: 0x040020DD RID: 8413
			public UI_PleaseWait \u001F;

			// Token: 0x040020DE RID: 8414
			public int \u000A;

			// Token: 0x040020DF RID: 8415
			public string \u0007;
		}
	}
}
