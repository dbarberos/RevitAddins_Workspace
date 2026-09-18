using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Core;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.One.ViewRange;
using DiRoots.One.ViewRange.Model;

namespace A
{
	// Token: 0x0200028D RID: 653
	internal class \u001C\u000E : ExternalEventInfo
	{
		// Token: 0x0600195F RID: 6495 RVA: 0x000A4114 File Offset: 0x000A2314
		public \u001C\u000E(Window \u001F, ProgressModel \u000A)
		{
			this.\u0010\u0018(\u001F, \u000A);
		}

		// Token: 0x170006F7 RID: 1783
		// (get) Token: 0x06001960 RID: 6496 RVA: 0x000A4130 File Offset: 0x000A2330
		// (set) Token: 0x06001961 RID: 6497 RVA: 0x000A4144 File Offset: 0x000A2344
		public List<ViewInformation> SelectViewInformation { get; set; }

		// Token: 0x170006F8 RID: 1784
		// (get) Token: 0x06001962 RID: 6498 RVA: 0x000A4158 File Offset: 0x000A2358
		// (set) Token: 0x06001963 RID: 6499 RVA: 0x000A416C File Offset: 0x000A236C
		public Window ParentWindow { get; set; }

		// Token: 0x170006F9 RID: 1785
		// (get) Token: 0x06001964 RID: 6500 RVA: 0x000A4180 File Offset: 0x000A2380
		// (set) Token: 0x06001965 RID: 6501 RVA: 0x000A4194 File Offset: 0x000A2394
		public ProgressModel ProgressBar { get; set; }

		// Token: 0x06001966 RID: 6502 RVA: 0x000A41A8 File Offset: 0x000A23A8
		private void \u0010\u0018(Window \u001F, ProgressModel \u000A)
		{
			\u001B\u0015\u0005.\u000A(this, \u001F);
			\u0008\u0015\u0005.\u000A(this, \u000A);
			\u000A\u0013\u0019.\u000A(\u000E\u0015\u0005.\u000A(this), \u001F);
			this.\u0006\u000A = \u0010\u0015\u0005.\u000A();
		}

