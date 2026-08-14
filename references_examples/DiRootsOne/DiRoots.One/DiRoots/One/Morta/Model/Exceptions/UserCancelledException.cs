using System;
using System.Runtime.Serialization;
using A;

namespace DiRoots.One.Morta.Model.Exceptions
{
	// Token: 0x020001EC RID: 492
	[Serializable]
	public class UserCancelledException : Exception
	{
		// Token: 0x06001294 RID: 4756 RVA: 0x0006B6BC File Offset: 0x000698BC
		public UserCancelledException()
		{
		}

		// Token: 0x06001295 RID: 4757 RVA: 0x0006B6D0 File Offset: 0x000698D0
		public UserCancelledException(string errorMessage) : base(errorMessage)
		{
		}

		// Token: 0x06001296 RID: 4758 RVA: 0x0006B6E4 File Offset: 0x000698E4
		protected UserCancelledException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x06001297 RID: 4759 RVA: 0x0006B6FC File Offset: 0x000698FC
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			\u000E\u0005\u0018.\u000A(this, info, context);
		}
	}
}
