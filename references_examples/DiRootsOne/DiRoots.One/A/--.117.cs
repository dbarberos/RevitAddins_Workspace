using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Extensions;
using DiRoots.One.SheetLink.Models;
using DiRoots.One.SheetLink.UI.Controls;

namespace A
{
	// Token: 0x020001FD RID: 509
	internal class \u0014\u000F
	{
		// Token: 0x060012F5 RID: 4853 RVA: 0x0006F520 File Offset: 0x0006D720
		public \u0014\u000F(Document \u001F, List<CategoryCollection> \u000A)
		{
			this.\u001F = \u001F;
			if (\u0008\u0003\u0018.\u000A(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u000F..ctor(Document, List<CategoryCollection>)).MethodHandle;
				}
				\u000E\u0003\u0018.\u000A(this, Enumerable.ToList<ICategoryModel>(Enumerable.Cast<ICategoryModel>(\u000A)));
			}
		}

		// Token: 0x060012F6 RID: 4854 RVA: 0x0006F574 File Offset: 0x0006D774
		public \u0014\u000F(Document \u001F)
		{
			this.\u001F = \u001F;
			this.\u001B();
		}

		// Token: 0x060012F7 RID: 4855 RVA: 0x0006F59C File Offset: 0x0006D79C
		// Note: this type is marked as 'beforefieldinit'.
		static \u0014\u000F()
		{
			Dictionary<long, List<ICategoryModel>> dictionary = \u0020\u0003\u0018.\u000A();
			long u000A = -2003400L;
			List<ICategoryModel> list = \u001E\u0003\u0018.\u000A();
			CategoryCollection categoryCollection = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection, -2003415L);
			List<string> list2 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list2, "7");
			\u0014\u0017\u0019.\u0007(categoryCollection, list2);
			\u0011\u0003\u0018.\u000A(list, categoryCollection);
			CategoryCollection categoryCollection2 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection2, -2003412L);
			List<string> list3 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list3, "7");
			\u0014\u0017\u0019.\u0007(categoryCollection2, list3);
			\u0011\u0003\u0018.\u000A(list, categoryCollection2);
			CategoryCollection categoryCollection3 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection3, -2003414L);
			List<string> list4 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list4, "7");
			\u0014\u0017\u0019.\u0007(categoryCollection3, list4);
			\u0011\u0003\u0018.\u000A(list, categoryCollection3);
			CategoryCollection categoryCollection4 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection4, -2003417L);
			List<string> list5 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list5, "7");
			\u0014\u0017\u0019.\u0007(categoryCollection4, list5);
			\u0011\u0003\u0018.\u000A(list, categoryCollection4);
			CategoryCollection categoryCollection5 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection5, -2003413L);
			List<string> list6 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list6, "7");
			\u0014\u0017\u0019.\u0007(categoryCollection5, list6);
			\u0011\u0003\u0018.\u000A(list, categoryCollection5);
			CategoryCollection categoryCollection6 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection6, -2003411L);
			List<string> list7 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list7, "7");
			\u0014\u0017\u0019.\u0007(categoryCollection6, list7);
			\u0011\u0003\u0018.\u000A(list, categoryCollection6);
			CategoryCollection categoryCollection7 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection7, -2003416L);
			List<string> list8 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list8, "7");
			\u0014\u0017\u0019.\u0007(categoryCollection7, list8);
			\u0011\u0003\u0018.\u000A(list, categoryCollection7);
			CategoryCollection categoryCollection8 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection8, -2003403L);
			List<string> list9 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list9, "7");
			\u0014\u0017\u0019.\u0007(categoryCollection8, list9);
			\u0011\u0003\u0018.\u000A(list, categoryCollection8);
			\u001B\u0003\u0018.\u000A(dictionary, u000A, list);
			long u000A2 = -2000032L;
			List<ICategoryModel> list10 = \u001E\u0003\u0018.\u000A();
			CategoryCollection categoryCollection9 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection9, -2001392L);
			List<string> list11 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list11, "1");
			\u001A\u0008\u0007.\u000A(list11, "2");
			\u0014\u0017\u0019.\u0007(categoryCollection9, list11);
			\u0011\u0003\u0018.\u000A(list10, categoryCollection9);
			CategoryCollection categoryCollection10 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection10, -2000898L);
			List<string> list12 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list12, "1");
			\u001A\u0008\u0007.\u000A(list12, "2");
			\u0014\u0017\u0019.\u0007(categoryCollection10, list12);
			\u0011\u0003\u0018.\u000A(list10, categoryCollection10);
			\u001B\u0003\u0018.\u000A(dictionary, u000A2, list10);
			long u000A3 = -2000051L;
			List<ICategoryModel> list13 = \u001E\u0003\u0018.\u000A();
			CategoryCollection categoryCollection11 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection11, -2000066L);
			List<string> list14 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list14, "7");
			\u0014\u0017\u0019.\u0007(categoryCollection11, list14);
			\u0011\u0003\u0018.\u000A(list13, categoryCollection11);
			CategoryCollection categoryCollection12 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection12, -2000833L);
			List<string> list15 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list15, "7");
			\u0014\u0017\u0019.\u0007(categoryCollection12, list15);
			\u0011\u0003\u0018.\u000A(list13, categoryCollection12);
			CategoryCollection categoryCollection13 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection13, -2000831L);
			List<string> list16 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list16, "7");
			\u0014\u0017\u0019.\u0007(categoryCollection13, list16);
			\u0011\u0003\u0018.\u000A(list13, categoryCollection13);
			CategoryCollection categoryCollection14 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection14, -2000045L);
			List<string> list17 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list17, "7");
			\u0014\u0017\u0019.\u0007(categoryCollection14, list17);
			\u0011\u0003\u0018.\u000A(list13, categoryCollection14);
			\u001B\u0003\u0018.\u000A(dictionary, u000A3, list13);
			long u000A4 = -2000126L;
			List<ICategoryModel> list18 = \u001E\u0003\u0018.\u000A();
			CategoryCollection categoryCollection15 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection15, -2000947L);
			List<string> list19 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list19, "1");
			\u001A\u0008\u0007.\u000A(list19, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection15, list19);
			\u0011\u0003\u0018.\u000A(list18, categoryCollection15);
			CategoryCollection categoryCollection16 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection16, -2000948L);
			List<string> list20 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list20, "1");
			\u001A\u0008\u0007.\u000A(list20, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection16, list20);
			\u0011\u0003\u0018.\u000A(list18, categoryCollection16);
			CategoryCollection categoryCollection17 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection17, -2000949L);
			List<string> list21 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list21, "1");
			\u001A\u0008\u0007.\u000A(list21, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection17, list21);
			\u0011\u0003\u0018.\u000A(list18, categoryCollection17);
			CategoryCollection categoryCollection18 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection18, -2000946L);
			List<string> list22 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list22, "1");
			\u001A\u0008\u0007.\u000A(list22, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection18, list22);
			\u0011\u0003\u0018.\u000A(list18, categoryCollection18);
			\u001B\u0003\u0018.\u000A(dictionary, u000A4, list18);
			long u000A5 = -2000035L;
			List<ICategoryModel> list23 = \u001E\u0003\u0018.\u000A();
			CategoryCollection categoryCollection19 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection19, -2001390L);
			List<string> list24 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list24, "1");
			\u001A\u0008\u0007.\u000A(list24, "2");
			\u0014\u0017\u0019.\u0007(categoryCollection19, list24);
			\u0011\u0003\u0018.\u000A(list23, categoryCollection19);
			CategoryCollection categoryCollection20 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection20, -2001391L);
			List<string> list25 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list25, "1");
			\u001A\u0008\u0007.\u000A(list25, "2");
			\u0014\u0017\u0019.\u0007(categoryCollection20, list25);
			\u0011\u0003\u0018.\u000A(list23, categoryCollection20);
			CategoryCollection categoryCollection21 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection21, -2001393L);
			List<string> list26 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list26, "1");
			\u001A\u0008\u0007.\u000A(list26, "2");
			\u0014\u0017\u0019.\u0007(categoryCollection21, list26);
			\u0011\u0003\u0018.\u000A(list23, categoryCollection21);
			\u001B\u0003\u0018.\u000A(dictionary, u000A5, list23);
			long u000A6 = -2000120L;
			List<ICategoryModel> list27 = \u001E\u0003\u0018.\u000A();
			CategoryCollection categoryCollection22 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection22, -2000920L);
			List<string> list28 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list28, "1");
			\u001A\u0008\u0007.\u000A(list28, "2");
			\u0014\u0017\u0019.\u0007(categoryCollection22, list28);
			\u0011\u0003\u0018.\u000A(list27, categoryCollection22);
			CategoryCollection categoryCollection23 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection23, -2000919L);
			List<string> list29 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list29, "1");
			\u001A\u0008\u0007.\u000A(list29, "2");
			\u0014\u0017\u0019.\u0007(categoryCollection23, list29);
			\u0011\u0003\u0018.\u000A(list27, categoryCollection23);
			CategoryCollection categoryCollection24 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection24, -2000952L);
			List<string> list30 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list30, "1");
			\u001A\u0008\u0007.\u000A(list30, "2");
			\u0014\u0017\u0019.\u0007(categoryCollection24, list30);
			\u0011\u0003\u0018.\u000A(list27, categoryCollection24);
			\u001B\u0003\u0018.\u000A(dictionary, u000A6, list27);
			long u000A7 = -2001320L;
			List<ICategoryModel> list31 = \u001E\u0003\u0018.\u000A();
			CategoryCollection categoryCollection25 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection25, -2000995L);
			List<string> list32 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list32, "2");
			\u001A\u0008\u0007.\u000A(list32, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection25, list32);
			\u0011\u0003\u0018.\u000A(list31, categoryCollection25);
			\u001B\u0003\u0018.\u000A(dictionary, u000A7, list31);
			long u000A8 = -2000011L;
			List<ICategoryModel> list33 = \u001E\u0003\u0018.\u000A();
			CategoryCollection categoryCollection26 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection26, -2000181L);
			List<string> list34 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list34, "1");
			\u001A\u0008\u0007.\u000A(list34, "2");
			\u001A\u0008\u0007.\u000A(list34, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection26, list34);
			\u0011\u0003\u0018.\u000A(list33, categoryCollection26);
			CategoryCollection categoryCollection27 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection27, -2000182L);
			List<string> list35 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list35, "1");
			\u001A\u0008\u0007.\u000A(list35, "2");
			\u001A\u0008\u0007.\u000A(list35, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection27, list35);
			\u0011\u0003\u0018.\u000A(list33, categoryCollection27);
			CategoryCollection categoryCollection28 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection28, -2000997L);
			List<string> list36 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list36, "1");
			\u001A\u0008\u0007.\u000A(list36, "2");
			\u001A\u0008\u0007.\u000A(list36, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection28, list36);
			\u0011\u0003\u0018.\u000A(list33, categoryCollection28);
			CategoryCollection categoryCollection29 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection29, -2003500L);
			List<string> list37 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list37, "1");
			\u001A\u0008\u0007.\u000A(list37, "2");
			\u001A\u0008\u0007.\u000A(list37, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection29, list37);
			\u0011\u0003\u0018.\u000A(list33, categoryCollection29);
			\u001B\u0003\u0018.\u000A(dictionary, u000A8, list33);
			long u000A9 = -2005200L;
			List<ICategoryModel> list38 = \u001E\u0003\u0018.\u000A();
			CategoryCollection categoryCollection30 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection30, -2005203L);
			List<string> list39 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list39, "2");
			\u0014\u0017\u0019.\u0007(categoryCollection30, list39);
			\u0011\u0003\u0018.\u000A(list38, categoryCollection30);
			CategoryCollection categoryCollection31 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection31, -2005202L);
			List<string> list40 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list40, "2");
			\u0014\u0017\u0019.\u0007(categoryCollection31, list40);
			\u0011\u0003\u0018.\u000A(list38, categoryCollection31);
			CategoryCollection categoryCollection32 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection32, -2005201L);
			List<string> list41 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list41, "2");
			\u0014\u0017\u0019.\u0007(categoryCollection32, list41);
			\u0011\u0003\u0018.\u000A(list38, categoryCollection32);
			\u001B\u0003\u0018.\u000A(dictionary, u000A9, list38);
			long u000A10 = -2001260L;
			List<ICategoryModel> list42 = \u001E\u0003\u0018.\u000A();
			CategoryCollection categoryCollection33 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection33, -2001263L);
			List<string> list43 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list43, "1");
			\u001A\u0008\u0007.\u000A(list43, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection33, list43);
			\u0011\u0003\u0018.\u000A(list42, categoryCollection33);
			CategoryCollection categoryCollection34 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection34, -2001265L);
			List<string> list44 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list44, "1");
			\u001A\u0008\u0007.\u000A(list44, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection34, list44);
			\u0011\u0003\u0018.\u000A(list42, categoryCollection34);
			CategoryCollection categoryCollection35 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection35, -2001268L);
			List<string> list45 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list45, "1");
			\u0014\u0017\u0019.\u0007(categoryCollection35, list45);
			\u0011\u0003\u0018.\u000A(list42, categoryCollection35);
			\u001B\u0003\u0018.\u000A(dictionary, u000A10, list42);
			long u000A11 = -2005204L;
			List<ICategoryModel> list46 = \u001E\u0003\u0018.\u000A();
			CategoryCollection categoryCollection36 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection36, -2005207L);
			List<string> list47 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list47, "2");
			\u0014\u0017\u0019.\u0007(categoryCollection36, list47);
			\u0011\u0003\u0018.\u000A(list46, categoryCollection36);
			CategoryCollection categoryCollection37 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection37, -2005206L);
			List<string> list48 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list48, "2");
			\u0014\u0017\u0019.\u0007(categoryCollection37, list48);
			\u0011\u0003\u0018.\u000A(list46, categoryCollection37);
			CategoryCollection categoryCollection38 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection38, -2005205L);
			List<string> list49 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list49, "2");
			\u0014\u0017\u0019.\u0007(categoryCollection38, list49);
			\u0011\u0003\u0018.\u000A(list46, categoryCollection38);
			\u001B\u0003\u0018.\u000A(dictionary, u000A11, list46);
			long u000A12 = -2006130L;
			List<ICategoryModel> list50 = \u001E\u0003\u0018.\u000A();
			CategoryCollection categoryCollection39 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection39, -2006203L);
			List<string> list51 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list51, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection39, list51);
			\u0011\u0003\u0018.\u000A(list50, categoryCollection39);
			CategoryCollection categoryCollection40 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection40, -2006204L);
			List<string> list52 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list52, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection40, list52);
			\u0011\u0003\u0018.\u000A(list50, categoryCollection40);
			CategoryCollection categoryCollection41 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection41, -2006202L);
			List<string> list53 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list53, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection41, list53);
			\u0011\u0003\u0018.\u000A(list50, categoryCollection41);
			CategoryCollection categoryCollection42 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection42, -2006205L);
			List<string> list54 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list54, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection42, list54);
			\u0011\u0003\u0018.\u000A(list50, categoryCollection42);
			\u001B\u0003\u0018.\u000A(dictionary, u000A12, list50);
			long u000A13 = -2006241L;
			List<ICategoryModel> list55 = \u001E\u0003\u0018.\u000A();
			CategoryCollection categoryCollection43 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection43, -2006245L);
			List<string> list56 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list56, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection43, list56);
			\u0011\u0003\u0018.\u000A(list55, categoryCollection43);
			CategoryCollection categoryCollection44 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection44, -2006246L);
			List<string> list57 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list57, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection44, list57);
			\u0011\u0003\u0018.\u000A(list55, categoryCollection44);
			CategoryCollection categoryCollection45 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection45, -2006248L);
			List<string> list58 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list58, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection45, list58);
			\u0011\u0003\u0018.\u000A(list55, categoryCollection45);
			CategoryCollection categoryCollection46 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection46, -2006134L);
			List<string> list59 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list59, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection46, list59);
			\u0011\u0003\u0018.\u000A(list55, categoryCollection46);
			CategoryCollection categoryCollection47 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection47, -2006137L);
			List<string> list60 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list60, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection47, list60);
			\u0011\u0003\u0018.\u000A(list55, categoryCollection47);
			\u001B\u0003\u0018.\u000A(dictionary, u000A13, list55);
			long u000A14 = -2006131L;
			List<ICategoryModel> list61 = \u001E\u0003\u0018.\u000A();
			CategoryCollection categoryCollection48 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection48, -2006221L);
			List<string> list62 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list62, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection48, list62);
			\u0011\u0003\u0018.\u000A(list61, categoryCollection48);
			CategoryCollection categoryCollection49 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection49, -2006219L);
			List<string> list63 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list63, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection49, list63);
			\u0011\u0003\u0018.\u000A(list61, categoryCollection49);
			CategoryCollection categoryCollection50 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection50, -2006225L);
			List<string> list64 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list64, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection50, list64);
			\u0011\u0003\u0018.\u000A(list61, categoryCollection50);
			CategoryCollection categoryCollection51 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection51, -2006136L);
			List<string> list65 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list65, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection51, list65);
			\u0011\u0003\u0018.\u000A(list61, categoryCollection51);
			CategoryCollection categoryCollection52 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection52, -2006132L);
			List<string> list66 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list66, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection52, list66);
			\u0011\u0003\u0018.\u000A(list61, categoryCollection52);
			CategoryCollection categoryCollection53 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection53, -2006229L);
			List<string> list67 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list67, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection53, list67);
			\u0011\u0003\u0018.\u000A(list61, categoryCollection53);
			\u001B\u0003\u0018.\u000A(dictionary, u000A14, list61);
			long u000A15 = -2006261L;
			List<ICategoryModel> list68 = \u001E\u0003\u0018.\u000A();
			CategoryCollection categoryCollection54 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection54, -2006265L);
			List<string> list69 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list69, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection54, list69);
			\u0011\u0003\u0018.\u000A(list68, categoryCollection54);
			CategoryCollection categoryCollection55 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection55, -2006263L);
			List<string> list70 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list70, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection55, list70);
			\u0011\u0003\u0018.\u000A(list68, categoryCollection55);
			\u001B\u0003\u0018.\u000A(dictionary, u000A15, list68);
			long u000A16 = -2009030L;
			List<ICategoryModel> list71 = \u001E\u0003\u0018.\u000A();
			CategoryCollection categoryCollection56 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection56, -2009044L);
			List<string> list72 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list72, "2");
			\u001A\u0008\u0007.\u000A(list72, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection56, list72);
			\u0011\u0003\u0018.\u000A(list71, categoryCollection56);
			CategoryCollection categoryCollection57 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection57, -2009038L);
			List<string> list73 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list73, "2");
			\u001A\u0008\u0007.\u000A(list73, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection57, list73);
			\u0011\u0003\u0018.\u000A(list71, categoryCollection57);
			CategoryCollection categoryCollection58 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection58, -2009041L);
			List<string> list74 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list74, "2");
			\u001A\u0008\u0007.\u000A(list74, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection58, list74);
			\u0011\u0003\u0018.\u000A(list71, categoryCollection58);
			CategoryCollection categoryCollection59 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection59, -2009037L);
			List<string> list75 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list75, "2");
			\u001A\u0008\u0007.\u000A(list75, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection59, list75);
			\u0011\u0003\u0018.\u000A(list71, categoryCollection59);
			CategoryCollection categoryCollection60 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection60, -2009046L);
			List<string> list76 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list76, "2");
			\u001A\u0008\u0007.\u000A(list76, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection60, list76);
			\u0011\u0003\u0018.\u000A(list71, categoryCollection60);
			CategoryCollection categoryCollection61 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection61, -2009039L);
			List<string> list77 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list77, "2");
			\u001A\u0008\u0007.\u000A(list77, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection61, list77);
			\u0011\u0003\u0018.\u000A(list71, categoryCollection61);
			\u001B\u0003\u0018.\u000A(dictionary, u000A16, list71);
			long u000A17 = -2009016L;
			List<ICategoryModel> list78 = \u001E\u0003\u0018.\u000A();
			CategoryCollection categoryCollection62 = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection62, -2009027L);
			List<string> list79 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list79, "2");
			\u001A\u0008\u0007.\u000A(list79, "6");
			\u0014\u0017\u0019.\u0007(categoryCollection62, list79);
			\u0011\u0003\u0018.\u000A(list78, categoryCollection62);
			\u001B\u0003\u0018.\u000A(dictionary, u000A17, list78);
			\u0014\u000F.\u0006 = dictionary;
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x0007042C File Offset: 0x0006E62C
		internal static void \u000F(Document \u001F)
		{
			if (\u0014\u000F.\u0016 == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u000F.\u000F(Document)).MethodHandle;
				}
				\u0014\u000F.\u0016 = \u0017\u0003\u0018.\u000A(\u001F);
			}
		}

		// Token: 0x17000589 RID: 1417
		// (get) Token: 0x060012F9 RID: 4857 RVA: 0x00070460 File Offset: 0x0006E660
		// (set) Token: 0x060012FA RID: 4858 RVA: 0x00070474 File Offset: 0x0006E674
		public IList<ICategoryModel> Categories { get; set; }

		// Token: 0x1700058A RID: 1418
		// (get) Token: 0x060012FB RID: 4859 RVA: 0x00070488 File Offset: 0x0006E688
		public List<Category> \u0012
		{
			get
			{
				return this.\u0019;
			}
		}

		// Token: 0x1700058B RID: 1419
		// (get) Token: 0x060012FC RID: 4860 RVA: 0x0007049C File Offset: 0x0006E69C
		// (set) Token: 0x060012FD RID: 4861 RVA: 0x000704B0 File Offset: 0x0006E6B0
		public bool IsCollectionModified { get; set; }

		// Token: 0x060012FE RID: 4862 RVA: 0x000704C4 File Offset: 0x0006E6C4
		public void \u0003()
		{
			IList<ICategoryModel> u000A = this.\u000A;
			if (u000A == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u000F.\u0003()).MethodHandle;
				}
			}
			else
			{
				\u0014\u0003\u0018.\u000A(u000A);
			}
			IList<ICategoryModel> u001D = this.\u001D;
			if (u001D == null)
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
			}
			else
			{
				\u0014\u0003\u0018.\u000A(u001D);
			}
			IList<ICategoryModel> u = this.\u0004;
			if (u == null)
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
			}
			else
			{
				\u0014\u0003\u0018.\u000A(u);
			}
			IList<ICategoryModel> list = \u0008\u0003\u0018.\u000A(this);
			if (list == null)
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
			}
			else
			{
				\u0014\u0003\u0018.\u000A(list);
			}
			this.\u0018 = -1L;
			\u0014\u000F.\u0016 = \u000B\u000B\u000E.\u001F;
		}

		// Token: 0x060012FF RID: 4863 RVA: 0x0007055C File Offset: 0x0006E75C
		public IList<ICategoryModel> \u001C()
		{
			if (this.\u000A != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u000F.\u001C()).MethodHandle;
				}
				if (Enumerable.Any<ICategoryModel>(this.\u000A))
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
					return this.\u000A;
				}
			}
			this.\u000A = \u001E\u0003\u0018.\u000A();
			Dictionary<long, List<Element>>.Enumerator enumerator = \u0009\u0003\u0018.\u000A(\u0014\u000F.\u0016);
			try
			{
				while (\u0013\u0003\u0018.\u000A(ref enumerator))
				{
					\u0014\u000F.\u000E\u000F u000E_u000F = new \u0014\u000F.\u000E\u000F();
					u000E_u000F.\u001F = \u0001\u0003\u0018.\u000A(ref enumerator);
					ICategoryModel categoryModel = Enumerable.FirstOrDefault<ICategoryModel>(\u0008\u0003\u0018.\u000A(this), new Func<ICategoryModel, bool>(u000E_u000F.\u000A));
					if (categoryModel != null)
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
						\u001A\u0003\u0018.\u000A(this.\u000A, \u000C\u0003\u0018.\u000A(categoryModel, \u0015\u0003\u0018.\u000A(ref u000E_u000F.\u001F)));
					}
				}
				for (;;)
				{
					switch (2)
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
			this.\u000D(\u0014\u000F.\u0016, this.\u000A);
			return this.\u000A;
		}

		// Token: 0x06001300 RID: 4864 RVA: 0x0007066C File Offset: 0x0006E86C
		private void \u000D(Dictionary<long, List<Element>> \u001F, IList<ICategoryModel> \u000A)
		{
			Dictionary<long, List<ICategoryModel>>.Enumerator enumerator = \u0018\u001C\u0018.\u000A(\u0014\u000F.\u0006);
			try
			{
				while (\u001F\u001C\u0018.\u000A(ref enumerator))
				{
					\u0014\u000F.\u0008\u000F u0008_u000F = new \u0014\u000F.\u0008\u000F();
					u0008_u000F.\u001F = \u0019\u001C\u0018.\u000A(ref enumerator);
					List<Element> list = \u0016\u0016\u0004.\u000A();
					List<ICategoryModel>.Enumerator enumerator2 = \u001D\u001C\u0018.\u000A(\u0004\u001C\u0018.\u000A(ref u0008_u000F.\u001F));
					try
					{
						while (\u000A\u001C\u0018.\u000A(ref enumerator2))
						{
							\u0014\u000F.\u001B\u000F u001B_u000F = new \u0014\u000F.\u001B\u000F();
							u001B_u000F.\u001F = \u0007\u001C\u0018.\u000A(ref enumerator2);
							KeyValuePair<long, List<Element>> keyValuePair = Enumerable.FirstOrDefault<KeyValuePair<long, List<Element>>>(\u001F, new Func<KeyValuePair<long, List<Element>>, bool>(u001B_u000F.\u000A));
							if (\u0015\u0003\u0018.\u000A(ref keyValuePair) != null)
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
									RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u000F.\u000D(Dictionary<long, List<Element>>, IList<ICategoryModel>)).MethodHandle;
								}
								\u0018\u0016\u0004.\u000A(list, \u0015\u0003\u0018.\u000A(ref keyValuePair));
							}
						}
						for (;;)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					finally
					{
						((IDisposable)enumerator2).Dispose();
					}
					if (\u0019\u0016\u0004.\u0007(list) > 0)
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
						CategoryCollection categoryCollection = \u0016\u000B\u000E.\u001F(Enumerable.FirstOrDefault<ICategoryModel>(\u000A, new Func<ICategoryModel, bool>(u0008_u000F.\u000A)));
						if (categoryCollection != null)
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
							\u0018\u0016\u0004.\u000A(\u001E\u0017\u0019.\u0007(categoryCollection), list);
						}
						else
						{
							ICategoryModel categoryModel = Enumerable.FirstOrDefault<ICategoryModel>(\u0008\u0003\u0018.\u000A(this), new Func<ICategoryModel, bool>(u0008_u000F.\u0007));
							if (categoryModel != null)
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
								\u001A\u0003\u0018.\u000A(\u000A, \u000C\u0003\u0018.\u000A(categoryModel, list));
							}
						}
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
		}

		// Token: 0x06001301 RID: 4865 RVA: 0x0007082C File Offset: 0x0006EA2C
		public IList<ICategoryModel> \u0010()
		{
			if (this.\u0007 != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u000F.\u0010()).MethodHandle;
				}
				if (Enumerable.Any<ICategoryModel>(this.\u0007))
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
					return this.\u0007;
				}
			}
			object u001F = \u0004\u0010.\u001D(this.\u001F, true);
			this.\u0007 = \u001E\u0003\u0018.\u000A();
			List<Document>.Enumerator enumerator = \u000D\u001C\u0018.\u000A(u001F);
			try
			{
				while (\u0005\u001C\u0018.\u000A(ref enumerator))
				{
					FilteredElementCollector filteredElementCollector = \u0020\u0011\u000A.\u000A(\u001C\u001C\u0018.\u000A(ref enumerator));
					try
					{
						IEnumerable<Element> enumerable = \u0009\u001E\u000A.\u001D(filteredElementCollector);
						Func<Element, bool> func;
						if ((func = \u0014\u000F.<>c.\u000A) == null)
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
							func = (\u0014\u000F.<>c.\u000A = new Func<Element, bool>(\u0014\u000F.<>c.\u001F.\u000F));
						}
						IEnumerable<Element> enumerable2 = Enumerable.Where<Element>(enumerable, func);
						Func<Element, Category> func2;
						if ((func2 = \u0014\u000F.<>c.\u0007) == null)
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
							func2 = (\u0014\u000F.<>c.\u0007 = new Func<Element, Category>(\u0014\u000F.<>c.\u001F.\u0012));
						}
						IEnumerable<IGrouping<Category, Element>> enumerable3 = Enumerable.GroupBy<Element, Category>(enumerable2, func2, \u0015\u001E\u000A.\u000A());
						Func<IGrouping<Category, Element>, Category> func3;
						if ((func3 = \u0014\u000F.<>c.\u001D) == null)
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
							func3 = (\u0014\u000F.<>c.\u001D = new Func<IGrouping<Category, Element>, Category>(\u0014\u000F.<>c.\u001F.\u0003));
						}
						Func<IGrouping<Category, Element>, List<Element>> func4;
						if ((func4 = \u0014\u000F.<>c.\u0004) == null)
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
							func4 = (\u0014\u000F.<>c.\u0004 = new Func<IGrouping<Category, Element>, List<Element>>(\u0014\u000F.<>c.\u001F.\u001C));
						}
						Dictionary<Category, List<Element>> dictionary = Enumerable.ToDictionary<IGrouping<Category, Element>, Category, List<Element>>(enumerable3, func3, func4);
						Dictionary<Category, List<Element>>.Enumerator enumerator2 = \u0003\u001C\u0018.\u000A(dictionary);
						try
						{
							while (\u0016\u001C\u0018.\u000A(ref enumerator2))
							{
								KeyValuePair<Category, List<Element>> keyValuePair = \u0012\u001C\u0018.\u000A(ref enumerator2);
								\u0014\u000F.\u0011\u000F u0011_u000F = new \u0014\u000F.\u0011\u000F();
								u0011_u000F.\u001F = \u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u0006\u001C\u0018.\u000A(ref keyValuePair)));
								ICategoryModel categoryModel = Enumerable.FirstOrDefault<ICategoryModel>(\u0008\u0003\u0018.\u000A(this), new Func<ICategoryModel, bool>(u0011_u000F.\u000A));
								List<string> list;
								if (categoryModel == null)
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
									list = \u001F\u000B\u000E.\u001F;
								}
								else
								{
									list = \u000F\u001C\u0018.\u000A(categoryModel);
								}
								List<string> list2 = list;
								ICategoryModel categoryModel2 = Enumerable.FirstOrDefault<ICategoryModel>(this.\u0007, new Func<ICategoryModel, bool>(u0011_u000F.\u0007));
								if (list2 != null)
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
									if (categoryModel2 == null)
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
										CategoryCollection u000A = \u0002\u001C\u0018.\u000A(\u0006\u001C\u0018.\u000A(ref keyValuePair), list2, \u000B\u001C\u0018.\u000A(ref keyValuePair));
										\u001A\u0003\u0018.\u000A(this.\u0007, u000A);
										continue;
									}
								}
								if (categoryModel2 != null)
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
									\u0018\u0016\u0004.\u000A(\u001E\u0017\u0019.\u0007(\u0005\u000B\u000E.\u001F(categoryModel2)), \u000B\u001C\u0018.\u000A(ref keyValuePair));
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
							((IDisposable)enumerator2).Dispose();
						}
						IEnumerable<KeyValuePair<Category, List<Element>>> enumerable4 = dictionary;
						Func<KeyValuePair<Category, List<Element>>, long> func5;
						if ((func5 = \u0014\u000F.<>c.\u0019) == null)
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
							func5 = (\u0014\u000F.<>c.\u0019 = new Func<KeyValuePair<Category, List<Element>>, long>(\u0014\u000F.<>c.\u001F.\u000D));
						}
						Func<KeyValuePair<Category, List<Element>>, List<Element>> func6;
						if ((func6 = \u0014\u000F.<>c.\u0018) == null)
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
							func6 = (\u0014\u000F.<>c.\u0018 = new Func<KeyValuePair<Category, List<Element>>, List<Element>>(\u0014\u000F.<>c.\u001F.\u0010));
						}
						this.\u000D(Enumerable.ToDictionary<KeyValuePair<Category, List<Element>>, long, List<Element>>(enumerable4, func5, func6), this.\u0007);
					}
					finally
					{
						if (filteredElementCollector != null)
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
							\u001F\u0017\u000A.\u000A(filteredElementCollector);
						}
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
			return this.\u0007;
		}

		// Token: 0x06001302 RID: 4866 RVA: 0x00070B9C File Offset: 0x0006ED9C
		public IList<ICategoryModel> \u000E(bool \u001F = false)
		{
			if (!\u000B\u001A\u000A.\u0007(this.\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u000F.\u000E(bool)).MethodHandle;
				}
				return this.\u001D;
			}
			View u001F = \u001B\u001C\u0018.\u000A(this.\u001F);
			if (this.\u001D != null)
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
				if (Enumerable.Any<ICategoryModel>(this.\u001D))
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
					if (\u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F)) == this.\u0018)
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
						if (!\u001F)
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
							return this.\u001D;
						}
					}
				}
			}
			int num;
			if (this.\u001D != null)
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
				num = \u000E\u001C\u0018.\u000A(this.\u001D);
			}
			else
			{
				num = 0;
			}
			int num2 = num;
			this.\u0018 = \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F));
			Dictionary<long, List<Element>> u001F2 = \u0008\u001C\u0018.\u000A(this.\u001F, \u0002\u001E\u000A.\u0007(u001F));
			this.\u001D = \u001E\u0003\u0018.\u000A();
			Dictionary<long, List<Element>>.Enumerator enumerator = \u0009\u0003\u0018.\u000A(u001F2);
			try
			{
				while (\u0013\u0003\u0018.\u000A(ref enumerator))
				{
					\u0014\u000F.\u001E\u000F u001E_u000F = new \u0014\u000F.\u001E\u000F();
					u001E_u000F.\u001F = \u0001\u0003\u0018.\u000A(ref enumerator);
					ICategoryModel categoryModel = Enumerable.FirstOrDefault<ICategoryModel>(\u0008\u0003\u0018.\u000A(this), new Func<ICategoryModel, bool>(u001E_u000F.\u000A));
					if (categoryModel != null)
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
						\u001A\u0003\u0018.\u000A(this.\u001D, \u000C\u0003\u0018.\u000A(categoryModel, \u0015\u0003\u0018.\u000A(ref u001E_u000F.\u001F)));
					}
				}
				for (;;)
				{
					switch (4)
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
			this.\u000D(u001F2, this.\u001D);
			if (num2 != \u000E\u001C\u0018.\u000A(this.\u001D))
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
				\u0010\u001C\u0018.\u0007(this, true);
			}
			return this.\u001D;
		}

		// Token: 0x06001303 RID: 4867 RVA: 0x00070D74 File Offset: 0x0006EF74
		public IList<ICategoryModel> \u0008(IEnumerable<Element> \u001F)
		{
			if (\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u000F.\u0008(IEnumerable<Element>)).MethodHandle;
				}
				if (Enumerable.Any<Element>(\u001F))
				{
					if (this.\u0004 != null)
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
						if (Enumerable.Any<ICategoryModel>(this.\u0004))
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
							if (this.\u0005 != null)
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
								IEnumerable<Element> u = this.\u0005;
								Func<Element, bool> func;
								if ((func = \u0014\u000F.<>c.\u0005) == null)
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
									func = (\u0014\u000F.<>c.\u0005 = new Func<Element, bool>(\u0014\u000F.<>c.\u001F.\u000E));
								}
								if (Enumerable.Any<Element>(u, func))
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
									if (this.\u0005.SetEquals(\u001F, \u001E\u001C\u0018.\u000A()))
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
										return this.\u0004;
									}
								}
							}
						}
					}
					\u0010\u001C\u0018.\u0007(this, true);
					Func<Element, bool> func2;
					if ((func2 = \u0014\u000F.<>c.\u0016) == null)
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
						func2 = (\u0014\u000F.<>c.\u0016 = new Func<Element, bool>(\u0014\u000F.<>c.\u001F.\u0008));
					}
					this.\u0005 = Enumerable.ToList<Element>(Enumerable.Where<Element>(\u001F, func2));
					IEnumerable<Element> u2 = this.\u0005;
					Func<Element, long> func3;
					if ((func3 = \u0014\u000F.<>c.\u000B) == null)
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
						func3 = (\u0014\u000F.<>c.\u000B = new Func<Element, long>(\u0014\u000F.<>c.\u001F.\u001B));
					}
					IEnumerable<IGrouping<long, Element>> enumerable = Enumerable.GroupBy<Element, long>(u2, func3);
					Func<IGrouping<long, Element>, long> func4;
					if ((func4 = \u0014\u000F.<>c.\u0002) == null)
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
						func4 = (\u0014\u000F.<>c.\u0002 = new Func<IGrouping<long, Element>, long>(\u0014\u000F.<>c.\u001F.\u0011));
					}
					Func<IGrouping<long, Element>, List<Element>> func5;
					if ((func5 = \u0014\u000F.<>c.\u0006) == null)
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
						func5 = (\u0014\u000F.<>c.\u0006 = new Func<IGrouping<long, Element>, List<Element>>(\u0014\u000F.<>c.\u001F.\u001E));
					}
					Dictionary<long, List<Element>> u001F = Enumerable.ToDictionary<IGrouping<long, Element>, long, List<Element>>(enumerable, func4, func5);
					this.\u0004 = \u001E\u0003\u0018.\u000A();
					this.\u0019 = \u0011\u001C\u0018.\u000A();
					Dictionary<long, List<Element>>.Enumerator enumerator = \u0009\u0003\u0018.\u000A(u001F);
					try
					{
						while (\u0013\u0003\u0018.\u000A(ref enumerator))
						{
							\u0014\u000F.\u0020\u000F u0020_u000F = new \u0014\u000F.\u0020\u000F();
							u0020_u000F.\u001F = \u0001\u0003\u0018.\u000A(ref enumerator);
							ICategoryModel categoryModel = Enumerable.FirstOrDefault<ICategoryModel>(\u0008\u0003\u0018.\u000A(this), new Func<ICategoryModel, bool>(u0020_u000F.\u000A));
							if (categoryModel != null)
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
								\u001A\u0003\u0018.\u000A(this.\u0004, \u000C\u0003\u0018.\u000A(categoryModel, \u0015\u0003\u0018.\u000A(ref u0020_u000F.\u001F)));
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
					this.\u000D(u001F, this.\u0004);
					return this.\u0004;
				}
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
			\u0010\u001C\u0018.\u0007(this, true);
			this.\u0005 = \u001F;
			return \u001E\u0003\u0018.\u000A();
		}

		// Token: 0x06001304 RID: 4868 RVA: 0x00071010 File Offset: 0x0006F210
		private void \u001B()
		{
			this.\u0011(\u0008\u0003\u0018.\u000A(this));
		}

		// Token: 0x06001305 RID: 4869 RVA: 0x0007102C File Offset: 0x0006F22C
		private void \u0011(IList<ICategoryModel> \u001F)
		{
			List<Category> list = Enumerable.ToList<Category>(Enumerable.Cast<Category>(\u000D\u0001\u001D.\u000A(\u0010\u0001\u001D.\u000A(this.\u001F))));
			IEnumerator<ICategoryModel> enumerator = \u0013\u001C\u0018.\u000A(\u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u0014\u000F.\u0017\u000F u0017_u000F = new \u0014\u000F.\u0017\u000F();
					u0017_u000F.\u001F = \u0014\u001C\u0018.\u000A(enumerator);
					Category category = Enumerable.FirstOrDefault<Category>(list, new Func<Category, bool>(u0017_u000F.\u000A));
					string u000A;
					if (category != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u000F.\u0011(IList<ICategoryModel>)).MethodHandle;
						}
						u000A = \u0009\u0014\u000A.\u001D(category);
					}
					else
					{
						u000A = this.\u001E(\u0017\u001C\u0018.\u000A(u0017_u000F.\u001F));
					}
					\u0020\u001C\u0018.\u000A(u0017_u000F.\u001F, u000A);
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}

		// Token: 0x06001306 RID: 4870 RVA: 0x0007111C File Offset: 0x0006F31C
		private string \u001E(long \u001F)
		{
			string text = "";
			Element element = \u001B\u0011\u000A.\u000A(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(this.\u001F), \u001F));
			if (element != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u000F.\u001E(long)).MethodHandle;
				}
				text = \u0009\u0014\u000A.\u001D(\u000D\u0003\u0018.\u0007(element));
			}
			if (\u001A\u0006\u0007.\u000A(text))
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
				if (\u001F == -2000096L)
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
					text = \u001A\u001C\u0018.\u000A();
				}
			}
			return text;
		}

		// Token: 0x0400078A RID: 1930
		private readonly Document \u001F;

		// Token: 0x0400078B RID: 1931
		private IList<ICategoryModel> \u000A;

		// Token: 0x0400078C RID: 1932
		private IList<ICategoryModel> \u0007;

		// Token: 0x0400078D RID: 1933
		private IList<ICategoryModel> \u001D;

		// Token: 0x0400078E RID: 1934
		private IList<ICategoryModel> \u0004;

		// Token: 0x0400078F RID: 1935
		private List<Category> \u0019;

		// Token: 0x04000790 RID: 1936
		private long \u0018 = -1L;

		// Token: 0x04000791 RID: 1937
		private IEnumerable<Element> \u0005;

		// Token: 0x04000792 RID: 1938
		private static Dictionary<long, List<Element>> \u0016 = \u000B\u000B\u000E.\u001F;

		// Token: 0x04000793 RID: 1939
		[CompilerGenerated]
		private IList<ICategoryModel> \u000B;

		// Token: 0x04000794 RID: 1940
		[CompilerGenerated]
		private bool \u0002;

		// Token: 0x04000795 RID: 1941
		private static readonly Dictionary<long, List<ICategoryModel>> \u0006;

		// Token: 0x0200089A RID: 2202
		[CompilerGenerated]
		private sealed class \u000E\u000F
		{
			// Token: 0x06004FA6 RID: 20390 RVA: 0x001E5788 File Offset: 0x001E3988
			internal bool \u000A(ICategoryModel \u001F)
			{
				return \u0017\u001C\u0018.\u000A(\u001F) == \u0003\u0016\u0006.\u000A(ref this.\u001F);
			}

			// Token: 0x04002266 RID: 8806
			public KeyValuePair<long, List<Element>> \u001F;
		}

		// Token: 0x0200089B RID: 2203
		[CompilerGenerated]
		private sealed class \u0008\u000F
		{
			// Token: 0x06004FA8 RID: 20392 RVA: 0x001E57C0 File Offset: 0x001E39C0
			internal bool \u000A(ICategoryModel \u001F)
			{
				return \u0017\u001C\u0018.\u000A(\u001F) == \u000C\u0005\u0010.\u000A(ref this.\u001F);
			}

			// Token: 0x06004FA9 RID: 20393 RVA: 0x001E57E4 File Offset: 0x001E39E4
			internal bool \u0007(ICategoryModel \u001F)
			{
				return \u0017\u001C\u0018.\u000A(\u001F) == \u000C\u0005\u0010.\u000A(ref this.\u001F);
			}

			// Token: 0x04002267 RID: 8807
			public KeyValuePair<long, List<ICategoryModel>> \u001F;
		}

		// Token: 0x0200089C RID: 2204
		[CompilerGenerated]
		private sealed class \u001B\u000F
		{
			// Token: 0x06004FAB RID: 20395 RVA: 0x001E581C File Offset: 0x001E3A1C
			internal bool \u000A(KeyValuePair<long, List<Element>> \u001F)
			{
				return \u0003\u0016\u0006.\u000A(ref \u001F) == \u0017\u001C\u0018.\u000A(this.\u001F);
			}

			// Token: 0x04002268 RID: 8808
			public ICategoryModel \u001F;
		}

		// Token: 0x0200089D RID: 2205
		[CompilerGenerated]
		private sealed class \u0011\u000F
		{
			// Token: 0x06004FAD RID: 20397 RVA: 0x001E5858 File Offset: 0x001E3A58
			internal bool \u000A(ICategoryModel \u001F)
			{
				return \u0017\u001C\u0018.\u000A(\u001F) == this.\u001F;
			}

			// Token: 0x06004FAE RID: 20398 RVA: 0x001E5878 File Offset: 0x001E3A78
			internal bool \u0007(ICategoryModel \u001F)
			{
				return \u0017\u001C\u0018.\u000A(\u001F) == this.\u001F;
			}

			// Token: 0x04002269 RID: 8809
			public long \u001F;
		}

		// Token: 0x0200089E RID: 2206
		[CompilerGenerated]
		private sealed class \u001E\u000F
		{
			// Token: 0x06004FB0 RID: 20400 RVA: 0x001E58AC File Offset: 0x001E3AAC
			internal bool \u000A(ICategoryModel \u001F)
			{
				return \u0017\u001C\u0018.\u000A(\u001F) == \u0003\u0016\u0006.\u000A(ref this.\u001F);
			}

			// Token: 0x0400226A RID: 8810
			public KeyValuePair<long, List<Element>> \u001F;
		}

		// Token: 0x0200089F RID: 2207
		[CompilerGenerated]
		private sealed class \u0020\u000F
		{
			// Token: 0x06004FB2 RID: 20402 RVA: 0x001E58E4 File Offset: 0x001E3AE4
			internal bool \u000A(ICategoryModel \u001F)
			{
				return \u0017\u001C\u0018.\u000A(\u001F) == \u0003\u0016\u0006.\u000A(ref this.\u001F);
			}

			// Token: 0x0400226B RID: 8811
			public KeyValuePair<long, List<Element>> \u001F;
		}

		// Token: 0x020008A0 RID: 2208
		[CompilerGenerated]
		private sealed class \u0017\u000F
		{
			// Token: 0x06004FB4 RID: 20404 RVA: 0x001E591C File Offset: 0x001E3B1C
			internal bool \u000A(Category \u001F)
			{
				return \u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u001F)) == \u0017\u001C\u0018.\u000A(this.\u001F);
			}

			// Token: 0x0400226C RID: 8812
			public ICategoryModel \u001F;
		}
	}
}
