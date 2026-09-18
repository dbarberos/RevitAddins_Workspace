using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using DiRoots.One.PanelLink.Models;

namespace A
{
	// Token: 0x0200018E RID: 398
	internal static class \u000E\u0002
	{
		// Token: 0x06000EC1 RID: 3777 RVA: 0x0005DE40 File Offset: 0x0005C040
		internal static void \u001F(int \u001F, int \u000A, SectionType \u0007, TableSectionData \u001D, List<PanelParameter> \u0004, IList<Parameter> \u0019, PanelParameters \u0018)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Core\\Base\\PanelScheduleExport.cs", "GetData");
			if (\u000A == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u0002.\u001F(int, int, SectionType, TableSectionData, List<PanelParameter>, IList<Parameter>, PanelParameters)).MethodHandle;
				}
				return;
			}
			if (\u0007 != null)
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
				if (\u0007 != 2)
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
					if (\u0007 == 3)
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
					}
					else
					{
						if (\u0007 == 1)
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
							\u000E\u0002.\u0007(\u001F, \u000A, \u001D, \u0019, \u0012\u001B\u0019.\u0007(\u0018));
							goto IL_8C;
						}
						goto IL_8C;
					}
				}
			}
			\u000E\u0002.\u000A(\u001F, \u000A, \u001D, \u0004, \u0003\u001B\u0019.\u0007(\u0018));
			IL_8C:
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Core\\Base\\PanelScheduleExport.cs", "GetData");
		}

		// Token: 0x06000EC2 RID: 3778 RVA: 0x0005DEF0 File Offset: 0x0005C0F0
		private static void \u000A(int \u001F, int \u000A, TableSectionData \u0007, List<PanelParameter> \u001D, List<PanelParameter> \u0004)
		{
			for (int i = 0; i < \u000A; i++)
			{
				for (int j = 0; j < \u001F; j++)
				{
					try
					{
						\u000E\u0002.\u000D\u0002 u000D_u = new \u000E\u0002.\u000D\u0002();
						u000D_u.\u001F = \u0020\u001B\u0019.\u000A(\u0007, i, j);
						List<PanelParameter>.Enumerator enumerator = \u001E\u001B\u0019.\u000A(\u001D);
						try
						{
							while (\u001C\u001B\u0019.\u000A(ref enumerator))
							{
								PanelParameter panelParameter = \u0011\u001B\u0019.\u000A(ref enumerator);
								if (\u0011\u0016\u001D.\u000A(u000D_u.\u001F, \u0014\u001F\u001D.\u0007(\u001B\u001B\u0019.\u000A(panelParameter))))
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
										RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u0002.\u000A(int, int, TableSectionData, List<PanelParameter>, List<PanelParameter>)).MethodHandle;
									}
									Func<PanelParameter, bool> func;
									if ((func = u000D_u.\u000A) == null)
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
										func = (u000D_u.\u000A = new Func<PanelParameter, bool>(u000D_u.\u0007));
									}
									if (!Enumerable.Any<PanelParameter>(\u0004, func))
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
										InternalDefinition u001F = \u0014\u0005\u000E.\u001F(\u0020\u001F\u001D.\u0007(\u001B\u001B\u0019.\u000A(panelParameter)));
										\u0008\u001B\u0019.\u0007(panelParameter, \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001B\u001B\u0019.\u000A(panelParameter))));
										\u000E\u001B\u0019.\u0007(panelParameter, \u001E\u001F\u001D.\u000A(u001F));
										\u0010\u001B\u0019.\u000A(panelParameter);
										\u000D\u001B\u0019.\u000A(\u0004, panelParameter);
										goto IL_134;
									}
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
							((IDisposable)enumerator).Dispose();
						}
						IL_134:;
					}
					catch (Exception u000A)
					{
						\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Core\\Base\\PanelScheduleExport.cs", "GetEquipmentParameters");
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

		// Token: 0x06000EC3 RID: 3779 RVA: 0x0005E0B0 File Offset: 0x0005C2B0
		private static void \u0007(int \u001F, int \u000A, TableSectionData \u0007, IList<Parameter> \u001D, List<PanelParameter> \u0004)
		{
			for (int i = 0; i < \u000A; i++)
			{
				for (int j = 0; j < \u001F; j++)
				{
					try
					{
						ElementId u001F = \u0020\u001B\u0019.\u000A(\u0007, i, j);
						IEnumerator<Parameter> enumerator = \u0015\u001B\u0019.\u000A(\u001D);
						try
						{
							while (\u000A\u0017\u000A.\u000A(enumerator))
							{
								\u000E\u0002.\u0010\u0002 u0010_u = new \u000E\u0002.\u0010\u0002();
								u0010_u.\u001F = \u000C\u001B\u0019.\u000A(enumerator);
								InternalDefinition u001F2 = \u0014\u0005\u000E.\u001F(\u0020\u001F\u001D.\u0007(u0010_u.\u001F));
								if (\u0011\u0016\u001D.\u000A(u001F, \u0014\u001F\u001D.\u0007(u0010_u.\u001F)))
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
										RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u0002.\u0007(int, int, TableSectionData, IList<Parameter>, List<PanelParameter>)).MethodHandle;
									}
									if (!Enumerable.Any<PanelParameter>(\u0004, new Func<PanelParameter, bool>(u0010_u.\u000A)))
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
										PanelParameter panelParameter = \u001A\u001B\u0019.\u000A();
										\u0013\u001B\u0019.\u0007(panelParameter, \u0010\u0014\u0007.\u000A(u0010_u.\u001F));
										\u000E\u001B\u0019.\u0007(panelParameter, \u001E\u001F\u001D.\u000A(u001F2));
										\u0014\u001B\u0019.\u000A(panelParameter, u0010_u.\u001F);
										\u0017\u001B\u0019.\u0007(panelParameter, false);
										\u0008\u001B\u0019.\u0007(panelParameter, \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(u0010_u.\u001F)));
										\u0010\u001B\u0019.\u000A(panelParameter);
										\u000D\u001B\u0019.\u000A(\u0004, panelParameter);
										goto IL_144;
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
							if (enumerator != null)
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
								\u001F\u0017\u000A.\u000A(enumerator);
							}
						}
						IL_144:;
					}
					catch (Exception u000A)
					{
						\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Core\\Base\\PanelScheduleExport.cs", "GetCircuitParameters");
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

		// Token: 0x06000EC4 RID: 3780 RVA: 0x0005E280 File Offset: 0x0005C480
		private static void \u001D(PanelScheduleTemplate \u001F, SectionType \u000A, ref int \u0007, ref int \u001D)
		{
			TableSectionData u001F = \u0001\u001B\u0019.\u000A(\u001F, \u000A);
			\u0007 = \u000F\u0004\u0004.\u000A(u001F);
			\u001D = \u0002\u0004\u0004.\u000A(u001F);
		}

		// Token: 0x06000EC5 RID: 3781 RVA: 0x0005E2AC File Offset: 0x0005C4AC
		internal static List<PanelParameters> \u0004(Document \u001F, long \u000A)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Core\\Base\\PanelScheduleExport.cs", "GetAllParameters");
			List<PanelParameters> list = \u0006\u0011\u0019.\u000A();
			List<ElementId> u001F = \u001C\u0013\u000A.\u000A();
			object u001F2 = \u0014\u0002.\u001F(\u001F, \u000A);
			List<PanelParameter> u = \u0020\u0002.\u001F(\u001F);
			IList<Parameter> u2 = \u0020\u0002.\u000A(\u001F);
			List<Panel>.Enumerator enumerator = \u0002\u0011\u0019.\u000A(u001F2);
			try
			{
				while (\u0018\u0011\u0019.\u000A(ref enumerator))
				{
					PanelScheduleView u001F3 = \u0020\u0005\u000E.\u001F(\u0016\u0011\u0019.\u000A(\u000B\u0011\u0019.\u000A(ref enumerator)));
					if (!\u0014\u000E\u0007.\u000A(u001F, \u0005\u0011\u0019.\u000A(u001F3)))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u0002.\u0004(Document, long)).MethodHandle;
						}
						\u0003\u0010\u0007.\u000A(u001F, \u0005\u0011\u0019.\u000A(u001F3));
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
			List<ElementId>.Enumerator enumerator2 = \u0015\u0005\u0004.\u000A(u001F);
			try
			{
				while (\u001A\u0005\u0004.\u000A(ref enumerator2))
				{
					ElementId u000A = \u000C\u0005\u0004.\u000A(ref enumerator2);
					PanelParameters panelParameters = \u0019\u0011\u0019.\u000A();
					\u0004\u0011\u0019.\u000A(panelParameters, u000A);
					\u001D\u0011\u0019.\u000A(panelParameters, \u0007\u0011\u0019.\u000A());
					\u000A\u0011\u0019.\u000A(panelParameters, \u0007\u0011\u0019.\u000A());
					PanelScheduleTemplate u001F4 = \u0017\u0005\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u001F, u000A));
					TableData u001F5 = \u001F\u0011\u0019.\u000A(u001F4);
					SectionType sectionType = 1;
					SectionType sectionType2 = 0;
					TableSectionData tableSectionData = \u0003\u0004\u0004.\u000A(u001F5, sectionType2);
					int u000A2 = \u000F\u0004\u0004.\u000A(tableSectionData);
					int u001F6 = \u0002\u0004\u0004.\u000A(tableSectionData);
					\u000E\u0002.\u001D(u001F4, sectionType2, ref u000A2, ref u001F6);
					\u000E\u0002.\u001F(u001F6, u000A2, sectionType2, tableSectionData, u, u2, panelParameters);
					tableSectionData = \u0003\u0004\u0004.\u000A(u001F5, sectionType);
					\u000E\u0002.\u001D(u001F4, sectionType, ref u000A2, ref u001F6);
					\u000E\u0002.\u001F(u001F6, u000A2, sectionType, tableSectionData, u, u2, panelParameters);
					sectionType2 = 2;
					tableSectionData = \u0003\u0004\u0004.\u000A(u001F5, sectionType2);
					\u000E\u0002.\u001D(u001F4, sectionType2, ref u000A2, ref u001F6);
					\u000E\u0002.\u001F(u001F6, u000A2, sectionType2, tableSectionData, u, u2, panelParameters);
					sectionType2 = 3;
					tableSectionData = \u0003\u0004\u0004.\u000A(u001F5, sectionType2);
					\u000E\u0002.\u001D(u001F4, sectionType2, ref u000A2, ref u001F6);
					\u000E\u0002.\u001F(u001F6, u000A2, sectionType2, tableSectionData, u, u2, panelParameters);
					\u0009\u001B\u0019.\u000A(list, panelParameters);
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
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Core\\Base\\PanelScheduleExport.cs", "GetAllParameters");
			return list;
		}

		// Token: 0x02000860 RID: 2144
		[CompilerGenerated]
		private sealed class \u000D\u0002
		{
			// Token: 0x06004EC6 RID: 20166 RVA: 0x001E1688 File Offset: 0x001DF888
			internal bool \u0007(PanelParameter \u001F)
			{
				return \u0017\u000B\u0018.\u0007(\u001F) == \u000B\u001E\u000A.\u000A(this.\u001F);
			}

			// Token: 0x04002147 RID: 8519
			public ElementId \u001F;

			// Token: 0x04002148 RID: 8520
			public Func<PanelParameter, bool> \u000A;
		}

		// Token: 0x02000861 RID: 2145
		[CompilerGenerated]
		private sealed class \u0010\u0002
		{
			// Token: 0x06004EC8 RID: 20168 RVA: 0x001E16C0 File Offset: 0x001DF8C0
			internal bool \u000A(PanelParameter \u001F)
			{
				return \u0017\u000B\u0018.\u0007(\u001F) == \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(this.\u001F));
			}

			// Token: 0x04002149 RID: 8521
			public Parameter \u001F;
		}
	}
}
