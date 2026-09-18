using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.ExtensibleStorage;
using DiRoots.One.Commons.Models;
using Newtonsoft.Json;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x02000085 RID: 133
	[Schema("0B505B69-C6B0-4918-951F-91DB43672723", "StoredSpatialElementParameterData")]
	public sealed class SpatialElementParameter : ModelBase, IRevitEntity, IEquatable<SpatialElementParameter>, IComparable<SpatialElementParameter>
	{
		// Token: 0x060005CA RID: 1482 RVA: 0x000208B0 File Offset: 0x0001EAB0
		public SpatialElementParameter()
		{
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x000208E0 File Offset: 0x0001EAE0
		public SpatialElementParameter(Parameter parameter, List<Parameter> parameters)
		{
			Func<Parameter, string> func;
			if ((func = SpatialElementParameter.<>c.<>9__4_0) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElementParameter..ctor(Parameter, List<Parameter>)).MethodHandle;
				}
				func = (SpatialElementParameter.<>c.<>9__4_0 = ((Parameter x) => \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u0007(x))));
			}
			\u0002\u000A\u001D.\u0007(this, new ObservableCollection<Parameter>(Enumerable.OrderBy<Parameter, string>(parameters, func)));
			this._selectedParameter = Enumerable.FirstOrDefault<Parameter>(\u000B\u000A\u001D.\u000A(this));
			\u0016\u000A\u001D.\u0007(this, \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(parameter)));
			\u0005\u000A\u001D.\u0007(this, \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u0007(parameter)));
			\u0018\u000A\u001D.\u0007(this, \u0011\u001F\u001D.\u0007(parameter));
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060005CC RID: 1484 RVA: 0x000209A4 File Offset: 0x0001EBA4
		// (set) Token: 0x060005CD RID: 1485 RVA: 0x000209B8 File Offset: 0x0001EBB8
		[Field]
		public long Id { get; set; }

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060005CE RID: 1486 RVA: 0x000209CC File Offset: 0x0001EBCC
		// (set) Token: 0x060005CF RID: 1487 RVA: 0x000209E0 File Offset: 0x0001EBE0
		[Field]
		public string Name { get; set; } = "";

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060005D0 RID: 1488 RVA: 0x000209F4 File Offset: 0x0001EBF4
		// (set) Token: 0x060005D1 RID: 1489 RVA: 0x00020A08 File Offset: 0x0001EC08
		[Field]
		public string Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
				\u0007\u0013\u000A.\u000A(this, "Value");
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x060005D2 RID: 1490 RVA: 0x00020A28 File Offset: 0x0001EC28
		// (set) Token: 0x060005D3 RID: 1491 RVA: 0x00020A3C File Offset: 0x0001EC3C
		[Field]
		public int StorageType { get; set; } = 3;

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060005D4 RID: 1492 RVA: 0x00020A50 File Offset: 0x0001EC50
		// (set) Token: 0x060005D5 RID: 1493 RVA: 0x00020A64 File Offset: 0x0001EC64
		[XmlIgnore]
		[JsonIgnore]
		public Parameter SelectedParameter
		{
			get
			{
				return this._selectedParameter;
			}
			set
			{
				this._selectedParameter = value;
				\u0005\u000A\u001D.\u0007(this, \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u0007(\u0006\u000A\u001D.\u0007(this))));
				\u0016\u000A\u001D.\u0007(this, \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u0006\u000A\u001D.\u0007(this))));
				\u0018\u000A\u001D.\u0007(this, \u0011\u001F\u001D.\u0007(\u0006\u000A\u001D.\u0007(this)));
				\u0007\u0013\u000A.\u000A(this, "SelectedParameter");
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060005D6 RID: 1494 RVA: 0x00020AD0 File Offset: 0x0001ECD0
		// (set) Token: 0x060005D7 RID: 1495 RVA: 0x00020AE4 File Offset: 0x0001ECE4
		[XmlIgnore]
		[JsonIgnore]
		public ObservableCollection<Parameter> Parameters
		{
			get
			{
				return this._parameters;
			}
			set
			{
				this._parameters = value;
				\u0007\u0013\u000A.\u000A(this, "Parameters");
			}
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x00020B04 File Offset: 0x0001ED04
		public int CompareTo(SpatialElementParameter other)
		{
			return \u0013\u001F\u001D.\u000A(\u000F\u000A\u001D.\u001D(this), \u000F\u000A\u001D.\u0007(other));
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x00020B28 File Offset: 0x0001ED28
		public bool Equals(SpatialElementParameter other)
		{
			long num = \u0012\u000A\u001D.\u001D(this);
			if (\u000C\u001F\u001D.\u000A(ref num, \u0012\u000A\u001D.\u0007(other)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElementParameter.Equals(SpatialElementParameter)).MethodHandle;
				}
				return \u000D\u001F\u001D.\u000A(\u000F\u000A\u001D.\u001D(this), \u000F\u000A\u001D.\u0007(other));
			}
			return false;
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x00020B80 File Offset: 0x0001ED80
		public override bool Equals(object obj)
		{
			if (obj != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElementParameter.Equals(object)).MethodHandle;
				}
				if (\u0001\u001F\u001D.\u000A(\u0003\u0011\u000A.\u001D(this), \u0003\u0011\u000A.\u0007(obj)))
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
					SpatialElementParameter u001F = \u0002\u0007\u000E.\u001F(obj);
					if (\u0012\u000A\u001D.\u001D(this) == \u0012\u000A\u001D.\u0007(u001F))
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
						return \u0008\u0013\u000A.\u000A(\u000F\u000A\u001D.\u001D(this), \u000F\u000A\u001D.\u0007(u001F));
					}
					return false;
				}
			}
			return false;
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x00020C08 File Offset: 0x0001EE08
		public override int GetHashCode()
		{
			long num = \u0012\u000A\u001D.\u001D(this);
			int num2 = \u0007\u000A\u001D.\u000A(ref num);
			string text = \u000F\u000A\u001D.\u001D(this);
			int? num3;
			int? num4;
			if (text == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElementParameter.GetHashCode()).MethodHandle;
				}
				\u000B\u0007\u000E.\u001F(ref num3);
				num4 = num3;
			}
			else
			{
				num4 = new int?(\u001B\u0013\u000A.\u000A(text));
			}
			int? num5 = num4;
			int? num6;
			if (!\u000A\u000A\u001D.\u000A(ref num5))
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
				\u000B\u0007\u000E.\u001F(ref num3);
				num6 = num3;
			}
			else
			{
				num6 = new int?(num2 ^ \u0009\u001F\u001D.\u000A(ref num5));
			}
			num3 = num6;
			return \u0009\u001F\u001D.\u000A(ref num3);
		}

		// Token: 0x0400023D RID: 573
		private string _value = "";

		// Token: 0x0400023E RID: 574
		private Parameter _selectedParameter;

		// Token: 0x0400023F RID: 575
		private ObservableCollection<Parameter> _parameters;
	}
}
