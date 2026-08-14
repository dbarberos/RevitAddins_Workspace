using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.SheetLink.Enums;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x02000253 RID: 595
	public class SpatialBaseElement : BaseElement
	{
		// Token: 0x0600182A RID: 6186 RVA: 0x0009C250 File Offset: 0x0009A450
		public SpatialBaseElement(Element element, bool isLinked = false, string linkName = "")
		{
			if (\u001E\u0007\u000E.\u001F(element) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialBaseElement..ctor(Element, bool, string)).MethodHandle;
				}
				string u000A;
				if ((u000A = \u001A\u0014\u0007.\u0007(\u0016\u0018\u0007.\u0007(element, -1006901L))) == null)
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
					u000A = "";
				}
				\u000E\u0020\u0005.\u000A(this, u000A);
				string u000A2;
				if ((u000A2 = \u001A\u0014\u0007.\u0007(\u0016\u0018\u0007.\u0007(element, -1006900L))) == null)
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
					u000A2 = "";
				}
				\u000D\u0020\u0005.\u000A(this, u000A2);
			}
			\u0010\u0020\u0005.\u000A(this, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(element)));
			string text;
			if (!\u0008\u0013\u000A.\u000A(\u0013\u0016\u0005.\u001D(this), string.Empty))
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
				text = "|";
			}
			else
			{
				text = "";
			}
			string text2 = text;
			if (isLinked)
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
				string[] array = \u001B\u001F\u000E.\u001F(6);
				array[0] = \u0013\u0016\u0005.\u001D(this);
				array[1] = " ";
				array[2] = text2;
				array[3] = " <";
				array[4] = linkName;
				array[5] = ">";
				\u000D\u0020\u0005.\u000A(this, \u0014\u0006\u001D.\u000A(array));
			}
			\u001C\u0020\u0005.\u000A(this, isLinked);
			\u0003\u0020\u0005.\u000A(this, element);
		}

		// Token: 0x170006BA RID: 1722
		// (get) Token: 0x0600182B RID: 6187 RVA: 0x0009C37C File Offset: 0x0009A57C
		// (set) Token: 0x0600182C RID: 6188 RVA: 0x0009C390 File Offset: 0x0009A590
		public string Number { get; set; }

		// Token: 0x170006BB RID: 1723
		// (get) Token: 0x0600182D RID: 6189 RVA: 0x0009C3A4 File Offset: 0x0009A5A4
		// (set) Token: 0x0600182E RID: 6190 RVA: 0x0009C3B8 File Offset: 0x0009A5B8
		public bool IsSelected
		{
			get
			{
				return this.VH;
			}
			set
			{
				this.VH = value;
				\u0007\u0013\u000A.\u000A(this, "IsSelected");
			}
		}

		// Token: 0x170006BC RID: 1724
		// (get) Token: 0x0600182F RID: 6191 RVA: 0x0009C3D8 File Offset: 0x0009A5D8
		// (set) Token: 0x06001830 RID: 6192 RVA: 0x0009C3EC File Offset: 0x0009A5EC
		public bool FilterPassed { get; set; }

		// Token: 0x170006BD RID: 1725
		// (get) Token: 0x06001831 RID: 6193 RVA: 0x0009C400 File Offset: 0x0009A600
		// (set) Token: 0x06001832 RID: 6194 RVA: 0x0009C414 File Offset: 0x0009A614
		public bool IsLinked { get; set; }

		// Token: 0x170006BE RID: 1726
		// (get) Token: 0x06001833 RID: 6195 RVA: 0x0009C428 File Offset: 0x0009A628
		// (set) Token: 0x06001834 RID: 6196 RVA: 0x0009C43C File Offset: 0x0009A63C
		public Element RevitElement { get; set; }

		// Token: 0x06001835 RID: 6197 RVA: 0x0009C450 File Offset: 0x0009A650
		internal static List<RevitParameter> LO()
		{
			List<RevitParameter> list = \u000D\u000E\u0018.\u000A();
			RevitParameter revitParameter = \u0009\u0010\u0018.\u000A();
			\u0008\u001B\u0019.\u0007(revitParameter, -1006901L);
			\u000E\u001B\u0019.\u0007(revitParameter, "Number");
			\u0007\u001E\u0005.\u001D(revitParameter, "Number");
			\u0014\u0010\u0018.\u0007(revitParameter, OtherParamTypes.Custom);
			\u000B\u001E\u0005.\u001D(revitParameter, "String");
			\u0004\u001E\u0005.\u001D(revitParameter, -1L);
			\u001D\u001E\u0005.\u001D(revitParameter, "");
			RevitParameter u000A = revitParameter;
			\u0017\u0010\u0018.\u000A(list, u000A);
			RevitParameter revitParameter2 = \u0009\u0010\u0018.\u000A();
			\u0008\u001B\u0019.\u0007(revitParameter2, -1006900L);
			\u000E\u001B\u0019.\u0007(revitParameter2, "Name");
			\u0007\u001E\u0005.\u001D(revitParameter2, "Name");
			\u0014\u0010\u0018.\u0007(revitParameter2, OtherParamTypes.Custom);
			\u000B\u001E\u0005.\u001D(revitParameter2, "String");
			\u0004\u001E\u0005.\u001D(revitParameter2, -1L);
			\u001D\u001E\u0005.\u001D(revitParameter2, "");
			u000A = revitParameter2;
			\u0017\u0010\u0018.\u000A(list, u000A);
			RevitParameter revitParameter3 = \u0009\u0010\u0018.\u000A();
			\u0008\u001B\u0019.\u0007(revitParameter3, -1012113L);
			\u000E\u001B\u0019.\u0007(revitParameter3, "Phase");
			\u0007\u001E\u0005.\u001D(revitParameter3, "Phase");
			\u0013\u001B\u0019.\u0007(revitParameter3, true);
			\u0014\u0010\u0018.\u0007(revitParameter3, OtherParamTypes.Custom);
			\u000B\u001E\u0005.\u001D(revitParameter3, "ElementId");
			\u0004\u001E\u0005.\u001D(revitParameter3, -1L);
			\u001D\u001E\u0005.\u001D(revitParameter3, "");
			u000A = revitParameter3;
			\u0017\u0010\u0018.\u000A(list, u000A);
			return list;
		}

		// Token: 0x04000985 RID: 2437
		private bool VH;

		// Token: 0x04000986 RID: 2438
		[CompilerGenerated]
		private string NC;

		// Token: 0x04000987 RID: 2439
		[CompilerGenerated]
		private bool TH;

		// Token: 0x04000988 RID: 2440
		[CompilerGenerated]
		private bool MC;

		// Token: 0x04000989 RID: 2441
		[CompilerGenerated]
		private Element ZH;
	}
}
