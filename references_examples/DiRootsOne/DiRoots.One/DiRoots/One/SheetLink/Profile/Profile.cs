using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using A;

namespace DiRoots.One.SheetLink.Profile
{
	// Token: 0x02000236 RID: 566
	[Serializable]
	public class Profile
	{
		// Token: 0x1700060D RID: 1549
		// (get) Token: 0x06001642 RID: 5698 RVA: 0x00092374 File Offset: 0x00090574
		// (set) Token: 0x06001643 RID: 5699 RVA: 0x00092388 File Offset: 0x00090588
		public string Name { get; set; }

		// Token: 0x1700060E RID: 1550
		// (get) Token: 0x06001644 RID: 5700 RVA: 0x0009239C File Offset: 0x0009059C
		// (set) Token: 0x06001645 RID: 5701 RVA: 0x000923B0 File Offset: 0x000905B0
		public bool IsCurrent { get; set; }

		// Token: 0x1700060F RID: 1551
		// (get) Token: 0x06001646 RID: 5702 RVA: 0x000923C4 File Offset: 0x000905C4
		// (set) Token: 0x06001647 RID: 5703 RVA: 0x000923D8 File Offset: 0x000905D8
		public bool IsPredefined { get; set; }

		// Token: 0x17000610 RID: 1552
		// (get) Token: 0x06001648 RID: 5704 RVA: 0x000923EC File Offset: 0x000905EC
		// (set) Token: 0x06001649 RID: 5705 RVA: 0x00092400 File Offset: 0x00090600
		public string FilePath { get; set; }

		// Token: 0x17000611 RID: 1553
		// (get) Token: 0x0600164A RID: 5706 RVA: 0x00092414 File Offset: 0x00090614
		// (set) Token: 0x0600164B RID: 5707 RVA: 0x00092428 File Offset: 0x00090628
		public ProfileTemplate CurrentProfileTemplate { get; set; }

		// Token: 0x0600164C RID: 5708 RVA: 0x0009243C File Offset: 0x0009063C
		internal static void \u001F(ObservableCollection<Profile> \u001F)
		{
			Profile profile = \u0009\u0006\u0005.\u000A();
			\u0015\u0006\u0005.\u000A(profile, \u0012\u000F\u0005.\u000A());
			\u000F\u000F\u0005.\u000A(profile, true);
			\u0006\u000F\u0005.\u000A(profile, true);
			\u0002\u000F\u0005.\u000A(\u001F, profile);
		}

