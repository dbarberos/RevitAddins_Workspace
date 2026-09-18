using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.ViewRange.Model;

namespace DiRoots.One.ViewRange
{
	// Token: 0x02000292 RID: 658
	public class BatchViewRangeViewModel : ViewModelBase
	{
		// Token: 0x0600199D RID: 6557 RVA: 0x000A55AC File Offset: 0x000A37AC
		public BatchViewRangeViewModel(List<ViewInformation> viewInformation)
		{
			this.AWR(viewInformation);
		}

		// Token: 0x17000709 RID: 1801
		// (get) Token: 0x0600199E RID: 6558 RVA: 0x000A55D4 File Offset: 0x000A37D4
		// (set) Token: 0x0600199F RID: 6559 RVA: 0x000A55E8 File Offset: 0x000A37E8
		public string SelectItemTop
		{
			get
			{
				return this.AW;
			}
			set
			{
				this.AW = value;
				this.YK = true;
				\u000D\u0020\u000A.\u000A(this, "SelectItemTop");
			}
		}

		// Token: 0x1700070A RID: 1802
		// (get) Token: 0x060019A0 RID: 6560 RVA: 0x000A5610 File Offset: 0x000A3810
		// (set) Token: 0x060019A1 RID: 6561 RVA: 0x000A5624 File Offset: 0x000A3824
		public string SelectItemBottom
		{
			get
			{
				return this.GW;
			}
			set
			{
				this.GW = value;
				this.CK = true;
				\u000D\u0020\u000A.\u000A(this, "SelectItemBottom");
			}
		}

		// Token: 0x1700070B RID: 1803
		// (get) Token: 0x060019A2 RID: 6562 RVA: 0x000A564C File Offset: 0x000A384C
		// (set) Token: 0x060019A3 RID: 6563 RVA: 0x000A5660 File Offset: 0x000A3860
		public string SelectItemDepth
		{
			get
			{
				return this.FK;
			}
			set
			{
				this.FK = value;
				this.LK = true;
				\u000D\u0020\u000A.\u000A(this, "SelectItemDepth");
			}
		}

		// Token: 0x1700070C RID: 1804
		// (get) Token: 0x060019A4 RID: 6564 RVA: 0x000A5688 File Offset: 0x000A3888
		// (set) Token: 0x060019A5 RID: 6565 RVA: 0x000A569C File Offset: 0x000A389C
		public string OffsetTop
		{
			get
			{
				return this.RK;
			}
			set
			{
				this.RK = value;
				this.SK = true;
				\u000D\u0020\u000A.\u000A(this, "OffsetTop");
			}
		}

		// Token: 0x1700070D RID: 1805
		// (get) Token: 0x060019A6 RID: 6566 RVA: 0x000A56C4 File Offset: 0x000A38C4
		// (set) Token: 0x060019A7 RID: 6567 RVA: 0x000A56D8 File Offset: 0x000A38D8
		public string OffsetCutPlane
		{
			get
			{
				return this.DK;
			}
			set
			{
				this.DK = value;
				this.WK = true;
				\u000D\u0020\u000A.\u000A(this, "OffsetCutPlane");
			}
		}

		// Token: 0x1700070E RID: 1806
		// (get) Token: 0x060019A8 RID: 6568 RVA: 0x000A5700 File Offset: 0x000A3900
		// (set) Token: 0x060019A9 RID: 6569 RVA: 0x000A5714 File Offset: 0x000A3914
		public string OffsetBottom
		{
			get
			{
				return this.MY;
			}
			set
			{
				this.MY = value;
				this.BK = true;
				\u000D\u0020\u000A.\u000A(this, "OffsetBottom");
			}
		}

		// Token: 0x1700070F RID: 1807
		// (get) Token: 0x060019AA RID: 6570 RVA: 0x000A573C File Offset: 0x000A393C
		// (set) Token: 0x060019AB RID: 6571 RVA: 0x000A5750 File Offset: 0x000A3950
		public string OffsetDepth
		{
			get
			{
				return this.HK;
			}
			set
			{
				this.HK = value;
				this.UK = true;
				\u000D\u0020\u000A.\u000A(this, "OffsetDepth");
			}
		}

