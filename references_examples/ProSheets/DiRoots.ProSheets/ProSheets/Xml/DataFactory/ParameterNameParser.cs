using System;
using System.Text;
using A;

namespace ProSheets.Xml.DataFactory
{
	// Token: 0x02000081 RID: 129
	public static class ParameterNameParser
	{
		// Token: 0x060007D5 RID: 2005 RVA: 0x00027FA8 File Offset: 0x000261A8
		public static string Parse(string parameterName)
		{
			if (parameterName != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterNameParser.Parse(string)).MethodHandle;
				}
				int num = \u001C\u0002\u0018.\u0003(parameterName);
				if (num <= 3)
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
					if (num != 2)
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
						if (num != 3)
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
							char c = \u0002\u0001\u0018.\u0003(parameterName, 1);
							if (c <= 'S')
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
								if (c != 'H')
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
									if (c != 'M')
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
										if (c != 'S')
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
											if (\u000F\u0002\u0018.\u0018(parameterName, "%SS"))
											{
												return \u001C\u0009\u0018.\u0010\u0003;
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
									else
									{
										if (\u000F\u0002\u0018.\u0018(parameterName, "%MM"))
										{
											return \u001C\u0009\u0018.\u0007\u0003;
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
								else
								{
									if (\u000F\u0002\u0018.\u0018(parameterName, "%HH"))
									{
										return \u001C\u0009\u0018.\u0019\u0003;
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
							else if (c != 'd')
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
								if (c != 'm')
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
									if (c != 'y')
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
										if (\u000F\u0002\u0018.\u0018(parameterName, "%yy"))
										{
											return \u001C\u0009\u0018.\u0006\u0003;
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
								else
								{
									if (\u000F\u0002\u0018.\u0018(parameterName, "%mm"))
									{
										return \u001C\u0009\u0018.\u001A\u0003;
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
							else
							{
								if (\u000F\u0002\u0018.\u0018(parameterName, "%dd"))
								{
									return \u001C\u0009\u0018.\u000B\u0003;
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
					}
					else
					{
						char c = \u0002\u0001\u0018.\u0003(parameterName, 1);
						if (c <= 'S')
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
							if (c != 'H')
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
								if (c != 'M')
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
										if (\u000F\u0002\u0018.\u0018(parameterName, "%S"))
										{
											return \u001C\u0009\u0018.\u000C\u0016;
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
								else
								{
									if (\u000F\u0002\u0018.\u0018(parameterName, "%M"))
									{
										return \u001C\u0009\u0018.\u000E\u0003;
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
							else
							{
								if (\u000F\u0002\u0018.\u0018(parameterName, "%H"))
								{
									return \u001C\u0009\u0018.\u0005\u0003;
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
						else if (c != 'Y')
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
							if (c != 'd')
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
								if (c != 'm')
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
									if (\u000F\u0002\u0018.\u0018(parameterName, "%m"))
									{
										return \u001C\u0009\u0018.\u0001\u0003;
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
							else
							{
								if (\u000F\u0002\u0018.\u0018(parameterName, "%d"))
								{
									return \u001C\u0009\u0018.\u001B\u0003;
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
						else
						{
							if (\u000F\u0002\u0018.\u0018(parameterName, "%Y"))
							{
								return \u001C\u0009\u0018.\u0008\u0003;
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
				}
				else if (num != 10)
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
					if (num != 11)
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
						if (\u000F\u0002\u0018.\u0018(parameterName, "%SheetSize%"))
						{
							return \u001C\u0009\u0018.\u000B;
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
				else
				{
					if (\u000F\u0002\u0018.\u0018(parameterName, "%UserName%"))
					{
						return \u001C\u0009\u0018.\u001D\u0003;
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
			return parameterName;
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x0002838C File Offset: 0x0002658C
		internal static string \u000C(string \u000C)
		{
			if (\u001F\u001A\u0018.\u0018(\u000C))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterNameParser.\u000C(string)).MethodHandle;
				}
				return "_";
			}
			StringBuilder u000C = \u0005\u0017\u0018.\u0018();
			for (int i = 0; i < \u001C\u0002\u0018.\u0014(\u000C); i++)
			{
				char c = \u0002\u0001\u0018.\u0014(\u000C, i);
				if (\u001E\u0001\u0018.\u0018(c))
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
					\u0010\u0012\u0003.\u0018(u000C, c);
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
			if (\u001E\u0019\u0014.\u0018(u000C) == 0)
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
				return "_";
			}
			if (!\u001D\u0001\u0018.\u0018(\u0007\u0012\u0003.\u0018(u000C, 0)))
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
				\u001A\u0012\u0003.\u0018(u000C, 0, '_');
			}
			if (\u001E\u0019\u0014.\u0018(u000C) >= 3)
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
				if (\u000B\u0012\u0003.\u0018(\u0019\u0012\u0003.\u0018(u000C, 0, 3), "xml", StringComparison.OrdinalIgnoreCase))
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
					\u001A\u0012\u0003.\u0018(u000C, 0, '_');
				}
			}
			return \u0001\u0017\u0018.\u0018(u000C);
		}
	}
}
