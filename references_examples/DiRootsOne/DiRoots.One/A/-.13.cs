using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000011 RID: 17
	[CompilerGenerated]
	internal sealed class \u0003<\u001F> : IEnumerable, ICollection, IList, IEnumerable<!0>, IReadOnlyCollection<!0>, IReadOnlyList<!0>, ICollection<!0>, IList<!0>
	{
		// Token: 0x06000063 RID: 99 RVA: 0x00003EF4 File Offset: 0x000020F4
		public \u0003(\u001F[] \u001F)
		{
			this.\u001F = \u001F;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003F10 File Offset: 0x00002110
		IEnumerator IEnumerable.\u000A()
		{
			return \u001D\u0011\u000A.\u000A(this.\u001F);
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00003F2C File Offset: 0x0000212C
		int ICollection.Count
		{
			get
			{
				return this.\u001F.Length;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00003F44 File Offset: 0x00002144
		bool ICollection.IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00003F54 File Offset: 0x00002154
		object ICollection.SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003F64 File Offset: 0x00002164
		void ICollection.\u0007(Array \u001F, int \u000A)
		{
			\u0004\u0011\u000A.\u000A(this.\u001F, \u001F, \u000A);
		}

		// Token: 0x1700002D RID: 45
		object IList.this[int index]
		{
			get
			{
				return this.\u001F[index];
			}
			set
			{
				throw \u0019\u0011\u000A.\u000A();
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00003FB4 File Offset: 0x000021B4
		bool IList.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00003FC4 File Offset: 0x000021C4
		bool IList.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003FD4 File Offset: 0x000021D4
		int IList.\u001D(object \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003FE8 File Offset: 0x000021E8
		void IList.\u0004()
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003FFC File Offset: 0x000021FC
		bool IList.\u0019(object \u001F)
		{
			return \u0018\u0011\u000A.\u000A(this.\u001F, \u001F);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00004018 File Offset: 0x00002218
		int IList.\u0018(object \u001F)
		{
			return \u0005\u0011\u000A.\u000A(this.\u001F, \u001F);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00004034 File Offset: 0x00002234
		void IList.\u0005(int \u001F, object \u000A)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00004048 File Offset: 0x00002248
		void IList.\u0016(object \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000405C File Offset: 0x0000225C
		void IList.\u000B(int \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00004070 File Offset: 0x00002270
		IEnumerator<\u001F> IEnumerable<!0>.\u0002()
		{
			return this.\u001F.GetEnumerator();
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000075 RID: 117 RVA: 0x0000408C File Offset: 0x0000228C
		int IReadOnlyCollection<!0>.Count
		{
			get
			{
				return this.\u001F.Length;
			}
		}

		// Token: 0x17000031 RID: 49
		\u001F IReadOnlyList<!0>.this[int index]
		{
			get
			{
				return this.\u001F[index];
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000077 RID: 119 RVA: 0x000040C0 File Offset: 0x000022C0
		int ICollection<!0>.Count
		{
			get
			{
				return this.\u001F.Length;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000078 RID: 120 RVA: 0x000040D8 File Offset: 0x000022D8
		bool ICollection<!0>.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000040E8 File Offset: 0x000022E8
		void ICollection<!0>.\u0006(\u001F \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000040FC File Offset: 0x000022FC
		void ICollection<!0>.\u000F()
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00004110 File Offset: 0x00002310
		bool ICollection<!0>.\u0012(\u001F \u001F)
		{
			return this.\u001F.Contains(\u001F);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x0000412C File Offset: 0x0000232C
		void ICollection<!0>.\u0003(\u001F[] \u001F, int \u000A)
		{
			this.\u001F.CopyTo(\u001F, \u000A);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00004148 File Offset: 0x00002348
		bool ICollection<!0>.\u001C(\u001F \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x17000034 RID: 52
		\u001F IList<!0>.this[int index]
		{
			get
			{
				return this.\u001F[index];
			}
			set
			{
				throw \u0019\u0011\u000A.\u000A();
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000418C File Offset: 0x0000238C
		int IList<!0>.\u000D(\u001F \u001F)
		{
			return this.\u001F.IndexOf(\u001F);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000041A8 File Offset: 0x000023A8
		void IList<!0>.\u0010(int \u001F, \u001F \u000A)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000041BC File Offset: 0x000023BC
		void IList<!0>.\u000E(int \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x0400002A RID: 42
		[CompilerGenerated]
		private readonly \u001F[] \u001F;
	}
}
