using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;

namespace DiRoots.One.TGDatabaseLayer.StyleMapping
{
	// Token: 0x02000124 RID: 292
	public class StyleMappingDto
	{
		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06000B03 RID: 2819 RVA: 0x00046E8C File Offset: 0x0004508C
		// (set) Token: 0x06000B04 RID: 2820 RVA: 0x00046EA0 File Offset: 0x000450A0
		public GeneralMappingSetting GeneralMapping { get; set; } = new GeneralMappingSetting();

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x06000B05 RID: 2821 RVA: 0x00046EB4 File Offset: 0x000450B4
		// (set) Token: 0x06000B06 RID: 2822 RVA: 0x00046EC8 File Offset: 0x000450C8
		public List<LineStyleMapping> LineStyleMappings { get; set; } = new List<LineStyleMapping>();

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06000B07 RID: 2823 RVA: 0x00046EDC File Offset: 0x000450DC
		// (set) Token: 0x06000B08 RID: 2824 RVA: 0x00046EF0 File Offset: 0x000450F0
		public List<TextStyleMapping> TextStyleMappings { get; set; } = new List<TextStyleMapping>();

		// Token: 0x06000B09 RID: 2825 RVA: 0x00046F04 File Offset: 0x00045104
		public bool EqualsByValue(StyleMappingDto other)
		{
			if (other == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingDto.EqualsByValue(StyleMappingDto)).MethodHandle;
				}
				return false;
			}
			if (this == other)
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
				return true;
			}
			if (\u0001\u0004\u0004.\u0007(\u0009\u0004\u0004.\u001D(this)) != \u0001\u0004\u0004.\u0007(\u0009\u0004\u0004.\u0007(other)))
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
				return false;
			}
			if (\u0012\u000B\u0004.\u0007(\u0009\u0004\u0004.\u001D(this)) != \u0012\u000B\u0004.\u0007(\u0009\u0004\u0004.\u0007(other)))
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
				return false;
			}
			if (\u0005\u0010\u0004.\u0007(\u0009\u0004\u0004.\u001D(this)) != \u0005\u0010\u0004.\u0007(\u0009\u0004\u0004.\u0007(other)))
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
				return false;
			}
			if (\u0018\u0010\u0004.\u000A(\u0009\u0004\u0004.\u001D(this)) != \u0018\u0010\u0004.\u000A(\u0009\u0004\u0004.\u0007(other)))
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
				return false;
			}
			if (\u0016\u0010\u0004.\u000A(\u0009\u0004\u0004.\u001D(this)) != \u0016\u0010\u0004.\u000A(\u0009\u0004\u0004.\u0007(other)))
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
				return false;
			}
			List<LineStyleMapping> u001F = \u0012\u001C\u0004.\u001D(this);
			List<LineStyleMapping> u000A = \u0012\u001C\u0004.\u0007(other);
			Func<LineStyleMapping, LineStyleMapping, bool> u;
			if ((u = StyleMappingDto.<>c.\u000A) == null)
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
				u = (StyleMappingDto.<>c.\u000A = new Func<LineStyleMapping, LineStyleMapping, bool>(StyleMappingDto.<>c.\u001F.\u001D));
			}
			if (!\u0001\u0005.\u001F<LineStyleMapping>(u001F, u000A, u))
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
			List<TextStyleMapping> u001F2 = \u0005\u000D\u0004.\u001D(this);
			List<TextStyleMapping> u000A2 = \u0005\u000D\u0004.\u0007(other);
			Func<TextStyleMapping, TextStyleMapping, bool> u2;
			if ((u2 = StyleMappingDto.<>c.\u0007) == null)
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
				u2 = (StyleMappingDto.<>c.\u0007 = new Func<TextStyleMapping, TextStyleMapping, bool>(StyleMappingDto.<>c.\u001F.\u0004));
			}
			if (!\u0001\u0005.\u001F<TextStyleMapping>(u001F2, u000A2, u2))
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
			return true;
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x000470B4 File Offset: 0x000452B4
		internal LineStyleMapping \u001D(ExcelLineStyleInfo \u001F)
		{
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingDto.\u001D(ExcelLineStyleInfo)).MethodHandle;
				}
				return null;
			}
			List<LineStyleMapping>.Enumerator enumerator = \u000D\u001C\u0004.\u000A(\u0012\u001C\u0004.\u001D(this));
			try
			{
				while (\u0003\u001C\u0004.\u000A(ref enumerator))
				{
					LineStyleMapping lineStyleMapping = \u001C\u001C\u0004.\u000A(ref enumerator);
					if (\u000A\u0009\u001D.\u0007(\u001F, \u000D\u0002\u0004.\u0007(lineStyleMapping)))
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
						return lineStyleMapping;
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return null;
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x00047150 File Offset: 0x00045350
		internal TextStyleMapping \u0004(ExcelTextStyleInfo \u001F)
		{
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingDto.\u0004(ExcelTextStyleInfo)).MethodHandle;
				}
				return null;
			}
			List<TextStyleMapping>.Enumerator enumerator = \u000F\u000D\u0004.\u000A(\u0005\u000D\u0004.\u001D(this));
			try
			{
				while (\u0016\u000D\u0004.\u000A(ref enumerator))
				{
					TextStyleMapping textStyleMapping = \u0006\u000D\u0004.\u000A(ref enumerator);
					if (\u001D\u0020\u0004.\u001D(\u001F, \u0002\u000D\u0004.\u001D(textStyleMapping)))
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
						return textStyleMapping;
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return null;
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x000471EC File Offset: 0x000453EC
		internal void \u0019()
		{
			\u0002\u0020\u0004.\u000A(\u0005\u000D\u0004.\u001D(this));
			\u000B\u0020\u0004.\u000A(\u0012\u001C\u0004.\u001D(this));
		}

		// Token: 0x0400046D RID: 1133
		[CompilerGenerated]
		private GeneralMappingSetting \u001F;

		// Token: 0x0400046E RID: 1134
		[CompilerGenerated]
		private List<LineStyleMapping> \u000A;

		// Token: 0x0400046F RID: 1135
		[CompilerGenerated]
		private List<TextStyleMapping> \u0007;
	}
}
