using System;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x02000061 RID: 97
	internal static class \u001C\u001D
	{
		// Token: 0x06000455 RID: 1109 RVA: 0x0001A824 File Offset: 0x00018A24
		internal static void \u001F(this Document \u001F, Action<TransactionGroup> \u000A, string \u0007 = "")
		{
			TransactionGroup transactionGroup = \u0009\u0017\u0007.\u000A(\u001F, \u0007);
			try
			{
				\u0001\u0017\u0007.\u000A(transactionGroup);
				if (\u000A != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Document.\u001F(Action<TransactionGroup>, string)).MethodHandle;
					}
					\u0015\u0017\u0007.\u000A(\u000A, transactionGroup);
				}
				\u000C\u0017\u0007.\u000A(transactionGroup);
			}
			catch (Exception)
			{
				\u001A\u0017\u0007.\u000A(transactionGroup);
				throw;
			}
			finally
			{
				if (transactionGroup != null)
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
					\u001F\u0017\u000A.\u000A(transactionGroup);
				}
			}
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x0001A8A8 File Offset: 0x00018AA8
		internal static void \u000A(this Document \u001F, Action<Transaction> \u000A, string \u0007 = "")
		{
			Transaction transaction = \u001D\u0014\u0007.\u000A(\u001F, \u0007);
			try
			{
				\u0007\u0014\u0007.\u000A(transaction);
				if (\u000A != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Document.\u000A(Action<Transaction>, string)).MethodHandle;
					}
					\u000A\u0014\u0007.\u000A(\u000A, transaction);
				}
				\u001B\u0001\u000A.\u000A(transaction);
			}
			catch (Exception)
			{
				\u001F\u0014\u0007.\u000A(transaction);
				throw;
			}
			finally
			{
				if (transaction != null)
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
					\u001F\u0017\u000A.\u000A(transaction);
				}
			}
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0001A92C File Offset: 0x00018B2C
		internal static void \u0007(this Document \u001F, Action<SubTransaction> \u000A)
		{
			SubTransaction subTransaction = \u0016\u0014\u0007.\u000A(\u001F);
			try
			{
				\u0005\u0014\u0007.\u000A(subTransaction);
				if (\u000A != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Document.\u0007(Action<SubTransaction>)).MethodHandle;
					}
					\u0018\u0014\u0007.\u000A(\u000A, subTransaction);
				}
				\u0019\u0014\u0007.\u000A(subTransaction);
			}
			catch (Exception)
			{
				\u0004\u0014\u0007.\u000A(subTransaction);
				throw;
			}
			finally
			{
				if (subTransaction != null)
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
					\u001F\u0017\u000A.\u000A(subTransaction);
				}
			}
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x0001A9B0 File Offset: 0x00018BB0
		internal static void \u001D(this Transaction \u001F, IFailuresPreprocessor \u000A)
		{
			FailureHandlingOptions failureHandlingOptions = \u0006\u0014\u0007.\u000A(\u001F);
			\u0002\u0014\u0007.\u000A(failureHandlingOptions, \u000A);
			\u000B\u0014\u0007.\u000A(\u001F, failureHandlingOptions);
		}
	}
}
