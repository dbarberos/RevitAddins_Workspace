using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using A;

namespace ProSheets.Extensions
{
	// Token: 0x020000DA RID: 218
	public class EventArgsExtension : MarkupExtension
	{
		// Token: 0x06000B59 RID: 2905 RVA: 0x00045994 File Offset: 0x00043B94
		public EventArgsExtension()
		{
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x000459A8 File Offset: 0x00043BA8
		public EventArgsExtension(string path)
		{
			\u001F\u001F\u0016.\u0018(this, new PropertyPath(path, Array.Empty<object>()));
		}

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x06000B5B RID: 2907 RVA: 0x000459D0 File Offset: 0x00043BD0
		// (set) Token: 0x06000B5C RID: 2908 RVA: 0x000459E4 File Offset: 0x00043BE4
		public PropertyPath Path { get; set; }

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x06000B5D RID: 2909 RVA: 0x000459F8 File Offset: 0x00043BF8
		// (set) Token: 0x06000B5E RID: 2910 RVA: 0x00045A0C File Offset: 0x00043C0C
		public IValueConverter Converter { get; set; }

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x06000B5F RID: 2911 RVA: 0x00045A20 File Offset: 0x00043C20
		// (set) Token: 0x06000B60 RID: 2912 RVA: 0x00045A34 File Offset: 0x00043C34
		public object ConverterParameter { get; set; }

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x06000B61 RID: 2913 RVA: 0x00045A48 File Offset: 0x00043C48
		// (set) Token: 0x06000B62 RID: 2914 RVA: 0x00045A5C File Offset: 0x00043C5C
		public Type ConverterTargetType { get; set; }

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x06000B63 RID: 2915 RVA: 0x00045A70 File Offset: 0x00043C70
		// (set) Token: 0x06000B64 RID: 2916 RVA: 0x00045A84 File Offset: 0x00043C84
		[TypeConverter(typeof(CultureInfoIetfLanguageTagConverter))]
		public CultureInfo ConverterCulture { get; set; }

		// Token: 0x06000B65 RID: 2917 RVA: 0x00045A98 File Offset: 0x00043C98
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x00045AA8 File Offset: 0x00043CA8
		internal object N(EventArgs P, XmlLanguage Q)
		{
			if (\u001D\u001F\u0016.\u0018(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(EventArgsExtension.N(EventArgs, XmlLanguage)).MethodHandle;
				}
				return P;
			}
			object obj = \u0007\u001F\u0018.\u000C(\u001D\u001F\u0016.\u0018(this), P);
			if (\u0004\u001F\u0016.\u0018(this) != null)
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
				object u000C = \u0004\u001F\u0016.\u0018(this);
				object u = obj;
				Type u2;
				if ((u2 = \u0002\u001F\u0016.\u0018(this)) == null)
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
					u2 = \u000A\u001D\u0018.\u0018(\u0002\u0004\u000F.\u000C());
				}
				object u3 = \u001E\u001F\u0016.\u0018(this);
				CultureInfo u4;
				if ((u4 = \u0017\u001F\u0016.\u0018(this)) == null)
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
					u4 = \u0015\u001F\u0016.\u0018(Q);
				}
				obj = \u0011\u001F\u0016.\u0018(u000C, u, u2, u3, u4);
			}
			return obj;
		}

		// Token: 0x0400054F RID: 1359
		[CompilerGenerated]
		private PropertyPath P;

		// Token: 0x04000550 RID: 1360
		[CompilerGenerated]
		private IValueConverter Q;

		// Token: 0x04000551 RID: 1361
		[CompilerGenerated]
		private object J;

		// Token: 0x04000552 RID: 1362
		[CompilerGenerated]
		private Type F;

		// Token: 0x04000553 RID: 1363
		[CompilerGenerated]
		private CultureInfo H;
	}
}
