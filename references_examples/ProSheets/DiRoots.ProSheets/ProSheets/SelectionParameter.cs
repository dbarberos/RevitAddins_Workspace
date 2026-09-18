using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Xml.Serialization;
using A;
using Autodesk.Revit.DB;
using ProSheets.Commons.CustomNameManageWindow.Models;
using ProSheets.Commons.CustomNameManageWindow.Models.Interfaces;

namespace ProSheets
{
	// Token: 0x0200007B RID: 123
	[Serializable]
	public class SelectionParameter : IEquatable<SelectionParameter>, IParameterModel
	{
		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06000792 RID: 1938 RVA: 0x000277B4 File Offset: 0x000259B4
		// (set) Token: 0x06000793 RID: 1939 RVA: 0x000277C8 File Offset: 0x000259C8
		public string GUID { get; set; } = \u001D\u001B\u0018.\u0018().ToString();

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x06000794 RID: 1940 RVA: 0x000277DC File Offset: 0x000259DC
		// (set) Token: 0x06000795 RID: 1941 RVA: 0x000277F0 File Offset: 0x000259F0
		[XmlIgnore]
		public Brush ForeColor { get; set; } = \u0016\u0012\u0003.\u0018();

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x06000796 RID: 1942 RVA: 0x00027804 File Offset: 0x00025A04
		[XmlIgnore]
		public string DisplayName
		{
			get
			{
				return \u001A\u001B\u0018.\u0018(\u000F\u0012\u0003.\u0018(this));
			}
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x06000797 RID: 1943 RVA: 0x00027820 File Offset: 0x00025A20
		// (set) Token: 0x06000798 RID: 1944 RVA: 0x00027834 File Offset: 0x00025A34
		public BuiltInParameter BuiltinType { get; set; } = -1L;

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06000799 RID: 1945 RVA: 0x00027848 File Offset: 0x00025A48
		// (set) Token: 0x0600079A RID: 1946 RVA: 0x0002785C File Offset: 0x00025A5C
		public SelectionParameterType Type { get; set; }

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x0600079B RID: 1947 RVA: 0x00027870 File Offset: 0x00025A70
		// (set) Token: 0x0600079C RID: 1948 RVA: 0x00027884 File Offset: 0x00025A84
		[XmlAttribute("xml:space=preserve")]
		public string Name { get; set; }

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x0600079D RID: 1949 RVA: 0x00027898 File Offset: 0x00025A98
		// (set) Token: 0x0600079E RID: 1950 RVA: 0x000278AC File Offset: 0x00025AAC
		public int AutoNumberOffset { get; set; }

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x0600079F RID: 1951 RVA: 0x000278C0 File Offset: 0x00025AC0
		// (set) Token: 0x060007A0 RID: 1952 RVA: 0x000278D4 File Offset: 0x00025AD4
		public bool IsSelected { get; set; }

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x060007A1 RID: 1953 RVA: 0x000278E8 File Offset: 0x00025AE8
		// (set) Token: 0x060007A2 RID: 1954 RVA: 0x000278FC File Offset: 0x00025AFC
		public bool IsProjectParameter { get; set; }

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x060007A3 RID: 1955 RVA: 0x00027910 File Offset: 0x00025B10
		// (set) Token: 0x060007A4 RID: 1956 RVA: 0x00027924 File Offset: 0x00025B24
		[XmlIgnore]
		public int SortingIndex { get; set; }

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x060007A5 RID: 1957 RVA: 0x00027938 File Offset: 0x00025B38
		[XmlIgnore]
		public bool IgnoreOnRemove
		{
			get
			{
				if (\u000B\u0020\u0014.\u0003(this) != SelectionParameterType.CustomText)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionParameter.get_IgnoreOnRemove()).MethodHandle;
					}
					if (\u000B\u0020\u0014.\u0003(this) != SelectionParameterType.CustemSeparator)
					{
						return false;
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
				return true;
			}
		}

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x060007A6 RID: 1958 RVA: 0x0002797C File Offset: 0x00025B7C
		// (set) Token: 0x060007A7 RID: 1959 RVA: 0x00027990 File Offset: 0x00025B90
		public string ParameterName { get; set; }

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x060007A8 RID: 1960 RVA: 0x000279A4 File Offset: 0x00025BA4
		// (set) Token: 0x060007A9 RID: 1961 RVA: 0x000279B8 File Offset: 0x00025BB8
		public long ParameterId { get; set; }

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x060007AA RID: 1962 RVA: 0x000279CC File Offset: 0x00025BCC
		// (set) Token: 0x060007AB RID: 1963 RVA: 0x000279E0 File Offset: 0x00025BE0
		public StorageType StorageType { get; set; }

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x060007AC RID: 1964 RVA: 0x000279F4 File Offset: 0x00025BF4
		// (set) Token: 0x060007AD RID: 1965 RVA: 0x00027A08 File Offset: 0x00025C08
		public List<ParameterModel> ParameterModels { get; set; }

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x060007AE RID: 1966 RVA: 0x00027A1C File Offset: 0x00025C1C
		// (set) Token: 0x060007AF RID: 1967 RVA: 0x00027A30 File Offset: 0x00025C30
		public bool IsCustomParameter { get; set; }

		// Token: 0x060007B0 RID: 1968 RVA: 0x00027A44 File Offset: 0x00025C44
		public bool Equals(SelectionParameter parameter)
		{
			if (\u000B\u0020\u0014.\u0003(this) == \u000B\u0020\u0014.\u0014(parameter))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionParameter.Equals(SelectionParameter)).MethodHandle;
				}
				if (\u000B\u0020\u0014.\u0003(this) != SelectionParameterType.CustemSeparator)
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
					if (\u000B\u0020\u0014.\u0003(this) == SelectionParameterType.CustomText)
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
						if (\u000A\u000B\u0014.\u0003(this) != -1L)
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
							if (\u000A\u000B\u0014.\u0003(this) == \u000A\u000B\u0014.\u0014(parameter))
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
								return true;
							}
						}
						if (\u000F\u0002\u0018.\u0018(\u0002\u0020\u0014.\u0003(this), \u0002\u0020\u0014.\u0014(parameter)))
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
							return true;
						}
						return false;
					}
				}
				return \u000F\u0002\u0018.\u0018(\u0012\u0012\u0003.\u0003(this), \u0012\u0012\u0003.\u0014(parameter));
			}
			return false;
		}
	}
}
