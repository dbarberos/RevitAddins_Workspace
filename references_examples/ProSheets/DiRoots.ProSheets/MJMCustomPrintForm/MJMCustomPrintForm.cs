using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using A;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Helpers;

namespace MJMCustomPrintForm
{
	// Token: 0x02000007 RID: 7
	public static class MJMCustomPrintForm
	{
		// Token: 0x06000010 RID: 16
		[SuppressUnmanagedCodeSecurity]
		[DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "OpenPrinter", SetLastError = true)]
		internal static extern bool \u0014([MarshalAs(UnmanagedType.LPTStr)] string \u000C, out IntPtr \u0018, ref MJMCustomPrintForm.\u0004\u0013\u0018 \u0014);

		// Token: 0x06000011 RID: 17
		[SuppressUnmanagedCodeSecurity]
		[DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "ClosePrinter", SetLastError = true)]
		internal static extern bool \u0003(IntPtr \u000C);

		// Token: 0x06000012 RID: 18
		[SuppressUnmanagedCodeSecurity]
		[DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "AddFormW", ExactSpelling = true, SetLastError = true)]
		internal static extern bool \u0016(IntPtr \u000C, [MarshalAs(UnmanagedType.I4)] int \u0018, ref MJMCustomPrintForm.\u000B\u0013\u0018 \u0014);

		// Token: 0x06000013 RID: 19
		[SuppressUnmanagedCodeSecurity]
		[DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "DeleteForm", SetLastError = true)]
		internal static extern bool \u000F(IntPtr \u000C, [MarshalAs(UnmanagedType.LPTStr)] string \u0018);

		// Token: 0x06000014 RID: 20
		[SuppressUnmanagedCodeSecurity]
		[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetLastError", ExactSpelling = true)]
		internal static extern int \u0012();

		// Token: 0x06000015 RID: 21
		[SuppressUnmanagedCodeSecurity]
		[DllImport("GDI32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "CreateDC", SetLastError = true)]
		internal static extern IntPtr \u000D([MarshalAs(UnmanagedType.LPTStr)] string \u000C, [MarshalAs(UnmanagedType.LPTStr)] string \u0018, [MarshalAs(UnmanagedType.LPTStr)] string \u0014, ref MJMCustomPrintForm.\u0019\u0013\u0018 \u0003);

		// Token: 0x06000016 RID: 22
		[SuppressUnmanagedCodeSecurity]
		[DllImport("GDI32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "ResetDC", SetLastError = true)]
		internal static extern IntPtr \u001C(IntPtr \u000C, ref MJMCustomPrintForm.\u0019\u0013\u0018 \u0018);

		// Token: 0x06000017 RID: 23
		[SuppressUnmanagedCodeSecurity]
		[DllImport("GDI32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "DeleteDC", SetLastError = true)]
		internal static extern bool \u0013(IntPtr \u000C);

		// Token: 0x06000018 RID: 24
		[SuppressUnmanagedCodeSecurity]
		[DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, EntryPoint = "SetPrinterA", ExactSpelling = true, SetLastError = true)]
		internal static extern bool \u0009(IntPtr \u000C, [MarshalAs(UnmanagedType.I4)] int \u0018, IntPtr \u0014, [MarshalAs(UnmanagedType.I4)] int \u0003);

		// Token: 0x06000019 RID: 25
		[DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, EntryPoint = "DocumentPropertiesA", ExactSpelling = true, SetLastError = true)]
		internal static extern int \u000A(IntPtr \u000C, IntPtr \u0018, [MarshalAs(UnmanagedType.LPStr)] string \u0014, IntPtr \u0003, IntPtr \u0016, int \u000F);

		// Token: 0x0600001A RID: 26
		[DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetPrinterA", ExactSpelling = true, SetLastError = true)]
		internal static extern bool \u0020(IntPtr \u000C, int \u0018, IntPtr \u0014, int \u0003, out int \u0016);

		// Token: 0x0600001B RID: 27
		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessageTimeout", SetLastError = true)]
		internal static extern IntPtr \u001F(IntPtr \u000C, uint \u0018, IntPtr \u0014, IntPtr \u0003, MJMCustomPrintForm.SendMessageTimeoutFlags \u0016, uint \u000F, out IntPtr \u0012);

		// Token: 0x0600001C RID: 28 RVA: 0x00002300 File Offset: 0x00000500
		public static void AddMjm80MmPaperSizeToDefaultPrinter()
		{
			\u001A\u0017\u0018.\u0018("MJM 80mm * Receipt Length", 80.1f, 4003.9f);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002324 File Offset: 0x00000524
		public static void AddMjm104MmPaperSizeToDefaultPrinter()
		{
			\u001A\u0017\u0018.\u0018("MJM 104mm * Receipt Length", 104.1f, 4003.9f);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002348 File Offset: 0x00000548
		public static void AddCustomPaperSizeToDefaultPrinter(string paperName, float widthMm, float heightMm)
		{
			\u000B\u0017\u0018.\u0018(\u0019\u0017\u0018.\u0018(\u0007\u0017\u0018.\u0018(\u0010\u0017\u0018.\u0018())), paperName, widthMm, heightMm);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002378 File Offset: 0x00000578
		public static bool TryAddCustomPaperSize(string printerName, string paperName, float widthMm, float heightMm)
		{
			if (PlatformID.Win32NT == \u000C\u001E\u0018.\u0018(\u0018\u001E\u0018.\u0018()))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MJMCustomPrintForm.TryAddCustomPaperSize(string, string, float, float)).MethodHandle;
				}
				MJMCustomPrintForm.\u0004\u0013\u0018 u0004_u0013_u = default(MJMCustomPrintForm.\u0004\u0013\u0018);
				u0004_u0013_u.\u000C = \u0005\u001E\u000F.\u000C;
				u0004_u0013_u.\u0018 = IntPtr.Zero;
				u0004_u0013_u.\u0014 = 8;
				IntPtr zero = IntPtr.Zero;
				if (MJMCustomPrintForm.\u0014(printerName, out zero, ref u0004_u0013_u))
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
					try
					{
						MJMCustomPrintForm.\u000F(zero, paperName);
						MJMCustomPrintForm.\u000B\u0013\u0018 u000B_u0013_u = default(MJMCustomPrintForm.\u000B\u0013\u0018);
						u000B_u0013_u.\u000C = 0U;
						u000B_u0013_u.\u0018 = paperName;
						u000B_u0013_u.\u0014.\u000C = (int)((double)widthMm * 1000.0);
						u000B_u0013_u.\u0014.\u0018 = (int)((double)heightMm * 1000.0);
						u000B_u0013_u.\u0003.\u000C = 0;
						u000B_u0013_u.\u0003.\u0014 = u000B_u0013_u.\u0014.\u000C;
						u000B_u0013_u.\u0003.\u0018 = 0;
						u000B_u0013_u.\u0003.\u0003 = u000B_u0013_u.\u0014.\u0018;
						if (!MJMCustomPrintForm.\u0016(zero, 1, ref u000B_u0013_u))
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
							StringBuilder u000C = \u0005\u0017\u0018.\u0018();
							\u000E\u0017\u0018.\u0018(u000C, "Failed to add the custom paper size {0} to the printer {1}, System error number: {2}", paperName, printerName, MJMCustomPrintForm.\u0012());
							\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), \u0001\u0017\u0018.\u0018(u000C), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\MJMCustomPrintForm.cs", "TryAddCustomPaperSize");
							return false;
						}
						return true;
					}
					finally
					{
						MJMCustomPrintForm.\u0003(zero);
					}
				}
				StringBuilder u000C2 = \u0005\u0017\u0018.\u0018();
				\u001B\u0017\u0018.\u0018(u000C2, "Failed to open the {0} printer, System error number: {1}", printerName, MJMCustomPrintForm.\u0012());
				\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), \u0001\u0017\u0018.\u0018(u000C2), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\MJMCustomPrintForm.cs", "TryAddCustomPaperSize");
				return false;
			}
			MJMCustomPrintForm.\u0019\u0013\u0018 u0019_u0013_u = default(MJMCustomPrintForm.\u0019\u0013\u0018);
			IntPtr u000C3 = MJMCustomPrintForm.\u000D(null, printerName, null, ref u0019_u0013_u);
			if (\u0006\u0017\u0018.\u0018(u000C3, IntPtr.Zero))
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
				u0019_u0013_u.\u000F = 14;
				u0019_u0013_u.\u000D = 256;
				u0019_u0013_u.\u0013 = (short)((double)widthMm * 1000.0);
				u0019_u0013_u.\u001C = (short)((double)heightMm * 1000.0);
				MJMCustomPrintForm.\u001C(u000C3, ref u0019_u0013_u);
				MJMCustomPrintForm.\u0013(u000C3);
			}
			return true;
		}

		// Token: 0x04000004 RID: 4
		private static int \u000C;

		// Token: 0x04000005 RID: 5
		private static int \u0018;

		// Token: 0x02000147 RID: 327
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		internal struct \u0004\u0013\u0018
		{
			// Token: 0x0400072B RID: 1835
			[MarshalAs(UnmanagedType.LPTStr)]
			public string \u000C;

			// Token: 0x0400072C RID: 1836
			public IntPtr \u0018;

			// Token: 0x0400072D RID: 1837
			[MarshalAs(UnmanagedType.I4)]
			public int \u0014;
		}

		// Token: 0x02000148 RID: 328
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		internal struct \u001D\u0013\u0018
		{
			// Token: 0x0400072E RID: 1838
			public int \u000C;

			// Token: 0x0400072F RID: 1839
			public int \u0018;
		}

		// Token: 0x02000149 RID: 329
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		internal struct \u001A\u0013\u0018
		{
			// Token: 0x04000730 RID: 1840
			public int \u000C;

			// Token: 0x04000731 RID: 1841
			public int \u0018;

			// Token: 0x04000732 RID: 1842
			public int \u0014;

			// Token: 0x04000733 RID: 1843
			public int \u0003;
		}

		// Token: 0x0200014A RID: 330
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct \u000B\u0013\u0018
		{
			// Token: 0x04000734 RID: 1844
			public uint \u000C;

			// Token: 0x04000735 RID: 1845
			public string \u0018;

			// Token: 0x04000736 RID: 1846
			public MJMCustomPrintForm.\u001D\u0013\u0018 \u0014;

			// Token: 0x04000737 RID: 1847
			public MJMCustomPrintForm.\u001A\u0013\u0018 \u0003;
		}

		// Token: 0x0200014B RID: 331
		internal struct \u0019\u0013\u0018
		{
			// Token: 0x04000738 RID: 1848
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string \u000C;

			// Token: 0x04000739 RID: 1849
			[MarshalAs(UnmanagedType.U2)]
			public short \u0018;

			// Token: 0x0400073A RID: 1850
			[MarshalAs(UnmanagedType.U2)]
			public short \u0014;

			// Token: 0x0400073B RID: 1851
			[MarshalAs(UnmanagedType.U2)]
			public short \u0003;

			// Token: 0x0400073C RID: 1852
			[MarshalAs(UnmanagedType.U2)]
			public short \u0016;

			// Token: 0x0400073D RID: 1853
			[MarshalAs(UnmanagedType.U4)]
			public int \u000F;

			// Token: 0x0400073E RID: 1854
			[MarshalAs(UnmanagedType.I2)]
			public short \u0012;

			// Token: 0x0400073F RID: 1855
			[MarshalAs(UnmanagedType.I2)]
			public short \u000D;

			// Token: 0x04000740 RID: 1856
			[MarshalAs(UnmanagedType.I2)]
			public short \u001C;

			// Token: 0x04000741 RID: 1857
			[MarshalAs(UnmanagedType.I2)]
			public short \u0013;

			// Token: 0x04000742 RID: 1858
			[MarshalAs(UnmanagedType.I2)]
			public short \u0009;

			// Token: 0x04000743 RID: 1859
			[MarshalAs(UnmanagedType.I2)]
			public short \u000A;

			// Token: 0x04000744 RID: 1860
			[MarshalAs(UnmanagedType.I2)]
			public short \u0020;

			// Token: 0x04000745 RID: 1861
			[MarshalAs(UnmanagedType.I2)]
			public short \u001F;

			// Token: 0x04000746 RID: 1862
			[MarshalAs(UnmanagedType.I2)]
			public short \u0011;

			// Token: 0x04000747 RID: 1863
			[MarshalAs(UnmanagedType.I2)]
			public short \u0015;

			// Token: 0x04000748 RID: 1864
			[MarshalAs(UnmanagedType.I2)]
			public short \u0017;

			// Token: 0x04000749 RID: 1865
			[MarshalAs(UnmanagedType.I2)]
			public short \u001E;

			// Token: 0x0400074A RID: 1866
			[MarshalAs(UnmanagedType.I2)]
			public short \u0002;

			// Token: 0x0400074B RID: 1867
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string \u0004;

			// Token: 0x0400074C RID: 1868
			[MarshalAs(UnmanagedType.U2)]
			public short \u001D;

			// Token: 0x0400074D RID: 1869
			[MarshalAs(UnmanagedType.U4)]
			public int \u001A;

			// Token: 0x0400074E RID: 1870
			[MarshalAs(UnmanagedType.U4)]
			public int \u000B;

			// Token: 0x0400074F RID: 1871
			[MarshalAs(UnmanagedType.U4)]
			public int \u0019;

			// Token: 0x04000750 RID: 1872
			[MarshalAs(UnmanagedType.U4)]
			public int \u0007;

			// Token: 0x04000751 RID: 1873
			[MarshalAs(UnmanagedType.U4)]
			public int \u0010;

			// Token: 0x04000752 RID: 1874
			[MarshalAs(UnmanagedType.U4)]
			public int \u0006;

			// Token: 0x04000753 RID: 1875
			[MarshalAs(UnmanagedType.U4)]
			public int \u0008;

			// Token: 0x04000754 RID: 1876
			[MarshalAs(UnmanagedType.U4)]
			public int \u0001;

			// Token: 0x04000755 RID: 1877
			[MarshalAs(UnmanagedType.U4)]
			public int \u001B;

			// Token: 0x04000756 RID: 1878
			[MarshalAs(UnmanagedType.U4)]
			public int \u0005;

			// Token: 0x04000757 RID: 1879
			[MarshalAs(UnmanagedType.U4)]
			public int \u000E;
		}

		// Token: 0x0200014C RID: 332
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		internal struct \u0007\u0013\u0018
		{
			// Token: 0x04000758 RID: 1880
			public IntPtr \u000C;
		}

		// Token: 0x0200014D RID: 333
		[Flags]
		public enum SendMessageTimeoutFlags : uint
		{
			// Token: 0x0400075A RID: 1882
			SMTO_NORMAL = 0U,
			// Token: 0x0400075B RID: 1883
			SMTO_BLOCK = 1U,
			// Token: 0x0400075C RID: 1884
			SMTO_ABORTIFHUNG = 2U,
			// Token: 0x0400075D RID: 1885
			SMTO_NOTIMEOUTIFNOTHUNG = 8U
		}
	}
}