		// Token: 0x17000710 RID: 1808
		// (get) Token: 0x060019AC RID: 6572 RVA: 0x000A5778 File Offset: 0x000A3978
		public double DoubleMax
		{
			get
			{
				return double.MaxValue;
			}
		}

		// Token: 0x17000711 RID: 1809
		// (get) Token: 0x060019AD RID: 6573 RVA: 0x000A5790 File Offset: 0x000A3990
		public double DoubleMin
		{
			get
			{
				return double.MinValue;
			}
		}

		// Token: 0x17000712 RID: 1810
		// (get) Token: 0x060019AE RID: 6574 RVA: 0x000A57A8 File Offset: 0x000A39A8
		// (set) Token: 0x060019AF RID: 6575 RVA: 0x000A57BC File Offset: 0x000A39BC
		public List<ViewInformation> BatchViewInformation { get; set; } = new List<ViewInformation>();

		// Token: 0x17000713 RID: 1811
		// (get) Token: 0x060019B0 RID: 6576 RVA: 0x000A57D0 File Offset: 0x000A39D0
		// (set) Token: 0x060019B1 RID: 6577 RVA: 0x000A57E4 File Offset: 0x000A39E4
		public List<string> TopLevelOptions { get; set; }

		// Token: 0x17000714 RID: 1812
		// (get) Token: 0x060019B2 RID: 6578 RVA: 0x000A57F8 File Offset: 0x000A39F8
		// (set) Token: 0x060019B3 RID: 6579 RVA: 0x000A580C File Offset: 0x000A3A0C
		public List<string> BottomLevelOptions { get; set; }

		// Token: 0x17000715 RID: 1813
		// (get) Token: 0x060019B4 RID: 6580 RVA: 0x000A5820 File Offset: 0x000A3A20
		public CommandBase ApplyBatch
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.OXR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x060019B5 RID: 6581 RVA: 0x000A5848 File Offset: 0x000A3A48
		private void AWR(List<ViewInformation> F)
		{
			\u001B\u0009\u0005.\u000A(this, F);
			\u0008\u0009\u0005.\u000A(this, \u0014\u000D\u0007.\u000A());
			\u001A\u0008\u0007.\u000A(\u000F\u0009\u0005.\u000A(this), \u000D\u0009\u0005.\u000A());
			\u001A\u0008\u0007.\u000A(\u000F\u0009\u0005.\u000A(this), \u001C\u0009\u0005.\u000A());
			\u001A\u0008\u0007.\u000A(\u000F\u0009\u0005.\u000A(this), \u000E\u0009\u0005.\u000A());
			\u001A\u0008\u0007.\u000A(\u000F\u0009\u0005.\u000A(this), \u0012\u0009\u0005.\u000A());
			\u0010\u0009\u0005.\u000A(this, \u0014\u000D\u0007.\u000A());
			\u001A\u0008\u0007.\u000A(\u000B\u0009\u0005.\u000A(this), \u000D\u0009\u0005.\u000A());
			\u001A\u0008\u0007.\u000A(\u000B\u0009\u0005.\u000A(this), \u001C\u0009\u0005.\u000A());
			\u001A\u0008\u0007.\u000A(\u000B\u0009\u0005.\u000A(this), \u0003\u0009\u0005.\u000A());
			\u001A\u0008\u0007.\u000A(\u000B\u0009\u0005.\u000A(this), \u0012\u0009\u0005.\u000A());
			\u0006\u0009\u0005.\u000A(this, \u0001\u0013\u0007.\u000A(\u000F\u0009\u0005.\u000A(this), 0));
			\u0002\u0009\u0005.\u000A(this, \u0001\u0013\u0007.\u000A(\u000B\u0009\u0005.\u000A(this), 0));
			\u0016\u0009\u0005.\u000A(this, \u0001\u0013\u0007.\u000A(\u000B\u0009\u0005.\u000A(this), 0));
		}

