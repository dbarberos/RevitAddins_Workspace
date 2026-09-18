using System;
using A;
using Autodesk.Revit.DB;

namespace ProSheets.Commons.Extensions
{
	// Token: 0x0200013D RID: 317
	public static class UnitExtensions
	{
		// Token: 0x06000FB0 RID: 4016 RVA: 0x00058A9C File Offset: 0x00056C9C
		public static double ConvertFromInternalUnits(this double value, ForgeTypeId unitTypeId)
		{
			return \u0004\u0004\u0018.\u0018(value, unitTypeId);
		}
	}
}
