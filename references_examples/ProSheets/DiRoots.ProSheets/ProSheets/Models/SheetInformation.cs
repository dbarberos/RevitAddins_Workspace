using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using ProSheets.Commons.CustomNameManageWindow.Enums;
using ProSheets.Commons.CustomNameManageWindow.Models;
using ProSheets.DrawingRegister.Model;

namespace ProSheets.Models
{
	// Token: 0x020000F8 RID: 248
	[Serializable]
	public class SheetInformation : ModelBase
	{
		// Token: 0x06000BFC RID: 3068 RVA: 0x00048BD8 File Offset: 0x00046DD8
		public SheetInformation(ViewSheet sheet)
		{
			\u001A\u0002\u0016.\u0018(this, sheet);
			\u001D\u0002\u0016.\u0014(this, new List<ParameterInformation>());
			this.QQ();
		}

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x06000BFD RID: 3069 RVA: 0x00048C04 File Offset: 0x00046E04
		// (set) Token: 0x06000BFE RID: 3070 RVA: 0x00048C18 File Offset: 0x00046E18
		[XmlIgnore]
		public ViewSheet ViewSheet { get; set; }

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x06000BFF RID: 3071 RVA: 0x00048C2C File Offset: 0x00046E2C
		public string SheetName
		{
			get
			{
				return \u001E\u0016\u0014.\u0018(\u000B\u0002\u0016.\u0014(this));
			}
		}

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x06000C00 RID: 3072 RVA: 0x00048C48 File Offset: 0x00046E48
		public string SheetNumber
		{
			get
			{
				return \u001E\u001D\u0014.\u0018(\u000B\u0002\u0016.\u0014(this));
			}
		}

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x06000C01 RID: 3073 RVA: 0x00048C64 File Offset: 0x00046E64
		public string SheetNameAndNumber
		{
			get
			{
				return \u0014\u001E\u0018.\u0018(\u0007\u0002\u0016.\u0014(this), " - ", \u0019\u0002\u0016.\u0018(this));
			}
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x06000C02 RID: 3074 RVA: 0x00048C90 File Offset: 0x00046E90
		public long SheetId
		{
			get
			{
				return \u0009\u0002\u0018.\u0018(\u000B\u0002\u0016.\u0014(this)).\u000C();
			}
		}

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x06000C03 RID: 3075 RVA: 0x00048CB4 File Offset: 0x00046EB4
		// (set) Token: 0x06000C04 RID: 3076 RVA: 0x00048CC8 File Offset: 0x00046EC8
		public bool IsLinkDoc { get; set; }

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x06000C05 RID: 3077 RVA: 0x00048CDC File Offset: 0x00046EDC
		public string UniqueId
		{
			get
			{
				return \u001E\u0002\u0016.\u0018(\u000B\u0002\u0016.\u0014(this));
			}
		}

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x06000C06 RID: 3078 RVA: 0x00048CF8 File Offset: 0x00046EF8
		// (set) Token: 0x06000C07 RID: 3079 RVA: 0x00048D0C File Offset: 0x00046F0C
		public RevisionInformation CurrentRevision { get; set; }

		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x06000C08 RID: 3080 RVA: 0x00048D20 File Offset: 0x00046F20
		// (set) Token: 0x06000C09 RID: 3081 RVA: 0x00048D34 File Offset: 0x00046F34
		public List<RevisionInformation> AllRevision { get; set; }

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06000C0A RID: 3082 RVA: 0x00048D48 File Offset: 0x00046F48
		// (set) Token: 0x06000C0B RID: 3083 RVA: 0x00048D5C File Offset: 0x00046F5C
		public List<ParameterInformation> Parameters { get; set; }

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06000C0C RID: 3084 RVA: 0x00048D70 File Offset: 0x00046F70
		// (set) Token: 0x06000C0D RID: 3085 RVA: 0x00048D84 File Offset: 0x00046F84
		public Dictionary<string, string> AllRevisionWithRevisionNumber { get; set; }

		// Token: 0x06000C0E RID: 3086 RVA: 0x00048D98 File Offset: 0x00046F98
		private void QQ()
		{
			\u0003\u0004\u0016.\u0018(this, \u0016\u0004\u0016.\u0018());
			object u000C = \u0014\u0004\u0016.\u0018(\u000B\u0002\u0016.\u0014(this));
			ElementId u = \u0018\u0004\u0016.\u0018(\u000B\u0002\u0016.\u0014(this));
			\u000C\u0004\u0016.\u0018(this, \u0011\u0013\u0016.\u0018());
			IEnumerator<ElementId> enumerator = \u0015\u001E\u0018.\u0018(u000C);
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator))
				{
					ElementId elementId = \u0011\u001E\u0018.\u0018(enumerator);
					Revision u000C2 = \u000C\u0006\u000F.\u000C(\u0003\u0004\u0018.\u0018(\u000E\u0002\u0016.\u0018(\u000B\u0002\u0016.\u0014(this)), elementId));
					if (\u0016\u0008\u0014.\u0018(elementId, u))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInformation.QQ()).MethodHandle;
						}
						\u0005\u0002\u0016.\u0018(this, \u0001\u0002\u0016.\u0018(u000C2));
					}
					\u0008\u0002\u0016.\u0018(\u001B\u0002\u0016.\u0014(this), \u0001\u0002\u0016.\u0018(u000C2));
					string text = \u0006\u0002\u0016.\u0018(\u000B\u0002\u0016.\u0014(this), elementId);
					if (!\u001F\u001A\u0018.\u0018(text))
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
						\u001D\u000B\u0014.\u0018(\u0010\u0002\u0016.\u0014(this), \u001E\u0002\u0016.\u0018(u000C2), text);
					}
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
		}

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06000C0F RID: 3087 RVA: 0x00048ED0 File Offset: 0x000470D0
		// (set) Token: 0x06000C10 RID: 3088 RVA: 0x00048EE4 File Offset: 0x000470E4
		public bool IsChecked
		{
			get
			{
				return this._isChecked;
			}
			set
			{
				this._isChecked = value;
				\u0007\u001B\u0018.\u0018(this, "IsChecked");
			}
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x00048F04 File Offset: 0x00047104
		public static bool CheckingRevision(SheetInformation sheetInformation, string uniqueId)
		{
			IEnumerable<RevisionInformation> enumerable = \u001B\u0002\u0016.\u0003(sheetInformation);
			Func<RevisionInformation, string> func;
			if ((func = SheetInformation.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInformation.CheckingRevision(SheetInformation, string)).MethodHandle;
				}
				func = (SheetInformation.<>c.\u0018 = new Func<RevisionInformation, string>(SheetInformation.<>c.\u000C.\u0014));
			}
			return Enumerable.Contains<string>(Enumerable.Select<RevisionInformation, string>(enumerable, func), uniqueId);
		}

		// Token: 0x06000C12 RID: 3090 RVA: 0x00048F5C File Offset: 0x0004715C
		public void UpdateParameterValue()
		{
			List<ParameterInformation>.Enumerator enumerator = \u0020\u0004\u0016.\u0018(\u001F\u0004\u0016.\u0014(this));
			try
			{
				while (\u000F\u0004\u0016.\u0018(ref enumerator))
				{
					ParameterInformation u000C = \u000A\u0004\u0016.\u0018(ref enumerator);
					if (\u0009\u0004\u0016.\u0014(u000C) == ParameterType.InstnaceParameter)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInformation.UpdateParameterValue()).MethodHandle;
						}
						\u0012\u0004\u0016.\u0014(u000C, this.JQ(\u000D\u0004\u0016.\u0018(u000C), false));
					}
					else if (\u0009\u0004\u0016.\u0014(u000C) == ParameterType.CombinedParameter)
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
						StringBuilder u000C2 = \u0005\u0017\u0018.\u0018();
						int num = 1;
						List<ParameterModel>.Enumerator enumerator2 = \u0019\u0019\u0014.\u0018(\u0013\u0004\u0016.\u0018(u000C));
						try
						{
							while (\u0020\u0019\u0014.\u0018(ref enumerator2))
							{
								ParameterModel u000C3 = \u000B\u0019\u0014.\u0018(ref enumerator2);
								StringBuilder stringBuilder = \u0005\u0017\u0018.\u0018();
								\u0017\u0020\u0014.\u0018(stringBuilder, \u001A\u0019\u0014.\u0018(u000C3));
								\u0017\u0020\u0014.\u0018(stringBuilder, this.JQ(\u0010\u0019\u0014.\u0018(u000C3), \u0006\u0019\u0014.\u0018(u000C3)));
								\u0017\u0020\u0014.\u0018(stringBuilder, \u0002\u0019\u0014.\u0018(u000C3));
								if (num != \u001C\u0004\u0016.\u0018(\u0013\u0004\u0016.\u0018(u000C)))
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
									\u0017\u0020\u0014.\u0018(stringBuilder, \u0015\u0019\u0014.\u0018(u000C3));
								}
								num++;
								\u001F\u0019\u0014.\u0018(u000C2, stringBuilder);
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
							((IDisposable)enumerator2).Dispose();
						}
						\u0012\u0004\u0016.\u0014(u000C, \u0001\u0017\u0018.\u0018(u000C2));
					}
					else
					{
						\u0012\u0004\u0016.\u0014(u000C, \u001C\u001A\u0014.\u0018(\u0017\u001D\u0014.\u0018(\u000E\u0002\u0018.\u0018(\u000E\u0002\u0016.\u0018(\u000B\u0002\u0016.\u0014(this))), \u000D\u0004\u0016.\u0018(u000C))));
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
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x0004915C File Offset: 0x0004735C
		private string JQ(long P, bool Q = false)
		{
			Parameter parameter = \u0005\u001A\u000F.\u000C;
			if (Q)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInformation.JQ(long, bool)).MethodHandle;
				}
				parameter = \u0017\u001D\u0014.\u0018(\u000E\u0002\u0018.\u0018(\u000E\u0002\u0016.\u0018(\u000B\u0002\u0016.\u0014(this))), P);
			}
			else
			{
				parameter = \u0017\u001D\u0014.\u0018(\u000B\u0002\u0016.\u0014(this), P);
			}
			string result = string.Empty;
			if (parameter != null)
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
				result = \u001C\u001A\u0014.\u0018(parameter);
			}
			return result;
		}

		// Token: 0x04000587 RID: 1415
		private bool _isChecked;
	}
}
