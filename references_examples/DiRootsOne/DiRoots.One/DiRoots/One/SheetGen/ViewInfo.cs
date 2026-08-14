using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using DiRoots.One.SheetGen.Data;
using DiRoots.One.SheetGen.DI.Interfaces;
using DiRoots.One.UIBehaviours.Extensions;
using DiRoots.One.UIBehaviours.Models;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002C1 RID: 705
	public class ViewInfo : ModelBase
	{
		// Token: 0x06001C72 RID: 7282 RVA: 0x000B5798 File Offset: 0x000B3998
		public ViewInfo()
		{
			\u000A\u0008\u0016.\u0007(this, new List<ViewData>());
		}

		// Token: 0x06001C73 RID: 7283 RVA: 0x000B57B8 File Offset: 0x000B39B8
		public ViewInfo(ViewTemplate template, SheetInfo sheetInfo, bool optimized)
		{
			this.OwnerSheet = sheetInfo;
			\u000C\u0004\u0016.\u001D(this, \u001C\u0008\u0016.\u000A(template));
			\u0003\u0008\u0016.\u0007(this, \u001C\u0008\u0016.\u000A(template));
			\u000F\u0008\u0016.\u000A(this, \u0012\u0008\u0016.\u000A(template));
			\u0019\u0019\u0016.\u001D(this, \u0006\u0008\u0016.\u000A(template));
			\u000B\u0008\u0016.\u000A(this, \u0002\u0008\u0016.\u000A(template));
			\u0005\u0008\u0016.\u000A(this, \u0016\u0008\u0016.\u000A(template));
			\u0019\u0008\u0016.\u0007(this, \u0018\u0008\u0016.\u000A(template));
			if (!optimized)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo..ctor(ViewTemplate, SheetInfo, bool)).MethodHandle;
				}
				this.IO();
			}
			else
			{
				\u000A\u0008\u0016.\u0007(this, new List<ViewData>());
				ViewData u000A;
				\u0017\u0019\u0016.\u001D(this, u000A = new ViewData());
				\u0002\u0010\u0016.\u001D(this, u000A);
			}
			List<BatchAction> list = new List<BatchAction>(4);
			BatchAction batchAction = new BatchAction();
			\u0016\u0007\u0019.\u000A(batchAction, "");
			\u0005\u0007\u0019.\u000A(batchAction, 0);
			\u0011\u0007\u0019.\u000A(batchAction, true);
			\u001D\u0008\u0016.\u000A(batchAction, this);
			\u0006\u0007\u0019.\u000A(list, batchAction);
			BatchAction batchAction2 = new BatchAction();
			\u0016\u0007\u0019.\u000A(batchAction2, \u0004\u0008\u0016.\u000A());
			\u0005\u0007\u0019.\u000A(batchAction2, 0);
			\u001D\u0008\u0016.\u000A(batchAction2, this);
			\u0006\u0007\u0019.\u000A(list, batchAction2);
			BatchAction batchAction3 = new BatchAction();
			\u0016\u0007\u0019.\u000A(batchAction3, \u0017\u001F\u0005.\u000A());
			\u0005\u0007\u0019.\u000A(batchAction3, 0);
			\u001D\u0008\u0016.\u000A(batchAction3, this);
			\u0006\u0007\u0019.\u000A(list, batchAction3);
			BatchAction batchAction4 = new BatchAction();
			\u0016\u0007\u0019.\u000A(batchAction4, \u000C\u001A\u0019.\u000A());
			\u0005\u0007\u0019.\u000A(batchAction4, 0);
			\u001D\u0008\u0016.\u000A(batchAction4, this);
			\u0006\u0007\u0019.\u000A(list, batchAction4);
			\u0007\u0008\u0016.\u000A(this, list);
		}

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x06001C74 RID: 7284 RVA: 0x000B591C File Offset: 0x000B3B1C
		// (remove) Token: 0x06001C75 RID: 7285 RVA: 0x000B5968 File Offset: 0x000B3B68
		public event ViewInfo.ViewEditedHandler ViewEdited
		{
			[CompilerGenerated]
			add
			{
				ViewInfo.ViewEditedHandler viewEditedHandler = this.XS;
				ViewInfo.ViewEditedHandler viewEditedHandler2;
				do
				{
					viewEditedHandler2 = viewEditedHandler;
					ViewInfo.ViewEditedHandler value2 = (ViewInfo.ViewEditedHandler)\u000F\u001E\u000A.\u000A(viewEditedHandler2, value);
					viewEditedHandler = Interlocked.CompareExchange<ViewInfo.ViewEditedHandler>(ref this.XS, value2, viewEditedHandler2);
				}
				while (viewEditedHandler != viewEditedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.add_ViewEdited(ViewInfo.ViewEditedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ViewInfo.ViewEditedHandler viewEditedHandler = this.XS;
				ViewInfo.ViewEditedHandler viewEditedHandler2;
				do
				{
					viewEditedHandler2 = viewEditedHandler;
					ViewInfo.ViewEditedHandler value2 = (ViewInfo.ViewEditedHandler)\u0012\u001E\u000A.\u000A(viewEditedHandler2, value);
					viewEditedHandler = Interlocked.CompareExchange<ViewInfo.ViewEditedHandler>(ref this.XS, value2, viewEditedHandler2);
				}
				while (viewEditedHandler != viewEditedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.remove_ViewEdited(ViewInfo.ViewEditedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x170007EE RID: 2030
		// (get) Token: 0x06001C76 RID: 7286 RVA: 0x000B59B4 File Offset: 0x000B3BB4
		// (set) Token: 0x06001C77 RID: 7287 RVA: 0x000B59C8 File Offset: 0x000B3BC8
		public string ColumnText { get; set; }

		// Token: 0x170007EF RID: 2031
		// (get) Token: 0x06001C78 RID: 7288 RVA: 0x000B59DC File Offset: 0x000B3BDC
		// (set) Token: 0x06001C79 RID: 7289 RVA: 0x000B59F0 File Offset: 0x000B3BF0
		public long ViewPortTypeId { get; set; }

		// Token: 0x170007F0 RID: 2032
		// (get) Token: 0x06001C7A RID: 7290 RVA: 0x000B5A04 File Offset: 0x000B3C04
		public string DisplayType
		{
			get
			{
				return \u001D\u0019\u0016.\u001D(this).\u001F();
			}
		}

		// Token: 0x170007F1 RID: 2033
		// (get) Token: 0x06001C7B RID: 7291 RVA: 0x000B5A20 File Offset: 0x000B3C20
		// (set) Token: 0x06001C7C RID: 7292 RVA: 0x000B5A34 File Offset: 0x000B3C34
		public ViewType Type
		{
			get
			{
				return this.VS;
			}
			set
			{
				this.VS = value;
				\u0007\u0013\u000A.\u000A(this, "Type");
				\u0007\u0013\u000A.\u000A(this, "DisplayType");
			}
		}

		// Token: 0x170007F2 RID: 2034
		// (get) Token: 0x06001C7D RID: 7293 RVA: 0x000B5A60 File Offset: 0x000B3C60
		// (set) Token: 0x06001C7E RID: 7294 RVA: 0x000B5A74 File Offset: 0x000B3C74
		public XYZLocation ViewLocationOnSheet { get; set; }

		// Token: 0x170007F3 RID: 2035
		// (get) Token: 0x06001C7F RID: 7295 RVA: 0x000B5A88 File Offset: 0x000B3C88
		// (set) Token: 0x06001C80 RID: 7296 RVA: 0x000B5A9C File Offset: 0x000B3C9C
		public ViewportRotation Rotation { get; set; }

		// Token: 0x170007F4 RID: 2036
		// (get) Token: 0x06001C81 RID: 7297 RVA: 0x000B5AB0 File Offset: 0x000B3CB0
		// (set) Token: 0x06001C82 RID: 7298 RVA: 0x000B5AC4 File Offset: 0x000B3CC4
		public List<ViewData> Views { get; set; }

		// Token: 0x170007F5 RID: 2037
		// (get) Token: 0x06001C83 RID: 7299 RVA: 0x000B5AD8 File Offset: 0x000B3CD8
		// (set) Token: 0x06001C84 RID: 7300 RVA: 0x000B5AEC File Offset: 0x000B3CEC
		public ViewData OldInitialView { get; set; }

		// Token: 0x170007F6 RID: 2038
		// (get) Token: 0x06001C85 RID: 7301 RVA: 0x000B5B00 File Offset: 0x000B3D00
		// (set) Token: 0x06001C86 RID: 7302 RVA: 0x000B5B14 File Offset: 0x000B3D14
		public ViewData CurrentView
		{
			get
			{
				return this.MS;
			}
			set
			{
				this.MS = value;
				\u0007\u0013\u000A.\u000A(this, "CurrentView");
				if (\u000E\u0019\u0016.\u001D(this))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.set_CurrentView(ViewData)).MethodHandle;
					}
					ViewInfo.ViewEditedHandler xs = this.XS;
					if (xs == null)
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
					}
					else
					{
						\u000D\u0008\u0016.\u000A(xs);
					}
					if (\u0008\u0013\u000A.\u000A(\u0014\u0019\u0016.\u0007(\u0002\u0019\u0016.\u001D(this)), ""))
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
						\u0020\u0019\u0016.\u001D(this, UpdateStates.ToTrash);
						return;
					}
					\u0020\u0019\u0016.\u001D(this, UpdateStates.Modified);
				}
			}
		}

		// Token: 0x170007F7 RID: 2039
		// (get) Token: 0x06001C87 RID: 7303 RVA: 0x000B5BA4 File Offset: 0x000B3DA4
		// (set) Token: 0x06001C88 RID: 7304 RVA: 0x000B5BB8 File Offset: 0x000B3DB8
		public long ViewPortId { get; set; }

		// Token: 0x170007F8 RID: 2040
		// (get) Token: 0x06001C89 RID: 7305 RVA: 0x000B5BCC File Offset: 0x000B3DCC
		// (set) Token: 0x06001C8A RID: 7306 RVA: 0x000B5BE0 File Offset: 0x000B3DE0
		public long OldViewPortId { get; set; }

		// Token: 0x170007F9 RID: 2041
		// (get) Token: 0x06001C8B RID: 7307 RVA: 0x000B5BF4 File Offset: 0x000B3DF4
		// (set) Token: 0x06001C8C RID: 7308 RVA: 0x000B5C08 File Offset: 0x000B3E08
		public XYZ LabelOffset { get; set; }

		// Token: 0x170007FA RID: 2042
		// (get) Token: 0x06001C8D RID: 7309 RVA: 0x000B5C1C File Offset: 0x000B3E1C
		// (set) Token: 0x06001C8E RID: 7310 RVA: 0x000B5C30 File Offset: 0x000B3E30
		public double LabelLineLength { get; set; }

		// Token: 0x170007FB RID: 2043
		// (get) Token: 0x06001C8F RID: 7311 RVA: 0x000B5C44 File Offset: 0x000B3E44
		public SheetInfo OwnerSheet { get; }

		// Token: 0x170007FC RID: 2044
		// (get) Token: 0x06001C90 RID: 7312 RVA: 0x000B5C58 File Offset: 0x000B3E58
		// (set) Token: 0x06001C91 RID: 7313 RVA: 0x000B5C6C File Offset: 0x000B3E6C
		public ViewData InitialView { get; set; }

		// Token: 0x170007FD RID: 2045
		// (get) Token: 0x06001C92 RID: 7314 RVA: 0x000B5C80 File Offset: 0x000B3E80
		// (set) Token: 0x06001C93 RID: 7315 RVA: 0x000B5C94 File Offset: 0x000B3E94
		public IList<BatchAction> ViewOptions { get; set; }

		// Token: 0x170007FE RID: 2046
		// (get) Token: 0x06001C94 RID: 7316 RVA: 0x000B5CA8 File Offset: 0x000B3EA8
		// (set) Token: 0x06001C95 RID: 7317 RVA: 0x000B5CBC File Offset: 0x000B3EBC
		public BatchAction SelectedViewOption
		{
			get
			{
				return this.ZS;
			}
			set
			{
				base.SetProperty<BatchAction>(ref this.ZS, value, null, "SelectedViewOption");
			}
		}

		// Token: 0x170007FF RID: 2047
		// (get) Token: 0x06001C96 RID: 7318 RVA: 0x000B5CE0 File Offset: 0x000B3EE0
		// (set) Token: 0x06001C97 RID: 7319 RVA: 0x000B5CF4 File Offset: 0x000B3EF4
		public UpdateStates Status
		{
			get
			{
				return this.BL;
			}
			set
			{
				base.SetProperty<UpdateStates>(ref this.BL, value, null, "Status");
			}
		}

		// Token: 0x17000800 RID: 2048
		// (get) Token: 0x06001C98 RID: 7320 RVA: 0x000B5D18 File Offset: 0x000B3F18
		// (set) Token: 0x06001C99 RID: 7321 RVA: 0x000B5D2C File Offset: 0x000B3F2C
		public bool NeedsViewPortLocationUpdate { get; set; }

		// Token: 0x06001C9A RID: 7322 RVA: 0x000B5D40 File Offset: 0x000B3F40
		private void IO()
		{
			ViewInfo.\u0020\u001B u0020_u001B = new ViewInfo.\u0020\u001B();
			u0020_u001B.\u001F = this;
			\u000A\u0008\u0016.\u0007(this, \u0010\u0002\u0016.\u000A(\u000E\u0002\u0016.\u0007(Collector.\u0004), \u001D\u0019\u0016.\u001D(this)));
			u0020_u001B.\u000A = Enumerable.FirstOrDefault<ViewTemplate>(\u000E\u0007\u0016.\u0007(\u0008\u0007\u0016.\u0007(\u0010\u0008\u0016.\u0007(this))), new Func<ViewTemplate, bool>(u0020_u001B.\u0007));
			ViewData u000A;
			if (u0020_u001B.\u000A != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.IO()).MethodHandle;
				}
				ViewData viewData;
				if ((viewData = Enumerable.FirstOrDefault<ViewData>(\u0006\u0010\u0016.\u001D(this), new Func<ViewData, bool>(u0020_u001B.\u001D))) == null)
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
					viewData = Enumerable.FirstOrDefault<ViewData>(\u0006\u0010\u0016.\u001D(this));
				}
				\u0017\u0019\u0016.\u001D(this, u000A = viewData);
				\u0002\u0010\u0016.\u001D(this, u000A);
				return;
			}
			\u0017\u0019\u0016.\u001D(this, u000A = Enumerable.First<ViewData>(\u0006\u0010\u0016.\u001D(this)));
			\u0002\u0010\u0016.\u001D(this, u000A);
		}

		// Token: 0x06001C9B RID: 7323 RVA: 0x000B5E30 File Offset: 0x000B4030
		public void RefreshViews(long id)
		{
			ViewInfo.\u0017\u001B u0017_u001B = new ViewInfo.\u0017\u001B();
			u0017_u001B.\u001F = id;
			\u000A\u0008\u0016.\u0007(this, \u0010\u0002\u0016.\u000A(\u000E\u0002\u0016.\u0007(Collector.\u0004), \u001D\u0019\u0016.\u001D(this)));
			\u0008\u0008\u0016.\u000A(this, \u000E\u0008\u0016.\u000A(this));
			ViewData viewData = Enumerable.FirstOrDefault<ViewData>(\u0006\u0010\u0016.\u001D(this), new Func<ViewData, bool>(u0017_u001B.\u000A));
			ViewData u000A;
			if ((u000A = viewData) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.RefreshViews(long)).MethodHandle;
				}
				u000A = \u000E\u0008\u0016.\u000A(this);
			}
			\u0017\u0019\u0016.\u001D(this, u000A);
			ViewData u000A2;
			if ((u000A2 = viewData) == null)
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
				u000A2 = \u0002\u0019\u0016.\u001D(this);
			}
			\u0002\u0010\u0016.\u001D(this, u000A2);
			\u0020\u0019\u0016.\u001D(this, UpdateStates.Updated);
		}

		// Token: 0x06001C9C RID: 7324 RVA: 0x000B5EE4 File Offset: 0x000B40E4
		public bool IsEdited()
		{
			ViewData viewData = \u000E\u0008\u0016.\u000A(this);
			long? num;
			long? num2;
			if (viewData == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.IsEdited()).MethodHandle;
				}
				\u000B\u0019\u000E.\u001F(ref num);
				num2 = num;
			}
			else
			{
				num2 = new long?(\u000B\u0019\u0016.\u001D(viewData));
			}
			long? num3 = num2;
			ViewData viewData2 = \u0002\u0019\u0016.\u001D(this);
			long? num4;
			if (viewData2 == null)
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
				\u000B\u0019\u000E.\u001F(ref num);
				num4 = num;
			}
			else
			{
				num4 = new long?(\u000B\u0019\u0016.\u001D(viewData2));
			}
			long? num5 = num4;
			return !(\u0012\u001B\u0018.\u000A(ref num3) == \u0012\u001B\u0018.\u000A(ref num5) & \u0016\u0002\u0004.\u000A(ref num3) == \u0016\u0002\u0004.\u000A(ref num5));
		}

		// Token: 0x06001C9D RID: 7325 RVA: 0x000B5F80 File Offset: 0x000B4180
		[BindableMethod("SelectView")]
		public void SelectView(Window wnd)
		{
			ViewInfo.\u0014\u001B u0014_u001B = new ViewInfo.\u0014\u001B();
			u0014_u001B.\u001F = \u000E\u001B\u000A.\u0004.GetService<ISelectView>(false);
			\u0014\u0008\u0016.\u000A(u0014_u001B.\u001F, wnd);
			\u0017\u0008\u0016.\u000A(u0014_u001B.\u001F, \u001D\u0019\u0016.\u001D(this));
			bool? flag = \u0020\u0008\u0016.\u000A(u0014_u001B.\u001F);
			if (\u0012\u0015\u000A.\u000A(ref flag))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.SelectView(Window)).MethodHandle;
				}
				if (!\u001E\u0008\u0016.\u000A(u0014_u001B.\u001F))
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
					if (\u0011\u0008\u0016.\u000A(u0014_u001B.\u001F) != 0)
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
						\u0019\u0008\u0016.\u0007(this, \u0011\u0008\u0016.\u000A(u0014_u001B.\u001F));
						\u000A\u0008\u0016.\u0007(this, \u0010\u0002\u0016.\u000A(\u000E\u0002\u0016.\u0007(Collector.\u0004), \u001D\u0019\u0016.\u001D(this)));
						\u0002\u0010\u0016.\u001D(this, Enumerable.FirstOrDefault<ViewData>(\u0006\u0010\u0016.\u001D(this), new Func<ViewData, bool>(u0014_u001B.\u000A)));
						return;
					}
					IEnumerable<KeyValuePair<ViewType, List<ViewData>>> enumerable = \u000E\u0002\u0016.\u0007(Collector.\u0004);
					Func<KeyValuePair<ViewType, List<ViewData>>, IEnumerable<ViewData>> func;
					if ((func = ViewInfo.<>c.\u000A) == null)
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
						func = (ViewInfo.<>c.\u000A = new Func<KeyValuePair<ViewType, List<ViewData>>, IEnumerable<ViewData>>(ViewInfo.<>c.\u001F.\u0007));
					}
					\u000A\u0008\u0016.\u0007(this, Enumerable.ToList<ViewData>(Enumerable.SelectMany<KeyValuePair<ViewType, List<ViewData>>, ViewData>(enumerable, func)));
					\u0002\u0010\u0016.\u001D(this, Enumerable.FirstOrDefault<ViewData>(\u0006\u0010\u0016.\u001D(this), new Func<ViewData, bool>(u0014_u001B.\u0007)));
					\u0019\u0008\u0016.\u0007(this, \u001B\u0008\u0016.\u000A(\u0002\u0019\u0016.\u001D(this)));
					\u000A\u0008\u0016.\u0007(this, \u0010\u0002\u0016.\u000A(\u000E\u0002\u0016.\u0007(Collector.\u0004), \u001D\u0019\u0016.\u001D(this)));
					return;
				}
				else
				{
					\u0002\u0010\u0016.\u001D(this, Enumerable.FirstOrDefault<ViewData>(\u0006\u0010\u0016.\u001D(this)));
				}
			}
		}

		// Token: 0x06001C9E RID: 7326 RVA: 0x000B6140 File Offset: 0x000B4340
		[BindableMethod("ViewOptionChanged")]
		public void ViewOptionChanged(Window wnd)
		{
			if (\u0008\u0013\u000A.\u000A(\u0013\u000B\u0019.\u0007(\u000C\u0008\u0016.\u000A(this)), \u0004\u0008\u0016.\u000A()))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.ViewOptionChanged(Window)).MethodHandle;
				}
				\u0002\u0010\u0016.\u001D(this, Enumerable.FirstOrDefault<ViewData>(\u0006\u0010\u0016.\u001D(this)));
			}
			else if (\u0008\u0013\u000A.\u000A(\u0013\u000B\u0019.\u0007(\u000C\u0008\u0016.\u000A(this)), \u0017\u001F\u0005.\u000A()))
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
				\u0015\u0008\u0016.\u000A(this, wnd);
			}
			else if (\u0008\u0013\u000A.\u000A(\u0013\u000B\u0019.\u0007(\u000C\u0008\u0016.\u000A(this)), \u000C\u001A\u0019.\u000A()))
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
				this.QO();
			}
			\u0013\u0008\u0016.\u000A(this, Enumerable.First<BatchAction>(\u001A\u0008\u0016.\u000A(this)));
		}

		// Token: 0x06001C9F RID: 7327 RVA: 0x000B620C File Offset: 0x000B440C
		private void QO()
		{
			try
			{
				Element u001F = \u0011\u0017\u000A.\u0007(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004), \u001E\u0001\u000A.\u000A(\u000B\u0019\u0016.\u0007(\u0002\u0019\u0016.\u001D(this))));
				\u001D\u0010\u0007.\u0007(\u000B\u001F\u0016.\u0007(DocumentAccessProvider.\u0004), \u0005\u001F\u000E.\u001F(u001F));
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Models\\SheetsAggregate\\ViewInfo.cs", "OpenView");
			}
		}

		// Token: 0x06001CA0 RID: 7328 RVA: 0x000B628C File Offset: 0x000B448C
		internal string AO(string F)
		{
			ViewInfo.\u0013\u001B u0013_u001B = new ViewInfo.\u0013\u001B();
			u0013_u001B.\u001F = F;
			u0013_u001B.\u000A = this;
			u0013_u001B.\u0007 = \u0011\u0020\u000A.\u0007(\u000B\u001F\u0016.\u0007(DocumentAccessProvider.\u0004));
			List<ViewData> list = Enumerable.ToList<ViewData>(Enumerable.Where<ViewData>(\u0006\u0010\u0016.\u001D(this), new Func<ViewData, bool>(u0013_u001B.\u001D)));
			if (Enumerable.Any<ViewData>(list))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.AO(string)).MethodHandle;
				}
				ViewData viewData;
				if ((viewData = Enumerable.FirstOrDefault<ViewData>(list, new Func<ViewData, bool>(u0013_u001B.\u0004))) == null)
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
					viewData = Enumerable.FirstOrDefault<ViewData>(list, new Func<ViewData, bool>(u0013_u001B.\u0019));
				}
				ViewData viewData2 = viewData;
				if (viewData2 == null)
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
					return \u0002\u0013\u000A.\u000A(u0013_u001B.\u001F, ":", \u0001\u0008\u0016.\u000A());
				}
				\u0002\u0010\u0016.\u001D(this, viewData2);
			}
			else
			{
				\u0002\u0010\u0016.\u001D(this, Enumerable.FirstOrDefault<ViewData>(\u0006\u0010\u0016.\u001D(this)));
			}
			return string.Empty;
		}

		// Token: 0x06001CA1 RID: 7329 RVA: 0x000B638C File Offset: 0x000B458C
		private static bool GO(Document F, long R)
		{
			View view = \u0005\u001F\u000E.\u001F(\u0011\u0017\u000A.\u0007(F, \u001E\u0001\u000A.\u000A(R)));
			if (view != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.GO(Document, long)).MethodHandle;
				}
				return !\u000E\u0013.\u0004(F, view);
			}
			return false;
		}

		// Token: 0x04000B6D RID: 2925
		private ViewData MS;

		// Token: 0x04000B6E RID: 2926
		private ViewType VS;

		// Token: 0x04000B6F RID: 2927
		private BatchAction ZS;

		// Token: 0x04000B70 RID: 2928
		private UpdateStates BL;

		// Token: 0x04000B71 RID: 2929
		[CompilerGenerated]
		private ViewInfo.ViewEditedHandler XS;

		// Token: 0x04000B72 RID: 2930
		[CompilerGenerated]
		private string PS;

		// Token: 0x04000B73 RID: 2931
		[CompilerGenerated]
		private long OS;

		// Token: 0x04000B74 RID: 2932
		[CompilerGenerated]
		private XYZLocation TS;

		// Token: 0x04000B75 RID: 2933
		[CompilerGenerated]
		private ViewportRotation IS;

		// Token: 0x04000B76 RID: 2934
		[CompilerGenerated]
		private List<ViewData> ER;

		// Token: 0x04000B77 RID: 2935
		[CompilerGenerated]
		private ViewData QS;

		// Token: 0x04000B78 RID: 2936
		[CompilerGenerated]
		private long SR;

		// Token: 0x04000B79 RID: 2937
		[CompilerGenerated]
		private long AS;

		// Token: 0x04000B7A RID: 2938
		[CompilerGenerated]
		private XYZ GS;

		// Token: 0x04000B7B RID: 2939
		[CompilerGenerated]
		private double FB;

		// Token: 0x04000B7C RID: 2940
		[CompilerGenerated]
		private readonly SheetInfo RB;

		// Token: 0x04000B7D RID: 2941
		[CompilerGenerated]
		private ViewData DB;

		// Token: 0x04000B7E RID: 2942
		[CompilerGenerated]
		private IList<BatchAction> HB;

		// Token: 0x04000B7F RID: 2943
		[CompilerGenerated]
		private bool YB;

		// Token: 0x0200099C RID: 2460
		// (Invoke) Token: 0x0600534F RID: 21327
		public delegate void ViewEditedHandler();

		// Token: 0x0200099E RID: 2462
		[CompilerGenerated]
		private sealed class \u0020\u001B
		{
			// Token: 0x06005356 RID: 21334 RVA: 0x001EC4BC File Offset: 0x001EA6BC
			internal bool \u0007(ViewTemplate \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0015\u0002\u0010.\u001D(this.\u001F), \u0012\u0008\u0016.\u000A(\u001F));
			}

			// Token: 0x06005357 RID: 21335 RVA: 0x001EC4E8 File Offset: 0x001EA6E8
			internal bool \u001D(ViewData \u001F)
			{
				return \u000B\u0019\u0016.\u0007(\u001F) == \u0020\u0016\u0002.\u000A(this.\u000A);
			}

			// Token: 0x040024FF RID: 9471
			public ViewInfo \u001F;

			// Token: 0x04002500 RID: 9472
			public ViewTemplate \u000A;
		}

		// Token: 0x0200099F RID: 2463
		[CompilerGenerated]
		private sealed class \u0017\u001B
		{
			// Token: 0x06005359 RID: 21337 RVA: 0x001EC520 File Offset: 0x001EA720
			internal bool \u000A(ViewData \u001F)
			{
				return \u000B\u0019\u0016.\u0007(\u001F) == this.\u001F;
			}

			// Token: 0x04002501 RID: 9473
			public long \u001F;
		}

		// Token: 0x020009A0 RID: 2464
		[CompilerGenerated]
		private sealed class \u0014\u001B
		{
			// Token: 0x0600535B RID: 21339 RVA: 0x001EC554 File Offset: 0x001EA754
			internal bool \u000A(ViewData \u001F)
			{
				return \u000B\u0019\u0016.\u0007(\u001F) == \u0017\u0016\u0016.\u000A(\u0004\u0006\u0010.\u000A(this.\u001F));
			}

			// Token: 0x0600535C RID: 21340 RVA: 0x001EC580 File Offset: 0x001EA780
			internal bool \u0007(ViewData \u001F)
			{
				return \u000B\u0019\u0016.\u0007(\u001F) == \u0017\u0016\u0016.\u000A(\u0004\u0006\u0010.\u000A(this.\u001F));
			}

			// Token: 0x04002502 RID: 9474
			public ISelectView \u001F;
		}

		// Token: 0x020009A1 RID: 2465
		[CompilerGenerated]
		private sealed class \u0013\u001B
		{
			// Token: 0x0600535E RID: 21342 RVA: 0x001EC5C0 File Offset: 0x001EA7C0
			internal bool \u001D(ViewData \u001F)
			{
				return \u000D\u0008\u000A.\u000A(\u0019\u0006\u0010.\u000A(\u001F), this.\u001F, true);
			}

			// Token: 0x0600535F RID: 21343 RVA: 0x001EC5E4 File Offset: 0x001EA7E4
			internal bool \u0004(ViewData \u001F)
			{
				long num = \u000B\u0019\u0016.\u0007(\u001F);
				ViewData viewData = \u0002\u0019\u0016.\u001D(this.\u000A);
				long? num3;
				if (viewData == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.\u0013\u001B.\u0004(ViewData)).MethodHandle;
					}
					long? num2;
					\u000B\u0019\u000E.\u001F(ref num2);
					num3 = num2;
				}
				else
				{
					num3 = new long?(\u000B\u0019\u0016.\u001D(viewData));
				}
				long? num4 = num3;
				return num == \u0012\u001B\u0018.\u000A(ref num4) & \u0016\u0002\u0004.\u000A(ref num4);
			}

			// Token: 0x06005360 RID: 21344 RVA: 0x001EC64C File Offset: 0x001EA84C
			internal bool \u0019(ViewData \u001F)
			{
				return ViewInfo.GO(this.\u0007, \u000B\u0019\u0016.\u0007(\u001F));
			}

			// Token: 0x04002503 RID: 9475
			public string \u001F;

			// Token: 0x04002504 RID: 9476
			public ViewInfo \u000A;

			// Token: 0x04002505 RID: 9477
			public Document \u0007;
		}
	}
}