		// Token: 0x06001967 RID: 6503 RVA: 0x000A41E0 File Offset: 0x000A23E0
		public override void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\ViewRange\\Core\\ExternalEvents\\ViewRangeEvent.cs", "Execute");
			this.\u000E\u0018(\u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app)));
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\ViewRange\\Core\\ExternalEvents\\ViewRangeEvent.cs", "Execute");
		}

		// Token: 0x06001968 RID: 6504 RVA: 0x000A4230 File Offset: 0x000A2430
		private void \u000E\u0018(Document \u001F)
		{
			this.\u0011\u0018();
			IEnumerable<ViewInformation> enumerable = \u0019\u0001\u0005.\u000A(this);
			Func<ViewInformation, bool> func;
			if ((func = \u001C\u000E.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u000E.\u000E\u0018(Document)).MethodHandle;
				}
				func = (\u001C\u000E.<>c.\u000A = new Func<ViewInformation, bool>(\u001C\u000E.<>c.\u001F.\u0019));
			}
			List<ViewInformation> u001F = Enumerable.ToList<ViewInformation>(Enumerable.Where<ViewInformation>(enumerable, func));
			\u0009\u0014\u0019.\u000A(\u000E\u0015\u0005.\u000A(this), \u0018\u0001\u0005.\u000A(u001F), \u0005\u0001\u0005.\u000A());
			int num = \u0018\u0001\u0005.\u000A(u001F) / 10;
			int num2;
			if (num != 0)
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
				num2 = num;
			}
			else
			{
				num2 = 1;
			}
			num = num2;
			int num3 = 1;
			Transaction transaction = \u001D\u0014\u0007.\u000A(\u001F, "ViewManager_ViewRangeChange");
			try
			{
				\u0007\u0014\u0007.\u000A(transaction);
				IEnumerable<ViewInformation> enumerable2 = \u0019\u0001\u0005.\u000A(this);
				Func<ViewInformation, bool> func2;
				if ((func2 = \u001C\u000E.<>c.\u0007) == null)
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
					func2 = (\u001C\u000E.<>c.\u0007 = new Func<ViewInformation, bool>(\u001C\u000E.<>c.\u001F.\u0018));
				}
				IEnumerator<ViewInformation> enumerator = \u0004\u0001\u0005.\u000A(Enumerable.Where<ViewInformation>(enumerable2, func2));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						ViewInformation u001F2 = \u001D\u0001\u0005.\u000A(enumerator);
						ViewPlan viewPlan = \u0016\u001F\u000E.\u001F(\u0007\u0001\u0005.\u0007(u001F2));
						if (viewPlan == null)
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
						PlanViewRange planViewRange = \u000A\u0001\u0005.\u000A(viewPlan);
						ElementId u = \u001E\u0001\u000A.\u000A(\u0009\u0015\u0005.\u000A(\u001F\u0001\u0005.\u0007(\u0001\u0015\u0005.\u000A(u001F2))));
						ElementId u2 = \u001E\u0001\u000A.\u000A(\u0009\u0015\u0005.\u000A(\u001F\u0001\u0005.\u0007(\u0015\u0015\u0005.\u000A(u001F2))));
						ElementId u3 = \u001E\u0001\u000A.\u000A(\u0009\u0015\u0005.\u000A(\u001F\u0001\u0005.\u0007(\u000C\u0015\u0005.\u000A(u001F2))));
						ElementId u001D = \u001E\u0001\u000A.\u000A(\u0009\u0015\u0005.\u000A(\u001F\u0001\u0005.\u0007(\u001A\u0015\u0005.\u000A(u001F2))));
						this.\u0008\u0018(planViewRange, 1, u, u001D, \u0013\u0015\u0005.\u0007(\u0001\u0015\u0005.\u000A(u001F2)));
						this.\u0008\u0018(planViewRange, 2, u2, u001D, \u0013\u0015\u0005.\u0007(\u0015\u0015\u0005.\u000A(u001F2)));
						this.\u0008\u0018(planViewRange, 3, u3, u001D, \u0013\u0015\u0005.\u0007(\u000C\u0015\u0005.\u000A(u001F2)));
						\u0017\u0015\u0005.\u000A(planViewRange, 0, \u0014\u0015\u0005.\u000A(this.\u0006\u000A, \u0013\u0015\u0005.\u0007(\u001A\u0015\u0005.\u000A(u001F2))));
						\u0020\u0015\u0005.\u000A(viewPlan, planViewRange);
						\u001E\u0015\u0005.\u000A(u001F2, UpdatedIconChange.Updated);
						if (num3 % num == 0)
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
							Delegate @delegate = \u0006\u000F\u0018.\u0007(\u000E\u0015\u0005.\u000A(this));
							if (@delegate == null)
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
								object[] array = \u0004\u0015\u0010.\u001F(1);
								array[0] = num3;
								\u0010\u001F\u0018.\u000A(@delegate, array);
							}
						}
						num3++;
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
				\u001B\u0001\u000A.\u000A(transaction);
				this.\u000C\u0018();
			}
			finally
			{
				if (transaction != null)
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
					\u001F\u0017\u000A.\u000A(transaction);
				}
			}
		}

		// Token: 0x06001969 RID: 6505 RVA: 0x000A4544 File Offset: 0x000A2744
		private void \u0008\u0018(PlanViewRange \u001F, PlanViewPlane \u000A, ElementId \u0007, ElementId \u001D, double \u0004)
		{
			double u = \u0014\u0015\u0005.\u000A(this.\u0006\u000A, \u0004);
			\u0016\u0001\u0005.\u000A(\u001F, \u000A, \u0007);
			\u0017\u0015\u0005.\u000A(\u001F, \u000A, u);
		}

		// Token: 0x0600196A RID: 6506 RVA: 0x000A4574 File Offset: 0x000A2774
		private double \u001B\u0018(PlanViewPlane \u001F)
		{
			if (\u001F != 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u000E.\u001B\u0018(PlanViewPlane)).MethodHandle;
				}
				return double.MinValue;
			}
			return double.MaxValue;
		}

		// Token: 0x0600196B RID: 6507 RVA: 0x000A45AC File Offset: 0x000A27AC
		private void \u0011\u0018()
		{
			IEnumerable<ViewInformation> enumerable = \u0019\u0001\u0005.\u000A(this);
			Func<ViewInformation, bool> func;
			if ((func = \u001C\u000E.<>c.\u001D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u000E.\u0011\u0018()).MethodHandle;
				}
				func = (\u001C\u000E.<>c.\u001D = new Func<ViewInformation, bool>(\u001C\u000E.<>c.\u001F.\u0005));
			}
			List<ViewInformation>.Enumerator enumerator = \u001C\u0001\u0005.\u000A(Enumerable.ToList<ViewInformation>(Enumerable.Where<ViewInformation>(enumerable, func)));
			try
			{
				while (\u000B\u0001\u0005.\u000A(ref enumerator))
				{
					ViewInformation viewInformation = \u0003\u0001\u0005.\u000A(ref enumerator);
					try
					{
						if (\u001F\u0001\u0005.\u0007(\u001A\u0015\u0005.\u000A(viewInformation)) != null)
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
							if (\u001F\u0001\u0005.\u0007(\u0001\u0015\u0005.\u000A(viewInformation)) != null)
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
								if (\u001F\u0001\u0005.\u0007(\u0015\u0015\u0005.\u000A(viewInformation)) != null)
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
									if (\u001F\u0001\u0005.\u0007(\u000C\u0015\u0005.\u000A(viewInformation)) != null)
									{
										bool flag = this.\u001E\u0018(viewInformation);
										bool flag4;
										if (\u0002\u0001\u0005.\u000A(viewInformation))
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
											bool flag2 = this.\u0020\u0018(viewInformation);
											bool flag3 = this.\u0017\u0018(viewInformation);
											flag4 = (flag && flag2 && flag3);
										}
										else
										{
											bool flag5 = this.\u0014\u0018(viewInformation);
											flag4 = (flag && flag5);
										}
										if (!flag4)
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
											\u001E\u0015\u0005.\u000A(viewInformation, UpdatedIconChange.NotValid);
										}
										continue;
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
							}
						}
						\u001E\u0015\u0005.\u000A(viewInformation, UpdatedIconChange.NotValid);
						object u001F = viewInformation;
						string u000A;
						if (!\u001A\u0006\u0007.\u000A(\u0012\u0001\u0005.\u000A(viewInformation)))
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
							u000A = \u0012\u0001\u0005.\u000A(viewInformation);
						}
						else
						{
							u000A = \u000F\u0001\u0005.\u000A();
						}
						\u0006\u0001\u0005.\u000A(u001F, u000A);
						return;
					}
					catch (Exception u000A2)
					{
						this.\u001A\u0018(viewInformation, u000A2);
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

		// Token: 0x0600196C RID: 6508 RVA: 0x000A4794 File Offset: 0x000A2994
		private bool \u001E\u0018(ViewInformation \u001F)
		{
			if (\u0009\u0015\u0005.\u000A(\u001F\u0001\u0005.\u0007(\u0001\u0015\u0005.\u000A(\u001F))) == -1L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u000E.\u001E\u0018(ViewInformation)).MethodHandle;
				}
				return true;
			}
			double num = \u0010\u0001\u0005.\u000A(\u001A\u0015\u0005.\u000A(\u001F), this.\u0006\u000A);
			double num2 = \u0010\u0001\u0005.\u000A(\u0001\u0015\u0005.\u000A(\u001F), this.\u0006\u000A);
			if (num <= num2)
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
				return true;
			}
			string u000A;
			if (!\u001A\u0006\u0007.\u000A(\u0012\u0001\u0005.\u000A(\u001F)))
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
				u000A = \u0012\u0001\u0005.\u000A(\u001F);
			}
			else
			{
				u000A = \u000D\u0001\u0005.\u000A();
			}
			\u0006\u0001\u0005.\u000A(\u001F, u000A);
			return false;
		}

		// Token: 0x0600196D RID: 6509 RVA: 0x000A4840 File Offset: 0x000A2A40
		private bool \u0020\u0018(ViewInformation \u001F)
		{
			if (\u0009\u0015\u0005.\u000A(\u001F\u0001\u0005.\u0007(\u0015\u0015\u0005.\u000A(\u001F))) == -1L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u000E.\u0020\u0018(ViewInformation)).MethodHandle;
				}
				return true;
			}
			double num = \u0010\u0001\u0005.\u000A(\u001A\u0015\u0005.\u000A(\u001F), this.\u0006\u000A);
			double num2 = \u0010\u0001\u0005.\u000A(\u0015\u0015\u0005.\u000A(\u001F), this.\u0006\u000A);
			if (num >= num2)
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
				return true;
			}
			\u001C\u000E.\u0013\u0018(\u001F, \u000E\u0001\u0005.\u000A());
			return false;
		}

		// Token: 0x0600196E RID: 6510 RVA: 0x000A48C4 File Offset: 0x000A2AC4
		private bool \u0017\u0018(ViewInformation \u001F)
		{
			if (\u0009\u0015\u0005.\u000A(\u001F\u0001\u0005.\u0007(\u0015\u0015\u0005.\u000A(\u001F))) == -1L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u000E.\u0017\u0018(ViewInformation)).MethodHandle;
				}
				if (\u0009\u0015\u0005.\u000A(\u001F\u0001\u0005.\u0007(\u000C\u0015\u0005.\u000A(\u001F))) == -1L)
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
					return true;
				}
			}
			if (\u0009\u0015\u0005.\u000A(\u001F\u0001\u0005.\u0007(\u000C\u0015\u0005.\u000A(\u001F))) == -1L)
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
				return true;
			}
			double num = \u0010\u0001\u0005.\u000A(\u0015\u0015\u0005.\u000A(\u001F), this.\u0006\u000A);
			double num2 = \u0010\u0001\u0005.\u000A(\u000C\u0015\u0005.\u000A(\u001F), this.\u0006\u000A);
			if (\u0009\u0015\u0005.\u000A(\u001F\u0001\u0005.\u0007(\u0015\u0015\u0005.\u000A(\u001F))) == -1L)
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
				num = double.MinValue;
			}
			if (num >= num2)
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
				return true;
			}
			\u001C\u000E.\u0013\u0018(\u001F, \u0008\u0001\u0005.\u000A());
			return false;
		}

		// Token: 0x0600196F RID: 6511 RVA: 0x000A49C4 File Offset: 0x000A2BC4
		private bool \u0014\u0018(ViewInformation \u001F)
		{
			if (\u0009\u0015\u0005.\u000A(\u001F\u0001\u0005.\u0007(\u0001\u0015\u0005.\u000A(\u001F))) == -1L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u000E.\u0014\u0018(ViewInformation)).MethodHandle;
				}
				if (\u0009\u0015\u0005.\u000A(\u001F\u0001\u0005.\u0007(\u000C\u0015\u0005.\u000A(\u001F))) == -1L)
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
					return true;
				}
			}
			if (\u0009\u0015\u0005.\u000A(\u001F\u0001\u0005.\u0007(\u000C\u0015\u0005.\u000A(\u001F))) == -1L)
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
				return true;
			}
			double num = \u0010\u0001\u0005.\u000A(\u0001\u0015\u0005.\u000A(\u001F), this.\u0006\u000A);
			double num2 = \u0010\u0001\u0005.\u000A(\u000C\u0015\u0005.\u000A(\u001F), this.\u0006\u000A);
			if (\u0009\u0015\u0005.\u000A(\u001F\u0001\u0005.\u0007(\u0015\u0015\u0005.\u000A(\u001F))) == -1L)
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
				num = double.MinValue;
			}
			if (num2 >= num)
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
				return true;
			}
			\u001C\u000E.\u0013\u0018(\u001F, \u001B\u0001\u0005.\u000A());
			return false;
		}

		// Token: 0x06001970 RID: 6512 RVA: 0x000A4AC0 File Offset: 0x000A2CC0
		private static void \u0013\u0018(ViewInformation \u001F, string \u000A)
		{
			if (\u001A\u0006\u0007.\u000A(\u0012\u0001\u0005.\u000A(\u001F)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u000E.\u0013\u0018(ViewInformation, string)).MethodHandle;
				}
				\u0006\u0001\u0005.\u000A(\u001F, \u000A);
				return;
			}
			\u0006\u0001\u0005.\u000A(\u001F, \u0002\u0013\u000A.\u000A(\u0012\u0001\u0005.\u000A(\u001F), " & ", \u000A));
		}

		// Token: 0x06001971 RID: 6513 RVA: 0x000A4B14 File Offset: 0x000A2D14
		private void \u001A\u0018(ViewInformation \u001F, Exception \u000A)
		{
			\u001E\u0015\u0005.\u000A(\u001F, UpdatedIconChange.NotValid);
			string u000A;
			if (!\u001A\u0006\u0007.\u000A(\u0012\u0001\u0005.\u000A(\u001F)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u000E.\u001A\u0018(ViewInformation, Exception)).MethodHandle;
				}
				u000A = \u0012\u0001\u0005.\u000A(\u001F);
			}
			else
			{
				u000A = \u000F\u0001\u0005.\u000A();
			}
			\u0006\u0001\u0005.\u000A(\u001F, u000A);
			\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), \u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\ViewRange\\Core\\ExternalEvents\\ViewRangeEvent.cs", "HandleException");
		}

		// Token: 0x06001972 RID: 6514 RVA: 0x000A4B7C File Offset: 0x000A2D7C
		private void \u000C\u0018()
		{
			List<ViewDetailReport> list = \u0001\u0001\u0005.\u000A();
			IEnumerable<ViewInformation> enumerable = \u0019\u0001\u0005.\u000A(this);
			Func<ViewInformation, bool> func;
			if ((func = \u001C\u000E.<>c.\u0004) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u000E.\u000C\u0018()).MethodHandle;
				}
				func = (\u001C\u000E.<>c.\u0004 = new Func<ViewInformation, bool>(\u001C\u000E.<>c.\u001F.\u0016));
			}
			List<ViewInformation>.Enumerator enumerator = \u001C\u0001\u0005.\u000A(Enumerable.ToList<ViewInformation>(Enumerable.Where<ViewInformation>(enumerable, func)));
			try
			{
				while (\u000B\u0001\u0005.\u000A(ref enumerator))
				{
					ViewInformation u001F = \u0003\u0001\u0005.\u000A(ref enumerator);
					ViewDetailReport viewDetailReport = \u0015\u0001\u0005.\u000A();
					\u001A\u0001\u0005.\u000A(viewDetailReport, \u000C\u0001\u0005.\u000A(u001F));
					\u0013\u0001\u0005.\u000A(viewDetailReport, \u0012\u0001\u0005.\u000A(u001F));
					\u0020\u0014\u0007.\u000A(viewDetailReport, ReportStates.Error);
					\u0014\u0001\u0005.\u000A(list, viewDetailReport);
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
			if (\u0017\u0001\u0005.\u000A(list) == 0)
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
				\u001E\u000E\u0007.\u000A(\u0020\u0001\u0005.\u000A(), \u0011\u0001\u0005.\u000A(this), 350.0, MessageBoxButtons.OK);
			}
			else
			{
				ReportsWindow u001F2 = \u0003\u0018\u001D.\u000A(\u001E\u0001\u0005.\u000A(Enumerable.ToList<Report>(Enumerable.Cast<Report>(list))), false);
				\u0015\u000D\u001D.\u000A(u001F2, \u0011\u0001\u0005.\u000A(this));
				\u0018\u0020\u000A.\u0007(u001F2);
			}
			\u0002\u0013\u0019.\u0007(\u000E\u0015\u0005.\u000A(this));
		}

		// Token: 0x04000A10 RID: 2576
		[CompilerGenerated]
		private List<ViewInformation> \u0002\u000A;

		// Token: 0x04000A11 RID: 2577
		[CompilerGenerated]
		private Window \u0018\u000A;

		// Token: 0x04000A12 RID: 2578
		private UnitConverter \u0006\u000A;

		// Token: 0x04000A13 RID: 2579
		[CompilerGenerated]
		private ProgressModel \u000F\u000A;
	}
}
