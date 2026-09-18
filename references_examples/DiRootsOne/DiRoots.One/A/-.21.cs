using System;
using System.Reflection;
using System.Reflection.Emit;

namespace A
{
	// Token: 0x0200001F RID: 31
	internal class \u0009\u001B\u000A
	{
		// Token: 0x060000F0 RID: 240 RVA: 0x000053E0 File Offset: 0x000035E0
		static \u0009\u001B\u000A()
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0009\u001B\u000A..cctor()).MethodHandle;
				}
				\u0009\u001B\u000A.\u001E = Assembly.GetExecutingAssembly().GetModules()[0].ModuleHandle;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00005440 File Offset: 0x00003640
		private int \u0020
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00005450 File Offset: 0x00003650
		public static void \u0017(int \u001F, int \u000A, int \u0007)
		{
			Type typeFromHandle;
			MethodInfo methodInfo;
			try
			{
				typeFromHandle = Type.GetTypeFromHandle(\u0009\u001B\u000A.\u001E.ResolveTypeHandle(\u001F));
				object methodFromHandle;
				if (\u0007 == 16777215)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0009\u001B\u000A.\u0017(int, int, int)).MethodHandle;
					}
					methodFromHandle = MethodBase.GetMethodFromHandle(\u0009\u001B\u000A.\u001E.ResolveMethodHandle(\u000A));
				}
				else
				{
					methodFromHandle = MethodBase.GetMethodFromHandle(\u0009\u001B\u000A.\u001E.ResolveMethodHandle(\u000A), \u0009\u001B\u000A.\u001E.ResolveTypeHandle(\u0007));
				}
				methodInfo = \u000A\u0002\u0008.\u001F(methodFromHandle);
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
						int num = (int)\u0007\u0002\u0008.\u001F(parameters) + 1;
						Type[] array = \u0011\u0016\u000E.\u001F(num);
						if (methodInfo.DeclaringType.IsValueType)
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
							array[0] = methodInfo.DeclaringType.MakeByRefType();
						}
						else
						{
							array[0] = Type.GetTypeFromHandle(\u000D\u0001\u0010.\u001F());
						}
						for (int j = 1; j < num; j++)
						{
							array[j] = parameters[j - 1].ParameterType;
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
						DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, methodInfo.ReturnType, array, typeFromHandle, true);
						ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
						ilgenerator.Emit(OpCodes.Ldarg_0);
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
								switch (7)
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
								switch (2)
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
								switch (6)
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
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
		}

		// Token: 0x04000033 RID: 51
		private static readonly int \u001F;

		// Token: 0x04000034 RID: 52
		private static readonly int \u000A;

		// Token: 0x04000035 RID: 53
		private static readonly int \u0007;

		// Token: 0x04000036 RID: 54
		private static readonly int \u001D;

		// Token: 0x04000037 RID: 55
		private static readonly int \u0004;

		// Token: 0x04000038 RID: 56
		private static readonly int \u0019;

		// Token: 0x04000039 RID: 57
		private static readonly int \u0018;

		// Token: 0x0400003A RID: 58
		private static readonly int \u0005;

		// Token: 0x0400003B RID: 59
		private static readonly int \u0016;

		// Token: 0x0400003C RID: 60
		private static readonly int \u000B;

		// Token: 0x0400003D RID: 61
		private static readonly int \u0002;

		// Token: 0x0400003E RID: 62
		private static readonly int \u0006;

		// Token: 0x0400003F RID: 63
		private static readonly int \u000F;

		// Token: 0x04000040 RID: 64
		private static readonly int \u0012;

		// Token: 0x04000041 RID: 65
		private static readonly int \u0003;

		// Token: 0x04000042 RID: 66
		private static readonly int \u001C;

		// Token: 0x04000043 RID: 67
		private static readonly int \u000D;

		// Token: 0x04000044 RID: 68
		private static readonly int \u0010;

		// Token: 0x04000045 RID: 69
		private static readonly int \u000E;

		// Token: 0x04000046 RID: 70
		private static readonly int \u0008;

		// Token: 0x04000047 RID: 71
		private static readonly int \u001B;

		// Token: 0x04000048 RID: 72
		private static readonly int \u0011;

		// Token: 0x04000049 RID: 73
		private static readonly ModuleHandle \u001E;
	}
}
