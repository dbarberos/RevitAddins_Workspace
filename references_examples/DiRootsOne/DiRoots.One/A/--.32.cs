using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;
using DiRoots.One.Commons.UI.Progress;
using DiRoots.One.Revit.Interfaces;
using DiRoots.One.ViewAligner.Data.Models;
using DiRoots.One.ViewAligner.Interfaces;
using DiRoots.One.ViewAligner.Services;
using DiRoots.Revit.SheetsAndViews;
using DiRoots.Revit.SheetsAndViews.Models;
using DiRoots.Revit.SheetsAndViews.Results;

namespace A
{
	// Token: 0x020000CF RID: 207
	internal class \u0003\u0019 : ExternalEventInfo
	{
		// Token: 0x060007D6 RID: 2006 RVA: 0x0002CBD4 File Offset: 0x0002ADD4
		public \u0003\u0019(ISheetLayoutService \u001F, ICropViewService \u000A, IReportingService \u0007, IProgressWindowService \u001D)
		{
			\u000D\u0001\u000A.\u0007(this, "ViewAligner");
			this.\u001B = \u001D;
			this.\u000E = \u001F;
			this.\u0008 = \u000A;
			this.\u0011 = \u0007;
		}

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060007D7 RID: 2007 RVA: 0x0002CC10 File Offset: 0x0002AE10
		// (remove) Token: 0x060007D8 RID: 2008 RVA: 0x0002CC5C File Offset: 0x0002AE5C
		public event \u0003\u0019.\u0005\u0019 \u001F
		{
			[CompilerGenerated]
			add
			{
				\u0003\u0019.\u0005\u0019 u0005_u = this.\u001F;
				\u0003\u0019.\u0005\u0019 u0005_u2;
				do
				{
					u0005_u2 = u0005_u;
					\u0003\u0019.\u0005\u0019 value2 = (\u0003\u0019.\u0005\u0019)\u000F\u001E\u000A.\u000A(u0005_u2, value);
					u0005_u = Interlocked.CompareExchange<\u0003\u0019.\u0005\u0019>(ref this.\u001F, value2, u0005_u2);
				}
				while (u0005_u != u0005_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0019.add_\u001F(\u0003\u0019.\u0005\u0019)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				\u0003\u0019.\u0005\u0019 u0005_u = this.\u001F;
				\u0003\u0019.\u0005\u0019 u0005_u2;
				do
				{
					u0005_u2 = u0005_u;
					\u0003\u0019.\u0005\u0019 value2 = (\u0003\u0019.\u0005\u0019)\u0012\u001E\u000A.\u000A(u0005_u2, value);
					u0005_u = Interlocked.CompareExchange<\u0003\u0019.\u0005\u0019>(ref this.\u001F, value2, u0005_u2);
				}
				while (u0005_u != u0005_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0019.remove_\u001F(\u0003\u0019.\u0005\u0019)).MethodHandle;
				}
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x060007D9 RID: 2009 RVA: 0x0002CCA8 File Offset: 0x0002AEA8
		// (set) Token: 0x060007DA RID: 2010 RVA: 0x0002CCBC File Offset: 0x0002AEBC
		public AlignSettings AlignSettings { get; set; }

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x060007DB RID: 2011 RVA: 0x0002CCD0 File Offset: 0x0002AED0
		private Document \u0004\u0018
		{
			get
			{
				UIApplication u001E = this.\u001E;
				if (u001E == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0019.get_\u0004\u0018()).MethodHandle;
					}
					return null;
				}
				UIDocument uidocument = \u0020\u0013\u000A.\u000A(u001E);
				if (uidocument == null)
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
					return null;
				}
				return \u0011\u0020\u000A.\u001D(uidocument);
			}
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x0002CD1C File Offset: 0x0002AF1C
		public override void Execute(UIApplication app)
		{
			int num = \u0019\u000E\u001D.\u000A(\u0018\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this)));
			if (\u0004\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0019.Execute(UIApplication)).MethodHandle;
				}
				num += num;
			}
			if (\u0007\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this)))
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
				num += num;
			}
			this.\u001E = app;
			IProgressWindowService u001B = this.\u001B;
			\u001F\u000E\u001D.\u000A(u001B, \u001A\u001D\u000E.\u001F(\u000F\u001E\u000A.\u000A(\u000A\u000E\u001D.\u000A(u001B), new ContentRenderedDelegate(this.\u0019\u0018))));
			\u0001\u0010\u001D.\u000A(this.\u001B, \u0009\u0010\u001D.\u000A(), num);
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x0002CDD0 File Offset: 0x0002AFD0
		public void \u0019\u0018()
		{
			\u0003\u0019.\u0016\u0019 u0016_u = new \u0003\u0019.\u0016\u0019();
			u0016_u.\u000A = this;
			\u0008\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\ViewAligner\\ExternalEvents\\ViewAlignerEventInfo.cs", "AlignViews");
			u0016_u.\u001F = \u0014\u001D\u000E.\u001F;
			u0016_u.\u001D = \u0014\u001D\u000E.\u001F;
			u0016_u.\u0004 = \u0014\u001D\u000E.\u001F;
			u0016_u.\u0019 = \u0014\u001D\u000E.\u001F;
			bool flag = false;
			u0016_u.\u0007 = 1;
			TransactionGroup transactionGroup = \u000E\u000E\u001D.\u000A(this.\u0004\u0018);
			try
			{
				try
				{
					\u0003\u0019.\u000B\u0019 u000B_u = new \u0003\u0019.\u000B\u0019();
					u000B_u.\u0004 = u0016_u;
					\u0010\u000E\u001D.\u000A(transactionGroup, \u0014\u0001\u000A.\u000A(this));
					if (\u0004\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this)))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0019.\u0019\u0018()).MethodHandle;
						}
						this.\u0018\u0018(new Action(u000B_u.\u0004.\u0002), "ViewAligner_ApplyScopeBox");
						IEnumerable<OperationResult<long>> enumerable = \u000E\u000D\u001D.\u001D(u000B_u.\u0004.\u001F);
						Func<OperationResult<long>, bool> func;
						if ((func = \u0003\u0019.<>c.\u000A) == null)
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
							func = (\u0003\u0019.<>c.\u000A = new Func<OperationResult<long>, bool>(\u0003\u0019.<>c.\u001F.\u0016));
						}
						if (Enumerable.Any<OperationResult<long>>(enumerable, func))
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
							this.\u0006\u0018(\u0019\u000E\u001D.\u000A(\u0018\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this))), ref u000B_u.\u0004.\u0007);
						}
					}
					u000B_u.\u000A = \u000D\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this));
					u000B_u.\u001D = AlignmentMode.Viewport;
					if (u000B_u.\u000A == AlignmentMode.ModelCoordinates)
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
						u000B_u.\u001F = Enumerable.ToList<ViewInfo>(Enumerable.Where<ViewInfo>(\u0018\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this)), new Func<ViewInfo, bool>(u000B_u.\u0004.\u000F)));
						u000B_u.\u0007 = Enumerable.ToList<ViewInfo>(Enumerable.Except<ViewInfo>(\u0018\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this)), u000B_u.\u001F));
					}
					else
					{
						u000B_u.\u001F = \u0018\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this));
						u000B_u.\u0007 = Array.Empty<ViewInfo>();
					}
					this.\u0018\u0018(new Action(u000B_u.\u0019), "ViewAligner_AlignViews");
					if (\u0007\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this)))
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
						\u0003\u0019.\u0002\u0019 u0002_u = new \u0003\u0019.\u0002\u0019();
						u0002_u.\u0007 = u000B_u;
						OperationResultList<long> u001D = u0002_u.\u0007.\u0004.\u001D;
						int num;
						if (u001D == null)
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
							num = 0;
						}
						else
						{
							num = \u001C\u000E\u001D.\u000A(\u000E\u000D\u001D.\u0007(u001D));
						}
						OperationResultList<long> u = u0002_u.\u0007.\u0004.\u0004;
						int num2;
						if (u == null)
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
							num2 = 0;
						}
						else
						{
							num2 = \u001C\u000E\u001D.\u000A(\u000E\u000D\u001D.\u0007(u));
						}
						int u001F = num + num2;
						this.\u0006\u0018(u001F, ref u0002_u.\u0007.\u0004.\u0007);
						\u0003\u0019.\u0002\u0019 u0002_u2 = u0002_u;
						IEnumerable<OperationResult<long>> enumerable2 = \u000F\u000D\u001D.\u0007(u0002_u.\u0007.\u0004.\u001D);
						Func<OperationResult<long>, long> func2;
						if ((func2 = \u0003\u0019.<>c.\u0007) == null)
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
							func2 = (\u0003\u0019.<>c.\u0007 = new Func<OperationResult<long>, long>(\u0003\u0019.<>c.\u001F.\u000B));
						}
						u0002_u2.\u001F = \u0002\u001C\u001D.\u000A(Enumerable.Select<OperationResult<long>, long>(enumerable2, func2));
						object u001F2 = u0002_u.\u001F;
						IEnumerable<OperationResult<long>> enumerable3 = \u000F\u000D\u001D.\u0007(u0002_u.\u0007.\u0004.\u0004);
						Func<OperationResult<long>, long> func3;
						if ((func3 = \u0003\u0019.<>c.\u001D) == null)
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
							func3 = (\u0003\u0019.<>c.\u001D = new Func<OperationResult<long>, long>(\u0003\u0019.<>c.\u001F.\u0002));
						}
						\u0003\u000E\u001D.\u000A(u001F2, Enumerable.Select<OperationResult<long>, long>(enumerable3, func3));
						u0002_u.\u000A = Enumerable.Where<ViewInfo>(\u0018\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this)), new Func<ViewInfo, bool>(u0002_u.\u001D));
						this.\u0018\u0018(new Action(u0002_u.\u0004), "ViewAligner_AlignTitles");
						IEnumerable<OperationResult<long>> enumerable4 = \u000E\u000D\u001D.\u001D(u0002_u.\u0007.\u0004.\u0019);
						Func<OperationResult<long>, bool> func4;
						if ((func4 = \u0003\u0019.<>c.\u0004) == null)
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
							func4 = (\u0003\u0019.<>c.\u0004 = new Func<OperationResult<long>, bool>(\u0003\u0019.<>c.\u001F.\u0006));
						}
						if (Enumerable.Any<OperationResult<long>>(enumerable4, func4))
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
							this.\u0006\u0018(\u0012\u000E\u001D.\u000A(u0002_u.\u001F), ref u0002_u.\u0007.\u0004.\u0007);
						}
					}
					flag = (\u000C\u0017\u0007.\u000A(transactionGroup) == 3);
				}
				catch (Exception ex)
				{
					\u001A\u0017\u0007.\u000A(transactionGroup);
					\u000F\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), ex, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\ViewAligner\\ExternalEvents\\ViewAlignerEventInfo.cs", "AlignViews");
					if (\u0013\u001D\u000E.\u001F(ex) == null)
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
						\u0006\u000E\u001D.\u000A(this.\u0011, ex);
					}
				}
				finally
				{
					IProgressWindowService u001B = this.\u001B;
					\u001F\u000E\u001D.\u000A(u001B, \u001A\u001D\u000E.\u001F(\u0012\u001E\u000A.\u000A(\u000A\u000E\u001D.\u000A(u001B), new ContentRenderedDelegate(this.\u0019\u0018))));
					\u0002\u000E\u001D.\u000A(this.\u001B);
				}
				if (flag)
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
					this.\u000B\u0018(u0016_u.\u001F, u0016_u.\u001D, u0016_u.\u0004, u0016_u.\u0019);
				}
				\u0003\u0019.\u0005\u0019 u001F3 = this.\u001F;
				if (u001F3 == null)
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
					\u000B\u000E\u001D.\u000A(u001F3, \u000C\u001D\u000E.\u001F);
				}
				\u0005\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\ViewAligner\\ExternalEvents\\ViewAlignerEventInfo.cs", "AlignViews");
			}
			finally
			{
				if (transactionGroup != null)
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
					\u001F\u0017\u000A.\u000A(transactionGroup);
				}
			}
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x0002D348 File Offset: 0x0002B548
		private void \u0018\u0018(Action \u001F, string \u000A)
		{
			Transaction transaction = \u001D\u0014\u0007.\u000A(this.\u0004\u0018, \u000A);
			try
			{
				\u0007\u0014\u0007.\u000A(transaction);
				\u001B\u0015\u0007.\u000A(\u001F);
				\u001B\u0001\u000A.\u000A(transaction);
			}
			finally
			{
				if (transaction != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0019.\u0018\u0018(Action, string)).MethodHandle;
					}
					\u001F\u0017\u000A.\u000A(transaction);
				}
			}
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x0002D3B0 File Offset: 0x0002B5B0
		private OperationResultList<long> \u0005\u0018(Action \u001F, CancellationToken \u000A)
		{
			\u0003\u0019.\u0006\u0019 u0006_u = new \u0003\u0019.\u0006\u0019();
			u0006_u.\u001F = \u001F;
			long u000A = \u0019\u0003\u001D.\u0007(\u0011\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this)));
			IEnumerable<ViewInfo> enumerable = \u0018\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this));
			Func<ViewInfo, long> func;
			if ((func = \u0003\u0019.<>c.\u0019) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0019.\u0005\u0018(Action, CancellationToken)).MethodHandle;
				}
				func = (\u0003\u0019.<>c.\u0019 = new Func<ViewInfo, long>(\u0003\u0019.<>c.\u001F.\u000F));
			}
			IEnumerable<long> u = Enumerable.Select<ViewInfo, long>(enumerable, func);
			return \u001B\u000E\u001D.\u000A(this.\u0008, u000A, u, new Action<long>(u0006_u.\u000A), new CancellationToken?(\u000A));
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x0002D44C File Offset: 0x0002B64C
		private OperationResultList<long> \u0019\u0018(IEnumerable<ViewInfo> \u001F, AlignmentMode \u000A, Action \u0007, CancellationToken \u001D)
		{
			\u0003\u0019.\u000F\u0019 u000F_u = new \u0003\u0019.\u000F\u0019();
			u000F_u.\u001F = \u0007;
			if (!Enumerable.Any<ViewInfo>(\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0019.\u0019\u0018(IEnumerable<ViewInfo>, AlignmentMode, Action, CancellationToken)).MethodHandle;
				}
				return \u0017\u000E\u001D.\u000A(Array.Empty<OperationResult<long>>(), \u000F\u0015\u0010.\u001F);
			}
			long u000A = \u0020\u000E\u001D.\u0007(\u0011\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this)));
			Func<ViewInfo, long> func;
			if ((func = \u0003\u0019.<>c.\u0018) == null)
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
				func = (\u0003\u0019.<>c.\u0018 = new Func<ViewInfo, long>(\u0003\u0019.<>c.\u001F.\u0012));
			}
			IEnumerable<long> u = Enumerable.Select<ViewInfo, long>(\u001F, func);
			return \u001E\u000E\u001D.\u000A(this.\u000E, u000A, u, \u000A, new Action<long>(u000F_u.\u000A), new CancellationToken?(\u001D));
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x0002D504 File Offset: 0x0002B704
		private OperationResultList<long> \u0016\u0018(IEnumerable<ViewInfo> \u001F, Action \u000A, CancellationToken \u0007)
		{
			\u0003\u0019.\u0012\u0019 u0012_u = new \u0003\u0019.\u0012\u0019();
			u0012_u.\u001F = \u000A;
			long u000A = \u0020\u000E\u001D.\u0007(\u0011\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this)));
			Func<ViewInfo, long> func;
			if ((func = \u0003\u0019.<>c.\u0005) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0019.\u0016\u0018(IEnumerable<ViewInfo>, Action, CancellationToken)).MethodHandle;
				}
				func = (\u0003\u0019.<>c.\u0005 = new Func<ViewInfo, long>(\u0003\u0019.<>c.\u001F.\u0003));
			}
			IEnumerable<long> u = Enumerable.Select<ViewInfo, long>(\u001F, func);
			return \u0014\u000E\u001D.\u000A(this.\u000E, u000A, u, new Action<long>(u0012_u.\u000A), new CancellationToken?(\u0007));
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x0002D594 File Offset: 0x0002B794
		private void \u000B\u0018(OperationResultList<long> \u001F, OperationResultList<long> \u000A, OperationResultList<long> \u0007, OperationResultList<long> \u001D)
		{
			\u001D\u0019 u001D_u = new \u001D\u0019();
			\u0009\u000E\u001D.\u000A(u001D_u, \u0011\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this)));
			\u0001\u000E\u001D.\u000A(u001D_u, \u0018\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this)));
			List<AlignReport> list = Enumerable.ToList<AlignReport>(u001D_u.\u001D(\u001F, \u000A, \u0007, \u001D));
			if (\u0004\u0010\u001D.\u000A(list) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0019.\u000B\u0018(OperationResultList<long>, OperationResultList<long>, OperationResultList<long>, OperationResultList<long>)).MethodHandle;
				}
				\u000C\u000E\u001D.\u000A(this.\u0011, list, \u0015\u000E\u001D.\u000A());
				return;
			}
			\u0013\u000E\u001D.\u000A(this.\u0011, \u001A\u000E\u001D.\u000A());
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x0002D628 File Offset: 0x0002B828
		private void \u0002\u0018(ref int \u001F)
		{
			\u001F\u0008\u001D.\u000A(this.\u001B, \u001F, "");
			\u001F++;
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x0002D650 File Offset: 0x0002B850
		private unsafe void \u0006\u0018(int \u001F, ref int \u000A)
		{
			for (int i = 0; i < \u001F; i++)
			{
				this.\u0002\u0018(ref \u000A);
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0019.\u0006\u0018(int, int*)).MethodHandle;
			}
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x0002D684 File Offset: 0x0002B884
		private static bool \u000F\u0018(ViewInfo \u001F, ViewInfo \u000A)
		{
			if (\u0018\u001C\u001D.\u001D(\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0019.\u000F\u0018(ViewInfo, ViewInfo)).MethodHandle;
				}
				return \u000A\u0008\u001D.\u0007(\u001F) == \u000A\u0008\u001D.\u0007(\u000A);
			}
			return false;
		}

		// Token: 0x04000322 RID: 802
		private readonly ISheetLayoutService \u000E;

		// Token: 0x04000323 RID: 803
		private readonly ICropViewService \u0008;

		// Token: 0x04000324 RID: 804
		private readonly IProgressWindowService \u001B;

		// Token: 0x04000325 RID: 805
		private readonly IReportingService \u0011;

		// Token: 0x04000326 RID: 806
		private UIApplication \u001E;

		// Token: 0x04000327 RID: 807
		[CompilerGenerated]
		private AlignSettings \u0020;

		// Token: 0x020007DA RID: 2010
		// (Invoke) Token: 0x06004CDB RID: 19675
		public delegate void \u0005\u0019(ITaskFinishedArgs args);

		// Token: 0x020007DC RID: 2012
		[CompilerGenerated]
		private sealed class \u0016\u0019
		{
			// Token: 0x06004CE8 RID: 19688 RVA: 0x001DD168 File Offset: 0x001DB368
			internal void \u0002()
			{
				\u0003\u0019 u000A = this.\u000A;
				Action u001F;
				if ((u001F = this.\u0018) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0019.\u0016\u0019.\u0002()).MethodHandle;
					}
					u001F = (this.\u0018 = new Action(this.\u0006));
				}
				this.\u001F = u000A.\u0005\u0018(u001F, \u0007\u0016\u000D.\u0007(\u000C\u0009\u000D.\u000A(this.\u000A.\u001B)));
			}

			// Token: 0x06004CE9 RID: 19689 RVA: 0x001DD1D4 File Offset: 0x001DB3D4
			internal void \u0006()
			{
				this.\u000A.\u0002\u0018(ref this.\u0007);
			}

			// Token: 0x06004CEA RID: 19690 RVA: 0x001DD1F4 File Offset: 0x001DB3F4
			internal bool \u000F(ViewInfo \u001F)
			{
				return \u0003\u0019.\u000F\u0018(\u001F, \u0011\u000E\u001D.\u000A(\u001D\u000E\u001D.\u000A(this.\u000A)));
			}

			// Token: 0x06004CEB RID: 19691 RVA: 0x001DD220 File Offset: 0x001DB420
			internal void \u0012()
			{
				this.\u000A.\u0002\u0018(ref this.\u0007);
			}

			// Token: 0x06004CEC RID: 19692 RVA: 0x001DD240 File Offset: 0x001DB440
			internal void \u0003()
			{
				this.\u000A.\u0002\u0018(ref this.\u0007);
			}

			// Token: 0x06004CED RID: 19693 RVA: 0x001DD260 File Offset: 0x001DB460
			internal void \u001C()
			{
				this.\u000A.\u0002\u0018(ref this.\u0007);
			}

			// Token: 0x04001FD7 RID: 8151
			public OperationResultList<long> \u001F;

			// Token: 0x04001FD8 RID: 8152
			public \u0003\u0019 \u000A;

			// Token: 0x04001FD9 RID: 8153
			public int \u0007;

			// Token: 0x04001FDA RID: 8154
			public OperationResultList<long> \u001D;

			// Token: 0x04001FDB RID: 8155
			public OperationResultList<long> \u0004;

			// Token: 0x04001FDC RID: 8156
			public OperationResultList<long> \u0019;

			// Token: 0x04001FDD RID: 8157
			public Action \u0018;

			// Token: 0x04001FDE RID: 8158
			public Action \u0005;

			// Token: 0x04001FDF RID: 8159
			public Action \u0016;

			// Token: 0x04001FE0 RID: 8160
			public Action \u000B;
		}

		// Token: 0x020007DD RID: 2013
		[CompilerGenerated]
		private sealed class \u000B\u0019
		{
			// Token: 0x06004CEF RID: 19695 RVA: 0x001DD294 File Offset: 0x001DB494
			internal void \u0019()
			{
				\u0003\u0019.\u0016\u0019 u = this.\u0004;
				\u0003\u0019 u000A = this.\u0004.\u000A;
				IEnumerable<ViewInfo> u001F = this.\u001F;
				AlignmentMode u000A2 = this.\u000A;
				Action u2;
				if ((u2 = this.\u0004.\u0005) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0019.\u000B\u0019.\u0019()).MethodHandle;
					}
					u2 = (this.\u0004.\u0005 = new Action(this.\u0004.\u0012));
				}
				u.\u001D = u000A.\u0019\u0018(u001F, u000A2, u2, \u0007\u0016\u000D.\u0007(\u000C\u0009\u000D.\u000A(this.\u0004.\u000A.\u001B)));
				\u0003\u0019.\u0016\u0019 u3 = this.\u0004;
				\u0003\u0019 u000A3 = this.\u0004.\u000A;
				IEnumerable<ViewInfo> u4 = this.\u0007;
				AlignmentMode u001D = this.\u001D;
				Action u5;
				if ((u5 = this.\u0004.\u0016) == null)
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
					u5 = (this.\u0004.\u0016 = new Action(this.\u0004.\u0003));
				}
				u3.\u0004 = u000A3.\u0019\u0018(u4, u001D, u5, \u0007\u0016\u000D.\u0007(\u000C\u0009\u000D.\u000A(this.\u0004.\u000A.\u001B)));
			}

			// Token: 0x04001FE1 RID: 8161
			public IEnumerable<ViewInfo> \u001F;

			// Token: 0x04001FE2 RID: 8162
			public AlignmentMode \u000A;

			// Token: 0x04001FE3 RID: 8163
			public IEnumerable<ViewInfo> \u0007;

			// Token: 0x04001FE4 RID: 8164
			public AlignmentMode \u001D;

			// Token: 0x04001FE5 RID: 8165
			public \u0003\u0019.\u0016\u0019 \u0004;
		}

		// Token: 0x020007DE RID: 2014
		[CompilerGenerated]
		private sealed class \u0002\u0019
		{
			// Token: 0x06004CF1 RID: 19697 RVA: 0x001DD3BC File Offset: 0x001DB5BC
			internal bool \u001D(ViewInfo \u001F)
			{
				return \u0016\u001C\u001D.\u000A(this.\u001F, \u0020\u000E\u001D.\u0007(\u001F));
			}

			// Token: 0x06004CF2 RID: 19698 RVA: 0x001DD3E0 File Offset: 0x001DB5E0
			internal void \u0004()
			{
				\u0003\u0019.\u0016\u0019 u = this.\u0007.\u0004;
				\u0003\u0019 u000A = this.\u0007.\u0004.\u000A;
				IEnumerable<ViewInfo> u000A2 = this.\u000A;
				Action u000A3;
				if ((u000A3 = this.\u0007.\u0004.\u000B) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0019.\u0002\u0019.\u0004()).MethodHandle;
					}
					u000A3 = (this.\u0007.\u0004.\u000B = new Action(this.\u0007.\u0004.\u001C));
				}
				u.\u0019 = u000A.\u0016\u0018(u000A2, u000A3, \u0007\u0016\u000D.\u0007(\u000C\u0009\u000D.\u000A(this.\u0007.\u0004.\u000A.\u001B)));
			}

			// Token: 0x04001FE6 RID: 8166
			public HashSet<long> \u001F;

			// Token: 0x04001FE7 RID: 8167
			public IEnumerable<ViewInfo> \u000A;

			// Token: 0x04001FE8 RID: 8168
			public \u0003\u0019.\u000B\u0019 \u0007;
		}

		// Token: 0x020007DF RID: 2015
		[CompilerGenerated]
		private sealed class \u0006\u0019
		{
			// Token: 0x06004CF4 RID: 19700 RVA: 0x001DD4A4 File Offset: 0x001DB6A4
			internal void \u000A(long \u001F)
			{
				\u001B\u0015\u0007.\u000A(this.\u001F);
			}

			// Token: 0x04001FE9 RID: 8169
			public Action \u001F;
		}

		// Token: 0x020007E0 RID: 2016
		[CompilerGenerated]
		private sealed class \u000F\u0019
		{
			// Token: 0x06004CF6 RID: 19702 RVA: 0x001DD4D0 File Offset: 0x001DB6D0
			internal void \u000A(long \u001F)
			{
				\u001B\u0015\u0007.\u000A(this.\u001F);
			}

			// Token: 0x04001FEA RID: 8170
			public Action \u001F;
		}

		// Token: 0x020007E1 RID: 2017
		[CompilerGenerated]
		private sealed class \u0012\u0019
		{
			// Token: 0x06004CF8 RID: 19704 RVA: 0x001DD4FC File Offset: 0x001DB6FC
			internal void \u000A(long \u001F)
			{
				\u001B\u0015\u0007.\u000A(this.\u001F);
			}

			// Token: 0x04001FEB RID: 8171
			public Action \u001F;
		}
	}
}
