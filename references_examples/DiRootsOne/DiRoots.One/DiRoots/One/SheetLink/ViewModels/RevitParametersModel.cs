using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;
using DiRoots.One.UIBehaviours.Extensions;

namespace DiRoots.One.SheetLink.ViewModels
{
	// Token: 0x02000215 RID: 533
	public class RevitParametersModel : ParameterBaseModel<BaseParameter>
	{
		// Token: 0x06001436 RID: 5174 RVA: 0x000823DC File Offset: 0x000805DC
		public RevitParametersModel() : base(new List<BaseParameter>(), new List<BaseParameter>())
		{
			ParameterSource? u000A;
			\u0003\u0002\u000E.\u001F(ref u000A);
			\u000C\u0001\u0018.\u000A(this, u000A);
		}

		// Token: 0x170005C2 RID: 1474
		// (get) Token: 0x06001437 RID: 5175 RVA: 0x00082408 File Offset: 0x00080608
		// (set) Token: 0x06001438 RID: 5176 RVA: 0x0008241C File Offset: 0x0008061C
		public ParameterSource? OrderBy { get; set; }

		// Token: 0x06001439 RID: 5177 RVA: 0x00082430 File Offset: 0x00080630
		[BindableMethod("OrderByInstance")]
		public void OrderByInstance()
		{
			ParameterSource? u000A = \u0001\u0001\u0018.\u000A(this);
			if (\u0015\u0001\u0018.\u000A(ref u000A) == ParameterSource.Instance)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParametersModel.OrderByInstance()).MethodHandle;
				}
				\u0003\u0002\u000E.\u001F(ref u000A);
				\u000C\u0001\u0018.\u000A(this, u000A);
			}
			else
			{
				\u000C\u0001\u0018.\u000A(this, new ParameterSource?(ParameterSource.Instance));
			}
			IEnumerable<BaseParameter> enumerable = \u000E\u0013\u0018.\u001D(this);
			Func<BaseParameter, bool> func;
			if ((func = RevitParametersModel.<>c.\u000A) == null)
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
				func = (RevitParametersModel.<>c.\u000A = new Func<BaseParameter, bool>(RevitParametersModel.<>c.\u001F.\u0008));
			}
			object u001F = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(enumerable, func));
			Action<BaseParameter> u000A2;
			if ((u000A2 = RevitParametersModel.<>c.\u0007) == null)
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
				u000A2 = (RevitParametersModel.<>c.\u0007 = new Action<BaseParameter>(RevitParametersModel.<>c.\u001F.\u001B));
			}
			\u0020\u001A\u0019.\u000A(u001F, u000A2);
			IEnumerable<BaseParameter> enumerable2 = \u000E\u0013\u0018.\u001D(this);
			Func<BaseParameter, bool> func2;
			if ((func2 = RevitParametersModel.<>c.\u001D) == null)
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
				func2 = (RevitParametersModel.<>c.\u001D = new Func<BaseParameter, bool>(RevitParametersModel.<>c.\u001F.\u0011));
			}
			object u001F2 = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(enumerable2, func2));
			Action<BaseParameter> u000A3;
			if ((u000A3 = RevitParametersModel.<>c.\u0004) == null)
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
				u000A3 = (RevitParametersModel.<>c.\u0004 = new Action<BaseParameter>(RevitParametersModel.<>c.\u001F.\u001E));
			}
			\u0020\u001A\u0019.\u000A(u001F2, u000A3);
			IEnumerable<BaseParameter> enumerable3 = \u000E\u0013\u0018.\u001D(this);
			Func<BaseParameter, bool> func3;
			if ((func3 = RevitParametersModel.<>c.\u0019) == null)
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
				func3 = (RevitParametersModel.<>c.\u0019 = new Func<BaseParameter, bool>(RevitParametersModel.<>c.\u001F.\u0020));
			}
			object u001F3 = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(enumerable3, func3));
			Action<BaseParameter> u000A4;
			if ((u000A4 = RevitParametersModel.<>c.\u0018) == null)
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
				u000A4 = (RevitParametersModel.<>c.\u0018 = new Action<BaseParameter>(RevitParametersModel.<>c.\u001F.\u0017));
			}
			\u0020\u001A\u0019.\u000A(u001F3, u000A4);
			this.AZR();
		}

		// Token: 0x0600143A RID: 5178 RVA: 0x000825D0 File Offset: 0x000807D0
		[BindableMethod("OrderByType")]
		public void OrderByType()
		{
			ParameterSource? u000A = \u0001\u0001\u0018.\u000A(this);
			if (\u0015\u0001\u0018.\u000A(ref u000A) == ParameterSource.Type)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParametersModel.OrderByType()).MethodHandle;
				}
				\u0003\u0002\u000E.\u001F(ref u000A);
				\u000C\u0001\u0018.\u000A(this, u000A);
			}
			else
			{
				\u000C\u0001\u0018.\u000A(this, new ParameterSource?(ParameterSource.Type));
			}
			IEnumerable<BaseParameter> enumerable = \u000E\u0013\u0018.\u001D(this);
			Func<BaseParameter, bool> func;
			if ((func = RevitParametersModel.<>c.\u0005) == null)
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
				func = (RevitParametersModel.<>c.\u0005 = new Func<BaseParameter, bool>(RevitParametersModel.<>c.\u001F.\u0014));
			}
			object u001F = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(enumerable, func));
			Action<BaseParameter> u000A2;
			if ((u000A2 = RevitParametersModel.<>c.\u0016) == null)
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
				u000A2 = (RevitParametersModel.<>c.\u0016 = new Action<BaseParameter>(RevitParametersModel.<>c.\u001F.\u0013));
			}
			\u0020\u001A\u0019.\u000A(u001F, u000A2);
			IEnumerable<BaseParameter> enumerable2 = \u000E\u0013\u0018.\u001D(this);
			Func<BaseParameter, bool> func2;
			if ((func2 = RevitParametersModel.<>c.\u000B) == null)
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
				func2 = (RevitParametersModel.<>c.\u000B = new Func<BaseParameter, bool>(RevitParametersModel.<>c.\u001F.\u001A));
			}
			object u001F2 = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(enumerable2, func2));
			Action<BaseParameter> u000A3;
			if ((u000A3 = RevitParametersModel.<>c.\u0002) == null)
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
				u000A3 = (RevitParametersModel.<>c.\u0002 = new Action<BaseParameter>(RevitParametersModel.<>c.\u001F.\u000C));
			}
			\u0020\u001A\u0019.\u000A(u001F2, u000A3);
			IEnumerable<BaseParameter> enumerable3 = \u000E\u0013\u0018.\u001D(this);
			Func<BaseParameter, bool> func3;
			if ((func3 = RevitParametersModel.<>c.\u0006) == null)
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
				func3 = (RevitParametersModel.<>c.\u0006 = new Func<BaseParameter, bool>(RevitParametersModel.<>c.\u001F.\u0015));
			}
			object u001F3 = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(enumerable3, func3));
			Action<BaseParameter> u000A4;
			if ((u000A4 = RevitParametersModel.<>c.\u000F) == null)
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
				u000A4 = (RevitParametersModel.<>c.\u000F = new Action<BaseParameter>(RevitParametersModel.<>c.\u001F.\u0001));
			}
			\u0020\u001A\u0019.\u000A(u001F3, u000A4);
			this.AZR();
		}

		// Token: 0x0600143B RID: 5179 RVA: 0x00082770 File Offset: 0x00080970
		[BindableMethod("OrderByReadOnly")]
		public void OrderByReadOnly()
		{
			ParameterSource? u000A = \u0001\u0001\u0018.\u000A(this);
			if (\u0015\u0001\u0018.\u000A(ref u000A) == ParameterSource.ReadOnly)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParametersModel.OrderByReadOnly()).MethodHandle;
				}
				\u0003\u0002\u000E.\u001F(ref u000A);
				\u000C\u0001\u0018.\u000A(this, u000A);
			}
			else
			{
				\u000C\u0001\u0018.\u000A(this, new ParameterSource?(ParameterSource.ReadOnly));
			}
			IEnumerable<BaseParameter> enumerable = \u000E\u0013\u0018.\u001D(this);
			Func<BaseParameter, bool> func;
			if ((func = RevitParametersModel.<>c.\u0012) == null)
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
				func = (RevitParametersModel.<>c.\u0012 = new Func<BaseParameter, bool>(RevitParametersModel.<>c.\u001F.\u0009));
			}
			object u001F = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(enumerable, func));
			Action<BaseParameter> u000A2;
			if ((u000A2 = RevitParametersModel.<>c.\u0003) == null)
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
				u000A2 = (RevitParametersModel.<>c.\u0003 = new Action<BaseParameter>(RevitParametersModel.<>c.\u001F.\u001F\u000A));
			}
			\u0020\u001A\u0019.\u000A(u001F, u000A2);
			IEnumerable<BaseParameter> enumerable2 = \u000E\u0013\u0018.\u001D(this);
			Func<BaseParameter, bool> func2;
			if ((func2 = RevitParametersModel.<>c.\u001C) == null)
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
				func2 = (RevitParametersModel.<>c.\u001C = new Func<BaseParameter, bool>(RevitParametersModel.<>c.\u001F.\u000A\u000A));
			}
			object u001F2 = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(enumerable2, func2));
			Action<BaseParameter> u000A3;
			if ((u000A3 = RevitParametersModel.<>c.\u000D) == null)
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
				u000A3 = (RevitParametersModel.<>c.\u000D = new Action<BaseParameter>(RevitParametersModel.<>c.\u001F.\u0007\u000A));
			}
			\u0020\u001A\u0019.\u000A(u001F2, u000A3);
			IEnumerable<BaseParameter> enumerable3 = \u000E\u0013\u0018.\u001D(this);
			Func<BaseParameter, bool> func3;
			if ((func3 = RevitParametersModel.<>c.\u0010) == null)
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
				func3 = (RevitParametersModel.<>c.\u0010 = new Func<BaseParameter, bool>(RevitParametersModel.<>c.\u001F.\u001D\u000A));
			}
			object u001F3 = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(enumerable3, func3));
			Action<BaseParameter> u000A4;
			if ((u000A4 = RevitParametersModel.<>c.\u000E) == null)
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
				u000A4 = (RevitParametersModel.<>c.\u000E = new Action<BaseParameter>(RevitParametersModel.<>c.\u001F.\u0004\u000A));
			}
			\u0020\u001A\u0019.\u000A(u001F3, u000A4);
			this.AZR();
		}

		// Token: 0x0600143C RID: 5180 RVA: 0x00082910 File Offset: 0x00080B10
		private void AZR()
		{
			ICollectionView u001F = \u0011\u0009\u000A.\u000A(\u000E\u0013\u0018.\u001D(this));
			\u0013\u001A\u0019.\u000A(\u0014\u001A\u0019.\u000A(u001F));
			ParameterSource? parameterSource = \u0001\u0001\u0018.\u000A(this);
			if (!\u0009\u0001\u0018.\u000A(ref parameterSource))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParametersModel.AZR()).MethodHandle;
				}
				\u0017\u001A\u0019.\u000A(\u0014\u001A\u0019.\u000A(u001F), new SortDescription("Name", ListSortDirection.Ascending));
				return;
			}
			\u0017\u001A\u0019.\u000A(\u0014\u001A\u0019.\u000A(u001F), new SortDescription("OrderIndex", ListSortDirection.Ascending));
			\u0017\u001A\u0019.\u000A(\u0014\u001A\u0019.\u000A(u001F), new SortDescription("Name", ListSortDirection.Ascending));
		}

		// Token: 0x040007C8 RID: 1992
		[CompilerGenerated]
		private ParameterSource? MW;
	}
}
