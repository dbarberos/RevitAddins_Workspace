using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DiRoots.One.TableGen.TGRevitHelper.Script;

namespace A
{
	// Token: 0x02000143 RID: 323
	internal sealed class \u0020\u0016
	{
		// Token: 0x06000BCF RID: 3023 RVA: 0x0004B310 File Offset: 0x00049510
		public \u0020\u0016(int \u001F, int \u000A, ScriptType \u0007)
		{
			if (\u001F < 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0016..ctor(int, int, ScriptType)).MethodHandle;
				}
				throw new ArgumentOutOfRangeException("start");
			}
			if (\u000A <= 0)
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
				throw new ArgumentOutOfRangeException("length");
			}
			this.Start = \u001F;
			this.Length = \u000A;
			this.Type = \u0007;
		}

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x0004B380 File Offset: 0x00049580
		public int Start { get; }

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x06000BD1 RID: 3025 RVA: 0x0004B394 File Offset: 0x00049594
		public int Length { get; }

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x06000BD2 RID: 3026 RVA: 0x0004B3A8 File Offset: 0x000495A8
		public ScriptType Type { get; }

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x06000BD3 RID: 3027 RVA: 0x0004B3BC File Offset: 0x000495BC
		// (set) Token: 0x06000BD4 RID: 3028 RVA: 0x0004B3D0 File Offset: 0x000495D0
		public List<char> FailedCharacter { get; set; } = new List<char>();

		// Token: 0x040004B7 RID: 1207
		[CompilerGenerated]
		private readonly int \u001F;

		// Token: 0x040004B8 RID: 1208
		[CompilerGenerated]
		private readonly int \u000A;

		// Token: 0x040004B9 RID: 1209
		[CompilerGenerated]
		private readonly ScriptType \u0007;

		// Token: 0x040004BA RID: 1210
		[CompilerGenerated]
		private List<char> \u001D;
	}
}
