using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using A;
using DiRoots.One.SheetLink.Enums;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x0200024C RID: 588
	public class ReadableParameterSource : INotifyPropertyChanged
	{
		// Token: 0x060017B8 RID: 6072 RVA: 0x0009A914 File Offset: 0x00098B14
		public ReadableParameterSource(ParameterSource source, string displayText)
		{
			\u0014\u0011\u0005.\u000A(this, source);
			\u0017\u0011\u0005.\u000A(this, displayText);
		}

		// Token: 0x17000690 RID: 1680
		// (get) Token: 0x060017B9 RID: 6073 RVA: 0x0009A938 File Offset: 0x00098B38
		// (set) Token: 0x060017BA RID: 6074 RVA: 0x0009A94C File Offset: 0x00098B4C
		public string DisplayText { get; set; }

		// Token: 0x17000691 RID: 1681
		// (get) Token: 0x060017BB RID: 6075 RVA: 0x0009A960 File Offset: 0x00098B60
		// (set) Token: 0x060017BC RID: 6076 RVA: 0x0009A974 File Offset: 0x00098B74
		public ParameterSource CurrentParameterSource { get; set; }

		// Token: 0x17000692 RID: 1682
		// (get) Token: 0x060017BD RID: 6077 RVA: 0x0009A988 File Offset: 0x00098B88
		// (set) Token: 0x060017BE RID: 6078 RVA: 0x0009A99C File Offset: 0x00098B9C
		public bool IsSelected
		{
			get
			{
				return this.\u0007;
			}
			set
			{
				this.\u0007 = value;
				\u0013\u0011\u0005.\u000A(this, "");
			}
		}

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x060017BF RID: 6079 RVA: 0x0009A9BC File Offset: 0x00098BBC
		// (remove) Token: 0x060017C0 RID: 6080 RVA: 0x0009AA0C File Offset: 0x00098C0C
		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.\u001D;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = \u0019\u0012\u000E.\u001F(\u000F\u001E\u000A.\u000A(propertyChangedEventHandler2, value));
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.\u001D, value2, propertyChangedEventHandler2);
				}
				while (propertyChangedEventHandler != propertyChangedEventHandler2);
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ReadableParameterSource.add_PropertyChanged(PropertyChangedEventHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.\u001D;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = \u0019\u0012\u000E.\u001F(\u0012\u001E\u000A.\u000A(propertyChangedEventHandler2, value));
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.\u001D, value2, propertyChangedEventHandler2);
				}
				while (propertyChangedEventHandler != propertyChangedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ReadableParameterSource.remove_PropertyChanged(PropertyChangedEventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x060017C1 RID: 6081 RVA: 0x0009AA5C File Offset: 0x00098C5C
		protected void OnPropertyChanged(string name = "")
		{
			PropertyChangedEventHandler u001D = this.\u001D;
			if (u001D != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ReadableParameterSource.OnPropertyChanged(string)).MethodHandle;
				}
				\u001A\u0011\u0005.\u000A(u001D, this, \u000C\u0011\u0005.\u000A(name));
			}
		}

		// Token: 0x0400095A RID: 2394
		[CompilerGenerated]
		private string \u001F;

		// Token: 0x0400095B RID: 2395
		[CompilerGenerated]
		private ParameterSource \u000A;

		// Token: 0x0400095C RID: 2396
		private bool \u0007;

		// Token: 0x0400095D RID: 2397
		[CompilerGenerated]
		private PropertyChangedEventHandler \u001D;
	}
}
