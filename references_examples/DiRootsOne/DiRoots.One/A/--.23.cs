using System;
using System.Drawing;
using System.IO;
using System.IO.Packaging;
using System.Windows.Media.Imaging;

namespace A
{
	// Token: 0x020000B2 RID: 178
	internal class \u0017\u0004 : \u001A\u0004
	{
		// Token: 0x060006EF RID: 1775 RVA: 0x00028680 File Offset: 0x00026880
		public \u0017\u0004(string \u001F, StorageInfo \u000A) : base(\u001F, \u000A)
		{
			this.\u0015();
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x0002869C File Offset: 0x0002689C
		public Image \u001F\u000A()
		{
			if (this.\u0005 != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u0004.\u001F\u000A()).MethodHandle;
				}
				if (\u0017\u0007\u000E.\u001F(this.\u0005) != 0)
				{
					goto IL_6F;
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
			Bitmap bitmap = \u000A\u0002\u001D.\u000A(128, 128);
			try
			{
				return \u0001\u0007\u000E.\u001F(\u001F\u0002\u001D.\u000A(bitmap));
			}
			finally
			{
				if (bitmap != null)
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
					\u001F\u0017\u000A.\u000A(bitmap);
				}
			}
			IL_6F:
			int num = this.\u001D\u000A();
			if (num == 0)
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
				Bitmap bitmap2 = \u000A\u0002\u001D.\u000A(128, 128);
				try
				{
					return \u0001\u0007\u000E.\u001F(\u001F\u0002\u001D.\u000A(bitmap2));
				}
				finally
				{
					if (bitmap2 != null)
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
						\u001F\u0017\u000A.\u000A(bitmap2);
					}
				}
			}
			try
			{
				byte[] array = \u0019\u0015\u0010.\u001F(\u0016\u0002\u001D.\u000A(this.\u0005, 0) - num + 1);
				MemoryStream memoryStream = \u001D\u0002\u001D.\u000A(this.\u0005);
				try
				{
					\u0005\u0002\u001D.\u000A(memoryStream, (long)num);
					\u0016\u000B\u001D.\u000A(memoryStream, array, 0, (int)\u0017\u0007\u000E.\u001F(array));
				}
				finally
				{
					if (memoryStream != null)
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
						\u001F\u0017\u000A.\u000A(memoryStream);
					}
				}
				byte[] array2 = \u001A\u0007\u000E.\u001F;
				if (array != null)
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
					MemoryStream memoryStream2 = \u001D\u0002\u001D.\u000A(array);
					try
					{
						PngBitmapDecoder u001F = \u0018\u0002\u001D.\u000A(memoryStream2, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
						array2 = this.\u000A\u000A(\u0004\u0002\u001D.\u000A(\u0019\u0002\u001D.\u000A(u001F), 0));
					}
					finally
					{
						if (memoryStream2 != null)
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
							\u001F\u0017\u000A.\u000A(memoryStream2);
						}
					}
				}
				if (array2 != null)
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
					if (\u0017\u0007\u000E.\u001F(array2) != 0)
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
						MemoryStream memoryStream3 = \u001D\u0002\u001D.\u000A(array2);
						try
						{
							Bitmap bitmap3 = \u0007\u0002\u001D.\u000A(memoryStream3);
							try
							{
								Image image = bitmap3;
								try
								{
									return \u0009\u0007\u000E.\u001F(\u001F\u0002\u001D.\u000A(image));
								}
								finally
								{
									if (image != null)
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
										\u001F\u0017\u000A.\u000A(image);
									}
								}
							}
							finally
							{
								if (bitmap3 != null)
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
									\u001F\u0017\u000A.\u000A(bitmap3);
								}
							}
						}
						finally
						{
							if (memoryStream3 != null)
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
								\u001F\u0017\u000A.\u000A(memoryStream3);
							}
						}
					}
				}
			}
			catch (Exception)
			{
			}
			Bitmap bitmap4 = \u000A\u0002\u001D.\u000A(128, 128);
			Image result;
			try
			{
				result = \u0001\u0007\u000E.\u001F(\u001F\u0002\u001D.\u000A(bitmap4));
			}
			finally
			{
				if (bitmap4 != null)
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
					\u001F\u0017\u000A.\u000A(bitmap4);
				}
			}
			return result;
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x000289E8 File Offset: 0x00026BE8
		private byte[] \u000A\u000A(BitmapSource \u001F)
		{
			BitmapEncoder u001F = \u001C\u0002\u001D.\u000A();
			MemoryStream memoryStream = \u0003\u0002\u001D.\u000A();
			byte[] result;
			try
			{
				\u0006\u0002\u001D.\u000A(\u0012\u0002\u001D.\u000A(u001F), \u000F\u0002\u001D.\u000A(\u001F));
				\u0002\u0002\u001D.\u000A(u001F, memoryStream);
				result = \u000B\u0002\u001D.\u000A(memoryStream);
			}
			finally
			{
				if (memoryStream != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u0004.\u000A\u000A(BitmapSource)).MethodHandle;
					}
					\u001F\u0017\u000A.\u000A(memoryStream);
				}
			}
			return result;
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x00028A5C File Offset: 0x00026C5C
		public void \u0015()
		{
			if (base.\u000B\u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u0004.\u0015()).MethodHandle;
				}
				return;
			}
			try
			{
				StreamInfo[] array = \u0013\u000B\u001D.\u000A(\u001A\u000B\u001D.\u000A(this));
				for (int i = 0; i < (int)\u0015\u0007\u000E.\u001F(array); i++)
				{
					StreamInfo u001F = array[i];
					if (\u000D\u001F\u001D.\u000A(\u0006\u000B\u001D.\u000A(\u0014\u000B\u001D.\u000A(u001F)), "REVITPREVIEW4.0"))
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
						this.\u0005 = this.\u0007\u000A(u001F);
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

		// Token: 0x060006F3 RID: 1779 RVA: 0x00028B14 File Offset: 0x00026D14
		private byte[] \u0007\u000A(StreamInfo \u001F)
		{
			Stream stream = \u0019\u000B\u001D.\u000A(\u001F, FileMode.Open, FileAccess.Read);
			byte[] result;
			try
			{
				byte[] array = \u0019\u0015\u0010.\u001F((int)(checked((IntPtr)\u000B\u000B\u001D.\u000A(stream))));
				\u0016\u000B\u001D.\u000A(stream, array, 0, (int)\u0017\u0007\u000E.\u001F(array));
				result = array;
			}
			finally
			{
				if (stream != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u0004.\u0007\u000A(StreamInfo)).MethodHandle;
					}
					\u001F\u0017\u000A.\u000A(stream);
				}
			}
			return result;
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00028B84 File Offset: 0x00026D84
		private int \u001D\u000A()
		{
			bool flag = false;
			int result = 0;
			int num = 0;
			MemoryStream memoryStream = \u001D\u0002\u001D.\u000A(this.\u0005);
			try
			{
				for (int i = 0; i < (int)\u0017\u0007\u000E.\u001F(this.\u0005); i++)
				{
					int num2 = \u001D\u000B\u001D.\u000A(memoryStream);
					if (num2 == 137)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u0004.\u001D\u000A()).MethodHandle;
						}
						flag = true;
						result = i;
						num = num2;
					}
					else if (num2 <= 26)
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
						if (num2 != 10)
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
							if (num2 != 13)
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
								if (num2 != 26)
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
									if (flag)
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
										if (num == 10)
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
											num = num2;
											goto IL_1EE;
										}
									}
									flag = false;
								}
							}
							else
							{
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
									if (num == 71)
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
										num = num2;
										goto IL_1EE;
									}
								}
								flag = false;
							}
						}
						else
						{
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
								if (num == 26)
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
									return result;
								}
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
								if (num == 13)
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
									num = num2;
									goto IL_1EE;
								}
							}
							flag = false;
						}
					}
					else if (num2 != 71)
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
						if (num2 != 78)
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
							if (num2 == 80)
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
								if (flag)
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
									if (num == 137)
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
										num = num2;
										goto IL_1EE;
									}
								}
								flag = false;
							}
						}
						else
						{
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
								if (num == 80)
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
									num = num2;
									goto IL_1EE;
								}
							}
							flag = false;
						}
					}
					else
					{
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
							if (num == 78)
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
								num = num2;
								goto IL_1EE;
							}
						}
						flag = false;
					}
					IL_1EE:;
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
				if (memoryStream != null)
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
					\u001F\u0017\u000A.\u000A(memoryStream);
				}
			}
			return 0;
		}

		// Token: 0x040002CD RID: 717
		private byte[] \u0005;
	}
}
