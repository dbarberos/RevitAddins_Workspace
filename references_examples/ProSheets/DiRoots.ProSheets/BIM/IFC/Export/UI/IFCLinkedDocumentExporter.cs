using System;
using System.Collections.Generic;
using System.Linq;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.IFC;
using DiRoots.One.Commons.Interfaces;

namespace BIM.IFC.Export.UI
{
	// Token: 0x02000009 RID: 9
	public class IFCLinkedDocumentExporter
	{
		// Token: 0x06000020 RID: 32 RVA: 0x000025DC File Offset: 0x000007DC
		public IFCLinkedDocumentExporter(Document document, IFCExportOptions ifcOptions, ICustomLogger customLogger)
		{
			this.\u0016 = customLogger;
			this.\u000C = document;
			this.\u0018 = ifcOptions;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002610 File Offset: 0x00000810
		private static string \u000D(Transform \u000C)
		{
			return \u0014\u001E\u0018.\u0018(\u0014\u001E\u0018.\u0018(\u0014\u001E\u0018.\u0018(\u0014\u001E\u0018.\u0018(string.Empty, IFCLinkedDocumentExporter.\u001C(\u0012\u001E\u0018.\u0018(\u000C)), ";"), IFCLinkedDocumentExporter.\u001C(\u000F\u001E\u0018.\u0018(\u000C)), ";"), IFCLinkedDocumentExporter.\u001C(\u0016\u001E\u0018.\u0018(\u000C)), ";"), IFCLinkedDocumentExporter.\u001C(\u0003\u001E\u0018.\u0018(\u000C)), ";");
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002690 File Offset: 0x00000890
		private static string \u001C(XYZ \u000C)
		{
			return \u0001\u0017\u0018.\u0018(\u000C);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000026A8 File Offset: 0x000008A8
		private unsafe void \u0013(ref string \u000C, string \u0018, IList<ElementId> \u0014)
		{
			if (\u0009\u001E\u0018.\u0018(\u000C, ""))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCLinkedDocumentExporter.\u0013(string*, string, IList<ElementId>)).MethodHandle;
				}
				\u000C = \u000D\u001E\u0018.\u0018(\u000C, "\n");
			}
			if (\u0013\u001E\u0018.\u0018(\u0014) > 0)
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
				\u000C = \u000D\u001E\u0018.\u0018(\u000C, \u001C\u001E\u0018.\u0018(\u0018, this.\u000A(\u0014)));
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000271C File Offset: 0x0000091C
		private unsafe void \u0009(ref string \u000C, string \u0018, IList<string> \u0014)
		{
			if (\u0009\u001E\u0018.\u0018(\u000C, ""))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCLinkedDocumentExporter.\u0009(string*, string, IList<string>)).MethodHandle;
				}
				\u000C = \u000D\u001E\u0018.\u0018(\u000C, "\n");
			}
			if (\u000A\u001E\u0018.\u0018(\u0014) > 0)
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
				\u000C = \u000D\u001E\u0018.\u0018(\u000C, \u001C\u001E\u0018.\u0018(\u0018, this.\u001F(\u0014)));
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002790 File Offset: 0x00000990
		private string \u000A(IList<ElementId> \u000C)
		{
			string text = "";
			IEnumerator<ElementId> enumerator = \u0015\u001E\u0018.\u0018(\u000C);
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator))
				{
					ElementId u000C = \u0011\u001E\u0018.\u0018(enumerator);
					if (\u0009\u001E\u0018.\u0018(text, ""))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(IFCLinkedDocumentExporter.\u000A(IList<ElementId>)).MethodHandle;
						}
						text = \u000D\u001E\u0018.\u0018(text, ", ");
					}
					text = \u000D\u001E\u0018.\u0018(text, \u0001\u0017\u0018.\u0018(u000C));
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
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					\u0020\u001E\u0018.\u0018(enumerator);
				}
			}
			return text;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002834 File Offset: 0x00000A34
		private void \u0020(Document \u000C, string \u0018, IDictionary<ElementId, string> \u0014, IDictionary<RevitLinkInstance, Transform> \u0003, IFCExportOptions \u0016, ElementId \u000F)
		{
			\u000D\u0004\u0018.\u0018(this.\u0016, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\IFC\\IFCLinkedDocumentExporter.cs", "ExportLinkedDocuments");
			int num = \u0012\u0004\u0018.\u0018(\u0018, '.');
			if (num <= 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCLinkedDocumentExporter.\u0020(Document, string, IDictionary<ElementId, string>, IDictionary<RevitLinkInstance, Transform>, IFCExportOptions, ElementId)).MethodHandle;
				}
				return;
			}
			string u = \u000D\u0002\u0018.\u0018(\u0018, num);
			\u0018 = \u0003\u0002\u0018.\u0018(\u0018, 0, num);
			IDictionary<string, int> dictionary = \u000F\u0004\u0018.\u0018();
			IDictionary<string, List<RevitLinkInstance>> u000C = \u0016\u0004\u0018.\u0018();
			try
			{
				View u2 = \u0018\u0002\u000F.\u000C(\u0003\u0004\u0018.\u0018(\u000C, \u000F));
				IEnumerator<RevitLinkInstance> enumerator = \u0018\u0004\u0018.\u0018(\u0014\u0004\u0018.\u0018(\u0003));
				try
				{
					while (\u001F\u001E\u0018.\u0018(enumerator))
					{
						RevitLinkInstance revitLinkInstance = \u000C\u0004\u0018.\u0018(enumerator);
						if (this.\u0017(revitLinkInstance, u2))
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
							Document document = \u0013\u0002\u0018.\u0018(revitLinkInstance);
							if (document != null)
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
								Parameter parameter = \u0005\u0002\u0018.\u0014(\u000E\u0002\u0018.\u0018(document), "Original IFC File Name");
								if (parameter == null)
								{
									goto IL_11B;
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
								if (\u001B\u0002\u0018.\u0018(parameter) != 3)
								{
									goto IL_11B;
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
								string u3 = \u0001\u0002\u0018.\u0018(parameter);
								IL_126:
								string text = this.\u0015(document, u3);
								if (!\u000B\u0002\u0018.\u0018(\u0006\u0002\u0018.\u0018(dictionary), text))
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
									\u0010\u0002\u0018.\u0018(dictionary, text, 0);
								}
								IDictionary<string, int> u000C2 = dictionary;
								string u4 = text;
								int num2 = \u0014\u0002\u0018.\u0018(u000C2, u4);
								\u0007\u0002\u0018.\u0018(u000C2, u4, num2 + 1);
								if (!\u000B\u0002\u0018.\u0018(\u0019\u0002\u0018.\u0018(u000C), u3))
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
									\u001D\u0002\u0018.\u0018(u000C, u3, \u001A\u0002\u0018.\u0018());
								}
								\u0004\u0002\u0018.\u0018(\u0015\u0002\u0018.\u0018(u000C, u3), revitLinkInstance);
								continue;
								IL_11B:
								u3 = \u0008\u0002\u0018.\u0018(document);
								goto IL_126;
							}
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
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
						\u0020\u001E\u0018.\u0018(enumerator);
					}
				}
			}
			catch (Exception u5)
			{
				\u001E\u001E\u0018.\u0018(this.\u0016, u5, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\IFC\\IFCLinkedDocumentExporter.cs", "ExportLinkedDocuments");
			}
			IEnumerator<KeyValuePair<string, List<RevitLinkInstance>>> enumerator2 = \u0002\u0002\u0018.\u0018(u000C);
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator2))
				{
					KeyValuePair<string, List<RevitLinkInstance>> keyValuePair = \u001E\u0002\u0018.\u0018(enumerator2);
					string text2 = \u0017\u0002\u0018.\u0018(ref keyValuePair);
					object u000C3 = \u0015\u0002\u0018.\u0018(u000C, text2);
					IList<string> u000C4 = \u0011\u0002\u0018.\u0018();
					IList<Tuple<ElementId, string>> u000C5 = \u001F\u0002\u0018.\u0018();
					Document document2 = \u0014\u0002\u000F.\u000C;
					List<RevitLinkInstance>.Enumerator enumerator3 = \u0020\u0002\u0018.\u0018(u000C3);
					try
					{
						while (\u001B\u001E\u0018.\u0018(ref enumerator3))
						{
							RevitLinkInstance revitLinkInstance2 = \u000A\u0002\u0018.\u0018(ref enumerator3);
							if (revitLinkInstance2 != null)
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
								ElementId elementId = \u0009\u0002\u0018.\u0018(revitLinkInstance2);
								Document document3;
								if ((document3 = document2) == null)
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
									document3 = \u0013\u0002\u0018.\u0018(revitLinkInstance2);
								}
								document2 = document3;
								string text3 = this.\u0015(document2, text2);
								if (\u001C\u0002\u0018.\u0014(text2) < 4)
								{
									goto IL_2F2;
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
								if (\u000F\u0002\u0018.\u0018(\u0012\u0002\u0018.\u0018(\u000D\u0002\u0018.\u0018(text2, \u001C\u0002\u0018.\u0014(text2) - 4)), ".ifc"))
								{
									goto IL_387;
								}
								for (;;)
								{
									switch (7)
									{
									case 0:
										continue;
									}
									goto IL_2F2;
								}
								IL_437:
								text3 = \u000D\u001E\u0018.\u0018(text3, u);
								\u000C\u0002\u0018.\u0018(u000C4, text3);
								\u0005\u001E\u0018.\u0018(u000C5, Tuple.Create<ElementId, string>(elementId, IFCLinkedDocumentExporter.\u000D(\u000E\u001E\u0018.\u0018(\u0003, revitLinkInstance2))));
								continue;
								IL_2F2:
								if (\u001C\u0002\u0018.\u0014(text2) >= 7)
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
									if (\u000F\u0002\u0018.\u0018(\u0012\u0002\u0018.\u0018(\u000D\u0002\u0018.\u0018(text2, \u001C\u0002\u0018.\u0014(text2) - 7)), ".ifcxml"))
									{
										goto IL_387;
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
								if (\u001C\u0002\u0018.\u0014(text2) >= 7)
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
									if (\u000F\u0002\u0018.\u0018(\u0012\u0002\u0018.\u0018(\u000D\u0002\u0018.\u0018(text2, \u001C\u0002\u0018.\u0014(text2) - 7)), ".ifczip"))
									{
										for (;;)
										{
											switch (2)
											{
											case 0:
												continue;
											}
											goto IL_387;
										}
									}
								}
								bool flag = \u0014\u0002\u0018.\u0018(dictionary, text3) > 1;
								text3 = \u0014\u001E\u0018.\u0018(\u0018, "-", text3);
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
									text3 = \u000D\u001E\u0018.\u0018(text3, "-");
									text3 = \u000D\u001E\u0018.\u0018(text3, \u0018\u0002\u0018.\u0018(\u0014, elementId));
									goto IL_437;
								}
								goto IL_437;
								IL_387:
								string u000C6 = \u0018;
								num = \u0016\u0002\u0018.\u0018(u000C6, "\\");
								if (num > 0)
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
									u000C6 = \u0003\u0002\u0018.\u0018(u000C6, 0, num + 1);
								}
								else
								{
									u000C6 = "";
								}
								text3 = \u0014\u001E\u0018.\u0018(u000C6, text3, "-");
								text3 = \u000D\u001E\u0018.\u0018(text3, \u0018\u0002\u0018.\u0018(\u0014, elementId));
								goto IL_437;
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
					finally
					{
						((IDisposable)enumerator3).Dispose();
					}
					if (document2 != null)
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
						try
						{
							int num3 = \u000A\u001E\u0018.\u0018(u000C4);
							\u0007\u001E\u0018.\u0018(\u0016, "NumberOfExportedLinkInstances", \u0010\u001E\u0018.\u0018(ref num3));
							for (int i = 0; i < num3; i++)
							{
								string text4;
								if (i != 0)
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
									string u000C7 = "ExportLinkId";
									int num2 = i + 1;
									text4 = \u000D\u001E\u0018.\u0018(u000C7, \u0010\u001E\u0018.\u0018(ref num2));
								}
								else
								{
									text4 = "ExportLinkId";
								}
								string u6 = text4;
								\u0007\u001E\u0018.\u0018(\u0016, u6, \u0001\u0017\u0018.\u0018(\u0001\u001E\u0018.\u0018(\u0008\u001E\u0018.\u0018(u000C5, i))));
								string text5;
								if (i != 0)
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
									string u000C8 = "ExportLinkInstanceTransform";
									int num2 = i + 1;
									text5 = \u000D\u001E\u0018.\u0018(u000C8, \u0010\u001E\u0018.\u0018(ref num2));
								}
								else
								{
									text5 = "ExportLinkInstanceTransform";
								}
								u6 = text5;
								\u0007\u001E\u0018.\u0018(\u0016, u6, \u0006\u001E\u0018.\u0018(\u0008\u001E\u0018.\u0018(u000C5, i)));
								if (i != 0)
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
									string u000C9 = "ExportLinkInstanceFileName";
									int num2 = i + 1;
									u6 = \u000D\u001E\u0018.\u0018(u000C9, \u0010\u001E\u0018.\u0018(ref num2));
									\u0007\u001E\u0018.\u0018(\u0016, u6, \u0002\u001E\u0018.\u0018(u000C4, i));
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
							string u7 = \u0019\u001E\u0018.\u0018(\u0002\u001E\u0018.\u0018(u000C4, 0));
							string u8 = \u000B\u001E\u0018.\u0018(\u0002\u001E\u0018.\u0018(u000C4, 0));
							\u0008\u0017\u0018.\u0018(this.\u0016, \u001A\u001E\u0018.\u0018("Exporting link: {0} with {1} instances.", \u0002\u001E\u0018.\u0018(u000C4, 0), num3), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\IFC\\IFCLinkedDocumentExporter.cs", "ExportLinkedDocuments");
							IFCLinkDocumentExportScope ifclinkDocumentExportScope = \u001D\u001E\u0018.\u0018(document2);
							try
							{
								\u0004\u001E\u0018.\u0018(document2, u7, u8, \u0016);
							}
							finally
							{
								if (ifclinkDocumentExportScope != null)
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
									\u0020\u001E\u0018.\u0018(ifclinkDocumentExportScope);
								}
							}
							\u0008\u0017\u0018.\u0018(this.\u0016, \u000D\u001E\u0018.\u0018("Exporting link ends: ", \u0002\u001E\u0018.\u0018(u000C4, 0)), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\IFC\\IFCLinkedDocumentExporter.cs", "ExportLinkedDocuments");
						}
						catch (Exception u9)
						{
							\u001E\u001E\u0018.\u0018(this.\u0016, u9, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\IFC\\IFCLinkedDocumentExporter.cs", "ExportLinkedDocuments");
						}
					}
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
			finally
			{
				if (enumerator2 != null)
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
					\u0020\u001E\u0018.\u0018(enumerator2);
				}
			}
			\u0017\u001E\u0018.\u0018(this.\u0016, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\IFC\\IFCLinkedDocumentExporter.cs", "ExportLinkedDocuments");
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002FB8 File Offset: 0x000011B8
		private string \u001F(IList<string> \u000C)
		{
			string text = "";
			IEnumerator<string> enumerator = \u0013\u0004\u0018.\u0018(\u000C);
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator))
				{
					string u = \u001C\u0004\u0018.\u0018(enumerator);
					if (\u0009\u001E\u0018.\u0018(text, ""))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(IFCLinkedDocumentExporter.\u001F(IList<string>)).MethodHandle;
						}
						text = \u000D\u001E\u0018.\u0018(text, "; ");
					}
					text = \u000D\u001E\u0018.\u0018(text, u);
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
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					\u0020\u001E\u0018.\u0018(enumerator);
				}
			}
			return text;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003054 File Offset: 0x00001254
		private ValueTuple<IDictionary<RevitLinkInstance, Transform>, string, int> \u0011(IList<RevitLinkInstance> \u000C)
		{
			IDictionary<RevitLinkInstance, Transform> dictionary = \u0010\u0004\u0018.\u0018();
			IList<string> u = \u0011\u0002\u0018.\u0018();
			IList<ElementId> list = \u0007\u0004\u0018.\u0018();
			IList<ElementId> list2 = \u0007\u0004\u0018.\u0018();
			IList<ElementId> list3 = \u0007\u0004\u0018.\u0018();
			Func<RevitLinkInstance, long> func;
			if ((func = IFCLinkedDocumentExporter.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCLinkedDocumentExporter.\u0011(IList<RevitLinkInstance>)).MethodHandle;
				}
				func = (IFCLinkedDocumentExporter.<>c.\u0018 = new Func<RevitLinkInstance, long>(IFCLinkedDocumentExporter.<>c.\u000C.\u0014));
			}
			IEnumerator<RevitLinkInstance> enumerator = \u0018\u0004\u0018.\u0018(Enumerable.OrderBy<RevitLinkInstance, long>(\u000C, func));
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator))
				{
					RevitLinkInstance revitLinkInstance = \u000C\u0004\u0018.\u0018(enumerator);
					if (revitLinkInstance != null)
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
						Document document = \u0013\u0002\u0018.\u0018(revitLinkInstance);
						if (document != null)
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
							ForgeTypeId u2 = \u001D\u0004\u0018.\u0018(\u001A\u0004\u0018.\u0018(\u0019\u0004\u0018.\u0018(document), \u000B\u0004\u0018.\u0018()));
							double u3 = \u0004\u0004\u0018.\u0018(1.0, u2);
							Transform transform = \u0002\u0004\u0018.\u0018(revitLinkInstance);
							ElementId u4 = \u0009\u0002\u0018.\u0018(revitLinkInstance);
							if (!\u001E\u0004\u0018.\u0018(transform))
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
								\u001F\u0004\u0018.\u0018(list, u4);
								this.\u0003++;
							}
							else if (\u0017\u0004\u0018.\u0018(transform))
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
								\u001F\u0004\u0018.\u0018(list3, u4);
								this.\u0003++;
							}
							else if (!\u0011\u0004\u0018.\u0018(\u0015\u0004\u0018.\u0018(transform), 1.0))
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
								\u001F\u0004\u0018.\u0018(list2, u4);
								this.\u0003++;
							}
							else
							{
								Transform u000C = transform;
								\u000A\u0004\u0018.\u0018(u000C, \u0020\u0004\u0018.\u0018(\u0012\u001E\u0018.\u0018(u000C), u3));
								\u0009\u0004\u0018.\u0018(dictionary, revitLinkInstance, transform);
							}
						}
					}
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
					\u0020\u001E\u0018.\u0018(enumerator);
				}
			}
			string empty = string.Empty;
			this.\u0009(ref empty, "LinkInstanceExportCantCreateDoc", u);
			this.\u0013(ref empty, "LinkInstanceExportNonConformal", list);
			this.\u0013(ref empty, "LinkInstanceExportScaled", list2);
			this.\u0013(ref empty, "LinkInstanceExportHasReflection", list3);
			return new ValueTuple<IDictionary<RevitLinkInstance, Transform>, string, int>(dictionary, empty, this.\u0003);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000032AC File Offset: 0x000014AC
		private string \u0015(Document \u000C, string \u0018)
		{
			int num = \u0016\u0002\u0018.\u0018(\u0018, "\\");
			if (num <= 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCLinkedDocumentExporter.\u0015(Document, string)).MethodHandle;
				}
				return \u0006\u0004\u0018.\u0018(\u000C);
			}
			string text = \u000D\u0002\u0018.\u0018(\u0018, num + 1);
			num = \u0012\u0004\u0018.\u0018(text, '.');
			if (num > 0)
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
				text = \u0003\u0002\u0018.\u0018(text, 0, num);
			}
			return text;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003318 File Offset: 0x00001518
		private bool \u0017(Element \u000C, View \u0018)
		{
			if (\u0018 == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCLinkedDocumentExporter.\u0017(Element, View)).MethodHandle;
				}
				return true;
			}
			if (\u0005\u0004\u0018.\u0018(\u000C, \u0018))
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
				return false;
			}
			Category category = \u001B\u0004\u0018.\u0018(\u000C);
			bool flag;
			if (category == null)
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
				flag = \u0001\u0004\u0018.\u0018(category, \u0018);
			}
			if (!flag)
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
				return false;
			}
			return \u0008\u0004\u0018.\u0018(\u0018, 2, \u0009\u0002\u0018.\u0018(\u000C));
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003394 File Offset: 0x00001594
		public void ExportSeparateDocuments(string fullName, string linkExportKind)
		{
			if (!this.\u0004(linkExportKind))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCLinkedDocumentExporter.ExportSeparateDocuments(string, string)).MethodHandle;
				}
				return;
			}
			if (!this.\u0002(linkExportKind))
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
				return;
			}
			ElementId elementId = \u0014\u001D\u0018.\u0018(this.\u0018);
			if (\u0003\u001D\u0018.\u0018(elementId, \u0018\u001D\u0018.\u0018()))
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
				\u0007\u001E\u0018.\u0018(this.\u0018, "HostViewId", \u0001\u0017\u0018.\u0018(\u0014\u001D\u0018.\u0018(this.\u0018)));
				\u000C\u001D\u0018.\u0018(this.\u0018, \u0018\u001D\u0018.\u0018());
			}
			\u000E\u0004\u0018.\u0018(this.\u000C);
			this.\u001E(linkExportKind, "");
			this.\u0020(this.\u000C, fullName, this.\u000F, this.\u0012, this.\u0018, elementId);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000346C File Offset: 0x0000166C
		public string GetErrors()
		{
			return this.\u0014;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003480 File Offset: 0x00001680
		public int GetNumberOfBadInstances()
		{
			return this.\u0003;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003494 File Offset: 0x00001694
		public void SetExportOption(string linkExportKind)
		{
			if (!this.\u0004(linkExportKind))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCLinkedDocumentExporter.SetExportOption(string)).MethodHandle;
				}
				return;
			}
			bool flag = this.\u0002(linkExportKind);
			object u000C = \u0020\u001D\u0018.\u0018(this.\u000C);
			ElementFilter u = \u0009\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000E\u001E\u000F.\u000C()));
			List<RevitLinkInstance> u000C2 = Enumerable.ToList<RevitLinkInstance>(Enumerable.Cast<RevitLinkInstance>(\u0013\u001D\u0018.\u0014(u000C, u)));
			string text = string.Empty;
			ValueTuple<IDictionary<RevitLinkInstance, Transform>, string, int> valueTuple = this.\u0011(u000C2);
			this.\u0012 = valueTuple.Item1;
			this.\u0014 = valueTuple.Item2;
			ISet<string> u000C3 = \u001C\u001D\u0018.\u0018();
			IEnumerator<RevitLinkInstance> enumerator = \u0018\u0004\u0018.\u0018(\u0014\u0004\u0018.\u0018(this.\u0012));
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator))
				{
					RevitLinkInstance u000C4 = \u000C\u0004\u0018.\u0018(enumerator);
					string text2 = \u000D\u001D\u0018.\u0018(u000C4);
					string text3 = \u0012\u0002\u0018.\u0018(text2);
					while (\u000B\u0002\u0018.\u0018(u000C3, text3))
					{
						text2 = \u000D\u001E\u0018.\u0018(text2, "-");
						text3 = \u000D\u001E\u0018.\u0018(text3, "-");
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
					\u0012\u001D\u0018.\u0018(u000C3, text3);
					if (!flag)
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
						string[] array = \u000C\u0002\u000F.\u000C(5);
						array[0] = text;
						array[1] = \u0001\u0017\u0018.\u0018(\u0009\u0002\u0018.\u0018(u000C4));
						array[2] = ",";
						array[3] = text2;
						array[4] = ";";
						text = \u000F\u001D\u0018.\u0018(array);
					}
					else
					{
						\u0016\u001D\u0018.\u0018(this.\u000F, \u0009\u0002\u0018.\u0018(u000C4), text2);
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
					\u0020\u001E\u0018.\u0018(enumerator);
				}
			}
			if (!flag)
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
				this.\u001E(linkExportKind, text);
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003670 File Offset: 0x00001870
		private void \u001E(string \u000C, string \u0018 = "")
		{
			\u0007\u001E\u0018.\u0018(this.\u0018, "ExportingLinks", \u000C);
			\u0007\u001E\u0018.\u0018(this.\u0018, "FederatedLinkInfo", \u0018);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000036A0 File Offset: 0x000018A0
		private bool \u0002(string \u000C)
		{
			return \u000F\u0002\u0018.\u0018(\u000C, "ExportAsSeparate");
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000036BC File Offset: 0x000018BC
		private bool \u0004(string \u000C)
		{
			return \u0009\u001E\u0018.\u0018(\u000C, "DontExport");
		}

		// Token: 0x0400000B RID: 11
		private readonly Document \u000C;

		// Token: 0x0400000C RID: 12
		private readonly IFCExportOptions \u0018;

		// Token: 0x0400000D RID: 13
		private string \u0014;

		// Token: 0x0400000E RID: 14
		private int \u0003;

		// Token: 0x0400000F RID: 15
		private readonly ICustomLogger \u0016;

		// Token: 0x04000010 RID: 16
		internal IDictionary<ElementId, string> \u000F = new Dictionary<ElementId, string>();

		// Token: 0x04000011 RID: 17
		internal IDictionary<RevitLinkInstance, Transform> \u0012;
	}
}
