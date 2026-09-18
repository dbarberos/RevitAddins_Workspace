using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.TableGen.TGRevitHelper.Script;
using DiRoots.One.TableGen.TGRevitHelper.StyleMapping;

namespace A
{
	// Token: 0x020000ED RID: 237
	internal static class \u0008\u0018
	{
		// Token: 0x1700023F RID: 575
		// (get) Token: 0x060008B2 RID: 2226 RVA: 0x00037CD8 File Offset: 0x00035ED8
		// (set) Token: 0x060008B3 RID: 2227 RVA: 0x00037CEC File Offset: 0x00035EEC
		internal static List<\u001A\u0005> ListOfTextElementsToMove { get; set; } = \u0013\u0019\u0004.\u000A();

		// Token: 0x060008B4 RID: 2228 RVA: 0x00037D00 File Offset: 0x00035F00
		internal static TextNote \u000A(Document \u001F, View \u000A, ElementId \u0007, \u0012\u0005 \u001D)
		{
			double u001F = \u001B\u0019\u0004.\u000A(\u001D) / 12.0;
			double u000A = \u0008\u0019\u0004.\u000A(\u001D) / 12.0;
			double u001D = \u000E\u0018\u0004.\u000A(\u001D) / 12.0;
			int num = \u0010\u0018\u0004.\u000A(\u001D);
			double num2 = (double)\u0008\u0007\u0004.\u000A(\u001D);
			string u = \u000A\u0014\u001D.\u001D(\u001A\u001F\u0004.\u0007(\u001D));
			double num3 = \u0015\u0001\u001D.\u000A(\u001D);
			double num4 = \u000C\u0001\u001D.\u000A(\u001D);
			double num5 = \u001A\u0001\u001D.\u000A(\u001D);
			double num6 = \u0013\u0001\u001D.\u000A(\u001D);
			TextNoteOptions textNoteOptions = \u000D\u0018\u0004.\u000A();
			\u001C\u0018\u0004.\u000A(textNoteOptions, \u0007);
			\u0003\u0018\u0004.\u000A(textNoteOptions, num2 * 3.141592653589793 / 180.0);
			\u0012\u0018\u0004.\u000A(textNoteOptions, false);
			HorizontalTextAlignment horizontalTextAlignment;
			switch (num)
			{
			case 1:
			case 4:
			case 7:
				horizontalTextAlignment = 0;
				break;
			case 2:
			case 5:
			case 8:
				horizontalTextAlignment = 2;
				break;
			case 3:
			case 6:
			case 9:
				horizontalTextAlignment = 1;
				break;
			default:
				horizontalTextAlignment = 0;
				break;
			}
			HorizontalTextAlignment u000A2 = horizontalTextAlignment;
			\u000F\u0018\u0004.\u000A(textNoteOptions, u000A2);
			VerticalTextAlignment verticalTextAlignment;
			switch (num)
			{
			case 1:
			case 2:
			case 3:
				verticalTextAlignment = 0;
				break;
			case 4:
			case 5:
			case 6:
				verticalTextAlignment = 2;
				break;
			case 7:
			case 8:
			case 9:
				verticalTextAlignment = 1;
				break;
			default:
				verticalTextAlignment = 0;
				break;
			}
			VerticalTextAlignment u000A3 = verticalTextAlignment;
			\u0006\u0018\u0004.\u000A(textNoteOptions, u000A3);
			XYZ xyz = \u001B\u001F\u0007.\u000A(u001F, u000A, 0.0);
			xyz = \u001F\u0007\u0007.\u000A(xyz, \u0001\u001D\u0007.\u000A(\u001B\u001F\u0007.\u000A(0.0, 0.025, 0.0), 12.0));
			TextNote textNote = \u0002\u0018\u0004.\u000A(\u001F, \u0002\u001E\u000A.\u0007(\u000A), xyz, u001D, u, textNoteOptions);
			\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNote, -1006503L), 0);
			\u0014\u0016.\u001D(textNote, \u001A\u001F\u0004.\u0007(\u001D), ScriptRenderMode.Supported);
			Element u001F2 = textNote;
			TextNoteIdentity textNoteIdentity = \u000B\u0018\u0004.\u000A();
			\u0005\u0018\u0004.\u000A(textNoteIdentity, \u0016\u0018\u0004.\u000A(\u001D));
			\u0019\u0018\u0004.\u000A(textNoteIdentity, \u0018\u0018\u0004.\u000A(\u001D));
			\u0004\u0018\u0004.\u000A(u001F2, textNoteIdentity);
			XYZ xyz2 = \u001D\u0018\u0004.\u000A(textNote);
			\u001A\u0005 u001A_u = new \u001A\u0005();
			\u0007\u0018\u0004.\u000A(u001A_u, \u0002\u001E\u000A.\u0007(textNote));
			\u000A\u0018\u0004.\u000A(u001A_u, num);
			\u001F\u0018\u0004.\u000A(u001A_u, num2);
			\u0009\u0019\u0004.\u000A(u001A_u, xyz2);
			if (num2 == 90.0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0018.\u000A(Document, View, ElementId, \u0012\u0005)).MethodHandle;
				}
				\u0015\u0019\u0004.\u000A(u001A_u, xyz2);
				if (num != 2)
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
					if (num != 5)
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
						if (num != 8)
						{
							if (num != 1)
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
								if (num != 4)
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
									if (num != 7)
									{
										goto IL_335;
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
								}
							}
							\u0015\u0019\u0004.\u000A(u001A_u, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(xyz2), num4 / 12.0, \u0003\u000A\u0007.\u000A(xyz2)));
							goto IL_335;
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
				\u0015\u0019\u0004.\u000A(u001A_u, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(xyz2), (num3 + num4) / 2.0 / 12.0, \u0003\u000A\u0007.\u000A(xyz2)));
				IL_335:
				if (num != 4)
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
					if (num != 5)
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
						if (num != 6)
						{
							if (num != 7)
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
								if (num != 8)
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
									if (num != 9)
									{
										goto IL_40D;
									}
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
							}
							\u0015\u0019\u0004.\u000A(u001A_u, \u001B\u001F\u0007.\u000A(num6 / 12.0, \u001C\u001F\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001A_u)), \u0003\u000A\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001A_u))));
							goto IL_40D;
						}
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
				}
				\u0015\u0019\u0004.\u000A(u001A_u, \u001B\u001F\u0007.\u000A((num5 + num6) / 2.0 / 12.0, \u001C\u001F\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001A_u)), \u0003\u000A\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001A_u))));
				IL_40D:
				\u001A\u0019\u0004.\u000A(\u000C\u0019\u0004.\u000A(), u001A_u);
			}
			else if (num2 == -90.0)
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
				\u0015\u0019\u0004.\u000A(u001A_u, xyz2);
				if (num != 2)
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
					if (num != 5)
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
						if (num != 8)
						{
							if (num != 3)
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
								if (num != 6)
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
									if (num != 9)
									{
										goto IL_4FF;
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
							}
							\u0015\u0019\u0004.\u000A(u001A_u, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(xyz2), num4 / 12.0, \u0003\u000A\u0007.\u000A(xyz2)));
							goto IL_4FF;
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
				}
				\u0015\u0019\u0004.\u000A(u001A_u, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(xyz2), (num3 + num4) / 2.0 / 12.0, \u0003\u000A\u0007.\u000A(xyz2)));
				IL_4FF:
				if (num != 4)
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
					if (num != 5)
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
						if (num != 6)
						{
							if (num != 1)
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
								if (num != 2)
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
									if (num != 3)
									{
										if (num != 7)
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
											if (num != 8)
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
												if (num != 9)
												{
													goto IL_640;
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
											}
										}
										\u0015\u0019\u0004.\u000A(u001A_u, \u001B\u001F\u0007.\u000A(num5 / 12.0, \u001C\u001F\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001A_u)), \u0003\u000A\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001A_u))));
										goto IL_640;
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
								}
							}
							\u0015\u0019\u0004.\u000A(u001A_u, \u001B\u001F\u0007.\u000A(num6 / 12.0, \u001C\u001F\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001A_u)), \u0003\u000A\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001A_u))));
							goto IL_640;
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
				}
				\u0015\u0019\u0004.\u000A(u001A_u, \u001B\u001F\u0007.\u000A((num5 + num6) / 2.0 / 12.0, \u001C\u001F\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001A_u)), \u0003\u000A\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001A_u))));
				IL_640:
				\u001A\u0019\u0004.\u000A(\u000C\u0019\u0004.\u000A(), u001A_u);
			}
			else
			{
				if (num != 4)
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
					if (num != 5)
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
						if (num != 6)
						{
							if (num != 7)
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
								if (num != 8)
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
									if (num != 9)
									{
										return textNote;
									}
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
							}
							\u0015\u0019\u0004.\u000A(u001A_u, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(xyz2), num4 / 12.0, \u0003\u000A\u0007.\u000A(xyz2)));
							\u001A\u0019\u0004.\u000A(\u000C\u0019\u0004.\u000A(), u001A_u);
							return textNote;
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
				}
				\u0015\u0019\u0004.\u000A(u001A_u, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(xyz2), (num3 + num4) / 2.0 / 12.0, \u0003\u000A\u0007.\u000A(xyz2)));
				\u001A\u0019\u0004.\u000A(\u000C\u0019\u0004.\u000A(), u001A_u);
			}
			return textNote;
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x0003843C File Offset: 0x0003663C
		internal static ElementId \u0007(double \u001F, bool \u000A, bool \u0007, bool \u001D, string \u0004, Document \u0019)
		{
			string u000A = \u0008\u0018.\u0019(\u0019, \u001F);
			string text = \u001E\u0020\u001D.\u000A("Imported_", u000A, " ", \u0004);
			if (\u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0018.\u0007(double, bool, bool, bool, string, Document)).MethodHandle;
				}
				text = \u0004\u001E\u000A.\u000A(text, "(Bold)");
			}
			if (\u0007)
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
				text = \u0004\u001E\u000A.\u000A(text, "(Italic)");
			}
			if (\u001D)
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
				text = \u0004\u001E\u000A.\u000A(text, "(Underline)");
			}
			\u001F = \u001F / 25.4 / 12.0;
			IEnumerable<TextNoteType> elements = \u0019.GetElements<TextNoteType>();
			IEnumerator<TextNoteType> enumerator = \u001B\u0018\u0004.\u000A(elements);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					TextNoteType u001F = \u0008\u0018\u0004.\u000A(enumerator);
					if (\u000D\u0008\u000A.\u000A(\u0005\u001E\u000A.\u000A(u001F), text, true))
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
						return \u0002\u001E\u000A.\u0007(u001F);
					}
				}
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
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			enumerator = \u001B\u0018\u0004.\u000A(elements);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					TextNoteType u001F2 = \u0008\u0018\u0004.\u000A(enumerator);
					try
					{
						TextNoteType textNoteType = \u001F\u0019\u000E.\u001F(\u001E\u0009\u001D.\u000A(u001F2, text));
						if (textNoteType != null)
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
							\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1150213L), 0);
							\u0002\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006327L), 1.0);
							\u0002\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006501L), 0.00666666666667);
							\u0016\u0018\u001D.\u0007(\u0016\u0018\u0007.\u0007(textNoteType, -1006300L), \u0004);
							\u0002\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006301L), \u001F);
							\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006314L), 1);
							if (\u000A)
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
								\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006311L), 1);
							}
							else
							{
								\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006311L), 0);
							}
							if (\u0007)
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
								\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006312L), 1);
							}
							else
							{
								\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006312L), 0);
							}
							if (\u001D)
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
								\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006313L), 1);
							}
							else
							{
								\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006313L), 0);
							}
							return \u0002\u001E\u000A.\u0007(textNoteType);
						}
					}
					catch (Exception)
					{
					}
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
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return null;
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x0003877C File Offset: 0x0003697C
		internal static void \u001D(Document \u001F, View \u000A)
		{
			if (\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0018.\u001D(Document, View)).MethodHandle;
				}
				if (\u000A != null)
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
					if (\u0015\u0018\u0004.\u000A(\u000C\u0019\u0004.\u000A()) != 0)
					{
						try
						{
							Transaction transaction = \u0013\u0001\u000A.\u000A(\u001F);
							try
							{
								\u0017\u0001\u000A.\u000A(transaction, "Adjust Elements");
								List<\u001A\u0005>.Enumerator enumerator = \u000C\u0018\u0004.\u000A(\u000C\u0019\u0004.\u000A());
								try
								{
									while (\u001E\u0018\u0004.\u000A(ref enumerator))
									{
										\u001A\u0005 u001F = \u001A\u0018\u0004.\u000A(ref enumerator);
										TextNote textNote = \u0009\u0004\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u001F, \u0017\u0018\u0004.\u000A(u001F)));
										if (textNote != null)
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
											BoundingBoxXYZ boundingBoxXYZ = \u0002\u0004\u0007.\u000A(textNote, \u000A);
											XYZ u001F2 = \u001D\u0018\u0004.\u000A(textNote);
											if (boundingBoxXYZ != null)
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
												XYZ u;
												if (\u0013\u0018\u0004.\u000A(u001F) == 90.0)
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
													if ((double)\u0014\u0018\u0004.\u000A(u001F) == 2.0)
													{
														goto IL_148;
													}
													for (;;)
													{
														switch (7)
														{
														case 0:
															continue;
														}
														break;
													}
													if ((double)\u0014\u0018\u0004.\u000A(u001F) == 5.0)
													{
														goto IL_148;
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
													if ((double)\u0014\u0018\u0004.\u000A(u001F) == 8.0)
													{
														for (;;)
														{
															switch (6)
															{
															case 0:
																continue;
															}
															goto IL_148;
														}
													}
													else
													{
														if ((double)\u0014\u0018\u0004.\u000A(u001F) != 1.0)
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
															if ((double)\u0014\u0018\u0004.\u000A(u001F) != 4.0)
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
																if ((double)\u0014\u0018\u0004.\u000A(u001F) != 7.0)
																{
																	goto IL_25A;
																}
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
														}
														u = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001F)), \u001C\u001F\u0007.\u000A(\u000B\u0004\u0007.\u000A(boundingBoxXYZ)) + 0.004583333333333333, \u0003\u000A\u0007.\u000A(u001F2));
														\u0008\u0018.\u0004(\u001F, textNote, u, \u0001\u0019\u0004.\u000A(u001F));
													}
													IL_25A:
													if ((double)\u0014\u0018\u0004.\u000A(u001F) != 4.0)
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
														if ((double)\u0014\u0018\u0004.\u000A(u001F) != 5.0)
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
															if ((double)\u0014\u0018\u0004.\u000A(u001F) != 6.0)
															{
																if ((double)\u0014\u0018\u0004.\u000A(u001F) != 7.0)
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
																	if ((double)\u0014\u0018\u0004.\u000A(u001F) != 8.0)
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
																		if ((double)\u0014\u0018\u0004.\u000A(u001F) != 9.0)
																		{
																			goto IL_8E3;
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
																}
																u = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0016\u0004\u0007.\u000A(boundingBoxXYZ)) + 0.0016666666666666668, \u001C\u001F\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001F)), \u0003\u000A\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001F)));
																\u0008\u0018.\u0004(\u001F, textNote, u, \u0001\u0019\u0004.\u000A(u001F));
																goto IL_8E3;
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
													}
													u = \u001B\u001F\u0007.\u000A((\u000D\u001F\u0007.\u000A(\u0016\u0004\u0007.\u000A(boundingBoxXYZ)) + \u000D\u001F\u0007.\u000A(\u000B\u0004\u0007.\u000A(boundingBoxXYZ))) / 2.0, \u001C\u001F\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001F)), \u0003\u000A\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001F)));
													\u0008\u0018.\u0004(\u001F, textNote, u, \u0001\u0019\u0004.\u000A(u001F));
													goto IL_8E3;
													IL_148:
													u = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001F)), (\u001C\u001F\u0007.\u000A(\u0016\u0004\u0007.\u000A(boundingBoxXYZ)) + \u001C\u001F\u0007.\u000A(\u000B\u0004\u0007.\u000A(boundingBoxXYZ))) / 2.0 + 0.0020833333333333333, \u0003\u000A\u0007.\u000A(u001F2));
													\u0008\u0018.\u0004(\u001F, textNote, u, \u0001\u0019\u0004.\u000A(u001F));
													goto IL_25A;
												}
												if (\u0013\u0018\u0004.\u000A(u001F) == -90.0)
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
													if ((double)\u0014\u0018\u0004.\u000A(u001F) == 2.0)
													{
														goto IL_44A;
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
													if ((double)\u0014\u0018\u0004.\u000A(u001F) == 5.0)
													{
														goto IL_44A;
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
													if ((double)\u0014\u0018\u0004.\u000A(u001F) == 8.0)
													{
														for (;;)
														{
															switch (1)
															{
															case 0:
																continue;
															}
															goto IL_44A;
														}
													}
													else
													{
														if ((double)\u0014\u0018\u0004.\u000A(u001F) != 3.0)
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
															if ((double)\u0014\u0018\u0004.\u000A(u001F) != 6.0)
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
																if ((double)\u0014\u0018\u0004.\u000A(u001F) != 9.0)
																{
																	goto IL_55C;
																}
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
														}
														u = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001F)), \u001C\u001F\u0007.\u000A(\u000B\u0004\u0007.\u000A(boundingBoxXYZ)) + 0.004583333333333333, \u0003\u000A\u0007.\u000A(u001F2));
														\u0008\u0018.\u0004(\u001F, textNote, u, \u0001\u0019\u0004.\u000A(u001F));
													}
													IL_55C:
													if ((double)\u0014\u0018\u0004.\u000A(u001F) != 4.0)
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
														if ((double)\u0014\u0018\u0004.\u000A(u001F) != 5.0)
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
															if ((double)\u0014\u0018\u0004.\u000A(u001F) != 6.0)
															{
																if ((double)\u0014\u0018\u0004.\u000A(u001F) != 1.0)
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
																	if ((double)\u0014\u0018\u0004.\u000A(u001F) != 2.0)
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
																		if ((double)\u0014\u0018\u0004.\u000A(u001F) != 3.0)
																		{
																			if ((double)\u0014\u0018\u0004.\u000A(u001F) != 7.0)
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
																				if ((double)\u0014\u0018\u0004.\u000A(u001F) != 8.0)
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
																					if ((double)\u0014\u0018\u0004.\u000A(u001F) != 9.0)
																					{
																						goto IL_8E3;
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
																			}
																			u = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u000B\u0004\u0007.\u000A(boundingBoxXYZ)) - 0.0016666666666666668, \u001C\u001F\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001F)), \u0003\u000A\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001F)));
																			\u0008\u0018.\u0004(\u001F, textNote, u, \u0001\u0019\u0004.\u000A(u001F));
																			goto IL_8E3;
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
																}
																u = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0016\u0004\u0007.\u000A(boundingBoxXYZ)) + 0.0016666666666666668, \u001C\u001F\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001F)), \u0003\u000A\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001F)));
																\u0008\u0018.\u0004(\u001F, textNote, u, \u0001\u0019\u0004.\u000A(u001F));
																goto IL_8E3;
															}
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
													}
													u = \u001B\u001F\u0007.\u000A((\u000D\u001F\u0007.\u000A(\u0016\u0004\u0007.\u000A(boundingBoxXYZ)) + \u000D\u001F\u0007.\u000A(\u000B\u0004\u0007.\u000A(boundingBoxXYZ))) / 2.0, \u001C\u001F\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001F)), \u0003\u000A\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001F)));
													\u0008\u0018.\u0004(\u001F, textNote, u, \u0001\u0019\u0004.\u000A(u001F));
													goto IL_8E3;
													IL_44A:
													u = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0001\u0019\u0004.\u000A(u001F)), (\u001C\u001F\u0007.\u000A(\u0016\u0004\u0007.\u000A(boundingBoxXYZ)) + \u001C\u001F\u0007.\u000A(\u000B\u0004\u0007.\u000A(boundingBoxXYZ))) / 2.0 + 0.0020833333333333333, \u0003\u000A\u0007.\u000A(u001F2));
													\u0008\u0018.\u0004(\u001F, textNote, u, \u0001\u0019\u0004.\u000A(u001F));
													goto IL_55C;
												}
												if ((double)\u0014\u0018\u0004.\u000A(u001F) != 4.0)
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
													if ((double)\u0014\u0018\u0004.\u000A(u001F) != 5.0)
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
														if ((double)\u0014\u0018\u0004.\u000A(u001F) != 6.0)
														{
															if ((double)\u0014\u0018\u0004.\u000A(u001F) != 7.0)
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
																if ((double)\u0014\u0018\u0004.\u000A(u001F) != 8.0)
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
																	if ((double)\u0014\u0018\u0004.\u000A(u001F) != 9.0)
																	{
																		goto IL_8E3;
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
																}
															}
															u = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F2), \u001C\u001F\u0007.\u000A(\u000B\u0004\u0007.\u000A(boundingBoxXYZ)) + 0.004583333333333333, \u0003\u000A\u0007.\u000A(u001F2));
															\u0008\u0018.\u0004(\u001F, textNote, u, \u0001\u0019\u0004.\u000A(u001F));
															goto IL_8E3;
														}
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
												}
												u = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F2), (\u001C\u001F\u0007.\u000A(\u0016\u0004\u0007.\u000A(boundingBoxXYZ)) + \u001C\u001F\u0007.\u000A(\u000B\u0004\u0007.\u000A(boundingBoxXYZ))) / 2.0 + 0.0020833333333333333, \u0003\u000A\u0007.\u000A(u001F2));
												\u0008\u0018.\u0004(\u001F, textNote, u, \u0001\u0019\u0004.\u000A(u001F));
											}
											IL_8E3:
											\u0008\u0018.\u0004(\u001F, \u0011\u0017\u000A.\u0007(\u001F, \u0017\u0018\u0004.\u000A(u001F)), \u0020\u0018\u0004.\u000A(u001F), \u0001\u0019\u0004.\u000A(u001F));
										}
									}
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
								finally
								{
									((IDisposable)enumerator).Dispose();
								}
								\u001B\u0001\u000A.\u000A(transaction);
							}
							finally
							{
								if (transaction != null)
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
									\u001F\u0017\u000A.\u000A(transaction);
								}
							}
						}
						catch (Exception u000A)
						{
							\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\TextNoteHandler.cs", "FlushPendingMoves");
						}
						finally
						{
							\u0011\u0018\u0004.\u000A(\u000C\u0019\u0004.\u000A());
						}
						return;
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
			}
			\u0011\u0018\u0004.\u000A(\u000C\u0019\u0004.\u000A());
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x00039168 File Offset: 0x00037368
		private static void \u0004(Document \u001F, Element \u000A, XYZ \u0007, XYZ \u001D)
		{
			if (!\u000A\u0004\u0007.\u000A(\u0007, \u001D))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0018.\u0004(Document, Element, XYZ, XYZ)).MethodHandle;
				}
				XYZ u = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u001D) - \u000D\u001F\u0007.\u000A(\u0007), \u001C\u001F\u0007.\u000A(\u001D) - \u001C\u001F\u0007.\u000A(\u0007), \u0003\u000A\u0007.\u000A(\u001D) - \u0003\u000A\u0007.\u000A(\u0007));
				\u000F\u0018\u0007.\u000A(\u001F, \u0002\u001E\u000A.\u0007(\u000A), u);
			}
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x000391E0 File Offset: 0x000373E0
		private static string \u0019(Document \u001F, double \u000A)
		{
			if (\u001E\u000B\u0007.\u000A(\u001F) == 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0018.\u0019(Document, double)).MethodHandle;
				}
				double u000A = \u000A / 25.4 / 12.0;
				return \u0011\u0018.\u001F(\u001F, u000A, 128);
			}
			double num = \u0016\u001F\u0007.\u000A(\u000A, 2);
			return \u0004\u001E\u000A.\u000A(\u0010\u0015\u0007.\u000A(ref num), "mm");
		}

		// Token: 0x0400035F RID: 863
		[CompilerGenerated]
		private static List<\u001A\u0005> \u001F;
	}
}
