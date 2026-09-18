using System;
using System.Collections.Generic;
using A;

namespace DiRoots.One.SheetGen.Models
{
	// Token: 0x02000376 RID: 886
	[Serializable]
	public class Settings
	{
		// Token: 0x17000A42 RID: 2626
		// (get) Token: 0x06002460 RID: 9312 RVA: 0x000DED00 File Offset: 0x000DCF00
		// (set) Token: 0x06002461 RID: 9313 RVA: 0x000DED14 File Offset: 0x000DCF14
		public List<ProfileMap> SGProfiles { get; set; }

		// Token: 0x17000A43 RID: 2627
		// (get) Token: 0x06002462 RID: 9314 RVA: 0x000DED28 File Offset: 0x000DCF28
		// (set) Token: 0x06002463 RID: 9315 RVA: 0x000DED3C File Offset: 0x000DCF3C
		public List<ProfileMap> VMProfiles { get; set; }

		// Token: 0x17000A44 RID: 2628
		// (get) Token: 0x06002464 RID: 9316 RVA: 0x000DED50 File Offset: 0x000DCF50
		// (set) Token: 0x06002465 RID: 9317 RVA: 0x000DEDC4 File Offset: 0x000DCFC4
		public string LastUsedPath
		{
			get
			{
				if (!\u0016\u0010\u000B.\u001D(\u000D\u0020\u0016.\u000A()))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Settings.get_LastUsedPath()).MethodHandle;
					}
					string lastPath = this._lastPath;
					bool flag;
					if (lastPath == null)
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
						flag = false;
					}
					else
					{
						flag = \u000F\u000C\u001D.\u001D(lastPath, \u0008\u0005\u0018.\u000A(Environment.SpecialFolder.Personal));
					}
					if (flag)
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
						return \u0008\u0005\u0018.\u000A(Environment.SpecialFolder.Desktop);
					}
				}
				return this._lastPath;
			}
			set
			{
				this._lastPath = value;
			}
		}

		// Token: 0x17000A45 RID: 2629
		// (get) Token: 0x06002466 RID: 9318 RVA: 0x000DEDD8 File Offset: 0x000DCFD8
		// (set) Token: 0x06002467 RID: 9319 RVA: 0x000DEE4C File Offset: 0x000DD04C
		public string ExcelLastUsedPath
		{
			get
			{
				if (!\u0016\u0010\u000B.\u001D(\u000D\u0020\u0016.\u000A()))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Settings.get_ExcelLastUsedPath()).MethodHandle;
					}
					string lastExcelPath = this._lastExcelPath;
					bool flag;
					if (lastExcelPath == null)
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
						flag = false;
					}
					else
					{
						flag = \u000F\u000C\u001D.\u001D(lastExcelPath, \u0008\u0005\u0018.\u000A(Environment.SpecialFolder.Personal));
					}
					if (flag)
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
						return \u0008\u0005\u0018.\u000A(Environment.SpecialFolder.Desktop);
					}
				}
				return this._lastExcelPath;
			}
			set
			{
				this._lastExcelPath = value;
			}
		}

		// Token: 0x17000A46 RID: 2630
		// (get) Token: 0x06002468 RID: 9320 RVA: 0x000DEE60 File Offset: 0x000DD060
		// (set) Token: 0x06002469 RID: 9321 RVA: 0x000DEE74 File Offset: 0x000DD074
		public bool BenchmarkPerformance { get; set; }

		// Token: 0x17000A47 RID: 2631
		// (get) Token: 0x0600246A RID: 9322 RVA: 0x000DEE88 File Offset: 0x000DD088
		// (set) Token: 0x0600246B RID: 9323 RVA: 0x000DEE9C File Offset: 0x000DD09C
		public bool UseApiSheetDuplication { get; set; } = true;

		// Token: 0x04000E6A RID: 3690
		private string _lastPath;

		// Token: 0x04000E6B RID: 3691
		private string _lastExcelPath;
	}
}
