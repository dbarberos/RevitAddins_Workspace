using System;
using A;

namespace DiRoots.ProSheets.Models
{
	// Token: 0x0200004F RID: 79
	public class VariableExpression : AbstractExpression
	{
		// Token: 0x0600030D RID: 781 RVA: 0x000122EC File Offset: 0x000104EC
		public override bool Evaluate(Context context)
		{
			string u;
			if (\u001B\u0013\u0018.\u0018(\u0002\u0020\u0014.\u0014(\u001A\u0020\u0014.\u0018(this)), "%sheetsize%", true))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(VariableExpression.Evaluate(Context)).MethodHandle;
				}
				if (!\u001F\u001A\u0018.\u0018(\u0010\u0020\u0014.\u0014(\u0007\u0020\u0014.\u0018(this))))
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
					if (!\u0007\u0020\u0014.\u0018(this).\u0003())
					{
						return false;
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
				string text;
				if (!\u001F\u001A\u0018.\u0018(\u0019\u0020\u0014.\u0018(\u0007\u0020\u0014.\u0018(this))))
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
					text = \u0019\u0020\u0014.\u0018(\u0007\u0020\u0014.\u0018(this));
				}
				else
				{
					text = "{{Sheet Size}}";
				}
				u = text;
			}
			else
			{
				u = \u0018\u001F\u0018.\u0018(\u0002\u0020\u0014.\u0014(\u001A\u0020\u0014.\u0018(this)));
			}
			\u0017\u0020\u0014.\u0018(\u001E\u0020\u0014.\u0018(context), u);
			return true;
		}
	}
}
