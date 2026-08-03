using System;
using System.Collections;
using System.Reflection;
using DiRoots.One.ViewRange;
using DiRoots.One.ViewRange.Model;

namespace A
{
	// Token: 0x020002DC RID: 732
	internal class \u0012\u0011 : IComparer
	{
		// Token: 0x06001E3B RID: 7739 RVA: 0x000BF030 File Offset: 0x000BD230
		public \u0012\u0011(string \u001F, bool \u000A)
		{
			this.\u001F = \u000A;
			this.\u000A = \u001F;
		}

		// Token: 0x06001E3C RID: 7740 RVA: 0x000BF054 File Offset: 0x000BD254
		public int Compare(object x, object y)
		{
			string u001F = this.\u0007(\u0003\u000D\u000E.\u001F(x));
			string u000A = this.\u0007(\u0003\u000D\u000E.\u001F(y));
			int num;
			if (!this.\u001F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u0011.Compare(object, object)).MethodHandle;
				}
				num = -1;
			}
			else
			{
				num = 1;
			}
			return num * \u000C\u0016\u001D.\u000A(u001F, u000A);
		}

		// Token: 0x06001E3D RID: 7741 RVA: 0x000BF0AC File Offset: 0x000BD2AC
		private string \u0007(ViewInformation \u001F)
		{
			object u000A = this.\u000A;
			char[] array = \u001C\u0007\u000E.\u001F(1);
			array[0] = '.';
			string[] array2 = \u0009\u0007\u001D.\u000A(u000A, array);
			PropertyInfo propertyInfo = \u0017\u001A\u0016.\u000A(\u0003\u0011\u000A.\u0007(\u001F), array2[0]);
			object obj;
			if (propertyInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u0011.\u0007(ViewInformation)).MethodHandle;
				}
				obj = \u0019\u001D\u000E.\u001F;
			}
			else
			{
				obj = \u000B\u000E\u0019.\u0007(propertyInfo, \u001F);
			}
			object obj2 = obj;
			ElevationInfo elevationInfo = \u000F\u000D\u000E.\u001F(obj2);
			if (elevationInfo != null)
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
				PropertyInfo propertyInfo2 = \u0017\u001A\u0016.\u000A(\u0003\u0011\u000A.\u0007(elevationInfo), array2[1]);
				object obj3;
				if (propertyInfo2 == null)
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
					obj3 = \u0019\u001D\u000E.\u001F;
				}
				else
				{
					obj3 = \u000B\u000E\u0019.\u0007(propertyInfo2, elevationInfo);
				}
				obj2 = obj3;
				LevelInfo levelInfo = \u0012\u000D\u000E.\u001F(obj2);
				if (levelInfo != null)
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
					return \u001D\u001F\u0016.\u000A(levelInfo);
				}
			}
			string text;
			if (obj2 == null)
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
				text = null;
			}
			else
			{
				text = \u001A\u000C\u000A.\u000A(obj2);
			}
			string result;
			if ((result = text) == null)
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
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x04000C70 RID: 3184
		private readonly bool \u001F;

		// Token: 0x04000C71 RID: 3185
		private readonly string \u000A;
	}
}
