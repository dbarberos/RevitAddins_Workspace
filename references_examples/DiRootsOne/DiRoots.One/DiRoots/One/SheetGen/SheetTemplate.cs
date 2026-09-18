using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.SheetGen.Core.Services;
using DiRoots.One.SheetGen.Data;
using DiRoots.One.SheetGen.Models;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002BF RID: 703
	public class SheetTemplate
	{
		// Token: 0x06001C44 RID: 7236 RVA: 0x000B47BC File Offset: 0x000B29BC
		public SheetTemplate()
		{
		}

		// Token: 0x06001C45 RID: 7237 RVA: 0x000B47F0 File Offset: 0x000B29F0
		public SheetTemplate(ViewSheet viewSheet, bool setTitleBlockName = true)
		{
			ElementId u001F = \u000C\u0010\u0016.\u000A(viewSheet);
			bool u000A;
			if (\u001B\u001B\u001D.\u000A(u001F, \u0012\u0015\u0010.\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetTemplate..ctor(ViewSheet, bool)).MethodHandle;
				}
				u000A = \u001B\u001B\u001D.\u000A(u001F, Constants.InvalidElementId);
			}
			else
			{
				u000A = false;
			}
			\u001A\u0010\u0016.\u0007(this, u000A);
			\u0013\u0010\u0016.\u0007(this, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(viewSheet)));
			\u0014\u0010\u0016.\u0007(this, \u0020\u0008\u001D.\u000A(viewSheet));
			\u0017\u0010\u0016.\u0007(this, \u0002\u0013\u000A.\u000A(\u0011\u0010\u0016.\u0007(this), " - ", \u0005\u001E\u000A.\u000A(viewSheet)));
			List<FamilyInstance> list = viewSheet.\u0006();
			FamilyInstance familyInstance = Enumerable.LastOrDefault<FamilyInstance>(list);
			FamilySymbol familySymbol;
			if (familyInstance == null)
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
				familySymbol = \u0019\u001C\u000E.\u001F;
			}
			else
			{
				familySymbol = \u001C\u001B\u0018.\u0007(familyInstance);
			}
			FamilySymbol familySymbol2 = familySymbol;
			long u000A2;
			if (familySymbol2 == null)
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
				u000A2 = 0L;
			}
			else
			{
				u000A2 = \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(familySymbol2));
			}
			\u0020\u000D\u0016.\u001D(this, u000A2);
			IEnumerable<FamilyInstance> enumerable = Enumerable.Take<FamilyInstance>(list, \u000B\u0015\u0004.\u000A(0, \u000C\u000F\u0016.\u000A(list) - 1));
			Func<FamilyInstance, Tuple<ElementId, ElementId>> func;
			if ((func = SheetTemplate.<>c.\u000A) == null)
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
				func = (SheetTemplate.<>c.\u000A = new Func<FamilyInstance, Tuple<ElementId, ElementId>>(SheetTemplate.<>c.\u001F.\u0004));
			}
			\u0011\u000D\u0016.\u001D(this, Enumerable.ToList<Tuple<ElementId, ElementId>>(Enumerable.Select<FamilyInstance, Tuple<ElementId, ElementId>>(enumerable, func)));
			if (setTitleBlockName)
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
				string u001F2 = "<";
				string u000A3;
				if (familySymbol2 == null)
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
					u000A3 = "None";
				}
				else
				{
					u000A3 = \u0001\u0015\u0018.\u0007(familySymbol2);
				}
				\u001B\u000D\u0016.\u001D(this, \u0002\u0013\u000A.\u000A(u001F2, u000A3, ">"));
			}
		}

		// Token: 0x170007DF RID: 2015
		// (get) Token: 0x06001C46 RID: 7238 RVA: 0x000B4994 File Offset: 0x000B2B94
		// (set) Token: 0x06001C47 RID: 7239 RVA: 0x000B49A8 File Offset: 0x000B2BA8
		internal static SheetTemplate CurrentTemplate { get; set; }

		// Token: 0x170007E0 RID: 2016
		// (get) Token: 0x06001C48 RID: 7240 RVA: 0x000B49BC File Offset: 0x000B2BBC
		// (set) Token: 0x06001C49 RID: 7241 RVA: 0x000B49D0 File Offset: 0x000B2BD0
		public long SheetId { get; set; }

		// Token: 0x170007E1 RID: 2017
		// (get) Token: 0x06001C4A RID: 7242 RVA: 0x000B49E4 File Offset: 0x000B2BE4
		// (set) Token: 0x06001C4B RID: 7243 RVA: 0x000B49F8 File Offset: 0x000B2BF8
		public long PlaceholderSheetId { get; set; } = -1L;

		// Token: 0x170007E2 RID: 2018
		// (get) Token: 0x06001C4C RID: 7244 RVA: 0x000B4A0C File Offset: 0x000B2C0C
		// (set) Token: 0x06001C4D RID: 7245 RVA: 0x000B4A20 File Offset: 0x000B2C20
		public string SheetNumber { get; set; }

		// Token: 0x170007E3 RID: 2019
		// (get) Token: 0x06001C4E RID: 7246 RVA: 0x000B4A34 File Offset: 0x000B2C34
		// (set) Token: 0x06001C4F RID: 7247 RVA: 0x000B4A48 File Offset: 0x000B2C48
		public string SheetText { get; set; }

		// Token: 0x170007E4 RID: 2020
		// (get) Token: 0x06001C50 RID: 7248 RVA: 0x000B4A5C File Offset: 0x000B2C5C
		// (set) Token: 0x06001C51 RID: 7249 RVA: 0x000B4A70 File Offset: 0x000B2C70
		public List<ViewTemplate> Views { get; set; } = new List<ViewTemplate>();

		// Token: 0x170007E5 RID: 2021
		// (get) Token: 0x06001C52 RID: 7250 RVA: 0x000B4A84 File Offset: 0x000B2C84
		// (set) Token: 0x06001C53 RID: 7251 RVA: 0x000B4A98 File Offset: 0x000B2C98
		public long TitleBlockId { get; set; }

		// Token: 0x170007E6 RID: 2022
		// (get) Token: 0x06001C54 RID: 7252 RVA: 0x000B4AAC File Offset: 0x000B2CAC
		// (set) Token: 0x06001C55 RID: 7253 RVA: 0x000B4AC0 File Offset: 0x000B2CC0
		public List<Tuple<ElementId, ElementId>> OtherTitleBlockIds { get; set; } = new List<Tuple<ElementId, ElementId>>();

		// Token: 0x170007E7 RID: 2023
		// (get) Token: 0x06001C56 RID: 7254 RVA: 0x000B4AD4 File Offset: 0x000B2CD4
		// (set) Token: 0x06001C57 RID: 7255 RVA: 0x000B4AE8 File Offset: 0x000B2CE8
		public string TitleBlockName { get; set; }

		// Token: 0x170007E8 RID: 2024
		// (get) Token: 0x06001C58 RID: 7256 RVA: 0x000B4AFC File Offset: 0x000B2CFC
		// (set) Token: 0x06001C59 RID: 7257 RVA: 0x000B4B10 File Offset: 0x000B2D10
		public bool IsAssemblySheet { get; set; }

		// Token: 0x06001C5A RID: 7258 RVA: 0x000B4B24 File Offset: 0x000B2D24
		public void AddViews(params IEnumerable<ViewTemplate>[] views)
		{
			Func<IEnumerable<ViewTemplate>, IEnumerable<ViewTemplate>> func;
			if ((func = SheetTemplate.<>c.\u0007) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetTemplate.AddViews(IEnumerable<ViewTemplate>[])).MethodHandle;
				}
				func = (SheetTemplate.<>c.\u0007 = new Func<IEnumerable<ViewTemplate>, IEnumerable<ViewTemplate>>(SheetTemplate.<>c.\u001F.\u0019));
			}
			IEnumerator<ViewTemplate> enumerator = \u0009\u0010\u0016.\u000A(Enumerable.SelectMany<IEnumerable<ViewTemplate>, ViewTemplate>(views, func));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ViewTemplate u000A = \u0001\u0010\u0016.\u000A(enumerator);
					\u0015\u0010\u0016.\u000A(\u000E\u0007\u0016.\u001D(this), u000A);
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

		// Token: 0x06001C5B RID: 7259 RVA: 0x000B4BC8 File Offset: 0x000B2DC8
		public void AddViews(IEnumerable<ViewTemplate> views)
		{
			IEnumerator<ViewTemplate> enumerator = \u0009\u0010\u0016.\u000A(views);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ViewTemplate viewTemplate = \u0001\u0010\u0016.\u000A(enumerator);
					\u001F\u000E\u0016.\u0007(viewTemplate, SheetTemplate.\u0003(\u000A\u000E\u0016.\u000A(\u000E\u0007\u0016.\u001D(this)) + 1));
					\u0015\u0010\u0016.\u000A(\u000E\u0007\u0016.\u001D(this), viewTemplate);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetTemplate.AddViews(IEnumerable<ViewTemplate>)).MethodHandle;
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

		// Token: 0x06001C5C RID: 7260 RVA: 0x000B4C58 File Offset: 0x000B2E58
		internal static SheetTemplate \u0002(ViewSheet \u001F, List<ViewTemplate> \u000A, List<ViewTemplate> \u0007)
		{
			SheetTemplate.\u000E\u001B u000E_u001B = new SheetTemplate.\u000E\u001B();
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetTemplate.\u0002(ViewSheet, List<ViewTemplate>, List<ViewTemplate>)).MethodHandle;
				}
				return \u0019\u000E\u0016.\u000A();
			}
			Document u001F = \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004);
			u000E_u001B.\u001F = \u001F.\u000A<SheetStoredData>();
			SheetTemplate sheetTemplate = \u0019\u000E\u0016.\u000A();
			\u0013\u0010\u0016.\u001D(sheetTemplate, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F)));
			bool u000A;
			if (\u001B\u001B\u001D.\u000A(\u000C\u0010\u0016.\u000A(\u001F), \u0012\u0015\u0010.\u001F))
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
				u000A = \u001B\u001B\u001D.\u000A(\u000C\u0010\u0016.\u000A(\u001F), Constants.InvalidElementId);
			}
			else
			{
				u000A = false;
			}
			\u001A\u0010\u0016.\u001D(sheetTemplate, u000A);
			\u0017\u0010\u0016.\u001D(sheetTemplate, \u0002\u0013\u000A.\u000A(\u0020\u0008\u001D.\u000A(\u001F), " - ", \u0005\u001E\u000A.\u000A(\u001F)));
			\u0014\u0010\u0016.\u001D(sheetTemplate, \u0020\u0008\u001D.\u000A(\u001F));
			SheetTemplate sheetTemplate2 = sheetTemplate;
			object u001F2 = sheetTemplate2;
			IEnumerable<ViewTemplate>[] array = \u0004\u001C\u000E.\u001F(2);
			array[0] = \u000A;
			array[1] = \u0007;
			\u0004\u000E\u0016.\u000A(u001F2, array);
			\u001D\u000E\u0016.\u000A(\u000E\u0007\u0016.\u0007(sheetTemplate2), SheetTemplate.\u000E(u001F, \u001F, true));
			if (u000E_u001B.\u001F != null)
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
				\u0007\u000E\u0016.\u000A(sheetTemplate2, Enumerable.ToList<ViewTemplate>(Enumerable.OrderBy<ViewTemplate, int>(\u000E\u0007\u0016.\u0007(sheetTemplate2), new Func<ViewTemplate, int>(u000E_u001B.\u000A))));
			}
			SheetTemplate.\u0003(\u000E\u0007\u0016.\u0007(sheetTemplate2));
			return sheetTemplate2;
		}

		// Token: 0x06001C5D RID: 7261 RVA: 0x000B4DA8 File Offset: 0x000B2FA8
		internal static SheetTemplate \u0006(long \u001F, IEnumerable<ViewInfo> \u000A, ViewInfoCollector \u0007 = null, bool \u001D = false)
		{
			Document u001F = \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004);
			ViewSheet viewSheet = \u0015\u001D\u000E.\u001F(\u0007\u0018\u0016.\u000A(u001F, \u001F));
			if (viewSheet == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetTemplate.\u0006(long, IEnumerable<ViewInfo>, ViewInfoCollector, bool)).MethodHandle;
				}
				return \u0019\u000E\u0016.\u000A();
			}
			if (\u0007 == null)
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
				\u0007 = \u000E\u0005\u0016.\u000A(u001F);
			}
			SheetTemplate sheetTemplate = SheetTemplate.\u001C(u001F, viewSheet, \u0007);
			List<ViewTemplate> list = \u0006\u000E\u0016.\u000A();
			IEnumerator<ViewInfo> enumerator = \u0002\u000E\u0016.\u000A(\u000A);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					SheetTemplate.\u0008\u001B u0008_u001B = new SheetTemplate.\u0008\u001B();
					u0008_u001B.\u001F = \u000B\u000E\u0016.\u000A(enumerator);
					ViewTemplate viewTemplate = Enumerable.FirstOrDefault<ViewTemplate>(\u000E\u0007\u0016.\u0007(sheetTemplate), new Func<ViewTemplate, bool>(u0008_u001B.\u000A));
					if (viewTemplate != null)
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
						if (\u001D)
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
							\u0016\u000E\u0016.\u0007(viewTemplate, 0L);
							\u0005\u000E\u0016.\u0007(viewTemplate, \u000A\u0012\u0016.\u000A());
						}
						\u0015\u0010\u0016.\u000A(list, viewTemplate);
					}
					else
					{
						ViewTemplate u000A = \u0018\u000E\u0016.\u000A(u0008_u001B.\u001F);
						\u0015\u0010\u0016.\u000A(list, u000A);
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			\u0007\u000E\u0016.\u000A(sheetTemplate, Enumerable.ToList<ViewTemplate>(list));
			SheetTemplate.\u0003(\u000E\u0007\u0016.\u0007(sheetTemplate));
			return sheetTemplate;
		}

		// Token: 0x06001C5E RID: 7262 RVA: 0x000B4F14 File Offset: 0x000B3114
		internal static SheetTemplate \u000F(long \u001F, long \u000A, IEnumerable<ViewInfo> \u0007, ViewInfoCollector \u001D = null)
		{
			Document u001F = \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004);
			SheetTemplate sheetTemplate = SheetTemplate.\u0006(\u001F, \u0007, \u001D, false);
			ViewSheet viewSheet = \u0015\u001D\u000E.\u001F(\u0007\u0018\u0016.\u000A(u001F, \u000A));
			if (viewSheet != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetTemplate.\u000F(long, long, IEnumerable<ViewInfo>, ViewInfoCollector)).MethodHandle;
				}
				\u000F\u000E\u0016.\u000A(sheetTemplate, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(viewSheet)));
				\u0014\u0010\u0016.\u001D(sheetTemplate, \u0020\u0008\u001D.\u000A(viewSheet));
				\u0017\u0010\u0016.\u001D(sheetTemplate, \u0002\u0013\u000A.\u000A(\u0020\u0008\u001D.\u000A(viewSheet), " - ", \u0005\u001E\u000A.\u000A(viewSheet)));
			}
			return sheetTemplate;
		}

		// Token: 0x06001C5F RID: 7263 RVA: 0x000B4FA8 File Offset: 0x000B31A8
		internal static SheetTemplate \u0006(long \u001F, IEnumerable<ViewTemplate> \u000A, ViewInfoCollector \u0007 = null)
		{
			Document u001F = \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004);
			ViewSheet viewSheet = \u0015\u001D\u000E.\u001F(SheetAndViewCreationHelper.\u0004(u001F, \u001F));
			if (viewSheet == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetTemplate.\u0006(long, IEnumerable<ViewTemplate>, ViewInfoCollector)).MethodHandle;
				}
				return \u0019\u000E\u0016.\u000A();
			}
			if (\u0007 == null)
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
				\u0007 = \u000E\u0005\u0016.\u000A(u001F);
			}
			SheetTemplate sheetTemplate = SheetTemplate.\u001C(u001F, viewSheet, \u0007);
			List<ViewTemplate> list = \u0006\u000E\u0016.\u000A();
			int num = 0;
			IEnumerator<ViewTemplate> enumerator = \u0009\u0010\u0016.\u000A(\u000A);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					SheetTemplate.\u001B\u001B u001B_u001B = new SheetTemplate.\u001B\u001B();
					u001B_u001B.\u001F = \u0001\u0010\u0016.\u000A(enumerator);
					ViewTemplate viewTemplate = Enumerable.FirstOrDefault<ViewTemplate>(\u000E\u0007\u0016.\u0007(sheetTemplate), new Func<ViewTemplate, bool>(u001B_u001B.\u000A));
					if (viewTemplate != null)
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
						\u0015\u0010\u0016.\u000A(list, viewTemplate);
					}
					else
					{
						ViewTemplate u000A = \u0012\u000E\u0016.\u000A(u001B_u001B.\u001F);
						\u0015\u0010\u0016.\u000A(list, u000A);
					}
					num++;
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
			\u0007\u000E\u0016.\u000A(sheetTemplate, Enumerable.ToList<ViewTemplate>(list));
			SheetTemplate.\u0003(\u000E\u0007\u0016.\u0007(sheetTemplate));
			return sheetTemplate;
		}

		// Token: 0x06001C60 RID: 7264 RVA: 0x000B50F4 File Offset: 0x000B32F4
		internal static SheetTemplate \u0012(long \u001F, ViewInfoCollector \u000A)
		{
			SheetTemplate.\u0011\u001B u0011_u001B = new SheetTemplate.\u0011\u001B();
			Document u001F = \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004);
			ViewSheet viewSheet = \u0015\u001D\u000E.\u001F(\u0007\u0018\u0016.\u000A(u001F, \u001F));
			if (viewSheet == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetTemplate.\u0012(long, ViewInfoCollector)).MethodHandle;
				}
				return \u0019\u000E\u0016.\u000A();
			}
			u0011_u001B.\u001F = viewSheet.\u000A<SheetStoredData>();
			SheetTemplate sheetTemplate = \u001C\u000E\u0016.\u000A(viewSheet, false);
			if (SheetAndViewCreationHelper.\u0004(u001F, \u0003\u000E\u0016.\u000A(sheetTemplate)) != null)
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
				List<Element> u000A = \u000A.\u001D(\u001B\u0007\u0016.\u0007(sheetTemplate));
				\u001D\u000E\u0016.\u000A(\u000E\u0007\u0016.\u0007(sheetTemplate), SheetTemplate.\u000D(u001F, u000A, true));
				\u001D\u000E\u0016.\u000A(\u000E\u0007\u0016.\u0007(sheetTemplate), SheetTemplate.\u0010(u001F, u000A, true));
			}
			\u001D\u000E\u0016.\u000A(\u000E\u0007\u0016.\u0007(sheetTemplate), SheetTemplate.\u000E(u001F, viewSheet, true));
			if (u0011_u001B.\u001F != null)
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
				\u0007\u000E\u0016.\u000A(sheetTemplate, Enumerable.ToList<ViewTemplate>(Enumerable.OrderBy<ViewTemplate, int>(\u000E\u0007\u0016.\u0007(sheetTemplate), new Func<ViewTemplate, int>(u0011_u001B.\u000A))));
			}
			SheetTemplate.\u0003(\u000E\u0007\u0016.\u0007(sheetTemplate));
			return sheetTemplate;
		}

		// Token: 0x06001C61 RID: 7265 RVA: 0x000B521C File Offset: 0x000B341C
		private static void \u0003(List<ViewTemplate> \u001F)
		{
			for (int i = 0; i < \u000A\u000E\u0016.\u000A(\u001F); i++)
			{
				\u001F\u000E\u0016.\u0007(\u000D\u000E\u0016.\u000A(\u001F, i), SheetTemplate.\u0003(i + 1));
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(SheetTemplate.\u0003(List<ViewTemplate>)).MethodHandle;
			}
		}

		// Token: 0x06001C62 RID: 7266 RVA: 0x000B5268 File Offset: 0x000B3468
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static string \u0003(int \u001F)
		{
			return \u0004\u001E\u000A.\u000A(\u0010\u000E\u0016.\u000A(), \u0003\u001F\u0019.\u000A(ref \u001F, "D2"));
		}

		// Token: 0x06001C63 RID: 7267 RVA: 0x000B5294 File Offset: 0x000B3494
		private static SheetTemplate \u001C(Document \u001F, ViewSheet \u000A, ViewInfoCollector \u0007)
		{
			SheetTemplate sheetTemplate = \u001C\u000E\u0016.\u000A(\u000A, true);
			if (\u0007\u0018\u0016.\u000A(\u001F, \u0003\u000E\u0016.\u000A(sheetTemplate)) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetTemplate.\u001C(Document, ViewSheet, ViewInfoCollector)).MethodHandle;
				}
				List<Element> u000A = \u0007.\u001D(\u001B\u0007\u0016.\u0007(sheetTemplate));
				\u001D\u000E\u0016.\u000A(\u000E\u0007\u0016.\u0007(sheetTemplate), SheetTemplate.\u000D(\u001F, u000A, false));
				\u001D\u000E\u0016.\u000A(\u000E\u0007\u0016.\u0007(sheetTemplate), SheetTemplate.\u0010(\u001F, u000A, false));
			}
			\u001D\u000E\u0016.\u000A(\u000E\u0007\u0016.\u0007(sheetTemplate), SheetTemplate.\u000E(\u001F, \u000A, true));
			return sheetTemplate;
		}

		// Token: 0x06001C64 RID: 7268 RVA: 0x000B5328 File Offset: 0x000B3528
		private static List<ViewTemplate> \u000D(Document \u001F, List<Element> \u000A, bool \u0007)
		{
			List<ViewTemplate> list = \u0006\u000E\u0016.\u000A();
			IEnumerator<PanelScheduleSheetInstance> enumerator = \u0014\u000E\u0016.\u000A(Enumerable.OfType<PanelScheduleSheetInstance>(\u000A));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					PanelScheduleSheetInstance u001F = \u0017\u000E\u0016.\u000A(enumerator);
					ElementId elementId = \u0020\u000E\u0016.\u000A(u001F);
					if (!\u0011\u0016\u001D.\u000A(elementId, Constants.InvalidElementId))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SheetTemplate.\u000D(Document, List<Element>, bool)).MethodHandle;
						}
						Element u001F2 = \u0011\u0017\u000A.\u0007(\u001F, elementId);
						ViewTemplate viewTemplate = \u001E\u000E\u0016.\u000A();
						\u0016\u000E\u0016.\u0007(viewTemplate, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F2)));
						\u0011\u000E\u0016.\u0007(viewTemplate, \u001C\u001C\u0007.\u0007(\u0005\u001F\u000E.\u001F(u001F2)));
						\u001B\u000E\u0016.\u0007(viewTemplate, \u000B\u001E\u000A.\u000A(\u0004\u0013\u0007.\u000A(u001F)));
						\u0008\u000E\u0016.\u0007(viewTemplate, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F)));
						\u0005\u000E\u0016.\u0007(viewTemplate, \u0005\u001E\u000A.\u000A(u001F2));
						ViewTemplate viewTemplate2 = viewTemplate;
						if (\u0007)
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
							ViewportStoredData viewportStoredData = u001F.\u000A<ViewportStoredData>();
							object u001F3 = viewTemplate2;
							string text;
							if (viewportStoredData == null)
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
								text = null;
							}
							else
							{
								text = \u0008\u0019\u0016.\u001D(viewportStoredData);
							}
							string u000A;
							if ((u000A = text) == null)
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
								u000A = "";
							}
							\u000E\u000E\u0016.\u0007(u001F3, u000A);
						}
						\u0015\u0010\u0016.\u000A(list, viewTemplate2);
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
			return list;
		}

		// Token: 0x06001C65 RID: 7269 RVA: 0x000B54A0 File Offset: 0x000B36A0
		private static List<ViewTemplate> \u0010(Document \u001F, List<Element> \u000A, bool \u0007)
		{
			List<ViewTemplate> list = \u0006\u000E\u0016.\u000A();
			IEnumerator<ScheduleSheetInstance> enumerator = \u0015\u000E\u0016.\u000A(Enumerable.OfType<ScheduleSheetInstance>(\u000A));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ScheduleSheetInstance u001F = \u000C\u000E\u0016.\u000A(enumerator);
					if (!\u001A\u000E\u0016.\u000A(u001F))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SheetTemplate.\u0010(Document, List<Element>, bool)).MethodHandle;
						}
						ElementId elementId = \u0018\u0011\u001D.\u000A(u001F);
						if (!\u0011\u0016\u001D.\u000A(elementId, Constants.InvalidElementId))
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
							ViewSchedule u000A = \u0001\u001D\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u001F, elementId));
							ViewTemplate u000A2 = \u0013\u000E\u0016.\u000A(u001F, u000A, \u0007);
							\u0015\u0010\u0016.\u000A(list, u000A2);
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return list;
		}

		// Token: 0x06001C66 RID: 7270 RVA: 0x000B5574 File Offset: 0x000B3774
		private static List<ViewTemplate> \u000E(Document \u001F, ViewSheet \u000A, bool \u0007)
		{
			SheetTemplate.\u001E\u001B u001E_u001B = new SheetTemplate.\u001E\u001B();
			u001E_u001B.\u001F = \u001F;
			List<ViewTemplate> list = \u0006\u000E\u0016.\u000A();
			IEnumerable<Viewport> enumerable = Enumerable.Cast<Viewport>(Enumerable.Select<ElementId, Element>(\u000C\u0019\u0016.\u000A(\u000A), new Func<ElementId, Element>(u001E_u001B.\u000A)));
			Func<Viewport, bool> func;
			if ((func = SheetTemplate.<>c.\u001D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetTemplate.\u000E(Document, ViewSheet, bool)).MethodHandle;
				}
				func = (SheetTemplate.<>c.\u001D = new Func<Viewport, bool>(SheetTemplate.<>c.\u001F.\u0018));
			}
			IEnumerator<Viewport> enumerator = \u001F\u0008\u0016.\u000A(Enumerable.Where<Viewport>(enumerable, func));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ViewTemplate u000A = \u0001\u000E\u0016.\u000A(\u0009\u000E\u0016.\u000A(enumerator), \u0007);
					\u0015\u0010\u0016.\u000A(list, u000A);
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
			return list;
		}

		// Token: 0x04000B5E RID: 2910
		[CompilerGenerated]
		private static SheetTemplate \u001F;

		// Token: 0x04000B5F RID: 2911
		[CompilerGenerated]
		private long \u000A;

		// Token: 0x04000B60 RID: 2912
		[CompilerGenerated]
		private long \u0007;

		// Token: 0x04000B61 RID: 2913
		[CompilerGenerated]
		private string \u001D;

		// Token: 0x04000B62 RID: 2914
		[CompilerGenerated]
		private string \u0004;

		// Token: 0x04000B63 RID: 2915
		[CompilerGenerated]
		private List<ViewTemplate> \u0019;

		// Token: 0x04000B64 RID: 2916
		[CompilerGenerated]
		private long \u0018;

		// Token: 0x04000B65 RID: 2917
		[CompilerGenerated]
		private List<Tuple<ElementId, ElementId>> \u0005;

		// Token: 0x04000B66 RID: 2918
		[CompilerGenerated]
		private string \u0016;

		// Token: 0x04000B67 RID: 2919
		[CompilerGenerated]
		private bool \u000B;

		// Token: 0x02000997 RID: 2455
		[CompilerGenerated]
		private sealed class \u000E\u001B
		{
			// Token: 0x06005345 RID: 21317 RVA: 0x001EC34C File Offset: 0x001EA54C
			internal int \u000A(ViewTemplate \u001F)
			{
				return \u0009\u0013\u0007.\u000A(\u001B\u0019\u0016.\u000A(this.\u001F), \u000A\u0006\u0010.\u000A(\u001F));
			}

			// Token: 0x040024F8 RID: 9464
			public SheetStoredData \u001F;
		}

		// Token: 0x02000998 RID: 2456
		[CompilerGenerated]
		private sealed class \u0008\u001B
		{
			// Token: 0x06005347 RID: 21319 RVA: 0x001EC38C File Offset: 0x001EA58C
			internal bool \u000A(ViewTemplate \u001F)
			{
				return \u0020\u0016\u0002.\u000A(\u001F) == \u000B\u0019\u0016.\u0007(\u0002\u0019\u0016.\u0007(this.\u001F));
			}

			// Token: 0x040024F9 RID: 9465
			public ViewInfo \u001F;
		}

		// Token: 0x02000999 RID: 2457
		[CompilerGenerated]
		private sealed class \u001B\u001B
		{
			// Token: 0x06005349 RID: 21321 RVA: 0x001EC3CC File Offset: 0x001EA5CC
			internal bool \u000A(ViewTemplate \u001F)
			{
				return \u0020\u0016\u0002.\u000A(\u001F) == \u0020\u0016\u0002.\u000A(this.\u001F);
			}

			// Token: 0x040024FA RID: 9466
			public ViewTemplate \u001F;
		}

		// Token: 0x0200099A RID: 2458
		[CompilerGenerated]
		private sealed class \u0011\u001B
		{
			// Token: 0x0600534B RID: 21323 RVA: 0x001EC404 File Offset: 0x001EA604
			internal int \u000A(ViewTemplate \u001F)
			{
				return \u0009\u0013\u0007.\u000A(\u001B\u0019\u0016.\u000A(this.\u001F), \u000A\u0006\u0010.\u000A(\u001F));
			}

			// Token: 0x040024FB RID: 9467
			public SheetStoredData \u001F;
		}

		// Token: 0x0200099B RID: 2459
		[CompilerGenerated]
		private sealed class \u001E\u001B
		{
			// Token: 0x0600534D RID: 21325 RVA: 0x001EC444 File Offset: 0x001EA644
			internal Element \u000A(ElementId \u001F)
			{
				return \u0011\u0017\u000A.\u0007(this.\u001F, \u001F);
			}

			// Token: 0x040024FC RID: 9468
			public Document \u001F;
		}
	}
}
