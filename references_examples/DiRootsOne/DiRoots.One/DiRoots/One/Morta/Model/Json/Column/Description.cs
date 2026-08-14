using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using A;
using DiRoots.One.SheetLink.Models;

namespace DiRoots.One.Morta.Model.Json.Column
{
	// Token: 0x020001E7 RID: 487
	[Serializable]
	public class Description
	{
		// Token: 0x06001278 RID: 4728 RVA: 0x0006B2DC File Offset: 0x000694DC
		public Description()
		{
		}

		// Token: 0x06001279 RID: 4729 RVA: 0x0006B2F0 File Offset: 0x000694F0
		public Description(string description, List<Block> blocks = null)
		{
			if (\u001A\u0006\u0007.\u000A(description))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Description..ctor(string, List<Block>)).MethodHandle;
				}
				return;
			}
			\u0003\u0005\u0018.\u000A(this, new Content());
			if (blocks != null)
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
				if (Enumerable.Any<Block>(blocks))
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
					if (\u0014\u001E\u001D.\u000A(\u0012\u0005\u0018.\u000A(\u000F\u0005\u0018.\u000A(blocks, 0)), "THIS CODE MAPS THE COLUMN"))
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
						\u0016\u0005\u0018.\u000A(\u000F\u0005\u0018.\u000A(blocks, 0), description);
					}
					\u0018\u0005\u0018.\u000A(\u0006\u0005\u0018.\u000A(this), blocks);
					return;
				}
			}
			object u001F = \u0006\u0005\u0018.\u000A(this);
			List<Block> list = new List<Block>();
			Block block = new Block();
			\u000B\u0005\u0018.\u000A(block, \u0002\u0005\u0018.\u000A().ToString());
			\u0016\u0005\u0018.\u000A(block, description);
			\u0005\u0005\u0018.\u000A(list, block);
			\u0018\u0005\u0018.\u000A(u001F, list);
		}

		// Token: 0x17000564 RID: 1380
		// (get) Token: 0x0600127A RID: 4730 RVA: 0x0006B3D4 File Offset: 0x000695D4
		// (set) Token: 0x0600127B RID: 4731 RVA: 0x0006B3E8 File Offset: 0x000695E8
		public Content content { get; set; }

		// Token: 0x0600127C RID: 4732 RVA: 0x0006B3FC File Offset: 0x000695FC
		internal string \u001F()
		{
			if (\u0010\u0005\u0018.\u0007(\u0006\u0005\u0018.\u000A(this)) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Description.\u001F()).MethodHandle;
				}
				if (!Enumerable.Any<Block>(\u0010\u0005\u0018.\u0007(\u0006\u0005\u0018.\u000A(this))))
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
				}
				else
				{
					string u000A = "\\{[^{}]*\\}";
					Match u001F = \u000D\u0005\u0018.\u000A(\u0012\u0005\u0018.\u000A(\u000F\u0005\u0018.\u000A(\u0010\u0005\u0018.\u0007(\u0006\u0005\u0018.\u000A(this)), 0)), u000A);
					if (\u001C\u0005\u0018.\u000A(u001F))
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
						return \u0005\u000C\u0004.\u000A(u001F);
					}
					return string.Empty;
				}
			}
			return string.Empty;
		}

		// Token: 0x0600127D RID: 4733 RVA: 0x0006B4A4 File Offset: 0x000696A4
		internal ParamExportInfo \u000A()
		{
			return ParamExportInfo.\u0004(this.\u001F());
		}
	}
}
