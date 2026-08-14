using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.TableGen.TGRevitHelper;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.Dto;
using DiRoots.One.TGDatabaseLayer.StyleMapping;

namespace A
{
	// Token: 0x020000F1 RID: 241
	internal static class \u0015\u0018
	{
		// Token: 0x17000240 RID: 576
		// (get) Token: 0x060008C1 RID: 2241 RVA: 0x000395A4 File Offset: 0x000377A4
		// (set) Token: 0x060008C2 RID: 2242 RVA: 0x000395B8 File Offset: 0x000377B8
		internal static bool IsCancelled { get; set; }

		// Token: 0x060008C3 RID: 2243 RVA: 0x000395CC File Offset: 0x000377CC
		internal static bool \u000A(ViewType \u001F, string \u000A)
		{
			\u0015\u0018.\u0014\u0018 u0014_u = new \u0015\u0018.\u0014\u0018();
			u0014_u.\u001F = \u001F;
			u0014_u.\u000A = \u000A;
			return Enumerable.FirstOrDefault<View>(\u0015\u0018.\u001D(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()), u0014_u.\u001F), new Func<View, bool>(u0014_u.\u0007)) != null;
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x00039620 File Offset: 0x00037820
		internal static bool \u000A(ViewType \u001F, string \u000A, long \u0007)
		{
			\u0015\u0018.\u0013\u0018 u0013_u = new \u0015\u0018.\u0013\u0018();
			u0013_u.\u001F = \u0007;
			u0013_u.\u000A = \u001F;
			u0013_u.\u0007 = \u000A;
			return Enumerable.FirstOrDefault<View>(\u0015\u0018.\u001D(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()), u0013_u.\u000A), new Func<View, bool>(u0013_u.\u001D)) != null;
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x0003967C File Offset: 0x0003787C
		internal static bool \u0007(ViewType \u001F, string \u000A)
		{
			\u0015\u0018.\u001A\u0018 u001A_u = new \u0015\u0018.\u001A\u0018();
			u001A_u.\u001F = \u001F;
			u001A_u.\u000A = \u000A;
			Element element = Enumerable.FirstOrDefault<View>(\u0015\u0018.\u001D(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()), u001A_u.\u001F), new Func<View, bool>(u001A_u.\u0007));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0018.\u0007(ViewType, string)).MethodHandle;
				}
				\u001D\u0010\u0007.\u0007(\u0008\u001B\u001D.\u0007(\u0007\u0018.\u0007<DocumentContext>()), \u0004\u0019\u000E.\u001F(element));
				return true;
			}
			return false;
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x00039700 File Offset: 0x00037900
		internal static IEnumerable<View> \u001D(Document \u001F, ViewType \u000A)
		{
			if (\u000A != 10)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0018.\u001D(Document, ViewType)).MethodHandle;
				}
				if (\u000A != 11)
				{
					return \u001F.GetElements<ViewSchedule>();
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
			return \u001F.GetElements<View>();
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x00039748 File Offset: 0x00037948
		internal static void \u0004(List<DiRoots.One.TGDatabaseLayer.SelectedExcel> \u001F)
		{
			\u0015\u0018.\u0004(\u0008\u001B\u001D.\u0007(\u0007\u0018.\u0007<DocumentContext>()), \u001F);
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x0003976C File Offset: 0x0003796C
		private static void \u0004(UIDocument \u001F, List<DiRoots.One.TGDatabaseLayer.SelectedExcel> \u000A)
		{
			\u0015\u0018.\u000C\u0018 u000C_u = new \u0015\u0018.\u000C\u0018();
			\u0008\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\ViewHandler.cs", "RemoveViews");
			u000C_u.\u001F = \u0011\u0020\u000A.\u0007(\u001F);
			List<ElementId> list = \u001C\u0013\u000A.\u000A();
			List<DiRoots.One.TGDatabaseLayer.SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(\u000A);
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					ElementId elementId = \u001E\u0001\u000A.\u000A(\u0009\u0005\u0004.\u000A(\u001F\u0016\u0004.\u000A(ref enumerator)));
					if (\u0005\u001F\u000E.\u001F(\u0011\u0017\u000A.\u0007(u000C_u.\u001F, elementId)) != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0018.\u0004(UIDocument, List<DiRoots.One.TGDatabaseLayer.SelectedExcel>)).MethodHandle;
						}
						if (\u000B\u001E\u000A.\u000A(elementId) != 0L)
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
							\u0003\u0010\u0007.\u000A(list, elementId);
						}
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
			if (\u001A\u0014\u000A.\u000A(list) > 0)
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
				List<UIView> list2 = Enumerable.ToList<UIView>(\u0017\u0010\u0007.\u000A(\u001F));
				if (\u0014\u000E\u0007.\u000A(list, \u0002\u001E\u000A.\u0007(\u0004\u0013\u000A.\u0007(u000C_u.\u001F))))
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
					UIView uiview = Enumerable.FirstOrDefault<UIView>(list2, new Func<UIView, bool>(u000C_u.\u000A));
					if (uiview != null)
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
						\u001D\u0010\u0007.\u0007(\u001F, \u0004\u0019\u000E.\u001F(\u0011\u0017\u000A.\u0007(u000C_u.\u001F, \u0008\u000E\u0007.\u000A(uiview))));
					}
					else
					{
						\u001D\u0010\u0007.\u0007(\u001F, \u0018\u0018.\u001D(u000C_u.\u001F));
					}
				}
				List<ElementId>.Enumerator enumerator2 = \u0015\u0005\u0004.\u000A(list);
				try
				{
					IL_1F8:
					while (\u001A\u0005\u0004.\u000A(ref enumerator2))
					{
						ElementId u000A = \u000C\u0005\u0004.\u000A(ref enumerator2);
						List<UIView>.Enumerator enumerator3 = \u0011\u0010\u0007.\u000A(Enumerable.ToList<UIView>(\u0017\u0010\u0007.\u000A(\u001F)));
						try
						{
							while (\u000E\u0010\u0007.\u000A(ref enumerator3))
							{
								UIView u001F = \u001B\u0010\u0007.\u000A(ref enumerator3);
								if (\u0011\u0016\u001D.\u000A(\u0008\u000E\u0007.\u000A(u001F), u000A))
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
									\u0008\u0010\u0007.\u000A(u001F);
									goto IL_1F8;
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
							((IDisposable)enumerator3).Dispose();
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
					((IDisposable)enumerator2).Dispose();
				}
				try
				{
					TransactionGroup transactionGroup = \u0009\u0017\u0007.\u000A(u000C_u.\u001F, \u0004\u001E\u000A.\u000A("TableGen - Remove Table ", \u0014\u0005\u0004.\u0007(\u0013\u0005\u0004.\u000A(\u000A, 0))));
					try
					{
						\u0001\u0017\u0007.\u000A(transactionGroup);
						Transaction transaction = \u0013\u0001\u000A.\u000A(u000C_u.\u001F);
						try
						{
							\u0017\u0001\u000A.\u000A(transaction, "Remove DraftViews Only");
							if (\u001A\u0014\u000A.\u000A(list) > 0)
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
								\u0003\u0009\u001D.\u000A(u000C_u.\u001F, list);
							}
							\u0018\u0018.\u001F(u000C_u.\u001F);
							\u001B\u0001\u000A.\u000A(transaction);
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
						if (\u0008\u0013\u000A.\u000A(\u0020\u0005\u0004.\u000A(\u0017\u0005\u0004.\u0007(u000C_u.\u001F)), "2017"))
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
							Transaction transaction2 = \u0013\u0001\u000A.\u000A(u000C_u.\u001F);
							try
							{
								\u0017\u0001\u000A.\u000A(transaction2, "Create DraftView");
								IEnumerable<ViewFamilyType> elements = u000C_u.\u001F.GetElements<ViewFamilyType>();
								Func<ViewFamilyType, bool> func;
								if ((func = \u0015\u0018.<>c.\u000A) == null)
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
									func = (\u0015\u0018.<>c.\u000A = new Func<ViewFamilyType, bool>(\u0015\u0018.<>c.\u001F.\u0002));
								}
								ViewFamilyType u001F2 = Enumerable.FirstOrDefault<ViewFamilyType>(elements, func);
								\u001E\u0005\u0004.\u000A(u000C_u.\u001F, \u0002\u001E\u000A.\u0007(u001F2));
								\u001F\u0014\u0007.\u000A(transaction2);
							}
							finally
							{
								if (transaction2 != null)
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
									\u001F\u0017\u000A.\u000A(transaction2);
								}
							}
						}
						\u000C\u0017\u0007.\u000A(transactionGroup);
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
				}
				catch (Exception ex)
				{
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), ex, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\ViewHandler.cs", "RemoveViews");
					\u0011\u0005\u0004.\u000A(\u001E\u0018\u001D.\u000A(ex));
				}
			}
			\u0005\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\ViewHandler.cs", "RemoveViews");
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x00039C14 File Offset: 0x00037E14
		private static void \u0019(UIDocument \u001F, List<DiRoots.One.TGDatabaseLayer.SelectedExcel> \u000A)
		{
			\u0015\u0018.\u0005(\u0011\u0020\u000A.\u0007(\u001F), \u000A, true);
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x00039C30 File Offset: 0x00037E30
		private static void \u0018(UIDocument \u001F, List<DiRoots.One.TGDatabaseLayer.SelectedExcel> \u000A)
		{
			\u0015\u0018.\u0005(\u0011\u0020\u000A.\u0007(\u001F), \u000A, false);
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x00039C4C File Offset: 0x00037E4C
		private static void \u0005(Document \u001F, List<DiRoots.One.TGDatabaseLayer.SelectedExcel> \u000A, bool \u0007 = true)
		{
			List<Element> u001F = \u0016\u0016\u0004.\u000A();
			List<View> list = Enumerable.ToList<View>(\u0015\u0018.\u001D(\u001F, 11));
			\u0005\u0016\u0004.\u000A(list, Enumerable.ToList<View>(\u0015\u0018.\u001D(\u001F, 5)));
			List<DiRoots.One.TGDatabaseLayer.SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(\u000A);
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					\u0015\u0018.\u0020\u0018 u0020_u = new \u0015\u0018.\u0020\u0018();
					u0020_u.\u001F = \u001F\u0016\u0004.\u000A(ref enumerator);
					\u0018\u0016\u0004.\u000A(u001F, Enumerable.ToList<View>(Enumerable.Where<View>(list, new Func<View, bool>(u0020_u.\u000A))));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0018.\u0005(Document, List<DiRoots.One.TGDatabaseLayer.SelectedExcel>, bool)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			if (\u0019\u0016\u0004.\u0007(u001F) > 0)
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
				List<ElementId> list2 = \u001C\u0013\u000A.\u000A();
				List<ElementFilter> u001F2 = \u0004\u0016\u0004.\u000A();
				ElementCategoryFilter u000A;
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
					u000A = \u0003\u0018\u0007.\u000A(-2000051L);
					\u001D\u0016\u0004.\u000A(u001F2, u000A);
				}
				u000A = \u0003\u0018\u0007.\u000A(-2000300L);
				\u001D\u0016\u0004.\u000A(u001F2, u000A);
				u000A = \u0003\u0018\u0007.\u000A(-2002000L);
				\u001D\u0016\u0004.\u000A(u001F2, u000A);
				u000A = \u0003\u0018\u0007.\u000A(-2000560L);
				\u001D\u0016\u0004.\u000A(u001F2, u000A);
				LogicalOrFilter u000A2 = \u0007\u0020\u000A.\u000A(u001F2);
				List<Element>.Enumerator enumerator2 = \u0001\u0010\u0007.\u000A(u001F);
				try
				{
					while (\u000C\u0010\u0007.\u000A(ref enumerator2))
					{
						Element u001F3 = \u0015\u0010\u0007.\u000A(ref enumerator2);
						List<ElementId> u000A3 = Enumerable.ToList<ElementId>(\u0011\u0019\u0004.\u000A(\u0014\u0011\u000A.\u001D(\u001A\u0018\u0007.\u000A(\u001F, \u0002\u001E\u000A.\u0007(u001F3)), u000A2)));
						\u000F\u0013\u000A.\u000A(list2, u000A3);
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
					((IDisposable)enumerator2).Dispose();
				}
				try
				{
					Transaction transaction = \u0013\u0001\u000A.\u000A(\u001F);
					try
					{
						FailureHandlingOptions failureHandlingOptions = \u0006\u0014\u0007.\u000A(transaction);
						\u0002\u0014\u0007.\u000A(failureHandlingOptions, new \u001E\u0018());
						\u0017\u0001\u000A.\u000A(transaction, "Remove DraftViews");
						\u0003\u0009\u001D.\u000A(\u001F, list2);
						\u0018\u0018.\u001F(\u001F);
						\u0007\u0016\u0004.\u000A(transaction, failureHandlingOptions);
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
				catch (Exception ex)
				{
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), ex, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\ViewHandler.cs", "ClearViews");
					\u0011\u0005\u0004.\u000A(\u001E\u0018\u001D.\u000A(ex));
				}
			}
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x00039ED8 File Offset: 0x000380D8
		internal static void \u0016(UIDocument \u001F, List<\u0020\u0019> \u000A, ActionTypes \u0007, CancellationTokenSource \u001D, StyleMappingDto \u0004 = null, List<\u0015\u0005> \u0019 = null)
		{
			Document document = \u0011\u0020\u000A.\u0007(\u001F);
			View view = \u000F\u000B\u0004.\u0007(\u001F);
			TransactionGroup transactionGroup = \u0009\u0017\u0007.\u000A(document, \u0004\u001E\u000A.\u000A("TableGen - Create Table", \u0014\u0005\u0004.\u0007(\u0002\u0016\u0004.\u0007(\u0006\u000B\u0004.\u000A(\u000A, 0)))));
			try
			{
				\u0001\u0017\u0007.\u000A(transactionGroup);
				try
				{
					List<\u0020\u0019>.Enumerator enumerator = \u0002\u000B\u0004.\u000A(\u000A);
					try
					{
						while (\u000B\u0016\u0004.\u000A(ref enumerator))
						{
							\u0015\u0018.\u0017\u0018 u0017_u = new \u0015\u0018.\u0017\u0018();
							u0017_u.\u001F = \u000B\u000B\u0004.\u000A(ref enumerator);
							View view2 = \u0011\u001F\u000E.\u001F;
							bool u = false;
							Transaction transaction = \u0013\u0001\u000A.\u000A(document);
							try
							{
								\u0017\u0001\u000A.\u000A(transaction, "Create DraftView");
								u0017_u.\u000A = \u0009\u0005\u0004.\u000A(\u0002\u0016\u0004.\u0007(u0017_u.\u001F));
								if (!\u001A\u0006\u0007.\u000A(\u0016\u000B\u0004.\u000A(\u0002\u0016\u0004.\u0007(u0017_u.\u001F))))
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
										RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0018.\u0016(UIDocument, List<\u0020\u0019>, ActionTypes, CancellationTokenSource, StyleMappingDto, List<\u0015\u0005>)).MethodHandle;
									}
									\u0005\u000B\u0004.\u000A(\u0002\u0016\u0004.\u0007(u0017_u.\u001F), \u001D\u0019\u000E.\u001F);
									\u0018\u000B\u0004.\u000A(\u0002\u0016\u0004.\u0007(u0017_u.\u001F), \u000F\u0015\u0010.\u001F);
								}
								if (\u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F))) != 10)
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
									if (\u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F))) != 11)
									{
										view2 = Enumerable.FirstOrDefault<ViewSchedule>(document.GetElements<ViewSchedule>(), new Func<ViewSchedule, bool>(u0017_u.\u001D));
										goto IL_19E;
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
								view2 = Enumerable.FirstOrDefault<View>(document.GetElements<View>(), new Func<View, bool>(u0017_u.\u0007));
								IL_19E:
								u = (view2 != \u0011\u001F\u000E.\u001F);
								if (view2 == null)
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
									if (\u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F))) == 10)
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
										IEnumerable<ViewFamilyType> elements = document.GetElements<ViewFamilyType>();
										Func<ViewFamilyType, bool> func;
										if ((func = \u0015\u0018.<>c.\u0007) == null)
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
											func = (\u0015\u0018.<>c.\u0007 = new Func<ViewFamilyType, bool>(\u0015\u0018.<>c.\u001F.\u0006));
										}
										ViewFamilyType u001F = Enumerable.FirstOrDefault<ViewFamilyType>(elements, func);
										view2 = \u001E\u0005\u0004.\u000A(document, \u0002\u001E\u000A.\u0007(u001F));
									}
									else if (\u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F))) == 11)
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
										ElementId u000A = \u0015\u0018.\u0006(document, \u0004\u0018.\u001F());
										view2 = \u0004\u0019\u000E.\u001F(\u0011\u0017\u000A.\u0007(document, u000A));
										if (view2 == null)
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
											throw \u0008\u0013\u0007.\u000A("Legend template not found");
										}
									}
									else if (\u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F))) == 5)
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
										view2 = \u0019\u000B\u0004.\u000A(document, \u001B\u0009\u001D.\u000A(-1));
									}
								}
								string u000A2 = \u0014\u0005\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F));
								\u0016\u0018.\u001F(view2, u000A2);
								\u001B\u0001\u000A.\u000A(transaction);
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
							\u001D\u0010\u0007.\u0007(\u001F, view2);
							\u0004\u000B\u0004.\u000A(\u0002\u0016\u0004.\u0007(u0017_u.\u001F), \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(view2)));
							\u001D\u000B\u0004.\u000A(\u0002\u0016\u0004.\u0007(u0017_u.\u001F), \u0012\u0010\u0007.\u000A(view2));
							\u0007\u000B\u0004.\u000A(100);
							ViewType viewType = \u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F)));
							bool u2 = viewType == 5;
							\u001F\u0005.\u001F(u0017_u.\u001F, \u0004, u2);
							\u0002\u0005.\u000D(u0017_u.\u001F);
							BlackAndWhiteSettings? blackAndWhiteSettings2;
							if (!\u001F\u000B\u0004.\u0007(\u000A\u000B\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F))))
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
								BlackAndWhiteSettings? blackAndWhiteSettings;
								\u0019\u0019\u000E.\u001F(ref blackAndWhiteSettings);
								blackAndWhiteSettings2 = blackAndWhiteSettings;
							}
							else
							{
								blackAndWhiteSettings2 = new BlackAndWhiteSettings?(\u0009\u0016\u0004.\u000A(\u0004));
							}
							BlackAndWhiteSettings? u3 = blackAndWhiteSettings2;
							if (\u0001\u0016\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F)) == UpdateStates.Modified)
							{
								goto IL_449;
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
							if (\u0001\u0016\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F)) == UpdateStates.Recreate)
							{
								goto IL_449;
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
							bool flag;
							if (\u0007 != ActionTypes.Update)
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
								flag = (\u0007 == ActionTypes.UpdateFrom);
							}
							else
							{
								flag = true;
							}
							IL_44A:
							bool u000A3 = flag;
							UpdateBehaviorOption u4 = \u0015\u0018.\u000B(\u0004, u000A3, u, view2);
							if (\u0008\u0013\u000A.\u000A(\u000B\u0011\u001D.\u000A(\u0015\u0016\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F))), ImportTypes.Table.ToString()))
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
								\u0015\u0018.\u0002(document, \u001F, view2, u0017_u.\u001F, viewType, u4, \u0004, u3, \u001D, \u0019);
							}
							else if (\u000D\u001B\u001D.\u0007(\u0015\u0016\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F))) == 1)
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
								bool flag2;
								if (\u0004 != null)
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
									flag2 = \u0001\u0004\u0004.\u0007(\u0009\u0004\u0004.\u0007(\u0004));
								}
								else
								{
									flag2 = false;
								}
								bool u001D = flag2;
								List<DiRoots.One.TGDatabaseLayer.SelectedExcel> list = \u000C\u0016\u0004.\u000A(1);
								\u001A\u0016\u0004.\u000A(list, \u0002\u0016\u0004.\u0007(u0017_u.\u001F));
								\u0015\u0018.\u0019(\u001F, list);
								Transaction transaction2 = \u0013\u0001\u000A.\u000A(document);
								try
								{
									\u0017\u0001\u000A.\u000A(transaction2, "Import Images");
									\u000B\u0018\u0007.\u000A(view2, \u0019\u0020\u001D.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F)));
									\u0018\u0016.\u001F(\u0011\u0020\u000A.\u0007(\u001F), view2, u0017_u.\u001F, u001D, \u001D);
									\u001B\u0001\u000A.\u000A(transaction2);
								}
								finally
								{
									if (transaction2 != null)
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
										\u001F\u0017\u000A.\u000A(transaction2);
									}
								}
							}
							IList<UIView> u001F2 = \u0017\u0010\u0007.\u000A(\u001F);
							if (\u001E\u0010\u0007.\u000A(u001F2) > 1)
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
								IEnumerator<UIView> enumerator2 = \u0013\u0016\u0004.\u000A(u001F2);
								try
								{
									while (\u000A\u0017\u000A.\u000A(enumerator2))
									{
										UIView u001F3 = \u0014\u0016\u0004.\u000A(enumerator2);
										if (\u0011\u0016\u001D.\u000A(\u0008\u000E\u0007.\u000A(u001F3), \u0002\u001E\u000A.\u0007(view2)))
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
												\u0008\u0010\u0007.\u000A(u001F3);
												goto IL_639;
											}
											catch (Exception u000A4)
											{
												\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A4, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\ViewHandler.cs", "CreateViews");
												goto IL_639;
											}
											continue;
											IL_639:
											goto IL_651;
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
									if (enumerator2 != null)
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
										\u001F\u0017\u000A.\u000A(enumerator2);
									}
								}
							}
							IL_651:
							object u001F4 = \u0002\u0016\u0004.\u0007(u0017_u.\u001F);
							DateTime dateTime = \u0017\u0016\u0004.\u000A();
							\u001E\u0016\u0004.\u000A(u001F4, \u0020\u0016\u0004.\u000A(ref dateTime, "MM/dd/yyyy HH:mm:ss"));
							\u0011\u0016\u0004.\u000A(\u0002\u0016\u0004.\u0007(u0017_u.\u001F), \u0014\u0005\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F)));
							\u001B\u0016\u0004.\u000A(\u0002\u0016\u0004.\u0007(u0017_u.\u001F), \u0020\u0020\u001D.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F)));
							\u0008\u0016\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F), \u0014\u0020\u001D.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F)));
							\u0010\u0016\u0004.\u000A(\u0002\u0016\u0004.\u0007(u0017_u.\u001F), \u000E\u0016\u0004.\u000A(\u0002\u0016\u0004.\u0007(u0017_u.\u001F)));
							\u0002\u0016\u0004.\u0007(u0017_u.\u001F).RX();
							\u000D\u0016\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F), UpdateStates.Updated);
							\u001C\u0016\u0004.\u0007(\u0002\u0016\u0004.\u0007(u0017_u.\u001F), ActionTypes.None);
							\u000F\u0016\u0004.\u000A(\u0002\u0016\u0004.\u0007(u0017_u.\u001F), \u0002\u0005.\u0010(\u0004, \u0003\u0016\u0004.\u000A(u0017_u.\u001F), \u0012\u0016\u0004.\u000A(u0017_u.\u001F)));
							\u0006\u0016\u0004.\u000A(\u0002\u0016\u0004.\u0007(u0017_u.\u001F), false);
							Transaction transaction3 = \u0013\u0001\u000A.\u000A(document);
							try
							{
								\u0017\u0001\u000A.\u000A(transaction3, "TableGen Set Element Schema");
								SchemaUtil.\u000A(view2, \u0002\u0016\u0004.\u0007(u0017_u.\u001F));
								\u001B\u0001\u000A.\u000A(transaction3);
							}
							finally
							{
								if (transaction3 != null)
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
									\u001F\u0017\u000A.\u000A(transaction3);
								}
							}
							continue;
							IL_449:
							flag = false;
							goto IL_44A;
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
					\u000C\u0017\u0007.\u000A(transactionGroup);
				}
				catch (OperationCanceledException u000A5)
				{
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A5, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\ViewHandler.cs", "CreateViews");
					\u001A\u0017\u0007.\u000A(transactionGroup);
				}
				catch (Exception u000A6)
				{
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A6, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\ViewHandler.cs", "CreateViews");
					\u001A\u0017\u0007.\u000A(transactionGroup);
					throw;
				}
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
			try
			{
				if (\u000C\u0020\u000A.\u0007(view))
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
					\u001D\u0010\u0007.\u0007(\u001F, view);
				}
			}
			catch (Exception u000A7)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A7, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\ViewHandler.cs", "CreateViews");
			}
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x0003A898 File Offset: 0x00038A98
		private static UpdateBehaviorOption \u000B(StyleMappingDto \u001F, bool \u000A, bool \u0007, View \u001D)
		{
			bool flag;
			if (\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0018.\u000B(StyleMappingDto, bool, bool, View)).MethodHandle;
				}
				flag = \u0001\u0004\u0004.\u0007(\u0009\u0004\u0004.\u0007(\u001F));
			}
			else
			{
				flag = false;
			}
			bool flag2 = flag;
			if (\u000A)
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
					if (!flag2)
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
					}
					else
					{
						DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel selectedExcel = SchemaUtil.\u0007(\u001D);
						bool flag3;
						if (selectedExcel == null)
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
							flag3 = true;
						}
						else
						{
							StyleMappingDto styleMappingDto = \u0017\u0019\u0004.\u0007(selectedExcel);
							bool? flag4;
							bool? flag5;
							if (styleMappingDto == null)
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
								\u001B\u000A\u000E.\u001F(ref flag4);
								flag5 = flag4;
							}
							else
							{
								flag5 = new bool?(\u0001\u0004\u0004.\u0007(\u0009\u0004\u0004.\u001D(styleMappingDto)));
							}
							flag4 = flag5;
							flag3 = !\u0012\u0015\u000A.\u000A(ref flag4);
						}
						if (flag3)
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
							return UpdateBehaviorOption.RecreateSchedule;
						}
						UpdateBehaviorOption updateBehaviorOption = \u0012\u000B\u0004.\u0007(\u0009\u0004\u0004.\u0007(\u001F));
						if (updateBehaviorOption == UpdateBehaviorOption.PreserveRevitColumnRowSize)
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
							return UpdateBehaviorOption.RecreateSchedule;
						}
						return updateBehaviorOption;
					}
				}
			}
			return UpdateBehaviorOption.RecreateSchedule;
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x0003A980 File Offset: 0x00038B80
		private static void \u0002(Document \u001F, UIDocument \u000A, View \u0007, \u0020\u0019 \u001D, ViewType \u0004, UpdateBehaviorOption \u0019, StyleMappingDto \u0018, BlackAndWhiteSettings? \u0005, CancellationTokenSource \u0016, List<\u0015\u0005> \u000B)
		{
			if (\u0004 != 10)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0018.\u0002(Document, UIDocument, View, \u0020\u0019, ViewType, UpdateBehaviorOption, StyleMappingDto, BlackAndWhiteSettings?, CancellationTokenSource, List<\u0015\u0005>)).MethodHandle;
				}
				if (\u0004 == 11)
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
				}
				else
				{
					if (\u0019 == UpdateBehaviorOption.UpdateDataOnly)
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
						int num;
						int num2;
						int num3;
						int num4;
						\u000D\u0018.\u0007(\u001F, \u0007, \u001D, \u0016, out num, out num2, out num3, out num4);
						return;
					}
					if (\u0019 == UpdateBehaviorOption.PreserveRevitColumnRowSize)
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
						\u000D\u0018.\u000A(\u001F, \u0007, \u001D, \u0016, \u0018, \u000B);
						return;
					}
					\u000D\u0018.\u001F(\u001F, \u0007, \u001D, \u0016, \u0018, \u000B, true);
					return;
				}
			}
			if (\u0019 == UpdateBehaviorOption.UpdateDataOnly)
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
				int num5;
				int num6;
				int num7;
				int num8;
				\u000E\u0018.\u001F(\u001F, \u0007, \u001D, \u0016, out num5, out num6, out num7, out num8);
				return;
			}
			bool flag = \u0019 == UpdateBehaviorOption.PreserveRevitColumnRowSize;
			List<DiRoots.One.TGDatabaseLayer.SelectedExcel> list = \u0003\u000B\u0004.\u000A();
			\u001A\u0016\u0004.\u000A(list, \u0002\u0016\u0004.\u0007(\u001D));
			List<DiRoots.One.TGDatabaseLayer.SelectedExcel> u000A = list;
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
				\u0015\u0018.\u0018(\u000A, u000A);
			}
			else
			{
				\u0015\u0018.\u0019(\u000A, u000A);
			}
			\u0015\u0018.\u000F(Enumerable.ToList<\u0012\u0005>(Enumerable.Cast<\u0012\u0005>(\u000C\u001D\u0004.\u0007(\u001D))), \u0007, \u000A, \u0016, \u0019\u0020\u001D.\u0007(\u0002\u0016\u0004.\u0007(\u001D)), \u0005, \u0018, \u000B, flag);
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x0003AAA0 File Offset: 0x00038CA0
		internal static ElementId \u0006(Document \u001F, string \u000A)
		{
			try
			{
				\u001C\u000B\u0004.\u000A(\u0007\u0018.\u0007<ActiveDocumentHandler>(), new \u0019\u0002());
				Document document = \u0010\u000B\u0004.\u000A(\u0017\u0005\u0004.\u0007(\u001F), \u000A);
				try
				{
					IEnumerable<View> elements = document.GetElements<View>();
					Func<View, bool> func;
					if ((func = \u0015\u0018.<>c.\u001D) == null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0018.\u0006(Document, string)).MethodHandle;
						}
						func = (\u0015\u0018.<>c.\u001D = new Func<View, bool>(\u0015\u0018.<>c.\u001F.\u000F));
					}
					Element element = Enumerable.FirstOrDefault<View>(elements, func);
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
						List<ElementId> list = \u001C\u0013\u000A.\u000A();
						\u0003\u0010\u0007.\u000A(list, \u0002\u001E\u000A.\u0007(element));
						ICollection<ElementId> collection = \u0018\u0018.\u0007(document, \u001F, list);
						if (collection != null)
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
							\u000D\u000B\u0004.\u000A(document, false);
							return Enumerable.FirstOrDefault<ElementId>(collection);
						}
					}
					\u000D\u000B\u0004.\u000A(document, false);
				}
				finally
				{
					if (document != null)
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
						\u001F\u0017\u000A.\u000A(document);
					}
				}
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\ViewHandler.cs", "CopyLegendView");
			}
			finally
			{
				\u001C\u000B\u0004.\u000A(\u0007\u0018.\u0007<ActiveDocumentHandler>(), \u0007\u0019\u000E.\u001F);
			}
			return Constants.InvalidElementId;
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x0003ABE0 File Offset: 0x00038DE0
		private static void \u000F(List<\u0012\u0005> \u001F, View \u000A, UIDocument \u0007, CancellationTokenSource \u001D, int \u0004, BlackAndWhiteSettings? \u0019, StyleMappingDto \u0018 = null, List<\u0015\u0005> \u0005 = null, bool \u0016 = false)
		{
			bool flag;
			if (\u0018 != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0018.\u000F(List<\u0012\u0005>, View, UIDocument, CancellationTokenSource, int, BlackAndWhiteSettings?, StyleMappingDto, List<\u0015\u0005>, bool)).MethodHandle;
				}
				flag = \u0001\u0004\u0004.\u0007(\u0009\u0004\u0004.\u0007(\u0018));
			}
			else
			{
				flag = false;
			}
			bool flag2 = flag;
			Document document = \u0011\u0020\u000A.\u0007(\u0007);
			if (\u000A != null)
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
				Transaction transaction = \u0013\u0001\u000A.\u000A(document);
				try
				{
					\u0017\u0001\u000A.\u000A(transaction, "Create Tables");
					\u000B\u0018\u0007.\u000A(\u000A, \u0004);
					FilledRegionType u001F = \u0018\u0018.\u000A(document);
					\u001F = Enumerable.ToList<\u0012\u0005>(Enumerable.Distinct<\u0012\u0005>(\u001F));
					\u001F = \u001D\u0018.\u0005(\u001F);
					int num = 0;
					IEnumerable<\u0012\u0005> enumerable = \u001F;
					Func<\u0012\u0005, bool> func;
					if ((func = \u0015\u0018.<>c.\u0004) == null)
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
						func = (\u0015\u0018.<>c.\u0004 = new Func<\u0012\u0005, bool>(\u0015\u0018.<>c.\u001F.\u0012));
					}
					IEnumerator<\u0012\u0005> enumerator = \u0020\u0019\u0004.\u000A(Enumerable.Where<\u0012\u0005>(enumerable, func));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							\u0012\u0005 u0012_u = \u001E\u0019\u0004.\u000A(enumerator);
							if (\u0004\u0013\u001D.\u0007(\u001D))
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
								throw \u001A\u001D\u0004.\u000A();
							}
							if (num % 10 == 0)
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
								\u0008\u000B\u0004.\u000A();
							}
							if (\u000C\u000B\u0004.\u000A())
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
								goto IL_2C1;
							}
							try
							{
								double num2 = \u001F\u001D\u0004.\u000A(\u0006\u0017\u001D.\u000A(u0012_u));
								bool u000A = \u0017\u0017\u001D.\u000A(\u0006\u0017\u001D.\u000A(u0012_u));
								bool u = \u0014\u0017\u001D.\u000A(\u0006\u0017\u001D.\u000A(u0012_u));
								bool u001D = \u0020\u0017\u001D.\u000A(\u0006\u0017\u001D.\u000A(u0012_u));
								string u2 = \u0007\u001D\u0004.\u000A(\u0006\u0017\u001D.\u000A(u0012_u));
								Color u001F2 = \u001A\u0017\u001D.\u0007(\u0006\u0017\u001D.\u000A(u0012_u));
								bool flag3 = true;
								ElementId elementId;
								if (flag2)
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
									if (\u0004\u001D\u0004.\u000A(u0012_u) != null)
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
										elementId = \u0009\u0018.\u0007(\u0004\u001D\u0004.\u000A(u0012_u), num2, \u0018, document, \u0005, out flag3);
										goto IL_1E5;
									}
								}
								elementId = \u0008\u0018.\u0007(num2, u000A, u, u001D, u2, document);
								IL_1E5:
								if (\u001B\u001B\u001D.\u000A(elementId, \u0012\u0015\u0010.\u001F))
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
									TextNote textNote = \u0008\u0018.\u000A(document, \u000A, elementId, u0012_u);
									if (flag3)
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
										if (textNote != null)
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
											OverrideGraphicSettings overrideGraphicSettings = \u000F\u0005\u0007.\u000A();
											\u0014\u0019\u0004.\u000A(overrideGraphicSettings, u001F2.\u001F());
											\u0002\u0005\u0007.\u000A(\u000A, \u0002\u001E\u000A.\u0007(textNote), overrideGraphicSettings);
										}
									}
								}
							}
							catch (Exception ex)
							{
								\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), ex, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\ViewHandler.cs", "CreateViewFromDrawingCommands");
								\u0015\u000B\u0004.\u000A("Text Error", \u0003\u001A\u000A.\u000A(ex));
							}
							num++;
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
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
							\u001F\u0017\u000A.\u000A(enumerator);
						}
					}
					IL_2C1:
					num = 0;
					IEnumerable<\u0012\u0005> enumerable2 = \u001F;
					Func<\u0012\u0005, bool> func2;
					if ((func2 = \u0015\u0018.<>c.\u0019) == null)
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
						func2 = (\u0015\u0018.<>c.\u0019 = new Func<\u0012\u0005, bool>(\u0015\u0018.<>c.\u001F.\u0003));
					}
					enumerator = \u0020\u0019\u0004.\u000A(Enumerable.Where<\u0012\u0005>(enumerable2, func2));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							\u0012\u0005 u001F3 = \u001E\u0019\u0004.\u000A(enumerator);
							if (\u0004\u0013\u001D.\u0007(\u001D))
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
								throw \u001A\u001D\u0004.\u000A();
							}
							if (\u0010\u0019\u0004.\u000A(u001F3).\u0002())
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
								double u001F4 = \u001B\u0019\u0004.\u000A(u001F3) / 12.0;
								double u000A2 = \u0008\u0019\u0004.\u000A(u001F3) / 12.0;
								Element u001F5 = \u0018\u0016.\u0007(document, \u000A, \u0007\u0019\u0004.\u0007(\u0010\u0019\u0004.\u000A(u001F3)), \u001B\u001F\u0007.\u000A(u001F4, u000A2, 0.0), \u000E\u0019\u0004.\u000A(\u0010\u0019\u0004.\u000A(u001F3)));
								\u0002\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(u001F5, -1007751L), \u0005\u0014\u001D.\u000A(\u0010\u0019\u0004.\u000A(u001F3)) / 12.0);
								\u0002\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(u001F5, -1007750L), \u0016\u0014\u001D.\u000A(\u0010\u0019\u0004.\u000A(u001F3)) / 12.0);
								\u000A\u0018.\u0005(\u0007\u0019\u0004.\u0007(\u0010\u0019\u0004.\u000A(u001F3)));
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
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
							\u001F\u0017\u000A.\u000A(enumerator);
						}
					}
					IEnumerable<GraphicsStyle> elements = document.GetElements<GraphicsStyle>();
					Func<GraphicsStyle, bool> func3;
					if ((func3 = \u0015\u0018.<>c.\u0018) == null)
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
						func3 = (\u0015\u0018.<>c.\u0018 = new Func<GraphicsStyle, bool>(\u0015\u0018.<>c.\u001F.\u001C));
					}
					IEnumerable<GraphicsStyle> enumerable3 = Enumerable.Where<GraphicsStyle>(elements, func3);
					Func<GraphicsStyle, ElementId> func4;
					if ((func4 = \u0015\u0018.<>c.\u0005) == null)
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
						func4 = (\u0015\u0018.<>c.\u0005 = new Func<GraphicsStyle, ElementId>(\u0015\u0018.<>c.\u001F.\u000D));
					}
					ElementId elementId2 = Enumerable.FirstOrDefault<ElementId>(Enumerable.Select<GraphicsStyle, ElementId>(enumerable3, func4));
					IEnumerable<\u0012\u0005> enumerable4 = \u001F;
					Func<\u0012\u0005, bool> func5;
					if ((func5 = \u0015\u0018.<>c.\u0016) == null)
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
						func5 = (\u0015\u0018.<>c.\u0016 = new Func<\u0012\u0005, bool>(\u0015\u0018.<>c.\u001F.\u0010));
					}
					enumerator = \u0020\u0019\u0004.\u000A(Enumerable.Where<\u0012\u0005>(enumerable4, func5));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							\u0012\u0005 u001F6 = \u001E\u0019\u0004.\u000A(enumerator);
							if (\u0004\u0013\u001D.\u0007(\u001D))
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
								throw \u001A\u001D\u0004.\u000A();
							}
							if (num % 20 == 0)
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
								\u0008\u000B\u0004.\u000A();
							}
							if (\u000C\u000B\u0004.\u000A())
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
								goto IL_7A2;
							}
							Color u001F7 = \u0011\u0007\u0004.\u000A(u001F6);
							if (!\u001E\u0007\u0004.\u000A(ref u001F7))
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
								if (!\u001A\u000B\u0004.\u000A(u001F7, \u0012\u0014\u001D.\u000A()))
								{
									try
									{
										double num3 = \u0015\u0001\u001D.\u000A(u001F6) / 12.0;
										double num4 = \u000C\u0001\u001D.\u000A(u001F6) / 12.0;
										double num5 = \u001A\u0001\u001D.\u000A(u001F6) / 12.0;
										double num6 = \u0013\u0001\u001D.\u000A(u001F6) / 12.0;
										XYZ[] array = \u000A\u0019\u000E.\u001F(5);
										array[0] = \u001B\u001F\u0007.\u000A(num3, num4, 0.0);
										array[1] = \u001B\u001F\u0007.\u000A(num3 + num6, num4, 0.0);
										array[2] = \u001B\u001F\u0007.\u000A(num3 + num6, num4 - num5, 0.0);
										array[3] = \u001B\u001F\u0007.\u000A(num3, num4 - num5, 0.0);
										array[4] = \u001B\u001F\u0007.\u000A(num3, num4, 0.0);
										XYZ[] array2 = array;
										List<CurveLoop> list = \u0013\u000B\u0004.\u000A();
										CurveLoop curveLoop = \u0014\u000B\u0004.\u000A();
										for (int i = 0; i <= 3; i++)
										{
											Line u000A3 = \u0002\u0007\u0007.\u000A(array2[i], array2[i + 1]);
											\u0017\u000B\u0004.\u000A(curveLoop, u000A3);
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
										\u0020\u000B\u0004.\u000A(list, curveLoop);
										FilledRegion u001F8 = \u001E\u000B\u0004.\u000A(document, \u0002\u001E\u000A.\u0007(u001F), \u0002\u001E\u000A.\u0007(\u000A), list);
										if (\u001B\u001B\u001D.\u000A(elementId2, \u0012\u0015\u0010.\u001F))
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
											\u0011\u000B\u0004.\u000A(u001F8, elementId2);
										}
										OverrideGraphicSettings overrideGraphicSettings2 = \u000F\u0005\u0007.\u000A();
										Color u000A4 = u001F7.\u001F();
										\u0016\u0018.\u0007(overrideGraphicSettings2, u000A4);
										\u0002\u0005\u0007.\u000A(\u000A, \u0002\u001E\u000A.\u0007(u001F8), overrideGraphicSettings2);
										\u001B\u000B\u0004.\u000A(document, \u000A, \u0002\u001E\u000A.\u0007(u001F8));
									}
									catch (Exception u000A5)
									{
										\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A5, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\ViewHandler.cs", "CreateViewFromDrawingCommands");
									}
									num++;
									continue;
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
							num++;
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
					IL_7A2:
					IEnumerable<\u0012\u0005> enumerable5 = \u001F;
					Func<\u0012\u0005, bool> func6;
					if ((func6 = \u0015\u0018.<>c.\u000B) == null)
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
						func6 = (\u0015\u0018.<>c.\u000B = new Func<\u0012\u0005, bool>(\u0015\u0018.<>c.\u001F.\u000E));
					}
					enumerator = \u0020\u0019\u0004.\u000A(Enumerable.Where<\u0012\u0005>(enumerable5, func6));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							\u0012\u0005 u001F9 = \u001E\u0019\u0004.\u000A(enumerator);
							if (\u0016)
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
								goto IL_9AE;
							}
							if (\u0004\u0013\u001D.\u0007(\u001D))
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
								throw \u001A\u001D\u0004.\u000A();
							}
							if (num % 20 == 0)
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
								\u0008\u000B\u0004.\u000A();
							}
							double u001F10 = \u0015\u0001\u001D.\u000A(u001F9) / 12.0;
							double u000A6 = \u000C\u0001\u001D.\u000A(u001F9) / 12.0;
							double u001F11 = \u001A\u0001\u001D.\u000A(u001F9) / 12.0;
							double u000A7 = \u0013\u0001\u001D.\u000A(u001F9) / 12.0;
							ExcelLineStyleInfo excelLineStyleInfo = \u0020\u0001\u001D.\u000A(u001F9);
							bool flag4;
							if (excelLineStyleInfo == null)
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
								flag4 = false;
							}
							else
							{
								flag4 = \u0017\u0001\u001D.\u0007(excelLineStyleInfo);
							}
							if (flag4)
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
								if (!flag2)
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
									num++;
									continue;
								}
							}
							if (!flag2)
							{
								goto IL_936;
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
							if (\u0020\u0001\u001D.\u000A(u001F9) == null)
							{
								goto IL_936;
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
							\u0001\u0018.\u0007(\u001B\u001F\u0007.\u000A(u001F10, u000A6, 0.0), \u001B\u001F\u0007.\u000A(u001F11, u000A7, 0.0), \u0020\u0001\u001D.\u000A(u001F9), \u0014\u0001\u001D.\u000A(u001F9), \u0018, \u000A, document, \u0005);
							IL_978:
							num++;
							continue;
							IL_936:
							\u0015\u0018.\u0012(\u001D\u0018.\u0007(\u001B\u001F\u0007.\u000A(u001F10, u000A6, 0.0), \u001B\u001F\u0007.\u000A(u001F11, u000A7, 0.0), \u0014\u0001\u001D.\u000A(u001F9), \u000A, document), \u000A, \u0019);
							goto IL_978;
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
					IL_9AE:
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
						\u001F\u0017\u000A.\u000A(transaction);
					}
				}
				\u0008\u0018.\u001D(document, \u000A);
				List<UIView>.Enumerator enumerator2 = \u0011\u0010\u0007.\u000A(Enumerable.ToList<UIView>(\u0017\u0010\u0007.\u000A(\u0007)));
				try
				{
					while (\u000E\u0010\u0007.\u000A(ref enumerator2))
					{
						UIView u001F12 = \u001B\u0010\u0007.\u000A(ref enumerator2);
						if (\u0011\u0016\u001D.\u000A(\u0002\u001E\u000A.\u0007(\u0011\u0017\u000A.\u0007(document, \u0008\u000E\u0007.\u000A(u001F12))), \u0002\u001E\u000A.\u0007(\u000A)))
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
							\u000E\u000B\u0004.\u000A(u001F12);
							return;
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
					((IDisposable)enumerator2).Dispose();
				}
			}
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x0003B70C File Offset: 0x0003990C
		private static void \u0012(DetailCurve \u001F, View \u000A, BlackAndWhiteSettings? \u0007)
		{
			if (\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0018.\u0012(DetailCurve, View, BlackAndWhiteSettings?)).MethodHandle;
				}
				if (\u0007\u0002\u0004.\u000A(ref \u0007))
				{
					try
					{
						Color u001F = \u000A\u0002\u0004.\u000A();
						BlackAndWhiteSettings blackAndWhiteSettings = \u001F\u0002\u0004.\u000A(ref \u0007);
						Color u001F2 = \u0001\u000B\u0004.\u000A(u001F, \u0009\u000B\u0004.\u000A(ref blackAndWhiteSettings));
						OverrideGraphicSettings overrideGraphicSettings = \u000F\u0005\u0007.\u000A();
						\u0014\u0019\u0004.\u000A(overrideGraphicSettings, u001F2.\u001F());
						\u0002\u0005\u0007.\u000A(\u000A, \u0002\u001E\u000A.\u0007(\u001F), overrideGraphicSettings);
					}
					catch (Exception u000A)
					{
						\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\ViewHandler.cs", "ApplyLegacyBorderBlackAndWhiteOverride");
					}
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
			}
		}

		// Token: 0x04000360 RID: 864
		[CompilerGenerated]
		private static bool \u001F;

		// Token: 0x020007F7 RID: 2039
		[CompilerGenerated]
		private sealed class \u0020\u0018
		{
			// Token: 0x06004D44 RID: 19780 RVA: 0x001DDE04 File Offset: 0x001DC004
			internal bool \u000A(View \u001F)
			{
				if (\u001C\u001C\u0007.\u0007(\u001F) == \u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(this.\u001F)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0018.\u0020\u0018.\u000A(View)).MethodHandle;
					}
					return \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F)) == \u0009\u0005\u0004.\u000A(this.\u001F);
				}
				return false;
			}

			// Token: 0x0400201E RID: 8222
			public DiRoots.One.TGDatabaseLayer.SelectedExcel \u001F;
		}

		// Token: 0x020007F8 RID: 2040
		[CompilerGenerated]
		private sealed class \u0017\u0018
		{
			// Token: 0x06004D46 RID: 19782 RVA: 0x001DDE78 File Offset: 0x001DC078
			internal bool \u0007(View \u001F)
			{
				if (\u001C\u001C\u0007.\u0007(\u001F) == \u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(\u0002\u0016\u0004.\u0007(this.\u001F))))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0018.\u0017\u0018.\u0007(View)).MethodHandle;
					}
					return \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F)) == this.\u000A;
				}
				return false;
			}

			// Token: 0x06004D47 RID: 19783 RVA: 0x001DDED8 File Offset: 0x001DC0D8
			internal bool \u001D(ViewSchedule \u001F)
			{
				return \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F)) == this.\u000A;
			}

			// Token: 0x0400201F RID: 8223
			public \u0020\u0019 \u001F;

			// Token: 0x04002020 RID: 8224
			public long \u000A;
		}

		// Token: 0x020007F9 RID: 2041
		[CompilerGenerated]
		private sealed class \u0014\u0018
		{
			// Token: 0x06004D49 RID: 19785 RVA: 0x001DDF10 File Offset: 0x001DC110
			internal bool \u0007(View \u001F)
			{
				if (\u001C\u001C\u0007.\u0007(\u001F) == this.\u001F)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0018.\u0014\u0018.\u0007(View)).MethodHandle;
					}
					return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u000A);
				}
				return false;
			}

			// Token: 0x04002021 RID: 8225
			public ViewType \u001F;

			// Token: 0x04002022 RID: 8226
			public string \u000A;
		}

		// Token: 0x020007FA RID: 2042
		[CompilerGenerated]
		private sealed class \u0013\u0018
		{
			// Token: 0x06004D4B RID: 19787 RVA: 0x001DDF6C File Offset: 0x001DC16C
			internal bool \u001D(View \u001F)
			{
				if (\u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F)) != this.\u001F)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0018.\u0013\u0018.\u001D(View)).MethodHandle;
					}
					if (\u001C\u001C\u0007.\u0007(\u001F) == this.\u000A)
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
						return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u0007);
					}
				}
				return false;
			}

			// Token: 0x04002023 RID: 8227
			public long \u001F;

			// Token: 0x04002024 RID: 8228
			public ViewType \u000A;

			// Token: 0x04002025 RID: 8229
			public string \u0007;
		}

		// Token: 0x020007FB RID: 2043
		[CompilerGenerated]
		private sealed class \u001A\u0018
		{
			// Token: 0x06004D4D RID: 19789 RVA: 0x001DDFE8 File Offset: 0x001DC1E8
			internal bool \u0007(View \u001F)
			{
				if (\u001C\u001C\u0007.\u0007(\u001F) == this.\u001F)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0018.\u001A\u0018.\u0007(View)).MethodHandle;
					}
					return \u0008\u0013\u000A.\u000A(\u0012\u0010\u0007.\u000A(\u001F), this.\u000A);
				}
				return false;
			}

			// Token: 0x04002026 RID: 8230
			public ViewType \u001F;

			// Token: 0x04002027 RID: 8231
			public string \u000A;
		}

		// Token: 0x020007FC RID: 2044
		[CompilerGenerated]
		private sealed class \u000C\u0018
		{
			// Token: 0x06004D4F RID: 19791 RVA: 0x001DE044 File Offset: 0x001DC244
			internal bool \u000A(UIView \u001F)
			{
				return \u001B\u001B\u001D.\u000A(\u0008\u000E\u0007.\u000A(\u001F), \u0002\u001E\u000A.\u0007(\u0004\u0013\u000A.\u0007(this.\u001F)));
			}

			// Token: 0x04002028 RID: 8232
			public Document \u001F;
		}
	}
}
