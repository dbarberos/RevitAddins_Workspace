using System;
using System.Xml.Serialization;
using A;

namespace DiRoots.One.SheetGen.Models
{
	// Token: 0x02000378 RID: 888
	[XmlInclude(typeof(RevisionParameter))]
	[XmlInclude(typeof(ParameterModel))]
	[XmlInclude(typeof(ParameterIdValue))]
	[XmlInclude(typeof(VMProfile))]
	[XmlInclude(typeof(SGProfile))]
	[XmlInclude(typeof(SelectionParameter))]
	[XmlInclude(typeof(ParameterIntegerValue))]
	[XmlInclude(typeof(ParameterStringValue))]
	[Serializable]
	public abstract class Profile
	{
		// Token: 0x06002471 RID: 9329 RVA: 0x000DEF14 File Offset: 0x000DD114
		public Profile()
		{
			\u001A\u0015\u000B.\u000A(this, true);
		}

		// Token: 0x17000A4A RID: 2634
		// (get) Token: 0x06002472 RID: 9330 RVA: 0x000DEF30 File Offset: 0x000DD130
		// (set) Token: 0x06002473 RID: 9331 RVA: 0x000DEF44 File Offset: 0x000DD144
		public virtual string Name { get; set; }

		// Token: 0x17000A4B RID: 2635
		// (get) Token: 0x06002474 RID: 9332 RVA: 0x000DEF58 File Offset: 0x000DD158
		// (set) Token: 0x06002475 RID: 9333 RVA: 0x000DEF6C File Offset: 0x000DD16C
		public virtual bool IsValid { get; set; }

		// Token: 0x17000A4C RID: 2636
		// (get) Token: 0x06002476 RID: 9334 RVA: 0x000DEF80 File Offset: 0x000DD180
		// (set) Token: 0x06002477 RID: 9335 RVA: 0x000DEF94 File Offset: 0x000DD194
		public virtual string FilePath { get; set; }

		// Token: 0x17000A4D RID: 2637
		// (get) Token: 0x06002478 RID: 9336 RVA: 0x000DEFA8 File Offset: 0x000DD1A8
		// (set) Token: 0x06002479 RID: 9337 RVA: 0x000DEFBC File Offset: 0x000DD1BC
		public bool IsSelected { get; set; }
	}
}
