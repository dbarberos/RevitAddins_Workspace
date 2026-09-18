using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.UIBehaviours.Extensions;
using DiRoots.RoomPro.Interfaces;
using DiRoots.RoomPro.Models;

namespace DiRoots.RoomPro.ViewModels
{
	// Token: 0x02000056 RID: 86
	public class CalloutNamingConfigurationTabViewModel : SettingsTabViewModel
	{
		// Token: 0x060002D8 RID: 728 RVA: 0x00012F18 File Offset: 0x00011118
		public CalloutNamingConfigurationTabViewModel(IModelSettings settings)
		{
			\u0013\u001D u0013_u001D = new \u0013\u001D(\u000C\u001D.\u0006);
			\u001A\u0005\u0007.\u000A(this, \u0009\u0009\u0010.\u001F(settings));
			NamingConfigurationViewModel namingConfigurationViewModel = new NamingConfigurationViewModel();
			\u0013\u0005\u0007.\u0007(namingConfigurationViewModel, new ObservableCollection<NamingParameter>(u0013_u001D.\u0020()));
			\u0014\u0005\u0007.\u000A(this, namingConfigurationViewModel);
			this.JKR();
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002D9 RID: 729 RVA: 0x00012F6C File Offset: 0x0001116C
		// (set) Token: 0x060002DA RID: 730 RVA: 0x00012F80 File Offset: 0x00011180
		public NamingConfigurationSettings NamingConfigurationSettings
		{
			get
			{
				return this.S;
			}
			set
			{
				this.S = value;
				\u000D\u0020\u000A.\u000A(this, "NamingConfigurationSettings");
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002DB RID: 731 RVA: 0x00012FA0 File Offset: 0x000111A0
		// (set) Token: 0x060002DC RID: 732 RVA: 0x00012FB4 File Offset: 0x000111B4
		public NamingConfigurationViewModel NamingConfigurationViewModel
		{
			get
			{
				return this.B;
			}
			set
			{
				this.B = value;
				\u000D\u0020\u000A.\u000A(this, "NamingConfigurationViewModel");
			}
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00012FD4 File Offset: 0x000111D4
		[BindableMethod("OnSelectedElementParameters")]
		public void OnSelectedElementParameters(object sender)
		{
			\u000C\u0005\u0007.\u000A(\u0015\u0005\u0007.\u0007(this), sender);
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00012FF0 File Offset: 0x000111F0
		[BindableMethod("OnSelectedElementNameComponents")]
		public void OnSelectedElementNameComponents(object sender)
		{
			\u0001\u0005\u0007.\u000A(\u0015\u0005\u0007.\u0007(this), sender);
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0001300C File Offset: 0x0001120C
		public override bool Validate(string propertyName, object value)
		{
			throw \u000C\u000C\u000A.\u000A();
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00013020 File Offset: 0x00011220
		internal override bool JWR(out IModelSettings F)
		{
			NamingConfigurationSettings namingConfigurationSettings = \u0016\u0016\u0007.\u000A();
			\u0018\u0016\u0007.\u000A(namingConfigurationSettings, Enumerable.ToList<NamingParameter>(\u0005\u0016\u0007.\u0007(\u0015\u0005\u0007.\u0007(this))));
			\u0004\u0016\u0007.\u000A(namingConfigurationSettings, \u0019\u0016\u0007.\u000A(\u0015\u0005\u0007.\u0007(this)));
			\u0007\u0016\u0007.\u000A(namingConfigurationSettings, \u001D\u0016\u0007.\u000A(\u0015\u0005\u0007.\u0007(this)));
			\u001F\u0016\u0007.\u000A(namingConfigurationSettings, \u000A\u0016\u0007.\u0007(\u0015\u0005\u0007.\u0007(this)));
			F = namingConfigurationSettings;
			object u001F = \u000B\u0016\u0007.\u000A();
			NamingConfigurationSettings namingConfigurationSettings2 = \u0016\u0016\u0007.\u000A();
			\u0018\u0016\u0007.\u000A(namingConfigurationSettings2, Enumerable.ToList<NamingParameter>(\u0005\u0016\u0007.\u0007(\u0015\u0005\u0007.\u0007(this))));
			\u0004\u0016\u0007.\u000A(namingConfigurationSettings2, \u0019\u0016\u0007.\u000A(\u0015\u0005\u0007.\u0007(this)));
			\u0007\u0016\u0007.\u000A(namingConfigurationSettings2, \u001D\u0016\u0007.\u000A(\u0015\u0005\u0007.\u0007(this)));
			\u001F\u0016\u0007.\u000A(namingConfigurationSettings2, \u000A\u0016\u0007.\u0007(\u0015\u0005\u0007.\u0007(this)));
			\u0009\u0005\u0007.\u000A(u001F, namingConfigurationSettings2);
			return true;
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00013100 File Offset: 0x00011300
		private void JKR()
		{
			\u0020\u0016\u0007.\u000A(\u0015\u0005\u0007.\u0007(this), \u0017\u0016\u0007.\u0007(\u000D\u0016\u0007.\u000A(this)));
			\u0011\u0016\u0007.\u000A(\u0015\u0005\u0007.\u0007(this), \u001E\u0016\u0007.\u0007(\u000D\u0016\u0007.\u000A(this)));
			\u0008\u0016\u0007.\u000A(\u0015\u0005\u0007.\u0007(this), \u001B\u0016\u0007.\u0007(\u000D\u0016\u0007.\u000A(this)));
			if (!Enumerable.Any<NamingParameter>(\u001C\u0016\u0007.\u0007(\u000D\u0016\u0007.\u000A(this))))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CalloutNamingConfigurationTabViewModel.JKR()).MethodHandle;
				}
				return;
			}
			\u0010\u0016\u0007.\u0007(\u0015\u0005\u0007.\u0007(this), \u000E\u0016\u0007.\u000A(\u001C\u0016\u0007.\u0007(\u000D\u0016\u0007.\u000A(this))));
			List<NamingParameter>.Enumerator enumerator = \u0003\u0016\u0007.\u000A(\u001C\u0016\u0007.\u0007(\u000D\u0016\u0007.\u000A(this)));
			try
			{
				while (\u0002\u0016\u0007.\u000A(ref enumerator))
				{
					CalloutNamingConfigurationTabViewModel.\u001B\u0007 u001B_u = new CalloutNamingConfigurationTabViewModel.\u001B\u0007();
					u001B_u.\u001F = \u0012\u0016\u0007.\u000A(ref enumerator);
					NamingParameter u000A = Enumerable.FirstOrDefault<NamingParameter>(\u000F\u0016\u0007.\u0007(\u0015\u0005\u0007.\u0007(this)), new Func<NamingParameter, bool>(u001B_u.\u000A));
					\u0006\u0016\u0007.\u000A(\u000F\u0016\u0007.\u0007(\u0015\u0005\u0007.\u0007(this)), u000A);
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
		}

		// Token: 0x0400010C RID: 268
		private NamingConfigurationSettings S;

		// Token: 0x0400010D RID: 269
		private NamingConfigurationViewModel B;

		// Token: 0x0200078F RID: 1935
		[CompilerGenerated]
		private sealed class \u001B\u0007
		{
			// Token: 0x06004B6D RID: 19309 RVA: 0x001DA024 File Offset: 0x001D8224
			internal bool \u000A(NamingParameter \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0020\u0013\u0007.\u0007(\u001F), \u0020\u0013\u0007.\u0007(this.\u001F));
			}

			// Token: 0x04001EB9 RID: 7865
			public NamingParameter \u001F;
		}
	}
}
