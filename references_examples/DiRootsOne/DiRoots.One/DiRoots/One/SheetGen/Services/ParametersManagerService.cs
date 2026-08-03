using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.SheetGen.Helpers.Excel;
using DiRoots.One.SheetGen.Messaging;
using DiRoots.One.SheetGen.Models;
using DiRoots.Revit.DataCollectors;

namespace DiRoots.One.SheetGen.Services
{
	// Token: 0x02000317 RID: 791
	public class ParametersManagerService : IDisposable
	{
		// Token: 0x0600223B RID: 8763 RVA: 0x000D2914 File Offset: 0x000D0B14
		private ParametersManagerService()
		{
		}

		// Token: 0x170009A7 RID: 2471
		// (get) Token: 0x0600223C RID: 8764 RVA: 0x000D2928 File Offset: 0x000D0B28
		internal static ParametersManagerService \u0008
		{
			get
			{
				if (ParametersManagerService.\u001F == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.get_\u0008()).MethodHandle;
					}
					ParametersManagerService.\u001F = \u000D\u0010\u000B.\u000A();
				}
				return ParametersManagerService.\u001F;
			}
		}

		// Token: 0x170009A8 RID: 2472
		// (get) Token: 0x0600223D RID: 8765 RVA: 0x000D2960 File Offset: 0x000D0B60
		// (set) Token: 0x0600223E RID: 8766 RVA: 0x000D2974 File Offset: 0x000D0B74
		public List<SelectionParameter> SheetsUsedParameters { get; set; }

		// Token: 0x170009A9 RID: 2473
		// (get) Token: 0x0600223F RID: 8767 RVA: 0x000D2988 File Offset: 0x000D0B88
		// (set) Token: 0x06002240 RID: 8768 RVA: 0x000D299C File Offset: 0x000D0B9C
		public List<SelectionParameter> SheetsAvailableParameters { get; set; }

		// Token: 0x170009AA RID: 2474
		// (get) Token: 0x06002241 RID: 8769 RVA: 0x000D29B0 File Offset: 0x000D0BB0
		// (set) Token: 0x06002242 RID: 8770 RVA: 0x000D29C4 File Offset: 0x000D0BC4
		public List<SelectionParameter> PlaceholderSheetsUsedParameters { get; set; }

		// Token: 0x170009AB RID: 2475
		// (get) Token: 0x06002243 RID: 8771 RVA: 0x000D29D8 File Offset: 0x000D0BD8
		// (set) Token: 0x06002244 RID: 8772 RVA: 0x000D29EC File Offset: 0x000D0BEC
		public List<SelectionParameter> PlaceholderSheetsAvailableParameters { get; set; }

		// Token: 0x170009AC RID: 2476
		// (get) Token: 0x06002245 RID: 8773 RVA: 0x000D2A00 File Offset: 0x000D0C00
		// (set) Token: 0x06002246 RID: 8774 RVA: 0x000D2A14 File Offset: 0x000D0C14
		public List<SelectionParameter> SheetsBasicParams { get; set; }

		// Token: 0x170009AD RID: 2477
		// (get) Token: 0x06002247 RID: 8775 RVA: 0x000D2A28 File Offset: 0x000D0C28
		// (set) Token: 0x06002248 RID: 8776 RVA: 0x000D2A3C File Offset: 0x000D0C3C
		public List<SelectionParameter> AllSheetParams { get; set; }

		// Token: 0x170009AE RID: 2478
		// (get) Token: 0x06002249 RID: 8777 RVA: 0x000D2A50 File Offset: 0x000D0C50
		// (set) Token: 0x0600224A RID: 8778 RVA: 0x000D2A64 File Offset: 0x000D0C64
		public List<SelectionParameter> AllPlaceholderParams { get; set; }

		// Token: 0x170009AF RID: 2479
		// (get) Token: 0x0600224B RID: 8779 RVA: 0x000D2A78 File Offset: 0x000D0C78
		// (set) Token: 0x0600224C RID: 8780 RVA: 0x000D2A8C File Offset: 0x000D0C8C
		public List<SelectionParameter> AllPlaceholderParamsWithReadOnly { get; set; }

		// Token: 0x170009B0 RID: 2480
		// (get) Token: 0x0600224D RID: 8781 RVA: 0x000D2AA0 File Offset: 0x000D0CA0
		// (set) Token: 0x0600224E RID: 8782 RVA: 0x000D2AB4 File Offset: 0x000D0CB4
		public List<SelectionParameter> AllViewManagerParams { get; set; }

		// Token: 0x170009B1 RID: 2481
		// (get) Token: 0x0600224F RID: 8783 RVA: 0x000D2AC8 File Offset: 0x000D0CC8
		// (set) Token: 0x06002250 RID: 8784 RVA: 0x000D2ADC File Offset: 0x000D0CDC
		public List<SelectionParameter> ViewManagerUsedParameters { get; set; }

		// Token: 0x170009B2 RID: 2482
		// (get) Token: 0x06002251 RID: 8785 RVA: 0x000D2AF0 File Offset: 0x000D0CF0
		// (set) Token: 0x06002252 RID: 8786 RVA: 0x000D2B04 File Offset: 0x000D0D04
		public List<SelectionParameter> ViewManagerAvailableParameters { get; set; }

		// Token: 0x170009B3 RID: 2483
		// (get) Token: 0x06002253 RID: 8787 RVA: 0x000D2B18 File Offset: 0x000D0D18
		// (set) Token: 0x06002254 RID: 8788 RVA: 0x000D2B2C File Offset: 0x000D0D2C
		public List<SelectionParameter> SelectViewUsedParameters { get; set; }

		// Token: 0x170009B4 RID: 2484
		// (get) Token: 0x06002255 RID: 8789 RVA: 0x000D2B40 File Offset: 0x000D0D40
		// (set) Token: 0x06002256 RID: 8790 RVA: 0x000D2B54 File Offset: 0x000D0D54
		public List<SelectionParameter> SelectViewAvailableParameters { get; set; }

		// Token: 0x170009B5 RID: 2485
		// (get) Token: 0x06002257 RID: 8791 RVA: 0x000D2B68 File Offset: 0x000D0D68
		// (set) Token: 0x06002258 RID: 8792 RVA: 0x000D2B7C File Offset: 0x000D0D7C
		public List<RevisionParameter> RevisionsUsedParameters { get; set; }

		// Token: 0x170009B6 RID: 2486
		// (get) Token: 0x06002259 RID: 8793 RVA: 0x000D2B90 File Offset: 0x000D0D90
		// (set) Token: 0x0600225A RID: 8794 RVA: 0x000D2BA4 File Offset: 0x000D0DA4
		public List<RevisionParameter> RevisionsAvailableParameters { get; set; }

		// Token: 0x170009B7 RID: 2487
		// (get) Token: 0x0600225B RID: 8795 RVA: 0x000D2BB8 File Offset: 0x000D0DB8
		// (set) Token: 0x0600225C RID: 8796 RVA: 0x000D2BCC File Offset: 0x000D0DCC
		public List<List<RevisionParameter>> RevisionsParameters { get; set; }

		// Token: 0x170009B8 RID: 2488
		// (get) Token: 0x0600225D RID: 8797 RVA: 0x000D2BE0 File Offset: 0x000D0DE0
		// (set) Token: 0x0600225E RID: 8798 RVA: 0x000D2BF4 File Offset: 0x000D0DF4
		public List<RevisionParameter> AllRevisionParameters { get; set; }

		// Token: 0x0600225F RID: 8799 RVA: 0x000D2C08 File Offset: 0x000D0E08
		public void Init(Document doc)
		{
			this.\u000A = doc;
			this.\u001B();
			this.\u0011();
			this.\u001E();
			this.\u0013();
		}

		// Token: 0x06002260 RID: 8800 RVA: 0x000D2C34 File Offset: 0x000D0E34
		public void InitForViewsManager(Document doc)
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Services\\ParametersManagerService.cs", "InitForViewsManager");
			this.\u000A = doc;
			this.\u0014();
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Services\\ParametersManagerService.cs", "InitForViewsManager");
		}

		// Token: 0x06002261 RID: 8801 RVA: 0x000D2C7C File Offset: 0x000D0E7C
		public Profile GetProfileFromParametersState(bool _isViewModel)
		{
			if (_isViewModel)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.GetProfileFromParametersState(bool)).MethodHandle;
				}
				VMProfile vmprofile = \u0013\u0010\u000B.\u000A();
				List<List<SelectionParameter>> list = \u001E\u0010\u000B.\u000A(2);
				\u0011\u0010\u000B.\u000A(list, \u0020\u001B\u0016.\u001D(this));
				\u0011\u0010\u000B.\u000A(list, \u0016\u0016\u0016.\u000A());
				\u0014\u0010\u000B.\u000A(vmprofile, list);
				return vmprofile;
			}
			SGProfile sgprofile = \u0017\u0010\u000B.\u000A();
			List<List<SelectionParameter>> list2 = \u001E\u0010\u000B.\u000A(2);
			\u0011\u0010\u000B.\u000A(list2, \u0009\u000D\u0016.\u001D(this));
			\u0011\u0010\u000B.\u000A(list2, \u0016\u0016\u0016.\u000A());
			\u0020\u0010\u000B.\u000A(sgprofile, list2);
			List<List<SelectionParameter>> list3 = \u001E\u0010\u000B.\u000A(2);
			\u0011\u0010\u000B.\u000A(list3, \u000D\u0005\u000B.\u001D(this));
			\u0011\u0010\u000B.\u000A(list3, \u0016\u0016\u0016.\u000A());
			\u001B\u0010\u000B.\u000A(sgprofile, list3);
			List<List<RevisionParameter>> list4 = \u0008\u0010\u000B.\u000A(2);
			\u001F\u0002\u000B.\u000A(list4, \u000E\u001C\u0016.\u001D(this));
			\u001F\u0002\u000B.\u000A(list4, \u000E\u0010\u000B.\u000A());
			\u0010\u0010\u000B.\u000A(sgprofile, list4);
			return sgprofile;
		}

		// Token: 0x06002262 RID: 8802 RVA: 0x000D2D54 File Offset: 0x000D0F54
		private void \u001B()
		{
			List<SelectionParameter> list = \u0016\u0016\u0016.\u000A();
			\u0007\u000E\u000B.\u000A(this, this.\u000C());
			List<SelectionParameter> u000A = this.\u001A();
			\u001F\u000E\u000B.\u000A(list, \u000A\u000E\u000B.\u000A(this));
			\u001F\u000E\u000B.\u000A(list, u000A);
			object u001F = list;
			Comparison<SelectionParameter> u000A2;
			if ((u000A2 = ParametersManagerService.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.\u001B()).MethodHandle;
				}
				u000A2 = (ParametersManagerService.<>c.\u000A = new Comparison<SelectionParameter>(ParametersManagerService.<>c.\u001F.\u001A));
			}
			\u0009\u0010\u000B.\u000A(u001F, u000A2);
			\u0001\u0010\u000B.\u000A(this, list);
			List<List<SelectionParameter>> list2 = \u0015\u0010\u000B.\u000A(this);
			if (list2 != null)
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
				IEnumerable<List<SelectionParameter>> enumerable = list2;
				Func<List<SelectionParameter>, bool> func;
				if ((func = ParametersManagerService.<>c.\u0007) == null)
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
					func = (ParametersManagerService.<>c.\u0007 = new Func<List<SelectionParameter>, bool>(ParametersManagerService.<>c.\u001F.\u000C));
				}
				if (Enumerable.Count<List<SelectionParameter>>(enumerable, func) == 2)
				{
					List<SelectionParameter> list3 = \u0016\u0016\u0016.\u000A();
					List<SelectionParameter>.Enumerator enumerator = \u0001\u000D\u0016.\u000A(\u001A\u0010\u000B.\u000A(list2, 0));
					try
					{
						while (\u0014\u000D\u0016.\u000A(ref enumerator))
						{
							ParametersManagerService.\u0006\u0020 u0006_u = new ParametersManagerService.\u0006\u0020();
							u0006_u.\u001F = \u0015\u000D\u0016.\u000A(ref enumerator);
							SelectionParameter selectionParameter = Enumerable.FirstOrDefault<SelectionParameter>(list, new Func<SelectionParameter, bool>(u0006_u.\u000A));
							if (selectionParameter != null)
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
								\u000A\u0016\u0016.\u000A(list3, selectionParameter);
							}
							else
							{
								\u0005\u001B\u000A.\u0018.\u0019<SGReport>(SGReport.LT(u0006_u.\u001F, "Sheet Parameter"), Context.ReportingService);
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
					\u0005\u0018\u000B.\u001D(this, list3);
					\u0018\u0018\u000B.\u001D(this, Enumerable.ToList<SelectionParameter>(Enumerable.Except<SelectionParameter>(list, list3)));
					enumerator = \u0001\u000D\u0016.\u000A(Enumerable.Last<List<SelectionParameter>>(list2));
					try
					{
						while (\u0014\u000D\u0016.\u000A(ref enumerator))
						{
							ParametersManagerService.\u000F\u0020 u000F_u = new ParametersManagerService.\u000F\u0020();
							u000F_u.\u001F = \u0015\u000D\u0016.\u000A(ref enumerator);
							if (Enumerable.FirstOrDefault<SelectionParameter>(\u001E\u0007\u000B.\u001D(this), new Func<SelectionParameter, bool>(u000F_u.\u000A)) == null)
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
								\u0005\u001B\u000A.\u0018.\u0019<SGReport>(SGReport.LT(u000F_u.\u001F, "Sheet Parameter"), Context.ReportingService);
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
					goto IL_278;
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
			\u0005\u0018\u000B.\u001D(this, \u0016\u0016\u0016.\u000A());
			\u0018\u0018\u000B.\u001D(this, Enumerable.ToList<SelectionParameter>(list));
			List<List<SelectionParameter>> list4 = \u001E\u0010\u000B.\u000A(2);
			\u0011\u0010\u000B.\u000A(list4, \u0009\u000D\u0016.\u001D(this));
			\u0011\u0010\u000B.\u000A(list4, \u001E\u0007\u000B.\u001D(this));
			\u000C\u0010\u000B.\u000A(this, list4);
			IL_278:
			object u001F2 = \u0009\u000D\u0016.\u001D(this);
			Action<SelectionParameter> u000A3;
			if ((u000A3 = ParametersManagerService.<>c.\u001D) == null)
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
				u000A3 = (ParametersManagerService.<>c.\u001D = new Action<SelectionParameter>(ParametersManagerService.<>c.\u001F.\u0015));
			}
			\u001E\u000F\u000B.\u000A(u001F2, u000A3);
		}

		// Token: 0x06002263 RID: 8803 RVA: 0x000D302C File Offset: 0x000D122C
		private void \u0011()
		{
			List<SelectionParameter> list = this.\u0015();
			\u0005\u000E\u000B.\u000A(this, list);
			IEnumerable<SelectionParameter> enumerable = list;
			Func<SelectionParameter, bool> func;
			if ((func = ParametersManagerService.<>c.\u0004) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.\u0011()).MethodHandle;
				}
				func = (ParametersManagerService.<>c.\u0004 = new Func<SelectionParameter, bool>(ParametersManagerService.<>c.\u001F.\u0001));
			}
			\u0018\u000E\u000B.\u000A(this, Enumerable.ToList<SelectionParameter>(Enumerable.Where<SelectionParameter>(enumerable, func)));
			object u001F = \u001D\u000E\u000B.\u0007(this);
			Comparison<SelectionParameter> u000A;
			if ((u000A = ParametersManagerService.<>c.\u0019) == null)
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
				u000A = (ParametersManagerService.<>c.\u0019 = new Comparison<SelectionParameter>(ParametersManagerService.<>c.\u001F.\u0009));
			}
			\u0009\u0010\u000B.\u000A(u001F, u000A);
			List<List<SelectionParameter>> list2 = \u0019\u000E\u000B.\u000A(this);
			if (list2 != null)
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
				IEnumerable<List<SelectionParameter>> enumerable2 = list2;
				Func<List<SelectionParameter>, bool> func2;
				if ((func2 = ParametersManagerService.<>c.\u0018) == null)
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
					func2 = (ParametersManagerService.<>c.\u0018 = new Func<List<SelectionParameter>, bool>(ParametersManagerService.<>c.\u001F.\u001F\u000A));
				}
				if (Enumerable.Count<List<SelectionParameter>>(enumerable2, func2) == 2)
				{
					List<SelectionParameter> list3 = \u0016\u0016\u0016.\u000A();
					List<SelectionParameter>.Enumerator enumerator = \u0001\u000D\u0016.\u000A(\u001A\u0010\u000B.\u000A(list2, 0));
					try
					{
						while (\u0014\u000D\u0016.\u000A(ref enumerator))
						{
							ParametersManagerService.\u0012\u0020 u0012_u = new ParametersManagerService.\u0012\u0020();
							u0012_u.\u001F = \u0015\u000D\u0016.\u000A(ref enumerator);
							SelectionParameter selectionParameter = Enumerable.FirstOrDefault<SelectionParameter>(\u001D\u000E\u000B.\u0007(this), new Func<SelectionParameter, bool>(u0012_u.\u000A));
							if (selectionParameter != null)
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
								\u000A\u0016\u0016.\u000A(list3, selectionParameter);
							}
							else
							{
								\u0005\u001B\u000A.\u0018.\u0019<SGReport>(SGReport.LT(u0012_u.\u001F, "Placeholder Parameter"), Context.ReportingService);
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
					\u0019\u0018\u000B.\u001D(this, list3);
					\u0004\u0018\u000B.\u001D(this, Enumerable.ToList<SelectionParameter>(Enumerable.Except<SelectionParameter>(\u001D\u000E\u000B.\u0007(this), list3)));
					enumerator = \u0001\u000D\u0016.\u000A(Enumerable.Last<List<SelectionParameter>>(list2));
					try
					{
						while (\u0014\u000D\u0016.\u000A(ref enumerator))
						{
							ParametersManagerService.\u0003\u0020 u0003_u = new ParametersManagerService.\u0003\u0020();
							u0003_u.\u001F = \u0015\u000D\u0016.\u000A(ref enumerator);
							if (Enumerable.FirstOrDefault<SelectionParameter>(\u001C\u0005\u000B.\u001D(this), new Func<SelectionParameter, bool>(u0003_u.\u000A)) == null)
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
								\u0005\u001B\u000A.\u0018.\u0019<SGReport>(SGReport.LT(u0003_u.\u001F, "Placeholder Parameter"), Context.ReportingService);
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
					goto IL_2A8;
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
			\u0019\u0018\u000B.\u001D(this, \u0016\u0016\u0016.\u000A());
			\u0004\u0018\u000B.\u001D(this, Enumerable.ToList<SelectionParameter>(\u001D\u000E\u000B.\u0007(this)));
			List<List<SelectionParameter>> list4 = \u001E\u0010\u000B.\u000A(2);
			\u0011\u0010\u000B.\u000A(list4, \u000D\u0005\u000B.\u001D(this));
			\u0011\u0010\u000B.\u000A(list4, \u001C\u0005\u000B.\u001D(this));
			\u0004\u000E\u000B.\u000A(this, list4);
			IL_2A8:
			object u001F2 = \u000D\u0005\u000B.\u001D(this);
			Action<SelectionParameter> u000A2;
			if ((u000A2 = ParametersManagerService.<>c.\u0005) == null)
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
				u000A2 = (ParametersManagerService.<>c.\u0005 = new Action<SelectionParameter>(ParametersManagerService.<>c.\u001F.\u000A\u000A));
			}
			\u001E\u000F\u000B.\u000A(u001F2, u000A2);
		}

		// Token: 0x06002264 RID: 8804 RVA: 0x000D3334 File Offset: 0x000D1534
		private void \u001E()
		{
			this.\u0017();
			\u0006\u000E\u000B.\u000A(this, \u000F\u000E\u000B.\u000A(this));
			if (\u000B\u000E\u000B.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.\u001E()).MethodHandle;
				}
				IEnumerable<List<RevisionParameter>> enumerable = \u000B\u000E\u000B.\u000A(this);
				Func<List<RevisionParameter>, bool> func;
				if ((func = ParametersManagerService.<>c.\u0016) == null)
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
					func = (ParametersManagerService.<>c.\u0016 = new Func<List<RevisionParameter>, bool>(ParametersManagerService.<>c.\u001F.\u0007\u000A));
				}
				if (Enumerable.Count<List<RevisionParameter>>(enumerable, func) == 2)
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
					List<RevisionParameter> list = \u000E\u0010\u000B.\u000A();
					List<RevisionParameter>.Enumerator enumerator = \u0010\u001C\u0016.\u000A(\u0002\u000E\u000B.\u000A(\u000B\u000E\u000B.\u000A(this), 0));
					try
					{
						while (\u000B\u001C\u0016.\u000A(ref enumerator))
						{
							ParametersManagerService.\u001C\u0020 u001C_u = new ParametersManagerService.\u001C\u0020();
							u001C_u.\u001F = \u000D\u001C\u0016.\u000A(ref enumerator);
							RevisionParameter revisionParameter = Enumerable.FirstOrDefault<RevisionParameter>(\u000D\u0016\u000B.\u001D(this), new Func<RevisionParameter, bool>(u001C_u.\u000A));
							if (revisionParameter != null)
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
								\u0002\u001C\u0016.\u000A(list, revisionParameter);
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
					\u0004\u000B\u000B.\u001D(this, list);
					\u0007\u000B\u000B.\u001D(this, Enumerable.ToList<RevisionParameter>(Enumerable.Except<RevisionParameter>(\u000D\u0016\u000B.\u001D(this), list)));
					goto IL_142;
				}
			}
			this.\u0020();
			\u0009\u000B\u000B.\u001D(this, \u000B\u000E\u000B.\u000A(this));
			IL_142:
			object u001F = \u000E\u001C\u0016.\u001D(this);
			Action<RevisionParameter> u000A;
			if ((u000A = ParametersManagerService.<>c.\u000B) == null)
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
				u000A = (ParametersManagerService.<>c.\u000B = new Action<RevisionParameter>(ParametersManagerService.<>c.\u001F.\u001D\u000A));
			}
			\u0016\u000E\u000B.\u000A(u001F, u000A);
			object u001F2 = \u0006\u000B\u000B.\u001D(this);
			Action<RevisionParameter> u000A2;
			if ((u000A2 = ParametersManagerService.<>c.\u0002) == null)
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
				u000A2 = (ParametersManagerService.<>c.\u0002 = new Action<RevisionParameter>(ParametersManagerService.<>c.\u001F.\u0004\u000A));
			}
			\u0016\u000E\u000B.\u000A(u001F2, u000A2);
		}

		// Token: 0x06002265 RID: 8805 RVA: 0x000D3500 File Offset: 0x000D1700
		private void \u0020()
		{
			ParametersManagerService.\u000D\u0020 u000D_u = new ParametersManagerService.\u000D\u0020();
			\u0006\u000E\u000B.\u000A(this, \u000A\u0002\u000B.\u000A());
			ParametersManagerService.\u000D\u0020 u000D_u2 = u000D_u;
			List<RevisionParameterType> u001F = \u0003\u000E\u000B.\u000A();
			\u0012\u000E\u000B.\u000A(u001F, RevisionParameterType.RevisionNumber);
			\u0012\u000E\u000B.\u000A(u001F, RevisionParameterType.Description);
			\u0012\u000E\u000B.\u000A(u001F, RevisionParameterType.RevisionDate);
			u000D_u2.\u001F = u001F;
			\u0004\u000B\u000B.\u001D(this, \u001A\u001C\u0016.\u000A(Enumerable.Where<RevisionParameter>(\u000D\u0016\u000B.\u001D(this), new Func<RevisionParameter, bool>(u000D_u.\u000A))));
			\u0007\u000B\u000B.\u001D(this, \u001A\u001C\u0016.\u000A(Enumerable.ToList<RevisionParameter>(Enumerable.Where<RevisionParameter>(\u000D\u0016\u000B.\u001D(this), new Func<RevisionParameter, bool>(u000D_u.\u0007)))));
			\u001F\u0002\u000B.\u000A(\u000B\u000E\u000B.\u000A(this), \u000E\u001C\u0016.\u001D(this));
			\u001F\u0002\u000B.\u000A(\u000B\u000E\u000B.\u000A(this), \u0006\u000B\u000B.\u001D(this));
		}

		// Token: 0x06002266 RID: 8806 RVA: 0x000D35C4 File Offset: 0x000D17C4
		private void \u0017()
		{
			if (\u000D\u0016\u000B.\u001D(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.\u0017()).MethodHandle;
				}
				Element element = Enumerable.FirstOrDefault<Element>(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(this.\u000A), \u001E\u0011\u000A.\u000A(\u001C\u0010\u000E.\u001F())));
				Parameter parameter;
				if (element == null)
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
					parameter = \u0012\u000B\u000E.\u001F;
				}
				else
				{
					parameter = \u0016\u0018\u0007.\u001D(element, -1007412L);
				}
				Parameter parameter2 = parameter;
				Parameter parameter3;
				if (element == null)
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
					parameter3 = \u0012\u000B\u000E.\u001F;
				}
				else
				{
					parameter3 = \u0016\u0018\u0007.\u001D(element, -1007414L);
				}
				Parameter parameter4 = parameter3;
				Parameter parameter5;
				if (element == null)
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
					parameter5 = \u0012\u000B\u000E.\u001F;
				}
				else
				{
					parameter5 = \u0016\u0018\u0007.\u001D(element, -1007415L);
				}
				Parameter parameter6 = parameter5;
				Parameter parameter7;
				if (element == null)
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
					parameter7 = \u0012\u000B\u000E.\u001F;
				}
				else
				{
					parameter7 = \u0016\u0018\u0007.\u001D(element, -1007417L);
				}
				Parameter parameter8 = parameter7;
				Parameter parameter9;
				if (element == null)
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
					parameter9 = \u0012\u000B\u000E.\u001F;
				}
				else
				{
					parameter9 = \u0016\u0018\u0007.\u001D(element, -1007416L);
				}
				Parameter parameter10 = parameter9;
				List<RevisionParameter> list = \u000E\u0010\u000B.\u000A();
				RevisionParameterType u001F = RevisionParameterType.RevisionNumber;
				string u000A;
				if (parameter2 == null)
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
					u000A = \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u001D(parameter2));
				}
				\u0002\u001C\u0016.\u000A(list, \u000D\u000E\u000B.\u000A(u001F, u000A));
				RevisionParameterType u001F2 = RevisionParameterType.Description;
				string u000A2;
				if (parameter4 == null)
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
					u000A2 = \u000F\u0015\u0010.\u001F;
				}
				else
				{
					u000A2 = \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u001D(parameter4));
				}
				\u0002\u001C\u0016.\u000A(list, \u000D\u000E\u000B.\u000A(u001F2, u000A2));
				RevisionParameterType u001F3 = RevisionParameterType.RevisionDate;
				string u000A3;
				if (parameter6 == null)
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
					u000A3 = \u000F\u0015\u0010.\u001F;
				}
				else
				{
					u000A3 = \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u001D(parameter6));
				}
				\u0002\u001C\u0016.\u000A(list, \u000D\u000E\u000B.\u000A(u001F3, u000A3));
				RevisionParameterType u001F4 = RevisionParameterType.IssuedBy;
				string u000A4;
				if (parameter8 == null)
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
					u000A4 = \u000F\u0015\u0010.\u001F;
				}
				else
				{
					u000A4 = \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u001D(parameter8));
				}
				\u0002\u001C\u0016.\u000A(list, \u000D\u000E\u000B.\u000A(u001F4, u000A4));
				RevisionParameterType u001F5 = RevisionParameterType.IssuedTo;
				string u000A5;
				if (parameter10 == null)
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
					u000A5 = \u000F\u0015\u0010.\u001F;
				}
				else
				{
					u000A5 = \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u001D(parameter10));
				}
				\u0002\u001C\u0016.\u000A(list, \u000D\u000E\u000B.\u000A(u001F5, u000A5));
				\u0002\u001C\u0016.\u000A(list, \u000D\u000E\u000B.\u000A(RevisionParameterType.Show, "Show"));
				\u001C\u000E\u000B.\u000A(this, list);
				IEnumerable<RevisionParameter> enumerable = \u000D\u0016\u000B.\u001D(this);
				Func<RevisionParameter, string> func;
				if ((func = ParametersManagerService.<>c.\u0006) == null)
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
					func = (ParametersManagerService.<>c.\u0006 = new Func<RevisionParameter, string>(ParametersManagerService.<>c.\u001F.\u0019\u000A));
				}
				\u001C\u000E\u000B.\u000A(this, Enumerable.ToList<RevisionParameter>(Enumerable.OrderBy<RevisionParameter, string>(enumerable, func)));
			}
		}

		// Token: 0x06002267 RID: 8807 RVA: 0x000D382C File Offset: 0x000D1A2C
		private void \u0014()
		{
			List<SelectionParameter> list = \u0016\u0016\u0016.\u000A();
			List<SelectionParameter> u000A = this.\u0001();
			List<SelectionParameter> u000A2 = this.\u001A();
			\u001F\u000E\u000B.\u000A(list, u000A);
			\u001F\u000E\u000B.\u000A(list, u000A2);
			object u001F = list;
			Comparison<SelectionParameter> u000A3;
			if ((u000A3 = ParametersManagerService.<>c.\u000F) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.\u0014()).MethodHandle;
				}
				u000A3 = (ParametersManagerService.<>c.\u000F = new Comparison<SelectionParameter>(ParametersManagerService.<>c.\u001F.\u0018\u000A));
			}
			\u0009\u0010\u000B.\u000A(u001F, u000A3);
			\u001B\u000E\u000B.\u000A(this, list);
			List<List<SelectionParameter>> list2 = \u0008\u000E\u000B.\u000A(this);
			if (list2 != null)
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
				IEnumerable<List<SelectionParameter>> enumerable = list2;
				Func<List<SelectionParameter>, bool> func;
				if ((func = ParametersManagerService.<>c.\u0012) == null)
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
					func = (ParametersManagerService.<>c.\u0012 = new Func<List<SelectionParameter>, bool>(ParametersManagerService.<>c.\u001F.\u0005\u000A));
				}
				if (Enumerable.Count<List<SelectionParameter>>(enumerable, func) == 2)
				{
					List<SelectionParameter> list3 = \u0016\u0016\u0016.\u000A();
					List<SelectionParameter>.Enumerator enumerator = \u0001\u000D\u0016.\u000A(\u001A\u0010\u000B.\u000A(list2, 0));
					try
					{
						while (\u0014\u000D\u0016.\u000A(ref enumerator))
						{
							ParametersManagerService.\u0010\u0020 u0010_u = new ParametersManagerService.\u0010\u0020();
							u0010_u.\u001F = \u0015\u000D\u0016.\u000A(ref enumerator);
							SelectionParameter selectionParameter = Enumerable.FirstOrDefault<SelectionParameter>(list, new Func<SelectionParameter, bool>(u0010_u.\u000A));
							if (selectionParameter != null)
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
								\u000A\u0016\u0016.\u000A(list3, selectionParameter);
							}
							else
							{
								\u0005\u001B\u000A.\u0018.\u0019<SGReport>(SGReport.LT(u0010_u.\u001F, "View Parameter"), Context.ReportingService);
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
					\u0011\u000F\u000B.\u001D(this, list3);
					\u0008\u000F\u000B.\u001D(this, Enumerable.ToList<SelectionParameter>(Enumerable.Except<SelectionParameter>(list, list3)));
					enumerator = \u0001\u000D\u0016.\u000A(Enumerable.Last<List<SelectionParameter>>(list2));
					try
					{
						while (\u0014\u000D\u0016.\u000A(ref enumerator))
						{
							ParametersManagerService.\u000E\u0020 u000E_u = new ParametersManagerService.\u000E\u0020();
							u000E_u.\u001F = \u0015\u000D\u0016.\u000A(ref enumerator);
							if (Enumerable.FirstOrDefault<SelectionParameter>(\u0020\u000F\u000B.\u001D(this), new Func<SelectionParameter, bool>(u000E_u.\u000A)) == null)
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
								\u0005\u001B\u000A.\u0018.\u0019<SGReport>(SGReport.LT(u000E_u.\u001F, "View Parameter"), Context.ReportingService);
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
					goto IL_273;
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
			\u0011\u000F\u000B.\u001D(this, \u0016\u0016\u0016.\u000A());
			\u0008\u000F\u000B.\u001D(this, Enumerable.ToList<SelectionParameter>(list));
			List<List<SelectionParameter>> list4 = \u000E\u000E\u000B.\u000A();
			\u0011\u0010\u000B.\u000A(list4, \u0020\u001B\u0016.\u001D(this));
			\u0011\u0010\u000B.\u000A(list4, \u0020\u000F\u000B.\u001D(this));
			List<List<SelectionParameter>> u000A4 = list4;
			\u0010\u000E\u000B.\u000A(this, u000A4);
			IL_273:
			object u001F2 = \u0020\u001B\u0016.\u001D(this);
			Action<SelectionParameter> u000A5;
			if ((u000A5 = ParametersManagerService.<>c.\u0003) == null)
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
				u000A5 = (ParametersManagerService.<>c.\u0003 = new Action<SelectionParameter>(ParametersManagerService.<>c.\u001F.\u0016\u000A));
			}
			\u001E\u000F\u000B.\u000A(u001F2, u000A5);
		}

		// Token: 0x06002268 RID: 8808 RVA: 0x000D3B00 File Offset: 0x000D1D00
		private void \u0013()
		{
			List<SelectionParameter> list = this.\u0001();
			object u001F = list;
			Comparison<SelectionParameter> u000A;
			if ((u000A = ParametersManagerService.<>c.\u001C) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.\u0013()).MethodHandle;
				}
				u000A = (ParametersManagerService.<>c.\u001C = new Comparison<SelectionParameter>(ParametersManagerService.<>c.\u001F.\u000B\u000A));
			}
			\u0009\u0010\u000B.\u000A(u001F, u000A);
			List<SelectionParameter> list2 = \u0016\u0016\u0016.\u000A();
			List<SelectionParameter> list3 = \u0016\u0016\u0016.\u000A();
			List<string> list4 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list4, "View Scale");
			List<string> u001F2 = list4;
			List<SelectionParameter>.Enumerator enumerator = \u0001\u000D\u0016.\u000A(list);
			try
			{
				while (\u0014\u000D\u0016.\u000A(ref enumerator))
				{
					SelectionParameter selectionParameter = \u0015\u000D\u0016.\u000A(ref enumerator);
					if (\u001F\u0020\u001D.\u000A(u001F2, \u001F\u0016\u0016.\u0007(selectionParameter)))
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
						\u000A\u0016\u0016.\u000A(list2, selectionParameter);
					}
					else
					{
						\u000A\u0016\u0016.\u000A(list3, selectionParameter);
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
			object u001F3 = list2;
			Comparison<SelectionParameter> u000A2;
			if ((u000A2 = ParametersManagerService.<>c.\u000D) == null)
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
				u000A2 = (ParametersManagerService.<>c.\u000D = new Comparison<SelectionParameter>(ParametersManagerService.<>c.\u001F.\u0002\u000A));
			}
			\u0009\u0010\u000B.\u000A(u001F3, u000A2);
			object u001F4 = list3;
			Comparison<SelectionParameter> u000A3;
			if ((u000A3 = ParametersManagerService.<>c.\u0010) == null)
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
				u000A3 = (ParametersManagerService.<>c.\u0010 = new Comparison<SelectionParameter>(ParametersManagerService.<>c.\u001F.\u0006\u000A));
			}
			\u0009\u0010\u000B.\u000A(u001F4, u000A3);
			\u0013\u0014\u0016.\u001D(this, list2);
			\u0017\u0014\u0016.\u001D(this, Enumerable.ToList<SelectionParameter>(Enumerable.Except<SelectionParameter>(list, list2)));
		}

		// Token: 0x06002269 RID: 8809 RVA: 0x000D3C68 File Offset: 0x000D1E68
		private List<SelectionParameter> \u001A()
		{
			List<SelectionParameter> list = \u0016\u0016\u0016.\u000A();
			List<Parameter>.Enumerator enumerator = \u0003\u0007\u0005.\u000A(Enumerable.ToList<Parameter>(Enumerable.Cast<Parameter>(\u000F\u0001\u0016.\u000A(\u0013\u0013\u0007.\u000A(this.\u000A)))));
			try
			{
				while (\u0006\u0007\u0005.\u000A(ref enumerator))
				{
					Parameter u001F = \u0012\u0007\u0005.\u000A(ref enumerator);
					if (!\u0010\u0014\u0007.\u000A(u001F))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.\u001A()).MethodHandle;
						}
						if (\u0011\u001F\u001D.\u0007(u001F) != null)
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
							if (\u0011\u001F\u001D.\u0007(u001F) != 4)
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
								SelectionParameter selectionParameter = \u001D\u0016\u0016.\u000A(u001F, SelectionParameterType.ProjectInformation);
								if (\u001E\u000B\u0018.\u000A(\u0020\u001F\u001D.\u0007(u001F)))
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
									\u0007\u0016\u0016.\u000A(selectionParameter, true);
								}
								\u000A\u0016\u0016.\u000A(list, selectionParameter);
							}
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

		// Token: 0x0600226A RID: 8810 RVA: 0x000D3D68 File Offset: 0x000D1F68
		private List<SelectionParameter> \u000C()
		{
			List<SelectionParameter> list = \u0016\u0016\u0016.\u000A();
			try
			{
				list = this.\u0015();
				SelectionParameter selectionParameter = \u000F\u0009\u0016.\u000A();
				\u000B\u0012\u0016.\u001D(selectionParameter, \u001E\u000E\u000B.\u000A());
				\u0016\u0012\u0016.\u001D(selectionParameter, 4);
				\u0011\u000E\u000B.\u000A(selectionParameter, true);
				\u0005\u0012\u0016.\u001D(selectionParameter, SelectionParameterType.Sheet);
				SelectionParameter u000A = selectionParameter;
				\u000A\u0016\u0016.\u000A(list, u000A);
			}
			catch (Exception u000A2)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Services\\ParametersManagerService.cs", "GetParametersOfSheets");
			}
			return list;
		}

		// Token: 0x0600226B RID: 8811 RVA: 0x000D3DE4 File Offset: 0x000D1FE4
		private List<SelectionParameter> \u0015()
		{
			List<SelectionParameter> list = \u0016\u0016\u0016.\u000A();
			try
			{
				List<ViewSheet> u001F = Enumerable.ToList<ViewSheet>(this.\u000A.CollectElements(null));
				if (\u001B\u0017\u0016.\u000A(u001F) == 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.\u0015()).MethodHandle;
					}
					return list;
				}
				HashSet<string> u001F2 = \u0015\u0006\u0019.\u000A();
				HashSet<BuiltInParameter> u001F3 = \u000C\u000E\u000B.\u000A(\u0015\u000E\u000B.\u000A(\u0007\u0005\u0016.\u000A()));
				IEnumerator u001F4 = \u0018\u0016\u0016.\u000A(\u0005\u0016\u0016.\u000A(\u001A\u000E\u000B.\u000A(u001F, 0)));
				try
				{
					while (\u000A\u0017\u000A.\u000A(u001F4))
					{
						ParametersManagerService.\u0008\u0020 u0008_u = new ParametersManagerService.\u0008\u0020();
						u0008_u.\u001F = \u0006\u0003\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F4));
						long num = \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(u0008_u.\u001F));
						string u000A = \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u0007(u0008_u.\u001F));
						BuiltInParameter builtInParameter;
						if (num >= 0L)
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
							builtInParameter = -1L;
						}
						else
						{
							builtInParameter = num;
						}
						BuiltInParameter builtInParameter2 = builtInParameter;
						if (\u0011\u001F\u001D.\u0007(u0008_u.\u001F) == null)
						{
							goto IL_143;
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
						if (\u0017\u0018\u0019.\u000A(u001F2, u000A))
						{
							goto IL_143;
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
						if (\u0013\u000E\u000B.\u000A(u001F3, builtInParameter2))
						{
							goto IL_143;
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
						bool flag = !\u0019\u0016\u0016.\u000A(list, new Predicate<SelectionParameter>(u0008_u.\u000A));
						IL_144:
						if (!flag)
						{
							continue;
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
						\u001B\u0006\u0019.\u000A(u001F2, u000A);
						if (builtInParameter2 == -1007401L)
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
							\u0014\u000E\u000B.\u000A(\u001D\u0016\u0016.\u000A(u0008_u.\u001F, SelectionParameterType.Sheet));
							continue;
						}
						if (builtInParameter2 == -1007400L)
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
							\u0017\u000E\u000B.\u000A(\u001D\u0016\u0016.\u000A(u0008_u.\u001F, SelectionParameterType.Sheet));
							continue;
						}
						SelectionParameter selectionParameter = \u001D\u0016\u0016.\u000A(u0008_u.\u001F, SelectionParameterType.Sheet);
						\u0007\u0016\u0016.\u000A(selectionParameter, \u001E\u000B\u0018.\u000A(\u0020\u001F\u001D.\u0007(u0008_u.\u001F)));
						bool u000A2;
						if (\u0011\u001F\u001D.\u0007(u0008_u.\u001F) != 4)
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
							u000A2 = \u0010\u0014\u0007.\u000A(u0008_u.\u001F);
						}
						else
						{
							u000A2 = true;
						}
						\u0020\u000E\u000B.\u000A(selectionParameter, u000A2);
						SelectionParameter u000A3 = selectionParameter;
						\u000A\u0016\u0016.\u000A(list, u000A3);
						continue;
						IL_143:
						flag = false;
						goto IL_144;
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
					IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F4);
					if (disposable != null)
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
						\u001F\u0017\u000A.\u000A(disposable);
					}
				}
			}
			catch (Exception u000A4)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A4, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Services\\ParametersManagerService.cs", "GetParametersOfPlaceholderSheets");
			}
			return list;
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x000D40A0 File Offset: 0x000D22A0
		private List<SelectionParameter> \u0001()
		{
			List<SelectionParameter> list = \u0016\u0016\u0016.\u000A();
			try
			{
				IEnumerable<View> enumerable = \u000E\u0013.\u001F<View>(this.\u000A);
				Func<View, int> func;
				if ((func = ParametersManagerService.<>c.\u000E) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.\u0001()).MethodHandle;
					}
					func = (ParametersManagerService.<>c.\u000E = new Func<View, int>(ParametersManagerService.<>c.\u001F.\u000F\u000A));
				}
				object u001F = Enumerable.ToList<View>(Enumerable.OrderByDescending<View, int>(enumerable, func));
				List<View> u001F2 = \u0006\u0019\u001D.\u000A();
				List<ViewType> list2 = \u001D\u0008\u000B.\u000A();
				\u001F\u0008\u000B.\u000A(list2, 6);
				\u001F\u0008\u000B.\u000A(list2, 7);
				\u001F\u0008\u000B.\u000A(list2, 12);
				List<ViewType> u001F3 = list2;
				List<ViewType> u001F4 = \u001D\u0008\u000B.\u000A();
				List<View>.Enumerator enumerator = \u0018\u0010\u0007.\u000A(u001F);
				try
				{
					while (\u0007\u0010\u0007.\u000A(ref enumerator))
					{
						View view = \u0019\u0010\u0007.\u000A(ref enumerator);
						if (\u0007\u0008\u000B.\u000A(view))
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
							if (!\u000A\u0008\u000B.\u000A(u001F3, \u001C\u001C\u0007.\u0007(view)))
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
								if (!\u000A\u0008\u000B.\u000A(u001F4, \u001C\u001C\u0007.\u0007(view)))
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
									\u001F\u0008\u000B.\u000A(u001F4, \u001C\u001C\u0007.\u0007(view));
									\u000B\u0016\u001D.\u000A(u001F2, view);
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
				List<string> u001F5 = \u0014\u000D\u0007.\u000A();
				List<BuiltInParameter> u001F6 = \u0015\u000E\u000B.\u000A(\u0007\u0005\u0016.\u000A());
				enumerator = \u0018\u0010\u0007.\u000A(u001F2);
				try
				{
					while (\u0007\u0010\u0007.\u000A(ref enumerator))
					{
						List<Parameter>.Enumerator enumerator2 = \u0003\u0007\u0005.\u000A(\u000C\u0002\u0016.\u000A(\u0019\u0010\u0007.\u000A(ref enumerator), false));
						try
						{
							while (\u0006\u0007\u0005.\u000A(ref enumerator2))
							{
								ParametersManagerService.\u001B\u0020 u001B_u = new ParametersManagerService.\u001B\u0020();
								u001B_u.\u001F = \u0012\u0007\u0005.\u000A(ref enumerator2);
								long num = \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(u001B_u.\u001F));
								string u000A = \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u0007(u001B_u.\u001F));
								BuiltInParameter builtInParameter;
								if (num >= 0L)
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
									builtInParameter = -1L;
								}
								else
								{
									builtInParameter = num;
								}
								BuiltInParameter u000A2 = builtInParameter;
								if (\u0011\u001F\u001D.\u0007(u001B_u.\u001F) == null)
								{
									goto IL_228;
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
								if (\u0009\u000E\u000B.\u000A(u001F6, u000A2))
								{
									goto IL_228;
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
								if (\u001F\u0020\u001D.\u000A(u001F5, u000A))
								{
									goto IL_228;
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
								bool flag = !\u0019\u0016\u0016.\u000A(list, new Predicate<SelectionParameter>(u001B_u.\u000A));
								IL_229:
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
									\u001A\u0008\u0007.\u000A(u001F5, u000A);
									SelectionParameter selectionParameter = \u000F\u0009\u0016.\u000A();
									\u0001\u000E\u000B.\u000A(selectionParameter, false);
									\u000B\u0012\u0016.\u001D(selectionParameter, u000A);
									\u0005\u0012\u0016.\u001D(selectionParameter, SelectionParameterType.Sheet);
									\u0016\u0012\u0016.\u001D(selectionParameter, \u0011\u001F\u001D.\u0007(u001B_u.\u001F));
									\u0018\u0012\u0016.\u001D(selectionParameter, u000A2);
									SelectionParameter selectionParameter2 = selectionParameter;
									ParametersManagerService.\u0009(u001B_u.\u001F, u000A2, selectionParameter2);
									\u000A\u0016\u0016.\u000A(list, selectionParameter2);
									continue;
								}
								continue;
								IL_228:
								flag = false;
								goto IL_229;
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
			catch (Exception u000A3)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A3, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Services\\ParametersManagerService.cs", "GetViewsParameters");
			}
			return list;
		}

		// Token: 0x0600226D RID: 8813 RVA: 0x000D4414 File Offset: 0x000D2614
		private static void \u0009(Parameter \u001F, BuiltInParameter \u000A, SelectionParameter \u0007)
		{
			Definition u001F = \u0020\u001F\u001D.\u0007(\u001F);
			if (\u001E\u000B\u0018.\u000A(u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.\u0009(Parameter, BuiltInParameter, SelectionParameter)).MethodHandle;
				}
				\u0007\u0016\u0016.\u000A(\u0007, true);
				return;
			}
			if (\u000C\u0008\u000B.\u000A(u001F))
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
				\u001A\u0008\u000B.\u000A(\u0007, true);
				return;
			}
			if (\u0013\u0008\u000B.\u000A(u001F))
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
				\u0014\u0008\u000B.\u000A(\u0007, true);
				return;
			}
			if (\u000A > -1005183L)
			{
				if (\u000A <= -1005168L)
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
					if (\u000A <= -1005177L)
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
						if (\u000A != -1005181L)
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
							if (\u000A != -1005177L)
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
							\u000B\u0008\u000B.\u000A(\u0007, true);
							return;
						}
					}
					else
					{
						if (\u000A == -1005176L)
						{
							\u0017\u0008\u000B.\u000A(\u0007, true);
							return;
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
						if (\u000A == -1005172L)
						{
							\u0004\u0008\u000B.\u000A(\u0007, true);
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
						if (\u000A != -1005168L)
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
						\u001E\u0008\u000B.\u000A(\u0007, true);
						return;
					}
				}
				else if (\u000A <= -1005158L)
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
					if (\u000A == -1005163L)
					{
						\u0020\u0008\u000B.\u000A(\u0007, true);
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
					if (\u000A == -1005161L)
					{
						\u0010\u0008\u000B.\u000A(\u0007, true);
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
					if (\u000A != -1005158L)
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
					\u0012\u0008\u000B.\u000A(\u0007, true);
					return;
				}
				else
				{
					if (\u000A == -1005153L)
					{
						\u0019\u0008\u000B.\u000A(\u0007, true);
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
					if (\u000A != -1005123L)
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
						if (\u000A != -1005050L)
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
						\u000F\u0008\u000B.\u000A(\u0007, true);
						return;
					}
				}
				\u0008\u0008\u000B.\u000A(\u0007, true);
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
			if (\u000A <= -1011002L)
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
				if (\u000A <= -1012202L)
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
					if (\u000A == -1154613L)
					{
						\u001C\u0008\u000B.\u000A(\u0007, true);
						return;
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
					if (\u000A != -1012202L)
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
					\u001B\u0008\u000B.\u000A(\u0007, true);
					return;
				}
				else
				{
					BuiltInParameter builtInParameter = \u000A - -1012103L;
					if (builtInParameter > 3L)
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
						switch (builtInParameter)
						{
						case 0U:
							\u0005\u0008\u000B.\u000A(\u0007, true);
							return;
						case 1U:
						case 3U:
							\u0016\u0008\u000B.\u000A(\u0007, true);
							return;
						case 2U:
							return;
						}
					}
					if (\u000A == -1011003L)
					{
						\u000E\u0008\u000B.\u000A(\u0007, true);
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
					if (\u000A != -1011002L)
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
					\u0011\u0008\u000B.\u000A(\u0007, true);
					return;
				}
			}
			else if (\u000A <= -1006609L)
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
				if (\u000A == -1008203L)
				{
					\u0006\u0008\u000B.\u000A(\u0007, true);
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
				if (\u000A != -1006609L)
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
				\u0002\u0008\u000B.\u000A(\u0007, true);
				return;
			}
			else
			{
				if (\u000A == -1005335L)
				{
					\u0018\u0008\u000B.\u000A(\u0007, true);
					return;
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
				if (\u000A == -1005254L)
				{
					\u000D\u0008\u000B.\u000A(\u0007, true);
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
				if (\u000A != -1005183L)
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
				\u0003\u0008\u000B.\u000A(\u0007, true);
				return;
			}
		}

		// Token: 0x0600226E RID: 8814 RVA: 0x000D47A8 File Offset: 0x000D29A8
		public void SaveRevisionsParameters(List<List<RevisionParameter>> list)
		{
			Profile profile = \u0015\u0008\u000B.\u0007(\u001E\u0020\u0016.\u000A());
			bool flag;
			if (profile == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.SaveRevisionsParameters(List<List<RevisionParameter>>)).MethodHandle;
				}
				flag = false;
			}
			else
			{
				flag = \u0001\u0008\u000B.\u000A(profile);
			}
			if (flag)
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
				\u0010\u0010\u000B.\u000A(\u0012\u0010\u000E.\u001F(\u0015\u0008\u000B.\u0007(\u001E\u0020\u0016.\u000A())), list);
			}
		}

		// Token: 0x0600226F RID: 8815 RVA: 0x000D480C File Offset: 0x000D2A0C
		public void SaveViewManagerParameters(List<List<SelectionParameter>> list)
		{
			Profile profile = \u0015\u0008\u000B.\u0007(\u0006\u001A\u0016.\u000A());
			bool flag;
			if (profile == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.SaveViewManagerParameters(List<List<SelectionParameter>>)).MethodHandle;
				}
				flag = false;
			}
			else
			{
				flag = \u0001\u0008\u000B.\u000A(profile);
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
				\u0014\u0010\u000B.\u000A(\u0003\u0010\u000E.\u001F(\u0015\u0008\u000B.\u0007(\u0006\u001A\u0016.\u000A())), list);
			}
		}

		// Token: 0x06002270 RID: 8816 RVA: 0x000D4870 File Offset: 0x000D2A70
		public void SaveSheetsParameters(List<List<SelectionParameter>> list)
		{
			Profile profile = \u0015\u0008\u000B.\u0007(\u001E\u0020\u0016.\u000A());
			bool flag;
			if (profile == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.SaveSheetsParameters(List<List<SelectionParameter>>)).MethodHandle;
				}
				flag = false;
			}
			else
			{
				flag = \u0001\u0008\u000B.\u000A(profile);
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
				\u0020\u0010\u000B.\u000A(\u0012\u0010\u000E.\u001F(\u0015\u0008\u000B.\u0007(\u001E\u0020\u0016.\u000A())), list);
			}
		}

		// Token: 0x06002271 RID: 8817 RVA: 0x000D48D4 File Offset: 0x000D2AD4
		public void SavePlaceholderParameters(List<List<SelectionParameter>> list)
		{
			Profile profile = \u0015\u0008\u000B.\u0007(\u001E\u0020\u0016.\u000A());
			bool flag;
			if (profile == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.SavePlaceholderParameters(List<List<SelectionParameter>>)).MethodHandle;
				}
				flag = false;
			}
			else
			{
				flag = \u0001\u0008\u000B.\u000A(profile);
			}
			if (flag)
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
				\u001B\u0010\u000B.\u000A(\u0012\u0010\u000E.\u001F(\u0015\u0008\u000B.\u0007(\u001E\u0020\u0016.\u000A())), list);
			}
		}

		// Token: 0x06002272 RID: 8818 RVA: 0x000D4938 File Offset: 0x000D2B38
		public List<List<RevisionParameter>> LoadRevisionsParameters()
		{
			Profile profile = \u0015\u0008\u000B.\u0007(\u001E\u0020\u0016.\u000A());
			bool flag;
			if (profile == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.LoadRevisionsParameters()).MethodHandle;
				}
				flag = false;
			}
			else
			{
				flag = \u0001\u0008\u000B.\u000A(profile);
			}
			if (flag)
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
				try
				{
					List<List<RevisionParameter>> list = \u001F\u001B\u000B.\u000A(\u0012\u0010\u000E.\u001F(\u0015\u0008\u000B.\u0007(\u001E\u0020\u0016.\u000A())));
					if (list != null)
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
						if (\u0009\u0008\u000B.\u000A(list) == 2)
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
							return list;
						}
					}
				}
				catch (Exception u000A)
				{
					\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Services\\ParametersManagerService.cs", "LoadRevisionsParameters");
				}
			}
			return null;
		}

		// Token: 0x06002273 RID: 8819 RVA: 0x000D49F0 File Offset: 0x000D2BF0
		public void ResetRevisionParameters()
		{
			List<RevisionParameter> u = Enumerable.ToList<RevisionParameter>(\u000E\u001C\u0016.\u0007(ParametersManagerService.\u0008));
			\u0016\u001C\u0016.\u000A(\u000E\u001C\u0016.\u0007(ParametersManagerService.\u0008));
			\u000A\u001B\u000B.\u000A(\u000B\u000E\u000B.\u000A(this), 0, u);
			\u0007\u000B\u000B.\u0007(ParametersManagerService.\u0008, Enumerable.ToList<RevisionParameter>(Enumerable.Concat<RevisionParameter>(\u0002\u000E\u000B.\u000A(\u000B\u000E\u000B.\u000A(this), 0), Enumerable.Last<List<RevisionParameter>>(\u000B\u000E\u000B.\u000A(this)))));
		}

		// Token: 0x06002274 RID: 8820 RVA: 0x000D4A70 File Offset: 0x000D2C70
		public List<List<SelectionParameter>> LoadViewManagersParameters()
		{
			Profile profile = \u0015\u0008\u000B.\u0007(\u0006\u001A\u0016.\u000A());
			bool flag;
			if (profile == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.LoadViewManagersParameters()).MethodHandle;
				}
				flag = false;
			}
			else
			{
				flag = \u0001\u0008\u000B.\u000A(profile);
			}
			if (flag)
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
				try
				{
					List<List<SelectionParameter>> list = \u0007\u001B\u000B.\u000A(\u0003\u0010\u000E.\u001F(\u0015\u0008\u000B.\u0007(\u0006\u001A\u0016.\u000A())));
					if (list != null)
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
						IEnumerable<List<SelectionParameter>> enumerable = list;
						Func<List<SelectionParameter>, bool> func;
						if ((func = ParametersManagerService.<>c.\u0008) == null)
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
							func = (ParametersManagerService.<>c.\u0008 = new Func<List<SelectionParameter>, bool>(ParametersManagerService.<>c.\u001F.\u0012\u000A));
						}
						if (Enumerable.Count<List<SelectionParameter>>(enumerable, func) == 2)
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
							return list;
						}
					}
				}
				catch (Exception u000A)
				{
					\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Services\\ParametersManagerService.cs", "LoadViewManagersParameters");
				}
			}
			return null;
		}

		// Token: 0x06002275 RID: 8821 RVA: 0x000D4B54 File Offset: 0x000D2D54
		public List<List<SelectionParameter>> LoadSheetsParameters()
		{
			Profile profile = \u0015\u0008\u000B.\u0007(\u001E\u0020\u0016.\u000A());
			bool flag;
			if (profile == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.LoadSheetsParameters()).MethodHandle;
				}
				flag = false;
			}
			else
			{
				flag = \u0001\u0008\u000B.\u000A(profile);
			}
			if (flag)
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
				try
				{
					List<List<SelectionParameter>> list = \u001D\u001B\u000B.\u000A(\u0012\u0010\u000E.\u001F(\u0015\u0008\u000B.\u0007(\u001E\u0020\u0016.\u000A())));
					if (list != null)
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
						IEnumerable<List<SelectionParameter>> enumerable = list;
						Func<List<SelectionParameter>, bool> func;
						if ((func = ParametersManagerService.<>c.\u001B) == null)
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
							func = (ParametersManagerService.<>c.\u001B = new Func<List<SelectionParameter>, bool>(ParametersManagerService.<>c.\u001F.\u0003\u000A));
						}
						if (Enumerable.Count<List<SelectionParameter>>(enumerable, func) == 2)
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
							return list;
						}
					}
				}
				catch (Exception u000A)
				{
					\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Services\\ParametersManagerService.cs", "LoadSheetsParameters");
				}
			}
			return null;
		}

		// Token: 0x06002276 RID: 8822 RVA: 0x000D4C38 File Offset: 0x000D2E38
		public List<List<SelectionParameter>> LoadPlaceholderParameters()
		{
			Profile profile = \u0015\u0008\u000B.\u0007(\u001E\u0020\u0016.\u000A());
			bool flag;
			if (profile == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersManagerService.LoadPlaceholderParameters()).MethodHandle;
				}
				flag = false;
			}
			else
			{
				flag = \u0001\u0008\u000B.\u000A(profile);
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
				try
				{
					List<List<SelectionParameter>> list = \u0004\u001B\u000B.\u000A(\u0012\u0010\u000E.\u001F(\u0015\u0008\u000B.\u0007(\u001E\u0020\u0016.\u000A())));
					if (list != null)
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
						IEnumerable<List<SelectionParameter>> enumerable = list;
						Func<List<SelectionParameter>, bool> func;
						if ((func = ParametersManagerService.<>c.\u0011) == null)
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
							func = (ParametersManagerService.<>c.\u0011 = new Func<List<SelectionParameter>, bool>(ParametersManagerService.<>c.\u001F.\u001C\u000A));
						}
						if (Enumerable.Count<List<SelectionParameter>>(enumerable, func) == 2)
						{
