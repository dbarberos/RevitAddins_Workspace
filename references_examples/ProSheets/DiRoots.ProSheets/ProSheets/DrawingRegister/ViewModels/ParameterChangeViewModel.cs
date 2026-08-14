using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using A;
using DiRoots.One.Commons.ViewModels;
using ProSheets.Extensions;

namespace ProSheets.DrawingRegister.ViewModels
{
	// Token: 0x02000109 RID: 265
	public class ParameterChangeViewModel : ViewModelBase
	{
		// Token: 0x06000D24 RID: 3364 RVA: 0x0004DCFC File Offset: 0x0004BEFC
		public ParameterChangeViewModel(string parameter)
		{
			\u0017\u0001\u0016.\u0018(this, parameter);
		}

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x06000D25 RID: 3365 RVA: 0x0004DD18 File Offset: 0x0004BF18
		// (set) Token: 0x06000D26 RID: 3366 RVA: 0x0004DD2C File Offset: 0x0004BF2C
		public string ParameterName
		{
			get
			{
				return this.\u000D\u0016;
			}
			set
			{
				if (\u0009\u001E\u0018.\u0018(this.\u000D\u0016, value))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterChangeViewModel.set_ParameterName(string)).MethodHandle;
					}
					this.\u000D\u0016 = value;
					\u0011\u0010\u0018.\u0018(this, "ParameterName");
				}
			}
		}

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x06000D27 RID: 3367 RVA: 0x0004DD70 File Offset: 0x0004BF70
		// (set) Token: 0x06000D28 RID: 3368 RVA: 0x0004DD84 File Offset: 0x0004BF84
		public Action ParameterNameChanged { get; set; }

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x06000D29 RID: 3369 RVA: 0x0004DD98 File Offset: 0x0004BF98
		// (set) Token: 0x06000D2A RID: 3370 RVA: 0x0004DDAC File Offset: 0x0004BFAC
		public string SelectedParameterText { get; set; }

		// Token: 0x06000D2B RID: 3371 RVA: 0x0004DDC0 File Offset: 0x0004BFC0
		[BindableMethod("UpdateParameterName")]
		public void UpdateParameterName()
		{
			if (!\u001F\u001A\u0018.\u0018(\u0002\u0001\u0016.\u0014(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterChangeViewModel.UpdateParameterName()).MethodHandle;
				}
				object u000C = \u000D\u0006\u000F.\u000C(\u0001\u000C\u0014.\u0018(this));
				Action action = \u001E\u0001\u0016.\u0018(this);
				if (action == null)
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
				}
				else
				{
					\u000D\u0005\u0003.\u0018(action);
				}
				\u000B\u000B\u0018.\u0014(u000C);
			}
		}

		// Token: 0x06000D2C RID: 3372 RVA: 0x0004DE24 File Offset: 0x0004C024
		[BindableMethod("TextValidationOnPreviewTextInput")]
		public void TextValidationOnPreviewTextInput(TextCompositionEventArgs e)
		{
			bool u;
			if (!\u001F\u001A\u0018.\u0018(\u000E\u0020\u0003.\u0018(e)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterChangeViewModel.TextValidationOnPreviewTextInput(TextCompositionEventArgs)).MethodHandle;
				}
				u = \u001F\u000B\u0018.\u0018(\u000E\u0020\u0003.\u0018(e));
			}
			else
			{
				u = true;
			}
			\u001D\u000B\u0018.\u0018(e, u);
		}

		// Token: 0x040005ED RID: 1517
		private string \u000D\u0016;

		// Token: 0x040005EE RID: 1518
		[CompilerGenerated]
		private Action \u001C\u0016;

		// Token: 0x040005EF RID: 1519
		[CompilerGenerated]
		private string \u0013\u0016;
	}
}
