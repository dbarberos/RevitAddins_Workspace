using System;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using ProSheets;

namespace DiRoots.ProSheets.Models
{
	// Token: 0x0200004D RID: 77
	public class RevitParameterExpression : AbstractExpression
	{
		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000305 RID: 773 RVA: 0x000121A0 File Offset: 0x000103A0
		// (set) Token: 0x06000306 RID: 774 RVA: 0x000121B4 File Offset: 0x000103B4
		public Document RevitDoc { get; set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000307 RID: 775 RVA: 0x000121C8 File Offset: 0x000103C8
		// (set) Token: 0x06000308 RID: 776 RVA: 0x000121DC File Offset: 0x000103DC
		public View Element { get; set; }

		// Token: 0x06000309 RID: 777 RVA: 0x000121F0 File Offset: 0x000103F0
		public override bool Evaluate(Context context)
		{
			SelectionParameter u000C = \u001A\u0020\u0014.\u0018(this);
			string text = \u000C\u000A\u0018.\u0008(\u001D\u0020\u0014.\u0018(this), \u0004\u0020\u0014.\u0018(this), \u0002\u0020\u0014.\u0014(u000C));
			if (!\u001F\u001A\u0018.\u0018(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParameterExpression.Evaluate(Context)).MethodHandle;
				}
				if (\u0009\u001E\u0018.\u0018(text, " "))
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
					\u0017\u0020\u0014.\u0018(\u001E\u0020\u0014.\u0018(context), text);
					return true;
				}
			}
			return false;
		}

		// Token: 0x04000169 RID: 361
		[CompilerGenerated]
		private Document \u0014;

		// Token: 0x0400016A RID: 362
		[CompilerGenerated]
		private View \u0003;
	}
}
