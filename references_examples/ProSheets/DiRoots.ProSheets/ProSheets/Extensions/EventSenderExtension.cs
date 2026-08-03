using System;
using System.Windows.Markup;

namespace ProSheets.Extensions
{
	// Token: 0x020000DB RID: 219
	public class EventSenderExtension : MarkupExtension
	{
		// Token: 0x06000B68 RID: 2920 RVA: 0x00045B6C File Offset: 0x00043D6C
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}
}
