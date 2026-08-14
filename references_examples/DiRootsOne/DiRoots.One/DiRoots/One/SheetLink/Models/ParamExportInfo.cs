using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.SheetLink.Enums;
using Newtonsoft.Json;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x02000248 RID: 584
	[Serializable]
	public class ParamExportInfo
	{
		// Token: 0x06001760 RID: 5984 RVA: 0x000998B8 File Offset: 0x00097AB8
		public ParamExportInfo()
		{
			\u0018\u001B\u0005.\u0007(this, new List<long>());
		}

		// Token: 0x1700066A RID: 1642
		// (get) Token: 0x06001762 RID: 5986 RVA: 0x00099900 File Offset: 0x00097B00
		// (set) Token: 0x06001761 RID: 5985 RVA: 0x000998EC File Offset: 0x00097AEC
		public string UniqueId { get; set; }

		// Token: 0x1700066B RID: 1643
		// (get) Token: 0x06001764 RID: 5988 RVA: 0x00099928 File Offset: 0x00097B28
		// (set) Token: 0x06001763 RID: 5987 RVA: 0x00099914 File Offset: 0x00097B14
		public string DisplayName { get; set; } = string.Empty;

		// Token: 0x1700066C RID: 1644
		// (get) Token: 0x06001766 RID: 5990 RVA: 0x00099950 File Offset: 0x00097B50
		// (set) Token: 0x06001765 RID: 5989 RVA: 0x0009993C File Offset: 0x00097B3C
		public string Name { get; set; } = string.Empty;

		// Token: 0x1700066D RID: 1645
		// (get) Token: 0x06001768 RID: 5992 RVA: 0x00099978 File Offset: 0x00097B78
		// (set) Token: 0x06001767 RID: 5991 RVA: 0x00099964 File Offset: 0x00097B64
		public OtherParamTypes OtherParamType { get; set; }

		// Token: 0x1700066E RID: 1646
		// (get) Token: 0x0600176A RID: 5994 RVA: 0x000999A0 File Offset: 0x00097BA0
		// (set) Token: 0x06001769 RID: 5993 RVA: 0x0009998C File Offset: 0x00097B8C
		public bool IsType { get; set; }

		// Token: 0x1700066F RID: 1647
		// (get) Token: 0x0600176C RID: 5996 RVA: 0x000999C8 File Offset: 0x00097BC8
		// (set) Token: 0x0600176B RID: 5995 RVA: 0x000999B4 File Offset: 0x00097BB4
		public bool IsReadOnly { get; set; }

		// Token: 0x17000670 RID: 1648
		// (get) Token: 0x0600176E RID: 5998 RVA: 0x000999F0 File Offset: 0x00097BF0
		// (set) Token: 0x0600176D RID: 5997 RVA: 0x000999DC File Offset: 0x00097BDC
		public bool IsShared { get; set; }

		// Token: 0x17000671 RID: 1649
		// (get) Token: 0x06001770 RID: 6000 RVA: 0x00099A18 File Offset: 0x00097C18
		// (set) Token: 0x0600176F RID: 5999 RVA: 0x00099A04 File Offset: 0x00097C04
		public string SharedGuid { get; set; }

		// Token: 0x17000672 RID: 1650
		// (get) Token: 0x06001772 RID: 6002 RVA: 0x00099A40 File Offset: 0x00097C40
		// (set) Token: 0x06001771 RID: 6001 RVA: 0x00099A2C File Offset: 0x00097C2C
		public long ScheduleId { get; set; }

		// Token: 0x17000673 RID: 1651
		// (get) Token: 0x06001774 RID: 6004 RVA: 0x00099A68 File Offset: 0x00097C68
		// (set) Token: 0x06001773 RID: 6003 RVA: 0x00099A54 File Offset: 0x00097C54
		[XmlArrayItem(typeof(int))]
		[XmlArrayItem(typeof(long))]
		public List<long> UsedParams { get; set; }

		// Token: 0x17000674 RID: 1652
		// (get) Token: 0x06001776 RID: 6006 RVA: 0x00099A90 File Offset: 0x00097C90
		// (set) Token: 0x06001775 RID: 6005 RVA: 0x00099A7C File Offset: 0x00097C7C
		public int StartIndex { get; set; }

		// Token: 0x17000675 RID: 1653
		// (get) Token: 0x06001778 RID: 6008 RVA: 0x00099AB8 File Offset: 0x00097CB8
		// (set) Token: 0x06001777 RID: 6007 RVA: 0x00099AA4 File Offset: 0x00097CA4
		public bool IsExportedByType { get; set; }

		// Token: 0x17000676 RID: 1654
		// (get) Token: 0x0600177A RID: 6010 RVA: 0x00099AE0 File Offset: 0x00097CE0
		// (set) Token: 0x06001779 RID: 6009 RVA: 0x00099ACC File Offset: 0x00097CCC
		public ExportTypes ExportType { get; set; }

		// Token: 0x17000677 RID: 1655
		// (get) Token: 0x0600177C RID: 6012 RVA: 0x00099B08 File Offset: 0x00097D08
		// (set) Token: 0x0600177B RID: 6011 RVA: 0x00099AF4 File Offset: 0x00097CF4
		public string ParamStorageType { get; set; }

		// Token: 0x17000678 RID: 1656
		// (get) Token: 0x0600177E RID: 6014 RVA: 0x00099B30 File Offset: 0x00097D30
		// (set) Token: 0x0600177D RID: 6013 RVA: 0x00099B1C File Offset: 0x00097D1C
		public bool IsYesNoParam { get; set; }

		// Token: 0x0600177F RID: 6015 RVA: 0x00099B44 File Offset: 0x00097D44
		internal bool \u001F(List<Parameter> \u001F)
		{
			List<Parameter>.Enumerator enumerator = \u0003\u0007\u0005.\u000A(\u001F);
			try
			{
				while (\u0006\u0007\u0005.\u000A(ref enumerator))
				{
					Parameter u001F = \u0012\u0007\u0005.\u000A(ref enumerator);
					if (\u0019\u001B\u0018.\u001D(this))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(ParamExportInfo.\u001F(List<Parameter>)).MethodHandle;
						}
						if (!\u001A\u0006\u0007.\u000A(\u000B\u001B\u0005.\u0007(this)))
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
							if (\u0002\u001B\u0005.\u000A(u001F))
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
								if (\u0008\u0013\u000A.\u000A(\u000B\u001B\u0005.\u0007(this), \u0016\u001B\u0005.\u000A(u001F).ToString()))
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
							}
						}
					}
					if (\u001A\u0008\u0019.\u000A(\u0005\u001B\u0005.\u0007(this), \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(u001F))))
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
			return false;
		}

		// Token: 0x06001780 RID: 6016 RVA: 0x00099C58 File Offset: 0x00097E58
		internal Parameter \u000A(Dictionary<long, List<Parameter>> \u001F)
		{
			KeyValuePair<long, List<Parameter>> keyValuePair = Enumerable.FirstOrDefault<KeyValuePair<long, List<Parameter>>>(\u001F, new Func<KeyValuePair<long, List<Parameter>>, bool>(this.\u0019));
			if (\u0002\u001B\u0018.\u000A(ref keyValuePair) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParamExportInfo.\u000A(Dictionary<long, List<Parameter>>)).MethodHandle;
				}
				if (Enumerable.Any<Parameter>(\u0002\u001B\u0018.\u000A(ref keyValuePair)))
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
					return \u000B\u001B\u0018.\u000A(\u0002\u001B\u0018.\u000A(ref keyValuePair), 0);
				}
			}
			return null;
		}

		// Token: 0x06001781 RID: 6017 RVA: 0x00099CC8 File Offset: 0x00097EC8
		internal static string \u0007(RevitParameter \u001F, int \u000A)
		{
			ParamExportInfo u001F = ParamExportInfo.\u001D(null, \u001F, \u0013\u000B\u000E.\u001F);
			\u000B\u000A\u0018.\u000A(u001F, \u000A);
			return \u0019\u0005\u0018.\u000A(u001F);
		}

		// Token: 0x06001782 RID: 6018 RVA: 0x00099CF4 File Offset: 0x00097EF4
		internal static ParamExportInfo \u001D(\u0015\u001C \u001F, RevitParameter \u000A, List<CategoryCollection> \u0007)
		{
			ParamExportInfo paramExportInfo = \u0002\u000A\u0018.\u000A();
			\u0006\u0017\u0018.\u000A(paramExportInfo, \u0004\u001E\u0018.\u0007(\u000A));
			\u0009\u0004\u0018.\u000A(paramExportInfo, \u001D\u001B\u0018.\u0007(\u000A));
			\u0014\u001B\u0005.\u000A(paramExportInfo, \u0004\u001B\u0018.\u0007(\u000A));
			\u0017\u001B\u0005.\u000A(paramExportInfo, \u0018\u000C\u0019.\u001D(\u000A));
			\u0020\u001B\u0005.\u000A(paramExportInfo, \u0005\u000C\u0019.\u001D(\u000A));
			\u0011\u001B\u0005.\u000A(paramExportInfo, \u001E\u001B\u0005.\u0007(\u000A));
			\u0008\u001B\u0005.\u000A(paramExportInfo, \u001B\u001B\u0005.\u0007(\u000A));
			\u000E\u001B\u0005.\u000A(paramExportInfo, \u000F\u0020\u0018.\u0007(\u000A));
			\u0010\u001B\u0005.\u000A(paramExportInfo, \u001F\u001B\u0018.\u0007(\u000A));
			\u0018\u001B\u0005.\u001D(paramExportInfo, \u0001\u0008\u0018.\u000A(\u000A));
			\u001C\u001B\u0005.\u000A(paramExportInfo, \u000D\u001B\u0005.\u000A(\u000A));
			\u0003\u001B\u0005.\u000A(paramExportInfo, \u0017\u0011\u0018.\u000A(\u000A));
			\u0018\u001B\u0005.\u001D(paramExportInfo, \u0001\u0008\u0018.\u000A(\u000A));
			\u0012\u001B\u0005.\u000A(paramExportInfo, \u001E\u0011\u0018.\u0007(\u000A));
			\u0006\u001B\u0005.\u000A(paramExportInfo, \u000F\u001B\u0005.\u000A(\u000A));
			if (\u0007 != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParamExportInfo.\u001D(\u0015\u001C, RevitParameter, List<CategoryCollection>)).MethodHandle;
				}
				ParamExportInfo.\u0007\u000D u0007_u000D = new ParamExportInfo.\u0007\u000D();
				ParamExportInfo.\u0007\u000D u0007_u000D2 = u0007_u000D;
				Func<CategoryCollection, long> func;
				if ((func = ParamExportInfo.<>c.\u000A) == null)
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
					func = (ParamExportInfo.<>c.\u000A = new Func<CategoryCollection, long>(ParamExportInfo.<>c.\u001F.\u001D));
				}
				u0007_u000D2.\u001F = Enumerable.ToList<long>(Enumerable.Select<CategoryCollection, long>(\u0007, func));
				object u001F = paramExportInfo;
				IEnumerable<KeyValuePair<long, List<long>>> enumerable = Enumerable.Where<KeyValuePair<long, List<long>>>(\u0002\u0020\u0018.\u000A(\u0006\u0020\u0018.\u000A(\u0012\u0020\u0018.\u0007(\u001F), \u000F\u0020\u0018.\u0007(\u000A))), new Func<KeyValuePair<long, List<long>>, bool>(u0007_u000D.\u000A));
				Func<KeyValuePair<long, List<long>>, IEnumerable<long>> func2;
				if ((func2 = ParamExportInfo.<>c.\u0007) == null)
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
					func2 = (ParamExportInfo.<>c.\u0007 = new Func<KeyValuePair<long, List<long>>, IEnumerable<long>>(ParamExportInfo.<>c.\u001F.\u0004));
				}
				\u0018\u001B\u0005.\u001D(u001F, Enumerable.ToList<long>(Enumerable.SelectMany<KeyValuePair<long, List<long>>, long>(enumerable, func2)));
			}
			return paramExportInfo;
		}

		// Token: 0x06001783 RID: 6019 RVA: 0x00099EA8 File Offset: 0x000980A8
		internal static ParamExportInfo \u0004(string \u001F)
		{
			ParamExportInfo result;
			try
			{
				result = JsonConvert.DeserializeObject<ParamExportInfo>(\u001F);
			}
			catch (Exception)
			{
				throw \u0013\u001B\u0005.\u000A(\u001A\u001B\u0005.\u000A());
			}
			return result;
		}

		// Token: 0x06001784 RID: 6020 RVA: 0x00099EE4 File Offset: 0x000980E4
		[CompilerGenerated]
		private bool \u0019(KeyValuePair<long, List<Parameter>> \u001F)
		{
			return this.\u001F(\u0002\u001B\u0018.\u000A(ref \u001F));
		}

		// Token: 0x0200091E RID: 2334
		[CompilerGenerated]
		private sealed class \u0007\u000D
		{
			// Token: 0x060051CA RID: 20938 RVA: 0x001E95F4 File Offset: 0x001E77F4
			internal bool \u000A(KeyValuePair<long, List<long>> \u001F)
			{
				return \u001A\u0008\u0019.\u000A(this.\u001F, \u0003\u0016\u0010.\u000A(ref \u001F));
			}

			// Token: 0x040023F4 RID: 9204
			public List<long> \u001F;
		}
	}
}
