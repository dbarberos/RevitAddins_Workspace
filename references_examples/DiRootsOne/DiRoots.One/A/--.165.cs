using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Services;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.One.SheetGen;
using DiRoots.One.SheetGen.Delegates;
using DiRoots.One.SheetGen.Models;
using DiRoots.One.SheetGen.Services;
using DiRoots.One.UIBehaviours.Win32;

namespace A
{
	// Token: 0x020002A6 RID: 678
	internal abstract class \u001F\u001B<\u0004> : ExternalEventInfo where \u0004 : ISheetModel
	{
		// Token: 0x06001AC1 RID: 6849 RVA: 0x000AE0AC File Offset: 0x000AC2AC
		public \u001F\u001B(\u001A\u001A<\u0004> \u001F, ISheetNumberValidationService \u000A, ICancellationManagerService \u0007, ICustomLogger \u001D, ISheetFinalRenumberingService \u0004)
		{
			this.\u000B\u0007 = \u0004\u001B\u0019.\u000A(\u0019\u001B\u0019.\u000A());
			this.\u001E\u0007 = \u001F;
			this.\u0020\u0007 = \u000A;
			this.\u0014\u0007 = \u0007;
			\u0019\u0010\u001D.\u001D(this, \u001D);
			this.\u0017\u0007 = \u0004;
		}

