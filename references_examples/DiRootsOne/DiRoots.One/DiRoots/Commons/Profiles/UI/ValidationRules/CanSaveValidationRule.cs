using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using Microsoft.CSharp.RuntimeBinder;

namespace DiRoots.Commons.Profiles.UI.ValidationRules
{
	// Token: 0x020000BA RID: 186
	[ContentProperty("Properties")]
	public class CanSaveValidationRule : ValidationRule
	{
		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000728 RID: 1832 RVA: 0x00029BF8 File Offset: 0x00027DF8
		// (set) Token: 0x06000729 RID: 1833 RVA: 0x00029C0C File Offset: 0x00027E0C
		public CanSaveValidationProperties Properties { get; set; }

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x0600072A RID: 1834 RVA: 0x00029C20 File Offset: 0x00027E20
		// (set) Token: 0x0600072B RID: 1835 RVA: 0x00029C34 File Offset: 0x00027E34
		public bool CheckInvalidCharacters { get; set; }

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x0600072C RID: 1836 RVA: 0x00029C48 File Offset: 0x00027E48
		// (set) Token: 0x0600072D RID: 1837 RVA: 0x00029C5C File Offset: 0x00027E5C
		public bool CheckInvalidPathCharacters { get; set; }

		// Token: 0x0600072E RID: 1838 RVA: 0x00029C70 File Offset: 0x00027E70
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			string text = \u0020\u0006\u001D.\u000A(\u000B\u0006\u001D.\u000A(\u0004\u001D\u000E.\u001F(\u0002\u0006\u001D.\u000A(\u0007\u001D\u000E.\u001F(value)))));
			if (text == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveValidationRule.Validate(object, CultureInfo)).MethodHandle;
				}
				return \u0014\u0002\u001D.\u000A(false, \u0016\u0006\u001D.\u000A());
			}
			if (\u0008\u0013\u000A.\u000A(text, ""))
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
				\u001E\u0006\u001D.\u000A(\u0008\u0006\u001D.\u000A(this), false);
				\u0011\u0006\u001D.\u000A(\u0008\u0006\u001D.\u000A(this), \u0015\u0002\u001D.\u000A());
				\u001B\u0006\u001D.\u000A(\u0008\u0006\u001D.\u000A(this), ErrorType.Error);
				return \u0014\u0002\u001D.\u000A(false, \u0002\u0013\u000A.\u000A(\u000E\u0006\u001D.\u000A(\u0008\u0006\u001D.\u000A(this)), " ", \u0010\u0006\u001D.\u000A()));
			}
			text = \u0018\u0006\u001D.\u0007(text);
			object u001F = text;
			char[] array = \u001C\u0007\u000E.\u001F(13);
			\u001B\u000B\u001D.\u000A(array, fieldof(\u0001\u001B\u000A.\u0016).FieldHandle);
			int r = \u0013\u000F\u0007.\u0007(u001F, array);
			int d = \u0013\u000F\u0007.\u0007(text, \u0017\u0001\u0007.\u000A());
			return this.H(text, r, d);
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x00029D80 File Offset: 0x00027F80
		private ValidationResult H(string F, int R, int D)
		{
			if (R != -1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveValidationRule.H(string, int, int)).MethodHandle;
				}
				if (\u0001\u0006\u001D.\u000A(this))
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
					this.L(\u0015\u0002\u001D.\u000A(), false, ErrorType.Error);
					return \u0014\u0002\u001D.\u000A(false, \u0002\u0013\u000A.\u000A(\u000E\u0006\u001D.\u000A(\u0008\u0006\u001D.\u000A(this)), " ", \u0015\u0006\u001D.\u000A()));
				}
			}
			if (D != -1)
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
				if (\u000C\u0006\u001D.\u000A(this))
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
					this.L(\u0015\u0002\u001D.\u000A(), false, ErrorType.Error);
					bool u001F = false;
					string[] array = \u001B\u001F\u000E.\u001F(5);
					array[0] = \u000E\u0006\u001D.\u000A(\u0008\u0006\u001D.\u000A(this));
					array[1] = " ";
					array[2] = \u001A\u0006\u001D.\u000A();
					array[3] = " \\ : ";
					array[4] = \u0013\u0006\u001D.\u000A(\u0017\u0001\u0007.\u000A());
					return \u0014\u0002\u001D.\u000A(u001F, \u0014\u0006\u001D.\u000A(array));
				}
			}
			if (\u0017\u0006\u001D.InvokeStubVirtual(\u0008\u0006\u001D.\u000A(this)) != null)
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
				if (!\u001A\u0006\u0007.\u000A(F))
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
					IEnumerable<object> enumerable = \u0017\u0006\u001D.InvokeStubVirtual(\u0008\u0006\u001D.\u000A(this));
					Func<object, object> func;
					if ((func = CanSaveValidationRule.<>c.\u000A) == null)
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
						func = (CanSaveValidationRule.<>c.\u000A = delegate(dynamic s)
						{
							if (CanSaveValidationRule.\u000C\u0004.\u001F == null)
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
									RuntimeMethodHandle runtimeMethodHandle2 = methodof(CanSaveValidationRule.<>c.<GettingValidationResult>b__13_0(object)).MethodHandle;
								}
								CSharpBinderFlags u001F2 = CSharpBinderFlags.None;
								string u000A = "ToLower";
								IEnumerable<Type> u = null;
								Type u001D = \u001E\u0011\u000A.\u000A(\u001C\u0005\u0008.\u001F());
								CSharpArgumentInfo[] array2 = \u000F\u0016\u000E.\u001F(1);
								array2[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
								CanSaveValidationRule.\u000C\u0004.\u001F = \u0019\u0001\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F2, u000A, u, u001D, array2));
							}
							return \u0004\u0001\u0019.\u000A(CanSaveValidationRule.\u000C\u0004.\u001F.Target, CanSaveValidationRule.\u000C\u0004.\u001F, s);
						});
					}
					if (!Enumerable.Contains<object>(Enumerable.Select<object, object>(enumerable, func), F))
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
						\u0011\u0006\u001D.\u000A(\u0008\u0006\u001D.\u000A(this), \u0015\u0002\u001D.\u000A());
						\u001E\u0006\u001D.\u000A(\u0008\u0006\u001D.\u000A(this), true);
						return \u0014\u0002\u001D.\u000A(true, \u0019\u001D\u000E.\u001F);
					}
				}
			}
			return this.C(F);
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x00029F3C File Offset: 0x0002813C
		private ValidationResult C(string F)
		{
			if (!\u001A\u0006\u0007.\u000A(F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveValidationRule.C(string)).MethodHandle;
				}
				if (\u0008\u0013\u000A.\u000A(F, \u000A\u000F\u001D.\u000A()))
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
					this.L(\u0007\u0006\u001D.\u000A(), false, ErrorType.Warning);
					return \u0014\u0002\u001D.\u000A(false, \u0017\u0006\u0007.\u000A(\u001F\u000F\u001D.\u000A(), \u000E\u0006\u001D.\u000A(\u0008\u0006\u001D.\u000A(this))));
				}
				if (\u0017\u0006\u001D.InvokeStubVirtual(\u0008\u0006\u001D.\u000A(this)) != null)
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
					IEnumerable<object> enumerable = \u0017\u0006\u001D.InvokeStubVirtual(\u0008\u0006\u001D.\u000A(this));
					Func<object, object> func;
					if ((func = CanSaveValidationRule.<>c.\u0007) == null)
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
						func = (CanSaveValidationRule.<>c.\u0007 = delegate(dynamic s)
						{
							if (CanSaveValidationRule.\u0015\u0004.\u001F == null)
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
									RuntimeMethodHandle runtimeMethodHandle2 = methodof(CanSaveValidationRule.<>c.<GettingVailadtionForSting>b__14_0(object)).MethodHandle;
								}
								CSharpBinderFlags u001F = CSharpBinderFlags.None;
								string u000A = "ToLower";
								IEnumerable<Type> u = null;
								Type u001D = \u001E\u0011\u000A.\u000A(\u001C\u0005\u0008.\u001F());
								CSharpArgumentInfo[] array = \u000F\u0016\u000E.\u001F(1);
								array[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
								CanSaveValidationRule.\u0015\u0004.\u001F = \u0019\u0001\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F, u000A, u, u001D, array));
							}
							return \u0004\u0001\u0019.\u000A(CanSaveValidationRule.\u0015\u0004.\u001F.Target, CanSaveValidationRule.\u0015\u0004.\u001F, s);
						});
					}
					if (Enumerable.Contains<object>(Enumerable.Select<object, object>(enumerable, func), F))
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
						this.L(\u0007\u0006\u001D.\u000A(), true, ErrorType.Warning);
						return \u0014\u0002\u001D.\u000A(false, \u0017\u0006\u0007.\u000A(\u0009\u0006\u001D.\u000A(), \u000E\u0006\u001D.\u000A(\u0008\u0006\u001D.\u000A(this))));
					}
				}
			}
			\u0011\u0006\u001D.\u000A(\u0008\u0006\u001D.\u000A(this), \u0015\u0002\u001D.\u000A());
			\u001E\u0006\u001D.\u000A(\u0008\u0006\u001D.\u000A(this), true);
			return \u0014\u0002\u001D.\u000A(true, \u0019\u001D\u000E.\u001F);
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x0002A090 File Offset: 0x00028290
		private void L(string F, bool R, ErrorType D)
		{
			\u0011\u0006\u001D.\u000A(\u0008\u0006\u001D.\u000A(this), F);
			\u001B\u0006\u001D.\u000A(\u0008\u0006\u001D.\u000A(this), D);
			\u001E\u0006\u001D.\u000A(\u0008\u0006\u001D.\u000A(this), R);
		}

		// Token: 0x040002E1 RID: 737
		[CompilerGenerated]
		private CanSaveValidationProperties F;

		// Token: 0x040002E2 RID: 738
		[CompilerGenerated]
		private bool R;

		// Token: 0x040002E3 RID: 739
		[CompilerGenerated]
		private bool D;

		// Token: 0x020007CF RID: 1999
		[CompilerGenerated]
		private static class \u000C\u0004
		{
			// Token: 0x04001FBA RID: 8122
			public static CallSite<Func<CallSite, object, object>> \u001F;
		}

		// Token: 0x020007D0 RID: 2000
		[CompilerGenerated]
		private static class \u0015\u0004
		{
			// Token: 0x04001FBB RID: 8123
			public static CallSite<Func<CallSite, object, object>> \u001F;
		}
	}
}