		// Token: 0x0600164D RID: 5709 RVA: 0x00092474 File Offset: 0x00090674
		internal static bool \u000A(List<Profile> \u001F, string \u000A, bool \u0007 = false)
		{
			try
			{
				string u001F = Profile.\u0019(\u000A);
				\u0019\u000E\u0004.\u000A(u001F);
				XmlSerializer u001F2 = \u0008\u001A\u0004.\u000A(\u001E\u0011\u000A.\u000A(\u0007\u0012\u000E.\u001F()));
				XmlSerializerNamespaces xmlSerializerNamespaces = \u0010\u000F\u0005.\u000A();
				\u000D\u000F\u0005.\u000A(xmlSerializerNamespaces, "", "");
				TextWriter textWriter = \u0011\u0017\u0018.\u000A(u001F);
				try
				{
					\u001C\u000F\u0005.\u000A(u001F2, textWriter, \u001F, xmlSerializerNamespaces);
					\u0008\u0017\u0018.\u000A(textWriter);
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(Profile.\u000A(List<Profile>, string, bool)).MethodHandle;
						}
						\u001F\u0017\u000A.\u000A(textWriter);
					}
				}
				return true;
			}
			catch (UnauthorizedAccessException)
			{
				if (\u0007)
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
					\u0005\u0013\u000A.\u000A(\u0003\u000F\u0005.\u000A(), 500.0);
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Profile\\Profile.cs", "SerialiseProfiles");
			}
			return false;
		}

		// Token: 0x0600164E RID: 5710 RVA: 0x0009256C File Offset: 0x0009076C
		internal static List<Profile> \u0007(string \u001F)
		{
			List<Profile> result = \u0008\u000F\u0005.\u000A();
			try
			{
				string u001F = Profile.\u0019(\u001F);
				if (\u0010\u0002\u001D.\u000A(u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Profile.\u0007(string)).MethodHandle;
					}
					object u001F2 = \u0008\u001A\u0004.\u000A(\u001E\u0011\u000A.\u000A(\u0007\u0012\u000E.\u001F()));
					StreamReader streamReader = \u0017\u0017\u0018.\u000A(u001F);
					result = \u001D\u0012\u000E.\u001F(\u001A\u001A\u0004.\u000A(u001F2, streamReader));
					\u000E\u000F\u0005.\u000A(streamReader);
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Profile\\Profile.cs", "DeserialiseProfiles");
			}
			return result;
		}

		// Token: 0x0600164F RID: 5711 RVA: 0x00092608 File Offset: 0x00090808
		internal static bool \u001D(Profile \u001F, string \u000A, bool \u0007 = false)
		{
			try
			{
				XmlSerializer u001F = \u0008\u001A\u0004.\u000A(\u001E\u0011\u000A.\u000A(\u001F\u0012\u000E.\u001F()));
				XmlSerializerNamespaces xmlSerializerNamespaces = \u0010\u000F\u0005.\u000A();
				\u000D\u000F\u0005.\u000A(xmlSerializerNamespaces, "", "");
				TextWriter textWriter = \u0011\u0017\u0018.\u000A(\u000A);
				try
				{
					\u001C\u000F\u0005.\u000A(u001F, textWriter, \u001F, xmlSerializerNamespaces);
					\u0008\u0017\u0018.\u000A(textWriter);
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
						if (!true)
						{
							RuntimeMethodHandle runtimeMethodHandle = methodof(Profile.\u001D(Profile, string, bool)).MethodHandle;
						}
						\u001F\u0017\u000A.\u000A(textWriter);
					}
				}
				return true;
			}
			catch (UnauthorizedAccessException)
			{
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
					\u0005\u0013\u000A.\u000A(\u0017\u0006\u0007.\u000A(\u001B\u000F\u0005.\u000A(), \u000A), 380.0);
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Profile\\Profile.cs", "SerialiseProfile");
			}
			return false;
		}

		// Token: 0x06001650 RID: 5712 RVA: 0x000926F4 File Offset: 0x000908F4
		internal static Profile \u0004(string \u001F)
		{
			Profile result = \u0009\u000F\u000E.\u001F;
			try
			{
				if (\u0010\u0002\u001D.\u000A(\u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Profile.\u0004(string)).MethodHandle;
					}
					object u001F = \u0008\u001A\u0004.\u000A(\u001E\u0011\u000A.\u000A(\u001F\u0012\u000E.\u001F()));
					StreamReader streamReader = \u0017\u0017\u0018.\u000A(\u001F);
					result = \u000A\u0012\u000E.\u001F(\u001A\u001A\u0004.\u000A(u001F, streamReader));
					\u000E\u000F\u0005.\u000A(streamReader);
				}
			}
			catch (UnauthorizedAccessException)
			{
				\u0008\u0011\u001D.\u000A(\u0017\u0006\u0007.\u000A(\u0011\u000F\u0005.\u000A(), \u001F));
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Profile\\Profile.cs", "DeserialiseProfile");
			}
			return result;
		}

		// Token: 0x06001651 RID: 5713 RVA: 0x000927AC File Offset: 0x000909AC
		internal static string \u0019(string \u001F)
		{
			string u000A = \u0020\u000F\u0005.\u000A(\u001A\u000E\u0019.\u000A());
			if (!\u0008\u0013\u000A.\u000A(\u001F, "Model"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Profile.\u0019(string)).MethodHandle;
				}
				if (!\u0008\u0013\u000A.\u000A(\u001F, "Annotation"))
				{
					goto IL_50;
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
			u000A = "80FB23B6-0F9F-4A99-9E01-A3BD39A6264A";
			IL_50:
			string u001F = \u001B\u0015\u001D.\u000A(\u001E\u000F\u0005.\u000A().\u0010, u000A);
			if (!\u001A\u0006\u0007.\u000A(\u001F))
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
				u001F = \u0002\u0013\u000A.\u000A(u001F, "_", \u001F);
			}
			return \u0004\u001E\u000A.\u000A(u001F, ".xml");
		}
	}
}
