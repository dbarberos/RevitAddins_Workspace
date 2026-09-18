using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Enums;
using ProSheets.Helpers;
using Xceed.Wpf.Toolkit;

namespace ProSheets.UI
{
	// Token: 0x0200008C RID: 140
	public partial class ImgOptions : UserControl
	{
		// Token: 0x060008A4 RID: 2212 RVA: 0x00033D38 File Offset: 0x00031F38
		public ImgOptions(Document objDoc)
		{
			\u0015\u001A\u0003.\u0018(this);
			\u0011\u001A\u0003.\u0018(this, objDoc);
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x00033D58 File Offset: 0x00031F58
		public void loadPrintConfig(Document objDoc)
		{
			\u0012\u000B\u0018.\u0018(this.W, \u0006\u0004\u0018.\u0018(objDoc));
			\u0007\u0018\u0003.\u0018(this.O, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.Q, new bool?(true));
			\u0012\u000B\u0018.\u0018(this.J, "2048");
			\u0007\u0018\u0003.\u0018(this.H, new bool?(true));
			\u0003\u0019\u0018.\u0018(this.X, this.U());
			\u0009\u0019\u0018.\u0018(this.X, 4);
			\u0003\u0019\u0018.\u0018(this.M, this.U());
			\u0009\u0019\u0018.\u0018(this.M, 4);
			\u0003\u0019\u0018.\u0018(this.Y, this.S());
			\u0009\u0019\u0018.\u0018(this.Y, 0);
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x00033E18 File Offset: 0x00032018
		public void getIMGControlValues()
		{
			try
			{
				if (\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.Q)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ImgOptions.getIMGControlValues()).MethodHandle;
					}
					\u000B\u001A\u0003.\u0018(0);
					\u0007\u001A\u0003.\u0018(\u0010\u001A\u0003.\u0018(\u0001\u000B\u0018.\u0018(this.J)));
					if (\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.F)))
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
						\u0019\u001A\u0003.\u0018(1);
					}
					else
					{
						\u0019\u001A\u0003.\u0018(0);
					}
				}
				else
				{
					\u000B\u001A\u0003.\u0018(1);
					\u001A\u001A\u0003.\u0018(\u0001\u000F\u0014.\u0018(\u001F\u0020\u0003.\u0018(this.Z)));
					\u001D\u001A\u0003.\u0018(\u0016\u0007\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.Y)));
				}
				\u0004\u001A\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.C)));
				\u0002\u001A\u0003.\u0018(\u0001\u000B\u0018.\u0018(this.W));
				\u001E\u001A\u0003.\u0018(\u0012\u0007\u0018.\u0018(this.X).\u0018());
				\u0017\u001A\u0003.\u0018(\u0012\u0007\u0018.\u0018(this.M).\u0018());
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\ImgOptions.xaml.cs", "getIMGControlValues");
			}
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x00033F80 File Offset: 0x00032180
		public void SetPrintConfig(Export export, ExportTemPlateInfo templateInfo)
		{
			try
			{
				if (\u0014\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo)) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ImgOptions.SetPrintConfig(Export, ExportTemPlateInfo)).MethodHandle;
					}
					\u0007\u0018\u0003.\u0018(this.H, new bool?(true));
				}
				else
				{
					\u0007\u0018\u0003.\u0018(this.F, new bool?(true));
				}
				if (\u0018\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo)) == null)
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
					\u0007\u0018\u0003.\u0018(this.Q, new bool?(true));
				}
				else
				{
					\u0007\u0018\u0003.\u0018(this.N, new bool?(true));
				}
				\u0007\u0018\u0003.\u0018(this.C, new bool?(\u000C\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo))));
				\u0007\u0018\u0003.\u0018(this.O, new bool?(!\u000C\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo))));
				\u000E\u001A\u0003.\u0018(this.W, new TextChangedEventHandler(this.txtCombineFileName_TextChanged));
				\u0012\u000B\u0018.\u0018(this.W, \u0005\u001A\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo)));
				\u000B\u0013\u0003.\u0018(this.W, new TextChangedEventHandler(this.txtCombineFileName_TextChanged));
				\u0016\u0007\u0018.\u0018(this.Y, \u001B\u001A\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo)));
				object j = this.J;
				int num = \u0001\u001A\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo));
				\u0012\u000B\u0018.\u0018(j, \u0010\u001E\u0018.\u0018(ref num));
				\u0008\u0020\u0003.\u0018(this.Z, new int?(\u0006\u001A\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo))));
				\u0016\u0007\u0018.\u0018(this.X, "HLRandWFViewsFileType");
				\u0016\u0007\u0018.\u0018(this.M, "ShadowViewsFileType");
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\ImgOptions.xaml.cs", "SetPrintConfig");
			}
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x00034158 File Offset: 0x00032358
		public void GetPrintConfig(ExportTemPlateInfo templateInfo)
		{
			try
			{
				if (\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.H)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ImgOptions.GetPrintConfig(ExportTemPlateInfo)).MethodHandle;
					}
					\u000A\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 0);
				}
				else
				{
					\u000A\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 1);
				}
				if (\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.Q)))
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
					\u0009\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 0);
				}
				else
				{
					\u0009\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 1);
				}
				\u0013\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.C)));
				\u001C\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), \u0001\u000B\u0018.\u0018(this.W));
				\u000D\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), \u0016\u0007\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.Y)));
				string text = \u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.X));
				if (text != null)
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
					int num = \u001C\u0002\u0018.\u0003(text);
					switch (num)
					{
					case 3:
					{
						char c = \u0002\u0001\u0018.\u0003(text, 0);
						if (c != 'B')
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
							if (c != 'P')
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
							}
							else if (!\u000F\u0002\u0018.\u0018(text, "PNG"))
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
								\u0012\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 4);
							}
						}
						else if (!\u000F\u0002\u0018.\u0018(text, "BMP"))
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
							\u0012\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 0);
						}
						break;
					}
					case 4:
						if (!\u000F\u0002\u0018.\u0018(text, "TIFF"))
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
						}
						else
						{
							\u0012\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 6);
						}
						break;
					case 5:
						if (!\u000F\u0002\u0018.\u0018(text, "TARGA"))
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
						}
						else
						{
							\u0012\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 5);
						}
						break;
					default:
						if (num != 11)
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
							if (num != 13)
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
							}
							else
							{
								char c = \u0002\u0001\u0018.\u0003(text, 5);
								if (c != 'L')
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
									if (c != 'S')
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
									}
									else if (!\u000F\u0002\u0018.\u0018(text, "JPEG Smallest"))
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
									}
									else
									{
										\u0012\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 3);
									}
								}
								else if (!\u000F\u0002\u0018.\u0018(text, "JPEG Lossless"))
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
								}
								else
								{
									\u0012\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 1);
								}
							}
						}
						else if (!\u000F\u0002\u0018.\u0018(text, "JPEG Medium"))
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
						}
						else
						{
							\u0012\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 2);
						}
						break;
					}
				}
				text = \u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.M));
				if (text != null)
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
					int num = \u001C\u0002\u0018.\u0003(text);
					switch (num)
					{
					case 3:
					{
						char c = \u0002\u0001\u0018.\u0003(text, 0);
						if (c != 'B')
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
							if (c != 'P')
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
							}
							else if (!\u000F\u0002\u0018.\u0018(text, "PNG"))
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
								\u000F\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 4);
							}
						}
						else if (!\u000F\u0002\u0018.\u0018(text, "BMP"))
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
							\u000F\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 0);
						}
						break;
					}
					case 4:
						if (!\u000F\u0002\u0018.\u0018(text, "TIFF"))
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
						}
						else
						{
							\u000F\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 6);
						}
						break;
					case 5:
						if (!\u000F\u0002\u0018.\u0018(text, "TARGA"))
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
							\u000F\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 5);
						}
						break;
					default:
						if (num != 11)
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
							if (num != 13)
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
							}
							else
							{
								char c = \u0002\u0001\u0018.\u0003(text, 5);
								if (c != 'L')
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
									if (c != 'S')
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
									else if (!\u000F\u0002\u0018.\u0018(text, "JPEG Smallest"))
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
										\u000F\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 3);
									}
								}
								else if (!\u000F\u0002\u0018.\u0018(text, "JPEG Lossless"))
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
								}
								else
								{
									\u000F\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 1);
								}
							}
						}
						else if (!\u000F\u0002\u0018.\u0018(text, "JPEG Medium"))
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
						}
						else
						{
							\u000F\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), 2);
						}
						break;
					}
				}
				\u0016\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), \u0010\u001A\u0003.\u0018(\u0001\u000B\u0018.\u0018(this.J)));
				\u0003\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(templateInfo), \u0001\u000F\u0014.\u0018(\u001F\u0020\u0003.\u0018(this.Z)));
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\ImgOptions.xaml.cs", "GetPrintConfig");
			}
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x000346FC File Offset: 0x000328FC
		private List<ImageResolution> S()
		{
			List<ImageResolution> list = \u001F\u000B\u0003.\u0018();
			\u0020\u000B\u0003.\u0018(list, 0);
			\u0020\u000B\u0003.\u0018(list, 1);
			\u0020\u000B\u0003.\u0018(list, 2);
			\u0020\u000B\u0003.\u0018(list, 3);
			return list;
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x0003472C File Offset: 0x0003292C
		private List<EnumInfo> U()
		{
			List<EnumInfo> list = \u0012\u0002\u0014.\u0018();
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u001A\u0014, "BMP", 0, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u000B\u0014, "JPEGLossless", 1, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0019\u0014, "JPEGMedium", 2, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0007\u0014, "JPEGSmallest", 3, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0010\u0014, "PNG", 4, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0006\u0014, "TARGA", 5, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0008\u0014, "TIFF", 6, false));
			return list;
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x00034800 File Offset: 0x00032A00
		private void rdbZoomTypeFit_Checked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.J, true);
			\u0014\u0019\u0018.\u0018(this.F, true);
			\u0014\u0019\u0018.\u0018(this.H, true);
			\u0014\u0019\u0018.\u0018(this.Y, false);
			\u0014\u0019\u0018.\u0018(this.Z, false);
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x0003484C File Offset: 0x00032A4C
		private void rdbZoomTypeZoom_Checked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.Z, true);
			\u0014\u0019\u0018.\u0018(this.Y, true);
			\u0014\u0019\u0018.\u0018(this.J, false);
			\u0014\u0019\u0018.\u0018(this.F, false);
			\u0014\u0019\u0018.\u0018(this.H, false);
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x00034898 File Offset: 0x00032A98
		private void txtPixelSize_LostFocus(object sender, RoutedEventArgs e)
		{
			if (\u000F\u0002\u0018.\u0018(\u0001\u000B\u0018.\u0018(this.J), ""))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ImgOptions.txtPixelSize_LostFocus(object, RoutedEventArgs)).MethodHandle;
				}
				\u0012\u000B\u0018.\u0018(this.J, "2048");
			}
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x000348E4 File Offset: 0x00032AE4
		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex u000C = \u000D\u0009\u0014.\u0018("[^0-9-]+");
			\u001D\u000B\u0018.\u0018(e, \u0012\u0009\u0014.\u0018(u000C, \u000E\u0020\u0003.\u0018(e)));
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x00034914 File Offset: 0x00032B14
		private void txtCombineFileName_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (\u000F\u0002\u0018.\u0018(\u0001\u000B\u0018.\u0018(this.W), string.Empty))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ImgOptions.txtCombineFileName_TextChanged(object, TextChangedEventArgs)).MethodHandle;
				}
				\u0014\u001A\u0018.\u0018(\u001C\u0009\u0018.\u000D\u0018);
			}
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x00034960 File Offset: 0x00032B60
		private void rdbSeparateFile_Checked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.W, false);
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x0003497C File Offset: 0x00032B7C
		private void rdbCombineFile_Checked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.W, true);
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x00034998 File Offset: 0x00032B98
		private void txtCombineFileName_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			List<char> u000C = Enumerable.ToList<char>(\u0008\u001A\u0018.\u0018());
			string u000C2 = \u000E\u0020\u0003.\u0018(e);
			for (int i = 0; i < \u001C\u0002\u0018.\u0014(u000C2); i++)
			{
				char u = \u0002\u0001\u0018.\u0014(u000C2, i);
				if (\u000C\u001F\u0003.\u0018(u000C, u))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ImgOptions.txtCombineFileName_PreviewTextInput(object, TextCompositionEventArgs)).MethodHandle;
					}
					\u001D\u000B\u0018.\u0018(e, true);
					return;
				}
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

		// Token: 0x060008B3 RID: 2227 RVA: 0x00034A0C File Offset: 0x00032C0C
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u000C\u0010\u0018.\u0018(\u0018\u0010\u0018.\u0018(\u0014\u0010\u0018.\u0018(this)));
			\u000E\u0007\u0018.\u0018(this);
		}
	}
}
