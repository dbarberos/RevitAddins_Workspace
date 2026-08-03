using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using A;
using ProSheets.Commons.CustomNameManageWindow.Models;
using ProSheets.Commons.CustomNameManageWindow.Models.Interfaces;
using ProSheets.Commons.CustomNameManageWindow.UI.Windows;

namespace ProSheets.Models
{
	// Token: 0x020000FF RID: 255
	public class CustomParameterModel
	{
		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x06000C79 RID: 3193 RVA: 0x00049EBC File Offset: 0x000480BC
		// (set) Token: 0x06000C7A RID: 3194 RVA: 0x00049ED0 File Offset: 0x000480D0
		public bool IsFileNameSet { get; set; }

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x06000C7B RID: 3195 RVA: 0x00049EE4 File Offset: 0x000480E4
		// (set) Token: 0x06000C7C RID: 3196 RVA: 0x00049EF8 File Offset: 0x000480F8
		public string FileName { get; set; }

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x06000C7D RID: 3197 RVA: 0x00049F0C File Offset: 0x0004810C
		// (set) Token: 0x06000C7E RID: 3198 RVA: 0x00049F20 File Offset: 0x00048120
		public List<IParameterModel> AvailableParameter { get; set; }

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06000C7F RID: 3199 RVA: 0x00049F34 File Offset: 0x00048134
		// (set) Token: 0x06000C80 RID: 3200 RVA: 0x00049F48 File Offset: 0x00048148
		public Parameters SelectedParameter { get; set; }

		// Token: 0x06000C81 RID: 3201 RVA: 0x00049F5C File Offset: 0x0004815C
		public CustomParameterModel CustomNameMangerExecute(Window window)
		{
			CustomParameterModel customParameterModel = \u0008\u0004\u0016.\u0018();
			List<IParameterModel> u = \u001C\u0014\u0003.\u0018();
			if (!\u0013\u0009\u0003.\u0003(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CustomParameterModel.CustomNameMangerExecute(Window)).MethodHandle;
				}
				if (\u001C\u000A\u0003.\u0003(this) != null)
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
					u = Enumerable.ToList<IParameterModel>(Enumerable.OfType<IParameterModel>(\u0013\u0019\u0014.\u0018(\u001C\u000A\u0003.\u0003(this))));
				}
			}
			CustomNameManager u000C = \u000D\u0014\u0003.\u0018(false, \u0007\u0004\u0016.\u0018(this), u, \u0012\u000A\u0003.\u0003(this), true);
			\u0012\u000A\u0014.\u0018(u000C, window);
			bool? flag = \u001E\u0007\u0018.\u0014(u000C);
			if (\u000C\u0007\u0018.\u0018(ref flag))
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
				\u0009\u0009\u0003.\u0003(this, \u0006\u0004\u0016.\u0014(\u0005\u000B\u000F.\u000C(\u0003\u0012\u0014.\u0014(u000C))));
				if (\u0013\u0009\u0003.\u0003(this))
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
					\u0012\u0009\u0003.\u0003(this, \u0010\u0004\u0016.\u0018(\u0005\u000B\u000F.\u000C(\u0003\u0012\u0014.\u0014(u000C))));
				}
				else
				{
					\u0020\u0009\u0003.\u0003(this, \u0012\u0014\u0003.\u0018(\u0005\u000B\u000F.\u000C(\u0003\u0012\u0014.\u0014(u000C))));
				}
			}
			\u0009\u0009\u0003.\u0014(customParameterModel, \u0013\u0009\u0003.\u0003(this));
			\u0012\u0009\u0003.\u0014(customParameterModel, \u0012\u000A\u0003.\u0003(this));
			\u001B\u0013\u0003.\u0018(customParameterModel, \u0007\u0004\u0016.\u0018(this));
			\u0020\u0009\u0003.\u0014(customParameterModel, \u001C\u000A\u0003.\u0003(this));
			return customParameterModel;
		}

		// Token: 0x040005B6 RID: 1462
		[CompilerGenerated]
		private bool \u000C;

		// Token: 0x040005B7 RID: 1463
		[CompilerGenerated]
		private string \u0018;

		// Token: 0x040005B8 RID: 1464
		[CompilerGenerated]
		private List<IParameterModel> \u0014;

		// Token: 0x040005B9 RID: 1465
		[CompilerGenerated]
		private Parameters \u0003;
	}
}
