using System;
using System.Reflection;
using System.Reflection.Emit;

namespace A
{
	// Token: 0x02000024 RID: 36
	internal class \u001F\u0017\u0018
	{
		// Token: 0x0600015B RID: 347 RVA: 0x0000891C File Offset: 0x00006B1C
		static \u001F\u0017\u0018()
		{
			if (Type.GetTypeFromHandle(\u0009\u0001\u000F.\u000C()) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0017\u0018..cctor()).MethodHandle;
				}
				\u001F\u0017\u0018.\u000B = Assembly.GetExecutingAssembly().GetModules()[0].ModuleHandle;
			}
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0000897C File Offset: 0x00006B7C
		public static void \u0019(int \u000C, int \u0018, int \u0014)
		{
			Type typeFromHandle;
			ConstructorInfo constructorInfo;
			try
			{
				typeFromHandle = Type.GetTypeFromHandle(\u001F\u0017\u0018.\u000B.ResolveTypeHandle(\u000C));
				object methodFromHandle;
				if (\u0014 == 16777215)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0017\u0018.\u0019(int, int, int)).MethodHandle;
					}
					methodFromHandle = MethodBase.GetMethodFromHandle(\u001F\u0017\u0018.\u000B.ResolveMethodHandle(\u0018));
				}
				else
				{
					methodFromHandle = MethodBase.GetMethodFromHandle(\u001F\u0017\u0018.\u000B.ResolveMethodHandle(\u0018), \u001F\u0017\u0018.\u000B.ResolveTypeHandle(\u0014));
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
					int num = (int)\u000B\u0010\u000F.\u000C(parameters) + 1;
					Type[] array = \u001C\u0001\u000F.\u000C(num);
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
							switch (4)
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
							switch (4)
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
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
		}

		// Token: 0x040000A6 RID: 166
		private static readonly int \u000C;

		// Token: 0x040000A7 RID: 167
		private static readonly int \u0018;

		// Token: 0x040000A8 RID: 168
		private static readonly int \u0014;

		// Token: 0x040000A9 RID: 169
		private static readonly int \u0003;

		// Token: 0x040000AA RID: 170
		private static readonly int \u0016;

		// Token: 0x040000AB RID: 171
		private static readonly int \u000F;

		// Token: 0x040000AC RID: 172
		private static readonly int \u0012;

		// Token: 0x040000AD RID: 173
		private static readonly int \u000D;

		// Token: 0x040000AE RID: 174
		private static readonly int \u001C;

		// Token: 0x040000AF RID: 175
		private static readonly int \u0013;

		// Token: 0x040000B0 RID: 176
		private static readonly int \u0009;

		// Token: 0x040000B1 RID: 177
		private static readonly int \u000A;

		// Token: 0x040000B2 RID: 178
		private static readonly int \u0020;

		// Token: 0x040000B3 RID: 179
		private static readonly int \u001F;

		// Token: 0x040000B4 RID: 180
		private static readonly int \u0011;

		// Token: 0x040000B5 RID: 181
		private static readonly int \u0015;

		// Token: 0x040000B6 RID: 182
		private static readonly int \u0017;

		// Token: 0x040000B7 RID: 183
		private static readonly int \u001E;

		// Token: 0x040000B8 RID: 184
		private static readonly int \u0002;

		// Token: 0x040000B9 RID: 185
		private static readonly int \u0004;

		// Token: 0x040000BA RID: 186
		private static readonly int \u001D;

		// Token: 0x040000BB RID: 187
		private static readonly int \u001A;

		// Token: 0x040000BC RID: 188
		private static readonly ModuleHandle \u000B;
	}
}
