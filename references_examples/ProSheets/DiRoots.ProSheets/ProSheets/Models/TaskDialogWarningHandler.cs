using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using ProSheets.Enums;

namespace ProSheets.Models
{
	// Token: 0x02000105 RID: 261
	public class TaskDialogWarningHandler
	{
		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x06000CAD RID: 3245 RVA: 0x0004A628 File Offset: 0x00048828
		// (set) Token: 0x06000CAE RID: 3246 RVA: 0x0004A63C File Offset: 0x0004883C
		public static TaskDialogWarningHandler Instance { get; set; }

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x06000CAF RID: 3247 RVA: 0x0004A650 File Offset: 0x00048850
		// (set) Token: 0x06000CB0 RID: 3248 RVA: 0x0004A664 File Offset: 0x00048864
		public List<View> CurrentViews { get; set; } = new List<View>();

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x06000CB1 RID: 3249 RVA: 0x0004A678 File Offset: 0x00048878
		// (set) Token: 0x06000CB2 RID: 3250 RVA: 0x0004A68C File Offset: 0x0004888C
		public int _dialogIndex { get; set; }

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x06000CB3 RID: 3251 RVA: 0x0004A6A0 File Offset: 0x000488A0
		// (set) Token: 0x06000CB4 RID: 3252 RVA: 0x0004A6B4 File Offset: 0x000488B4
		public bool IsCombined
		{
			get
			{
				return this.\u0018;
			}
			set
			{
				this.\u0018 = value;
				\u0016\u001D\u0016.\u0018(this, 1);
				this.\u0014 = false;
				this.\u0003 = false;
				this.\u0016 = false;
				this.\u000F = false;
				\u0003\u001D\u0016.\u0018(\u001A\u0008\u0014.\u0003(this));
			}
		}

