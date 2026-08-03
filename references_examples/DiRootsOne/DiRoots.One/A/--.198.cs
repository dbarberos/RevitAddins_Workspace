using System;
using System.Collections.Generic;
using System.Linq;

namespace A
{
	// Token: 0x020003BF RID: 959
	internal class \u0015\u0014 : IComparer<string>
	{
		// Token: 0x06002609 RID: 9737 RVA: 0x000E4B58 File Offset: 0x000E2D58
		public int Compare(string x, string y)
		{
			double num;
			bool flag = \u0013\u000C\u000A.\u000A(x, ref num);
			double u000A;
			bool flag2 = \u0013\u000C\u000A.\u000A(y, ref u000A);
			if (flag && flag2)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0014.Compare(string, string)).MethodHandle;
				}
				return \u0003\u0014\u0007.\u000A(ref num, u000A);
			}
			IEnumerable<string> enumerable = \u0006\u000C\u001D.\u000A(x, "\\d+");
			string[] array = \u0006\u000C\u001D.\u000A(y, "\\d+");
			string[] array2 = \u0006\u000C\u001D.\u000A(x, "\\D+");
			string[] array3 = \u0006\u000C\u001D.\u000A(y, "\\D+");
			Func<string, bool> func;
			if ((func = \u0015\u0014.<>c.\u000A) == null)
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
				func = (\u0015\u0014.<>c.\u000A = new Func<string, bool>(\u0015\u0014.<>c.\u001F.\u0019));
			}
			string text = Enumerable.FirstOrDefault<string>(enumerable, func);
			IEnumerable<string> enumerable2 = array;
			Func<string, bool> func2;
			if ((func2 = \u0015\u0014.<>c.\u0007) == null)
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
				func2 = (\u0015\u0014.<>c.\u0007 = new Func<string, bool>(\u0015\u0014.<>c.\u001F.\u0018));
			}
			string text2 = Enumerable.FirstOrDefault<string>(enumerable2, func2);
			string u001F;
			if (text == null)
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
				u001F = null;
			}
			else
			{
				u001F = \u0018\u0006\u001D.\u001D(text);
			}
			string u000A2;
			if (text2 == null)
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
				u000A2 = \u000F\u0015\u0010.\u001F;
			}
			else
			{
				u000A2 = \u0018\u0006\u001D.\u001D(text2);
			}
			if (\u001D\u0017\u000A.\u000A(u001F, u000A2))
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
				return \u0013\u001F\u001D.\u000A(x, y);
			}
			IEnumerable<string> enumerable3 = array2;
			Func<string, bool> func3;
			if ((func3 = \u0015\u0014.<>c.\u001D) == null)
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
				func3 = (\u0015\u0014.<>c.\u001D = new Func<string, bool>(\u0015\u0014.<>c.\u001F.\u0005));
			}
			double num2;
			bool flag3 = \u0013\u000C\u000A.\u000A(Enumerable.FirstOrDefault<string>(enumerable3, func3), ref num2);
			IEnumerable<string> enumerable4 = array3;
			Func<string, bool> func4;
			if ((func4 = \u0015\u0014.<>c.\u0004) == null)
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
				func4 = (\u0015\u0014.<>c.\u0004 = new Func<string, bool>(\u0015\u0014.<>c.\u001F.\u0016));
			}
			double u000A3;
			bool flag4 = \u0013\u000C\u000A.\u000A(Enumerable.FirstOrDefault<string>(enumerable4, func4), ref u000A3);
			if (flag3 && flag4)
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
				return \u0003\u0014\u0007.\u000A(ref num2, u000A3);
			}
			return \u0013\u001F\u001D.\u000A(x, y);
		}
	}
}
