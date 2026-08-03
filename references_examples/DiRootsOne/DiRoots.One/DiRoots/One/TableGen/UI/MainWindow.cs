using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.Profiles;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.TableGen.Models;
using DiRoots.One.TableGen.TableGen.ViewModels.StyleMappings;
using DiRoots.One.TableGen.TGRevitHelper;
using DiRoots.One.TableGen.ViewModels;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.StyleMapping;
using DiRoots.One.UIBehaviours.Models;

namespace DiRoots.One.TableGen.UI
{
	// Token: 0x0200015A RID: 346
	public class MainWindow : DiRootsWindow, IComponentConnector, IStyleConnector
	{
		// Token: 0x06000CD5 RID: 3285 RVA: 0x00050D4C File Offset: 0x0004EF4C
		public MainWindow()
		{
			\u001C\u000C\u0007.\u0007(this, \u0007\u0018.\u0007<ICustomLogger>());
			SelectedExcel.XR += this.GDR;
			\u0009\u0008\u0004.\u000A(false);
			this.C = new MainWindowViewModel();
			\u000A\u000C\u0007.\u0007(this.C, this);
			\u0006\u0019\u0019.\u000A(this.C, new Func<StyleMappingDto>(this.HYR));
			\u0002\u0019\u0019.\u000A(this.C, new Func<Profile>(this.YYR));
			\u0017\u001A\u000A.\u0007(this, this.C);
			\u000B\u0019\u0019.\u000A(this);
			\u0016\u0019\u0019.\u000A(false);
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x00050DEC File Offset: 0x0004EFEC
		private void ADR(bool F)
		{
			List<ReportInfo> f = \u0010\u001D\u0019.\u000A();
			List<SelectedExcel> list = \u0003\u000B\u0004.\u000A();
			List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(\u001C\u001B\u0004.\u000A());
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					SelectedExcel selectedExcel = \u001F\u0016\u0004.\u000A(ref enumerator);
					if (\u0001\u0016\u0004.\u0007(selectedExcel) != UpdateStates.ToAdd)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.ADR(bool)).MethodHandle;
						}
						if (\u0001\u0016\u0004.\u0007(selectedExcel) == UpdateStates.ToDuplicate)
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
						}
						else
						{
							if (!\u001F\u001E\u0004.\u000A(selectedExcel))
							{
								continue;
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
							if (\u0009\u0005\u0004.\u000A(selectedExcel) <= 0L)
							{
								continue;
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
							ElementId u000A = \u001E\u0001\u000A.\u000A(\u0009\u0005\u0004.\u000A(selectedExcel));
							if (\u0011\u0017\u000A.\u0007(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()), u000A) != null)
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
								\u001A\u0016\u0004.\u000A(list, selectedExcel);
								continue;
							}
							continue;
						}
					}
					\u0013\u0011\u0004.\u001D(selectedExcel);
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			this.PHR(f);
			if (\u000C\u001B\u0004.\u000A(list) > 0)
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
				\u0011\u0019\u0019.\u000A(true);
				\u001B\u0019\u0019.\u000A(true);
				\u000E\u0019\u0019.\u000A(\u0003\u0019\u0019.\u000A(), \u0008\u0019\u0019.\u000A());
				\u0010\u0019\u0019.\u000A(\u0003\u0019\u0019.\u000A(), false);
				\u000D\u0019\u0019.\u0007(\u0003\u0019\u0019.\u000A(), F);
				\u001C\u0019\u0019.\u0007(\u0003\u0019\u0019.\u000A(), !F);
				\u0012\u0019\u0019.\u000A(\u0003\u0019\u0019.\u000A(), list);
				\u0011\u001E\u000A.\u000A(\u000F\u0019\u0019.\u000A());
			}
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x00050F80 File Offset: 0x0004F180
		private void GDR(bool F)
		{
			if (F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.GDR(bool)).MethodHandle;
				}
				\u0011\u001F\u0019.\u000A(\u001E\u0019\u0019.\u000A(), MessageBoxButtons.OK);
			}
			this.RD = true;
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x00050FBC File Offset: 0x0004F1BC
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			this.SHR();
			\u0014\u001A\u000A.\u000A(this.NR, \u0004\u001E\u000A.\u000A(\u0007\u0018\u0019.\u000A(), " 0%"));
			\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "Main Window Loading", "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\UI\\Windows\\MainWindow.xaml.cs", "Window_Loaded");
			List<SelectedExcel> list = SchemaUtil.\u001D(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()));
			\u0001\u0007\u0019.\u000A(list, \u0004\u0002.\u0016(list));
			\u000A\u0018\u0019.\u000A(\u0016\u001E\u0004.\u000A());
			List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(list);
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					SelectedExcel u001F = \u001F\u0016\u0004.\u000A(ref enumerator);
					\u001A\u0011\u0004.\u001D(u001F);
					if (\u0001\u0016\u0004.\u0007(u001F) == UpdateStates.Modified)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.Window_Loaded(object, RoutedEventArgs)).MethodHandle;
						}
						if (!\u0017\u001B\u0004.\u001D(u001F))
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
							\u000D\u0016\u0004.\u0007(u001F, UpdateStates.Updated);
						}
					}
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			enumerator = \u000A\u0016\u0004.\u000A(list);
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					SelectedExcel u001F2 = \u001F\u0016\u0004.\u000A(ref enumerator);
					\u0001\u0020\u0004.\u000A(u001F2, false);
					\u001F\u0018\u0019.\u000A(u001F2, false);
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
			IEnumerable<SelectedExcel> enumerable = list;
			Func<SelectedExcel, bool> func;
			if ((func = MainWindow.<>c.\u000A) == null)
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
				func = (MainWindow.<>c.\u000A = new Func<SelectedExcel, bool>(MainWindow.<>c.\u001F.\u0006));
			}
			object u001F3 = Enumerable.ToList<SelectedExcel>(Enumerable.Where<SelectedExcel>(enumerable, func));
			Action<SelectedExcel> u000A;
			if ((u000A = MainWindow.<>c.\u0007) == null)
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
				u000A = (MainWindow.<>c.\u0007 = new Action<SelectedExcel>(MainWindow.<>c.\u001F.\u000F));
			}
			\u0009\u0019\u0019.\u000A(u001F3, u000A);
			\u0001\u0019\u0019.\u000A(list);
			\u0015\u0019\u0019.\u000A(this.C);
			\u0016\u000C\u0007.\u000A(this, "");
			this.FD = \u000C\u0019\u0019.\u000A();
			\u001A\u0019\u0019.\u000A(this.FD, new EventHandler(this.DispatcherTimer_Tick));
			\u0013\u0019\u0019.\u000A(this.FD, \u0006\u0001\u000A.\u000A(1000.0));
			\u0014\u0019\u0019.\u000A(this.FD);
			\u0005\u0002.\u001D(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()), \u001C\u001B\u0004.\u000A());
			SelectedExcel.PR += this.ADR;
			this.FHR();
			this.RHR();
			\u0002\u0005.\u0001(\u0017\u0019\u0019.\u000A(this), \u001C\u001B\u0004.\u000A());
			\u0020\u0019\u0019.\u000A(this.C, this.MHR());
			\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "Main Window Loading", "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\UI\\Windows\\MainWindow.xaml.cs", "Window_Loaded");
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x0005125C File Offset: 0x0004F45C
		private void FHR()
		{
			try
			{
				\u0010\u0016.\u000D\u0016 u000D_u = \u0010\u0016.\u0007(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()));
				if (u000D_u == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.FHR()).MethodHandle;
					}
				}
				else
				{
					\u0004\u0018\u0019.\u000A(this, \u0019\u0018\u0019.\u0007(u000D_u));
					string dd;
					if ((dd = \u001D\u0018\u0019.\u000A(u000D_u)) == null)
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
						dd = string.Empty;
					}
					this.DD = dd;
				}
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\UI\\Windows\\MainWindow.xaml.cs", "LoadStyleMappingSnapshotFromDocument");
			}
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x000512F0 File Offset: 0x0004F4F0
		private void RHR()
		{
			try
			{
				\u0004\u0015\u0007.\u000A(new \u000E\u000E\u000A("DiRootsOne", "TableGen", \u0007\u0018.\u0007<ICustomLogger>()));
				List<Type> list = \u000D\u0018\u0019.\u000A();
				\u000A\u0015\u0007.\u000A(list, \u001E\u0011\u000A.\u000A(\u0007\u0005\u000E.\u001F()));
				List<Type> u000A = list;
				this.HD = \u001C\u0018\u0019.\u000A(Profile.\u0007("TGStyleMapping", u000A));
				if (\u0003\u0018\u0019.\u000A(this.HD) == 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.RHR()).MethodHandle;
					}
					Profile.\u001F(this.HD);
				}
				else
				{
					\u000F\u0018\u0019.\u000A(\u0012\u0018\u0019.\u000A(this.HD, 0), \u000A\u000F\u001D.\u000A());
				}
				List<Profile>.Enumerator enumerator = \u0006\u0018\u0019.\u000A(Enumerable.ToList<Profile>(this.HD));
				try
				{
					while (\u0018\u0018\u0019.\u000A(ref enumerator))
					{
						Profile profile = \u0002\u0018\u0019.\u000A(ref enumerator);
						if (!\u000B\u0018\u0019.\u000A(profile))
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
							if (!\u0010\u0002\u001D.\u000A(\u0016\u0018\u0019.\u000A(profile)))
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
								\u0005\u0018\u0019.\u000A(this.HD, profile);
							}
						}
					}
					for (;;)
					{
						switch (6)
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
				this.YD = this.DHR();
			}
			catch (Exception u000A2)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\UI\\Windows\\MainWindow.xaml.cs", "InitializeStyleMappingProfiles");
			}
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x0005147C File Offset: 0x0004F67C
		private Profile DHR()
		{
			MainWindow.\u001D\u000B u001D_u000B = new MainWindow.\u001D\u000B();
			if (this.HD != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.DHR()).MethodHandle;
				}
				if (\u0003\u0018\u0019.\u000A(this.HD) != 0)
				{
					u001D_u000B.\u001F = \u0012\u0018\u0019.\u000A(this.HD, 0);
					u001D_u000B.\u000A = this.DD;
					u001D_u000B.\u001D = \u0017\u0019\u0019.\u000A(this);
					if (!\u001A\u0006\u0007.\u000A(u001D_u000B.\u000A))
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
						if (u001D_u000B.\u001D == null)
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
						}
						else
						{
							u001D_u000B.\u0007 = \u0015\u000F\u0007.\u000A(\u0002\u0013\u000A.\u000A("^", \u0004\u000C\u0004.\u000A(u001D_u000B.\u000A), " \\([0-9]+\\)$"));
							Profile profile = Enumerable.FirstOrDefault<Profile>(Enumerable.Where<Profile>(this.HD, new Func<Profile, bool>(u001D_u000B.\u0004)), new Func<Profile, bool>(u001D_u000B.\u0019));
							if (profile != null)
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
								return profile;
							}
							if (!Enumerable.Any<Profile>(this.HD, new Func<Profile, bool>(u001D_u000B.\u0018)))
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
								Profile profile2 = MainWindow.YHR(u001D_u000B.\u000A, u001D_u000B.\u001D);
								\u0010\u0018\u0019.\u000A(this.HD, profile2);
								return profile2;
							}
							Profile profile3 = MainWindow.YHR(MainWindow.CHR(this.HD, u001D_u000B.\u000A), u001D_u000B.\u001D);
							\u0010\u0018\u0019.\u000A(this.HD, profile3);
							return profile3;
						}
					}
					return u001D_u000B.\u001F;
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
			}
			return null;
		}

		// Token: 0x06000CDC RID: 3292 RVA: 0x00051604 File Offset: 0x0004F804
		private static bool HHR(Profile F, StyleMappingDto R)
		{
			object u001F;
			if (F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.HHR(Profile, StyleMappingDto)).MethodHandle;
				}
				u001F = null;
			}
			else
			{
				u001F = \u001C\u000D\u0004.\u001D(F);
			}
			StyleMappingProfileTemplate styleMappingProfileTemplate = \u0017\u0019\u000E.\u001F(u001F);
			if (styleMappingProfileTemplate == null)
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
				return false;
			}
			StyleMappingDto styleMappingDto = \u0003\u000D\u0004.\u000A(styleMappingProfileTemplate);
			if (styleMappingDto != null)
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
				return \u000E\u0018\u0019.\u000A(styleMappingDto, R);
			}
			return false;
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x0005166C File Offset: 0x0004F86C
		private static Profile YHR(string F, StyleMappingDto R)
		{
			Profile profile = \u0020\u0018\u0019.\u000A();
			\u000F\u0018\u0019.\u000A(profile, F);
			\u001E\u0018\u0019.\u000A(profile, true);
			\u0011\u0018\u0019.\u000A(profile, true);
			\u0008\u0018\u0019.\u000A(profile, \u001B\u0018\u0019.\u000A(R));
			return profile;
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x000516A4 File Offset: 0x0004F8A4
		private static string CHR(IEnumerable<Profile> F, string R)
		{
			Func<Profile, string> func;
			if ((func = MainWindow.<>c.\u001D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.CHR(IEnumerable<Profile>, string)).MethodHandle;
				}
				func = (MainWindow.<>c.\u001D = new Func<Profile, string>(MainWindow.<>c.\u001F.\u0012));
			}
			HashSet<string> u001F = \u0014\u0018\u0019.\u000A(Enumerable.Select<Profile, string>(F, func), \u0013\u0018\u0019.\u000A());
			int num = 1;
			string text;
			for (;;)
			{
				text = \u0018\u000E\u0007.\u000A("{0} ({1})", R, num);
				if (!\u0017\u0018\u0019.\u000A(u001F, text))
				{
					break;
				}
				num++;
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
			return text;
		}

		// Token: 0x06000CDF RID: 3295 RVA: 0x0005172C File Offset: 0x0004F92C
		private string LHR(Profile F)
		{
			if (F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.LHR(Profile)).MethodHandle;
				}
				return string.Empty;
			}
			if (this.HD != null)
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
				if (\u0003\u0018\u0019.\u000A(this.HD) > 0)
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
					if (F == \u0012\u0018\u0019.\u000A(this.HD, 0))
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
						return string.Empty;
					}
				}
			}
			string result;
			if ((result = \u001A\u0018\u0019.\u0007(F)) == null)
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
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000CE0 RID: 3296 RVA: 0x000517C0 File Offset: 0x0004F9C0
		private void DispatcherTimer_Tick(object sender, EventArgs e)
		{
			if (this.RD)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.DispatcherTimer_Tick(object, EventArgs)).MethodHandle;
				}
				\u000C\u0018\u0019.\u000A(\u001C\u0015\u0007.\u0007(this), new Action(this.C.HKR));
				this.RD = false;
			}
			this.SHR();
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x00051814 File Offset: 0x0004FA14
		private void DiRootsWindow_Activated(object sender, EventArgs e)
		{
			this.RD = true;
		}

		// Token: 0x06000CE2 RID: 3298 RVA: 0x00051828 File Offset: 0x0004FA28
		private void SHR()
		{
			int num = \u000C\u001B\u0004.\u000A(\u001C\u001B\u0004.\u000A());
			IEnumerable<SelectedExcel> enumerable = \u001C\u001B\u0004.\u000A();
			Func<SelectedExcel, bool> func;
			if ((func = MainWindow.<>c.\u0004) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.SHR()).MethodHandle;
				}
				func = (MainWindow.<>c.\u0004 = new Func<SelectedExcel, bool>(MainWindow.<>c.\u001F.\u0003));
			}
			int num2 = \u000C\u001B\u0004.\u000A(Enumerable.ToList<SelectedExcel>(Enumerable.Where<SelectedExcel>(enumerable, func)));
			IEnumerable<SelectedExcel> enumerable2 = \u001C\u001B\u0004.\u000A();
			Func<SelectedExcel, bool> func2;
			if ((func2 = MainWindow.<>c.\u0019) == null)
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
				func2 = (MainWindow.<>c.\u0019 = new Func<SelectedExcel, bool>(MainWindow.<>c.\u001F.\u001C));
			}
			int num3 = \u000C\u001B\u0004.\u000A(Enumerable.ToList<SelectedExcel>(Enumerable.Where<SelectedExcel>(enumerable2, func2)));
			IEnumerable<SelectedExcel> enumerable3 = \u001C\u001B\u0004.\u000A();
			Func<SelectedExcel, bool> func3;
			if ((func3 = MainWindow.<>c.\u0018) == null)
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
				func3 = (MainWindow.<>c.\u0018 = new Func<SelectedExcel, bool>(MainWindow.<>c.\u001F.\u000D));
			}
			int num4 = \u000C\u001B\u0004.\u000A(Enumerable.ToList<SelectedExcel>(Enumerable.Where<SelectedExcel>(enumerable3, func3)));
			IEnumerable<SelectedExcel> enumerable4 = \u001C\u001B\u0004.\u000A();
			Func<SelectedExcel, bool> func4;
			if ((func4 = MainWindow.<>c.\u0005) == null)
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
				func4 = (MainWindow.<>c.\u0005 = new Func<SelectedExcel, bool>(MainWindow.<>c.\u001F.\u0010));
			}
			int num5 = \u000C\u001B\u0004.\u000A(Enumerable.ToList<SelectedExcel>(Enumerable.Where<SelectedExcel>(enumerable4, func4)));
			object kr = this.KR;
			string u001F = "{0} {1} | {2} {3} | {4} {5}";
			object[] array = \u0004\u0015\u0010.\u001F(6);
			array[0] = \u000A\u0005\u0019.\u000A();
			array[1] = num;
			array[2] = \u001F\u0005\u0019.\u000A();
			array[3] = num2;
			array[4] = \u0009\u0018\u0019.\u000A();
			array[5] = num3;
			string u001F2 = \u001C\u0015\u001D.\u000A(u001F, array);
			string u001F3 = " | {0} {1} | {2} {3}";
			object[] array2 = \u0004\u0015\u0010.\u001F(4);
			array2[0] = \u0001\u0018\u0019.\u000A();
			array2[1] = num4;
			array2[2] = \u0015\u0018\u0019.\u000A();
			array2[3] = num5;
			\u0014\u001A\u000A.\u000A(kr, \u0004\u001E\u000A.\u000A(u001F2, \u001C\u0015\u001D.\u000A(u001F3, array2)));
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x00051A00 File Offset: 0x0004FC00
		private string BHR(string F, int R)
		{
			return \u0002\u0013\u000A.\u000A(F, " Copy ", \u0003\u001F\u0019.\u000A(ref R, "D3"));
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x00051A28 File Offset: 0x0004FC28
		private bool UHR(string F, ViewType R)
		{
			MainWindow.\u0004\u000B u0004_u000B = new MainWindow.\u0004\u000B();
			u0004_u000B.\u001F = R;
			u0004_u000B.\u000A = F;
			bool result = !Enumerable.Any<SelectedExcel>(\u001C\u001B\u0004.\u000A(), new Func<SelectedExcel, bool>(u0004_u000B.\u0007));
			if (\u0015\u0018.\u000A(u0004_u000B.\u001F, u0004_u000B.\u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.UHR(string, ViewType)).MethodHandle;
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x00051A94 File Offset: 0x0004FC94
		private void DgViews_PreviewDrag(object sender, DragEventArgs e)
		{
			if (\u001D\u0005\u0019.\u000A(\u0004\u0005\u0019.\u000A(this)) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.DgViews_PreviewDrag(object, DragEventArgs)).MethodHandle;
				}
				\u0007\u0005\u0019.\u000A(e, DragDropEffects.None);
				\u0019\u0013\u000A.\u000A(e, true);
			}
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x00051AD4 File Offset: 0x0004FCD4
		private void WHR(SelectedExcel F)
		{
			SelectedExcel selectedExcel = \u0001\u0009\u0004.\u000A(\u0006\u0020\u001D.\u0007(F));
			\u000D\u0016\u0004.\u0007(selectedExcel, UpdateStates.ToDuplicate);
			\u0001\u001B\u0004.\u000A(selectedExcel, \u000E\u0016\u0004.\u000A(F));
			\u000C\u0011\u0004.\u001D(selectedExcel, \u0011\u0020\u001D.\u0007(F));
			\u0014\u0020\u0004.\u000A(selectedExcel, \u0013\u0008\u0004.\u001D(F));
			\u001E\u0008\u0004.\u001D(selectedExcel, \u0017\u0008\u0004.\u001D(F));
			\u001E\u0016\u0004.\u000A(selectedExcel, \u000F\u001B\u0004.\u001D(F));
			\u001E\u001B\u0004.\u001D(selectedExcel, \u0018\u001B\u0004.\u001D(F));
			\u0012\u001B\u0004.\u001D(selectedExcel, \u0019\u0020\u001D.\u0007(F));
			\u000D\u0020\u0004.\u000A(selectedExcel, \u0002\u0003\u0004.\u0007(F));
			\u0009\u001B\u0004.\u000A(selectedExcel, \u0015\u0016\u0004.\u0007(F));
			\u000A\u001E\u0004.\u000A(selectedExcel, \u0018\u0011\u0004.\u001D(F));
			\u0007\u001E\u0004.\u000A(selectedExcel, \u0004\u0011\u0004.\u001D(F));
			\u001B\u0020\u0004.\u000A(selectedExcel, \u000A\u0011\u0004.\u001D(F));
			List<string>.Enumerator enumerator = \u0013\u0008\u0007.\u000A(\u0011\u001B\u0004.\u001D(selectedExcel));
			try
			{
				while (\u0017\u0008\u0007.\u000A(ref enumerator))
				{
					string text = \u0014\u0008\u0007.\u000A(ref enumerator);
					if (\u0008\u0013\u000A.\u000A(text, \u0020\u0020\u001D.\u0007(F)))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.WHR(SelectedExcel)).MethodHandle;
						}
						\u001B\u001B\u0004.\u001D(selectedExcel, text);
						goto IL_132;
					}
				}
				for (;;)
				{
					switch (6)
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
			IL_132:
			List<NamedRangeInfo>.Enumerator enumerator2 = \u0020\u0009\u0004.\u000A(\u000A\u001B\u0004.\u001D(selectedExcel));
			try
			{
				while (\u0011\u0009\u0004.\u000A(ref enumerator2))
				{
					NamedRangeInfo namedRangeInfo = \u001E\u0009\u0004.\u000A(ref enumerator2);
					if (\u0008\u0013\u000A.\u000A(\u001B\u0012\u0004.\u001D(namedRangeInfo), \u001B\u0012\u0004.\u001D(\u0014\u0020\u001D.\u0007(F))))
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
						\u001F\u001B\u0004.\u001D(selectedExcel, namedRangeInfo);
						goto IL_1AA;
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
				((IDisposable)enumerator2).Dispose();
			}
			IL_1AA:
			string f = \u0014\u0005\u0004.\u0007(F);
			int num = 1;
			string u000A = this.BHR(f, num);
			while (!this.UHR(this.BHR(f, num), \u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(selectedExcel))))
			{
				num++;
				u000A = this.BHR(f, num);
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
			\u0004\u0017\u0004.\u000A(selectedExcel, u000A);
			\u001A\u0016\u0004.\u000A(\u001C\u001B\u0004.\u000A(), selectedExcel);
			this.C.HKR();
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x00051D1C File Offset: 0x0004FF1C
		public bool PerformOperation(string selectedItem, List<SelectedExcel> selectedExcels)
		{
			Func<SelectedExcel, string> func;
			if ((func = MainWindow.<>c.\u0016) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.PerformOperation(string, List<SelectedExcel>)).MethodHandle;
				}
				func = (MainWindow.<>c.\u0016 = new Func<SelectedExcel, string>(MainWindow.<>c.\u001F.\u000E));
			}
			List<string> u001F = Enumerable.ToList<string>(Enumerable.Distinct<string>(Enumerable.Select<SelectedExcel, string>(selectedExcels, func)));
			if (\u0008\u0013\u000A.\u000A(selectedItem, \u000D\u0007\u0019.\u000A()))
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
				if (\u0015\u0007\u0019.\u000A(u001F) > 1)
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
					\u001E\u0005\u0019.\u000A(this.C, selectedExcels, \u0007\u0018.\u0007<ICustomLogger>());
					return true;
				}
			}
			List<ReportInfo> list = \u0010\u001D\u0019.\u000A();
			if (\u001D\u0017\u000A.\u000A(selectedItem, \u0003\u0005\u0019.\u000A()))
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
				if (\u001D\u0017\u000A.\u000A(selectedItem, \u000D\u0007\u0019.\u000A()))
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
					if (\u001D\u0017\u000A.\u000A(selectedItem, \u0012\u0007\u0019.\u000A()))
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
						List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(selectedExcels);
						try
						{
							while (\u0001\u0005\u0004.\u000A(ref enumerator))
							{
								SelectedExcel u001F2 = \u001F\u0016\u0004.\u000A(ref enumerator);
								if (!\u0010\u0002\u001D.\u000A(\u0011\u0020\u001D.\u0007(u001F2)))
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
									\u0006\u001D\u0019.\u000A(list, \u001B\u0005\u0019.\u000A(u001F2, \u0003\u001D\u0019.\u000A()));
								}
								else if (\u000A\u001E\u001D.\u000A(\u000A\u001B\u0004.\u001D(u001F2)) == 0)
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
									\u0006\u001D\u0019.\u000A(list, \u001B\u0005\u0019.\u000A(u001F2, \u0011\u0005\u0019.\u000A()));
								}
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
						}
						finally
						{
							((IDisposable)enumerator).Dispose();
						}
					}
				}
			}
			if (\u0008\u0005\u0019.\u000A(list) > 0)
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
				ReportsWindow u001F3 = \u0003\u0018\u001D.\u000A(\u000E\u0005\u0019.\u000A(Enumerable.ToList<Report>(Enumerable.Cast<Report>(list)), \u001E\u0011\u000A.\u000A(\u0008\u0018\u000E.\u001F()), 1005), false);
				\u0007\u0010\u001D.\u0007(u001F3, "Report");
				\u000C\u000E\u0007.\u0007(u001F3, this);
				\u0018\u0020\u000A.\u0007(u001F3);
				return false;
			}
			ActionTypes actionTypes = ActionTypes.None;
			bool flag;
			if (!\u0008\u0013\u000A.\u000A(selectedItem, \u001B\u0008\u0004.\u000A()))
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
				flag = \u0008\u0013\u000A.\u000A(selectedItem, \u000B\u0007\u0019.\u000A());
			}
			else
			{
				flag = true;
			}
			bool flag2 = flag;
			if (!flag2)
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
				if (!\u0008\u0013\u000A.\u000A(selectedItem, \u0010\u0005\u0019.\u000A()))
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
					if (!\u0008\u0013\u000A.\u000A(selectedItem, \u001B\u0007\u0019.\u000A()))
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
						if (!\u0008\u0013\u000A.\u000A(selectedItem, \u000D\u0005\u0019.\u000A()))
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
							if (!\u0008\u0013\u000A.\u000A(selectedItem, \u0008\u0007\u0019.\u000A()))
							{
								if (!\u0008\u0013\u000A.\u000A(selectedItem, \u000D\u0007\u0019.\u000A()))
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
									if (\u0008\u0013\u000A.\u000A(selectedItem, \u001C\u0005\u0019.\u000A()))
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
									}
									else
									{
										if (!\u0008\u0013\u000A.\u000A(selectedItem, \u0003\u0005\u0019.\u000A()))
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
											if (\u0008\u0013\u000A.\u000A(selectedItem, \u0012\u0007\u0019.\u000A()))
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
											}
											else
											{
												if (!\u0008\u0013\u000A.\u000A(selectedItem, \u000E\u0007\u0019.\u000A()))
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
													if (!\u0008\u0013\u000A.\u000A(selectedItem, \u0006\u0005\u0019.\u000A()))
													{
														goto IL_3BA;
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
												List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(selectedExcels);
												try
												{
													while (\u0001\u0005\u0004.\u000A(ref enumerator))
													{
														SelectedExcel f = \u001F\u0016\u0004.\u000A(ref enumerator);
														this.WHR(f);
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
													goto IL_68B;
												}
												finally
												{
													((IDisposable)enumerator).Dispose();
												}
												IL_3BA:
												if (\u0008\u0013\u000A.\u000A(selectedItem, \u001C\u0007\u0019.\u000A()))
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
													enumerator = \u000A\u0016\u0004.\u000A(selectedExcels);
													try
													{
														while (\u0001\u0005\u0004.\u000A(ref enumerator))
														{
															SelectedExcel u001F4 = \u001F\u0016\u0004.\u000A(ref enumerator);
															if (\u0010\u0002\u001D.\u000A(\u0011\u0020\u001D.\u0007(u001F4)))
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
																\u0004\u0019\u0019.\u000A(\u0011\u0020\u001D.\u0007(u001F4));
															}
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
														goto IL_68B;
													}
													finally
													{
														((IDisposable)enumerator).Dispose();
													}
												}
												if (\u0008\u0013\u000A.\u000A(selectedItem, \u0003\u0007\u0019.\u000A()))
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
													List<string> u001F5 = \u0014\u000D\u0007.\u000A();
													enumerator = \u000A\u0016\u0004.\u000A(selectedExcels);
													try
													{
														while (\u0001\u0005\u0004.\u000A(ref enumerator))
														{
															SelectedExcel u001F6 = \u001F\u0016\u0004.\u000A(ref enumerator);
															if (!\u001F\u0020\u001D.\u000A(u001F5, \u0011\u0020\u001D.\u0007(u001F6)))
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
																\u001A\u0008\u0007.\u000A(u001F5, \u0011\u0020\u001D.\u0007(u001F6));
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
													List<string>.Enumerator enumerator2 = \u0013\u0008\u0007.\u000A(u001F5);
													try
													{
														while (\u0017\u0008\u0007.\u000A(ref enumerator2))
														{
															string text = \u0014\u0008\u0007.\u000A(ref enumerator2);
															if (\u0010\u0002\u001D.\u000A(text))
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
																string u000A = text;
																string u000A2 = \u0017\u0006\u0007.\u000A("/e, /select, \"{0}\"", u000A);
																ProcessStartInfo u001F7 = \u0002\u0005\u0019.\u000A();
																\u000B\u0005\u0019.\u000A(u001F7, "explorer");
																\u0016\u0005\u0019.\u000A(u001F7, u000A2);
																\u0005\u0005\u0019.\u000A(u001F7);
															}
															else
															{
																string text2 = \u0019\u000E\u0004.\u000A(text);
																if (\u000C\u0010\u0004.\u000A(text2))
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
																	\u0018\u0005\u0019.\u000A("explorer.exe", text2);
																}
															}
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
														goto IL_68B;
													}
													finally
													{
														((IDisposable)enumerator2).Dispose();
													}
												}
												if (\u0008\u0013\u000A.\u000A(selectedItem, \u0010\u0007\u0019.\u000A()))
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
													string u001F8 = \u000F\u0015\u0010.\u001F;
													try
													{
														u001F8 = \u0005\u001A\u000A.\u0007(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()));
													}
													catch (Exception u000A3)
													{
														\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A3, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\UI\\Windows\\MainWindow.xaml.cs", "PerformOperation");
													}
													if (!\u001A\u0006\u0007.\u000A(u001F8))
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
														enumerator = \u000A\u0016\u0004.\u000A(selectedExcels);
														try
														{
															while (\u0001\u0005\u0004.\u000A(ref enumerator))
															{
																SelectedExcel u001F9 = \u001F\u0016\u0004.\u000A(ref enumerator);
																\u0014\u0020\u0004.\u000A(u001F9, !\u0013\u0008\u0004.\u001D(u001F9));
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
														}
														finally
														{
															((IDisposable)enumerator).Dispose();
														}
														this.ADR(false);
														goto IL_68B;
													}
													\u0011\u001F\u0019.\u000A(\u000C\u0004\u0019.\u000A(), MessageBoxButtons.OK);
													goto IL_68B;
												}
												else
												{
													if (\u0008\u0013\u000A.\u000A(selectedItem, \u000F\u0007\u0019.\u000A()))
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
														return this.JHR(selectedExcels);
													}
													goto IL_68B;
												}
											}
										}
										actionTypes = ActionTypes.Delete;
										if (!\u000F\u0005\u0019.\u000A(\u0012\u0005\u0019.\u000A(), this, MessageBoxButtons.YesNo))
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
											return false;
										}
										goto IL_68B;
									}
								}
								actionTypes = ActionTypes.UpdateFrom;
								goto IL_68B;
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
						}
					}
				}
			}
			actionTypes = ActionTypes.Update;
			IL_68B:
			if (actionTypes == ActionTypes.Delete)
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
				List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(selectedExcels);
				try
				{
					while (\u0001\u0005\u0004.\u000A(ref enumerator))
					{
						SelectedExcel u001F10 = \u001F\u0016\u0004.\u000A(ref enumerator);
						\u001C\u0016\u0004.\u0007(u001F10, ActionTypes.Delete);
						\u000D\u0016\u0004.\u0007(u001F10, UpdateStates.ToTrash);
					}
					for (;;)
					{
						switch (6)
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
				this.C.HKR();
				this.ZHR(selectedExcels);
			}
			else if (actionTypes == ActionTypes.Update)
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
				MainWindow.KHR(selectedExcels, flag2, selectedItem);
				this.C.HKR();
			}
			else if (actionTypes == ActionTypes.UpdateFrom)
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
				\u0019\u0005\u0019.\u000A(this.C, selectedExcels);
			}
			\u0002\u0005.\u0001(\u0017\u0019\u0019.\u000A(this), \u001C\u001B\u0004.\u000A());
			return true;
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x000524D4 File Offset: 0x000506D4
		private static void KHR(List<SelectedExcel> F, bool R, string D)
		{
			bool flag;
			if (!\u0008\u0013\u000A.\u000A(D, \u000D\u0005\u0019.\u000A()))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.KHR(List<SelectedExcel>, bool, string)).MethodHandle;
				}
				flag = \u0008\u0013\u000A.\u000A(D, \u0008\u0007\u0019.\u000A());
			}
			else
			{
				flag = true;
			}
			bool flag2 = flag;
			List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(F);
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					SelectedExcel selectedExcel = \u001F\u0016\u0004.\u000A(ref enumerator);
					if (\u0019\u0010\u0004.\u0007(selectedExcel) != ActionTypes.Delete)
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
						if (\u0019\u0010\u0004.\u0007(selectedExcel) != ActionTypes.Create)
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
							bool flag3;
							if (\u0019\u0010\u0004.\u0007(selectedExcel) == ActionTypes.Update)
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
								flag3 = (\u0001\u0016\u0004.\u0007(selectedExcel) == UpdateStates.Recreate);
							}
							else
							{
								flag3 = false;
							}
							bool flag4 = flag3;
							if (R)
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
								if (flag4)
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
									\u001C\u0016\u0004.\u0007(selectedExcel, ActionTypes.None);
									object u001F = selectedExcel;
									UpdateStates u000A;
									if (!\u0017\u001B\u0004.\u001D(selectedExcel))
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
										u000A = UpdateStates.Updated;
									}
									else
									{
										u000A = UpdateStates.Modified;
									}
									\u000D\u0016\u0004.\u0007(u001F, u000A);
								}
								else
								{
									\u000D\u0016\u0004.\u0007(selectedExcel, UpdateStates.Recreate);
									\u001C\u0016\u0004.\u0007(selectedExcel, ActionTypes.Update);
								}
							}
							else
							{
								if (flag2)
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
									if (\u0001\u0016\u0004.\u0007(selectedExcel) == UpdateStates.Recreate)
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
										object u001F2 = selectedExcel;
										UpdateStates u000A2;
										if (!\u0017\u001B\u0004.\u001D(selectedExcel))
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
											u000A2 = UpdateStates.Updated;
										}
										else
										{
											u000A2 = UpdateStates.Modified;
										}
										\u000D\u0016\u0004.\u0007(u001F2, u000A2);
										continue;
									}
								}
								if (flag4)
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
									\u001C\u0016\u0004.\u0007(selectedExcel, ActionTypes.None);
									object u001F3 = selectedExcel;
									UpdateStates u000A3;
									if (!\u0017\u001B\u0004.\u001D(selectedExcel))
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
										u000A3 = UpdateStates.Updated;
									}
									else
									{
										u000A3 = UpdateStates.Modified;
									}
									\u000D\u0016\u0004.\u0007(u001F3, u000A3);
								}
								else
								{
									object u001F4 = selectedExcel;
									ActionTypes u000A4;
									if (\u0019\u0010\u0004.\u0007(selectedExcel) != ActionTypes.Update)
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
										u000A4 = ActionTypes.Update;
									}
									else
									{
										u000A4 = ActionTypes.None;
									}
									\u001C\u0016\u0004.\u0007(u001F4, u000A4);
								}
							}
						}
					}
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x000526B4 File Offset: 0x000508B4
		private bool JHR(List<SelectedExcel> F)
		{
			if (!\u000F\u0005\u0019.\u000A(\u0014\u0005\u0019.\u000A(), this, MessageBoxButtons.YesNo))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.JHR(List<SelectedExcel>)).MethodHandle;
				}
				return false;
			}
			this.FYR(false);
			Action<SelectedExcel> u000A;
			if ((u000A = MainWindow.<>c.\u000B) == null)
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
				u000A = (MainWindow.<>c.\u000B = new Action<SelectedExcel>(MainWindow.<>c.\u001F.\u0008));
			}
			\u0009\u0019\u0019.\u000A(F, u000A);
			\u0002\u0002 u0002_u = new \u0002\u0002();
			\u0017\u0005\u0019.\u000A(u0002_u, F);
			\u0002\u0002 u0002_u2 = u0002_u;
			u0002_u2.\u0017 += this.QHR;
			u0002_u2.\u001F += this.GHR;
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u0002_u2);
			\u0020\u0005\u0019.\u000A(\u0017\u001E\u000A.\u000A());
			return true;
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x0005276C File Offset: 0x0005096C
		private void DgViews_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ComboBox comboBox = \u000F\u001F\u000E.\u001F(\u0018\u0001\u0007.\u000A(e));
			if (comboBox != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.DgViews_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				if (\u0008\u0013\u000A.\u000A(\u0013\u0005\u0019.\u000A(comboBox), "ImportTypeComboBox"))
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
					this.NHR(this.MD);
					this.NHR(this.VD);
					return;
				}
			}
			this.EHR();
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x000527E0 File Offset: 0x000509E0
		private void EHR()
		{
			if (\u0018\u0013\u000A.\u000A(\u0009\u0006\u0007.\u0007(this.ED)) != 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.EHR()).MethodHandle;
				}
				SelectedExcel selectedExcel = \u0011\u0018\u000E.\u001F(\u0019\u000C\u0007.\u001D(this.ED));
				if (selectedExcel != null)
				{
					List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(\u001C\u001B\u0004.\u000A());
					try
					{
						while (\u0001\u0005\u0004.\u000A(ref enumerator))
						{
							\u001F\u0018\u0019.\u000A(\u001F\u0016\u0004.\u000A(ref enumerator), false);
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
					}
					finally
					{
						((IDisposable)enumerator).Dispose();
					}
					IEnumerator u001F = \u001D\u0011\u000A.\u000A(\u0009\u0006\u0007.\u0007(this.ED));
					try
					{
						while (\u000A\u0017\u000A.\u000A(u001F))
						{
							\u001F\u0018\u0019.\u000A(\u000A\u0005\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F)), true);
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
						IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F);
						if (disposable != null)
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
							\u001F\u0017\u000A.\u000A(disposable);
						}
					}
					\u000A\u0016\u0019.\u000A(this.ED, \u0007\u0016\u0019.\u000A());
					bool flag;
					if (\u0018\u0013\u000A.\u000A(\u0009\u0006\u0007.\u0007(this.ED)) == 1)
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
						flag = !\u0010\u0002\u001D.\u000A(\u0011\u0020\u001D.\u0007(selectedExcel));
					}
					else
					{
						flag = false;
					}
					bool flag2 = flag;
					bool flag3 = this.MHR();
					if (!flag2)
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
						if (\u0001\u0016\u0004.\u0007(selectedExcel) != UpdateStates.ToAdd)
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
							if (\u0001\u0016\u0004.\u0007(selectedExcel) != UpdateStates.ToDuplicate)
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
								string f;
								if (!flag3)
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
									f = \u0010\u0005\u0019.\u000A();
								}
								else
								{
									f = \u000D\u0005\u0019.\u000A();
								}
								this.VHR(f, "updatetable.png", new RoutedEventHandler(this.MenuItem_Click));
								if (flag3)
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
									this.VHR(\u001B\u0008\u0004.\u000A(), "Status/pen.png", new RoutedEventHandler(this.MenuItem_Click));
								}
							}
						}
					}
					this.VHR(\u000D\u0007\u0019.\u000A(), "changefolder.png", new RoutedEventHandler(this.MenuItem_Click));
					this.VHR(\u0003\u0005\u0019.\u000A(), "deletetable.png", new RoutedEventHandler(this.MenuItem_Click));
					if (!flag2)
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
						\u0001\u0005\u0019.\u000A(\u0010\u000C\u0007.\u000A(\u001F\u0016\u0019.\u000A(this.ED)), \u0009\u0005\u0019.\u000A());
						this.VHR(\u0006\u0005\u0019.\u000A(), "duplicate.png", new RoutedEventHandler(this.MenuItem_Click));
						this.VHR(\u0010\u0007\u0019.\u000A(), "switch.png", new RoutedEventHandler(this.MenuItem_Click));
					}
					if (\u0018\u0013\u000A.\u000A(\u0009\u0006\u0007.\u0007(this.ED)) == 1)
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
						\u0001\u0005\u0019.\u000A(\u0010\u000C\u0007.\u000A(\u001F\u0016\u0019.\u000A(this.ED)), \u0009\u0005\u0019.\u000A());
						if (\u0001\u0016\u0004.\u0007(selectedExcel) != UpdateStates.ToAdd)
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
							if (\u0001\u0016\u0004.\u0007(selectedExcel) != UpdateStates.ToDuplicate)
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
								this.VHR(\u0015\u0005\u0019.\u000A(), "opentable.png", new RoutedEventHandler(this.MenuItem_Click2));
							}
						}
						if (!flag2)
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
							this.VHR(\u000C\u0005\u0019.\u000A(), "openfile.png", new RoutedEventHandler(this.MenuItem_Click2));
							this.VHR(\u001A\u0005\u0019.\u000A(), "openfolder.png", new RoutedEventHandler(this.MenuItem_Click2));
						}
					}
					this.VHR(\u000F\u0007\u0019.\u000A(), "unlink.png", new RoutedEventHandler(this.MenuItem_Click));
					return;
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
			\u000A\u0016\u0019.\u000A(this.ED, \u001F\u0005\u000E.\u001F);
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x00052B9C File Offset: 0x00050D9C
		private void NHR(DataGridTemplateColumn F)
		{
			DataTemplateSelector u000A = \u0004\u0016\u0019.\u000A(F);
			\u001D\u0016\u0019.\u000A(F, \u0009\u0018\u000E.\u001F);
			\u001D\u0016\u0019.\u000A(F, u000A);
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x00052BC4 File Offset: 0x00050DC4
		private bool MHR()
		{
			StyleMappingDto styleMappingDto = \u0017\u0019\u0019.\u000A(this);
			if (styleMappingDto == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.MHR()).MethodHandle;
				}
				return false;
			}
			GeneralMappingSetting generalMappingSetting = \u0009\u0004\u0004.\u001D(styleMappingDto);
			UpdateBehaviorOption? updateBehaviorOption;
			UpdateBehaviorOption? updateBehaviorOption2;
			if (generalMappingSetting == null)
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
				\u0001\u0018\u000E.\u001F(ref updateBehaviorOption);
				updateBehaviorOption2 = updateBehaviorOption;
			}
			else
			{
				updateBehaviorOption2 = new UpdateBehaviorOption?(\u0012\u000B\u0004.\u001D(generalMappingSetting));
			}
			updateBehaviorOption = updateBehaviorOption2;
			return \u0019\u0016\u0019.\u000A(ref updateBehaviorOption) == UpdateBehaviorOption.UpdateDataOnly;
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x00052C2C File Offset: 0x00050E2C
		private void VHR(string F, string R, RoutedEventHandler D)
		{
			MenuItem menuItem = \u0002\u0016\u0019.\u000A();
			\u000B\u0016\u0019.\u000A(menuItem, F);
			MenuItem menuItem2 = menuItem;
			\u0005\u0016\u0019.\u000A(menuItem2, \u0016\u0016\u0019.\u000A(R, "/DiRoots.One;component/TableGen/TableGen/Resources/Images/", \u0007\u0018.\u0007<ICustomLogger>()));
			\u0018\u0016\u0019.\u000A(menuItem2, D);
			\u0001\u0005\u0019.\u000A(\u0010\u000C\u0007.\u000A(\u001F\u0016\u0019.\u000A(this.ED)), menuItem2);
		}

		// Token: 0x06000CEF RID: 3311 RVA: 0x00052C88 File Offset: 0x00050E88
		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			List<SelectedExcel> list = Enumerable.ToList<SelectedExcel>(Enumerable.Cast<SelectedExcel>(\u0009\u0006\u0007.\u0007(this.ED)));
			if (\u000C\u001B\u0004.\u000A(list) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.MenuItem_Click(object, RoutedEventArgs)).MethodHandle;
				}
				\u0006\u0016\u0019.\u000A(this, \u001A\u000C\u000A.\u000A(\u000F\u0016\u0019.\u000A(\u0006\u0009\u0010.\u001F(sender))), list);
			}
		}

		// Token: 0x06000CF0 RID: 3312 RVA: 0x00052CF0 File Offset: 0x00050EF0
		private void MenuItem_Click2(object sender, RoutedEventArgs e)
		{
			List<SelectedExcel> u001F = Enumerable.ToList<SelectedExcel>(Enumerable.Cast<SelectedExcel>(\u0009\u0006\u0007.\u0007(this.ED)));
			if (\u000C\u001B\u0004.\u000A(u001F) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.MenuItem_Click2(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			SelectedExcel u001F2 = \u0013\u0005\u0004.\u000A(u001F, 0);
			string u001F3 = \u001A\u000C\u000A.\u000A(\u000F\u0016\u0019.\u000A(\u0006\u0009\u0010.\u001F(sender)));
			try
			{
				if (\u0008\u0013\u000A.\u000A(u001F3, \u000C\u0005\u0019.\u000A()))
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
					if (\u0010\u0002\u001D.\u000A(\u0011\u0020\u001D.\u0007(u001F2)))
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
						\u0004\u0019\u0019.\u000A(\u0011\u0020\u001D.\u0007(u001F2));
					}
					else
					{
						\u0011\u001F\u0019.\u000A(\u0003\u001D\u0019.\u000A(), MessageBoxButtons.OK);
					}
				}
				else if (\u0008\u0013\u000A.\u000A(u001F3, \u001A\u0005\u0019.\u000A()))
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
					if (\u0010\u0002\u001D.\u000A(\u0011\u0020\u001D.\u0007(u001F2)))
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
						string u000A = \u0011\u0020\u001D.\u0007(u001F2);
						string u000A2 = \u0017\u0006\u0007.\u000A("/e, /select, \"{0}\"", u000A);
						ProcessStartInfo u001F4 = \u0002\u0005\u0019.\u000A();
						\u000B\u0005\u0019.\u000A(u001F4, "explorer");
						\u0016\u0005\u0019.\u000A(u001F4, u000A2);
						\u0005\u0005\u0019.\u000A(u001F4);
					}
					else
					{
						string text = \u0019\u000E\u0004.\u000A(\u0011\u0020\u001D.\u0007(u001F2));
						if (\u000C\u0010\u0004.\u000A(text))
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
							\u0018\u0005\u0019.\u000A("explorer.exe", text);
						}
						else
						{
							\u0011\u001F\u0019.\u000A(\u0003\u0016\u0019.\u000A(), MessageBoxButtons.OK);
						}
					}
				}
				else if (!\u0015\u0018.\u0007(\u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(u001F2)), \u0017\u0017\u0004.\u000A(u001F2)))
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
					\u0011\u001F\u0019.\u000A(\u0012\u0016\u0019.\u000A(), MessageBoxButtons.OK);
				}
			}
			catch (Exception u001F5)
			{
				\u000A\u0016.\u001F(u001F5);
			}
		}

		// Token: 0x06000CF1 RID: 3313 RVA: 0x00052ED8 File Offset: 0x000510D8
		private void ChkSheetSelect_Checked(object sender, RoutedEventArgs e)
		{
			IEnumerator<SelectedExcel> enumerator = \u001E\u000F\u0004.\u000A(Enumerable.Cast<SelectedExcel>(\u0010\u000C\u0007.\u000A(this.ED)));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u0001\u0020\u0004.\u000A(\u0011\u000F\u0004.\u000A(enumerator), true);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.ChkSheetSelect_Checked(object, RoutedEventArgs)).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}

		// Token: 0x06000CF2 RID: 3314 RVA: 0x00052F54 File Offset: 0x00051154
		private void ChkSheetSelect_Unchecked(object sender, RoutedEventArgs e)
		{
			IEnumerator<SelectedExcel> enumerator = \u001E\u000F\u0004.\u000A(Enumerable.Cast<SelectedExcel>(\u0010\u000C\u0007.\u000A(this.ED)));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u0001\u0020\u0004.\u000A(\u0011\u000F\u0004.\u000A(enumerator), false);
				}
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.ChkSheetSelect_Unchecked(object, RoutedEventArgs)).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x00052FD0 File Offset: 0x000511D0
		private void btnOkay_Click(object sender, RoutedEventArgs e)
		{
			MainWindow.\u0019\u000B u0019_u000B = new MainWindow.\u0019\u000B();
			u0019_u000B.\u001F = this;
			try
			{
				u0019_u000B.\u000A = \u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>());
				object c = this.C;
				IEnumerable<SelectedExcel> u000A = \u001C\u001B\u0004.\u000A();
				bool u = false;
				Action u001D = new Action(u0019_u000B.\u0007);
				BlackAndWhiteTextLinesOption? u2;
				\u000E\u0018\u000E.\u001F(ref u2);
				\u001C\u0016\u0019.\u000A(c, u000A, u, u001D, u2);
			}
			catch (Exception u001F)
			{
				\u000A\u0016.\u001F(u001F);
			}
		}

		// Token: 0x06000CF4 RID: 3316 RVA: 0x00053040 File Offset: 0x00051240
		private void ZHR(List<SelectedExcel> F)
		{
			MainWindow.\u0018\u000B u0018_u000B = new MainWindow.\u0018\u000B();
			u0018_u000B.\u001F = this;
			u0018_u000B.\u000A = \u0003\u000B\u0004.\u000A();
			try
			{
				\u0013\u0016\u0019.\u000A(this.ED, new EventHandler<DataGridCellEditEndingEventArgs>(this.DgViews_CellEditEnding));
				\u0014\u0016\u0019.\u000A(this.ED, DataGridEditingUnit.Row, true);
				\u0017\u0016\u0019.\u000A(this.ED, new EventHandler<DataGridCellEditEndingEventArgs>(this.DgViews_CellEditEnding));
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\UI\\Windows\\MainWindow.xaml.cs", "Execute");
			}
			this.DYR();
			this.C.HKR();
			List<ReportInfo> list = \u0010\u001D\u0019.\u000A();
			List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(F);
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					MainWindow.\u0005\u000B u0005_u000B = new MainWindow.\u0005\u000B();
					u0005_u000B.\u001F = \u001F\u0016\u0004.\u000A(ref enumerator);
					if (\u0019\u0010\u0004.\u0007(u0005_u000B.\u001F) != ActionTypes.None)
					{
						goto IL_104;
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.ZHR(List<SelectedExcel>)).MethodHandle;
					}
					if (\u0001\u0016\u0004.\u0007(u0005_u000B.\u001F) == UpdateStates.Modified)
					{
						goto IL_104;
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
					bool flag = \u0001\u0016\u0004.\u0007(u0005_u000B.\u001F) == UpdateStates.Recreate;
					IL_105:
					bool flag2 = flag;
					if (flag2)
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
						if (\u0001\u0016\u0004.\u0007(u0005_u000B.\u001F) == UpdateStates.ToTrash)
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
							\u001A\u0016\u0004.\u000A(u0018_u000B.\u000A, u0005_u000B.\u001F);
							continue;
						}
						if (!\u0010\u0002\u001D.\u000A(\u0011\u0020\u001D.\u0007(u0005_u000B.\u001F)))
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
							\u0006\u001D\u0019.\u000A(list, \u001B\u0005\u0019.\u000A(u0005_u000B.\u001F, \u0003\u001D\u0019.\u000A()));
							continue;
						}
						if (\u0015\u0007\u0019.\u000A(\u0011\u001B\u0004.\u001D(u0005_u000B.\u001F)) != 0)
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
							if (\u000A\u001E\u001D.\u000A(\u000A\u001B\u0004.\u001D(u0005_u000B.\u001F)) != 0)
							{
								if (\u000C\u0008\u0004.\u000A(\u0015\u0016\u0004.\u0007(u0005_u000B.\u001F), ImportTypes.Table))
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
									if (\u0014\u0020\u001D.\u0007(u0005_u000B.\u001F) != null)
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
										if (Enumerable.FirstOrDefault<NamedRangeInfo>(\u000A\u001B\u0004.\u001D(u0005_u000B.\u001F), new Func<NamedRangeInfo, bool>(u0005_u000B.\u000A)) == null)
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
											\u0006\u001D\u0019.\u000A(list, \u001B\u0005\u0019.\u000A(u0005_u000B.\u001F, \u0020\u0016\u0019.\u000A()));
											continue;
										}
									}
								}
								if (\u000C\u0008\u0004.\u000A(\u0015\u0016\u0004.\u0007(u0005_u000B.\u001F), ImportTypes.Image))
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
									if (\u000C\u0008\u0004.\u000A(\u0004\u0011\u0004.\u001D(u0005_u000B.\u001F), PageOptions.Select))
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
										if (\u001E\u000B\u001D.\u000A(\u0013\u0016.\u001F(\u000A\u0011\u0004.\u001D(u0005_u000B.\u001F))) == 0)
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
											\u0006\u001D\u0019.\u000A(list, \u001B\u0005\u0019.\u000A(u0005_u000B.\u001F, \u001E\u0016\u0019.\u000A()));
											continue;
										}
									}
								}
								if (\u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(u0005_u000B.\u001F)) != 11)
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
									if (\u0019\u0020\u001D.\u0007(u0005_u000B.\u001F) >= 1)
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
										if (\u0019\u0020\u001D.\u0007(u0005_u000B.\u001F) <= 24000)
										{
											goto IL_38F;
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
									\u0006\u001D\u0019.\u000A(list, \u001B\u0005\u0019.\u000A(u0005_u000B.\u001F, \u000A\u0019\u0019.\u000A()));
									continue;
								}
								IL_38F:
								if (\u000D\u001B\u0004.\u001D(u0005_u000B.\u001F, \u0006\u0020\u001D.\u0007(u0005_u000B.\u001F), false))
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
									if (!\u0003\u0016.\u001F(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()), u0005_u000B.\u001F))
									{
										if (\u000D\u001B\u0004.\u001D(u0005_u000B.\u001F, \u0006\u0020\u001D.\u0007(u0005_u000B.\u001F), false))
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
											if (!\u0003\u0016.\u001F(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()), u0005_u000B.\u001F))
											{
												try
												{
													\u000F\u0016.\u001F(u0005_u000B.\u001F);
												}
												catch (Exception u001F)
												{
													flag2 = false;
													if (\u000F\u000C\u001D.\u0007(\u0003\u001A\u000A.\u000A(u001F), "The process cannot access the file"))
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
														\u0006\u001D\u0019.\u000A(list, \u001B\u0005\u0019.\u000A(u0005_u000B.\u001F, \u001E\u001F\u0019.\u000A()));
													}
													else
													{
														\u0006\u001D\u0019.\u000A(list, \u001B\u0005\u0019.\u000A(u0005_u000B.\u001F, \u0003\u001A\u000A.\u000A(u001F)));
													}
												}
												goto IL_4E2;
											}
											for (;;)
											{
												switch (6)
												{
												case 0:
													continue;
												}
												break;
											}
										}
										\u0006\u001D\u0019.\u000A(list, \u001B\u0005\u0019.\u000A(u0005_u000B.\u001F, \u001B\u0016\u0019.\u000A()));
										continue;
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
								\u0006\u001D\u0019.\u000A(list, \u001B\u0005\u0019.\u000A(u0005_u000B.\u001F, \u0011\u0016\u0019.\u000A()));
								continue;
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
						}
						\u0006\u001D\u0019.\u000A(list, \u001B\u0005\u0019.\u000A(u0005_u000B.\u001F, \u0011\u0005\u0019.\u000A()));
						continue;
					}
					IL_4E2:
					if (\u0008\u0016\u0019.\u000A(\u0014\u0020\u001D.\u0007(u0005_u000B.\u001F)))
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
						if (!this.XHR(\u0014\u0020\u001D.\u0007(u0005_u000B.\u001F)))
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
							return;
						}
					}
					if (flag2)
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
						\u001A\u0016\u0004.\u000A(u0018_u000B.\u000A, u0005_u000B.\u001F);
						continue;
					}
					continue;
					IL_104:
					flag = true;
					goto IL_105;
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
			this.PHR(list);
			if (\u000C\u001B\u0004.\u000A(u0018_u000B.\u000A) == 0)
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
			this.FYR(false);
			\u000E\u0015\u0007.\u000A(this.JR, \u000E\u0016\u0019.\u000A(0));
			\u0014\u001A\u000A.\u000A(this.NR, \u0017\u001D\u0019.\u000A());
			\u000D\u0016\u0019.\u000A(\u0010\u0016\u0019.\u000A(new ParameterizedThreadStart(u0018_u000B.\u0007)));
		}

		// Token: 0x06000CF5 RID: 3317 RVA: 0x00053670 File Offset: 0x00051870
		private bool XHR(NamedRangeInfo F)
		{
			StringBuilder u001F = \u001A\u0013\u0007.\u000A();
			\u001A\u0016\u0019.\u000A(u001F, \u0018\u000E\u0007.\u000A("{0}: {1}", \u0009\u0016\u0019.\u000A(), \u001F\u0008\u0004.\u001D(F)));
			\u001A\u0016\u0019.\u000A(u001F, \u0018\u000E\u0007.\u000A("{0}: {1}", \u0001\u0016\u0019.\u000A(), \u0009\u000E\u0004.\u001D(F)));
			\u0015\u0016\u0019.\u000A(u001F);
			\u001A\u0016\u0019.\u000A(u001F, \u000C\u0016\u0019.\u000A());
			return \u000F\u0005\u0019.\u000A(\u001A\u000C\u000A.\u000A(u001F), this, MessageBoxButtons.YesNo);
		}

		// Token: 0x06000CF6 RID: 3318 RVA: 0x00053700 File Offset: 0x00051900
		private void PHR(List<ReportInfo> F)
		{
			if (\u0008\u0005\u0019.\u000A(F) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.PHR(List<ReportInfo>)).MethodHandle;
				}
				ReportsWindow u001F = \u0003\u0018\u001D.\u000A(\u000E\u0005\u0019.\u000A(Enumerable.ToList<Report>(Enumerable.Cast<Report>(F)), \u001E\u0011\u000A.\u000A(\u0008\u0018\u000E.\u001F()), 1005), false);
				\u000C\u000E\u0007.\u0007(u001F, this);
				\u0007\u0010\u001D.\u0007(u001F, "Report");
				\u0018\u0020\u000A.\u0007(u001F);
			}
		}

		// Token: 0x06000CF7 RID: 3319 RVA: 0x00053778 File Offset: 0x00051978
		private void OHR(List<SelectedExcel> F)
		{
			MainWindow.\u0016\u000B u0016_u000B = new MainWindow.\u0016\u000B();
			u0016_u000B.\u001F = this;
			\u000E\u0019\u0019.\u000A(\u0003\u0019\u0019.\u000A(), \u0008\u0019\u0019.\u000A());
			List<SelectedExcel> u001F = \u0003\u000B\u0004.\u000A();
			u0016_u000B.\u000A = \u0007\u000B\u0019.\u000A();
			List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(F);
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					SelectedExcel selectedExcel = \u001F\u0016\u0004.\u000A(ref enumerator);
					if (\u0019\u0010\u0004.\u0007(selectedExcel) == ActionTypes.None)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.OHR(List<SelectedExcel>)).MethodHandle;
						}
						if (\u0001\u0016\u0004.\u0007(selectedExcel) != UpdateStates.Modified)
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
							if (\u0001\u0016\u0004.\u0007(selectedExcel) != UpdateStates.Recreate)
							{
								continue;
							}
							for (;;)
							{
								switch (6)
								{
								case 0:
									continue;
								}
								break;
							}
						}
					}
					bool flag;
					if (!\u0010\u0002\u001D.\u000A(\u0011\u0020\u001D.\u0007(selectedExcel)))
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
						flag = (\u0001\u0016\u0004.\u0007(selectedExcel) == UpdateStates.ToTrash);
					}
					else
					{
						flag = true;
					}
					bool flag2 = flag;
					if (\u000A\u001E\u001D.\u000A(\u000A\u001B\u0004.\u001D(selectedExcel)) == 0)
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
						if (\u0001\u0016\u0004.\u0007(selectedExcel) != UpdateStates.ToTrash)
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
							flag2 = false;
						}
					}
					if (!\u000D\u001B\u0004.\u001D(selectedExcel, \u0006\u0020\u001D.\u0007(selectedExcel), false))
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
						if (\u0001\u0016\u0004.\u0007(selectedExcel) != UpdateStates.ToTrash)
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
							flag2 = false;
						}
					}
					if (flag2)
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
						\u001A\u0016\u0004.\u000A(u001F, selectedExcel);
					}
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
			int num = 1;
			int num2 = \u000C\u001B\u0004.\u000A(u001F);
			bool flag3 = false;
			StyleMappingDto styleMappingDto = \u0017\u0019\u0019.\u000A(this);
			bool flag4;
			if (styleMappingDto == null)
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
				flag4 = false;
			}
			else
			{
				flag4 = \u0001\u0004\u0004.\u0007(\u0009\u0004\u0004.\u001D(styleMappingDto));
			}
			bool u = flag4;
			StyleMappingDto styleMappingDto2 = \u0017\u0019\u0019.\u000A(this);
			DecimalSymbolOption decimalSymbolOption;
			if (styleMappingDto2 == null)
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
				decimalSymbolOption = DecimalSymbolOption.UseSystemSettings;
			}
			else
			{
				decimalSymbolOption = \u0016\u0010\u0004.\u000A(\u0009\u0004\u0004.\u001D(styleMappingDto2));
			}
			DecimalSymbolOption u000A = decimalSymbolOption;
			\u001C\u0016 u001D = \u001C\u0016.\u0005(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()), u000A);
			enumerator = \u000A\u0016\u0004.\u000A(u001F);
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					SelectedExcel selectedExcel2 = \u001F\u0016\u0004.\u000A(ref enumerator);
					MainWindow.\u000B\u000B u000B_u000B = new MainWindow.\u000B\u000B();
					u000B_u000B.\u000A = u0016_u000B;
					u000B_u000B.\u001F = num * 100 / num2;
					this.QHR(u000B_u000B.\u001F);
					num++;
					if (\u0019\u0010\u0004.\u0007(selectedExcel2) == ActionTypes.Delete)
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
						\u0020\u0019 u0020_u = new \u0020\u0019();
						\u0004\u0020\u001D.\u000A(u0020_u, selectedExcel2);
						\u001F\u000B\u0019.\u000A(u000B_u000B.\u000A.\u000A, u0020_u);
					}
					else
					{
						try
						{
							\u0020\u0019 u000A2 = \u0006\u0016.\u001F(selectedExcel2, \u000A\u000B\u0019.\u0007(\u0003\u0019\u0019.\u000A()), new Action(u000B_u000B.\u0007), u001D, u);
							\u001F\u000B\u0019.\u000A(u000B_u000B.\u000A.\u000A, u000A2);
						}
						catch (Exception ex)
						{
							MainWindow.\u0002\u000B u0002_u000B = new MainWindow.\u0002\u000B();
							u0002_u000B.\u000A = u000B_u000B;
							Exception u001F2 = ex;
							u0002_u000B.\u001F = u001F2;
							flag3 = true;
							\u000C\u0018\u0019.\u000A(\u001C\u0015\u0007.\u0007(this), new Action(u0002_u000B.\u0007));
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
			if (!flag3)
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
				\u000C\u0018\u0019.\u000A(\u001C\u0015\u0007.\u0007(this), new Action(u0016_u000B.\u0007));
			}
		}

		// Token: 0x06000CF8 RID: 3320 RVA: 0x00053B10 File Offset: 0x00051D10
		private void THR(Exception F)
		{
			this.FYR(true);
			\u000A\u0016.\u001F(F);
		}

		// Token: 0x06000CF9 RID: 3321 RVA: 0x00053B2C File Offset: 0x00051D2C
		private void IHR(List<\u0020\u0019> F, StyleMappingDto R = null)
		{
			if (!\u0004\u0013\u001D.\u0007(\u000A\u000B\u0019.\u0007(\u0003\u0019\u0019.\u000A())))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.IHR(List<\u0020\u0019>, StyleMappingDto)).MethodHandle;
				}
				\u0003\u0019\u0019.\u000A().\u0007 += this.GHR;
				\u0003\u0019\u0019.\u000A().\u001D += this.QHR;
				\u0010\u0019\u0019.\u000A(\u0003\u0019\u0019.\u000A(), false);
				\u000D\u0019\u0019.\u0007(\u0003\u0019\u0019.\u000A(), false);
				\u001C\u0019\u0019.\u0007(\u0003\u0019\u0019.\u000A(), false);
				\u0019\u000B\u0019.\u000A(\u0003\u0019\u0019.\u000A(), F);
				\u0004\u000B\u0019.\u0007(\u0003\u0019\u0019.\u000A(), R);
				\u001D\u000B\u0019.\u0007(\u0003\u0019\u0019.\u000A(), this.DD);
				\u0011\u001E\u000A.\u000A(\u000F\u0019\u0019.\u000A());
			}
		}

		// Token: 0x06000CFA RID: 3322 RVA: 0x00053BF8 File Offset: 0x00051DF8
		private void QHR(int F)
		{
			MainWindow.\u0006\u000B u0006_u000B = new MainWindow.\u0006\u000B();
			u0006_u000B.\u001F = this;
			u0006_u000B.\u000A = F;
			\u0018\u000B\u0019.\u000A(\u001C\u0015\u0007.\u0007(this), new Action(u0006_u000B.\u0007), DispatcherPriority.Background);
		}

		// Token: 0x06000CFB RID: 3323 RVA: 0x00053C34 File Offset: 0x00051E34
		private void QHR(int F, string R)
		{
			MainWindow.\u000F\u000B u000F_u000B = new MainWindow.\u000F\u000B();
			u000F_u000B.\u001F = this;
			u000F_u000B.\u000A = F;
			u000F_u000B.\u0007 = R;
			\u0018\u000B\u0019.\u000A(\u001C\u0015\u0007.\u0007(this), new Action(u000F_u000B.\u001D), DispatcherPriority.Background);
		}

		// Token: 0x06000CFC RID: 3324 RVA: 0x00053C78 File Offset: 0x00051E78
		private void AHR(int F)
		{
			\u000E\u0015\u0007.\u000A(this.JR, \u000E\u0016\u0019.\u000A(F));
			object nr = this.NR;
			string[] array = \u001B\u001F\u000E.\u001F(5);
			array[0] = "[1/2] ";
			array[1] = \u0017\u001D\u0019.\u000A();
			array[2] = " ";
			array[3] = \u000C\u0013\u0007.\u000A(ref F);
			array[4] = "%";
			\u0014\u001A\u000A.\u000A(nr, \u0014\u0006\u001D.\u000A(array));
		}

		// Token: 0x06000CFD RID: 3325 RVA: 0x00053CE0 File Offset: 0x00051EE0
		private void AHR(int F, string R)
		{
			\u000E\u0015\u0007.\u000A(this.JR, \u000E\u0016\u0019.\u000A(F));
			object nr = this.NR;
			string[] array = \u001B\u001F\u000E.\u001F(5);
			array[0] = "[2/2] ";
			int num = 1;
			string text;
			if (!\u0016\u000B\u0019.\u000A())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.AHR(int, string)).MethodHandle;
				}
				text = \u0004\u001E\u000A.\u000A(\u0007\u0018\u0019.\u000A(), " ");
			}
			else
			{
				text = \u0004\u001E\u000A.\u000A(\u0005\u000B\u0019.\u000A(), " ");
			}
			array[num] = text;
			array[2] = \u000C\u0013\u0007.\u000A(ref F);
			array[3] = "% - ";
			array[4] = R;
			\u0014\u001A\u000A.\u000A(nr, \u0014\u0006\u001D.\u000A(array));
			this.C.HKR();
		}

		// Token: 0x06000CFE RID: 3326 RVA: 0x00053D8C File Offset: 0x00051F8C
		private void GHR()
		{
			\u0003\u0019\u0019.\u000A().\u0007 -= this.GHR;
			\u0003\u0019\u0019.\u000A().\u001D -= this.QHR;
			\u0018\u000B\u0019.\u000A(\u001C\u0015\u0007.\u0007(this), new Action(this.VL), DispatcherPriority.Background);
		}

		// Token: 0x06000CFF RID: 3327 RVA: 0x00053DE4 File Offset: 0x00051FE4
		private void VL()
		{
			\u000E\u0015\u0007.\u000A(this.JR, \u000E\u0016\u0019.\u000A(100));
			\u0014\u001A\u000A.\u000A(this.NR, \u0004\u001E\u000A.\u000A(\u0007\u0018\u0019.\u000A(), " 100%"));
			this.FYR(true);
			this.C.HKR();
			if (!\u0016\u000B\u0019.\u000A())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.VL()).MethodHandle;
				}
				if (!\u0002\u000B\u0019.\u000A(\u0003\u0019\u0019.\u000A()))
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
					\u000F\u0005\u0019.\u000A(\u000B\u000B\u0019.\u000A(), this, MessageBoxButtons.OK);
				}
			}
			\u000E\u0015\u0007.\u000A(this.JR, \u000E\u0016\u0019.\u000A(0));
			\u0014\u001A\u000A.\u000A(this.NR, \u0004\u001E\u000A.\u000A(\u0007\u0018\u0019.\u000A(), " 0%"));
			\u0009\u0008\u0004.\u000A(false);
		}

		// Token: 0x06000D00 RID: 3328 RVA: 0x00053EB4 File Offset: 0x000520B4
		private void FYR(bool F)
		{
			\u0015\u0009\u000A.\u000A(this.ZD, F);
			\u0015\u0009\u000A.\u000A(this.WD, F);
			\u0015\u0009\u000A.\u000A(this.ED, F);
			\u0015\u0009\u000A.\u000A(this.KD, F);
			\u0015\u0009\u000A.\u000A(this.JD, F);
			\u0015\u0009\u000A.\u000A(this.UD, F);
		}

		// Token: 0x06000D01 RID: 3329 RVA: 0x00053F0C File Offset: 0x0005210C
		private void DgViews_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
		{
			SelectedExcel selectedExcel = \u0011\u0018\u000E.\u001F(\u0004\u0001\u0007.\u0007(\u0006\u000B\u0019.\u000A(e)));
			if (selectedExcel != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.DgViews_BeginningEdit(object, DataGridBeginningEditEventArgs)).MethodHandle;
				}
				this.CD = \u0014\u0005\u0004.\u0007(selectedExcel);
			}
		}

		// Token: 0x06000D02 RID: 3330 RVA: 0x00053F54 File Offset: 0x00052154
		private void DgViews_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
		{
			bool flag = true;
			SelectedExcel selectedExcel = \u0011\u0018\u000E.\u001F(\u0004\u0001\u0007.\u0007(\u001E\u000B\u0019.\u000A(e)));
			if (selectedExcel != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.DgViews_CellEditEnding(object, DataGridCellEditEndingEventArgs)).MethodHandle;
				}
				if (\u0011\u000B\u0019.\u000A(e) == DataGridEditAction.Commit)
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
					TextBox textBox = \u0008\u000A\u000E.\u001F(\u001B\u000B\u0019.\u000A(e));
					if (textBox == null)
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
					if (\u0015\u001F\u0019.\u000A(\u0003\u000B\u0019.\u0007(textBox), true, \u000D\u0018\u000E.\u001F))
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
						\u000F\u000B\u0019.\u000A(e, true);
						\u0008\u000B\u0019.\u000A(this.ED);
						\u0008\u000B\u0019.\u000A(this.ED);
						return;
					}
					DataGridBoundColumn dataGridBoundColumn = \u0015\u0018\u000E.\u001F(\u000E\u000B\u0019.\u000A(e));
					string u001F;
					if (dataGridBoundColumn == null)
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
						u001F = null;
					}
					else
					{
						u001F = \u0010\u000B\u0019.\u0007(dataGridBoundColumn);
					}
					if (\u0008\u0013\u000A.\u000A(u001F, "View Name"))
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
						if (\u001A\u0006\u0007.\u000A(\u0003\u000B\u0019.\u0007(textBox)))
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
							flag = false;
							\u0011\u001F\u0019.\u000A(\u000D\u000B\u0019.\u000A(), MessageBoxButtons.OK);
							\u000F\u000B\u0019.\u000A(e, true);
							\u0004\u0017\u0004.\u000A(selectedExcel, this.CD);
						}
						if (flag)
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
							if (!\u0001\u0016\u001D.\u000A(\u0003\u000B\u0019.\u0007(textBox), " "))
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
								if (!\u0014\u001E\u001D.\u000A(\u0003\u000B\u0019.\u0007(textBox), " "))
								{
									goto IL_1A1;
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
							}
							flag = false;
							\u0011\u001F\u0019.\u000A(\u001C\u000B\u0019.\u000A(), MessageBoxButtons.OK);
							\u000F\u000B\u0019.\u000A(e, true);
							\u0004\u0017\u0004.\u000A(selectedExcel, this.CD);
						}
						IL_1A1:
						if (flag)
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
							ViewType u001F2 = \u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(selectedExcel));
							List<SelectedExcel> u001F3 = \u0003\u000B\u0004.\u000A();
							List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(\u001C\u001B\u0004.\u000A());
							try
							{
								while (\u0001\u0005\u0004.\u000A(ref enumerator))
								{
									SelectedExcel selectedExcel2 = \u001F\u0016\u0004.\u000A(ref enumerator);
									if (\u0008\u0013\u000A.\u000A(\u0014\u0005\u0004.\u0007(selectedExcel2), \u0014\u0005\u0004.\u0007(selectedExcel)))
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
										if (\u0010\u001B\u0004.\u000A(\u0006\u0020\u001D.\u0007(selectedExcel2), \u0006\u0020\u001D.\u0007(selectedExcel)))
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
											\u001A\u0016\u0004.\u000A(u001F3, selectedExcel2);
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
							if (\u000C\u001B\u0004.\u000A(u001F3) > 1)
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
								flag = false;
								\u0011\u001F\u0019.\u000A(\u0012\u000B\u0019.\u000A(), MessageBoxButtons.OK);
								\u000F\u000B\u0019.\u000A(e, true);
								\u0004\u0017\u0004.\u000A(selectedExcel, this.CD);
							}
							if (\u0019\u0010\u0004.\u0007(selectedExcel) == ActionTypes.Create)
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
								if (\u0015\u0018.\u000A(u001F2, \u0003\u000B\u0019.\u0007(textBox)))
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
									flag = false;
									\u0011\u001F\u0019.\u000A(\u0012\u000B\u0019.\u000A(), MessageBoxButtons.OK);
									\u000F\u000B\u0019.\u000A(e, true);
									\u0004\u0017\u0004.\u000A(selectedExcel, this.CD);
								}
							}
						}
					}
				}
				if (flag)
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
					\u0013\u0016\u0019.\u000A(this.ED, new EventHandler<DataGridCellEditEndingEventArgs>(this.DgViews_CellEditEnding));
					\u0014\u0016\u0019.\u000A(this.ED, DataGridEditingUnit.Row, true);
					if (\u001D\u0017\u000A.\u000A(\u0016\u000B\u0004.\u000A(selectedExcel), \u0014\u0005\u0004.\u0007(selectedExcel)))
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
						if (\u0001\u0016\u0004.\u0007(selectedExcel) == UpdateStates.Updated)
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
							\u000D\u0016\u0004.\u0007(selectedExcel, UpdateStates.Modified);
						}
					}
					\u0017\u0016\u0019.\u000A(this.ED, new EventHandler<DataGridCellEditEndingEventArgs>(this.DgViews_CellEditEnding));
					return;
				}
				\u0013\u0016\u0019.\u000A(this.ED, new EventHandler<DataGridCellEditEndingEventArgs>(this.DgViews_CellEditEnding));
				\u0014\u0016\u0019.\u000A(this.ED, DataGridEditingUnit.Row, true);
				\u0017\u0016\u0019.\u000A(this.ED, new EventHandler<DataGridCellEditEndingEventArgs>(this.DgViews_CellEditEnding));
			}
		}

		// Token: 0x06000D03 RID: 3331 RVA: 0x0005432C File Offset: 0x0005252C
		private void Window_Closing(object sender, CancelEventArgs e)
		{
			if (this.RYR())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.Window_Closing(object, CancelEventArgs)).MethodHandle;
				}
				if (!\u000F\u0005\u0019.\u000A(\u0017\u000B\u0019.\u000A(), this, MessageBoxButtons.YesNo))
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
					\u0020\u000B\u0019.\u000A(e, true);
					return;
				}
			}
			SelectedExcel.XR -= this.GDR;
			SelectedExcel.PR -= this.ADR;
		}

		// Token: 0x06000D04 RID: 3332 RVA: 0x0005439C File Offset: 0x0005259C
		private bool RYR()
		{
			if (\u0017\u0019\u0019.\u000A(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.RYR()).MethodHandle;
				}
				return false;
			}
			Profile yd = this.YD;
			object u001F;
			if (yd == null)
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
				u001F = null;
			}
			else
			{
				u001F = \u001C\u000D\u0004.\u001D(yd);
			}
			StyleMappingProfileTemplate styleMappingProfileTemplate = \u0017\u0019\u000E.\u001F(u001F);
			if (styleMappingProfileTemplate != null)
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
				StyleMappingDto styleMappingDto = \u0003\u000D\u0004.\u000A(styleMappingProfileTemplate);
				if (styleMappingDto != null)
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
					if (\u000E\u0018\u0019.\u000A(\u0017\u0019\u0019.\u000A(this), styleMappingDto))
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
						return false;
					}
				}
			}
			try
			{
				\u0010\u0016.\u000D\u0016 u000D_u = \u0010\u0016.\u0007(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()));
				bool flag;
				if (u000D_u == null)
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
					flag = (null != null);
				}
				else
				{
					flag = (\u0019\u0018\u0019.\u001D(u000D_u) != null);
				}
				if (flag)
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
					if (\u000E\u0018\u0019.\u000A(\u0017\u0019\u0019.\u000A(this), \u0019\u0018\u0019.\u0007(u000D_u)))
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
						return false;
					}
				}
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\UI\\Windows\\MainWindow.xaml.cs", "HasUnsavedStyleMappingChanges");
			}
			return true;
		}

		// Token: 0x06000D05 RID: 3333 RVA: 0x000544C0 File Offset: 0x000526C0
		private void cmbBatchActions_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			BatchAction batchAction = \u000C\u0018\u000E.\u001F(\u0019\u000C\u0007.\u001D(this.KD));
			if (batchAction != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.cmbBatchActions_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				if (\u001A\u000B\u0019.\u0007(batchAction))
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
					return;
				}
				IEnumerable<SelectedExcel> enumerable = \u001C\u001B\u0004.\u000A();
				Func<SelectedExcel, bool> func;
				if ((func = MainWindow.<>c.\u0002) == null)
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
					func = (MainWindow.<>c.\u0002 = new Func<SelectedExcel, bool>(MainWindow.<>c.\u001F.\u001B));
				}
				if (\u000C\u001B\u0004.\u000A(Enumerable.ToList<SelectedExcel>(Enumerable.Where<SelectedExcel>(enumerable, func))) > 0)
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
					List<SelectedExcel> list = \u0003\u000B\u0004.\u000A();
					List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(\u001C\u001B\u0004.\u000A());
					try
					{
						while (\u0001\u0005\u0004.\u000A(ref enumerator))
						{
							SelectedExcel selectedExcel = \u001F\u0016\u0004.\u000A(ref enumerator);
							if (\u0009\u0017\u0004.\u000A(selectedExcel))
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
								\u001A\u0016\u0004.\u000A(list, selectedExcel);
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
					\u0006\u0016\u0019.\u000A(this, \u0013\u000B\u0019.\u0007(batchAction), list);
				}
				else
				{
					\u0011\u001F\u0019.\u000A(\u0014\u000B\u0019.\u000A(), MessageBoxButtons.OK);
				}
			}
			\u0004\u000C\u000A.\u000A(this.KD, 0);
		}

		// Token: 0x06000D06 RID: 3334 RVA: 0x00054608 File Offset: 0x00052808
		private void Window_Closed(object sender, EventArgs e)
		{
			\u000A\u0002\u0019.\u000A(\u000A\u000B\u0019.\u0007(\u0003\u0019\u0019.\u000A()));
			\u0003\u0019\u0019.\u000A().\u0007 -= this.GHR;
			\u0003\u0019\u0019.\u000A().\u001D -= this.QHR;
			\u0016\u0019\u0019.\u000A(true);
			\u001F\u0002\u0019.\u000A(\u0013\u0018\u000E.\u001F);
			\u0009\u000B\u0019.\u000A(\u0006\u0001\u001D.\u000A());
			List<SelectedExcel> list = \u001C\u001B\u0004.\u000A();
			if (list == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.Window_Closed(object, EventArgs)).MethodHandle;
				}
			}
			else
			{
				\u0001\u000B\u0019.\u0007(list);
			}
			\u0015\u000B\u0019.\u000A(\u0012\u0010\u0004.\u000A());
			\u000C\u000B\u0019.\u000A(this.FD);
			this.FD = \u001A\u0018\u000E.\u001F;
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x000546BC File Offset: 0x000528BC
		private void GridSelectedStatus_Checked(object sender, RoutedEventArgs e)
		{
			IEnumerator u001F = \u001D\u0011\u000A.\u000A(\u0009\u0006\u0007.\u0007(this.ED));
			try
			{
				while (\u000A\u0017\u000A.\u000A(u001F))
				{
					SelectedExcel selectedExcel = \u0011\u0018\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F));
					if (selectedExcel != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.GridSelectedStatus_Checked(object, RoutedEventArgs)).MethodHandle;
						}
						\u0001\u0020\u0004.\u000A(selectedExcel, true);
					}
				}
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			finally
			{
				IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F);
				if (disposable != null)
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
					\u001F\u0017\u000A.\u000A(disposable);
				}
			}
		}

		// Token: 0x06000D08 RID: 3336 RVA: 0x00054750 File Offset: 0x00052950
		private void GridSelectedStatus_Unchecked(object sender, RoutedEventArgs e)
		{
			IEnumerator u001F = \u001D\u0011\u000A.\u000A(\u0009\u0006\u0007.\u0007(this.ED));
			try
			{
				while (\u000A\u0017\u000A.\u000A(u001F))
				{
					SelectedExcel selectedExcel = \u0011\u0018\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F));
					if (selectedExcel != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.GridSelectedStatus_Unchecked(object, RoutedEventArgs)).MethodHandle;
						}
						\u0001\u0020\u0004.\u000A(selectedExcel, false);
					}
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
			}
			finally
			{
				IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F);
				if (disposable != null)
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
					\u001F\u0017\u000A.\u000A(disposable);
				}
			}
		}

		// Token: 0x06000D09 RID: 3337 RVA: 0x000547E4 File Offset: 0x000529E4
		private void BtnRefresh_Click(object sender, RoutedEventArgs e)
		{
			\u000A\u0018\u0019.\u000A(\u0016\u001E\u0004.\u000A());
			this.DYR();
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06000D0A RID: 3338 RVA: 0x00054804 File Offset: 0x00052A04
		// (set) Token: 0x06000D0B RID: 3339 RVA: 0x00054818 File Offset: 0x00052A18
		public StyleMappingDto MappingSettings { get; set; }

		// Token: 0x06000D0C RID: 3340 RVA: 0x0005482C File Offset: 0x00052A2C
		private void BtnStyleMappingSettings_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				MainWindow.\u0012\u000B u0012_u000B = new MainWindow.\u0012\u000B();
				u0012_u000B.\u000A = this;
				u0012_u000B.\u001F = \u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>());
				object c = this.C;
				IEnumerable<SelectedExcel> u000A = \u001C\u001B\u0004.\u000A();
				bool u = false;
				Action u001D = new Action(u0012_u000B.\u0007);
				BlackAndWhiteTextLinesOption? u2;
				\u000E\u0018\u000E.\u001F(ref u2);
				\u001C\u0016\u0019.\u000A(c, u000A, u, u001D, u2);
			}
			catch (Exception u001F)
			{
				\u000A\u0016.\u001F(u001F);
			}
		}

		// Token: 0x06000D0D RID: 3341 RVA: 0x0005489C File Offset: 0x00052A9C
		private void DYR()
		{
			\u000A\u0018\u0019.\u000A(\u0016\u001E\u0004.\u000A());
			List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(\u001C\u001B\u0004.\u000A());
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					\u001A\u0011\u0004.\u001D(\u001F\u0016\u0004.\u000A(ref enumerator));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.DYR()).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			this.C.HKR();
		}

		// Token: 0x06000D0E RID: 3342 RVA: 0x00054920 File Offset: 0x00052B20
		private void DgViews_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (\u0015\u001F\u0019.\u000A(\u0001\u0015\u0007.\u000A(e), false, \u000D\u0018\u000E.\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.DgViews_PreviewTextInput(object, TextCompositionEventArgs)).MethodHandle;
				}
				\u0019\u0013\u000A.\u000A(e, true);
			}
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x00054960 File Offset: 0x00052B60
		private void DgViews_ContextMenuOpening(object sender, ContextMenuEventArgs e)
		{
			if (this.SD)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.DgViews_ContextMenuOpening(object, ContextMenuEventArgs)).MethodHandle;
				}
				if (\u0018\u0013\u000A.\u000A(\u0009\u0006\u0007.\u0007(this.ED)) != 0)
				{
					goto IL_42;
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
			}
			\u0019\u0013\u000A.\u000A(e, true);
			IL_42:
			this.SD = false;
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x000549B8 File Offset: 0x00052BB8
		private void DgViews_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			this.SD = true;
		}

		// Token: 0x06000D11 RID: 3345 RVA: 0x000549CC File Offset: 0x00052BCC
		protected override void ApplyLicense(bool isLicenseValid)
		{
			if (!isLicenseValid)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.ApplyLicense(bool)).MethodHandle;
				}
				\u0019\u000B\u0007.\u0007(this);
			}
		}

		// Token: 0x06000D12 RID: 3346 RVA: 0x000549F8 File Offset: 0x00052BF8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/tablegen/tablegen/ui/windows/mainwindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x00054A40 File Offset: 0x00052C40
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0016\u0002\u0019.\u000A(\u0014\u0018\u000E.\u001F(R), new EventHandler(this.DiRootsWindow_Activated));
				\u0016\u0015\u0007.\u0007(\u0014\u0018\u000E.\u001F(R), new EventHandler(this.Window_Closed));
				\u0017\u0015\u0007.\u0007(\u0014\u0018\u000E.\u001F(R), new CancelEventHandler(this.Window_Closing));
				\u0011\u000C\u000A.\u0007(\u0014\u0018\u000E.\u001F(R), new RoutedEventHandler(this.Window_Loaded));
				return;
			case 2:
				this.BD = \u0014\u0001\u0010.\u001F(R);
				return;
			case 3:
				this.UD = \u0005\u0009\u0010.\u001F(R);
				return;
			case 4:
				this.JR = \u0013\u000A\u000E.\u001F(R);
				return;
			case 5:
				this.NR = \u001A\u000A\u000E.\u001F(R);
				return;
			case 6:
				this.WD = \u0004\u0009\u0010.\u001F(R);
				return;
			case 7:
				this.KD = \u000B\u000A\u000E.\u001F(R);
				\u001B\u000C\u000A.\u0007(this.KD, new SelectionChangedEventHandler(this.cmbBatchActions_SelectionChanged));
				return;
			case 8:
				this.JD = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.JD, new RoutedEventHandler(this.BtnRefresh_Click));
				return;
			case 9:
				\u0010\u0015\u000A.\u000A(\u001E\u0001\u0010.\u001F(R), new RoutedEventHandler(this.BtnStyleMappingSettings_Click));
				return;
			case 10:
				this.ED = \u0020\u0001\u0010.\u001F(R);
				\u0005\u0002\u0019.\u000A(this.ED, new DragEventHandler(this.DgViews_PreviewDrag));
				\u0018\u0002\u0019.\u000A(this.ED, new DragEventHandler(this.DgViews_PreviewDrag));
				\u0019\u0002\u0019.\u000A(this.ED, new DragEventHandler(this.DgViews_PreviewDrag));
				\u0004\u0002\u0019.\u000A(this.ED, new EventHandler<DataGridBeginningEditEventArgs>(this.DgViews_BeginningEdit));
				\u0017\u0016\u0019.\u000A(this.ED, new EventHandler<DataGridCellEditEndingEventArgs>(this.DgViews_CellEditEnding));
				\u001D\u0002\u0019.\u000A(this.ED, new ContextMenuEventHandler(this.DgViews_ContextMenuOpening));
				\u0007\u0002\u0019.\u000A(this.ED, new MouseButtonEventHandler(this.DgViews_MouseRightButtonDown));
				\u000F\u0001\u0007.\u000A(this.ED, new TextCompositionEventHandler(this.DgViews_PreviewTextInput));
				\u001B\u000C\u000A.\u0007(this.ED, new SelectionChangedEventHandler(this.DgViews_SelectionChanged));
				return;
			case 11:
				this.ND = \u0016\u0009\u0010.\u001F(R);
				\u000E\u0015\u000A.\u000A(this.ND, new RoutedEventHandler(this.ChkSheetSelect_Checked));
				\u000D\u0015\u000A.\u000A(this.ND, new RoutedEventHandler(this.ChkSheetSelect_Unchecked));
				return;
			case 13:
				this.VR = \u000B\u000A\u000E.\u001F(R);
				return;
			case 14:
				this.ZR = \u000B\u000A\u000E.\u001F(R);
				return;
			case 15:
				this.MD = \u0016\u000A\u000E.\u001F(R);
				return;
			case 16:
				this.VD = \u0016\u000A\u000E.\u001F(R);
				return;
			case 17:
				this.KR = \u001A\u000A\u000E.\u001F(R);
				return;
			case 18:
				this.ZD = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.ZD, new RoutedEventHandler(this.btnOkay_Click));
				return;
			}
			this.R = true;
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x00054D4C File Offset: 0x00052F4C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.AQ(int F, object R)
		{
			if (F == 12)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.AQ(int, object)).MethodHandle;
				}
				\u000E\u0015\u000A.\u000A(\u0016\u0009\u0010.\u001F(R), new RoutedEventHandler(this.GridSelectedStatus_Checked));
				\u000D\u0015\u000A.\u000A(\u0016\u0009\u0010.\u001F(R), new RoutedEventHandler(this.GridSelectedStatus_Unchecked));
			}
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x00054DA4 File Offset: 0x00052FA4
		[CompilerGenerated]
		private StyleMappingDto HYR()
		{
			return \u0017\u0019\u0019.\u000A(this);
		}

		// Token: 0x06000D16 RID: 3350 RVA: 0x00054DBC File Offset: 0x00052FBC
		[CompilerGenerated]
		private Profile YYR()
		{
			return this.YD;
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x00054DD0 File Offset: 0x00052FD0
		[CompilerGenerated]
		private void CYR(IEnumerable<SelectedExcel> F, BlackAndWhiteTextLinesOption R)
		{
			\u001C\u0016\u0019.\u000A(this.C, F, true, null, new BlackAndWhiteTextLinesOption?(R));
		}

		// Token: 0x06000D18 RID: 3352 RVA: 0x00054DF4 File Offset: 0x00052FF4
		[CompilerGenerated]
		private void LYR(BlackAndWhiteTextLinesOption F)
		{
			\u000B\u0002\u0019.\u000A(this.C, new BlackAndWhiteTextLinesOption?(F));
		}

		// Token: 0x04000517 RID: 1303
		private static string StyleMappingProfilesFileName;

		// Token: 0x04000518 RID: 1304
		private DispatcherTimer FD;

		// Token: 0x04000519 RID: 1305
		private bool RD;

		// Token: 0x0400051A RID: 1306
		private MainWindowViewModel C;

		// Token: 0x0400051B RID: 1307
		private string DD;

		// Token: 0x0400051C RID: 1308
		private ObservableCollection<Profile> HD;

		// Token: 0x0400051D RID: 1309
		private Profile YD;

		// Token: 0x0400051E RID: 1310
		private string CD = "";

		// Token: 0x0400051F RID: 1311
		[CompilerGenerated]
		private StyleMappingDto LD;

		// Token: 0x04000520 RID: 1312
		private bool SD;

		// Token: 0x04000521 RID: 1313
		internal Grid BD;

		// Token: 0x04000522 RID: 1314
		internal WatermarkTextBox UD;

		// Token: 0x04000523 RID: 1315
		internal ProgressBar JR;

		// Token: 0x04000524 RID: 1316
		internal Label NR;

		// Token: 0x04000525 RID: 1317
		internal LeftImageButton WD;

		// Token: 0x04000526 RID: 1318
		internal ComboBox KD;

		// Token: 0x04000527 RID: 1319
		internal Button JD;

		// Token: 0x04000528 RID: 1320
		internal DataGrid ED;

		// Token: 0x04000529 RID: 1321
		internal CheckBox ND;

		// Token: 0x0400052A RID: 1322
		internal ComboBox VR;

		// Token: 0x0400052B RID: 1323
		internal ComboBox ZR;

		// Token: 0x0400052C RID: 1324
		internal DataGridTemplateColumn MD;

		// Token: 0x0400052D RID: 1325
		internal DataGridTemplateColumn VD;

		// Token: 0x0400052E RID: 1326
		internal Label KR;

		// Token: 0x0400052F RID: 1327
		internal Button ZD;

		// Token: 0x04000530 RID: 1328
		private bool R;

		// Token: 0x02000830 RID: 2096
		[CompilerGenerated]
		private sealed class \u001D\u000B
		{
			// Token: 0x06004E15 RID: 19989 RVA: 0x001DFAD0 File Offset: 0x001DDCD0
			internal bool \u0004(Profile \u001F)
			{
				if (\u001F != this.\u001F)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.\u001D\u000B.\u0004(Profile)).MethodHandle;
					}
					if (\u001A\u0018\u0019.\u0007(\u001F) != null)
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
						if (!\u001B\u0003\u0004.\u000A(\u001A\u0018\u0019.\u0007(\u001F), this.\u000A, StringComparison.Ordinal))
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
							return \u000C\u000F\u0007.\u001D(this.\u0007, \u001A\u0018\u0019.\u0007(\u001F));
						}
						return true;
					}
				}
				return false;
			}

			// Token: 0x06004E16 RID: 19990 RVA: 0x001DFB48 File Offset: 0x001DDD48
			internal bool \u0019(Profile \u001F)
			{
				return MainWindow.HHR(\u001F, this.\u001D);
			}

			// Token: 0x06004E17 RID: 19991 RVA: 0x001DFB64 File Offset: 0x001DDD64
			internal bool \u0018(Profile \u001F)
			{
				return \u001B\u0003\u0004.\u000A(\u001A\u0018\u0019.\u0007(\u001F), this.\u000A, StringComparison.Ordinal);
			}

			// Token: 0x040020C1 RID: 8385
			public Profile \u001F;

			// Token: 0x040020C2 RID: 8386
			public string \u000A;

			// Token: 0x040020C3 RID: 8387
			public Regex \u0007;

			// Token: 0x040020C4 RID: 8388
			public StyleMappingDto \u001D;
		}

		// Token: 0x02000831 RID: 2097
		[CompilerGenerated]
		private sealed class \u0004\u000B
		{
			// Token: 0x06004E19 RID: 19993 RVA: 0x001DFB9C File Offset: 0x001DDD9C
			internal bool \u0007(SelectedExcel \u001F)
			{
				if (\u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(\u001F)) == this.\u001F)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.\u0004\u000B.\u0007(SelectedExcel)).MethodHandle;
					}
					return \u0008\u0013\u000A.\u000A(\u0014\u0005\u0004.\u0007(\u001F), this.\u000A);
				}
				return false;
			}

			// Token: 0x040020C5 RID: 8389
			public ViewType \u001F;

			// Token: 0x040020C6 RID: 8390
			public string \u000A;
		}

		// Token: 0x02000832 RID: 2098
		[CompilerGenerated]
		private sealed class \u0019\u000B
		{
			// Token: 0x06004E1B RID: 19995 RVA: 0x001DFC00 File Offset: 0x001DDE00
			internal void \u0007()
			{
				if (\u0017\u0019\u0019.\u000A(this.\u001F) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.\u0019\u000B.\u0007()).MethodHandle;
					}
					\u0004\u0018\u0019.\u000A(this.\u001F, \u0001\u000A\u0010.\u000A(this.\u001F.C));
				}
				\u0015\u000A\u0010.\u000A(this.\u001F.C, this.\u000A);
				\u0002\u0005.\u0001(\u0017\u0019\u0019.\u000A(this.\u001F), \u001C\u001B\u0004.\u000A());
				this.\u001F.ZHR(\u001C\u001B\u0004.\u000A());
			}

			// Token: 0x040020C7 RID: 8391
			public MainWindow \u001F;

			// Token: 0x040020C8 RID: 8392
			public Document \u000A;
		}

		// Token: 0x02000833 RID: 2099
		[CompilerGenerated]
		private sealed class \u0018\u000B
		{
			// Token: 0x06004E1D RID: 19997 RVA: 0x001DFCA4 File Offset: 0x001DDEA4
			internal void \u0007(object \u001F)
			{
				this.\u001F.OHR(this.\u000A);
			}

			// Token: 0x040020C9 RID: 8393
			public MainWindow \u001F;

			// Token: 0x040020CA RID: 8394
			public List<SelectedExcel> \u000A;
		}

		// Token: 0x02000834 RID: 2100
		[CompilerGenerated]
		private sealed class \u0005\u000B
		{
			// Token: 0x06004E1F RID: 19999 RVA: 0x001DFCD8 File Offset: 0x001DDED8
			internal bool \u000A(NamedRangeInfo \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001B\u0012\u0004.\u001D(\u001F), \u001B\u0012\u0004.\u001D(\u0014\u0020\u001D.\u0007(this.\u001F)));
			}

			// Token: 0x040020CB RID: 8395
			public SelectedExcel \u001F;
		}

		// Token: 0x02000835 RID: 2101
		[CompilerGenerated]
		private sealed class \u0016\u000B
		{
			// Token: 0x06004E21 RID: 20001 RVA: 0x001DFD1C File Offset: 0x001DDF1C
			internal void \u0007()
			{
				this.\u001F.IHR(this.\u000A, \u0017\u0019\u0019.\u000A(this.\u001F));
			}

			// Token: 0x040020CC RID: 8396
			public MainWindow \u001F;

			// Token: 0x040020CD RID: 8397
			public List<\u0020\u0019> \u000A;
		}

		// Token: 0x02000836 RID: 2102
		[CompilerGenerated]
		private sealed class \u000B\u000B
		{
			// Token: 0x06004E23 RID: 20003 RVA: 0x001DFD5C File Offset: 0x001DDF5C
			internal void \u0007()
			{
				this.\u000A.\u001F.QHR(this.\u001F);
			}

			// Token: 0x040020CE RID: 8398
			public int \u001F;

			// Token: 0x040020CF RID: 8399
			public MainWindow.\u0016\u000B \u000A;
		}

		// Token: 0x02000837 RID: 2103
		[CompilerGenerated]
		private sealed class \u0002\u000B
		{
			// Token: 0x06004E25 RID: 20005 RVA: 0x001DFD94 File Offset: 0x001DDF94
			internal void \u0007()
			{
				this.\u000A.\u000A.\u001F.THR(this.\u001F);
			}

			// Token: 0x040020D0 RID: 8400
			public Exception \u001F;

			// Token: 0x040020D1 RID: 8401
			public MainWindow.\u000B\u000B \u000A;
		}

		// Token: 0x02000838 RID: 2104
		[CompilerGenerated]
		private sealed class \u0006\u000B
		{
			// Token: 0x06004E27 RID: 20007 RVA: 0x001DFDD0 File Offset: 0x001DDFD0
			internal void \u0007()
			{
				this.\u001F.AHR(this.\u000A);
			}

			// Token: 0x040020D2 RID: 8402
			public MainWindow \u001F;

			// Token: 0x040020D3 RID: 8403
			public int \u000A;
		}

		// Token: 0x02000839 RID: 2105
		[CompilerGenerated]
		private sealed class \u000F\u000B
		{
			// Token: 0x06004E29 RID: 20009 RVA: 0x001DFE04 File Offset: 0x001DE004
			internal void \u001D()
			{
				this.\u001F.AHR(this.\u000A, this.\u0007);
			}

			// Token: 0x040020D4 RID: 8404
			public MainWindow \u001F;

			// Token: 0x040020D5 RID: 8405
			public int \u000A;

			// Token: 0x040020D6 RID: 8406
			public string \u0007;
		}

		// Token: 0x0200083A RID: 2106
		[CompilerGenerated]
		private sealed class \u0012\u000B
		{
			// Token: 0x06004E2B RID: 20011 RVA: 0x001DFE3C File Offset: 0x001DE03C
			internal void \u0007()
			{
				\u0015\u000A\u0010.\u000A(this.\u000A.C, this.\u001F);
				StyleCacheReloadCallback u = new StyleCacheReloadCallback(this.\u000A.CYR);
				StyleCacheSyncCallback u2 = new StyleCacheSyncCallback(this.\u000A.LYR);
				StyleMappingSettingsViewModel u001F = \u0007\u0007\u0010.\u000A(this.\u001F, \u001C\u001B\u0004.\u000A(), \u0017\u0019\u0019.\u000A(this.\u000A), this.\u000A.YD, \u0004\u0007\u0010.\u000A(this.\u000A.C), \u001D\u0007\u0010.\u000A(this.\u000A.C), u, u2);
				StyleMappingSettingsWindow styleMappingSettingsWindow = \u000A\u0007\u0010.\u000A(u001F, this.\u000A.HD, this.\u000A.YD);
				\u000C\u000E\u0007.\u0007(styleMappingSettingsWindow, this.\u000A);
				\u0020\u0014\u000A.\u0007(styleMappingSettingsWindow, WindowStartupLocation.CenterOwner);
				StyleMappingSettingsWindow u001F2 = styleMappingSettingsWindow;
				bool? flag = \u0018\u0020\u000A.\u0007(u001F2);
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.\u0012\u000B.\u0007()).MethodHandle;
					}
					\u0004\u0018\u0019.\u000A(this.\u000A, \u001F\u0007\u0010.\u000A(u001F));
					this.\u000A.YD = \u0009\u000A\u0010.\u000A(u001F2);
					this.\u000A.DD = this.\u000A.LHR(this.\u000A.YD);
					object c = this.\u000A.C;
					BlackAndWhiteTextLinesOption? u000A;
					\u000E\u0018\u000E.\u001F(ref u000A);
					\u000B\u0002\u0019.\u000A(c, u000A);
					\u0002\u0005.\u0001(\u0017\u0019\u0019.\u000A(this.\u000A), \u001C\u001B\u0004.\u000A());
					\u0020\u0019\u0019.\u000A(this.\u000A.C, this.\u000A.MHR());
					this.\u000A.EHR();
				}
			}

			// Token: 0x040020D7 RID: 8407
			public Document \u001F;

			// Token: 0x040020D8 RID: 8408
			public MainWindow \u000A;
		}
	}
}
