using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using DiRoots.One.Commons.Helpers;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.One.TableGen.Models;
using DiRoots.One.TableGen.TGRevitHelper;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.Dto;
using DiRoots.One.TGDatabaseLayer.StyleMapping;

namespace A
{
	// Token: 0x0200018D RID: 397
	internal class \u001C\u0002 : IExternalEventHandler
	{
		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06000E9E RID: 3742 RVA: 0x0005CD28 File Offset: 0x0005AF28
		// (set) Token: 0x06000E9F RID: 3743 RVA: 0x0005CD3C File Offset: 0x0005AF3C
		internal static ExternalEvent ViewHandlerEvent { get; set; }

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06000EA0 RID: 3744 RVA: 0x0005CD50 File Offset: 0x0005AF50
		// (set) Token: 0x06000EA1 RID: 3745 RVA: 0x0005CD64 File Offset: 0x0005AF64
		internal static \u001C\u0002 ViewHandlerInstance { get; set; }

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x06000EA2 RID: 3746 RVA: 0x0005CD78 File Offset: 0x0005AF78
		// (remove) Token: 0x06000EA3 RID: 3747 RVA: 0x0005CDC4 File Offset: 0x0005AFC4
		internal event \u001C\u0002.\u0006\u0002 \u0007
		{
			[CompilerGenerated]
			add
			{
				\u001C\u0002.\u0006\u0002 u0006_u = this.\u0007;
				\u001C\u0002.\u0006\u0002 u0006_u2;
				do
				{
					u0006_u2 = u0006_u;
					\u001C\u0002.\u0006\u0002 value2 = (\u001C\u0002.\u0006\u0002)\u000F\u001E\u000A.\u000A(u0006_u2, value);
					u0006_u = Interlocked.CompareExchange<\u001C\u0002.\u0006\u0002>(ref this.\u0007, value2, u0006_u2);
				}
				while (u0006_u != u0006_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u0002.add_\u0007(\u001C\u0002.\u0006\u0002)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				\u001C\u0002.\u0006\u0002 u0006_u = this.\u0007;
				\u001C\u0002.\u0006\u0002 u0006_u2;
				do
				{
					u0006_u2 = u0006_u;
					\u001C\u0002.\u0006\u0002 value2 = (\u001C\u0002.\u0006\u0002)\u0012\u001E\u000A.\u000A(u0006_u2, value);
					u0006_u = Interlocked.CompareExchange<\u001C\u0002.\u0006\u0002>(ref this.\u0007, value2, u0006_u2);
				}
				while (u0006_u != u0006_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u0002.remove_\u0007(\u001C\u0002.\u0006\u0002)).MethodHandle;
				}
			}
		}

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06000EA4 RID: 3748 RVA: 0x0005CE10 File Offset: 0x0005B010
		// (remove) Token: 0x06000EA5 RID: 3749 RVA: 0x0005CE5C File Offset: 0x0005B05C
		internal event \u001C\u0002.\u000F\u0002 \u001D
		{
			[CompilerGenerated]
			add
			{
				\u001C\u0002.\u000F\u0002 u000F_u = this.\u001D;
				\u001C\u0002.\u000F\u0002 u000F_u2;
				do
				{
					u000F_u2 = u000F_u;
					\u001C\u0002.\u000F\u0002 value2 = (\u001C\u0002.\u000F\u0002)\u000F\u001E\u000A.\u000A(u000F_u2, value);
					u000F_u = Interlocked.CompareExchange<\u001C\u0002.\u000F\u0002>(ref this.\u001D, value2, u000F_u2);
				}
				while (u000F_u != u000F_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u0002.add_\u001D(\u001C\u0002.\u000F\u0002)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				\u001C\u0002.\u000F\u0002 u000F_u = this.\u001D;
				\u001C\u0002.\u000F\u0002 u000F_u2;
				do
				{
					u000F_u2 = u000F_u;
					\u001C\u0002.\u000F\u0002 value2 = (\u001C\u0002.\u000F\u0002)\u0012\u001E\u000A.\u000A(u000F_u2, value);
					u000F_u = Interlocked.CompareExchange<\u001C\u0002.\u000F\u0002>(ref this.\u001D, value2, u000F_u2);
				}
				while (u000F_u != u000F_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u0002.remove_\u001D(\u001C\u0002.\u000F\u0002)).MethodHandle;
				}
			}
		}

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x06000EA6 RID: 3750 RVA: 0x0005CEA8 File Offset: 0x0005B0A8
		// (set) Token: 0x06000EA7 RID: 3751 RVA: 0x0005CEBC File Offset: 0x0005B0BC
		internal bool SuppressErrors { get; set; }

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x06000EA8 RID: 3752 RVA: 0x0005CED0 File Offset: 0x0005B0D0
		// (set) Token: 0x06000EA9 RID: 3753 RVA: 0x0005CEE4 File Offset: 0x0005B0E4
		internal CancellationTokenSource CancellationToken { get; set; } = new CancellationTokenSource();

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x06000EAA RID: 3754 RVA: 0x0005CEF8 File Offset: 0x0005B0F8
		// (set) Token: 0x06000EAB RID: 3755 RVA: 0x0005CF0C File Offset: 0x0005B10C
		internal bool IsAutoSync { get; set; }

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x06000EAC RID: 3756 RVA: 0x0005CF20 File Offset: 0x0005B120
		// (set) Token: 0x06000EAD RID: 3757 RVA: 0x0005CF34 File Offset: 0x0005B134
		internal bool HideSuccess { get; set; }

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x06000EAE RID: 3758 RVA: 0x0005CF48 File Offset: 0x0005B148
		// (set) Token: 0x06000EAF RID: 3759 RVA: 0x0005CF5C File Offset: 0x0005B15C
		internal bool UpdateRelativePath { get; set; }

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x06000EB0 RID: 3760 RVA: 0x0005CF70 File Offset: 0x0005B170
		// (set) Token: 0x06000EB1 RID: 3761 RVA: 0x0005CF84 File Offset: 0x0005B184
		internal List<DiRoots.One.TGDatabaseLayer.SelectedExcel> AutoSyncExcels { get; set; } = new List<DiRoots.One.TGDatabaseLayer.SelectedExcel>();

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x06000EB2 RID: 3762 RVA: 0x0005CF98 File Offset: 0x0005B198
		// (set) Token: 0x06000EB3 RID: 3763 RVA: 0x0005CFAC File Offset: 0x0005B1AC
		internal List<\u0020\u0019> DataToProcess { get; set; } = new List<\u0020\u0019>();

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x06000EB4 RID: 3764 RVA: 0x0005CFC0 File Offset: 0x0005B1C0
		// (set) Token: 0x06000EB5 RID: 3765 RVA: 0x0005CFD4 File Offset: 0x0005B1D4
		internal StyleMappingDto StyleMappings { get; set; }

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x06000EB6 RID: 3766 RVA: 0x0005CFE8 File Offset: 0x0005B1E8
		// (set) Token: 0x06000EB7 RID: 3767 RVA: 0x0005CFFC File Offset: 0x0005B1FC
		internal string ActiveProfileName { get; set; }

