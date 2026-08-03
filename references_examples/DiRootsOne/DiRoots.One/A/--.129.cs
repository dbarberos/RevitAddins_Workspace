using System;
using Syncfusion.UI.Xaml.CellGrid;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.XlsIO;

namespace A
{
	// Token: 0x0200023A RID: 570
	internal class \u001C\u001C : FillSeriesController
	{
		// Token: 0x06001699 RID: 5785 RVA: 0x00093C54 File Offset: 0x00091E54
		public \u001C\u001C(SpreadsheetGrid \u001F) : base(\u001F)
		{
			this.\u001F = \u001F;
		}

		// Token: 0x0600169A RID: 5786 RVA: 0x00093C70 File Offset: 0x00091E70
		protected override void FillSeries(GridRangeInfo oldRange, GridRangeInfo newRange)
		{
			try
			{
				\u0013\u0012\u0005.\u000A(this, oldRange, newRange);
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Models\\Excels\\SheetLinkFillSeriesController.cs", "FillSeries");
			}
		}

		// Token: 0x0600169B RID: 5787 RVA: 0x00093CB4 File Offset: 0x00091EB4
		protected override void CopyCells(GridRangeInfo oldRange, GridRangeInfo newRange)
		{
			this.\u000A(oldRange, newRange);
		}

		// Token: 0x0600169C RID: 5788 RVA: 0x00093CCC File Offset: 0x00091ECC
		private void \u000A(GridRangeInfo \u001F, GridRangeInfo \u000A)
		{
			try
			{
				string u000A = \u0019\u0016\u0005.\u000A(\u001F, this.\u001F);
				string u000A2 = \u0019\u0016\u0005.\u000A(\u000A, this.\u001F);
				IRange u001F = \u0009\u0006\u0004.\u000A(\u000C\u0012\u0005.\u000A(this), u000A);
				IRange u001F2 = \u0009\u0006\u0004.\u000A(\u000C\u0012\u0005.\u000A(this), u000A2);
				int num = \u000B\u0013\u001D.\u000A(u001F) - \u0009\u0020\u001D.\u000A(u001F) + 1;
				int num2 = \u0016\u0013\u001D.\u000A(u001F) - \u0001\u0020\u001D.\u000A(u001F) + 1;
				IRange[] array = \u0017\u0014\u001D.\u000A(u001F2);
				for (int i = 0; i < (int)\u0018\u0004\u000E.\u001F(array); i++)
				{
					IRange range = array[i];
					try
					{
						bool flag;
						if (range == null)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u001C.\u000A(GridRangeInfo, GridRangeInfo)).MethodHandle;
							}
							flag = (null != null);
						}
						else
						{
							flag = (\u001F\u0014\u001D.\u000A(range) != null);
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
							if (\u001D\u0016\u0005.\u000A(\u001F\u0014\u001D.\u000A(range)))
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
							}
							else
							{
								int u000A3 = \u0009\u0020\u001D.\u000A(u001F) + (\u0009\u0020\u001D.\u000A(range) - \u0009\u0020\u001D.\u000A(u001F2)) % num;
								int u = \u0001\u0020\u001D.\u000A(u001F) + (\u0001\u0020\u001D.\u000A(range) - \u0001\u0020\u001D.\u000A(u001F2)) % num2;
								IRange range2 = \u000F\u000A\u0004.\u000A(\u000C\u0012\u0005.\u000A(this), u000A3, u);
								if (range2 == null)
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
									string text;
									if (\u001A\u0006\u0007.\u000A(\u0007\u000C\u001D.\u000A(range2)))
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
										object obj = \u001A\u0012\u0005.\u000A(range2);
										if (obj == null)
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
											text = \u000F\u0015\u0010.\u001F;
										}
										else
										{
											text = \u001A\u000C\u000A.\u000A(obj);
										}
									}
									else
									{
										text = \u0007\u000C\u001D.\u000A(range2);
									}
									string text2 = text;
									if (\u001A\u0006\u0007.\u000A(text2))
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
										\u0009\u001E\u0018.\u000A(range, text2);
									}
								}
							}
						}
					}
					catch (Exception u000A4)
					{
						\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A4, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Models\\Excels\\SheetLinkFillSeriesController.cs", "CopyValues");
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
				\u0007\u0016\u0005.\u000A(this.\u001F, \u000A, false);
			}
			catch (Exception u000A5)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A5, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Models\\Excels\\SheetLinkFillSeriesController.cs", "CopyValues");
			}
		}

		// Token: 0x040008F9 RID: 2297
		private readonly SpreadsheetGrid \u001F;
	}
}
