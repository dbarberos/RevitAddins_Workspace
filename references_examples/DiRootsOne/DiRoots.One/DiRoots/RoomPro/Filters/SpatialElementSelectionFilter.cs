using System;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace DiRoots.RoomPro.Filters
{
	// Token: 0x02000093 RID: 147
	public class SpatialElementSelectionFilter<T> : ISelectionFilter where T : Element
	{
		// Token: 0x06000658 RID: 1624 RVA: 0x000245B0 File Offset: 0x000227B0
		public SpatialElementSelectionFilter(Document doc)
		{
			this.\u001F = doc;
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000659 RID: 1625 RVA: 0x000245CC File Offset: 0x000227CC
		// (set) Token: 0x0600065A RID: 1626 RVA: 0x000245E0 File Offset: 0x000227E0
		public bool AllowSelectingFromLinkedFiles { get; set; }

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x0600065B RID: 1627 RVA: 0x000245F4 File Offset: 0x000227F4
		// (set) Token: 0x0600065C RID: 1628 RVA: 0x00024608 File Offset: 0x00022808
		public Document LinkedDocument { get; set; }

		// Token: 0x0600065D RID: 1629 RVA: 0x0002461C File Offset: 0x0002281C
		public bool AllowElement(Element elem)
		{
			return true;
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x0002462C File Offset: 0x0002282C
		public bool AllowReference(Reference reference, XYZ position)
		{
			this.LinkedDocument = \u0010\u0007\u000E.\u001F;
			Element element = \u001A\u0004\u001D.\u000A(this.\u001F, reference);
			RevitLinkInstance revitLinkInstance = \u000E\u0007\u000E.\u001F(element);
			if (revitLinkInstance != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElementSelectionFilter.AllowReference(Reference, XYZ)).MethodHandle;
				}
				if (!this.AllowSelectingFromLinkedFiles)
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
					return false;
				}
				this.LinkedDocument = \u000E\u0009\u0007.\u000A(revitLinkInstance);
				element = \u0011\u0017\u000A.\u0007(this.LinkedDocument, \u0013\u0004\u001D.\u000A(reference));
			}
			if (!(element is T))
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
				Document linkedDocument = this.LinkedDocument;
				object obj;
				if (linkedDocument == null)
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
					obj = null;
				}
				else
				{
					obj = \u0011\u0017\u000A.\u001D(linkedDocument, \u0013\u0004\u001D.\u000A(reference));
				}
				return obj is T;
			}
			return true;
		}

		// Token: 0x04000262 RID: 610
		private readonly Document \u001F;

		// Token: 0x04000263 RID: 611
		[CompilerGenerated]
		private bool \u000A;

		// Token: 0x04000264 RID: 612
		[CompilerGenerated]
		private Document \u0007;
	}
}
