using System;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace A
{
	// Token: 0x02000125 RID: 293
	internal static class \u0010\u0015\u0018
	{
		// Token: 0x06000F0D RID: 3853 RVA: 0x00055698 File Offset: 0x00053898
		internal static object \u000C(this string \u000C)
		{
			TextBlock textBlock = \u001F\u000F\u000F.\u0018();
			\u000B\u000F\u0003.\u0018(textBlock, \u000C);
			return textBlock;
		}

		// Token: 0x06000F0E RID: 3854 RVA: 0x000556B4 File Offset: 0x000538B4
		internal static string GetColumnHeaderAsString(this DataGridColumnHeader dataGridColumnHeader)
		{
			return \u0007\u000F\u0003.\u0018(\u0001\u0006\u000F.\u000C(\u0003\u0012\u0014.\u0014(dataGridColumnHeader)));
		}

		// Token: 0x06000F0F RID: 3855 RVA: 0x000556D8 File Offset: 0x000538D8
		internal static string GetColumnHeaderAsString(this DataGridColumn dataGridColumn)
		{
			return \u0007\u000F\u0003.\u0018(\u0001\u0006\u000F.\u000C(\u0010\u0016\u0003.\u0018(dataGridColumn)));
		}
	}
}
