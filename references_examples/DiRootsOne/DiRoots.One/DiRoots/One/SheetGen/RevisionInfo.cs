using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using DiRoots.One.SheetGen.Data;
using DiRoots.One.SheetGen.Services;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002BB RID: 699
	[Serializable]
	public class RevisionInfo : ModelBase
	{
		// Token: 0x06001BCF RID: 7119 RVA: 0x000B1F44 File Offset: 0x000B0144
		public RevisionInfo()
		{
			\u001E\u0018\u0016.\u001D(this, new List<RevisionData>());
			\u0006\u0003\u0016.\u000A(this, new List<RevisionParameter>());
			\u0011\u0018\u0016.\u001D(this);
			\u0002\u0003\u0016.\u0007(this);
		}

		// Token: 0x06001BD0 RID: 7120 RVA: 0x000B1F84 File Offset: 0x000B0184
		public RevisionInfo(SheetInfo sheet)
		{
			this._sheetInfo = sheet;
			\u001E\u0018\u0016.\u001D(this, new List<RevisionData>());
			\u0006\u0003\u0016.\u000A(this, new List<RevisionParameter>());
			\u0011\u0018\u0016.\u001D(this);
			\u0002\u0003\u0016.\u0007(this);
		}

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x06001BD2 RID: 7122 RVA: 0x000B1FF4 File Offset: 0x000B01F4
		// (remove) Token: 0x06001BD3 RID: 7123 RVA: 0x000B2040 File Offset: 0x000B0240
		internal static event RevisionInfo.RevisionChangedHandler RS
		{
			[CompilerGenerated]
			add
			{
				RevisionInfo.RevisionChangedHandler revisionChangedHandler = RevisionInfo.RS;
				RevisionInfo.RevisionChangedHandler revisionChangedHandler2;
				do
				{
					revisionChangedHandler2 = revisionChangedHandler;
					RevisionInfo.RevisionChangedHandler value2 = (RevisionInfo.RevisionChangedHandler)\u000F\u001E\u000A.\u000A(revisionChangedHandler2, value);
					revisionChangedHandler = Interlocked.CompareExchange<RevisionInfo.RevisionChangedHandler>(ref RevisionInfo.RS, value2, revisionChangedHandler2);
				}
				while (revisionChangedHandler != revisionChangedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionInfo.add_RS(RevisionInfo.RevisionChangedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				RevisionInfo.RevisionChangedHandler revisionChangedHandler = RevisionInfo.RS;
				RevisionInfo.RevisionChangedHandler revisionChangedHandler2;
				do
				{
					revisionChangedHandler2 = revisionChangedHandler;
					RevisionInfo.RevisionChangedHandler value2 = (RevisionInfo.RevisionChangedHandler)\u0012\u001E\u000A.\u000A(revisionChangedHandler2, value);
					revisionChangedHandler = Interlocked.CompareExchange<RevisionInfo.RevisionChangedHandler>(ref RevisionInfo.RS, value2, revisionChangedHandler2);
				}
				while (revisionChangedHandler != revisionChangedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionInfo.remove_RS(RevisionInfo.RevisionChangedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x06001BD4 RID: 7124 RVA: 0x000B208C File Offset: 0x000B028C
		// (remove) Token: 0x06001BD5 RID: 7125 RVA: 0x000B20D8 File Offset: 0x000B02D8
		public event RevisionInfo.RevisionsEditedHandler RevisionEdited
		{
			[CompilerGenerated]
			add
			{
				RevisionInfo.RevisionsEditedHandler revisionsEditedHandler = this.RevisionEdited;
				RevisionInfo.RevisionsEditedHandler revisionsEditedHandler2;
				do
				{
					revisionsEditedHandler2 = revisionsEditedHandler;
					RevisionInfo.RevisionsEditedHandler value2 = (RevisionInfo.RevisionsEditedHandler)\u000F\u001E\u000A.\u000A(revisionsEditedHandler2, value);
					revisionsEditedHandler = Interlocked.CompareExchange<RevisionInfo.RevisionsEditedHandler>(ref this.RevisionEdited, value2, revisionsEditedHandler2);
				}
				while (revisionsEditedHandler != revisionsEditedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionInfo.add_RevisionEdited(RevisionInfo.RevisionsEditedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				RevisionInfo.RevisionsEditedHandler revisionsEditedHandler = this.RevisionEdited;
				RevisionInfo.RevisionsEditedHandler revisionsEditedHandler2;
				do
				{
					revisionsEditedHandler2 = revisionsEditedHandler;
					RevisionInfo.RevisionsEditedHandler value2 = (RevisionInfo.RevisionsEditedHandler)\u0012\u001E\u000A.\u000A(revisionsEditedHandler2, value);
					revisionsEditedHandler = Interlocked.CompareExchange<RevisionInfo.RevisionsEditedHandler>(ref this.RevisionEdited, value2, revisionsEditedHandler2);
				}
				while (revisionsEditedHandler != revisionsEditedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionInfo.remove_RevisionEdited(RevisionInfo.RevisionsEditedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x170007BA RID: 1978
		// (get) Token: 0x06001BD6 RID: 7126 RVA: 0x000B2124 File Offset: 0x000B0324
		// (set) Token: 0x06001BD7 RID: 7127 RVA: 0x000B2138 File Offset: 0x000B0338
		public List<RevisionData> Revisions { get; set; }

		// Token: 0x170007BB RID: 1979
		// (get) Token: 0x06001BD8 RID: 7128 RVA: 0x000B214C File Offset: 0x000B034C
		// (set) Token: 0x06001BD9 RID: 7129 RVA: 0x000B2160 File Offset: 0x000B0360
		public List<ElementId> CloudRevisions { get; set; }

		// Token: 0x170007BC RID: 1980
		// (get) Token: 0x06001BDA RID: 7130 RVA: 0x000B2174 File Offset: 0x000B0374
		// (set) Token: 0x06001BDB RID: 7131 RVA: 0x000B2188 File Offset: 0x000B0388
		public List<RevisionParameter> Parameters { get; set; }

		// Token: 0x170007BD RID: 1981
		// (get) Token: 0x06001BDC RID: 7132 RVA: 0x000B219C File Offset: 0x000B039C
		// (set) Token: 0x06001BDD RID: 7133 RVA: 0x000B21B0 File Offset: 0x000B03B0
		internal static bool ReloadCache { get; set; }

		// Token: 0x170007BE RID: 1982
		// (get) Token: 0x06001BDE RID: 7134 RVA: 0x000B21C4 File Offset: 0x000B03C4
		// (set) Token: 0x06001BDF RID: 7135 RVA: 0x000B21D8 File Offset: 0x000B03D8
		internal static List<RevisionData> RevisionsCache { get; set; } = \u0012\u0003\u0016.\u000A();

		// Token: 0x170007BF RID: 1983
		// (get) Token: 0x06001BE0 RID: 7136 RVA: 0x000B21EC File Offset: 0x000B03EC
		// (set) Token: 0x06001BE1 RID: 7137 RVA: 0x000B2200 File Offset: 0x000B0400
		internal static Dictionary<string, List<RevisionParameter>> ParametersCache { get; set; } = \u000F\u0003\u0016.\u000A();

		// Token: 0x06001BE2 RID: 7138 RVA: 0x000B2214 File Offset: 0x000B0414
		public void SetSheetInfo(SheetInfo sheet)
		{
			this._sheetInfo = sheet;
		}

		// Token: 0x06001BE3 RID: 7139 RVA: 0x000B2228 File Offset: 0x000B0428
		private List<RevisionData> KO(List<RevisionData> F)
		{
			List<RevisionData> list = \u0012\u0003\u0016.\u000A();
			List<RevisionData>.Enumerator enumerator = \u0014\u0004\u0016.\u000A(F);
			try
			{
				while (\u001B\u0004\u0016.\u000A(ref enumerator))
				{
					RevisionData u001F = \u0017\u0004\u0016.\u000A(ref enumerator);
					RevisionData revisionData = \u0017\u0003\u0016.\u000A();
					\u001E\u0003\u0016.\u000A(revisionData, \u0020\u0003\u0016.\u000A(u001F));
					\u001B\u0003\u0016.\u000A(revisionData, \u0011\u0003\u0016.\u000A(u001F));
					\u0008\u0003\u0016.\u000A(revisionData, \u001E\u0004\u0016.\u000A(u001F));
					\u000E\u0003\u0016.\u000A(revisionData, \u0020\u0004\u0016.\u000A(u001F));
					\u0010\u0003\u0016.\u000A(revisionData, \u000B\u0003\u0016.\u001D(u001F));
					\u001C\u0003\u0016.\u000A(revisionData, \u000D\u0003\u0016.\u0007(u001F));
					RevisionData u000A = revisionData;
					\u0003\u0003\u0016.\u000A(list, u000A);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionInfo.KO(List<RevisionData>)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x06001BE4 RID: 7140 RVA: 0x000B22F4 File Offset: 0x000B04F4
		public void RefreshRevisions()
		{
			if (\u0007\u001C\u0016.\u000A())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionInfo.RefreshRevisions()).MethodHandle;
				}
				\u000A\u001C\u0016.\u000A(\u0015\u0003\u0016.\u000A());
				\u0009\u0003\u0016.\u000A(\u001F\u001C\u0016.\u000A());
				\u000F\u0006\u0016.\u000A(false);
			}
			if (\u001A\u0003\u0016.\u000A(\u0015\u0003\u0016.\u000A()) == 0)
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
				\u0001\u0003\u0016.\u000A(\u0015\u0003\u0016.\u000A(), RevisionInfo.NO(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004)));
			}
			List<RevisionData> list = this.KO(\u0015\u0003\u0016.\u000A());
			List<RevisionData>.Enumerator enumerator = \u0014\u0004\u0016.\u000A(list);
			try
			{
				while (\u001B\u0004\u0016.\u000A(ref enumerator))
				{
					RevisionData u001F = \u0017\u0004\u0016.\u000A(ref enumerator);
					List<RevisionData>.Enumerator enumerator2 = \u0014\u0004\u0016.\u000A(\u0013\u0004\u0016.\u001D(this));
					try
					{
						while (\u001B\u0004\u0016.\u000A(ref enumerator2))
						{
							RevisionData u001F2 = \u0017\u0004\u0016.\u000A(ref enumerator2);
							if (!\u0020\u0004\u0016.\u000A(u001F2))
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
								if (\u000B\u0003\u0016.\u001D(u001F2) == \u000B\u0003\u0016.\u001D(u001F))
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
									if (\u001E\u0004\u0016.\u000A(u001F2))
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
										\u0008\u0003\u0016.\u000A(u001F, true);
									}
								}
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
					}
					finally
					{
						((IDisposable)enumerator2).Dispose();
					}
					if (!\u0020\u0004\u0016.\u000A(u001F))
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
						\u000C\u0003\u0016.\u000A(u001F, new RevisionData.RevisionCheckChangedHandler(this.JO));
					}
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			IEnumerable<RevisionData> enumerable = list;
			Func<RevisionData, bool> func;
			if ((func = RevisionInfo.<>c.\u000A) == null)
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
				func = (RevisionInfo.<>c.\u000A = new Func<RevisionData, bool>(RevisionInfo.<>c.\u001F.\u0018));
			}
			List<RevisionData> list2 = Enumerable.ToList<RevisionData>(Enumerable.Where<RevisionData>(enumerable, func));
			if (\u001A\u0003\u0016.\u000A(list2) > 0)
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
				RevisionData u001F3 = Enumerable.Last<RevisionData>(list2);
				\u0010\u0003\u0016.\u000A(\u0013\u0003\u0016.\u000A(list, 0), \u000B\u0003\u0016.\u001D(u001F3));
				\u0008\u0003\u0016.\u000A(\u0013\u0003\u0016.\u000A(list, 0), true);
			}
			else
			{
				\u0010\u0003\u0016.\u000A(\u0013\u0003\u0016.\u000A(list, 0), 0);
				\u0008\u0003\u0016.\u000A(\u0013\u0003\u0016.\u000A(list, 0), false);
			}
			\u001E\u0018\u0016.\u001D(this, list);
			\u0014\u0003\u0016.\u0007(this, \u0011\u0004\u0016.\u0007(\u0013\u0003\u0016.\u000A(\u0013\u0004\u0016.\u001D(this), 0)));
		}

		// Token: 0x06001BE5 RID: 7141 RVA: 0x000B255C File Offset: 0x000B075C
		private void JO(RevisionData F)
		{
			IEnumerable<RevisionData> enumerable = \u0013\u0004\u0016.\u001D(this);
			Func<RevisionData, bool> func;
			if ((func = RevisionInfo.<>c.\u0007) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionInfo.JO(RevisionData)).MethodHandle;
				}
				func = (RevisionInfo.<>c.\u0007 = new Func<RevisionData, bool>(RevisionInfo.<>c.\u001F.\u0005));
			}
			List<RevisionData> list = Enumerable.ToList<RevisionData>(Enumerable.Where<RevisionData>(enumerable, func));
			if (\u001A\u0003\u0016.\u000A(list) > 0)
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
				RevisionData u001F = Enumerable.LastOrDefault<RevisionData>(list);
				\u0014\u0003\u0016.\u0007(this, \u0011\u0004\u0016.\u0007(u001F));
				\u0010\u0003\u0016.\u000A(\u0013\u0003\u0016.\u000A(\u0013\u0004\u0016.\u001D(this), 0), \u000B\u0003\u0016.\u001D(u001F));
				\u0008\u0003\u0016.\u000A(\u0013\u0003\u0016.\u000A(\u0013\u0004\u0016.\u001D(this), 0), true);
			}
			else
			{
				\u0014\u0003\u0016.\u0007(this, "");
				\u0010\u0003\u0016.\u000A(\u0013\u0003\u0016.\u000A(\u0013\u0004\u0016.\u001D(this), 0), 0);
				\u0008\u0003\u0016.\u000A(\u0013\u0003\u0016.\u000A(\u0013\u0004\u0016.\u001D(this), 0), false);
			}
			RevisionInfo.RevisionsEditedHandler revisionEdited = this.RevisionEdited;
			if (revisionEdited == null)
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
				return;
			}
			\u001D\u001C\u0016.\u000A(revisionEdited, F);
		}

		// Token: 0x170007C0 RID: 1984
		// (get) Token: 0x06001BE6 RID: 7142 RVA: 0x000B2668 File Offset: 0x000B0868
		// (set) Token: 0x06001BE7 RID: 7143 RVA: 0x000B267C File Offset: 0x000B087C
		public string CurrentRevision
		{
			get
			{
				return this._currentRevision;
			}
			set
			{
				if (\u001D\u0017\u000A.\u000A(value, \u000A\u0012\u0016.\u000A()))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionInfo.set_CurrentRevision(string)).MethodHandle;
					}
					if (\u001D\u0017\u000A.\u000A(this._currentRevision, value))
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
						this._currentRevision = value;
						\u0002\u0003\u0016.\u0007(this);
						RevisionInfo.RevisionChangedHandler rs = RevisionInfo.RS;
						if (rs == null)
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
							return;
						}
						\u0004\u001C\u0016.\u000A(rs);
					}
				}
			}
		}

		// Token: 0x06001BE8 RID: 7144 RVA: 0x000B26F0 File Offset: 0x000B08F0
		public void CopyRevisions(List<RevisionData> revisions)
		{
			\u000A\u001C\u0016.\u000A(\u0013\u0004\u0016.\u001D(this));
			List<RevisionData>.Enumerator enumerator = \u0014\u0004\u0016.\u000A(revisions);
			try
			{
				while (\u001B\u0004\u0016.\u000A(ref enumerator))
				{
					RevisionData u001F = \u0017\u0004\u0016.\u000A(ref enumerator);
					RevisionData revisionData = \u0017\u0003\u0016.\u000A();
					\u000E\u0003\u0016.\u000A(revisionData, \u0020\u0004\u0016.\u000A(u001F));
					\u0008\u0003\u0016.\u000A(revisionData, \u001E\u0004\u0016.\u000A(u001F));
					\u0010\u0003\u0016.\u000A(revisionData, \u000B\u0003\u0016.\u001D(u001F));
					\u001E\u0003\u0016.\u000A(revisionData, \u0020\u0003\u0016.\u000A(u001F));
					\u001B\u0003\u0016.\u000A(revisionData, \u0011\u0003\u0016.\u000A(u001F));
					RevisionData revisionData2 = revisionData;
					if (!\u0020\u0004\u0016.\u000A(revisionData2))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionInfo.CopyRevisions(List<RevisionData>)).MethodHandle;
						}
						\u000C\u0003\u0016.\u000A(revisionData2, new RevisionData.RevisionCheckChangedHandler(this.JO));
					}
					\u0003\u0003\u0016.\u000A(\u0013\u0004\u0016.\u001D(this), revisionData2);
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
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06001BE9 RID: 7145 RVA: 0x000B27E8 File Offset: 0x000B09E8
		public void RefreshRevisionParameters()
		{
			string text = this._currentRevision;
			if (\u001A\u0006\u0007.\u000A(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionInfo.RefreshRevisionParameters()).MethodHandle;
				}
				text = "empty";
			}
			if (!\u0008\u001C\u0016.\u000A(\u001F\u001C\u0016.\u000A(), text))
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
				\u0016\u001C\u0016.\u000A(\u0005\u001C\u0016.\u0007(this));
				List<RevisionParameter>.Enumerator enumerator = \u0010\u001C\u0016.\u000A(\u000E\u001C\u0016.\u0007(ParametersManagerService.\u0008));
				try
				{
					while (\u000B\u001C\u0016.\u000A(ref enumerator))
					{
						RevisionParameter u001F = \u000D\u001C\u0016.\u000A(ref enumerator);
						RevisionParameter revisionParameter = \u001C\u001C\u0016.\u000A();
						\u0012\u001C\u0016.\u0007(revisionParameter, \u0003\u001C\u0016.\u000A(u001F));
						\u0006\u001C\u0016.\u0007(revisionParameter, \u000F\u001C\u0016.\u0007(u001F));
						RevisionParameter u000A = revisionParameter;
						\u0002\u001C\u0016.\u000A(\u0005\u001C\u0016.\u0007(this), u000A);
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
				this.EO();
				return;
			}
			\u0016\u001C\u0016.\u000A(\u0005\u001C\u0016.\u0007(this));
			object u001F2 = \u0005\u001C\u0016.\u0007(this);
			IEnumerable<RevisionParameter> enumerable = \u0018\u001C\u0016.\u000A(\u001F\u001C\u0016.\u000A(), text);
			Func<RevisionParameter, RevisionParameter> func;
			if ((func = RevisionInfo.<>c.\u001D) == null)
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
				func = (RevisionInfo.<>c.\u001D = new Func<RevisionParameter, RevisionParameter>(RevisionInfo.<>c.\u001F.\u0016));
			}
			\u0019\u001C\u0016.\u000A(u001F2, Enumerable.Select<RevisionParameter, RevisionParameter>(enumerable, func));
		}

		// Token: 0x06001BEA RID: 7146 RVA: 0x000B2934 File Offset: 0x000B0B34
		private void EO()
		{
			RevisionData revisionData = Enumerable.FirstOrDefault<RevisionData>(\u0013\u0004\u0016.\u001D(this), new Func<RevisionData, bool>(this.MO));
			Revision revision;
			if (revisionData == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionInfo.EO()).MethodHandle;
				}
				revision = \u0007\u001C\u000E.\u001F;
			}
			else
			{
				revision = \u000D\u0003\u0016.\u001D(revisionData);
			}
			Revision u000A = revision;
			List<RevisionParameter>.Enumerator enumerator = \u0010\u001C\u0016.\u000A(\u0005\u001C\u0016.\u0007(this));
			try
			{
				while (\u000B\u001C\u0016.\u000A(ref enumerator))
				{
					\u001B\u001C\u0016.\u000A(\u000D\u001C\u0016.\u000A(ref enumerator), u000A, this._sheetInfo);
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
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06001BEB RID: 7147 RVA: 0x000B29E0 File Offset: 0x000B0BE0
		internal static List<RevisionData> NO(Document F)
		{
			List<RevisionData> list = \u0012\u0003\u0016.\u000A();
			IEnumerator<Element> enumerator = \u0009\u000C\u0004.\u000A(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(F), \u001E\u0011\u000A.\u000A(\u001F\u001C\u000E.\u001F())));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					Revision revision = \u000A\u001C\u000E.\u001F(\u0001\u000C\u0004.\u000A(enumerator));
					RevisionData revisionData = \u0017\u0003\u0016.\u000A();
					\u000E\u0003\u0016.\u000A(revisionData, false);
					\u0008\u0003\u0016.\u000A(revisionData, false);
					\u0010\u0003\u0016.\u000A(revisionData, \u0013\u001C\u0016.\u000A(revision));
					\u001C\u0003\u0016.\u000A(revisionData, revision);
					RevisionData revisionData2 = revisionData;
					string text = " - ";
					try
					{
						if (\u0012\u0003\u0018.\u0007(\u0016\u0018\u0007.\u0007(revision, -1011951L)))
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionInfo.NO(Document)).MethodHandle;
							}
							if (!\u001A\u0006\u0007.\u000A(\u0014\u001C\u0016.\u000A(revision)))
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
								text = \u0002\u0013\u000A.\u000A(text, "No. ", \u0014\u001C\u0016.\u000A(revision));
							}
						}
						if (\u0012\u0003\u0018.\u0007(\u0016\u0018\u0007.\u0007(revision, -1011952L)))
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
							if (!\u001A\u0006\u0007.\u000A(\u0017\u001C\u0016.\u000A(revision)))
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
								text = \u0002\u0013\u000A.\u000A(text, " - ", \u0017\u001C\u0016.\u000A(revision));
							}
						}
						if (\u0012\u0003\u0018.\u0007(\u0016\u0018\u0007.\u0007(revision, -1011953L)))
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
							if (!\u001A\u0006\u0007.\u000A(\u0020\u001C\u0016.\u000A(revision)))
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
								text = \u0002\u0013\u000A.\u000A(text, " - ", \u0020\u001C\u0016.\u000A(revision));
							}
						}
					}
					catch (Exception u000A)
					{
						\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Models\\SheetsAggregate\\RevisionInfo.cs", "GetAllRevisions");
					}
					\u001E\u0003\u0016.\u000A(revisionData2, text);
					\u001B\u0003\u0016.\u000A(revisionData2, 180);
					\u0003\u0003\u0016.\u000A(list, revisionData2);
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
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			object u001F = list;
			Comparison<RevisionData> u000A2;
			if ((u000A2 = RevisionInfo.<>c.\u0004) == null)
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
				u000A2 = (RevisionInfo.<>c.\u0004 = new Comparison<RevisionData>(RevisionInfo.<>c.\u001F.\u000B));
			}
			\u001E\u001C\u0016.\u000A(u001F, u000A2);
			RevisionData revisionData3 = \u0017\u0003\u0016.\u000A();
			\u000E\u0003\u0016.\u000A(revisionData3, true);
			\u001E\u0003\u0016.\u000A(revisionData3, "");
			\u001B\u0003\u0016.\u000A(revisionData3, 0);
			RevisionData revisionData4 = revisionData3;
			IEnumerable<RevisionData> enumerable = list;
			Func<RevisionData, bool> func;
			if ((func = RevisionInfo.<>c.\u0019) == null)
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
				func = (RevisionInfo.<>c.\u0019 = new Func<RevisionData, bool>(RevisionInfo.<>c.\u001F.\u0002));
			}
			List<RevisionData> list2 = Enumerable.ToList<RevisionData>(Enumerable.Where<RevisionData>(enumerable, func));
			if (\u001A\u0003\u0016.\u000A(list2) > 0)
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
				RevisionData u001F2 = Enumerable.LastOrDefault<RevisionData>(list2);
				\u0010\u0003\u0016.\u000A(revisionData4, \u000B\u0003\u0016.\u001D(u001F2));
				\u0008\u0003\u0016.\u000A(revisionData4, true);
			}
			else
			{
				\u0010\u0003\u0016.\u000A(revisionData4, 0);
				\u0008\u0003\u0016.\u000A(revisionData4, false);
			}
			\u0011\u001C\u0016.\u000A(list, 0, revisionData4);
			return list;
		}

		// Token: 0x06001BEC RID: 7148 RVA: 0x000B2CE8 File Offset: 0x000B0EE8
		public void UpdateParameters(List<RevisionParameter> parameters)
		{
			RevisionInfo.\u0016\u001B u0016_u001B = new RevisionInfo.\u0016\u001B();
			u0016_u001B.\u001F = parameters;
			List<RevisionParameter>.Enumerator enumerator = \u0010\u001C\u0016.\u000A(Enumerable.ToList<RevisionParameter>(\u0005\u001C\u0016.\u0007(this)));
			try
			{
				while (\u000B\u001C\u0016.\u000A(ref enumerator))
				{
					RevisionParameter u000A = \u000D\u001C\u0016.\u000A(ref enumerator);
					if (!u0016_u001B.\u001F.\u000A(u000A))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionInfo.UpdateParameters(List<RevisionParameter>)).MethodHandle;
						}
						\u000C\u001C\u0016.\u000A(\u0005\u001C\u0016.\u0007(this), u000A);
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u0006\u0003\u0016.\u000A(this, \u001A\u001C\u0016.\u000A(Enumerable.OrderBy<RevisionParameter, int>(\u0005\u001C\u0016.\u0007(this), new Func<RevisionParameter, int>(u0016_u001B.\u000A))));
		}

		// Token: 0x06001BED RID: 7149 RVA: 0x000B2DB8 File Offset: 0x000B0FB8
		[CompilerGenerated]
		private bool MO(RevisionData F)
		{
			if (!\u0020\u0004\u0016.\u000A(F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionInfo.MO(RevisionData)).MethodHandle;
				}
				int num = \u000B\u0003\u0016.\u001D(F);
				return \u0008\u0013\u000A.\u000A(\u000C\u0013\u0007.\u000A(ref num), this._currentRevision);
			}
			return false;
		}

		// Token: 0x04000B3D RID: 2877
		private string _currentRevision = "";

		// Token: 0x04000B3E RID: 2878
		private SheetInfo _sheetInfo;

		// Token: 0x04000B42 RID: 2882
		[CompilerGenerated]
		private static bool DS;

		// Token: 0x04000B43 RID: 2883
		[CompilerGenerated]
		private static List<RevisionData> HS;

		// Token: 0x04000B44 RID: 2884
		[CompilerGenerated]
		private static Dictionary<string, List<RevisionParameter>> YS;

		// Token: 0x02000988 RID: 2440
		// (Invoke) Token: 0x06005315 RID: 21269
		public delegate void RevisionChangedHandler();

		// Token: 0x02000989 RID: 2441
		// (Invoke) Token: 0x06005319 RID: 21273
		public delegate void RevisionsEditedHandler(RevisionData data);

		// Token: 0x0200098B RID: 2443
		[CompilerGenerated]
		private sealed class \u0016\u001B
		{
			// Token: 0x06005324 RID: 21284 RVA: 0x001EBEA4 File Offset: 0x001EA0A4
			internal int \u000A(RevisionParameter \u001F)
			{
				RevisionInfo.\u000B\u001B u000B_u001B = new RevisionInfo.\u000B\u001B();
				u000B_u001B.\u001F = \u001F;
				return \u001A\u0002\u0010.\u000A(this.\u001F, new Predicate<RevisionParameter>(u000B_u001B.\u000A));
			}

			// Token: 0x040024E2 RID: 9442
			public List<RevisionParameter> \u001F;
		}

		// Token: 0x0200098C RID: 2444
		[CompilerGenerated]
		private sealed class \u000B\u001B
		{
			// Token: 0x06005326 RID: 21286 RVA: 0x001EBEEC File Offset: 0x001EA0EC
			internal bool \u000A(RevisionParameter \u001F)
			{
				return \u000F\u001C\u0016.\u0007(\u001F) == \u000F\u001C\u0016.\u0007(this.\u001F);
			}

			// Token: 0x040024E3 RID: 9443
			public RevisionParameter \u001F;
		}
	}
}
