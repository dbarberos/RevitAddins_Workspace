using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.SheetGen.Core.Services;
using DiRoots.One.SheetGen.Data;
using DiRoots.One.SheetGen.DI.Interfaces;
using DiRoots.Revit.DataCollectors;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002D4 RID: 724
	public class PleaseWait : DiRootsWindow, ILoadData, IComponentConnector
	{
		// Token: 0x06001DA4 RID: 7588 RVA: 0x000BAC1C File Offset: 0x000B8E1C
		public PleaseWait()
		{
			\u0002\u0017\u0016.\u000A(this);
		}

		// Token: 0x17000831 RID: 2097
		// (get) Token: 0x06001DA5 RID: 7589 RVA: 0x000BAC38 File Offset: 0x000B8E38
		// (set) Token: 0x06001DA6 RID: 7590 RVA: 0x000BAC4C File Offset: 0x000B8E4C
		public List<SheetInfo> ModifiedSheets { get; set; }

		// Token: 0x17000832 RID: 2098
		// (get) Token: 0x06001DA7 RID: 7591 RVA: 0x000BAC60 File Offset: 0x000B8E60
		// (set) Token: 0x06001DA8 RID: 7592 RVA: 0x000BAC74 File Offset: 0x000B8E74
		public bool ClearCache { get; set; }

		// Token: 0x17000833 RID: 2099
		// (get) Token: 0x06001DA9 RID: 7593 RVA: 0x000BAC88 File Offset: 0x000B8E88
		// (set) Token: 0x06001DAA RID: 7594 RVA: 0x000BAC9C File Offset: 0x000B8E9C
		public string LabelText
		{
			get
			{
				return this.PB;
			}
			set
			{
				this.PB = value;
				\u0008\u0011\u0016.\u000A(this, "LabelText");
			}
		}

		// Token: 0x17000834 RID: 2100
		// (get) Token: 0x06001DAB RID: 7595 RVA: 0x000BACBC File Offset: 0x000B8EBC
		// (set) Token: 0x06001DAC RID: 7596 RVA: 0x000BACD0 File Offset: 0x000B8ED0
		public bool VMRefreshing { get; set; }

		// Token: 0x06001DAD RID: 7597 RVA: 0x000BACE4 File Offset: 0x000B8EE4
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			\u0014\u001A\u000A.\u000A(this.NR, \u0004\u001E\u000A.\u000A(\u0007\u0018\u0019.\u000A(), " 0%"));
			if (\u000D\u0017\u0016.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PleaseWait.Window_Loaded(object, RoutedEventArgs)).MethodHandle;
				}
				\u0006\u0017\u0016.\u000A(this, \u001C\u0017\u0016.\u000A());
				return;
			}
			if (\u0003\u0017\u0016.\u000A(this))
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
				\u0006\u0017\u0016.\u000A(this, \u0012\u0017\u0016.\u000A());
				return;
			}
			\u0006\u0017\u0016.\u000A(this, \u000F\u0017\u0016.\u000A());
		}

		// Token: 0x06001DAE RID: 7598 RVA: 0x000BAD6C File Offset: 0x000B8F6C
		private void GYR(int F)
		{
			\u000E\u0015\u0007.\u000A(this.JR, \u000E\u0016\u0019.\u000A(F));
			\u0014\u001A\u000A.\u000A(this.NR, \u0018\u000E\u0007.\u000A("{0} {1}%", \u0007\u0018\u0019.\u000A(), F));
		}

		// Token: 0x06001DAF RID: 7599 RVA: 0x000BADB0 File Offset: 0x000B8FB0
		private void FCR()
		{
			Document document = \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004);
			Func<ViewSheet, bool> filter;
			if ((filter = PleaseWait.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PleaseWait.FCR()).MethodHandle;
				}
				filter = (PleaseWait.<>c.\u000A = new Func<ViewSheet, bool>(PleaseWait.<>c.\u001F.\u001D));
			}
			List<ViewSheet> list = Enumerable.ToList<ViewSheet>(document.CollectElements(filter));
			if (\u0003\u0017\u0016.\u000A(this))
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
				list = Enumerable.ToList<ViewSheet>(Enumerable.Where<ViewSheet>(list, new Func<ViewSheet, bool>(this.DCR)));
			}
			object u001F = list;
			Comparison<ViewSheet> u000A;
			if ((u000A = PleaseWait.<>c.\u0007) == null)
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
				u000A = (PleaseWait.<>c.\u0007 = new Comparison<ViewSheet>(PleaseWait.<>c.\u001F.\u0004));
			}
			\u0011\u0017\u0016.\u000A(u001F, u000A);
			int num = \u001B\u0017\u0016.\u000A(list);
			int num2 = 0;
			int num3;
			if (num <= 10)
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
				num3 = num;
			}
			else
			{
				num3 = num / 10;
			}
			int num4 = num3;
			TitleBlockService d = \u0002\u0006\u0016.\u000A(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004));
			List<ViewSheet>.Enumerator enumerator = \u0008\u0017\u0016.\u000A(list);
			try
			{
				while (\u0010\u0017\u0016.\u000A(ref enumerator))
				{
					ViewSheet viewSheet = \u000E\u0017\u0016.\u000A(ref enumerator);
					PleaseWait.\u001D\u0011 u001D_u = new PleaseWait.\u001D\u0011();
					u001D_u.\u000A = this;
					u001D_u.\u001F = \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(viewSheet));
					if (!Enumerable.Any<SheetInfo>(\u0014\u0007\u0016.\u000A(), new Func<SheetInfo, bool>(u001D_u.\u0007)))
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
						this.RCR(viewSheet, \u001D\u001D\u0016.\u000A(\u0014\u0007\u0016.\u000A()), d, false, "");
					}
					num2++;
					if (num2 % num4 != 0)
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
						if (num2 != num)
						{
							continue;
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
					PleaseWait.\u0004\u0011 u0004_u = new PleaseWait.\u0004\u0011();
					u0004_u.\u000A = u001D_u;
					u0004_u.\u001F = num2 * 100 / num;
					\u0018\u000B\u0019.\u000A(\u001C\u0015\u0007.\u0007(this), new Action(u0004_u.\u0007), DispatcherPriority.Background);
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
			\u000C\u0018\u0019.\u000A(\u001C\u0015\u0007.\u0007(this), new Action(base.Close));
		}

		// Token: 0x06001DB0 RID: 7600 RVA: 0x000BAFD4 File Offset: 0x000B91D4
		private void RCR(ViewSheet F, int R, ITitleBlockService D, bool H = false, string C = "")
		{
			PleaseWait.\u0019\u0011 u0019_u = new PleaseWait.\u0019\u0011();
			u0019_u.\u001F = \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(F));
			\u000D\u0005\u0016.\u000A(SheetTemplate.\u0002(F, Enumerable.ToList<ViewTemplate>(Enumerable.Where<ViewTemplate>(\u000C\u0017\u0016.\u000A(Collector.\u0004), new Func<ViewTemplate, bool>(u0019_u.\u000A))), Enumerable.ToList<ViewTemplate>(Enumerable.Where<ViewTemplate>(\u001A\u0017\u0016.\u000A(Collector.\u0004), new Func<ViewTemplate, bool>(u0019_u.\u0007)))));
			SheetInfo sheetInfo = \u0013\u0017\u0016.\u000A(F, \u000C\u0018\u0016.\u000A(), D, false);
			\u0003\u0005\u0016.\u000A(sheetInfo, \u0020\u0008\u001D.\u000A(F));
			\u001F\u0018\u0016.\u000A(sheetInfo, \u0020\u0008\u001D.\u000A(F));
			\u0001\u0019\u0016.\u000A(sheetInfo, \u0005\u001E\u000A.\u000A(F));
			\u0009\u0019\u0016.\u000A(sheetInfo, \u0005\u001E\u000A.\u000A(F));
			\u0014\u0017\u0016.\u000A(sheetInfo, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(F)));
			\u0017\u0017\u0016.\u000A(sheetInfo, H);
			SheetInfo sheetInfo2 = sheetInfo;
			if (!\u001A\u0006\u0007.\u000A(C))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PleaseWait.RCR(ViewSheet, int, ITitleBlockService, bool, string)).MethodHandle;
				}
				\u0020\u0017\u0016.\u000A(sheetInfo2, C);
			}
			object u001F = \u000D\u0004\u0016.\u000A(F);
			List<string> list = \u0014\u000D\u0007.\u000A();
			IEnumerator<ElementId> enumerator = \u000B\u0013\u0007.\u000A(u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ElementId u000A = \u0016\u0013\u0007.\u000A(enumerator);
					Element element = \u0011\u0017\u000A.\u0007(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004), u000A);
					if (element != null)
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
						Revision u001F2 = \u000A\u001C\u000E.\u001F(element);
						object u001F3 = list;
						int num = \u0013\u001C\u0016.\u000A(u001F2);
						\u001A\u0008\u0007.\u000A(u001F3, \u000C\u0013\u0007.\u000A(ref num));
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
			List<RevisionData> list2 = Enumerable.ToList<RevisionData>(\u0013\u0004\u0016.\u0007(\u0008\u0004\u0016.\u0007(sheetInfo2)));
			List<RevisionData>.Enumerator enumerator2 = \u0014\u0004\u0016.\u000A(list2);
			try
			{
				while (\u001B\u0004\u0016.\u000A(ref enumerator2))
				{
					RevisionData u001F4 = \u0017\u0004\u0016.\u000A(ref enumerator2);
					if (\u001F\u0020\u001D.\u000A(list, \u0011\u0004\u0016.\u0007(u001F4)))
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
						\u0008\u0003\u0016.\u000A(u001F4, true);
					}
					else
					{
						\u0008\u0003\u0016.\u000A(u001F4, false);
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
			\u001E\u0018\u0016.\u0007(\u0008\u0004\u0016.\u0007(sheetInfo2), list2);
			\u0011\u0018\u0016.\u0007(\u0008\u0004\u0016.\u0007(sheetInfo2));
			\u001B\u0018\u0016.\u000A(sheetInfo2);
			\u0012\u0005\u0016.\u0007(sheetInfo2, UpdateStates.Updated);
			\u001E\u0017\u0016.\u000A(\u0014\u0007\u0016.\u000A(), R, sheetInfo2);
		}

		// Token: 0x06001DB1 RID: 7601 RVA: 0x000BB25C File Offset: 0x000B945C
		private void Window_ContentRendered(object sender, EventArgs e)
		{
			\u000E\u0015\u0007.\u000A(this.JR, \u000E\u0016\u0019.\u000A(0));
			\u0015\u0017\u0016.\u000A(Collector.\u0004);
			this.FCR();
		}

		// Token: 0x06001DB2 RID: 7602 RVA: 0x000BB290 File Offset: 0x000B9490
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PleaseWait.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/pleasewait.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001DB3 RID: 7603 RVA: 0x000BB2D8 File Offset: 0x000B94D8
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.QB = \u0020\u001C\u000E.\u001F(R);
				\u0020\u0002\u0019.\u000A(this.QB, new EventHandler(this.Window_ContentRendered));
				\u0011\u000C\u000A.\u0007(this.QB, new RoutedEventHandler(this.Window_Loaded));
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

		// Token: 0x06001DB4 RID: 7604 RVA: 0x000BB370 File Offset: 0x000B9570
		bool? ILoadData.ZG()
		{
			return \u0018\u0020\u000A.\u001D(this);
		}

		// Token: 0x06001DB5 RID: 7605 RVA: 0x000BB388 File Offset: 0x000B9588
		[CompilerGenerated]
		private bool DCR(ViewSheet F)
		{
			PleaseWait.\u0007\u0011 u0007_u = new PleaseWait.\u0007\u0011();
			u0007_u.\u001F = F;
			return Enumerable.Any<SheetInfo>(\u0001\u0017\u0016.\u000A(this), new Func<SheetInfo, bool>(u0007_u.\u000A));
		}

		// Token: 0x04000C14 RID: 3092
		private string PB;

		// Token: 0x04000C15 RID: 3093
		[CompilerGenerated]
		private List<SheetInfo> OB;

		// Token: 0x04000C16 RID: 3094
		[CompilerGenerated]
		private bool TB;

		// Token: 0x04000C17 RID: 3095
		[CompilerGenerated]
		private bool IB;

		// Token: 0x04000C18 RID: 3096
		internal PleaseWait QB;

		// Token: 0x04000C19 RID: 3097
		internal TextBlock KR;

		// Token: 0x04000C1A RID: 3098
		internal ProgressBar JR;

		// Token: 0x04000C1B RID: 3099
		internal Label NR;

		// Token: 0x04000C1C RID: 3100
		private bool R;

		// Token: 0x020009AB RID: 2475
		[CompilerGenerated]
		private sealed class \u0007\u0011
		{
			// Token: 0x0600537B RID: 21371 RVA: 0x001ECEF0 File Offset: 0x001EB0F0
			internal bool \u000A(SheetInfo \u001F)
			{
				return \u001D\u0004\u0016.\u0007(\u001F) == \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(this.\u001F));
			}

			// Token: 0x0400251E RID: 9502
			public ViewSheet \u001F;
		}

		// Token: 0x020009AC RID: 2476
		[CompilerGenerated]
		private sealed class \u001D\u0011
		{
			// Token: 0x0600537D RID: 21373 RVA: 0x001ECF30 File Offset: 0x001EB130
			internal bool \u0007(SheetInfo \u001F)
			{
				return \u001D\u0004\u0016.\u0007(\u001F) == this.\u001F;
			}

			// Token: 0x0400251F RID: 9503
			public long \u001F;

			// Token: 0x04002520 RID: 9504
			public PleaseWait \u000A;
		}

		// Token: 0x020009AD RID: 2477
		[CompilerGenerated]
		private sealed class \u0004\u0011
		{
			// Token: 0x0600537F RID: 21375 RVA: 0x001ECF64 File Offset: 0x001EB164
			internal void \u0007()
			{
				this.\u000A.\u000A.GYR(this.\u001F);
			}

			// Token: 0x04002521 RID: 9505
			public int \u001F;

			// Token: 0x04002522 RID: 9506
			public PleaseWait.\u001D\u0011 \u000A;
		}

		// Token: 0x020009AE RID: 2478
		[CompilerGenerated]
		private sealed class \u0019\u0011
		{
			// Token: 0x06005381 RID: 21377 RVA: 0x001ECF9C File Offset: 0x001EB19C
			internal bool \u000A(ViewTemplate \u001F)
			{
				return \u000E\u0006\u0010.\u000A(\u001F) == this.\u001F;
			}

			// Token: 0x06005382 RID: 21378 RVA: 0x001ECFBC File Offset: 0x001EB1BC
			internal bool \u0007(ViewTemplate \u001F)
			{
				return \u000E\u0006\u0010.\u000A(\u001F) == this.\u001F;
			}

			// Token: 0x04002523 RID: 9507
			public long \u001F;
		}
	}
}
