using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.Exceptions;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x02000202 RID: 514
	internal static class \u0018\u0012
	{
		// Token: 0x0600132C RID: 4908 RVA: 0x0007323C File Offset: 0x0007143C
		internal unsafe static object \u001F(Element \u001F, Dictionary<long, List<Parameter>> \u000A, Dictionary<long, List<Parameter>> \u0007, RevitParameter \u001D, bool \u0004, out Parameter \u0019)
		{
			\u0019 = null;
			if (\u0004\u001B\u0018.\u0007(\u001D) == OtherParamTypes.Custom)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0012.\u001F(Element, Dictionary<long, List<Parameter>>, Dictionary<long, List<Parameter>>, RevitParameter, bool, Parameter*)).MethodHandle;
				}
				return \u0018\u0012.\u0007(\u001F, \u001D\u001B\u0018.\u0007(\u001D), \u0017\u000B\u0018.\u0007(\u001D));
			}
			if (\u0007\u001B\u0018.\u000A(\u001D))
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
				\u0019 = \u0018\u0012.\u000A(\u000A, \u0001\u0008\u0018.\u000A(\u001D));
			}
			if (!\u0009\u0008\u0018.\u000A(\u001D))
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
				if (\u0019 != null)
				{
					goto IL_B3;
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
				if (!\u000A\u001B\u0018.\u000A(\u001D))
				{
					goto IL_B3;
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
			\u0019 = \u0018\u0012.\u000A(\u0007, \u0001\u0008\u0018.\u000A(\u001D));
			\u0017\u001B\u0019.\u0007(\u001D, true);
			IL_B3:
			if (\u0019 == null)
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
				if (\u001F\u001B\u0018.\u0007(\u001D) > 0L)
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
					if (\u0009\u0008\u0018.\u000A(\u001D))
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
						\u0019 = \u0018\u0012.\u000A(\u000A, \u0001\u0008\u0018.\u000A(\u001D));
						\u0017\u001B\u0019.\u0007(\u001D, false);
					}
				}
			}
			return \u0018\u0012.\u001F(\u001F, \u0004, \u0019);
		}

		// Token: 0x0600132D RID: 4909 RVA: 0x0007335C File Offset: 0x0007155C
		internal unsafe static string \u001F(Element \u001F, Dictionary<long, List<Parameter>> \u000A, Dictionary<long, List<Parameter>> \u0007, ParamExportInfo \u001D, bool \u0004, out Parameter \u0019)
		{
			\u0019 = null;
			if (\u0005\u001B\u0018.\u000A(\u001D) == OtherParamTypes.Schedule)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0012.\u001F(Element, Dictionary<long, List<Parameter>>, Dictionary<long, List<Parameter>>, ParamExportInfo, bool, Parameter*)).MethodHandle;
				}
				return "";
			}
			if (!\u000F\u0003\u0018.\u000A(\u001D))
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
				\u0019 = \u001D.\u000A(\u000A);
			}
			if (!\u000F\u0003\u0018.\u000A(\u001D))
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
				if (\u0019 != null)
				{
					goto IL_A1;
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
				if (\u0018\u001B\u0018.\u000A(\u001D) <= 0L)
				{
					goto IL_A1;
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
				if (!\u0019\u001B\u0018.\u0007(\u001D))
				{
					goto IL_A1;
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
			\u0019 = \u001D.\u000A(\u0007);
			IL_A1:
			Parameter parameter = \u0019;
			bool flag;
			if (parameter == null)
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
				flag = false;
			}
			else
			{
				flag = \u0010\u0014\u0007.\u000A(parameter);
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
				return string.Empty;
			}
			return \u001A\u000C\u000A.\u000A(\u0018\u0012.\u001F(\u001F, \u0004, \u0019));
		}

		// Token: 0x0600132E RID: 4910 RVA: 0x0007344C File Offset: 0x0007164C
		private static object \u001F(Element \u001F, bool \u000A, Parameter \u0007)
		{
			object obj = string.Empty;
			if (\u0007 != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0012.\u001F(Element, bool, Parameter)).MethodHandle;
				}
				long num = \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u0007));
				if (num != -1114147L)
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
					if (num != -1140230L)
					{
						if (num != -1114146L)
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
							if (num != -1114136L)
							{
								if (num != -1006304L)
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
									if (num != -1002550L)
									{
										obj = \u0018\u0012.\u001F(\u0007, \u000A);
										goto IL_E4;
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
								obj = \u0018\u0012.\u001D(\u001E\u0010\u0019.\u0007(\u0007));
								goto IL_E4;
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
						obj = \u0017\u000D.\u0003(\u001A\u0014\u0007.\u0007(\u0007));
						goto IL_E4;
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
				obj = \u0017\u000D.\u0010(\u001A\u0014\u0007.\u0007(\u0007));
			}
			IL_E4:
			if (obj != null)
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
				if (!\u0008\u0013\u000A.\u000A(\u001A\u000C\u000A.\u000A(obj), ""))
				{
					return obj;
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
			obj = \u0018\u0012.\u0004(\u0007, \u001F);
			return obj;
		}

		// Token: 0x0600132F RID: 4911 RVA: 0x00073578 File Offset: 0x00071778
		internal static object \u001F(Parameter \u001F, bool \u000A)
		{
			if (\u001F == null)
			{
				return string.Empty;
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0012.\u001F(Parameter, bool)).MethodHandle;
			}
			\u0018\u0012.\u0004\u0012 u0004_u = new \u0018\u0012.\u0004\u0012();
			u0004_u.\u001F = \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F));
			StorageType storageType = \u0011\u001F\u001D.\u0007(\u001F);
			if (storageType == 2)
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
				object result = "";
				if (\u0012\u0003\u0018.\u0007(\u001F))
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
					try
					{
						result = \u0016\u001F\u0007.\u000A(\u0016\u001B\u0018.\u000A(\u001F), 8);
					}
					catch (InvalidOperationException u000A)
					{
						result = 0;
						\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Parameters\\ParameterValueReader.cs", "GetParameterValues");
					}
				}
				return result;
			}
			if (storageType == 1)
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
				string text;
				if (!\u001E\u000B\u0018.\u000A(\u0020\u001F\u001D.\u0007(\u001F)))
				{
					if (u0004_u.\u001F != -1005150L)
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
						if (u0004_u.\u001F != -1005151L)
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
							if (u0004_u.\u001F != -1002110L)
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
								if (u0004_u.\u001F == -1006304L)
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
									if (u0004_u.\u001F == -1001122L)
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
										return EnumHandler.\u0005(\u001E\u0010\u0019.\u0007(\u001F));
									}
									if (u0004_u.\u001F == -1005172L)
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
										return EnumHandler.\u000B(\u001E\u0010\u0019.\u0007(\u001F));
									}
									if (u0004_u.\u001F == -1140335L)
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
										return EnumHandler.\u0006(\u001E\u0010\u0019.\u0007(\u001F));
									}
									if (u0004_u.\u001F == -1001006L)
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
										return EnumHandler.\u0012(\u001E\u0010\u0019.\u0007(\u001F));
									}
									text = \u0017\u0013\u0007.\u001D(\u001F);
									if (!\u001A\u0006\u0007.\u000A(text))
									{
										return text;
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
									text = "";
									if (u0004_u.\u001F == -1011002L)
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
										return "Undefined";
									}
									return text;
								}
							}
						}
					}
					return \u001E\u0010\u0019.\u0007(\u001F);
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
				if (!\u0012\u0003\u0018.\u0007(\u001F))
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
					text = "";
				}
				else
				{
					text = "No";
					if (\u001E\u0010\u0019.\u0007(\u001F) == 1)
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
						text = "Yes";
					}
				}
				return text;
			}
			if (storageType == 3)
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
				string text2 = \u001A\u0014\u0007.\u0007(\u001F);
				string text3;
				if (!\u001A\u0006\u0007.\u000A(text2))
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
					text3 = \u0003\u000B\u001D.\u0007(text2);
				}
				else
				{
					text3 = string.Empty;
				}
				text2 = text3;
				if (!\u001A\u0006\u0007.\u000A(text2))
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
					IEnumerable<char> enumerable = text2;
					Func<char, bool> func;
					if ((func = \u0018\u0012.<>c.\u000A) == null)
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
						func = (\u0018\u0012.<>c.\u000A = new Func<char, bool>(\u0018\u0012.<>c.\u001F.\u0007));
					}
					if (Enumerable.All<char>(enumerable, func))
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
						text2 = string.Empty;
					}
				}
				return text2;
			}
			if (storageType == 4)
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
				ElementId elementId = \u001E\u001B\u001D.\u001D(\u001F);
				string result2;
				if (Enumerable.FirstOrDefault<DropDownparamInfo>(DropDownparamInfo.\u0005(\u000A), new Func<DropDownparamInfo, bool>(u0004_u.\u000A)) != null)
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
					if (\u000B\u001E\u000A.\u000A(elementId) == -1L)
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
						result2 = "None";
					}
					else
					{
						if (u0004_u.\u001F != -1140753L)
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
							if (u0004_u.\u001F != -1001103L)
							{
								return \u0017\u0013\u0007.\u001D(\u001F);
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
						result2 = \u0005\u001E\u000A.\u000A(\u0011\u0017\u000A.\u0007(\u0008\u0019\u0007.\u000A(\u0010\u0003\u0018.\u000A(\u001F)), \u001E\u001B\u001D.\u001D(\u001F)));
					}
				}
				else if (\u000B\u001E\u000A.\u000A(elementId) == -1L)
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
					result2 = "None";
				}
				else
				{
					string text4 = \u0017\u0013\u0007.\u001D(\u001F);
					if (\u001A\u0006\u0007.\u000A(text4))
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
						Element element = \u0011\u0017\u000A.\u0007(\u0008\u0019\u0007.\u000A(\u0010\u0003\u0018.\u000A(\u001F)), elementId);
						string text5;
						if (element == null)
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
							text5 = \u000F\u0015\u0010.\u001F;
						}
						else
						{
							text5 = \u0005\u001E\u000A.\u000A(element);
						}
						text4 = text5;
					}
					string text6;
					if (!\u001A\u0006\u0007.\u000A(text4))
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
						text6 = text4;
					}
					else
					{
						long num = \u000B\u001E\u000A.\u000A(elementId);
						text6 = \u0011\u0013\u000A.\u000A(ref num);
					}
					result2 = text6;
				}
				return result2;
			}
			if (storageType == null)
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
				return \u0017\u0013\u0007.\u001D(\u001F);
			}
			return string.Empty;
		}

		// Token: 0x06001330 RID: 4912 RVA: 0x00073A54 File Offset: 0x00071C54
		private static Parameter \u000A(Dictionary<long, List<Parameter>> \u001F, List<long> \u000A)
		{
			\u0018\u0012.\u0019\u0012 u0019_u = new \u0018\u0012.\u0019\u0012();
			u0019_u.\u001F = \u000A;
			KeyValuePair<long, List<Parameter>> keyValuePair = Enumerable.FirstOrDefault<KeyValuePair<long, List<Parameter>>>(\u001F, new Func<KeyValuePair<long, List<Parameter>>, bool>(u0019_u.\u000A));
			if (\u0002\u001B\u0018.\u000A(ref keyValuePair) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0012.\u000A(Dictionary<long, List<Parameter>>, List<long>)).MethodHandle;
				}
				if (Enumerable.Any<Parameter>(\u0002\u001B\u0018.\u000A(ref keyValuePair)))
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
					return \u000B\u001B\u0018.\u000A(\u0002\u001B\u0018.\u000A(ref keyValuePair), 0);
				}
			}
			return null;
		}

		// Token: 0x06001331 RID: 4913 RVA: 0x00073AD0 File Offset: 0x00071CD0
		private static string \u0007(Element \u001F, string \u000A, long \u0007)
		{
			string result = string.Empty;
			\u000A = \u0003\u000B\u001D.\u0007(\u000A);
			if (\u000D\u0008\u000A.\u000A(\u000A, "GUID", true))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0012.\u0007(Element, string, long)).MethodHandle;
				}
				if (\u001F != null)
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
					result = \u0012\u0010\u0007.\u000A(\u001F);
				}
			}
			else if (\u000D\u0008\u000A.\u000A(\u000A, "Element ID", true))
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
				if (\u001F != null)
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
					long num = \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F));
					result = \u0011\u0013\u000A.\u000A(ref num);
				}
				else
				{
					long num = Constants.InvalidElementIdValue;
					result = \u0011\u0013\u000A.\u000A(ref num);
				}
			}
			else if (\u000D\u0008\u000A.\u000A(\u000A, "Type ID", true))
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
				long num = Constants.InvalidElementIdValue;
				result = \u0011\u0013\u000A.\u000A(ref num);
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
					\u001F = \u0011\u0017\u000A.\u0007(\u0008\u0019\u0007.\u000A(\u001F), \u0004\u0013\u0007.\u000A(\u001F));
					if (\u001F != null)
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
						num = \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F));
						result = \u0011\u0013\u000A.\u000A(ref num);
					}
				}
			}
			else if (\u000D\u0008\u000A.\u000A(\u000A, "Base Equipment", true))
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
				ElectricalSystem electricalSystem = \u0015\u0005\u000E.\u001F(\u001F);
				if (electricalSystem != null)
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
					result = \u0005\u001E\u000A.\u000A(\u0015\u0017\u0019.\u000A(electricalSystem));
				}
			}
			else if (\u0007 != -1L)
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
				Parameter parameter = \u0016\u0018\u0007.\u0007(\u001F, \u0007);
				if (parameter != null)
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
					result = \u0017\u0013\u0007.\u001D(parameter);
				}
			}
			return result;
		}

		// Token: 0x06001332 RID: 4914 RVA: 0x00073C84 File Offset: 0x00071E84
		internal static object \u001D(int \u001F)
		{
			if (\u001F > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0012.\u001D(int)).MethodHandle;
				}
				byte b = (byte)((\u001F & 16711680) >> 16);
				byte b2 = (byte)((\u001F & 65280) >> 8);
				byte b3 = (byte)(\u001F & 255);
				string[] array = \u001B\u001F\u000E.\u001F(5);
				array[0] = \u0006\u001B\u0018.\u000A(ref b);
				array[1] = ", ";
				array[2] = \u0006\u001B\u0018.\u000A(ref b2);
				array[3] = ", ";
				array[4] = \u0006\u001B\u0018.\u000A(ref b3);
				return \u0014\u0006\u001D.\u000A(array);
			}
			return "0, 0, 0";
		}

		// Token: 0x06001333 RID: 4915 RVA: 0x00073D14 File Offset: 0x00071F14
		internal static string \u0004(Parameter \u001F, Element \u000A)
		{
			long? num2;
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0012.\u0004(Parameter, Element)).MethodHandle;
				}
				long? num;
				\u000B\u0019\u000E.\u001F(ref num);
				num2 = num;
			}
			else
			{
				num2 = new long?(\u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u001D(\u001F)));
			}
			long? num3 = num2;
			if (\u001F != null)
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
				long? num = num3;
				long num4 = -1002002L;
				if (!(\u0012\u001B\u0018.\u000A(ref num) == num4 & \u0016\u0002\u0004.\u000A(ref num)))
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
					num = num3;
					num4 = -1002001L;
					if (!(\u0012\u001B\u0018.\u000A(ref num) == num4 & \u0016\u0002\u0004.\u000A(ref num)))
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
						num = num3;
						num4 = -1001210L;
						if (!(\u0012\u001B\u0018.\u000A(ref num) == num4 & \u0016\u0002\u0004.\u000A(ref num)))
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
							num = num3;
							num4 = 187002L;
							if (!(\u0012\u001B\u0018.\u000A(ref num) == num4 & \u0016\u0002\u0004.\u000A(ref num)))
							{
								goto IL_222;
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
				FamilyInstance familyInstance = \u000D\u000B\u000E.\u001F(\u000A);
				object obj;
				if (familyInstance == null)
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
					obj = null;
				}
				else
				{
					obj = \u001C\u001B\u0018.\u0007(familyInstance);
				}
				object obj2 = obj;
				Family family;
				if (obj2 == null)
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
					family = \u0010\u000B\u000E.\u001F;
				}
				else
				{
					family = \u0003\u001B\u0018.\u0007(obj2);
				}
				Family family2 = family;
				num = num3;
				num4 = -1002002L;
				if (\u0012\u001B\u0018.\u000A(ref num) == num4 & \u0016\u0002\u0004.\u000A(ref num))
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
					if (family2 == null)
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
						return "";
					}
					return \u0005\u001E\u000A.\u000A(family2);
				}
				else
				{
					num = num3;
					num4 = -1002001L;
					if (\u0012\u001B\u0018.\u000A(ref num) == num4 & \u0016\u0002\u0004.\u000A(ref num))
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
						if (familyInstance == null)
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
							return "";
						}
						return \u0005\u001E\u000A.\u000A(familyInstance);
					}
					else
					{
						bool flag;
						if (familyInstance == null)
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
							flag = (null != null);
						}
						else
						{
							flag = (\u000D\u0003\u0018.\u001D(familyInstance) != null);
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
							if (\u000F\u001B\u0018.\u000A(\u000D\u0003\u0018.\u0007(familyInstance)) == null)
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
								return "";
							}
							return \u0005\u001E\u000A.\u000A(\u000F\u001B\u0018.\u000A(\u000D\u0003\u0018.\u0007(familyInstance)));
						}
					}
				}
			}
			IL_222:
			return string.Empty;
		}

		// Token: 0x020008AC RID: 2220
		[CompilerGenerated]
		private sealed class \u0004\u0012
		{
			// Token: 0x06004FDB RID: 20443 RVA: 0x001E5E20 File Offset: 0x001E4020
			internal bool \u000A(DropDownparamInfo \u001F)
			{
				return \u0005\u0019\u0010.\u000A(\u001F) == this.\u001F;
			}

			// Token: 0x04002289 RID: 8841
			public long \u001F;
		}

		// Token: 0x020008AD RID: 2221
		[CompilerGenerated]
		private sealed class \u0019\u0012
		{
			// Token: 0x06004FDD RID: 20445 RVA: 0x001E5E54 File Offset: 0x001E4054
			internal bool \u000A(KeyValuePair<long, List<Parameter>> \u001F)
			{
				return \u001A\u0008\u0019.\u000A(this.\u001F, \u0004\u0016\u0010.\u000A(ref \u001F));
			}

			// Token: 0x0400228A RID: 8842
			public List<long> \u001F;
		}
	}
}
