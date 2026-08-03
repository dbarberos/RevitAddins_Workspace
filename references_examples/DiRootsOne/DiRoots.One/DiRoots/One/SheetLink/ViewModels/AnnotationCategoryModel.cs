using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;
using DiRoots.One.SheetLink.Models;
using DiRoots.One.SheetLink.Profile;
using DiRoots.One.SheetLink.UI.Controls;
using DiRoots.One.UIBehaviours.Extensions;

namespace DiRoots.One.SheetLink.ViewModels
{
	// Token: 0x0200020E RID: 526
	public sealed class AnnotationCategoryModel : CategoryBaseModel
	{
		// Token: 0x06001365 RID: 4965 RVA: 0x0007BC94 File Offset: 0x00079E94
		public AnnotationCategoryModel(UIDocument uidoc, Window parent, AnnotationCategories userControl) : base(uidoc, parent, \u0009\u001B\u0018.\u000A())
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\AnnotationCategoryModel.cs", ".ctor");
			this.AU = userControl;
			this.ParametersModel = \u001A\u0014\u0018.\u0007(this.AU.J);
			RevitParametersModel parametersModel = this.ParametersModel;
			\u0014\u0014\u0018.\u000A(parametersModel, \u0020\u000B\u000E.\u001F(\u000F\u001E\u000A.\u000A(\u0013\u0014\u0018.\u0007(parametersModel), new ParameterBaseModel<BaseParameter>.CollectionChangedDelegate(this.SetStatus))));
			\u0017\u0014\u0018.\u000A(this);
			\u0016\u0002\u0019.\u000A(parent, new EventHandler(this.NVR));
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\AnnotationCategoryModel.cs", ".ctor");
		}

