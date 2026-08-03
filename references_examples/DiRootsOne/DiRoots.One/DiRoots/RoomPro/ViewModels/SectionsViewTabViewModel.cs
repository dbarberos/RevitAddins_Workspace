using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.QuickViews.Helpers;
using DiRoots.RoomPro.Interfaces;
using DiRoots.RoomPro.Models;

namespace DiRoots.RoomPro.ViewModels
{
	// Token: 0x0200005E RID: 94
	public class SectionsViewTabViewModel : SettingsTabViewModel
	{
		// Token: 0x06000414 RID: 1044 RVA: 0x0001990C File Offset: 0x00017B0C
		public SectionsViewTabViewModel(IModelSettings settings)
		{
			List<ViewDetailLevel> list = new List<ViewDetailLevel>();
			\u0017\u000B\u0007.\u000A(list, 1);
			\u0017\u000B\u0007.\u000A(list, 2);
			\u0017\u000B\u0007.\u000A(list, 3);
			this.ViewDetailLevels = list;
			string[] array = \u001B\u001F\u000E.\u001F(2);
			array[0] = \u000C\u001D.\u0018;
			array[1] = \u000C\u001D.\u0019;
			this.References = array;
			base..ctor();
			\u0011\u001E\u0007.\u000A(this, \u0008\u001F\u000E.\u001F(settings));
			this.R = \u000C\u001D.\u0006;
			this.M = \u001E\u000B\u0007.\u000A(this.R);
			string[] u000A;
			if (this.M != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionsViewTabViewModel..ctor(IModelSettings)).MethodHandle;
				}
				u000A = \u0009\u001D.\u000A;
			}
			else
			{
				u000A = \u0009\u001D.\u001F;
			}
			\u001B\u001E\u0007.\u000A(this, u000A);
			\u0013\u001D u0013_u001D = new \u0013\u001D(this.R);
			IEnumerable<ViewFamilyType> enumerable = u0013_u001D.\u000F(114);
			Func<ViewFamilyType, ModelViewType> func;
			if ((func = SectionsViewTabViewModel.<>c.\u000A) == null)
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
				func = (SectionsViewTabViewModel.<>c.\u000A = new Func<ViewFamilyType, ModelViewType>(SectionsViewTabViewModel.<>c.\u001F.\u0004));
			}
			\u0008\u001E\u0007.\u000A(this, Enumerable.ToList<ModelViewType>(Enumerable.Select<ViewFamilyType, ModelViewType>(enumerable, func)));
			IEnumerable<ViewFamilyType> enumerable2 = u0013_u001D.\u000F(112);
			Func<ViewFamilyType, ModelViewType> func2;
			if ((func2 = SectionsViewTabViewModel.<>c.\u0007) == null)
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
				func2 = (SectionsViewTabViewModel.<>c.\u0007 = new Func<ViewFamilyType, ModelViewType>(SectionsViewTabViewModel.<>c.\u001F.\u0019));
			}
			\u000E\u001E\u0007.\u000A(this, Enumerable.ToList<ModelViewType>(Enumerable.Select<ViewFamilyType, ModelViewType>(enumerable2, func2)));
			IEnumerable<Phase> enumerable3 = u0013_u001D.\u0012();
			Func<Phase, ModelPhase> func3;
			if ((func3 = SectionsViewTabViewModel.<>c.\u001D) == null)
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
				func3 = (SectionsViewTabViewModel.<>c.\u001D = new Func<Phase, ModelPhase>(SectionsViewTabViewModel.<>c.\u001F.\u0018));
			}
			\u0010\u001E\u0007.\u000A(this, Enumerable.ToList<ModelPhase>(Enumerable.Select<Phase, ModelPhase>(enumerable3, func3)));
			\u000D\u001E\u0007.\u000A(this, Enumerable.ToList<ViewTemplate>(u0013_u001D.\u000D()));
			this.JKR(\u001C\u001E\u0007.\u000A(this));
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000415 RID: 1045 RVA: 0x00019ABC File Offset: 0x00017CBC
		// (set) Token: 0x06000416 RID: 1046 RVA: 0x00019AD0 File Offset: 0x00017CD0
		public SectionViewSettings SectionViewSettings
		{
			get
			{
				return this.NY;
			}
			set
			{
				this.NY = value;
				\u000D\u0020\u000A.\u000A(this, "SectionViewSettings");
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x00019AF0 File Offset: 0x00017CF0
		// (set) Token: 0x06000418 RID: 1048 RVA: 0x00019B04 File Offset: 0x00017D04
		public List<ModelViewType> ElevationTypes { get; private set; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x00019B18 File Offset: 0x00017D18
		// (set) Token: 0x0600041A RID: 1050 RVA: 0x00019B2C File Offset: 0x00017D2C
		public List<ModelViewType> SectionTypes { get; private set; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600041B RID: 1051 RVA: 0x00019B40 File Offset: 0x00017D40
		// (set) Token: 0x0600041C RID: 1052 RVA: 0x00019B54 File Offset: 0x00017D54
		public string[] Scales { get; private set; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600041D RID: 1053 RVA: 0x00019B68 File Offset: 0x00017D68
		// (set) Token: 0x0600041E RID: 1054 RVA: 0x00019B7C File Offset: 0x00017D7C
		public List<ViewDetailLevel> ViewDetailLevels { get; private set; }

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x00019B90 File Offset: 0x00017D90
		// (set) Token: 0x06000420 RID: 1056 RVA: 0x00019BA4 File Offset: 0x00017DA4
		public List<ViewTemplate> ViewTemplates { get; private set; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x00019BB8 File Offset: 0x00017DB8
		// (set) Token: 0x06000422 RID: 1058 RVA: 0x00019BCC File Offset: 0x00017DCC
		public List<ModelPhase> Phases { get; private set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x00019BE0 File Offset: 0x00017DE0
		// (set) Token: 0x06000424 RID: 1060 RVA: 0x00019BF4 File Offset: 0x00017DF4
		public string[] References { get; private set; }

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x00019C08 File Offset: 0x00017E08
		// (set) Token: 0x06000426 RID: 1062 RVA: 0x00019C1C File Offset: 0x00017E1C
		public ModelViewType SelectedElevationType { get; set; }

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x00019C30 File Offset: 0x00017E30
		// (set) Token: 0x06000428 RID: 1064 RVA: 0x00019C44 File Offset: 0x00017E44
		public ModelViewType SelectedSectionType { get; set; }

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x00019C58 File Offset: 0x00017E58
		// (set) Token: 0x0600042A RID: 1066 RVA: 0x00019C6C File Offset: 0x00017E6C
		public string SelectedScale { get; set; }

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x00019C80 File Offset: 0x00017E80
		// (set) Token: 0x0600042C RID: 1068 RVA: 0x00019C94 File Offset: 0x00017E94
		public ViewDetailLevel ViewDetailLevel { get; set; }

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x00019CA8 File Offset: 0x00017EA8
		// (set) Token: 0x0600042E RID: 1070 RVA: 0x00019CBC File Offset: 0x00017EBC
		public ModelPhase SelectedPhase { get; set; }

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x00019CD0 File Offset: 0x00017ED0
		// (set) Token: 0x06000430 RID: 1072 RVA: 0x00019CE4 File Offset: 0x00017EE4
		public ViewTemplate SelectedViewTemplate { get; set; }

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x00019CF8 File Offset: 0x00017EF8
		// (set) Token: 0x06000432 RID: 1074 RVA: 0x00019D0C File Offset: 0x00017F0C
		public bool UseOneMarker { get; set; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x00019D20 File Offset: 0x00017F20
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x00019D34 File Offset: 0x00017F34
		public string SelectedReference
		{
			get
			{
				return this.EY;
			}
			set
			{
				this.EY = value;
				\u000D\u0020\u000A.\u000A(this, "SelectedReference");
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x00019D54 File Offset: 0x00017F54
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x00019D68 File Offset: 0x00017F68
		public double AbsoluteSectionHeight
		{
			get
			{
				return this.KY;
			}
			set
			{
				this.KY = value;
				\u000D\u0020\u000A.\u000A(this, "AbsoluteSectionHeight");
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x00019D88 File Offset: 0x00017F88
		// (set) Token: 0x06000438 RID: 1080 RVA: 0x00019D9C File Offset: 0x00017F9C
		public double RelativeSectionHeight
		{
			get
			{
				return this.JY;
			}
			set
			{
				this.JY = value;
				\u000D\u0020\u000A.\u000A(this, "RelativeSectionHeight");
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x00019DBC File Offset: 0x00017FBC
		// (set) Token: 0x0600043A RID: 1082 RVA: 0x00019DD0 File Offset: 0x00017FD0
		public double OffsetBottom
		{
			get
			{
				return this.MY;
			}
			set
			{
				this.MY = value;
				\u000D\u0020\u000A.\u000A(this, "OffsetBottom");
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x00019DF0 File Offset: 0x00017FF0
		// (set) Token: 0x0600043C RID: 1084 RVA: 0x00019E04 File Offset: 0x00018004
		public double OffsetLeft
		{
			get
			{
				return this.VY;
			}
			set
			{
				this.VY = value;
				\u000D\u0020\u000A.\u000A(this, "OffsetLeft");
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x00019E24 File Offset: 0x00018024
		// (set) Token: 0x0600043E RID: 1086 RVA: 0x00019E38 File Offset: 0x00018038
		public double OffsetRight
		{
			get
			{
				return this.ZY;
			}
			set
			{
				this.ZY = value;
				\u000D\u0020\u000A.\u000A(this, "OffsetRight");
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x00019E58 File Offset: 0x00018058
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x00019E6C File Offset: 0x0001806C
		public double DistanceBeforeBoundary
		{
			get
			{
				return this.XY;
			}
			set
			{
				this.XY = value;
				\u000D\u0020\u000A.\u000A(this, "DistanceBeforeBoundary");
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x00019E8C File Offset: 0x0001808C
		// (set) Token: 0x06000442 RID: 1090 RVA: 0x00019EA0 File Offset: 0x000180A0
		public double DistanceAfterBoundary
		{
			get
			{
				return this.PY;
			}
			set
			{
				this.PY = value;
				\u000D\u0020\u000A.\u000A(this, "DistanceAfterBoundary");
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x00019EC0 File Offset: 0x000180C0
		// (set) Token: 0x06000444 RID: 1092 RVA: 0x00019ED4 File Offset: 0x000180D4
		public double BoundLineTolerance
		{
			get
			{
				return this.OY;
			}
			set
			{
				this.OY = value;
				\u000D\u0020\u000A.\u000A(this, "BoundLineTolerance");
			}
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00019EF4 File Offset: 0x000180F4
		public override bool Validate(string propertyName, object value)
		{
			if (propertyName != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionsViewTabViewModel.Validate(string, object)).MethodHandle;
				}
				int num = \u001C\u000F\u0007.\u001D(propertyName);
				switch (num)
				{
				case 10:
					if (\u0008\u0013\u000A.\u000A(propertyName, "OffsetLeft"))
					{
						return this.ZKR(propertyName, value);
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
					break;
				case 11:
					if (\u0008\u0013\u000A.\u000A(propertyName, "OffsetRight"))
					{
						return this.ZKR(propertyName, value);
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
					break;
				case 12:
					if (\u0008\u0013\u000A.\u000A(propertyName, "OffsetBottom"))
					{
						return this.ZKR(propertyName, value);
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
					break;
				default:
					switch (num)
					{
					case 18:
						if (\u0008\u0013\u000A.\u000A(propertyName, "BoundLineTolerance"))
						{
							return this.ZKR(propertyName, value);
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
						break;
					case 21:
					{
						char c = \u001E\u001E\u0007.\u0007(propertyName, 0);
						if (c != 'A')
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
							if (c != 'D')
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
								if (c != 'R')
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
								}
								else
								{
									if (\u0008\u0013\u000A.\u000A(propertyName, "RelativeSectionHeight"))
									{
										return this.ZKR(propertyName, value);
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
							}
							else
							{
								if (\u0008\u0013\u000A.\u000A(propertyName, "DistanceAfterBoundary"))
								{
									return this.ZKR(propertyName, value);
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
						}
						else
						{
							if (\u0008\u0013\u000A.\u000A(propertyName, "AbsoluteSectionHeight"))
							{
								return this.ZKR(propertyName, value);
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
						break;
					}
					case 22:
						if (\u0008\u0013\u000A.\u000A(propertyName, "DistanceBeforeBoundary"))
						{
							return this.ZKR(propertyName, value);
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
						break;
					}
					break;
				}
			}
			return true;
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x0001A0E8 File Offset: 0x000182E8
		private bool ZKR(string F, object R)
		{
			bool flag = \u0018\u0007\u000A.\u001F(this, F, R);
			if (!flag)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionsViewTabViewModel.ZKR(string, object)).MethodHandle;
				}
				return flag;
			}
			double num = this.XKR(R);
			string text = \u000F\u0015\u0010.\u001F;
			if (num < 0.0)
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
				text = \u0016\u0006\u0007.\u000A();
			}
			if (!\u0008\u0013\u000A.\u000A(F, "AbsoluteSectionHeight"))
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
				if (!\u0008\u0013\u000A.\u000A(F, "DistanceAfterBoundary"))
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
					if (!\u0008\u0013\u000A.\u000A(F, "RelativeSectionHeight"))
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
						goto IL_F0;
					}
					if (num <= 0.0)
					{
						goto IL_F0;
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
					if (num > 10000.\u0007())
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
						text = \u0020\u001E\u0007.\u000A();
						goto IL_F0;
					}
					goto IL_F0;
				}
			}
			string text2;
			if ((text2 = text) == null)
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
				text2 = this.ZER(num);
			}
			text = text2;
			IL_F0:
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
				\u0018\u0006\u0007.\u000A(this, F, \u0005\u0006\u0007.\u000A(text, ErrorType.Error));
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0001A208 File Offset: 0x00018408
		private string ZER(double F)
		{
			if (F == 0.0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionsViewTabViewModel.ZER(double)).MethodHandle;
				}
				return \u0013\u001E\u0007.\u000A();
			}
			if (F > 0.0)
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
				if (F < 10.\u0007())
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
					return \u0014\u001E\u0007.\u000A();
				}
			}
			if (F > 0.0)
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
				if (F > 10000.\u0007())
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
					return \u0017\u001E\u0007.\u000A();
				}
			}
			return null;
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0001A2A8 File Offset: 0x000184A8
		private void JKR(SectionViewSettings F)
		{
			SectionsViewTabViewModel.\u000F\u001D u000F_u001D = new SectionsViewTabViewModel.\u000F\u001D();
			u000F_u001D.\u001F = F;
			ModelViewType u000A;
			if ((u000A = \u001B\u0002\u0007.\u000A(\u001E\u0020\u0007.\u000A(this), new Predicate<ModelViewType>(u000F_u001D.\u000A))) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionsViewTabViewModel.JKR(SectionViewSettings)).MethodHandle;
				}
				u000A = \u001B\u0002\u0007.\u000A(\u001E\u0020\u0007.\u000A(this), new Predicate<ModelViewType>(u000F_u001D.\u0007));
			}
			\u0011\u0020\u0007.\u000A(this, u000A);
			if (\u0020\u0020\u0007.\u000A(this) == null)
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
				\u0011\u0020\u0007.\u000A(this, \u0019\u0006\u0007.\u000A(\u001E\u0020\u0007.\u000A(this), 0));
			}
			ModelViewType u000A2;
			if ((u000A2 = \u001B\u0002\u0007.\u000A(\u0008\u0020\u0007.\u000A(this), new Predicate<ModelViewType>(u000F_u001D.\u001D))) == null)
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
				u000A2 = \u001B\u0002\u0007.\u000A(\u0008\u0020\u0007.\u000A(this), new Predicate<ModelViewType>(u000F_u001D.\u0004));
			}
			\u000E\u0020\u0007.\u000A(this, u000A2);
			if (\u001B\u0020\u0007.\u000A(this) == null)
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
				\u000E\u0020\u0007.\u000A(this, \u0019\u0006\u0007.\u000A(\u0008\u0020\u0007.\u000A(this), 0));
			}
			\u0010\u0020\u0007.\u000A(this, \u0001\u001D.\u000A(\u0008\u0018\u0007.\u000A(u000F_u001D.\u001F), this.M));
			\u000D\u0020\u0007.\u000A(this, \u0010\u0018\u0007.\u000A(u000F_u001D.\u001F));
			ModelPhase u000A3;
			if ((u000A3 = \u000D\u0002\u0007.\u000A(\u0003\u0020\u0007.\u000A(this), new Predicate<ModelPhase>(u000F_u001D.\u0019))) == null)
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
				u000A3 = \u000D\u0002\u0007.\u000A(\u0003\u0020\u0007.\u000A(this), new Predicate<ModelPhase>(u000F_u001D.\u0018));
			}
			\u0012\u0020\u0007.\u000A(this, u000A3);
			if (\u001C\u0020\u0007.\u000A(this) == null)
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
				\u0012\u0020\u0007.\u000A(this, \u0009\u0002\u0007.\u000A(\u0003\u0020\u0007.\u000A(this), 0));
			}
			ViewTemplate u000A4;
			if ((u000A4 = \u0003\u0002\u0007.\u000A(\u0006\u0020\u0007.\u000A(this), new Predicate<ViewTemplate>(u000F_u001D.\u0005))) == null)
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
				u000A4 = \u0003\u0002\u0007.\u000A(\u0006\u0020\u0007.\u000A(this), new Predicate<ViewTemplate>(u000F_u001D.\u0016));
			}
			\u0002\u0020\u0007.\u000A(this, u000A4);
			if (\u000F\u0020\u0007.\u000A(this) == null)
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
				\u0002\u0020\u0007.\u000A(this, \u0015\u0002\u0007.\u000A(\u0006\u0020\u0007.\u000A(this), 0));
			}
			\u0016\u0020\u0007.\u000A(this, \u000B\u0020\u0007.\u000A(u000F_u001D.\u001F));
			\u0018\u0020\u0007.\u000A(this, \u0005\u0020\u0007.\u000A(u000F_u001D.\u001F));
			\u0004\u0020\u0007.\u000A(this, \u0019\u0020\u0007.\u000A(u000F_u001D.\u001F));
			\u0007\u0020\u0007.\u000A(this, \u001D\u0020\u0007.\u000A(u000F_u001D.\u001F));
			\u000A\u0020\u0007.\u000A(this, \u001B\u0018\u0007.\u000A(u000F_u001D.\u001F));
			\u001F\u0020\u0007.\u000A(this, \u0015\u0018\u0007.\u000A(u000F_u001D.\u001F));
			\u0009\u001E\u0007.\u000A(this, \u000C\u0018\u0007.\u000A(u000F_u001D.\u001F));
			\u0001\u001E\u0007.\u000A(this, \u0013\u0004\u0007.\u000A(u000F_u001D.\u001F));
			\u0015\u001E\u0007.\u000A(this, \u000E\u0018\u0007.\u000A(u000F_u001D.\u001F));
			\u001A\u001E\u0007.\u000A(this, \u000C\u001E\u0007.\u000A(u000F_u001D.\u001F));
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x0001A58C File Offset: 0x0001878C
		internal override bool JWR(out IModelSettings F)
		{
			SectionViewSettings sectionViewSettings = \u0011\u0017\u0007.\u000A();
			\u001B\u0017\u0007.\u000A(sectionViewSettings, \u0020\u0020\u0007.\u000A(this));
			\u0008\u0017\u0007.\u000A(sectionViewSettings, \u001B\u0020\u0007.\u000A(this));
			\u0010\u0017\u0007.\u000A(sectionViewSettings, \u0001\u001D.\u001F(\u000E\u0017\u0007.\u000A(this), this.M));
			\u001C\u0017\u0007.\u000A(sectionViewSettings, \u000D\u0017\u0007.\u000A(this));
			\u0003\u0017\u0007.\u000A(sectionViewSettings, \u001C\u0020\u0007.\u000A(this));
			\u0012\u0017\u0007.\u000A(sectionViewSettings, \u000F\u0020\u0007.\u000A(this));
			\u0006\u0017\u0007.\u000A(sectionViewSettings, \u000F\u0017\u0007.\u000A(this));
			\u000B\u0017\u0007.\u000A(sectionViewSettings, \u0002\u0017\u0007.\u000A(this));
			\u0005\u0017\u0007.\u000A(sectionViewSettings, \u0016\u0017\u0007.\u000A(this));
			\u0019\u0017\u0007.\u000A(sectionViewSettings, \u0018\u0017\u0007.\u000A(this));
			\u001D\u0017\u0007.\u000A(sectionViewSettings, \u0004\u0017\u0007.\u000A(this));
			\u000A\u0017\u0007.\u000A(sectionViewSettings, \u0007\u0017\u0007.\u000A(this));
			\u0009\u0020\u0007.\u000A(sectionViewSettings, \u001F\u0017\u0007.\u000A(this));
			\u0015\u0020\u0007.\u000A(sectionViewSettings, \u0001\u0020\u0007.\u000A(this));
			\u001A\u0020\u0007.\u000A(sectionViewSettings, \u000C\u0020\u0007.\u000A(this));
			\u0014\u0020\u0007.\u000A(sectionViewSettings, \u0013\u0020\u0007.\u000A(this));
			F = sectionViewSettings;
			\u0017\u0020\u0007.\u000A(\u000B\u001B\u0007.\u000A(), \u0008\u001F\u000E.\u001F(F));
			return true;
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0001A6A8 File Offset: 0x000188A8
		private double XKR(object F)
		{
			double result = 0.0;
			string text = \u0007\u001F\u000E.\u001F(F);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionsViewTabViewModel.XKR(object)).MethodHandle;
				}
				string text2;
				\u000B\u0006\u0007.\u000A(\u0006\u0006\u0007.\u000A(this.R), \u0002\u0006\u0007.\u000A(), text, ref result, ref text2);
			}
			return result;
		}

		// Token: 0x0400017D RID: 381
		private readonly DisplayUnit M;

		// Token: 0x0400017E RID: 382
		private double KY;

		// Token: 0x0400017F RID: 383
		private double JY;

		// Token: 0x04000180 RID: 384
		private string EY;

		// Token: 0x04000181 RID: 385
		private SectionViewSettings NY;

		// Token: 0x04000182 RID: 386
		private double MY;

		// Token: 0x04000183 RID: 387
		private double VY;

		// Token: 0x04000184 RID: 388
		private double ZY;

		// Token: 0x04000185 RID: 389
		private double XY;

		// Token: 0x04000186 RID: 390
		private double PY;

		// Token: 0x04000187 RID: 391
		private double OY;

		// Token: 0x04000188 RID: 392
		private readonly Document R;

		// Token: 0x04000189 RID: 393
		[CompilerGenerated]
		private List<ModelViewType> TY;

		// Token: 0x0400018A RID: 394
		[CompilerGenerated]
		private List<ModelViewType> IY;

		// Token: 0x0400018B RID: 395
		[CompilerGenerated]
		private string[] O;

		// Token: 0x0400018C RID: 396
		[CompilerGenerated]
		private List<ViewDetailLevel> T;

		// Token: 0x0400018D RID: 397
		[CompilerGenerated]
		private List<ViewTemplate> I;

		// Token: 0x0400018E RID: 398
		[CompilerGenerated]
		private List<ModelPhase> Q;

		// Token: 0x0400018F RID: 399
		[CompilerGenerated]
		private string[] QY;

		// Token: 0x04000190 RID: 400
		[CompilerGenerated]
		private ModelViewType AY;

		// Token: 0x04000191 RID: 401
		[CompilerGenerated]
		private ModelViewType GY;

		// Token: 0x04000192 RID: 402
		[CompilerGenerated]
		private string G;

		// Token: 0x04000193 RID: 403
		[CompilerGenerated]
		private ViewDetailLevel FR;

		// Token: 0x04000194 RID: 404
		[CompilerGenerated]
		private ModelPhase RR;

		// Token: 0x04000195 RID: 405
		[CompilerGenerated]
		private ViewTemplate DR;

		// Token: 0x04000196 RID: 406
		[CompilerGenerated]
		private bool FC;

		// Token: 0x020007AD RID: 1965
		[CompilerGenerated]
		private sealed class \u000F\u001D
		{
			// Token: 0x06004BFA RID: 19450 RVA: 0x001DB514 File Offset: 0x001D9714
			internal bool \u000A(ModelViewType \u001F)
			{
				return \u0018\u0018\u0007.\u0007(\u001F) == \u0018\u0018\u0007.\u0007(\u001A\u001A\u0007.\u000A(this.\u001F));
			}

			// Token: 0x06004BFB RID: 19451 RVA: 0x001DB540 File Offset: 0x001D9740
			internal bool \u0007(ModelViewType \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001D\u000D\u0007.\u0007(\u001F), \u001D\u000D\u0007.\u0007(\u001A\u001A\u0007.\u000A(this.\u001F)));
			}

			// Token: 0x06004BFC RID: 19452 RVA: 0x001DB570 File Offset: 0x001D9770
			internal bool \u001D(ModelViewType \u001F)
			{
				return \u0018\u0018\u0007.\u0007(\u001F) == \u0018\u0018\u0007.\u0007(\u0015\u001A\u0007.\u000A(this.\u001F));
			}

			// Token: 0x06004BFD RID: 19453 RVA: 0x001DB59C File Offset: 0x001D979C
			internal bool \u0004(ModelViewType \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001D\u000D\u0007.\u0007(\u001F), \u001D\u000D\u0007.\u0007(\u0015\u001A\u0007.\u000A(this.\u001F)));
			}

			// Token: 0x06004BFE RID: 19454 RVA: 0x001DB5CC File Offset: 0x001D97CC
			internal bool \u0019(ModelPhase \u001F)
			{
				return \u0018\u0018\u0007.\u0007(\u001F) == \u0018\u0018\u0007.\u0007(\u0005\u0018\u0007.\u000A(this.\u001F));
			}

			// Token: 0x06004BFF RID: 19455 RVA: 0x001DB5F8 File Offset: 0x001D97F8
			internal bool \u0018(ModelPhase \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001D\u000D\u0007.\u0007(\u001F), \u001D\u000D\u0007.\u0007(\u0005\u0018\u0007.\u000A(this.\u001F)));
			}

			// Token: 0x06004C00 RID: 19456 RVA: 0x001DB628 File Offset: 0x001D9828
			internal bool \u0005(ViewTemplate \u001F)
			{
				return \u0018\u0018\u0007.\u0007(\u001F) == \u0018\u0018\u0007.\u0007(\u0006\u0013\u0007.\u000A(this.\u001F));
			}

			// Token: 0x06004C01 RID: 19457 RVA: 0x001DB654 File Offset: 0x001D9854
			internal bool \u0016(ViewTemplate \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001D\u000D\u0007.\u0007(\u001F), \u001D\u000D\u0007.\u0007(\u0006\u0013\u0007.\u000A(this.\u001F)));
			}

			// Token: 0x04001F28 RID: 7976
			public SectionViewSettings \u001F;
		}
	}
}
