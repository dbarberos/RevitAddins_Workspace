using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.StyleMapping;
using Syncfusion.XlsIO;

namespace DiRoots.One.TGRevitHelper.StyleMapping
{
	// Token: 0x020000F6 RID: 246
	public sealed class ExcelStylesAggregator
	{
		// Token: 0x17000241 RID: 577
		// (get) Token: 0x060008EB RID: 2283 RVA: 0x0003CF54 File Offset: 0x0003B154
		public IReadOnlyCollection<ExcelLineStyleInfo> LineStyles
		{
			get
			{
				return this.\u0007;
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x060008EC RID: 2284 RVA: 0x0003CF68 File Offset: 0x0003B168
		public IReadOnlyCollection<ExcelTextStyleInfo> TextStyles
		{
			get
			{
				return this.\u001D;
			}
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x060008ED RID: 2285 RVA: 0x0003CF7C File Offset: 0x0003B17C
		public BlackAndWhiteTextLinesOption AggregateBwOption
		{
			get
			{
				return this.\u0004;
			}
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0003CF90 File Offset: 0x0003B190
		public void Sync(IEnumerable<SelectedExcel> excels, BlackAndWhiteTextLinesOption bwOption)
		{
			HashSet<SelectedExcel> u001F = \u0017\u000F\u0004.\u000A();
			Dictionary<\u0004\u0005, HashSet<long>> u001F2 = \u0020\u000F\u0004.\u000A();
			if (excels != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelStylesAggregator.Sync(IEnumerable<SelectedExcel>, BlackAndWhiteTextLinesOption)).MethodHandle;
				}
				IEnumerator<SelectedExcel> enumerator = \u001E\u000F\u0004.\u000A(excels);
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						SelectedExcel selectedExcel = \u0011\u000F\u0004.\u000A(enumerator);
						if (selectedExcel != null)
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
							\u001B\u000F\u0004.\u000A(u001F, selectedExcel);
							\u001D\u0005 u001D_u = \u001D\u0005.\u0005(selectedExcel);
							\u0004\u0005 u = u001D_u.\u0018;
							HashSet<long> hashSet;
							if (!\u0008\u000F\u0004.\u000A(u001F2, u, ref hashSet))
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
								hashSet = \u000E\u000F\u0004.\u000A();
								\u0010\u000F\u0004.\u000A(u001F2, u, hashSet);
							}
							\u001C\u000F\u0004.\u000A(hashSet, \u000D\u000F\u0004.\u000A(ref u001D_u));
							if (!ExcelStylesAggregator.\u0005(selectedExcel))
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
								\u0005\u000F\u0004.\u000A(this.\u000A, selectedExcel);
							}
							else if (\u0003\u000F\u0004.\u000A(this.\u001F, u001D_u))
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
								\u0012\u000F\u0004.\u000A(this.\u000A, selectedExcel, u001D_u);
							}
							else
							{
								\u0005\u000F\u0004.\u000A(this.\u000A, selectedExcel);
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
			List<SelectedExcel> u001F3 = \u0003\u000B\u0004.\u000A();
			Dictionary<SelectedExcel, \u001D\u0005>.KeyCollection.Enumerator enumerator2 = \u0006\u000F\u0004.\u000A(\u000F\u000F\u0004.\u000A(this.\u000A));
			try
			{
				while (\u0016\u000F\u0004.\u000A(ref enumerator2))
				{
					SelectedExcel u000A = \u0002\u000F\u0004.\u000A(ref enumerator2);
					if (!\u000B\u000F\u0004.\u000A(u001F, u000A))
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
						\u001A\u0016\u0004.\u000A(u001F3, u000A);
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
				((IDisposable)enumerator2).Dispose();
			}
			List<SelectedExcel>.Enumerator enumerator3 = \u000A\u0016\u0004.\u000A(u001F3);
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator3))
				{
					SelectedExcel u000A2 = \u001F\u0016\u0004.\u000A(ref enumerator3);
					\u0005\u000F\u0004.\u000A(this.\u000A, u000A2);
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
			this.\u0019(u001F2);
			\u0018\u000F\u0004.\u000A(this, bwOption);
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x0003D1CC File Offset: 0x0003B3CC
		private void \u0019(Dictionary<\u0004\u0005, HashSet<long>> \u001F)
		{
			if (\u0004\u0012\u0004.\u000A(this.\u001F) != 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelStylesAggregator.\u0019(Dictionary<\u0004\u0005, HashSet<long>>)).MethodHandle;
				}
				if (\u001D\u0012\u0004.\u000A(\u001F) == 0)
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
					List<\u001D\u0005> list = \u0003\u0019\u000E.\u001F;
					Dictionary<\u001D\u0005, \u0007\u0005>.KeyCollection.Enumerator enumerator = \u000A\u0012\u0004.\u000A(\u0007\u0012\u0004.\u000A(this.\u001F));
					try
					{
						while (\u0015\u000F\u0004.\u000A(ref enumerator))
						{
							\u001D\u0005 u000A = \u001F\u0012\u0004.\u000A(ref enumerator);
							HashSet<long> u001F;
							if (\u0008\u000F\u0004.\u000A(\u001F, u000A.\u0018, ref u001F))
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
								if (!\u0016\u001C\u001D.\u000A(u001F, \u000D\u000F\u0004.\u000A(ref u000A)))
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
									List<\u001D\u0005> u001F2;
									if ((u001F2 = list) == null)
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
										u001F2 = (list = \u0009\u000F\u0004.\u000A());
									}
									\u0001\u000F\u0004.\u000A(u001F2, u000A);
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
					if (list == null)
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
						return;
					}
					List<\u001D\u0005>.Enumerator enumerator2 = \u000C\u000F\u0004.\u000A(list);
					try
					{
						while (\u0014\u000F\u0004.\u000A(ref enumerator2))
						{
							\u001D\u0005 u000A2 = \u001A\u000F\u0004.\u000A(ref enumerator2);
							\u0013\u000F\u0004.\u000A(this.\u001F, u000A2);
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
					return;
				}
			}
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x0003D32C File Offset: 0x0003B52C
		public int EnsureExtracted(IEnumerable<SelectedExcel> excels, BlackAndWhiteTextLinesOption bwOption, Action<ExtractionProgressInfo> onProgress = null)
		{
			if (excels == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelStylesAggregator.EnsureExtracted(IEnumerable<SelectedExcel>, BlackAndWhiteTextLinesOption, Action<ExtractionProgressInfo>)).MethodHandle;
				}
				\u0018\u000F\u0004.\u000A(this, bwOption);
				return 0;
			}
			Dictionary<string, List<ValueTuple<SelectedExcel, \u001D\u0005>>> u001F = \u0003\u0012\u0004.\u000A(\u001C\u0012\u0004.\u000A());
			int num = 0;
			IEnumerator<SelectedExcel> enumerator = \u001E\u000F\u0004.\u000A(excels);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					SelectedExcel selectedExcel = \u0011\u000F\u0004.\u000A(enumerator);
					if (ExcelStylesAggregator.\u0005(selectedExcel))
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
						string text;
						if ((text = \u0011\u0020\u001D.\u0007(selectedExcel)) == null)
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
							text = string.Empty;
						}
						string text2 = text;
						if (!\u001A\u0006\u0007.\u000A(text2))
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
							if (\u0010\u0002\u001D.\u000A(text2))
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
								\u001D\u0005 u001D_u = \u001D\u0005.\u0005(selectedExcel);
								if (\u0003\u000F\u0004.\u000A(this.\u001F, u001D_u))
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
									\u0012\u000F\u0004.\u000A(this.\u000A, selectedExcel, u001D_u);
								}
								else
								{
									List<ValueTuple<SelectedExcel, \u001D\u0005>> list;
									if (!\u0012\u0012\u0004.\u000A(u001F, text2, ref list))
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
										list = \u000F\u0012\u0004.\u000A();
										\u0006\u0012\u0004.\u000A(u001F, text2, list);
									}
									\u0002\u0012\u0004.\u000A(list, new ValueTuple<SelectedExcel, \u001D\u0005>(selectedExcel, u001D_u));
									num++;
								}
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
			if (num == 0)
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
				\u0018\u000F\u0004.\u000A(this, bwOption);
				return 0;
			}
			int u = 0;
			Dictionary<string, List<ValueTuple<SelectedExcel, \u001D\u0005>>>.Enumerator enumerator2 = \u000B\u0012\u0004.\u000A(u001F);
			try
			{
				while (\u0019\u0012\u0004.\u000A(ref enumerator2))
				{
					KeyValuePair<string, List<ValueTuple<SelectedExcel, \u001D\u0005>>> keyValuePair = \u0016\u0012\u0004.\u000A(ref enumerator2);
					u = this.\u0018(\u0005\u0012\u0004.\u000A(ref keyValuePair), \u0018\u0012\u0004.\u000A(ref keyValuePair), u, num, onProgress);
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
				((IDisposable)enumerator2).Dispose();
			}
			\u0018\u000F\u0004.\u000A(this, bwOption);
			return num;
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x0003D538 File Offset: 0x0003B738
		public int Reload(IEnumerable<SelectedExcel> excels, BlackAndWhiteTextLinesOption bwOption, Action<ExtractionProgressInfo> onProgress = null)
		{
			if (excels == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelStylesAggregator.Reload(IEnumerable<SelectedExcel>, BlackAndWhiteTextLinesOption, Action<ExtractionProgressInfo>)).MethodHandle;
				}
				\u0018\u000F\u0004.\u000A(this, bwOption);
				return 0;
			}
			Dictionary<string, List<ValueTuple<SelectedExcel, \u001D\u0005>>> u001F = \u0003\u0012\u0004.\u000A(\u001C\u0012\u0004.\u000A());
			int num = 0;
			IEnumerator<SelectedExcel> enumerator = \u001E\u000F\u0004.\u000A(excels);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					SelectedExcel selectedExcel = \u0011\u000F\u0004.\u000A(enumerator);
					if (ExcelStylesAggregator.\u0005(selectedExcel))
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
						string text;
						if ((text = \u0011\u0020\u001D.\u0007(selectedExcel)) == null)
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
							text = string.Empty;
						}
						string text2 = text;
						if (!\u001A\u0006\u0007.\u000A(text2))
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
							if (\u0010\u0002\u001D.\u000A(text2))
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
								\u001D\u0005 item = \u001D\u0005.\u0005(selectedExcel);
								List<ValueTuple<SelectedExcel, \u001D\u0005>> list;
								if (!\u0012\u0012\u0004.\u000A(u001F, text2, ref list))
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
									list = \u000F\u0012\u0004.\u000A();
									\u0006\u0012\u0004.\u000A(u001F, text2, list);
								}
								\u0002\u0012\u0004.\u000A(list, new ValueTuple<SelectedExcel, \u001D\u0005>(selectedExcel, item));
								num++;
							}
						}
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
			int u = 0;
			Dictionary<string, List<ValueTuple<SelectedExcel, \u001D\u0005>>>.Enumerator enumerator2 = \u000B\u0012\u0004.\u000A(u001F);
			try
			{
				while (\u0019\u0012\u0004.\u000A(ref enumerator2))
				{
					KeyValuePair<string, List<ValueTuple<SelectedExcel, \u001D\u0005>>> keyValuePair = \u0016\u0012\u0004.\u000A(ref enumerator2);
					u = this.\u0018(\u0005\u0012\u0004.\u000A(ref keyValuePair), \u0018\u0012\u0004.\u000A(ref keyValuePair), u, num, onProgress);
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
				((IDisposable)enumerator2).Dispose();
			}
			\u0018\u000F\u0004.\u000A(this, bwOption);
			return num;
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x0003D6E4 File Offset: 0x0003B8E4
		private int \u0018(string \u001F, [TupleElementNames(new string[]
		{
			"excel",
			"key"
		})] List<ValueTuple<SelectedExcel, \u001D\u0005>> \u000A, int \u0007, int \u001D, Action<ExtractionProgressInfo> \u0004)
		{
			ExcelEngine excelEngine = \u000F\u0019\u000E.\u001F;
			IWorkbook workbook = \u0012\u0019\u000E.\u001F;
			try
			{
				excelEngine = \u0008\u001E\u001D.\u000A();
				IApplication u001F = \u000E\u001E\u001D.\u000A(excelEngine);
				\u0010\u001E\u001D.\u000A(u001F, ExcelVersion.Excel2013);
				u001F.\u001F(\u0007\u0018.\u0007<ICustomLogger>());
				try
				{
					workbook = \u001C\u001E\u001D.\u000A(\u000D\u001E\u001D.\u000A(u001F), \u001F);
				}
				catch (Exception u000A)
				{
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\ExcelStylesAggregator.cs", "ExtractFileBatch");
					return \u0007 + \u0020\u0012\u0004.\u000A(\u000A);
				}
				if (workbook == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelStylesAggregator.\u0018(string, List<ValueTuple<SelectedExcel, \u001D\u0005>>, int, int, Action<ExtractionProgressInfo>)).MethodHandle;
					}
					return \u0007 + \u0020\u0012\u0004.\u000A(\u000A);
				}
				List<ValueTuple<SelectedExcel, \u001D\u0005>>.Enumerator enumerator = \u001E\u0012\u0004.\u000A(\u000A);
				try
				{
					while (\u0010\u0012\u0004.\u000A(ref enumerator))
					{
						ValueTuple<SelectedExcel, \u001D\u0005> valueTuple = \u0011\u0012\u0004.\u000A(ref enumerator);
						SelectedExcel item = valueTuple.Item1;
						\u001D\u0005 item2 = valueTuple.Item2;
						\u0007++;
						try
						{
							if (\u0004 != null)
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
								int current = \u0007;
								string sheet;
								if (item == null)
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
									sheet = null;
								}
								else
								{
									sheet = \u0020\u0020\u001D.\u001D(item);
								}
								string region;
								if (item == null)
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
									region = \u000F\u0015\u0010.\u001F;
								}
								else
								{
									NamedRangeInfo namedRangeInfo = \u0014\u0020\u001D.\u001D(item);
									if (namedRangeInfo == null)
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
										region = \u000F\u0015\u0010.\u001F;
									}
									else
									{
										region = \u001B\u0012\u0004.\u0007(namedRangeInfo);
									}
								}
								\u0008\u0012\u0004.\u000A(\u0004, new ExtractionProgressInfo(current, \u001D, \u001F, sheet, region));
							}
							IRange range = \u000A\u0005.\u001F(workbook, item);
							if (range == null)
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
								ValueTuple<HashSet<ExcelLineStyleInfo>, HashSet<ExcelTextStyleInfo>> valueTuple2 = \u000A\u0005.\u000A(range);
								HashSet<ExcelLineStyleInfo> item3 = valueTuple2.Item1;
								HashSet<ExcelTextStyleInfo> item4 = valueTuple2.Item2;
								\u000E\u0012\u0004.\u000A(this.\u001F, item2, new \u0007\u0005(item3, item4));
								\u0012\u000F\u0004.\u000A(this.\u000A, item, item2);
							}
						}
						catch (Exception u000A2)
						{
							\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\ExcelStylesAggregator.cs", "ExtractFileBatch");
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
			}
			finally
			{
				try
				{
					if (workbook != null)
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
						\u0020\u0011\u001D.\u000A(workbook, false);
					}
				}
				catch (Exception u000A3)
				{
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A3, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\ExcelStylesAggregator.cs", "ExtractFileBatch");
				}
				try
				{
					if (excelEngine != null)
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
						\u000D\u0012\u0004.\u0007(excelEngine);
					}
				}
				catch (Exception u000A4)
				{
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A4, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\ExcelStylesAggregator.cs", "ExtractFileBatch");
				}
			}
			return \u0007;
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x0003D9C8 File Offset: 0x0003BBC8
		public void RebuildAggregate(BlackAndWhiteTextLinesOption bwOption)
		{
			\u0005\u0003\u0004.\u000A(this.\u0007);
			\u0018\u0003\u0004.\u000A(this.\u001D);
			this.\u0004 = bwOption;
			Dictionary<SelectedExcel, \u001D\u0005>.Enumerator enumerator = \u0019\u0003\u0004.\u000A(this.\u000A);
			try
			{
				while (\u0017\u0012\u0004.\u000A(ref enumerator))
				{
					KeyValuePair<SelectedExcel, \u001D\u0005> keyValuePair = \u0004\u0003\u0004.\u000A(ref enumerator);
					SelectedExcel selectedExcel = \u001D\u0003\u0004.\u000A(ref keyValuePair);
					\u0007\u0005 u001F;
					if (\u000A\u0003\u0004.\u000A(this.\u001F, \u0007\u0003\u0004.\u000A(ref keyValuePair), ref u001F))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelStylesAggregator.RebuildAggregate(BlackAndWhiteTextLinesOption)).MethodHandle;
						}
						bool flag;
						if (selectedExcel == null)
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
							flag = (null != null);
						}
						else
						{
							flag = (\u000A\u000B\u0004.\u001D(selectedExcel) != null);
						}
						bool flag2;
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
							flag2 = \u001F\u000B\u0004.\u0007(\u000A\u000B\u0004.\u0007(selectedExcel));
						}
						else
						{
							flag2 = false;
						}
						bool flag3 = flag2;
						HashSet<ExcelLineStyleInfo>.Enumerator enumerator2 = \u0009\u0012\u0004.\u000A(\u001F\u0003\u0004.\u000A(u001F));
						try
						{
							while (\u0015\u0012\u0004.\u000A(ref enumerator2))
							{
								ExcelLineStyleInfo excelLineStyleInfo = \u0001\u0012\u0004.\u000A(ref enumerator2);
								ExcelLineStyleInfo excelLineStyleInfo2;
								if (!flag3)
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
									excelLineStyleInfo2 = excelLineStyleInfo;
								}
								else
								{
									excelLineStyleInfo2 = \u0006\u001A\u001D.\u000A(\u0015\u0002\u0004.\u0007(excelLineStyleInfo), \u0001\u000B\u0004.\u000A(\u0012\u0002\u0004.\u0007(excelLineStyleInfo), bwOption));
								}
								ExcelLineStyleInfo u000A = excelLineStyleInfo2;
								\u0004\u000F\u0004.\u000A(this.\u0007, u000A);
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
							enumerator2.Dispose();
						}
						HashSet<ExcelTextStyleInfo>.Enumerator enumerator3 = \u001A\u0012\u0004.\u000A(\u000C\u0012\u0004.\u000A(u001F));
						try
						{
							while (\u0014\u0012\u0004.\u000A(ref enumerator3))
							{
								ExcelTextStyleInfo excelTextStyleInfo = \u0013\u0012\u0004.\u000A(ref enumerator3);
								ExcelTextStyleInfo excelTextStyleInfo2;
								if (!flag3)
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
									excelTextStyleInfo2 = excelTextStyleInfo;
								}
								else
								{
									excelTextStyleInfo2 = \u0015\u001A\u001D.\u000A(\u0016\u001D\u0004.\u0007(excelTextStyleInfo), \u0001\u000B\u0004.\u000A(\u0005\u001D\u0004.\u0007(excelTextStyleInfo), bwOption), \u001B\u0006\u0004.\u0007(excelTextStyleInfo), \u0018\u001D\u0004.\u0007(excelTextStyleInfo), \u0019\u001D\u0004.\u0007(excelTextStyleInfo), \u001D\u001D\u0004.\u0007(excelTextStyleInfo));
								}
								ExcelTextStyleInfo u000A2 = excelTextStyleInfo2;
								\u0019\u000F\u0004.\u000A(this.\u001D, u000A2);
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
							enumerator3.Dispose();
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

		// Token: 0x060008F4 RID: 2292 RVA: 0x0003DC2C File Offset: 0x0003BE2C
		public int CountMissing(IEnumerable<SelectedExcel> excels)
		{
			if (excels == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelStylesAggregator.CountMissing(IEnumerable<SelectedExcel>)).MethodHandle;
				}
				return 0;
			}
			int num = 0;
			IEnumerator<SelectedExcel> enumerator = \u001E\u000F\u0004.\u000A(excels);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					SelectedExcel u001F = \u0011\u000F\u0004.\u000A(enumerator);
					if (ExcelStylesAggregator.\u0005(u001F))
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
						string text;
						if ((text = \u0011\u0020\u001D.\u0007(u001F)) == null)
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
							text = string.Empty;
						}
						string u001F2 = text;
						if (!\u001A\u0006\u0007.\u000A(u001F2))
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
							if (\u0010\u0002\u001D.\u000A(u001F2))
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
								\u001D\u0005 u000A = \u001D\u0005.\u0005(u001F);
								if (!\u0003\u000F\u0004.\u000A(this.\u001F, u000A))
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
									num++;
								}
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
			return num;
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x0003DD2C File Offset: 0x0003BF2C
		public void Clear()
		{
			\u000B\u0003\u0004.\u000A(this.\u001F);
			\u0016\u0003\u0004.\u000A(this.\u000A);
			\u0005\u0003\u0004.\u000A(this.\u0007);
			\u0018\u0003\u0004.\u000A(this.\u001D);
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x0003DD68 File Offset: 0x0003BF68
		private static bool \u0005(SelectedExcel \u001F)
		{
			if (\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelStylesAggregator.\u0005(SelectedExcel)).MethodHandle;
				}
				EnumInfo enumInfo = \u0002\u0003\u0004.\u0007(\u001F);
				bool flag;
				if (enumInfo == null)
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
					flag = false;
				}
				else
				{
					flag = (\u000D\u001B\u001D.\u001D(enumInfo) == 0);
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
					EnumInfo enumInfo2 = \u0015\u0016\u0004.\u0007(\u001F);
					bool flag2;
					if (enumInfo2 == null)
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
						flag2 = false;
					}
					else
					{
						flag2 = (\u000D\u001B\u001D.\u001D(enumInfo2) == 0);
					}
					if (flag2)
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
						return \u0001\u0016\u0004.\u0007(\u001F) != UpdateStates.ToTrash;
					}
				}
			}
			return false;
		}

		// Token: 0x04000363 RID: 867
		private readonly Dictionary<\u001D\u0005, \u0007\u0005> \u001F = new Dictionary<\u001D\u0005, \u0007\u0005>();

		// Token: 0x04000364 RID: 868
		private readonly Dictionary<SelectedExcel, \u001D\u0005> \u000A = new Dictionary<SelectedExcel, \u001D\u0005>();

		// Token: 0x04000365 RID: 869
		private readonly HashSet<ExcelLineStyleInfo> \u0007 = new HashSet<ExcelLineStyleInfo>();

		// Token: 0x04000366 RID: 870
		private readonly HashSet<ExcelTextStyleInfo> \u001D = new HashSet<ExcelTextStyleInfo>();

		// Token: 0x04000367 RID: 871
		private BlackAndWhiteTextLinesOption \u0004;
	}
}