		// Token: 0x17000757 RID: 1879
		// (get) Token: 0x06001AC2 RID: 6850 RVA: 0x000AE110 File Offset: 0x000AC310
		// (set) Token: 0x06001AC3 RID: 6851 RVA: 0x000AE124 File Offset: 0x000AC324
		public IEnumerable<\u0004> ItemsToHandle { get; set; } = Array.Empty<\u0004>();

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x06001AC4 RID: 6852 RVA: 0x000AE138 File Offset: 0x000AC338
		// (remove) Token: 0x06001AC5 RID: 6853 RVA: 0x000AE188 File Offset: 0x000AC388
		public event CreateSheetsAndViewsProgressHandler \u001A\u0007
		{
			[CompilerGenerated]
			add
			{
				CreateSheetsAndViewsProgressHandler createSheetsAndViewsProgressHandler = this.\u001A\u0007;
				CreateSheetsAndViewsProgressHandler createSheetsAndViewsProgressHandler2;
				do
				{
					createSheetsAndViewsProgressHandler2 = createSheetsAndViewsProgressHandler;
					CreateSheetsAndViewsProgressHandler value2 = \u0014\u0003\u000E.\u001F(\u000F\u001E\u000A.\u000A(createSheetsAndViewsProgressHandler2, value));
					createSheetsAndViewsProgressHandler = Interlocked.CompareExchange<CreateSheetsAndViewsProgressHandler>(ref this.\u001A\u0007, value2, createSheetsAndViewsProgressHandler2);
				}
				while (createSheetsAndViewsProgressHandler != createSheetsAndViewsProgressHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u001B.add_\u001A\u0007(CreateSheetsAndViewsProgressHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				CreateSheetsAndViewsProgressHandler createSheetsAndViewsProgressHandler = this.\u001A\u0007;
				CreateSheetsAndViewsProgressHandler createSheetsAndViewsProgressHandler2;
				do
				{
					createSheetsAndViewsProgressHandler2 = createSheetsAndViewsProgressHandler;
					CreateSheetsAndViewsProgressHandler value2 = \u0014\u0003\u000E.\u001F(\u0012\u001E\u000A.\u000A(createSheetsAndViewsProgressHandler2, value));
					createSheetsAndViewsProgressHandler = Interlocked.CompareExchange<CreateSheetsAndViewsProgressHandler>(ref this.\u001A\u0007, value2, createSheetsAndViewsProgressHandler2);
				}
				while (createSheetsAndViewsProgressHandler != createSheetsAndViewsProgressHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u001B.remove_\u001A\u0007(CreateSheetsAndViewsProgressHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x06001AC6 RID: 6854 RVA: 0x000AE1D8 File Offset: 0x000AC3D8
		// (remove) Token: 0x06001AC7 RID: 6855 RVA: 0x000AE228 File Offset: 0x000AC428
		public event CreateSheetsAndViewsFinishedHandler \u000C\u0007
		{
			[CompilerGenerated]
			add
			{
				CreateSheetsAndViewsFinishedHandler createSheetsAndViewsFinishedHandler = this.\u000C\u0007;
				CreateSheetsAndViewsFinishedHandler createSheetsAndViewsFinishedHandler2;
				do
				{
					createSheetsAndViewsFinishedHandler2 = createSheetsAndViewsFinishedHandler;
					CreateSheetsAndViewsFinishedHandler value2 = \u0017\u0003\u000E.\u001F(\u000F\u001E\u000A.\u000A(createSheetsAndViewsFinishedHandler2, value));
					createSheetsAndViewsFinishedHandler = Interlocked.CompareExchange<CreateSheetsAndViewsFinishedHandler>(ref this.\u000C\u0007, value2, createSheetsAndViewsFinishedHandler2);
				}
				while (createSheetsAndViewsFinishedHandler != createSheetsAndViewsFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u001B.add_\u000C\u0007(CreateSheetsAndViewsFinishedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				CreateSheetsAndViewsFinishedHandler createSheetsAndViewsFinishedHandler = this.\u000C\u0007;
				CreateSheetsAndViewsFinishedHandler createSheetsAndViewsFinishedHandler2;
				do
				{
					createSheetsAndViewsFinishedHandler2 = createSheetsAndViewsFinishedHandler;
					CreateSheetsAndViewsFinishedHandler value2 = \u0017\u0003\u000E.\u001F(\u0012\u001E\u000A.\u000A(createSheetsAndViewsFinishedHandler2, value));
					createSheetsAndViewsFinishedHandler = Interlocked.CompareExchange<CreateSheetsAndViewsFinishedHandler>(ref this.\u000C\u0007, value2, createSheetsAndViewsFinishedHandler2);
				}
				while (createSheetsAndViewsFinishedHandler != createSheetsAndViewsFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u001B.remove_\u000C\u0007(CreateSheetsAndViewsFinishedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x06001AC8 RID: 6856 RVA: 0x000AE278 File Offset: 0x000AC478
		public override void Execute(UIApplication app)
		{
			try
			{
				this.\u000B\u0019(app);
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\UpdateSheetsEvent.cs", "Execute");
				\u000D\u0014\u0004.\u000A(\u0013\u0007\u0016.\u000A(), u000A, true);
			}
		}

		// Token: 0x06001AC9 RID: 6857 RVA: 0x000AE2C8 File Offset: 0x000AC4C8
		protected virtual void \u000B\u0019(UIApplication \u001F)
		{
			\u001F\u001B<\u0004>.\u0015\u0008 u0015_u = new \u001F\u001B<\u0004>.\u0015\u0008();
			u0015_u.\u001F = this;
			\u0008\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\UpdateSheetsEvent.cs", "ExecuteInternal");
			Document document = \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(\u001F));
			List<\u0004> list = Enumerable.ToList<\u0004>(this.ItemsToHandle);
			this.\u001C\u0016(list);
			u0015_u.\u000A = list.Count;
			if (u0015_u.\u000A == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u001B.\u000B\u0019(UIApplication)).MethodHandle;
				}
				\u0005\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\UpdateSheetsEvent.cs", "ExecuteInternal");
				return;
			}
			TransactionGroup transactionGroup = \u0009\u0017\u0007.\u000A(document, "SheetGen_ApplyModifications");
			try
			{
				TransactionStatus transactionStatus = \u0001\u0017\u0007.\u000A(transactionGroup);
				u0015_u.\u0007 = 0;
				IEnumerable<\u0004> enumerable = list;
				Func<\u0004, bool> func;
				if ((func = \u001F\u001B<\u0004>.<>c.\u000A) == null)
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
					func = (\u001F\u001B<\u0004>.<>c.\u000A = new Func<\u0004, bool>(\u001F\u001B<\u0004>.<>c.\u001F.\u0004));
				}
				List<\u0004> u000A = Enumerable.ToList<\u0004>(Enumerable.Where<\u0004>(enumerable, func));
				this.\u000F\u0019(document, u000A, new Action<\u0011\u000C<\u0004>>(u0015_u.\u001D));
				IEnumerable<\u0004> enumerable2 = list;
				Func<\u0004, bool> func2;
				if ((func2 = \u001F\u001B<\u0004>.<>c.\u0007) == null)
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
					func2 = (\u001F\u001B<\u0004>.<>c.\u0007 = new Func<\u0004, bool>(\u001F\u001B<\u0004>.<>c.\u001F.\u0019));
				}
				List<\u0004> u000A2 = Enumerable.ToList<\u0004>(Enumerable.Where<\u0004>(enumerable2, func2));
				this.\u0002\u0019(document, u000A2, new Action<\u0004>(u0015_u.\u0004));
				IEnumerable<\u0004> enumerable3 = list;
				Func<\u0004, bool> func3;
				if ((func3 = \u001F\u001B<\u0004>.<>c.\u001D) == null)
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
					func3 = (\u001F\u001B<\u0004>.<>c.\u001D = new Func<\u0004, bool>(\u001F\u001B<\u0004>.<>c.\u001F.\u0018));
				}
				List<\u0004> sheets = Enumerable.ToList<\u0004>(Enumerable.Where<\u0004>(enumerable3, func3));
				this.\u0017\u0007.ApplySheetNumbers<\u0004>(document, sheets, this.\u0011\u0007);
				transactionStatus = \u000C\u0017\u0007.\u000A(transactionGroup);
				\u0009\u0004\u001D.\u000A(this, transactionStatus == 3);
				this.\u000F\u0016(\u0014\u0019\u001D.\u0007(this), false);
				\u0005\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\UpdateSheetsEvent.cs", "ExecuteInternal");
			}
			finally
			{
				if (transactionGroup != null)
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
					\u001F\u0017\u000A.\u000A(transactionGroup);
				}
			}
		}

		// Token: 0x06001ACA RID: 6858 RVA: 0x000AE4DC File Offset: 0x000AC6DC
		protected virtual void \u000F\u0019(Document \u001F, IEnumerable<\u0004> \u000A, Action<\u0011\u000C<\u0004>> \u0007)
		{
			\u001F\u001B<\u0004>.\u0001\u0008 u0001_u = new \u001F\u001B<\u0004>.\u0001\u0008();
			u0001_u.\u001F = this;
			u0001_u.\u000A = \u001F;
			IEnumerator<\u0004> enumerator = \u000A.GetEnumerator();
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u001F\u001B<\u0004>.\u0009\u0008 u0009_u = new \u001F\u001B<\u0004>.\u0009\u0008();
					u0009_u.\u001D = u0001_u;
					u0009_u.\u001F = enumerator.Current;
					\u0018\u0004\u0016.\u000A(this.\u0014\u0007);
					string u000A = \u001E\u0020\u001D.\u000A("SheetGen_ApplyModification", u0009_u.\u001F.SheetNumber, "-", u0009_u.\u001F.SheetName);
					\u0008\u0008\u000A u0008_u0008_u000A = this.\u0012\u0016("");
					u0009_u.\u000A = new \u0011\u000C<\u0004>(u0009_u.\u001F);
					u0009_u.\u0007 = false;
					TransactionStatus u001F = \u0004\u0004\u0016.\u000A(u0009_u.\u001D.\u000A, u000A, u0008_u0008_u000A, new Action(u0009_u.\u0004), new Action<Exception>(u0009_u.\u0019));
					\u0007(u0009_u.\u000A);
					\u001F\u0004\u0016.\u0007(\u000A\u0004\u0016.\u0007(u0008_u0008_u000A));
					if (u001F.\u0018())
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u001B.\u000F\u0019(Document, IEnumerable<\u0004>, Action<\u0011\u000C<\u0004>>)).MethodHandle;
						}
						if (!u0009_u.\u0007)
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
							this.\u0006\u0019(u0009_u.\u001D.\u000A, u0009_u.\u001F, \u0009\u001D\u0016.\u000A(u0008_u0008_u000A));
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}

		// Token: 0x06001ACB RID: 6859
		protected abstract void \u0002\u0019(Document \u001F, IEnumerable<\u0004> \u000A, Action<\u0004> \u0007);

		// Token: 0x06001ACC RID: 6860 RVA: 0x000AE670 File Offset: 0x000AC870
		protected void \u000F\u0016(bool \u001F, bool \u000A)
		{
			if (!\u0010\u0018\u0016.\u000A(this.\u0014\u0007))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u001B.\u000F\u0016(bool, bool)).MethodHandle;
				}
				CreateSheetsAndViewsFinishedHandler u000C_u = this.\u000C\u0007;
				if (u000C_u == null)
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
					\u000D\u0006\u0016.\u000A(u000C_u, \u001F, \u000A, this.\u0011\u0007);
				}
			}
			this.\u001A\u0007 = \u001E\u0003\u000E.\u001F;
			this.\u000C\u0007 = \u0020\u0003\u000E.\u001F;
		}

