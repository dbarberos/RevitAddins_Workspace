using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using A;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.TGDatabaseLayer.StyleMapping;
using Newtonsoft.Json;

namespace DiRoots.One.TGDatabaseLayer.Dto
{
	// Token: 0x02000129 RID: 297
	[Serializable]
	public class SelectedExcel : ModelBase
	{
		// Token: 0x17000319 RID: 793
		// (get) Token: 0x06000B2B RID: 2859 RVA: 0x0004765C File Offset: 0x0004585C
		// (set) Token: 0x06000B2C RID: 2860 RVA: 0x00047670 File Offset: 0x00045870
		public List<SheetAndNamedRange> SheetAndNamedRanges { get; set; } = new List<SheetAndNamedRange>();

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x06000B2D RID: 2861 RVA: 0x00047684 File Offset: 0x00045884
		// (set) Token: 0x06000B2E RID: 2862 RVA: 0x00047698 File Offset: 0x00045898
		public bool IsChecked { get; set; }

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x06000B2F RID: 2863 RVA: 0x000476AC File Offset: 0x000458AC
		// (set) Token: 0x06000B30 RID: 2864 RVA: 0x000476C0 File Offset: 0x000458C0
		public ActionTypes ActionType { get; set; }

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06000B31 RID: 2865 RVA: 0x000476D4 File Offset: 0x000458D4
		// (set) Token: 0x06000B32 RID: 2866 RVA: 0x000476E8 File Offset: 0x000458E8
		public int ViewScale { get; set; }

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x06000B33 RID: 2867 RVA: 0x000476FC File Offset: 0x000458FC
		// (set) Token: 0x06000B34 RID: 2868 RVA: 0x00047710 File Offset: 0x00045910
		public string DataSourceDefinitionId { get; set; }

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06000B35 RID: 2869 RVA: 0x00047724 File Offset: 0x00045924
		// (set) Token: 0x06000B36 RID: 2870 RVA: 0x00047738 File Offset: 0x00045938
		public bool AutoSync_Initial { get; set; }

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06000B37 RID: 2871 RVA: 0x0004774C File Offset: 0x0004594C
		// (set) Token: 0x06000B38 RID: 2872 RVA: 0x00047760 File Offset: 0x00045960
		public bool AutoSync { get; set; }

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000B39 RID: 2873 RVA: 0x00047774 File Offset: 0x00045974
		// (set) Token: 0x06000B3A RID: 2874 RVA: 0x00047788 File Offset: 0x00045988
		public long ViewElementId { get; set; }

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000B3B RID: 2875 RVA: 0x0004779C File Offset: 0x0004599C
		// (set) Token: 0x06000B3C RID: 2876 RVA: 0x000477B0 File Offset: 0x000459B0
		public string UniqueId { get; set; }

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000B3D RID: 2877 RVA: 0x000477C4 File Offset: 0x000459C4
		// (set) Token: 0x06000B3E RID: 2878 RVA: 0x000477D8 File Offset: 0x000459D8
		public string SheetName_Initial { get; set; }

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06000B3F RID: 2879 RVA: 0x000477EC File Offset: 0x000459EC
		// (set) Token: 0x06000B40 RID: 2880 RVA: 0x00047800 File Offset: 0x00045A00
		public string SheetName { get; set; }

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000B41 RID: 2881 RVA: 0x00047814 File Offset: 0x00045A14
		// (set) Token: 0x06000B42 RID: 2882 RVA: 0x00047828 File Offset: 0x00045A28
		public List<string> WorkSheets { get; set; } = new List<string>();

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000B43 RID: 2883 RVA: 0x0004783C File Offset: 0x00045A3C
		// (set) Token: 0x06000B44 RID: 2884 RVA: 0x00047850 File Offset: 0x00045A50
		public string WorkSheet_Initial { get; set; }

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06000B45 RID: 2885 RVA: 0x00047864 File Offset: 0x00045A64
		// (set) Token: 0x06000B46 RID: 2886 RVA: 0x00047878 File Offset: 0x00045A78
		public string WorkSheet { get; set; }

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06000B47 RID: 2887 RVA: 0x0004788C File Offset: 0x00045A8C
		// (set) Token: 0x06000B48 RID: 2888 RVA: 0x000478A0 File Offset: 0x00045AA0
		public List<NamedRangeInfo> WorkSheetRegions { get; set; }

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06000B49 RID: 2889 RVA: 0x000478B4 File Offset: 0x00045AB4
		// (set) Token: 0x06000B4A RID: 2890 RVA: 0x000478C8 File Offset: 0x00045AC8
		public NamedRangeInfo WorkSheetRegion_Initial { get; set; } = new NamedRangeInfo();

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06000B4B RID: 2891 RVA: 0x000478DC File Offset: 0x00045ADC
		// (set) Token: 0x06000B4C RID: 2892 RVA: 0x000478F0 File Offset: 0x00045AF0
		public NamedRangeInfo WorkSheetRegion { get; set; }

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06000B4D RID: 2893 RVA: 0x00047904 File Offset: 0x00045B04
		// (set) Token: 0x06000B4E RID: 2894 RVA: 0x00047918 File Offset: 0x00045B18
		public string ExcelFileRelative { get; set; }

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x06000B4F RID: 2895 RVA: 0x0004792C File Offset: 0x00045B2C
		// (set) Token: 0x06000B50 RID: 2896 RVA: 0x00047940 File Offset: 0x00045B40
		public string ExcelFile { get; set; }

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06000B51 RID: 2897 RVA: 0x00047954 File Offset: 0x00045B54
		// (set) Token: 0x06000B52 RID: 2898 RVA: 0x00047968 File Offset: 0x00045B68
		public bool IsRelativePath { get; set; }

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06000B53 RID: 2899 RVA: 0x0004797C File Offset: 0x00045B7C
		// (set) Token: 0x06000B54 RID: 2900 RVA: 0x00047990 File Offset: 0x00045B90
		public string ViewType { get; set; }

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06000B55 RID: 2901 RVA: 0x000479A4 File Offset: 0x00045BA4
		// (set) Token: 0x06000B56 RID: 2902 RVA: 0x000479B8 File Offset: 0x00045BB8
		public string Modified { get; set; }

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06000B57 RID: 2903 RVA: 0x000479CC File Offset: 0x00045BCC
		// (set) Token: 0x06000B58 RID: 2904 RVA: 0x000479E0 File Offset: 0x00045BE0
		public UpdateStates UpdateState { get; set; }

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06000B59 RID: 2905 RVA: 0x000479F4 File Offset: 0x00045BF4
		// (set) Token: 0x06000B5A RID: 2906 RVA: 0x00047A08 File Offset: 0x00045C08
		public SelectedExcel OldSelectedExcel { get; set; }

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x06000B5B RID: 2907 RVA: 0x00047A1C File Offset: 0x00045C1C
		// (set) Token: 0x06000B5C RID: 2908 RVA: 0x00047A30 File Offset: 0x00045C30
		public string OldSelectedExcelSheetName { get; set; }

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x06000B5D RID: 2909 RVA: 0x00047A44 File Offset: 0x00045C44
		// (set) Token: 0x06000B5E RID: 2910 RVA: 0x00047A58 File Offset: 0x00045C58
		public int SourceType { get; set; }

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x06000B5F RID: 2911 RVA: 0x00047A6C File Offset: 0x00045C6C
		// (set) Token: 0x06000B60 RID: 2912 RVA: 0x00047A80 File Offset: 0x00045C80
		public int ImportType { get; set; }

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06000B61 RID: 2913 RVA: 0x00047A94 File Offset: 0x00045C94
		// (set) Token: 0x06000B62 RID: 2914 RVA: 0x00047AA8 File Offset: 0x00045CA8
		public int SelectedDpi { get; set; }

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06000B63 RID: 2915 RVA: 0x00047ABC File Offset: 0x00045CBC
		// (set) Token: 0x06000B64 RID: 2916 RVA: 0x00047AD0 File Offset: 0x00045CD0
		public int PageOption { get; set; }

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x06000B65 RID: 2917 RVA: 0x00047AE4 File Offset: 0x00045CE4
		// (set) Token: 0x06000B66 RID: 2918 RVA: 0x00047AF8 File Offset: 0x00045CF8
		public string SelectedPages { get; set; }

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06000B67 RID: 2919 RVA: 0x00047B0C File Offset: 0x00045D0C
		// (set) Token: 0x06000B68 RID: 2920 RVA: 0x00047B20 File Offset: 0x00045D20
		public bool BlackAndWhite { get; set; }

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x06000B69 RID: 2921 RVA: 0x00047B34 File Offset: 0x00045D34
		// (set) Token: 0x06000B6A RID: 2922 RVA: 0x00047B48 File Offset: 0x00045D48
		[XmlIgnore]
		public StyleMappingDto StyleMappingSnapshot { get; set; }

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06000B6B RID: 2923 RVA: 0x00047B5C File Offset: 0x00045D5C
		// (set) Token: 0x06000B6C RID: 2924 RVA: 0x00047BD0 File Offset: 0x00045DD0
		public string StyleMappingSnapshotJson
		{
			get
			{
				if (\u0017\u0019\u0004.\u0007(this) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.get_StyleMappingSnapshotJson()).MethodHandle;
					}
					return null;
				}
				string result;
				try
				{
					result = \u000E\u000D\u0004.\u000A(\u0017\u0019\u0004.\u0007(this), Formatting.None);
				}
				catch (Exception u000A)
				{
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGDatabaseLayer\\Dto\\SelectedExcel.cs", "StyleMappingSnapshotJson");
					result = \u000F\u0015\u0010.\u001F;
				}
				return result;
			}
			set
			{
				if (\u001A\u0006\u0007.\u000A(value))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.set_StyleMappingSnapshotJson(string)).MethodHandle;
					}
					\u000F\u0020\u0004.\u0007(this, \u0001\u0004\u000E.\u001F);
					return;
				}
				try
				{
					\u000F\u0020\u0004.\u0007(this, JsonConvert.DeserializeObject<StyleMappingDto>(value));
				}
				catch (Exception u000A)
				{
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGDatabaseLayer\\Dto\\SelectedExcel.cs", "StyleMappingSnapshotJson");
					\u000F\u0020\u0004.\u0007(this, \u0001\u0004\u000E.\u001F);
				}
			}
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x00047C4C File Offset: 0x00045E4C
		public static List<SelectedExcel> ConvertFromDto(List<SelectedExcel> selectedExcels)
		{
			List<SelectedExcel> list = \u0003\u000B\u0004.\u000A();
			List<SelectedExcel>.Enumerator enumerator = \u000F\u0017\u0004.\u000A(selectedExcels);
			try
			{
				while (\u0012\u0020\u0004.\u000A(ref enumerator))
				{
					SelectedExcel.\u0009\u0005 u0009_u = new SelectedExcel.\u0009\u0005();
					u0009_u.\u001F = \u0006\u0017\u0004.\u000A(ref enumerator);
					SelectedExcel selectedExcel = \u0002\u0017\u0004.\u000A();
					\u0002\u0008\u0004.\u001D(selectedExcel, u0009_u.\u001F);
					\u0011\u0016\u0004.\u000A(selectedExcel, \u000B\u0017\u0004.\u000A(u0009_u.\u001F));
					\u001B\u0016\u0004.\u000A(selectedExcel, \u0016\u0017\u0004.\u000A(u0009_u.\u001F));
					\u0008\u0016\u0004.\u0007(selectedExcel, \u0005\u0017\u0004.\u000A(u0009_u.\u001F));
					\u0010\u0016\u0004.\u000A(selectedExcel, \u0018\u0017\u0004.\u000A(u0009_u.\u001F));
					\u001E\u0008\u0004.\u001D(selectedExcel, \u0019\u0017\u0004.\u000A(u0009_u.\u001F));
					\u000C\u0011\u0004.\u001D(selectedExcel, \u000F\u0011\u0004.\u000A(u0009_u.\u001F));
					\u0004\u0017\u0004.\u000A(selectedExcel, \u0012\u0011\u0004.\u000A(u0009_u.\u001F));
					\u001E\u001B\u0004.\u001D(selectedExcel, \u001D\u0017\u0004.\u000A(u0009_u.\u001F));
					\u001B\u001B\u0004.\u001D(selectedExcel, \u0007\u0017\u0004.\u000A(u0009_u.\u001F));
					\u0007\u001B\u0004.\u001D(selectedExcel, \u000A\u0017\u0004.\u000A(u0009_u.\u001F));
					\u001F\u001B\u0004.\u001D(selectedExcel, \u001F\u0017\u0004.\u000A(u0009_u.\u001F));
					\u0001\u0020\u0004.\u000A(selectedExcel, \u0009\u0020\u0004.\u000A(u0009_u.\u001F));
					\u001C\u0016\u0004.\u0007(selectedExcel, \u0015\u0020\u0004.\u000A(u0009_u.\u001F));
					\u0012\u001B\u0004.\u001D(selectedExcel, \u0002\u0011\u0004.\u000A(u0009_u.\u001F));
					\u0001\u001B\u0004.\u000A(selectedExcel, \u000C\u0020\u0004.\u000A(u0009_u.\u001F));
					\u0014\u001B\u0004.\u001D(selectedExcel, \u001A\u0020\u0004.\u000A(u0009_u.\u001F));
					\u0014\u0020\u0004.\u000A(selectedExcel, \u0013\u0020\u0004.\u000A(u0009_u.\u001F));
					\u0004\u000B\u0004.\u000A(selectedExcel, \u0017\u0020\u0004.\u000A(u0009_u.\u001F));
					\u001D\u000B\u0004.\u000A(selectedExcel, \u0020\u0020\u0004.\u000A(u0009_u.\u001F));
					\u001E\u0016\u0004.\u000A(selectedExcel, \u001E\u0020\u0004.\u000A(u0009_u.\u001F));
					\u000D\u0016\u0004.\u0007(selectedExcel, \u0011\u0020\u0004.\u000A(u0009_u.\u001F));
					\u000A\u001E\u0004.\u000A(selectedExcel, \u0005\u0011\u0004.\u000A(u0009_u.\u001F));
					\u001B\u0020\u0004.\u000A(selectedExcel, \u0007\u0011\u0004.\u000A(u0009_u.\u001F));
					FormatOptions formatOptions = \u0008\u0020\u0004.\u000A();
					\u001A\u0008\u0004.\u000A(formatOptions, \u000B\u0011\u0004.\u000A(u0009_u.\u001F));
					\u000E\u0020\u0004.\u000A(selectedExcel, formatOptions);
					\u0007\u001E\u0004.\u000A(selectedExcel, \u000B\u0008\u0004.\u000A((PageOptions)\u0019\u0011\u0004.\u000A(u0009_u.\u001F)));
					\u000D\u0020\u0004.\u000A(selectedExcel, \u000B\u0008\u0004.\u000A((SourceTypes)\u0010\u0020\u0004.\u000A(u0009_u.\u001F)));
					\u0009\u001B\u0004.\u000A(selectedExcel, \u000B\u0008\u0004.\u000A((ImportTypes)\u0006\u0011\u0004.\u000A(u0009_u.\u001F)));
					\u000F\u0016\u0004.\u000A(selectedExcel, \u0017\u0019\u0004.\u001D(u0009_u.\u001F));
					SelectedExcel selectedExcel2 = selectedExcel;
					EnumInfo f = Enumerable.First<EnumInfo>(\u0020\u0011\u0004.\u001D(selectedExcel2), new Func<EnumInfo, bool>(u0009_u.\u000A));
					selectedExcel2.FX(f);
					object u001F = selectedExcel2;
					string u000A;
					if (\u0003\u0020\u0004.\u000A(u0009_u.\u001F) == null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.ConvertFromDto(List<SelectedExcel>)).MethodHandle;
						}
						u000A = \u001C\u0020\u0004.\u000A(u0009_u.\u001F);
					}
					else
					{
						u000A = \u0012\u0011\u0004.\u000A(\u0003\u0020\u0004.\u000A(u0009_u.\u001F));
					}
					\u0018\u000B\u0004.\u000A(u001F, u000A);
					\u001A\u0016\u0004.\u000A(list, selectedExcel2);
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
			return list;
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x00047F9C File Offset: 0x0004619C
		public static List<SelectedExcel> ConvertToDto(List<SelectedExcel> selectedExcels)
		{
			List<SelectedExcel> list = \u001C\u0017\u0004.\u000A();
			List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(selectedExcels);
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					SelectedExcel u001F = \u001F\u0016\u0004.\u000A(ref enumerator);
					\u0012\u0017\u0004.\u000A(list, \u0003\u0017\u0004.\u000A(u001F));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.ConvertToDto(List<SelectedExcel>)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x06000B6F RID: 2927 RVA: 0x00048014 File Offset: 0x00046214
		public static SelectedExcel ConvertToDto(SelectedExcel selectedExcel)
		{
			SelectedExcel selectedExcel2 = \u0006\u0014\u0004.\u000A();
			\u0002\u0014\u0004.\u000A(selectedExcel2, \u0016\u000B\u0004.\u000A(selectedExcel));
			\u000B\u0014\u0004.\u000A(selectedExcel2, \u0016\u0011\u0004.\u001D(selectedExcel));
			\u0016\u0014\u0004.\u000A(selectedExcel2, \u0008\u001B\u0004.\u001D(selectedExcel));
			\u0018\u0014\u0004.\u000A(selectedExcel2, \u0005\u0014\u0004.\u000A(selectedExcel));
			\u0019\u0014\u0004.\u000A(selectedExcel2, \u0017\u0008\u0004.\u001D(selectedExcel));
			\u001C\u0011\u0004.\u000A(selectedExcel2, \u0011\u0020\u001D.\u0007(selectedExcel));
			\u0004\u0014\u0004.\u000A(selectedExcel2, \u0014\u0005\u0004.\u0007(selectedExcel));
			\u001D\u0014\u0004.\u000A(selectedExcel2, \u0018\u001B\u0004.\u001D(selectedExcel));
			\u0007\u0014\u0004.\u000A(selectedExcel2, \u0020\u0020\u001D.\u0007(selectedExcel));
			\u000A\u0014\u0004.\u000A(selectedExcel2, \u000A\u001B\u0004.\u001D(selectedExcel));
			\u001F\u0014\u0004.\u000A(selectedExcel2, \u0014\u0020\u001D.\u0007(selectedExcel));
			\u0001\u0017\u0004.\u000A(selectedExcel2, \u0009\u0017\u0004.\u000A(selectedExcel));
			\u0015\u0017\u0004.\u000A(selectedExcel2, \u0019\u0010\u0004.\u0007(selectedExcel));
			\u000D\u0011\u0004.\u000A(selectedExcel2, \u0019\u0020\u001D.\u0007(selectedExcel));
			\u000C\u0017\u0004.\u000A(selectedExcel2, \u000E\u0016\u0004.\u000A(selectedExcel));
			\u001A\u0017\u0004.\u000A(selectedExcel2, \u0016\u001B\u0004.\u001D(selectedExcel));
			\u0013\u0017\u0004.\u000A(selectedExcel2, \u0013\u0008\u0004.\u001D(selectedExcel));
			\u0014\u0017\u0004.\u000A(selectedExcel2, \u0009\u0005\u0004.\u000A(selectedExcel));
			\u0020\u0017\u0004.\u000A(selectedExcel2, \u0017\u0017\u0004.\u000A(selectedExcel));
			\u001E\u0017\u0004.\u000A(selectedExcel2, \u000B\u0011\u001D.\u000A(\u0006\u0020\u001D.\u0007(selectedExcel)));
			\u0011\u0017\u0004.\u000A(selectedExcel2, \u000F\u001B\u0004.\u001D(selectedExcel));
			\u001B\u0017\u0004.\u000A(selectedExcel2, \u0001\u0016\u0004.\u0007(selectedExcel));
			\u0008\u0017\u0004.\u000A(selectedExcel2, \u000D\u001B\u001D.\u0007(\u0002\u0003\u0004.\u0007(selectedExcel)));
			\u001B\u0011\u0004.\u000A(selectedExcel2, \u000D\u001B\u001D.\u0007(\u0015\u0016\u0004.\u0007(selectedExcel)));
			\u0008\u0011\u0004.\u000A(selectedExcel2, \u0018\u0011\u0004.\u001D(selectedExcel));
			\u0010\u0011\u0004.\u000A(selectedExcel2, \u000A\u0011\u0004.\u001D(selectedExcel));
			\u000E\u0011\u0004.\u000A(selectedExcel2, \u000D\u001B\u001D.\u0007(\u0004\u0011\u0004.\u001D(selectedExcel)));
			\u0003\u0011\u0004.\u000A(selectedExcel2, \u001F\u000B\u0004.\u0007(\u000A\u000B\u0004.\u0007(selectedExcel)));
			\u000F\u0020\u0004.\u001D(selectedExcel2, \u000B\u0010\u0004.\u000A(selectedExcel));
			SelectedExcel selectedExcel3 = selectedExcel2;
			if (\u000E\u0017\u0004.\u000A(selectedExcel) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.ConvertToDto(SelectedExcel)).MethodHandle;
				}
				\u000D\u0017\u0004.\u000A(selectedExcel3, \u0014\u0005\u0004.\u0007(\u000E\u0017\u0004.\u000A(selectedExcel)));
			}
			else
			{
				\u000D\u0017\u0004.\u000A(selectedExcel3, \u0010\u0017\u0004.\u000A(selectedExcel));
			}
			return selectedExcel3;
		}

		// Token: 0x02000811 RID: 2065
		[CompilerGenerated]
		private sealed class \u0009\u0005
		{
			// Token: 0x06004DA0 RID: 19872 RVA: 0x001DEA40 File Offset: 0x001DCC40
			internal bool \u000A(EnumInfo \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u000B\u0011\u001D.\u000A(\u001F), \u0013\u001A\u0004.\u000A(this.\u001F));
			}

			// Token: 0x0400205E RID: 8286
			public SelectedExcel \u001F;
		}
	}
}
