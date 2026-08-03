using System;
using DiRoots.One.TableGen.ViewModels;

namespace DiRoots.One.TableGen.Services
{
	// Token: 0x02000169 RID: 361
	public interface IFileInfoViewModelFactory
	{
		// Token: 0x06000D76 RID: 3446
		IFileInfoViewModel Create(string filePath);
	}
}
