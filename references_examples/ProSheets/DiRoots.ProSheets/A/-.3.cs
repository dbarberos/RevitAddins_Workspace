using System;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x02000055 RID: 85
	internal static class \u000A\u0009\u0018
	{
		// Token: 0x06000431 RID: 1073 RVA: 0x000166F4 File Offset: 0x000148F4
		public static string \u000C(this ViewType \u000C)
		{
			switch (\u000C)
			{
			case 1:
				return \u000D\u0009\u0018.\u0002;
			case 2:
				return \u000D\u0009\u0018.\u001A;
			case 3:
				return \u000D\u0009\u0018.\u000B;
			case 4:
				return \u000D\u0009\u0018.\u001E;
			case 5:
				return \u000D\u0009\u0018.\u0010;
			case 6:
				return \u000D\u0009\u0018.\u0008;
			case 7:
			case 9:
				break;
			case 8:
				return \u000D\u0009\u0018.\u001B;
			case 10:
				return \u000D\u0009\u0018.\u0006;
			case 11:
				return \u000D\u0009\u0018.\u0001;
			default:
				switch (\u000C)
				{
				case 115:
					return \u000D\u0009\u0018.\u0004;
				case 116:
					return \u000D\u0009\u0018.\u001D;
				case 117:
					return \u000D\u0009\u0018.\u0019;
				case 118:
					return \u000D\u0009\u0018.\u0007;
				case 119:
					return \u000D\u0009\u0018.\u0005;
				case 120:
					return \u000D\u0009\u0018.\u000E;
				case 121:
					return \u000D\u0009\u0018.\u000C\u0018;
				case 122:
					return \u000D\u0009\u0018.\u0014\u0018;
				case 123:
					return \u000D\u0009\u0018.\u0018\u0018;
				case 124:
					return \u000D\u0009\u0018.\u0003\u0018;
				case 125:
					return \u000D\u0009\u0018.\u0016\u0018;
				case 126:
					return \u000D\u0009\u0018.\u000F\u0018;
				}
				break;
			}
			return \u000C.ToString().\u000C();
		}
	}
}
