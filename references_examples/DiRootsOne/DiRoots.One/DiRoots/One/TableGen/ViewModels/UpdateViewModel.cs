using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;
using DiRoots.One.TableGen.Models;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.UIBehaviours.Extensions;

namespace DiRoots.One.TableGen.ViewModels
{
	// Token: 0x02000149 RID: 329
	public class UpdateViewModel : AddBaseViewModel
	{
		// Token: 0x06000C2C RID: 3116 RVA: 0x0004D630 File Offset: 0x0004B830
		public UpdateViewModel(List<SelectedExcel> existingTables, SelectedExcel selectedExcel) : base(existingTables)
		{
			\u001B\u001F\u0019.\u000A(this, false);
			\u0008\u001F\u0019.\u000A(this, false);
			this.GL = selectedExcel;
			\u0002\u001F\u0019.\u000A(this, new CommandBase<Window>(new Action<Window>(this.JNR), new Predicate<Window>(base.CanAdd)));
			\u000E\u001F\u0019.\u000A(this);
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x0004D684 File Offset: 0x0004B884
		public void Init()
		{
			try
			{
				\u0011\u0001\u0004.\u000A(this, Enumerable.FirstOrDefault<EnumInfo>(\u001E\u0001\u0004.\u000A(this), new Func<EnumInfo, bool>(this.ENR)));
				\u0008\u0001\u0004.\u000A(this, \u0002\u0003\u0004.\u0007(this.GL));
				\u0010\u0001\u0004.\u000A(this, \u0015\u0016\u0004.\u0007(this.GL));
				\u0013\u001F\u0019.\u000A(this, \u0018\u0011\u0004.\u001D(this.GL));
				\u0004\u0009\u0004.\u000A(this, \u0011\u0020\u001D.\u0007(this.GL));
				\u0014\u001F\u0019.\u000A(this, \u0014\u0005\u0004.\u0007(this.GL));
				\u0015\u0001\u0004.\u000A(this, \u0019\u0020\u001D.\u0007(this.GL));
				\u0017\u001F\u0019.\u000A(this, \u0009\u0011\u0004.\u000A(this.GL));
				\u001C\u0001\u0004.\u000A(this, \u0004\u0011\u0004.\u001D(this.GL));
				\u0020\u001F\u0019.\u000A(this, \u000A\u0011\u0004.\u001D(this.GL));
				if (\u000D\u001B\u001D.\u0007(\u0018\u0009\u0004.\u000A(this)) == 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(UpdateViewModel.Init()).MethodHandle;
					}
					Dictionary<string, List<NamedRangeInfo>> dictionary = \u0010\u0018\u000E.\u001F;
					if (\u0010\u0002\u001D.\u000A(\u0011\u0020\u001D.\u0007(this.GL)))
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
						dictionary = \u0013\u0019.\u001F(\u0011\u0020\u001D.\u0007(this.GL));
					}
					if (dictionary != null)
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
						if (\u0016\u0009\u0004.\u000A(dictionary) > 0)
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
							IEnumerable<KeyValuePair<string, List<NamedRangeInfo>>> enumerable = dictionary;
							Func<KeyValuePair<string, List<NamedRangeInfo>>, WorkSheetNamedRegion> func;
							if ((func = UpdateViewModel.<>c.\u000A) == null)
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
								func = (UpdateViewModel.<>c.\u000A = new Func<KeyValuePair<string, List<NamedRangeInfo>>, WorkSheetNamedRegion>(UpdateViewModel.<>c.\u001F.\u001D));
							}
							\u000F\u0009\u0004.\u000A(this, Enumerable.ToList<WorkSheetNamedRegion>(Enumerable.Select<KeyValuePair<string, List<NamedRangeInfo>>, WorkSheetNamedRegion>(enumerable, func)));
							\u000B\u0009\u0004.\u000A(this, Enumerable.FirstOrDefault<WorkSheetNamedRegion>(\u0006\u0009\u0004.\u000A(this), new Func<WorkSheetNamedRegion, bool>(this.NNR)));
							WorkSheetNamedRegion workSheetNamedRegion = \u000A\u0009\u0004.\u000A(this);
							NamedRangeInfo u000A;
							if (workSheetNamedRegion == null)
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
								u000A = \u0010\u0019\u000E.\u001F;
							}
							else
							{
								List<NamedRangeInfo> list = \u001F\u0009\u0004.\u0007(workSheetNamedRegion);
								if (list == null)
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
									u000A = \u0010\u0019\u000E.\u001F;
								}
								else
								{
									u000A = Enumerable.FirstOrDefault<NamedRangeInfo>(list, new Func<NamedRangeInfo, bool>(this.MNR));
								}
							}
							\u0009\u0001\u0004.\u000A(this, u000A);
						}
					}
				}
			}
			catch (Exception u001F)
			{
				if (\u000F\u000C\u001D.\u0007(\u0003\u001A\u000A.\u000A(u001F), "The process cannot access the file"))
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
					\u0011\u001F\u0019.\u000A(\u001E\u001F\u0019.\u000A(), MessageBoxButtons.OK);
				}
				else
				{
					\u000A\u0016.\u001F(u001F);
				}
			}
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x0004D8F4 File Offset: 0x0004BAF4
		private void JNR(Window F)
		{
			SelectedExcel gl = this.GL;
			SelectedExcel u001F = \u0010\u001F\u0019.\u000A(this, \u0001\u0001\u0004.\u000A(this));
			\u0018\u000B\u0004.\u000A(gl, \u0014\u0005\u0004.\u0007(gl));
			\u0004\u0017\u0004.\u000A(gl, \u0003\u000B\u001D.\u0007(\u0014\u0005\u0004.\u0007(u001F)));
			if (\u001D\u0017\u000A.\u000A(\u0016\u000B\u0004.\u000A(gl), \u0014\u0005\u0004.\u0007(gl)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UpdateViewModel.JNR(Window)).MethodHandle;
				}
				if (\u0001\u0016\u0004.\u0007(gl) == UpdateStates.Updated)
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
					\u000D\u0016\u0004.\u0007(gl, UpdateStates.Modified);
				}
			}
			if (\u000D\u001B\u001D.\u0007(\u0015\u0016\u0004.\u0007(gl)) == 1)
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
				if (\u0018\u0011\u0004.\u001D(gl) != \u0018\u0011\u0004.\u001D(u001F))
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
					if (\u0001\u0016\u0004.\u0007(gl) == UpdateStates.Updated)
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
						\u000D\u0016\u0004.\u0007(gl, UpdateStates.Modified);
					}
				}
			}
			\u000A\u001E\u0004.\u000A(gl, \u0018\u0011\u0004.\u001D(u001F));
			\u001E\u001B\u0004.\u001D(gl, \u0018\u001B\u0004.\u001D(u001F));
			if (\u0019\u0010\u0004.\u0007(gl) != ActionTypes.Create)
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
				if (\u0019\u0010\u0004.\u0007(gl) != ActionTypes.Delete)
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
					\u001C\u0016\u0004.\u0007(gl, ActionTypes.Update);
				}
			}
			\u0007\u001B\u0004.\u001D(gl, \u000A\u001B\u0004.\u001D(u001F));
			\u001B\u001B\u0004.\u001D(gl, \u0020\u0020\u001D.\u0007(u001F));
			\u001F\u001B\u0004.\u001D(gl, \u0014\u0020\u001D.\u0007(u001F));
			\u000C\u0011\u0004.\u001D(gl, \u0011\u0020\u001D.\u0007(u001F));
			\u001E\u0008\u0004.\u001D(gl, \u0017\u0008\u0004.\u001D(u001F));
			\u0005\u0008\u0004.\u001D(gl, \u0006\u0020\u001D.\u0007(u001F));
			\u0012\u001B\u0004.\u001D(gl, \u0019\u0020\u001D.\u0007(u001F));
			\u001B\u0020\u0004.\u000A(gl, \u000A\u0011\u0004.\u001D(u001F));
			\u0007\u001E\u0004.\u000A(gl, \u0004\u0011\u0004.\u001D(u001F));
			\u0006\u0015\u0007.\u001D(F, new bool?(true));
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x0004DAAC File Offset: 0x0004BCAC
		protected override void SetValues(string filePath)
		{
			Dictionary<string, List<NamedRangeInfo>> dictionary = \u0013\u0019.\u001F(filePath);
			if (\u0016\u0009\u0004.\u000A(dictionary) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UpdateViewModel.SetValues(string)).MethodHandle;
				}
				\u0004\u0009\u0004.\u000A(this, filePath);
				IEnumerable<KeyValuePair<string, List<NamedRangeInfo>>> enumerable = dictionary;
				Func<KeyValuePair<string, List<NamedRangeInfo>>, WorkSheetNamedRegion> func;
				if ((func = UpdateViewModel.<>c.\u0007) == null)
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
					func = (UpdateViewModel.<>c.\u0007 = new Func<KeyValuePair<string, List<NamedRangeInfo>>, WorkSheetNamedRegion>(UpdateViewModel.<>c.\u001F.\u0004));
				}
				\u000F\u0009\u0004.\u000A(this, Enumerable.ToList<WorkSheetNamedRegion>(Enumerable.Select<KeyValuePair<string, List<NamedRangeInfo>>, WorkSheetNamedRegion>(enumerable, func)));
				\u000B\u0009\u0004.\u000A(this, \u000C\u001F\u0019.\u000A(\u0006\u0009\u0004.\u000A(this), new Predicate<WorkSheetNamedRegion>(this.VNR)));
				if (\u000A\u0009\u0004.\u000A(this) != null)
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
					NamedRangeInfo namedRangeInfo = \u001A\u001F\u0019.\u000A(\u001F\u0009\u0004.\u001D(\u000A\u0009\u0004.\u000A(this)), new Predicate<NamedRangeInfo>(this.ZNR));
					if (namedRangeInfo == null)
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
						namedRangeInfo = NamedRangeInfo.\u000A(\u001F\u0009\u0004.\u001D(\u000A\u0009\u0004.\u000A(this)));
					}
					\u0009\u0001\u0004.\u000A(this, namedRangeInfo);
					\u0014\u001F\u0019.\u000A(this, \u0014\u0005\u0004.\u0007(this.GL));
					return;
				}
				\u0005\u0009\u0004.\u000A(this, filePath, dictionary);
			}
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x0004DBC8 File Offset: 0x0004BDC8
		[BindableMethod("OnPreviewTextInput")]
		public void OnPreviewTextInput(TextCompositionEventArgs e)
		{
			if (\u0015\u001F\u0019.\u000A(\u0001\u0015\u0007.\u000A(e), false, \u000D\u0018\u000E.\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UpdateViewModel.OnPreviewTextInput(TextCompositionEventArgs)).MethodHandle;
				}
				\u0019\u0013\u000A.\u000A(e, true);
			}
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x0004DC08 File Offset: 0x0004BE08
		protected override void DataValidation(string propertyName)
		{
			ViewType u001F = \u000D\u001B\u001D.\u0007(\u001D\u0009\u0004.\u000A(this));
			if (\u0008\u0013\u000A.\u000A(propertyName, "ViewName"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UpdateViewModel.DataValidation(string)).MethodHandle;
				}
				if (\u001A\u0006\u0007.\u000A(\u0001\u0001\u0004.\u000A(this)))
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
					\u0009\u0009\u0004.\u000A(this, propertyName, \u000A\u000A\u0019.\u000A());
					return;
				}
				if (\u000D\u001F\u0019.\u000A(this, \u0001\u0001\u0004.\u000A(this)))
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
					\u0009\u0009\u0004.\u000A(this, propertyName, \u0017\u0006\u0007.\u000A(\u001F\u000A\u0019.\u000A(), \u0001\u001F\u0019.\u000A(\u001D\u0009\u0004.\u000A(this))));
					return;
				}
				if (\u0015\u0018.\u000A(u001F, \u0001\u0001\u0004.\u000A(this), \u0009\u0005\u0004.\u000A(this.GL)))
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
					\u0009\u0009\u0004.\u000A(this, propertyName, \u0017\u0006\u0007.\u000A(\u0009\u001F\u0019.\u000A(), \u0001\u001F\u0019.\u000A(\u001D\u0009\u0004.\u000A(this))));
					return;
				}
			}
			\u000C\u0001\u0004.\u001D(this, propertyName);
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x0004DD0C File Offset: 0x0004BF0C
		[CompilerGenerated]
		private bool ENR(EnumInfo F)
		{
			return \u000D\u001B\u001D.\u0007(F) == \u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(this.GL));
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x0004DD38 File Offset: 0x0004BF38
		[CompilerGenerated]
		private bool NNR(WorkSheetNamedRegion F)
		{
			return \u0008\u0013\u000A.\u000A(\u0017\u0009\u0004.\u000A(F), \u0020\u0020\u001D.\u0007(this.GL));
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x0004DD64 File Offset: 0x0004BF64
		[CompilerGenerated]
		private bool MNR(NamedRangeInfo F)
		{
			string u001F = \u0017\u0020\u001D.\u0007(F);
			NamedRangeInfo namedRangeInfo = \u0014\u0020\u001D.\u0007(this.GL);
			string u000A;
			if (namedRangeInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UpdateViewModel.MNR(NamedRangeInfo)).MethodHandle;
				}
				u000A = \u000F\u0015\u0010.\u001F;
			}
			else
			{
				u000A = \u0017\u0020\u001D.\u001D(namedRangeInfo);
			}
			return \u0008\u0013\u000A.\u000A(u001F, u000A);
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x0004DDB4 File Offset: 0x0004BFB4
		[CompilerGenerated]
		private bool VNR(WorkSheetNamedRegion F)
		{
			string u001F = \u0017\u0009\u0004.\u000A(F);
			SelectedExcel gl = this.GL;
			string u000A;
			if (gl == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UpdateViewModel.VNR(WorkSheetNamedRegion)).MethodHandle;
				}
				u000A = \u000F\u0015\u0010.\u001F;
			}
			else
			{
				u000A = \u0020\u0020\u001D.\u001D(gl);
			}
			return \u0008\u0013\u000A.\u000A(u001F, u000A);
		}

		// Token: 0x06000C36 RID: 3126 RVA: 0x0004DDFC File Offset: 0x0004BFFC
		[CompilerGenerated]
		private bool ZNR(NamedRangeInfo F)
		{
			string u001F = \u0017\u0020\u001D.\u0007(F);
			NamedRangeInfo namedRangeInfo = \u0014\u0020\u001D.\u0007(this.GL);
			string u000A;
			if (namedRangeInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UpdateViewModel.ZNR(NamedRangeInfo)).MethodHandle;
				}
				u000A = \u000F\u0015\u0010.\u001F;
			}
			else
			{
				u000A = \u0017\u0020\u001D.\u001D(namedRangeInfo);
			}
			return \u0008\u0013\u000A.\u000A(u001F, u000A);
		}

		// Token: 0x040004D6 RID: 1238
		private readonly SelectedExcel GL;
	}
}
