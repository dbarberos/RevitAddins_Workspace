using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Core;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.One.SheetGen;
using DiRoots.One.SheetGen.TemplateTransfer;
using DiRoots.One.SheetGen.TemplateTransfer.Model;

namespace A
{
	// Token: 0x020002E4 RID: 740
	internal class \u001E\u0011 : ExternalEventInfo
	{
		// Token: 0x06001E97 RID: 7831 RVA: 0x000C0B90 File Offset: 0x000BED90
		public \u001E\u0011(ProgressModel \u001F, ViewManagerView \u000A, List<ViewManagerView> \u0007, List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> \u001D)
		{
			\u001E\u0001\u0016.\u000A(this, \u001F);
			\u0011\u0001\u0016.\u000A(this, \u000A);
			\u001B\u0001\u0016.\u000A(this, \u0007);
			\u0008\u0001\u0016.\u000A(this, \u001D);
			\u000E\u0001\u0016.\u000A(this, new List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>());
		}

		// Token: 0x1700086F RID: 2159
		// (get) Token: 0x06001E98 RID: 7832 RVA: 0x000C0BCC File Offset: 0x000BEDCC
		// (set) Token: 0x06001E99 RID: 7833 RVA: 0x000C0BE0 File Offset: 0x000BEDE0
		public ProgressModel ProgressBar { get; set; }

		// Token: 0x17000870 RID: 2160
		// (get) Token: 0x06001E9A RID: 7834 RVA: 0x000C0BF4 File Offset: 0x000BEDF4
		// (set) Token: 0x06001E9B RID: 7835 RVA: 0x000C0C08 File Offset: 0x000BEE08
		public ViewManagerView SourceView { get; set; }

		// Token: 0x17000871 RID: 2161
		// (get) Token: 0x06001E9C RID: 7836 RVA: 0x000C0C1C File Offset: 0x000BEE1C
		// (set) Token: 0x06001E9D RID: 7837 RVA: 0x000C0C30 File Offset: 0x000BEE30
		public List<ViewManagerView> DestinationView { get; set; }

		// Token: 0x17000872 RID: 2162
		// (get) Token: 0x06001E9E RID: 7838 RVA: 0x000C0C44 File Offset: 0x000BEE44
		// (set) Token: 0x06001E9F RID: 7839 RVA: 0x000C0C58 File Offset: 0x000BEE58
		public List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> SelectParameters { get; set; }

		// Token: 0x17000873 RID: 2163
		// (get) Token: 0x06001EA0 RID: 7840 RVA: 0x000C0C6C File Offset: 0x000BEE6C
		// (set) Token: 0x06001EA1 RID: 7841 RVA: 0x000C0C80 File Offset: 0x000BEE80
		private List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> ErrorParameters { get; set; }