		// Token: 0x06001366 RID: 4966 RVA: 0x0007BD44 File Offset: 0x00079F44
		private void NVR(object F, EventArgs R)
		{
			ObservableCollection<ICategoryModel> observableCollection = \u0015\u0014\u0018.\u000A(this.AU.U);
			List<ICategoryModel> u000A;
			if (observableCollection == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AnnotationCategoryModel.NVR(object, EventArgs)).MethodHandle;
				}
				u000A = \u0014\u000B\u000E.\u001F;
			}
			else
			{
				u000A = Enumerable.ToList<ICategoryModel>(observableCollection);
			}
			\u000C\u0014\u0018.\u000A(this, u000A);
		}

		// Token: 0x06001367 RID: 4967 RVA: 0x0007BD90 File Offset: 0x00079F90
		[BindableMethod("CategorySelectionChanged")]
		public void CategorySelectionChanged()
		{
			\u0001\u0014\u0018.\u000A(this, \u0015\u0014\u0018.\u000A(this.AU.U));
		}

		// Token: 0x17000597 RID: 1431
		// (get) Token: 0x06001368 RID: 4968 RVA: 0x0007BDB8 File Offset: 0x00079FB8
		public CommandBase<ProfileUserControl> ProfileChangedCommand
		{
			get
			{
				return \u0009\u0014\u0018.\u000A(new Action<ProfileUserControl>(this.ProfileChanged), \u0015\u000B\u000E.\u001F);
			}
		}

		// Token: 0x06001369 RID: 4969 RVA: 0x0007BDE0 File Offset: 0x00079FE0
		public void ProfileChanged(ProfileUserControl profileControl)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\AnnotationCategoryModel.cs", "ProfileChanged");
			\u0005\u0013\u0018.\u000A(this);
			TemplateInfo templateInfo = \u000C\u000B\u000E.\u001F(\u0018\u0013\u0018.\u0007(profileControl));
			\u0019\u0013\u0018.\u000A(this, 1);
			\u001D\u0013\u0018.\u000A(this, \u0004\u0013\u0018.\u000A(templateInfo));
			\u000A\u0013\u0018.\u000A(this, \u0007\u0013\u0018.\u000A(templateInfo));
			this.MVR(\u001F\u0013\u0018.\u0007(profileControl), templateInfo);
			this.AU.U.M();
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\AnnotationCategoryModel.cs", "ProfileChanged");
		}

		// Token: 0x0600136A RID: 4970 RVA: 0x0007BE74 File Offset: 0x0007A074
		private void MVR(Profile F, TemplateInfo R)
		{
			ObservableCollection<ICategoryModel> observableCollection = \u0015\u0014\u0018.\u000A(this.AU.U);
			if (observableCollection == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AnnotationCategoryModel.MVR(Profile, TemplateInfo)).MethodHandle;
				}
			}
			else
			{
				\u001F\u001A\u0018.\u0007(observableCollection);
			}
			List<ProfileReport> list = \u0009\u0013\u0018.\u000A();
			List<long>.Enumerator enumerator = \u0015\u0013\u0018.\u000A(\u0001\u0013\u0018.\u000A(R));
			try
			{
				while (\u0017\u0013\u0018.\u000A(ref enumerator))
				{
					AnnotationCategoryModel.\u0017\u0012 u0017_u = new AnnotationCategoryModel.\u0017\u0012();
					u0017_u.\u001F = (int)\u000C\u0013\u0018.\u000A(ref enumerator);
					ICategoryModel categoryModel = Enumerable.FirstOrDefault<ICategoryModel>(\u001A\u0013\u0018.\u000A(this), new Func<ICategoryModel, bool>(u0017_u.\u000A));
					if (categoryModel != null)
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
						\u0013\u0013\u0018.\u000A(categoryModel, true);
						\u0014\u0013\u0018.\u000A(\u0015\u0014\u0018.\u000A(this.AU.U), categoryModel);
					}
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
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u0001\u0014\u0018.\u000A(this, \u0015\u0014\u0018.\u000A(this.AU.U));
			List<RevitParameter> list2 = Enumerable.ToList<RevitParameter>(Enumerable.Cast<RevitParameter>(\u000E\u0013\u0018.\u0007(this.ParametersModel)));
			List<ParamExportInfo>.Enumerator enumerator2 = \u001E\u0013\u0018.\u000A(\u0020\u0013\u0018.\u000A(R));
			try
			{
				while (\u000B\u0013\u0018.\u000A(ref enumerator2))
				{
					AnnotationCategoryModel.\u0014\u0012 u0014_u = new AnnotationCategoryModel.\u0014\u0012();
					u0014_u.\u001F = \u0011\u0013\u0018.\u000A(ref enumerator2);
					AnnotationCategoryModel.\u0013\u0012 u0013_u = new AnnotationCategoryModel.\u0013\u0012();
					AnnotationCategoryModel.\u0013\u0012 u0013_u2 = u0013_u;
					IEnumerable<BaseParameter> enumerable = Enumerable.Where<BaseParameter>(\u000E\u0013\u0018.\u0007(this.ParametersModel), new Func<BaseParameter, bool>(u0014_u.\u000A));
					Func<BaseParameter, string> func;
					if ((func = AnnotationCategoryModel.<>c.\u000A) == null)
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
						func = (AnnotationCategoryModel.<>c.\u000A = new Func<BaseParameter, string>(AnnotationCategoryModel.<>c.\u001F.\u0005));
					}
					u0013_u2.\u001F = Enumerable.ToList<string>(Enumerable.Select<BaseParameter, string>(enumerable, func));
					u0013_u.\u000A = Enumerable.FirstOrDefault<RevitParameter>(list2, new Func<RevitParameter, bool>(u0013_u.\u0007));
					if (u0013_u.\u000A != null)
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
						if (Enumerable.FirstOrDefault<BaseParameter>(\u001B\u0013\u0018.\u000A(this.ParametersModel), new Func<BaseParameter, bool>(u0013_u.\u001D)) == null)
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
							\u0008\u0013\u0018.\u000A(\u001B\u0013\u0018.\u000A(this.ParametersModel), u0013_u.\u000A);
							\u0010\u0013\u0018.\u000A(\u000E\u0013\u0018.\u0007(this.ParametersModel), u0013_u.\u000A);
						}
						else
						{
							ProfileReport profileReport = \u000D\u0013\u0018.\u000A();
							\u001C\u0013\u0018.\u000A(profileReport, \u0014\u0004\u0018.\u0007(u0014_u.\u001F));
							\u0020\u0014\u0007.\u000A(profileReport, ReportStates.Error);
							\u0006\u0013\u0018.\u000A(profileReport, \u000F\u0013\u0018.\u000A(\u0003\u0013\u0018.\u000A(), \u0014\u0004\u0018.\u0007(u0014_u.\u001F), \u0012\u0013\u0018.\u000A(F)));
							\u0002\u0013\u0018.\u000A(list, profileReport);
						}
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
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			\u0017\u0014\u0018.\u000A(this);
			\u0016\u0013\u0018.\u000A(this, list);
		}

		// Token: 0x0600136B RID: 4971 RVA: 0x0007C174 File Offset: 0x0007A374
		[BindableMethod("AddProfile")]
		public void AddProfile(ProfileUserControl profileControl)
		{
			this.VVR(profileControl);
		}

		// Token: 0x0600136C RID: 4972 RVA: 0x0007C188 File Offset: 0x0007A388
		[BindableMethod("SaveProfile")]
		public void SaveProfile(ProfileUserControl profileControl)
		{
			this.VVR(profileControl);
		}

		// Token: 0x0600136D RID: 4973 RVA: 0x0007C19C File Offset: 0x0007A39C
		private void VVR(ProfileUserControl F)
		{
			AnnotationCategoryModel.\u0020\u0012 u0020_u = new AnnotationCategoryModel.\u0020\u0012();
			u0020_u.\u001F = this;
			TemplateInfo templateInfo = \u0016\u001A\u0018.\u000A();
			AnnotationCategoryModel.\u0020\u0012 u0020_u2 = u0020_u;
			ObservableCollection<ICategoryModel> observableCollection = \u0015\u0014\u0018.\u000A(this.AU.U);
			List<CategoryCollection> u000A;
			if (observableCollection == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AnnotationCategoryModel.VVR(ProfileUserControl)).MethodHandle;
				}
				u000A = \u0013\u000B\u000E.\u001F;
			}
			else
			{
				u000A = Enumerable.ToList<CategoryCollection>(Enumerable.Cast<CategoryCollection>(observableCollection));
			}
			u0020_u2.\u000A = u000A;
			object u001F = templateInfo;
			List<CategoryCollection> u000A2 = u0020_u.\u000A;
			List<long> u000A3;
			if (u000A2 == null)
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
				u000A3 = \u001A\u000B\u000E.\u001F;
			}
			else
			{
				Func<CategoryCollection, long> func;
				if ((func = AnnotationCategoryModel.<>c.\u0007) == null)
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
					func = (AnnotationCategoryModel.<>c.\u0007 = new Func<CategoryCollection, long>(AnnotationCategoryModel.<>c.\u001F.\u0016));
				}
				u000A3 = Enumerable.ToList<long>(Enumerable.Select<CategoryCollection, long>(u000A2, func));
			}
			\u0005\u001A\u0018.\u0007(u001F, u000A3);
			\u0018\u001A\u0018.\u0007(templateInfo, Enumerable.ToList<ParamExportInfo>(Enumerable.Select<BaseParameter, ParamExportInfo>(\u001B\u0013\u0018.\u000A(this.ParametersModel), new Func<BaseParameter, ParamExportInfo>(u0020_u.\u0007))));
			\u0004\u001A\u0018.\u000A(templateInfo, \u0019\u001A\u0018.\u000A(this));
			\u0007\u001A\u0018.\u000A(templateInfo, \u001D\u001A\u0018.\u000A(this));
			\u000A\u001A\u0018.\u0007(F, templateInfo);
		}

		// Token: 0x0600136E RID: 4974 RVA: 0x0007C2AC File Offset: 0x0007A4AC
		public override void SetStatus()
		{
			List<BaseParameter> list = \u0006\u001A\u0018.\u000A(this.ParametersModel);
			bool u000A;
			if (list == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AnnotationCategoryModel.SetStatus()).MethodHandle;
				}
				u000A = false;
			}
			else
			{
				u000A = (\u0002\u001A\u0018.\u000A(list) > 0);
			}
			\u001C\u001A\u0018.\u000A(this, u000A);
			string[] array = \u001B\u001F\u000E.\u001F(7);
			array[0] = \u0003\u001A\u0018.\u000A();
			int num = 1;
			string u001F = " {0} ";
			ObservableCollection<ICategoryModel> observableCollection = \u001A\u0013\u0018.\u000A(this);
			int? num2;
			int? num3;
			if (observableCollection == null)
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
				\u000B\u0007\u000E.\u001F(ref num2);
				num3 = num2;
			}
			else
			{
				Func<ICategoryModel, bool> func;
				if ((func = AnnotationCategoryModel.<>c.\u001D) == null)
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
					func = (AnnotationCategoryModel.<>c.\u001D = new Func<ICategoryModel, bool>(AnnotationCategoryModel.<>c.\u001F.\u000B));
				}
				num3 = new int?(Enumerable.Count<ICategoryModel>(observableCollection, func));
			}
			array[num] = \u0017\u0006\u0007.\u000A(u001F, num3);
			array[2] = "| ";
			array[3] = \u001C\u0013\u0019.\u000A();
			array[4] = \u0017\u0006\u0007.\u000A(" {0} | ", \u0012\u001A\u0018.\u0007(\u000E\u0013\u0018.\u0007(this.ParametersModel)));
			array[5] = \u000F\u001A\u0018.\u000A();
			int num4 = 6;
			string u001F2 = " {0}";
			List<BaseParameter> list2 = \u0006\u001A\u0018.\u000A(this.ParametersModel);
			int? num5;
			if (list2 == null)
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
				\u000B\u0007\u000E.\u001F(ref num2);
				num5 = num2;
			}
			else
			{
				num5 = new int?(\u0002\u001A\u0018.\u000A(list2));
			}
			array[num4] = \u0017\u0006\u0007.\u000A(u001F2, num5);
			\u000B\u001A\u0018.\u000A(this, \u0014\u0006\u001D.\u000A(array));
		}

		// Token: 0x0600136F RID: 4975 RVA: 0x0007C404 File Offset: 0x0007A604
		public override void ExportToExcel(IExportOption exportOption)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\AnnotationCategoryModel.cs", "ExportToExcel");
			if (\u0015\u0014\u0018.\u000A(this.AU.U) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AnnotationCategoryModel.ExportToExcel(IExportOption)).MethodHandle;
				}
				List<ICategoryModel> list = Enumerable.ToList<ICategoryModel>(\u0015\u0014\u0018.\u000A(this.AU.U));
				\u0010\u001A\u0018.\u000A(exportOption, \u0004\u000F.\u0018(\u000E\u001A\u0018.\u000A(this, list), false, true));
				\u000D\u001A\u0018.\u000A(this, Enumerable.ToList<CategoryCollection>(Enumerable.Cast<CategoryCollection>(list)), exportOption);
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\AnnotationCategoryModel.cs", "ExportToExcel");
		}

		// Token: 0x06001370 RID: 4976 RVA: 0x0007C4AC File Offset: 0x0007A6AC
		public override void ExportToDrive(IExportOption exportOption)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\AnnotationCategoryModel.cs", "ExportToDrive");
			if (\u0015\u0014\u0018.\u000A(this.AU.U) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AnnotationCategoryModel.ExportToDrive(IExportOption)).MethodHandle;
				}
				List<ICategoryModel> list = Enumerable.ToList<ICategoryModel>(\u0015\u0014\u0018.\u000A(this.AU.U));
				\u001B\u001A\u0018.\u000A(exportOption, \u000E\u001A\u0018.\u000A(this, list));
				\u0008\u001A\u0018.\u000A(this, Enumerable.ToList<CategoryCollection>(Enumerable.Cast<CategoryCollection>(list)), exportOption);
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\AnnotationCategoryModel.cs", "ExportToDrive");
		}

		// Token: 0x06001371 RID: 4977 RVA: 0x0007C54C File Offset: 0x0007A74C
		public override void ExportToMorta(IExportOption exportOption)
		{
		}

		// Token: 0x06001372 RID: 4978 RVA: 0x0007C55C File Offset: 0x0007A75C
		public override void Reset()
		{
			\u001E\u001A\u0018.\u000A(this.AU.U);
			\u0011\u001A\u0018.\u000A(this.AU.J);
		}

		// Token: 0x06001373 RID: 4979 RVA: 0x0007C58C File Offset: 0x0007A78C
		public void GetData(Delegate showPreview)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\AnnotationCategoryModel.cs", "GetData");
			if (\u0015\u0014\u0018.\u000A(this.AU.U) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AnnotationCategoryModel.GetData(Delegate)).MethodHandle;
				}
				List<ICategoryModel> list = Enumerable.ToList<ICategoryModel>(\u0015\u0014\u0018.\u000A(this.AU.U));
				\u0020\u001A\u0018.\u000A(this, Enumerable.ToList<CategoryCollection>(Enumerable.Cast<CategoryCollection>(list)), showPreview, "");
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\AnnotationCategoryModel.cs", "GetData");
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x0007C624 File Offset: 0x0007A824
		public override void EnableIsolateElements()
		{
			ObservableCollection<ICategoryModel> observableCollection = \u0015\u0014\u0018.\u000A(this.AU.U);
			List<ICategoryModel> u000A;
			if (observableCollection == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AnnotationCategoryModel.EnableIsolateElements()).MethodHandle;
				}
				u000A = \u0014\u000B\u000E.\u001F;
			}
			else
			{
				u000A = Enumerable.ToList<ICategoryModel>(observableCollection);
			}
			\u000C\u0014\u0018.\u000A(this, u000A);
		}

		// Token: 0x06001375 RID: 4981 RVA: 0x0007C670 File Offset: 0x0007A870
		public override void Isolate()
		{
			View u000A = \u000F\u000B\u0004.\u0007(this.ActiveDocument);
			Window u = \u0018\u000B\u0007.\u0007(this);
			IEnumerable<ICategoryModel> enumerable = \u0015\u0014\u0018.\u000A(this.AU.U);
			Func<ICategoryModel, bool> func;
			if ((func = AnnotationCategoryModel.<>c.\u0004) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AnnotationCategoryModel.Isolate()).MethodHandle;
				}
				func = (AnnotationCategoryModel.<>c.\u0004 = new Func<ICategoryModel, bool>(AnnotationCategoryModel.<>c.\u001F.\u0002));
			}
			IEnumerable<ICategoryModel> enumerable2 = Enumerable.Where<ICategoryModel>(enumerable, func);
			Func<ICategoryModel, IEnumerable<ElementId>> func2;
			if ((func2 = AnnotationCategoryModel.<>c.\u0018) == null)
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
				func2 = (AnnotationCategoryModel.<>c.\u0018 = new Func<ICategoryModel, IEnumerable<ElementId>>(AnnotationCategoryModel.<>c.\u001F.\u0006));
			}
			\u0017\u001A\u0018.\u000A(this, u000A, u, Enumerable.ToList<ElementId>(Enumerable.SelectMany<ICategoryModel, ElementId>(enumerable2, func2)));
		}

		// Token: 0x06001376 RID: 4982 RVA: 0x0007C71C File Offset: 0x0007A91C
		public override void SectionBox()
		{
		}

		// Token: 0x06001377 RID: 4983 RVA: 0x0007C72C File Offset: 0x0007A92C
		public override void CustomDispose()
		{
			RevitParametersModel parametersModel = this.ParametersModel;
			\u0014\u0014\u0018.\u000A(parametersModel, \u0020\u000B\u000E.\u001F(\u0012\u001E\u000A.\u000A(\u0013\u0014\u0018.\u0007(parametersModel), new ParameterBaseModel<BaseParameter>.CollectionChangedDelegate(this.SetStatus))));
			\u0013\u001A\u0018.\u000A(\u0018\u000B\u0007.\u0007(this), new EventHandler(this.NVR));
			this.AU = \u0017\u000B\u000E.\u001F;
			\u0014\u001A\u0018.\u0007(this);
		}

		// Token: 0x040007AB RID: 1963
		private AnnotationCategories AU;

		// Token: 0x020008BC RID: 2236
		[CompilerGenerated]
		private sealed class \u0020\u0012
		{
			// Token: 0x06005022 RID: 20514 RVA: 0x001E66E0 File Offset: 0x001E48E0
			internal ParamExportInfo \u0007(BaseParameter \u001F)
			{
				return ParamExportInfo.\u001D(\u0015\u001A\u0018.\u000A(this.\u001F), \u0018\u0012\u000E.\u001F(\u001F), this.\u000A);
			}

			// Token: 0x040022BA RID: 8890
			public AnnotationCategoryModel \u001F;

			// Token: 0x040022BB RID: 8891
			public List<CategoryCollection> \u000A;
		}

		// Token: 0x020008BD RID: 2237
		[CompilerGenerated]
		private sealed class \u0017\u0012
		{
			// Token: 0x06005024 RID: 20516 RVA: 0x001E6724 File Offset: 0x001E4924
			internal bool \u000A(ICategoryModel \u001F)
			{
				return \u0017\u001C\u0018.\u000A(\u001F) == (long)this.\u001F;
			}

			// Token: 0x040022BC RID: 8892
			public int \u001F;
		}

		// Token: 0x020008BE RID: 2238
		[CompilerGenerated]
		private sealed class \u0014\u0012
		{
			// Token: 0x06005026 RID: 20518 RVA: 0x001E6758 File Offset: 0x001E4958
			internal bool \u000A(BaseParameter \u001F)
			{
				return \u0010\u0016\u0010.\u000A(\u0018\u0012\u000E.\u001F(\u001F), this.\u001F);
			}

			// Token: 0x040022BD RID: 8893
			public ParamExportInfo \u001F;
		}

		// Token: 0x020008BF RID: 2239
		[CompilerGenerated]
		private sealed class \u0013\u0012
		{
			// Token: 0x06005028 RID: 20520 RVA: 0x001E6790 File Offset: 0x001E4990
			internal bool \u0007(RevitParameter \u001F)
			{
				return \u001F\u0020\u001D.\u000A(this.\u001F, \u000F\u0020\u0018.\u0007(\u001F));
			}

			// Token: 0x06005029 RID: 20521 RVA: 0x001E67B4 File Offset: 0x001E49B4
			internal bool \u001D(BaseParameter \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u000F\u0020\u0018.\u0007(\u001F), \u000F\u0020\u0018.\u0007(this.\u000A));
			}

			// Token: 0x040022BE RID: 8894
			public List<string> \u001F;

			// Token: 0x040022BF RID: 8895
			public RevitParameter \u000A;
		}
	}
}
