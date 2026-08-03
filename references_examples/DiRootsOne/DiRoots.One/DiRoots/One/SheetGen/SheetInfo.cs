using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.SheetGen.Core.Services;
using DiRoots.One.SheetGen.Data;
using DiRoots.One.SheetGen.Messaging;
using DiRoots.One.SheetGen.Services;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002BE RID: 702
	[Serializable]
	public class SheetInfo : SheetModelBase
	{
		// Token: 0x06001C0B RID: 7179 RVA: 0x000B3440 File Offset: 0x000B1640
		public SheetInfo()
		{
		}

		// Token: 0x06001C0C RID: 7180 RVA: 0x000B3464 File Offset: 0x000B1664
		public SheetInfo(SheetTemplate template)
		{
			\u0008\u000D\u0016.\u0007(this, template.\u001F());
			\u000E\u000D\u0016.\u000A(this, new RevisionInfo(this));
			\u0012\u0005\u0016.\u0007(this, UpdateStates.ToAdd);
			\u000D\u000D\u0016.\u000A(this, \u0010\u000D\u0016.\u000A(template));
			string u000A;
			if ((u000A = \u001C\u000D\u0016.\u000A(\u0008\u0007\u0016.\u001D(this))) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo..ctor(SheetTemplate)).MethodHandle;
				}
				u000A = "<None>";
			}
			\u0003\u000D\u0016.\u000A(this, u000A);
			\u0012\u000D\u0016.\u000A(this, false);
			\u000F\u000D\u0016.\u000A(\u0008\u0004\u0016.\u001D(this), new RevisionInfo.RevisionsEditedHandler(this.PO));
		}

		// Token: 0x06001C0D RID: 7181 RVA: 0x000B3508 File Offset: 0x000B1708
		public SheetInfo(SheetTemplate template, ITitleBlockService titleBlockService)
		{
			\u0008\u000D\u0016.\u0007(this, template.\u001F());
			\u000E\u000D\u0016.\u000A(this, new RevisionInfo(this));
			\u0012\u0005\u0016.\u0007(this, UpdateStates.ToAdd);
			\u000D\u000D\u0016.\u000A(this, \u0010\u000D\u0016.\u000A(\u0008\u0007\u0016.\u001D(this)));
			ViewSheet viewSheet = \u0015\u001D\u000E.\u001F(\u0007\u0018\u0016.\u000A(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004), \u001B\u0007\u0016.\u0007(\u0008\u0007\u0016.\u001D(this))));
			if (viewSheet != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo..ctor(SheetTemplate, ITitleBlockService)).MethodHandle;
				}
				FamilySymbol familySymbol;
				\u0020\u000D\u0016.\u0007(\u0008\u0007\u0016.\u001D(this), \u0017\u000D\u0016.\u000A(titleBlockService, viewSheet, out familySymbol));
				\u0011\u000D\u0016.\u0007(\u0008\u0007\u0016.\u001D(this), \u001E\u000D\u0016.\u000A(titleBlockService, viewSheet));
				object u001F = \u0008\u0007\u0016.\u001D(this);
				string u000A;
				if (familySymbol == null)
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
					u000A = "<None>";
				}
				else
				{
					u000A = \u0002\u0013\u000A.\u000A("<", \u0001\u0015\u0018.\u0007(familySymbol), ">");
				}
				\u001B\u000D\u0016.\u0007(u001F, u000A);
			}
			string u000A2;
			if ((u000A2 = \u001C\u000D\u0016.\u000A(\u0008\u0007\u0016.\u001D(this))) == null)
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
				u000A2 = "<None>";
			}
			\u0003\u000D\u0016.\u000A(this, u000A2);
			this.ZO(titleBlockService);
			\u0012\u000D\u0016.\u000A(this, false);
			\u000F\u000D\u0016.\u000A(\u0008\u0004\u0016.\u001D(this), new RevisionInfo.RevisionsEditedHandler(this.PO));
		}

		// Token: 0x06001C0E RID: 7182 RVA: 0x000B365C File Offset: 0x000B185C
		public SheetInfo(ViewSheet sheetElement, SheetTemplate template, ITitleBlockService titleBlockService, bool optimized)
		{
			\u0008\u000D\u0016.\u0007(this, template.\u001F());
			\u000E\u000D\u0016.\u000A(this, new RevisionInfo(this));
			\u0012\u0005\u0016.\u0007(this, UpdateStates.ToAdd);
			\u000D\u000D\u0016.\u000A(this, \u0010\u000D\u0016.\u000A(template));
			FamilySymbol familySymbol;
			\u0020\u000D\u0016.\u0007(\u0008\u0007\u0016.\u001D(this), \u0017\u000D\u0016.\u000A(titleBlockService, sheetElement, out familySymbol));
			\u0011\u000D\u0016.\u0007(\u0008\u0007\u0016.\u001D(this), \u001E\u000D\u0016.\u000A(titleBlockService, sheetElement));
			object u001F = \u0008\u0007\u0016.\u001D(this);
			string text;
			if (familySymbol == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo..ctor(ViewSheet, SheetTemplate, ITitleBlockService, bool)).MethodHandle;
				}
				text = "<None>";
			}
			else
			{
				text = \u0002\u0013\u000A.\u000A("<", \u0001\u0015\u0018.\u0007(familySymbol), ">");
			}
			string u000A;
			\u001B\u000D\u0016.\u0007(u001F, u000A = text);
			\u0003\u000D\u0016.\u000A(this, u000A);
			this.ZO(titleBlockService);
			\u0012\u000D\u0016.\u000A(this, optimized);
			\u000F\u000D\u0016.\u000A(\u0008\u0004\u0016.\u001D(this), new RevisionInfo.RevisionsEditedHandler(this.PO));
		}

		// Token: 0x06001C0F RID: 7183 RVA: 0x000B3750 File Offset: 0x000B1950
		public SheetInfo(ITitleBlockService titleBlockService) : this(\u000C\u0018\u0016.\u000A(), titleBlockService)
		{
			\u000D\u000D\u0016.\u000A(this, false);
		}

		// Token: 0x170007CB RID: 1995
		// (get) Token: 0x06001C11 RID: 7185 RVA: 0x000B3790 File Offset: 0x000B1990
		// (set) Token: 0x06001C12 RID: 7186 RVA: 0x000B37A4 File Offset: 0x000B19A4
		internal static List<SheetInfo> Sheets { get; set; } = \u001D\u000B\u0016.\u000A();

		// Token: 0x170007CC RID: 1996
		// (get) Token: 0x06001C13 RID: 7187 RVA: 0x000B37B8 File Offset: 0x000B19B8
		// (set) Token: 0x06001C14 RID: 7188 RVA: 0x000B37CC File Offset: 0x000B19CC
		internal static SelectionParameter SheetNumberParameter { get; set; }

		// Token: 0x170007CD RID: 1997
		// (get) Token: 0x06001C15 RID: 7189 RVA: 0x000B37E0 File Offset: 0x000B19E0
		// (set) Token: 0x06001C16 RID: 7190 RVA: 0x000B37F4 File Offset: 0x000B19F4
		internal static SelectionParameter SheetNameParameter { get; set; }

		// Token: 0x170007CE RID: 1998
		// (get) Token: 0x06001C17 RID: 7191 RVA: 0x000B3808 File Offset: 0x000B1A08
		// (set) Token: 0x06001C18 RID: 7192 RVA: 0x000B381C File Offset: 0x000B1A1C
		internal static List<SheetInfo> SelectedSheets { get; set; }

		// Token: 0x170007CF RID: 1999
		// (get) Token: 0x06001C19 RID: 7193 RVA: 0x000B3830 File Offset: 0x000B1A30
		// (set) Token: 0x06001C1A RID: 7194 RVA: 0x000B3844 File Offset: 0x000B1A44
		internal static bool SuppressSelectionPropagation { get; set; }

		// Token: 0x170007D0 RID: 2000
		// (get) Token: 0x06001C1B RID: 7195 RVA: 0x000B3858 File Offset: 0x000B1A58
		// (set) Token: 0x06001C1C RID: 7196 RVA: 0x000B386C File Offset: 0x000B1A6C
		internal static Action OnStatusChanged { get; set; }

		// Token: 0x06001C1D RID: 7197 RVA: 0x000B3880 File Offset: 0x000B1A80
		private void ZO(ITitleBlockService F)
		{
			Document u001F = \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004);
			Element element;
			if ((element = \u0007\u0018\u0016.\u000A(u001F, \u001F\u0010\u0016.\u000A(\u0008\u0007\u0016.\u001D(this)))) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.ZO(ITitleBlockService)).MethodHandle;
				}
				element = \u0007\u0018\u0016.\u000A(u001F, \u001B\u0007\u0016.\u0007(\u0008\u0007\u0016.\u001D(this)));
			}
			Element element2 = element;
			List<Parameter> list;
			if (element2 == null)
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
				list = \u0012\u0007\u000E.\u001F;
			}
			else
			{
				list = \u0003\u0007\u001D.\u000A(element2, false);
			}
			List<Parameter> u000A = list;
			List<SelectionParameter>.Enumerator enumerator = \u0001\u000D\u0016.\u000A(\u0009\u000D\u0016.\u0007(ParametersManagerService.\u0008));
			try
			{
				while (\u0014\u000D\u0016.\u000A(ref enumerator))
				{
					SelectionParameter selectionParameter = \u0015\u000D\u0016.\u000A(ref enumerator);
					ParameterModel parameterModel;
					if (\u000A\u0003\u0016.\u001D(selectionParameter) != SelectionParameterType.ProjectInformation)
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
						parameterModel = \u000C\u000D\u0016.\u000A(selectionParameter);
					}
					else
					{
						parameterModel = \u001A\u000D\u0016.\u000A(selectionParameter);
					}
					ParameterModel parameterModel2 = parameterModel;
					\u0013\u000D\u0016.\u000A(this, parameterModel2);
					if (element2 != null)
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
						\u0009\u0005\u0016.\u000A(parameterModel2, parameterModel2.\u000A(u000A), selectionParameter, element2);
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
		}

		// Token: 0x06001C1E RID: 7198 RVA: 0x000B39B0 File Offset: 0x000B1BB0
		public void ChangeTemplate(SheetTemplate template)
		{
			\u0008\u000D\u0016.\u0007(this, template.\u001F());
			\u001A\u0019\u0016.\u001D(this, true);
			\u0012\u000D\u0016.\u000A(this, false);
			object u001F = \u001B\u001D\u0016.\u001D(this);
			Action<ViewInfo> u000A;
			if ((u000A = SheetInfo.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.ChangeTemplate(SheetTemplate)).MethodHandle;
				}
				u000A = (SheetInfo.<>c.\u000A = new Action<ViewInfo>(SheetInfo.<>c.\u001F.\u0005));
			}
			\u000A\u0010\u0016.\u000A(u001F, u000A);
			this.XO();
		}

		// Token: 0x06001C1F RID: 7199 RVA: 0x000B3A20 File Offset: 0x000B1C20
		public void RefreshTemplate(SheetTemplate template)
		{
			\u0008\u000D\u0016.\u0007(this, template.\u001F());
		}

		// Token: 0x06001C20 RID: 7200 RVA: 0x000B3A3C File Offset: 0x000B1C3C
		public void SubscribeEvents()
		{
			\u000F\u000D\u0016.\u000A(\u0008\u0004\u0016.\u001D(this), new RevisionInfo.RevisionsEditedHandler(this.PO));
			List<ViewInfo>.Enumerator enumerator = \u0008\u001D\u0016.\u000A(\u001B\u001D\u0016.\u001D(this));
			try
			{
				while (\u0019\u001D\u0016.\u000A(ref enumerator))
				{
					\u0007\u0010\u0016.\u000A(\u000E\u001D\u0016.\u000A(ref enumerator), new ViewInfo.ViewEditedHandler(this.XO));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.SubscribeEvents()).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06001C21 RID: 7201 RVA: 0x000B3ACC File Offset: 0x000B1CCC
		public void GenerateViews(bool optimized)
		{
			\u0016\u0010\u0016.\u000A(this, \u000B\u0010\u0016.\u000A());
			List<ViewTemplate>.Enumerator enumerator = \u0005\u0010\u0016.\u000A(\u000E\u0007\u0016.\u0007(\u0008\u0007\u0016.\u001D(this)));
			try
			{
				while (\u001D\u0010\u0016.\u000A(ref enumerator))
				{
					ViewInfo viewInfo = \u0019\u0010\u0016.\u000A(\u0018\u0010\u0016.\u000A(ref enumerator), this, optimized);
					\u0007\u0010\u0016.\u000A(viewInfo, new ViewInfo.ViewEditedHandler(this.XO));
					\u0004\u0010\u0016.\u000A(\u001B\u001D\u0016.\u001D(this), viewInfo);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.GenerateViews(bool)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06001C22 RID: 7202 RVA: 0x000B3B70 File Offset: 0x000B1D70
		public void UpdateViews(SheetInfo sheet)
		{
			List<ViewInfo>.Enumerator enumerator = \u0008\u001D\u0016.\u000A(\u001B\u001D\u0016.\u001D(this));
			try
			{
				while (\u0019\u001D\u0016.\u000A(ref enumerator))
				{
					SheetInfo.\u0002\u001B u0002_u001B = new SheetInfo.\u0002\u001B();
					u0002_u001B.\u001F = \u000E\u001D\u0016.\u000A(ref enumerator);
					SheetInfo.\u0006\u001B u0006_u001B = new SheetInfo.\u0006\u001B();
					u0006_u001B.\u001F = Enumerable.FirstOrDefault<ViewInfo>(\u001B\u001D\u0016.\u0007(sheet), new Func<ViewInfo, bool>(u0002_u001B.\u000A));
					if (u0006_u001B.\u001F != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.UpdateViews(SheetInfo)).MethodHandle;
						}
						ViewData viewData = Enumerable.FirstOrDefault<ViewData>(\u0006\u0010\u0016.\u0007(u0002_u001B.\u001F), new Func<ViewData, bool>(u0006_u001B.\u000A));
						if (viewData != null)
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
							\u0017\u0019\u0016.\u0007(u0002_u001B.\u001F, viewData);
							\u0002\u0010\u0016.\u0007(u0002_u001B.\u001F, viewData);
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
		}

		// Token: 0x06001C23 RID: 7203 RVA: 0x000B3C68 File Offset: 0x000B1E68
		public void UpdateViews(SheetTemplate template, bool duplicateViews, bool keepLegend, bool keepSchedule)
		{
			List<ViewInfo>.Enumerator enumerator = \u0008\u001D\u0016.\u000A(\u001B\u001D\u0016.\u001D(this));
			try
			{
				while (\u0019\u001D\u0016.\u000A(ref enumerator))
				{
					SheetInfo.\u000F\u001B u000F_u001B = new SheetInfo.\u000F\u001B();
					u000F_u001B.\u001F = \u000E\u001D\u0016.\u000A(ref enumerator);
					SheetInfo.\u0012\u001B u0012_u001B = new SheetInfo.\u0012\u001B();
					u0012_u001B.\u001F = Enumerable.FirstOrDefault<ViewTemplate>(\u000E\u0007\u0016.\u0007(template), new Func<ViewTemplate, bool>(u000F_u001B.\u000A));
					if (u0012_u001B.\u001F == null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.UpdateViews(SheetTemplate, bool, bool, bool)).MethodHandle;
						}
						return;
					}
					ViewType viewType = \u001D\u0019\u0016.\u0007(u000F_u001B.\u001F);
					if (viewType == 5)
					{
						goto IL_B6;
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
					bool flag;
					if (viewType != 11)
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
						if (viewType == 123)
						{
							goto IL_B6;
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
						flag = duplicateViews;
					}
					else
					{
						flag = keepLegend;
					}
					IL_BF:
					bool flag2 = flag;
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
						\u000C\u0004\u0016.\u0007(u000F_u001B.\u001F, 0L);
					}
					ViewData viewData;
					if (!flag2)
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
						viewData = Enumerable.First<ViewData>(\u0006\u0010\u0016.\u0007(u000F_u001B.\u001F));
					}
					else
					{
						viewData = Enumerable.FirstOrDefault<ViewData>(\u0006\u0010\u0016.\u0007(u000F_u001B.\u001F), new Func<ViewData, bool>(u0012_u001B.\u000A));
					}
					ViewData viewData2 = viewData;
					if (viewData2 != null)
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
						\u0017\u0019\u0016.\u0007(u000F_u001B.\u001F, viewData2);
						\u0002\u0010\u0016.\u0007(u000F_u001B.\u001F, viewData2);
						continue;
					}
					continue;
					IL_B6:
					flag = keepSchedule;
					goto IL_BF;
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
		}

		// Token: 0x06001C24 RID: 7204 RVA: 0x000B3DFC File Offset: 0x000B1FFC
		public void UpdateParameters(List<SelectionParameter> parameters)
		{
			SheetInfo.\u0003\u001B u0003_u001B = new SheetInfo.\u0003\u001B();
			u0003_u001B.\u001F = parameters;
			List<ParameterModel>.Enumerator enumerator = \u0010\u000B\u0016.\u000A(Enumerable.ToList<ParameterModel>(\u0005\u0005\u0016.\u001D(this)));
			try
			{
				while (\u0003\u000B\u0016.\u000A(ref enumerator))
				{
					ParameterModel u000A = \u000D\u000B\u0016.\u000A(ref enumerator);
					if (!u0003_u001B.\u001F.\u000A(u000A))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.UpdateParameters(List<SelectionParameter>)).MethodHandle;
						}
						\u0012\u0010\u0016.\u000A(\u0005\u0005\u0016.\u001D(this), u000A);
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
			\u000F\u0010\u0016.\u000A(this, Enumerable.ToList<ParameterModel>(Enumerable.OrderBy<ParameterModel, int>(\u0005\u0005\u0016.\u001D(this), new Func<ParameterModel, int>(u0003_u001B.\u000A))));
		}

		// Token: 0x06001C25 RID: 7205 RVA: 0x000B3ECC File Offset: 0x000B20CC
		public bool HasSameViewsAsTemplate()
		{
			IEnumerable<ViewInfo> enumerable = \u001B\u001D\u0016.\u001D(this);
			Func<ViewInfo, long> func;
			if ((func = SheetInfo.<>c.\u0007) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.HasSameViewsAsTemplate()).MethodHandle;
				}
				func = (SheetInfo.<>c.\u0007 = new Func<ViewInfo, long>(SheetInfo.<>c.\u001F.\u0016));
			}
			IEnumerable<long> enumerable2 = Enumerable.Select<ViewInfo, long>(enumerable, func);
			IEnumerable<ViewTemplate> enumerable3 = \u000E\u0007\u0016.\u0007(\u0008\u0007\u0016.\u001D(this));
			Func<ViewTemplate, long> func2;
			if ((func2 = SheetInfo.<>c.\u001D) == null)
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
				func2 = (SheetInfo.<>c.\u001D = new Func<ViewTemplate, long>(SheetInfo.<>c.\u001F.\u000B));
			}
			IEnumerable<long> enumerable4 = Enumerable.Select<ViewTemplate, long>(enumerable3, func2);
			return Enumerable.SequenceEqual<long>(enumerable2, enumerable4);
		}

		// Token: 0x06001C26 RID: 7206 RVA: 0x000B3F64 File Offset: 0x000B2164
		private void XO()
		{
			if (\u0006\u0004\u0016.\u0007(this) != UpdateStates.Updated)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.XO()).MethodHandle;
				}
				if (\u0006\u0004\u0016.\u0007(this) != UpdateStates.NameModified)
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
					if (\u0006\u0004\u0016.\u0007(this) != UpdateStates.NumberModified)
					{
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
				}
			}
			\u0012\u0005\u0016.\u0007(this, UpdateStates.Modified);
		}

		// Token: 0x06001C27 RID: 7207 RVA: 0x000B3FC0 File Offset: 0x000B21C0
		private void PO(RevisionData F)
		{
			SheetInfo.\u000D\u001B u000D_u001B = new SheetInfo.\u000D\u001B();
			u000D_u001B.\u001F = F;
			List<SheetInfo> list;
			if ((list = \u0003\u0010\u0016.\u000A()) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.PO(RevisionData)).MethodHandle;
				}
				list = \u001D\u000B\u0016.\u000A();
			}
			List<SheetInfo> u001F = list;
			if (\u001D\u001D\u0016.\u000A(u001F) > 1)
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
				List<SheetInfo>.Enumerator enumerator = \u0017\u0007\u0016.\u000A(u001F);
				try
				{
					while (\u000D\u0007\u0016.\u000A(ref enumerator))
					{
						SheetInfo u001F2 = \u0020\u0007\u0016.\u000A(ref enumerator);
						IEnumerable<RevisionData> enumerable = \u0013\u0004\u0016.\u0007(\u0008\u0004\u0016.\u0007(u001F2));
						Func<RevisionData, bool> func;
						if ((func = SheetInfo.<>c.\u0004) == null)
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
							func = (SheetInfo.<>c.\u0004 = new Func<RevisionData, bool>(SheetInfo.<>c.\u001F.\u0002));
						}
						IEnumerable<RevisionData> enumerable2 = Enumerable.Where<RevisionData>(enumerable, func);
						Func<RevisionData, bool> func2;
						if ((func2 = u000D_u001B.\u000A) == null)
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
							func2 = (u000D_u001B.\u000A = new Func<RevisionData, bool>(u000D_u001B.\u0007));
						}
						RevisionData revisionData = Enumerable.FirstOrDefault<RevisionData>(enumerable2, func2);
						if (revisionData != null)
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
							\u0008\u0003\u0016.\u000A(revisionData, \u001E\u0004\u0016.\u000A(u000D_u001B.\u001F));
							IEnumerable<RevisionData> enumerable3 = \u0013\u0004\u0016.\u0007(\u0008\u0004\u0016.\u0007(u001F2));
							Func<RevisionData, bool> func3;
							if ((func3 = SheetInfo.<>c.\u0019) == null)
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
								func3 = (SheetInfo.<>c.\u0019 = new Func<RevisionData, bool>(SheetInfo.<>c.\u001F.\u0006));
							}
							RevisionData revisionData2 = Enumerable.LastOrDefault<RevisionData>(enumerable3, func3);
							string text;
							if (revisionData2 == null)
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
								text = null;
							}
							else
							{
								text = \u0011\u0004\u0016.\u001D(revisionData2);
							}
							string text2;
							if ((text2 = text) == null)
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
								text2 = "";
							}
							string u000A = text2;
							\u0014\u0003\u0016.\u001D(\u0008\u0004\u0016.\u0007(u001F2), u000A);
							if (\u0006\u0004\u0016.\u0007(u001F2) != UpdateStates.Updated)
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
								if (\u0006\u0004\u0016.\u0007(u001F2) != UpdateStates.NameModified)
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
									if (\u0006\u0004\u0016.\u0007(u001F2) != UpdateStates.NumberModified)
									{
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
							}
							\u0012\u0005\u0016.\u0007(u001F2, UpdateStates.Modified);
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
			}
			if (\u0006\u0004\u0016.\u0007(this) != UpdateStates.Updated)
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
				if (\u0006\u0004\u0016.\u0007(this) != UpdateStates.NameModified)
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
					if (\u0006\u0004\u0016.\u0007(this) != UpdateStates.NumberModified)
					{
						return;
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
			\u0012\u0005\u0016.\u0007(this, UpdateStates.Modified);
		}

		// Token: 0x06001C28 RID: 7208 RVA: 0x000B4214 File Offset: 0x000B2414
		internal void OO()
		{
			List<ViewInfo>.Enumerator enumerator = \u0008\u001D\u0016.\u000A(\u001B\u001D\u0016.\u001D(this));
			try
			{
				while (\u0019\u001D\u0016.\u000A(ref enumerator))
				{
					ViewInfo u001F = \u000E\u001D\u0016.\u000A(ref enumerator);
					if (\u001C\u0010\u0016.\u000A(u001F) != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.OO()).MethodHandle;
						}
						\u0017\u0019\u0016.\u0007(u001F, \u001C\u0010\u0016.\u000A(u001F));
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
		}

		// Token: 0x06001C29 RID: 7209 RVA: 0x000B42A0 File Offset: 0x000B24A0
		protected override void OnParameterValueChanged(ParameterModel parameter)
		{
			List<SheetInfo> u001F;
			if ((u001F = \u0003\u0010\u0016.\u000A()) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.OnParameterValueChanged(ParameterModel)).MethodHandle;
				}
				u001F = \u001D\u000B\u0016.\u000A();
			}
			List<SheetInfo>.Enumerator enumerator = \u0017\u0007\u0016.\u000A(u001F);
			try
			{
				while (\u000D\u0007\u0016.\u000A(ref enumerator))
				{
					ParameterModel u001F2 = \u0020\u0007\u0016.\u000A(ref enumerator).\u001D(\u0004\u0005\u0016.\u0007(parameter), \u000A\u0003\u0016.\u001D(\u0004\u0005\u0016.\u0007(parameter)) == SelectionParameterType.ProjectInformation);
					if (\u000E\u0010\u0016.\u000A(u001F2))
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
						\u0010\u0010\u0016.\u000A(u001F2, \u0009\u0018\u0016.\u0007(parameter));
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
			\u000D\u0010\u0016.\u000A(this, parameter);
			\u0005\u001B\u000A.\u0018.\u0019<object>(\u001C\u0016\u0016.\u000A(), Context.RefreshSheets);
		}

		// Token: 0x06001C2A RID: 7210 RVA: 0x000B4380 File Offset: 0x000B2580
		internal void TO(ITitleBlockService F)
		{
			SheetInfo.\u0010\u001B u0010_u001B = new SheetInfo.\u0010\u001B();
			Document u001F = \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004);
			Element element;
			if ((element = \u0007\u0018\u0016.\u000A(u001F, \u001F\u0010\u0016.\u000A(\u0008\u0007\u0016.\u001D(this)))) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.TO(ITitleBlockService)).MethodHandle;
				}
				element = \u0007\u0018\u0016.\u000A(u001F, \u001B\u0007\u0016.\u0007(\u0008\u0007\u0016.\u001D(this)));
			}
			Element element2 = element;
			SheetInfo.\u0010\u001B u0010_u001B2 = u0010_u001B;
			IEnumerable<ParameterModel> enumerable = \u0005\u0005\u0016.\u001D(this);
			Func<ParameterModel, SelectionParameter> func;
			if ((func = SheetInfo.<>c.\u0018) == null)
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
				func = (SheetInfo.<>c.\u0018 = new Func<ParameterModel, SelectionParameter>(SheetInfo.<>c.\u001F.\u000F));
			}
			u0010_u001B2.\u001F = Enumerable.Select<ParameterModel, SelectionParameter>(enumerable, func);
			object u001F2 = Enumerable.Where<SelectionParameter>(\u0009\u000D\u0016.\u0007(ParametersManagerService.\u0008), new Func<SelectionParameter, bool>(u0010_u001B.\u000A));
			List<Parameter> list;
			if (element2 == null)
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
				list = \u0003\u0007\u001D.\u000A(element2, false);
			}
			List<Parameter> u000A = list;
			IEnumerator<SelectionParameter> enumerator = \u001B\u0010\u0016.\u000A(u001F2);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					SelectionParameter selectionParameter = \u0008\u0010\u0016.\u000A(enumerator);
					ParameterModel parameterModel = \u000C\u000D\u0016.\u000A(selectionParameter);
					\u0013\u000D\u0016.\u000A(this, parameterModel);
					if (element2 != null)
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
						\u0009\u0005\u0016.\u000A(parameterModel, parameterModel.\u000A(u000A), selectionParameter, element2);
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}

		// Token: 0x170007D1 RID: 2001
		// (get) Token: 0x06001C2B RID: 7211 RVA: 0x000B44EC File Offset: 0x000B26EC
		public override long TemplateSheetId
		{
			get
			{
				SheetTemplate sheetTemplate = \u0008\u0007\u0016.\u001D(this);
				if (sheetTemplate == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.get_TemplateSheetId()).MethodHandle;
					}
					return 0L;
				}
				return \u001B\u0007\u0016.\u001D(sheetTemplate);
			}
		}

		// Token: 0x170007D2 RID: 2002
		// (get) Token: 0x06001C2C RID: 7212 RVA: 0x000B4524 File Offset: 0x000B2724
		public override string TemplateSheetNumber
		{
			get
			{
				SheetTemplate sheetTemplate = \u0008\u0007\u0016.\u001D(this);
				string text;
				if (sheetTemplate == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.get_TemplateSheetNumber()).MethodHandle;
					}
					text = null;
				}
				else
				{
					text = \u0011\u0010\u0016.\u0007(sheetTemplate);
				}
				string result;
				if ((result = text) == null)
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
					result = string.Empty;
				}
				return result;
			}
		}

		// Token: 0x170007D3 RID: 2003
		// (get) Token: 0x06001C2D RID: 7213 RVA: 0x000B4570 File Offset: 0x000B2770
		// (set) Token: 0x06001C2E RID: 7214 RVA: 0x000B4584 File Offset: 0x000B2784
		public bool IsCreatedBySheetGen { get; set; }

		// Token: 0x170007D4 RID: 2004
		// (get) Token: 0x06001C2F RID: 7215 RVA: 0x000B4598 File Offset: 0x000B2798
		// (set) Token: 0x06001C30 RID: 7216 RVA: 0x000B45AC File Offset: 0x000B27AC
		public bool IsModifiedBySheetGen { get; set; }

		// Token: 0x170007D5 RID: 2005
		// (get) Token: 0x06001C31 RID: 7217 RVA: 0x000B45C0 File Offset: 0x000B27C0
		// (set) Token: 0x06001C32 RID: 7218 RVA: 0x000B45D4 File Offset: 0x000B27D4
		public bool IsAssemblySheet { get; set; }

		// Token: 0x170007D6 RID: 2006
		// (get) Token: 0x06001C33 RID: 7219 RVA: 0x000B45E8 File Offset: 0x000B27E8
		// (set) Token: 0x06001C34 RID: 7220 RVA: 0x000B45FC File Offset: 0x000B27FC
		public bool TemplateChanged { get; set; }

		// Token: 0x170007D7 RID: 2007
		// (get) Token: 0x06001C35 RID: 7221 RVA: 0x000B4610 File Offset: 0x000B2810
		public bool IsGoodForExport
		{
			get
			{
				bool result = false;
				if (\u0006\u0004\u0016.\u0007(this) == UpdateStates.Updated)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.get_IsGoodForExport()).MethodHandle;
					}
					if (!\u0006\u000D\u0016.\u001D(this))
					{
						goto IL_35;
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
				result = true;
				IL_35:
				if (\u001E\u0010\u0016.\u000A(this))
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
					result = true;
				}
				return result;
			}
		}

		// Token: 0x170007D8 RID: 2008
		// (get) Token: 0x06001C36 RID: 7222 RVA: 0x000B466C File Offset: 0x000B286C
		// (set) Token: 0x06001C37 RID: 7223 RVA: 0x000B4680 File Offset: 0x000B2880
		public List<ViewInfo> Views { get; set; }

		// Token: 0x170007D9 RID: 2009
		// (get) Token: 0x06001C38 RID: 7224 RVA: 0x000B4694 File Offset: 0x000B2894
		// (set) Token: 0x06001C39 RID: 7225 RVA: 0x000B46A8 File Offset: 0x000B28A8
		public RevisionInfo Revision { get; set; }

		// Token: 0x170007DA RID: 2010
		// (get) Token: 0x06001C3A RID: 7226 RVA: 0x000B46BC File Offset: 0x000B28BC
		// (set) Token: 0x06001C3B RID: 7227 RVA: 0x000B46D4 File Offset: 0x000B28D4
		public override UpdateStates UpdateState
		{
			get
			{
				return \u0006\u0004\u0016.\u001D(this);
			}
			set
			{
				\u0012\u0005\u0016.\u001D(this, value);
				Action action = \u0020\u0010\u0016.\u000A();
				if (action == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.set_UpdateState(UpdateStates)).MethodHandle;
					}
					return;
				}
				\u001B\u0015\u0007.\u000A(action);
			}
		}

		// Token: 0x170007DB RID: 2011
		// (get) Token: 0x06001C3C RID: 7228 RVA: 0x000B470C File Offset: 0x000B290C
		// (set) Token: 0x06001C3D RID: 7229 RVA: 0x000B4720 File Offset: 0x000B2920
		public int ViewDuplicateOption { get; set; } = 1;

		// Token: 0x170007DC RID: 2012
		// (get) Token: 0x06001C3E RID: 7230 RVA: 0x000B4734 File Offset: 0x000B2934
		// (set) Token: 0x06001C3F RID: 7231 RVA: 0x000B4748 File Offset: 0x000B2948
		public SheetTemplate Template
		{
			get
			{
				return this._template;
			}
			set
			{
				base.SetProperty<SheetTemplate>(ref this._template, value, null, "Template");
			}
		}

		// Token: 0x170007DD RID: 2013
		// (get) Token: 0x06001C40 RID: 7232 RVA: 0x000B476C File Offset: 0x000B296C
		// (set) Token: 0x06001C41 RID: 7233 RVA: 0x000B4780 File Offset: 0x000B2980
		public bool CopyTextAndDetailingLines { get; set; } = true;

		// Token: 0x170007DE RID: 2014
		// (get) Token: 0x06001C42 RID: 7234 RVA: 0x000B4794 File Offset: 0x000B2994
		// (set) Token: 0x06001C43 RID: 7235 RVA: 0x000B47A8 File Offset: 0x000B29A8
		public List<ParameterModel> TitleBlockParameters { get; internal set; }

		// Token: 0x04000B4E RID: 2894
		[CompilerGenerated]
		private static List<SheetInfo> CS;

		// Token: 0x04000B4F RID: 2895
		[CompilerGenerated]
		private static SelectionParameter LS;

		// Token: 0x04000B50 RID: 2896
		[CompilerGenerated]
		private static SelectionParameter SS;

		// Token: 0x04000B51 RID: 2897
		[CompilerGenerated]
		private static List<SheetInfo> BS;

		// Token: 0x04000B52 RID: 2898
		[CompilerGenerated]
		private static bool US;

		// Token: 0x04000B53 RID: 2899
		[CompilerGenerated]
		private static Action WS;

		// Token: 0x04000B54 RID: 2900
		private SheetTemplate _template;

		// Token: 0x0200098E RID: 2446
		[CompilerGenerated]
		private sealed class \u0002\u001B
		{
			// Token: 0x06005330 RID: 21296 RVA: 0x001EC008 File Offset: 0x001EA208
			internal bool \u000A(ViewInfo \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0015\u0002\u0010.\u0007(this.\u001F), \u0015\u0002\u0010.\u0007(\u001F));
			}

			// Token: 0x040024EB RID: 9451
			public ViewInfo \u001F;
		}

		// Token: 0x0200098F RID: 2447
		[CompilerGenerated]
		private sealed class \u0006\u001B
		{
			// Token: 0x06005332 RID: 21298 RVA: 0x001EC048 File Offset: 0x001EA248
			internal bool \u000A(ViewData \u001F)
			{
				return \u000B\u0019\u0016.\u0007(\u001F) == \u000B\u0019\u0016.\u0007(\u0002\u0019\u0016.\u0007(this.\u001F));
			}

			// Token: 0x040024EC RID: 9452
			public ViewInfo \u001F;
		}

		// Token: 0x02000990 RID: 2448
		[CompilerGenerated]
		private sealed class \u000F\u001B
		{
			// Token: 0x06005334 RID: 21300 RVA: 0x001EC088 File Offset: 0x001EA288
			internal bool \u000A(ViewTemplate \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0015\u0002\u0010.\u0007(this.\u001F), \u0012\u0008\u0016.\u000A(\u001F));
			}

			// Token: 0x040024ED RID: 9453
			public ViewInfo \u001F;
		}

		// Token: 0x02000991 RID: 2449
		[CompilerGenerated]
		private sealed class \u0012\u001B
		{
			// Token: 0x06005336 RID: 21302 RVA: 0x001EC0C8 File Offset: 0x001EA2C8
			internal bool \u000A(ViewData \u001F)
			{
				return \u000B\u0019\u0016.\u0007(\u001F) == \u0020\u0016\u0002.\u000A(this.\u001F);
			}

			// Token: 0x040024EE RID: 9454
			public ViewTemplate \u001F;
		}

		// Token: 0x02000992 RID: 2450
		[CompilerGenerated]
		private sealed class \u0003\u001B
		{
			// Token: 0x06005338 RID: 21304 RVA: 0x001EC100 File Offset: 0x001EA300
			internal int \u000A(ParameterModel \u001F)
			{
				SheetInfo.\u001C\u001B u001C_u001B = new SheetInfo.\u001C\u001B();
				u001C_u001B.\u001F = \u001F;
				return \u0001\u0002\u0010.\u000A(this.\u001F, new Predicate<SelectionParameter>(u001C_u001B.\u000A));
			}

			// Token: 0x040024EF RID: 9455
			public List<SelectionParameter> \u001F;
		}

		// Token: 0x02000993 RID: 2451
		[CompilerGenerated]
		private sealed class \u001C\u001B
		{
			// Token: 0x0600533A RID: 21306 RVA: 0x001EC148 File Offset: 0x001EA348
			internal bool \u000A(SelectionParameter \u001F)
			{
				if (\u000A\u0003\u0016.\u001D(\u001F) != \u000A\u0003\u0016.\u001D(\u0004\u0005\u0016.\u0007(this.\u001F)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.\u001C\u001B.\u000A(SelectionParameter)).MethodHandle;
					}
					return false;
				}
				if (\u0008\u000F\u0016.\u0007(\u0004\u0005\u0016.\u0007(this.\u001F)) == -1L)
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
					return \u0008\u0013\u000A.\u000A(\u001F\u0016\u0016.\u0007(\u0004\u0005\u0016.\u0007(this.\u001F)), \u001F\u0016\u0016.\u0007(\u001F));
				}
				return \u0008\u000F\u0016.\u0007(\u0004\u0005\u0016.\u0007(this.\u001F)) == \u0008\u000F\u0016.\u0007(\u001F);
			}

			// Token: 0x040024F0 RID: 9456
			public ParameterModel \u001F;
		}

		// Token: 0x02000994 RID: 2452
		[CompilerGenerated]
		private sealed class \u000D\u001B
		{
			// Token: 0x0600533C RID: 21308 RVA: 0x001EC200 File Offset: 0x001EA400
			internal bool \u0007(RevisionData \u001F)
			{
				if (\u0008\u0013\u000A.\u000A(\u0011\u0004\u0016.\u0007(\u001F), \u0011\u0004\u0016.\u0007(this.\u001F)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.\u000D\u001B.\u0007(RevisionData)).MethodHandle;
					}
					if (\u000B\u0003\u0016.\u001D(\u001F) == \u000B\u0003\u0016.\u001D(this.\u001F))
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
						return \u0008\u0013\u000A.\u000A(\u0020\u0003\u0016.\u000A(\u001F), \u0020\u0003\u0016.\u000A(this.\u001F));
					}
				}
				return false;
			}

			// Token: 0x040024F1 RID: 9457
			public RevisionData \u001F;

			// Token: 0x040024F2 RID: 9458
			public Func<RevisionData, bool> \u000A;
		}

		// Token: 0x02000995 RID: 2453
		[CompilerGenerated]
		private sealed class \u0010\u001B
		{
			// Token: 0x0600533E RID: 21310 RVA: 0x001EC294 File Offset: 0x001EA494
			internal bool \u000A(SelectionParameter \u001F)
			{
				return !Enumerable.Contains<SelectionParameter>(this.\u001F, \u001F);
			}

			// Token: 0x040024F3 RID: 9459
			public IEnumerable<SelectionParameter> \u001F;
		}
	}
}
