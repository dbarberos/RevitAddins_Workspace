using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000013 RID: 19
	[CompilerGenerated]
	internal sealed class \u0010<\u000A> : IEnumerable, ICollection, IList, IEnumerable<\u000A>, IReadOnlyCollection<\u000A>, IReadOnlyList<\u000A>, ICollection<\u000A>, IList<\u000A>
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x000044B8 File Offset: 0x000026B8
		public \u0010(\u000A \u001F)
		{
			this.\u001F = \u001F;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000044D4 File Offset: 0x000026D4
		IEnumerator IEnumerable.\u000A()
		{
			return new \u0010<\u000A>.\u000D(this.\u001F);
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x000044EC File Offset: 0x000026EC
		int ICollection.Count
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x000044FC File Offset: 0x000026FC
		bool ICollection.IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x0000450C File Offset: 0x0000270C
		object ICollection.SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000451C File Offset: 0x0000271C
		void ICollection.\u0007(Array \u001F, int \u000A)
		{
			\u0016\u0011\u000A.\u000A(\u001F, this.\u001F, \u000A);
		}

		// Token: 0x17000043 RID: 67
		object IList.this[int index]
		{
			get
			{
				if (index != 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010.System.Collections.IList.get_Item(int)).MethodHandle;
					}
					throw \u000B\u0011\u000A.\u000A();
				}
				return this.\u001F;
			}
			set
			{
				throw \u0019\u0011\u000A.\u000A();
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00004588 File Offset: 0x00002788
		bool IList.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00004598 File Offset: 0x00002798
		bool IList.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000045A8 File Offset: 0x000027A8
		int IList.\u001D(object \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000045BC File Offset: 0x000027BC
		void IList.\u0004()
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000045D0 File Offset: 0x000027D0
		bool IList.\u0019(object \u001F)
		{
			return EqualityComparer<\u000A>.Default.Equals(this.\u001F, (\u000A)((object)\u001F));
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000045F8 File Offset: 0x000027F8
		int IList.\u0018(object \u001F)
		{
			if (!EqualityComparer<\u000A>.Default.Equals(this.\u001F, (\u000A)((object)\u001F)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010.\u0018(object)).MethodHandle;
				}
				return -1;
			}
			return 0;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00004638 File Offset: 0x00002838
		void IList.\u0005(int \u001F, object \u000A)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000464C File Offset: 0x0000284C
		void IList.\u0016(object \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00004660 File Offset: 0x00002860
		void IList.\u000B(int \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00004674 File Offset: 0x00002874
		IEnumerator<\u000A> IEnumerable<!0>.\u0002()
		{
			return new \u0010<\u000A>.\u000D(this.\u001F);
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x0000468C File Offset: 0x0000288C
		int IReadOnlyCollection<!0>.Count
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000047 RID: 71
		\u000A IReadOnlyList<!0>.this[int index]
		{
			get
			{
				if (index != 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010.System.Collections.Generic.IReadOnlyList<T>.get_Item(int)).MethodHandle;
					}
					throw \u000B\u0011\u000A.\u000A();
				}
				return this.\u001F;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x000046D0 File Offset: 0x000028D0
		int ICollection<!0>.Count
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x000046E0 File Offset: 0x000028E0
		bool ICollection<!0>.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000046F0 File Offset: 0x000028F0
		void ICollection<!0>.\u0006(\u000A \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00004704 File Offset: 0x00002904
		void ICollection<!0>.\u000F()
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00004718 File Offset: 0x00002918
		bool ICollection<!0>.\u0012(\u000A \u001F)
		{
			return EqualityComparer<\u000A>.Default.Equals(this.\u001F, \u001F);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000473C File Offset: 0x0000293C
		void ICollection<!0>.\u0003(\u000A[] \u001F, int \u000A)
		{
			\u001F[\u000A] = this.\u001F;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00004758 File Offset: 0x00002958
		bool ICollection<!0>.\u001C(\u000A \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x1700004A RID: 74
		\u000A IList<!0>.this[int index]
		{
			get
			{
				if (index != 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010.System.Collections.Generic.IList<T>.get_Item(int)).MethodHandle;
					}
					throw \u000B\u0011\u000A.\u000A();
				}
				return this.\u001F;
			}
			set
			{
				throw \u0019\u0011\u000A.\u000A();
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000047B4 File Offset: 0x000029B4
		int IList<!0>.\u000D(\u000A \u001F)
		{
			if (!EqualityComparer<\u000A>.Default.Equals(this.\u001F, \u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010.\u000D(\u000A)).MethodHandle;
				}
				return -1;
			}
			return 0;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000047F0 File Offset: 0x000029F0
		void IList<!0>.\u0010(int \u001F, \u000A \u000A)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004804 File Offset: 0x00002A04
		void IList<!0>.\u000E(int \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x0400002C RID: 44
		[CompilerGenerated]
		private readonly \u000A \u001F;

		// Token: 0x02000762 RID: 1890
		private sealed class \u000D : IDisposable, IEnumerator, IEnumerator<\u001F>
		{
			// Token: 0x06004A77 RID: 19063 RVA: 0x001D6ACC File Offset: 0x001D4CCC
			public \u000D(\u001F \u001F)
			{
				this.\u001D = \u001F;
			}

			// Token: 0x1700135F RID: 4959
			// (get) Token: 0x06004A78 RID: 19064 RVA: 0x001D6AE8 File Offset: 0x001D4CE8
			object IEnumerator.\u0007
			{
				get
				{
					return this.\u001F;
				}
			}

			// Token: 0x17001360 RID: 4960
			// (get) Token: 0x06004A79 RID: 19065 RVA: 0x001D6B00 File Offset: 0x001D4D00
			\u001F IEnumerator<!0>.\u001D
			{
				get
				{
					return this.\u001F;
				}
			}

			// Token: 0x06004A7A RID: 19066 RVA: 0x001D6B14 File Offset: 0x001D4D14
			bool IEnumerator.\u0004()
			{
				if (!this.\u000A)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010.\u000D.\u0004()).MethodHandle;
					}
					return this.\u000A = true;
				}
				return false;
			}

			// Token: 0x06004A7B RID: 19067 RVA: 0x001D6B48 File Offset: 0x001D4D48
			void IEnumerator.\u0019()
			{
				this.\u000A = false;
			}

			// Token: 0x06004A7C RID: 19068 RVA: 0x001D6B5C File Offset: 0x001D4D5C
			void IDisposable.\u0018()
			{
			}

			// Token: 0x04001DAD RID: 7597
			[CompilerGenerated]
			private readonly \u001F \u001F;

			// Token: 0x04001DAE RID: 7598
			[CompilerGenerated]
			private bool \u000A;
		}
	}
}
