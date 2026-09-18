using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Forms;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.ViewModels;
using DiRoots.ProfileControl;
using ProSheets.Commons.CustomNameManageWindow.Enums;
using ProSheets.Commons.CustomNameManageWindow.Models;
using ProSheets.Commons.ViewModel;
using ProSheets.DrawingRegister.Enums;
using ProSheets.DrawingRegister.Model;
using ProSheets.DrawingRegister.Model.TreeViewModel;
using ProSheets.DrawingRegister.UI.Windows;
using ProSheets.Extensions;
using ProSheets.Models;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.XlsIO;

namespace ProSheets.DrawingRegister.ViewModels
{
	// Token: 0x02000107 RID: 263
	public class DocRegisterViewModel : ViewModelBase
	{
		// Token: 0x06000CBE RID: 3262 RVA: 0x0004ADB0 File Offset: 0x00048FB0
		public DocRegisterViewModel()
		{
			\u000A\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\DocRegisterViewModel.cs", ".ctor");
			this.\u0004\u0018 = \u0007\u0015\u0018.\u0003;
			this.\u0004\u0013();
			this.\u001A\u0013();
			this.\u000B\u0013();
			this.\u001D\u0013();
			SheetsViewModel sheetsViewModel = new SheetsViewModel();
			\u000B\u0005\u0018.\u0014(sheetsViewModel, \u0001\u000C\u0014.\u0018(this));
			\u0010\u001D\u0016.\u0018(this, sheetsViewModel);
			\u0007\u001D\u0016.\u0018(this, new HeaderViewModel());
			RevisionNumbering revisionNumbering = this.\u0002\u0013();
			\u0019\u001D\u0016.\u0018(this, new RevisionViewModel(revisionNumbering));
			\u000B\u001D\u0016.\u0018(this, new PreviewViewModel());
			\u001A\u001D\u0016.\u0018(this, true);
			\u001D\u001D\u0016.\u0018(this, false);
			\u0004\u001D\u0016.\u0018(this, false);
			\u0002\u001D\u0016.\u0018(this, new ProgressModel());
			\u000D\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\DocRegisterViewModel.cs", ".ctor");
			\u001E\u001D\u0016.\u0018(this, true);
		}

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x06000CBF RID: 3263 RVA: 0x0004AE80 File Offset: 0x00049080
		// (set) Token: 0x06000CC0 RID: 3264 RVA: 0x0004AE94 File Offset: 0x00049094
		public bool IsEnablePrevious
		{
			get
			{
				return this.\u001E\u0003;
			}
			set
			{
				this.\u001E\u0003 = value;
				\u0011\u0010\u0018.\u0018(this, "IsEnablePrevious");
			}
		}

		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x06000CC1 RID: 3265 RVA: 0x0004AEB4 File Offset: 0x000490B4
		// (set) Token: 0x06000CC2 RID: 3266 RVA: 0x0004AEC8 File Offset: 0x000490C8
		public bool IsNextEnable
		{
			get
			{
				return this.\u001D\u0003;
			}
			set
			{
				this.\u001D\u0003 = value;
				\u0011\u0010\u0018.\u0018(this, "IsNextEnable");
			}
		}

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x06000CC3 RID: 3267 RVA: 0x0004AEE8 File Offset: 0x000490E8
		// (set) Token: 0x06000CC4 RID: 3268 RVA: 0x0004AEFC File Offset: 0x000490FC
		public int SelectedTabIndex
		{
			get
			{
				return this.\u001A\u0003;
			}
			set
			{
				if (this.\u001A\u0003 != value)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.set_SelectedTabIndex(int)).MethodHandle;
					}
					this.\u001A\u0003 = value;
					\u0011\u0010\u0018.\u0018(this, "SelectedTabIndex");
				}
			}
		}

		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x06000CC5 RID: 3269 RVA: 0x0004AF38 File Offset: 0x00049138
		// (set) Token: 0x06000CC6 RID: 3270 RVA: 0x0004AF4C File Offset: 0x0004914C
		public bool PreviousTabIndexIsSheets { get; set; }

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x06000CC7 RID: 3271 RVA: 0x0004AF60 File Offset: 0x00049160
		// (set) Token: 0x06000CC8 RID: 3272 RVA: 0x0004AF74 File Offset: 0x00049174
		public bool IsEnablePreview
		{
			get
			{
				return this.\u0002\u0003;
			}
			set
			{
				this.\u0002\u0003 = value;
				\u0011\u0010\u0018.\u0018(this, "IsEnablePreview");
			}
		}

		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x06000CC9 RID: 3273 RVA: 0x0004AF94 File Offset: 0x00049194
		// (set) Token: 0x06000CCA RID: 3274 RVA: 0x0004AFA8 File Offset: 0x000491A8
		public bool IsPublishVisible
		{
			get
			{
				return this.\u0004\u0003;
			}
			set
			{
				this.\u0004\u0003 = value;
				\u0011\u0010\u0018.\u0018(this, "IsPublishVisible");
			}
		}

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x06000CCB RID: 3275 RVA: 0x0004AFC8 File Offset: 0x000491C8
		// (set) Token: 0x06000CCC RID: 3276 RVA: 0x0004AFDC File Offset: 0x000491DC
		public HeaderViewModel HeaderViewModel { get; set; }

		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x06000CCD RID: 3277 RVA: 0x0004AFF0 File Offset: 0x000491F0
		// (set) Token: 0x06000CCE RID: 3278 RVA: 0x0004B004 File Offset: 0x00049204
		public RevisionViewModel RevisionViewModel
		{
			get
			{
				return this.\u000B\u0003;
			}
			set
			{
				this.\u000B\u0003 = value;
				\u0011\u0010\u0018.\u0018(this, "RevisionViewModel");
			}
		}

		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x06000CCF RID: 3279 RVA: 0x0004B024 File Offset: 0x00049224
		// (set) Token: 0x06000CD0 RID: 3280 RVA: 0x0004B038 File Offset: 0x00049238
		public SheetsViewModel SheetViewModels { get; set; }

		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x06000CD1 RID: 3281 RVA: 0x0004B04C File Offset: 0x0004924C
		// (set) Token: 0x06000CD2 RID: 3282 RVA: 0x0004B060 File Offset: 0x00049260
		public PreviewViewModel PreviewViewModel { get; set; }

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x06000CD3 RID: 3283 RVA: 0x0004B074 File Offset: 0x00049274
		// (set) Token: 0x06000CD4 RID: 3284 RVA: 0x0004B088 File Offset: 0x00049288
		public ProgressModel ProgressBar { get; set; }

		// Token: 0x06000CD5 RID: 3285 RVA: 0x0004B09C File Offset: 0x0004929C
		private RevisionNumbering \u0002\u0013()
		{
			return \u0006\u001D\u0016.\u0018(\u0008\u001D\u0016.\u0018(this.\u0004\u0018));
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x0004B0C0 File Offset: 0x000492C0
		private void \u0004\u0013()
		{
			object u000C = Enumerable.ToList<RevitLinkInstance>(Enumerable.Cast<RevitLinkInstance>(\u0013\u0015\u0016.\u0003(\u0006\u001D\u0014.\u0003(\u0020\u001D\u0018.\u0018(this.\u0004\u0018), -2001352L))));
			List<Document> u000C2 = \u000F\u001A\u0016.\u0018();
			List<RevitLinkInstance>.Enumerator enumerator = \u0020\u0002\u0018.\u0018(u000C);
			try
			{
				while (\u001B\u001E\u0018.\u0018(ref enumerator))
				{
					RevitLinkInstance u000C3 = \u000A\u0002\u0018.\u0018(ref enumerator);
					if (\u0013\u0002\u0018.\u0018(u000C3) != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.\u0004\u0013()).MethodHandle;
						}
						\u0016\u001A\u0016.\u0018(u000C2, \u0013\u0002\u0018.\u0018(u000C3));
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
			\u0003\u001A\u0016.\u0018(u000C2);
			List<Document>.Enumerator enumerator2 = \u0014\u001A\u0016.\u0018(u000C2);
			try
			{
				while (\u0001\u001D\u0016.\u0018(ref enumerator2))
				{
					Document u000C4 = \u0018\u001A\u0016.\u0018(ref enumerator2);
					List<RevisionInformation> list = \u0016\u0004\u0016.\u0018();
					IEnumerator<Revision> enumerator3 = \u000C\u001A\u0016.\u0018(Enumerable.Cast<Revision>(\u0010\u001D\u0014.\u0014(\u0020\u001D\u0018.\u0018(u000C4), \u000A\u001D\u0018.\u0018(\u000F\u0006\u000F.\u000C()))));
					try
					{
						while (\u001F\u001E\u0018.\u0018(enumerator3))
						{
							Revision u000C5 = \u000E\u001D\u0016.\u0018(enumerator3);
							object u000C6 = list;
							RevisionInformation revisionInformation = \u0001\u0002\u0016.\u0018(u000C5);
							\u0005\u001D\u0016.\u0018(revisionInformation, true);
							\u0008\u0002\u0016.\u0018(u000C6, revisionInformation);
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
						if (enumerator3 != null)
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
							\u0020\u001E\u0018.\u0018(enumerator3);
						}
					}
					\u001B\u001D\u0016.\u0018(list);
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
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x0004B264 File Offset: 0x00049464
		[BindableMethod("TabControlChanged")]
		public void TabControlChanged(SelectionChangedEventArgs e)
		{
			if (\u0010\u000B\u000F.\u000C(\u0017\u0016\u0003.\u0018(e)) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.TabControlChanged(SelectionChangedEventArgs)).MethodHandle;
				}
				return;
			}
			\u001A\u001D\u0016.\u0018(this, true);
			\u001D\u001D\u0016.\u0018(this, true);
			\u0010\u001A\u0016.\u0018(this, true);
			\u0004\u001D\u0016.\u0018(this, false);
			switch (\u0007\u001A\u0016.\u0018(this))
			{
			case 0:
				\u001D\u001D\u0016.\u0018(this, false);
				\u001E\u001D\u0016.\u0018(this, true);
				return;
			case 1:
			{
				if (\u0019\u001A\u0016.\u0018(this))
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
					if (\u000B\u001A\u0016.\u0018() == null)
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
						if (Enumerable.Any<SheetInformation>(\u001D\u001A\u0016.\u0014(\u0011\u001A\u0016.\u0014(this))))
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
							if (\u0001\u0019\u0018.\u0018(\u001A\u001A\u0016.\u0018(), \u0001\u000C\u0014.\u0018(this), 350.0, DiRoots.One.Commons.Enums.MessageBoxButtons.YesNo))
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
								DocRegisterViewModel.\u0005\u0011\u0018 u0005_u0011_u = new DocRegisterViewModel.\u0005\u0011\u0018();
								DocRegisterViewModel.\u0005\u0011\u0018 u0005_u0011_u2 = u0005_u0011_u;
								IEnumerable<SheetInformation> enumerable = \u001D\u001A\u0016.\u0014(\u0011\u001A\u0016.\u0014(this));
								Func<SheetInformation, IEnumerable<string>> func;
								if ((func = DocRegisterViewModel.<>c.\u0014) == null)
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
									func = (DocRegisterViewModel.<>c.\u0014 = new Func<SheetInformation, IEnumerable<string>>(DocRegisterViewModel.<>c.\u000C.\u000B));
								}
								u0005_u0011_u2.\u000C = Enumerable.ToList<string>(Enumerable.SelectMany<SheetInformation, string>(enumerable, func));
								u0005_u0011_u.\u000C = Enumerable.ToList<string>(Enumerable.Distinct<string>(u0005_u0011_u.\u000C));
								\u0004\u001A\u0016.\u0018(\u001E\u001A\u0016.\u0014(\u000A\u001A\u0016.\u0014(this)), new Action<RevisionInformation>(u0005_u0011_u.\u0018));
								object u000C = \u001E\u001A\u0016.\u0014(\u000A\u001A\u0016.\u0014(this));
								Predicate<RevisionInformation> u;
								if ((u = DocRegisterViewModel.<>c.\u0003) == null)
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
									u = (DocRegisterViewModel.<>c.\u0003 = new Predicate<RevisionInformation>(DocRegisterViewModel.<>c.\u000C.\u0007));
								}
								if (\u0002\u001A\u0016.\u0018(u000C, u))
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
									object u000C2 = \u000A\u001A\u0016.\u0014(this);
									IEnumerable<RevisionInformation> enumerable2 = \u001E\u001A\u0016.\u0014(\u000A\u001A\u0016.\u0014(this));
									Func<RevisionInformation, bool> func2;
									if ((func2 = DocRegisterViewModel.<>c.\u0016) == null)
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
										func2 = (DocRegisterViewModel.<>c.\u0016 = new Func<RevisionInformation, bool>(DocRegisterViewModel.<>c.\u000C.\u0010));
									}
									\u0017\u001A\u0016.\u0014(u000C2, Enumerable.Count<RevisionInformation>(enumerable2, func2));
								}
								\u0015\u001A\u0016.\u0014(\u000A\u001A\u0016.\u0014(this));
							}
						}
					}
				}
				bool u2 = \u001F\u001A\u0016.\u0014(\u0011\u001A\u0016.\u0014(this));
				\u0020\u001A\u0016.\u0018(\u000A\u001A\u0016.\u0014(this), u2);
				\u0009\u001A\u0016.\u0018(\u000A\u001A\u0016.\u0014(this));
				\u001E\u001D\u0016.\u0018(this, false);
				return;
			}
			case 2:
				\u001E\u001D\u0016.\u0018(this, false);
				return;
			case 3:
				\u0013\u001A\u0016.\u0018(\u000D\u001A\u0016.\u0018(this), false);
				\u0004\u001D\u0016.\u0018(this, true);
				\u001A\u001D\u0016.\u0018(this, false);
				\u001C\u001A\u0016.\u0018(this);
				\u0012\u001A\u0016.\u0018(\u000D\u001A\u0016.\u0018(this));
				\u001E\u001D\u0016.\u0018(this, false);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x0004B504 File Offset: 0x00049704
		[BindableMethod("NextTab")]
		public void NextTab()
		{
			int num = \u0007\u001A\u0016.\u0018(this);
			\u0006\u001A\u0016.\u0018(this, num + 1);
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x0004B524 File Offset: 0x00049724
		[BindableMethod("PreviousTab")]
		public void PreviousTab()
		{
			int num = \u0007\u001A\u0016.\u0018(this);
			\u0006\u001A\u0016.\u0018(this, num - 1);
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x0004B544 File Offset: 0x00049744
		[BindableMethod("PreviewTab")]
		public void PreviewTab()
		{
			\u0006\u001A\u0016.\u0018(this, 3);
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x0004B558 File Offset: 0x00049758
		private void \u001D\u0013()
		{
			\u0008\u001A\u0016.\u0018(\u0001\u001A\u0016.\u0018());
		}

		// Token: 0x06000CDC RID: 3292 RVA: 0x0004B574 File Offset: 0x00049774
		private void \u001A\u0013()
		{
			List<ParameterInformation> list = \u0001\u001A\u0016.\u0018();
			IEnumerator u000C = \u000F\u000B\u0014.\u0018(\u0012\u000B\u0014.\u0018(\u000E\u0002\u0018.\u0018(this.\u0004\u0018)));
			try
			{
				while (\u001F\u001E\u0018.\u0018(u000C))
				{
					Parameter u000C2 = \u0003\u000B\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C));
					if (!\u000F\u000B\u0016.\u0018(u000C2))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.\u001A\u0013()).MethodHandle;
						}
						if (\u001B\u0002\u0018.\u0018(u000C2) != null)
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
							if (\u001B\u0002\u0018.\u0018(u000C2) != 4)
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
								ParameterInformation parameterInformation = \u0016\u000B\u0016.\u0018();
								\u0003\u000B\u0016.\u0014(parameterInformation, \u0003\u000B\u0014.\u0018(\u0018\u000B\u0014.\u0018(u000C2)));
								\u0014\u000B\u0016.\u0018(parameterInformation, \u0003\u000B\u0014.\u0018(\u0018\u000B\u0014.\u0018(u000C2)));
								\u0018\u000B\u0016.\u0014(parameterInformation, \u0005\u001A\u0014.\u0018(u000C2).\u000C());
								\u0012\u0004\u0016.\u0014(parameterInformation, \u001C\u001A\u0014.\u0018(u000C2));
								\u000C\u000B\u0016.\u0014(parameterInformation, \u001B\u0002\u0018.\u0018(u000C2));
								\u000E\u001A\u0016.\u0014(parameterInformation, ParameterType.ProjectParameter);
								ParameterInformation u = parameterInformation;
								\u0005\u001A\u0016.\u0018(list, u);
							}
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
				IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C);
				if (disposable != null)
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
					\u0020\u001E\u0018.\u0018(disposable);
				}
			}
			IEnumerable<ParameterInformation> enumerable = list;
			Func<ParameterInformation, string> func;
			if ((func = DocRegisterViewModel.<>c.\u000F) == null)
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
				func = (DocRegisterViewModel.<>c.\u000F = new Func<ParameterInformation, string>(DocRegisterViewModel.<>c.\u000C.\u0006));
			}
			list = Enumerable.ToList<ParameterInformation>(Enumerable.OrderBy<ParameterInformation, string>(enumerable, func));
			\u001B\u001A\u0016.\u0018(list);
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x0004B700 File Offset: 0x00049900
		private void \u000B\u0013()
		{
			List<RevisionInformation> list = \u0016\u0004\u0016.\u0018();
			IEnumerator<Revision> enumerator = \u000C\u001A\u0016.\u0018(Enumerable.Cast<Revision>(\u0010\u001D\u0014.\u0014(\u0020\u001D\u0018.\u0018(this.\u0004\u0018), \u000A\u001D\u0018.\u0018(\u000F\u0006\u000F.\u000C()))));
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator))
				{
					Revision u000C = \u000E\u001D\u0016.\u0018(enumerator);
					object u000C2 = list;
					RevisionInformation revisionInformation = \u0001\u0002\u0016.\u0018(u000C);
					\u0005\u001D\u0016.\u0018(revisionInformation, false);
					\u0008\u0002\u0016.\u0018(u000C2, revisionInformation);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.\u000B\u0013()).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u0020\u001E\u0018.\u0018(enumerator);
				}
			}
			\u0012\u000B\u0016.\u0018(list);
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x0004B7B0 File Offset: 0x000499B0
		public void ExportData()
		{
			\u000A\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\DocRegisterViewModel.cs", "ExportData");
			try
			{
				\u0003\u001E\u0014.\u0018(\u001C\u000B\u0016.\u0014(this), 3, \u001A\u000B\u0016.\u0018());
				Delegate @delegate = \u0012\u0017\u0014.\u0003(\u001C\u000B\u0016.\u0014(this));
				if (@delegate == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.ExportData()).MethodHandle;
					}
				}
				else
				{
					object[] array = \u0008\u001E\u000F.\u000C(1);
					array[0] = 1;
					\u000F\u0017\u0014.\u0018(@delegate, array);
				}
				\u0008\u0015\u0018.\u000F();
				List<ParameterInformation> u000C = Enumerable.ToList<ParameterInformation>(\u0004\u000B\u0016.\u0014(\u001D\u000B\u0016.\u0014(\u0009\u000B\u0016.\u0018(this))));
				List<RevisionData> u000C2 = Enumerable.ToList<RevisionData>(\u001E\u000B\u0016.\u0014(\u0002\u000B\u0016.\u0014(\u000A\u001A\u0016.\u0014(this))));
				IEnumerable<RevisionInformation> enumerable = \u001E\u001A\u0016.\u0014(\u000A\u001A\u0016.\u0014(this));
				Func<RevisionInformation, bool> func;
				if ((func = DocRegisterViewModel.<>c.\u0012) == null)
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
					func = (DocRegisterViewModel.<>c.\u0012 = new Func<RevisionInformation, bool>(DocRegisterViewModel.<>c.\u000C.\u0008));
				}
				List<RevisionInformation> u = Enumerable.ToList<RevisionInformation>(Enumerable.Where<RevisionInformation>(enumerable, func));
				List<SheetInformation> list = \u001D\u001A\u0016.\u0014(\u0011\u001A\u0016.\u0014(this));
				List<ParameterInformation> list2 = \u0017\u000B\u0016.\u0014(\u0011\u001A\u0016.\u0014(this));
				ColumnRowDetail u000C3 = \u0008\u0015\u0018.\u001C(u000C, 1, 5, \u0013\u000B\u0016.\u0018(\u0009\u000B\u0016.\u0018(this)));
				int num;
				if (!Enumerable.Any<ParameterInformation>(list2))
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
					num = 0;
				}
				else
				{
					num = \u0015\u000B\u0016.\u0018(list2);
				}
				int num2 = num;
				int u2 = \u0011\u000B\u0016.\u0014(\u000A\u001A\u0016.\u0014(this));
				int u3;
				if (num2 < 7)
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
					u3 = 7 - num2;
					num2 = 7;
				}
				else
				{
					u3 = 0;
				}
				Delegate delegate2 = \u0012\u0017\u0014.\u0003(\u001C\u000B\u0016.\u0014(this));
				if (delegate2 == null)
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
				}
				else
				{
					object[] array2 = \u0008\u001E\u000F.\u000C(1);
					array2[0] = 2;
					\u000F\u0017\u0014.\u0018(delegate2, array2);
				}
				int num3 = \u000A\u000B\u0016.\u0018(u000C3);
				if (num3 < 5)
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
					num3 = 5;
				}
				u000C3 = \u0008\u0015\u0018.\u0009(u000C2, num3 + 1, num2);
				Delegate delegate3 = \u0012\u0017\u0014.\u0003(\u001C\u000B\u0016.\u0014(this));
				if (delegate3 == null)
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
				}
				else
				{
					object[] array3 = \u0008\u001E\u000F.\u000C(1);
					array3[0] = 3;
					\u000F\u0017\u0014.\u0018(delegate3, array3);
				}
				if (Enumerable.Any<ParameterInformation>(list2))
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
					\u0008\u0015\u0018.\u0020(list2, \u000A\u000B\u0016.\u0018(u000C3) + 1, u3);
				}
				if (Enumerable.Any<SheetInformation>(list))
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
					string u000F = \u001F\u000B\u0016.\u0018(\u000A\u001A\u0016.\u0014(this));
					RevisionNumbering u4 = \u0020\u000B\u0016.\u0014(\u000A\u001A\u0016.\u0014(this));
					\u0008\u0015\u0018.\u000A(list, \u000A\u000B\u0016.\u0018(u000C3) + 1, u3);
					\u0008\u0015\u0018.\u000D(\u000A\u000B\u0016.\u0018(u000C3) + 2, num2 + 1, u2, list, u, u000F, u4);
				}
				\u0008\u0015\u0018.\u0013(\u0013\u000B\u0016.\u0018(\u0009\u000B\u0016.\u0018(this)));
			}
			catch (Exception u5)
			{
				\u0017\u001E\u0014.\u0018(\u0002\u0002\u0016.\u0018(), u5, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\DocRegisterViewModel.cs", "ExportData");
			}
			\u000D\u000B\u0016.\u0018(\u001C\u000B\u0016.\u0014(this));
			\u000D\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\DocRegisterViewModel.cs", "ExportData");
		}

		// Token: 0x06000CDF RID: 3295 RVA: 0x0004BAD8 File Offset: 0x00049CD8
		[BindableMethod("Publish")]
		public void PublishData()
		{
			try
			{
				SaveFileDialog u000C = \u000C\u0019\u0016.\u0018();
				\u000E\u000B\u0016.\u0018(u000C, "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*");
				\u0005\u000B\u0016.\u0018(u000C, 1);
				\u001B\u000B\u0016.\u0018(u000C, true);
				string u = \u000D\u001E\u0018.\u0018(\u0006\u0004\u0018.\u0018(this.\u0004\u0018), "_DocRegister.xlsx");
				\u0001\u000B\u0016.\u0018(u000C, u);
				SfSpreadsheet q = \u0008\u000B\u0016.\u0018().Q;
				this.\u0019\u0013(q);
				\u0006\u000B\u0016.\u0018(q, u);
				if (\u0011\u000B\u0018.\u0018(u000C) == DialogResult.OK)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.PublishData()).MethodHandle;
					}
					string text = \u0010\u000B\u0016.\u0018(u000C);
					\u0007\u000B\u0016.\u0018(q, text);
					ExcelOpen u000C2 = \u0019\u000B\u0016.\u0018(text);
					\u001B\u0007\u0018.\u0018(u000C2, \u0001\u000C\u0014.\u0018(this));
					\u001E\u0007\u0018.\u0014(u000C2);
				}
			}
			catch (Exception u2)
			{
				\u001B\u0003\u0014.\u0018(\u000B\u000B\u0016.\u0018(), \u0001\u000C\u0014.\u0018(this), 300.0);
				\u0017\u001E\u0014.\u0018(\u0002\u0002\u0016.\u0018(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\DocRegisterViewModel.cs", "PublishData");
			}
		}

		// Token: 0x06000CE0 RID: 3296 RVA: 0x0004BBDC File Offset: 0x00049DDC
		private void \u0019\u0013(SfSpreadsheet \u000C)
		{
			IWorksheet u000C = \u000C\u0020\u0016.\u0018(\u0018\u0020\u0016.\u0018(\u0003\u0019\u0016.\u0018(\u000C)), 0);
			if (\u0014\u0019\u0016.\u0018(u000C))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.\u0019\u0013(SfSpreadsheet)).MethodHandle;
				}
				\u0018\u0019\u0016.\u0018(u000C, "DiRoots_DR");
			}
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x0004BC2C File Offset: 0x00049E2C
		public DocRegisterProfileTemplate AddProfile()
		{
			return this.\u0007\u0013();
		}

		// Token: 0x06000CE2 RID: 3298 RVA: 0x0004BC44 File Offset: 0x00049E44
		public DocRegisterProfileTemplate SaveProfile()
		{
			return this.\u0007\u0013();
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x0004BC5C File Offset: 0x00049E5C
		private DocRegisterProfileTemplate \u0007\u0013()
		{
			DocRegisterProfileTemplate result;
			try
			{
				\u000A\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\DocRegisterViewModel.cs", "SetChangeToTemplate");
				DocRegisterProfileTemplate docRegisterProfileTemplate = \u000D\u0019\u0016.\u0018();
				HeaderProfile u = this.\u0001\u0013();
				RevisionProfile u2 = this.\u0008\u0013();
				SheetProfile u3 = this.\u0010\u0013();
				\u0012\u0019\u0016.\u0018(docRegisterProfileTemplate, u3);
				\u000F\u0019\u0016.\u0018(docRegisterProfileTemplate, u2);
				\u0016\u0019\u0016.\u0018(docRegisterProfileTemplate, u);
				\u000D\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\DocRegisterViewModel.cs", "SetChangeToTemplate");
				result = docRegisterProfileTemplate;
			}
			catch (Exception u4)
			{
				\u0017\u001E\u0014.\u0018(\u0002\u0002\u0016.\u0018(), u4, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\DocRegisterViewModel.cs", "SetChangeToTemplate");
				result = \u0016\u0006\u000F.\u000C;
			}
			return result;
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x0004BD00 File Offset: 0x00049F00
		private SheetProfile \u0010\u0013()
		{
			SheetProfile sheetProfile = \u001A\u0019\u0016.\u0018();
			\u001D\u0019\u0016.\u0018(sheetProfile, \u001F\u001A\u0016.\u0014(\u0011\u001A\u0016.\u0014(this)));
			\u0002\u0019\u0016.\u0018(sheetProfile, \u0004\u0019\u0016.\u0014(\u0011\u001A\u0016.\u0014(this)));
			\u0015\u0019\u0016.\u0018(sheetProfile, Enumerable.First<string>(\u0017\u0019\u0016.\u0018(\u001E\u0019\u0016.\u0014(\u0011\u001A\u0016.\u0014(this)))));
			\u0011\u0019\u0016.\u0018(sheetProfile, Enumerable.ToList<ParameterInformation>(\u0017\u000B\u0016.\u0014(\u0011\u001A\u0016.\u0014(this))));
			IEnumerable<SheetInformation> enumerable = \u001D\u001A\u0016.\u0014(\u0011\u001A\u0016.\u0014(this));
			Func<SheetInformation, string> func;
			if ((func = DocRegisterViewModel.<>c.\u000D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.\u0010\u0013()).MethodHandle;
				}
				func = (DocRegisterViewModel.<>c.\u000D = new Func<SheetInformation, string>(DocRegisterViewModel.<>c.\u000C.\u0001));
			}
			\u001F\u0019\u0016.\u0018(sheetProfile, Enumerable.ToList<string>(Enumerable.Select<SheetInformation, string>(enumerable, func)));
			\u0020\u0019\u0016.\u0018(sheetProfile, \u0009\u0019\u0016.\u0014(\u0011\u001A\u0016.\u0014(this)));
			ViewInfo u000C = \u000A\u0019\u0016.\u0018();
			this.\u0006\u0013(\u0009\u0019\u0016.\u0014(\u0011\u001A\u0016.\u0014(this)), ref u000C);
			\u001C\u0019\u0016.\u0018(sheetProfile, \u0013\u0019\u0016.\u0018(u000C));
			return sheetProfile;
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x0004BE14 File Offset: 0x0004A014
		private unsafe void \u0006\u0013(List<ViewInfo> \u000C, ref ViewInfo \u0018)
		{
			if (!Enumerable.Any<ViewInfo>(\u000C))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.\u0006\u0013(List<ViewInfo>, ViewInfo*)).MethodHandle;
				}
				return;
			}
			List<ViewInfo>.Enumerator enumerator = \u0008\u0019\u0016.\u0018(\u000C);
			try
			{
				while (\u000B\u0019\u0016.\u0018(ref enumerator))
				{
					ViewInfo viewInfo = \u0006\u0019\u0016.\u0018(ref enumerator);
					if (\u0010\u0019\u0016.\u0018(viewInfo))
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
						this.\u0006\u0013(\u0007\u0019\u0016.\u0014(viewInfo), ref \u0018);
					}
					else
					{
						bool? flag = \u0019\u0019\u0016.\u0018(viewInfo);
						if (\u000C\u0007\u0018.\u0018(ref flag))
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
							\u0018 = viewInfo;
						}
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
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x0004BED0 File Offset: 0x0004A0D0
		private RevisionProfile \u0008\u0013()
		{
			RevisionProfile revisionProfile = \u000F\u0007\u0016.\u0018();
			\u0016\u0007\u0016.\u0018(revisionProfile, Enumerable.ToList<RevisionData>(\u001E\u000B\u0016.\u0014(\u0002\u000B\u0016.\u0014(\u000A\u001A\u0016.\u0014(this)))));
			\u0003\u0007\u0016.\u0018(revisionProfile, \u0011\u000B\u0016.\u0014(\u000A\u001A\u0016.\u0014(this)));
			\u0018\u0007\u0016.\u0018(revisionProfile, \u0014\u0007\u0016.\u0018(\u000A\u001A\u0016.\u0014(this)));
			\u000E\u0019\u0016.\u0018(revisionProfile, \u000C\u0007\u0016.\u0014(\u000A\u001A\u0016.\u0014(this)));
			\u0005\u0019\u0016.\u0018(revisionProfile, \u001F\u000B\u0016.\u0018(\u000A\u001A\u0016.\u0014(this)));
			\u001B\u0019\u0016.\u0018(revisionProfile, \u0020\u000B\u0016.\u0014(\u000A\u001A\u0016.\u0014(this)));
			IEnumerable<RevisionInformation> enumerable = \u001E\u001A\u0016.\u0014(\u000A\u001A\u0016.\u0014(this));
			Func<RevisionInformation, bool> func;
			if ((func = DocRegisterViewModel.<>c.\u001C) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.\u0008\u0013()).MethodHandle;
				}
				func = (DocRegisterViewModel.<>c.\u001C = new Func<RevisionInformation, bool>(DocRegisterViewModel.<>c.\u000C.\u001B));
			}
			IEnumerable<RevisionInformation> enumerable2 = Enumerable.Where<RevisionInformation>(enumerable, func);
			Func<RevisionInformation, string> func2;
			if ((func2 = DocRegisterViewModel.<>c.\u0013) == null)
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
				func2 = (DocRegisterViewModel.<>c.\u0013 = new Func<RevisionInformation, string>(DocRegisterViewModel.<>c.\u000C.\u0005));
			}
			\u0001\u0019\u0016.\u0018(revisionProfile, Enumerable.ToList<string>(Enumerable.Select<RevisionInformation, string>(enumerable2, func2)));
			return revisionProfile;
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x0004BFF8 File Offset: 0x0004A1F8
		private HeaderProfile \u0001\u0013()
		{
			HeaderProfile headerProfile = \u001C\u0007\u0016.\u0018();
			\u000D\u0007\u0016.\u0018(headerProfile, \u0013\u000B\u0016.\u0018(\u0009\u000B\u0016.\u0018(this)));
			\u0012\u0007\u0016.\u0018(headerProfile, Enumerable.ToList<ParameterInformation>(\u0004\u000B\u0016.\u0014(\u001D\u000B\u0016.\u0014(\u0009\u000B\u0016.\u0018(this)))));
			return headerProfile;
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x0004C044 File Offset: 0x0004A244
		public void ProfileChanged(ProfileTemplate profileTemp)
		{
			DocRegisterProfileTemplate docRegisterProfileTemplate = \u0003\u0006\u000F.\u000C(profileTemp);
			if (docRegisterProfileTemplate == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.ProfileChanged(ProfileTemplate)).MethodHandle;
				}
				return;
			}
			this.\u0003\u0009(\u0013\u0007\u0016.\u0018(docRegisterProfileTemplate));
			this.\u000C\u0009(docRegisterProfileTemplate);
			this.\u001B\u0013(docRegisterProfileTemplate);
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x0004C090 File Offset: 0x0004A290
		private void \u001B\u0013(DocRegisterProfileTemplate \u000C)
		{
			DocRegisterViewModel.\u000E\u0011\u0018 u000E_u0011_u = new DocRegisterViewModel.\u000E\u0011\u0018();
			u000E_u0011_u.\u000C = \u000C;
			\u001C\u0010\u0016.\u0014(\u0011\u001A\u0016.\u0014(this), \u0013\u0010\u0016.\u0018(\u0002\u0007\u0016.\u0018(u000E_u0011_u.\u000C)));
			\u0012\u0010\u0016.\u0014(\u0011\u001A\u0016.\u0014(this), \u000D\u0010\u0016.\u0018(\u0002\u0007\u0016.\u0018(u000E_u0011_u.\u000C)));
			\u000F\u0010\u0016.\u0014(\u0011\u001A\u0016.\u0014(this));
			Dictionary<string, object>.Enumerator enumerator = \u0003\u0010\u0016.\u0018(\u0016\u0010\u0016.\u0014(\u0011\u001A\u0016.\u0014(this)));
			try
			{
				while (\u0001\u0007\u0016.\u0018(ref enumerator))
				{
					KeyValuePair<string, object> keyValuePair = \u0014\u0010\u0016.\u0018(ref enumerator);
					if (\u0014\u0006\u000F.\u000C(\u000E\u0007\u0016.\u0018(ref keyValuePair)) == \u0004\u0019\u0016.\u0014(\u0011\u001A\u0016.\u0014(this)))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.\u001B\u0013(DocRegisterProfileTemplate)).MethodHandle;
						}
						object u000C = \u0011\u001A\u0016.\u0014(this);
						Dictionary<string, object> dictionary = \u0018\u0010\u0016.\u0018();
						\u0005\u0007\u0016.\u0018(dictionary, \u000C\u0010\u0016.\u0018(ref keyValuePair), \u000E\u0007\u0016.\u0018(ref keyValuePair));
						\u001B\u0007\u0016.\u0014(u000C, dictionary);
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
			\u0008\u0007\u0016.\u0014(\u0011\u001A\u0016.\u0014(this));
			List<ParameterInformation> list = \u0001\u001A\u0016.\u0018();
			\u001A\u0007\u0016.\u0018(list, \u0006\u0007\u0016.\u0018());
			IEnumerable<ParameterInformation> enumerable = \u0010\u0007\u0016.\u0018();
			Func<ParameterInformation, bool> func;
			if ((func = DocRegisterViewModel.<>c.\u0009) == null)
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
				func = (DocRegisterViewModel.<>c.\u0009 = new Func<ParameterInformation, bool>(DocRegisterViewModel.<>c.\u000C.\u000E));
			}
			List<ParameterInformation> list2 = Enumerable.ToList<ParameterInformation>(Enumerable.Where<ParameterInformation>(enumerable, func));
			if (\u001F\u001A\u0016.\u0014(\u0011\u001A\u0016.\u0014(this)))
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
				IEnumerable<ParameterInformation> enumerable2 = \u0019\u0007\u0016.\u0018();
				Func<ParameterInformation, bool> func2;
				if ((func2 = DocRegisterViewModel.<>c.\u000A) == null)
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
					func2 = (DocRegisterViewModel.<>c.\u000A = new Func<ParameterInformation, bool>(DocRegisterViewModel.<>c.\u000C.\u000C\u0018));
				}
				\u0007\u0007\u0016.\u0018(Enumerable.ToList<ParameterInformation>(Enumerable.Where<ParameterInformation>(enumerable2, func2)));
				\u001A\u0007\u0016.\u0018(list2, \u0019\u0007\u0016.\u0018());
				IEnumerable<ParameterInformation> enumerable3 = list2;
				Func<ParameterInformation, long> func3;
				if ((func3 = DocRegisterViewModel.<>c.\u0020) == null)
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
					func3 = (DocRegisterViewModel.<>c.\u0020 = new Func<ParameterInformation, long>(DocRegisterViewModel.<>c.\u000C.\u0018\u0018));
				}
				IEnumerable<IGrouping<long, ParameterInformation>> enumerable4 = Enumerable.GroupBy<ParameterInformation, long>(enumerable3, func3);
				Func<IGrouping<long, ParameterInformation>, ParameterInformation> func4;
				if ((func4 = DocRegisterViewModel.<>c.\u001F) == null)
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
					func4 = (DocRegisterViewModel.<>c.\u001F = new Func<IGrouping<long, ParameterInformation>, ParameterInformation>(DocRegisterViewModel.<>c.\u000C.\u0014\u0018));
				}
				list2 = Enumerable.ToList<ParameterInformation>(Enumerable.Select<IGrouping<long, ParameterInformation>, ParameterInformation>(enumerable4, func4));
			}
			\u001A\u0007\u0016.\u0018(list, list2);
			\u001A\u0007\u0016.\u0018(list, \u000B\u0007\u0016.\u0018());
			IEnumerable<ParameterInformation> enumerable5 = list;
			Func<ParameterInformation, string> func5;
			if ((func5 = DocRegisterViewModel.<>c.\u0011) == null)
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
				func5 = (DocRegisterViewModel.<>c.\u0011 = new Func<ParameterInformation, string>(DocRegisterViewModel.<>c.\u000C.\u0003\u0018));
			}
			IOrderedEnumerable<ParameterInformation> orderedEnumerable = Enumerable.OrderBy<ParameterInformation, string>(enumerable5, func5);
			Func<ParameterInformation, ParameterType> func6;
			if ((func6 = DocRegisterViewModel.<>c.\u0015) == null)
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
				func6 = (DocRegisterViewModel.<>c.\u0015 = new Func<ParameterInformation, ParameterType>(DocRegisterViewModel.<>c.\u000C.\u0016\u0018));
			}
			list = Enumerable.ToList<ParameterInformation>(Enumerable.ThenBy<ParameterInformation, ParameterType>(orderedEnumerable, func6));
			List<ParameterInformation> list3 = Enumerable.ToList<ParameterInformation>(Enumerable.Where<ParameterInformation>(list, new Func<ParameterInformation, bool>(u000E_u0011_u.\u0018)));
			\u001D\u0007\u0016.\u0018(list3, new Action<ParameterInformation>(u000E_u0011_u.\u0014));
			\u0017\u0007\u0016.\u0018(this, \u0009\u0019\u0016.\u0014(\u0011\u001A\u0016.\u0014(this)), \u0004\u0007\u0016.\u0018(\u0002\u0007\u0016.\u0018(u000E_u0011_u.\u000C)));
			if (\u0004\u0019\u0016.\u0014(\u0011\u001A\u0016.\u0014(this)) == BrowserOption.SheetList)
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
				List<ViewInfo> u = \u0009\u0019\u0016.\u0014(\u0011\u001A\u0016.\u0014(this));
				List<string> list4 = \u0011\u0002\u0018.\u0018();
				\u0019\u0017\u0014.\u0018(list4, \u001E\u0007\u0016.\u0018(\u0002\u0007\u0016.\u0018(u000E_u0011_u.\u000C)));
				\u0017\u0007\u0016.\u0018(this, u, list4);
			}
			\u0011\u0007\u0016.\u0014(\u0011\u001A\u0016.\u0014(this), Enumerable.ToList<SheetInformation>(Enumerable.Where<SheetInformation>(\u0015\u0007\u0016.\u0014(\u0011\u001A\u0016.\u0014(this)), new Func<SheetInformation, bool>(u000E_u0011_u.\u0003))));
			List<ParameterInformation> u000C2 = this.\u0005\u0013(u000E_u0011_u.\u000C, list, list3);
			\u0020\u0007\u0016.\u0014(\u0011\u001A\u0016.\u0014(this), \u001F\u0007\u0016.\u0018(u000C2));
			\u000A\u0007\u0016.\u0014(\u0011\u001A\u0016.\u0014(this));
			\u0009\u0007\u0016.\u0014(\u0011\u001A\u0016.\u0014(this));
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x0004C48C File Offset: 0x0004A68C
		private List<ParameterInformation> \u0005\u0013(DocRegisterProfileTemplate \u000C, List<ParameterInformation> \u0018, List<ParameterInformation> \u0014)
		{
			List<ParameterInformation> list = \u0001\u001A\u0016.\u0018();
			List<ParameterInformation>.Enumerator enumerator = \u0020\u0004\u0016.\u0018(\u001F\u0010\u0016.\u0018(\u0002\u0007\u0016.\u0018(\u000C)));
			try
			{
				while (\u000F\u0004\u0016.\u0018(ref enumerator))
				{
					DocRegisterViewModel.\u0018\u0015\u0018 u0018_u0015_u = new DocRegisterViewModel.\u0018\u0015\u0018();
					u0018_u0015_u.\u000C = \u000A\u0004\u0016.\u0018(ref enumerator);
					ParameterInformation parameterInformation = \u0011\u0010\u0016.\u0018(\u0014, new Predicate<ParameterInformation>(u0018_u0015_u.\u0018));
					if (parameterInformation != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.\u0005\u0013(DocRegisterProfileTemplate, List<ParameterInformation>, List<ParameterInformation>)).MethodHandle;
						}
						\u0005\u001A\u0016.\u0018(list, parameterInformation);
					}
					if (\u0009\u0004\u0016.\u0014(u0018_u0015_u.\u000C) == ParameterType.CombinedParameter)
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
						int u = \u0020\u0010\u0016.\u0018(\u001F\u0010\u0016.\u0018(\u0002\u0007\u0016.\u0018(\u000C)), u0018_u0015_u.\u000C);
						List<ParameterModel> u000C = \u000F\u0009\u0016.\u0018();
						List<ParameterModel>.Enumerator enumerator2 = \u0019\u0019\u0014.\u0018(\u0013\u0004\u0016.\u0018(u0018_u0015_u.\u000C));
						try
						{
							while (\u0020\u0019\u0014.\u0018(ref enumerator2))
							{
								DocRegisterViewModel.\u0014\u0015\u0018 u0014_u0015_u = new DocRegisterViewModel.\u0014\u0015\u0018();
								u0014_u0015_u.\u000C = \u000B\u0019\u0014.\u0018(ref enumerator2);
								if (!\u000A\u0010\u0016.\u0018(\u0018, new Predicate<ParameterInformation>(u0014_u0015_u.\u0018)))
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
									\u0003\u0009\u0016.\u0018(u000C, u0014_u0015_u.\u000C);
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
							((IDisposable)enumerator2).Dispose();
						}
						\u0014\u0009\u0016.\u0018(u000C, new Action<ParameterModel>(u0018_u0015_u.\u0014));
						\u0009\u0010\u0016.\u0018(list, u, u0018_u0015_u.\u000C);
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
			return list;
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x0004C64C File Offset: 0x0004A84C
		private void \u000E\u0013(List<ViewInfo> \u000C, ViewInfo \u0018)
		{
			if (!Enumerable.Any<ViewInfo>(\u000C))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.\u000E\u0013(List<ViewInfo>, ViewInfo)).MethodHandle;
				}
				return;
			}
			List<ViewInfo>.Enumerator enumerator = \u0008\u0019\u0016.\u0018(\u000C);
			try
			{
				while (\u000B\u0019\u0016.\u0018(ref enumerator))
				{
					ViewInfo viewInfo = \u0006\u0019\u0016.\u0018(ref enumerator);
					if (\u0010\u0019\u0016.\u0018(viewInfo))
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
						this.\u000E\u0013(\u0007\u0019\u0016.\u0014(viewInfo), \u0018);
					}
					object u000C = viewInfo;
					bool value;
					if (\u001E\u0010\u0016.\u0018(viewInfo))
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
						value = (\u0017\u0010\u0016.\u0018(viewInfo) == \u0017\u0010\u0016.\u0018(\u0018));
					}
					else
					{
						value = false;
					}
					\u0015\u0010\u0016.\u0018(u000C, new bool?(value));
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
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x0004C718 File Offset: 0x0004A918
		public void SelectSheetChecked(List<ViewInfo> vInfo, List<string> selectedSheetUniqueId)
		{
			List<ViewInfo>.Enumerator enumerator = \u0008\u0019\u0016.\u0018(vInfo);
			try
			{
				while (\u000B\u0019\u0016.\u0018(ref enumerator))
				{
					ViewInfo u000C = \u0006\u0019\u0016.\u0018(ref enumerator);
					if (Enumerable.Any<ViewInfo>(\u0007\u0019\u0016.\u0014(u000C)))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.SelectSheetChecked(List<ViewInfo>, List<string>)).MethodHandle;
						}
						\u0017\u0007\u0016.\u0018(this, \u0007\u0019\u0016.\u0014(u000C), selectedSheetUniqueId);
					}
					else if (\u0007\u0017\u0014.\u0018(selectedSheetUniqueId, \u0013\u0019\u0016.\u0018(u000C)))
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
						\u0015\u0010\u0016.\u0018(u000C, new bool?(true));
					}
					else
					{
						\u0015\u0010\u0016.\u0018(u000C, new bool?(false));
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

		// Token: 0x06000CED RID: 3309 RVA: 0x0004C7E0 File Offset: 0x0004A9E0
		private void \u000C\u0009(DocRegisterProfileTemplate \u000C)
		{
			\u0020\u001A\u0016.\u0018(\u000A\u001A\u0016.\u0014(this), \u0015\u0006\u0016.\u0018(\u0019\u0010\u0016.\u0018(\u000C)));
			\u001F\u0006\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), \u0011\u0006\u0016.\u0018(\u0019\u0010\u0016.\u0018(\u000C)));
			\u0017\u001A\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), \u000B\u0010\u0016.\u0018(\u0019\u0010\u0016.\u0018(\u000C)));
			if (\u000C\u0007\u0016.\u0014(\u000A\u001A\u0016.\u0014(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.\u000C\u0009(DocRegisterProfileTemplate)).MethodHandle;
				}
				\u0009\u001A\u0016.\u0018(\u000A\u001A\u0016.\u0014(this));
			}
			List<RevisionData> list = Enumerable.ToList<RevisionData>(\u000A\u0006\u0016.\u0018(\u0019\u0010\u0016.\u0018(\u000C)));
			this.\u0018\u0009(\u001E\u001A\u0016.\u0014(\u000A\u001A\u0016.\u0014(this)), \u0020\u0006\u0016.\u0018(\u0019\u0010\u0016.\u0018(\u000C)));
			if (Enumerable.Any<RevisionData>(\u000A\u0006\u0016.\u0018(\u0019\u0010\u0016.\u0018(\u000C))))
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
				\u0013\u0006\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), \u0009\u0006\u0016.\u0018(\u0019\u0010\u0016.\u0018(\u000C)));
				\u001C\u0006\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), this.\u0014\u0009(RevisionDataProperty.Sequence, list));
				\u0007\u0010\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), \u000D\u0006\u0016.\u0014(\u000A\u001A\u0016.\u0014(this)), RevisionDataProperty.Sequence);
				if (\u0020\u000B\u0016.\u0014(\u000A\u001A\u0016.\u0014(this)) == null)
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
					\u0012\u0006\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), this.\u0014\u0009(RevisionDataProperty.RevisionNumber, list));
					\u0007\u0010\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), \u000F\u0006\u0016.\u0014(\u000A\u001A\u0016.\u0014(this)), RevisionDataProperty.RevisionNumber);
				}
				else
				{
					object u000C = list;
					object u000C2 = list;
					Predicate<RevisionData> u;
					if ((u = DocRegisterViewModel.<>c.\u001E) == null)
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
						u = (DocRegisterViewModel.<>c.\u001E = new Predicate<RevisionData>(DocRegisterViewModel.<>c.\u000C.\u0012\u0018));
					}
					\u0003\u0006\u0016.\u0018(u000C, \u0016\u0006\u0016.\u0018(u000C2, u));
				}
				\u0014\u0006\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), this.\u0014\u0009(RevisionDataProperty.Description, list));
				\u0007\u0010\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), \u0018\u0006\u0016.\u0014(\u000A\u001A\u0016.\u0014(this)), RevisionDataProperty.Description);
				\u000C\u0006\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), this.\u0014\u0009(RevisionDataProperty.IssuedBy, list));
				\u000E\u0010\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), this.\u0014\u0009(RevisionDataProperty.IssuedTo, list));
				\u0005\u0010\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), this.\u0014\u0009(RevisionDataProperty.Date, list));
				\u001B\u0010\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), this.\u0014\u0009(RevisionDataProperty.Issued, list));
				\u0007\u0010\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), \u0001\u0010\u0016.\u0014(\u000A\u001A\u0016.\u0014(this)), RevisionDataProperty.IssuedBy);
				\u0007\u0010\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), \u0008\u0010\u0016.\u0014(\u000A\u001A\u0016.\u0014(this)), RevisionDataProperty.IssuedTo);
				\u0007\u0010\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), \u0006\u0010\u0016.\u0014(\u000A\u001A\u0016.\u0014(this)), RevisionDataProperty.Date);
				\u0007\u0010\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), \u0010\u0010\u0016.\u0014(\u000A\u001A\u0016.\u0014(this)), RevisionDataProperty.Issued);
			}
			\u0017\u001A\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), \u000B\u0010\u0016.\u0018(\u0019\u0010\u0016.\u0018(\u000C)));
			object u000C3 = \u001E\u001A\u0016.\u0014(\u000A\u001A\u0016.\u0014(this));
			Predicate<RevisionInformation> u2;
			if ((u2 = DocRegisterViewModel.<>c.\u0002) == null)
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
				u2 = (DocRegisterViewModel.<>c.\u0002 = new Predicate<RevisionInformation>(DocRegisterViewModel.<>c.\u000C.\u000D\u0018));
			}
			if (!\u0002\u001A\u0016.\u0018(u000C3, u2))
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
				object u000C4 = list;
				Action<RevisionData> u3;
				if ((u3 = DocRegisterViewModel.<>c.\u001D) == null)
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
					u3 = (DocRegisterViewModel.<>c.\u001D = new Action<RevisionData>(DocRegisterViewModel.<>c.\u000C.\u001C\u0018));
				}
				\u001A\u0010\u0016.\u0018(u000C4, u3);
			}
			\u001D\u0010\u0016.\u0014(\u000A\u001A\u0016.\u0014(this), \u0004\u0010\u0016.\u0018(list));
			\u0002\u0010\u0016.\u0014(\u0002\u000B\u0016.\u0014(\u000A\u001A\u0016.\u0014(this)), \u0004\u0010\u0016.\u0018(list));
			\u0015\u001A\u0016.\u0014(\u000A\u001A\u0016.\u0014(this));
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x0004CB9C File Offset: 0x0004AD9C
		private void \u0018\u0009(List<RevisionInformation> \u000C, List<string> \u0018)
		{
			List<RevisionInformation>.Enumerator enumerator = \u001D\u0006\u0016.\u0018(\u000C);
			try
			{
				while (\u0017\u0006\u0016.\u0018(ref enumerator))
				{
					RevisionInformation u000C = \u0004\u0006\u0016.\u0018(ref enumerator);
					\u001E\u0006\u0016.\u0018(u000C, \u0007\u0017\u0014.\u0018(\u0018, \u0002\u0006\u0016.\u0018(u000C)));
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.\u0018\u0009(List<RevisionInformation>, List<string>)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06000CEF RID: 3311 RVA: 0x0004CC14 File Offset: 0x0004AE14
		private RevisionData \u0014\u0009(RevisionDataProperty \u000C, IEnumerable<RevisionData> \u0018)
		{
			DocRegisterViewModel.\u0003\u0015\u0018 u0003_u0015_u = new DocRegisterViewModel.\u0003\u0015\u0018();
			u0003_u0015_u.\u000C = \u000C;
			RevisionData result;
			if ((result = Enumerable.FirstOrDefault<RevisionData>(\u0018, new Func<RevisionData, bool>(u0003_u0015_u.\u0018))) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.\u0014\u0009(RevisionDataProperty, IEnumerable<RevisionData>)).MethodHandle;
				}
				RevisionData revisionData = \u0007\u0006\u0016.\u0018();
				\u0019\u0006\u0016.\u0018(revisionData, u0003_u0015_u.\u000C);
				result = revisionData;
				RevisionData revisionData2 = Enumerable.FirstOrDefault<RevisionData>(\u0018);
				List<long> u;
				if (revisionData2 == null)
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
					u = \u0001\u000B\u000F.\u000C;
				}
				else
				{
					u = \u000B\u0006\u0016.\u0018(revisionData2);
				}
				\u001A\u0006\u0016.\u0018(revisionData, u);
			}
			return result;
		}

		// Token: 0x06000CF0 RID: 3312 RVA: 0x0004CC98 File Offset: 0x0004AE98
		private void \u0003\u0009(HeaderProfile \u000C)
		{
			DocRegisterViewModel.\u0016\u0015\u0018 u0016_u0015_u = new DocRegisterViewModel.\u0016\u0015\u0018();
			u0016_u0015_u.\u000C = \u000C;
			\u0005\u0006\u0016.\u0014(\u0009\u000B\u0016.\u0018(this), \u000E\u0006\u0016.\u0018(u0016_u0015_u.\u000C));
			\u001D\u0007\u0016.\u0018(\u001B\u0006\u0016.\u0014(\u0009\u000B\u0016.\u0018(this)), new Action<ParameterInformation>(u0016_u0015_u.\u0018));
			\u0006\u0006\u0016.\u0014(\u001D\u000B\u0016.\u0014(\u0009\u000B\u0016.\u0018(this)), \u0008\u0006\u0016.\u0018(\u0001\u0006\u0016.\u0018(u0016_u0015_u.\u000C)));
			\u0010\u0006\u0016.\u0014(\u0009\u000B\u0016.\u0018(this));
		}

		// Token: 0x040005D4 RID: 1492
		private readonly Document \u0004\u0018;

		// Token: 0x040005D5 RID: 1493
		private bool \u001E\u0003;

		// Token: 0x040005D6 RID: 1494
		private bool \u0002\u0003;

		// Token: 0x040005D7 RID: 1495
		private bool \u0004\u0003;

		// Token: 0x040005D8 RID: 1496
		private bool \u001D\u0003;

		// Token: 0x040005D9 RID: 1497
		private int \u001A\u0003;

		// Token: 0x040005DA RID: 1498
		private RevisionViewModel \u000B\u0003;

		// Token: 0x040005DB RID: 1499
		[CompilerGenerated]
		private bool \u0019\u0003;

		// Token: 0x040005DC RID: 1500
		[CompilerGenerated]
		private HeaderViewModel \u0007\u0003;

		// Token: 0x040005DD RID: 1501
		[CompilerGenerated]
		private SheetsViewModel \u0010\u0003;

		// Token: 0x040005DE RID: 1502
		[CompilerGenerated]
		private PreviewViewModel \u0006\u0003;

		// Token: 0x040005DF RID: 1503
		[CompilerGenerated]
		private ProgressModel \u0008\u0003;

		// Token: 0x020001F6 RID: 502
		[CompilerGenerated]
		private sealed class \u0005\u0011\u0018
		{
			// Token: 0x0600127B RID: 4731 RVA: 0x00060310 File Offset: 0x0005E510
			internal void \u0018(RevisionInformation \u000C)
			{
				\u001E\u0006\u0016.\u0018(\u000C, \u0007\u0017\u0014.\u0018(this.\u000C, \u0002\u0006\u0016.\u0018(\u000C)));
			}

			// Token: 0x04000906 RID: 2310
			public List<string> \u000C;
		}

		// Token: 0x020001F7 RID: 503
		[CompilerGenerated]
		private sealed class \u000E\u0011\u0018
		{
			// Token: 0x0600127D RID: 4733 RVA: 0x0006034C File Offset: 0x0005E54C
			internal bool \u0018(ParameterInformation \u000C)
			{
				IEnumerable<ParameterInformation> enumerable = \u001F\u0010\u0016.\u0018(\u0002\u0007\u0016.\u0018(this.\u000C));
				Func<ParameterInformation, long> func;
				if ((func = DocRegisterViewModel.<>c.\u0017) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.\u000E\u0011\u0018.\u0018(ParameterInformation)).MethodHandle;
					}
					func = (DocRegisterViewModel.<>c.\u0017 = new Func<ParameterInformation, long>(DocRegisterViewModel.<>c.\u000C.\u000F\u0018));
				}
				return Enumerable.Contains<long>(Enumerable.Select<ParameterInformation, long>(enumerable, func), \u000D\u0004\u0016.\u0018(\u000C));
			}

			// Token: 0x0600127E RID: 4734 RVA: 0x000603B8 File Offset: 0x0005E5B8
			internal void \u0014(ParameterInformation \u000C)
			{
				DocRegisterViewModel.\u000C\u0015\u0018 u000C_u0015_u = new DocRegisterViewModel.\u000C\u0015\u0018();
				u000C_u0015_u.\u000C = \u000C;
				\u0014\u000B\u0016.\u0018(u000C_u0015_u.\u000C, \u001F\u0001\u0016.\u0018(\u0011\u0010\u0016.\u0018(\u001F\u0010\u0016.\u0018(\u0002\u0007\u0016.\u0018(this.\u000C)), new Predicate<ParameterInformation>(u000C_u0015_u.\u0018))));
				\u0015\u0001\u0016.\u0018(u000C_u0015_u.\u000C, \u0011\u0014\u000F.\u0018(\u0011\u0010\u0016.\u0018(\u001F\u0010\u0016.\u0018(\u0002\u0007\u0016.\u0018(this.\u000C)), new Predicate<ParameterInformation>(u000C_u0015_u.\u0014))));
			}

			// Token: 0x0600127F RID: 4735 RVA: 0x00060444 File Offset: 0x0005E644
			internal bool \u0003(SheetInformation \u000C)
			{
				return \u0007\u0017\u0014.\u0018(\u0004\u0007\u0016.\u0018(\u0002\u0007\u0016.\u0018(this.\u000C)), \u0008\u0017\u000F.\u0018(\u000C));
			}

			// Token: 0x04000907 RID: 2311
			public DocRegisterProfileTemplate \u000C;
		}

		// Token: 0x020001F8 RID: 504
		[CompilerGenerated]
		private sealed class \u000C\u0015\u0018
		{
			// Token: 0x06001281 RID: 4737 RVA: 0x00060488 File Offset: 0x0005E688
			internal bool \u0018(ParameterInformation \u000C)
			{
				return \u000D\u0004\u0016.\u0018(\u000C) == \u000D\u0004\u0016.\u0018(this.\u000C);
			}

			// Token: 0x06001282 RID: 4738 RVA: 0x000604AC File Offset: 0x0005E6AC
			internal bool \u0014(ParameterInformation \u000C)
			{
				return \u000D\u0004\u0016.\u0018(\u000C) == \u000D\u0004\u0016.\u0018(this.\u000C);
			}

			// Token: 0x04000908 RID: 2312
			public ParameterInformation \u000C;
		}

		// Token: 0x020001F9 RID: 505
		[CompilerGenerated]
		private sealed class \u0018\u0015\u0018
		{
			// Token: 0x06001284 RID: 4740 RVA: 0x000604E4 File Offset: 0x0005E6E4
			internal bool \u0018(ParameterInformation \u000C)
			{
				return \u000D\u0004\u0016.\u0018(\u000C) == \u000D\u0004\u0016.\u0018(this.\u000C);
			}

			// Token: 0x06001285 RID: 4741 RVA: 0x00060508 File Offset: 0x0005E708
			internal void \u0014(ParameterModel \u000C)
			{
				\u0009\u0011\u000F.\u0018(\u0013\u0004\u0016.\u0018(this.\u000C), \u000C);
			}

			// Token: 0x04000909 RID: 2313
			public ParameterInformation \u000C;
		}

		// Token: 0x020001FA RID: 506
		[CompilerGenerated]
		private sealed class \u0014\u0015\u0018
		{
			// Token: 0x06001287 RID: 4743 RVA: 0x00060540 File Offset: 0x0005E740
			internal bool \u0018(ParameterInformation \u000C)
			{
				return \u000D\u0004\u0016.\u0018(\u000C) == \u0010\u0019\u0014.\u0018(this.\u000C);
			}

			// Token: 0x0400090A RID: 2314
			public ParameterModel \u000C;
		}

		// Token: 0x020001FB RID: 507
		[CompilerGenerated]
		private sealed class \u0003\u0015\u0018
		{
			// Token: 0x06001289 RID: 4745 RVA: 0x00060578 File Offset: 0x0005E778
			internal bool \u0018(RevisionData \u000C)
			{
				return \u0010\u0005\u0016.\u0018(\u000C) == this.\u000C;
			}

			// Token: 0x0400090B RID: 2315
			public RevisionDataProperty \u000C;
		}

		// Token: 0x020001FC RID: 508
		[CompilerGenerated]
		private sealed class \u0016\u0015\u0018
		{
			// Token: 0x0600128B RID: 4747 RVA: 0x000605AC File Offset: 0x0005E7AC
			internal void \u0018(ParameterInformation \u000C)
			{
				\u0018\u0001\u0016.\u0018(\u000C, false);
				IEnumerable<ParameterInformation> enumerable = \u0001\u0006\u0016.\u0018(this.\u000C);
				Func<ParameterInformation, long> func;
				if ((func = DocRegisterViewModel.<>c.\u001A) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterViewModel.\u0016\u0015\u0018.\u0018(ParameterInformation)).MethodHandle;
					}
					func = (DocRegisterViewModel.<>c.\u001A = new Func<ParameterInformation, long>(DocRegisterViewModel.<>c.\u000C.\u0009\u0018));
				}
				if (Enumerable.Contains<long>(Enumerable.Select<ParameterInformation, long>(enumerable, func), \u000D\u0004\u0016.\u0018(\u000C)))
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
					\u0018\u0001\u0016.\u0018(\u000C, true);
				}
			}

			// Token: 0x0400090C RID: 2316
			public HeaderProfile \u000C;
		}
	}
}
