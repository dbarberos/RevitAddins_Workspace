using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Services;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.SheetGen;
using DiRoots.One.SheetGen.Services;

namespace A
{
	// Token: 0x020002A5 RID: 677
	internal class \u001A\u0008 : \u001F\u001B<PlaceholderSheet>
	{
		// Token: 0x06001ABE RID: 6846 RVA: 0x000ADE50 File Offset: 0x000AC050
		public \u001A\u0008(\u0020\u001A \u001F, ISheetNumberValidationService \u000A, ICancellationManagerService \u0007, ICustomLogger \u001D, ISheetFinalRenumberingService \u0004) : base(\u001F, \u000A, \u0007, \u001D, \u0004)
		{
		}

		// Token: 0x06001ABF RID: 6847 RVA: 0x000ADE6C File Offset: 0x000AC06C
		protected override void \u0002\u0019(Document \u001F, IEnumerable<PlaceholderSheet> \u000A, Action<PlaceholderSheet> \u0007)
		{
			\u001A\u0008.\u0017\u0008 u0017_u = new \u001A\u0008.\u0017\u0008();
			u0017_u.\u001F = this;
			u0017_u.\u000A = \u001F;
			IEnumerator<PlaceholderSheet> enumerator = \u001C\u0006\u0016.\u000A(\u000A);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u001A\u0008.\u0014\u0008 u0014_u = new \u001A\u0008.\u0014\u0008();
					u0014_u.\u000A = u0017_u;
					u0014_u.\u001F = \u0003\u0006\u0016.\u000A(enumerator);
					\u001A\u0008.\u0013\u0008 u0013_u = new \u001A\u0008.\u0013\u0008();
					u0013_u.\u000A = u0014_u;
					\u0018\u0004\u0016.\u000A(this.\u0014\u0007);
					\u0012\u0006\u0016.\u000A(\u0007, u0013_u.\u000A.\u001F);
					\u0008\u0008\u000A u0008_u0008_u000A = base.\u0012\u0016("");
					u0013_u.\u001F = false;
					TransactionStatus u001F = \u0004\u0004\u0016.\u000A(u0013_u.\u000A.\u000A.\u000A, \u001E\u0020\u001D.\u000A("SheetGen_ApplyModification", \u0011\u0007\u0016.\u0007(u0013_u.\u000A.\u001F), "-", \u0019\u0004\u0016.\u0007(u0013_u.\u000A.\u001F)), u0008_u0008_u000A, new Action(u0013_u.\u000A.\u0007), new Action<Exception>(u0013_u.\u0007));
					\u001F\u0004\u0016.\u0007(\u000A\u0004\u0016.\u0007(u0008_u0008_u000A));
					if (u001F.\u0018())
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u001A\u0008.\u0002\u0019(Document, IEnumerable<PlaceholderSheet>, Action<PlaceholderSheet>)).MethodHandle;
						}
						if (!u0013_u.\u001F)
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
							this.\u0006\u0019(u0013_u.\u000A.\u000A.\u000A, u0013_u.\u000A.\u001F, \u0009\u001D\u0016.\u000A(u0008_u0008_u000A));
						}
					}
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

		// Token: 0x06001AC0 RID: 6848 RVA: 0x000AE010 File Offset: 0x000AC210
		private void \u0006\u0016(Document \u001F, PlaceholderSheet \u000A)
		{
			ViewSheet viewSheet = \u001F.AsElement(\u001D\u0004\u0016.\u0007(\u000A));
			if (viewSheet == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001A\u0008.\u0006\u0016(Document, PlaceholderSheet)).MethodHandle;
				}
				return;
			}
			\u001F\u0018\u0016.\u000A(\u000A, \u0020\u0008\u001D.\u000A(viewSheet));
			object u001F = viewSheet;
			string text;
			if (!\u001A\u0006\u0007.\u000A(\u0019\u0004\u0016.\u0007(\u000A)))
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
				text = \u0019\u0004\u0016.\u0007(\u000A);
			}
			else
			{
				text = "Unnamed";
			}
			string text2;
			\u0011\u0013\u0007.\u000A(u001F, text2 = text);
			string u000A;
			\u0009\u0019\u0016.\u000A(\u000A, u000A = text2);
			\u0001\u0019\u0016.\u000A(\u000A, u000A);
			this.\u001E\u0007.\u0002(\u000A, viewSheet);
			\u000A.\u001F(UpdateStates.Updated);
		}

		// Token: 0x02000977 RID: 2423
		[CompilerGenerated]
		private sealed class \u0017\u0008
		{
			// Token: 0x040024BA RID: 9402
			public \u001A\u0008 \u001F;

			// Token: 0x040024BB RID: 9403
			public Document \u000A;
		}

		// Token: 0x02000978 RID: 2424
		[CompilerGenerated]
		private sealed class \u0014\u0008
		{
			// Token: 0x060052E7 RID: 21223 RVA: 0x001EB708 File Offset: 0x001E9908
			internal void \u0007()
			{
				this.\u000A.\u001F.\u0006\u0016(this.\u000A.\u000A, this.\u001F);
			}

			// Token: 0x040024BC RID: 9404
			public PlaceholderSheet \u001F;

			// Token: 0x040024BD RID: 9405
			public \u001A\u0008.\u0017\u0008 \u000A;
		}

		// Token: 0x02000979 RID: 2425
		[CompilerGenerated]
		private sealed class \u0013\u0008
		{
			// Token: 0x060052E9 RID: 21225 RVA: 0x001EB74C File Offset: 0x001E994C
			internal void \u0007(Exception \u001F)
			{
				this.\u001F = true;
				this.\u000A.\u000A.\u001F.\u0006\u0019(this.\u000A.\u000A.\u000A, this.\u000A.\u001F, \u001F);
			}

			// Token: 0x040024BE RID: 9406
			public bool \u001F;

			// Token: 0x040024BF RID: 9407
			public \u001A\u0008.\u0014\u0008 \u000A;
		}
	}
}
