using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.SheetLink.Models;

namespace DiRoots.One.SheetLink.ViewModels
{
	// Token: 0x02000214 RID: 532
	public class ParameterBaseModel<T> : ViewModelBase where T : BaseParameter
	{
		// Token: 0x06001407 RID: 5127 RVA: 0x00081530 File Offset: 0x0007F730
		public ParameterBaseModel(List<T> availableItems, List<T> selectedItems)
		{
			this.KW = new ObservableCollection<T>(selectedItems);
			this.WW = new ObservableCollection<T>(availableItems);
		}

		// Token: 0x170005B0 RID: 1456
		// (get) Token: 0x06001408 RID: 5128 RVA: 0x00081564 File Offset: 0x0007F764
		// (set) Token: 0x06001409 RID: 5129 RVA: 0x00081578 File Offset: 0x0007F778
		public ParameterBaseModel<T>.CollectionChangedDelegate CollectionChangedHandler { get; set; }

		// Token: 0x170005B1 RID: 1457
		// (get) Token: 0x0600140A RID: 5130 RVA: 0x0008158C File Offset: 0x0007F78C
		// (set) Token: 0x0600140B RID: 5131 RVA: 0x000815A0 File Offset: 0x0007F7A0
		public ObservableCollection<T> AvailableParams
		{
			get
			{
				return this.WW;
			}
			set
			{
				this.WW = value;
				this.OnPropertyChanged<ObservableCollection<T>>(new Func<ObservableCollection<T>>(this.VZR), "AvailableParams");
				if (this.AddSortDescription)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.set_AvailableParams(ObservableCollection<T>)).MethodHandle;
					}
					this.YZR();
				}
			}
		}

		// Token: 0x170005B2 RID: 1458
		// (get) Token: 0x0600140C RID: 5132 RVA: 0x000815F0 File Offset: 0x0007F7F0
		// (set) Token: 0x0600140D RID: 5133 RVA: 0x00081604 File Offset: 0x0007F804
		public ObservableCollection<T> UsedParams
		{
			get
			{
				return this.KW;
			}
			set
			{
				this.KW = value;
				this.OnPropertyChanged<ObservableCollection<T>>(new Func<ObservableCollection<T>>(this.ZZR), "UsedParams");
			}
		}

		// Token: 0x170005B3 RID: 1459
		// (get) Token: 0x0600140E RID: 5134 RVA: 0x00081630 File Offset: 0x0007F830
		public List<T> UsedFilterdParams
		{
			get
			{
				ObservableCollection<T> usedParams = this.UsedParams;
				if (usedParams == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.get_UsedFilterdParams()).MethodHandle;
					}
					return null;
				}
				Func<T, bool> func;
				if ((func = ParameterBaseModel<T>.<>c.\u000A) == null)
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
					func = (ParameterBaseModel<T>.<>c.\u000A = new Func<T, bool>(ParameterBaseModel<T>.<>c.\u001F.\u001D));
				}
				return Enumerable.ToList<T>(Enumerable.Where<T>(usedParams, func));
			}
		}

		// Token: 0x170005B4 RID: 1460
		// (get) Token: 0x0600140F RID: 5135 RVA: 0x00081698 File Offset: 0x0007F898
		// (set) Token: 0x06001410 RID: 5136 RVA: 0x000816AC File Offset: 0x0007F8AC
		public IList<T> SelectedUsedParams
		{
			get
			{
				return this.JW;
			}
			set
			{
				this.JW = value;
				this.OnPropertyChanged<IList<T>>(new Func<IList<T>>(this.XZR), "SelectedUsedParams");
			}
		}

		// Token: 0x170005B5 RID: 1461
		// (get) Token: 0x06001411 RID: 5137 RVA: 0x000816D8 File Offset: 0x0007F8D8
		// (set) Token: 0x06001412 RID: 5138 RVA: 0x000816EC File Offset: 0x0007F8EC
		public IList<T> SelectedAvailableParams
		{
			get
			{
				return this.EW;
			}
			set
			{
				this.EW = value;
				this.OnPropertyChanged<IList<T>>(new Func<IList<T>>(this.PZR), "SelectedAvailableParams");
			}
		}

		// Token: 0x170005B6 RID: 1462
		// (get) Token: 0x06001413 RID: 5139 RVA: 0x00081718 File Offset: 0x0007F918
		// (set) Token: 0x06001414 RID: 5140 RVA: 0x0008172C File Offset: 0x0007F92C
		public bool AddSortDescription { get; set; } = true;

		// Token: 0x170005B7 RID: 1463
		// (get) Token: 0x06001415 RID: 5141 RVA: 0x00081740 File Offset: 0x0007F940
		public CommandBase<ListView> DoubleClickCommand
		{
			get
			{
				return \u001E\u0001\u0018.\u000A(new Action<ListView>(this.KZR), \u0012\u0002\u000E.\u001F);
			}
		}

		// Token: 0x170005B8 RID: 1464
		// (get) Token: 0x06001416 RID: 5142 RVA: 0x00081768 File Offset: 0x0007F968
		public CommandBase AvailableToUsedCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.SZR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005B9 RID: 1465
		// (get) Token: 0x06001417 RID: 5143 RVA: 0x00081790 File Offset: 0x0007F990
		public CommandBase AvailableDoubleClickCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.WZR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005BA RID: 1466
		// (get) Token: 0x06001418 RID: 5144 RVA: 0x000817B8 File Offset: 0x0007F9B8
		public CommandBase UsedDoubleClickCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.UZR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005BB RID: 1467
		// (get) Token: 0x06001419 RID: 5145 RVA: 0x000817E0 File Offset: 0x0007F9E0
		public CommandBase UsedToAvailableCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.LZR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005BC RID: 1468
		// (get) Token: 0x0600141A RID: 5146 RVA: 0x00081808 File Offset: 0x0007FA08
		public CommandBase MoveToBeginningCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.JZR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005BD RID: 1469
		// (get) Token: 0x0600141B RID: 5147 RVA: 0x00081830 File Offset: 0x0007FA30
		public CommandBase MoveUpCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.EZR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005BE RID: 1470
		// (get) Token: 0x0600141C RID: 5148 RVA: 0x00081858 File Offset: 0x0007FA58
		public CommandBase MoveDownCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.NZR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005BF RID: 1471
		// (get) Token: 0x0600141D RID: 5149 RVA: 0x00081880 File Offset: 0x0007FA80
		public CommandBase MoveToEndCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.MZR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005C0 RID: 1472
		// (get) Token: 0x0600141E RID: 5150 RVA: 0x000818A8 File Offset: 0x0007FAA8
		public CommandBase<Window> ApplyCommand
		{
			get
			{
				return \u0007\u0009\u0004.\u000A(new Action<Window>(this.Apply), \u0003\u0018\u000E.\u001F);
			}
		}

		// Token: 0x170005C1 RID: 1473
		// (get) Token: 0x0600141F RID: 5151 RVA: 0x000818D0 File Offset: 0x0007FAD0
		public CommandBase ReloadCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.CZR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x06001420 RID: 5152 RVA: 0x000818F8 File Offset: 0x0007FAF8
		private void YZR()
		{
			\u0017\u001A\u0019.\u000A(\u0014\u001A\u0019.\u000A(\u0011\u0009\u000A.\u000A(this.AvailableParams)), new SortDescription("Name", ListSortDirection.Ascending));
		}

		// Token: 0x06001421 RID: 5153 RVA: 0x0008192C File Offset: 0x0007FB2C
		private void CZR()
		{
			IEnumerator<T> enumerator = this.UsedParams.GetEnumerator();
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					T item = enumerator.Current;
					this.AvailableParams.Add(item);
				}
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.CZR()).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			this.UsedParams.Clear();
			IEnumerable<T> availableParams = this.AvailableParams;
			Func<T, string> func;
			if ((func = ParameterBaseModel<T>.<>c.\u0007) == null)
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
				func = (ParameterBaseModel<T>.<>c.\u0007 = new Func<T, string>(ParameterBaseModel<T>.<>c.\u001F.\u0004));
			}
			List<T> list = Enumerable.ToList<T>(Enumerable.OrderBy<T, string>(availableParams, func));
			this.AvailableParams = new ObservableCollection<T>(list);
			ParameterBaseModel<T>.CollectionChangedDelegate collectionChangedHandler = this.CollectionChangedHandler;
			if (collectionChangedHandler == null)
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
				return;
			}
			collectionChangedHandler();
		}

		// Token: 0x06001422 RID: 5154 RVA: 0x00081A1C File Offset: 0x0007FC1C
		public void Reset()
		{
			this.AvailableParams.Clear();
			ObservableCollection<T> usedParams = this.UsedParams;
			if (usedParams == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.Reset()).MethodHandle;
				}
				return;
			}
			usedParams.Clear();
		}

		// Token: 0x06001423 RID: 5155 RVA: 0x00081A5C File Offset: 0x0007FC5C
		private void LZR()
		{
			if (this.SelectedUsedParams != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.LZR()).MethodHandle;
				}
				ParameterBaseModel<T>.\u0006\u0003 u0006_u = new ParameterBaseModel<T>.\u0006\u0003();
				u0006_u.\u001F = Enumerable.ToList<T>(this.SelectedUsedParams);
				List<T> list = Enumerable.ToList<T>(this.AvailableParams);
				list.AddRange(u0006_u.\u001F);
				this.BZR(list);
				List<T> list2 = Enumerable.ToList<T>(this.UsedParams);
				list2.RemoveAll(new Predicate<T>(u0006_u.\u000A));
				this.UsedParams = new ObservableCollection<T>(list2);
			}
			ParameterBaseModel<T>.CollectionChangedDelegate collectionChangedHandler = this.CollectionChangedHandler;
			if (collectionChangedHandler == null)
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
				return;
			}
			collectionChangedHandler();
		}

		// Token: 0x06001424 RID: 5156 RVA: 0x00081B14 File Offset: 0x0007FD14
		private void SZR()
		{
			if (this.SelectedAvailableParams != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.SZR()).MethodHandle;
				}
				ParameterBaseModel<T>.\u000F\u0003 u000F_u = new ParameterBaseModel<T>.\u000F\u0003();
				u000F_u.\u001F = Enumerable.ToList<T>(this.SelectedAvailableParams);
				List<T> list = Enumerable.ToList<T>(Enumerable.Cast<T>(\u000F\u0009\u0010.\u001F(\u0011\u0009\u000A.\u000A(this.AvailableParams))));
				u000F_u.\u001F = Enumerable.ToList<T>(Enumerable.Where<T>(list, new Func<T, bool>(u000F_u.\u000A)));
				List<T> list2 = Enumerable.ToList<T>(this.UsedParams);
				list2.AddRange(u000F_u.\u001F);
				this.UsedParams = new ObservableCollection<T>(list2);
				List<T> list3 = Enumerable.ToList<T>(this.AvailableParams);
				list3.RemoveAll(new Predicate<T>(u000F_u.\u0007));
				this.BZR(list3);
			}
			ParameterBaseModel<T>.CollectionChangedDelegate collectionChangedHandler = this.CollectionChangedHandler;
			if (collectionChangedHandler == null)
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
				return;
			}
			collectionChangedHandler();
		}

		// Token: 0x06001425 RID: 5157 RVA: 0x00081C14 File Offset: 0x0007FE14
		private void BZR(List<T> F)
		{
			ICollectionView u001F = \u0011\u0009\u000A.\u000A(this.AvailableParams);
			object u001F2 = \u0014\u001A\u0019.\u000A(u001F);
			this.AvailableParams = new ObservableCollection<T>(F);
			u001F = \u0011\u0009\u000A.\u000A(this.AvailableParams);
			\u0013\u001A\u0019.\u000A(\u0014\u001A\u0019.\u000A(u001F));
			IEnumerator<SortDescription> enumerator = \u0013\u0001\u0018.\u000A(u001F2);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					SortDescription sortDescription = \u0014\u0001\u0018.\u000A(enumerator);
					\u0017\u001A\u0019.\u000A(\u0014\u001A\u0019.\u000A(u001F), new SortDescription(\u0017\u0001\u0018.\u000A(ref sortDescription), \u0020\u0001\u0018.\u000A(ref sortDescription)));
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.BZR(List<T>)).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			\u0014\u0003\u0007.\u000A(u001F);
		}

		// Token: 0x06001426 RID: 5158 RVA: 0x00081CE4 File Offset: 0x0007FEE4
		private void UZR()
		{
			if (this.SelectedUsedParams != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.UZR()).MethodHandle;
				}
				IEnumerator<T> enumerator = this.SelectedUsedParams.GetEnumerator();
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						T item = enumerator.Current;
						this.AvailableParams.Add(item);
						this.UsedParams.Remove(item);
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
				}
				finally
				{
					if (enumerator != null)
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
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
			}
			ParameterBaseModel<T>.CollectionChangedDelegate collectionChangedHandler = this.CollectionChangedHandler;
			if (collectionChangedHandler == null)
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
				return;
			}
			collectionChangedHandler();
		}

		// Token: 0x06001427 RID: 5159 RVA: 0x00081DA4 File Offset: 0x0007FFA4
		private void WZR()
		{
			if (this.SelectedAvailableParams != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.WZR()).MethodHandle;
				}
				IEnumerator<T> enumerator = this.SelectedAvailableParams.GetEnumerator();
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						T item = enumerator.Current;
						this.UsedParams.Add(item);
						this.AvailableParams.Remove(item);
					}
					for (;;)
					{
						switch (1)
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
							switch (7)
							{
							case 0:
								continue;
							}
							break;
						}
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
			}
			ParameterBaseModel<T>.CollectionChangedDelegate collectionChangedHandler = this.CollectionChangedHandler;
			if (collectionChangedHandler == null)
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
				return;
			}
			collectionChangedHandler();
		}

		// Token: 0x06001428 RID: 5160 RVA: 0x00081E64 File Offset: 0x00080064
		private void KZR(ListView F)
		{
			List<T> list = Enumerable.ToList<T>(Enumerable.Cast<T>(\u0011\u001A\u0019.\u0007(F)));
			object obj = \u001A\u0001\u0018.\u000A(F);
			string u001F;
			if (obj == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.KZR(ListView)).MethodHandle;
				}
				u001F = null;
			}
			else
			{
				u001F = \u001A\u000C\u000A.\u000A(obj);
			}
			if (\u0008\u0013\u000A.\u000A(u001F, "EventFromAvailableList"))
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
				using (List<T>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						T item = enumerator.Current;
						this.UsedParams.Add(item);
						this.AvailableParams.Remove(item);
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
					goto IL_10A;
				}
			}
			using (List<T>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T item2 = enumerator.Current;
					this.AvailableParams.Add(item2);
					this.UsedParams.Remove(item2);
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
			}
			IL_10A:
			ParameterBaseModel<T>.CollectionChangedDelegate collectionChangedHandler = this.CollectionChangedHandler;
			if (collectionChangedHandler == null)
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
				return;
			}
			collectionChangedHandler();
		}

		// Token: 0x06001429 RID: 5161 RVA: 0x00081FB4 File Offset: 0x000801B4
		private void JZR()
		{
			if (this.SelectedUsedParams != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.JZR()).MethodHandle;
				}
				List<T> list = Enumerable.ToList<T>(Enumerable.OrderBy<T, int>(this.SelectedUsedParams, new Func<T, int>(this.OZR)));
				int num = 0;
				using (List<T>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						T item = enumerator.Current;
						this.UsedParams.Move(this.UsedParams.IndexOf(item), num++);
					}
					for (;;)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
				}
			}
		}

		// Token: 0x0600142A RID: 5162 RVA: 0x00082070 File Offset: 0x00080270
		private void EZR()
		{
			if (this.SelectedUsedParams != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.EZR()).MethodHandle;
				}
				using (List<T>.Enumerator enumerator = Enumerable.ToList<T>(Enumerable.OrderBy<T, int>(this.SelectedUsedParams, new Func<T, int>(this.TZR))).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						T item = enumerator.Current;
						int num = this.UsedParams.IndexOf(item);
						int num2 = num - 1;
						if (num2 < 0)
						{
							return;
						}
						for (;;)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						this.UsedParams.Move(num, num2);
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
				}
			}
		}

		// Token: 0x0600142B RID: 5163 RVA: 0x0008213C File Offset: 0x0008033C
		private void NZR()
		{
			if (this.SelectedUsedParams != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.NZR()).MethodHandle;
				}
				using (List<T>.Enumerator enumerator = Enumerable.ToList<T>(Enumerable.OrderByDescending<T, int>(this.SelectedUsedParams, new Func<T, int>(this.IZR))).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						T item = enumerator.Current;
						int num = this.UsedParams.IndexOf(item);
						int num2 = num + 1;
						if (num2 >= this.UsedParams.Count)
						{
							return;
						}
						for (;;)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							break;
						}
						this.UsedParams.Move(num, num2);
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
				}
			}
		}

		// Token: 0x0600142C RID: 5164 RVA: 0x00082214 File Offset: 0x00080414
		private void MZR()
		{
			if (this.SelectedUsedParams != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.MZR()).MethodHandle;
				}
				List<T> list = Enumerable.ToList<T>(Enumerable.OrderByDescending<T, int>(this.SelectedUsedParams, new Func<T, int>(this.QZR)));
				int num = this.UsedParams.Count - 1;
				using (List<T>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						T item = enumerator.Current;
						this.UsedParams.Move(this.UsedParams.IndexOf(item), num--);
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
				}
			}
		}

		// Token: 0x0600142D RID: 5165 RVA: 0x000822E0 File Offset: 0x000804E0
		public virtual void Apply(Window wnd)
		{
			\u0006\u0015\u0007.\u001D(wnd, new bool?(true));
		}

		// Token: 0x0600142E RID: 5166 RVA: 0x000822FC File Offset: 0x000804FC
		[CompilerGenerated]
		private ObservableCollection<T> VZR()
		{
			return this.AvailableParams;
		}

		// Token: 0x0600142F RID: 5167 RVA: 0x00082314 File Offset: 0x00080514
		[CompilerGenerated]
		private ObservableCollection<T> ZZR()
		{
			return this.UsedParams;
		}

		// Token: 0x06001430 RID: 5168 RVA: 0x0008232C File Offset: 0x0008052C
		[CompilerGenerated]
		private IList<T> XZR()
		{
			return this.SelectedUsedParams;
		}

		// Token: 0x06001431 RID: 5169 RVA: 0x00082344 File Offset: 0x00080544
		[CompilerGenerated]
		private IList<T> PZR()
		{
			return this.SelectedAvailableParams;
		}

		// Token: 0x06001432 RID: 5170 RVA: 0x0008235C File Offset: 0x0008055C
		[CompilerGenerated]
		private int OZR(T F)
		{
			return this.UsedParams.IndexOf(F);
		}

		// Token: 0x06001433 RID: 5171 RVA: 0x0008237C File Offset: 0x0008057C
		[CompilerGenerated]
		private int TZR(T F)
		{
			return this.UsedParams.IndexOf(F);
		}

		// Token: 0x06001434 RID: 5172 RVA: 0x0008239C File Offset: 0x0008059C
		[CompilerGenerated]
		private int IZR(T F)
		{
			return this.UsedParams.IndexOf(F);
		}

		// Token: 0x06001435 RID: 5173 RVA: 0x000823BC File Offset: 0x000805BC
		[CompilerGenerated]
		private int QZR(T F)
		{
			return this.UsedParams.IndexOf(F);
		}

		// Token: 0x040007C2 RID: 1986
		[CompilerGenerated]
		private ParameterBaseModel<T>.CollectionChangedDelegate UW;

		// Token: 0x040007C3 RID: 1987
		private ObservableCollection<T> WW;

		// Token: 0x040007C4 RID: 1988
		private ObservableCollection<T> KW;

		// Token: 0x040007C5 RID: 1989
		private IList<T> JW;

		// Token: 0x040007C6 RID: 1990
		private IList<T> EW;

		// Token: 0x040007C7 RID: 1991
		[CompilerGenerated]
		private bool NW;

		// Token: 0x020008D4 RID: 2260
		// (Invoke) Token: 0x06005089 RID: 20617
		public delegate void CollectionChangedDelegate();

		// Token: 0x020008D6 RID: 2262
		[CompilerGenerated]
		private sealed class \u0006\u0003
		{
			// Token: 0x06005091 RID: 20625 RVA: 0x001E73B0 File Offset: 0x001E55B0
			internal bool \u000A(\u001F \u001F)
			{
				return this.\u001F.Contains(\u001F);
			}

			// Token: 0x0400230E RID: 8974
			public List<\u001F> \u001F;
		}

		// Token: 0x020008D7 RID: 2263
		[CompilerGenerated]
		private sealed class \u000F\u0003
		{
			// Token: 0x06005093 RID: 20627 RVA: 0x001E73E0 File Offset: 0x001E55E0
			internal bool \u000A(\u000A \u001F)
			{
				return this.\u001F.Contains(\u001F);
			}

			// Token: 0x06005094 RID: 20628 RVA: 0x001E73FC File Offset: 0x001E55FC
			internal bool \u0007(\u000A \u001F)
			{
				return this.\u001F.Contains(\u001F);
			}

			// Token: 0x0400230F RID: 8975
			public List<\u000A> \u001F;
		}
	}
}
