using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.Commons.WindowControl;
using ProSheets.Commons.CustomNameManageWindow.Enums;
using ProSheets.DrawingRegister.Model;
using ProSheets.DrawingRegister.ViewModels;

namespace ProSheets.DrawingRegister.UI.Windows
{
	// Token: 0x02000111 RID: 273
	public partial class ParameterTransfer : DiRootsWindow, IStyleConnector
	{
		// Token: 0x06000E1E RID: 3614 RVA: 0x00052EA0 File Offset: 0x000510A0
		public ParameterTransfer(List<ParameterInformation> selectParameter, bool IsLinkedFile)
		{
			\u0004\u0003\u000F.\u0018(this);
			ParameterTransferViewModel parameterTransferViewModel = new ParameterTransferViewModel(selectParameter, IsLinkedFile);
			\u000B\u0005\u0018.\u0014(parameterTransferViewModel, this);
			this.JN = parameterTransferViewModel;
			\u001C\u000B\u0018.\u0003(this, this.JN);
		}

		// Token: 0x06000E1F RID: 3615 RVA: 0x00052EDC File Offset: 0x000510DC
		private void DgSelect_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				TextBlock textBlock = \u0001\u0006\u000F.\u000C(\u0017\u0016\u0003.\u0018(e));
				if (textBlock == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterTransfer.DgSelect_MouseRightButtonDown(object, MouseButtonEventArgs)).MethodHandle;
					}
				}
				else
				{
					ParameterInformation parameterInformation = \u0012\u0006\u000F.\u000C(\u0003\u0012\u0014.\u0014(textBlock));
					if (parameterInformation != null)
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
						if (\u0009\u0004\u0016.\u0014(parameterInformation) != ParameterType.CombinedParameter)
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
						}
						else
						{
							\u0018\u000F\u0003.\u0018(this.NN, \u000B\u000B\u000F.\u000C(\u001A\u0009\u0014.\u0003(this.NN, "CombineParameterEdit")));
							\u001D\u0003\u000F.\u0018(this.JN, parameterInformation);
							\u0016\u000F\u0003.\u0018(\u0006\u0016\u0003.\u0018(this.NN), this.NN);
							\u0008\u0013\u0014.\u0018(\u0006\u0016\u0003.\u0018(this.NN), Visibility.Visible);
							\u0003\u000F\u0003.\u0018(\u0006\u0016\u0003.\u0018(this.NN), true);
						}
					}
				}
			}
			catch (Exception u)
			{
				\u0017\u001E\u0014.\u0018(\u0002\u0002\u0016.\u0018(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\UI\\Windows\\Parametertransfer.xaml.cs", "DgSelect_MouseRightButtonDown");
			}
		}

		// Token: 0x06000E20 RID: 3616 RVA: 0x00052FE8 File Offset: 0x000511E8
		private void ContextMenu_Closed(object sender, RoutedEventArgs e)
		{
			ContextMenu contextMenu = \u0008\u0006\u000F.\u000C(sender);
			if (contextMenu == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterTransfer.ContextMenu_Closed(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			\u0008\u0013\u0014.\u0018(contextMenu, Visibility.Collapsed);
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x00053064 File Offset: 0x00051264
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		internal Delegate TN(Type P, string Q)
		{
			return \u000E\u000B\u0018.\u0018(P, this, Q);
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x0005311C File Offset: 0x0005131C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		void IStyleConnector.WN(int P, object Q)
		{
			if (P == 6)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterTransfer.WN(int, object)).MethodHandle;
				}
				\u000B\u0003\u000F.\u0018(\u000C\u0004\u000F.\u000C(Q), new MouseButtonEventHandler(this.DgSelect_MouseRightButtonDown));
			}
		}

		// Token: 0x04000647 RID: 1607
		private ParameterTransferViewModel JN;
	}
}
