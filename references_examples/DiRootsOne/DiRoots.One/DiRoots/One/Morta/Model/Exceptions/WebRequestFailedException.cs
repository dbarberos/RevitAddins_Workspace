using System;
using System.Runtime.Serialization;
using A;

namespace DiRoots.One.Morta.Model.Exceptions
{
	// Token: 0x020001ED RID: 493
	[Serializable]
	public class WebRequestFailedException : Exception
	{
		// Token: 0x06001298 RID: 4760 RVA: 0x0006B714 File Offset: 0x00069914
		public WebRequestFailedException()
		{
		}

		// Token: 0x06001299 RID: 4761 RVA: 0x0006B728 File Offset: 0x00069928
		public WebRequestFailedException(string errorMessage) : base(errorMessage)
		{
		}

		// Token: 0x0600129A RID: 4762 RVA: 0x0006B73C File Offset: 0x0006993C
		protected WebRequestFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x0600129B RID: 4763 RVA: 0x0006B754 File Offset: 0x00069954
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			\u000E\u0005\u0018.\u000A(this, info, context);
		}
	}
}
