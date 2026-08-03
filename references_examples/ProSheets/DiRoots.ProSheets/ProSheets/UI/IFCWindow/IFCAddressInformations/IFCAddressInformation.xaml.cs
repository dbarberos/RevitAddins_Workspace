using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;
using Revit.IFC.Common.Extensions;

namespace ProSheets.UI.IFCWindow.IFCAddressInformations
{
	// Token: 0x02000095 RID: 149
	public partial class IFCAddressInformation : DiRootsWindow
	{
		// Token: 0x0600091D RID: 2333 RVA: 0x00038B94 File Offset: 0x00036D94
		public IFCAddressInformation(IFCAddressItem iFCAddressItem)
		{
			string[] array = \u000C\u0002\u000F.\u000C(5);
			array[0] = "OFFICE";
			array[1] = "SITE";
			array[2] = "HOME";
			array[3] = "DISTRIBUTIONPOINT";
			array[4] = "USERDEFINED";
			this.KR = array;
			string[] array2 = \u000C\u0002\u000F.\u000C(5);
			array2[0] = \u001C\u0009\u0018.\u0001\u0016;
			array2[1] = \u001C\u0009\u0018.\u001B\u0016;
			array2[2] = \u001C\u0009\u0018.\u0005\u0016;
			array2[3] = \u001C\u0009\u0018.\u000E\u0016;
			array2[4] = \u001C\u0009\u0018.\u0001\u0018;
			this.PH = array2;
			this.BH = new IFCAddress();
			this.QH = new IFCAddressItem();
			this.JH = new IFCAddressItem();
			base..ctor();
			\u0018\u001B\u0003.\u0018(this);
			bool flag;
			if (\u000C\u001B\u0003.\u0018(iFCAddressItem))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCAddressInformation..ctor(IFCAddressItem)).MethodHandle;
				}
				if (!\u000C\u001B\u0003.\u0018(this.QH))
				{
					flag = true;
					goto IL_11D;
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
			if (\u000C\u001B\u0003.\u0018(iFCAddressItem))
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
				if (\u000C\u001B\u0003.\u0018(this.QH))
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
					flag = !\u000E\u0001\u0003.\u0018(iFCAddressItem, this.QH);
					goto IL_11D;
				}
			}
			flag = false;
			IL_11D:
			if (flag)
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
				this.QH = iFCAddressItem;
			}
			int num = Enumerable.Count<string>(this.KR);
			for (int i = 0; i < num; i++)
			{
				if (\u000F\u0002\u0018.\u0018(\u0005\u0001\u0003.\u0018(this.QH), this.KR[i]))
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
					\u0009\u0019\u0018.\u0018(this.RH, i);
					IL_18A:
					\u0007\u0018\u0003.\u0018(this.NH, new bool?(\u001B\u0001\u0003.\u0018(iFCAddressItem)));
					\u0007\u0018\u0003.\u0018(this.ZH, new bool?(\u0001\u0001\u0003.\u0018(iFCAddressItem)));
					\u0007\u0018\u0003.\u0018(this.MH, new bool?(\u0008\u0001\u0003.\u0018(iFCAddressItem)));
					return;
				}
			}
			for (;;)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				goto IL_18A;
			}
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x00038D74 File Offset: 0x00036F74
		private string RM()
		{
			return this.KR[4];
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x00038D8C File Offset: 0x00036F8C
		private void wndIFCAddress_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000B\u0018.\u0003(this, this.QH);
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x00038DA8 File Offset: 0x00036FA8
		private void wndIFCAddress_Initialized(object sender, EventArgs e)
		{
			if (\u0020\u001A\u0003.\u0018(this.BH, \u0007\u0015\u0018.\u0003, ref this.QH))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCAddressInformation.wndIFCAddress_Initialized(object, EventArgs)).MethodHandle;
				}
				this.JH = \u0014\u001B\u0003.\u0018(this.QH);
				int num = Enumerable.Count<string>(this.KR);
				for (int i = 0; i < num; i++)
				{
					if (\u000F\u0002\u0018.\u0018(\u0005\u0001\u0003.\u0018(this.QH), this.KR[i]))
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
						\u0009\u0019\u0018.\u0018(this.RH, i);
						return;
					}
				}
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
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x00038E54 File Offset: 0x00037054
		private void cmbBxPurpose_Initialized(object sender, EventArgs e)
		{
			string[] ph = this.PH;
			for (int i = 0; i < (int)\u0020\u001A\u000F.\u000C(ph); i++)
			{
				string u = ph[i];
				\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.RH), u);
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(IFCAddressInformation.cmbBxPurpose_Initialized(object, EventArgs)).MethodHandle;
			}
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x00038EAC File Offset: 0x000370AC
		private void cmbBxPurpose_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			\u000F\u001B\u0003.\u0018(this.QH, this.KR[\u000D\u0007\u0018.\u0018(this.RH)]);
			if (\u0016\u001B\u0003.\u0018(\u0005\u0001\u0003.\u0018(this.QH), this.RM()) != 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCAddressInformation.cmbBxPurpose_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				\u0003\u001B\u0003.\u0018(this.QH, "");
				\u0014\u0019\u0018.\u0018(this.HH, false);
				return;
			}
			\u0014\u0019\u0018.\u0018(this.HH, true);
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x00038F34 File Offset: 0x00037134
		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
			if (\u001B\u0001\u0003.\u0018(this.QH))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCAddressInformation.btnOk_Click(object, RoutedEventArgs)).MethodHandle;
				}
				string p = this.HM(this.QH);
				string q = this.NM(this.QH);
				IFCAddressInformation.YM(p, q);
			}
			if (!\u000E\u0001\u0003.\u0018(this.QH, this.JH))
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
				\u0005\u0020\u0018.\u000F(new Action(this.OM));
			}
			\u000B\u000B\u0018.\u0003(this);
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x00038FBC File Offset: 0x000371BC
		private string HM(IFCAddressItem P)
		{
			StringBuilder stringBuilder = \u0005\u0017\u0018.\u0018();
			this.ZM(stringBuilder, \u0011\u001B\u0003.\u0018(P), false);
			this.ZM(stringBuilder, \u001F\u001B\u0003.\u0018(P), false);
			this.ZM(stringBuilder, \u0020\u001B\u0003.\u0018(P), false);
			bool flag = this.MM(stringBuilder, \u000A\u001B\u0003.\u0018(P));
			bool flag2 = this.XM(stringBuilder, \u0009\u001B\u0003.\u0018(P), ", ");
			bool flag3 = this.XM(stringBuilder, \u0013\u001B\u0003.\u0018(P), " ");
			if (flag || flag2 || flag3)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCAddressInformation.HM(IFCAddressItem)).MethodHandle;
				}
				\u001C\u001B\u0003.\u0018(stringBuilder);
			}
			this.ZM(stringBuilder, \u000D\u001B\u0003.\u0018(P), false);
			this.ZM(stringBuilder, \u0012\u001B\u0003.\u0018(P), true);
			return \u0001\u0017\u0018.\u0018(stringBuilder);
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x0003908C File Offset: 0x0003728C
		private string NM(IFCAddressItem P)
		{
			StringBuilder stringBuilder = \u0005\u0017\u0018.\u0018();
			this.MM(stringBuilder, \u000A\u001B\u0003.\u0018(P));
			this.XM(stringBuilder, \u0009\u001B\u0003.\u0018(P), ", ");
			this.XM(stringBuilder, \u000D\u001B\u0003.\u0018(P), ", ");
			return \u0001\u0017\u0018.\u0018(stringBuilder);
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x000390EC File Offset: 0x000372EC
		private void ZM(StringBuilder P, string Q, bool J = false)
		{
			if (!\u001F\u001A\u0018.\u0018(Q))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCAddressInformation.ZM(StringBuilder, string, bool)).MethodHandle;
				}
				if (J)
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
					\u001C\u001B\u0003.\u0018(P);
				}
				\u0015\u001B\u0003.\u0018(P, Q);
			}
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x00039138 File Offset: 0x00037338
		private bool MM(StringBuilder P, string Q)
		{
			if (!\u001F\u001A\u0018.\u0018(Q))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCAddressInformation.MM(StringBuilder, string)).MethodHandle;
				}
				\u0017\u0020\u0014.\u0018(P, Q);
				return true;
			}
			return false;
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x00039170 File Offset: 0x00037370
		private bool XM(StringBuilder P, string Q, string J)
		{
			if (!\u001F\u001A\u0018.\u0018(Q))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCAddressInformation.XM(StringBuilder, string, string)).MethodHandle;
				}
				\u0017\u0020\u0014.\u0018(P, J);
				\u0017\u0020\u0014.\u0018(P, Q);
				return true;
			}
			return false;
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x000391B4 File Offset: 0x000373B4
		private static void YM(string P, string Q)
		{
			\u0004\u001B\u0003.\u0018(\u000E\u0002\u0018.\u0018(\u0007\u0015\u0018.\u0003), P);
			if (!\u001F\u001A\u0018.\u0018(Q))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCAddressInformation.YM(string, string)).MethodHandle;
				}
				\u0017\u001B\u0003.\u0018(\u001E\u001B\u0003.\u0018(\u0002\u001B\u0003.\u0018(\u0007\u0015\u0018.\u0003)), Q);
			}
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x00039210 File Offset: 0x00037410
		private void txtUserDefine_LostFocus(object sender, RoutedEventArgs e)
		{
			if (!\u001F\u001A\u0018.\u0018(\u001D\u001B\u0003.\u0018(this.QH)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCAddressInformation.txtUserDefine_LostFocus(object, RoutedEventArgs)).MethodHandle;
				}
				\u000F\u001B\u0003.\u0018(this.QH, this.RM());
				\u0016\u0007\u0018.\u0018(this.RH, Enumerable.LastOrDefault<string>(this.PH));
			}
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x00039274 File Offset: 0x00037474
		private void chkBxUpdareProjectInfo_Click(object sender, RoutedEventArgs e)
		{
			object qh = this.QH;
			bool? flag = \u001B\u0001\u0018.\u0018(this.NH);
			\u001A\u001B\u0003.\u0018(qh, \u000F\u0014\u0003.\u0018(ref flag));
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x000392A4 File Offset: 0x000374A4
		private void chkBxAssignToBuilding_Click(object sender, RoutedEventArgs e)
		{
			object qh = this.QH;
			bool? flag = \u001B\u0001\u0018.\u0018(this.ZH);
			\u000B\u001B\u0003.\u0018(qh, \u000F\u0014\u0003.\u0018(ref flag));
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x000392D4 File Offset: 0x000374D4
		private void chkBxAssignToSite_Click(object sender, RoutedEventArgs e)
		{
			object qh = this.QH;
			bool? flag = \u001B\u0001\u0018.\u0018(this.MH);
			\u0019\u001B\u0003.\u0018(qh, \u000F\u0014\u0003.\u0018(ref flag));
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x000394C4 File Offset: 0x000376C4
		[CompilerGenerated]
		private void OM()
		{
			\u0010\u001B\u0003.\u0018(this.BH, \u0007\u0015\u0018.\u0003, this.QH);
		}

		// Token: 0x04000447 RID: 1095
		private string[] KR;

		// Token: 0x04000448 RID: 1096
		private string[] PH;

		// Token: 0x04000449 RID: 1097
		private IFCAddress BH;

		// Token: 0x0400044A RID: 1098
		private IFCAddressItem QH;

		// Token: 0x0400044B RID: 1099
		private IFCAddressItem JH;
	}
}
