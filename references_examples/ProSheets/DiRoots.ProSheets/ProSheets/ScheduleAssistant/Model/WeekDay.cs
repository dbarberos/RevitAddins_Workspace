using System;
using A;
using DiRoots.One.Commons.Models;

namespace ProSheets.ScheduleAssistant.Model
{
	// Token: 0x020000B3 RID: 179
	[Serializable]
	public class WeekDay : ModelBase
	{
		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06000A48 RID: 2632 RVA: 0x0003E848 File Offset: 0x0003CA48
		// (set) Token: 0x06000A49 RID: 2633 RVA: 0x0003E85C File Offset: 0x0003CA5C
		public bool IsChecked
		{
			get
			{
				return this._isChecked;
			}
			set
			{
				this._isChecked = value;
				\u0007\u001B\u0018.\u0018(this, "IsChecked");
			}
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000A4A RID: 2634 RVA: 0x0003E87C File Offset: 0x0003CA7C
		// (set) Token: 0x06000A4B RID: 2635 RVA: 0x0003E890 File Offset: 0x0003CA90
		public DayOfWeek DayOfWeek { get; set; }

		// Token: 0x040004D4 RID: 1236
		private bool _isChecked;
	}
}
