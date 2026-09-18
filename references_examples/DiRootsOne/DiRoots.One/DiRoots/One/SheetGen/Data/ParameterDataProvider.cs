using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Revit.Extensions;

namespace DiRoots.One.SheetGen.Data
{
	// Token: 0x02000356 RID: 854
	[Serializable]
	public class ParameterDataProvider : IDisposable
	{
		// Token: 0x0600239C RID: 9116 RVA: 0x000DC0C8 File Offset: 0x000DA2C8
		private ParameterDataProvider()
		{
		}

		// Token: 0x170009DF RID: 2527
		// (get) Token: 0x0600239D RID: 9117 RVA: 0x000DC0DC File Offset: 0x000DA2DC
		public ObservableCollection<ParameterIntegerValue> PartVisiblity
		{
			get
			{
				if (this._partVisiblity == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_PartVisiblity()).MethodHandle;
					}
					ObservableCollection<ParameterIntegerValue> observableCollection = \u0002\u0013\u000B.\u000A();
					ParameterIntegerValue parameterIntegerValue = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue, \u000B\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue, -1);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue);
					ParameterIntegerValue parameterIntegerValue2 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue2, \u0016\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue2, 0);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue2);
					ParameterIntegerValue parameterIntegerValue3 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue3, \u0005\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue3, 1);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue3);
					ParameterIntegerValue parameterIntegerValue4 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue4, \u0019\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue4, 2);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue4);
					this._partVisiblity = observableCollection;
				}
				return this._partVisiblity;
			}
		}

		// Token: 0x170009E0 RID: 2528
		// (get) Token: 0x0600239E RID: 9118 RVA: 0x000DC1A0 File Offset: 0x000DA3A0
		public ObservableCollection<ParameterIntegerValue> DisplayModel
		{
			get
			{
				if (this._displayModel == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_DisplayModel()).MethodHandle;
					}
					ObservableCollection<ParameterIntegerValue> observableCollection = \u0002\u0013\u000B.\u000A();
					ParameterIntegerValue parameterIntegerValue = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue, \u0012\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue, 0);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue);
					ParameterIntegerValue parameterIntegerValue2 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue2, \u000F\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue2, 1);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue2);
					ParameterIntegerValue parameterIntegerValue3 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue3, \u0006\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue3, 2);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue3);
					this._displayModel = observableCollection;
				}
				return this._displayModel;
			}
		}

		// Token: 0x170009E1 RID: 2529
		// (get) Token: 0x0600239F RID: 9119 RVA: 0x000DC244 File Offset: 0x000DA444
		public ObservableCollection<ParameterIntegerValue> RotationOnSheet
		{
			get
			{
				if (this._rotationOnSheet == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_RotationOnSheet()).MethodHandle;
					}
					ObservableCollection<ParameterIntegerValue> observableCollection = \u0002\u0013\u000B.\u000A();
					ParameterIntegerValue parameterIntegerValue = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue, \u0008\u001C\u001D.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue, 0);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue);
					ParameterIntegerValue parameterIntegerValue2 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue2, \u001C\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue2, 1);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue2);
					ParameterIntegerValue parameterIntegerValue3 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue3, \u0003\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue3, 2);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue3);
					this._rotationOnSheet = observableCollection;
				}
				return this._rotationOnSheet;
			}
		}

		// Token: 0x170009E2 RID: 2530
		// (get) Token: 0x060023A0 RID: 9120 RVA: 0x000DC2E8 File Offset: 0x000DA4E8
		public ObservableCollection<ParameterIntegerValue> ShowHiddenLines
		{
			get
			{
				if (this._showHiddenLines == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_ShowHiddenLines()).MethodHandle;
					}
					ObservableCollection<ParameterIntegerValue> observableCollection = \u0002\u0013\u000B.\u000A();
					ParameterIntegerValue parameterIntegerValue = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue, \u0008\u001C\u001D.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue, 0);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue);
					ParameterIntegerValue parameterIntegerValue2 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue2, \u000D\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue2, 1);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue2);
					ParameterIntegerValue parameterIntegerValue3 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue3, \u000E\u000E\u0004.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue3, 2);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue3);
					this._showHiddenLines = observableCollection;
				}
				return this._showHiddenLines;
			}
		}

		// Token: 0x170009E3 RID: 2531
		// (get) Token: 0x060023A1 RID: 9121 RVA: 0x000DC38C File Offset: 0x000DA58C
		public ObservableCollection<ParameterIntegerValue> ColorSchemaLocation
		{
			get
			{
				if (this._colorSchemaLocation == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_ColorSchemaLocation()).MethodHandle;
					}
					ObservableCollection<ParameterIntegerValue> observableCollection = \u0002\u0013\u000B.\u000A();
					ParameterIntegerValue parameterIntegerValue = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue, \u000E\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue, 1);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue);
					ParameterIntegerValue parameterIntegerValue2 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue2, \u0010\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue2, 0);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue2);
					this._colorSchemaLocation = observableCollection;
				}
				return this._colorSchemaLocation;
			}
		}

		// Token: 0x170009E4 RID: 2532
		// (get) Token: 0x060023A2 RID: 9122 RVA: 0x000DC40C File Offset: 0x000DA60C
		public ObservableCollection<ParameterIntegerValue> WallJoinDisplay
		{
			get
			{
				if (this._wallJoinDisplay == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_WallJoinDisplay()).MethodHandle;
					}
					ObservableCollection<ParameterIntegerValue> observableCollection = \u0002\u0013\u000B.\u000A();
					ParameterIntegerValue parameterIntegerValue = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue, \u001B\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue, 0);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue);
					ParameterIntegerValue parameterIntegerValue2 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue2, \u0008\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue2, 1);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue2);
					this._wallJoinDisplay = observableCollection;
				}
				return this._wallJoinDisplay;
			}
		}

		// Token: 0x170009E5 RID: 2533
		// (get) Token: 0x060023A3 RID: 9123 RVA: 0x000DC48C File Offset: 0x000DA68C
		public ObservableCollection<ParameterIntegerValue> ProjectModel
		{
			get
			{
				if (this._projectModel == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_ProjectModel()).MethodHandle;
					}
					ObservableCollection<ParameterIntegerValue> observableCollection = \u0002\u0013\u000B.\u000A();
					ParameterIntegerValue parameterIntegerValue = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue, \u001E\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue, 0);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue);
					ParameterIntegerValue parameterIntegerValue2 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue2, \u0011\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue2, 1);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue2);
					this._projectModel = observableCollection;
				}
				return this._projectModel;
			}
		}

		// Token: 0x170009E6 RID: 2534
		// (get) Token: 0x060023A4 RID: 9124 RVA: 0x000DC50C File Offset: 0x000DA70C
		public ObservableCollection<ParameterIntegerValue> FarClipSettings
		{
			get
			{
				if (this._farClipSettings == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_FarClipSettings()).MethodHandle;
					}
					ObservableCollection<ParameterIntegerValue> observableCollection = \u0002\u0013\u000B.\u000A();
					ParameterIntegerValue parameterIntegerValue = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue, \u0017\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue, 0);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue);
					ParameterIntegerValue parameterIntegerValue2 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue2, \u0020\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue2, 1);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue2);
					this._farClipSettings = observableCollection;
				}
				return this._farClipSettings;
			}
		}

		// Token: 0x170009E7 RID: 2535
		// (get) Token: 0x060023A5 RID: 9125 RVA: 0x000DC58C File Offset: 0x000DA78C
		public ObservableCollection<ParameterIntegerValue> ShowIn
		{
			get
			{
				if (this._showIn == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_ShowIn()).MethodHandle;
					}
					ObservableCollection<ParameterIntegerValue> observableCollection = \u0002\u0013\u000B.\u000A();
					ParameterIntegerValue parameterIntegerValue = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue, \u0013\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue, 0);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue);
					ParameterIntegerValue parameterIntegerValue2 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue2, \u0014\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue2, 1);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue2);
					this._showIn = observableCollection;
				}
				return this._showIn;
			}
		}

		// Token: 0x170009E8 RID: 2536
		// (get) Token: 0x060023A6 RID: 9126 RVA: 0x000DC60C File Offset: 0x000DA80C
		public ObservableCollection<ParameterIntegerValue> UnderlayOrientation
		{
			get
			{
				if (this._underlayOrientation == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_UnderlayOrientation()).MethodHandle;
					}
					ObservableCollection<ParameterIntegerValue> observableCollection = \u0002\u0013\u000B.\u000A();
					ParameterIntegerValue parameterIntegerValue = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue, \u000C\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue, 0);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue);
					ParameterIntegerValue parameterIntegerValue2 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue2, \u001A\u0013\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue2, 1);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue2);
					this._underlayOrientation = observableCollection;
				}
				return this._underlayOrientation;
			}
		}

		// Token: 0x170009E9 RID: 2537
		// (get) Token: 0x060023A7 RID: 9127 RVA: 0x000DC68C File Offset: 0x000DA88C
		public ObservableCollection<ParameterIdValue> Phases
		{
			get
			{
				if (this._phases == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_Phases()).MethodHandle;
					}
					this._phases = this.\u000A<Element>(Enumerable.ToList<Element>(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004).GetElements(-2000112L)), true, true, false);
				}
				return this._phases;
			}
		}

		// Token: 0x170009EA RID: 2538
		// (get) Token: 0x060023A8 RID: 9128 RVA: 0x000DC6F0 File Offset: 0x000DA8F0
		public ObservableCollection<ParameterIdValue> PhaseFilters
		{
			get
			{
				if (this._phaseFilters == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_PhaseFilters()).MethodHandle;
					}
					this._phaseFilters = this.\u000A<Element>(Enumerable.ToList<Element>(Enumerable.Cast<Element>(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004).GetElements<PhaseFilter>())), true, true, false);
				}
				return this._phaseFilters;
			}
		}

		// Token: 0x170009EB RID: 2539
		// (get) Token: 0x060023A9 RID: 9129 RVA: 0x000DC754 File Offset: 0x000DA954
		public ObservableCollection<ParameterIdValue> RangeBaseLevel
		{
			get
			{
				if (this._rangeBaseLevel == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_RangeBaseLevel()).MethodHandle;
					}
					IEnumerable<Level> elements = \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004).GetElements<Level>();
					Func<Level, bool> func;
					if ((func = ParameterDataProvider.<>c.\u000A) == null)
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
						func = (ParameterDataProvider.<>c.\u000A = new Func<Level, bool>(ParameterDataProvider.<>c.\u001F.\u0012));
					}
					IEnumerable<Level> enumerable = Enumerable.Where<Level>(elements, func);
					Func<Level, double> func2;
					if ((func2 = ParameterDataProvider.<>c.\u0007) == null)
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
						func2 = (ParameterDataProvider.<>c.\u0007 = new Func<Level, double>(ParameterDataProvider.<>c.\u001F.\u0003));
					}
					List<Element> u001F = Enumerable.ToList<Element>(Enumerable.Cast<Element>(Enumerable.OrderBy<Level, double>(enumerable, func2)));
					this._rangeBaseLevel = this.\u000A<Element>(u001F, true, false, false);
					\u001F\u0012\u0016.\u000A(\u001B\u000F\u0016.\u000A(this._rangeBaseLevel, 0), -1L);
					\u0012\u000F\u0016.\u000A(\u001B\u000F\u0016.\u000A(this._rangeBaseLevel, 0), \u0008\u001C\u001D.\u000A());
				}
				return this._rangeBaseLevel;
			}
		}

		// Token: 0x170009EC RID: 2540
		// (get) Token: 0x060023AA RID: 9130 RVA: 0x000DC84C File Offset: 0x000DAA4C
		public ObservableCollection<ParameterIdValue> RangeTopLevel
		{
			get
			{
				if (this._rangeTopLevel == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_RangeTopLevel()).MethodHandle;
					}
					IEnumerable<Level> elements = \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004).GetElements<Level>();
					Func<Level, bool> func;
					if ((func = ParameterDataProvider.<>c.\u001D) == null)
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
						func = (ParameterDataProvider.<>c.\u001D = new Func<Level, bool>(ParameterDataProvider.<>c.\u001F.\u001C));
					}
					IEnumerable<Level> enumerable = Enumerable.Where<Level>(elements, func);
					Func<Level, double> func2;
					if ((func2 = ParameterDataProvider.<>c.\u0004) == null)
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
						func2 = (ParameterDataProvider.<>c.\u0004 = new Func<Level, double>(ParameterDataProvider.<>c.\u001F.\u000D));
					}
					List<Element> u001F = Enumerable.ToList<Element>(Enumerable.Cast<Element>(Enumerable.OrderBy<Level, double>(enumerable, func2)));
					this._rangeTopLevel = this.\u000A<Element>(u001F, true, false, false);
					\u001F\u0012\u0016.\u000A(\u001B\u000F\u0016.\u000A(this._rangeTopLevel, 0), -1L);
					\u0012\u000F\u0016.\u000A(\u001B\u000F\u0016.\u000A(this._rangeTopLevel, 0), \u0015\u0013\u000B.\u000A());
				}
				return this._rangeTopLevel;
			}
		}

		// Token: 0x170009ED RID: 2541
		// (get) Token: 0x060023AB RID: 9131 RVA: 0x000DC944 File Offset: 0x000DAB44
		public ObservableCollection<ParameterIdValue> Materials
		{
			get
			{
				if (this._materials == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_Materials()).MethodHandle;
					}
					this._materials = this.\u000A<Element>(Enumerable.ToList<Element>(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004).GetElements(-2000700L)), true, true, false);
				}
				return this._materials;
			}
		}

		// Token: 0x170009EE RID: 2542
		// (get) Token: 0x060023AC RID: 9132 RVA: 0x000DC9A8 File Offset: 0x000DABA8
		public ObservableCollection<ParameterIdValue> FillPatterns
		{
			get
			{
				if (this._fillPatterns == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_FillPatterns()).MethodHandle;
					}
					this._fillPatterns = this.\u000A<FillPatternElement>(Enumerable.ToList<FillPatternElement>(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004).GetElements<FillPatternElement>()), true, true, false);
				}
				return this._fillPatterns;
			}
		}

		// Token: 0x170009EF RID: 2543
		// (get) Token: 0x060023AD RID: 9133 RVA: 0x000DCA04 File Offset: 0x000DAC04
		public ObservableCollection<ParameterIdValue> TitleBlocks
		{
			get
			{
				if (this._titleBlocks == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_TitleBlocks()).MethodHandle;
					}
					this._titleBlocks = this.\u000A<Element>(Enumerable.ToList<Element>(Enumerable.Cast<Element>(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004).GetElementTypes(-2000280L))), true, true, true);
					ICollectionView u001F = \u0011\u0009\u000A.\u000A(this._titleBlocks);
					\u0009\u0013\u000B.\u000A(\u0001\u0013\u000B.\u000A(u001F));
					\u0006\u0008\u0007.\u000A(\u0001\u0013\u000B.\u000A(u001F), \u000F\u0008\u0007.\u000A("GroupName"));
				}
				return this._titleBlocks;
			}
		}

		// Token: 0x060023AE RID: 9134 RVA: 0x000DCAA4 File Offset: 0x000DACA4
		private ObservableCollection<ParameterIdValue> \u000A<\u001F>(List<\u001F> \u001F, bool \u000A = false, bool \u0007 = true, bool \u001D = false) where \u001F : Element
		{
			List<ParameterIdValue> list = \u0018\u001A\u000B.\u000A();
			using (List<\u001F>.Enumerator enumerator = \u001F.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					\u001F u001F = enumerator.Current;
					Element u001F2 = u001F;
					ParameterIdValue parameterIdValue = \u0007\u0012\u0016.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIdValue, \u0005\u001E\u000A.\u000A(u001F2));
					\u001F\u0012\u0016.\u000A(parameterIdValue, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F2)));
					ParameterIdValue parameterIdValue2 = parameterIdValue;
					ElementType elementType = \u001C\u000B\u000E.\u001F(u001F2);
					if (elementType != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.\u000A(List<\u001F>, bool, bool, bool)).MethodHandle;
						}
						\u0007\u001A\u000B.\u000A(parameterIdValue2, \u0001\u0015\u0018.\u0007(elementType));
					}
					\u0019\u001A\u000B.\u000A(list, parameterIdValue2);
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
			}
			if (\u0007)
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
				List<ParameterIdValue> list2;
				if (!\u001D)
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
					IEnumerable<ParameterIdValue> enumerable = list;
					Func<ParameterIdValue, string> func;
					if ((func = ParameterDataProvider.<>c__51<\u001F>.\u001D) == null)
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
						func = (ParameterDataProvider.<>c__51<\u001F>.\u001D = new Func<ParameterIdValue, string>(ParameterDataProvider.<>c__51<\u001F>.\u001F.\u0018));
					}
					list2 = Enumerable.ToList<ParameterIdValue>(Enumerable.OrderBy<ParameterIdValue, string>(enumerable, func));
				}
				else
				{
					IEnumerable<ParameterIdValue> enumerable2 = list;
					Func<ParameterIdValue, string> func2;
					if ((func2 = ParameterDataProvider.<>c__51<\u001F>.\u000A) == null)
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
						func2 = (ParameterDataProvider.<>c__51<\u001F>.\u000A = new Func<ParameterIdValue, string>(ParameterDataProvider.<>c__51<\u001F>.\u001F.\u0004));
					}
					IOrderedEnumerable<ParameterIdValue> orderedEnumerable = Enumerable.OrderBy<ParameterIdValue, string>(enumerable2, func2);
					Func<ParameterIdValue, string> func3;
					if ((func3 = ParameterDataProvider.<>c__51<\u001F>.\u0007) == null)
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
						func3 = (ParameterDataProvider.<>c__51<\u001F>.\u0007 = new Func<ParameterIdValue, string>(ParameterDataProvider.<>c__51<\u001F>.\u001F.\u0019));
					}
					list2 = Enumerable.ToList<ParameterIdValue>(Enumerable.ThenBy<ParameterIdValue, string>(orderedEnumerable, func3));
				}
				list = list2;
			}
			if (\u000A)
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
				\u000A\u001A\u000B.\u000A(list, 0, ParameterIdValue.\u001F());
			}
			if (\u001D)
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
				\u0007\u001A\u000B.\u000A(\u0004\u001A\u000B.\u000A(list, 0), \u001D\u001A\u000B.\u000A());
				ParameterIdValue parameterIdValue3 = ParameterIdValue.\u000A();
				\u0007\u001A\u000B.\u000A(parameterIdValue3, \u001D\u001A\u000B.\u000A());
				\u000A\u001A\u000B.\u000A(list, 1, parameterIdValue3);
			}
			return \u001F\u001A\u000B.\u000A(list);
		}

		// Token: 0x170009F0 RID: 2544
		// (get) Token: 0x060023AF RID: 9135 RVA: 0x000DCC94 File Offset: 0x000DAE94
		internal static ParameterDataProvider Instance
		{
			get
			{
				if (ParameterDataProvider.\u001F == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_Instance()).MethodHandle;
					}
					ParameterDataProvider.\u001F = \u0005\u001A\u000B.\u000A();
				}
				return ParameterDataProvider.\u001F;
			}
		}

		// Token: 0x170009F1 RID: 2545
		// (get) Token: 0x060023B0 RID: 9136 RVA: 0x000DCCCC File Offset: 0x000DAECC
		public ParameterStringValue NullValue
		{
			get
			{
				ParameterStringValue parameterStringValue = \u001C\u000F\u0016.\u000A();
				\u0012\u000F\u0016.\u000A(parameterStringValue, "null");
				return parameterStringValue;
			}
		}

		// Token: 0x170009F2 RID: 2546
		// (get) Token: 0x060023B1 RID: 9137 RVA: 0x000DCCEC File Offset: 0x000DAEEC
		public ObservableCollection<ParameterIntegerValue> BooleanValues
		{
			get
			{
				if (this._bools == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_BooleanValues()).MethodHandle;
					}
					ObservableCollection<ParameterIntegerValue> observableCollection = \u0002\u0013\u000B.\u000A();
					ParameterIntegerValue parameterIntegerValue = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue, "");
					\u0004\u0013\u000B.\u000A(parameterIntegerValue, -1);
					\u0002\u001A\u000B.\u000A(parameterIntegerValue, true);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue);
					ParameterIntegerValue parameterIntegerValue2 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue2, \u000B\u001A\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue2, 0);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue2);
					ParameterIntegerValue parameterIntegerValue3 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue3, \u0016\u001A\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue3, 1);
					\u001D\u0013\u000B.\u000A(observableCollection, parameterIntegerValue3);
					ObservableCollection<ParameterIntegerValue> bools = observableCollection;
					return this._bools = bools;
				}
				return this._bools;
			}
		}

		// Token: 0x170009F3 RID: 2547
		// (get) Token: 0x060023B2 RID: 9138 RVA: 0x000DCD98 File Offset: 0x000DAF98
		public ObservableCollection<ParameterIntegerValue> FarClipping
		{
			get
			{
				if (this._farClipping == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_FarClipping()).MethodHandle;
					}
					List<ParameterIntegerValue> list = \u000D\u001A\u000B.\u000A();
					ParameterIntegerValue parameterIntegerValue = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue, \u001C\u001A\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue, 0);
					\u000F\u001A\u000B.\u000A(list, parameterIntegerValue);
					ParameterIntegerValue parameterIntegerValue2 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue2, \u0003\u001A\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue2, 2);
					\u000F\u001A\u000B.\u000A(list, parameterIntegerValue2);
					ParameterIntegerValue parameterIntegerValue3 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue3, \u0012\u001A\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue3, 1);
					\u000F\u001A\u000B.\u000A(list, parameterIntegerValue3);
					List<ParameterIntegerValue> u001F = list;
					return this._farClipping = \u0006\u001A\u000B.\u000A(u001F);
				}
				return this._farClipping;
			}
		}

		// Token: 0x170009F4 RID: 2548
		// (get) Token: 0x060023B3 RID: 9139 RVA: 0x000DCE48 File Offset: 0x000DB048
		public ObservableCollection<ParameterIdValue> ViewTemplates
		{
			get
			{
				if (this._temps == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_ViewTemplates()).MethodHandle;
					}
					IEnumerable<View> enumerable = Enumerable.Cast<View>(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004)), \u001E\u0011\u000A.\u000A(\u0006\u001F\u000E.\u001F())));
					Func<View, bool> func;
					if ((func = ParameterDataProvider.<>c.\u0019) == null)
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
						func = (ParameterDataProvider.<>c.\u0019 = new Func<View, bool>(ParameterDataProvider.<>c.\u001F.\u0010));
					}
					object u001F = Enumerable.ToList<View>(Enumerable.Where<View>(enumerable, func));
					List<ParameterIdValue> list = \u0018\u001A\u000B.\u000A();
					IEnumerator<View> enumerator = \u0011\u001C\u0007.\u000A(u001F);
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							View u001F2 = \u001B\u001C\u0007.\u000A(enumerator);
							object u001F3 = list;
							ParameterIdValue parameterIdValue = \u0007\u0012\u0016.\u000A();
							\u0012\u000F\u0016.\u000A(parameterIdValue, SheetAndViewCreationHelper.\u001D(u001F2));
							\u001F\u0012\u0016.\u000A(parameterIdValue, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F2)));
							\u0019\u001A\u000B.\u000A(u001F3, parameterIdValue);
						}
						for (;;)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					finally
					{
						if (enumerator != null)
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
							\u001F\u0017\u000A.\u000A(enumerator);
						}
					}
					IEnumerable<ParameterIdValue> enumerable2 = list;
					Func<ParameterIdValue, string> func2;
					if ((func2 = ParameterDataProvider.<>c.\u0018) == null)
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
						func2 = (ParameterDataProvider.<>c.\u0018 = new Func<ParameterIdValue, string>(ParameterDataProvider.<>c.\u001F.\u000E));
					}
					list = Enumerable.ToList<ParameterIdValue>(Enumerable.OrderBy<ParameterIdValue, string>(enumerable2, func2));
					\u000A\u001A\u000B.\u000A(list, 0, ParameterIdValue.\u001F());
					return this._temps = \u001F\u001A\u000B.\u000A(list);
				}
				return this._temps;
			}
		}

		// Token: 0x170009F5 RID: 2549
		// (get) Token: 0x060023B4 RID: 9140 RVA: 0x000DCFC0 File Offset: 0x000DB1C0
		public ObservableCollection<ParameterIntegerValue> Orientations
		{
			get
			{
				if (this._orientations == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_Orientations()).MethodHandle;
					}
					List<ParameterIntegerValue> list = \u000D\u001A\u000B.\u000A();
					ParameterIntegerValue parameterIntegerValue = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue, \u0008\u001A\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue, 0);
					\u000F\u001A\u000B.\u000A(list, parameterIntegerValue);
					ParameterIntegerValue parameterIntegerValue2 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue2, \u000E\u001A\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue2, 1);
					\u000F\u001A\u000B.\u000A(list, parameterIntegerValue2);
					List<ParameterIntegerValue> list2 = list;
					object u001F = list2;
					Comparison<ParameterIntegerValue> u000A;
					if ((u000A = ParameterDataProvider.<>c.\u0005) == null)
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
						u000A = (ParameterDataProvider.<>c.\u0005 = new Comparison<ParameterIntegerValue>(ParameterDataProvider.<>c.\u001F.\u0008));
					}
					\u0010\u001A\u000B.\u000A(u001F, u000A);
					return this._orientations = \u0006\u001A\u000B.\u000A(list2);
				}
				return this._orientations;
			}
		}

		// Token: 0x170009F6 RID: 2550
		// (get) Token: 0x060023B5 RID: 9141 RVA: 0x000DD07C File Offset: 0x000DB27C
		public ObservableCollection<ParameterIntegerValue> DetailLevels
		{
			get
			{
				if (this._detailLevels == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_DetailLevels()).MethodHandle;
					}
					List<ParameterIntegerValue> list = \u000D\u001A\u000B.\u000A();
					ParameterIntegerValue parameterIntegerValue = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue, \u001E\u001A\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue, 1);
					\u000F\u001A\u000B.\u000A(list, parameterIntegerValue);
					ParameterIntegerValue parameterIntegerValue2 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue2, \u0011\u001A\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue2, 2);
					\u000F\u001A\u000B.\u000A(list, parameterIntegerValue2);
					ParameterIntegerValue parameterIntegerValue3 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue3, \u001B\u001A\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue3, 3);
					\u000F\u001A\u000B.\u000A(list, parameterIntegerValue3);
					List<ParameterIntegerValue> list2 = list;
					object u001F = list2;
					Comparison<ParameterIntegerValue> u000A;
					if ((u000A = ParameterDataProvider.<>c.\u0016) == null)
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
						u000A = (ParameterDataProvider.<>c.\u0016 = new Comparison<ParameterIntegerValue>(ParameterDataProvider.<>c.\u001F.\u001B));
					}
					\u0010\u001A\u000B.\u000A(u001F, u000A);
					return this._detailLevels = \u0006\u001A\u000B.\u000A(list2);
				}
				return this._detailLevels;
			}
		}

		// Token: 0x170009F7 RID: 2551
		// (get) Token: 0x060023B6 RID: 9142 RVA: 0x000DD15C File Offset: 0x000DB35C
		public ObservableCollection<ParameterIntegerValue> VisualStyles
		{
			get
			{
				if (this._visStyles == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_VisualStyles()).MethodHandle;
					}
					List<ParameterIntegerValue> list = \u000D\u001A\u000B.\u000A();
					ParameterIntegerValue parameterIntegerValue = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue, \u0017\u001A\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue, 1);
					\u000F\u001A\u000B.\u000A(list, parameterIntegerValue);
					ParameterIntegerValue parameterIntegerValue2 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue2, \u0020\u001A\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue2, 2);
					\u000F\u001A\u000B.\u000A(list, parameterIntegerValue2);
					List<ParameterIntegerValue> list2 = list;
					object u001F = list2;
					Comparison<ParameterIntegerValue> u000A;
					if ((u000A = ParameterDataProvider.<>c.\u000B) == null)
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
						u000A = (ParameterDataProvider.<>c.\u000B = new Comparison<ParameterIntegerValue>(ParameterDataProvider.<>c.\u001F.\u0011));
					}
					\u0010\u001A\u000B.\u000A(u001F, u000A);
					return this._visStyles = \u0006\u001A\u000B.\u000A(list2);
				}
				return this._visStyles;
			}
		}

		// Token: 0x170009F8 RID: 2552
		// (get) Token: 0x060023B7 RID: 9143 RVA: 0x000DD218 File Offset: 0x000DB418
		public ObservableCollection<ParameterIntegerValue> Disciplines
		{
			get
			{
				if (this._displines == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_Disciplines()).MethodHandle;
					}
					List<ParameterIntegerValue> list = \u000D\u001A\u000B.\u000A();
					ParameterIntegerValue parameterIntegerValue = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue, \u000C\u001A\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue, 1);
					\u000F\u001A\u000B.\u000A(list, parameterIntegerValue);
					ParameterIntegerValue parameterIntegerValue2 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue2, \u0004\u0014\u0018.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue2, 8);
					\u000F\u001A\u000B.\u000A(list, parameterIntegerValue2);
					ParameterIntegerValue parameterIntegerValue3 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue3, \u0019\u0014\u0018.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue3, 4);
					\u000F\u001A\u000B.\u000A(list, parameterIntegerValue3);
					ParameterIntegerValue parameterIntegerValue4 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue4, \u001A\u001A\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue4, 16);
					\u000F\u001A\u000B.\u000A(list, parameterIntegerValue4);
					ParameterIntegerValue parameterIntegerValue5 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue5, \u0013\u001A\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue5, 2);
					\u000F\u001A\u000B.\u000A(list, parameterIntegerValue5);
					ParameterIntegerValue parameterIntegerValue6 = \u0018\u0013\u000B.\u000A();
					\u0012\u000F\u0016.\u000A(parameterIntegerValue6, \u0014\u001A\u000B.\u000A());
					\u0004\u0013\u000B.\u000A(parameterIntegerValue6, 4095);
					\u000F\u001A\u000B.\u000A(list, parameterIntegerValue6);
					List<ParameterIntegerValue> list2 = list;
					object u001F = list2;
					Comparison<ParameterIntegerValue> u000A;
					if ((u000A = ParameterDataProvider.<>c.\u0002) == null)
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
						u000A = (ParameterDataProvider.<>c.\u0002 = new Comparison<ParameterIntegerValue>(ParameterDataProvider.<>c.\u001F.\u001E));
					}
					\u0010\u001A\u000B.\u000A(u001F, u000A);
					return this._displines = \u0006\u001A\u000B.\u000A(list2);
				}
				return this._displines;
			}
		}

		// Token: 0x170009F9 RID: 2553
		// (get) Token: 0x060023B8 RID: 9144 RVA: 0x000DD360 File Offset: 0x000DB560
		public ObservableCollection<ParameterIdValue> ScopeBoxes
		{
			get
			{
				if (this._scopes == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.get_ScopeBoxes()).MethodHandle;
					}
					List<ParameterIdValue> list = \u0018\u001A\u000B.\u000A();
					IEnumerator<Element> enumerator = \u0009\u000C\u0004.\u000A(\u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004)), -2006000L)));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							Element u001F = \u0001\u000C\u0004.\u000A(enumerator);
							ParameterIdValue parameterIdValue = \u0007\u0012\u0016.\u000A();
							\u0012\u000F\u0016.\u000A(parameterIdValue, \u0005\u001E\u000A.\u000A(u001F));
							\u001F\u0012\u0016.\u000A(parameterIdValue, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F)));
							ParameterIdValue u000A = parameterIdValue;
							\u0019\u001A\u000B.\u000A(list, u000A);
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
					finally
					{
						if (enumerator != null)
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
							\u001F\u0017\u000A.\u000A(enumerator);
						}
					}
					IEnumerable<ParameterIdValue> enumerable = list;
					Func<ParameterIdValue, string> func;
					if ((func = ParameterDataProvider.<>c.\u0006) == null)
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
						func = (ParameterDataProvider.<>c.\u0006 = new Func<ParameterIdValue, string>(ParameterDataProvider.<>c.\u001F.\u0020));
					}
					list = Enumerable.ToList<ParameterIdValue>(Enumerable.OrderBy<ParameterIdValue, string>(enumerable, func));
					\u000A\u001A\u000B.\u000A(list, 0, ParameterIdValue.\u001F());
					return this._scopes = \u001F\u001A\u000B.\u000A(list);
				}
				return this._scopes;
			}
		}

		// Token: 0x060023B9 RID: 9145 RVA: 0x000DD49C File Offset: 0x000DB69C
		public List<SelectionParameter> GetCustomNameParameters(bool viewManager = false)
		{
			List<SelectionParameter> list = \u0016\u0016\u0016.\u000A();
			SelectionParameter selectionParameter = \u000F\u0009\u0016.\u000A();
			\u000B\u0012\u0016.\u001D(selectionParameter, \u0006\u001E\u000B.\u000A());
			\u0005\u0012\u0016.\u001D(selectionParameter, SelectionParameterType.Name);
			\u000A\u0016\u0016.\u000A(list, selectionParameter);
			SelectionParameter selectionParameter2 = \u000F\u0009\u0016.\u000A();
			\u000B\u0012\u0016.\u001D(selectionParameter2, \u0019\u000C\u000B.\u000A());
			\u0005\u0012\u0016.\u001D(selectionParameter2, SelectionParameterType.DateTime);
			\u000A\u0016\u0016.\u000A(list, selectionParameter2);
			SelectionParameter selectionParameter3 = \u000F\u0009\u0016.\u000A();
			\u000B\u0012\u0016.\u001D(selectionParameter3, \u0004\u000C\u000B.\u000A());
			\u0005\u0012\u0016.\u001D(selectionParameter3, SelectionParameterType.DateTime);
			\u000A\u0016\u0016.\u000A(list, selectionParameter3);
			SelectionParameter selectionParameter4 = \u000F\u0009\u0016.\u000A();
			\u000B\u0012\u0016.\u001D(selectionParameter4, \u001D\u000C\u000B.\u000A());
			\u0005\u0012\u0016.\u001D(selectionParameter4, SelectionParameterType.DateTime);
			\u000A\u0016\u0016.\u000A(list, selectionParameter4);
			SelectionParameter selectionParameter5 = \u000F\u0009\u0016.\u000A();
			\u000B\u0012\u0016.\u001D(selectionParameter5, \u0007\u000C\u000B.\u000A());
			\u0005\u0012\u0016.\u001D(selectionParameter5, SelectionParameterType.DateTime);
			\u000A\u0016\u0016.\u000A(list, selectionParameter5);
			SelectionParameter selectionParameter6 = \u000F\u0009\u0016.\u000A();
			\u000B\u0012\u0016.\u001D(selectionParameter6, \u000A\u000C\u000B.\u000A());
			\u0005\u0012\u0016.\u001D(selectionParameter6, SelectionParameterType.DateTime);
			\u000A\u0016\u0016.\u000A(list, selectionParameter6);
			SelectionParameter selectionParameter7 = \u000F\u0009\u0016.\u000A();
			\u000B\u0012\u0016.\u001D(selectionParameter7, \u001F\u000C\u000B.\u000A());
			\u0005\u0012\u0016.\u001D(selectionParameter7, SelectionParameterType.DateTime);
			\u000A\u0016\u0016.\u000A(list, selectionParameter7);
			SelectionParameter selectionParameter8 = \u000F\u0009\u0016.\u000A();
			\u000B\u0012\u0016.\u001D(selectionParameter8, \u0009\u001A\u000B.\u000A());
			\u0005\u0012\u0016.\u001D(selectionParameter8, SelectionParameterType.DateTime);
			\u000A\u0016\u0016.\u000A(list, selectionParameter8);
			List<SelectionParameter> list2 = list;
			if (!viewManager)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.GetCustomNameParameters(bool)).MethodHandle;
				}
				object u001F = list2;
				int u000A = 1;
				SelectionParameter selectionParameter9 = \u000F\u0009\u0016.\u000A();
				\u000B\u0012\u0016.\u001D(selectionParameter9, \u0002\u001E\u000B.\u000A());
				\u0005\u0012\u0016.\u001D(selectionParameter9, SelectionParameterType.Number);
				\u0001\u001A\u000B.\u000A(u001F, u000A, selectionParameter9);
			}
			else
			{
				\u000B\u0012\u0016.\u001D(\u0015\u001A\u000B.\u000A(list2, 0), \u0004\u0003\u000B.\u000A());
			}
			return list2;
		}

		// Token: 0x060023BA RID: 9146 RVA: 0x000DD610 File Offset: 0x000DB810
		public IEnumerable<string> GetValueStrings(ParameterDataType type)
		{
			IEnumerable<ParameterStringValue> enumerable = \u0001\u0006\u0016.\u001D(this, type);
			if (enumerable == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterDataProvider.GetValueStrings(ParameterDataType)).MethodHandle;
				}
				return null;
			}
			Func<ParameterStringValue, string> func;
			if ((func = ParameterDataProvider.<>c.\u000F) == null)
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
				func = (ParameterDataProvider.<>c.\u000F = new Func<ParameterStringValue, string>(ParameterDataProvider.<>c.\u001F.\u0017));
			}
			return Enumerable.Select<ParameterStringValue, string>(enumerable, func);
		}

		// Token: 0x060023BB RID: 9147 RVA: 0x000DD670 File Offset: 0x000DB870
		public IEnumerable<ParameterStringValue> GetValues(ParameterDataType type)
		{
			switch (type)
			{
			case ParameterDataType.Bool:
				return \u000A\u0005\u0016.\u001D(this);
			case ParameterDataType.ViewOrientation:
				return \u0016\u000F\u0016.\u001D(this);
			case ParameterDataType.ViewDiscipline:
				return \u0005\u000F\u0016.\u001D(this);
			case ParameterDataType.DetailLevel:
				return \u0018\u000F\u0016.\u001D(this);
			case ParameterDataType.ViewTemplate:
				return \u0019\u000F\u0016.\u001D(this);
			case ParameterDataType.ScopeBox:
				return \u0004\u000F\u0016.\u001D(this);
			case ParameterDataType.FarClipping:
				return \u0020\u000C\u000B.\u000A(this);
			case ParameterDataType.VisualStyle:
				return \u001E\u000C\u000B.\u000A(this);
			case ParameterDataType.PartVisiblity:
				return \u0011\u000C\u000B.\u000A(this);
			case ParameterDataType.DisplayModel:
				return \u001B\u000C\u000B.\u000A(this);
			case ParameterDataType.RotationOnSheet:
				return \u0008\u000C\u000B.\u000A(this);
			case ParameterDataType.ShowHiddenLines:
				return \u000E\u000C\u000B.\u000A(this);
			case ParameterDataType.ColorSchemaLocation:
				return \u0010\u000C\u000B.\u000A(this);
			case ParameterDataType.WallJoinDisplay:
				return \u000D\u000C\u000B.\u000A(this);
			case ParameterDataType.ProjectModel:
				return \u001C\u000C\u000B.\u000A(this);
			case ParameterDataType.FarClipSettings:
				return \u0003\u000C\u000B.\u000A(this);
			case ParameterDataType.ShowIn:
				return \u0012\u000C\u000B.\u000A(this);
			case ParameterDataType.UnderlayOrientation:
				return \u000F\u000C\u000B.\u000A(this);
			case ParameterDataType.Phases:
				return \u0006\u000C\u000B.\u000A(this);
			case ParameterDataType.PhaseFilters:
				return \u0002\u000C\u000B.\u000A(this);
			case ParameterDataType.RangeBaseLevel:
				return \u000B\u000C\u000B.\u000A(this);
			case ParameterDataType.RangeTopLevel:
				return \u0016\u000C\u000B.\u000A(this);
			case ParameterDataType.Material:
				return \u0005\u000C\u000B.\u000A(this);
			case ParameterDataType.FillPattern:
				return \u0018\u000C\u000B.\u000A(this);
			case ParameterDataType.TitleBlock:
				return \u001A\u000F\u0016.\u001D(this);
			}
			return \u0004\u000E\u000E.\u001F;
		}

		// Token: 0x060023BC RID: 9148 RVA: 0x000DD83C File Offset: 0x000DBA3C
		public List<BuiltInParameter> GetSkippedViewsParameters()
		{
			List<BuiltInParameter> list = \u000E\u0006\u0005.\u000A();
			\u0010\u0006\u0005.\u000A(list, -1005147L);
			\u0010\u0006\u0005.\u000A(list, -1002052L);
			\u0010\u0006\u0005.\u000A(list, -1140362L);
			\u0010\u0006\u0005.\u000A(list, -1002051L);
			\u0010\u0006\u0005.\u000A(list, -1139998L);
			\u0010\u0006\u0005.\u000A(list, -1002002L);
			\u0010\u0006\u0005.\u000A(list, -1002001L);
			\u0010\u0006\u0005.\u000A(list, -1007419L);
			\u0010\u0006\u0005.\u000A(list, -1140363L);
			\u0010\u0006\u0005.\u000A(list, -1139999L);
			\u0010\u0006\u0005.\u000A(list, -1002000L);
			\u0010\u0006\u0005.\u000A(list, -1012109L);
			\u0010\u0006\u0005.\u000A(list, -1139997L);
			\u0010\u0006\u0005.\u000A(list, -1012106L);
			\u0010\u0006\u0005.\u000A(list, -1002050L);
			\u0010\u0006\u0005.\u000A(list, -1007409L);
			\u0010\u0006\u0005.\u000A(list, -1006602L);
			\u0010\u0006\u0005.\u000A(list, -1013201L);
			\u0010\u0006\u0005.\u000A(list, -1006601L);
			\u0010\u0006\u0005.\u000A(list, -1005148L);
			\u0010\u0006\u0005.\u000A(list, -1005120L);
			\u0010\u0006\u0005.\u000A(list, -1006612L);
			\u0010\u0006\u0005.\u000A(list, -1007608L);
			\u0010\u0006\u0005.\u000A(list, -1005332L);
			\u0010\u0006\u0005.\u000A(list, -1005112L);
			\u0010\u0006\u0005.\u000A(list, -1005199L);
			\u0010\u0006\u0005.\u000A(list, -1005165L);
			return list;
		}

		// Token: 0x060023BD RID: 9149 RVA: 0x000DD994 File Offset: 0x000DBB94
		public void Dispose()
		{
			this._temps = \u000A\u000E\u000E.\u001F;
			this._displines = \u0007\u000E\u000E.\u001F;
			this._visStyles = \u0007\u000E\u000E.\u001F;
			this._detailLevels = \u0007\u000E\u000E.\u001F;
			this._orientations = \u0007\u000E\u000E.\u001F;
			this._farClipping = \u0007\u000E\u000E.\u001F;
			this._bools = \u0007\u000E\u000E.\u001F;
			this._scopes = \u000A\u000E\u000E.\u001F;
			this._titleBlocks = \u000A\u000E\u000E.\u001F;
			ParameterDataProvider.\u001F = \u001D\u000E\u000E.\u001F;
		}

		// Token: 0x04000E0E RID: 3598
		private ObservableCollection<ParameterIntegerValue> _partVisiblity;

		// Token: 0x04000E0F RID: 3599
		private ObservableCollection<