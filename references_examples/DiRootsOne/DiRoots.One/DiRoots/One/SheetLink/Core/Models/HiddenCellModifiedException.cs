using System;
using System.Runtime.Serialization;
using A;

namespace DiRoots.One.SheetLink.Core.Models
{
	// Token: 0x0200027B RID: 635
	[Serializable]
	public class HiddenCellModifiedException : Exception
	{
		// Token: 0x06001926 RID: 6438 RVA: 0x000A3014 File Offset: 0x000A1214
		public HiddenCellModifiedException(string message) : base(message)
		{
		}

		// Token: 0x06001927 RID: 6439 RVA: 0x000A3028 File Offset: 0x000A1228
		protected HiddenCellModifiedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x06001928 RID: 6440 RVA: 0x000A3040 File Offset: 0x000A1240
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			\u000E\u0005\u0018.\u000A(this, info, context);
		}
	}
}
