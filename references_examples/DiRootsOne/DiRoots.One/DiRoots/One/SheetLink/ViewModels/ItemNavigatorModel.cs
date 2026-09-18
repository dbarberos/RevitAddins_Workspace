using System;
using System.Collections.Generic;
using System.Linq;
using A;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.SheetLink.Enums;

namespace DiRoots.One.SheetLink.ViewModels
{
	// Token: 0x0200020B RID: 523
	public class ItemNavigatorModel : ViewModelBase
	{
		// Token: 0x06001360 RID: 4960 RVA: 0x0007B8B8 File Offset: 0x00079AB8
		internal static void EVR(MultiSelectComboBox F)
		{
			Dictionary<string, object> dictionary = \u0006\u0014\u0018.\u000A();
			\u001F\u0014\u0018.\u000A(dictionary, \u0002\u0014\u0018.\u000A(), "All");
			List<Disciplines>.Enumerator enumerator = \u000B\u0014\u0018.\u000A(Enumerable.ToList<Disciplines>(Enumerable.Cast<Disciplines>(\u000D\u0011\u001D.\u000A(\u001E\u0011\u000A.\u000A(\u0011\u000B\u000E.\u001F())))));
			try
			{
				while (\u0009\u0017\u0018.\u000A(ref enumerator))
				{
					Disciplines disciplines = \u0016\u0014\u0018.\u000A(ref enumerator);
					switch (disciplines)
					{
					case Disciplines.Architecture:
						\u001F\u0014\u0018.\u000A(dictionary, \u0005\u0014\u0018.\u000A(), (int)disciplines);
						break;
					case Disciplines.Structure:
						\u001F\u0014\u0018.\u000A(dictionary, \u0018\u0014\u0018.\u000A(), (int)disciplines);
						break;
					case Disciplines.Mechanical:
						\u001F\u0014\u0018.\u000A(dictionary, \u0019\u0014\u0018.\u000A(), (int)disciplines);
						break;
					case Disciplines.Electrical:
						\u001F\u0014\u0018.\u000A(dictionary, \u0004\u0014\u0018.\u000A(), (int)disciplines);
						break;
					case Disciplines.Piping:
						\u001F\u0014\u0018.\u000A(dictionary, \u001D\u0014\u0018.\u000A(), (int)disciplines);
						break;
					case Disciplines.Infrastructure:
						\u001F\u0014\u0018.\u000A(dictionary, \u0007\u0014\u0018.\u000A(), (int)disciplines);
						break;
					case Disciplines.General:
						\u001F\u0014\u0018.\u000A(dictionary, \u000A\u0014\u0018.\u000A(), (int)disciplines);
						break;
					}
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ItemNavigatorModel.EVR(MultiSelectComboBox)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u0001\u0017\u0018.\u000A(F, dictionary);
			Dictionary<string, object> u000A = \u0015\u0017\u0018.\u000A(dictionary);
			\u000C\u0017\u0018.\u000A(F, u000A);
		}
	}
}
