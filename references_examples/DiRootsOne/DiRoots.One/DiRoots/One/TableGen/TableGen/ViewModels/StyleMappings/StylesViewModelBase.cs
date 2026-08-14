using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using DiRoots.One.UIBehaviours.Extensions;

namespace DiRoots.One.TableGen.TableGen.ViewModels.StyleMappings
{
	// Token: 0x02000178 RID: 376
	public abstract class StylesViewModelBase<T> : ModelBase where T : ModelBase
	{
		// Token: 0x06000E0D RID: 3597 RVA: 0x00059F04 File Offset: 0x00058104
		public StylesViewModelBase(Document doc, Action onReadFromFiles, Action onMarkDataChanged)
		{
			this._doc = doc;
			this.HH = onReadFromFiles;
			this._onMarkDataChanged = onMarkDataChanged;
		}

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06000E0E RID: 3598 RVA: 0x00059F38 File Offset: 0x00058138
		// (set) Token: 0x06000E0F RID: 3599 RVA: 0x00059F4C File Offset: 0x0005814C
		public string SearchText
		{
			get
			{
				return this._searchText;
			}
			set
			{
				this._searchText = value;
				\u0007\u0013\u000A.\u000A(this, "SearchText");
				\u0014\u0003\u0007.\u000A(this.StylesView);
			}
		}

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x06000E10 RID: 3600 RVA: 0x00059F78 File Offset: 0x00058178
		// (set) Token: 0x06000E11 RID: 3601 RVA: 0x00059F8C File Offset: 0x0005818C
		public ICollectionView StylesView { get; set; }

		// Token: 0x06000E12 RID: 3602 RVA: 0x00059FA0 File Offset: 0x000581A0
		[BindableMethod("OnReadFromFiles")]
		public void OnReadFromFiles()
		{
			\u001B\u0015\u0007.\u000A(this.HH);
		}

		// Token: 0x06000E13 RID: 3603 RVA: 0x00059FB8 File Offset: 0x000581B8
		protected void DetachStyleVmHandlers(ObservableCollection<T> objects)
		{
			IEnumerator<T> enumerator = objects.GetEnumerator();
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u001E\u000D\u0019.\u000A(enumerator.Current, new PropertyChangedEventHandler(this.StyleVm_PropertyChanged));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(StylesViewModelBase.DetachStyleVmHandlers(ObservableCollection<T>)).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}

		// Token: 0x06000E14 RID: 3604 RVA: 0x0005A034 File Offset: 0x00058234
		protected void StyleVm_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			\u001B\u0015\u0007.\u000A(this._onMarkDataChanged);
		}

		// Token: 0x0400058C RID: 1420
		protected string _searchText = string.Empty;

		// Token: 0x0400058D RID: 1421
		protected readonly Document _doc;

		// Token: 0x0400058E RID: 1422
		private readonly Action HH;

		// Token: 0x0400058F RID: 1423
		protected readonly Action _onMarkDataChanged;

		// Token: 0x04000590 RID: 1424
		[CompilerGenerated]
		private ICollectionView YH;
	}
}
