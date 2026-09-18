using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using A;

namespace DiRoots.RoomPro.Enums
{
	// Token: 0x02000097 RID: 151
	public class EnumToItemsSource : MarkupExtension
	{
		// Token: 0x0600065F RID: 1631 RVA: 0x000246F4 File Offset: 0x000228F4
		public EnumToItemsSource(Type type)
		{
			this.F = type;
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x00024710 File Offset: 0x00022910
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return Enumerable.ToList<object>(Enumerable.Select<string, object>(\u000C\u0004\u001D.\u000A(this.F), new Func<string, object>(this.R)));
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x00024744 File Offset: 0x00022944
		[CompilerGenerated]
		private object R(string F)
		{
			return \u0015\u0004\u001D.\u000A(this.F, F);
		}

		// Token: 0x0400026E RID: 622
		private readonly Type F;
	}
}
