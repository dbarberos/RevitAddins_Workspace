using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.SheetGen;
using DiRoots.One.SheetGen.Services;
using Microsoft.Win32;

namespace A
{
	// Token: 0x02000316 RID: 790
	internal class \u000B\u0020 : IExcelExportImportHandler
	{
		// Token: 0x06002233 RID: 8755 RVA: 0x000D231C File Offset: 0x000D051C
		public \u000B\u0020(Document \u001F, IPlaceholderRepository \u000A, IPlaceholderSheetParameterService \u0007, IDialogsService \u001D, IReportsWindowService \u0004)
		{
			this.\u001F = \u001F;
			this.\u000A = \u000A;
			this.\u001D = \u001D;
			this.\u0007 = \u0007;
			this.\u0004 = \u0004;
		}

		// Token: 0x06002234 RID: 8756 RVA: 0x000D2354 File Offset: 0x000D0554
		public void ExportToExcel<TSheet>(IList<TSheet> sheets, string fileName) where TSheet : ISheetModel
		{
			SaveFileDialog saveFileDialog = \u0001\u0016\u000B.\u000A();
			\u0015\u0016\u000B.\u000A(saveFileDialog, fileName);
			string u000A;
			if ((u000A = \u000D\u001D\u000B.\u000A(\u0019\u001D\u000B.\u0007(\u001E\u0020\u0016.\u000A()))) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000B\u0020.ExportToExcel(IList<TSheet>, string)).MethodHandle;
				}
				u000A = \u001C\u001D\u000B.\u000A(\u000D\u0020\u0016.\u000A());
			}
			\u0003\u001D\u000B.\u000A(saveFileDialog, u000A);
			\u000C\u0016\u000B.\u000A(saveFileDialog, true);
			\u0012\u0012\u0005.\u000A(saveFileDialog, "Macro Enabled Excel Files (.xlsm)|*.xlsm");
			SaveFileDialog u001F = saveFileDialog;
			bool? flag = \u000F\u0012\u0005.\u000A(u001F);
			if (!\u0012\u0015\u000A.\u000A(ref flag))
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
			try
			{
				string text = \u0006\u0012\u0005.\u000A(u001F);
				\u001E\u0016\u000B.\u000A(\u0019\u001D\u000B.\u0007(\u001E\u0020\u0016.\u000A()), \u0019\u000E\u0004.\u000A(text));
				\u0001\u0014.\u001D<TSheet>(sheets, text);
				\u0012\u0010\u000B.\u000A(this.\u001D, \u0003\u0010\u000B.\u000A(), text);
			}
			catch (Exception u001F2)
			{
				\u0005\u001F\u000B.\u000A(this.\u001D, \u0003\u001A\u000A.\u000A(u001F2));
			}
		}

		// Token: 0x06002235 RID: 8757 RVA: 0x000D2450 File Offset: 0x000D0650
		public bool ImportSheetsFromExcel(string filePath, Action populateParams)
		{
			if (!\u0010\u0002\u001D.\u000A(filePath))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000B\u0020.ImportSheetsFromExcel(string, Action)).MethodHandle;
				}
				return false;
			}
			List<string> list = \u0014\u000D\u0007.\u000A();
			\u0012\u0017 u000A = new \u0012\u0017(this.\u0005());
			Dictionary<ParameterModel, List<string>> u000A2;
			List<BR> list2;
			bool flag = \u0010\u0013.\u0007(filePath, u000A, populateParams, ref list, out u000A2, out list2);
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
				this.\u0018<SheetInfo>(\u0014\u0007\u0016.\u000A(), u000A2);
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
					if (Enumerable.Any<BR>(list2))
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
						IReportsWindowService u = this.\u0004;
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
							return flag;
						}
						u.ShowWindow<BR>(list2);
					}
				}
			}
			return flag;
		}

		// Token: 0x06002236 RID: 8758 RVA: 0x000D24FC File Offset: 0x000D06FC
		public bool ImportSheetsFromExcel(Action populateParams)
		{
			string u000A;
			if (!this.\u0019(out u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000B\u0020.ImportSheetsFromExcel(Action)).MethodHandle;
				}
				return false;
			}
			return \u001C\u0010\u000B.\u000A(this, u000A, populateParams);
		}

		// Token: 0x06002237 RID: 8759 RVA: 0x000D2534 File Offset: 0x000D0734
		public bool ImportPlaceholdersFromExcel(Action populateParams)
		{
			string u001F;
			if (!this.\u0019(out u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000B\u0020.ImportPlaceholdersFromExcel(Action)).MethodHandle;
				}
				return false;
			}
			\u0003\u0017 u000A = new \u0003\u0017(this.\u0005());
			List<BR> list;
			bool flag = \u0010\u0013.\u001D(u001F, u000A, \u0008\u0009\u0016.\u000A(this.\u000A), populateParams, this.\u0007, out list);
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
					if (Enumerable.Any<BR>(list))
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
						IReportsWindowService u = this.\u0004;
						if (u == null)
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
							return flag;
						}
						u.ShowWindow<BR>(list);
					}
				}
			}
			return flag;
		}

		// Token: 0x06002238 RID: 8760 RVA: 0x000D25D8 File Offset: 0x000D07D8
		private unsafe bool \u0019(out string \u001F)
		{
			\u001F = null;
			OpenFileDialog openFileDialog = \u0003\u0012\u0005.\u000A();
			\u0012\u0012\u0005.\u000A(openFileDialog, "Macro Enabled Excel Files (.xlsm)|*.xlsm");
			string u000A;
			if ((u000A = \u000D\u001D\u000B.\u000A(\u0019\u001D\u000B.\u0007(\u001E\u0020\u0016.\u000A()))) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000B\u0020.\u0019(string*)).MethodHandle;
				}
				u000A = \u001C\u001D\u000B.\u000A(\u000D\u0020\u0016.\u000A());
			}
			\u0003\u001D\u000B.\u000A(openFileDialog, u000A);
			OpenFileDialog u001F = openFileDialog;
			bool? flag = \u000F\u0012\u0005.\u000A(u001F);
			if (!\u0012\u0015\u000A.\u000A(ref flag))
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
				return false;
			}
			\u001F = \u0006\u0012\u0005.\u000A(u001F);
			\u001E\u0016\u000B.\u000A(\u0019\u001D\u000B.\u0007(\u001E\u0020\u0016.\u000A()), \u0019\u000E\u0004.\u000A(\u001F));
			return true;
		}

		// Token: 0x06002239 RID: 8761 RVA: 0x000D2684 File Offset: 0x000D0884
		private void \u0018<\u001F>(IList<\u001F> \u001F, Dictionary<ParameterModel, List<string>> \u000A) where \u001F : ISheetModel
		{
			if (\u000A != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000B\u0020.\u0018(IList<\u001F>, Dictionary<ParameterModel, List<string>>)).MethodHandle;
				}
				if (\u001A\u0012\u000B.\u000A(\u000A) != 0)
				{
					Func<KeyValuePair<ParameterModel, List<string>>, SelectionParameter> func;
					if ((func = \u000B\u0020.<>c__11<\u001F>.\u000A) == null)
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
						func = (\u000B\u0020.<>c__11<\u001F>.\u000A = new Func<KeyValuePair<ParameterModel, List<string>>, SelectionParameter>(\u000B\u0020.<>c__11<\u001F>.\u001F.\u0005));
					}
					IEnumerable<IGrouping<SelectionParameter, KeyValuePair<ParameterModel, List<string>>>> enumerable = Enumerable.GroupBy<KeyValuePair<ParameterModel, List<string>>, SelectionParameter>(\u000A, func);
					Func<IGrouping<SelectionParameter, KeyValuePair<ParameterModel, List<string>>>, SelectionParameter> func2;
					if ((func2 = \u000B\u0020.<>c__11<\u001F>.\u0007) == null)
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
						func2 = (\u000B\u0020.<>c__11<\u001F>.\u0007 = new Func<IGrouping<SelectionParameter, KeyValuePair<ParameterModel, List<string>>>, SelectionParameter>(\u000B\u0020.<>c__11<\u001F>.\u001F.\u0016));
					}
					Func<IGrouping<SelectionParameter, KeyValuePair<ParameterModel, List<string>>>, Dictionary<ParameterModel, List<string>>> func3;
					if ((func3 = \u000B\u0020.<>c__11<\u001F>.\u0019) == null)
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
						func3 = (\u000B\u0020.<>c__11<\u001F>.\u0019 = new Func<IGrouping<SelectionParameter, KeyValuePair<ParameterModel, List<string>>>, Dictionary<ParameterModel, List<string>>>(\u000B\u0020.<>c__11<\u001F>.\u001F.\u000B));
					}
					Dictionary<SelectionParameter, Dictionary<ParameterModel, List<string>>>.Enumerator enumerator = \u000A\u0003\u000B.\u000A(Enumerable.ToDictionary<IGrouping<SelectionParameter, KeyValuePair<ParameterModel, List<string>>>, SelectionParameter, Dictionary<ParameterModel, List<string>>>(enumerable, func2, func3));
					try
					{
						while (\u000C\u0012\u000B.\u000A(ref enumerator))
						{
							KeyValuePair<SelectionParameter, Dictionary<ParameterModel, List<string>>> keyValuePair = \u001F\u0003\u000B.\u000A(ref enumerator);
							\u000B\u0020.\u0016\u0020<\u001F> u0016_u = new \u000B\u0020.\u0016\u0020<\u001F>();
							IEnumerable<List<string>> enumerable2 = \u0001\u0012\u000B.\u000A(\u0009\u0012\u000B.\u000A(ref keyValuePair));
							Func<List<string>, IEnumerable<string>> func4;
							if ((func4 = \u000B\u0020.<>c__11<\u001F>.\u0018) == null)
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
								func4 = (\u000B\u0020.<>c__11<\u001F>.\u0018 = new Func<List<string>, IEnumerable<string>>(\u000B\u0020.<>c__11<\u001F>.\u001F.\u000F));
							}
							IEnumerable<string> enumerable3 = Enumerable.SelectMany<List<string>, string>(enumerable2, func4);
							u0016_u.\u001F = \u0013\u0013\u0007.\u000A(this.\u001F).\u001F(\u0015\u0012\u000B.\u000A(ref keyValuePair));
							string text = Enumerable.FirstOrDefault<string>(enumerable3, new Func<string, bool>(u0016_u.\u000A));
							if (text != null)
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
								IEnumerator<\u001F> enumerator2 = \u001F.GetEnumerator();
								try
								{
									while (\u000A\u0017\u000A.\u000A(enumerator2))
									{
										\u001F u001F = enumerator2.Current;
										if (u001F != null)
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
											u001F.\u0004(u001F.\u001D(\u0015\u0012\u000B.\u000A(ref keyValuePair), \u000A\u0003\u0016.\u001D(\u0015\u0012\u000B.\u000A(ref keyValuePair)) == SelectionParameterType.ProjectInformation), text);
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
					return;
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
		}

		// Token: 0x0600223A RID: 8762 RVA: 0x000D28DC File Offset: 0x000D0ADC
		private IList<ISheetModel> \u0005()
		{
			return Enumerable.ToList<ISheetModel>(Enumerable.Concat<ISheetModel>(Enumerable.Cast<ISheetModel>(\u0014\u0007\u0016.\u000A()), \u0008\u0009\u0016.\u000A(this.\u000A)));
		}

		// Token: 0x04000DBB RID: 3515
		private readonly Document \u001F;

		// Token: 0x04000DBC RID: 3516
		private readonly IPlaceholderRepository \u000A;

		// Token: 0x04000DBD RID: 3517
		private readonly IPlaceholderSheetParameterService \u0007;

		// Token: 0x04000DBE RID: 3518
		private readonly IDialogsService \u001D;

		// Token: 0x04000DBF RID: 3519
		private readonly IReportsWindowService \u0004;

		// Token: 0x020009FE RID: 2558
		[CompilerGenerated]
		private sealed class \u0016\u0020<\u001F> where \u001F : ISheetModel
		{
			// Token: 0x060054E5 RID: 21733 RVA: 0x001F035C File Offset: 0x001EE55C
			internal bool \u000A(string \u001F)
			{
				return \u001D\u0017\u000A.\u000A(\u001F, this.\u001F);
			}

			// Token: 0x04002646 RID: 9798
			public string \u001F;
		}
	}
}
