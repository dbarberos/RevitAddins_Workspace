using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.ViewModel;
using DiRoots.RoomPro.Interfaces;
using DiRoots.RoomPro.Models;
using DiRoots.RoomPro.UI.Controls;

namespace DiRoots.RoomPro.ViewModels
{
	// Token: 0x0200005F RID: 95
	public abstract class SettingsTabViewModel : ValidationViewModelBase
	{
		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600044C RID: 1100 RVA: 0x0001A714 File Offset: 0x00018914
		// (set) Token: 0x0600044D RID: 1101 RVA: 0x0001A728 File Offset: 0x00018928
		public SettingsTab SettingsTab { get; set; }

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x0600044E RID: 1102 RVA: 0x0001A73C File Offset: 0x0001893C
		// (set) Token: 0x0600044F RID: 1103 RVA: 0x0001A750 File Offset: 0x00018950
		public string TabName { get; set; }

		// Token: 0x06000450 RID: 1104 RVA: 0x0001A764 File Offset: 0x00018964
		protected T GetValidObject<T>(T obj, IEnumerable<T> objects) where T : ModelObject
		{
			SettingsTabViewModel.\u0012\u001D<T> u0012_u001D = new SettingsTabViewModel.\u0012\u001D<T>();
			u0012_u001D.\u001F = obj;
			T result;
			if ((result = Enumerable.FirstOrDefault<T>(objects, new Func<T, bool>(u0012_u001D.\u000A))) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SettingsTabViewModel.GetValidObject(T, IEnumerable<T>)).MethodHandle;
				}
				result = Enumerable.FirstOrDefault<T>(objects);
			}
			return result;
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0001A7B8 File Offset: 0x000189B8
		internal bool XER()
		{
			return \u001E\u0017\u0007.\u000A(\u0020\u0017\u0007.\u000A(this));
		}

		// Token: 0x06000452 RID: 1106
		internal abstract bool JWR(out IModelSettings F);

		// Token: 0x04000197 RID: 407
		[CompilerGenerated]
		private SettingsTab RC;

		// Token: 0x04000198 RID: 408
		[CompilerGenerated]
		private string DC;

		// Token: 0x020007AE RID: 1966
		[CompilerGenerated]
		private sealed class \u0012\u001D<\u001F> where \u001F : ModelObject
		{
			// Token: 0x06004C03 RID: 19459 RVA: 0x001DB698 File Offset: 0x001D9898
			internal bool \u000A(\u001F \u001F)
			{
				string u001F = \u001D\u000D\u0007.\u0007(\u001F);
				\u001F u001F2 = this.\u001F;
				string u000A;
				if (u001F2 == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SettingsTabViewModel.\u0012\u001D.\u000A(\u001F)).MethodHandle;
					}
					u000A = \u000F\u0015\u0010.\u001F;
				}
				else
				{
					u000A = \u001D\u000D\u0007.\u0007(u001F2);
				}
				return \u0008\u0013\u000A.\u000A(u001F, u000A);
			}

			// Token: 0x04001F29 RID: 7977
			public \u001F \u001F;
		}
	}
}
