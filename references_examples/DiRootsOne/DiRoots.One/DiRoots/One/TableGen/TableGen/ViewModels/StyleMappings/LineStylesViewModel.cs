using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.TGDatabaseLayer.StyleMapping;

namespace DiRoots.One.TableGen.TableGen.ViewModels.StyleMappings
{
	// Token: 0x02000171 RID: 369
	public class LineStylesViewModel : StylesViewModelBase<LineStyleMappingVM>
	{
		// Token: 0x06000DBD RID: 3517 RVA: 0x00058784 File Offset: 0x00056984
		public LineStylesViewModel(Document doc, List<LineStyleMapping> styleMappings, Action onReadFromFiles, Action onMarkDataChanged) : base(doc, onReadFromFiles, onMarkDataChanged)
		{
			\u001E\u0003\u0019.\u0007(this, styleMappings);
			this.AvailableLineStyles = this.IX();
			this.LineStyleMappingVMs = new ObservableCollection<LineStyleMappingVM>();
			\u001B\u0003\u0019.\u000A(this, \u0011\u0009\u000A.\u000A(\u0011\u0003\u0019.\u000A(this)));
			\u0005\u0008\u0007.\u000A(\u0008\u0003\u0019.\u000A(this), new Predicate<object>(this.FP));
		}

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x06000DBE RID: 3518 RVA: 0x000587EC File Offset: 0x000569EC
		// (set) Token: 0x06000DBF RID: 3519 RVA: 0x00058800 File Offset: 0x00056A00
		public List<LineStyleMapping> StyleMappings { get; set; }

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06000DC0 RID: 3520 RVA: 0x00058814 File Offset: 0x00056A14
		public ObservableCollection<LineStyleMappingVM> LineStyleMappingVMs { get; }

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06000DC1 RID: 3521 RVA: 0x00058828 File Offset: 0x00056A28
		public ObservableCollection<LineRevitStyleItem> AvailableLineStyles { get; }