		// Token: 0x06001ACD RID: 6861 RVA: 0x000AE6D8 File Offset: 0x000AC8D8
		protected \u0008\u0008\u000A \u0012\u0016(string \u001F = "")
		{
			\u0008\u0008\u000A u0008_u0008_u000A = new \u0008\u0008\u000A();
			\u0001\u000B\u0016.\u000A(u0008_u0008_u000A, \u001F);
			IntPtr u000B_u = this.\u000B\u0007;
			WindowInterceptor.ProcessWindow u000A;
			if ((u000A = \u001F\u001B<\u0004>.\u000C\u0008.\u001F) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u001B.\u0012\u0016(string)).MethodHandle;
				}
				u000A = (\u001F\u001B<\u0004>.\u000C\u0008.\u001F = new WindowInterceptor.ProcessWindow(\u001F\u001B<\u0004>.\u000D\u0005));
			}
			\u000C\u000B\u0016.\u000A(u0008_u0008_u000A, \u0015\u000B\u0016.\u000A(u000B_u, u000A));
			return u0008_u0008_u000A;
		}

		// Token: 0x06001ACE RID: 6862 RVA: 0x000AE734 File Offset: 0x000AC934
		protected void \u0006\u0019(Document \u001F, \u0004 \u000A, Exception \u0007)
		{
			\u000F\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), \u0007, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\UpdateSheetsEvent.cs", "ReportAndRollbackSheetFailure");
			this.\u0006\u0019(\u001F, \u000A, \u0003\u001A\u000A.\u000A(\u0007));
		}

		// Token: 0x06001ACF RID: 6863 RVA: 0x000AE76C File Offset: 0x000AC96C
		protected unsafe void \u0003\u0016(\u0004 \u001F, int \u000A, ref int \u0007)
		{
			int num = 10;
			\u0007++;
			if (\u0007 % num == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u001B.\u0003\u0016(\u0004, int, int*)).MethodHandle;
				}
				int u000A = \u0007 * 100 / \u000A;
				string sheetNumber = \u001F.SheetNumber;
				string u000A2 = " + ";
				string u;
				if (!\u001A\u0006\u0007.\u000A(\u001F.SheetName))
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
					u = \u001F.SheetName;
				}
				else
				{
					u = "Unnamed";
				}
				string u2 = \u0002\u0013\u000A.\u000A(sheetNumber, u000A2, u);
				CreateSheetsAndViewsProgressHandler u001A_u = this.\u001A\u0007;
				if (u001A_u == null)
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
				\u0010\u0006\u0016.\u000A(u001A_u, u000A, u2);
			}
		}

		// Token: 0x06001AD0 RID: 6864 RVA: 0x000AE818 File Offset: 0x000ACA18
		protected void \u001C\u0016(IList<\u0004> \u001F)
		{
			IList<ISheetModel> list = \u001E\u0006\u0016.\u000A(this.\u0020\u0007, Enumerable.Cast<ISheetModel>(\u001F));
			if (!Enumerable.Any<ISheetModel>(list))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u001B.\u001C\u0016(IList<\u0004>)).MethodHandle;
				}
				return;
			}
			ShowMessage u001F = \u0020\u0019\u001D.\u000A(\u0011\u0006\u0016.\u000A(), MessageBoxButtons.YesNo);
			\u0018\u0020\u000A.\u0007(u001F);
			MessageBoxResult messageBoxResult = \u001B\u0006\u0016.\u000A(u001F);
			if (messageBoxResult == MessageBoxResult.No)
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
				IEnumerator<ISheetModel> enumerator = \u0008\u0006\u0016.\u000A(list);
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						\u0004 item = (\u0004)((object)\u000E\u0006\u0016.\u000A(enumerator));
						\u001F.Remove(item);
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
					return;
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
			if (messageBoxResult == MessageBoxResult.None)
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
				\u001F.Clear();
			}
		}

		// Token: 0x06001AD1 RID: 6865 RVA: 0x000AE8F8 File Offset: 0x000ACAF8
		protected virtual void \u0006\u0019(Document \u001F, \u0004 \u000A, string \u0007)
		{
			if (\u001A\u0006\u0007.\u000A(\u0007))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u001B.\u0006\u0019(Document, \u0004, string)).MethodHandle;
				}
				return;
			}
			\u0011\u001D\u0016.\u000A(this.\u0011\u0007, \u001F\u001B<\u0004>.\u000B\u0005(\u000A, \u0007, ReportStates.Error));
			if (\u000A.UpdateState != UpdateStates.ToAdd)
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
				ref \u0004 ptr = ref \u000A;
				if (default(\u0004) == null)
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
					\u0004 u = \u000A;
					ptr = ref u;
				}
				ptr.UpdateState = \u000A.PreviousStatus;
			}
		}

		// Token: 0x06001AD2 RID: 6866 RVA: 0x000AE994 File Offset: 0x000ACB94
		protected static FailedSheetReport \u000B\u0005(\u0004 \u001F, string \u000A, ReportStates \u0007)
		{
			FailedSheetReport failedSheetReport = \u001C\u0018\u0016.\u000A();
			\u0012\u0018\u0016.\u000A(failedSheetReport, \u001F.SheetName);
			\u0006\u0018\u0016.\u000A(failedSheetReport, \u001F.SheetNumber);
			\u0002\u0018\u0016.\u000A(failedSheetReport, \u000A);
			\u0020\u0014\u0007.\u000A(failedSheetReport, \u0007);
			return failedSheetReport;
		}

		// Token: 0x06001AD3 RID: 6867 RVA: 0x000AE9E0 File Offset: 0x000ACBE0
		protected static FailedSheetReport \u000D\u0016(string \u001F)
		{
			FailedSheetReport failedSheetReport = \u001C\u0018\u0016.\u000A();
			\u0012\u0018\u0016.\u000A(failedSheetReport, "Project Information Parameters");
			\u0006\u0018\u0016.\u000A(failedSheetReport, "N/A");
			\u0002\u0018\u0016.\u000A(failedSheetReport, \u001F);
			\u0020\u0014\u0007.\u000A(failedSheetReport, ReportStates.Error);
			return failedSheetReport;
		}

		// Token: 0x06001AD4 RID: 6868 RVA: 0x000AEA18 File Offset: 0x000ACC18
		private static void \u000D\u0005(IntPtr \u001F)
		{
			\u0006\u0016\u0016.\u000A(\u001F, 16U, 0, 0);
		}

		// Token: 0x04000AA4 RID: 2724
		private readonly IntPtr \u000B\u0007;

		// Token: 0x04000AA5 RID: 2725
		protected readonly List<FailedSheetReport> \u0011\u0007 = new List<FailedSheetReport>();

		// Token: 0x04000AA6 RID: 2726
		protected readonly \u001A\u001A<\u0004> \u001E\u0007;

		// Token: 0x04000AA7 RID: 2727
		protected readonly ISheetNumberValidationService \u0020\u0007;

		// Token: 0x04000AA8 RID: 2728
		protected readonly ISheetFinalRenumberingService \u0017\u0007;

		// Token: 0x04000AA9 RID: 2729
		protected ICancellationManagerService \u0014\u0007;

		// Token: 0x04000AAA RID: 2730
		[CompilerGenerated]
		private IEnumerable<\u0004> \u0013\u0007;

		// Token: 0x0200097A RID: 2426
		[CompilerGenerated]
		private static class \u000C\u0008
		{
			// Token: 0x040024C0 RID: 9408
			public static WindowInterceptor.ProcessWindow \u001F;
		}

		// Token: 0x0200097C RID: 2428
		[CompilerGenerated]
		private sealed class \u0015\u0008
		{
			// Token: 0x060052F0 RID: 21232 RVA: 0x001EB83C File Offset: 0x001E9A3C
			internal void \u001D(\u0011\u000C<\u000A> \u001F)
			{
				this.\u001F.\u0003\u0016(\u001F.SheetModel, this.\u000A, ref this.\u0007);
			}

			// Token: 0x060052F1 RID: 21233 RVA: 0x001EB868 File Offset: 0x001E9A68
			internal void \u0004(\u000A \u001F)
			{
				this.\u001F.\u0003\u0016(\u001F, this.\u000A, ref this.\u0007);
			}

			// Token: 0x040024C5 RID: 9413
			public \u001F\u001B<\u000A> \u001F;

			// Token: 0x040024C6 RID: 9414
			public int \u000A;

			// Token: 0x040024C7 RID: 9415
			public int \u0007;
		}

		// Token: 0x0200097D RID: 2429
		[CompilerGenerated]
		private sealed class \u0001\u0008
		{
			// Token: 0x040024C8 RID: 9416
			public \u001F\u001B<\u0007> \u001F;

			// Token: 0x040024C9 RID: 9417
			public Document \u000A;
		}

		// Token: 0x0200097E RID: 2430
		[CompilerGenerated]
		private sealed class \u0009\u0008
		{
			// Token: 0x060052F4 RID: 21236 RVA: 0x001EB8B8 File Offset: 0x001E9AB8
			internal void \u0004()
			{
				if (!this.\u001D.\u001F.\u001E\u0007.\u000B(this.\u001F, out this.\u000A))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u001B.\u0009\u0008.\u0004()).MethodHandle;
					}
					\u0011\u001D\u0016.\u000A(this.\u001D.\u001F.\u0011\u0007, \u001F\u001B<\u001D>.\u000B\u0005(this.\u001F, \u0020\u0002\u0010.\u000A(), ReportStates.Error));
				}
			}

			// Token: 0x060052F5 RID: 21237 RVA: 0x001EB928 File Offset: 0x001E9B28
			internal void \u0019(Exception \u001F)
			{
				this.\u0007 = true;
				this.\u001D.\u001F.\u0006\u0019(this.\u001D.\u000A, this.\u001F, \u001F);
			}

			// Token: 0x040024CA RID: 9418
			public \u001D \u001F;

			// Token: 0x040024CB RID: 9419
			public \u0011\u000C<\u001D> \u000A;

			// Token: 0x040024CC RID: 9420
			public bool \u0007;

			// Token: 0x040024CD RID: 9421
			public \u001F\u001B<\u001D>.\u0001\u0008 \u001D;
		}
	}
}
