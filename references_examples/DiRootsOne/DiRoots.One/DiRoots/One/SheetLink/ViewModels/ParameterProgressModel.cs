using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons;
using DiRoots.One.SheetLink.Models;
using DiRoots.One.SheetLink.UI.Windows;

namespace DiRoots.One.SheetLink.ViewModels
{
	// Token: 0x0200020D RID: 525
	public class ParameterProgressModel : ProgressModel
	{
		// Token: 0x06001363 RID: 4963 RVA: 0x0007BAC0 File Offset: 0x00079CC0
		internal ParameterProgressModel(Document F, \u0015\u001C R, List<CategoryCollection> D)
		{
			this.CR = R;
			this.IU = D;
			this.QU = F;
			\u000F\u0014\u0018.\u000A(this, \u000E\u0014\u0018.\u000A());
		}

		// Token: 0x06001364 RID: 4964 RVA: 0x0007BAF8 File Offset: 0x00079CF8
		public override void RunProcess()
		{
			ProgressWindow u001F = \u001E\u000B\u000E.\u001F(\u0018\u000B\u0007.\u0007(this));
			try
			{
				\u001E\u0014\u0018.\u0007(this, (double)\u0020\u0014\u0018.\u000A(this.IU));
				int num = 1;
				List<CategoryCollection>.Enumerator enumerator = \u0014\u0016\u0018.\u000A(this.IU);
				try
				{
					while (\u001E\u0016\u0018.\u000A(ref enumerator))
					{
						ParameterProgressModel.\u001E\u0012 u001E_u = new ParameterProgressModel.\u001E\u0012();
						u001E_u.\u000A = this;
						u001E_u.\u001F = \u0017\u0016\u0018.\u000A(ref enumerator);
						if (\u0011\u0014\u0018.\u000A(u001F))
						{
							IEnumerator<CategoryCollection> enumerator2 = \u001E\u0013\u0019.\u000A(Enumerable.Where<CategoryCollection>(this.IU, new Func<CategoryCollection, bool>(u001E_u.\u0007)));
							try
							{
								while (\u000A\u0017\u000A.\u000A(enumerator2))
								{
									\u001B\u0013\u0019.\u000A(\u0011\u0013\u0019.\u000A(enumerator2), false);
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
								goto IL_10F;
							}
							finally
							{
								if (enumerator2 != null)
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
									\u001F\u0017\u000A.\u000A(enumerator2);
								}
							}
							continue;
							IL_10F:
							goto IL_11F;
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterProgressModel.RunProcess()).MethodHandle;
						}
						this.CR.\u0005(u001E_u.\u001F, this.QU);
						\u001B\u0014\u0018.\u000A(this, num++, DispatcherPriority.Render);
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
					((IDisposable)enumerator).Dispose();
				}
				IL_11F:
				\u0008\u0014\u0018.\u000A(this);
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\ViewModels\\Progress\\ParameterProgressModel.cs", "RunProcess");
			}
		}

		// Token: 0x040007A8 RID: 1960
		private readonly \u0015\u001C CR;

		// Token: 0x040007A9 RID: 1961
		private readonly List<CategoryCollection> IU;

		// Token: 0x040007AA RID: 1962
		private readonly Document QU;

		// Token: 0x020008BA RID: 2234
		[CompilerGenerated]
		private sealed class \u001E\u0012
		{
			// Token: 0x06005018 RID: 20504 RVA: 0x001E658C File Offset: 0x001E478C
			internal bool \u0007(CategoryCollection \u001F)
			{
				return \u001C\u0016\u0010.\u000A(this.\u000A.IU, \u001F) >= \u001C\u0016\u0010.\u000A(this.\u000A.IU, this.\u001F);
			}

			// Token: 0x040022B1 RID: 8881
			public CategoryCollection \u001F;

			// Token: 0x040022B2 RID: 8882
			public ParameterProgressModel \u000A;
		}
	}
}
