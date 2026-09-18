using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using A;

namespace DiRoots.ProfileControl.Helper
{
	// Token: 0x0200001A RID: 26
	public class FolderHandler
	{
		// Token: 0x060000DF RID: 223 RVA: 0x00006504 File Offset: 0x00004704
		public FolderHandler(string rootFolder, string pluginName)
		{
			this.\u0018 = rootFolder;
			this.\u000C = pluginName;
			if (this.\u001F())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler..ctor(string, string)).MethodHandle;
				}
				this.\u0011(\u0018\u0006\u0018.\u0018(this));
			}
			else
			{
				this.\u0014 = \u0018\u0006\u0018.\u0018(this);
				this.\u0003 = \u0010\u0010\u0018.\u0014(this);
				this.\u000D = \u000C\u0006\u0018.\u0018(this);
			}
			this.\u0016 = \u0019\u0010\u0018.\u0014(this);
			this.\u0003 = \u000C\u0006\u0018.\u0018(this);
			LastUsedFolder lastUsedFolder = this.\u0004();
			if (lastUsedFolder != null)
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
				\u0006\u0010\u0018.\u0014(this.\u0013, \u000E\u0010\u0018.\u0018(lastUsedFolder));
				\u0007\u0010\u0018.\u0014(this.\u0013, \u0005\u0010\u0018.\u0018(lastUsedFolder));
				\u000B\u0010\u0018.\u0014(this.\u0013, \u001B\u0010\u0018.\u0018(lastUsedFolder));
				\u001D\u0010\u0018.\u0014(this.\u0013, \u0001\u0010\u0018.\u0018(lastUsedFolder));
			}
			else
			{
				this.\u001C = true;
				\u0006\u0010\u0018.\u0014(this.\u0013, \u0008\u0010\u0018.\u0014(this));
				\u0007\u0010\u0018.\u0014(this.\u0013, \u0010\u0010\u0018.\u0014(this));
				\u000B\u0010\u0018.\u0014(this.\u0013, \u0019\u0010\u0018.\u0014(this));
				\u001D\u0010\u0018.\u0014(this.\u0013, \u001A\u0010\u0018.\u0014(this));
				this.\u001C = false;
			}
			this.\u0002();
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00006670 File Offset: 0x00004870
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x00006684 File Offset: 0x00004884
		public string RootDirectory { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00006698 File Offset: 0x00004898
		public string PluginDirectory
		{
			get
			{
				this.\u0017(this.\u0014);
				return this.\u0014;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x000066BC File Offset: 0x000048BC
		public string TemplateDirectory
		{
			get
			{
				if (!this.\u001C)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.get_TemplateDirectory()).MethodHandle;
					}
					this.\u0017(this.\u0003);
				}
				return this.\u0003;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x000066FC File Offset: 0x000048FC
		public string ProfileDirectory
		{
			get
			{
				if (!this.\u001C)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.get_ProfileDirectory()).MethodHandle;
					}
					this.\u0017(this.\u0016);
				}
				return this.\u0016;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x0000673C File Offset: 0x0000493C
		public string AppDataProfileDirectory
		{
			get
			{
				string u000F = this.\u000F;
				this.\u0017(u000F);
				return u000F;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x0000675C File Offset: 0x0000495C
		public string PanelDirectory
		{
			get
			{
				if (!this.\u001C)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.get_PanelDirectory()).MethodHandle;
					}
					this.\u0017(this.\u0012);
				}
				return this.\u0012;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x0000679C File Offset: 0x0000499C
		public string TempDirectory
		{
			get
			{
				string u000D = this.\u000D;
				if (!this.\u001C)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.get_TempDirectory()).MethodHandle;
					}
					this.\u0017(u000D);
				}
				return u000D;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x000067D8 File Offset: 0x000049D8
		// (set) Token: 0x060000E9 RID: 233 RVA: 0x00006838 File Offset: 0x00004A38
		public string PluginRecentDirectory
		{
			get
			{
				if (!this.\u0017(\u000E\u0010\u0018.\u0018(this.\u0013)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.get_PluginRecentDirectory()).MethodHandle;
					}
					this.\u0017(\u0008\u0010\u0018.\u0014(this));
					return \u0008\u0010\u0018.\u0014(this);
				}
				return \u000E\u0010\u0018.\u0018(this.\u0013);
			}
			set
			{
				string u;
				if (this.\u0020(value, out u))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.set_PluginRecentDirectory(string)).MethodHandle;
					}
					\u0006\u0010\u0018.\u0014(this.\u0013, u);
				}
				this.\u0002();
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00006878 File Offset: 0x00004A78
		// (set) Token: 0x060000EB RID: 235 RVA: 0x000068D8 File Offset: 0x00004AD8
		public string TemplateRecentDirectory
		{
			get
			{
				if (!this.\u0017(\u0005\u0010\u0018.\u0018(this.\u0013)))
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.get_TemplateRecentDirectory()).MethodHandle;
					}
					this.\u0017(\u0010\u0010\u0018.\u0014(this));
					return \u0010\u0010\u0018.\u0014(this);
				}
				return \u0005\u0010\u0018.\u0018(this.\u0013);
			}
			set
			{
				\u0007\u0010\u0018.\u0014(this.\u0013, value);
				this.\u0002();
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000EC RID: 236 RVA: 0x000068F8 File Offset: 0x00004AF8
		// (set) Token: 0x060000ED RID: 237 RVA: 0x00006958 File Offset: 0x00004B58
		public string ProfileRecentDirectory
		{
			get
			{
				if (!this.\u0017(\u001B\u0010\u0018.\u0018(this.\u0013)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.get_ProfileRecentDirectory()).MethodHandle;
					}
					this.\u0017(\u0019\u0010\u0018.\u0014(this));
					return \u0019\u0010\u0018.\u0014(this);
				}
				return \u001B\u0010\u0018.\u0018(this.\u0013);
			}
			set
			{
				string u;
				if (this.\u0020(value, out u))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.set_ProfileRecentDirectory(string)).MethodHandle;
					}
					\u000B\u0010\u0018.\u0014(this.\u0013, u);
				}
				this.\u0002();
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000EE RID: 238 RVA: 0x00006998 File Offset: 0x00004B98
		// (set) Token: 0x060000EF RID: 239 RVA: 0x000069F8 File Offset: 0x00004BF8
		public string PanelRecentDirectory
		{
			get
			{
				if (!this.\u0017(\u0001\u0010\u0018.\u0018(this.\u0013)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.get_PanelRecentDirectory()).MethodHandle;
					}
					this.\u0017(\u001A\u0010\u0018.\u0014(this));
					return \u001A\u0010\u0018.\u0014(this);
				}
				return \u0001\u0010\u0018.\u0018(this.\u0013);
			}
			set
			{
				string u;
				if (this.\u0020(value, out u))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.set_PanelRecentDirectory(string)).MethodHandle;
					}
					\u001D\u0010\u0018.\u0014(this.\u0013, u);
				}
				this.\u0002();
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x00006A38 File Offset: 0x00004C38
		// (set) Token: 0x060000F1 RID: 241 RVA: 0x00006A4C File Offset: 0x00004C4C
		public bool UseLastUsedPath { get; set; } = true;

		// Token: 0x060000F2 RID: 242 RVA: 0x00006A60 File Offset: 0x00004C60
		private unsafe bool \u0020(string \u000C, out string \u0018)
		{
			bool result = false;
			\u0018 = "";
			try
			{
				FileAttributes fileAttributes = \u0003\u0006\u0018.\u0018(\u000C);
				if (\u0014\u0006\u0018.\u0018(fileAttributes, FileAttributes.Directory))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.\u0020(string, string*)).MethodHandle;
					}
					\u0018 = \u000C;
				}
				else
				{
					\u0018 = \u0019\u001E\u0018.\u0018(\u000C);
				}
				result = true;
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00006AD0 File Offset: 0x00004CD0
		private bool \u001F()
		{
			string text = this.\u001E();
			try
			{
				string text2 = \u0003\u001A\u0018.\u0018(text, this.\u0018);
				if (!\u0012\u0006\u0018.\u0018(text2))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.\u001F()).MethodHandle;
					}
					\u000F\u0006\u0018.\u0018(text2);
				}
				\u0016\u0006\u0018.\u0018(this, text2);
			}
			catch (Exception)
			{
				\u0016\u0006\u0018.\u0018(this, text);
				return false;
			}
			return true;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00006B44 File Offset: 0x00004D44
		private void \u0011(string \u000C)
		{
			\u000C = \u0003\u001A\u0018.\u0018(\u000C, this.\u000C);
			if (this.\u0017(\u000C))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.\u0011(string)).MethodHandle;
				}
				this.\u0014 = \u000C;
				this.\u0016 = \u0003\u001A\u0018.\u0018(this.\u0014, "Profiles");
				this.\u0012 = \u0003\u001A\u0018.\u0018(this.\u0014, "PanelLink");
				this.\u0003 = \u0003\u001A\u0018.\u0018(this.\u0015(), "Templates");
				this.\u000D = \u0003\u001A\u0018.\u0018(this.\u0015(), "Temp");
				this.\u000F = \u0003\u001A\u0018.\u0018(this.\u0015(), "Profiles");
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00006C0C File Offset: 0x00004E0C
		public void ClearTempDirectory()
		{
			FileInfo[] array = \u001C\u0006\u0018.\u0018(\u0013\u0006\u0018.\u0018(\u000C\u0006\u0018.\u0018(this)));
			for (int i = 0; i < (int)\u001F\u0004\u000F.\u000C(array); i++)
			{
				FileInfo u000C = array[i];
				try
				{
					\u000D\u0006\u0018.\u0018(u000C);
				}
				catch (Exception)
				{
				}
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.ClearTempDirectory()).MethodHandle;
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00006C78 File Offset: 0x00004E78
		private string \u0015()
		{
			return \u0009\u0006\u0018.\u0018(\u000A\u0006\u0018.\u0018(Environment.SpecialFolder.LocalApplicationData), this.\u0018, this.\u000C);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00006CA4 File Offset: 0x00004EA4
		private bool \u0017(string \u000C)
		{
			try
			{
				if (!\u0012\u0006\u0018.\u0018(\u000C))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.\u0017(string)).MethodHandle;
					}
					\u000F\u0006\u0018.\u0018(\u000C);
				}
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00006CF4 File Offset: 0x00004EF4
		private string \u001E()
		{
			return \u000A\u0006\u0018.\u0018(Environment.SpecialFolder.Personal);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00006D0C File Offset: 0x00004F0C
		private void \u0002()
		{
			if (\u000C\u0006\u0018.\u0018(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.\u0002()).MethodHandle;
				}
				return;
			}
			try
			{
				LastUsedFolder u = this.\u0013;
				string u000C = \u0003\u001A\u0018.\u0018(\u000C\u0006\u0018.\u0018(this), "LastUsedPath.xml");
				XmlSerializer u000C2 = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000A\u0004\u000F.\u000C()));
				XmlSerializerNamespaces xmlSerializerNamespaces = \u0019\u001D\u0018.\u0018();
				\u000B\u001D\u0018.\u0018(xmlSerializerNamespaces, "", "");
				TextWriter textWriter = \u001A\u001D\u0018.\u0018(u000C);
				try
				{
					\u001D\u001D\u0018.\u0018(u000C2, textWriter, u, xmlSerializerNamespaces);
					\u0004\u001D\u0018.\u0018(textWriter);
				}
				finally
				{
					if (textWriter != null)
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
						\u0020\u001E\u0018.\u0018(textWriter);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00006DD0 File Offset: 0x00004FD0
		private LastUsedFolder \u0004()
		{
			if (\u000C\u0006\u0018.\u0018(this) == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(FolderHandler.\u0004()).MethodHandle;
				}
				return null;
			}
			LastUsedFolder result = \u0009\u0004\u000F.\u000C;
			try
			{
				string u000C = \u0003\u001A\u0018.\u0018(\u000C\u0006\u0018.\u0018(this), "LastUsedPath.xml");
				if (\u000C\u001A\u0018.\u0018(u000C))
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
					object u000C2 = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000A\u0004\u000F.\u000C()));
					StreamReader streamReader = \u000E\u001D\u0018.\u0018(u000C);
					result = \u0020\u0004\u000F.\u000C(\u0005\u001D\u0018.\u0018(u000C2, streamReader));
					\u001B\u001D\u0018.\u0018(streamReader);
				}
				return result;
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x04000057 RID: 87
		public static string UsedPathCacheName;

		// Token: 0x04000058 RID: 88
		private readonly string \u000C;

		// Token: 0x04000059 RID: 89
		private readonly string \u0018;

		// Token: 0x0400005A RID: 90
		private string \u0014;

		// Token: 0x0400005B RID: 91
		private string \u0003;

		// Token: 0x0400005C RID: 92
		private string \u0016;

		// Token: 0x0400005D RID: 93
		private string \u000F;

		// Token: 0x0400005E RID: 94
		private string \u0012;

		// Token: 0x0400005F RID: 95
		private string \u000D;

		// Token: 0x04000060 RID: 96
		private readonly bool \u001C;

		// Token: 0x04000061 RID: 97
		private readonly LastUsedFolder \u0013 = new LastUsedFolder();

		// Token: 0x04000062 RID: 98
		[CompilerGenerated]
		private string \u0009;

		// Token: 0x04000063 RID: 99
		[CompilerGenerated]
		private bool \u000A;
	}
}
