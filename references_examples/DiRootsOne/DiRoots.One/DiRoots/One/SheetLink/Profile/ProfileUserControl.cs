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
using DiRoots.One.UIBehaviours.Models;
using Microsoft.Win32;

namespace DiRoots.One.SheetLink.Profile
{
	// Token: 0x02000237 RID: 567
	public class ProfileUserControl : UserControl, IComponentConnector
	{
		// Token: 0x06001652 RID: 5714 RVA: 0x00092854 File Offset: 0x00090A54
		public ProfileUserControl()
		{
			\u0013\u000F\u0005.\u000A(this);
			ObservableCollection<BatchAction> observableCollection = new ObservableCollection<BatchAction>();
			BatchAction batchAction = new BatchAction();
			\u0016\u0007\u0019.\u000A(batchAction, \u0015\u0002\u001D.\u000A());
			\u0005\u0007\u0019.\u000A(batchAction, 10);
			\u0017\u000F\u0005.\u000A(observableCollection, batchAction);
			BatchAction batchAction2 = new BatchAction();
			\u0016\u0007\u0019.\u000A(batchAction2, \u0014\u000F\u0005.\u000A());
			\u0005\u0007\u0019.\u000A(batchAction2, 10);
			\u0017\u000F\u0005.\u000A(observableCollection, batchAction2);
			ObservableCollection<BatchAction> u000A = observableCollection;
			\u0018\u000C\u0007.\u000A(this.J, u000A);
			\u0015\u0009\u000A.\u000A(this.E, false);
		}

		// Token: 0x17000612 RID: 1554
		// (get) Token: 0x06001653 RID: 5715 RVA: 0x000928CC File Offset: 0x00090ACC
		// (set) Token: 0x06001654 RID: 5716 RVA: 0x000928E0 File Offset: 0x00090AE0
		internal static \u000E\u000E\u000A CurrentFolderHandler { get; set; }

		// Token: 0x17000613 RID: 1555
		// (get) Token: 0x06001655 RID: 5717 RVA: 0x000928F4 File Offset: 0x00090AF4
		// (set) Token: 0x06001656 RID: 5718 RVA: 0x00092908 File Offset: 0x00090B08
		public ProfileTemplate CurrentTemPlateInfo { get; set; }

