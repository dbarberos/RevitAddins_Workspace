using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.IFC;

namespace A
{
	// Token: 0x020000E4 RID: 228
	internal static class \u000E\u001F\u0018
	{
		// Token: 0x06000B9D RID: 2973 RVA: 0x00046F58 File Offset: 0x00045158
		public unsafe static void \u000C(string \u000C, out string \u0018, out IFCFileFormat \u0014)
		{
			if (\u000F\u0002\u0018.\u0018(\u000C, "IfcXML"))
			{
				\u0018 = ".ifcxml";
				\u0014 = 1;
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u001F\u0018.\u000C(string, string*, IFCFileFormat*)).MethodHandle;
			}
			if (\u000F\u0002\u0018.\u0018(\u000C, "IfcZIP"))
			{
				\u0018 = ".ifczip";
				\u0014 = 2;
				return;
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
			if (!\u000F\u0002\u0018.\u0018(\u000C, "IfcXMLZIP"))
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
				\u0018 = ".ifc";
				\u0014 = 0;
				return;
			}
			\u0018 = ".ifczip";
			\u0014 = 3;
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x00046FE8 File Offset: 0x000451E8
		public static string \u0018(string \u000C)
		{
			if (\u000F\u0002\u0018.\u0018(\u000C, "1st Level"))
			{
				return "1";
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u001F\u0018.\u0018(string)).MethodHandle;
			}
			if (!\u000F\u0002\u0018.\u0018(\u000C, "2nd Level"))
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
				return "0";
			}
			return "2";
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x00047044 File Offset: 0x00045244
		public static string \u0014(string \u000C)
		{
			if (\u000F\u0002\u0018.\u0018(\u000C, "Site Survey Point"))
			{
				return "Site";
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u001F\u0018.\u0014(string)).MethodHandle;
			}
			if (\u000F\u0002\u0018.\u0018(\u000C, "Project Base Point"))
			{
				return "Project";
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
			if (\u000F\u0002\u0018.\u0018(\u000C, "Internal Coordinates"))
			{
				return "Internal";
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
			if (\u000F\u0002\u0018.\u0018(\u000C, "Project Base Point oriented in True North"))
			{
				return "ProjectInTN";
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
			if (!\u000F\u0002\u0018.\u0018(\u000C, "Internal Origin oriented in True North"))
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
				return "Shared";
			}
			return "InternalInTN";
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x00047100 File Offset: 0x00045300
		public static bool \u0003(ElementId \u000C)
		{
			return \u000D\u0015\u0016.\u0018(\u0013\u001F\u0014.\u0018(\u000C));
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x0004711C File Offset: 0x0004531C
		public static double \u0016(string \u000C)
		{
			double result = 0.5;
			if (\u000F\u0002\u0018.\u0018(\u000C, "Extra Low"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u001F\u0018.\u0016(string)).MethodHandle;
				}
				result = 0.25;
			}
			else if (\u000F\u0002\u0018.\u0018(\u000C, "Low"))
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
				result = 0.5;
			}
			else if (\u000F\u0002\u0018.\u0018(\u000C, "Medium"))
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
				result = 0.75;
			}
			else if (\u000F\u0002\u0018.\u0018(\u000C, "High"))
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
				result = 1.0;
			}
			return result;
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x000471D0 File Offset: 0x000453D0
		public static string \u000F(double \u000C)
		{
			string result = "Low";
			if (\u000C == 0.25)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u001F\u0018.\u000F(double)).MethodHandle;
				}
				result = "Extra Low";
			}
			else if (\u000C == 0.5)
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
				result = "Low";
			}
			else if (\u000C == 0.75)
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
				result = "Medium";
			}
			else if (\u000C == 1.0)
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
				result = "High";
			}
			return result;
		}
	}
}
