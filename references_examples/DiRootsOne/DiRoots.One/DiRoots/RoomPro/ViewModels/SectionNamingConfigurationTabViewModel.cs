using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.UIBehaviours.Extensions;
using DiRoots.One.UnitTextBox.UI.Validation;
using DiRoots.RoomPro.Enums;
using DiRoots.RoomPro.Interfaces;
using DiRoots.RoomPro.Models;

namespace DiRoots.RoomPro.ViewModels
{
	// Token: 0x0200005C RID: 92
	public class SectionNamingConfigurationTabViewModel : SettingsTabViewModel
	{
		// Token: 0x060003EE RID: 1006 RVA: 0x00018EF4 File Offset: 0x000170F4
		public SectionNamingConfigurationTabViewModel(IModelSettings settings)
		{
			\u0013\u001D u0013_u001D = new \u0013\u001D(\u000C\u001D.\u0006);
			\u0019\u0011\u0007.\u000A(this, \u000E\u001F\u000E.\u001F(settings));
			NamingConfigurationViewModel namingConfigurationViewModel = new NamingConfigurationViewModel();
			\u0013\u0005\u0007.\u0007(namingConfigurationViewModel, new ObservableCollection<NamingParameter>(u0013_u001D.\u0020()));
			\u0004\u0011\u0007.\u000A(this, namingConfigurationViewModel);
			\u0007\u000F\u0007.\u000A(\u000F\u0016\u0007.\u0007(\u001D\u0011\u0007.\u0007(this)), 0, new NamingParameter(\u000C\u001D.\u0005, NamingParameterType.CustomParameter));
			this.JKR();
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x00018F8C File Offset: 0x0001718C
		// (set) Token: 0x060003F0 RID: 1008 RVA: 0x00018FA0 File Offset: 0x000171A0
		public SectionNamingConfigurationSettings NamingConfigurationSettings
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

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x00018FC0 File Offset: 0x000171C0
		// (set) Token: 0x060003F2 RID: 1010 RVA: 0x00019020 File Offset: 0x00017220
		public NamingConfigurationViewModel NamingConfigurationViewModel
		{
			get
			{
				IEnumerable<NamingParameter> enumerable = \u0005\u0016\u0007.\u0007(this.B);
				Func<NamingParameter, bool> func;
				if ((func = SectionNamingConfigurationTabViewModel.<>c.\u000A) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SectionNamingConfigurationTabViewModel.get_NamingConfigurationViewModel()).MethodHandle;
					}
					func = (SectionNamingConfigurationTabViewModel.<>c.\u000A = new Func<NamingParameter, bool>(SectionNamingConfigurationTabViewModel.<>c.\u001F.\u0007));
				}
				\u0016\u0011\u0007.\u000A(this, Enumerable.Any<NamingParameter>(enumerable, func));
				return this.B;
			}
			set
			{
				this.B = value;
				\u000D\u0020\u000A.\u000A(this, "NamingConfigurationViewModel");
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x00019040 File Offset: 0x00017240
		// (set) Token: 0x060003F4 RID: 1012 RVA: 0x00019054 File Offset: 0x00017254
		public ClockOrder ClockOrder
		{
			get
			{
				return this.HY;
			}
			set
			{
				this.HY = value;
				\u000D\u0020\u000A.\u000A(this, "ClockOrder");
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x00019074 File Offset: 0x00017274
		// (set) Token: 0x060003F6 RID: 1014 RVA: 0x00019088 File Offset: 0x00017288
		public SortingDirections Direction
		{
			get
			{
				return this.YY;
			}
			set
			{
				this.YY = value;
				\u000D\u0020\u000A.\u000A(this, "Direction");
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x000190A8 File Offset: 0x000172A8
		// (set) Token: 0x060003F8 RID: 1016 RVA: 0x000190BC File Offset: 0x000172BC
		public CountStyle CountStyle
		{
			get
			{
				return this.CY;
			}
			set
			{
				this.CY = value;
				\u000D\u0020\u000A.\u000A(this, "CountStyle");
				this.MER();
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060003F9 RID: 1017 RVA: 0x000190E4 File Offset: 0x000172E4
		// (set) Token: 0x060003FA RID: 1018 RVA: 0x000190F8 File Offset: 0x000172F8
		public string StartValue
		{
			get
			{
				return this.LY;
			}
			set
			{
				this.LY = value;
				this.NER();
				\u000D\u0020\u000A.\u000A(this, "StartValue");
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x00019120 File Offset: 0x00017320
		// (set) Token: 0x060003FC RID: 1020 RVA: 0x00019134 File Offset: 0x00017334
		public bool EnableViewCount
		{
			get
			{
				return this.SY;
			}
			set
			{
				this.SY = value;
				\u000D\u0020\u000A.\u000A(this, "EnableViewCount");
			}
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00019154 File Offset: 0x00017354
		[BindableMethod("OnSelectedElementParameters")]
		public void OnSelectedElementParameters(object sender)
		{
			\u000C\u0005\u0007.\u000A(\u001D\u0011\u0007.\u0007(this), sender);
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00019170 File Offset: 0x00017370
		[BindableMethod("OnSelectedElementNameComponents")]
		public void OnSelectedElementNameComponents(object sender)
		{
			\u0001\u0005\u0007.\u000A(\u001D\u0011\u0007.\u0007(this), sender);
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x0001918C File Offset: 0x0001738C
		public override bool Validate(string propertyName, object value)
		{
			bool result = true;
			if (\u0008\u0013\u000A.\u000A(propertyName, "StartValue"))
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionNamingConfigurationTabViewModel.Validate(string, object)).MethodHandle;
				}
				result = this.EER(\u0013\u0001\u0010.\u001F(value));
			}
			return result;
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x000191D0 File Offset: 0x000173D0
		internal override bool JWR(out IModelSettings F)
		{
			SectionNamingConfigurationSettings sectionNamingConfigurationSettings = \u0008\u0011\u0007.\u000A();
			NamingConfigurationSettings namingConfigurationSettings = \u0016\u0016\u0007.\u000A();
			\u0018\u0016\u0007.\u000A(namingConfigurationSettings, Enumerable.ToList<NamingParameter>(\u0005\u0016\u0007.\u0007(\u001D\u0011\u0007.\u0007(this))));
			\u0004\u0016\u0007.\u000A(namingConfigurationSettings, \u0019\u0016\u0007.\u000A(\u001D\u0011\u0007.\u0007(this)));
			\u0007\u0016\u0007.\u000A(namingConfigurationSettings, \u001D\u0016\u0007.\u000A(\u001D\u0011\u0007.\u0007(this)));
			\u001F\u0016\u0007.\u000A(namingConfigurationSettings, \u000A\u0016\u0007.\u0007(\u001D\u0011\u0007.\u0007(this)));
			\u000E\u0011\u0007.\u000A(sectionNamingConfigurationSettings, namingConfigurationSettings);
			\u000D\u0011\u0007.\u000A(sectionNamingConfigurationSettings, (int)\u0010\u0011\u0007.\u000A(this));
			\u0003\u0011\u0007.\u000A(sectionNamingConfigurationSettings, \u001C\u0011\u0007.\u000A(this));
			\u000F\u0011\u0007.\u000A(sectionNamingConfigurationSettings, (int)\u0012\u0011\u0007.\u000A(this));
			\u0002\u0011\u0007.\u000A(sectionNamingConfigurationSettings, (int)\u0006\u0011\u0007.\u000A(this));
			F = sectionNamingConfigurationSettings;
			\u000B\u0011\u0007.\u000A(\u000B\u001B\u0007.\u000A(), \u000E\u001F\u000E.\u001F(F));
			return true;
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0001929C File Offset: 0x0001749C
		private bool EER(string F)
		{
			if (\u0012\u0011\u0007.\u000A(this) == CountStyle.Number)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionNamingConfigurationTabViewModel.EER(string)).MethodHandle;
				}
				return \u000C\u000F\u0007.\u0007(\u0015\u000F\u0007.\u000A("^\\d+$"), F);
			}
			return \u000C\u000F\u0007.\u0007(\u0015\u000F\u0007.\u000A("[a-zA-Z]"), F);
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x000192F0 File Offset: 0x000174F0
		private void NER()
		{
			\u000C\u0006\u0007.\u000A(this, "StartValue");
			if (\u0013\u0006\u0007.\u000A(this, "StartValue", this.LY))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionNamingConfigurationTabViewModel.NER()).MethodHandle;
				}
				return;
			}
			CountStyle countStyle = \u0012\u0011\u0007.\u000A(this);
			if (countStyle == CountStyle.Number)
			{
				\u0020\u0006\u0007.\u000A(this, "StartValue", this.RY, ErrorType.Error);
				return;
			}
			for (;;)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			if (countStyle != CountStyle.Alphabet)
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
				return;
			}
			\u0020\u0006\u0007.\u000A(this, "StartValue", this.DY, ErrorType.Error);
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0001937C File Offset: 0x0001757C
		private void MER()
		{
			CountStyle countStyle = \u0012\u0011\u0007.\u000A(this);
			if (countStyle == CountStyle.Number)
			{
				\u001B\u0011\u0007.\u000A(this, "1");
				return;
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(SectionNamingConfigurationTabViewModel.MER()).MethodHandle;
			}
			if (countStyle != CountStyle.Alphabet)
			{
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				return;
			}
			\u001B\u0011\u0007.\u000A(this, "A");
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x000193D0 File Offset: 0x000175D0
		private void JKR()
		{
			\u0020\u0016\u0007.\u000A(\u001D\u0011\u0007.\u0007(this), \u0017\u0016\u0007.\u0007(\u0015\u0011\u0007.\u000A(\u001E\u0011\u0007.\u000A(this))));
			\u0011\u0016\u0007.\u000A(\u001D\u0011\u0007.\u0007(this), \u001E\u0016\u0007.\u0007(\u0015\u0011\u0007.\u000A(\u001E\u0011\u0007.\u000A(this))));
			\u0008\u0016\u0007.\u000A(\u001D\u0011\u0007.\u0007(this), \u001B\u0016\u0007.\u0007(\u0015\u0011\u0007.\u000A(\u001E\u0011\u0007.\u000A(this))));
			if (Enumerable.Any<NamingParameter>(\u001C\u0016\u0007.\u0007(\u0015\u0011\u0007.\u000A(\u001E\u0011\u0007.\u000A(this)))))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionNamingConfigurationTabViewModel.JKR()).MethodHandle;
				}
				\u0010\u0016\u0007.\u0007(\u001D\u0011\u0007.\u0007(this), \u000E\u0016\u0007.\u000A(\u001C\u0016\u0007.\u0007(\u0015\u0011\u0007.\u000A(\u001E\u0011\u0007.\u000A(this)))));
				List<NamingParameter>.Enumerator enumerator = \u0003\u0016\u0007.\u000A(\u001C\u0016\u0007.\u0007(\u0015\u0011\u0007.\u000A(\u001E\u0011\u0007.\u000A(this))));
				try
				{
					while (\u0002\u0016\u0007.\u000A(ref enumerator))
					{
						SectionNamingConfigurationTabViewModel.\u0002\u001D u0002_u001D = new SectionNamingConfigurationTabViewModel.\u0002\u001D();
						u0002_u001D.\u001F = \u0012\u0016\u0007.\u000A(ref enumerator);
						NamingParameter u000A = Enumerable.FirstOrDefault<NamingParameter>(\u000F\u0016\u0007.\u0007(\u001D\u0011\u0007.\u0007(this)), new Func<NamingParameter, bool>(u0002_u001D.\u000A));
						\u0006\u0016\u0007.\u000A(\u000F\u0016\u0007.\u0007(\u001D\u0011\u0007.\u0007(this)), u000A);
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
			\u001A\u0011\u0007.\u000A(this, (ClockOrder)\u000C\u0011\u0007.\u000A(\u001E\u0011\u0007.\u000A(this)));
			\u0014\u0011\u0007.\u000A(this, (SortingDirections)\u0013\u0011\u0007.\u000A(\u001E\u0011\u0007.\u000A(this)));
			\u0020\u0011\u0007.\u000A(this, (CountStyle)\u0017\u0011\u0007.\u000A(\u001E\u0011\u0007.\u000A(this)));
			\u001B\u0011\u0007.\u000A(this, \u0011\u0011\u0007.\u000A(\u001E\u0011\u0007.\u000A(this)));
		}

		// Token: 0x0400016D RID: 365
		private static string GH;

		// Token: 0x0400016E RID: 366
		private static string FY;

		// Token: 0x0400016F RID: 367
		private readonly string RY = \u0005\u0011\u0007.\u000A();

		// Token: 0x04000170 RID: 368
		private readonly string DY = \u0018\u0011\u0007.\u000A();

		// Token: 0x04000171 RID: 369
		private NamingConfigurationViewModel B;

		// Token: 0x04000172 RID: 370
		private ClockOrder HY;

		// Token: 0x04000173 RID: 371
		private SortingDirections YY;

		// Token: 0x04000174 RID: 372
		private CountStyle CY;

		// Token: 0x04000175 RID: 373
		private string LY = "1";

		// Token: 0x04000176 RID: 374
		private SectionNamingConfigurationSettings S;

		// Token: 0x04000177 RID: 375
		private bool SY;

		// Token: 0x020007AA RID: 1962
		[CompilerGenerated]
		private sealed class \u0002\u001D
		{
			// Token: 0x06004BF1 RID: 19441 RVA: 0x001DB3FC File Offset: 0x001D95FC
			internal bool \u000A(NamingParameter \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0020\u0013\u0007.\u0007(\u001F), \u0020\u0013\u0007.\u0007(this.\u001F));
			}

			// Token: 0x04001F22 RID: 7970
			public NamingParameter \u001F;
		}
	}
}
