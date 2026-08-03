using System;
using System.IO;
using System.IO.Packaging;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x020000B3 RID: 179
	internal class \u0014\u0004 : \u0013\u0004, IDisposable
	{
		// Token: 0x060006F5 RID: 1781 RVA: 0x00028DDC File Offset: 0x00026FDC
		public \u0014\u0004(string \u001F) : base(\u001F)
		{
			if (!\u0010\u0002\u001D.\u000A(\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u0004..ctor(string)).MethodHandle;
				}
				throw new FileNotFoundException(\u0017\u0006\u0007.\u000A("The file \"{0}\" was not found.", \u001F));
			}
			base.\u0002\u000A = \u001F;
			this.\u0018\u000A();
			if (!base.\u000B\u000A)
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
				if (\u000D\u0002\u001D.\u000A(this) != null)
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
					this.\u0016\u000A(\u000D\u0002\u001D.\u000A(this));
				}
				return;
			}
			this.\u0004\u000A = new \u0020\u0004(base.\u0002\u000A, \u000D\u0002\u001D.\u000A(this));
			if (\u000D\u0002\u001D.\u000A(this) != null)
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
				this.\u0016\u000A(\u000D\u0002\u001D.\u000A(this));
			}
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00028EA4 File Offset: 0x000270A4
		protected virtual void \u001C(bool \u001F)
		{
			if (!this.\u0002)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u0004.\u001C(bool)).MethodHandle;
				}
				if (\u001F)
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
					if (\u000D\u0002\u001D.\u000A(this) != null)
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
						this.\u0016\u000A(\u000D\u0002\u001D.\u000A(this));
					}
				}
				this.\u0002 = true;
			}
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00028F04 File Offset: 0x00027104
		public void Dispose()
		{
			this.\u001C(true);
			\u000E\u0002\u001D.\u000A(this);
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x060006F8 RID: 1784 RVA: 0x00028F20 File Offset: 0x00027120
		// (set) Token: 0x060006F9 RID: 1785 RVA: 0x00028F60 File Offset: 0x00027160
		public \u0020\u0004 \u0004\u000A
		{
			get
			{
				if (!this.\u0016.\u000B\u000A)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u0004.get_\u0004\u000A()).MethodHandle;
					}
					this.\u0016.\u0015();
				}
				return this.\u0016;
			}
			set
			{
				this.\u0016 = value;
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x060006FA RID: 1786 RVA: 0x00028F74 File Offset: 0x00027174
		// (set) Token: 0x060006FB RID: 1787 RVA: 0x00028FB4 File Offset: 0x000271B4
		public \u0017\u0004 \u0019\u000A
		{
			get
			{
				if (!this.\u000B.\u000B\u000A)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u0004.get_\u0019\u000A()).MethodHandle;
					}
					this.\u000B.\u0015();
				}
				return this.\u000B;
			}
			set
			{
				this.\u000B = value;
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x060006FC RID: 1788 RVA: 0x00028FC8 File Offset: 0x000271C8
		// (set) Token: 0x060006FD RID: 1789 RVA: 0x00028FDC File Offset: 0x000271DC
		private StorageInfo StorageRoot { get; set; }

		// Token: 0x060006FE RID: 1790 RVA: 0x00028FF0 File Offset: 0x000271F0
		private void \u0018\u000A()
		{
			base.\u000B\u000A = false;
			try
			{
				\u0008\u0002\u001D.\u000A(this, this.\u0005\u000A(base.\u0002\u000A));
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x00029030 File Offset: 0x00027230
		private StorageInfo \u0005\u000A(string \u001F)
		{
			try
			{
				StorageInfo u001F = null;
				string u000A = "Open";
				object[] array = \u0004\u0015\u0010.\u001F(4);
				array[0] = \u001F;
				array[1] = FileMode.Open;
				array[2] = FileAccess.Read;
				array[3] = FileShare.Read;
				StorageInfo storageInfo = \u001F\u001D\u000E.\u001F(base.\u0012\u000A(u001F, u000A, array));
				if (storageInfo == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u0004.\u0005\u000A(string)).MethodHandle;
					}
					base.\u000B\u000A = false;
					throw \u0008\u0013\u0007.\u000A(\u0017\u0006\u0007.\u000A("Unable to open \"{0}\" as a structured storage file.", \u001F));
				}
				base.\u000B\u000A = true;
				return storageInfo;
			}
			catch (Exception)
			{
				base.\u000B\u000A = false;
			}
			return null;
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x000290D4 File Offset: 0x000272D4
		private void \u0016\u000A(StorageInfo \u001F)
		{
			base.\u0012\u000A(\u001F, "Close", Array.Empty<object>());
		}

		// Token: 0x040002CE RID: 718
		private \u0020\u0004 \u0016;

		// Token: 0x040002CF RID: 719
		private \u0017\u0004 \u000B;

		// Token: 0x040002D0 RID: 720
		private bool \u0002;

		// Token: 0x040002D1 RID: 721
		[CompilerGenerated]
		private StorageInfo \u0006;
	}
}
