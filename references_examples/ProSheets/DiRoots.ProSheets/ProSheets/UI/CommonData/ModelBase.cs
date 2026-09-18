using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using A;

namespace ProSheets.UI.CommonData
{
	// Token: 0x02000097 RID: 151
	public abstract class ModelBase : INotifyPropertyChanged
	{
		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000935 RID: 2357 RVA: 0x00039578 File Offset: 0x00037778
		// (remove) Token: 0x06000936 RID: 2358 RVA: 0x000395C8 File Offset: 0x000377C8
		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.\u000C;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = \u0011\u0007\u000F.\u000C(\u001C\u0019\u0018.\u0018(propertyChangedEventHandler2, value));
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.\u000C, value2, propertyChangedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ModelBase.add_PropertyChanged(PropertyChangedEventHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.\u000C;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = \u0011\u0007\u000F.\u000C(\u0013\u0019\u0018.\u0018(propertyChangedEventHandler2, value));
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.\u000C, value2, propertyChangedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ModelBase.remove_PropertyChanged(PropertyChangedEventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x00039618 File Offset: 0x00037818
		protected void OnPropertyChanged([CallerMemberName] string property = "")
		{
			PropertyChangedEventHandler u000C = this.\u000C;
			if (u000C == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ModelBase.OnPropertyChanged(string)).MethodHandle;
				}
				return;
			}
			\u0006\u001B\u0003.\u0018(u000C, this, \u0008\u001B\u0003.\u0018(property));
		}

		// Token: 0x04000454 RID: 1108
		[CompilerGenerated]
		private PropertyChangedEventHandler \u000C;
	}
}