		// Token: 0x17000614 RID: 1556
		// (get) Token: 0x06001657 RID: 5719 RVA: 0x0009291C File Offset: 0x00090B1C
		// (set) Token: 0x06001658 RID: 5720 RVA: 0x00092930 File Offset: 0x00090B30
		public Profile CurrentProfile { get; set; }

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x06001659 RID: 5721 RVA: 0x00092944 File Offset: 0x00090B44
		// (remove) Token: 0x0600165A RID: 5722 RVA: 0x00092994 File Offset: 0x00090B94
		public event RoutedEventHandler ProfileChanged
		{
			[CompilerGenerated]
			add
			{
				RoutedEventHandler routedEventHandler = this.D;
				RoutedEventHandler routedEventHandler2;
				do
				{
					routedEventHandler2 = routedEventHandler;
					RoutedEventHandler value2 = \u0006\u0001\u0010.\u001F(\u000F\u001E\u000A.\u000A(routedEventHandler2, value));
					routedEventHandler = Interlocked.CompareExchange<RoutedEventHandler>(ref this.D, value2, routedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.add_ProfileChanged(RoutedEventHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				RoutedEventHandler routedEventHandler = this.D;
				RoutedEventHandler routedEventHandler2;
				do
				{
					routedEventHandler2 = routedEventHandler;
					RoutedEventHandler value2 = \u0006\u0001\u0010.\u001F(\u0012\u001E\u000A.\u000A(routedEventHandler2, value));
					routedEventHandler = Interlocked.CompareExchange<RoutedEventHandler>(ref this.D, value2, routedEventHandler2);
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

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x0600165B RID: 5723 RVA: 0x000929E4 File Offset: 0x00090BE4
		// (remove) Token: 0x0600165C RID: 5724 RVA: 0x00092A34 File Offset: 0x00090C34
		public event RoutedEventHandler AddProfile
		{
			[CompilerGenerated]
			add
			{
				RoutedEventHandler routedEventHandler = this.H;
				RoutedEventHandler routedEventHandler2;
				do
				{
					routedEventHandler2 = routedEventHandler;
					RoutedEventHandler value2 = \u0006\u0001\u0010.\u001F(\u000F\u001E\u000A.\u000A(routedEventHandler2, value));
					routedEventHandler = Interlocked.CompareExchange<RoutedEventHandler>(ref this.H, value2, routedEventHandler2);
				}
				while (routedEventHandler != routedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.add_AddProfile(RoutedEventHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				RoutedEventHandler routedEventHandler = this.H;
				RoutedEventHandler routedEventHandler2;
				do
				{
					routedEventHandler2 = routedEventHandler;
					RoutedEventHandler value2 = \u0006\u0001\u0010.\u001F(\u0012\u001E\u000A.\u000A(routedEventHandler2, value));
					routedEventHandler = Interlocked.CompareExchange<RoutedEventHandler>(ref this.H, value2, routedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.remove_AddProfile(RoutedEventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x0600165D RID: 5725 RVA: 0x00092A84 File Offset: 0x00090C84
		// (remove) Token: 0x0600165E RID: 5726 RVA: 0x00092AD4 File Offset: 0x00090CD4
		public event RoutedEventHandler SaveProfile
		{
			[CompilerGenerated]
			add
			{
				RoutedEventHandler routedEventHandler = this.C;
				RoutedEventHandler routedEventHandler2;
				do
				{
					routedEventHandler2 = routedEventHandler;
					RoutedEventHandler value2 = \u0006\u0001\u0010.\u001F(\u000F\u001E\u000A.\u000A(routedEventHandler2, value));
					routedEventHandler = Interlocked.CompareExchange<RoutedEventHandler>(ref this.C, value2, routedEventHandler2);
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
				RoutedEventHandler routedEventHandler = this.C;
				RoutedEventHandler routedEventHandler2;
				do
				{
					routedEventHandler2 = routedEventHandler;
					RoutedEventHandler value2 = \u0006\u0001\u0010.\u001F(\u0012\u001E\u000A.\u000A(routedEventHandler2, value));
					routedEventHandler = Interlocked.CompareExchange<RoutedEventHandler>(ref this.C, value2, routedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.remove_SaveProfile(RoutedEventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x17000615 RID: 1557
		// (get) Token: 0x0600165F RID: 5727 RVA: 0x00092B24 File Offset: 0x00090D24
		// (set) Token: 0x06001660 RID: 5728 RVA: 0x00092B38 File Offset: 0x00090D38
		public string FileSuffix { get; set; }

		// Token: 0x17000616 RID: 1558
		// (get) Token: 0x06001661 RID: 5729 RVA: 0x00092B4C File Offset: 0x00090D4C
		// (set) Token: 0x06001662 RID: 5730 RVA: 0x00092B60 File Offset: 0x00090D60
		public ObservableCollection<Profile> List { get; set; }

		// Token: 0x17000617 RID: 1559
		// (get) Token: 0x06001663 RID: 5731 RVA: 0x00092B74 File Offset: 0x00090D74
		// (set) Token: 0x06001664 RID: 5732 RVA: 0x00092B88 File Offset: 0x00090D88
		public ProfileUserControl.ProfileValidation IsValidProfile { get; set; }

		// Token: 0x06001665 RID: 5733 RVA: 0x00092B9C File Offset: 0x00090D9C
		public void LoadProfile()
		{
			if (\u001A\u000F\u0005.\u000A(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.LoadProfile()).MethodHandle;
				}
				\u0004\u0012\u0005.\u000A(this, \u0019\u0012\u0005.\u000A(Profile.\u0007(\u0018\u0012\u0005.\u000A(this))));
				if (\u001D\u0012\u0005.\u000A(\u001A\u000F\u0005.\u000A(this)) == 0)
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
					Profile.\u001F(\u001A\u000F\u0005.\u000A(this));
				}
				else
				{
					\u0015\u0006\u0005.\u000A(\u0007\u0012\u0005.\u000A(\u001A\u000F\u0005.\u000A(this), 0), \u0012\u000F\u0005.\u000A());
				}
			}
			List<Profile>.Enumerator enumerator = \u000A\u0012\u0005.\u000A(Enumerable.ToList<Profile>(\u001A\u000F\u0005.\u000A(this)));
			try
			{
				while (\u000C\u000F\u0005.\u000A(ref enumerator))
				{
					Profile profile = \u001F\u0012\u0005.\u000A(ref enumerator);
					if (!\u0009\u000F\u0005.\u000A(profile))
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
						if (!\u0010\u0002\u001D.\u000A(\u0001\u000F\u0005.\u000A(profile)))
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
							\u0015\u000F\u0005.\u000A(\u001A\u000F\u0005.\u000A(this), profile);
						}
					}
				}
				for (;;)
				{
					switch (3)
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
			\u0018\u000C\u0007.\u000A(this.W, \u001A\u000F\u0005.\u000A(this));
			\u0004\u000C\u000A.\u000A(this.W, 0);
		}

		// Token: 0x06001666 RID: 5734 RVA: 0x00092CE0 File Offset: 0x00090EE0
		private void btnImportProfile_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				OpenFileDialog u001F = \u0003\u0012\u0005.\u000A();
				\u0012\u0012\u0005.\u000A(u001F, "Xml Files (.xml)|*.xml");
				bool? flag = \u000F\u0012\u0005.\u000A(u001F);
				if (\u0012\u0015\u000A.\u000A(ref flag))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.btnImportProfile_Click(object, RoutedEventArgs)).MethodHandle;
					}
					ProfileUserControl.\u0003\u001C u0003_u001C = new ProfileUserControl.\u0003\u001C();
					string u001F2 = \u0006\u0012\u0005.\u000A(u001F);
					u0003_u001C.\u001F = Profile.\u0004(u001F2);
					if (u0003_u001C.\u001F != null)
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
						if (\u0016\u0012\u0005.\u000A(u0003_u001C.\u001F) != null)
						{
							Profile profile = Enumerable.FirstOrDefault<Profile>(\u001A\u000F\u0005.\u000A(this), new Func<Profile, bool>(u0003_u001C.\u000A));
							if (profile != null)
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
								if (!\u000F\u0005\u0019.\u000A(\u000B\u0012\u0005.\u000A(), this, MessageBoxButtons.YesNo))
								{
									return;
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
								\u0015\u000F\u0005.\u000A(\u001A\u000F\u0005.\u000A(this), profile);
							}
							\u000A\u001A\u0018.\u001D(this, \u0016\u0012\u0005.\u000A(u0003_u001C.\u001F));
							this.O(u0003_u001C.\u001F, true);
							goto IL_116;
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
					\u000F\u0005\u0019.\u000A(\u0002\u0012\u0005.\u000A(), this, MessageBoxButtons.OK);
				}
				IL_116:;
			}
			catch (Exception)
			{
				\u0008\u0011\u001D.\u000A(\u0005\u0012\u0005.\u000A());
			}
		}

		// Token: 0x06001667 RID: 5735 RVA: 0x00092E34 File Offset: 0x00091034
		private void cmbSave_DropDownClosed(object sender, EventArgs e)
		{
			BatchAction batchAction = \u000C\u0018\u000E.\u001F(\u0019\u000C\u0007.\u001D(this.J));
			if (batchAction == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.cmbSave_DropDownClosed(object, EventArgs)).MethodHandle;
				}
				return;
			}
			if (this.C != null)
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
				\u000B\u0015\u000A.\u000A(this.C, this, \u0002\u0015\u000A.\u000A());
				if (\u0012\u000C\u000A.\u000A(this.W) <= 0)
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
					this.P();
				}
				else
				{
					Profile f = \u000A\u0012\u000E.\u001F(\u0019\u000C\u0007.\u001D(this.W));
					if (\u0008\u0013\u000A.\u000A(\u0013\u000B\u0019.\u0007(batchAction), \u0015\u0002\u001D.\u000A()))
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
						this.V(f);
					}
					else if (\u0008\u0013\u000A.\u000A(\u0013\u000B\u0019.\u0007(batchAction), \u0014\u000F\u0005.\u000A()))
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
						this.P();
					}
				}
			}
			\u0012\u0002\u0019.\u000A(this.J, \u0019\u001D\u000E.\u001F);
			\u0004\u000C\u000A.\u000A(this.J, -1);
		}

		// Token: 0x06001668 RID: 5736 RVA: 0x00092F3C File Offset: 0x0009113C
		private void V(Profile F)
		{
			\u001C\u0012\u0005.\u000A(F, \u000D\u0012\u0005.\u000A(\u0018\u0013\u0018.\u001D(this)));
			Profile.\u000A(Enumerable.ToList<Profile>(\u001A\u000F\u0005.\u000A(this)), \u0018\u0012\u0005.\u000A(this), false);
		}

		// Token: 0x06001669 RID: 5737 RVA: 0x00092F80 File Offset: 0x00091180
		private void P()
		{
			string u001E = \u001E\u000F\u0005.\u000A().\u001E;
			IEnumerable<Profile> enumerable = \u001A\u000F\u0005.\u000A(this);
			Func<Profile, string> func;
			if ((func = ProfileUserControl.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.P()).MethodHandle;
				}
				func = (ProfileUserControl.<>c.\u000A = new Func<Profile, string>(ProfileUserControl.<>c.\u001F.\u0004));
			}
			NewProFile newProFile = \u0010\u0012\u0005.\u000A(u001E, Enumerable.ToList<string>(Enumerable.Select<Profile, string>(enumerable, func)));
			this.T(newProFile);
			bool? flag = \u0018\u0020\u000A.\u0007(newProFile);
			if (\u0012\u0015\u000A.\u000A(ref flag))
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
				Profile f = \u0009\u000F\u000E.\u001F;
				\u000B\u0015\u000A.\u000A(this.H, this, \u0002\u0015\u000A.\u000A());
				f = \u000C\u0006\u0005.\u001D(newProFile);
				this.O(f, false);
			}
		}

		// Token: 0x0600166A RID: 5738 RVA: 0x0009303C File Offset: 0x0009123C
		private void O(Profile F, bool R)
		{
			try
			{
				\u001B\u0012\u0005.\u000A(this, F);
				\u001C\u0012\u0005.\u000A(F, \u000D\u0012\u0005.\u000A(\u0018\u0013\u0018.\u001D(this)));
				\u000F\u000F\u0005.\u000A(F, true);
				if (!R)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.O(Profile, bool)).MethodHandle;
					}
					if (!Profile.\u001D(F, \u0001\u000F\u0005.\u000A(F), true))
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
						return;
					}
					\u001E\u000F\u0005.\u000A().\u001E = \u0001\u000F\u0005.\u000A(F);
				}
				object u001F = Enumerable.ToList<Profile>(\u001A\u000F\u0005.\u000A(this));
				Action<Profile> u000A;
				if ((u000A = ProfileUserControl.<>c.\u0007) == null)
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
					u000A = (ProfileUserControl.<>c.\u0007 = new Action<Profile>(ProfileUserControl.<>c.\u001F.\u0019));
				}
				\u0008\u0012\u0005.\u000A(u001F, u000A);
				\u0002\u000F\u0005.\u000A(\u001A\u000F\u0005.\u000A(this), F);
				\u0012\u0002\u0019.\u000A(this.W, F);
				Profile.\u000A(Enumerable.ToList<Profile>(\u001A\u000F\u0005.\u000A(this)), \u0018\u0012\u0005.\u000A(this), !R);
			}
			catch (Exception)
			{
				\u0008\u0011\u001D.\u000A(\u000E\u0012\u0005.\u000A());
			}
		}

