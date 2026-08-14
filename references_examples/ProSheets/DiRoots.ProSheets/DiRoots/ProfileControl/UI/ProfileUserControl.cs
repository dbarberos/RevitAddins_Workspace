using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.Enums;
using DiRoots.ProfileControl.Helper;
using Microsoft.Win32;
using ProSheets.Helper;

namespace DiRoots.ProfileControl.UI
{
	// Token: 0x02000014 RID: 20
	public class ProfileUserControl : UserControl, IComponentConnector
	{
		// Token: 0x0600008D RID: 141 RVA: 0x000051C8 File Offset: 0x000033C8
		public ProfileUserControl()
		{
			\u000D\u0019\u0018.\u0018(this);
			ObservableCollection<BatchAction> observableCollection = new ObservableCollection<BatchAction>();
			BatchAction batchAction = new BatchAction();
			\u0012\u0019\u0018.\u0018(batchAction, \u000D\u0009\u0018.\u000F\u0014);
			\u000F\u0019\u0018.\u0018(batchAction, 10);
			\u0016\u0019\u0018.\u0018(observableCollection, batchAction);
			BatchAction batchAction2 = new BatchAction();
			\u0012\u0019\u0018.\u0018(batchAction2, \u000D\u0009\u0018.\u001E\u0014);
			\u000F\u0019\u0018.\u0018(batchAction2, 10);
			\u0016\u0019\u0018.\u0018(observableCollection, batchAction2);
			ObservableCollection<BatchAction> u = observableCollection;
			\u0003\u0019\u0018.\u0018(this.W, u);
			\u0014\u0019\u0018.\u0018(this.T, false);
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600008E RID: 142 RVA: 0x0000524C File Offset: 0x0000344C
		// (remove) Token: 0x0600008F RID: 143 RVA: 0x0000529C File Offset: 0x0000349C
		public event RoutedEventHandler ProfileChanged
		{
			[CompilerGenerated]
			add
			{
				RoutedEventHandler routedEventHandler = this.P;
				RoutedEventHandler routedEventHandler2;
				do
				{
					routedEventHandler2 = routedEventHandler;
					RoutedEventHandler value2 = \u001C\u0004\u000F.\u000C(\u001C\u0019\u0018.\u0018(routedEventHandler2, value));
					routedEventHandler = Interlocked.CompareExchange<RoutedEventHandler>(ref this.P, value2, routedEventHandler2);
				}
				while (routedEventHandler != routedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.add_ProfileChanged(RoutedEventHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				RoutedEventHandler routedEventHandler = this.P;
				RoutedEventHandler routedEventHandler2;
				do
				{
					routedEventHandler2 = routedEventHandler;
					RoutedEventHandler value2 = \u001C\u0004\u000F.\u000C(\u0013\u0019\u0018.\u0018(routedEventHandler2, value));
					routedEventHandler = Interlocked.CompareExchange<RoutedEventHandler>(ref this.P, value2, routedEventHandler2);
				}
				while (routedEventHandler != routedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.remove_ProfileChanged(RoutedEventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000090 RID: 144 RVA: 0x000052EC File Offset: 0x000034EC
		// (remove) Token: 0x06000091 RID: 145 RVA: 0x0000533C File Offset: 0x0000353C
		public event RoutedEventHandler AddProfile
		{
			[CompilerGenerated]
			add
			{
				RoutedEventHandler routedEventHandler = this.Q;
				RoutedEventHandler routedEventHandler2;
				do
				{
					routedEventHandler2 = routedEventHandler;
					RoutedEventHandler value2 = \u001C\u0004\u000F.\u000C(\u001C\u0019\u0018.\u0018(routedEventHandler2, value));
					routedEventHandler = Interlocked.CompareExchange<RoutedEventHandler>(ref this.Q, value2, routedEventHandler2);
				}
				while (routedEventHandler != routedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.add_AddProfile(RoutedEventHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				RoutedEventHandler routedEventHandler = this.Q;
				RoutedEventHandler routedEventHandler2;
				do
				{
					routedEventHandler2 = routedEventHandler;
					RoutedEventHandler value2 = \u001C\u0004\u000F.\u000C(\u0013\u0019\u0018.\u0018(routedEventHandler2, value));
					routedEventHandler = Interlocked.CompareExchange<RoutedEventHandler>(ref this.Q, value2, routedEventHandler2);
				}
				while (routedEventHandler != routedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.remove_AddProfile(RoutedEventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000092 RID: 146 RVA: 0x0000538C File Offset: 0x0000358C
		// (remove) Token: 0x06000093 RID: 147 RVA: 0x000053DC File Offset: 0x000035DC
		public event RoutedEventHandler SaveProfile
		{
			[CompilerGenerated]
			add
			{
				RoutedEventHandler routedEventHandler = this.J;
				RoutedEventHandler routedEventHandler2;
				do
				{
					routedEventHandler2 = routedEventHandler;
					RoutedEventHandler value2 = \u001C\u0004\u000F.\u000C(\u001C\u0019\u0018.\u0018(routedEventHandler2, value));
					routedEventHandler = Interlocked.CompareExchange<RoutedEventHandler>(ref this.J, value2, routedEventHandler2);
				}
				while (routedEventHandler != routedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.add_SaveProfile(RoutedEventHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				RoutedEventHandler routedEventHandler = this.J;
				RoutedEventHandler routedEventHandler2;
				do
				{
					routedEventHandler2 = routedEventHandler;
					RoutedEventHandler value2 = \u001C\u0004\u000F.\u000C(\u0013\u0019\u0018.\u0018(routedEventHandler2, value));
					routedEventHandler = Interlocked.CompareExchange<RoutedEventHandler>(ref this.J, value2, routedEventHandler2);
				}
				while (routedEventHandler != routedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.remove_SaveProfile(RoutedEventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000094 RID: 148 RVA: 0x0000542C File Offset: 0x0000362C
		// (set) Token: 0x06000095 RID: 149 RVA: 0x00005440 File Offset: 0x00003640
		public ProfileUserControl.ProfileValidation IsValidProfile { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00005454 File Offset: 0x00003654
		// (set) Token: 0x06000097 RID: 151 RVA: 0x00005468 File Offset: 0x00003668
		public List<Type> KnownTypes { get; set; } = new List<Type>();

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000098 RID: 152 RVA: 0x0000547C File Offset: 0x0000367C
		// (set) Token: 0x06000099 RID: 153 RVA: 0x00005490 File Offset: 0x00003690
		public static FolderHandler CurrentFolderHandler { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600009A RID: 154 RVA: 0x000054A4 File Offset: 0x000036A4
		// (set) Token: 0x0600009B RID: 155 RVA: 0x000054B8 File Offset: 0x000036B8
		public ProfileTemplate CurrentTemPlateInfo { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600009C RID: 156 RVA: 0x000054CC File Offset: 0x000036CC
		// (set) Token: 0x0600009D RID: 157 RVA: 0x000054E0 File Offset: 0x000036E0
		public Profile CurrentProfile { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600009E RID: 158 RVA: 0x000054F4 File Offset: 0x000036F4
		// (set) Token: 0x0600009F RID: 159 RVA: 0x00005508 File Offset: 0x00003708
		public string SettingsFileName { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x0000551C File Offset: 0x0000371C
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x00005530 File Offset: 0x00003730
		public ObservableCollection<Profile> Profiles { get; set; }

		// Token: 0x060000A2 RID: 162 RVA: 0x00005544 File Offset: 0x00003744
		public void LoadProfile()
		{
			if (\u000A\u0019\u0018.\u0018(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.LoadProfile()).MethodHandle;
				}
				\u001A\u0019\u0018.\u0018(this, \u000B\u0019\u0018.\u0018(\u0019\u0019\u0018.\u0018(\u0010\u0019\u0018.\u0018(this), \u0007\u0019\u0018.\u0014(this))));
				if (\u001D\u0019\u0018.\u0018(\u000A\u0019\u0018.\u0018(this)) == 0)
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
					\u0004\u0019\u0018.\u0018(\u000A\u0019\u0018.\u0018(this));
				}
				else
				{
					\u0017\u001D\u0018.\u0018(\u0002\u0019\u0018.\u0018(\u000A\u0019\u0018.\u0018(this), 0), \u000D\u0009\u0018.\u0015\u0018);
				}
			}
			List<Profile>.Enumerator enumerator = \u001E\u0019\u0018.\u0018(Enumerable.ToList<Profile>(\u000A\u0019\u0018.\u0018(this)));
			try
			{
				while (\u0020\u0019\u0018.\u0018(ref enumerator))
				{
					Profile profile = \u0017\u0019\u0018.\u0018(ref enumerator);
					if (!\u0015\u0019\u0018.\u0018(profile))
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
						if (!\u000C\u001A\u0018.\u0018(\u0011\u0019\u0018.\u0018(profile)))
						{
							for (;;)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
							\u001F\u0019\u0018.\u0018(\u000A\u0019\u0018.\u0018(this), profile);
						}
					}
				}
				for (;;)
				{
					switch (4)
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
			\u0003\u0019\u0018.\u0018(this.O, \u000A\u0019\u0018.\u0018(this));
			\u0009\u0019\u0018.\u0018(this.O, 0);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00005694 File Offset: 0x00003894
		private void btnImportProfile_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = \u0003\u0007\u0018.\u0018();
				\u0014\u0007\u0018.\u0018(openFileDialog, "Xml Files (.xml)|*.xml");
				OpenFileDialog u000C = openFileDialog;
				bool? flag = \u0018\u0007\u0018.\u0018(u000C);
				if (\u000C\u0007\u0018.\u0018(ref flag))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.btnImportProfile_Click(object, RoutedEventArgs)).MethodHandle;
					}
					ProfileUserControl.\u0008\u0013\u0018 u0008_u0013_u = new ProfileUserControl.\u0008\u0013\u0018();
					string u000C2 = \u000E\u0019\u0018.\u0018(u000C);
					u0008_u0013_u.\u000C = \u0005\u0019\u0018.\u0018(u000C2, \u0007\u0019\u0018.\u0014(this));
					Profile u000C3 = u0008_u0013_u.\u000C;
					bool flag2;
					if (u000C3 == null)
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
						flag2 = (null != null);
					}
					else
					{
						flag2 = (\u0008\u0019\u0018.\u0003(u000C3) != null);
					}
					if (!flag2)
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
						\u001B\u0019\u0018.\u0018(\u000D\u0009\u0018.\u0014\u0014, this, MessageBoxButtons.OK);
					}
					else
					{
						Profile profile = Enumerable.FirstOrDefault<Profile>(\u000A\u0019\u0018.\u0018(this), new Func<Profile, bool>(u0008_u0013_u.\u0018));
						if (profile != null)
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
							if (!\u0001\u0019\u0018.\u0018(\u000D\u0009\u0018.\u0003\u0014, this, 250.0, MessageBoxButtons.YesNo))
							{
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
							\u001F\u0019\u0018.\u0018(\u000A\u0019\u0018.\u0018(this), profile);
						}
						\u0006\u0019\u0018.\u0014(this, \u0008\u0019\u0018.\u0014(u0008_u0013_u.\u000C));
						this.E(u0008_u0013_u.\u000C, true, -1);
						this.V();
					}
				}
			}
			catch (Exception)
			{
				\u0014\u001A\u0018.\u0018(\u000D\u0009\u0018.\u0016\u0014);
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00005800 File Offset: 0x00003A00
		private void cmbSave_DropDownClosed(object sender, EventArgs e)
		{
			BatchAction batchAction = \u000D\u0004\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.W));
			if (batchAction == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.cmbSave_DropDownClosed(object, EventArgs)).MethodHandle;
				}
				return;
			}
			if (this.J != null)
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
				\u001C\u0007\u0018.\u0018(this.J, this, \u0013\u0007\u0018.\u0018());
				if (\u000D\u0007\u0018.\u0018(this.O) <= 0)
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
					this.L();
				}
				else
				{
					Profile p = \u0012\u0002\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.O));
					if (\u000F\u0002\u0018.\u0018(\u000F\u0007\u0018.\u0018(batchAction), \u000D\u0009\u0018.\u000F\u0014))
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
						this.U(p);
					}
					else if (\u000F\u0002\u0018.\u0018(\u000F\u0007\u0018.\u0018(batchAction), \u000D\u0009\u0018.\u001E\u0014))
					{
						for (;;)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						this.L();
					}
				}
			}
			\u0016\u0007\u0018.\u0018(this.W, \u001F\u0002\u000F.\u000C);
			\u0009\u0019\u0018.\u0018(this.W, -1);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00005908 File Offset: 0x00003B08
		private void U(Profile P)
		{
			\u000A\u0007\u0018.\u0018(P, \u0020\u0007\u0018.\u0018(\u001F\u0007\u0018.\u0014(this)));
			\u0009\u0007\u0018.\u0018(Enumerable.ToList<Profile>(\u000A\u0019\u0018.\u0018(this)), \u0010\u0019\u0018.\u0018(this), \u0007\u0019\u0018.\u0014(this), false);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00005954 File Offset: 0x00003B54
		private void L()
		{
			ProfileUserControl.\u0001\u0013\u0018 u0001_u0013_u = new ProfileUserControl.\u0001\u0013\u0018();
			ProfileUserControl.\u0001\u0013\u0018 u0001_u0013_u2 = u0001_u0013_u;
			string u000C = \u0004\u0007\u0018.\u0018(\u000F\u001A\u0018.\u0018());
			IEnumerable<Profile> enumerable = \u000A\u0019\u0018.\u0018(this);
			Func<Profile, string> func;
			if ((func = ProfileUserControl.<>c.\u0018) == null)
			{
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.L()).MethodHandle;
				}
				func = (ProfileUserControl.<>c.\u0018 = new Func<Profile, string>(ProfileUserControl.<>c.\u000C.\u0016));
			}
			u0001_u0013_u2.\u000C = \u0002\u0007\u0018.\u0018(u000C, Enumerable.ToList<string>(Enumerable.Select<Profile, string>(enumerable, func)));
			this.A(u0001_u0013_u.\u000C);
			bool? flag = \u001E\u0007\u0018.\u0014(u0001_u0013_u.\u000C);
			if (\u000C\u0007\u0018.\u0018(ref flag))
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
				if (\u000F\u0002\u0018.\u0018(\u0017\u0007\u0018.\u0018(u0001_u0013_u.\u000C), \u000D\u0009\u0018.\u000F\u0014))
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
					\u001C\u0007\u0018.\u0018(this.Q, this, \u0013\u0007\u0018.\u0018());
					this.E(\u0011\u0007\u0018.\u0018(u0001_u0013_u.\u000C), false, -1);
					return;
				}
				Profile u = Enumerable.First<Profile>(\u000A\u0019\u0018.\u0018(this), new Func<Profile, bool>(u0001_u0013_u.\u0018));
				int j = \u0015\u0007\u0018.\u0018(\u000A\u0019\u0018.\u0018(this), u);
				\u001F\u0019\u0018.\u0018(\u000A\u0019\u0018.\u0018(this), u);
				\u001C\u0007\u0018.\u0018(this.Q, this, \u0013\u0007\u0018.\u0018());
				this.E(\u0011\u0007\u0018.\u0018(u0001_u0013_u.\u000C), false, j);
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00005AB4 File Offset: 0x00003CB4
		private void E(Profile P, bool Q, int J = -1)
		{
			try
			{
				\u0007\u0007\u0018.\u0018(this, P);
				\u000A\u0007\u0018.\u0018(P, \u0020\u0007\u0018.\u0018(\u001F\u0007\u0018.\u0014(this)));
				\u0015\u001D\u0018.\u0018(P, true);
				if (!Q)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.E(Profile, bool, int)).MethodHandle;
					}
					if (!\u0019\u0007\u0018.\u0018(P, \u0011\u0019\u0018.\u0018(P), \u0007\u0019\u0018.\u0014(this), true))
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
						return;
					}
					\u000B\u0007\u0018.\u0018(\u000F\u001A\u0018.\u0018(), \u0011\u0019\u0018.\u0018(P));
				}
				object u000C = Enumerable.ToList<Profile>(\u000A\u0019\u0018.\u0018(this));
				Action<Profile> u;
				if ((u = ProfileUserControl.<>c.\u0014) == null)
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
					u = (ProfileUserControl.<>c.\u0014 = new Action<Profile>(ProfileUserControl.<>c.\u000C.\u000F));
				}
				\u001A\u0007\u0018.\u0018(u000C, u);
				if (J == -1)
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
					\u001F\u001D\u0018.\u0018(\u000A\u0019\u0018.\u0018(this), P);
				}
				else
				{
					\u001D\u0007\u0018.\u0018(\u000A\u0019\u0018.\u0018(this), J, P);
				}
				\u0016\u0007\u0018.\u0018(this.O, P);
				\u0009\u0007\u0018.\u0018(Enumerable.ToList<Profile>(\u000A\u0019\u0018.\u0018(this)), \u0010\u0019\u0018.\u0018(this), \u0007\u0019\u0018.\u0014(this), !Q);
			}
			catch (Exception)
			{
				if (Q)
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
					\u0014\u001A\u0018.\u0018(\u000D\u0009\u0018.\u0016\u0014);
				}
				else
				{
					\u0014\u001A\u0018.\u0018(\u000D\u0009\u0018.\u0002\u0014);
				}
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00005C28 File Offset: 0x00003E28
		private void btnDeleteProfile_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (\u0012\u0007\u0018.\u0018(this.O) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.btnDeleteProfile_Click(object, RoutedEventArgs)).MethodHandle;
					}
				}
				else
				{
					string u = \u0008\u0007\u0018.\u0014(\u0012\u0002\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.O)));
					if (\u0001\u0007\u0018.\u0018(\u001C\u001E\u0018.\u0018(\u000D\u0009\u0018.\u0012\u0014, u), MessageBoxButtons.YesNo))
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
						List<Profile>.Enumerator enumerator = \u001E\u0019\u0018.\u0018(Enumerable.ToList<Profile>(\u000A\u0019\u0018.\u0018(this)));
						try
						{
							while (\u0020\u0019\u0018.\u0018(ref enumerator))
							{
								Profile profile = \u0017\u0019\u0018.\u0018(ref enumerator);
								if (\u000F\u0002\u0018.\u0018(\u0008\u0007\u0018.\u0014(profile), u))
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
									\u001F\u0019\u0018.\u0018(\u000A\u0019\u0018.\u0018(this), profile);
									goto IL_E0;
								}
							}
							for (;;)
							{
								switch (7)
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
						IL_E0:
						\u0009\u0019\u0018.\u0018(this.O, 0);
						\u0007\u0007\u0018.\u0018(this, \u0012\u0002\u000F.\u000C(\u0006\u0007\u0018.\u0018(this.O)));
						\u0015\u001D\u0018.\u0018(\u0010\u0007\u0018.\u0014(this), true);
						\u0009\u0007\u0018.\u0018(Enumerable.ToList<Profile>(\u000A\u0019\u0018.\u0018(this)), \u0010\u0019\u0018.\u0018(this), \u0007\u0019\u0018.\u0014(this), false);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00005DAC File Offset: 0x00003FAC
		private void A(Window P)
		{
			Window window = \u0005\u0007\u0018.\u0018(this);
			if (window != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.A(Window)).MethodHandle;
				}
				\u001B\u0007\u0018.\u0018(P, window);
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00005DE0 File Offset: 0x00003FE0
		public bool SetDefaultProfile()
		{
			if (\u000D\u0007\u0018.\u0018(this.O) != 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.SetDefaultProfile()).MethodHandle;
				}
				\u0009\u0019\u0018.\u0018(this.O, 0);
				\u0007\u0007\u0018.\u0018(this, \u0012\u0002\u000F.\u000C(\u0006\u0007\u0018.\u0018(this.O)));
				\u0015\u001D\u0018.\u0018(\u0010\u0007\u0018.\u0014(this), true);
				\u0009\u0007\u0018.\u0018(Enumerable.ToList<Profile>(\u000A\u0019\u0018.\u0018(this)), \u0010\u0019\u0018.\u0018(this), \u0007\u0019\u0018.\u0014(this), false);
				return true;
			}
			return false;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00005E70 File Offset: 0x00004070
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u000C\u0010\u0018.\u0018(\u0018\u0010\u0018.\u0018(\u0014\u0010\u0018.\u0018(this)));
			\u000E\u0007\u0018.\u0018(this);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00005E98 File Offset: 0x00004098
		private void cmbProfiles_DropDownClosed(object sender, EventArgs e)
		{
			this.V();
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00005EAC File Offset: 0x000040AC
		private void V()
		{
			if (\u0012\u0007\u0018.\u0018(this.O) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.V()).MethodHandle;
				}
				return;
			}
			if (this.P != null)
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
				\u0006\u0019\u0018.\u0014(this, \u0012\u0004\u000F.\u000C);
				\u0014\u0019\u0018.\u0018(this.W, true);
				\u0014\u0019\u0018.\u0018(this.T, true);
				if (\u000D\u0007\u0018.\u0018(this.O) == 0)
				{
					for (;;)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					\u0014\u0019\u0018.\u0018(this.W, true);
					\u0014\u0019\u0018.\u0018(this.T, false);
					\u001C\u0007\u0018.\u0018(this.P, this, \u0013\u0007\u0018.\u0018());
					return;
				}
				if (\u001D\u0019\u0018.\u0018(\u000A\u0019\u0018.\u0018(this)) > 1)
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
					object u000C = Enumerable.ToList<Profile>(\u000A\u0019\u0018.\u0018(this));
					Action<Profile> u;
					if ((u = ProfileUserControl.<>c.\u0003) == null)
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
						u = (ProfileUserControl.<>c.\u0003 = new Action<Profile>(ProfileUserControl.<>c.\u000C.\u0012));
					}
					\u001A\u0007\u0018.\u0018(u000C, u);
					Profile profile = \u0012\u0002\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.O));
					\u0015\u001D\u0018.\u0018(profile, true);
					\u0006\u0019\u0018.\u0014(this, \u0008\u0019\u0018.\u0014(profile));
					if (\u001F\u0007\u0018.\u0014(this) != null)
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
						\u0006\u0019\u0018.\u0014(this, \u0020\u0007\u0018.\u0018(\u001F\u0007\u0018.\u0014(this)));
					}
					\u0007\u0007\u0018.\u0018(this, profile);
					\u0009\u0007\u0018.\u0018(Enumerable.ToList<Profile>(\u000A\u0019\u0018.\u0018(this)), \u0010\u0019\u0018.\u0018(this), \u0007\u0019\u0018.\u0014(this), false);
					\u001C\u0007\u0018.\u0018(this.P, this, \u0013\u0007\u0018.\u0018());
				}
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000604C File Offset: 0x0000424C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		public void InitializeComponent()
		{
			if (this.I)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.I = true;
			Uri u = \u0005\u000B\u0018.\u0018("/DiRoots.ProSheets;V2.1.2.0;component/drawingregister/profiles/profileusercontrol.xaml", UriKind.Relative);
			\u001B\u000B\u0018.\u0018(this, u);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00006094 File Offset: 0x00004294
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.S(int P, object Q)
		{
			switch (P)
			{
			case 1:
				\u0018\u0019\u0018.\u0018(\u0003\u0004\u000F.\u000C(Q), new RoutedEventHandler(this.UserControl_Loaded));
				return;
			case 2:
				this.Y = \u0016\u0004\u000F.\u000C(Q);
				return;
			case 3:
				this.O = \u000F\u0004\u000F.\u000C(Q);
				\u0003\u0010\u0018.\u0018(this.O, new EventHandler(this.cmbProfiles_DropDownClosed));
				return;
			case 4:
				this.C = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.C, new RoutedEventHandler(this.btnImportProfile_Click));
				return;
			case 5:
				this.W = \u000F\u0004\u000F.\u000C(Q);
				\u0003\u0010\u0018.\u0018(this.W, new EventHandler(this.cmbSave_DropDownClosed));
				return;
			case 6:
				this.T = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.T, new RoutedEventHandler(this.btnDeleteProfile_Click));
				return;
			default:
				this.I = true;
				return;
			}
		}

		// Token: 0x0400003E RID: 62
		[CompilerGenerated]
		private RoutedEventHandler P;

		// Token: 0x0400003F RID: 63
		[CompilerGenerated]
		private RoutedEventHandler Q;

		// Token: 0x04000040 RID: 64
		[CompilerGenerated]
		private RoutedEventHandler J;

		// Token: 0x04000041 RID: 65
		[CompilerGenerated]
		private ProfileUserControl.ProfileValidation F;

		// Token: 0x04000042 RID: 66
		[CompilerGenerated]
		private List<Type> H;

		// Token: 0x04000044 RID: 68
		[CompilerGenerated]
		private ProfileTemplate N;

		// Token: 0x04000045 RID: 69
		[CompilerGenerated]
		private Profile Z;

		// Token: 0x04000046 RID: 70
		[CompilerGenerated]
		private string M;

		// Token: 0x04000047 RID: 71
		[CompilerGenerated]
		private ObservableCollection<Profile> X;

		// Token: 0x04000048 RID: 72
		internal Image Y;

		// Token: 0x04000049 RID: 73
		internal ComboBox O;

		// Token: 0x0400004A RID: 74
		internal Button C;

		// Token: 0x0400004B RID: 75
		internal ComboBox W;

		// Token: 0x0400004C RID: 76
		internal Button T;

		// Token: 0x0400004D RID: 77
		private bool I;

		// Token: 0x02000153 RID: 339
		// (Invoke) Token: 0x06001028 RID: 4136
		public delegate string ProfileValidation(Profile profile);

		// Token: 0x02000155 RID: 341
		[CompilerGenerated]
		private sealed class \u0008\u0013\u0018
		{
			// Token: 0x06001031 RID: 4145 RVA: 0x0005A288 File Offset: 0x00058488
			internal bool \u0018(Profile \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u0008\u0007\u0018.\u0014(\u000C), \u0008\u0007\u0018.\u0014(this.\u000C));
			}

			// Token: 0x0400076E RID: 1902
			public Profile \u000C;
		}

		// Token: 0x02000156 RID: 342
		[CompilerGenerated]
		private sealed class \u0001\u0013\u0018
		{
			// Token: 0x06001033 RID: 4147 RVA: 0x0005A2C8 File Offset: 0x000584C8
			internal bool \u0018(Profile \u000C)
			{
				return \u001B\u0013\u0018.\u0018(\u0008\u0007\u0018.\u0014(\u000C), \u0004\u000B\u0018.\u0003(this.\u000C), true);
			}

			// Token: 0x0400076F RID: 1903
			public NewProFile \u000C;
		}
	}
}
