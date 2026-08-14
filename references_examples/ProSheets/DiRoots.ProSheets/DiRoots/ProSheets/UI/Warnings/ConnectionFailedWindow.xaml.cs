using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;

namespace DiRoots.ProSheets.UI.Warnings
{
	// Token: 0x02000046 RID: 70
	public partial class ConnectionFailedWindow : DiRootsWindow
	{
		// Token: 0x060002CF RID: 719 RVA: 0x00010510 File Offset: 0x0000E710
		public ConnectionFailedWindow(Exception ex)
		{
			\u001C\u0009\u0014.\u0018(this);
			this.EN(ex);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00010530 File Offset: 0x0000E730
		private void EN(Exception P)
		{
			FlowDocument flowDocument = \u001D\u0009\u0014.\u0018();
			Paragraph paragraph = \u0017\u0009\u0014.\u0018();
			\u0020\u0009\u0014.\u0018(\u0011\u0009\u0014.\u0018(paragraph), \u0015\u0009\u0014.\u0018(\u001F\u0009\u0014.\u0018(this.JZ("PS-ConnectionFailed-ErrorType"))));
			\u0020\u0009\u0014.\u0018(\u0011\u0009\u0014.\u0018(paragraph), \u001F\u0009\u0014.\u0018(\u0002\u0009\u0014.\u0018(\u0004\u0009\u0014.\u0018(P))));
			\u0009\u0009\u0014.\u0018(\u000A\u0009\u0014.\u0018(flowDocument), paragraph);
			paragraph = \u0017\u0009\u0014.\u0018();
			\u0020\u0009\u0014.\u0018(\u0011\u0009\u0014.\u0018(paragraph), \u0015\u0009\u0014.\u0018(\u001F\u0009\u0014.\u0018(this.JZ("PS-ConnectionFailed-ErrorMessage"))));
			\u0020\u0009\u0014.\u0018(\u0011\u0009\u0014.\u0018(paragraph), \u001F\u0009\u0014.\u0018(\u000A\u0001\u0018.\u0018(P)));
			\u0009\u0009\u0014.\u0018(\u000A\u0009\u0014.\u0018(flowDocument), paragraph);
			Exception ex = \u001E\u0009\u0014.\u0018(P);
			string text;
			if (ex == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ConnectionFailedWindow.EN(Exception)).MethodHandle;
				}
				text = null;
			}
			else
			{
				text = \u000A\u0001\u0018.\u0018(ex);
			}
			string text2;
			if ((text2 = text) == null)
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
				text2 = string.Empty;
			}
			string u000C = text2;
			if (!\u001F\u001A\u0018.\u0018(u000C))
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
				paragraph = \u0017\u0009\u0014.\u0018();
				\u0020\u0009\u0014.\u0018(\u0011\u0009\u0014.\u0018(paragraph), \u0015\u0009\u0014.\u0018(\u001F\u0009\u0014.\u0018(this.JZ("PS-ConnectionFailed-InnerException"))));
				\u0020\u0009\u0014.\u0018(\u0011\u0009\u0014.\u0018(paragraph), \u001F\u0009\u0014.\u0018(u000C));
				\u0009\u0009\u0014.\u0018(\u000A\u0009\u0014.\u0018(flowDocument), paragraph);
			}
			\u0013\u0009\u0014.\u0018(this.KQ, flowDocument);
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x000106B0 File Offset: 0x0000E8B0
		private string JZ(string P)
		{
			string result;
			if ((result = \u0014\u0004\u000F.\u000C(\u001A\u0009\u0014.\u0014(this, P))) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ConnectionFailedWindow.JZ(string)).MethodHandle;
				}
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x000106EC File Offset: 0x0000E8EC
		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			\u000B\u000B\u0018.\u0003(this);
		}
	}
}
