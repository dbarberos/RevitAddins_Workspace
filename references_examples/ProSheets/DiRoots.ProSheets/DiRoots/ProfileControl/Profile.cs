using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using A;

namespace DiRoots.ProfileControl
{
	// Token: 0x0200000B RID: 11
	[Serializable]
	public class Profile
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00003710 File Offset: 0x00001910
		// (set) Token: 0x06000036 RID: 54 RVA: 0x00003724 File Offset: 0x00001924
		public string Name { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00003738 File Offset: 0x00001938
		// (set) Token: 0x06000038 RID: 56 RVA: 0x0000374C File Offset: 0x0000194C
		public bool IsCurrent { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00003760 File Offset: 0x00001960
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00003774 File Offset: 0x00001974
		public bool IsPredefined { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00003788 File Offset: 0x00001988
		// (set) Token: 0x0600003C RID: 60 RVA: 0x0000379C File Offset: 0x0000199C
		public string FilePath { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600003D RID: 61 RVA: 0x000037B0 File Offset: 0x000019B0
		// (set) Token: 0x0600003E RID: 62 RVA: 0x000037C4 File Offset: 0x000019C4
		public ProfileTemplate CurrentProfileTemplate { get; set; }

		// Token: 0x0600003F RID: 63 RVA: 0x000037D8 File Offset: 0x000019D8
		public static void AddEmptyProfile(ObservableCollection<Profile> profiles)
		{
			Profile profile = \u001E\u001D\u0018.\u0018();
			\u0017\u001D\u0018.\u0018(profile, \u000D\u0009\u0018.\u0015\u0018);
			\u0015\u001D\u0018.\u0018(profile, true);
			\u0011\u001D\u0018.\u0018(profile, true);
			Profile u = profile;
			\u001F\u001D\u0018.\u0018(profiles, u);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003810 File Offset: 0x00001A10
		public static bool SerialiseProfiles(List<Profile> lstProfiles, string fileName, List<Type> knownTypes, bool showMessage = false)
		{
			string u = "";
			try
			{
				string u000C = \u0001\u001D\u0018.\u0018(fileName);
				u = \u0019\u001E\u0018.\u0018(u000C);
				XmlSerializer u000C2 = \u0016\u0002\u000F.\u000C;
				if (\u0008\u001D\u0018.\u0018(knownTypes) > 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Profile.SerialiseProfiles(List<Profile>, string, List<Type>, bool)).MethodHandle;
					}
					u000C2 = \u0010\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000D\u0002\u000F.\u000C()), \u0006\u001D\u0018.\u0018(knownTypes));
				}
				else
				{
					u000C2 = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000D\u0002\u000F.\u000C()));
				}
				XmlSerializerNamespaces xmlSerializerNamespaces = \u0019\u001D\u0018.\u0018();
				\u000B\u001D\u0018.\u0018(xmlSerializerNamespaces, "", "");
				TextWriter textWriter = \u001A\u001D\u0018.\u0018(u000C);
				try
				{
					\u001D\u001D\u0018.\u0018(u000C2, textWriter, lstProfiles, xmlSerializerNamespaces);
					\u0004\u001D\u0018.\u0018(textWriter);
				}
				finally
				{
					if (textWriter != null)
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
						\u0020\u001E\u0018.\u0018(textWriter);
					}
				}
				return true;
			}
			catch (UnauthorizedAccessException)
			{
				if (showMessage)
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
					\u0002\u001D\u0018.\u0018(\u001C\u001E\u0018.\u0018(\u000D\u0009\u0018.\u000E\u0018, u), 500.0);
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003938 File Offset: 0x00001B38
		public static List<Profile> DeserialiseProfiles(string fileName, List<Type> knownTypes)
		{
			List<Profile> result = \u0018\u001A\u0018.\u0018();
			try
			{
				string u000C = \u0001\u001D\u0018.\u0018(fileName);
				if (\u000C\u001A\u0018.\u0018(u000C))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Profile.DeserialiseProfiles(string, List<Type>)).MethodHandle;
					}
					XmlSerializer u000C2 = \u0016\u0002\u000F.\u000C;
					if (\u0008\u001D\u0018.\u0018(knownTypes) > 0)
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
						u000C2 = \u0010\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000D\u0002\u000F.\u000C()), \u0006\u001D\u0018.\u0018(knownTypes));
					}
					else
					{
						u000C2 = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000D\u0002\u000F.\u000C()));
					}
					StreamReader streamReader = \u000E\u001D\u0018.\u0018(u000C);
					result = \u001C\u0002\u000F.\u000C(\u0005\u001D\u0018.\u0018(u000C2, streamReader));
					\u001B\u001D\u0018.\u0018(streamReader);
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003A00 File Offset: 0x00001C00
		public static bool SerialiseProfile(Profile profile, string filePath, List<Type> knownTypes, bool showMessage = false)
		{
			try
			{
				XmlSerializer u000C = \u0016\u0002\u000F.\u000C;
				if (\u0008\u001D\u0018.\u0018(knownTypes) > 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Profile.SerialiseProfile(Profile, string, List<Type>, bool)).MethodHandle;
					}
					u000C = \u0010\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000F\u0002\u000F.\u000C()), \u0006\u001D\u0018.\u0018(knownTypes));
				}
				else
				{
					u000C = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000F\u0002\u000F.\u000C()));
				}
				XmlSerializerNamespaces xmlSerializerNamespaces = \u0019\u001D\u0018.\u0018();
				\u000B\u001D\u0018.\u0018(xmlSerializerNamespaces, "", "");
				TextWriter textWriter = \u001A\u001D\u0018.\u0018(filePath);
				try
				{
					\u001D\u001D\u0018.\u0018(u000C, textWriter, profile, xmlSerializerNamespaces);
					\u0004\u001D\u0018.\u0018(textWriter);
				}
				finally
				{
					if (textWriter != null)
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
						\u0020\u001E\u0018.\u0018(textWriter);
					}
				}
				return true;
			}
			catch (UnauthorizedAccessException)
			{
				if (showMessage)
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
					\u0002\u001D\u0018.\u0018(\u001C\u001E\u0018.\u0018(\u000D\u0009\u0018.\u000C\u0014, filePath), 380.0);
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003B10 File Offset: 0x00001D10
		public static Profile DeserialiseProfile(string filePath, List<Type> knownTypes)
		{
			Profile result = \u0003\u0002\u000F.\u000C;
			try
			{
				if (\u000C\u001A\u0018.\u0018(filePath))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Profile.DeserialiseProfile(string, List<Type>)).MethodHandle;
					}
					XmlSerializer u000C = \u0016\u0002\u000F.\u000C;
					if (\u0008\u001D\u0018.\u0018(knownTypes) > 0)
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
						u000C = \u0010\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000F\u0002\u000F.\u000C()), \u0006\u001D\u0018.\u0018(knownTypes));
					}
					else
					{
						u000C = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000F\u0002\u000F.\u000C()));
					}
					StreamReader streamReader = \u000E\u001D\u0018.\u0018(filePath);
					result = \u0012\u0002\u000F.\u000C(\u0005\u001D\u0018.\u0018(u000C, streamReader));
					\u001B\u001D\u0018.\u0018(streamReader);
				}
			}
			catch (UnauthorizedAccessException)
			{
				\u0014\u001A\u0018.\u0018(\u001C\u001E\u0018.\u0018(\u000D\u0009\u0018.\u0018\u0014, filePath));
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003BF0 File Offset: 0x00001DF0
		public static string GetProfilesFilePath(string fileName)
		{
			fileName = \u000D\u001E\u0018.\u0018(fileName, ".xml");
			return \u0003\u001A\u0018.\u0018(\u0016\u001A\u0018.\u0018(\u000F\u001A\u0018.\u0018()), fileName);
		}
	}
}
