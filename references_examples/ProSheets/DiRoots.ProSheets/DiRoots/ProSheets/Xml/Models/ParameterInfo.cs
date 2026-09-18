using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.ProSheets.Xml.Enums;
using DiRoots.ProSheets.Xml.Interfaces;

namespace DiRoots.ProSheets.Xml.Models
{
	// Token: 0x02000029 RID: 41
	public class ParameterInfo : ModelBase, IEquatable<ParameterInfo>, IParameterInfo
	{
		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600017D RID: 381 RVA: 0x00009618 File Offset: 0x00007818
		// (set) Token: 0x0600017E RID: 382 RVA: 0x0000962C File Offset: 0x0000782C
		public string Guid { get; set; } = \u001D\u001B\u0018.\u0018().ToString();

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600017F RID: 383 RVA: 0x00009640 File Offset: 0x00007840
		// (set) Token: 0x06000180 RID: 384 RVA: 0x00009654 File Offset: 0x00007854
		public long Id { get; set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000181 RID: 385 RVA: 0x00009668 File Offset: 0x00007868
		// (set) Token: 0x06000182 RID: 386 RVA: 0x0000967C File Offset: 0x0000787C
		public string Name { get; set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000183 RID: 387 RVA: 0x00009690 File Offset: 0x00007890
		public string DisplayName
		{
			get
			{
				return \u001A\u001B\u0018.\u0018(\u0009\u001B\u0018.\u0003(this));
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000184 RID: 388 RVA: 0x000096AC File Offset: 0x000078AC
		// (set) Token: 0x06000185 RID: 389 RVA: 0x000096C0 File Offset: 0x000078C0
		public string Value { get; set; } = \u0019\u0020\u0018.\u0013;

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000186 RID: 390 RVA: 0x000096D4 File Offset: 0x000078D4
		// (set) Token: 0x06000187 RID: 391 RVA: 0x000096E8 File Offset: 0x000078E8
		public ParameterType Type { get; set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000188 RID: 392 RVA: 0x000096FC File Offset: 0x000078FC
		[XmlIgnore]
		public bool IgnoreOnRemove
		{
			get
			{
				return \u0011\u001B\u0018.\u0003(this) == ParameterType.Custom;
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00009714 File Offset: 0x00007914
		public override bool Equals(object obj)
		{
			return \u000B\u001B\u0018.\u0018(this, \u0014\u001D\u000F.\u000C(obj));
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00009734 File Offset: 0x00007934
		public virtual bool Equals(ParameterInfo parameter)
		{
			if (parameter == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterInfo.Equals(ParameterInfo)).MethodHandle;
				}
				return false;
			}
			if (\u0011\u001B\u0018.\u0003(this) != \u0011\u001B\u0018.\u0014(parameter))
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
				return false;
			}
			ParameterType parameterType = \u0011\u001B\u0018.\u0003(this);
			bool flag;
			if (parameterType - ParameterType.Environment <= 1)
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
				flag = true;
			}
			else
			{
				flag = false;
			}
			if (flag)
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
				return \u000F\u0002\u0018.\u0018(\u0019\u001B\u0018.\u0003(this), \u0019\u001B\u0018.\u0014(parameter));
			}
			if (\u0020\u001B\u0018.\u0003(this) < 0L)
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
				if (\u0020\u001B\u0018.\u0003(this) == \u0020\u001B\u0018.\u0014(parameter))
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
			return \u000F\u0002\u0018.\u0018(\u0009\u001B\u0018.\u0003(this), \u0009\u001B\u0018.\u0014(parameter));
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00009808 File Offset: 0x00007A08
		public override int GetHashCode()
		{
			int hashCode = \u0011\u001B\u0018.\u0003(this).GetHashCode();
			if (\u0011\u001B\u0018.\u0003(this) != ParameterType.Environment)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterInfo.GetHashCode()).MethodHandle;
				}
				if (\u0011\u001B\u0018.\u0003(this) == ParameterType.Custom)
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
					if (\u0020\u001B\u0018.\u0003(this) < 0L)
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
						int num = hashCode;
						long num2 = \u0020\u001B\u0018.\u0003(this);
						return num ^ \u0004\u001B\u0018.\u0018(ref num2);
					}
					int num3 = hashCode;
					string text = \u0009\u001B\u0018.\u0003(this);
					int num4;
					if (text == null)
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
						num4 = 0;
					}
					else
					{
						num4 = \u0002\u001B\u0018.\u0018(text);
					}
					return num3 ^ num4;
				}
			}
			return hashCode ^ \u0002\u001B\u0018.\u0018(\u0019\u001B\u0018.\u0003(this));
		}

		// Token: 0x040000CF RID: 207
		[CompilerGenerated]
		private string Y;

		// Token: 0x040000D0 RID: 208
		[CompilerGenerated]
		private long J;

		// Token: 0x040000D1 RID: 209
		[CompilerGenerated]
		private string F;

		// Token: 0x040000D2 RID: 210
		[CompilerGenerated]
		private string O;

		// Token: 0x040000D3 RID: 211
		[CompilerGenerated]
		private ParameterType C;
	}
}
