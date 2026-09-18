using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Markup;
using A;

namespace ProSheets.Extensions
{
	// Token: 0x020000DC RID: 220
	public class MethodBindingExtension : MarkupExtension
	{
		// Token: 0x06000B69 RID: 2921 RVA: 0x00045B7C File Offset: 0x00043D7C
		public MethodBindingExtension(object method)
		{
			object[] array = \u0008\u001E\u000F.\u000C(1);
			array[0] = method;
			this..ctor(array);
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x00045B9C File Offset: 0x00043D9C
		public MethodBindingExtension(object arg0, object arg1)
		{
			object[] array = \u0008\u001E\u000F.\u000C(2);
			array[0] = arg0;
			array[1] = arg1;
			this..ctor(array);
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x00045BC0 File Offset: 0x00043DC0
		public MethodBindingExtension(object arg0, object arg1, object arg2)
		{
			object[] array = \u0008\u001E\u000F.\u000C(3);
			array[0] = arg0;
			array[1] = arg1;
			array[2] = arg2;
			this..ctor(array);
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x00045BE8 File Offset: 0x00043DE8
		public MethodBindingExtension(object arg0, object arg1, object arg2, object arg3)
		{
			object[] array = \u0008\u001E\u000F.\u000C(4);
			array[0] = arg0;
			array[1] = arg1;
			array[2] = arg2;
			array[3] = arg3;
			this..ctor(array);
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x00045C14 File Offset: 0x00043E14
		public MethodBindingExtension(object arg0, object arg1, object arg2, object arg3, object arg4)
		{
			object[] array = \u0008\u001E\u000F.\u000C(5);
			array[0] = arg0;
			array[1] = arg1;
			array[2] = arg2;
			array[3] = arg3;
			array[4] = arg4;
			this..ctor(array);
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x00045C48 File Offset: 0x00043E48
		public MethodBindingExtension(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5)
		{
			object[] array = \u0008\u001E\u000F.\u000C(6);
			array[0] = arg0;
			array[1] = arg1;
			array[2] = arg2;
			array[3] = arg3;
			array[4] = arg4;
			array[5] = arg5;
			this..ctor(array);
		}

		// Token: 0x06000B6F RID: 2927 RVA: 0x00045C80 File Offset: 0x00043E80
		public MethodBindingExtension(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6)
		{
			object[] array = \u0008\u001E\u000F.\u000C(7);
			array[0] = arg0;
			array[1] = arg1;
			array[2] = arg2;
			array[3] = arg3;
			array[4] = arg4;
			array[5] = arg5;
			array[6] = arg6;
			this..ctor(array);
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x00045CBC File Offset: 0x00043EBC
		public MethodBindingExtension(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7)
		{
			object[] array = \u0008\u001E\u000F.\u000C(8);
			array[0] = arg0;
			array[1] = arg1;
			array[2] = arg2;
			array[3] = arg3;
			array[4] = arg4;
			array[5] = arg5;
			array[6] = arg6;
			array[7] = arg7;
			this..ctor(array);
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x00045CFC File Offset: 0x00043EFC
		public MethodBindingExtension(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8)
		{
			object[] array = \u0008\u001E\u000F.\u000C(9);
			array[0] = arg0;
			array[1] = arg1;
			array[2] = arg2;
			array[3] = arg3;
			array[4] = arg4;
			array[5] = arg5;
			array[6] = arg6;
			array[7] = arg7;
			array[8] = arg8;
			this..ctor(array);
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x00045D44 File Offset: 0x00043F44
		private MethodBindingExtension(object[] P)
		{
			this.Q = new List<DependencyProperty>();
			base..ctor();
			this.P = P;
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x00045D88 File Offset: 0x00043F88
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			IProvideValueTarget u000C = \u0004\u0010\u000F.\u000C(\u0001\u001F\u0016.\u0018(serviceProvider, \u000A\u001D\u0018.\u0018(\u0002\u0010\u000F.\u000C())));
			FrameworkElement frameworkElement = \u0010\u001D\u000F.\u000C(\u0008\u001F\u0016.\u0018(u000C));
			Type type = \u0017\u001D\u000F.\u000C;
			EventInfo eventInfo = \u001D\u0010\u000F.\u000C(\u0010\u001F\u0016.\u0018(u000C));
			if (eventInfo != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MethodBindingExtension.ProvideValue(IServiceProvider)).MethodHandle;
				}
				type = \u0006\u001F\u0016.\u0018(eventInfo);
			}
			else
			{
				MethodInfo methodInfo = \u001A\u0010\u000F.\u000C(\u0010\u001F\u0016.\u0018(u000C));
				if (methodInfo != null)
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
					ParameterInfo[] array = \u0007\u001F\u0016.\u0018(methodInfo);
					if ((int)\u000B\u0010\u000F.\u000C(array) == 2)
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
						type = \u0019\u001F\u0016.\u0018(array[1]);
					}
				}
			}
			if (frameworkElement != null)
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
				if (!\u001A\u000F\u0014.\u0018(type, \u0017\u001D\u000F.\u000C))
				{
					object[] p = this.P;
					for (int i = 0; i < (int)\u001E\u0004\u000F.\u000C(p); i++)
					{
						object q = p[i];
						DependencyProperty u = this.F(frameworkElement, q);
						\u000B\u001F\u0016.\u0018(this.Q, u);
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
					return this.J(frameworkElement, type);
				}
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			return this;
		}

		// Token: 0x06000B75 RID: 2933 RVA: 0x00045EC8 File Offset: 0x000440C8
		private Delegate J(FrameworkElement P, Type Q)
		{
			MethodBindingExtension.\u0004\u001F\u0018 u0004_u001F_u = new MethodBindingExtension.\u0004\u001F\u0018();
			u0004_u001F_u.\u000C = P;
			u0004_u001F_u.\u0018 = this;
			EventHandler u000C = new EventHandler(u0004_u001F_u.\u0014);
			return \u001B\u001F\u0016.\u0018(Q, \u000E\u001F\u0016.\u0018(u000C), \u0005\u001F\u0016.\u0018(u000C));
		}

		// Token: 0x06000B76 RID: 2934 RVA: 0x00045F0C File Offset: 0x0004410C
		private DependencyProperty F(DependencyObject P, object Q)
		{
			MethodBindingExtension.\u001A\u001F\u0018 u001A_u001F_u = new MethodBindingExtension.\u001A\u001F\u0018();
			u001A_u001F_u.\u000C = P;
			DependencyProperty dependencyProperty = Enumerable.FirstOrDefault<DependencyProperty>(MethodBindingExtension.StorageProperties, new Func<DependencyProperty, bool>(u001A_u001F_u.\u0018));
			if (dependencyProperty == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MethodBindingExtension.F(DependencyObject, object)).MethodHandle;
				}
				string u000C = "Storage";
				int num = \u0014\u0011\u0016.\u0018(MethodBindingExtension.StorageProperties);
				dependencyProperty = \u000E\u000F\u0014.\u0018(\u000D\u001E\u0018.\u0018(u000C, \u0010\u001E\u0018.\u0018(ref num)), \u000A\u001D\u0018.\u0018(\u0002\u0004\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0017\u0010\u000F.\u000C()), \u0018\u0011\u0016.\u0018());
				\u000B\u001F\u0016.\u0018(MethodBindingExtension.StorageProperties, dependencyProperty);
			}
			MarkupExtension markupExtension = \u001E\u0010\u000F.\u000C(Q);
			if (markupExtension != null)
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
				object u = \u000C\u0011\u0016.\u0018(markupExtension, new MethodBindingExtension.\u0002\u001F\u0018(u001A_u001F_u.\u000C, dependencyProperty));
				\u0007\u001A\u0018.\u0003(u001A_u001F_u.\u000C, dependencyProperty, u);
			}
			else
			{
				\u0007\u001A\u0018.\u0003(u001A_u001F_u.\u000C, dependencyProperty, Q);
			}
			return dependencyProperty;
		}

		// Token: 0x04000554 RID: 1364
		private static readonly List<DependencyProperty> StorageProperties = \u001A\u001F\u0016.\u0018();

		// Token: 0x04000555 RID: 1365
		private readonly object[] P;

		// Token: 0x04000556 RID: 1366
		private readonly List<DependencyProperty> Q;

		// Token: 0x020001D8 RID: 472
		private class \u0002\u001F\u0018 : IServiceProvider, IProvideValueTarget
		{
			// Token: 0x06001211 RID: 4625 RVA: 0x0005DD68 File Offset: 0x0005BF68
			public \u0002\u001F\u0018(object \u000C, object \u0018)
			{
				this.TargetObject = \u000C;
				this.TargetProperty = \u0018;
			}

			// Token: 0x1700058C RID: 1420
			// (get) Token: 0x06001212 RID: 4626 RVA: 0x0005DD8C File Offset: 0x0005BF8C
			public object TargetObject { get; }

			// Token: 0x1700058D RID: 1421
			// (get) Token: 0x06001213 RID: 4627 RVA: 0x0005DDA0 File Offset: 0x0005BFA0
			public object TargetProperty { get; }

			// Token: 0x06001214 RID: 4628 RVA: 0x0005DDB4 File Offset: 0x0005BFB4
			public object GetService(Type serviceType)
			{
				if (!\u0017\u0011\u000F.\u0018(serviceType, this))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MethodBindingExtension.\u0002\u001F\u0018.GetService(Type)).MethodHandle;
					}
					return null;
				}
				return this;
			}