		// Token: 0x06001EA2 RID: 7842 RVA: 0x000C0C94 File Offset: 0x000BEE94
		public override void Execute(UIApplication app)
		{
			this.\u0015\u0007 = \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app));
			object u001F = \u0014\u0001\u0016.\u000A(this);
			IEnumerable<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> enumerable = \u0017\u0001\u0016.\u000A(this);
			Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, bool> func;
			if ((func = \u001E\u0011.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0011.Execute(UIApplication)).MethodHandle;
				}
				func = (\u001E\u0011.<>c.\u000A = new Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, bool>(\u001E\u0011.<>c.\u001F.\u0004));
			}
			\u0004\u0001\u0016.\u000A(u001F, Enumerable.Where<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>(enumerable, func));
			Transaction transaction = \u001D\u0014\u0007.\u000A(this.\u0015\u0007, "ViewManager_ApplyModifications");
			try
			{
				\u0007\u0014\u0007.\u000A(transaction);
				int num = \u0004\u000B\u0016.\u000A(\u001A\u0001\u0016.\u000A(this));
				int num2 = 1;
				List<ViewManagerView>.Enumerator enumerator = \u001A\u0016\u0016.\u000A(\u001A\u0001\u0016.\u000A(this));
				try
				{
					while (\u0020\u0016\u0016.\u000A(ref enumerator))
					{
						ViewManagerView u001F2 = \u0013\u0016\u0016.\u000A(ref enumerator);
						\u0002\u0013\u0019.\u0007(\u0020\u0001\u0016.\u000A(this));
						\u0013\u0001\u0016.\u0007(\u0020\u0001\u0016.\u000A(this), \u001E\u0007\u0007.\u000A("{0}/{1} {2}", num2, num, \u0007\u000B\u0016.\u000A(u001F2)));
						List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> u000A = \u0008\u0011.\u000A(\u001F\u000B\u0016.\u0007(u001F2));
						\u0004\u0001\u0016.\u000A(\u0014\u0001\u0016.\u000A(this), \u0011\u0011.\u0007(u001F2, u000A, \u0017\u0001\u0016.\u000A(this)));
						this.\u0010\u0016(\u0017\u0001\u0016.\u000A(this), \u001F\u000B\u0016.\u0007(u001F2));
						\u0011\u0011.\u000A(u001F2, \u0017\u0001\u0016.\u000A(this));
						num2++;
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
				\u001B\u0001\u000A.\u000A(transaction);
			}
			catch (Exception u000A2)
			{
				\u001F\u0014\u0007.\u000A(transaction);
				\u0002\u0013\u0019.\u0007(\u0020\u0001\u0016.\u000A(this));
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\TemplateTransfer\\Core\\External Event\\TemplateTransferEvent.cs", "Execute");
			}
			finally
			{
				if (transaction != null)
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
					\u001F\u0017\u000A.\u000A(transaction);
				}
			}
			this.\u000C\u0018();
		}

		// Token: 0x06001EA3 RID: 7843 RVA: 0x000C0EB4 File Offset: 0x000BF0B4
		private void \u0010\u0016(List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> \u001F, View \u000A)
		{
			View u001F = \u001F\u000B\u0016.\u0007(\u000C\u0001\u0016.\u000A(this));
			\u001E\u0014\u0018.\u001D(\u0020\u0001\u0016.\u000A(this), 1.0);
			Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, bool> func;
			if ((func = \u001E\u0011.<>c.\u0007) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0011.\u0010\u0016(List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>, View)).MethodHandle;
				}
				func = (\u001E\u0011.<>c.\u0007 = new Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, bool>(\u001E\u0011.<>c.\u001F.\u0019));
			}
			IEnumerable<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> enumerable = Enumerable.Where<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>(\u001F, func);
			Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, ElementId> func2;
			if ((func2 = \u001E\u0011.<>c.\u001D) == null)
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
				func2 = (\u001E\u0011.<>c.\u001D = new Func<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, ElementId>(\u001E\u0011.<>c.\u001F.\u0018));
			}
			IEnumerable<ElementId> u = Enumerable.Select<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo, ElementId>(enumerable, func2);
			\u0011\u0011.\u001F(u001F, \u000A, u);
			Delegate @delegate = \u0006\u000F\u0018.\u0007(\u0020\u0001\u0016.\u000A(this));
			if (@delegate == null)
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
				return;
			}
			object[] array = \u0004\u0015\u0010.\u001F(1);
			array[0] = 1;
			\u0010\u001F\u0018.\u000A(@delegate, array);
		}

		// Token: 0x06001EA4 RID: 7844 RVA: 0x000C0F90 File Offset: 0x000BF190
		private void \u000C\u0018()
		{
			List<TemplateTransferReport> list = \u0004\u0009\u0016.\u000A();
			List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>.Enumerator enumerator = \u000C\u0015\u0016.\u000A(\u0014\u0001\u0016.\u000A(this));
			try
			{
				while (\u001B\u0015\u0016.\u000A(ref enumerator))
				{
					DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo u001F = \u001A\u0015\u0016.\u000A(ref enumerator);
					TemplateTransferReport templateTransferReport = \u001D\u0009\u0016.\u000A();
					\u0007\u0009\u0016.\u000A(templateTransferReport, \u0009\u000C\u0016.\u000A(u001F));
					\u000A\u0009\u0016.\u000A(templateTransferReport, \u001C\u0001\u0016.\u000A(u001F));
					\u0020\u0014\u0007.\u000A(templateTransferReport, ReportStates.Error);
					\u001F\u0009\u0016.\u000A(list, templateTransferReport);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0011.\u000C\u0018()).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u0002\u0013\u0019.\u0007(\u0020\u0001\u0016.\u000A(this));
			if (Enumerable.Any<TemplateTransferReport>(list))
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
				ReportsWindow u001F2 = \u0003\u0018\u001D.\u000A(\u0009\u0001\u0016.\u000A(Enumerable.ToList<Report>(Enumerable.Cast<Report>(list))), false);
				\u0015\u000D\u001D.\u000A(u001F2, \u0015\u0001\u0016.\u0007(\u0020\u0001\u0016.\u000A(this)));
				\u0018\u0020\u000A.\u0007(u001F2);
				return;
			}
			\u000F\u0005\u0019.\u000A(\u0001\u0001\u0016.\u000A(), \u0015\u0001\u0016.\u0007(\u0020\u0001\u0016.\u000A(this)), MessageBoxButtons.OK);
		}

		// Token: 0x04000C8E RID: 3214
		private Document \u0015\u0007;

		// Token: 0x04000C8F RID: 3215
		[CompilerGenerated]
		private ProgressModel \u000F\u000A;

		// Token: 0x04000C90 RID: 3216
		[CompilerGenerated]
		private ViewManagerView \u0001\u0007;

		// Token: 0x04000C91 RID: 3217
		[CompilerGenerated]
		private List<ViewManagerView> \u0009\u0007;

		// Token: 0x04000C92 RID: 3218
		[CompilerGenerated]
		private List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> \u001F\u001D;

		// Token: 0x04000C93 RID: 3219
		[CompilerGenerated]
		private List<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo> \u000A\u001D;
	}
}