		// Token: 0x06000CB5 RID: 3253 RVA: 0x0004A6F8 File Offset: 0x000488F8
		public int Handle(string dialogId, string message)
		{
			List<View> list = \u001A\u0008\u0014.\u0003(this);
			string text;
			if ((text = message) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TaskDialogWarningHandler.Handle(string, string)).MethodHandle;
				}
				text = string.Empty;
			}
			message = text;
			if (\u000F\u0002\u0018.\u0018(dialogId, "TaskDialog_Really_Print_Or_Export_Temp_View_Modes"))
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
				if (\u0012\u001D\u0016.\u0018(this))
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
					if (!this.\u0014)
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
						object u000C = \u001A\u0008\u0014.\u0003(this);
						Predicate<View> u;
						if ((u = TaskDialogWarningHandler.<>c.\u0018) == null)
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
							u = (TaskDialogWarningHandler.<>c.\u0018 = new Predicate<View>(TaskDialogWarningHandler.<>c.\u000C.\u0013));
						}
						if (\u000F\u001D\u0016.\u0018(u000C, u))
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
							this.\u0014 = true;
							return this.\u001C(\u0001\u0008\u0003.\u0018(\u000E\u000F\u0003.\u0018()));
						}
					}
					if (!this.\u0003)
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
						object u000C2 = \u001A\u0008\u0014.\u0003(this);
						Predicate<View> u2;
						if ((u2 = TaskDialogWarningHandler.<>c.\u0014) == null)
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
							u2 = (TaskDialogWarningHandler.<>c.\u0014 = new Predicate<View>(TaskDialogWarningHandler.<>c.\u000C.\u0009));
						}
						if (\u000F\u001D\u0016.\u0018(u000C2, u2))
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
							if (\u000A\u0017\u0014.\u0018(message, "/"))
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
								this.\u0003 = true;
								return this.\u001C(\u0005\u0008\u0003.\u0018(\u000E\u000F\u0003.\u0018()));
							}
						}
					}
					if (!this.\u0016)
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
						object u000C3 = \u001A\u0008\u0014.\u0003(this);
						Predicate<View> u3;
						if ((u3 = TaskDialogWarningHandler.<>c.\u0003) == null)
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
							u3 = (TaskDialogWarningHandler.<>c.\u0003 = new Predicate<View>(TaskDialogWarningHandler.<>c.\u000C.\u000A));
						}
						if (\u000F\u001D\u0016.\u0018(u000C3, u3))
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
							this.\u0016 = true;
							return this.\u001C(\u001B\u0008\u0003.\u0018(\u000E\u000F\u0003.\u0018()));
						}
					}
					if (!this.\u000F)
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
						object u000C4 = \u001A\u0008\u0014.\u0003(this);
						Predicate<View> u4;
						if ((u4 = TaskDialogWarningHandler.<>c.\u0016) == null)
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
							u4 = (TaskDialogWarningHandler.<>c.\u0016 = new Predicate<View>(TaskDialogWarningHandler.<>c.\u000C.\u0020));
						}
						if (\u000F\u001D\u0016.\u0018(u000C4, u4))
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
							this.\u000F = true;
							return this.\u001C(\u0008\u0008\u0003.\u0018(\u000E\u000F\u0003.\u0018()));
						}
					}
				}
				else if (Enumerable.Any<View>(list))
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
					object u000C5 = list;
					Predicate<View> u5;
					if ((u5 = TaskDialogWarningHandler.<>c.\u000F) == null)
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
						u5 = (TaskDialogWarningHandler.<>c.\u000F = new Predicate<View>(TaskDialogWarningHandler.<>c.\u000C.\u001F));
					}
					if (\u000F\u001D\u0016.\u0018(u000C5, u5))
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
						if (\u000A\u0017\u0014.\u0018(message, "/"))
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
							return this.\u001C(\u0005\u0008\u0003.\u0018(\u000E\u000F\u0003.\u0018()));
						}
					}
					object u000C6 = list;
					Predicate<View> u6;
					if ((u6 = TaskDialogWarningHandler.<>c.\u0012) == null)
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
						u6 = (TaskDialogWarningHandler.<>c.\u0012 = new Predicate<View>(TaskDialogWarningHandler.<>c.\u000C.\u0011));
					}
					if (\u000F\u001D\u0016.\u0018(u000C6, u6))
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
						return this.\u001C(\u001B\u0008\u0003.\u0018(\u000E\u000F\u0003.\u0018()));
					}
					object u000C7 = list;
					Predicate<View> u7;
					if ((u7 = TaskDialogWarningHandler.<>c.\u000D) == null)
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
						u7 = (TaskDialogWarningHandler.<>c.\u000D = new Predicate<View>(TaskDialogWarningHandler.<>c.\u000C.\u0015));
					}
					if (\u000F\u001D\u0016.\u0018(u000C7, u7))
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
						return this.\u001C(\u0001\u0008\u0003.\u0018(\u000E\u000F\u0003.\u0018()));
					}
					object u000C8 = list;
					Predicate<View> u8;
					if ((u8 = TaskDialogWarningHandler.<>c.\u001C) == null)
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
						u8 = (TaskDialogWarningHandler.<>c.\u001C = new Predicate<View>(TaskDialogWarningHandler.<>c.\u000C.\u0017));
					}
					if (\u000F\u001D\u0016.\u0018(u000C8, u8))
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
						return this.\u001C(\u0008\u0008\u0003.\u0018(\u000E\u000F\u0003.\u0018()));
					}
				}
				return -1;
			}
			if (\u000F\u0002\u0018.\u0018(dialogId, "TaskDialog_Update_Resources"))
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
				return 1001;
			}
			return -1;
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x0004AAF8 File Offset: 0x00048CF8
		private int \u001C(TemporaryModeOption \u000C)
		{
			if (\u000C != TemporaryModeOption.Leave)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TaskDialogWarningHandler.\u001C(TemporaryModeOption)).MethodHandle;
				}
				return 1001;
			}
			return 1002;
		}

		// Token: 0x040005CA RID: 1482
		[CompilerGenerated]
		private static TaskDialogWarningHandler \u000C;

		// Token: 0x040005CB RID: 1483
		private bool \u0018;

		// Token: 0x040005CC RID: 1484
		private bool \u0014;

		// Token: 0x040005CD RID: 1485
		private bool \u0003;

		// Token: 0x040005CE RID: 1486
		private bool \u0016;

		// Token: 0x040005CF RID: 1487
		private bool \u000F;

		// Token: 0x040005D0 RID: 1488
		[CompilerGenerated]
		private List<View> \u0012;

		// Token: 0x040005D1 RID: 1489
		[CompilerGenerated]
		private int \u000D;
	}
}
