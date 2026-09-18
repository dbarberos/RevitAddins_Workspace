using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using A;
using ProSheets.Models;

namespace DiRoots.ProSheets.UI
{
	// Token: 0x0200003A RID: 58
	public class GroupToBoolConvertor : IValueConverter
	{
		// Token: 0x0600027D RID: 637 RVA: 0x0000DF44 File Offset: 0x0000C144
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			ReadOnlyObservableCollection<object> readOnlyObservableCollection = \u0011\u001D\u000F.\u000C(value);
			if (readOnlyObservableCollection == null)
			{
				return true;
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(GroupToBoolConvertor.Convert(object, Type, object, CultureInfo)).MethodHandle;
			}
			if (!Enumerable.Any<object>(readOnlyObservableCollection))
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
			List<SheetInfo> list = Enumerable.ToList<SheetInfo>(Enumerable.OfType<SheetInfo>(readOnlyObservableCollection));
			if (Enumerable.Any<SheetInfo>(list))
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
				object u000C = list;
				Predicate<SheetInfo> u;
				if ((u = GroupToBoolConvertor.<>c.\u0018) == null)
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
					u = (GroupToBoolConvertor.<>c.\u0018 = new Predicate<SheetInfo>(GroupToBoolConvertor.<>c.\u000C.\u0012));
				}
				bool flag = \u0010\u000F\u0014.\u0018(u000C, u);
				if (!flag)
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
					object u000C2 = list;
					Predicate<SheetInfo> u2;
					if ((u2 = GroupToBoolConvertor.<>c.\u0014) == null)
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
						u2 = (GroupToBoolConvertor.<>c.\u0014 = new Predicate<SheetInfo>(GroupToBoolConvertor.<>c.\u000C.\u000D));
					}
					if (\u0007\u000F\u0014.\u0018(u000C2, u2))
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
						return null;
					}
				}
				return flag;
			}
			List<CollectionViewGroup> p = Enumerable.ToList<CollectionViewGroup>(Enumerable.OfType<CollectionViewGroup>(readOnlyObservableCollection));
			return this.P(p);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000E060 File Offset: 0x0000C260
		private bool? P(List<CollectionViewGroup> P)
		{
			bool? result;
			\u000B\u0004\u000F.\u000C(ref result);
			Func<CollectionViewGroup, ReadOnlyObservableCollection<object>> func;
			if ((func = GroupToBoolConvertor.<>c.\u0003) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(GroupToBoolConvertor.P(List<CollectionViewGroup>)).MethodHandle;
				}
				func = (GroupToBoolConvertor.<>c.\u0003 = new Func<CollectionViewGroup, ReadOnlyObservableCollection<object>>(GroupToBoolConvertor.<>c.\u000C.\u001C));
			}
			IEnumerator<ReadOnlyObservableCollection<object>> enumerator = \u0008\u000F\u0014.\u0018(Enumerable.Select<CollectionViewGroup, ReadOnlyObservableCollection<object>>(P, func));
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator))
				{
					ReadOnlyObservableCollection<object> readOnlyObservableCollection = \u0006\u000F\u0014.\u0018(enumerator);
					List<SheetInfo> list = Enumerable.ToList<SheetInfo>(Enumerable.OfType<SheetInfo>(readOnlyObservableCollection));
					if (Enumerable.Any<SheetInfo>(list))
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
						object u000C = list;
						Predicate<SheetInfo> u;
						if ((u = GroupToBoolConvertor.<>c.\u0016) == null)
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
							u = (GroupToBoolConvertor.<>c.\u0016 = new Predicate<SheetInfo>(GroupToBoolConvertor.<>c.\u000C.\u0013));
						}
						bool flag = \u0010\u000F\u0014.\u0018(u000C, u);
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
							object u000C2 = list;
							Predicate<SheetInfo> u2;
							if ((u2 = GroupToBoolConvertor.<>c.\u000F) == null)
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
								u2 = (GroupToBoolConvertor.<>c.\u000F = new Predicate<SheetInfo>(GroupToBoolConvertor.<>c.\u000C.\u0009));
							}
							if (\u0007\u000F\u0014.\u0018(u000C2, u2))
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
								\u000B\u0004\u000F.\u000C(ref result);
								continue;
							}
						}
						result = new bool?(flag);
					}
					else
					{
						result = this.P(Enumerable.ToList<CollectionViewGroup>(Enumerable.Cast<CollectionViewGroup>(readOnlyObservableCollection)));
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
			return result;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000E1D4 File Offset: 0x0000C3D4
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw \u0020\u0006\u0018.\u0018();
		}
	}
}
