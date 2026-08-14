using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.TableGen.TGRevitHelper;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.Dto;

namespace A
{
	// Token: 0x0200018B RID: 395
	internal static class \u0005\u0002
	{
		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x06000E8D RID: 3725 RVA: 0x0005C588 File Offset: 0x0005A788
		// (set) Token: 0x06000E8E RID: 3726 RVA: 0x0005C59C File Offset: 0x0005A79C
		internal static bool ForceUpdateRelative { get; set; }

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x06000E8F RID: 3727 RVA: 0x0005C5B0 File Offset: 0x0005A7B0
		// (set) Token: 0x06000E90 RID: 3728 RVA: 0x0005C5C4 File Offset: 0x0005A7C4
		internal static bool SaveDataInElement { get; set; }

		// Token: 0x06000E91 RID: 3729 RVA: 0x0005C5D8 File Offset: 0x0005A7D8
		internal static void \u0007(Document \u001F, List<DiRoots.One.TGDatabaseLayer.SelectedExcel> \u000A)
		{
			if (\u000C\u001B\u0004.\u000A(\u000A) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0005\u0002.\u0007(Document, List<DiRoots.One.TGDatabaseLayer.SelectedExcel>)).MethodHandle;
				}
				Transaction transaction = \u0013\u0001\u000A.\u000A(\u001F);
				try
				{
					\u0017\u0001\u000A.\u000A(transaction, "TableGen update autosync/relative path");
					\u0005\u0002.\u001D(\u001F, \u000A);
					\u001B\u0001\u000A.\u000A(transaction);
				}
				finally
				{
					if (transaction != null)
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
						\u001F\u0017\u000A.\u000A(transaction);
					}
				}
			}
			\u0011\u0019\u0019.\u000A(false);
		}

		// Token: 0x06000E92 RID: 3730 RVA: 0x0005C658 File Offset: 0x0005A858
		internal static void \u001D(Document \u001F, List<DiRoots.One.TGDatabaseLayer.SelectedExcel> \u000A)
		{
			if (\u000C\u001B\u0004.\u000A(\u000A) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0005\u0002.\u001D(Document, List<DiRoots.One.TGDatabaseLayer.SelectedExcel>)).MethodHandle;
				}
				if (\u001A\u0006\u0007.\u000A(\u0005\u001A\u000A.\u0007(\u001F)))
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
				string text = \u0019\u000E\u0004.\u000A(\u0005\u001A\u000A.\u0007(\u001F));
				bool flag = \u000F\u0005.\u0006(\u0005\u001A\u000A.\u0007(\u001F));
				List<DiRoots.One.TGDatabaseLayer.SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(\u000A);
				try
				{
					while (\u0001\u0005\u0004.\u000A(ref enumerator))
					{
						DiRoots.One.TGDatabaseLayer.SelectedExcel selectedExcel = \u001F\u0016\u0004.\u000A(ref enumerator);
						if (flag)
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
							string u001F;
							if ((u001F = \u0011\u0020\u001D.\u0007(selectedExcel)) == null)
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
								u001F = \u000F\u0011\u0004.\u000A(\u001D\u0011\u0004.\u001D(selectedExcel));
							}
							string text2 = \u000F\u0005.\u0002(u001F, \u0017\u0008\u0004.\u001D(selectedExcel), \u0007\u0008\u0019.\u000A());
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
								\u000C\u0011\u0004.\u001D(selectedExcel, text2);
								\u001E\u0008\u0004.\u001D(selectedExcel, \u0020\u0008\u0004.\u001D(selectedExcel, \u0011\u0020\u001D.\u0007(selectedExcel), text));
								\u0015\u0011\u0004.\u001D(selectedExcel);
								\u0005\u0002.\u0004(\u001F, selectedExcel);
							}
						}
						else if (\u0007\u0008\u0019.\u000A())
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
							\u001E\u0008\u0004.\u001D(selectedExcel, FilePathHelper.\u0004(\u0011\u0020\u001D.\u0007(selectedExcel), text));
							\u0015\u0011\u0004.\u001D(selectedExcel);
							\u0005\u0002.\u0004(\u001F, selectedExcel);
						}
						else if (\u0013\u0008\u0004.\u001D(selectedExcel))
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
							if (!\u001A\u0006\u0007.\u000A(\u0017\u0008\u0004.\u001D(selectedExcel)))
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
								string text3 = FilePathHelper.\u0019(\u0017\u0008\u0004.\u001D(selectedExcel), text);
								if (\u0010\u0002\u001D.\u000A(text3))
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
									\u000C\u0011\u0004.\u001D(selectedExcel, text3);
									\u001E\u0008\u0004.\u001D(selectedExcel, FilePathHelper.\u0004(\u0011\u0020\u001D.\u0007(selectedExcel), text));
									\u0015\u0011\u0004.\u001D(selectedExcel);
									\u0005\u0002.\u0004(\u001F, selectedExcel);
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
					((IDisposable)enumerator).Dispose();
				}
			}
			\u0011\u0019\u0019.\u000A(false);
		}

		// Token: 0x06000E93 RID: 3731 RVA: 0x0005C878 File Offset: 0x0005AA78
		private static void \u0004(Document \u001F, DiRoots.One.TGDatabaseLayer.SelectedExcel \u000A)
		{
			if (\u001D\u0008\u0019.\u000A())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0005\u0002.\u0004(Document, DiRoots.One.TGDatabaseLayer.SelectedExcel)).MethodHandle;
				}
				ElementId u000A = \u001E\u0001\u000A.\u000A(\u0009\u0005\u0004.\u000A(\u000A));
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
					DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel selectedExcel = SchemaUtil.\u0007(u001F);
					if (selectedExcel != null)
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
						\u001C\u0011\u0004.\u000A(selectedExcel, \u0011\u0020\u001D.\u0007(\u000A));
						\u000C\u0017\u0004.\u000A(selectedExcel, \u000E\u0016\u0004.\u000A(\u000A));
						\u0013\u0017\u0004.\u000A(selectedExcel, \u0013\u0008\u0004.\u001D(\u000A));
						\u0019\u0014\u0004.\u000A(selectedExcel, \u0017\u0008\u0004.\u001D(\u000A));
						SchemaUtil.\u000A(u001F, selectedExcel);
						return;
					}
					SchemaUtil.\u000A(u001F, \u000A);
				}
			}
		}

		// Token: 0x040005BD RID: 1469
		[CompilerGenerated]
		private static bool \u001F;

		// Token: 0x040005BE RID: 1470
		[CompilerGenerated]
		private static bool \u000A;
	}
}