		// Token: 0x060019B6 RID: 6582 RVA: 0x000A5958 File Offset: 0x000A3B58
		private void OXR()
		{
			this.TXR();
			\u0006\u0015\u0007.\u001D(\u0018\u000B\u0007.\u0007(this), new bool?(true));
			\u0019\u000B\u0007.\u001D(\u0018\u000B\u0007.\u0007(this));
		}

		// Token: 0x060019B7 RID: 6583 RVA: 0x000A598C File Offset: 0x000A3B8C
		private void TXR()
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\ViewRange\\ViewModel\\BatchViewRangeViewModel.cs", "SettingBatchInformation");
			IEnumerable<ViewInformation> enumerable = \u0013\u0009\u0005.\u0007(this);
			Func<ViewInformation, bool> func;
			if ((func = BatchViewRangeViewModel.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BatchViewRangeViewModel.TXR()).MethodHandle;
				}
				func = (BatchViewRangeViewModel.<>c.\u000A = new Func<ViewInformation, bool>(BatchViewRangeViewModel.<>c.\u001F.\u0019));
			}
			IEnumerator<ViewInformation> enumerator = \u0004\u0001\u0005.\u000A(Enumerable.Where<ViewInformation>(enumerable, func));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ViewInformation viewInformation = \u001D\u0001\u0005.\u000A(enumerator);
					this.AXR(viewInformation);
					this.IXR(viewInformation);
					if (this.WK)
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
						if (!\u001A\u0006\u0007.\u000A(\u0014\u0009\u0005.\u000A(this)))
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
							\u0011\u0009\u0005.\u000A(\u001A\u0015\u0005.\u000A(viewInformation), \u0014\u001B\u0018.\u000A(\u0014\u0009\u0005.\u000A(this)));
						}
					}
					if (this.SK)
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
						if (!\u001A\u0006\u0007.\u000A(\u0017\u0009\u0005.\u000A(this)))
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
							\u0011\u0009\u0005.\u000A(\u0001\u0015\u0005.\u000A(viewInformation), \u0014\u001B\u0018.\u000A(\u0017\u0009\u0005.\u000A(this)));
						}
					}
					if (this.UK)
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
						if (!\u001A\u0006\u0007.\u000A(\u0020\u0009\u0005.\u000A(this)))
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
							\u0011\u0009\u0005.\u000A(\u000C\u0015\u0005.\u000A(viewInformation), \u0014\u001B\u0018.\u000A(\u0020\u0009\u0005.\u000A(this)));
						}
					}
					if (\u0002\u0001\u0005.\u000A(viewInformation))
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
						this.QXR(viewInformation);
						if (this.BK)
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
							if (!\u001A\u0006\u0007.\u000A(\u001E\u0009\u0005.\u000A(this)))
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
								\u0011\u0009\u0005.\u000A(\u0015\u0015\u0005.\u000A(viewInformation), \u0014\u001B\u0018.\u000A(\u001E\u0009\u0005.\u000A(this)));
							}
						}
					}
					else
					{
						\u0011\u0009\u0005.\u000A(\u0015\u0015\u0005.\u000A(viewInformation), \u0013\u0015\u0005.\u0007(\u001A\u0015\u0005.\u000A(viewInformation)));
					}
					\u001E\u0015\u0005.\u000A(viewInformation, UpdatedIconChange.Modify);
				}
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
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\ViewRange\\ViewModel\\BatchViewRangeViewModel.cs", "SettingBatchInformation");
		}

		// Token: 0x060019B8 RID: 6584 RVA: 0x000A5BD8 File Offset: 0x000A3DD8
		private void IXR(ViewInformation F)
		{
			if (this.LK)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BatchViewRangeViewModel.IXR(ViewInformation)).MethodHandle;
				}
				if (this.DPR(F, \u000C\u0015\u0005.\u000A(F), \u001A\u0009\u0005.\u000A(this)))
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
					return;
				}
				if (\u000F\u000C\u001D.\u0007(\u001A\u0009\u0005.\u000A(this), \u0003\u0009\u0005.\u000A()))
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
					this.GXR(F, \u000C\u0015\u0005.\u000A(F));
					return;
				}
				this.HPR(F, \u000C\u0015\u0005.\u000A(F), \u001A\u0009\u0005.\u000A(this));
			}
		}

		// Token: 0x060019B9 RID: 6585 RVA: 0x000A5C74 File Offset: 0x000A3E74
		private void QXR(ViewInformation F)
		{
			if (this.CK)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BatchViewRangeViewModel.QXR(ViewInformation)).MethodHandle;
				}
				if (this.DPR(F, \u0015\u0015\u0005.\u000A(F), \u000C\u0009\u0005.\u000A(this)))
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
					return;
				}
				if (\u000F\u000C\u001D.\u0007(\u000C\u0009\u0005.\u000A(this), \u0003\u0009\u0005.\u000A()))
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
					this.GXR(F, \u0015\u0015\u0005.\u000A(F));
					return;
				}
				this.HPR(F, \u0015\u0015\u0005.\u000A(F), \u000C\u0009\u0005.\u000A(this));
			}
		}

		// Token: 0x060019BA RID: 6586 RVA: 0x000A5D10 File Offset: 0x000A3F10
		private void AXR(ViewInformation F)
		{
			if (this.YK)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BatchViewRangeViewModel.AXR(ViewInformation)).MethodHandle;
				}
				if (this.DPR(F, \u0001\u0015\u0005.\u000A(F), \u0015\u0009\u0005.\u000A(this)))
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
					return;
				}
				if (\u000F\u000C\u001D.\u0007(\u0015\u0009\u0005.\u000A(this), \u000E\u0009\u0005.\u000A()))
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
					this.FPR(F, \u0001\u0015\u0005.\u000A(F));
					return;
				}
				this.HPR(F, \u0001\u0015\u0005.\u000A(F), \u0015\u0009\u0005.\u000A(this));
			}
		}

		// Token: 0x060019BB RID: 6587 RVA: 0x000A5DAC File Offset: 0x000A3FAC
		private void GXR(ViewInformation F, ElevationInfo R)
		{
			int num = this.RPR(\u001F\u001F\u0016.\u000A(F), \u000A\u001F\u0016.\u000A(\u001F\u0001\u0005.\u0007(R)));
			if (num > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BatchViewRangeViewModel.GXR(ViewInformation, ElevationInfo)).MethodHandle;
				}
				\u0001\u0009\u0005.\u000A(R, \u0009\u0009\u0005.\u000A(\u001F\u001F\u0016.\u000A(F), num - 1));
			}
		}

		// Token: 0x060019BC RID: 6588 RVA: 0x000A5E08 File Offset: 0x000A4008
		private void FPR(ViewInformation F, ElevationInfo R)
		{
			int num = this.RPR(\u001F\u001F\u0016.\u000A(F), \u000A\u001F\u0016.\u000A(\u001F\u0001\u0005.\u0007(R)));
			if (num < \u0007\u001F\u0016.\u000A(\u001F\u001F\u0016.\u000A(F)) - 2)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BatchViewRangeViewModel.FPR(ViewInformation, ElevationInfo)).MethodHandle;
				}
				\u0001\u0009\u0005.\u000A(R, \u0009\u0009\u0005.\u000A(\u001F\u001F\u0016.\u000A(F), num + 1));
			}
			if (\u0008\u0013\u000A.\u000A(\u001D\u001F\u0016.\u000A(\u001F\u0001\u0005.\u0007(\u0001\u0015\u0005.\u000A(F))), \u0012\u0009\u0005.\u000A()))
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
				IEnumerable<LevelInfo> enumerable = \u001F\u001F\u0016.\u000A(F);
				Func<LevelInfo, double> func;
				if ((func = BatchViewRangeViewModel.<>c.\u0007) == null)
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
					func = (BatchViewRangeViewModel.<>c.\u0007 = new Func<LevelInfo, double>(BatchViewRangeViewModel.<>c.\u001F.\u0018));
				}
				int num2 = \u001F\u0004\u0007.\u000A(Enumerable.ToList<double>(Enumerable.Select<LevelInfo, double>(enumerable, func)), \u000A\u001F\u0016.\u000A(\u001F\u0001\u0005.\u0007(\u001A\u0015\u0005.\u000A(F))));
				LevelInfo u000A;
				if (num2 != \u0007\u001F\u0016.\u000A(\u001F\u001F\u0016.\u000A(F)) - 2)
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
					u000A = \u0009\u0009\u0005.\u000A(\u001F\u001F\u0016.\u000A(F), num2 + 1);
				}
				else
				{
					u000A = \u0009\u0009\u0005.\u000A(\u001F\u001F\u0016.\u000A(F), num2);
				}
				\u0001\u0009\u0005.\u000A(R, u000A);
			}
		}

		// Token: 0x060019BD RID: 6589 RVA: 0x000A5F4C File Offset: 0x000A414C
		private int RPR(List<LevelInfo> F, double R)
		{
			Func<LevelInfo, double> func;
			if ((func = BatchViewRangeViewModel.<>c.\u001D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BatchViewRangeViewModel.RPR(List<LevelInfo>, double)).MethodHandle;
				}
				func = (BatchViewRangeViewModel.<>c.\u001D = new Func<LevelInfo, double>(BatchViewRangeViewModel.<>c.\u001F.\u0005));
			}
			return \u001F\u0004\u0007.\u000A(Enumerable.ToList<double>(Enumerable.Select<LevelInfo, double>(F, func)), R);
		}

		// Token: 0x060019BE RID: 6590 RVA: 0x000A5FA4 File Offset: 0x000A41A4
		private bool DPR(ViewInformation F, ElevationInfo R, string D)
		{
			if (\u000F\u000C\u001D.\u0007(D, \u0012\u0009\u0005.\u000A()))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BatchViewRangeViewModel.DPR(ViewInformation, ElevationInfo, string)).MethodHandle;
				}
				object u001F = \u001F\u001F\u0016.\u000A(F);
				Predicate<LevelInfo> u000A;
				if ((u000A = BatchViewRangeViewModel.<>c.\u0004) == null)
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
					u000A = (BatchViewRangeViewModel.<>c.\u0004 = new Predicate<LevelInfo>(BatchViewRangeViewModel.<>c.\u001F.\u0016));
				}
				\u0001\u0009\u0005.\u000A(R, \u0004\u001F\u0016.\u000A(u001F, u000A));
				return true;
			}
			return false;
		}

		// Token: 0x060019BF RID: 6591 RVA: 0x000A6018 File Offset: 0x000A4218
		private void HPR(ViewInformation F, ElevationInfo R, string D)
		{
			if (\u000F\u000C\u001D.\u0007(D, \u001C\u0009\u0005.\u000A()))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BatchViewRangeViewModel.HPR(ViewInformation, ElevationInfo, string)).MethodHandle;
				}
				\u0001\u0009\u0005.\u000A(R, \u001F\u0001\u0005.\u0007(\u001A\u0015\u0005.\u000A(F)));
			}
		}

		// Token: 0x04000A2A RID: 2602
		private string AW;

		// Token: 0x04000A2B RID: 2603
		private string GW;

		// Token: 0x04000A2C RID: 2604
		private string FK;

		// Token: 0x04000A2D RID: 2605
		private string RK;

		// Token: 0x04000A2E RID: 2606
		private string DK;

		// Token: 0x04000A2F RID: 2607
		private string MY;

		// Token: 0x04000A30 RID: 2608
		private string HK;

		// Token: 0x04000A31 RID: 2609
		private bool YK;

		// Token: 0x04000A32 RID: 2610
		private bool CK;

		// Token: 0x04000A33 RID: 2611
		private bool LK;

		// Token: 0x04000A34 RID: 2612
		private bool SK;

		// Token: 0x04000A35 RID: 2613
		private bool BK;

		// Token: 0x04000A36 RID: 2614
		private bool UK;

		// Token: 0x04000A37 RID: 2615
		private bool WK;

		// Token: 0x04000A38 RID: 2616
		[CompilerGenerated]
		private List<ViewInformation> KK;

		// Token: 0x04000A39 RID: 2617
		[CompilerGenerated]
		private List<string> JK;

		// Token: 0x04000A3A RID: 2618
		[CompilerGenerated]
		private List<string> EK;
	}
}
