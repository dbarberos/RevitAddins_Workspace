using System;
using A;
using DiRoots.One.TableGen.ViewModels;

namespace DiRoots.One.TableGen.UI
{
	// Token: 0x02000155 RID: 341
	public class SheetRegionTemplateSelector : ConditionalTemplateSelector<SheetRegionViewModel>
	{
		// Token: 0x06000CC9 RID: 3273 RVA: 0x000509A8 File Offset: 0x0004EBA8
		protected override bool UseFallback(SheetRegionViewModel item)
		{
			return \u001A\u0006\u0007.\u000A(\u0014\u000A\u0019.\u001D(item));
		}
	}
}
