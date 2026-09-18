using System;
using System.Collections.Generic;
using System.Windows;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.TGDatabaseLayer;

namespace DiRoots.One.TableGen.ViewModels
{
	// Token: 0x02000148 RID: 328
	public class AddBulkViewModel : AddBaseViewModel
	{
		// Token: 0x06000C23 RID: 3107 RVA: 0x0004D390 File Offset: 0x0004B590
		public AddBulkViewModel()
		{
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x0004D3AC File Offset: 0x0004B5AC
		public AddBulkViewModel(List<SelectedExcel> existingTables) : base(existingTables)
		{
			\u0006\u001F\u0019.\u000A(this, false);
			\u0002\u001F\u0019.\u000A(this, new CommandBase<Window>(new Action<Window>(this.UNR), new Predicate<Window>(base.CanAdd)));
		}

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x06000C25 RID: 3109 RVA: 0x0004D3F4 File Offset: 0x0004B5F4
		// (set) Token: 0x06000C26 RID: 3110 RVA: 0x0004D408 File Offset: 0x0004B608
		public int NumberOfCopies
		{
			get
			{
				return this.AL;
			}
			set
			{
				this.AL = value;
				\u000D\u0020\u000A.\u000A(this, "NumberOfCopies");
				\u000C\u0001\u0004.\u0007(this, "NumberOfCopies");
			}
		}

		// Token: 0x06000C27 RID: 3111 RVA: 0x0004D434 File Offset: 0x0004B634
		private void UNR(Window F)
		{
			for (int i = 1; i <= \u000F\u001F\u0019.\u000A(this); i++)
			{
				string text;
				if (\u000D\u001B\u001D.\u0007(\u0018\u0009\u0004.\u000A(this)) != 0)
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(AddBulkViewModel.UNR(Window)).MethodHandle;
					}
					text = \u0012\u0015\u001D.\u000A(\u000D\u0009\u0004.\u000A(this));
				}
				else
				{
					text = \u0017\u0009\u0004.\u000A(\u000A\u0009\u0004.\u000A(this));
				}
				string text2 = text;
				text2 = this.WNR(text2);
				int num = 1;
				string text3 = \u0002\u0013\u000A.\u000A(text2, " ", \u0003\u001F\u0019.\u000A(ref num, "D3"));
				while (!\u0012\u001F\u0019.\u000A(this, text3))
				{
					num++;
					text3 = \u0002\u0013\u000A.\u000A(text2, " ", \u0003\u001F\u0019.\u000A(ref num, "D3"));
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
				this.KNR(text3);
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
			\u0006\u0015\u0007.\u001D(F, new bool?(true));
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x0004D51C File Offset: 0x0004B71C
		protected bool IsViewNameValid(string viewName)
		{
			if (!\u000D\u001F\u0019.\u000A(this, viewName))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddBulkViewModel.IsViewNameValid(string)).MethodHandle;
				}
				return !\u001C\u001F\u0019.\u000A(this, viewName);
			}
			return false;
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x0004D558 File Offset: 0x0004B758
		private string WNR(string F)
		{
			char[] array = \u001C\u0007\u000E.\u001F(14);
			\u001B\u000B\u001D.\u000A(array, fieldof(\u0001\u001B\u000A.\u000B).FieldHandle);
			char[] u000A = array;
			return \u0014\u0006\u001D.\u000A(\u0009\u0007\u001D.\u000A(F, u000A));
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x0004D58C File Offset: 0x0004B78C
		private void KNR(string F)
		{
			SelectedExcel selectedExcel = \u0010\u001F\u0019.\u000A(this, F);
			\u000D\u0016\u0004.\u0007(selectedExcel, UpdateStates.ToAdd);
			\u001A\u0016\u0004.\u000A(\u001C\u001B\u0004.\u000A(), selectedExcel);
			\u001A\u0016\u0004.\u000A(this._existingTables, selectedExcel);
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x0004D5C4 File Offset: 0x0004B7C4
		protected override void DataValidation(string propertyName)
		{
			if (\u0008\u0013\u000A.\u000A(propertyName, "NumberOfCopies"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddBulkViewModel.DataValidation(string)).MethodHandle;
				}
				if (\u000F\u001F\u0019.\u000A(this) > 50)
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
					\u0009\u0009\u0004.\u000A(this, propertyName, \u0017\u0006\u0007.\u000A(\u000A\u001F\u0019.\u000A(), 50));
					return;
				}
			}
			\u000C\u0001\u0004.\u001D(this, propertyName);
		}

		// Token: 0x040004D5 RID: 1237
		private int AL = 1;
	}
}
