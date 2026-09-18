using System;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons;
using DiRoots.One.Morta.Model.Json;
using Newtonsoft.Json;
using RestSharp;

namespace DiRoots.One.Morta.Model
{
	// Token: 0x020001B5 RID: 437
	public class Login
	{
		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x06001056 RID: 4182 RVA: 0x00067978 File Offset: 0x00065B78
		// (set) Token: 0x06001057 RID: 4183 RVA: 0x0006798C File Offset: 0x00065B8C
		public string AccessKey { get; set; }

		// Token: 0x06001058 RID: 4184 RVA: 0x000679A0 File Offset: 0x00065BA0
		public bool SigIn(string accessKey)
		{
			\u0008\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Model\\Login.cs", "SigIn");
			try
			{
				if (this.\u000A(accessKey))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Login.SigIn(string)).MethodHandle;
					}
					\u0010\u0019\u0018.\u000A(this, accessKey);
					string u000A = \u0009\u0006.\u001F(accessKey, "MortaAPIKey");
					MortaSetting mortaSetting = \u000D\u0019\u0018.\u000A();
					\u001C\u0019\u0018.\u000A(mortaSetting, u000A);
					XMLUtility.SerialiseInfo<MortaSetting>(mortaSetting, \u0001\u0006.\u0005());
					return true;
				}
			}
			catch (Exception u000A2)
			{
				\u000F\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Model\\Login.cs", "SigIn");
			}
			\u0005\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Model\\Login.cs", "SigIn");
			return false;
		}

		// Token: 0x06001059 RID: 4185 RVA: 0x00067A5C File Offset: 0x00065C5C
		private bool \u000A(string \u001F)
		{
			return \u000E\u0019\u0018.\u000A(this, \u001F) != \u0008\u0016\u000E.\u001F;
		}

		// Token: 0x0600105A RID: 4186 RVA: 0x00067A7C File Offset: 0x00065C7C
		public AccessTokenData GetUserInfo(string accessKey)
		{
			\u0008\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Model\\Login.cs", "GetUserInfo");
			object u001F = \u0020\u0019\u0018.\u000A("https://api.morta.io/v1");
			RestRequest u000A = \u001E\u0019\u0018.\u000A("user/me").\u001F(accessKey);
			IRestResponse u001F2 = \u0011\u0019\u0018.\u000A(u001F, u000A);
			AccessTokenData result = \u0008\u0016\u000E.\u001F;
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Login.GetUserInfo(string)).MethodHandle;
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
					result = JsonConvert.DeserializeObject<AccessTokenData>(text);
				}
			}
			\u0005\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Model\\Login.cs", "GetUserInfo");
			return result;
		}

		// Token: 0x0600105B RID: 4187 RVA: 0x00067B24 File Offset: 0x00065D24
		public bool SignOut()
		{
			\u0008\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Model\\Login.cs", "SignOut");
			try
			{
				\u0010\u0019\u0018.\u000A(this, \u000F\u0015\u0010.\u001F);
				\u0007\u0001\u001D.\u000A(\u0001\u0006.\u0005());
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Model\\Login.cs", "SignOut");
				return false;
			}
			\u0005\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Model\\Login.cs", "SignOut");
			return true;
		}

		// Token: 0x0600105C RID: 4188 RVA: 0x00067BA4 File Offset: 0x00065DA4
		public bool IsAlreadyLoggedIn()
		{
			\u0010\u0019\u0018.\u000A(this, this.\u0007());
			return this.\u000A(\u0017\u0019\u0018.\u000A(this));
		}

		// Token: 0x0600105D RID: 4189 RVA: 0x00067BD0 File Offset: 0x00065DD0
		private string \u0007()
		{
			string text = \u0001\u0006.\u0005();
			if (\u0010\u0002\u001D.\u000A(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Login.\u0007()).MethodHandle;
				}
				return \u0009\u0006.\u000A(\u0014\u0019\u0018.\u000A(XMLUtility.DeserialiseInfo<MortaSetting>(text)), "MortaAPIKey");
			}
			return null;
		}

		// Token: 0x04000680 RID: 1664
		[CompilerGenerated]
		private string \u001F;
	}
}
