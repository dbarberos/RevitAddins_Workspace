using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.WindowControl;
using ProSheets.Helpers;
using ProSheets.Models;

namespace ProSheets.UI
{
	// Token: 0x02000091 RID: 145
	public partial class UI_PleaseWait : DiRootsWindow
	{
		// Token: 0x06000903 RID: 2307 RVA: 0x00037F7C File Offset: 0x0003617C
		public UI_PleaseWait(UI_MainWindow parent)
		{
			\u001F\u0008\u0003.\u0018(this);
			this.CR = parent;
		}

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06000904 RID: 2308 RVA: 0x00037F9C File Offset: 0x0003619C
		// (set) Token: 0x06000905 RID: 2309 RVA: 0x00037FB0 File Offset: 0x000361B0
		public static bool IsCancelled { get; set; }

		// Token: 0x06000906 RID: 2310 RVA: 0x00037FC4 File Offset: 0x000361C4
		private void PM()
		{
			\u000B\u000B\u0018.\u0003(this);
			\u0011\u0008\u0003.\u0018(false);
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x00037FE0 File Offset: 0x000361E0
		private void Window_ContentRendered(object sender, EventArgs e)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_PleaseWait.xaml.cs", "Window_ContentRendered");
			try
			{
				\u0011\u0008\u0003.\u0018(false);
				\u000C\u000A\u0018.\u000C += this.BM;
				\u000B\u000F\u0003.\u0018(this.DQ, \u001C\u0009\u0018.\u0012);
				\u0019\u001C\u0003.\u0018(this.WR, \u0010\u0008\u0003.\u0018(0));
				List<ViewSheet> u = \u0014\u000E\u0018.\u0018(\u000E\u0005\u0018.\u0003(this.CR._viewModel));
				\u001E\u001A\u0014.\u0018(\u0020\u001F\u0018.\u0003());
				\u001B\u000C\u0003.\u0018(\u000C\u000A\u0018.\u0014(\u0017\u001B\u0014.\u0018(), u));
				object u000C = \u0003\u0007\u0014.\u0018();
				Comparison<SheetInfo> u2;
				if ((u2 = UI_PleaseWait.<>c.\u0018) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(UI_PleaseWait.Window_ContentRendered(object, EventArgs)).MethodHandle;
					}
					u2 = (UI_PleaseWait.<>c.\u0018 = new Comparison<SheetInfo>(UI_PleaseWait.<>c.\u000C.\u0003));
				}
				\u0011\u0016\u0003.\u0018(u000C, u2);
				\u0019\u0008\u0003.\u0018(\u0007\u0008\u0003.\u0018(\u001D\u0005\u0018.\u0003(this.CR._viewModel)));
				\u001A\u0008\u0003.\u0018(\u000B\u0008\u0003.\u0018(\u001D\u0005\u0018.\u0003(this.CR._viewModel)));
				\u0004\u0008\u0003.\u0018(\u001D\u0008\u0003.\u0018(\u001D\u0005\u0018.\u0003(this.CR._viewModel)));
				\u001E\u0008\u0003.\u0018(this.CR, \u0002\u0008\u0003.\u0018(\u001D\u0005\u0018.\u0003(this.CR._viewModel)));
				\u0015\u0008\u0003.\u0018(this.CR, \u0017\u0008\u0003.\u0018(\u001D\u0005\u0018.\u0003(this.CR._viewModel)));
				\u000C\u000A\u0018.\u000C -= this.BM;
				this.PM();
			}
			catch (Exception u3)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u3, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_PleaseWait.xaml.cs", "Window_ContentRendered");
			}
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_PleaseWait.xaml.cs", "Window_ContentRendered");
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x000381BC File Offset: 0x000363BC
		private void BM(int P)
		{
			\u0019\u001C\u0003.\u0018(this.WR, \u0010\u0008\u0003.\u0018(P));
			\u0018\u0009\u0014.\u0018(this.TR, \u001C\u001E\u0018.\u0018(\u001C\u0009\u0018.\u0002\u0003, \u0010\u001E\u0018.\u0018(ref P)));
			object u000C = \u0005\u0014\u0003.\u0014(this);
			DispatcherPriority u = DispatcherPriority.Background;
			Action u2;
			if ((u2 = UI_PleaseWait.<>c.\u0014) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_PleaseWait.BM(int)).MethodHandle;
				}
				u2 = (UI_PleaseWait.<>c.\u0014 = new Action(UI_PleaseWait.<>c.\u000C.\u0016));
			}
			\u001B\u0014\u0003.\u0018(u000C, u, u2);
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x00038244 File Offset: 0x00036444
		private void Window_Closed(object sender, EventArgs e)
		{
			\u0011\u0008\u0003.\u0018(true);
		}

		// Token: 0x0400042D RID: 1069
		private UI_MainWindow CR;
	}
}
