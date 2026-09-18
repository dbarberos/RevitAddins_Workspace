using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.SheetGen.Models;
using DiRoots.Revit.DataCollectors;

namespace DiRoots.One.SheetGen.Data
{
	// Token: 0x02000355 RID: 853
	public class Collector : IDisposable
	{
		// Token: 0x0600238D RID: 9101 RVA: 0x000DB838 File Offset: 0x000D9A38
		protected Collector()
		{
		}

		// Token: 0x170009DB RID: 2523
		// (get) Token: 0x0600238E RID: 9102 RVA: 0x000DB84C File Offset: 0x000D9A4C
		internal static Collector \u0004
		{
			get
			{
				Collector result;
				if ((result = Collector.\u001F) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Collector.get_\u0004()).MethodHandle;
					}
					result = (Collector.\u001F = \u001B\u0014\u000B.\u000A());
				}
				return result;
			}
		}

		// Token: 0x170009DC RID: 2524
		// (get) Token: 0x0600238F RID: 9103 RVA: 0x000DB884 File Offset: 0x000D9A84
		// (set) Token: 0x06002390 RID: 9104 RVA: 0x000DB898 File Offset: 0x000D9A98
		public Dictionary<ViewType, List<ViewData>> ViewsData { get; private set; }

		// Token: 0x170009DD RID: 2525
		// (get) Token: 0x06002391 RID: 9105 RVA: 0x000DB8AC File Offset: 0x000D9AAC
		// (set) Token: 0x06002392 RID: 9106 RVA: 0x000DB8C0 File Offset: 0x000D9AC0
		public List<ViewTemplate> Schedules { get; private set; }

		// Token: 0x170009DE RID: 2526
		// (get) Token: 0x06002393 RID: 9107 RVA: 0x000DB8D4 File Offset: 0x000D9AD4
		// (set) Token: 0x06002394 RID: 9108 RVA: 0x000DB8E8 File Offset: 0x000D9AE8
		public List<ViewTemplate> PanelSchedules { get; private set; }

		// Token: 0x06002395 RID: 9109 RVA: 0x000DB8FC File Offset: 0x000D9AFC
		public void Init()
		{
			\u0014\u0014\u000B.\u000A(this, \u0013\u0014\u000B.\u000A());
			List<View> u000A = Enumerable.ToList<View>(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004).CollectElementsOfCategory(-2000279L, null));
			IEnumerator u001F = \u0017\u0014\u000B.\u000A(\u000D\u0011\u001D.\u000A(\u001E\u0011\u000A.\u000A(\u0009\u0010\u000E.\u001F())));
			try
			{
				while (\u000A\u0017\u000A.\u000A(u001F))
				{
					ViewType viewType = \u001F\u000E\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F));
					\u0020\u0014\u000B.\u000A(\u000E\u0002\u0016.\u001D(this), viewType, this.\u0005(viewType, u000A));
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Collector.Init()).MethodHandle;
				}
			}
			finally
			{
				IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F);
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
					\u001F\u0017\u000A.\u000A(disposable);
				}
			}
			\u001E\u0014\u000B.\u000A(this, Collector.\u000B());
			\u0011\u0014\u000B.\u000A(this, Collector.\u0016());
		}

		// Token: 0x06002396 RID: 9110 RVA: 0x000DB9E8 File Offset: 0x000D9BE8
		internal void \u0019(View \u001F)
		{
			Element element;
			if (!\u001B\u001B\u001D.\u000A(\u0011\u0002\u0016.\u000A(\u001F), \u0012\u0015\u0010.\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Collector.\u0019(View)).MethodHandle;
				}
				element = \u0007\u000B\u000E.\u001F;
			}
			else
			{
				element = \u0011\u0017\u000A.\u0007(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004), \u0011\u0002\u0016.\u000A(\u001F));
			}
			Element element2 = element;
			ViewData viewData = \u0014\u0002\u0016.\u000A();
			\u0017\u0002\u0016.\u000A(viewData, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F)));
			\u0020\u0002\u0016.\u0007(viewData, \u0005\u001E\u000A.\u000A(\u001F));
			\u001E\u0002\u0016.\u000A(viewData, \u001C\u001C\u0007.\u0007(\u001F));
			string u000A;
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
				u000A = \u000F\u0015\u0010.\u001F;
			}
			else
			{
				u000A = \u0005\u001E\u000A.\u000A(element2);
			}
			\u001B\u0002\u0016.\u0007(viewData, u000A);
			ViewData u000A2 = viewData;
			if (\u001C\u001C\u0007.\u0007(\u001F) == 5)
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
				if (!\u0008\u0002\u0016.\u000A(\u0001\u001D\u000E.\u001F(\u001F)))
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
					\u000D\u0002\u0016.\u000A(\u0010\u0002\u0016.\u000A(\u000E\u0002\u0016.\u001D(this), \u001C\u001C\u0007.\u0007(\u001F)), u000A2);
					return;
				}
			}
			else
			{
				\u000D\u0002\u0016.\u000A(\u0010\u0002\u0016.\u000A(\u000E\u0002\u0016.\u001D(this), \u001C\u001C\u0007.\u0007(\u001F)), u000A2);
			}
		}

		// Token: 0x06002397 RID: 9111 RVA: 0x000DBB0C File Offset: 0x000D9D0C
		internal void \u0018(View \u001F)
		{
			Collector.\u0012\u0014 u0012_u = new Collector.\u0012\u0014();
			u0012_u.\u001F = \u001F;
			if (!Enumerable.Any<ViewData>(\u0010\u0002\u0016.\u000A(\u000E\u0002\u0016.\u001D(this), \u001C\u001C\u0007.\u0007(u0012_u.\u001F)), new Func<ViewData, bool>(u0012_u.\u000A)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Collector.\u0018(View)).MethodHandle;
				}
				this.\u0019(u0012_u.\u001F);
			}
		}

		// Token: 0x06002398 RID: 9112 RVA: 0x000DBB78 File Offset: 0x000D9D78
		private List<ViewData> \u0005(ViewType \u001F, List<View> \u000A)
		{
			List<ViewData> list = \u0001\u0014\u000B.\u000A();
			Document document = \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004);
			if (\u001F == 5)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Collector.\u0005(ViewType, List<View>)).MethodHandle;
				}
				\u000A = Enumerable.ToList<View>(Enumerable.Cast<View>(document.CollectElements(null)));
			}
			else if (\u001F == 123)
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
				\u000A = Enumerable.ToList<View>(Enumerable.Cast<View>(document.CollectElements(null)));
			}
			List<View>.Enumerator enumerator = \u0018\u0010\u0007.\u000A(\u000A);
			try
			{
				while (\u0007\u0010\u0007.\u000A(ref enumerator))
				{
					View u001F = \u0019\u0010\u0007.\u000A(ref enumerator);
					if (\u001C\u001C\u0007.\u0007(u001F) == \u001F)
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
						if (!\u000C\u0009\u001D.\u000A(u001F))
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
							ViewData viewData = \u0014\u0002\u0016.\u000A();
							\u0017\u0002\u0016.\u000A(viewData, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F)));
							\u0020\u0002\u0016.\u0007(viewData, \u0005\u001E\u000A.\u000A(u001F));
							\u001E\u0002\u0016.\u000A(viewData, \u001F);
							ViewData viewData2 = viewData;
							if (\u001B\u001B\u001D.\u000A(\u0011\u0002\u0016.\u000A(u001F), \u0012\u0015\u0010.\u001F))
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
								Element element = \u0011\u0017\u000A.\u0007(document, \u0011\u0002\u0016.\u000A(u001F));
								if (element != null)
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
									\u001B\u0002\u0016.\u0007(viewData2, \u0005\u001E\u000A.\u000A(element));
								}
							}
							ViewSchedule viewSchedule = \u0001\u001D\u000E.\u001F(u001F);
							if (viewSchedule != null)
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
								if (!\u0008\u0002\u0016.\u000A(viewSchedule))
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
									if (!\u0015\u0014\u000B.\u000A(viewSchedule))
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
										\u000D\u0002\u0016.\u000A(list, viewData2);
									}
								}
							}
							else
							{
								\u000D\u0002\u0016.\u000A(list, viewData2);
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
			object u001F2 = list;
			Comparison<ViewData> u000A;
			if ((u000A = Collector.<>c.\u000A) == null)
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
				u000A = (Collector.<>c.\u000A = new Comparison<ViewData>(Collector.<>c.\u001F.\u0007));
			}
			\u000C\u0014\u000B.\u000A(u001F2, u000A);
			object u001F3 = list;
			int u000A2 = 0;
			ViewData viewData3 = \u0014\u0002\u0016.\u000A();
			\u001E\u0002\u0016.\u000A(viewData3, \u001F);
			\u001A\u0014\u000B.\u000A(u001F3, u000A2, viewData3);
			return list;
		}

		// Token: 0x06002399 RID: 9113 RVA: 0x000DBDA4 File Offset: 0x000D9FA4
		internal static List<ViewTemplate> \u0016()
		{
			List<ViewTemplate> list = \u0006\u000E\u0016.\u000A();
			List<PanelScheduleSheetInstance>.Enumerator enumerator = \u0007\u0013\u000B.\u000A(\u000E\u0013.\u001F<PanelScheduleSheetInstance>(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004)));
			try
			{
				while (\u0009\u0014\u000B.\u000A(ref enumerator))
				{
					PanelScheduleSheetInstance u001F = \u000A\u0013\u000B.\u000A(ref enumerator);
					Element element = \u0011\u0017\u000A.\u0007(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004), \u0017\u0008\u0018.\u000A(u001F));
					if (element != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(Collector.\u0016()).MethodHandle;
						}
						ViewSheet viewSheet = \u0015\u001D\u000E.\u001F(element);
						\u0002\u0004\u0007.\u000A(u001F, viewSheet);
						ElementId elementId = \u0020\u000E\u0016.\u000A(u001F);
						if (!\u0011\u0016\u001D.\u000A(elementId, Constants.InvalidElementId))
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
							View u001F2 = \u0005\u001F\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004), elementId));
							ViewportStoredData viewportStoredData = u001F.\u000A<ViewportStoredData>();
							ViewTemplate viewTemplate = \u001E\u000E\u0016.\u000A();
							\u0016\u000E\u0016.\u0007(viewTemplate, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F2)));
							\u001B\u000E\u0016.\u0007(viewTemplate, \u000B\u001E\u000A.\u000A(\u0004\u0013\u0007.\u000A(u001F)));
							\u0011\u000E\u0016.\u0007(viewTemplate, \u001C\u001C\u0007.\u0007(u001F2));
							\u0005\u000E\u0016.\u0007(viewTemplate, \u0005\u001E\u000A.\u000A(u001F));
							string text;
							if (viewportStoredData == null)
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
									switch (3)
									{
									case 0:
										continue;
									}
									break;
								}
								u000A = "";
							}
							\u000E\u000E\u0016.\u0007(viewTemplate, u000A);
							\u0008\u000E\u0016.\u0007(viewTemplate, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F)));
							\u001F\u0013\u000B.\u000A(viewTemplate, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(viewSheet)));
							ViewTemplate u000A2 = viewTemplate;
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
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x0600239A RID: 9114 RVA: 0x000DBF80 File Offset: 0x000DA180
		internal static List<ViewTemplate> \u000B()
		{
			List<ViewTemplate> list = \u0006\u000E\u0016.\u000A();
			Document document = \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004);
			IEnumerator<ScheduleSheetInstance> enumerator = \u0015\u000E\u0016.\u000A(document.CollectElements(null));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ScheduleSheetInstance u001F = \u000C\u000E\u0016.\u000A(enumerator);
					if (!\u001A\u000E\u0016.\u000A(u001F))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(Collector.\u000B()).MethodHandle;
						}
						if (!\u0011\u0016\u001D.\u000A(\u0018\u0011\u001D.\u000A(u001F), Constants.InvalidElementId))
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
							Element element = \u0011\u0017\u000A.\u0007(document, \u0017\u0008\u0018.\u000A(u001F));
							if (element != null)
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
								ViewSheet u001F2 = \u0015\u001D\u000E.\u001F(element);
								ViewSchedule u000A = \u0001\u001D\u000E.\u001F(\u0011\u0017\u000A.\u0007(document, \u0018\u0011\u001D.\u000A(u001F)));
								ViewTemplate viewTemplate = \u0013\u000E\u0016.\u000A(u001F, u000A, true);
								\u001F\u0013\u000B.\u000A(viewTemplate, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F2)));
								ViewTemplate u000A2 = viewTemplate;
								\u0015\u0010\u0016.\u000A(list, u000A2);
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
			return list;
		}

		// Token: 0x0600239B RID: 9115 RVA: 0x000DC0B0 File Offset: 0x000DA2B0
		public void Dispose()
		{
			Collector.\u001F = \u0001\u0010\u000E.\u001F;
		}

		// Token: 0x04000E0A RID: 3594
		private static Collector \u001F;

		// Token: 0x04000E0B RID: 3595
		[CompilerGenerated]
		private Dictionary<ViewType, List<ViewData>> \u000A;

		// Token: 0x04000E0C RID: 3596
		[CompilerGenerated]
		private List<ViewTemplate> \u0007;

		// Token: 0x04000E0D RID: 3597
		[CompilerGenerated]
		private List<ViewTemplate> \u001D;

		// Token: 0x02000A41 RID: 2625
		[CompilerGenerated]
		private sealed class \u0012\u0014
		{
			// Token: 0x060055D5 RID: 21973 RVA: 0x001F2178 File Offset: 0x001F0378
			internal bool \u000A(ViewData \u001F)
			{
				return \u000B\u0019\u0016.\u0007(\u001F) == \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(this.\u001F));
			}

			// Token: 0x040026FC RID: 9980
			public View \u001F;
		}
	}
}
