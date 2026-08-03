using System;
using System.Runtime.CompilerServices;
using A;

namespace DiRoots.One.SheetGen.Services
{
	// Token: 0x02000314 RID: 788
	public class DirectoriesHandler : IDisposable
	{
		// Token: 0x0600221C RID: 8732 RVA: 0x000D1EE8 File Offset: 0x000D00E8
		private DirectoriesHandler(string F)
		{
			this.R = F;
			this.U();
			if (this.B())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DirectoriesHandler..ctor(string)).MethodHandle;
				}
				this.W(\u0018\u0010\u000B.\u000A(this));
				this.K();
				return;
			}
			this.F = \u0018\u0010\u000B.\u000A(this);
			\u0019\u0010\u000B.\u0007(this, \u0018\u0010\u000B.\u000A(this));
		}

		// Token: 0x170009A1 RID: 2465
		// (get) Token: 0x0600221D RID: 8733 RVA: 0x000D1F5C File Offset: 0x000D015C
		public static DirectoriesHandler Instance
		{
			get
			{
				if (DirectoriesHandler._instance == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(DirectoriesHandler.get_Instance()).MethodHandle;
					}
					DirectoriesHandler._instance = \u0005\u0010\u000B.\u000A("SheetGen");
				}
				return DirectoriesHandler._instance;
			}
		}

		// Token: 0x170009A2 RID: 2466
		// (get) Token: 0x0600221E RID: 8734 RVA: 0x000D1F9C File Offset: 0x000D019C
		// (set) Token: 0x0600221F RID: 8735 RVA: 0x000D1FB0 File Offset: 0x000D01B0
		public bool RootDirectoryAvailable { get; private set; }

		// Token: 0x170009A3 RID: 2467
		// (get) Token: 0x06002220 RID: 8736 RVA: 0x000D1FC4 File Offset: 0x000D01C4
		// (set) Token: 0x06002221 RID: 8737 RVA: 0x000D1FD8 File Offset: 0x000D01D8
		public string RootDirectory { get; set; }

		// Token: 0x170009A4 RID: 2468
		// (get) Token: 0x06002222 RID: 8738 RVA: 0x000D1FEC File Offset: 0x000D01EC
		// (set) Token: 0x06002223 RID: 8739 RVA: 0x000D2028 File Offset: 0x000D0228
		public string PluginDirectory
		{
			get
			{
				if (!\u0016\u0010\u000B.\u0007(this))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(DirectoriesHandler.get_PluginDirectory()).MethodHandle;
					}
					return \u0008\u0005\u0018.\u000A(Environment.SpecialFolder.Desktop);
				}
				return this.F;
			}
			set
			{
				this.F = value;
			}
		}

		// Token: 0x170009A5 RID: 2469
		// (get) Token: 0x06002224 RID: 8740 RVA: 0x000D203C File Offset: 0x000D023C
		// (set) Token: 0x06002225 RID: 8741 RVA: 0x000D2050 File Offset: 0x000D0250
		public string AppDataDirectory { get; set; }

		// Token: 0x170009A6 RID: 2470
		// (get) Token: 0x06002226 RID: 8742 RVA: 0x000D2064 File Offset: 0x000D0264
		// (set) Token: 0x06002227 RID: 8743 RVA: 0x000D2078 File Offset: 0x000D0278
		public string ProfileDirectory { get; set; }

		// Token: 0x06002228 RID: 8744 RVA: 0x000D208C File Offset: 0x000D028C
		private bool S(string F)
		{
			bool result;
			try
			{
				string u001F = \u0004\u001E\u000A.\u000A(F, "\\Test");
				if (!\u000C\u0010\u0004.\u000A(u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(DirectoriesHandler.S(string)).MethodHandle;
					}
					\u0011\u0015\u001D.\u000A(u001F);
				}
				\u000B\u0010\u000B.\u000A(\u0004\u001E\u000A.\u000A(F, "\\Test"));
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06002229 RID: 8745 RVA: 0x000D20FC File Offset: 0x000D02FC
		private bool B()
		{
			string u001F = \u0008\u0005\u0018.\u000A(Environment.SpecialFolder.Personal);
			try
			{
				string text = \u0004\u001E\u000A.\u000A(u001F, "\\DiRootsOne");
				if (!\u000C\u0010\u0004.\u000A(text))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(DirectoriesHandler.B()).MethodHandle;
					}
					\u0011\u0015\u001D.\u000A(text);
				}
				\u0006\u0010\u000B.\u000A(this, text);
			}
			catch (Exception)
			{
				\u0006\u0010\u000B.\u000A(this, \u0008\u0005\u0018.\u000A(Environment.SpecialFolder.Desktop));
				return false;
			}
			\u0002\u0010\u000B.\u000A(this, this.S(\u0018\u0010\u000B.\u000A(this)));
			return true;
		}

		// Token: 0x0600222A RID: 8746 RVA: 0x000D218C File Offset: 0x000D038C
		private bool U()
		{
			string text = \u0008\u0005\u0018.\u000A(Environment.SpecialFolder.LocalApplicationData);
			try
			{
				string text2 = \u0004\u001E\u000A.\u000A(text, "\\DiRootsOne\\SheetGen");
				if (!\u000C\u0010\u0004.\u000A(text2))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(DirectoriesHandler.U()).MethodHandle;
					}
					\u0011\u0015\u001D.\u000A(text2);
				}
				\u000F\u0010\u000B.\u000A(this, text2);
			}
			catch (Exception)
			{
				\u000F\u0010\u000B.\u000A(this, text);
				return false;
			}
			return true;
		}

		// Token: 0x0600222B RID: 8747 RVA: 0x000D2200 File Offset: 0x000D0400
		private void W(string F)
		{
			F = \u001B\u0015\u001D.\u000A(F, this.R);
			if (this.J(F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DirectoriesHandler.W(string)).MethodHandle;
				}
				this.F = F;
			}
		}

		// Token: 0x0600222C RID: 8748 RVA: 0x000D2244 File Offset: 0x000D0444
		private void K()
		{
			if (this.F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DirectoriesHandler.K()).MethodHandle;
				}
				string text = \u001B\u0015\u001D.\u000A(this.F, "Profiles");
				if (this.J(text))
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
					\u0019\u0010\u000B.\u0007(this, text);
					return;
				}
			}
			else
			{
				string f;
				\u0019\u0010\u000B.\u0007(this, f = \u0018\u0010\u000B.\u000A(this));
				this.F = f;
			}
		}

		// Token: 0x0600222D RID: 8749 RVA: 0x000D22B4 File Offset: 0x000D04B4
		private bool J(string F)
		{
			try
			{
				if (!\u000C\u0010\u0004.\u000A(F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(DirectoriesHandler.J(string)).MethodHandle;
					}
					\u0011\u0015\u001D.\u000A(F);
				}
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600222E RID: 8750 RVA: 0x000D2304 File Offset: 0x000D0504
		public void Dispose()
		{
			DirectoriesHandler._instance = \u000B\u0010\u000E.\u001F;
		}

		// Token: 0x04000DB4 RID: 3508
		private string F;

		// Token: 0x04000DB5 RID: 3509
		private readonly string R;

		// Token: 0x04000DB6 RID: 3510
		private static DirectoriesHandler _instance;

		// Token: 0x04000DB7 RID: 3511
		[CompilerGenerated]
		private bool D;

		// Token: 0x04000DB8 RID: 3512
		[CompilerGenerated]
		private string H;

		// Token: 0x04000DB9 RID: 3513
		[CompilerGenerated]
		private string C;

		// Token: 0x04000DBA RID: 3514
		[CompilerGenerated]
		private string L;
	}
}
