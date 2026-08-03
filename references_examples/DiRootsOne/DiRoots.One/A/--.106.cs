using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DiRoots.One.Morta.Model;
using DiRoots.One.Morta.Model.CustomTable;
using DiRoots.One.Morta.Model.Exceptions;
using DiRoots.One.Morta.Model.Json.Column;
using DiRoots.One.Morta.Model.Json.Project;
using DiRoots.One.Morta.Model.Json.Table;
using DiRoots.One.Morta.Model.Json.TableType;
using DiRoots.One.SheetLink.Models;
using DiRoots.One.SheetLink.Morta.Enums;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using RestSharp;

namespace A
{
	// Token: 0x020001B7 RID: 439
	internal class \u0013\u0006
	{
		// Token: 0x06001061 RID: 4193 RVA: 0x00067C5C File Offset: 0x00065E5C
		public \u0013\u0006(Login \u001F)
		{
			\u0013\u0019\u0018.\u000A(this, \u001F);
		}

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x06001062 RID: 4194 RVA: 0x00067C78 File Offset: 0x00065E78
		// (set) Token: 0x06001063 RID: 4195 RVA: 0x00067C8C File Offset: 0x00065E8C
		public Login LoginInstance { get; set; }

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x06001064 RID: 4196 RVA: 0x00067CA0 File Offset: 0x00065EA0
		private string \u000A
		{
			get
			{
				Login login = \u0017\u0007\u0018.\u001D(this);
				if (login == null)
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u0006.get_\u000A()).MethodHandle;
					}
					return null;
				}
				return \u0017\u0019\u0018.\u000A(login);
			}
		}

		// Token: 0x06001065 RID: 4197 RVA: 0x00067CD8 File Offset: 0x00065ED8
		public List<ProjectData> \u0007()
		{
			\u0008\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Model\\MortaUtil.cs", "GetProjects");
			List<ProjectData> list = \u0013\u0007\u0018.\u000A();
			object u001F = \u0020\u0019\u0018.\u000A("https://api.morta.io/v1");
			RestRequest u000A = \u001E\u0019\u0018.\u000A("user/projects").\u001F(this.\u000A);
			IRestResponse u001F2 = \u0011\u0019\u0018.\u000A(u001F, u000A);
			if (\u001B\u0019\u0018.\u000A(u001F2))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u0006.\u0007()).MethodHandle;
				}
				string text = \u0008\u0019\u0018.\u000A(u001F2);
				if (text != null)
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
					DiRoots.One.Morta.Model.Json.Project.Datum[] array = \u000A\u0018\u0018.\u000A(JsonConvert.DeserializeObject<ProjectInfo>(text));
					for (int i = 0; i < (int)\u0013\u0016\u000E.\u001F(array); i++)
					{
						DiRoots.One.Morta.Model.Json.Project.Datum u001F3 = array[i];
						if (!\u001F\u0018\u0018.\u000A(u001F3))
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
							ProjectData projectData = \u0009\u0019\u0018.\u000A();
							\u0010\u0007\u0018.\u0007(projectData, \u0001\u0019\u0018.\u000A(u001F3));
							\u000C\u0019\u0018.\u000A(projectData, \u0015\u0019\u0018.\u000A(u001F3));
							ProjectData u000A2 = projectData;
							\u001A\u0019\u0018.\u000A(list, u000A2);
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
			}
			\u0005\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Model\\MortaUtil.cs", "GetProjects");
			return list;
		}

		// Token: 0x06001066 RID: 4198 RVA: 0x00067E04 File Offset: 0x00066004
		public Task \u001D(string \u001F)
		{
			\u0013\u0006.\u001B\u0006 u001B_u;
			u001B_u.\u000A = \u0008\u0011\u000A.\u000A();
			u001B_u.\u001D = this;
			u001B_u.\u0007 = \u001F;
			u001B_u.\u001F = -1;
			u001B_u.\u000A.Start<\u0013\u0006.\u001B\u0006>(ref u001B_u);
			return \u000E\u0011\u000A.\u000A(ref u001B_u.\u000A);
		}

		// Token: 0x06001067 RID: 4199 RVA: 0x00067E54 File Offset: 0x00066054
		public Task \u0004(TableInfo \u001F)
		{
			\u0013\u0006.\u0017\u0006 u0017_u;
			u0017_u.\u000A = \u0008\u0011\u000A.\u000A();
			u0017_u.\u0007 = this;
			u0017_u.\u001D = \u001F;
			u0017_u.\u001F = -1;
			u0017_u.\u000A.Start<\u0013\u0006.\u0017\u0006>(ref u0017_u);
			return \u000E\u0011\u000A.\u000A(ref u0017_u.\u000A);
		}

		// Token: 0x06001068 RID: 4200 RVA: 0x00067EA4 File Offset: 0x000660A4
		private Task \u0019(TableInfo \u001F)
		{
			\u0013\u0006.\u000E\u0006 u000E_u;
			u000E_u.\u000A = \u0008\u0011\u000A.\u000A();
			u000E_u.\u0007 = this;
			u000E_u.\u001D = \u001F;
			u000E_u.\u001F = -1;
			u000E_u.\u000A.Start<\u0013\u0006.\u000E\u0006>(ref u000E_u);
			return \u000E\u0011\u000A.\u000A(ref u000E_u.\u000A);
		}

		// Token: 0x06001069 RID: 4201 RVA: 0x00067EF4 File Offset: 0x000660F4
		private Task \u0018(TableInfo \u001F)
		{
			\u0013\u0006.\u0020\u0006 u0020_u;
			u0020_u.\u000A = \u0008\u0011\u000A.\u000A();
			u0020_u.\u001D = this;
			u0020_u.\u0007 = \u001F;
			u0020_u.\u001F = -1;
			u0020_u.\u000A.Start<\u0013\u0006.\u0020\u0006>(ref u0020_u);
			return \u000E\u0011\u000A.\u000A(ref u0020_u.\u000A);
		}

		// Token: 0x0600106A RID: 4202 RVA: 0x00067F44 File Offset: 0x00066144
		private Task<string> \u0005(TableInfo \u001F, ColumnInfo \u000A)
		{
			\u0013\u0006.\u000D\u0006 u000D_u;
			u000D_u.\u000A = \u001D\u0018\u0018.\u000A();
			u000D_u.\u001D = this;
			u000D_u.\u0007 = \u001F;
			u000D_u.\u0004 = \u000A;
			u000D_u.\u001F = -1;
			u000D_u.\u000A.Start<\u0013\u0006.\u000D\u0006>(ref u000D_u);
			return \u0007\u0018\u0018.\u000A(ref u000D_u.\u000A);
		}

		// Token: 0x0600106B RID: 4203 RVA: 0x00067F9C File Offset: 0x0006619C
		private Task<string> \u0016(TableInfo \u001F, ColumnInfo \u000A, Column \u0007, bool \u001D)
		{
			\u0013\u0006.\u001E\u0006 u001E_u;
			u001E_u.\u000A = \u001D\u0018\u0018.\u000A();
			u001E_u.\u0018 = this;
			u001E_u.\u0004 = \u001F;
			u001E_u.\u0007 = \u000A;
			u001E_u.\u0019 = \u0007;
			u001E_u.\u001D = \u001D;
			u001E_u.\u001F = -1;
			u001E_u.\u000A.Start<\u0013\u0006.\u001E\u0006>(ref u001E_u);
			return \u0007\u0018\u0018.\u000A(ref u001E_u.\u000A);
		}

		// Token: 0x0600106C RID: 4204 RVA: 0x00068004 File Offset: 0x00066204
		public List<TableTypeInfo> \u000B(string \u001F)
		{
			\u0008\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Model\\MortaUtil.cs", "GetTableTypes");
			List<TableTypeInfo> list = \u0003\u0018\u0018.\u000A();
			object u001F = \u0020\u0019\u0018.\u000A("https://api.morta.io/v1");
			RestRequest u000A = \u0012\u0018\u0018.\u000A(\u0004\u001E\u000A.\u000A("project/", \u001F), \u0003\u000E.\u001F(CustomRequestMethod.Get)).\u001F(this.\u000A);
			IRestResponse restResponse = \u0011\u0019\u0018.\u000A(u001F, u000A);
			if (\u001B\u0019\u0018.\u000A(restResponse))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u0006.\u000B(string)).MethodHandle;
				}
				string text = \u0008\u0019\u0018.\u000A(restResponse);
				if (text == null)
				{
					goto IL_11B;
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
				List<Folder>.Enumerator enumerator = \u0002\u0018\u0018.\u000A(\u0006\u0018\u0018.\u000A(\u000F\u0018\u0018.\u000A(JsonConvert.DeserializeObject<ProjectFolder>(text))));
				try
				{
					while (\u0019\u0018\u0018.\u000A(ref enumerator))
					{
						Folder u001F2 = \u000B\u0018\u0018.\u000A(ref enumerator);
						object u001F3 = list;
						TableTypeInfo tableTypeInfo = \u0006\u001D\u0018.\u000A();
						\u0012\u0007\u0018.\u000A(tableTypeInfo, \u0016\u0018\u0018.\u000A(u001F2));
						\u0010\u0007\u0018.\u0007(tableTypeInfo, \u0005\u0018\u0018.\u000A(u001F2));
						\u0018\u0018\u0018.\u000A(u001F3, tableTypeInfo);
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
					goto IL_11B;
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			\u0004\u0018\u0018.InvokeStub(this, restResponse);
			IL_11B:
			\u0005\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Model\\MortaUtil.cs", "GetTableTypes");
			return list;
		}

		// Token: 0x0600106D RID: 4205 RVA: 0x00068154 File Offset: 0x00066354
		public List<TableInfo> \u0002(string \u001F)
		{
			\u0013\u0006.\u0003\u0006 u0003_u = new \u0013\u0006.\u0003\u0006();
			\u0008\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Model\\MortaUtil.cs", "GetTables");
			u0003_u.\u001F = \u0014\u0007\u0018.\u000A();
			object u001F = \u0020\u0019\u0018.\u000A("https://api.morta.io/v1");
			RestRequest u000A = \u0012\u0018\u0018.\u000A(\u0002\u0013\u000A.\u000A("project/", \u001F, "/resources"), \u0003\u000E.\u001F(CustomRequestMethod.Post)).\u001F(this.\u000A);
			IRestResponse u001F2 = \u0011\u0019\u0018.\u000A(u001F, u000A);
			if (\u001B\u0019\u0018.\u000A(u001F2))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u0006.\u0002(string)).MethodHandle;
				}
				string text = \u0008\u0019\u0018.\u000A(u001F2);
				if (text != null)
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
					\u001C\u0018\u0018.\u000A(Enumerable.ToList<DiRoots.One.Morta.Model.Json.Project.Datum>(\u000A\u0018\u0018.\u000A(JsonConvert.DeserializeObject<ProjectInfo>(text))), new Action<DiRoots.One.Morta.Model.Json.Project.Datum>(u0003_u.\u000A));
				}
			}
			\u0005\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Model\\MortaUtil.cs", "GetTables");
			return u0003_u.\u001F;
		}

		// Token: 0x0600106E RID: 4206 RVA: 0x00068248 File Offset: 0x00066448
		public Task<string> \u0006(string \u001F, TableInfo \u000A)
		{
			\u0013\u0006.\u0008\u0006 u0008_u;
			u0008_u.\u000A = \u001D\u0018\u0018.\u000A();
			u0008_u.\u0007 = this;
			u0008_u.\u001D = \u001F;
			u0008_u.\u0004 = \u000A;
			u0008_u.\u001F = -1;
			u0008_u.\u000A.Start<\u0013\u0006.\u0008\u0006>(ref u0008_u);
			return \u0007\u0018\u0018.\u000A(ref u0008_u.\u000A);
		}

		// Token: 0x0600106F RID: 4207 RVA: 0x000682A0 File Offset: 0x000664A0
		public Task<CreatedTableInfo> \u000F(string \u001F, TableInfo \u000A)
		{
			\u0013\u0006.\u0014\u0006 u0014_u;
			u0014_u.\u000A = \u0010\u0018\u0018.\u000A();
			u0014_u.\u0007 = this;
			u0014_u.\u001D = \u001F;
			u0014_u.\u0004 = \u000A;
			u0014_u.\u001F = -1;
			u0014_u.\u000A.Start<\u0013\u0006.\u0014\u0006>(ref u0014_u);
			return \u000D\u0018\u0018.\u000A(ref u0014_u.\u000A);
		}

		// Token: 0x06001070 RID: 4208 RVA: 0x000682F8 File Offset: 0x000664F8
		internal TableInformationClass \u0012(string \u001F)
		{
			\u0008\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Model\\MortaUtil.cs", "GetTableInformation");
			object u001F = \u0020\u0019\u0018.\u000A("https://api.morta.io/v1");
			RestRequest u000A = \u001E\u0019\u0018.\u000A(\u0004\u001E\u000A.\u000A("table/", \u001F)).\u001F(this.\u000A);
			TableInformationClass result = \u0014\u0016\u000E.\u001F;
			IRestResponse u001F2 = \u0011\u0019\u0018.\u000A(u001F, u000A);
			if (\u001B\u0019\u0018.\u000A(u001F2))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u0006.\u0012(string)).MethodHandle;
				}
				string text = \u0008\u0019\u0018.\u000A(u001F2);
				if (text != null)
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
					result = JsonConvert.DeserializeObject<TableInformationClass>(text);
				}
			}
			\u0005\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Model\\MortaUtil.cs", "GetTableInformation");
			return result;
		}

		// Token: 0x06001071 RID: 4209 RVA: 0x000683B0 File Offset: 0x000665B0
		internal List<string> \u0003(string \u001F)
		{
			\u001B\u0018\u0018.\u000A();
			string u001F = \u0002\u0013\u000A.\u000A("table/views/", \u001F, "/rows?size=1");
			RestClient u001F2 = \u0020\u0019\u0018.\u000A("https://api.morta.io/v1");
			RestRequest u000A = \u0012\u0018\u0018.\u000A(u001F, \u0003\u000E.\u001F(CustomRequestMethod.Get)).\u001F(this.\u000A);
			string text = \u0008\u0019\u0018.\u000A(\u0011\u0019\u0018.\u000A(u001F2, u000A));
			if (text == null)
			{
				return \u0014\u000D\u0007.\u000A();
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u0006.\u0003(string)).MethodHandle;
			}
			DiRoots.One.Morta.Model.Json.Table.Datum datum = Enumerable.FirstOrDefault<DiRoots.One.Morta.Model.Json.Table.Datum>(\u0008\u0018\u0018.\u000A(JsonConvert.DeserializeObject<JsonRowInfo>(text)));
			if (datum == null)
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
				return null;
			}
			IEnumerable<KeyValuePair<string, object>> enumerable = \u000E\u0018\u0018.\u0007(datum);
			Func<KeyValuePair<string, object>, string> func;
			if ((func = \u0013\u0006.<>c.\u000A) == null)
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
				func = (\u0013\u0006.<>c.\u000A = new Func<KeyValuePair<string, object>, string>(\u0013\u0006.<>c.\u001F.\u0007));
			}
			return Enumerable.ToList<string>(Enumerable.Select<KeyValuePair<string, object>, string>(enumerable, func));
		}

		// Token: 0x06001072 RID: 4210 RVA: 0x0006849C File Offset: 0x0006669C
		internal Task<List<List<object>>> \u001C(string \u001F, List<string> \u000A, Action \u0007)
		{
			\u0013\u0006.\u0011\u0006 u0011_u;
			u0011_u.\u000A = \u001E\u0018\u0018.\u000A();
			u0011_u.\u0004 = this;
			u0011_u.\u0007 = \u001F;
			u0011_u.\u0019 = \u000A;
			u0011_u.\u001D = \u0007;
			u0011_u.\u001F = -1;
			u0011_u.\u000A.Start<\u0013\u0006.\u0011\u0006>(ref u0011_u);
			return \u0011\u0018\u0018.\u000A(ref u0011_u.\u000A);
		}

		// Token: 0x06001073 RID: 4211 RVA: 0x000684FC File Offset: 0x000666FC
		public Task<bool> \u000D(string \u001F, List<string> \u000A, List<RowInfo> \u0007)
		{
			\u0013\u0006.\u0010\u0006 u0010_u;
			u0010_u.\u000A = \u0017\u0018\u0018.\u000A();
			u0010_u.\u001D = this;
			u0010_u.\u0007 = \u001F;
			u0010_u.\u0019 = \u000A;
			u0010_u.\u0004 = \u0007;
			u0010_u.\u001F = -1;
			u0010_u.\u000A.Start<\u0013\u0006.\u0010\u0006>(ref u0010_u);
			return \u0020\u0018\u0018.\u000A(ref u0010_u.\u000A);
		}

		// Token: 0x06001074 RID: 4212 RVA: 0x0006855C File Offset: 0x0006675C
		private void ThrowError(dynamic restResponse)
		{
			if (\u0013\u0006.\u001C\u0006.\u001D == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u0006.ThrowError(object)).MethodHandle;
				}
				CSharpBinderFlags u001F = CSharpBinderFlags.None;
				string u000A = "message";
				Type u = \u001E\u0011\u000A.\u000A(\u001B\u0016\u000E.\u001F());
				CSharpArgumentInfo[] array = \u000F\u0016\u000E.\u001F(1);
				array[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
				\u0013\u0006.\u001C\u0006.\u001D = \u0019\u0001\u0019.\u000A(\u0018\u0001\u0019.\u000A(u001F, u000A, u, array));
			}
			object target = \u0013\u0006.\u001C\u0006.\u001D.Target;
			CallSite u001D = \u0013\u0006.\u001C\u0006.\u001D;
			if (\u0013\u0006.\u001C\u0006.\u0007 == null)
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
				CSharpBinderFlags u001F2 = CSharpBinderFlags.None;
				string u000A2 = "detail";
				Type u2 = \u001E\u0011\u000A.\u000A(\u001B\u0016\u000E.\u001F());
				CSharpArgumentInfo[] array2 = \u000F\u0016\u000E.\u001F(1);
				array2[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
				\u0013\u0006.\u001C\u0006.\u0007 = \u0019\u0001\u0019.\u000A(\u0018\u0001\u0019.\u000A(u001F2, u000A2, u2, array2));
			}
			object target2 = \u0013\u0006.\u001C\u0006.\u0007.Target;
			CallSite u3 = \u0013\u0006.\u001C\u0006.\u0007;
			if (\u0013\u0006.\u001C\u0006.\u000A == null)
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
				CSharpBinderFlags u001F3 = CSharpBinderFlags.None;
				string u000A3 = "DeserializeObject";
				Type[] array3 = \u0011\u0016\u000E.\u001F(1);
				array3[0] = \u001E\u0011\u000A.\u000A(\u001E\u0016\u000E.\u001F());
				Type u001D2 = \u001E\u0011\u000A.\u000A(\u001B\u0016\u000E.\u001F());
				CSharpArgumentInfo[] array4 = \u000F\u0016\u000E.\u001F(2);
				array4[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, \u000F\u0015\u0010.\u001F);
				array4[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
				\u0013\u0006.\u001C\u0006.\u000A = \u0015\u0018\u0018.\u000A(\u001A\u0015\u0019.\u000A(u001F3, u000A3, array3, u001D2, array4));
			}
			object target3 = \u0013\u0006.\u001C\u0006.\u000A.Target;
			CallSite u000A4 = \u0013\u0006.\u001C\u0006.\u000A;
			Type u4 = \u001E\u0011\u000A.\u000A(\u0020\u0016\u000E.\u001F());
			if (\u0013\u0006.\u001C\u0006.\u001F == null)
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
				CSharpBinderFlags u001F4 = CSharpBinderFlags.None;
				string u000A5 = "Content";
				Type u5 = \u001E\u0011\u000A.\u000A(\u001B\u0016\u000E.\u001F());
				CSharpArgumentInfo[] array5 = \u000F\u0016\u000E.\u001F(1);
				array5[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
				\u0013\u0006.\u001C\u0006.\u001F = \u0019\u0001\u0019.\u000A(\u0018\u0001\u0019.\u000A(u001F4, u000A5, u5, array5));
			}
			object u001D3 = \u0004\u0001\u0019.\u000A(target, u001D, \u0004\u0001\u0019.\u000A(target2, u3, \u000C\u0018\u0018.\u000A(target3, u000A4, u4, \u0004\u0001\u0019.\u000A(\u0013\u0006.\u001C\u0006.\u001F.Target, \u0013\u0006.\u001C\u0006.\u001F, restResponse))));
			if (\u0013\u0006.\u001C\u0006.\u0004 == null)
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
				CSharpBinderFlags u001F5 = CSharpBinderFlags.None;
				Type u000A6 = \u001E\u0011\u000A.\u000A(\u001B\u0016\u000E.\u001F());
				CSharpArgumentInfo[] array6 = \u000F\u0016\u000E.\u001F(2);
				array6[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, \u000F\u0015\u0010.\u001F);
				array6[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
				\u0013\u0006.\u001C\u0006.\u0004 = \u0013\u0018\u0018.\u000A(\u001A\u0018\u0018.\u000A(u001F5, u000A6, array6));
			}
			throw \u0014\u0018\u0018.\u000A(\u0013\u0006.\u001C\u0006.\u0004.Target, \u0013\u0006.\u001C\u0006.\u0004, \u001E\u0011\u000A.\u000A(\u0017\u0016\u000E.\u001F()), u001D3);
		}

		// Token: 0x04000682 RID: 1666
		[CompilerGenerated]
		private Login \u001F;

		// Token: 0x0200087D RID: 2173
		[CompilerGenerated]
		private sealed class \u0012\u0006
		{
			// Token: 0x06004F43 RID: 20291 RVA: 0x001E35B4 File Offset: 0x001E17B4
			internal bool \u000A(Column \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u000D\u0003\u0004.\u001D(\u0017\u001D\u0010.\u000A(\u001F)), \u000D\u0003\u0004.\u001D(\u0017\u0004\u0010.\u000A(this.\u001F)));
			}

			// Token: 0x06004F44 RID: 20292 RVA: 0x001E35EC File Offset: 0x001E17EC
			internal bool \u0007(Column \u001F)
			{
				DiRoots.One.Morta.Model.Json.Column.Description description = \u0006\u000A\u0018.\u000A(\u001F);
				string u001F;
				if (description == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u0006.\u0012\u0006.\u0007(Column)).MethodHandle;
					}
					u001F = null;
				}
				else
				{
					ParamExportInfo paramExportInfo = description.\u000A();
					if (paramExportInfo == null)
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
						u001F = null;
					}
					else
					{
						u001F = \u0014\u0004\u0018.\u001D(paramExportInfo);
					}
				}
				return \u0008\u0013\u000A.\u000A(u001F, \u000B\u0019\u0010.\u000A(this.\u001F));
			}

			// Token: 0x040021E5 RID: 8677
			public ColumnInfo \u001F;
		}

		// Token: 0x0200087E RID: 2174
		[CompilerGenerated]
		private sealed class \u0003\u0006
		{
			// Token: 0x06004F46 RID: 20294 RVA: 0x001E3664 File Offset: 0x001E1864
			internal void \u000A(DiRoots.One.Morta.Model.Json.Project.Datum \u001F)
			{
				if (\u0006\u0019\u0010.\u000A(\u001F) != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u0006.\u0003\u0006.\u000A(DiRoots.One.Morta.Model.Json.Project.Datum)).MethodHandle;
					}
					TableInfo tableInfo = \u000E\u0004\u0018.\u000A();
					\u0010\u0007\u0018.\u0007(tableInfo, \u0001\u0019\u0018.\u000A(\u001F));
					\u0012\u0019\u0010.\u000A(tableInfo, \u0003\u0019\u0010.\u000A(\u000D\u0019\u0010.\u000A(), \u001C\u0019\u0010.\u000A(\u0006\u0019\u0010.\u000A(\u001F))));
					\u0012\u0007\u0018.\u000A(tableInfo, \u000F\u0019\u0010.\u000A(\u0006\u0019\u0010.\u000A(\u001F)));
					\u000E\u000A\u0018.\u000A(tableInfo, \u001F\u0005\u0018.\u000A(\u0002\u0019\u0010.\u000A(\u0006\u0019\u0010.\u000A(\u001F))));
					TableInfo u000A = tableInfo;
					\u0015\u001D\u0018.\u000A(this.\u001F, u000A);
				}
			}

			// Token: 0x040021E6 RID: 8678
			public List<TableInfo> \u001F;
		}

		// Token: 0x0200087F RID: 2175
		[CompilerGenerated]
		private static class \u001C\u0006
		{
			// Token: 0x040021E7 RID: 8679
			public static CallSite<Func<CallSite, object, object>> \u001F;

			// Token: 0x040021E8 RID: 8680
			public static CallSite<Func<CallSite, Type, object, object>> \u000A;

			// Token: 0x040021E9 RID: 8681
			public static CallSite<Func<CallSite, object, object>> \u0007;

			// Token: 0x040021EA RID: 8682
			public static CallSite<Func<CallSite, object, object>> \u001D;

			// Token: 0x040021EB RID: 8683
			public static CallSite<Func<CallSite, Type, object, WebRequestFailedException>> \u0004;
		}
	}
}
