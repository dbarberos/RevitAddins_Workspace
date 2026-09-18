using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.SheetGen.Models
{
	// Token: 0x0200037D RID: 893
	public class ViewSheetSetInfo : ModelBase
	{
		// Token: 0x06002498 RID: 9368 RVA: 0x000DF294 File Offset: 0x000DD494
		public ViewSheetSetInfo(string name, IViewSheetSet vs)
		{
			\u0012\u001C\u000B.\u001D(this, name);
			if (vs != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewSheetSetInfo..ctor(string, IViewSheetSet)).MethodHandle;
				}
				\u0009\u0015\u000B.\u000A(this, \u0001\u0015\u000B.\u000A(vs));
				IEnumerable<View> enumerable = Enumerable.Cast<View>(\u0001\u0015\u000B.\u000A(vs));
				Func<View, VSSetItem> func;
				if ((func = ViewSheetSetInfo.<>c.\u000A) == null)
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
					func = (ViewSheetSetInfo.<>c.\u000A = new Func<View, VSSetItem>(ViewSheetSetInfo.<>c.\u001F.\u001D));
				}
				\u0015\u0015\u000B.\u000A(this, Enumerable.ToList<VSSetItem>(Enumerable.Select<View, VSSetItem>(enumerable, func)));
			}
		}

		// Token: 0x06002499 RID: 9369 RVA: 0x000DF320 File Offset: 0x000DD520
		public void UpdateItems(IViewSheetSet vsset)
		{
			IEnumerable<View> enumerable = Enumerable.Cast<View>(\u0001\u0015\u000B.\u000A(vsset));
			Func<View, VSSetItem> func;
			if ((func = ViewSheetSetInfo.<>c.\u0007) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewSheetSetInfo.UpdateItems(IViewSheetSet)).MethodHandle;
				}
				func = (ViewSheetSetInfo.<>c.\u0007 = new Func<View, VSSetItem>(ViewSheetSetInfo.<>c.\u001F.\u0004));
			}
			\u0015\u0015\u000B.\u000A(this, Enumerable.ToList<VSSetItem>(Enumerable.Select<View, VSSetItem>(enumerable, func)));
		}

		// Token: 0x17000A5A RID: 2650
		// (get) Token: 0x0600249A RID: 9370 RVA: 0x000DF384 File Offset: 0x000DD584
		// (set) Token: 0x0600249B RID: 9371 RVA: 0x000DF398 File Offset: 0x000DD598
		public string Name
		{
			get
			{
				return this.JR;
			}
			set
			{
				this.JR = value;
				\u0007\u0013\u000A.\u000A(this, "Name");
			}
		}

		// Token: 0x17000A5B RID: 2651
		// (get) Token: 0x0600249C RID: 9372 RVA: 0x000DF3B8 File Offset: 0x000DD5B8
		// (set) Token: 0x0600249D RID: 9373 RVA: 0x000DF3CC File Offset: 0x000DD5CC
		public bool IsChecked
		{
			get
			{
				return this.WR;
			}
			set
			{
				this.WR = value;
				\u0007\u0013\u000A.\u000A(this, "IsChecked");
			}
		}

		// Token: 0x17000A5C RID: 2652
		// (get) Token: 0x0600249E RID: 9374 RVA: 0x000DF3EC File Offset: 0x000DD5EC
		// (set) Token: 0x0600249F RID: 9375 RVA: 0x000DF400 File Offset: 0x000DD600
		public bool IsHidden
		{
			get
			{
				return this.KR;
			}
			set
			{
				this.KR = value;
				\u0007\u0013\u000A.\u000A(this, "IsHidden");
			}
		}

		// Token: 0x17000A5D RID: 2653
		// (get) Token: 0x060024A0 RID: 9376 RVA: 0x000DF420 File Offset: 0x000DD620
		// (set) Token: 0x060024A1 RID: 9377 RVA: 0x000DF434 File Offset: 0x000DD634
		public ViewSet ItemSet { get; set; }

		// Token: 0x17000A5E RID: 2654
		// (get) Token: 0x060024A2 RID: 9378 RVA: 0x000DF448 File Offset: 0x000DD648
		// (set) Token: 0x060024A3 RID: 9379 RVA: 0x000DF45C File Offset: 0x000DD65C
		public List<VSSetItem> Items { get; set; }

		// Token: 0x04000E82 RID: 3714
		private string JR;

		// Token: 0x04000E83 RID: 3715
		private bool WR;

		// Token: 0x04000E84 RID: 3716
		private bool KR;

		// Token: 0x04000E85 RID: 3717
		[CompilerGenerated]
		private ViewSet KU;

		// Token: 0x04000E86 RID: 3718
		[CompilerGenerated]
		private List<VSSetItem> DY;
	}
}
