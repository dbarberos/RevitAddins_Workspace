using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Serialization;
using A;
using Autodesk.Revit.DB;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002BA RID: 698
	[Serializable]
	public class RevisionData
	{
		// Token: 0x14000030 RID: 48
		// (add) Token: 0x06001BBF RID: 7103 RVA: 0x000B1D10 File Offset: 0x000AFF10
		// (remove) Token: 0x06001BC0 RID: 7104 RVA: 0x000B1D5C File Offset: 0x000AFF5C
		public event RevisionData.RevisionCheckChangedHandler RevisionCheckChanged
		{
			[CompilerGenerated]
			add
			{
				RevisionData.RevisionCheckChangedHandler revisionCheckChangedHandler = this.RevisionCheckChanged;
				RevisionData.RevisionCheckChangedHandler revisionCheckChangedHandler2;
				do
				{
					revisionCheckChangedHandler2 = revisionCheckChangedHandler;
					RevisionData.RevisionCheckChangedHandler value2 = (RevisionData.RevisionCheckChangedHandler)\u000F\u001E\u000A.\u000A(revisionCheckChangedHandler2, value);
					revisionCheckChangedHandler = Interlocked.CompareExchange<RevisionData.RevisionCheckChangedHandler>(ref this.RevisionCheckChanged, value2, revisionCheckChangedHandler2);
				}
				while (revisionCheckChangedHandler != revisionCheckChangedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionData.add_RevisionCheckChanged(RevisionData.RevisionCheckChangedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				RevisionData.RevisionCheckChangedHandler revisionCheckChangedHandler = this.RevisionCheckChanged;
				RevisionData.RevisionCheckChangedHandler revisionCheckChangedHandler2;
				do
				{
					revisionCheckChangedHandler2 = revisionCheckChangedHandler;
					RevisionData.RevisionCheckChangedHandler value2 = (RevisionData.RevisionCheckChangedHandler)\u0012\u001E\u000A.\u000A(revisionCheckChangedHandler2, value);
					revisionCheckChangedHandler = Interlocked.CompareExchange<RevisionData.RevisionCheckChangedHandler>(ref this.RevisionCheckChanged, value2, revisionCheckChangedHandler2);
				}
				while (revisionCheckChangedHandler != revisionCheckChangedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionData.remove_RevisionCheckChanged(RevisionData.RevisionCheckChangedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x170007B3 RID: 1971
		// (get) Token: 0x06001BC1 RID: 7105 RVA: 0x000B1DA8 File Offset: 0x000AFFA8
		// (set) Token: 0x06001BC2 RID: 7106 RVA: 0x000B1DBC File Offset: 0x000AFFBC
		public bool IsChecked
		{
			get
			{
				return this._isChecked;
			}
			set
			{
				bool flag = false;
				if (this._isChecked != value)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionData.set_IsChecked(bool)).MethodHandle;
					}
					flag = true;
				}
				this._isChecked = value;
				if (flag)
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
					RevisionData.RevisionCheckChangedHandler revisionCheckChanged = this.RevisionCheckChanged;
					if (revisionCheckChanged == null)
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
					\u0016\u0003\u0016.\u000A(revisionCheckChanged, this);
				}
			}
		}

		// Token: 0x170007B4 RID: 1972
		// (get) Token: 0x06001BC3 RID: 7107 RVA: 0x000B1E18 File Offset: 0x000B0018
		// (set) Token: 0x06001BC4 RID: 7108 RVA: 0x000B1E2C File Offset: 0x000B002C
		public bool IsHidden { get; set; }

		// Token: 0x170007B5 RID: 1973
		// (get) Token: 0x06001BC5 RID: 7109 RVA: 0x000B1E40 File Offset: 0x000B0040
		public string Name
		{
			get
			{
				if (\u000B\u0003\u0016.\u0007(this) > 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionData.get_Name()).MethodHandle;
					}
					int num = \u000B\u0003\u0016.\u0007(this);
					return \u000C\u0013\u0007.\u000A(ref num);
				}
				return \u000A\u0012\u0016.\u000A();
			}
		}

		// Token: 0x170007B6 RID: 1974
		// (get) Token: 0x06001BC6 RID: 7110 RVA: 0x000B1E88 File Offset: 0x000B0088
		// (set) Token: 0x06001BC7 RID: 7111 RVA: 0x000B1E9C File Offset: 0x000B009C
		public int Sequence { get; set; }

		// Token: 0x170007B7 RID: 1975
		// (get) Token: 0x06001BC8 RID: 7112 RVA: 0x000B1EB0 File Offset: 0x000B00B0
		// (set) Token: 0x06001BC9 RID: 7113 RVA: 0x000B1EC4 File Offset: 0x000B00C4
		public string Description { get; set; }

		// Token: 0x170007B8 RID: 1976
		// (get) Token: 0x06001BCA RID: 7114 RVA: 0x000B1ED8 File Offset: 0x000B00D8
		// (set) Token: 0x06001BCB RID: 7115 RVA: 0x000B1EEC File Offset: 0x000B00EC
		public int DesriptionWidth { get; set; }

		// Token: 0x170007B9 RID: 1977
		// (get) Token: 0x06001BCC RID: 7116 RVA: 0x000B1F00 File Offset: 0x000B0100
		// (set) Token: 0x06001BCD RID: 7117 RVA: 0x000B1F14 File Offset: 0x000B0114
		[XmlIgnore]
		public Revision RevisionElement { get; set; }

		// Token: 0x06001BCE RID: 7118 RVA: 0x000B1F28 File Offset: 0x000B0128
		public RevisionData Clone()
		{
			return \u0009\u0003\u000E.\u001F(\u0001\u0012\u0016.\u000A(this));
		}

		// Token: 0x04000B35 RID: 2869
		private bool _isChecked;

		// Token: 0x02000987 RID: 2439
		// (Invoke) Token: 0x06005311 RID: 21265
		public delegate void RevisionCheckChangedHandler(RevisionData data);
	}
}