			// Token: 0x0400089D RID: 2205
			[CompilerGenerated]
			private readonly object \u000C;

			// Token: 0x0400089E RID: 2206
			[CompilerGenerated]
			private readonly object \u0018;
		}

		// Token: 0x020001DA RID: 474
		[CompilerGenerated]
		private sealed class \u0004\u001F\u0018
		{
			// Token: 0x0600121A RID: 4634 RVA: 0x0005DEA0 File Offset: 0x0005C0A0
			internal void \u0014(object \u000C, EventArgs \u0018)
			{
				MethodBindingExtension.\u001D\u001F\u0018 u001D_u001F_u = new MethodBindingExtension.\u001D\u001F\u0018();
				object obj = \u0019\u001A\u0018.\u0003(this.\u000C, \u0005\u0011\u000F.\u0018(this.\u0018.Q, 0));
				if (obj == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MethodBindingExtension.\u0004\u001F\u0018.\u0014(object, EventArgs)).MethodHandle;
					}
					\u001A\u0011\u000F.\u0018("[MethodBinding] First method binding argument is required and cannot resolve to null - method name or method target expected.");
					return;
				}
				u001D_u001F_u.\u000C = \u0014\u0004\u000F.\u000C(obj);
				object obj2;
				int num;
				if (u001D_u001F_u.\u000C != null)
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
					obj2 = \u0003\u0012\u0014.\u0014(this.\u000C);
					num = 1;
				}
				else
				{
					if (\u0014\u0011\u0016.\u0018(this.\u0018.Q) < 2)
					{
						\u001A\u0011\u000F.\u0018(\u001A\u001E\u0018.\u0018("[MethodBinding] Method name must resolve to a '{0}' (actual type: '{1}').", \u000A\u001D\u0018.\u0018(\u001A\u0002\u000F.\u000C()), \u0004\u0017\u0018.\u0014(obj)));
						return;
					}
					for (;;)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					obj2 = obj;
					num = 2;
					object obj3 = \u0019\u001A\u0018.\u0003(this.\u000C, \u0005\u0011\u000F.\u0018(this.\u0018.Q, 1));
					if (obj3 == null)
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
						\u001A\u0011\u000F.\u0018(\u001C\u001E\u0018.\u0018("[MethodBinding] First argument resolved as a method target object of type '{0}', second argument must resolve to a method name and cannot resolve to null.", \u0004\u0017\u0018.\u0014(obj2)));
						return;
					}
					u001D_u001F_u.\u000C = \u0014\u0004\u000F.\u000C(obj3);
					if (u001D_u001F_u.\u000C == null)
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
						\u001A\u0011\u000F.\u0018(\u0007\u000C\u0003.\u0018("[MethodBinding] First argument resolved as a method target object of type '{0}', second argument (method name) must resolve to a '{1}' (actual type: '{2}').", \u0004\u0017\u0018.\u0014(obj2), \u000A\u001D\u0018.\u0018(\u001A\u0002\u000F.\u000C()), \u0004\u0017\u0018.\u0014(obj3)));
						return;
					}
				}
				u001D_u001F_u.\u0018 = \u0008\u001E\u000F.\u000C(\u0014\u0011\u0016.\u0018(this.\u0018.Q) - num);
				for (int i = num; i < \u0014\u0011\u0016.\u0018(this.\u0018.Q); i++)
				{
					object obj4 = \u0019\u001A\u0018.\u0003(this.\u000C, \u0005\u0011\u000F.\u0018(this.\u0018.Q, i));
					if (\u0006\u0008\u000F.\u000C(obj4) != null)
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
						obj4 = \u000C;
					}
					else
					{
						EventArgsExtension eventArgsExtension = \u0008\u0008\u000F.\u000C(obj4);
						if (eventArgsExtension != null)
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
							obj4 = eventArgsExtension.N(\u0018, \u001B\u0011\u000F.\u0018(this.\u000C));
						}
					}
					u001D_u001F_u.\u0018[i - num] = obj4;
				}
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				Type type = \u0004\u0017\u0018.\u0014(obj2);
				try
				{
					MethodInfo[] array = \u0001\u0011\u000F.\u0018(type, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
					MethodInfo u000C = Enumerable.FirstOrDefault<MethodInfo>(array, new Func<MethodInfo, bool>(u001D_u001F_u.\u0003));
					if (\u000B\u0011\u000F.\u0018(u000C, \u0001\u0008\u000F.\u000C))
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
						IEnumerable<MethodInfo> enumerable = array;
						Func<MethodInfo, bool> func;
						if ((func = MethodBindingExtension.<>c.\u0014) == null)
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
							func = (MethodBindingExtension.<>c.\u0014 = new Func<MethodInfo, bool>(MethodBindingExtension.<>c.\u000C.\u0003));
						}
						u000C = Enumerable.FirstOrDefault<MethodInfo>(Enumerable.Where<MethodInfo>(enumerable, func), new Func<MethodInfo, bool>(u001D_u001F_u.\u000F));
					}
					u001D_u001F_u.\u000C = \u0004\u0011\u000F.\u0018(u000C);
					\u000F\u001C\u0014.\u0014(u000C, obj2, u001D_u001F_u.\u0018);
					return;
				}
				catch (MissingMethodException)
				{
				}
				catch (NullReferenceException)
				{
				}
				catch (Exception)
				{
				}
				MethodInfo methodInfo = Enumerable.SingleOrDefault<MethodInfo>(\u0008\u0011\u000F.\u0018(type), new Func<MethodInfo, bool>(u001D_u001F_u.\u0012));
				if (\u0006\u0011\u000F.\u0018(methodInfo, \u0001\u0008\u000F.\u000C))
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
					ParameterInfo[] array2 = \u0007\u001F\u0016.\u0018(methodInfo);
					int j = 0;
					while (j < (int)\u001E\u0004\u000F.\u000C(u001D_u001F_u.\u0018))
					{
						if (u001D_u001F_u.\u0018[j] == null)
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
							if (\u0010\u0011\u000F.\u0018(\u0019\u001F\u0016.\u0018(array2[j])))
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
								methodInfo = \u0001\u0008\u000F.\u000C;
								goto IL_457;
							}
						}
						else
						{
							if (\u0014\u0004\u000F.\u000C(u001D_u001F_u.\u0018[j]) != null)
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
								if (\u0010\u0012\u0014.\u0018(\u0019\u001F\u0016.\u0018(array2[j]), \u000A\u001D\u0018.\u0018(\u001A\u0002\u000F.\u000C())))
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
									u001D_u001F_u.\u0018[j] = \u0019\u0011\u000F.\u0018(\u0007\u0011\u000F.\u0018(\u0019\u001F\u0016.\u0018(array2[j])), \u001E\u0002\u000F.\u000C(u001D_u001F_u.\u0018[j]));
									goto IL_432;
								}
							}
							if (!\u0017\u0011\u000F.\u0018(\u0019\u001F\u0016.\u0018(array2[j]), u001D_u001F_u.\u0018[j]))
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
								methodInfo = \u0001\u0008\u000F.\u000C;
								goto IL_457;
							}
						}
						IL_432:
						j++;
						continue;
						IL_457:
						if (methodInfo != null)
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
							\u000F\u001C\u0014.\u0003(methodInfo, obj2, u001D_u001F_u.\u0018);
							goto IL_476;
						}
						goto IL_476;
					}
					for (;;)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						goto IL_457;
					}
				}
				IL_476:
				if (\u000B\u0011\u000F.\u0018(methodInfo, \u0001\u0008\u000F.\u000C))
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
					\u001A\u0011\u000F.\u0018(\u001A\u001E\u0018.\u0018("[MethodBinding] Could not find a method '{0}' on target type '{1}' that accepts the parameters provided.", u001D_u001F_u.\u000C, type));
				}
			}

			// Token: 0x040008A2 RID: 2210
			public FrameworkElement \u000C;

			// Token: 0x040008A3 RID: 2211
			public MethodBindingExtension \u0018;
		}

		// Token: 0x020001DB RID: 475
		[CompilerGenerated]
		private sealed class \u001D\u001F\u0018
		{
			// Token: 0x0600121C RID: 4636 RVA: 0x0005E394 File Offset: 0x0005C594
			internal bool \u0003(MethodInfo \u000C)
			{
				IEnumerable<object> enumerable = \u0011\u0016\u0016.\u0018(\u000C, \u000A\u001D\u0018.\u0018(\u0005\u0008\u000F.\u000C()), true);
				Func<object, bool> func;
				if ((func = this.\u0014) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MethodBindingExtension.\u001D\u001F\u0018.\u0003(MethodInfo)).MethodHandle;
					}
					func = (this.\u0014 = new Func<object, bool>(this.\u0016));
				}
				return Enumerable.FirstOrDefault<object>(enumerable, func) != null;
			}

			// Token: 0x0600121D RID: 4637 RVA: 0x0005E3F4 File Offset: 0x0005C5F4
			internal bool \u0016(object \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u000E\u0011\u000F.\u0018(\u001B\u0008\u000F.\u000C(\u000C)), this.\u000C);
			}

			// Token: 0x0600121E RID: 4638 RVA: 0x0005E420 File Offset: 0x0005C620
			internal bool \u000F(MethodInfo \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u0004\u0011\u000F.\u0018(\u000C), this.\u000C);
			}

			// Token: 0x0600121F RID: 4639 RVA: 0x0005E444 File Offset: 0x0005C644
			internal bool \u0012(MethodInfo \u000C)
			{
				if (\u000F\u0002\u0018.\u0018(\u0004\u0011\u000F.\u0018(\u000C), this.\u000C))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MethodBindingExtension.\u001D\u001F\u0018.\u0012(MethodInfo)).MethodHandle;
					}
					return (int)\u000B\u0010\u000F.\u000C(\u0007\u001F\u0016.\u0018(\u000C)) == (int)\u001E\u0004\u000F.\u000C(this.\u0018);
				}
				return false;
			}

			// Token: 0x040008A4 RID: 2212
			public string \u000C;

			// Token: 0x040008A5 RID: 2213
			public object[] \u0018;

			// Token: 0x040008A6 RID: 2214
			public Func<object, bool> \u0014;
		}

		// Token: 0x020001DC RID: 476
		[CompilerGenerated]
		private sealed class \u001A\u001F\u0018
		{
			// Token: 0x06001221 RID: 4641 RVA: 0x0005E4B4 File Offset: 0x0005C6B4
			internal bool \u0018(DependencyProperty \u000C)
			{
				return \u000C\u0015\u000F.\u0018(this.\u000C, \u000C) == DependencyProperty.UnsetValue;
			}

			// Token: 0x040008A7 RID: 2215
			public DependencyObject \u000C;
		}
	}
}
