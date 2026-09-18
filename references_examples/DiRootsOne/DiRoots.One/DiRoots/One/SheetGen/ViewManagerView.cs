using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using DiRoots.One.SheetGen.Messaging;
using DiRoots.One.SheetGen.Services;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002C6 RID: 710
	public class ViewManagerView : ModelBase
	{
		// Token: 0x06001CC5 RID: 7365 RVA: 0x000B6ABC File Offset: 0x000B4CBC
		public ViewManagerView(View view)
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Models\\ViewsAggregate\\ViewManagerView.cs", ".ctor");
			\u000D\u001B\u0016.\u000A(this, new List<ParameterModel>());
			\u0001\u0016\u0016.\u001D(this, UpdateStates.ToAdd);
			\u0009\u000B\u0016.\u001D(this, view);
			\u001F\u0002\u0016.\u001D(this, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(view)));
			string u000A;
			\u0015\u0002\u0016.\u001D(this, u000A = SheetAndViewCreationHelper.\u001D(view));
			\u0001\u0002\u0016.\u001D(this, u000A);
			\u001C\u001B\u0016.\u000A(this, \u001C\u001C\u0007.\u0007(view));
			\u0003\u001B\u0016.\u0007(this, view.\u001F());
			\u0012\u001B\u0016.\u0007(this, true);
			\u000F\u001B\u0016.\u000A(this, \u000C\u0009\u001D.\u000A(view));
			this.FT(view);
			\u0006\u001B\u0016.\u000A(this);
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Models\\ViewsAggregate\\ViewManagerView.cs", ".ctor");
		}

		// Token: 0x06001CC6 RID: 7366 RVA: 0x000B6B80 File Offset: 0x000B4D80
		public ViewManagerView(ViewManagerView other)
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Models\\ViewsAggregate\\ViewManagerView.cs", ".ctor");
			\u000D\u001B\u0016.\u000A(this, new List<ParameterModel>());
			\u0001\u0016\u0016.\u001D(this, UpdateStates.ToAdd);
			\u001F\u0002\u0016.\u001D(this, \u0017\u0016\u0016.\u000A(other));
			\u0009\u000B\u0016.\u001D(this, \u001F\u000B\u0016.\u0007(other));
			\u0015\u0002\u0016.\u001D(this, \u0007\u000B\u0016.\u000A(other));
			\u001C\u001B\u0016.\u000A(this, \u0014\u0016\u0016.\u0007(other));
			\u0003\u001B\u0016.\u0007(this, \u0014\u000F\u0016.\u000A(other));
			\u0012\u001B\u0016.\u0007(this, true);
			\u000F\u001B\u0016.\u000A(this, \u0012\u000B\u0016.\u0007(other));
			this.FT(\u001F\u000B\u0016.\u0007(other));
			\u0006\u001B\u0016.\u000A(this);
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Models\\ViewsAggregate\\ViewManagerView.cs", ".ctor");
		}

		// Token: 0x1700080C RID: 2060
		// (get) Token: 0x06001CC7 RID: 7367 RVA: 0x000B6C40 File Offset: 0x000B4E40
		// (set) Token: 0x06001CC8 RID: 7368 RVA: 0x000B6C54 File Offset: 0x000B4E54
		internal static Action OnStatusChanged { get; set; }

		// Token: 0x1700080D RID: 2061
		// (get) Token: 0x06001CC9 RID: 7369 RVA: 0x000B6C68 File Offset: 0x000B4E68
		// (set) Token: 0x06001CCA RID: 7370 RVA: 0x000B6C7C File Offset: 0x000B4E7C
		internal static List<ViewManagerView> SelectedViews { get; set; }

		// Token: 0x06001CCB RID: 7371 RVA: 0x000B6C90 File Offset: 0x000B4E90
		private void FT(View F)
		{
			try
			{
				if (\u0012\u000B\u0016.\u001D(this))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManagerView.FT(View)).MethodHandle;
					}
					if (\u0001\u001D\u000E.\u001F(F) == null)
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
						\u0010\u001B\u0016.\u000A(this, \u000E\u001B\u0016.\u000A(F));
					}
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Models\\ViewsAggregate\\ViewManagerView.cs", "SetViewDiscipline");
			}
		}

		// Token: 0x1700080E RID: 2062
		// (get) Token: 0x06001CCC RID: 7372 RVA: 0x000B6D08 File Offset: 0x000B4F08
		// (set) Token: 0x06001CCD RID: 7373 RVA: 0x000B6D1C File Offset: 0x000B4F1C
		public long ViewId { get; set; }

		// Token: 0x1700080F RID: 2063
		// (get) Token: 0x06001CCE RID: 7374 RVA: 0x000B6D30 File Offset: 0x000B4F30
		// (set) Token: 0x06001CCF RID: 7375 RVA: 0x000B6D44 File Offset: 0x000B4F44
		public bool ViewTempHasAssociateView { get; set; }

		// Token: 0x17000810 RID: 2064
		// (get) Token: 0x06001CD0 RID: 7376 RVA: 0x000B6D58 File Offset: 0x000B4F58
		// (set) Token: 0x06001CD1 RID: 7377 RVA: 0x000B6D6C File Offset: 0x000B4F6C
		public ViewType Type { get; set; }

		// Token: 0x17000811 RID: 2065
		// (get) Token: 0x06001CD2 RID: 7378 RVA: 0x000B6D80 File Offset: 0x000B4F80
		// (set) Token: 0x06001CD3 RID: 7379 RVA: 0x000B6D94 File Offset: 0x000B4F94
		public ViewDiscipline ViewDiscipline { get; set; }

		// Token: 0x17000812 RID: 2066
		// (get) Token: 0x06001CD4 RID: 7380 RVA: 0x000B6DA8 File Offset: 0x000B4FA8
		public bool IsPanelSchedule
		{
			get
			{
				return \u0014\u0016\u0016.\u001D(this) == 123;
			}
		}

		// Token: 0x17000813 RID: 2067
		// (get) Token: 0x06001CD5 RID: 7381 RVA: 0x000B6DC4 File Offset: 0x000B4FC4
		// (set) Token: 0x06001CD6 RID: 7382 RVA: 0x000B6DD8 File Offset: 0x000B4FD8
		public int NumberOfViewAssoicateWithTemplate { get; set; }

		// Token: 0x17000814 RID: 2068
		// (get) Token: 0x06001CD7 RID: 7383 RVA: 0x000B6DEC File Offset: 0x000B4FEC
		public bool CanBeDuplicatedWithDetailing
		{
			get
			{
				return \u0007\u0014\u0005.\u000A(\u001F\u000B\u0016.\u001D(this), 2);
			}
		}

		// Token: 0x17000815 RID: 2069
		// (get) Token: 0x06001CD8 RID: 7384 RVA: 0x000B6E0C File Offset: 0x000B500C
		public bool CanBeDuplicatedAsDependent
		{
			get
			{
				return \u0007\u0014\u0005.\u000A(\u001F\u000B\u0016.\u001D(this), 1);
			}
		}

		// Token: 0x17000816 RID: 2070
		// (get) Token: 0x06001CD9 RID: 7385 RVA: 0x000B6E2C File Offset: 0x000B502C
		public bool CanBeDuplicated
		{
			get
			{
				return \u0007\u0014\u0005.\u000A(\u001F\u000B\u0016.\u001D(this), 0);
			}
		}

		// Token: 0x17000817 RID: 2071
		// (get) Token: 0x06001CDA RID: 7386 RVA: 0x000B6E4C File Offset: 0x000B504C
		// (set) Token: 0x06001CDB RID: 7387 RVA: 0x000B6E60 File Offset: 0x000B5060
		public List<ParameterModel> Parameters { get; set; }

		// Token: 0x17000818 RID: 2072
		// (get) Token: 0x06001CDC RID: 7388 RVA: 0x000B6E74 File Offset: 0x000B5074
		// (set) Token: 0x06001CDD RID: 7389 RVA: 0x000B6E88 File Offset: 0x000B5088
		public string ViewName
		{
			get
			{
				return this.JR;
			}
			set
			{
				this.JR = value;
				\u0007\u0013\u000A.\u000A(this, "ViewName");
			}
		}

		// Token: 0x17000819 RID: 2073
		// (get) Token: 0x06001CDE RID: 7390 RVA: 0x000B6EA8 File Offset: 0x000B50A8
		public string OriginalName
		{
			get
			{
				if (this.BB == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManagerView.get_OriginalName()).MethodHandle;
					}
					this.BB = this.JR;
				}
				return this.BB;
			}
		}

		// Token: 0x1700081A RID: 2074
		// (get) Token: 0x06001CDF RID: 7391 RVA: 0x000B6EE4 File Offset: 0x000B50E4
		public string ViewTypeString
		{
			get
			{
				return \u0014\u0016\u0016.\u001D(this).\u001F();
			}
		}

		// Token: 0x1700081B RID: 2075
		// (get) Token: 0x06001CE0 RID: 7392 RVA: 0x000B6F00 File Offset: 0x000B5100
		public bool IsViewTemplateEnabled
		{
			get
			{
				if (\u0014\u0016\u0016.\u001D(this) != 5)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManagerView.get_IsViewTemplateEnabled()).MethodHandle;
					}
					return \u0014\u0016\u0016.\u001D(this) != 123;
				}
				return false;
			}
		}

		// Token: 0x1700081C RID: 2076
		// (get) Token: 0x06001CE1 RID: 7393 RVA: 0x000B6F3C File Offset: 0x000B513C
		// (set) Token: 0x06001CE2 RID: 7394 RVA: 0x000B6F50 File Offset: 0x000B5150
		public bool IsScopeBoxEnabled
		{
			get
			{
				return this.LB;
			}
			set
			{
				this.LB = value;
				\u0007\u0013\u000A.\u000A(this, "IsScopeBoxEnabled");
			}
		}

		// Token: 0x1700081D RID: 2077
		// (get) Token: 0x06001CE3 RID: 7395 RVA: 0x000B6F70 File Offset: 0x000B5170
		// (set) Token: 0x06001CE4 RID: 7396 RVA: 0x000B6F84 File Offset: 0x000B5184
		public bool IsChecked
		{
			get
			{
				return this.WR;
			}
			set
			{
				this.WR = value;
				\u0007\u0013\u000A.\u000A(this, "IsChecked");
			}
		}

		// Token: 0x1700081E RID: 2078
		// (get) Token: 0x06001CE5 RID: 7397 RVA: 0x000B6FA4 File Offset: 0x000B51A4
		// (set) Token: 0x06001CE6 RID: 7398 RVA: 0x000B6FB8 File Offset: 0x000B51B8
		public UpdateStates UpdateState
		{
			get
			{
				return this.BL;
			}
			set
			{
				\u001B\u001B\u0016.\u0007(this, \u000A\u000B\u0016.\u001D(this));
				this.BL = value;
				Action action = \u0008\u001B\u0016.\u000A();
				if (action == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManagerView.set_UpdateState(UpdateStates)).MethodHandle;
					}
				}
				else
				{
					\u001B\u0015\u0007.\u000A(action);
				}
				\u0007\u0013\u000A.\u000A(this, "UpdateState");
			}
		}

		// Token: 0x1700081F RID: 2079
		// (get) Token: 0x06001CE7 RID: 7399 RVA: 0x000B700C File Offset: 0x000B520C
		// (set) Token: 0x06001CE8 RID: 7400 RVA: 0x000B7020 File Offset: 0x000B5220
		public UpdateStates PreviousStatus { get; set; }

		// Token: 0x17000820 RID: 2080
		// (get) Token: 0x06001CE9 RID: 7401 RVA: 0x000B7034 File Offset: 0x000B5234
		// (set) Token: 0x06001CEA RID: 7402 RVA: 0x000B7048 File Offset: 0x000B5248
		public View ViewElement { get; set; }

		// Token: 0x17000821 RID: 2081
		// (get) Token: 0x06001CEB RID: 7403 RVA: 0x000B705C File Offset: 0x000B525C
		// (set) Token: 0x06001CEC RID: 7404 RVA: 0x000B7070 File Offset: 0x000B5270
		public ViewDuplicateOption DuplicateOption
		{
			get
			{
				return this.SB;
			}
			set
			{
				this.SB = value;
				\u0007\u0013\u000A.\u000A(this, "DuplicateOption");
			}
		}

		// Token: 0x17000822 RID: 2082
		// (get) Token: 0x06001CED RID: 7405 RVA: 0x000B7090 File Offset: 0x000B5290
		// (set) Token: 0x06001CEE RID: 7406 RVA: 0x000B70A4 File Offset: 0x000B52A4
		public bool PassedFilter { get; internal set; }

		// Token: 0x17000823 RID: 2083
		// (get) Token: 0x06001CEF RID: 7407 RVA: 0x000B70B8 File Offset: 0x000B52B8
		// (set) Token: 0x06001CF0 RID: 7408 RVA: 0x000B70CC File Offset: 0x000B52CC
		public string CommittedName { get; internal set; }

		// Token: 0x17000824 RID: 2084
		// (get) Token: 0x06001CF1 RID: 7409 RVA: 0x000B70E0 File Offset: 0x000B52E0
		// (set) Token: 0x06001CF2 RID: 7410 RVA: 0x000B70F4 File Offset: 0x000B52F4
		public bool IsNameModifiedFromService { get; internal set; }

		// Token: 0x17000825 RID: 2085
		// (get) Token: 0x06001CF3 RID: 7411 RVA: 0x000B7108 File Offset: 0x000B5308
		// (set) Token: 0x06001CF4 RID: 7412 RVA: 0x000B711C File Offset: 0x000B531C
		public bool IsViewTemplate { get; set; }

		// Token: 0x06001CF5 RID: 7413 RVA: 0x000B7130 File Offset: 0x000B5330
		public void PopulateParameters()
		{
			if (\u0020\u001B\u0016.\u0007(ParametersManagerService.\u0008) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManagerView.PopulateParameters()).MethodHandle;
				}
				return;
			}
			View view = \u001F\u000B\u0016.\u001D(this);
			List<Parameter> list;
			if (view == null)
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
				list = \u0012\u0007\u000E.\u001F;
			}
			else
			{
				list = \u0003\u0007\u001D.\u000A(view, false);
			}
			List<Parameter> u000A = list;
			List<SelectionParameter>.Enumerator enumerator = \u0001\u000D\u0016.\u000A(\u0020\u001B\u0016.\u0007(ParametersManagerService.\u0008));
			try
			{
				while (\u0014\u000D\u0016.\u000A(ref enumerator))
				{
					SelectionParameter selectionParameter = \u0015\u000D\u0016.\u000A(ref enumerator);
					if (this.\u001F(selectionParameter, \u000A\u0003\u0016.\u001D(selectionParameter) == SelectionParameterType.ProjectInformation) == null)
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
						ParameterModel parameterModel;
						if (\u000A\u0003\u0016.\u001D(selectionParameter) == SelectionParameterType.ProjectInformation)
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
							parameterModel = \u001A\u000D\u0016.\u000A(selectionParameter);
							\u0011\u001B\u0016.\u000A(parameterModel, parameterModel.\u000A(u000A), selectionParameter, this);
						}
						else
						{
							parameterModel = \u000C\u000D\u0016.\u000A(selectionParameter);
						}
						\u001E\u001B\u0016.\u0007(this, parameterModel);
						if (\u000A\u0003\u0016.\u001D(\u0004\u0005\u0016.\u0007(parameterModel)) == SelectionParameterType.Sheet)
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
							if (\u001F\u000B\u0016.\u001D(this) != null)
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
								Parameter u000A2 = parameterModel.\u000A(u000A);
								\u0011\u001B\u0016.\u000A(parameterModel, u000A2, selectionParameter, this);
							}
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

		// Token: 0x06001CF6 RID: 7414 RVA: 0x000B7290 File Offset: 0x000B5490
		private void RT(ParameterModel F)
		{
			List<ViewManagerView> u001F;
			if ((u001F = \u0017\u001B\u0016.\u000A()) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManagerView.RT(ParameterModel)).MethodHandle;
				}
				u001F = \u0005\u000B\u0016.\u000A();
			}
			List<ViewManagerView>.Enumerator enumerator = \u001A\u0016\u0016.\u000A(u001F);
			try
			{
				while (\u0020\u0016\u0016.\u000A(ref enumerator))
				{
					ViewManagerView viewManagerView = \u0013\u0016\u0016.\u000A(ref enumerator);
					ParameterModel parameterModel = viewManagerView.\u001F(\u0004\u0005\u0016.\u0007(F), false);
					if (\u0009\u0006\u0016.\u001D(F) == ParameterDataType.ViewTemplate)
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
						if (\u001F\u0006\u0016.\u000A(viewManagerView))
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
							\u0010\u0010\u0016.\u000A(parameterModel, \u0009\u0018\u0016.\u0007(F));
						}
					}
					else if (\u0009\u0006\u0016.\u001D(F) == ParameterDataType.ScopeBox)
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
						if (\u0014\u000F\u0016.\u000A(viewManagerView))
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
							\u0010\u0010\u0016.\u000A(parameterModel, \u0009\u0018\u0016.\u0007(F));
						}
					}
					else if (\u000E\u0010\u0016.\u000A(parameterModel))
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
						\u0010\u0010\u0016.\u000A(parameterModel, \u0009\u0018\u0016.\u0007(F));
					}
					viewManagerView.DT(parameterModel);
					if (\u000A\u000B\u0016.\u001D(this) == UpdateStates.Updated)
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
						\u0001\u0016\u0016.\u001D(this, UpdateStates.Modified);
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
			\u0005\u001B\u000A.\u0018.\u0019<object>(\u001C\u0016\u0016.\u000A(), Context.RefreshViews);
		}

		// Token: 0x06001CF7 RID: 7415 RVA: 0x000B73F4 File Offset: 0x000B55F4
		internal void DT(ParameterModel F)
		{
			if (\u0008\u000F\u0016.\u0007(\u0004\u0005\u0016.\u0007(F)) == -1008203L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManagerView.DT(ParameterModel)).MethodHandle;
				}
				this.HT(F, -1005123L, 1L);
			}
			if (\u0008\u000F\u0016.\u0007(\u0004\u0005\u0016.\u0007(F)) == -1005153L)
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
				this.HT(F, -1005335L, -1L);
				this.HT(F, -1005177L, -1L);
			}
		}

		// Token: 0x06001CF8 RID: 7416 RVA: 0x000B747C File Offset: 0x000B567C
		private void HT(ParameterModel F, BuiltInParameter R, long D)
		{
			ViewManagerView.\u0001\u001B u0001_u001B = new ViewManagerView.\u0001\u001B();
			u0001_u001B.\u001F = R;
			ParameterModel parameterModel = Enumerable.FirstOrDefault<ParameterModel>(\u001A\u0002\u0016.\u001D(this), new Func<ParameterModel, bool>(u0001_u001B.\u000A));
			if (parameterModel == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManagerView.HT(ParameterModel, BuiltInParameter, long)).MethodHandle;
				}
				return;
			}
			long num = 0L;
			ParameterIntegerValue parameterIntegerValue = \u0012\u0003\u000E.\u001F(\u0009\u0018\u0016.\u0007(F));
			if (parameterIntegerValue != null)
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
				num = (long)\u001B\u000B\u0016.\u000A(parameterIntegerValue);
			}
			else
			{
				ParameterIdValue parameterIdValue = \u0003\u0003\u000E.\u001F(\u0009\u0018\u0016.\u0007(F));
				if (parameterIdValue != null)
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
					num = \u001D\u0006\u0016.\u0007(parameterIdValue);
				}
			}
			if (num == D)
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
				\u000C\u0006\u0016.\u001D(parameterModel, false);
				return;
			}
			\u000C\u0006\u0016.\u001D(parameterModel, true);
		}

		// Token: 0x06001CF9 RID: 7417 RVA: 0x000B753C File Offset: 0x000B573C
		private void YT()
		{
			if (\u000A\u000B\u0016.\u001D(this) == UpdateStates.Updated)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManagerView.YT()).MethodHandle;
				}
				\u0001\u0016\u0016.\u001D(this, UpdateStates.Modified);
			}
		}

		// Token: 0x06001CFA RID: 7418 RVA: 0x000B7570 File Offset: 0x000B5770
		public void AddParameter(ParameterModel pinfo)
		{
			if (\u000A\u0003\u0016.\u001D(\u0004\u0005\u0016.\u0007(pinfo)) != SelectionParameterType.ProjectInformation)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManagerView.AddParameter(ParameterModel)).MethodHandle;
				}
				\u0009\u0012\u0016.\u000A(pinfo, \u0015\u0003\u000E.\u001F(\u000F\u001E\u000A.\u000A(\u000A\u000F\u0016.\u001D(pinfo), new Action<ParameterModel>(this.RT))));
				\u0004\u0003\u0016.\u000A(pinfo, \u0005\u0007\u000E.\u001F(\u000F\u001E\u000A.\u000A(\u0013\u000F\u0016.\u001D(pinfo), new Action(this.YT))));
			}
			\u0014\u001B\u0016.\u000A(\u001A\u0002\u0016.\u001D(this), pinfo);
		}

		// Token: 0x06001CFB RID: 7419 RVA: 0x000B7600 File Offset: 0x000B5800
		public void UpdateParameters(List<SelectionParameter> parameters)
		{
			ViewManagerView.\u000C\u001B u000C_u001B = new ViewManagerView.\u000C\u001B();
			u000C_u001B.\u001F = parameters;
			List<ParameterModel>.Enumerator enumerator = \u0010\u000B\u0016.\u000A(Enumerable.ToList<ParameterModel>(\u001A\u0002\u0016.\u001D(this)));
			try
			{
				while (\u0003\u000B\u0016.\u000A(ref enumerator))
				{
					ParameterModel u000A = \u000D\u000B\u0016.\u000A(ref enumerator);
					if (!u000C_u001B.\u001F.\u000A(u000A))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManagerView.UpdateParameters(List<SelectionParameter>)).MethodHandle;
						}
						\u001A\u001B\u0016.\u000A(\u001A\u0002\u0016.\u001D(this), u000A);
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
			\u000D\u001B\u0016.\u000A(this, \u0013\u001B\u0016.\u000A(Enumerable.OrderBy<ParameterModel, int>(\u001A\u0002\u0016.\u001D(this), new Func<ParameterModel, int>(u000C_u001B.\u000A))));
		}

		// Token: 0x04000B8A RID: 2954
		[CompilerGenerated]
		private static Action WS;

		// Token: 0x04000B8B RID: 2955
		[CompilerGenerated]
		private static List<ViewManagerView> CB;

		// Token: 0x04000B8C RID: 2956
		private bool WR;

		// Token: 0x04000B8D RID: 2957
		private string JR;

		// Token: 0x04000B8E RID: 2958
		private bool LB;

		// Token: 0x04000B8F RID: 2959
		private UpdateStates BL;

		// Token: 0x04000B90 RID: 2960
		private ViewDuplicateOption SB;

		// Token: 0x04000B91 RID: 2961
		private string BB;

		// Token: 0x04000B92 RID: 2962
		[CompilerGenerated]
		private long JS;

		// Token: 0x04000B93 RID: 2963
		[CompilerGenerated]
		private bool UB;

		// Token: 0x04000B94 RID: 2964
		[CompilerGenerated]
		private ViewType NS;

		// Token: 0x04000B95 RID: 2965
		[CompilerGenerated]
		private ViewDiscipline WB;

		// Token: 0x04000B96 RID: 2966
		[CompilerGenerated]
		private int KB;

		// Token: 0x04000B97 RID: 2967
		[CompilerGenerated]
		private List<ParameterModel> OL;

		// Token: 0x04000B98 RID: 2968
		[CompilerGenerated]
		private UpdateStates TL;

		// Token: 0x04000B99 RID: 2969
		[CompilerGenerated]
		private View JB;

		// Token: 0x04000B9A RID: 2970
		[CompilerGenerated]
		private bool EB;

		// Token: 0x04000B9B RID: 2971
		[CompilerGenerated]
		private string VL;

		// Token: 0x04000B9C RID: 2972
		[CompilerGenerated]
		private bool NB;

		// Token: 0x04000B9D RID: 2973
		[CompilerGenerated]
		private bool MB;

		// Token: 0x020009A3 RID: 2467
		[CompilerGenerated]
		private sealed class \u000C\u001B
		{
			// Token: 0x06005365 RID: 21349 RVA: 0x001EC6C8 File Offset: 0x001EA8C8
			internal int \u000A(ParameterModel \u001F)
			{
				ViewManagerView.\u0015\u001B u0015_u001B = new ViewManagerView.\u0015\u001B();
				u0015_u001B.\u001F = \u001F;
				return \u0001\u0002\u0010.\u000A(this.\u001F, new Predicate<SelectionParameter>(u0015_u001B.\u000A));
			}

			// Token: 0x04002508 RID: 9480
			public List<SelectionParameter> \u001F;
		}

		// Token: 0x020009A4 RID: 2468
		[CompilerGenerated]
		private sealed class \u0015\u001B
		{
			// Token: 0x06005367 RID: 21351 RVA: 0x001EC710 File Offset: 0x001EA910
			internal bool \u000A(SelectionParameter \u001F)
			{
				if (\u000A\u0003\u0016.\u001D(\u001F) == \u000A\u0003\u0016.\u001D(\u0004\u0005\u0016.\u0007(this.\u001F)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewManagerView.\u0015\u001B.\u000A(SelectionParameter)).MethodHandle;
					}
					if (\u0008\u000F\u0016.\u0007(\u0004\u0005\u0016.\u0007(this.\u001F)) != -1L)
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
						if (\u0008\u000F\u0016.\u0007(\u0004\u0005\u0016.\u0007(this.\u001F)) == \u0008\u000F\u0016.\u0007(\u001F))
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
							return true;
						}
					}
					else if (\u0008\u0013\u000A.\u000A(\u001F\u0016\u0016.\u0007(\u0004\u0005\u0016.\u0007(this.\u001F)), \u001F\u0016\u0016.\u0007(\u001F)))
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
						return true;
					}
				}
				return false;
			}

			// Token: 0x04002509 RID: 9481
			public ParameterModel \u001F;
		}

		// Token: 0x020009A5 RID: 2469
		[CompilerGenerated]
		private sealed class \u0001\u001B
		{
			// Token: 0x06005369 RID: 21353 RVA: 0x001EC7E4 File Offset: 0x001EA9E4
			internal bool \u000A(ParameterModel \u001F)
			{
				return \u0008\u000F\u0016.\u0007(\u0004\u0005\u0016.\u0007(\u001F)) == this.\u001F;
			}

			// Token: 0x0400250A RID: 9482
			public BuiltInParameter \u001F;
		}
	}
}
