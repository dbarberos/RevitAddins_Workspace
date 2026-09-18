using System;
using System.Runtime.CompilerServices;
using A;
using DiRoots.ProSheets.Xml.Enums;

namespace DiRoots.ProSheets.Xml.Models
{
	// Token: 0x02000028 RID: 40
	public class ParameterDto : IEquatable<ParameterDto>, IEquatable<ParameterInfo>
	{
		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600016E RID: 366 RVA: 0x0000931C File Offset: 0x0000751C
		// (set) Token: 0x0600016F RID: 367 RVA: 0x00009330 File Offset: 0x00007530
		public long Id { get; set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000170 RID: 368 RVA: 0x00009344 File Offset: 0x00007544
		// (set) Token: 0x06000171 RID: 369 RVA: 0x00009358 File Offset: 0x00007558
		public string Name { get; set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000172 RID: 370 RVA: 0x0000936C File Offset: 0x0000756C
		// (set) Token: 0x06000173 RID: 371 RVA: 0x00009380 File Offset: 0x00007580
		public string ElementName { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000174 RID: 372 RVA: 0x00009394 File Offset: 0x00007594
		// (set) Token: 0x06000175 RID: 373 RVA: 0x000093A8 File Offset: 0x000075A8
		public string Value { get; set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000176 RID: 374 RVA: 0x000093BC File Offset: 0x000075BC
		// (set) Token: 0x06000177 RID: 375 RVA: 0x000093D0 File Offset: 0x000075D0
		public ParameterType Type { get; set; }

		// Token: 0x06000178 RID: 376 RVA: 0x000093E4 File Offset: 0x000075E4
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDto.Equals(ParameterInfo)).MethodHandle;
				}
				return false;
			}
			if (\u0015\u001B\u0018.\u0014(this) != \u0011\u001B\u0018.\u0014(parameter))
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
				return false;
			}
			if (\u001F\u001B\u0018.\u0014(this) < 0L)
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
				if (\u001F\u001B\u0018.\u0014(this) == \u0020\u001B\u0018.\u0014(parameter))
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
			return \u000F\u0002\u0018.\u0018(\u000A\u001B\u0018.\u0014(this), \u0009\u001B\u0018.\u0014(parameter));
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00009474 File Offset: 0x00007674
		public virtual bool Equals(ParameterDto parameter)
		{
			if (parameter == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDto.Equals(ParameterDto)).MethodHandle;
				}
				return false;
			}
			if (\u0015\u001B\u0018.\u0014(this) != \u0015\u001B\u0018.\u0003(parameter))
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
				return false;
			}
			if (\u001F\u001B\u0018.\u0014(this) < 0L)
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
				if (\u001F\u001B\u0018.\u0014(this) == \u001F\u001B\u0018.\u0003(parameter))
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
			return \u000F\u0002\u0018.\u0018(\u000A\u001B\u0018.\u0014(this), \u000A\u001B\u0018.\u0003(parameter));
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00009504 File Offset: 0x00007704
		public override bool Equals(object obj)
		{
			ParameterDto parameterDto = \u0018\u001D\u000F.\u000C(obj);
			if (parameterDto != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDto.Equals(object)).MethodHandle;
				}
				return \u001E\u001B\u0018.\u0018(this, parameterDto);
			}
			ParameterInfo parameterInfo = \u0014\u001D\u000F.\u000C(obj);
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
				return \u0017\u001B\u0018.\u0018(this, parameterInfo);
			}
			return false;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000955C File Offset: 0x0000775C
		public override int GetHashCode()
		{
			int hashCode = \u0015\u001B\u0018.\u0014(this).GetHashCode();
			if (\u001F\u001B\u0018.\u0014(this) < 0L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDto.GetHashCode()).MethodHandle;
				}
				int num = hashCode;
				long num2 = \u001F\u001B\u0018.\u0014(this);
				return num ^ \u0004\u001B\u0018.\u0018(ref num2);
			}
			int num3 = hashCode;
			string text = \u000A\u001B\u0018.\u0014(this);
			int num4;
			if (text == null)
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
				num4 = 0;
			}
			else
			{
				num4 = \u0002\u001B\u0018.\u0018(text);
			}
			return num3 ^ num4;
		}

		// Token: 0x040000CA RID: 202
		[CompilerGenerated]
		private long \u000C;

		// Token: 0x040000CB RID: 203
		[CompilerGenerated]
		private string \u0018;

		// Token: 0x040000CC RID: 204
		[CompilerGenerated]
		private string \u0014;

		// Token: 0x040000CD RID: 205
		[CompilerGenerated]
		private string \u0003;

		// Token: 0x040000CE RID: 206
		[CompilerGenerated]
		private ParameterType \u0016;
	}
}