		// Token: 0x06000DC2 RID: 3522 RVA: 0x0005883C File Offset: 0x00056A3C
		public void UpdateMappingVMs()
		{
			\u0015\u0003\u0019.\u000A(this, \u0011\u0003\u0019.\u000A(this));
			\u000C\u0003\u0019.\u000A(\u0011\u0003\u0019.\u000A(this));
			List<LineStyleMapping>.Enumerator enumerator = \u000D\u001C\u0004.\u000A(\u001A\u0003\u0019.\u000A(this));
			try
			{
				while (\u0003\u001C\u0004.\u000A(ref enumerator))
				{
					LineStyleMapping u001F = \u001C\u001C\u0004.\u000A(ref enumerator);
					List<LineRevitStyleItem> u = this.AX(\u000D\u0002\u0004.\u0007(u001F));
					LineStyleMappingVM lineStyleMappingVM = \u0014\u0003\u0019.\u000A(u001F, \u0013\u0003\u0019.\u000A(this), u);
					this.TX(lineStyleMappingVM);
					\u0017\u0003\u0019.\u000A(lineStyleMappingVM, new PropertyChangedEventHandler(base.StyleVm_PropertyChanged));
					\u0020\u0003\u0019.\u000A(\u0011\u0003\u0019.\u000A(this), lineStyleMappingVM);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(LineStylesViewModel.UpdateMappingVMs()).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u0007\u0013\u000A.\u000A(this, "StylesView");
		}

		// Token: 0x06000DC3 RID: 3523 RVA: 0x00058914 File Offset: 0x00056B14
		private void TX(LineStyleMappingVM F)
		{
			LineStylesViewModel.\u001A\u000B u001A_u000B = new LineStylesViewModel.\u001A\u000B();
			u001A_u000B.\u001F = F;
			string u000A = \u0009\u0003\u0019.\u000A(u001A_u000B.\u001F);
			if (\u000A\u001C\u0019.\u000A(u001A_u000B.\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(LineStylesViewModel.TX(LineStyleMappingVM)).MethodHandle;
				}
				object u001F = u001A_u000B.\u001F;
				IEnumerable<LineRevitStyleItem> enumerable = \u0017\u0012\u0019.\u001D(u001A_u000B.\u001F);
				Func<LineRevitStyleItem, bool> func;
				if ((func = LineStylesViewModel.<>c.\u000A) == null)
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
					func = (LineStylesViewModel.<>c.\u000A = new Func<LineRevitStyleItem, bool>(LineStylesViewModel.<>c.\u001F.\u000F));
				}
				\u0018\u0003\u0019.\u001D(u001F, Enumerable.FirstOrDefault<LineRevitStyleItem>(enumerable, func));
				return;
			}
			if (\u001F\u001C\u0019.\u000A(u001A_u000B.\u001F))
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
				object u001F2 = u001A_u000B.\u001F;
				IEnumerable<LineRevitStyleItem> enumerable2 = \u0017\u0012\u0019.\u001D(u001A_u000B.\u001F);
				Func<LineRevitStyleItem, bool> func2;
				if ((func2 = LineStylesViewModel.<>c.\u0007) == null)
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
					func2 = (LineStylesViewModel.<>c.\u0007 = new Func<LineRevitStyleItem, bool>(LineStylesViewModel.<>c.\u001F.\u0012));
				}
				\u0018\u0003\u0019.\u001D(u001F2, Enumerable.FirstOrDefault<LineRevitStyleItem>(enumerable2, func2));
				if (!\u001B\u0003\u0004.\u000A(\u0009\u0003\u0019.\u000A(u001A_u000B.\u001F), u000A, StringComparison.Ordinal))
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
					\u001D\u0003\u0019.\u001D(u001A_u000B.\u001F, u000A);
					return;
				}
			}
			else
			{
				long? num = \u0001\u0003\u0019.\u000A(u001A_u000B.\u001F);
				if (\u0016\u0002\u0004.\u000A(ref num))
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
					LineRevitStyleItem lineRevitStyleItem = Enumerable.FirstOrDefault<LineRevitStyleItem>(\u0017\u0012\u0019.\u001D(u001A_u000B.\u001F), new Func<LineRevitStyleItem, bool>(u001A_u000B.\u000A));
					if (lineRevitStyleItem != null)
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
						\u0018\u0003\u0019.\u001D(u001A_u000B.\u001F, lineRevitStyleItem);
						return;
					}
				}
				LineRevitStyleItem lineRevitStyleItem2 = Enumerable.FirstOrDefault<LineRevitStyleItem>(\u0017\u0012\u0019.\u001D(u001A_u000B.\u001F), new Func<LineRevitStyleItem, bool>(u001A_u000B.\u0007));
				object u001F3 = u001A_u000B.\u001F;
				LineRevitStyleItem u000A2;
				if ((u000A2 = lineRevitStyleItem2) == null)
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
					IEnumerable<LineRevitStyleItem> enumerable3 = \u0017\u0012\u0019.\u001D(u001A_u000B.\u001F);
					Func<LineRevitStyleItem, bool> func3;
					if ((func3 = LineStylesViewModel.<>c.\u001D) == null)
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
						func3 = (LineStylesViewModel.<>c.\u001D = new Func<LineRevitStyleItem, bool>(LineStylesViewModel.<>c.\u001F.\u0003));
					}
					u000A2 = Enumerable.FirstOrDefault<LineRevitStyleItem>(enumerable3, func3);
				}
				\u0018\u0003\u0019.\u001D(u001F3, u000A2);
			}
		}

		// Token: 0x06000DC4 RID: 3524 RVA: 0x00058B18 File Offset: 0x00056D18
		private ObservableCollection<LineRevitStyleItem> IX()
		{
			ObservableCollection<LineRevitStyleItem> observableCollection = \u000E\u0003\u0019.\u000A();
			object u001F = observableCollection;
			LineRevitStyleItem lineRevitStyleItem = \u0006\u001C\u0019.\u000A();
			\u0010\u0003\u0019.\u000A(lineRevitStyleItem, \u0002\u0013\u000A.\u000A("<", \u0008\u001C\u001D.\u000A(), ">"));
			\u000D\u001C\u0019.\u000A(lineRevitStyleItem, true);
			\u0016\u001C\u0019.\u000A(lineRevitStyleItem, "");
			\u0016\u0003\u0019.\u000A(u001F, lineRevitStyleItem);
			object u001F2 = observableCollection;
			LineRevitStyleItem lineRevitStyleItem2 = \u0006\u001C\u0019.\u000A();
			\u0010\u0003\u0019.\u000A(lineRevitStyleItem2, \u001C\u001C\u0019.\u000A());
			\u000B\u001C\u0019.\u000A(lineRevitStyleItem2, true);
			\u0016\u001C\u0019.\u000A(lineRevitStyleItem2, "");
			\u0016\u0003\u0019.\u000A(u001F2, lineRevitStyleItem2);
			try
			{
				List<Category>.Enumerator enumerator = \u0020\u0002\u0004.\u000A(\u0014\u0002\u0004.\u000A(this._doc));
				try
				{
					while (\u0011\u0002\u0004.\u000A(ref enumerator))
					{
						Category category = \u001E\u0002\u0004.\u000A(ref enumerator);
						if (category != null)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(LineStylesViewModel.IX()).MethodHandle;
							}
							Autodesk.Revit.DB.Color color = \u000D\u0005\u000E.\u001F;
							GraphicsStyle graphicsStyle = \u0011\u0004\u000E.\u001F;
							LinePatternElement linePatternElement = \u0010\u0005\u000E.\u001F;
							double u000A = 0.0;
							try
							{
								color = \u0003\u001C\u0019.\u000A(category);
								graphicsStyle = \u0012\u0001\u001D.\u0007(category, 1);
								linePatternElement = \u001C\u0005\u000E.\u001F(\u0011\u0017\u000A.\u0007(this._doc, \u0012\u001C\u0019.\u000A(\u000B\u000C\u0004.\u000A(graphicsStyle), 1)));
								int? num = \u000F\u001C\u0019.\u000A(category, 1);
								u000A = (double)\u0009\u001F\u001D.\u000A(ref num);
							}
							catch
							{
							}
							string u000A2 = LineStylesViewModel.QX(graphicsStyle);
							IReadOnlyList<LinePatternSegmentType> u000A3 = Array.Empty<LinePatternSegmentType>();
							try
							{
								IList<LinePatternSegment> list;
								if (linePatternElement == null)
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
									list = \u0018\u0019\u000E.\u001F;
								}
								else
								{
									LinePattern linePattern = \u0005\u0006\u0004.\u001D(linePatternElement);
									if (linePattern == null)
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
										list = \u0018\u0019\u000E.\u001F;
									}
									else
									{
										list = \u0018\u0006\u0004.\u000A(linePattern);
									}
								}
								IList<LinePatternSegment> list2 = list;
								if (list2 != null)
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
									IEnumerable<LinePatternSegment> enumerable = list2;
									Func<LinePatternSegment, LinePatternSegmentType> func;
									if ((func = LineStylesViewModel.<>c.\u0004) == null)
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
										func = (LineStylesViewModel.<>c.\u0004 = new Func<LinePatternSegment, LinePatternSegmentType>(LineStylesViewModel.<>c.\u001F.\u001C));
									}
									u000A3 = Enumerable.ToArray<LinePatternSegmentType>(Enumerable.Select<LinePatternSegment, LinePatternSegmentType>(enumerable, func));
								}
							}
							catch
							{
							}
							if (graphicsStyle != null)
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
								object u001F3 = observableCollection;
								LineRevitStyleItem lineRevitStyleItem3 = \u0006\u001C\u0019.\u000A();
								\u0010\u0003\u0019.\u000A(lineRevitStyleItem3, \u0009\u0014\u000A.\u001D(category));
								\u0002\u001C\u0019.\u000A(lineRevitStyleItem3, new long?(\u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(graphicsStyle))));
								\u000B\u001C\u0019.\u000A(lineRevitStyleItem3, false);
								\u0016\u001C\u0019.\u000A(lineRevitStyleItem3, u000A2);
								\u0005\u001C\u0019.\u000A(lineRevitStyleItem3, u000A);
								System.Windows.Media.Color u000A4;
								if (color != null)
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
									u000A4 = \u0014\u0012\u0019.\u000A(\u0018\u001C\u0019.\u000A(color), \u0019\u001C\u0019.\u000A(color), \u0004\u001C\u0019.\u000A(color));
								}
								else
								{
									u000A4 = \u0013\u0012\u0019.\u000A();
								}
								\u001D\u001C\u0019.\u000A(lineRevitStyleItem3, u000A4);
								\u0007\u001C\u0019.\u000A(lineRevitStyleItem3, u000A3);
								\u0016\u0003\u0019.\u000A(u001F3, lineRevitStyleItem3);
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
			}
			catch (Exception u000A5)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A5, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\ViewModels\\StyleMappings\\LineStylesViewModel.cs", "BuildAvailableLineStyles");
			}
			return observableCollection;
		}

		// Token: 0x06000DC5 RID: 3525 RVA: 0x00058E34 File Offset: 0x00057034
		private static string QX(GraphicsStyle F)
		{
			if (F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(LineStylesViewModel.QX(GraphicsStyle)).MethodHandle;
				}
				return \u0002\u0013\u000A.\u000A("<", \u0010\u001C\u0019.\u000A(), ">");
			}
			ElementId elementId = \u0012\u001C\u0019.\u000A(\u000B\u000C\u0004.\u000A(F), 1);
			if (\u0011\u0016\u001D.\u000A(elementId, \u0008\u001C\u0019.\u000A()))
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
				return \u000E\u001C\u0019.\u000A();
			}
			LinePatternElement linePatternElement = \u001C\u0005\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u0008\u0019\u0007.\u000A(F), elementId));
			string text;
			if (linePatternElement == null)
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
				text = null;
			}
			else
			{
				text = \u0005\u001E\u000A.\u000A(linePatternElement);
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
				result = \u0002\u0013\u000A.\u000A("<", \u0010\u001C\u0019.\u000A(), ">");
			}
			return result;
		}

		// Token: 0x06000DC6 RID: 3526 RVA: 0x00058EFC File Offset: 0x000570FC
		internal List<LineRevitStyleItem> AX(ExcelLineStyleInfo F)
		{
			LineStylesViewModel.\u000C\u000B u000C_u000B = new LineStylesViewModel.\u000C\u000B();
			u000C_u000B.\u0007 = F;
			if (u000C_u000B.\u0007 == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(LineStylesViewModel.AX(ExcelLineStyleInfo)).MethodHandle;
				}
				return \u001B\u001C\u0019.\u000A();
			}
			u000C_u000B.\u001F = \u0002\u0005.\u0013(\u0015\u0002\u0004.\u0007(u000C_u000B.\u0007));
			LineStylesViewModel.\u000C\u000B u000C_u000B2 = u000C_u000B;
			System.Drawing.Color color = \u0012\u0002\u0004.\u0007(u000C_u000B.\u0007);
			byte u001F = \u0015\u0017\u001D.\u000A(ref color);
			color = \u0012\u0002\u0004.\u0007(u000C_u000B.\u0007);
			byte u000A = \u000C\u0017\u001D.\u000A(ref color);
			color = \u0012\u0002\u0004.\u0007(u000C_u000B.\u0007);
			u000C_u000B2.\u000A = \u0014\u0012\u0019.\u000A(u001F, u000A, \u0013\u0017\u001D.\u000A(ref color));
			IEnumerable<LineRevitStyleItem> enumerable = \u0013\u0003\u0019.\u000A(this);
			Func<LineRevitStyleItem, bool> func;
			if ((func = LineStylesViewModel.<>c.\u0019) == null)
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
				func = (LineStylesViewModel.<>c.\u0019 = new Func<LineRevitStyleItem, bool>(LineStylesViewModel.<>c.\u001F.\u000D));
			}
			IEnumerable<\u000F<LineRevitStyleItem, bool, double, double>> enumerable2 = Enumerable.Select<LineRevitStyleItem, \u000F<LineRevitStyleItem, bool, double, double>>(Enumerable.Where<LineRevitStyleItem>(enumerable, func), new Func<LineRevitStyleItem, \u000F<LineRevitStyleItem, bool, double, double>>(u000C_u000B.\u001D));
			Func<\u000F<LineRevitStyleItem, bool, double, double>, bool> func2;
			if ((func2 = LineStylesViewModel.<>c.\u0018) == null)
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
				func2 = (LineStylesViewModel.<>c.\u0018 = new Func<\u000F<LineRevitStyleItem, bool, double, double>, bool>(LineStylesViewModel.<>c.\u001F.\u0010));
			}
			IOrderedEnumerable<\u000F<LineRevitStyleItem, bool, double, double>> orderedEnumerable = Enumerable.OrderByDescending<\u000F<LineRevitStyleItem, bool, double, double>, bool>(enumerable2, func2);
			Func<\u000F<LineRevitStyleItem, bool, double, double>, double> func3;
			if ((func3 = LineStylesViewModel.<>c.\u0005) == null)
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
				func3 = (LineStylesViewModel.<>c.\u0005 = new Func<\u000F<LineRevitStyleItem, bool, double, double>, double>(LineStylesViewModel.<>c.\u001F.\u000E));
			}
			IOrderedEnumerable<\u000F<LineRevitStyleItem, bool, double, double>> orderedEnumerable2 = Enumerable.ThenBy<\u000F<LineRevitStyleItem, bool, double, double>, double>(orderedEnumerable, func3);
			Func<\u000F<LineRevitStyleItem, bool, double, double>, double> func4;
			if ((func4 = LineStylesViewModel.<>c.\u0016) == null)
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
				func4 = (LineStylesViewModel.<>c.\u0016 = new Func<\u000F<LineRevitStyleItem, bool, double, double>, double>(LineStylesViewModel.<>c.\u001F.\u0008));
			}
			IOrderedEnumerable<\u000F<LineRevitStyleItem, bool, double, double>> orderedEnumerable3 = Enumerable.ThenBy<\u000F<LineRevitStyleItem, bool, double, double>, double>(orderedEnumerable2, func4);
			Func<\u000F<LineRevitStyleItem, bool, double, double>, string> func5;
			if ((func5 = LineStylesViewModel.<>c.\u000B) == null)
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
				func5 = (LineStylesViewModel.<>c.\u000B = new Func<\u000F<LineRevitStyleItem, bool, double, double>, string>(LineStylesViewModel.<>c.\u001F.\u001B));
			}
			IEnumerable<\u000F<LineRevitStyleItem, bool, double, double>> enumerable3 = Enumerable.Take<\u000F<LineRevitStyleItem, bool, double, double>>(Enumerable.ThenBy<\u000F<LineRevitStyleItem, bool, double, double>, string>(orderedEnumerable3, func5, \u001C\u0012\u0004.\u000A()), 5);
			Func<\u000F<LineRevitStyleItem, bool, double, double>, LineRevitStyleItem> func6;
			if ((func6 = LineStylesViewModel.<>c.\u0002) == null)
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
				func6 = (LineStylesViewModel.<>c.\u0002 = new Func<\u000F<LineRevitStyleItem, bool, double, double>, LineRevitStyleItem>(LineStylesViewModel.<>c.\u001F.\u0011));
			}
			return Enumerable.ToList<LineRevitStyleItem>(Enumerable.Select<\u000F<LineRevitStyleItem, bool, double, double>, LineRevitStyleItem>(enumerable3, func6));
		}

		// Token: 0x06000DC7 RID: 3527 RVA: 0x000590F8 File Offset: 0x000572F8
		private static double GX(System.Windows.Media.Color F, System.Windows.Media.Color R)
		{
			double num = (double)(\u000A\u0010\u0004.\u000A(ref F) - \u000A\u0010\u0004.\u000A(ref R));
			double num2 = (double)(\u001F\u0010\u0004.\u000A(ref F) - \u001F\u0010\u0004.\u000A(ref R));
			double num3 = (double)(\u0009\u000D\u0004.\u000A(ref F) - \u0009\u000D\u0004.\u000A(ref R));
			return \u0011\u001F\u0007.\u000A(num * num + num2 * num2 + num3 * num3);
		}

		// Token: 0x06000DC8 RID: 3528 RVA: 0x00059154 File Offset: 0x00057354
		private bool FP(object F)
		{
			if (\u0010\u0010\u001D.\u000A(this._searchText))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(LineStylesViewModel.FP(object)).MethodHandle;
				}
				return true;
			}
			LineStyleMappingVM lineStyleMappingVM = \u0003\u0005\u000E.\u001F(F);
			if (lineStyleMappingVM != null)
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
				string u000A = \u000D\u0003\u0004.\u001D(this._searchText);
				if (!\u000F\u000C\u001D.\u0007(\u000D\u0003\u0004.\u001D(\u001E\u001C\u0019.\u000A(lineStyleMappingVM)), u000A))
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
					if (!\u000F\u000C\u001D.\u0007(\u000D\u0003\u0004.\u001D(\u0011\u001C\u0019.\u000A(lineStyleMappingVM)), u000A))
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
						string u001F;
						if ((u001F = \u0009\u0003\u0019.\u000A(lineStyleMappingVM)) == null)
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
							u001F = "";
						}
						return \u000F\u000C\u001D.\u0007(\u000D\u0003\u0004.\u001D(u001F), u000A);
					}
				}
				return true;
			}
			return true;
		}

		// Token: 0x06000DC9 RID: 3529 RVA: 0x00059220 File Offset: 0x00057420
		public List<LineStyleMapping> GetStyleMappings()
		{
			IEnumerable<LineStyleMappingVM> enumerable = \u0011\u0003\u0019.\u000A(this);
			Func<LineStyleMappingVM, LineStyleMapping> func;
			if ((func = LineStylesViewModel.<>c.\u0006) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(LineStylesViewModel.GetStyleMappings()).MethodHandle;
				}
				func = (LineStylesViewModel.<>c.\u0006 = new Func<LineStyleMappingVM, LineStyleMapping>(LineStylesViewModel.<>c.\u001F.\u001E));
			}
			return Enumerable.ToList<LineStyleMapping>(Enumerable.Select<LineStyleMappingVM, LineStyleMapping>(enumerable, func));
		}

		// Token: 0x0400056E RID: 1390
		[CompilerGenerated]
		private List<LineStyleMapping> KD;

		// Token: 0x0400056F RID: 1391
		[CompilerGenerated]
		private readonly ObservableCollection<LineStyleMappingVM> JD;

		// Token: 0x04000570 RID: 1392
		[CompilerGenerated]
		private readonly ObservableCollection<LineRevitStyleItem> ED;

		// Token: 0x0200084C RID: 2124
		[CompilerGenerated]
		private sealed class \u001A\u000B
		{
			// Token: 0x06004E7F RID: 20095 RVA: 0x001E0E6C File Offset: 0x001DF06C
			internal bool \u000A(LineRevitStyleItem \u001F)
			{
				long? num = \u0007\u0003\u0019.\u0007(\u001F);
				long? num2 = \u0001\u0003\u0019.\u000A(this.\u001F);
				long num3 = \u0017\u0002\u0004.\u000A(ref num2);
				return \u0012\u001B\u0018.\u000A(ref num) == num3 & \u0016\u0002\u0004.\u000A(ref num);
			}

			// Token: 0x06004E80 RID: 20096 RVA: 0x001E0EB0 File Offset: 0x001DF0B0
			internal bool \u0007(LineRevitStyleItem \u001F)
			{
				if (\u0008\u0013\u000A.\u000A(\u0004\u0003\u0019.\u0007(\u001F), \u0009\u0003\u0019.\u000A(this.\u001F)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(LineStylesViewModel.\u001A\u000B.\u0007(LineRevitStyleItem)).MethodHandle;
					}
					if (!\u001F\u0003\u0019.\u0007(\u001F))
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
						return !\u0019\u0003\u0019.\u0007(\u001F);
					}
				}
				return false;
			}

			// Token: 0x0400211D RID: 8477
			public LineStyleMappingVM \u001F;
		}

		// Token: 0x0200084D RID: 2125
		[CompilerGenerated]
		private sealed class \u000C\u000B
		{
			// Token: 0x06004E82 RID: 20098 RVA: 0x001E0F24 File Offset: 0x001DF124
			internal \u000F<LineRevitStyleItem, bool, double, double> \u001D(LineRevitStyleItem \u001F)
			{
				IReadOnlyList<LinePatternSegmentType> readOnlyList;
				if ((readOnlyList = \u0020\u001C\u0019.\u001D(\u001F)) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(LineStylesViewModel.\u000C\u000B.\u001D(LineRevitStyleItem)).MethodHandle;
					}
					readOnlyList = Array.Empty<LinePatternSegmentType>();
				}
				return new \u000F<LineRevitStyleItem, bool, double, double>(\u001F, Enumerable.SequenceEqual<LinePatternSegmentType>(readOnlyList, this.\u001F), LineStylesViewModel.GX(\u0017\u001C\u0019.\u001D(\u001F), this.\u000A), \u0008\u001F\u0007.\u000A(\u0014\u001C\u0019.\u001D(\u001F) - (double)\u001C\u0002\u0004.\u0007(this.\u0007)));
			}

			// Token: 0x0400211E RID: 8478
			public IReadOnlyList<LinePatternSegmentType> \u001F;

			// Token: 0x0400211F RID: 8479
			public System.Windows.Media.Color \u000A;

			// Token: 0x04002120 RID: 8480
			public ExcelLineStyleInfo \u0007;
		}
	}
}
