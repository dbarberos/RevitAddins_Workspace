using System;
using System.IO;
using System.IO.Packaging;
using System.Reflection;
using DiRoots.RevitOleStorage;

namespace A
{
	// Token: 0x020000B4 RID: 180
	internal abstract class \u0013\u0004
	{
		// Token: 0x06000701 RID: 1793 RVA: 0x000290F8 File Offset: 0x000272F8
		public \u0013\u0004(string \u001F)
		{
			if (!\u0010\u0002\u001D.\u000A(\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u0004..ctor(string)).MethodHandle;
				}
				throw new FileNotFoundException(\u0017\u0006\u0007.\u000A("The file \"{0}\" was not found.", \u001F));
			}
			this.\u0002\u000A = \u001F;
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000702 RID: 1794 RVA: 0x00029150 File Offset: 0x00027350
		// (set) Token: 0x06000703 RID: 1795 RVA: 0x00029164 File Offset: 0x00027364
		public bool \u000B\u000A
		{
			get
			{
				return this.\u0012;
			}
			protected set
			{
				this.\u0012 = value;
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000704 RID: 1796 RVA: 0x00029178 File Offset: 0x00027378
		// (set) Token: 0x06000705 RID: 1797 RVA: 0x0002918C File Offset: 0x0002738C
		public string \u0002\u000A
		{
			get
			{
				return this.\u000F;
			}
			protected set
			{
				this.\u000F = value;
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000706 RID: 1798 RVA: 0x000291A0 File Offset: 0x000273A0
		public string \u0006\u000A
		{
			get
			{
				if (\u001A\u0006\u0007.\u000A(this.\u0002\u000A))
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u0004.get_\u0006\u000A()).MethodHandle;
					}
					return string.Empty;
				}
				return \u001C\u000B\u001D.\u0007(\u001B\u0002\u001D.\u000A(this.\u0002\u000A), ".", string.Empty);
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x000291F8 File Offset: 0x000273F8
		public DocumentType \u000F\u000A
		{
			get
			{
				if (\u001A\u0006\u0007.\u000A(this.\u0006\u000A))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u0004.get_\u000F\u000A()).MethodHandle;
					}
					return DocumentType.Unknown;
				}
				string u001F = \u0006\u000B\u001D.\u000A(this.\u0006\u000A);
				if (\u0008\u0013\u000A.\u000A(u001F, "RVT"))
				{
					return DocumentType.Project;
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
				if (\u0008\u0013\u000A.\u000A(u001F, "RTE"))
				{
					return DocumentType.ProjectTemplate;
				}
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (\u0008\u0013\u000A.\u000A(u001F, "RFA"))
				{
					return DocumentType.Family;
				}
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!\u0008\u0013\u000A.\u000A(u001F, "RFT"))
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
					return DocumentType.Unknown;
				}
				return DocumentType.FamilyTemplate;
			}
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x000292AC File Offset: 0x000274AC
		protected object \u0012\u000A(StorageInfo \u001F, string \u000A, params object[] \u0007)
		{
			BindingFlags u = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod;
			return \u0011\u0002\u001D.\u000A(\u001E\u0002\u001D.\u000A(\u0020\u0002\u001D.\u000A(\u001E\u0011\u000A.\u000A(\u000A\u001D\u000E.\u001F())), "System.IO.Packaging.StorageRoot", true, false), \u000A, u, null, \u001F, \u0007);
		}

		// Token: 0x040002D2 RID: 722
		private string \u000F = string.Empty;

		// Token: 0x040002D3 RID: 723
		private bool \u0012;
	}
}
