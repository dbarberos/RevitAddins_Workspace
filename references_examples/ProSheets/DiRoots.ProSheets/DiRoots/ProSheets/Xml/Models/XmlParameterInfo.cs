using System;
using A;
using DiRoots.ProSheets.Xml.Enums;

namespace DiRoots.ProSheets.Xml.Models
{
	// Token: 0x0200002B RID: 43
	public class XmlParameterInfo : ParameterInfo
	{
		// Token: 0x0600018F RID: 399 RVA: 0x00009908 File Offset: 0x00007B08
		public XmlParameterInfo()
		{
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000991C File Offset: 0x00007B1C
		public XmlParameterInfo(ParameterDto parameterDto)
		{
			\u000E\u001B\u0018.\u0014(this, \u001F\u001B\u0018.\u0003(parameterDto));
			\u0005\u001B\u0018.\u0014(this, \u000A\u001B\u0018.\u0003(parameterDto));
			\u0001\u001B\u0018.\u0014(this, \u001B\u001B\u0018.\u0018(parameterDto));
			\u0006\u001B\u0018.\u0014(this, \u0008\u001B\u0018.\u0018(parameterDto));
			\u0010\u001B\u0018.\u0014(this, \u0015\u001B\u0018.\u0003(parameterDto));
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000191 RID: 401 RVA: 0x00009978 File Offset: 0x00007B78
		// (set) Token: 0x06000192 RID: 402 RVA: 0x0000998C File Offset: 0x00007B8C
		public string InitialElementName
		{
			get
			{
				return this.I;
			}
			set
			{
				this.I = value;
				this.T = value;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000193 RID: 403 RVA: 0x000099A8 File Offset: 0x00007BA8
		// (set) Token: 0x06000194 RID: 404 RVA: 0x000099BC File Offset: 0x00007BBC
		public string ElementName
		{
			get
			{
				return this.T;
			}
			set
			{
				this.T = value;
				\u0007\u001B\u0018.\u0018(this, "ElementName");
				\u0007\u001B\u0018.\u0018(this, "IsElementNameModified");
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000195 RID: 405 RVA: 0x000099E8 File Offset: 0x00007BE8
		public bool IsElementNameModified
		{
			get
			{
				if (\u0011\u001B\u0018.\u0003(this) == ParameterType.Custom)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(XmlParameterInfo.get_IsElementNameModified()).MethodHandle;
					}
					return false;
				}
				return \u0009\u001E\u0018.\u0018(\u0018\u0005\u0018.\u0014(this), \u000C\u0005\u0018.\u0014(this));
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00009A2C File Offset: 0x00007C2C
		public static XmlParameterInfo GetCustomElement(string elementName, string value)
		{
			XmlParameterInfo xmlParameterInfo = \u0014\u0005\u0018.\u0018();
			\u0005\u001B\u0018.\u0003(xmlParameterInfo, "-");
			\u0001\u001B\u0018.\u0003(xmlParameterInfo, elementName);
			\u0006\u001B\u0018.\u0003(xmlParameterInfo, value);
			\u0010\u001B\u0018.\u0003(xmlParameterInfo, ParameterType.Custom);
			return xmlParameterInfo;
		}

		// Token: 0x040000D5 RID: 213
		private string T;

		// Token: 0x040000D6 RID: 214
		private string I;
	}
}
