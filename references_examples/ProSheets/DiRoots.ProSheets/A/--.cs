using System;
using System.Reflection;
using System.Reflection.Emit;

namespace A
{
	// Token: 0x0200001F RID: 31
	internal class \u000A\u0017\u0018
	{
		// Token: 0x0600010F RID: 271 RVA: 0x00007164 File Offset: 0x00005364
		static \u000A\u0017\u0018()
		{
			if (Type.GetTypeFromHandle(\u0009\u0001\u000F.\u000C()) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0017\u0018..cctor()).MethodHandle;
				}
				\u000A\u0017\u0018.\u000B = Assembly.GetExecutingAssembly().GetModules()[0].ModuleHandle;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000111 RID: 273 RVA: 0x000071C4 File Offset: 0x000053C4
		private int \u0019
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000071D4 File Offset: 0x000053D4
		public static void \u0007(int \u000C, int \u0018, int \u0014)
		{
			Type typeFromHandle;
			MethodInfo methodInfo;
			try
			{
				typeFromHandle = Type.GetTypeFromHandle(\u000A\u0017\u0018.\u000B.ResolveTypeHandle(\u000C));
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0017\u0018.\u0007(int, int, int)).MethodHandle;
					}
					methodFromHandle = MethodBase.GetMethodFromHandle(\u000A\u0017\u0018.\u000B.ResolveMethodHandle(\u0018));
				}
				else
				{
					methodFromHandle = MethodBase.GetMethodFromHandle(\u000A\u0017\u0018.\u000B.ResolveMethodHandle(\u0018), \u000A\u0017\u0018.\u000B.ResolveTypeHandle(\u0014));
				}
				methodInfo = \u000D\u0001\u000F.\u000C(methodFromHandle);
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
					Delegate value;
					if (methodInfo.IsStatic)
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
						value = Delegate.CreateDelegate(fieldInfo.FieldType, methodInfo);
					}
					else
					{
						ParameterInfo[] parameters = methodInfo.GetParameters();
						int num = (int)\u000B\u0010\u000F.\u000C(parameters) + 1;
						Type[] array = \u001C\u0001\u000F.\u000C(num);
						if (methodInfo.DeclaringType.IsValueType)
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
							array[0] = methodInfo.DeclaringType.MakeByRefType();
						}
						else
						{
							array[0] = Type.GetTypeFromHandle(\u0002\u0004\u000F.\u000C());
						}
						for (int j = 1; j < num; j++)
						{
							array[j] = parameters[j - 1].ParameterType;
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
						DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, methodInfo.ReturnType, array, typeFromHandle, true);
						ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
						ilgenerator.Emit(OpCodes.Ldarg_0);
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
								switch (1)
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
								switch (7)
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
								switch (7)
								{
								case 0:
									continue;
								}
								break;
							}
						}
						ILGenerator ilgenerator2 = ilgenerator;
						OpCode opcode;
						if (!fieldInfo.IsFamilyOrAssembly)
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
							opcode = OpCodes.Call;
						}
						else
						{
							opcode = OpCodes.Callvirt;
						}
						ilgenerator2.Emit(opcode, methodInfo);
						ilgenerator.Emit(OpCodes.Ret);
						value = dynamicMethod.CreateDelegate(typeFromHandle);
					}
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

		// Token: 0x04000069 RID: 105
		private static readonly int \u000C;

		// Token: 0x0400006A RID: 106
		private static readonly int \u0018;

		// Token: 0x0400006B RID: 107
		private static readonly int \u0014;

		// Token: 0x0400006C RID: 108
		private static readonly int \u0003;

		// Token: 0x0400006D RID: 109
		private static readonly int \u0016;

		// Token: 0x0400006E RID: 110
		private static readonly int \u000F;

		// Token: 0x0400006F RID: 111
		private static readonly int \u0012;

		// Token: 0x04000070 RID: 112
		private static readonly int \u000D;

		// Token: 0x04000071 RID: 113
		private static readonly int \u001C;

		// Token: 0x04000072 RID: 114
		private static readonly int \u0013;

		// Token: 0x04000073 RID: 115
		private static readonly int \u0009;

		// Token: 0x04000074 RID: 116
		private static readonly int \u000A;

		// Token: 0x04000075 RID: 117
		private static readonly int \u0020;

		// Token: 0x04000076 RID: 118
		private static readonly int \u001F;

		// Token: 0x04000077 RID: 119
		private static readonly int \u0011;

		// Token: 0x04000078 RID: 120
		private static readonly int \u0015;

		// Token: 0x04000079 RID: 121
		private static readonly int \u0017;

		// Token: 0x0400007A RID: 122
		private static readonly int \u001E;

		// Token: 0x0400007B RID: 123
		private static readonly int \u0002;

		// Token: 0x0400007C RID: 124
		private static readonly int \u0004;

		// Token: 0x0400007D RID: 125
		private static readonly int \u001D;

		// Token: 0x0400007E RID: 126
		private static readonly int \u001A;

		// Token: 0x0400007F RID: 127
		private static readonly ModuleHandle \u000B;
	}
}
