using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using DiRoots.RevitOleStorage;

namespace A
{
	// Token: 0x020000B1 RID: 177
	internal class \u0020\u0004 : \u001A\u0004
	{
		// Token: 0x060006D6 RID: 1750 RVA: 0x0002785C File Offset: 0x00025A5C
		public \u0020\u0004(string \u001F, StorageInfo \u000A) : base(\u001F, \u000A)
		{
			this.\u0015();
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x000278B8 File Offset: 0x00025AB8
		public bool \u000D
		{
			get
			{
				if (this.\u000E != WorkSharingMode.NotEnabled)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0004.get_\u000D()).MethodHandle;
					}
					if (this.\u000E != WorkSharingMode.Unknown)
					{
						bool flag = false;
						bool flag2 = this.\u000E == WorkSharingMode.Central;
						string u000A = \u0006\u000B\u001D.\u000A(\u000F\u000B\u001D.\u000A(base.\u0002\u000A));
						string u001F = string.Empty;
						if (\u001C\u000F\u0007.\u0007(this.\u001B) > 0)
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
							u001F = \u0006\u000B\u001D.\u000A(\u000F\u000B\u001D.\u000A(this.\u001B));
						}
						if (\u001C\u000F\u0007.\u0007(u001F) > 0)
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
							flag = \u000D\u001F\u001D.\u000A(u001F, u000A);
						}
						return flag2 && flag;
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
				return false;
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x060006D8 RID: 1752 RVA: 0x00027978 File Offset: 0x00025B78
		public bool \u0010
		{
			get
			{
				if (this.\u000E != WorkSharingMode.NotEnabled)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0004.get_\u0010()).MethodHandle;
					}
					if (this.\u000E == WorkSharingMode.Unknown)
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
						bool flag = false;
						bool flag2 = this.\u000E == WorkSharingMode.Local;
						string u000A = \u0006\u000B\u001D.\u000A(\u000F\u000B\u001D.\u000A(base.\u0002\u000A));
						string u001F = string.Empty;
						if (\u001C\u000F\u0007.\u0007(this.\u001B) > 0)
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
							u001F = \u0006\u000B\u001D.\u000A(\u000F\u000B\u001D.\u000A(this.\u001B));
						}
						if (\u001C\u000F\u0007.\u0007(u001F) > 0)
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
							flag = \u000D\u001F\u001D.\u000A(u001F, u000A);
						}
						if (!flag2)
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
							return !flag;
						}
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x060006D9 RID: 1753 RVA: 0x00027A48 File Offset: 0x00025C48
		// (set) Token: 0x060006DA RID: 1754 RVA: 0x00027A5C File Offset: 0x00025C5C
		public WorkSharingMode \u000E
		{
			get
			{
				return this.\u001F;
			}
			private set
			{
				this.\u001F = value;
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x060006DB RID: 1755 RVA: 0x00027A70 File Offset: 0x00025C70
		// (set) Token: 0x060006DC RID: 1756 RVA: 0x00027A84 File Offset: 0x00025C84
		public string \u0008
		{
			get
			{
				return this.\u000A;
			}
			private set
			{
				this.\u000A = value;
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x00027A98 File Offset: 0x00025C98
		// (set) Token: 0x060006DE RID: 1758 RVA: 0x00027AAC File Offset: 0x00025CAC
		public string \u001B
		{
			get
			{
				return this.\u0007;
			}
			private set
			{
				this.\u0007 = value;
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x00027AC0 File Offset: 0x00025CC0
		// (set) Token: 0x060006E0 RID: 1760 RVA: 0x00027AD4 File Offset: 0x00025CD4
		public string \u0011
		{
			get
			{
				return this.\u001D;
			}
			private set
			{
				this.\u001D = value;
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x060006E1 RID: 1761 RVA: 0x00027AE8 File Offset: 0x00025CE8
		// (set) Token: 0x060006E2 RID: 1762 RVA: 0x00027AFC File Offset: 0x00025CFC
		public string \u001E
		{
			get
			{
				return this.\u0004;
			}
			private set
			{
				this.\u0004 = value;
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x060006E3 RID: 1763 RVA: 0x00027B10 File Offset: 0x00025D10
		public ProductType \u0020
		{
			get
			{
				if (\u001A\u0006\u0007.\u000A(this.\u001E))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0004.get_\u0020()).MethodHandle;
					}
					return ProductType.Unknown;
				}
				if (\u0012\u000B\u001D.\u000A(\u0006\u000B\u001D.\u000A(this.\u001E), "MEP") >= 0)
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
					return ProductType.MEP;
				}
				if (\u0012\u000B\u001D.\u000A(\u0006\u000B\u001D.\u000A(this.\u001E), "ARCHITECTURE") >= 0)
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
					return ProductType.Architecture;
				}
				if (\u0012\u000B\u001D.\u000A(\u0006\u000B\u001D.\u000A(this.\u001E), "STRUCTURE") >= 0)
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
					return ProductType.Structure;
				}
				return ProductType.Unknown;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x060006E4 RID: 1764 RVA: 0x00027BC4 File Offset: 0x00025DC4
		public string \u0017
		{
			get
			{
				if (\u001A\u0006\u0007.\u000A(this.\u001E))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0004.get_\u0017()).MethodHandle;
					}
					return string.Empty;
				}
				object u001E = this.\u001E;
				char[] array = \u001C\u0007\u000E.\u001F(1);
				array[0] = ':';
				string[] array2 = \u0009\u0007\u001D.\u000A(u001E, array);
				if ((int)\u000C\u0007\u000E.\u001F(array2) == 2)
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
					return \u0003\u000B\u001D.\u0007(\u001C\u000B\u001D.\u0007(\u001C\u000B\u001D.\u0007(\u001C\u000B\u001D.\u0007(\u0003\u000B\u001D.\u0007(array2[1]), "(x64))", string.Empty), "(x64)", string.Empty), ")", string.Empty));
				}
				return \u0003\u000B\u001D.\u0007(this.\u0004);
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x060006E5 RID: 1765 RVA: 0x00027C80 File Offset: 0x00025E80
		public PlatformType \u0014
		{
			get
			{
				if (\u001A\u0006\u0007.\u000A(this.\u001E))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0004.get_\u0014()).MethodHandle;
					}
					return PlatformType.Unknown;
				}
				if (\u0012\u000B\u001D.\u000A(\u0006\u000B\u001D.\u000A(this.\u001E), "X64") >= 0)
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
					return PlatformType.x64;
				}
				return PlatformType.x86;
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x060006E6 RID: 1766 RVA: 0x00027CE0 File Offset: 0x00025EE0
		// (set) Token: 0x060006E7 RID: 1767 RVA: 0x00027CF4 File Offset: 0x00025EF4
		public string \u0013
		{
			get
			{
				return this.\u0019;
			}
			private set
			{
				this.\u0019 = value;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x060006E8 RID: 1768 RVA: 0x00027D08 File Offset: 0x00025F08
		// (set) Token: 0x060006E9 RID: 1769 RVA: 0x00027D1C File Offset: 0x00025F1C
		public int \u001A
		{
			get
			{
				return this.\u0018;
			}
			private set
			{
				this.\u0018 = value;
			}
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x00027D30 File Offset: 0x00025F30
		private void \u000C(string \u001F)
		{
			\u001F = \u0003\u000B\u001D.\u0007(\u001F);
			string u001F = \u0010\u000B\u001D.\u000A(\u001F, \u0012\u000B\u001D.\u000A(\u001F, ":") + 1);
			string text = \u000A\u000B\u001D.\u000A(\u001F, 0, \u0012\u000B\u001D.\u000A(\u001F, ":"));
			text = \u001C\u000B\u001D.\u0007(\u0006\u000B\u001D.\u000A(\u0003\u000B\u001D.\u0007(text)), " ", string.Empty);
			text = \u001E\u0004.\u001D(text);
			u001F = \u001E\u0004.\u001D(u001F);
			if (text != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0004.\u000C(string)).MethodHandle;
				}
				switch (\u001C\u000F\u0007.\u001D(text))
				{
				case 5:
					if (!\u0008\u0013\u000A.\u000A(text, "BUILD"))
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
						return;
					}
					break;
				case 6:
					if (!\u0008\u0013\u000A.\u000A(text, "FORMAT"))
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
					this.\u0011 = \u0003\u000B\u001D.\u0007(u001F);
					return;
				case 7:
				case 9:
				case 13:
				case 14:
				case 16:
				case 17:
					return;
				case 8:
					if (!\u0008\u0013\u000A.\u000A(text, "USERNAME"))
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
					this.\u0008 = \u0003\u000B\u001D.\u0007(u001F);
					return;
				case 10:
					if (!\u0008\u0013\u000A.\u000A(text, "REVITBUILD"))
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
					break;
				case 11:
				{
					if (!\u0008\u0013\u000A.\u000A(text, "WORKSHARING"))
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
						return;
					}
					if (\u001A\u0006\u0007.\u000A(u001F))
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
						this.\u000E = WorkSharingMode.Unknown;
						return;
					}
					string u001F2 = \u0006\u000B\u001D.\u000A(\u0003\u000B\u001D.\u0007(\u001C\u000B\u001D.\u0007(u001F, " ", string.Empty)));
					if (\u0008\u0013\u000A.\u000A(u001F2, "NOTENABLED"))
					{
						this.\u000E = WorkSharingMode.NotEnabled;
						return;
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
					if (\u0008\u0013\u000A.\u000A(u001F2, "LOCAL"))
					{
						this.\u000E = WorkSharingMode.Local;
						return;
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
					if (!\u0008\u0013\u000A.\u000A(u001F2, "CENTRAL"))
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
						this.\u000E = WorkSharingMode.Unknown;
						return;
					}
					this.\u000E = WorkSharingMode.Central;
					return;
				}
				case 12:
					if (!\u0008\u0013\u000A.\u000A(text, "LASTSAVEPATH"))
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
						return;
					}
					this.\u0013 = \u0003\u000B\u001D.\u0007(u001F);
					return;
				case 15:
					if (!\u0008\u0013\u000A.\u000A(text, "CENTRALFILEPATH"))
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
						return;
					}
					this.\u001B = \u0003\u000B\u001D.\u0007(u001F);
					return;
				case 18:
					if (!\u0008\u0013\u000A.\u000A(text, "OPENWORKSETDEFAULT"))
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
					this.\u001A = \u000D\u000B\u001D.\u000A(\u0003\u000B\u001D.\u0007(u001F));
					return;
				default:
					return;
				}
				this.\u001E = \u0003\u000B\u001D.\u0007(u001F);
				return;
			}
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x00028000 File Offset: 0x00026200
		public void \u0015()
		{
			if (base.\u000B\u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0004.\u0015()).MethodHandle;
				}
				return;
			}
			try
			{
				StreamInfo[] array = \u0013\u000B\u001D.\u000A(\u001A\u000B\u001D.\u000A(this));
				for (int i = 0; i < (int)\u0015\u0007\u000E.\u001F(array); i++)
				{
					StreamInfo streamInfo = array[i];
					if (\u000D\u001F\u001D.\u000A(\u0006\u000B\u001D.\u000A(\u0014\u000B\u001D.\u000A(streamInfo)), "BASICFILEINFO"))
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
						if (streamInfo != null)
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
							byte[] array2 = \u001E\u0004.\u0005(streamInfo);
							int num = 0;
							List<int> u001F = \u0017\u000B\u001D.\u000A();
							while (num + 1 < (int)\u0017\u0007\u000E.\u001F(array2))
							{
								if (array2[num] == 13)
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
									if (array2[num + 1] == 10)
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
										\u0020\u000B\u001D.\u000A(u001F, num);
									}
								}
								num++;
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
							byte[] array3;
							if (\u001E\u000B\u001D.\u000A(u001F) >= 2)
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
								int num2 = \u001E\u000B\u001D.\u000A(u001F) - 1;
								array3 = Enumerable.ToArray<byte>(Enumerable.Take<byte>(Enumerable.Skip<byte>(array2, \u0011\u000B\u001D.\u000A(u001F, num2 - 1) + 2), \u0011\u000B\u001D.\u000A(u001F, num2) - \u0011\u000B\u001D.\u000A(u001F, num2 - 1) - 2));
								byte[] u001F2 = array3;
								byte[] array4 = \u0019\u0015\u0010.\u001F(6);
								\u001B\u000B\u001D.\u000A(array4, fieldof(\u0001\u001B\u000A.\u0019).FieldHandle);
								byte[] array5 = \u0019\u0015\u0010.\u001F(10);
								\u001B\u000B\u001D.\u000A(array5, fieldof(\u0001\u001B\u000A.\u001F).FieldHandle);
								array3 = \u0020\u0004.\u0001(u001F2, array4, array5);
								byte[] u001F3 = array3;
								byte[] array6 = \u0019\u0015\u0010.\u001F(5);
								\u001B\u000B\u001D.\u000A(array6, fieldof(\u0001\u001B\u000A.\u000A).FieldHandle);
								byte[] array7 = \u0019\u0015\u0010.\u001F(8);
								\u001B\u000B\u001D.\u000A(array7, fieldof(\u0001\u001B\u000A.\u0005).FieldHandle);
								array3 = \u0020\u0004.\u0001(u001F3, array6, array7);
							}
							else
							{
								array3 = Enumerable.ToArray<byte>(array2);
							}
							string text = \u0018\u000B\u001D.\u000A(\u0008\u000B\u001D.\u000A("UTF-16"), array3);
							if (\u0012\u000B\u001D.\u000A(text, "\r\n") >= 0)
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
								object u001F4 = text;
								string[] array8 = \u001B\u001F\u000E.\u001F(1);
								array8[0] = "\r\n";
								string[] array9 = \u000E\u000B\u001D.\u000A(u001F4, array8, StringSplitOptions.None);
								for (int j = 0; j < (int)\u000C\u0007\u000E.\u001F(array9); j++)
								{
									string u001F5 = array9[j];
									this.\u000C(u001F5);
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
					}
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
			catch (Exception)
			{
				base.\u000B\u000A = false;
			}
			base.\u000B\u000A = true;
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x0002828C File Offset: 0x0002648C
		internal static byte[] \u0001(byte[] \u001F, byte[] \u000A, byte[] \u0007)
		{
			byte[] array = \u001A\u0007\u000E.\u001F;
			int num = \u0020\u0004.\u0009(\u001F, \u000A);
			if (num >= 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0004.\u0001(byte[], byte[], byte[])).MethodHandle;
				}
				array = \u0019\u0015\u0010.\u001F((int)\u0017\u0007\u000E.\u001F(\u001F) - (int)\u0017\u0007\u000E.\u001F(\u000A) + (int)\u0017\u0007\u000E.\u001F(\u0007));
				\u000C\u000B\u001D.\u000A(\u001F, 0, array, 0, num);
				\u000C\u000B\u001D.\u000A(\u0007, 0, array, num, (int)\u0017\u0007\u000E.\u001F(\u0007));
				\u000C\u000B\u001D.\u000A(\u001F, num + (int)\u0017\u0007\u000E.\u001F(\u000A), array, num + (int)\u0017\u0007\u000E.\u001F(\u0007), (int)\u0017\u0007\u000E.\u001F(\u001F) - (num + (int)\u0017\u0007\u000E.\u001F(\u000A)));
				return array;
			}
			return \u001F;
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0002833C File Offset: 0x0002653C
		internal static int \u0009(byte[] \u001F, byte[] \u000A)
		{
			int result = -1;
			int num = 0;
			for (int i = 0; i < (int)\u0017\u0007\u000E.\u001F(\u001F); i++)
			{
				if (\u001F[i] == \u000A[num])
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0004.\u0009(byte[], byte[])).MethodHandle;
					}
					if (num == (int)\u0017\u0007\u000E.\u001F(\u000A) - 1)
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
						result = i - num;
						return result;
					}
					num++;
				}
				else if (\u001F[i] == \u000A[0])
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
					num = 1;
				}
				else
				{
					num = 0;
				}
			}
			for (;;)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				return result;
			}
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x000283C4 File Offset: 0x000265C4
		public override string ToString()
		{
			StringBuilder u001F = \u001A\u0013\u0007.\u000A();
			string u000A = string.Empty;
			try
			{
				if (this != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0004.ToString()).MethodHandle;
					}
					u000A = \u0004\u001E\u000A.\u000A("+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+", \u0009\u000B\u001D.\u000A());
					\u001E\u0013\u0007.\u000A(u001F, \u0018\u000E\u0007.\u000A("FileName: <{0}>{1}", base.\u0002\u000A, \u0009\u000B\u001D.\u000A()));
					\u001E\u0013\u0007.\u000A(u001F, u000A);
					\u001E\u0013\u0007.\u000A(u001F, \u0017\u0006\u0007.\u000A("BasicFileInfo Section{0}", \u0009\u000B\u001D.\u000A()));
					\u001E\u0013\u0007.\u000A(u001F, u000A);
					\u001E\u0013\u0007.\u000A(u001F, \u0018\u000E\u0007.\u000A("DocType: <{0}>{1}", base.\u000F\u000A, \u0009\u000B\u001D.\u000A()));
					\u001E\u0013\u0007.\u000A(u001F, \u0018\u000E\u0007.\u000A("WorkSharing: <{0}>{1}", this.\u000E, \u0009\u000B\u001D.\u000A()));
					\u001E\u0013\u0007.\u000A(u001F, \u0018\u000E\u0007.\u000A("IsCentralFile: <{0}>{1}", this.\u000D, \u0009\u000B\u001D.\u000A()));
					\u001E\u0013\u0007.\u000A(u001F, \u0018\u000E\u0007.\u000A("UserName: <{0}>{1}", this.\u0008, \u0009\u000B\u001D.\u000A()));
					\u001E\u0013\u0007.\u000A(u001F, \u0018\u000E\u0007.\u000A("CentralFilePath: <{0}>{1}", this.\u001B, \u0009\u000B\u001D.\u000A()));
					\u001E\u0013\u0007.\u000A(u001F, \u0018\u000E\u0007.\u000A("Format: <{0}>{1}", this.\u0011, \u0009\u000B\u001D.\u000A()));
					\u001E\u0013\u0007.\u000A(u001F, \u0018\u000E\u0007.\u000A("RevitBuild: <{0}>{1}", this.\u001E, \u0009\u000B\u001D.\u000A()));
					\u001E\u0013\u0007.\u000A(u001F, \u0018\u000E\u0007.\u000A("Product: <{0}>{1}", this.\u0020, \u0009\u000B\u001D.\u000A()));
					\u001E\u0013\u0007.\u000A(u001F, \u0018\u000E\u0007.\u000A("Platform: <{0}>{1}", this.\u0014, \u0009\u000B\u001D.\u000A()));
					\u001E\u0013\u0007.\u000A(u001F, \u0018\u000E\u0007.\u000A("BuildTimeStamp: <{0}>{1}", this.\u0017, \u0009\u000B\u001D.\u000A()));
					\u001E\u0013\u0007.\u000A(u001F, \u0018\u000E\u0007.\u000A("LastSavedpath: <{0}>{1}", this.\u0013, \u0009\u000B\u001D.\u000A()));
					\u001E\u0013\u0007.\u000A(u001F, \u0018\u000E\u0007.\u000A("OpenWorksetDefault: <{0}>{1}", this.\u001A, \u0009\u000B\u001D.\u000A()));
					\u001E\u0013\u0007.\u000A(u001F, u000A);
					return \u001A\u000C\u000A.\u000A(u001F);
				}
			}
			finally
			{
				\u0001\u000B\u001D.\u000A(u001F, 0);
				\u0015\u000B\u001D.\u000A(u001F, 0);
				u001F = \u0013\u0007\u000E.\u001F;
			}
			return string.Empty;
		}

		// Token: 0x040002C6 RID: 710
		private WorkSharingMode \u001F = WorkSharingMode.Unknown;

		// Token: 0x040002C7 RID: 711
		private string \u000A = string.Empty;

		// Token: 0x040002C8 RID: 712
		private string \u0007 = string.Empty;

		// Token: 0x040002C9 RID: 713
		private string \u001D = string.Empty;

		// Token: 0x040002CA RID: 714
		private string \u0004 = string.Empty;

		// Token: 0x040002CB RID: 715
		private string \u0019 = string.Empty;

		// Token: 0x040002CC RID: 716
		private int \u0018;
	}
}
