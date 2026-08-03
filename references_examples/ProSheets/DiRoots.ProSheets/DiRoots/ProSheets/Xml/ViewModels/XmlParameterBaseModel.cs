using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.ProSheets.Xml.Interfaces;
using DiRoots.ProSheets.Xml.Models;
using ProSheets.Extensions;

namespace DiRoots.ProSheets.Xml.ViewModels
{
	// Token: 0x02000023 RID: 35
	public class XmlParameterBaseModel : ParameterBaseModel
	{
		// Token: 0x0600014C RID: 332 RVA: 0x000085AC File Offset: 0x000067AC
		public XmlParameterBaseModel() : base(new List<IParameterInfo>(), new List<IParameterInfo>())
		{
		}

		// Token: 0x0600014D RID: 333 RVA: 0x000085CC File Offset: 0x000067CC
		public XmlParameterBaseModel(List<IParameterInfo> availableItems, List<IParameterInfo> selectedItems, ComboBoxViewModel parameterTypeFilter) : base(availableItems, selectedItems)
		{
			this.\u0015\u0018 = parameterTypeFilter;
			this.\u0015\u0018.\u0014\u0018 += this.\u001B\u000D;
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600014E RID: 334 RVA: 0x00008600 File Offset: 0x00006800
		// (set) Token: 0x0600014F RID: 335 RVA: 0x00008614 File Offset: 0x00006814
		public string ElementName
		{
			get
			{
				return this.\u001F\u0018;
			}
			set
			{
				this.\u001F\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "ElementName");
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000150 RID: 336 RVA: 0x00008634 File Offset: 0x00006834
		// (set) Token: 0x06000151 RID: 337 RVA: 0x00008648 File Offset: 0x00006848
		public string ElementValue
		{
			get
			{
				return this.\u0011\u0018;
			}
			set
			{
				this.\u0011\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "ElementValue");
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000152 RID: 338 RVA: 0x00008668 File Offset: 0x00006868
		// (set) Token: 0x06000153 RID: 339 RVA: 0x0000867C File Offset: 0x0000687C
		public ComboBoxViewModel ParameterTypeFilter
		{
			get
			{
				return this.\u0015\u0018;
			}
			set
			{
				this.\u0015\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "ParameterTypeFilter");
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000154 RID: 340 RVA: 0x0000869C File Offset: 0x0000689C
		// (set) Token: 0x06000155 RID: 341 RVA: 0x000086B0 File Offset: 0x000068B0
		public XmlExportOptions ExportOptions
		{
			get
			{
				return this.\u0017\u0018;
			}
			set
			{
				this.\u0017\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "ExportOptions");
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000086D0 File Offset: 0x000068D0
		private void \u001B\u000D(object \u000C)
		{
			\u0014\u0008\u0018.\u0018(this);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x000086E4 File Offset: 0x000068E4
		private void \u0005\u000D()
		{
			ICollectionView u000C = \u0010\u0006\u0018.\u0018(\u000C\u0008\u0018.\u0014(this));
			\u001B\u0008\u0018.\u0018(\u0005\u0008\u0018.\u0018(u000C), new SortDescription("Type", ListSortDirection.Ascending));
			\u001B\u0008\u0018.\u0018(\u0005\u0008\u0018.\u0018(u000C), new SortDescription("DisplayName", ListSortDirection.Ascending));
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00008730 File Offset: 0x00006930
		protected override bool ParameterFilter(object obj)
		{
			bool flag = \u0003\u0001\u0018.\u0018(this, obj);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(XmlParameterBaseModel.ParameterFilter(object)).MethodHandle;
				}
				if (this.\u0015\u0018 != null)
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
					IParameterInfo parameterInfo = \u0010\u0004\u000F.\u000C(obj);
					if (parameterInfo != null)
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
						if (\u0014\u0001\u0018.\u0018(this.\u0015\u0018))
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
							flag = true;
						}
						else
						{
							IEnumerable<EnumInfo> enumerable = Enumerable.Cast<EnumInfo>(\u0018\u0001\u0018.\u0018(this.\u0015\u0018, \u001A\u0004\u000F.\u000C));
							Func<EnumInfo, int> func;
							if ((func = XmlParameterBaseModel.<>c.\u0018) == null)
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
								func = (XmlParameterBaseModel.<>c.\u0018 = new Func<EnumInfo, int>(XmlParameterBaseModel.<>c.\u000C.\u0003));
							}
							if (!\u000E\u0008\u0018.\u0018(Enumerable.ToList<int>(Enumerable.Select<EnumInfo, int>(enumerable, func)), (int)\u000C\u0001\u0018.\u0018(parameterInfo)))
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
								flag = false;
							}
						}
					}
				}
			}
			return flag;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0000881C File Offset: 0x00006A1C
		[BindableMethod("OnAddCustomParameter")]
		public void OnAddCustomParameter()
		{
			if (!\u001F\u001A\u0018.\u0018(\u001C\u0001\u0018.\u0018(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(XmlParameterBaseModel.OnAddCustomParameter()).MethodHandle;
				}
				if (!\u001F\u001A\u0018.\u0018(\u000D\u0001\u0018.\u0018(this)))
				{
					\u000D\u0008\u0018.\u0018(\u0012\u0008\u0018.\u0014(this), \u0012\u0001\u0018.\u0018(\u001C\u0001\u0018.\u0018(this), \u000D\u0001\u0018.\u0018(this)));
					\u000F\u0001\u0018.\u0018(this, string.Empty);
					\u0016\u0001\u0018.\u0018(this, string.Empty);
					return;
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
		}

		// Token: 0x0600015A RID: 346 RVA: 0x000088A4 File Offset: 0x00006AA4
		public override void Reload()
		{
			\u001A\u0008\u0018.\u0003(this);
			this.\u0005\u000D();
			\u0009\u0001\u0018.\u0018(this.\u0015\u0018);
			\u0014\u0008\u0018.\u0018(this);
			object u000C = Enumerable.ToList<XmlParameterInfo>(Enumerable.Cast<XmlParameterInfo>(\u0008\u0008\u0018.\u0018(this)));
			Action<XmlParameterInfo> u;
			if ((u = XmlParameterBaseModel.<>c.\u0014) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(XmlParameterBaseModel.Reload()).MethodHandle;
				}
				u = (XmlParameterBaseModel.<>c.\u0014 = new Action<XmlParameterInfo>(XmlParameterBaseModel.<>c.\u000C.\u0016));
			}
			\u0013\u0001\u0018.\u0018(u000C, u);
		}

		// Token: 0x040000A2 RID: 162
		private string \u001F\u0018;

		// Token: 0x040000A3 RID: 163
		private string \u0011\u0018;

		// Token: 0x040000A4 RID: 164
		private ComboBoxViewModel \u0015\u0018;

		// Token: 0x040000A5 RID: 165
		private XmlExportOptions \u0017\u0018;
	}
}
