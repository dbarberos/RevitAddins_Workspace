using System;
using A;
using DiRoots.One.Commons.Models;
using ProSheets.Xml.Enums;

namespace DiRoots.ProSheets.Xml.Models
{
	// Token: 0x0200002A RID: 42
	public class XmlExportOptions : ModelBase
	{
		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600018D RID: 397 RVA: 0x000098D4 File Offset: 0x00007AD4
		// (set) Token: 0x0600018E RID: 398 RVA: 0x000098E8 File Offset: 0x00007AE8
		public XmlExportAsOptions XmlExportAsOption
		{
			get
			{
				return this.W;
			}
			set
			{
				this.W = value;
				\u0007\u001B\u0018.\u0018(this, "XmlExportAsOption");
			}
		}

		// Token: 0x040000D4 RID: 212
		private XmlExportAsOptions W;
	}
}
