using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.WindowControl;
using ProSheets.Helpers;

namespace ProSheets
{
	// Token: 0x02000068 RID: 104
	public class CleanPrinterQueue : DiRootsWindow, IComponentConnector
	{
		// Token: 0x060005BD RID: 1469 RVA: 0x00021A1C File Offset: 0x0001FC1C
		public CleanPrinterQueue()
		{
			\u0009\u000C\u0003.\u0018(this);
			\u0013\u000C\u0003.\u0018(false);
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x060005BE RID: 1470 RVA: 0x00021A3C File Offset: 0x0001FC3C
		// (set) Token: 0x060005BF RID: 1471 RVA: 0x00021A50 File Offset: 0x0001FC50
		public static bool CleanChosen { get; set; }

		// Token: 0x060005C0 RID: 1472 RVA: 0x00021A64 File Offset: 0x0001FC64
		private void btnCancel_Click_1(object sender, RoutedEventArgs e)
		{
			\u000B\u000B\u0018.\u0003(this);
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x00021A78 File Offset: 0x0001FC78
		private void btnClean_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				LocalPrintServer localPrintServer = \u0017\u000C\u0003.\u0018();
				try
				{
					PrintQueue printQueue = \u0015\u000C\u0003.\u0018(localPrintServer, \u0002\u001A\u0014.\u0018(), PrintSystemDesiredAccess.AdministratePrinter);
					try
					{
						\u0011\u000C\u0003.\u0018(printQueue);
						object u000C = \u001F\u000C\u0003.\u0018(printQueue);
						int num = 0;
						IEnumerator<PrintSystemJobInfo> enumerator = \u0020\u000C\u0003.\u0018(u000C);
						try
						{
							while (\u001F\u001E\u0018.\u0018(enumerator))
							{
								\u000A\u000C\u0003.\u0018(enumerator);
								num++;
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(CleanPrinterQueue.btnClean_Click(object, RoutedEventArgs)).MethodHandle;
							}
							goto IL_C7;
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
								\u0020\u001E\u0018.\u0018(enumerator);
							}
						}
						IL_75:
						object u000C2 = \u001F\u000C\u0003.\u0018(printQueue);
						num = 0;
						enumerator = \u0020\u000C\u0003.\u0018(u000C2);
						try
						{
							while (\u001F\u001E\u0018.\u0018(enumerator))
							{
								\u000A\u000C\u0003.\u0018(enumerator);
								num++;
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
									switch (1)
									{
									case 0:
										continue;
									}
									break;
								}
								\u0020\u001E\u0018.\u0018(enumerator);
							}
						}
						\u0013\u0017\u0014.\u0018(100);
						IL_C7:
						if (num > 0)
						{
							goto IL_75;
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
						if (printQueue != null)
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
							\u0020\u001E\u0018.\u0018(printQueue);
						}
					}
				}
				finally
				{
					if (localPrintServer != null)
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
						\u0020\u001E\u0018.\u0018(localPrintServer);
					}
				}
				\u0013\u000C\u0003.\u0018(true);
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\CleanPrinterQueue.xaml.cs", "btnClean_Click");
				\u0017\u0014\u0014.\u0018(\u001C\u0009\u0018.\u000B\u0018, this);
			}
			\u000B\u000B\u0018.\u0003(this);
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x00021C3C File Offset: 0x0001FE3C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		public void InitializeComponent()
		{
			if (this.Q)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CleanPrinterQueue.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.Q = true;
			Uri u = \u0005\u000B\u0018.\u0018("/DiRoots.ProSheets;V2.1.2.0;component/ui/cleanprinterqueue.xaml", UriKind.Relative);
			\u001B\u000B\u0018.\u0018(this, u);
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x00021C84 File Offset: 0x0001FE84
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		void IComponentConnector.CN(int P, object Q)
		{
			if (P == 1)
			{
				this.PB = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.PB, new RoutedEventHandler(this.btnCancel_Click_1));
				return;
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(CleanPrinterQueue.CN(int, object)).MethodHandle;
			}
			if (P != 2)
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
				this.Q = true;
				return;
			}
			this.MJ = \u000E\u0002\u000F.\u000C(Q);
			\u000C\u0019\u0018.\u0018(this.MJ, new RoutedEventHandler(this.btnClean_Click));
		}

		// Token: 0x04000203 RID: 515
		internal Button PB;

		// Token: 0x04000204 RID: 516
		internal Button MJ;

		// Token: 0x04000205 RID: 517
		private bool Q;
	}
}
