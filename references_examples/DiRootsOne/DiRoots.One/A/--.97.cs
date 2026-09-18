using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.TableGen.TGRevitHelper;
using DiRoots.One.TGDatabaseLayer;

namespace A
{
	// Token: 0x0200018C RID: 396
	internal class \u0002\u0002 : ExternalEventInfo
	{
		// Token: 0x14000012 RID: 18
		// (add) Token: 0x06000E95 RID: 3733 RVA: 0x0005C944 File Offset: 0x0005AB44
		// (remove) Token: 0x06000E96 RID: 3734 RVA: 0x0005C990 File Offset: 0x0005AB90
		internal event \u0002\u0002.\u0016\u0002 \u001F
		{
			[CompilerGenerated]
			add
			{
				\u0002\u0002.\u0016\u0002 u0016_u = this.\u001F;
				\u0002\u0002.\u0016\u0002 u0016_u2;
				do
				{
					u0016_u2 = u0016_u;
					\u0002\u0002.\u0016\u0002 value2 = (\u0002\u0002.\u0016\u0002)\u000F\u001E\u000A.\u000A(u0016_u2, value);
					u0016_u = Interlocked.CompareExchange<\u0002\u0002.\u0016\u0002>(ref this.\u001F, value2, u0016_u2);
				}
				while (u0016_u != u0016_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0002.add_\u001F(\u0002\u0002.\u0016\u0002)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				\u0002\u0002.\u0016\u0002 u0016_u = this.\u001F;
				\u0002\u0002.\u0016\u0002 u0016_u2;
				do
				{
					u0016_u2 = u0016_u;
					\u0002\u0002.\u0016\u0002 value2 = (\u0002\u0002.\u0016\u0002)\u0012\u001E\u000A.\u000A(u0016_u2, value);
					u0016_u = Interlocked.CompareExchange<\u0002\u0002.\u0016\u0002>(ref this.\u001F, value2, u0016_u2);
				}
				while (u0016_u != u0016_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0002.remove_\u001F(\u0002\u0002.\u0016\u0002)).MethodHandle;
				}
			}
		}

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x06000E97 RID: 3735 RVA: 0x0005C9DC File Offset: 0x0005ABDC
		// (remove) Token: 0x06000E98 RID: 3736 RVA: 0x0005CA28 File Offset: 0x0005AC28
		internal event \u0002\u0002.\u000B\u0002 \u0017
		{
			[CompilerGenerated]
			add
			{
				\u0002\u0002.\u000B\u0002 u000B_u = this.\u0017;
				\u0002\u0002.\u000B\u0002 u000B_u2;
				do
				{
					u000B_u2 = u000B_u;
					\u0002\u0002.\u000B\u0002 value2 = (\u0002\u0002.\u000B\u0002)\u000F\u001E\u000A.\u000A(u000B_u2, value);
					u000B_u = Interlocked.CompareExchange<\u0002\u0002.\u000B\u0002>(ref this.\u0017, value2, u000B_u2);
				}
				while (u000B_u != u000B_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0002.add_\u0017(\u0002\u0002.\u000B\u0002)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				\u0002\u0002.\u000B\u0002 u000B_u = this.\u0017;
				\u0002\u0002.\u000B\u0002 u000B_u2;
				do
				{
					u000B_u2 = u000B_u;
					\u0002\u0002.\u000B\u0002 value2 = (\u0002\u0002.\u000B\u0002)\u0012\u001E\u000A.\u000A(u000B_u2, value);
					u000B_u = Interlocked.CompareExchange<\u0002\u0002.\u000B\u0002>(ref this.\u0017, value2, u000B_u2);
				}
				while (u000B_u != u000B_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0002.remove_\u0017(\u0002\u0002.\u000B\u0002)).MethodHandle;
				}
			}
		}

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06000E99 RID: 3737 RVA: 0x0005CA74 File Offset: 0x0005AC74
		// (set) Token: 0x06000E9A RID: 3738 RVA: 0x0005CA88 File Offset: 0x0005AC88
		internal List<SelectedExcel> Views { get; set; }

		// Token: 0x06000E9B RID: 3739 RVA: 0x0005CA9C File Offset: 0x0005AC9C
		public override void Execute(UIApplication app)
		{
			\u0008\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\Core\\ExternalEvents\\UnlinkViewExternalEvent.cs", "Execute");
			try
			{
				this.\u0012\u0018(app);
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\Core\\ExternalEvents\\UnlinkViewExternalEvent.cs", "Execute");
			}
			\u0002\u0002.\u0016\u0002 u001F = this.\u001F;
			if (u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0002.Execute(UIApplication)).MethodHandle;
				}
			}
			else
			{
				\u0004\u0008\u0019.\u000A(u001F);
			}
			\u0005\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\Core\\ExternalEvents\\UnlinkViewExternalEvent.cs", "Execute");
		}

		// Token: 0x06000E9C RID: 3740 RVA: 0x0005CB2C File Offset: 0x0005AD2C
		private void \u0012\u0018(UIApplication \u001F)
		{
			Document u001F = \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(\u001F));
			Transaction transaction = \u0013\u0001\u000A.\u000A(u001F);
			try
			{
				\u0017\u0001\u000A.\u000A(transaction, "TableGen-Unlink View");
				int num = 1;
				List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(\u0016\u0008\u0019.\u000A(this));
				try
				{
					while (\u0001\u0005\u0004.\u000A(ref enumerator))
					{
						SelectedExcel selectedExcel = \u001F\u0016\u0004.\u000A(ref enumerator);
						try
						{
							int u000A = num++ * 100 / \u000C\u001B\u0004.\u000A(\u0016\u0008\u0019.\u000A(this));
							\u0005\u0008\u0019.\u000A(this.\u0017, u000A, \u0002\u0013\u000A.\u000A(\u000F\u0007\u0019.\u000A(), ":", \u0014\u0005\u0004.\u0007(selectedExcel)));
							Element element = \u0011\u0017\u000A.\u0007(u001F, \u001E\u0001\u000A.\u000A(\u0009\u0005\u0004.\u000A(selectedExcel)));
							if (element == null)
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
									RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0002.\u0012\u0018(UIApplication)).MethodHandle;
								}
								\u0019\u0008\u0019.\u000A(\u001C\u001B\u0004.\u000A(), selectedExcel);
							}
							else
							{
								Schema schema = SchemaUtil.\u001F(false);
								if (schema == null)
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
									\u0018\u0008\u0019.\u000A(element, schema);
									\u0019\u0008\u0019.\u000A(\u001C\u001B\u0004.\u000A(), selectedExcel);
								}
							}
						}
						catch (Exception u000A2)
						{
							\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\Core\\ExternalEvents\\UnlinkViewExternalEvent.cs", "UnlinkViews");
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
				\u001B\u0001\u000A.\u000A(transaction);
			}
			finally
			{
				if (transaction != null)
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
					\u001F\u0017\u000A.\u000A(transaction);
				}
			}
		}

		// Token: 0x040005C1 RID: 1473
		[CompilerGenerated]
		private List<SelectedExcel> \u0014;

		// Token: 0x02000859 RID: 2137
		// (Invoke) Token: 0x06004EAE RID: 20142
		internal delegate void \u0016\u0002();

		// Token: 0x0200085A RID: 2138
		// (Invoke) Token: 0x06004EB2 RID: 20146
		internal delegate void \u000B\u0002(int percent, string text);
	}
}
