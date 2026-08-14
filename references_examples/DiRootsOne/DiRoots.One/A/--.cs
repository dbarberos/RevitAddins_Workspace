using System;
using System.Reflection;
using System.Reflection.Emit;

namespace A
{
	// Token: 0x02000022 RID: 34
	internal class \u001F\u0011\u000A
	{
		// Token: 0x06000117 RID: 279 RVA: 0x000065A8 File Offset: 0x000047A8
		static \u001F\u0011\u000A()
		{
			if (Type.GetTypeFromHandle(\u0004\u0002\u0008.\u001F()) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0011\u000A..cctor()).MethodHandle;
				}
				\u001F\u0011\u000A.\u001E = Assembly.GetExecutingAssembly().GetModules()[0].ModuleHandle;
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00006608 File Offset: 0x00004808
		public static void \u0020(int \u001F, int \u000A, int \u0007)
		{
			Type typeFromHandle;
			ConstructorInfo constructorInfo;
			try
			{
				typeFromHandle = Type.GetTypeFromHandle(\u001F\u0011\u000A.\u001E.ResolveTypeHandle(\u001F));
				object methodFromHandle;
				if (\u0007 == 16777215)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0011\u000A.\u0020(int, int, int)).MethodHandle;
					}
					methodFromHandle = MethodBase.GetMethodFromHandle(\u001F\u0011\u000A.\u001E.ResolveMethodHandle(\u000A));
				}
				else
				{
					methodFromHandle = MethodBase.GetMethodFromHandle(\u001F\u0011\u000A.\u001E.ResolveMethodHandle(\u000A), \u001F\u0011\u000A.\u001E.ResolveTypeHandle(\u0007));
				}
				constructorInfo = \u0019\u0002\u0008.\u001F(methodFromHandle);
			}
			catch (Exception)
			{
				throw;
			}
			FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
			for (int i = 0; i < (int)\u001D\u0002\u0008.\u001F(fields); i++)
			{
				FieldInfo fieldInfo = fields[i];
				try
				{
					ParameterInfo[] parameters = constructorInfo.GetParameters();
					int num = (int)\u0007\u0002\u0008.\u001F(parameters);
					Type[] array = \u0011\u0016\u000E.\u001F(num);
					for (int j = 0; j < num; j++)
					{
						array[j] = parameters[j].ParameterType;
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
					DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, constructorInfo.DeclaringType, array, typeFromHandle, true);
					ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
					if (num > 0)
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
						ilgenerator.Emit(OpCodes.Ldarg_0);
					}
					if (num > 1)
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
						ilgenerator.Emit(OpCodes.Ldarg_1);
					}
					if (num > 2)
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
						ilgenerator.Emit(OpCodes.Ldarg_2);
					}
					if (num > 3)
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
						ilgenerator.Emit(OpCodes.Ldarg_3);
					}
					if (num > 4)
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
						for (int k = 4; k < num; k++)
						{
							ilgenerator.Emit(OpCodes.Ldarg_S, k);
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
					ilgenerator.Emit(OpCodes.Newobj, constructorInfo);
					ilgenerator.Emit(OpCodes.Ret);
					Delegate value = dynamicMethod.CreateDelegate(typeFromHandle);
					fieldInfo.SetValue(null, value);
				}
				catch (Exception)
				{
				}
			}
			for (;;)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
		}

		// Token: 0x0400004F RID: 79
		private static readonly int \u001F;

		// Token: 0x04000050 RID: 80
		private static readonly int \u000A;

		// Token: 0x04000051 RID: 81
		private static readonly int \u0007;

		// Token: 0x04000052 RID: 82
		private static readonly int \u001D;

		// Token: 0x04000053 RID: 83
		private static readonly int \u0004;

		// Token: 0x04000054 RID: 84
		private static readonly int \u0019;

		// Token: 0x04000055 RID: 85
		private static readonly int \u0018;

		// Token: 0x04000056 RID: 86
		private static readonly int \u0005;

		// Token: 0x04000057 RID: 87
		private static readonly int \u0016;

		// Token: 0x04000058 RID: 88
		private static readonly int \u000B;

		// Token: 0x04000059 RID: 89
		private static readonly int \u0002;

		// Token: 0x0400005A RID: 90
		private static readonly int \u0006;

		// Token: 0x0400005B RID: 91
		private static readonly int \u000F;

		// Token: 0x0400005C RID: 92
		private static readonly int \u0012;

		// Token: 0x0400005D RID: 93
		private static readonly int \u0003;

		// Token: 0x0400005E RID: 94
		private static readonly int \u001C;

		// Token: 0x0400005F RID: 95
		private static readonly int \u000D;

		// Token: 0x04000060 RID: 96
		private static readonly int \u0010;

		// Token: 0x04000061 RID: 97
		private static readonly int \u000E;

		// Token: 0x04000062 RID: 98
		private static readonly int \u0008;

		// Token: 0x04000063 RID: 99
		private static readonly int \u001B;

		// Token: 0x04000064 RID: 100
		private static readonly int \u0011;

		// Token: 0x04000065 RID: 101
		private static readonly ModuleHandle \u001E;
	}
}