		// Token: 0x0600166B RID: 5739 RVA: 0x00093158 File Offset: 0x00091358
		private void btnDeleteProfile_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (\u0019\u000C\u0007.\u001D(this.W) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.btnDeleteProfile_Click(object, RoutedEventArgs)).MethodHandle;
					}
				}
				else
				{
					string u000A = \u001A\u000C\u000A.\u000A(\u0012\u0013\u0018.\u000A(\u000A\u0012\u000E.\u001F(\u0019\u000C\u0007.\u001D(this.W))));
					if (\u0011\u001F\u0019.\u000A(\u0017\u0006\u0007.\u000A(\u001E\u0012\u0005.\u000A(), u000A), MessageBoxButtons.YesNo))
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
						List<Profile>.Enumerator enumerator = \u000A\u0012\u0005.\u000A(Enumerable.ToList<Profile>(\u001A\u000F\u0005.\u000A(this)));
						try
						{
							while (\u000C\u000F\u0005.\u000A(ref enumerator))
							{
								Profile profile = \u001F\u0012\u0005.\u000A(ref enumerator);
								if (\u0008\u0013\u000A.\u000A(\u0012\u0013\u0018.\u000A(profile), u000A))
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
									\u0015\u000F\u0005.\u000A(\u001A\u000F\u0005.\u000A(this), profile);
									goto IL_E7;
								}
							}
							for (;;)
							{
								switch (3)
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
						IL_E7:
						\u0004\u000C\u000A.\u000A(this.W, 0);
						\u001B\u0012\u0005.\u000A(this, \u000A\u0012\u000E.\u001F(\u0011\u0012\u0005.\u000A(this.W)));
						\u000F\u000F\u0005.\u000A(\u001F\u0013\u0018.\u001D(this), true);
						Profile.\u000A(Enumerable.ToList<Profile>(\u001A\u000F\u0005.\u000A(this)), \u0018\u0012\u0005.\u000A(this), false);
					}
				}
			}
			catch (Exception u000A2)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Profile\\ProfileUserControl.xaml.cs", "btnDeleteProfile_Click");
			}
		}

		// Token: 0x0600166C RID: 5740 RVA: 0x000932F0 File Offset: 0x000914F0
		private void cmbProfiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (\u0019\u000C\u0007.\u001D(this.W) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.cmbProfiles_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				return;
			}
			if (this.D != null)
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
				\u000A\u001A\u0018.\u001D(this, \u0004\u0012\u000E.\u001F);
				\u0015\u0009\u000A.\u000A(this.J, true);
				\u0015\u0009\u000A.\u000A(this.E, true);
				if (\u0012\u000C\u000A.\u000A(this.W) == 0)
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
					\u0015\u0009\u000A.\u000A(this.J, true);
					\u0015\u0009\u000A.\u000A(this.E, false);
					return;
				}
				if (\u001D\u0012\u0005.\u000A(\u001A\u000F\u0005.\u000A(this)) > 1)
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
					object u001F = Enumerable.ToList<Profile>(\u001A\u000F\u0005.\u000A(this));
					Action<Profile> u000A;
					if ((u000A = ProfileUserControl.<>c.\u001D) == null)
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
						u000A = (ProfileUserControl.<>c.\u001D = new Action<Profile>(ProfileUserControl.<>c.\u001F.\u0018));
					}
					\u0008\u0012\u0005.\u000A(u001F, u000A);
					Profile profile = \u000A\u0012\u000E.\u001F(\u0019\u000C\u0007.\u001D(this.W));
					\u000F\u000F\u0005.\u000A(profile, true);
					\u000A\u001A\u0018.\u001D(this, \u0016\u0012\u0005.\u000A(profile));
					if (\u0018\u0013\u0018.\u001D(this) != null)
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
						\u000A\u001A\u0018.\u001D(this, \u000D\u0012\u0005.\u000A(\u0018\u0013\u0018.\u001D(this)));
					}
					\u001B\u0012\u0005.\u000A(this, profile);
					Profile.\u000A(Enumerable.ToList<Profile>(\u001A\u000F\u0005.\u000A(this)), \u0018\u0012\u0005.\u000A(this), false);
					\u000B\u0015\u000A.\u000A(this.D, this, \u0002\u0015\u000A.\u000A());
				}
			}
		}

		// Token: 0x0600166D RID: 5741 RVA: 0x00093474 File Offset: 0x00091674
		private void T(Window F)
		{
			Window window = \u0020\u0012\u0005.\u000A(this);
			if (window != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.T(Window)).MethodHandle;
				}
				\u000C\u000E\u0007.\u0007(F, window);
			}
		}

		// Token: 0x0600166E RID: 5742 RVA: 0x000934A8 File Offset: 0x000916A8
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x0600166F RID: 5743 RVA: 0x000934D0 File Offset: 0x000916D0
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.N)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileUserControl.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.N = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink.core/profile/profileusercontrol.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001670 RID: 5744 RVA: 0x00093518 File Offset: 0x00091718
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.M(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u0001\u0002\u000E.\u001F(R), new RoutedEventHandler(this.UserControl_Loaded));
				return;
			case 2:
				this.U = \u0015\u0002\u000E.\u001F(R);
				return;
			case 3:
				this.W = \u000B\u000A\u000E.\u001F(R);
				\u001B\u000C\u000A.\u0007(this.W, new SelectionChangedEventHandler(this.cmbProfiles_SelectionChanged));
				return;
			case 4:
				this.K = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.K, new RoutedEventHandler(this.btnImportProfile_Click));
				return;
			case 5:
				this.J = \u000B\u000A\u000E.\u001F(R);
				\u001C\u0018\u0005.\u000A(this.J, new EventHandler(this.cmbSave_DropDownClosed));
				return;
			case 6:
				this.E = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.E, new RoutedEventHandler(this.btnDeleteProfile_Click));
				return;
			default:
				this.N = true;
				return;
			}
		}

		// Token: 0x040008DC RID: 2268
		[CompilerGenerated]
		private ProfileTemplate F;

		// Token: 0x040008DD RID: 2269
		[CompilerGenerated]
		private Profile R;

		// Token: 0x040008DE RID: 2270
		[CompilerGenerated]
		private RoutedEventHandler D;

		// Token: 0x040008DF RID: 2271
		[CompilerGenerated]
		private RoutedEventHandler H;

		// Token: 0x040008E0 RID: 2272
		[CompilerGenerated]
		private RoutedEventHandler C;

		// Token: 0x040008E1 RID: 2273
		[CompilerGenerated]
		private string L;

		// Token: 0x040008E2 RID: 2274
		[CompilerGenerated]
		private ObservableCollection<Profile> S;

		// Token: 0x040008E3 RID: 2275
		[CompilerGenerated]
		private ProfileUserControl.ProfileValidation B;

		// Token: 0x040008E4 RID: 2276
		internal Image U;

		// Token: 0x040008E5 RID: 2277
		internal ComboBox W;

		// Token: 0x040008E6 RID: 2278
		internal Button K;

		// Token: 0x040008E7 RID: 2279
		internal ComboBox J;

		// Token: 0x040008E8 RID: 2280
		internal Button E;

		// Token: 0x040008E9 RID: 2281
		private bool N;

		// Token: 0x02000906 RID: 2310
		// (Invoke) Token: 0x0600516E RID: 20846
		public delegate string ProfileValidation(Profile profile);

		// Token: 0x02000908 RID: 2312
		[CompilerGenerated]
		private sealed class \u0003\u001C
		{
			// Token: 0x06005177 RID: 20855 RVA: 0x001E8BF0 File Offset: 0x001E6DF0
			internal bool \u000A(Profile \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0012\u0013\u0018.\u000A(\u001F), \u0012\u0013\u0018.\u000A(this.\u001F));
			}

			// Token: 0x040023B8 RID: 9144
			public Profile \u001F;
		}
	}
}
