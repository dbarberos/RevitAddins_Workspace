using System;
using System.Xml.Serialization;
using DiRoots.One.SheetLink.Models;

namespace DiRoots.One.SheetLink.Profile
{
	// Token: 0x02000235 RID: 565
	[XmlInclude(typeof(TemplateInfo))]
	[Serializable]
	public abstract class ProfileTemplate
	{
		// Token: 0x06001640 RID: 5696
		public abstract ProfileTemplate Clone();
	}
}
