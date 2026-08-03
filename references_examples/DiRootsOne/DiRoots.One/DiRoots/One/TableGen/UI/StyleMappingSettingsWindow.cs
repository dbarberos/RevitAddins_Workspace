using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Profiles;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.TableGen.TableGen.ViewModels.StyleMappings;

namespace DiRoots.One.TableGen.UI
{
	// Token: 0x0200015B RID: 347
	public class StyleMappingSettingsWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x06000D19 RID: 3353 RVA: 0x00054E14 File Offset: 0x00053014
		public StyleMappingSettingsWindow(StyleMappingSettingsViewModel viewModel, ObservableCollection<Profile> profiles, Profile activeProfile)
		{
			this.C = viewModel;
			this.XD = profiles;
			this.PD = activeProfile;
			\u0002\u0002\u0019.\u000A(this);
			\u0017\u001A\u000A.\u0007(this, this.C);
			\u0011\u000C\u000A.\u001D(this, new RoutedEventHandler(this.StyleMappingSettingsWindow_Loaded));
		}

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06000D1A RID: 3354 RVA: 0x00054E60 File Offset: 0x00053060
		public Profile ActiveProfile
		{
			get
			{
				Profile result;
				if ((result = this.PD) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingSettingsWindow.get_ActiveProfile()).MethodHandle;
					}
					result = \u0006\u0002\u0019.\u0007(this.TD);
				}
				return result;
			}
		}

		// Token: 0x06000D1B RID: 3355 RVA: 0x00054E98 File Offset: 0x00053098
		private void StyleMappingSettingsWindow_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				if (\u000E\u0002\u0019.\u000A() == null)
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingSettingsWindow.StyleMappingSettingsWindow_Loaded(object, RoutedEventArgs)).MethodHandle;
					}
					\u0004\u0015\u0007.\u000A(new \u000E\u000E\u000A("DiRootsOne", "TableGen", \u0007\u0018.\u0007<ICustomLogger>()));
				}
				\u001D\u0015\u0007.\u000A(this.TD, "TGStyleMapping");
				if (!\u0010\u0002\u0019.\u000A(\u0007\u0015\u0007.\u0007(this.TD), \u001E\u0011\u000A.\u000A(\u0007\u0005\u000E.\u001F())))
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
					\u000A\u0015\u0007.\u000A(\u0007\u0015\u0007.\u0007(this.TD), \u001E\u0011\u000A.\u000A(\u0007\u0005\u000E.\u001F()));
				}
				\u000D\u0002\u0019.\u0007(this.TD, this.XD);
				this.OD = true;
				try
				{
					\u001F\u0015\u0007.\u000A(this.TD);
					if (this.PD != null)
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
						if (this.XD != null)
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
							if (\u001C\u0002\u0019.\u000A(this.XD, this.PD))
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
								ComboBox comboBox = \u000F\u001F\u000E.\u001F(\u0003\u0002\u0019.\u000A(this.TD, "cmbProfiles"));
								if (comboBox != null)
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
									\u0012\u0002\u0019.\u000A(comboBox, this.PD);
								}
								\u000F\u0002\u0019.\u0007(this.TD, this.PD);
								\u001A\u000C\u0007.\u0007(this.TD, \u001C\u000D\u0004.\u0007(this.PD));
							}
						}
					}
				}
				finally
				{
					this.OD = false;
				}
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\UI\\Windows\\StyleMappingSettingsWindow.xaml.cs", "StyleMappingSettingsWindow_Loaded");
			}
		}

		// Token: 0x06000D1C RID: 3356 RVA: 0x0005505C File Offset: 0x0005325C
		private void BtnOk_Click(object sender, RoutedEventArgs e)
		{
			this.C.DP();
			\u0006\u0015\u0007.\u0007(this, new bool?(true));
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06000D1D RID: 3357 RVA: 0x00055088 File Offset: 0x00053288
		private void ProfileControl_ProfileChanged(object sender, RoutedEventArgs e)
		{
			if (this.OD)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingSettingsWindow.ProfileControl_ProfileChanged(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			try
			{
				Profile pd = \u001D\u0005\u000E.\u001F;
				if (\u0001\u000C\u0007.\u0007(this.TD) == null)
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
					pd = \u0012\u0018\u0019.\u000A(\u0008\u0002\u0019.\u0007(this.TD), 0);
				}
				else
				{
					pd = \u0006\u0002\u0019.\u0007(this.TD);
				}
				this.PD = pd;
				this.C.LP(this.PD);
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\UI\\Windows\\StyleMappingSettingsWindow.xaml.cs", "ProfileControl_ProfileChanged");
			}
		}

		// Token: 0x06000D1E RID: 3358 RVA: 0x0005513C File Offset: 0x0005333C
		private void ProfileControl_SaveAddProfile(object sender, RoutedEventArgs e)
		{
			try
			{
				\u001A\u000C\u0007.\u0007(this.TD, this.C.YP());
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\UI\\Windows\\StyleMappingSettingsWindow.xaml.cs", "ProfileControl_SaveAddProfile");
			}
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x00055190 File Offset: 0x00053390
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingSettingsWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/tablegen/tablegen/ui/windows/stylemappingsettingswindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06000D20 RID: 3360 RVA: 0x000551D8 File Offset: 0x000533D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		internal Delegate TDR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x06000D21 RID: 3361 RVA: 0x000551F0 File Offset: 0x000533F0
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			if (F == 1)
			{
				this.TD = \u0018\u000A\u000E.\u001F(R);
				return;
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingSettingsWindow.QQ(int, object)).MethodHandle;
			}
			if (F != 2)
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
				this.R = true;
				return;
			}
			this.H = \u001E\u0001\u0010.\u001F(R);
			\u0010\u0015\u000A.\u000A(this.H, new RoutedEventHandler(this.BtnOk_Click));
		}

		// Token: 0x04000531 RID: 1329
		private static string SettingsFile;

		// Token: 0x04000532 RID: 1330
		private readonly StyleMappingSettingsViewModel C;

		// Token: 0x04000533 RID: 1331
		private readonly ObservableCollection<Profile> XD;

		// Token: 0x04000534 RID: 1332
		private Profile PD;

		// Token: 0x04000535 RID: 1333
		private bool OD;

		// Token: 0x04000536 RID: 1334
		internal ProfileUserControl TD;

		// Token: 0x04000537 RID: 1335
		internal Button H;

		// Token: 0x04000538 RID: 1336
		private bool R;
	}
}
