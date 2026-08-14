using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.RoomPro.Models;

namespace A
{
	// Token: 0x02000092 RID: 146
	internal static class \u0019\u0004
	{
		// Token: 0x0600064E RID: 1614 RVA: 0x00023464 File Offset: 0x00021664
		internal static SectionAndElevationUserSettings \u001F()
		{
			SectionAndElevationUserSettings sectionAndElevationUserSettings = \u0008\u001D\u001D.\u000A(new \u0013\u001D(\u000C\u001D.\u0006).\u0017());
			if (sectionAndElevationUserSettings == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0004.\u001F()).MethodHandle;
				}
				return \u0019\u0004.\u000B();
			}
			SectionAndElevationUserSettings sectionAndElevationUserSettings2 = \u0003\u001E\u0007.\u000A();
			\u0016\u001E\u0007.\u000A(sectionAndElevationUserSettings2, \u0019\u0004.\u0018(\u0019\u001E\u0007.\u000A(sectionAndElevationUserSettings)));
			\u0005\u001E\u0007.\u000A(sectionAndElevationUserSettings2, \u0019\u0004.\u0005(\u001D\u001E\u0007.\u000A(sectionAndElevationUserSettings)));
			\u0018\u001E\u0007.\u000A(sectionAndElevationUserSettings2, \u0019\u0004.\u0019(\u001F\u001E\u0007.\u000A(sectionAndElevationUserSettings)));
			return sectionAndElevationUserSettings2;
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x000234F0 File Offset: 0x000216F0
		internal static CalloutUserSettings \u000A()
		{
			CalloutUserSettings calloutUserSettings = \u001B\u001D\u001D.\u000A(new \u0013\u001D(\u000C\u001D.\u0006).\u0017());
			if (calloutUserSettings == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0004.\u000A()).MethodHandle;
				}
				return \u0019\u0004.\u0016();
			}
			CalloutUserSettings calloutUserSettings2 = \u001C\u000B\u0007.\u000A();
			\u001D\u000B\u0007.\u000A(calloutUserSettings2, \u0019\u0004.\u001D(\u001F\u000B\u0007.\u000A(calloutUserSettings)));
			\u0007\u000B\u0007.\u000A(calloutUserSettings2, \u0019\u0004.\u0004(\u0001\u0016\u0007.\u000A(calloutUserSettings)));
			\u000A\u000B\u0007.\u000A(calloutUserSettings2, \u0019\u0004.\u0019(\u001A\u0016\u0007.\u000A(calloutUserSettings)));
			return calloutUserSettings2;
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0002357C File Offset: 0x0002177C
		private static int \u0007<\u001F>(List<\u001F> \u001F, \u001F \u000A) where \u001F : ModelObject
		{
			\u0019\u0004.\u0007\u0004<\u001F> u0007_u = new \u0019\u0004.\u0007\u0004<\u001F>();
			u0007_u.\u001F = \u000A;
			if (u0007_u.\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0004.\u0007(List<\u001F>, \u001F)).MethodHandle;
				}
				if (Enumerable.Any<\u001F>(\u001F))
				{
					int num = \u001F.FindIndex(new Predicate<\u001F>(u0007_u.\u000A));
					if (num >= 0)
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
						if (num < \u001F.Count)
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
							return num;
						}
					}
					num = \u001F.FindIndex(new Predicate<\u001F>(u0007_u.\u0007));
					if (num >= 0)
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
						if (num < \u001F.Count)
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
							return num;
						}
					}
					return 0;
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
			return 0;
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x00023644 File Offset: 0x00021844
		private static CalloutViewSettings \u001D(CalloutViewSettings \u001F)
		{
			\u0013\u001D u0013_u001D = new \u0013\u001D(\u000C\u001D.\u0006);
			IEnumerable<ViewFamilyType> enumerable = u0013_u001D.\u000F(109);
			Func<ViewFamilyType, ModelViewType> func;
			if ((func = \u0019\u0004.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0004.\u001D(CalloutViewSettings)).MethodHandle;
				}
				func = (\u0019\u0004.<>c.\u000A = new Func<ViewFamilyType, ModelViewType>(\u0019\u0004.<>c.\u001F.\u001B));
			}
			List<ModelViewType> u001F = Enumerable.ToList<ModelViewType>(Enumerable.Select<ViewFamilyType, ModelViewType>(enumerable, func));
			int u000A = \u0019\u0004.\u0007<ModelViewType>(u001F, \u0011\u001D\u001D.\u000A(\u001F));
			IEnumerable<Phase> enumerable2 = u0013_u001D.\u0012();
			Func<Phase, ModelPhase> func2;
			if ((func2 = \u0019\u0004.<>c.\u0007) == null)
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
				func2 = (\u0019\u0004.<>c.\u0007 = new Func<Phase, ModelPhase>(\u0019\u0004.<>c.\u001F.\u0011));
			}
			List<ModelPhase> u001F2 = Enumerable.ToList<ModelPhase>(Enumerable.Select<Phase, ModelPhase>(enumerable2, func2));
			int u000A2 = \u0019\u0004.\u0007<ModelPhase>(u001F2, \u0018\u0013\u0007.\u000A(\u001F));
			List<ViewTemplate> u001F3 = Enumerable.ToList<ViewTemplate>(u0013_u001D.\u0010());
			int u000A3 = \u0019\u0004.\u0007<ViewTemplate>(u001F3, \u0005\u0013\u0007.\u000A(\u001F));
			CalloutViewSettings calloutViewSettings = \u0002\u0002\u0007.\u000A();
			\u0016\u0002\u0007.\u000A(calloutViewSettings, \u0019\u0006\u0007.\u000A(u001F, u000A));
			\u0018\u0002\u0007.\u000A(calloutViewSettings, \u001D\u0006\u0007.\u000A(\u001F));
			\u0004\u0002\u0007.\u000A(calloutViewSettings, \u000A\u0006\u0007.\u000A(\u001F));
			\u0007\u0002\u0007.\u000A(calloutViewSettings, \u0009\u0002\u0007.\u000A(u001F2, u000A2));
			\u001F\u0002\u0007.\u000A(calloutViewSettings, \u0015\u0002\u0007.\u000A(u001F3, u000A3));
			\u0001\u000B\u0007.\u000A(calloutViewSettings, \u001A\u0002\u0007.\u000A(\u001F));
			\u000C\u000B\u0007.\u000A(calloutViewSettings, \u0014\u0002\u0007.\u000A(\u001F));
			\u0013\u000B\u0007.\u000A(calloutViewSettings, \u0020\u0002\u0007.\u000A(\u001F));
			return calloutViewSettings;
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x000237AC File Offset: 0x000219AC
		private static NamingConfigurationSettings \u0004(NamingConfigurationSettings \u001F)
		{
			\u0013\u001D u0013_u001D = new \u0013\u001D(\u000C\u001D.\u0006);
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0004.\u0004(NamingConfigurationSettings)).MethodHandle;
				}
				\u001F = \u0016\u0016\u0007.\u000A();
			}
			List<NamingParameter> list = Enumerable.ToList<NamingParameter>(\u001C\u0016\u0007.\u0007(\u001F));
			List<NamingParameter> list2 = \u001E\u001D\u001D.\u000A();
			List<NamingParameter> list3 = \u000B\u000F\u0007.\u000A(Enumerable.ToList<NamingParameter>(u0013_u001D.\u0020()));
			IEnumerable<Parameter> enumerable = u0013_u001D.\u0014();
			Func<Parameter, NamingParameter> func;
			if ((func = \u0019\u0004.<>c.\u001D) == null)
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
				func = (\u0019\u0004.<>c.\u001D = new Func<Parameter, NamingParameter>(\u0019\u0004.<>c.\u001F.\u001E));
			}
			List<NamingParameter> u000A = \u000B\u000F\u0007.\u000A(Enumerable.Select<Parameter, NamingParameter>(enumerable, func));
			\u001E\u0006\u0007.\u000A(list3, u000A);
			if (Enumerable.Any<NamingParameter>(list))
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
				List<NamingParameter>.Enumerator enumerator = \u0003\u0016\u0007.\u000A(list);
				try
				{
					while (\u0002\u0016\u0007.\u000A(ref enumerator))
					{
						NamingParameter namingParameter = \u0012\u0016\u0007.\u000A(ref enumerator);
						IEnumerable<NamingParameter> enumerable2 = list3;
						Func<NamingParameter, bool> func2;
						if ((func2 = \u0019\u0004.<>c.\u0004) == null)
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
							func2 = (\u0019\u0004.<>c.\u0004 = new Func<NamingParameter, bool>(\u0019\u0004.<>c.\u001F.\u0020));
						}
						IEnumerable<NamingParameter> enumerable3 = Enumerable.Where<NamingParameter>(enumerable2, func2);
						Func<NamingParameter, string> func3;
						if ((func3 = \u0019\u0004.<>c.\u0019) == null)
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
							func3 = (\u0019\u0004.<>c.\u0019 = new Func<NamingParameter, string>(\u0019\u0004.<>c.\u001F.\u0017));
						}
						if (Enumerable.Contains<string>(Enumerable.Select<NamingParameter, string>(enumerable3, func3), \u0020\u0013\u0007.\u0007(namingParameter)))
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
							\u0020\u001D\u001D.\u000A(list2, namingParameter);
						}
						if (\u000E\u000F\u0007.\u0007(namingParameter) == 2)
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
							\u0020\u001D\u001D.\u000A(list2, namingParameter);
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
				IEnumerable<NamingParameter> enumerable4 = list2;
				Func<NamingParameter, bool> func4;
				if ((func4 = \u0019\u0004.<>c.\u0018) == null)
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
					func4 = (\u0019\u0004.<>c.\u0018 = new Func<NamingParameter, bool>(\u0019\u0004.<>c.\u001F.\u0014));
				}
				if (!Enumerable.Any<NamingParameter>(enumerable4, func4))
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
					list2 = \u001E\u001D\u001D.\u000A();
				}
			}
			NamingConfigurationSettings namingConfigurationSettings = \u0016\u0016\u0007.\u000A();
			\u0018\u0016\u0007.\u000A(namingConfigurationSettings, list2);
			\u0007\u0016\u0007.\u000A(namingConfigurationSettings, \u001E\u0016\u0007.\u0007(\u001F));
			\u0004\u0016\u0007.\u000A(namingConfigurationSettings, \u001B\u0016\u0007.\u0007(\u001F));
			\u001F\u0016\u0007.\u000A(namingConfigurationSettings, \u0017\u0016\u0007.\u0007(\u001F));
			return namingConfigurationSettings;
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x000239E4 File Offset: 0x00021BE4
		private static ParametersSettings \u0019(ParametersSettings \u001F)
		{
			\u0019\u0004.\u001D\u0004 u001D_u = new \u0019\u0004.\u001D\u0004();
			\u0013\u001D u0013_u001D = new \u0013\u001D(\u000C\u001D.\u0006);
			List<SpatialElementParameter> list = \u0002\u000B\u0007.\u000A(\u001F);
			if (list == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0004.\u0019(ParametersSettings)).MethodHandle;
				}
				list = \u0013\u001D\u001D.\u000A();
			}
			List<SpatialElementParameter> list2 = \u0013\u001D\u001D.\u000A();
			\u0019\u0004.\u001D\u0004 u001D_u2 = u001D_u;
			IEnumerable<Parameter> enumerable = u0013_u001D.\u001E();
			Func<Parameter, string> func;
			if ((func = \u0019\u0004.<>c.\u0005) == null)
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
				func = (\u0019\u0004.<>c.\u0005 = new Func<Parameter, string>(\u0019\u0004.<>c.\u001F.\u0013));
			}
			u001D_u2.\u001F = \u0014\u001D\u001D.\u000A(Enumerable.OrderBy<Parameter, string>(enumerable, func));
			List<SpatialElementParameter> u000A = Enumerable.ToList<SpatialElementParameter>(Enumerable.Select<SpatialElementParameter, SpatialElementParameter>(Enumerable.Where<SpatialElementParameter>(list, new Func<SpatialElementParameter, bool>(u001D_u.\u000A)), new Func<SpatialElementParameter, SpatialElementParameter>(u001D_u.\u0007)));
			\u0017\u001D\u001D.\u000A(list2, u000A);
			ParametersSettings parametersSettings = \u0002\u0012\u0007.\u000A();
			\u0006\u0012\u0007.\u000A(parametersSettings, list2);
			return parametersSettings;
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x00023AC0 File Offset: 0x00021CC0
		private static SectionViewSettings \u0018(SectionViewSettings \u001F)
		{
			\u0013\u001D u0013_u001D = new \u0013\u001D(\u000C\u001D.\u0006);
			IEnumerable<ViewFamilyType> enumerable = u0013_u001D.\u000F(114);
			Func<ViewFamilyType, ModelViewType> func;
			if ((func = \u0019\u0004.<>c.\u000B) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0004.\u0018(SectionViewSettings)).MethodHandle;
				}
				func = (\u0019\u0004.<>c.\u000B = new Func<ViewFamilyType, ModelViewType>(\u0019\u0004.<>c.\u001F.\u000C));
			}
			List<ModelViewType> u001F = Enumerable.ToList<ModelViewType>(Enumerable.Select<ViewFamilyType, ModelViewType>(enumerable, func));
			int u000A = \u0019\u0004.\u0007<ModelViewType>(u001F, \u001A\u001A\u0007.\u000A(\u001F));
			IEnumerable<ViewFamilyType> enumerable2 = u0013_u001D.\u000F(112);
			Func<ViewFamilyType, ModelViewType> func2;
			if ((func2 = \u0019\u0004.<>c.\u0002) == null)
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
				func2 = (\u0019\u0004.<>c.\u0002 = new Func<ViewFamilyType, ModelViewType>(\u0019\u0004.<>c.\u001F.\u0015));
			}
			List<ModelViewType> u001F2 = Enumerable.ToList<ModelViewType>(Enumerable.Select<ViewFamilyType, ModelViewType>(enumerable2, func2));
			int u000A2 = \u0019\u0004.\u0007<ModelViewType>(u001F2, \u0015\u001A\u0007.\u000A(\u001F));
			IEnumerable<Phase> enumerable3 = u0013_u001D.\u0012();
			Func<Phase, ModelPhase> func3;
			if ((func3 = \u0019\u0004.<>c.\u0006) == null)
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
				func3 = (\u0019\u0004.<>c.\u0006 = new Func<Phase, ModelPhase>(\u0019\u0004.<>c.\u001F.\u0001));
			}
			List<ModelPhase> u001F3 = Enumerable.ToList<ModelPhase>(Enumerable.Select<Phase, ModelPhase>(enumerable3, func3));
			int u000A3 = \u0019\u0004.\u0007<ModelPhase>(u001F3, \u0005\u0018\u0007.\u000A(\u001F));
			List<ViewTemplate> u001F4 = Enumerable.ToList<ViewTemplate>(u0013_u001D.\u000D());
			int u000A4 = \u0019\u0004.\u0007<ViewTemplate>(u001F4, \u0006\u0013\u0007.\u000A(\u001F));
			SectionViewSettings sectionViewSettings = \u0011\u0017\u0007.\u000A();
			\u001B\u0017\u0007.\u000A(sectionViewSettings, \u0019\u0006\u0007.\u000A(u001F, u000A));
			\u0008\u0017\u0007.\u000A(sectionViewSettings, \u0019\u0006\u0007.\u000A(u001F2, u000A2));
			\u0010\u0017\u0007.\u000A(sectionViewSettings, \u0008\u0018\u0007.\u000A(\u001F));
			\u001C\u0017\u0007.\u000A(sectionViewSettings, \u0010\u0018\u0007.\u000A(\u001F));
			\u0003\u0017\u0007.\u000A(sectionViewSettings, \u0009\u0002\u0007.\u000A(u001F3, u000A3));
			\u0012\u0017\u0007.\u000A(sectionViewSettings, \u0015\u0002\u0007.\u000A(u001F4, u000A4));
			\u0006\u0017\u0007.\u000A(sectionViewSettings, \u000B\u0020\u0007.\u000A(\u001F));
			\u000B\u0017\u0007.\u000A(sectionViewSettings, \u0005\u0020\u0007.\u000A(\u001F));
			\u0005\u0017\u0007.\u000A(sectionViewSettings, \u0019\u0020\u0007.\u000A(\u001F));
			\u0019\u0017\u0007.\u000A(sectionViewSettings, \u001D\u0020\u0007.\u000A(\u001F));
			\u001D\u0017\u0007.\u000A(sectionViewSettings, \u001B\u0018\u0007.\u000A(\u001F));
			\u0009\u0020\u0007.\u000A(sectionViewSettings, \u000C\u0018\u0007.\u000A(\u001F));
			\u000A\u0017\u0007.\u000A(sectionViewSettings, \u0015\u0018\u0007.\u000A(\u001F));
			\u0015\u0020\u0007.\u000A(sectionViewSettings, \u0013\u0004\u0007.\u000A(\u001F));
			\u001A\u0020\u0007.\u000A(sectionViewSettings, \u000E\u0018\u0007.\u000A(\u001F));
			\u0014\u0020\u0007.\u000A(sectionViewSettings, \u000C\u001E\u0007.\u000A(\u001F));
			return sectionViewSettings;
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x00023CF0 File Offset: 0x00021EF0
		private static SectionNamingConfigurationSettings \u0005(SectionNamingConfigurationSettings \u001F)
		{
			\u0013\u001D u0013_u001D = new \u0013\u001D(\u000C\u001D.\u0006);
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0004.\u0005(SectionNamingConfigurationSettings)).MethodHandle;
				}
				SectionNamingConfigurationSettings sectionNamingConfigurationSettings = \u0008\u0011\u0007.\u000A();
				\u000E\u0011\u0007.\u000A(sectionNamingConfigurationSettings, \u0016\u0016\u0007.\u000A());
				\u001F = sectionNamingConfigurationSettings;
			}
			List<NamingParameter> list = Enumerable.ToList<NamingParameter>(\u001C\u0016\u0007.\u0007(\u0015\u0011\u0007.\u000A(\u001F)));
			List<NamingParameter> list2 = \u001E\u001D\u001D.\u000A();
			List<NamingParameter> list3 = \u000B\u000F\u0007.\u000A(Enumerable.ToList<NamingParameter>(u0013_u001D.\u0020()));
			IEnumerable<Parameter> enumerable = u0013_u001D.\u0014();
			Func<Parameter, NamingParameter> func;
			if ((func = \u0019\u0004.<>c.\u000F) == null)
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
				func = (\u0019\u0004.<>c.\u000F = new Func<Parameter, NamingParameter>(\u0019\u0004.<>c.\u001F.\u0009));
			}
			List<NamingParameter> u000A = \u000B\u000F\u0007.\u000A(Enumerable.Select<Parameter, NamingParameter>(enumerable, func));
			\u001E\u0006\u0007.\u000A(list3, u000A);
			if (Enumerable.Any<NamingParameter>(list))
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
				List<NamingParameter>.Enumerator enumerator = \u0003\u0016\u0007.\u000A(list);
				try
				{
					while (\u0002\u0016\u0007.\u000A(ref enumerator))
					{
						NamingParameter namingParameter = \u0012\u0016\u0007.\u000A(ref enumerator);
						IEnumerable<NamingParameter> enumerable2 = list3;
						Func<NamingParameter, bool> func2;
						if ((func2 = \u0019\u0004.<>c.\u0012) == null)
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
							func2 = (\u0019\u0004.<>c.\u0012 = new Func<NamingParameter, bool>(\u0019\u0004.<>c.\u001F.\u001F\u000A));
						}
						IEnumerable<NamingParameter> enumerable3 = Enumerable.Where<NamingParameter>(enumerable2, func2);
						Func<NamingParameter, string> func3;
						if ((func3 = \u0019\u0004.<>c.\u0003) == null)
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
							func3 = (\u0019\u0004.<>c.\u0003 = new Func<NamingParameter, string>(\u0019\u0004.<>c.\u001F.\u000A\u000A));
						}
						if (Enumerable.Contains<string>(Enumerable.Select<NamingParameter, string>(enumerable3, func3), \u0020\u0013\u0007.\u0007(namingParameter)))
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
							\u0020\u001D\u001D.\u000A(list2, namingParameter);
						}
						if (\u000E\u000F\u0007.\u0007(namingParameter) == 3)
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
							\u0020\u001D\u001D.\u000A(list2, namingParameter);
						}
						if (\u000E\u000F\u0007.\u0007(namingParameter) == 2)
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
							\u0020\u001D\u001D.\u000A(list2, namingParameter);
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
			}
			SectionNamingConfigurationSettings sectionNamingConfigurationSettings2 = \u0008\u0011\u0007.\u000A();
			NamingConfigurationSettings namingConfigurationSettings = \u0016\u0016\u0007.\u000A();
			\u0018\u0016\u0007.\u000A(namingConfigurationSettings, list2);
			\u0007\u0016\u0007.\u000A(namingConfigurationSettings, \u001E\u0016\u0007.\u0007(\u0015\u0011\u0007.\u000A(\u001F)));
			\u0004\u0016\u0007.\u000A(namingConfigurationSettings, \u001B\u0016\u0007.\u0007(\u0015\u0011\u0007.\u000A(\u001F)));
			\u001F\u0016\u0007.\u000A(namingConfigurationSettings, \u0017\u0016\u0007.\u0007(\u0015\u0011\u0007.\u000A(\u001F)));
			\u000E\u0011\u0007.\u000A(sectionNamingConfigurationSettings2, namingConfigurationSettings);
			\u0002\u0011\u0007.\u000A(sectionNamingConfigurationSettings2, \u0013\u0011\u0007.\u000A(\u001F));
			\u0003\u0011\u0007.\u000A(sectionNamingConfigurationSettings2, \u0011\u0011\u0007.\u000A(\u001F));
			\u000D\u0011\u0007.\u000A(sectionNamingConfigurationSettings2, \u000C\u0011\u0007.\u000A(\u001F));
			\u000F\u0011\u0007.\u000A(sectionNamingConfigurationSettings2, \u0017\u0011\u0007.\u000A(\u001F));
			return sectionNamingConfigurationSettings2;
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x00023F70 File Offset: 0x00022170
		private static CalloutUserSettings \u0016()
		{
			Document u = \u000C\u001D.\u0006;
			\u0013\u001D u0013_u001D = new \u0013\u001D(u);
			DisplayUnit displayUnit = \u001E\u000B\u0007.\u000A(u);
			string[] array;
			if (displayUnit != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0004.\u0016()).MethodHandle;
				}
				array = \u0009\u001D.\u000A;
			}
			else
			{
				array = \u0009\u001D.\u001F;
			}
			string[] array2 = array;
			IEnumerable<ViewFamilyType> enumerable = u0013_u001D.\u000F(109);
			Func<ViewFamilyType, ModelViewType> func;
			if ((func = \u0019\u0004.<>c.\u001C) == null)
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
				func = (\u0019\u0004.<>c.\u001C = new Func<ViewFamilyType, ModelViewType>(\u0019\u0004.<>c.\u001F.\u0007\u000A));
			}
			List<ModelViewType> u001F = Enumerable.ToList<ModelViewType>(Enumerable.Select<ViewFamilyType, ModelViewType>(enumerable, func));
			int num;
			if (\u0004\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()) < \u0019\u0004\u001D.\u000A(u001F))
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
				num = \u0004\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A());
			}
			else
			{
				num = 0;
			}
			int u000A = num;
			IEnumerable<Phase> enumerable2 = u0013_u001D.\u0012();
			Func<Phase, ModelPhase> func2;
			if ((func2 = \u0019\u0004.<>c.\u000D) == null)
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
				func2 = (\u0019\u0004.<>c.\u000D = new Func<Phase, ModelPhase>(\u0019\u0004.<>c.\u001F.\u001D\u000A));
			}
			List<ModelPhase> u001F2 = Enumerable.ToList<ModelPhase>(Enumerable.Select<Phase, ModelPhase>(enumerable2, func2));
			int num2;
			if (\u0007\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()) < \u001D\u0004\u001D.\u000A(u001F2))
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
				num2 = \u0007\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A());
			}
			else
			{
				num2 = 0;
			}
			int u000A2 = num2;
			List<ViewTemplate> u001F3 = Enumerable.ToList<ViewTemplate>(u0013_u001D.\u0010());
			int num3;
			if (\u001F\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()) < \u000A\u0004\u001D.\u000A(u001F3))
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
				num3 = \u001F\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A());
			}
			else
			{
				num3 = 0;
			}
			int u000A3 = num3;
			CalloutUserSettings calloutUserSettings = \u001C\u000B\u0007.\u000A();
			CalloutViewSettings calloutViewSettings = \u0002\u0002\u0007.\u000A();
			\u0016\u0002\u0007.\u000A(calloutViewSettings, \u0019\u0006\u0007.\u000A(u001F, u000A));
			\u0018\u0002\u0007.\u000A(calloutViewSettings, \u0001\u001D.\u001F(array2[\u0009\u001D\u001D.\u000A(\u0001\u0008\u0007.\u000A())], displayUnit));
			\u0004\u0002\u0007.\u000A(calloutViewSettings, \u0015\u001D\u001D.\u000A(\u000C\u001D.\u0016, \u0001\u001D\u001D.\u000A(\u0001\u0008\u0007.\u000A())));
			\u0007\u0002\u0007.\u000A(calloutViewSettings, \u0009\u0002\u0007.\u000A(u001F2, u000A2));
			\u001F\u0002\u0007.\u000A(calloutViewSettings, \u0015\u0002\u0007.\u000A(u001F3, u000A3));
			\u0001\u000B\u0007.\u000A(calloutViewSettings, \u000C\u001D\u001D.\u000A(\u0001\u0008\u0007.\u000A()));
			\u000C\u000B\u0007.\u000A(calloutViewSettings, \u001A\u001D\u001D.\u000A(\u0001\u0008\u0007.\u000A()));
			\u001D\u000B\u0007.\u000A(calloutUserSettings, calloutViewSettings);
			NamingConfigurationSettings namingConfigurationSettings = \u0016\u0016\u0007.\u000A();
			\u0018\u0016\u0007.\u000A(namingConfigurationSettings, \u001E\u001D\u001D.\u000A());
			\u0007\u000B\u0007.\u000A(calloutUserSettings, namingConfigurationSettings);
			ParametersSettings parametersSettings = \u0002\u0012\u0007.\u000A();
			\u0006\u0012\u0007.\u000A(parametersSettings, \u0013\u001D\u001D.\u000A());
			\u000A\u000B\u0007.\u000A(calloutUserSettings, parametersSettings);
			return calloutUserSettings;
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x000241CC File Offset: 0x000223CC
		private static SectionAndElevationUserSettings \u000B()
		{
			Document u = \u000C\u001D.\u0006;
			\u0013\u001D u0013_u001D = new \u0013\u001D(u);
			DisplayUnit displayUnit = \u001E\u000B\u0007.\u000A(u);
			string[] array;
			if (displayUnit != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0004.\u000B()).MethodHandle;
				}
				array = \u0009\u001D.\u000A;
			}
			else
			{
				array = \u0009\u001D.\u001F;
			}
			string[] array2 = array;
			IEnumerable<ViewFamilyType> enumerable = u0013_u001D.\u000F(114);
			Func<ViewFamilyType, ModelViewType> func;
			if ((func = \u0019\u0004.<>c.\u0010) == null)
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
				func = (\u0019\u0004.<>c.\u0010 = new Func<ViewFamilyType, ModelViewType>(\u0019\u0004.<>c.\u001F.\u0004\u000A));
			}
			List<ModelViewType> u001F = Enumerable.ToList<ModelViewType>(Enumerable.Select<ViewFamilyType, ModelViewType>(enumerable, func));
			int num;
			if (\u0014\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()) < \u0019\u0004\u001D.\u000A(u001F))
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
				num = \u0014\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A());
			}
			else
			{
				num = 0;
			}
			int u000A = num;
			IEnumerable<ViewFamilyType> enumerable2 = u0013_u001D.\u000F(112);
			Func<ViewFamilyType, ModelViewType> func2;
			if ((func2 = \u0019\u0004.<>c.\u000E) == null)
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
				func2 = (\u0019\u0004.<>c.\u000E = new Func<ViewFamilyType, ModelViewType>(\u0019\u0004.<>c.\u001F.\u0019\u000A));
			}
			List<ModelViewType> u001F2 = Enumerable.ToList<ModelViewType>(Enumerable.Select<ViewFamilyType, ModelViewType>(enumerable2, func2));
			int num2;
			if (\u0017\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()) < \u0019\u0004\u001D.\u000A(u001F2))
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
				num2 = \u0017\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A());
			}
			else
			{
				num2 = 0;
			}
			int u000A2 = num2;
			IEnumerable<Phase> enumerable3 = u0013_u001D.\u0012();
			Func<Phase, ModelPhase> func3;
			if ((func3 = \u0019\u0004.<>c.\u0008) == null)
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
				func3 = (\u0019\u0004.<>c.\u0008 = new Func<Phase, ModelPhase>(\u0019\u0004.<>c.\u001F.\u0018\u000A));
			}
			List<ModelPhase> u001F3 = Enumerable.ToList<ModelPhase>(Enumerable.Select<Phase, ModelPhase>(enumerable3, func3));
			int num3;
			if (\u0020\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()) < \u001D\u0004\u001D.\u000A(u001F3))
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
				num3 = \u0020\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A());
			}
			else
			{
				num3 = 0;
			}
			int u000A3 = num3;
			List<ViewTemplate> u001F4 = Enumerable.ToList<ViewTemplate>(u0013_u001D.\u000D());
			int num4;
			if (\u001E\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()) < \u000A\u0004\u001D.\u000A(u001F4))
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
				num4 = \u001E\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A());
			}
			else
			{
				num4 = 0;
			}
			int u000A4 = num4;
			SectionAndElevationUserSettings sectionAndElevationUserSettings = \u0003\u001E\u0007.\u000A();
			SectionViewSettings sectionViewSettings = \u0011\u0017\u0007.\u000A();
			\u001B\u0017\u0007.\u000A(sectionViewSettings, \u0019\u0006\u0007.\u000A(u001F, u000A));
			\u0008\u0017\u0007.\u000A(sectionViewSettings, \u0019\u0006\u0007.\u000A(u001F2, u000A2));
			\u0010\u0017\u0007.\u000A(sectionViewSettings, \u0001\u001D.\u001F(array2[\u0011\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A())], displayUnit));
			\u001C\u0017\u0007.\u000A(sectionViewSettings, \u0015\u001D\u001D.\u000A(\u000C\u001D.\u0016, \u001B\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A())));
			\u0003\u0017\u0007.\u000A(sectionViewSettings, \u0009\u0002\u0007.\u000A(u001F3, u000A3));
			\u0012\u0017\u0007.\u000A(sectionViewSettings, \u0015\u0002\u0007.\u000A(u001F4, u000A4));
			\u0006\u0017\u0007.\u000A(sectionViewSettings, \u0008\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()));
			\u000B\u0017\u0007.\u000A(sectionViewSettings, \u000E\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()));
			\u0005\u0017\u0007.\u000A(sectionViewSettings, \u0010\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()));
			\u0019\u0017\u0007.\u000A(sectionViewSettings, \u000D\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()));
			\u001D\u0017\u0007.\u000A(sectionViewSettings, \u001C\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()));
			\u0009\u0020\u0007.\u000A(sectionViewSettings, \u0003\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()));
			\u000A\u0017\u0007.\u000A(sectionViewSettings, \u0012\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()));
			\u0015\u0020\u0007.\u000A(sectionViewSettings, \u000F\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()));
			\u001A\u0020\u0007.\u000A(sectionViewSettings, \u0006\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()));
			\u0014\u0020\u0007.\u000A(sectionViewSettings, \u0002\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()));
			\u0016\u001E\u0007.\u000A(sectionAndElevationUserSettings, sectionViewSettings);
			SectionNamingConfigurationSettings sectionNamingConfigurationSettings = \u0008\u0011\u0007.\u000A();
			NamingConfigurationSettings namingConfigurationSettings = \u0016\u0016\u0007.\u000A();
			\u0018\u0016\u0007.\u000A(namingConfigurationSettings, \u001E\u001D\u001D.\u000A());
			\u000E\u0011\u0007.\u000A(sectionNamingConfigurationSettings, namingConfigurationSettings);
			\u000D\u0011\u0007.\u000A(sectionNamingConfigurationSettings, \u000B\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()));
			\u0003\u0011\u0007.\u000A(sectionNamingConfigurationSettings, \u0016\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()));
			\u0002\u0011\u0007.\u000A(sectionNamingConfigurationSettings, \u0005\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()));
			\u000F\u0011\u0007.\u000A(sectionNamingConfigurationSettings, \u0018\u0004\u001D.\u000A(\u0001\u0008\u0007.\u000A()));
			\u0005\u001E\u0007.\u000A(sectionAndElevationUserSettings, sectionNamingConfigurationSettings);
			ParametersSettings parametersSettings = \u0002\u0012\u0007.\u000A();
			\u0006\u0012\u0007.\u000A(parametersSettings, \u0013\u001D\u001D.\u000A());
			\u0018\u001E\u0007.\u000A(sectionAndElevationUserSettings, parametersSettings);
			return sectionAndElevationUserSettings;
		}

		// Token: 0x020007C1 RID: 1985
		[CompilerGenerated]
		private sealed class \u0007\u0004<\u001F> where \u001F : ModelObject
		{
			// Token: 0x06004C87 RID: 19591 RVA: 0x001DC590 File Offset: 0x001DA790
			internal bool \u000A(\u001F \u001F)
			{
				long num = \u0018\u0018\u0007.\u0007(\u001F);
				return \u000C\u001F\u001D.\u000A(ref num, \u0018\u0018\u0007.\u0007(this.\u001F));
			}

			// Token: 0x06004C88 RID: 19592 RVA: 0x001DC5C8 File Offset: 0x001DA7C8
			internal bool \u0007(\u001F \u001F)
			{
				return \u000D\u001F\u001D.\u000A(\u001D\u000D\u0007.\u0007(\u001F), \u001D\u000D\u0007.\u0007(this.\u001F));
			}

			// Token: 0x04001F97 RID: 8087
			public \u001F \u001F;
		}

		// Token: 0x020007C2 RID: 1986
		[CompilerGenerated]
		private sealed class \u001D\u0004
		{
			// Token: 0x06004C8A RID: 19594 RVA: 0x001DC610 File Offset: 0x001DA810
			internal bool \u000A(SpatialElementParameter \u001F)
			{
				IEnumerable<Parameter> u001F = this.\u001F;
				Func<Parameter, long> func;
				if ((func = \u0019\u0004.<>c.\u0016) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0004.\u001D\u0004.\u000A(SpatialElementParameter)).MethodHandle;
					}
					func = (\u0019\u0004.<>c.\u0016 = new Func<Parameter, long>(\u0019\u0004.<>c.\u001F.\u001A));
				}
				return Enumerable.Contains<long>(Enumerable.Select<Parameter, long>(u001F, func), \u0012\u000A\u001D.\u0007(\u001F));
			}

			// Token: 0x06004C8B RID: 19595 RVA: 0x001DC66C File Offset: 0x001DA86C
			internal SpatialElementParameter \u0007(SpatialElementParameter \u001F)
			{
				\u0019\u0004.\u0004\u0004 u0004_u = new \u0019\u0004.\u0004\u0004();
				u0004_u.\u001F = \u001F;
				SpatialElementParameter spatialElementParameter = \u0010\u0009\u000D.\u000A();
				\u0016\u000A\u001D.\u001D(spatialElementParameter, \u0012\u000A\u001D.\u0007(u0004_u.\u001F));
				\u0005\u000A\u001D.\u001D(spatialElementParameter, \u000F\u000A\u001D.\u0007(u0004_u.\u001F));
				\u0018\u000A\u001D.\u001D(spatialElementParameter, \u000D\u0009\u000D.\u000A(u0004_u.\u001F));
				\u000A\u0001\u000D.\u000A(spatialElementParameter, \u0005\u0018\u001D.\u000A(u0004_u.\u001F));
				\u0002\u000A\u001D.\u001D(spatialElementParameter, this.\u001F);
				\u001F\u0001\u000D.\u000A(spatialElementParameter, Enumerable.First<Parameter>(this.\u001F, new Func<Parameter, bool>(u0004_u.\u000A)));
				return spatialElementParameter;
			}

			// Token: 0x04001F98 RID: 8088
			public ObservableCollection<Parameter> \u001F;
		}

		// Token: 0x020007C3 RID: 1987
		[CompilerGenerated]
		private sealed class \u0004\u0004
		{
			// Token: 0x06004C8D RID: 19597 RVA: 0x001DC718 File Offset: 0x001DA918
			internal bool \u000A(Parameter \u001F)
			{
				return \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F)) == \u0012\u000A\u001D.\u0007(this.\u001F);
			}

			// Token: 0x04001F99 RID: 8089
			public SpatialElementParameter \u001F;
		}
	}
}
