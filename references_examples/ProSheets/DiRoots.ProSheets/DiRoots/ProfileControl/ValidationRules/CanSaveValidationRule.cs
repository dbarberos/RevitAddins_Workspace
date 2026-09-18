using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using Microsoft.CSharp.RuntimeBinder;

namespace DiRoots.ProfileControl.ValidationRules
{
	// Token: 0x02000010 RID: 16
	[ContentProperty("Properties")]
	public class CanSaveValidationRule : ValidationRule
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00004508 File Offset: 0x00002708
		// (set) Token: 0x06000062 RID: 98 RVA: 0x0000451C File Offset: 0x0000271C
		public CanSaveValidationProperties Properties { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00004530 File Offset: 0x00002730
		// (set) Token: 0x06000064 RID: 100 RVA: 0x00004544 File Offset: 0x00002744
		public bool CheckInvalidCharacters { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00004558 File Offset: 0x00002758
		// (set) Token: 0x06000066 RID: 102 RVA: 0x0000456C File Offset: 0x0000276C
		public bool CheckInvalidPathCharacters { get; set; }

		// Token: 0x06000067 RID: 103 RVA: 0x00004580 File Offset: 0x00002780
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			string text = \u0018\u000B\u0018.\u0018(\u001E\u001A\u0018.\u0018(\u000A\u0002\u000F.\u000C(\u0002\u001A\u0018.\u0018(\u0013\u0002\u000F.\u000C(value)))));
			if (text == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveValidationRule.Validate(object, CultureInfo)).MethodHandle;
				}
				return \u0012\u001A\u0018.\u0018(false, \u000D\u0009\u0018.\u0007\u0018);
			}
			if (\u000F\u0002\u0018.\u0018(text, ""))
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
				\u000C\u000B\u0018.\u0018(\u001B\u001A\u0018.\u0018(this), false);
				\u000E\u001A\u0018.\u0018(\u001B\u001A\u0018.\u0018(this), \u000D\u0009\u0018.\u000F\u0014);
				\u0005\u001A\u0018.\u0018(\u001B\u001A\u0018.\u0018(this), ErrorType.Error);
				return \u0012\u001A\u0018.\u0018(false, \u0014\u001E\u0018.\u0018(\u0001\u001A\u0018.\u0018(\u001B\u001A\u0018.\u0018(this)), " ", \u000D\u0009\u0018.\u000D\u0014));
			}
			object u000C = \u0012\u0002\u0018.\u0018(text);
			char[] array = \u0020\u0002\u000F.\u000C(13);
			\u0017\u001A\u0018.\u0018(array, fieldof(\u0009\u0017\u0018.\u0014).FieldHandle);
			int q = \u0015\u001A\u0018.\u0018(u000C, array);
			int j = \u0015\u001A\u0018.\u0018(\u0012\u0002\u0018.\u0018(text), \u0008\u001A\u0018.\u0018());
			return this.F(text, q, j);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00004694 File Offset: 0x00002894
		private ValidationResult F(string P, int Q, int J)
		{
			if (Q != -1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveValidationRule.F(string, int, int)).MethodHandle;
				}
				if (\u000F\u000B\u0018.\u0018(this))
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
					this.N(\u000D\u0009\u0018.\u000F\u0014, false, ErrorType.Error);
					return \u0012\u001A\u0018.\u0018(false, \u0014\u001E\u0018.\u0018(\u0001\u001A\u0018.\u0018(\u001B\u001A\u0018.\u0018(this)), " ", \u000D\u0009\u0018.\u0015\u0014));
				}
			}
			if (J != -1)
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
				if (\u0016\u000B\u0018.\u0018(this))
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
					this.N(\u000D\u0009\u0018.\u000F\u0014, false, ErrorType.Error);
					bool u000C = false;
					string[] array = \u000C\u0002\u000F.\u000C(5);
					array[0] = \u0001\u001A\u0018.\u0018(\u001B\u001A\u0018.\u0018(this));
					array[1] = " ";
					array[2] = \u000D\u0009\u0018.\u0017\u0014;
					array[3] = " \\ : ";
					array[4] = \u0003\u000B\u0018.\u0018(\u0008\u001A\u0018.\u0018());
					return \u0012\u001A\u0018.\u0018(u000C, \u000F\u001D\u0018.\u0018(array));
				}
			}
			if (\u0014\u000B\u0018.InvokeStubVirtual(\u001B\u001A\u0018.\u0018(this)) != null)
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
				if (!\u001F\u001A\u0018.\u0018(\u0012\u0002\u0018.\u0018(P)))
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
					IEnumerable<object> enumerable = \u0014\u000B\u0018.InvokeStubVirtual(\u001B\u001A\u0018.\u0018(this));
					Func<object, object> func;
					if ((func = CanSaveValidationRule.<>c.\u0018) == null)
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
						func = (CanSaveValidationRule.<>c.\u0018 = delegate(dynamic s)
						{
							if (CanSaveValidationRule.\u0010\u0013\u0018.\u000C == null)
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
									RuntimeMethodHandle runtimeMethodHandle2 = methodof(CanSaveValidationRule.<>c.<GettingValidationResult>b__13_0(object)).MethodHandle;
								}
								CSharpBinderFlags u000C2 = CSharpBinderFlags.None;
								string u = "ToLower";
								IEnumerable<Type> u2 = null;
								Type u3 = \u000A\u001D\u0018.\u0018(\u001D\u0008\u000F.\u000C());
								CSharpArgumentInfo[] array2 = \u0006\u0019\u000F.\u000C(1);
								array2[0] = \u0004\u0015\u0003.\u0018(CSharpArgumentInfoFlags.None, \u0005\u001E\u000F.\u000C);
								CanSaveValidationRule.\u0010\u0013\u0018.\u000C = \u001E\u0015\u0003.\u0018(\u0002\u0009\u000F.\u0018(u000C2, u, u2, u3, array2));
							}
							return \u0017\u0015\u0003.\u0018(CanSaveValidationRule.\u0010\u0013\u0018.\u000C.Target, CanSaveValidationRule.\u0010\u0013\u0018.\u000C, s);
						});
					}
					if (!Enumerable.Contains<object>(Enumerable.Select<object, object>(enumerable, func), \u0012\u0002\u0018.\u0018(P)))
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
						\u000E\u001A\u0018.\u0018(\u001B\u001A\u0018.\u0018(this), \u000D\u0009\u0018.\u000F\u0014);
						\u000C\u000B\u0018.\u0018(\u001B\u001A\u0018.\u0018(this), true);
						return \u0012\u001A\u0018.\u0018(true, \u001F\u0002\u000F.\u000C);
					}
				}
			}
			return this.H(P);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00004860 File Offset: 0x00002A60
		private ValidationResult H(string P)
		{
			if (!\u001F\u001A\u0018.\u0018(\u0012\u0002\u0018.\u0018(P)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveValidationRule.H(string)).MethodHandle;
				}
				if (\u000F\u0002\u0018.\u0018(P, \u000D\u0009\u0018.\u0015\u0018))
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
					this.N(\u000D\u0009\u0018.\u001F\u0014, false, ErrorType.Warning);
					return \u0012\u001A\u0018.\u0018(false, \u001C\u001E\u0018.\u0018(\u000D\u0009\u0018.\u001C\u0014, \u0001\u001A\u0018.\u0018(\u001B\u001A\u0018.\u0018(this))));
				}
				if (\u0014\u000B\u0018.InvokeStubVirtual(\u001B\u001A\u0018.\u0018(this)) != null)
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
					IEnumerable<object> enumerable = \u0014\u000B\u0018.InvokeStubVirtual(\u001B\u001A\u0018.\u0018(this));
					Func<object, object> func;
					if ((func = CanSaveValidationRule.<>c.\u0014) == null)
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
						func = (CanSaveValidationRule.<>c.\u0014 = delegate(dynamic s)
						{
							if (CanSaveValidationRule.\u0006\u0013\u0018.\u000C == null)
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
									RuntimeMethodHandle runtimeMethodHandle2 = methodof(CanSaveValidationRule.<>c.<GettingVailadtionForSting>b__14_0(object)).MethodHandle;
								}
								CSharpBinderFlags u000C = CSharpBinderFlags.None;
								string u = "ToLower";
								IEnumerable<Type> u2 = null;
								Type u3 = \u000A\u001D\u0018.\u0018(\u001D\u0008\u000F.\u000C());
								CSharpArgumentInfo[] array = \u0006\u0019\u000F.\u000C(1);
								array[0] = \u0004\u0015\u0003.\u0018(CSharpArgumentInfoFlags.None, \u0005\u001E\u000F.\u000C);
								CanSaveValidationRule.\u0006\u0013\u0018.\u000C = \u001E\u0015\u0003.\u0018(\u0002\u0009\u000F.\u0018(u000C, u, u2, u3, array));
							}
							return \u0017\u0015\u0003.\u0018(CanSaveValidationRule.\u0006\u0013\u0018.\u000C.Target, CanSaveValidationRule.\u0006\u0013\u0018.\u000C, s);
						});
					}
					if (Enumerable.Contains<object>(Enumerable.Select<object, object>(enumerable, func), \u0012\u0002\u0018.\u0018(P)))
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
						this.N(\u000D\u0009\u0018.\u001F\u0014, true, ErrorType.Warning);
						return \u0012\u001A\u0018.\u0018(false, \u001C\u001E\u0018.\u0018(\u000D\u0009\u0018.\u0011\u0014, \u0001\u001A\u0018.\u0018(\u001B\u001A\u0018.\u0018(this))));
					}
				}
			}
			\u000E\u001A\u0018.\u0018(\u001B\u001A\u0018.\u0018(this), \u000D\u0009\u0018.\u000F\u0014);
			\u000C\u000B\u0018.\u0018(\u001B\u001A\u0018.\u0018(this), true);
			return \u0012\u001A\u0018.\u0018(true, \u001F\u0002\u000F.\u000C);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000049C0 File Offset: 0x00002BC0
		private void N(string P, bool Q, ErrorType J)
		{
			\u000E\u001A\u0018.\u0018(\u001B\u001A\u0018.\u0018(this), P);
			\u0005\u001A\u0018.\u0018(\u001B\u001A\u0018.\u0018(this), J);
			\u000C\u000B\u0018.\u0018(\u001B\u001A\u0018.\u0018(this), Q);
		}

		// Token: 0x04000023 RID: 35
		[CompilerGenerated]
		private CanSaveValidationProperties P;

		// Token: 0x04000024 RID: 36
		[CompilerGenerated]
		private bool Q;

		// Token: 0x04000025 RID: 37
		[CompilerGenerated]
		private bool J;

		// Token: 0x02000151 RID: 337
		[CompilerGenerated]
		private static class \u0010\u0013\u0018
		{
			// Token: 0x04000768 RID: 1896
			public static CallSite<Func<CallSite, object, object>> \u000C;
		}

		// Token: 0x02000152 RID: 338
		[CompilerGenerated]
		private static class \u0006\u0013\u0018
		{
			// Token: 0x04000769 RID: 1897
			public static CallSite<Func<CallSite, object, object>> \u000C;
		}
	}
}
