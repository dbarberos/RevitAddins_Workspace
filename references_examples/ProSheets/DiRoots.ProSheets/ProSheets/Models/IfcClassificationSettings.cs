using System;
using A;
using DiRoots.One.Commons.Models;

namespace ProSheets.Models
{
	// Token: 0x02000101 RID: 257
	public class IfcClassificationSettings : ModelBase
	{
		// Token: 0x06000C89 RID: 3209 RVA: 0x0004A144 File Offset: 0x00048344
		public IfcClassificationSettings()
		{
			\u0005\u000C\u0016.\u0003(this, \u001F\u0018\u0016.\u0018());
		}

		// Token: 0x06000C8A RID: 3210 RVA: 0x0004A164 File Offset: 0x00048364
		private IfcClassificationSettings(IfcClassificationSettings P)
		{
			\u0007\u0001\u0003.\u0003(this, \u0010\u0001\u0003.\u0014(P));
			\u000B\u0001\u0003.\u0003(this, \u0019\u0001\u0003.\u0014(P));
			\u001D\u0001\u0003.\u0003(this, \u001A\u0001\u0003.\u0014(P));
			\u0005\u000C\u0016.\u0003(this, \u001E\u000C\u0016.\u0014(P));
			\u001B\u000C\u0016.\u0003(this, \u0015\u000C\u0016.\u0014(P));
			\u0007\u000C\u0016.\u0003(this, \u0011\u000C\u0016.\u0014(P));
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x06000C8B RID: 3211 RVA: 0x0004A1CC File Offset: 0x000483CC
		// (set) Token: 0x06000C8C RID: 3212 RVA: 0x0004A1E0 File Offset: 0x000483E0
		public string ClassificationName
		{
			get
			{
				return this.SB;
			}
			set
			{
				this.SB = value;
				\u0007\u001B\u0018.\u0018(this, "ClassificationNameTextBox");
			}
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x06000C8D RID: 3213 RVA: 0x0004A200 File Offset: 0x00048400
		// (set) Token: 0x06000C8E RID: 3214 RVA: 0x0004A214 File Offset: 0x00048414
		public string ClassificationEdition
		{
			get
			{
				return this.UB;
			}
			set
			{
				this.UB = value;
				\u0007\u001B\u0018.\u0018(this, "ClassificationEditionTextBox");
			}
		}

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x06000C8F RID: 3215 RVA: 0x0004A234 File Offset: 0x00048434
		// (set) Token: 0x06000C90 RID: 3216 RVA: 0x0004A248 File Offset: 0x00048448
		public string ClassificationSource
		{
			get
			{
				return this.LB;
			}
			set
			{
				this.LB = value;
				\u0007\u001B\u0018.\u0018(this, "ClassificationSourceTextBox");
			}
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x06000C91 RID: 3217 RVA: 0x0004A268 File Offset: 0x00048468
		// (set) Token: 0x06000C92 RID: 3218 RVA: 0x0004A27C File Offset: 0x0004847C
		public DateTime ClassificationEditionDate
		{
			get
			{
				return this.EB;
			}
			set
			{
				this.EB = value;
				\u0007\u001B\u0018.\u0018(this, "datePicker1");
			}
		}

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x06000C93 RID: 3219 RVA: 0x0004A29C File Offset: 0x0004849C
		// (set) Token: 0x06000C94 RID: 3220 RVA: 0x0004A2B0 File Offset: 0x000484B0
		public string ClassificationLocation
		{
			get
			{
				return this.GB;
			}
			set
			{
				this.GB = value;
				\u0007\u001B\u0018.\u0018(this, "ClassificationLocationTextBox");
			}
		}

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x06000C95 RID: 3221 RVA: 0x0004A2D0 File Offset: 0x000484D0
		// (set) Token: 0x06000C96 RID: 3222 RVA: 0x0004A2E4 File Offset: 0x000484E4
		public string ClassificationFieldName
		{
			get
			{
				return this.AB;
			}
			set
			{
				this.AB = value;
				\u0007\u001B\u0018.\u0018(this, "ClassificationFieldNameTextBox");
			}
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x0004A304 File Offset: 0x00048504
		internal string FQ()
		{
			return \u0001\u0004\u0016.\u0018(this);
		}

		// Token: 0x06000C98 RID: 3224 RVA: 0x0004A31C File Offset: 0x0004851C
		public bool IsUnchanged(IfcClassificationSettings classificationToCheck)
		{
			if (\u0016\u001B\u0003.\u0018(\u0010\u0001\u0003.\u0003(this), \u0010\u0001\u0003.\u0014(classificationToCheck)) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcClassificationSettings.IsUnchanged(IfcClassificationSettings)).MethodHandle;
				}
				if (\u0016\u001B\u0003.\u0018(\u0019\u0001\u0003.\u0003(this), \u0019\u0001\u0003.\u0014(classificationToCheck)) == 0)
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
					if (\u0016\u001B\u0003.\u0018(\u001A\u0001\u0003.\u0003(this), \u001A\u0001\u0003.\u0014(classificationToCheck)) == 0)
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
						DateTime dateTime = \u001E\u000C\u0016.\u0003(this);
						if (\u001B\u0004\u0016.\u0018(ref dateTime, \u001E\u000C\u0016.\u0014(classificationToCheck)))
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
							if (\u0016\u001B\u0003.\u0018(\u0015\u000C\u0016.\u0003(this), \u0015\u000C\u0016.\u0014(classificationToCheck)) == 0)
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
								if (\u0016\u001B\u0003.\u0018(\u0011\u000C\u0016.\u0003(this), \u0011\u000C\u0016.\u0014(classificationToCheck)) == 0)
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
									return true;
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000C99 RID: 3225 RVA: 0x0004A414 File Offset: 0x00048614
		public bool AreMandatoryFieldsFilled()
		{
			if (!\u001F\u001A\u0018.\u0018(\u0010\u0001\u0003.\u0003(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcClassificationSettings.AreMandatoryFieldsFilled()).MethodHandle;
				}
				if (!\u001F\u001A\u0018.\u0018(\u0019\u0001\u0003.\u0003(this)))
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
					if (!\u001F\u001A\u0018.\u0018(\u001A\u0001\u0003.\u0003(this)))
					{
						return true;
					}
					for (;;)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
				}
			}
			return false;
		}

		// Token: 0x06000C9A RID: 3226 RVA: 0x0004A480 File Offset: 0x00048680
		public IfcClassificationSettings Clone()
		{
			return \u0005\u0004\u0016.\u0018(this);
		}

		// Token: 0x040005BD RID: 1469
		private string SB;

		// Token: 0x040005BE RID: 1470
		private string UB;

		// Token: 0x040005BF RID: 1471
		private string LB;

		// Token: 0x040005C0 RID: 1472
		private DateTime EB;

		// Token: 0x040005C1 RID: 1473
		private string GB;

		// Token: 0x040005C2 RID: 1474
		private string AB;
	}
}