		// Token: 0x06000EB8 RID: 3768 RVA: 0x0005D010 File Offset: 0x0005B210
		void IExternalEventHandler.\u0003(UIApplication \u001F)
		{
			\u001C\u0008\u0019.\u001D(\u0003\u0019\u0019.\u000A(), false);
			UIDocument u001F = \u0020\u0013\u000A.\u000A(\u001F);
			Document u001F2 = \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(\u001F));
			List<ReportInfo> list = \u0010\u001D\u0019.\u000A();
			List<DiRoots.One.TGDatabaseLayer.SelectedExcel> list2 = \u0003\u000B\u0004.\u000A();
			object u001F3 = list2;
			IEnumerable<\u0020\u0019> enumerable = \u0006\u0008\u0019.\u000A(this);
			Func<\u0020\u0019, DiRoots.One.TGDatabaseLayer.SelectedExcel> func;
			if ((func = \u001C\u0002.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u0002.\u0003(UIApplication)).MethodHandle;
				}
				func = (\u001C\u0002.<>c.\u000A = new Func<\u0020\u0019, DiRoots.One.TGDatabaseLayer.SelectedExcel>(\u001C\u0002.<>c.\u001F.\u0019));
			}
			\u0001\u0007\u0019.\u000A(u001F3, Enumerable.Select<\u0020\u0019, DiRoots.One.TGDatabaseLayer.SelectedExcel>(enumerable, func));
			\u0001\u0007\u0019.\u000A(list2, \u000B\u0008\u0019.\u000A(this));
			List<long> list3 = \u001C\u0002.\u0010(u001F2, list2);
			\u000C\u0008\u0019.\u000A(list, \u001C\u0002.\u000E(list2, list3));
			List<DiRoots.One.TGDatabaseLayer.SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(Enumerable.ToList<DiRoots.One.TGDatabaseLayer.SelectedExcel>(list2));
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					\u001C\u0002.\u0003\u0002 u0003_u = new \u001C\u0002.\u0003\u0002();
					u0003_u.\u001F = \u001F\u0016\u0004.\u000A(ref enumerator);
					if (\u001A\u0008\u0019.\u000A(list3, \u0009\u0005\u0004.\u000A(u0003_u.\u001F)))
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
						\u0013\u0008\u0019.\u000A(\u0006\u0008\u0019.\u000A(this), Enumerable.FirstOrDefault<\u0020\u0019>(\u0006\u0008\u0019.\u000A(this), new Func<\u0020\u0019, bool>(u0003_u.\u000A)));
						if (\u0019\u0008\u0019.\u000A(\u000B\u0008\u0019.\u000A(this), u0003_u.\u001F))
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
							if (\u0017\u0008\u0019.\u000A(this))
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
								\u0001\u001B\u0004.\u000A(u0003_u.\u001F, !\u000E\u0016\u0004.\u000A(u0003_u.\u001F));
							}
							else if (\u0014\u0008\u0019.\u000A(this))
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
								\u0014\u0020\u0004.\u000A(u0003_u.\u001F, !\u0013\u0008\u0004.\u001D(u0003_u.\u001F));
							}
						}
						\u0019\u0008\u0019.\u000A(list2, u0003_u.\u001F);
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
			\u0005\u0002.\u0007(u001F2, list2);
			\u000A\u0018\u0019.\u000A(\u0016\u001E\u0004.\u000A());
			if (\u0017\u0008\u0019.\u000A(this))
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
				if (\u000C\u001B\u0004.\u000A(\u000B\u0008\u0019.\u000A(this)) <= 0)
				{
					goto IL_724;
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
				Transaction transaction = \u0013\u0001\u000A.\u000A(u001F2);
				try
				{
					\u0017\u0001\u000A.\u000A(transaction, "TableGen update autosync/relative path");
					enumerator = \u000A\u0016\u0004.\u000A(\u000B\u0008\u0019.\u000A(this));
					try
					{
						while (\u0001\u0005\u0004.\u000A(ref enumerator))
						{
							DiRoots.One.TGDatabaseLayer.SelectedExcel u001F4 = \u001F\u0016\u0004.\u000A(ref enumerator);
							ElementId u000A = \u001E\u0001\u000A.\u000A(\u0009\u0005\u0004.\u000A(u001F4));
							Element u001F5 = \u0011\u0017\u000A.\u0007(u001F2, u000A);
							if (\u0005\u001F\u000E.\u001F(u001F5) != null)
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
								DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel selectedExcel = SchemaUtil.\u0007(u001F5);
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
									\u000C\u0017\u0004.\u000A(selectedExcel, \u000E\u0016\u0004.\u000A(u001F4));
									\u0013\u0017\u0004.\u000A(selectedExcel, \u0013\u0008\u0004.\u001D(u001F4));
									\u001B\u0017\u0004.\u000A(selectedExcel, UpdateStates.Updated);
								}
								SchemaUtil.\u000A(u001F5, selectedExcel);
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
					\u001B\u0001\u000A.\u000A(transaction);
					goto IL_724;
				}
				finally
				{
					if (transaction != null)
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
						\u001F\u0017\u000A.\u000A(transaction);
					}
				}
			}
			int num = 0;
			int num2 = \u001E\u0002\u0019.\u000A(\u0006\u0008\u0019.\u000A(this));
			if (num2 > 0)
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
				StyleMappingDto styleMappingDto = \u0012\u0008\u0019.\u000A(this);
				object obj;
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
					obj = \u0001\u0004\u0004.\u0007(\u0009\u0004\u0004.\u0007(styleMappingDto));
				}
				else
				{
					obj = 0;
				}
				object obj2 = obj;
				List<\u0015\u0005> list4;
				if (obj2 == null)
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
					list4 = \u001E\u0005\u000E.\u001F;
				}
				else
				{
					list4 = \u0020\u0008\u0019.\u000A();
				}
				List<\u0015\u0005> list5 = list4;
				if (obj2 != null)
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
					\u0002\u0005.\u001C(u001F2);
				}
				List<\u0020\u0019>.Enumerator enumerator2 = \u0002\u000B\u0004.\u000A(\u0006\u0008\u0019.\u000A(this));
				try
				{
					while (\u000B\u0016\u0004.\u000A(ref enumerator2))
					{
						\u0020\u0019 u0020_u = \u000B\u000B\u0004.\u000A(ref enumerator2);
						if (\u0004\u0013\u001D.\u0007(\u000A\u000B\u0019.\u001D(this)))
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
							goto IL_71C;
						}
						int num3 = num * 100 / num2;
						if (this.\u001D != null)
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
							string text = "";
							if (\u0001\u0016\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0020_u)) == UpdateStates.Modified)
							{
								goto IL_451;
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
							if (\u0001\u0016\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0020_u)) == UpdateStates.Recreate)
							{
								for (;;)
								{
									switch (7)
									{
									case 0:
										continue;
									}
									goto IL_451;
								}
							}
							IL_460:
							switch (\u0019\u0010\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0020_u)))
							{
							case ActionTypes.Create:
								text = \u001E\u0008\u0019.\u000A();
								break;
							case ActionTypes.Update:
								text = \u001B\u0008\u0019.\u000A();
								break;
							case ActionTypes.Delete:
								text = \u0011\u0008\u0019.\u000A();
								break;
							}
							object u001D = this.\u001D;
							int u000A2 = num3;
							string[] array = \u001B\u001F\u000E.\u001F(5);
							array[0] = text;
							array[1] = " ";
							array[2] = \u0014\u0005\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0020_u));
							array[3] = " ";
							array[4] = \u0008\u0008\u0019.\u000A();
							\u000E\u0008\u0019.\u000A(u001D, u000A2, \u0014\u0006\u001D.\u000A(array));
							goto IL_4F8;
							IL_451:
							\u001C\u0016\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0020_u), ActionTypes.Update);
							goto IL_460;
						}
						IL_4F8:
						num++;
						\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), \u0018\u000E\u0007.\u000A("Enter creating view: View Name:{0} ; ActionType:{1}", \u0014\u0005\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0020_u)), \u0019\u0010\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0020_u))), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\Core\\ExternalEvents\\ViewHandlerExternalEvent.cs", "Execute");
						try
						{
							if (\u0019\u0010\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0020_u)) != ActionTypes.Delete)
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
								try
								{
									\u000F\u0016.\u001F(\u0002\u0016\u0004.\u0007(u0020_u));
								}
								catch (Exception)
								{
									continue;
								}
								List<\u0020\u0019> list6 = \u0007\u000B\u0019.\u000A();
								\u001F\u000B\u0019.\u000A(list6, u0020_u);
								\u0015\u0018.\u0016(u001F, list6, \u0019\u0010\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0020_u)), \u000A\u000B\u0019.\u001D(this), styleMappingDto, list5);
							}
							else
							{
								List<DiRoots.One.TGDatabaseLayer.SelectedExcel> u001F6 = \u0003\u000B\u0004.\u000A();
								\u001A\u0016\u0004.\u000A(u001F6, \u0002\u0016\u0004.\u0007(u0020_u));
								\u0015\u0018.\u0004(u001F6);
								\u0019\u0008\u0019.\u000A(\u001C\u001B\u0004.\u000A(), \u0002\u0016\u0004.\u0007(u0020_u));
							}
							IEnumerable<\u001C\u0005> enumerable2 = \u000C\u001D\u0004.\u0007(u0020_u);
							Func<\u001C\u0005, bool> func2;
							if ((func2 = \u001C\u0002.<>c.\u0007) == null)
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
								func2 = (\u001C\u0002.<>c.\u0007 = new Func<\u001C\u0005, bool>(\u001C\u0002.<>c.\u001F.\u0018));
							}
							if (Enumerable.Any<\u001C\u0005>(enumerable2, func2))
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
								\u0006\u001D\u0019.\u000A(list, \u001B\u0005\u0019.\u000A(\u0002\u0016\u0004.\u0007(u0020_u), \u0010\u0008\u0019.\u000A()));
							}
						}
						catch (Exception ex)
						{
							if (!\u000D\u0008\u0019.\u000A(this))
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
								if (!\u0004\u0013\u001D.\u0007(\u000A\u000B\u0019.\u001D(this)))
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
									\u0006\u001D\u0019.\u000A(list, \u001B\u0005\u0019.\u000A(\u0002\u0016\u0004.\u0007(u0020_u), \u0003\u001A\u000A.\u000A(ex)));
								}
							}
							\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), ex, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\Core\\ExternalEvents\\ViewHandlerExternalEvent.cs", "Execute");
						}
						\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), \u0018\u000E\u0007.\u000A("Exit creating view: View Name:{0} ; ActionType:{1}", \u0014\u0005\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0020_u)), \u0019\u0010\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0020_u))), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\Core\\ExternalEvents\\ViewHandlerExternalEvent.cs", "Execute");
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
					((IDisposable)enumerator2).Dispose();
				}
				IL_71C:
				this.\u000D(list5);
			}
			IL_724:
			if (\u0008\u0005\u0019.\u000A(list) > 0)
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
				ReportsWindow u001F7 = \u0003\u0018\u001D.\u000A(\u000E\u0005\u0019.\u000A(Enumerable.ToList<Report>(Enumerable.Cast<Report>(list)), \u001E\u0011\u000A.\u000A(\u0008\u0018\u000E.\u001F()), 1005), false);
				\u0020\u0014\u000A.\u0007(u001F7, WindowStartupLocation.CenterScreen);
				\u0007\u0010\u001D.\u0007(u001F7, "Report");
				\u0018\u0020\u000A.\u0007(u001F7);
				\u001C\u0008\u0019.\u0007(this, true);
			}
			if (!\u0004\u0013\u001D.\u0007(\u000A\u000B\u0019.\u001D(this)))
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
				\u001C\u0002.\u0006\u0002 u = this.\u0007;
				if (u == null)
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
				}
				else
				{
					\u0003\u0008\u0019.\u000A(u);
				}
			}
			\u000D\u0019\u0019.\u001D(this, false);
			\u001C\u0019\u0019.\u001D(this, false);
			\u001B\u0019\u0019.\u000A(false);
			if (\u0012\u0008\u0019.\u000A(this) != null)
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
				if (\u001E\u0002\u0019.\u000A(\u0006\u0008\u0019.\u000A(this)) > 0)
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
					if (!\u0004\u0013\u001D.\u0007(\u000A\u000B\u0019.\u001D(this)))
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
						\u0010\u0016.\u001D(u001F2, \u0012\u0008\u0019.\u000A(this), \u000F\u0008\u0019.\u000A(this));
					}
				}
			}
			\u0004\u000B\u0019.\u001D(this, \u0001\u0004\u000E.\u001F);
			\u001D\u000B\u0019.\u001D(this, \u000F\u0015\u0010.\u001F);
			\u0002\u0008\u0019.\u000A(\u0006\u0008\u0019.\u000A(this));
			\u0001\u000B\u0019.\u001D(\u000B\u0008\u0019.\u000A(this));
		}

		// Token: 0x06000EB9 RID: 3769 RVA: 0x0005D918 File Offset: 0x0005BB18
		private void \u000D(List<\u0015\u0005> \u001F)
		{
			if (\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u0002.\u000D(List<\u0015\u0005>)).MethodHandle;
				}
				if (\u0001\u0008\u0019.\u000A(\u001F) == 0)
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
				}
				else
				{
					Func<\u0015\u0005, bool> func;
					if ((func = \u001C\u0002.<>c.\u001D) == null)
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
						func = (\u001C\u0002.<>c.\u001D = new Func<\u0015\u0005, bool>(\u001C\u0002.<>c.\u001F.\u0005));
					}
					List<\u0015\u0005> list = Enumerable.ToList<\u0015\u0005>(Enumerable.Where<\u0015\u0005>(\u001F, func));
					if (\u0001\u0008\u0019.\u000A(list) == 0)
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
						return;
					}
					IEnumerable<\u0015\u0005> enumerable = list;
					Func<\u0015\u0005, StyleCreationReport> func2;
					if ((func2 = \u001C\u0002.<>c.\u0004) == null)
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
						func2 = (\u001C\u0002.<>c.\u0004 = new Func<\u0015\u0005, StyleCreationReport>(\u001C\u0002.<>c.\u001F.\u0016));
					}
					ReportsWindow u001F = \u0003\u0018\u001D.\u000A(\u000E\u0005\u0019.\u000A(Enumerable.ToList<Report>(Enumerable.Cast<Report>(Enumerable.Select<\u0015\u0005, StyleCreationReport>(enumerable, func2))), \u001E\u0011\u000A.\u000A(\u0011\u0005\u000E.\u001F()), 600), false);
					\u0020\u0014\u000A.\u0007(u001F, WindowStartupLocation.CenterScreen);
					\u0007\u0010\u001D.\u0007(u001F, \u0015\u0008\u0019.\u000A());
					\u0018\u0020\u000A.\u0007(u001F);
					return;
				}
			}
		}

		// Token: 0x06000EBA RID: 3770 RVA: 0x0005DA1C File Offset: 0x0005BC1C
		internal static List<long> \u0010(Document \u001F, List<DiRoots.One.TGDatabaseLayer.SelectedExcel> \u000A)
		{
			\u001C\u0002.\u0008(\u001F);
			List<long> list = \u001F\u001B\u0019.\u000A();
			TransactionGroup transactionGroup = \u0009\u0017\u0007.\u000A(\u001F, "TableGen - Check element editable");
			try
			{
				\u0001\u0017\u0007.\u000A(transactionGroup);
				Transaction transaction = \u0013\u0001\u000A.\u000A(\u001F);
				try
				{
					\u0017\u0001\u000A.\u000A(transaction, "TableGen update CloudPath");
					\u0018\u0002 u0018_u = new \u0018\u0002();
					FailureHandlingOptions failureHandlingOptions = \u0006\u0014\u0007.\u000A(transaction);
					\u0002\u0014\u0007.\u000A(failureHandlingOptions, u0018_u);
					\u000B\u0014\u0007.\u000A(transaction, failureHandlingOptions);
					List<DiRoots.One.TGDatabaseLayer.SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(\u000A);
					try
					{
						while (\u0001\u0005\u0004.\u000A(ref enumerator))
						{
							ElementId u000A = \u001E\u0001\u000A.\u000A(\u0009\u0005\u0004.\u000A(\u001F\u0016\u0004.\u000A(ref enumerator)));
							Element u001F = \u0011\u0017\u000A.\u0007(\u001F, u000A);
							if (\u0005\u001F\u000E.\u001F(u001F) != null)
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
									RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u0002.\u0010(Document, List<DiRoots.One.TGDatabaseLayer.SelectedExcel>)).MethodHandle;
								}
								DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel u000A2 = SchemaUtil.\u0007(u001F);
								SchemaUtil.\u000A(u001F, u000A2);
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
					\u001B\u0001\u000A.\u000A(transaction);
					\u0009\u0008\u0019.\u000A(list, \u0009\u000E\u0019.\u001D(u0018_u));
				}
				finally
				{
					if (transaction != null)
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
						\u001F\u0017\u000A.\u000A(transaction);
					}
				}
				\u001A\u0017\u0007.\u000A(transactionGroup);
			}
			finally
			{
				if (transactionGroup != null)
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
					\u001F\u0017\u000A.\u000A(transactionGroup);
				}
			}
			\u001C\u0002.\u001B(\u001F);
			return list;
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x0005DBB0 File Offset: 0x0005BDB0
		internal static List<ReportInfo> \u000E(List<DiRoots.One.TGDatabaseLayer.SelectedExcel> \u001F, List<long> \u000A)
		{
			List<ReportInfo> list = \u0010\u001D\u0019.\u000A();
			if (\u001B\u000A\u001D.\u000A(\u000A) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u0002.\u000E(List<DiRoots.One.TGDatabaseLayer.SelectedExcel>, List<long>)).MethodHandle;
				}
				List<DiRoots.One.TGDatabaseLayer.SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(\u001F);
				try
				{
					while (\u0001\u0005\u0004.\u000A(ref enumerator))
					{
						DiRoots.One.TGDatabaseLayer.SelectedExcel u001F = \u001F\u0016\u0004.\u000A(ref enumerator);
						if (\u001A\u0008\u0019.\u000A(\u000A, \u0009\u0005\u0004.\u000A(u001F)))
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
							\u0006\u001D\u0019.\u000A(list, \u001B\u0005\u0019.\u000A(u001F, "Can't edit the element. Reload latest model and try again."));
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
			}
			return list;
		}

		// Token: 0x06000EBC RID: 3772 RVA: 0x0005DC60 File Offset: 0x0005BE60
		string IExternalEventHandler.\u001C()
		{
			return "Create Views";
		}

		// Token: 0x06000EBD RID: 3773 RVA: 0x0005DC74 File Offset: 0x0005BE74
		internal static void \u0008(Document \u001F)
		{
			if (\u000D\u000B\u001D.\u000A(\u0020\u0005\u0004.\u000A(\u0017\u0005\u0004.\u0007(\u001F))) > 2019)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u0002.\u0008(Document)).MethodHandle;
				}
				object u001F = \u0005\u001B\u0019.\u0007(\u0004\u001A\u000A.\u000A(\u001F));
				EventHandler<DialogBoxShowingEventArgs> u000A;
				if ((u000A = \u001C\u0002.\u0012\u0002.\u001F) == null)
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
					u000A = (\u001C\u0002.\u0012\u0002.\u001F = new EventHandler<DialogBoxShowingEventArgs>(\u001C\u0002.\u0011));
				}
				\u0018\u001B\u0019.\u000A(u001F, u000A);
				return;
			}
			IntPtr intPtr = \u0004\u001B\u0019.\u000A(\u0019\u001B\u0019.\u000A());
			\u001C\u0002.\u0012 = \u000A\u001B\u0019.\u000A(\u001D\u001B\u0019.\u000A(ref intPtr), \u0007\u001B\u0019.\u000A(\u0014\u000E\u0019.\u000A()), -1);
		}

		// Token: 0x06000EBE RID: 3774 RVA: 0x0005DD20 File Offset: 0x0005BF20
		internal static void \u001B(Document \u001F)
		{
			if (\u000D\u000B\u001D.\u000A(\u0020\u0005\u0004.\u000A(\u0017\u0005\u0004.\u0007(\u001F))) > 2019)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u0002.\u001B(Document)).MethodHandle;
				}
				object u001F = \u0005\u001B\u0019.\u0007(\u0004\u001A\u000A.\u000A(\u001F));
				EventHandler<DialogBoxShowingEventArgs> u000A;
				if ((u000A = \u001C\u0002.\u0012\u0002.\u001F) == null)
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
					u000A = (\u001C\u0002.\u0012\u0002.\u001F = new EventHandler<DialogBoxShowingEventArgs>(\u001C\u0002.\u0011));
				}
				\u000B\u001B\u0019.\u000A(u001F, u000A);
				return;
			}
			DialogCloser u = \u001C\u0002.\u0012;
			if (u == null)
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
			\u0016\u001B\u0019.\u000A(u);
		}

		// Token: 0x06000EBF RID: 3775 RVA: 0x0005DDB0 File Offset: 0x0005BFB0
		internal static void \u0011(object \u001F, DialogBoxShowingEventArgs \u000A)
		{
			try
			{
				\u0002\u001B\u0019.\u000A(\u000A, 1001);
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\Core\\ExternalEvents\\ViewHandlerExternalEvent.cs", "AppDialogShowing");
			}
		}

		// Token: 0x06000EC0 RID: 3776 RVA: 0x0005DDF8 File Offset: 0x0005BFF8
		internal static void \u001E()
		{
			if (\u0003\u0019\u0019.\u000A() == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u0002.\u001E()).MethodHandle;
				}
				\u000F\u001B\u0019.\u000A(new \u001C\u0002());
				\u0006\u001B\u0019.\u000A(\u001D\u0005\u001D.\u000A(\u0003\u0019\u0019.\u000A()));
			}
		}

		// Token: 0x040005C2 RID: 1474
		[CompilerGenerated]
		private static ExternalEvent \u001F;

		// Token: 0x040005C3 RID: 1475
		[CompilerGenerated]
		private static \u001C\u0002 \u000A;

		// Token: 0x040005C6 RID: 1478
		[CompilerGenerated]
		private bool \u0004;

		// Token: 0x040005C7 RID: 1479
		[CompilerGenerated]
		private CancellationTokenSource \u0019;

		// Token: 0x040005C8 RID: 1480
		[CompilerGenerated]
		private bool \u0018;

		// Token: 0x040005C9 RID: 1481
		[CompilerGenerated]
		private bool \u0005;

		// Token: 0x040005CA RID: 1482
		[CompilerGenerated]
		private bool \u0016;

		// Token: 0x040005CB RID: 1483
		[CompilerGenerated]
		private List<DiRoots.One.TGDatabaseLayer.SelectedExcel> \u000B;

		// Token: 0x040005CC RID: 1484
		[CompilerGenerated]
		private List<\u0020\u0019> \u0002;

		// Token: 0x040005CD RID: 1485
		[CompilerGenerated]
		private StyleMappingDto \u0006;

		// Token: 0x040005CE RID: 1486
		[CompilerGenerated]
		private string \u000F;

		// Token: 0x040005CF RID: 1487
		private static DialogCloser \u0012;

		// Token: 0x0200085B RID: 2139
		// (Invoke) Token: 0x06004EB6 RID: 20150
		internal delegate void \u0006\u0002();

		// Token: 0x0200085C RID: 2140
		// (Invoke) Token: 0x06004EBA RID: 20154
		internal delegate void \u000F\u0002(int percent, string text);

		// Token: 0x0200085D RID: 2141
		[CompilerGenerated]
		private static class \u0012\u0002
		{
			// Token: 0x04002140 RID: 8512
			public static EventHandler<DialogBoxShowingEventArgs> \u001F;
		}

		// Token: 0x0200085F RID: 2143
		[CompilerGenerated]
		private sealed class \u0003\u0002
		{
			// Token: 0x06004EC4 RID: 20164 RVA: 0x001E1654 File Offset: 0x001DF854
			internal bool \u000A(\u0020\u0019 \u001F)
			{
				return \u0002\u0016\u0004.\u0007(\u001F) == this.\u001F;
			}

			// Token: 0x04002146 RID: 8518
			public DiRoots.One.TGDatabaseLayer.SelectedExcel \u001F;
		}
	}
}
