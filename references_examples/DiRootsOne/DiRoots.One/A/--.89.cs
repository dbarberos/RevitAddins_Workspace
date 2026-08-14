using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DiRoots.One.TableGen.TGRevitHelper.Script;

namespace A
{
	// Token: 0x02000142 RID: 322
	internal sealed class \u001E\u0016
	{
		// Token: 0x06000BC7 RID: 3015 RVA: 0x0004B0A8 File Offset: 0x000492A8
		public \u001E\u0016(string \u001F)
		{
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0016..ctor(string)).MethodHandle;
				}
				throw new ArgumentNullException("text");
			}
			this.Text = \u001F;
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06000BC8 RID: 3016 RVA: 0x0004B0FC File Offset: 0x000492FC
		public string Text { get; }

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06000BC9 RID: 3017 RVA: 0x0004B110 File Offset: 0x00049310
		public IReadOnlyList<\u0020\u0016> \u001D
		{
			get
			{
				return this.\u000A;
			}
		}

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x06000BCA RID: 3018 RVA: 0x0004B124 File Offset: 0x00049324
		// (set) Token: 0x06000BCB RID: 3019 RVA: 0x0004B138 File Offset: 0x00049338
		public List<\u0020\u0016> FailedRuns { get; set; } = new List<\u0020\u0016>();

		// Token: 0x06000BCC RID: 3020 RVA: 0x0004B14C File Offset: 0x0004934C
		public \u001E\u0016 \u0004(int \u001F, int \u000A)
		{
			\u0010\u0015\u0004.\u000A(this.\u000A, new \u0020\u0016(\u001F, \u000A, ScriptType.Superscript));
			return this;
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x0004B170 File Offset: 0x00049370
		public \u001E\u0016 \u0019(int \u001F, int \u000A)
		{
			\u0010\u0015\u0004.\u000A(this.\u000A, new \u0020\u0016(\u001F, \u000A, ScriptType.Subscript));
			return this;
		}

		// Token: 0x06000BCE RID: 3022 RVA: 0x0004B194 File Offset: 0x00049394
		public IEnumerable<\u0020\u0016> \u0018()
		{
			List<\u0020\u0016>.Enumerator enumerator = \u0017\u0015\u0004.\u000A(this.\u000A);
			try
			{
				while (\u001E\u0015\u0004.\u000A(ref enumerator))
				{
					\u0020\u0016 u001F = \u0020\u0015\u0004.\u000A(ref enumerator);
					if (\u001D\u0015\u0004.\u000A(u001F) + \u0007\u0015\u0004.\u000A(u001F) > \u001C\u000F\u0007.\u0007(\u000A\u0014\u001D.\u0007(this)))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0016.\u0018()).MethodHandle;
						}
						throw \u0011\u0015\u0004.\u000A(\u001E\u0007\u0007.\u000A("Run out of range: start={0}, length={1}, textLen={2}", \u001D\u0015\u0004.\u000A(u001F), \u0007\u0015\u0004.\u000A(u001F), \u001C\u000F\u0007.\u0007(\u000A\u0014\u001D.\u0007(this))));
					}
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			IEnumerable<\u0020\u0016> u000A = this.\u000A;
			Func<\u0020\u0016, int> func;
			if ((func = \u001E\u0016.<>c.\u000A) == null)
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
				func = (\u001E\u0016.<>c.\u000A = new Func<\u0020\u0016, int>(\u001E\u0016.<>c.\u001F.\u0007));
			}
			\u0020\u0016[] array = Enumerable.ToArray<\u0020\u0016>(Enumerable.OrderBy<\u0020\u0016, int>(u000A, func));
			for (int i = 0; i < (int)\u000F\u0018\u000E.\u001F(array) - 1; i++)
			{
				\u0020\u0016 u001F2 = array[i];
				\u0020\u0016 u001F3 = array[i + 1];
				if (\u001D\u0015\u0004.\u000A(u001F2) + \u0007\u0015\u0004.\u000A(u001F2) > \u001D\u0015\u0004.\u000A(u001F3))
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
					throw \u0011\u0015\u0004.\u000A("Overlapping runs are not allowed. Merge/split them first.");
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
			return array;
		}

		// Token: 0x040004B4 RID: 1204
		[CompilerGenerated]
		private readonly string \u001F;

		// Token: 0x040004B5 RID: 1205
		private readonly List<\u0020\u0016> \u000A = new List<\u0020\u0016>();

		// Token: 0x040004B6 RID: 1206
		[CompilerGenerated]
		private List<\u0020\u0016> \u0007;
	}
}
