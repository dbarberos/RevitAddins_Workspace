using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using A;

namespace ProSheets
{
	// Token: 0x0200006E RID: 110
	public class UtilityXML
	{
		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06000640 RID: 1600 RVA: 0x000256C0 File Offset: 0x000238C0
		// (set) Token: 0x06000641 RID: 1601 RVA: 0x000256D4 File Offset: 0x000238D4
		public static Profiles profiles { get; set; } = \u0004\u000A\u0014.\u0018();

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000642 RID: 1602 RVA: 0x000256E8 File Offset: 0x000238E8
		// (set) Token: 0x06000643 RID: 1603 RVA: 0x000256FC File Offset: 0x000238FC
		public static AutoRemember remember_settings { get; set; } = \u001B\u000F\u0003.\u0018();

		// Token: 0x06000644 RID: 1604 RVA: 0x00025710 File Offset: 0x00023910
		public static bool SerialiseTemplateInfo(ExportTemPlateInfo tempInfo, string path)
		{
			bool result;
			try
			{
				XmlSerializer u000C = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u0014\u0019\u000F.\u000C()));
				XmlSerializerNamespaces xmlSerializerNamespaces = \u0019\u001D\u0018.\u0018();
				\u000B\u001D\u0018.\u0018(xmlSerializerNamespaces, "", "");
				TextWriter textWriter = \u001A\u001D\u0018.\u0018(path);
				try
				{
					\u001D\u001D\u0018.\u0018(u000C, textWriter, tempInfo, xmlSerializerNamespaces);
					\u0004\u001D\u0018.\u0018(textWriter);
				}
				finally
				{
					if (textWriter != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(UtilityXML.SerialiseTemplateInfo(ExportTemPlateInfo, string)).MethodHandle;
						}
						\u0020\u001E\u0018.\u0018(textWriter);
					}
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x000257A8 File Offset: 0x000239A8
		public static string GetProfileDirectory()
		{
			string text = \u0003\u001A\u0018.\u0018(\u000A\u0006\u0018.\u0018(Environment.SpecialFolder.LocalApplicationData), "DiRoots\\ProSheets\\Profiles");
			if (!\u0012\u0006\u0018.\u0018(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UtilityXML.GetProfileDirectory()).MethodHandle;
				}
				\u000F\u0006\u0018.\u0018(text);
			}
			return text;
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x000257F4 File Offset: 0x000239F4
		public static string GetProfilesFilePath()
		{
			return \u000D\u001E\u0018.\u0018(\u0005\u000F\u0003.\u0018(), "\\profiles.xml");
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x00025814 File Offset: 0x00023A14
		public static bool SerializeAutoRemember()
		{
			bool result;
			try
			{
				string u000C = \u000D\u001E\u0018.\u0018(\u0005\u000F\u0003.\u0018(), "\\auto_remember.xml");
				XmlSerializer u000C2 = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000F\u0019\u000F.\u000C()));
				XmlSerializerNamespaces xmlSerializerNamespaces = \u0019\u001D\u0018.\u0018();
				\u000B\u001D\u0018.\u0018(xmlSerializerNamespaces, "", "");
				TextWriter textWriter = \u001A\u001D\u0018.\u0018(u000C);
				try
				{
					\u001D\u001D\u0018.\u0018(u000C2, textWriter, \u000E\u000F\u0003.\u0018(), xmlSerializerNamespaces);
					\u0004\u001D\u0018.\u0018(textWriter);
				}
				finally
				{
					if (textWriter != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(UtilityXML.SerializeAutoRemember()).MethodHandle;
						}
						\u0020\u001E\u0018.\u0018(textWriter);
					}
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x000258C4 File Offset: 0x00023AC4
		public static void DeserialiseAutoRemember()
		{
			try
			{
				\u000C\u0012\u0003.\u0018(\u001B\u000F\u0003.\u0018());
				string u000C = \u000D\u001E\u0018.\u0018(\u0005\u000F\u0003.\u0018(), "\\auto_remember.xml");
				if (\u000C\u001A\u0018.\u0018(u000C))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(UtilityXML.DeserialiseAutoRemember()).MethodHandle;
					}
					object u000C2 = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000F\u0019\u000F.\u000C()));
					StreamReader streamReader = \u000E\u001D\u0018.\u0018(u000C);
					\u000C\u0012\u0003.\u0018(\u0012\u0019\u000F.\u000C(\u0005\u001D\u0018.\u0018(u000C2, streamReader)));
					\u001B\u001D\u0018.\u0018(streamReader);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x0002595C File Offset: 0x00023B5C
		public static bool SerializeDefaultProfile(Profile p)
		{
			bool result;
			try
			{
				string u000C = \u000D\u001E\u0018.\u0018(\u0005\u000F\u0003.\u0018(), "\\default_profile.xml");
				Profiles profiles = \u0004\u000A\u0014.\u0018();
				\u0009\u000A\u0014.\u0018(\u001B\u0009\u0014.\u0014(profiles), p);
				XmlSerializer u000C2 = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000A\u001A\u000F.\u000C()));
				XmlSerializerNamespaces xmlSerializerNamespaces = \u0019\u001D\u0018.\u0018();
				\u000B\u001D\u0018.\u0018(xmlSerializerNamespaces, "", "");
				TextWriter textWriter = \u001A\u001D\u0018.\u0018(u000C);
				try
				{
					\u001D\u001D\u0018.\u0018(u000C2, textWriter, profiles, xmlSerializerNamespaces);
					\u0004\u001D\u0018.\u0018(textWriter);
				}
				finally
				{
					if (textWriter != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(UtilityXML.SerializeDefaultProfile(Profile)).MethodHandle;
						}
						\u0020\u001E\u0018.\u0018(textWriter);
					}
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x00025A20 File Offset: 0x00023C20
		public static Profile DeserializeDefaultProfile()
		{
			Profiles u000C = \u0004\u000A\u0014.\u0018();
			try
			{
				string u000C2 = \u000D\u001E\u0018.\u0018(\u0005\u000F\u0003.\u0018(), "\\default_profile.xml");
				if (\u000C\u001A\u0018.\u0018(u000C2))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(UtilityXML.DeserializeDefaultProfile()).MethodHandle;
					}
					object u000C3 = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000A\u001A\u000F.\u000C()));
					StreamReader streamReader = \u000E\u001D\u0018.\u0018(u000C2);
					u000C = \u0016\u0019\u000F.\u000C(\u0005\u001D\u0018.\u0018(u000C3, streamReader));
					\u001B\u001D\u0018.\u0018(streamReader);
				}
			}
			catch (Exception)
			{
			}
			if (\u0006\u000A\u0014.\u0018(\u001B\u0009\u0014.\u0014(u000C)) > 0)
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
				return \u0010\u000A\u0014.\u0018(\u001B\u0009\u0014.\u0014(u000C), 0);
			}
			return \u0002\u000A\u0014.\u0018();
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x00025AE4 File Offset: 0x00023CE4
		public static bool SerializeProfiles()
		{
			bool result;
			try
			{
				string u000C = \u0002\u0018\u0003.\u0018();
				XmlSerializer u000C2 = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000A\u001A\u000F.\u000C()));
				XmlSerializerNamespaces xmlSerializerNamespaces = \u0019\u001D\u0018.\u0018();
				\u000B\u001D\u0018.\u0018(xmlSerializerNamespaces, "", "");
				TextWriter textWriter = \u001A\u001D\u0018.\u0018(u000C);
				try
				{
					\u001D\u001D\u0018.\u0018(u000C2, textWriter, \u0005\u0009\u0014.\u0018(), xmlSerializerNamespaces);
					\u0004\u001D\u0018.\u0018(textWriter);
				}
				finally
				{
					if (textWriter != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(UtilityXML.SerializeProfiles()).MethodHandle;
						}
						\u0020\u001E\u0018.\u0018(textWriter);
					}
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x00025B88 File Offset: 0x00023D88
		public static Profiles DeserialiseProfiles(string filePath)
		{
			Profiles result = \u0004\u000A\u0014.\u0018();
			try
			{
				if (\u000C\u001A\u0018.\u0018(filePath))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(UtilityXML.DeserialiseProfiles(string)).MethodHandle;
					}
					object u000C = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000A\u001A\u000F.\u000C()));
					StreamReader streamReader = \u000E\u001D\u0018.\u0018(filePath);
					result = \u0016\u0019\u000F.\u000C(\u0005\u001D\u0018.\u0018(u000C, streamReader));
					\u001B\u001D\u0018.\u0018(streamReader);
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x00025C04 File Offset: 0x00023E04
		public static ExportTemPlateInfo DeserialiseTemplateInfo(string path)
		{
			ExportTemPlateInfo result;
			try
			{
				ExportTemPlateInfo exportTemPlateInfo = \u0018\u0019\u000F.\u000C;
				if (\u000C\u001A\u0018.\u0018(path))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(UtilityXML.DeserialiseTemplateInfo(string)).MethodHandle;
					}
					object u000C = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u0014\u0019\u000F.\u000C()));
					StreamReader streamReader = \u000E\u001D\u0018.\u0018(path);
					exportTemPlateInfo = \u0003\u0019\u000F.\u000C(\u0005\u001D\u0018.\u0018(u000C, streamReader));
					\u001B\u001D\u0018.\u0018(streamReader);
				}
				result = exportTemPlateInfo;
			}
			catch (Exception)
			{
				result = \u0018\u0019\u000F.\u000C;
			}
			return result;
		}

		// Token: 0x0400024F RID: 591
		[CompilerGenerated]
		private static Profiles \u000C;

		// Token: 0x04000250 RID: 592
		[CompilerGenerated]
		private static AutoRemember \u0018;
	}
}
