using System;
using System.Reflection;
using System.Reflection.Emit;

namespace A
{
	// Token: 0x02000022 RID: 34
	internal class \u0020\u0017\u0018
	{
		// Token: 0x06000149 RID: 329 RVA: 0x000082FC File Offset: 0x000064FC
		static \u0020\u0017\u0018()
		{
			if (Type.GetTypeFromHandle(\u0009\u0001\u000F.\u000C()) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0017\u0018..cctor()).MethodHandle;
				}
				\u0020\u0017\u0018.\u000B = Assembly.GetExecutingAssembly().GetModules()[0].ModuleHandle;
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000835C File Offset: 0x0000655C
		public static void \u0019(int \u000C, int \u0018, int \u0014)
		{
			Type typeFromHandle;
			ConstructorInfo constructorInfo;
			try
			{
				typeFromHandle = Type.GetTypeFromHandle(\u0020\u0017\u0018.\u000B.ResolveTypeHandle(\u000C));
				object methodFromHandle;
				if (\u0014 == 16777215)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0017\u0018.\u0019(int, int, int)).MethodHandle;
					}
					methodFromHandle = MethodBase.GetMethodFromHandle(\u0020\u0017\u0018.\u000B.ResolveMethodHandle(\u0018));
				}
				else
				{
					methodFromHandle = MethodBase.GetMethodFromHandle(\u0020\u0017\u0018.\u000B.ResolveMethodHandle(\u0018), \u0020\u0017\u0018.\u000B.ResolveTypeHandle(\u0014));
				}
				constructorInfo = \u000A\u0001\u000F.\u000C(methodFromHandle);
			}
			catch (Exception)
			{
				throw;
			}
			FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
			for (int i = 0; i < (int)\u0013\u0001\u000F.\u000C(fields); i++)
			{
				FieldInfo fieldInfo = fields[i];
				try
				{
					ParameterInfo[] parameters = constructorInfo.GetParameters();
					int num = (int)\u000B\u0010\u000F.\u000C(parameters);
					Type[] array = \u001C\u0001\u000F.\u000C(num);
					for (int j = 0; j < num; j++)
					{
						array[j] = parameters[j].ParameterType;
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
					DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, constructorInfo.DeclaringType, array, typeFromHandle, true);
					ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
					if (num > 0)
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
						ilgenerator.Emit(OpCodes.Ldarg_0);
					}
					if (num > 1)
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
							switch (3)
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
							switch (2)
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
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
		}

		// Token: 0x0400008B RID: 139
		private static readonly int \u000C;

		// Token: 0x0400008C RID: 140
		private static readonly int \u0018;

		// Token: 0x0400008D RID: 141
		private static readonly int \u0014;

		// Token: 0x0400008E RID: 142
		private static readonly int \u0003;

		// Token: 0x0400008F RID: 143
		private static readonly int \u0016;

		// Token: 0x04000090 RID: 144
		private static readonly int \u000F;

		// Token: 0x04000091 RID: 145
		private static readonly int \u0012;

		// Token: 0x04000092 RID: 146
		private static readonly int \u000D;

		// Token: 0x04000093 RID: 147
		private static readonly int \u001C;

		// Token: 0x04000094 RID: 148
		private static readonly int \u0013;

		// Token: 0x04000095 RID: 149
		private static readonly int \u0009;

		// Token: 0x04000096 RID: 150
		private static readonly int \u000A;

		// Token: 0x04000097 RID: 151
		private static readonly int \u0020;

		// Token: 0x04000098 RID: 152
		private static readonly int \u001F;

		// Token: 0x04000099 RID: 153
		private static readonly int \u0011;

		// Token: 0x0400009A RID: 154
		private static readonly int \u0015;

		// Token: 0x0400009B RID: 155
		private static readonly int \u0017;

		// Token: 0x0400009C RID: 156
		private static readonly int \u001E;

		// Token: 0x0400009D RID: 157
		private static readonly int \u0002;

		// Token: 0x0400009E RID: 158
		private static readonly int \u0004;

		// Token: 0x0400009F RID: 159
		private static readonly int \u001D;

		// Token: 0x040000A0 RID: 160
		private static readonly int \u001A;

		// Token: 0x040000A1 RID: 161
		private static readonly ModuleHandle \u000B;
	}
}
