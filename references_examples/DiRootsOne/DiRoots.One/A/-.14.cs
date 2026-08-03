using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000012 RID: 18
	[CompilerGenerated]
	internal sealed class \u001C<\u001F> : IEnumerable, ICollection, IList, IEnumerable<!0>, IReadOnlyCollection<!0>, IReadOnlyList<!0>, ICollection<!0>, IList<!0>
	{
		// Token: 0x06000083 RID: 131 RVA: 0x000041D0 File Offset: 0x000023D0
		public \u001C(List<\u001F> \u001F)
		{
			this.\u001F = \u001F;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000041EC File Offset: 0x000023EC
		IEnumerator IEnumerable.\u000A()
		{
			return \u001D\u0011\u000A.\u000A(this.\u001F);
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00004208 File Offset: 0x00002408
		int ICollection.Count
		{
			get
			{
				return this.\u001F.Count;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00004224 File Offset: 0x00002424
		bool ICollection.IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00004234 File Offset: 0x00002434
		object ICollection.SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00004244 File Offset: 0x00002444
		void ICollection.\u0007(Array \u001F, int \u000A)
		{
			\u0004\u0011\u000A.\u000A(this.\u001F, \u001F, \u000A);
		}

		// Token: 0x17000038 RID: 56
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

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600008B RID: 139 RVA: 0x00004294 File Offset: 0x00002494
		bool IList.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600008C RID: 140 RVA: 0x000042A4 File Offset: 0x000024A4
		bool IList.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000042B4 File Offset: 0x000024B4
		int IList.\u001D(object \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000042C8 File Offset: 0x000024C8
		void IList.\u0004()
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000042DC File Offset: 0x000024DC
		bool IList.\u0019(object \u001F)
		{
			return \u0018\u0011\u000A.\u000A(this.\u001F, \u001F);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000042F8 File Offset: 0x000024F8
		int IList.\u0018(object \u001F)
		{
			return \u0005\u0011\u000A.\u000A(this.\u001F, \u001F);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004314 File Offset: 0x00002514
		void IList.\u0005(int \u001F, object \u000A)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00004328 File Offset: 0x00002528
		void IList.\u0016(object \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000433C File Offset: 0x0000253C
		void IList.\u000B(int \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00004350 File Offset: 0x00002550
		IEnumerator<\u001F> IEnumerable<!0>.\u0002()
		{
			return ((IEnumerable<!0>)this.\u001F).GetEnumerator();
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000095 RID: 149 RVA: 0x0000436C File Offset: 0x0000256C
		int IReadOnlyCollection<!0>.Count
		{
			get
			{
				return this.\u001F.Count;
			}
		}

		// Token: 0x1700003C RID: 60
		\u001F IReadOnlyList<!0>.this[int index]
		{
			get
			{
				return this.\u001F[index];
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000097 RID: 151 RVA: 0x000043A4 File Offset: 0x000025A4
		int ICollection<!0>.Count
		{
			get
			{
				return this.\u001F.Count;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000098 RID: 152 RVA: 0x000043C0 File Offset: 0x000025C0
		bool ICollection<!0>.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000043D0 File Offset: 0x000025D0
		void ICollection<!0>.\u0006(\u001F \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000043E4 File Offset: 0x000025E4
		void ICollection<!0>.\u000F()
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000043F8 File Offset: 0x000025F8
		bool ICollection<!0>.\u0012(\u001F \u001F)
		{
			return this.\u001F.Contains(\u001F);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00004414 File Offset: 0x00002614
		void ICollection<!0>.\u0003(\u001F[] \u001F, int \u000A)
		{
			this.\u001F.CopyTo(\u001F, \u000A);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00004430 File Offset: 0x00002630
		bool ICollection<!0>.\u001C(\u001F \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x1700003F RID: 63
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

		// Token: 0x060000A0 RID: 160 RVA: 0x00004474 File Offset: 0x00002674
		int IList<!0>.\u000D(\u001F \u001F)
		{
			return this.\u001F.IndexOf(\u001F);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00004490 File Offset: 0x00002690
		void IList<!0>.\u0010(int \u001F, \u001F \u000A)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000044A4 File Offset: 0x000026A4
		void IList<!0>.\u000E(int \u001F)
		{
			throw \u0019\u0011\u000A.\u000A();
		}

		// Token: 0x0400002B RID: 43
		[CompilerGenerated]
		private readonly List<\u001F> \u001F;
	}
}
