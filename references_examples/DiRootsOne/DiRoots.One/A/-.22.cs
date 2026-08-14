using System;
using System.Reflection;
using System.Reflection.Emit;

namespace A
{
	// Token: 0x02000024 RID: 36
	internal class \u000A\u0011\u000A
	{
		// Token: 0x0600012E RID: 302 RVA: 0x00007110 File Offset: 0x00005310
		static \u000A\u0011\u000A()
		{
			if (Type.GetTypeFromHandle(\u0004\u0002\u0008.\u001F()) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0011\u000A..cctor()).MethodHandle;
				}
				\u000A\u0011\u000A.\u001E = Assembly.GetExecutingAssembly().GetModules()[0].ModuleHandle;
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00007170 File Offset: 0x00005370
		public static void \u0020(int \u001F, int \u000A, int \u0007)
		{
			Type typeFromHandle;
			ConstructorInfo constructorInfo;
			try
			{
				typeFromHandle = Type.GetTypeFromHandle(\u000A\u0011\u000A.\u001E.ResolveTypeHandle(\u001F));
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0011\u000A.\u0020(int, int, int)).MethodHandle;
					}
					methodFromHandle = MethodBase.GetMethodFromHandle(\u000A\u0011\u000A.\u001E.ResolveMethodHandle(\u000A));
				}
				else
				{
					methodFromHandle = MethodBase.GetMethodFromHandle(\u000A\u0011\u000A.\u001E.ResolveMethodHandle(\u000A), \u000A\u0011\u000A.\u001E.ResolveTypeHandle(\u0007));
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
					int num = (int)\u0007\u0002\u0008.\u001F(parameters) + 1;
					Type[] array = \u0011\u0016\u000E.\u001F(num);
					array[0] = constructorInfo.DeclaringType.MakeByRefType();
					for (int j = 1; j < num; j++)
					{
						array[j] = parameters[j - 1].ParameterType;
					}
					for (;;)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, null, array, typeFromHandle, true);
					ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
					if (num > 0)
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
						ilgenerator.Emit(OpCodes.Ldarg_0);
					}
					if (num > 1)
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
						ilgenerator.Emit(OpCodes.Ldarg_1);
					}
					if (num > 2)
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
						ilgenerator.Emit(OpCodes.Ldarg_2);
					}
					if (num > 3)
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
						ilgenerator.Emit(OpCodes.Ldarg_3);
					}
					if (num > 4)
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
					ilgenerator.Emit(OpCodes.Call, constructorInfo);
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
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
		}

		// Token: 0x0400006B RID: 107
		private static readonly int \u001F;

		// Token: 0x0400006C RID: 108
		private static readonly int \u000A;

		// Token: 0x0400006D RID: 109
		private static readonly int \u0007;

		// Token: 0x0400006E RID: 110
		private static readonly int \u001D;

		// Token: 0x0400006F RID: 111
		private static readonly int \u0004;

		// Token: 0x04000070 RID: 112
		private static readonly int \u0019;

		// Token: 0x04000071 RID: 113
		private static readonly int \u0018;

		// Token: 0x04000072 RID: 114
		private static readonly int \u0005;

		// Token: 0x04000073 RID: 115
		private static readonly int \u0016;

		// Token: 0x04000074 RID: 116
		private static readonly int \u000B;

		// Token: 0x04000075 RID: 117
		private static readonly int \u0002;

		// Token: 0x04000076 RID: 118
		private static readonly int \u0006;

		// Token: 0x04000077 RID: 119
		private static readonly int \u000F;

		// Token: 0x04000078 RID: 120
		private static readonly int \u0012;

		// Token: 0x04000079 RID: 121
		private static readonly int \u0003;

		// Token: 0x0400007A RID: 122
		private static readonly int \u001C;

		// Token: 0x0400007B RID: 123
		private static readonly int \u000D;

		// Token: 0x0400007C RID: 124
		private static readonly int \u0010;

		// Token: 0x0400007D RID: 125
		private static readonly int \u000E;

		// Token: 0x0400007E RID: 126
		private static readonly int \u0008;

		// Token: 0x0400007F RID: 127
		private static readonly int \u001B;

		// Token: 0x04000080 RID: 128
		private static readonly int \u0011;

		// Token: 0x04000081 RID: 129
		private static readonly ModuleHandle \u001E;
	}
}
