using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.UI.Controls;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x02000238 RID: 568
	public class CategoryCollection : ModelBase, ICategoryModel
	{
		// Token: 0x06001671 RID: 5745 RVA: 0x00093614 File Offset: 0x00091814
		public CategoryCollection()
		{
		}

		// Token: 0x06001672 RID: 5746 RVA: 0x00093628 File Offset: 0x00091828
		public CategoryCollection(int catId, List<string> type)
		{
			\u0013\u0017\u0019.\u001D(this, (long)catId);
			\u0014\u0017\u0019.\u001D(this, type);
		}

		// Token: 0x06001673 RID: 5747 RVA: 0x0009364C File Offset: 0x0009184C
		public CategoryCollection(Document doc, int catId, List<string> type)
		{
			\u000C\u0015\u0018.\u001D(this, doc);
			\u0013\u0017\u0019.\u001D(this, (long)catId);
			\u0014\u0017\u0019.\u001D(this, type);
		}

		// Token: 0x06001674 RID: 5748 RVA: 0x00093678 File Offset: 0x00091878
		public CategoryCollection(Category cat, List<string> type, IList<Element> elements)
		{
			\u0015\u0015\u0018.\u001D(this, \u0009\u0014\u000A.\u001D(cat));
			\u0013\u0017\u0019.\u001D(this, \u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(cat)));
			\u0014\u0017\u0019.\u001D(this, type);
			\u0011\u0017\u0019.\u001D(this, new List<Element>(elements));
		}

		// Token: 0x06001675 RID: 5749 RVA: 0x000936C4 File Offset: 0x000918C4
		public CategoryCollection(ICategoryModel category, IList<Element> elements)
		{
			\u0015\u0015\u0018.\u001D(this, \u000B\u0015\u0018.\u000A(category));
			\u0013\u0017\u0019.\u001D(this, \u0017\u001C\u0018.\u000A(category));
			\u0014\u0017\u0019.\u001D(this, \u000F\u001C\u0018.\u000A(category));
			\u0011\u0017\u0019.\u001D(this, new List<Element>(elements));
		}

		// Token: 0x17000618 RID: 1560
		// (get) Token: 0x06001677 RID: 5751 RVA: 0x00093724 File Offset: 0x00091924
		// (set) Token: 0x06001676 RID: 5750 RVA: 0x00093710 File Offset: 0x00091910
		public long Id { get; set; }

		// Token: 0x17000619 RID: 1561
		// (get) Token: 0x06001679 RID: 5753 RVA: 0x0009374C File Offset: 0x0009194C
		// (set) Token: 0x06001678 RID: 5752 RVA: 0x00093738 File Offset: 0x00091938
		public string ElementName { get; set; }

		// Token: 0x1700061A RID: 1562
		// (get) Token: 0x0600167B RID: 5755 RVA: 0x00093774 File Offset: 0x00091974
		// (set) Token: 0x0600167A RID: 5754 RVA: 0x00093760 File Offset: 0x00091960
		public string Name { get; set; }

		// Token: 0x1700061B RID: 1563
		// (get) Token: 0x0600167D RID: 5757 RVA: 0x0009379C File Offset: 0x0009199C
		// (set) Token: 0x0600167C RID: 5756 RVA: 0x00093788 File Offset: 0x00091988
		public List<string> CatType { get; set; }

		// Token: 0x1700061C RID: 1564
		// (get) Token: 0x0600167F RID: 5759 RVA: 0x000937C4 File Offset: 0x000919C4
		// (set) Token: 0x0600167E RID: 5758 RVA: 0x000937B0 File Offset: 0x000919B0
		public bool IsSchedule { get; set; }

		// Token: 0x1700061D RID: 1565
		// (get) Token: 0x06001681 RID: 5761 RVA: 0x000937EC File Offset: 0x000919EC
		// (set) Token: 0x06001680 RID: 5760 RVA: 0x000937D8 File Offset: 0x000919D8
		public bool IsFromSelection { get; set; }

		// Token: 0x1700061E RID: 1566
		// (get) Token: 0x06001683 RID: 5763 RVA: 0x00093814 File Offset: 0x00091A14
		// (set) Token: 0x06001682 RID: 5762 RVA: 0x00093800 File Offset: 0x00091A00
		public string SheetName { get; set; }

		// Token: 0x1700061F RID: 1567
		// (get) Token: 0x06001685 RID: 5765 RVA: 0x0009383C File Offset: 0x00091A3C
		// (set) Token: 0x06001684 RID: 5764 RVA: 0x00093828 File Offset: 0x00091A28
		public Document CurrentDocument { get; set; }

		// Token: 0x17000620 RID: 1568
		// (get) Token: 0x06001686 RID: 5766 RVA: 0x00093850 File Offset: 0x00091A50
		// (set) Token: 0x06001687 RID: 5767 RVA: 0x00093864 File Offset: 0x00091A64
		public bool FilterPassed { get; set; }

		// Token: 0x17000621 RID: 1569
		// (get) Token: 0x06001688 RID: 5768 RVA: 0x00093878 File Offset: 0x00091A78
		// (set) Token: 0x06001689 RID: 5769 RVA: 0x0009388C File Offset: 0x00091A8C
		public ExportTypes ExportType { get; set; }

		// Token: 0x17000622 RID: 1570
		// (get) Token: 0x0600168A RID: 5770 RVA: 0x000938A0 File Offset: 0x00091AA0
		// (set) Token: 0x0600168B RID: 5771 RVA: 0x000938B4 File Offset: 0x00091AB4
		public List<Element> Elements
		{
			get
			{
				return this.HY;
			}
			set
			{
				this.HY = value;
				\u0007\u0013\u000A.\u000A(this, "Elements");
			}
		}

		// Token: 0x17000623 RID: 1571
		// (get) Token: 0x0600168C RID: 5772 RVA: 0x000938D4 File Offset: 0x00091AD4
		public List<Element> ValidElements
		{
			get
			{
				List<Element> list = \u001E\u0017\u0019.\u001D(this);
				if (list == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryCollection.get_ValidElements()).MethodHandle;
					}
					return null;
				}
				Func<Element, bool> func;
				if ((func = CategoryCollection.<>c.\u000A) == null)
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
					func = (CategoryCollection.<>c.\u000A = new Func<Element, bool>(CategoryCollection.<>c.\u001F.\u0007));
				}
				return Enumerable.ToList<Element>(Enumerable.Where<Element>(list, func));
			}
		}

		// Token: 0x17000624 RID: 1572
		// (get) Token: 0x0600168D RID: 5773 RVA: 0x0009393C File Offset: 0x00091B3C
		// (set) Token: 0x0600168E RID: 5774 RVA: 0x00093950 File Offset: 0x00091B50
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

		// Token: 0x0600168F RID: 5775 RVA: 0x00093970 File Offset: 0x00091B70
		public long GetCategoryId()
		{
			long result = \u0013\u000E\u0018.\u001D(this);
			if (\u0014\u0012\u0005.\u0007(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryCollection.GetCategoryId()).MethodHandle;
				}
				if (!\u0016\u001E\u0018.\u001D(this))
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
					if (\u0017\u0012\u0005.\u0007(this) != null)
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
						long num = \u000B\u001E\u000A.\u000A(\u0004\u0013\u0007.\u000A(\u0011\u0017\u000A.\u0007(\u0017\u0012\u0005.\u0007(this), \u001E\u0001\u000A.\u000A(\u0013\u000E\u0018.\u001D(this)))));
						if (num > 0L)
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
							result = num;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06001690 RID: 5776 RVA: 0x00093A10 File Offset: 0x00091C10
		public string CorrectSheetName(string name)
		{
			if (\u000F\u000C\u001D.\u0007(name, "/"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryCollection.CorrectSheetName(string)).MethodHandle;
				}
				name = \u001C\u000B\u001D.\u0007(name, "/", "");
			}
			if (\u000F\u000C\u001D.\u0007(name, "\\"))
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
				name = \u001C\u000B\u001D.\u0007(name, "\\", "");
			}
			string text;
			if (\u001C\u000F\u0007.\u0007(name) <= 31)
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
				text = name;
			}
			else
			{
				text = \u000A\u000B\u001D.\u000A(name, 0, 31);
			}
			name = text;
			return name;
		}

		// Token: 0x06001691 RID: 5777 RVA: 0x00093AB0 File Offset: 0x00091CB0
		internal static List<CategoryCollection> QP()
		{
			List<CategoryCollection> list = \u0017\u0017\u0019.\u000A();
			CategoryCollection categoryCollection = \u001A\u0017\u0019.\u000A();
			if (!\u001F\u000C\u000A.\u001D(\u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A())))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryCollection.QP()).MethodHandle;
				}
				\u0013\u0017\u0019.\u0007(categoryCollection, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u0013\u0013\u0007.\u000A(\u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A())))));
				\u0015\u0015\u0018.\u0007(categoryCollection, "Project Information");
				\u0014\u0017\u0019.\u0007(categoryCollection, \u001F\u000B\u000E.\u001F);
				\u0020\u0017\u0019.\u000A(list, categoryCollection);
			}
			categoryCollection = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection, -2L);
			\u0015\u0015\u0018.\u0007(categoryCollection, "Object Styles");
			\u0014\u0017\u0019.\u0007(categoryCollection, \u001F\u000B\u000E.\u001F);
			\u0020\u0017\u0019.\u000A(list, categoryCollection);
			categoryCollection = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection, -3L);
			\u0015\u0015\u0018.\u0007(categoryCollection, "Line Styles");
			\u0014\u0017\u0019.\u0007(categoryCollection, \u001F\u000B\u000E.\u001F);
			\u0020\u0017\u0019.\u000A(list, categoryCollection);
			categoryCollection = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection, -4L);
			\u0015\u0015\u0018.\u0007(categoryCollection, "Families");
			\u0014\u0017\u0019.\u0007(categoryCollection, \u001F\u000B\u000E.\u001F);
			\u0020\u0017\u0019.\u000A(list, categoryCollection);
			return list;
		}

		// Token: 0x040008EA RID: 2282
		private bool VH;

		// Token: 0x040008EB RID: 2283
		private List<Element> HY;

		// Token: 0x040008EC RID: 2284
		[CompilerGenerated]
		private long W;

		// Token: 0x040008ED RID: 2285
		[CompilerGenerated]
		private string V;

		// Token: 0x040008EE RID: 2286
		[CompilerGenerated]
		private string K;

		// Token: 0x040008EF RID: 2287
		[CompilerGenerated]
		private List<string> YY;

		// Token: 0x040008F0 RID: 2288
		[CompilerGenerated]
		private bool CY;

		// Token: 0x040008F1 RID: 2289
		[CompilerGenerated]
		private bool LY;

		// Token: 0x040008F2 RID: 2290
		[CompilerGenerated]
		private string SY;

		// Token: 0x040008F3 RID: 2291
		[CompilerGenerated]
		private Document BY;

		// Token: 0x040008F4 RID: 2292
		[CompilerGenerated]
		private bool TH;

		// Token: 0x040008F5 RID: 2293
		[CompilerGenerated]
		private ExportTypes UY;
	}
}
