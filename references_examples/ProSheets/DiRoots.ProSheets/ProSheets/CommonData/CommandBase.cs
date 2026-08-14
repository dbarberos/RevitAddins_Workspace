using System;
using System.Windows.Input;
using A;

namespace ProSheets.CommonData
{
	// Token: 0x0200009D RID: 157
	public class CommandBase : ICommand
	{
		// Token: 0x0600095C RID: 2396 RVA: 0x00039C68 File Offset: 0x00037E68
		public CommandBase(Action execute, Predicate<object> canExecute = null)
		{
			if (execute == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CommandBase..ctor(Action, Predicate<object>)).MethodHandle;
				}
				throw new NullReferenceException("execute");
			}
			this.\u000C = execute;
			Predicate<object> u = canExecute;
			if (canExecute == null)
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
				if ((u = CommandBase.<>c.\u0018) == null)
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
					u = (CommandBase.<>c.\u0018 = new Predicate<object>(CommandBase.<>c.\u000C.\u0014));
				}
			}
			this.\u0018 = u;
		}

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x0600095D RID: 2397 RVA: 0x00039CE4 File Offset: 0x00037EE4
		// (remove) Token: 0x0600095E RID: 2398 RVA: 0x00039CF8 File Offset: 0x00037EF8
		public event EventHandler CanExecuteChanged
		{
			add
			{
				\u0016\u0005\u0003.\u0018(value);
			}
			remove
			{
				\u000F\u0005\u0003.\u0018(value);
			}
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x00039D0C File Offset: 0x00037F0C
		public bool CanExecute(object parameter = null)
		{
			return \u0012\u0005\u0003.\u0018(this.\u0018, parameter);
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x00039D28 File Offset: 0x00037F28
		public void Execute(object parameter)
		{
			\u000D\u0005\u0003.\u0018(this.\u000C);
		}

		// Token: 0x04000465 RID: 1125
		private readonly Action \u000C;

		// Token: 0x04000466 RID: 1126
		private readonly Predicate<object> \u0018;
	}
}
