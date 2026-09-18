using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.TableGen.TGRevitHelper.StyleMapping;

namespace A
{
	// Token: 0x0200013E RID: 318
	internal sealed class \u0008\u0016
	{
		// Token: 0x06000BBE RID: 3006 RVA: 0x0004A6E8 File Offset: 0x000488E8
		internal \u0008\u0016(View \u001F)
		{
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0016..ctor(View)).MethodHandle;
				}
				return;
			}
			try
			{
				IEnumerator<Element> enumerator = \u0009\u000C\u0004.\u000A(\u0011\u0011\u000A.\u001D(\u0017\u0011\u000A.\u0007(new FilteredElementCollector(\u0008\u0019\u0007.\u000A(\u001F), \u0002\u001E\u000A.\u0007(\u001F)), -2000300L), \u001E\u0011\u000A.\u000A(\u0002\u0018\u000E.\u001F())));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						TextNote textNote = \u0009\u0004\u000E.\u001F(\u0001\u000C\u0004.\u000A(enumerator));
						if (textNote != null)
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
							TextNoteIdentity textNoteIdentity = \u0015\u000C\u0004.\u000A(textNote);
							if (textNoteIdentity != null)
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
								\u0013\u000C\u0004.\u000A(this.\u001F, new ValueTuple<int, int>(\u000C\u000C\u0004.\u000A(textNoteIdentity), \u001A\u000C\u0004.\u000A(textNoteIdentity)), textNote);
							}
						}
					}
					for (;;)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				finally
				{
					if (enumerator != null)
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
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\TextNoteMatcher.cs", ".ctor");
			}
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x0004A820 File Offset: 0x00048A20
		internal TextNote \u0007(\u0012\u0005 \u001F)
		{
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0016.\u0007(\u0012\u0005)).MethodHandle;
				}
				return null;
			}
			ValueTuple<int, int> u000A;
			\u000A\u0015\u0004.\u000A(ref u000A, \u0016\u0018\u0004.\u000A(\u001F), \u0018\u0018\u0004.\u000A(\u001F));
			TextNote textNote;
			if (\u001F\u0015\u0004.\u000A(this.\u001F, u000A, ref textNote))
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
				if (\u000C\u0020\u000A.\u0007(textNote))
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
					\u0002\u0019\u0004.\u000A(this.\u000A, u000A);
					return textNote;
				}
			}
			return null;
		}

		// Token: 0x06000BC0 RID: 3008 RVA: 0x0004A8A0 File Offset: 0x00048AA0
		internal IEnumerable<TextNote> \u001D()
		{
			\u0008\u0016.\u000E\u0016 u000E_u = new \u0008\u0016.\u000E\u0016(-2);
			u000E_u.\u001D = this;
			return u000E_u;
		}

		// Token: 0x040004AB RID: 1195
		[TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})]
		private readonly Dictionary<ValueTuple<int, int>, TextNote> \u001F = new Dictionary<ValueTuple<int, int>, TextNote>();

		// Token: 0x040004AC RID: 1196
		[TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})]
		private readonly HashSet<ValueTuple<int, int>> \u000A = new HashSet<ValueTuple<int, int>>();
	}
}
