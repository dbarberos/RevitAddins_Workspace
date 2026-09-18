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
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;
using DiRoots.One.SheetLink.Profile;
using DiRoots.One.SheetLink.UI.Controls;
using DiRoots.One.SheetLink.UI.Windows;
using DiRoots.One.UIBehaviours.Extensions;

namespace DiRoots.One.SheetLink.ViewModels
{
	// Token: 0x02000210 RID: 528
	public sealed class ElementsWindowModel : CategoryBaseModel
	{
		// Token: 0x060013B7 RID: 5047 RVA: 0x0007DF54 File Offset: 0x0007C154
		public ElementsWindowModel(UIDocument uidoc, Window parent, ElementsWindow userControl) : base(uidoc, parent, ElementsWindowModel.AVR())
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\ElementsWindowModel.cs", ".ctor");
			this.AU = userControl;
			this.ParametersModel = \u001A\u0014\u0018.\u0007(this.AU.N);
			RevitParametersModel parametersModel = this.ParametersModel;
			\u0014\u0014\u0018.\u000A(parametersModel, \u0020\u000B\u000E.\u001F(\u000F\u001E\u000A.\u000A(\u0013\u0014\u0018.\u0007(parametersModel), new ParameterBaseModel<BaseParameter>.CollectionChangedDelegate(this.SetStatus))));
			\u0016\u0002\u0019.\u000A(parent, new EventHandler(this.NVR));
			ElementNavigator k = userControl.K;
			\u0012\u0015\u0018.\u000A(k, (ElementNavigator.ContextMenuDelegate)\u000F\u001E\u000A.\u000A(\u0003\u0015\u0018.\u0007(k), new ElementNavigator.ContextMenuDelegate(this.OVR)));
			\u0017\u0014\u0018.\u000A(this);
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\ElementsWindowModel.cs", ".ctor");
		}

		// Token: 0x060013B8 RID: 5048 RVA: 0x0007E02C File Offset: 0x0007C22C
		private void NVR(object F, EventArgs R)
		{
			ObservableCollection<ICategoryModel> observableCollection = \u001C\u0015\u0018.\u000A(this);
			List<ICategoryModel> u000A;
			if (observableCollection == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindowModel.NVR(object, EventArgs)).MethodHandle;
				}
				u000A = \u0014\u000B\u000E.\u001F;
			}
			else
			{
				u000A = Enumerable.ToList<ICategoryModel>(observableCollection);
			}
			\u000C\u0014\u0018.\u000A(this, u000A);
		}

		// Token: 0x170005AA RID: 1450
		// (get) Token: 0x060013B9 RID: 5049 RVA: 0x0007E06C File Offset: 0x0007C26C
		// (set) Token: 0x060013BA RID: 5050 RVA: 0x0007E080 File Offset: 0x0007C280
		public ObservableCollection<ICategoryModel> Elements
		{
			get
			{
				return this.LW;
			}
			set
			{
				this.LW = value;
				\u000D\u0020\u000A.\u000A(this, "Elements");
			}
		}

		// Token: 0x060013BB RID: 5051 RVA: 0x0007E0A0 File Offset: 0x0007C2A0
		[BindableMethod("CategorySelectionChanged")]
		public void CategorySelectionChanged()
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\ElementsWindowModel.cs", "CategorySelectionChanged");
			ElementsWindow au = this.AU;
			bool flag;
			if (au == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindowModel.CategorySelectionChanged()).MethodHandle;
				}
				flag = (null != null);
			}
			else
			{
				ItemNavigator w = au.W;
				if (w == null)
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
					flag = (null != null);
				}
				else
				{
					flag = (\u000D\u0015\u0018.\u001D(w) != null);
				}
			}
			if (flag)
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
				ElementsWindow au2 = this.AU;
				List<string> list;
				if (au2 == null)
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
					list = \u001F\u000B\u000E.\u001F;
				}
				else
				{
					ElementNavigator k = au2.K;
					if (k == null)
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
						list = \u001F\u000B\u000E.\u001F;
					}
					else
					{
						ObservableCollection<ICategoryModel> observableCollection = \u000E\u0015\u0018.\u0007(k);
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
							list = \u001F\u000B\u000E.\u001F;
						}
						else
						{
							Func<ICategoryModel, string> func;
							if ((func = ElementsWindowModel.<>c.\u000A) == null)
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
								func = (ElementsWindowModel.<>c.\u000A = new Func<ICategoryModel, string>(ElementsWindowModel.<>c.\u001F.\u0020));
							}
							list = Enumerable.ToList<string>(Enumerable.Select<ICategoryModel, string>(observableCollection, func));
						}
					}
				}
				List<string> list2 = list;
				ObservableCollection<BaseParameter> observableCollection2 = \u001B\u0013\u0018.\u000A(this.ParametersModel);
				List<long> sw;
				if (observableCollection2 == null)
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
					sw = \u001A\u000B\u000E.\u001F;
				}
				else
				{
					Func<BaseParameter, long> func2;
					if ((func2 = ElementsWindowModel.<>c.\u0007) == null)
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
						func2 = (ElementsWindowModel.<>c.\u0007 = new Func<BaseParameter, long>(ElementsWindowModel.<>c.\u001F.\u0017));
					}
					sw = Enumerable.ToList<long>(Enumerable.Select<BaseParameter, long>(observableCollection2, func2));
				}
				this.SW = sw;
				\u0010\u0015\u0018.\u000A(this.AU.K);
				\u0011\u001A\u0018.\u000A(this.AU.N);
				this.IU = Enumerable.ToList<ICategoryModel>(\u000D\u0015\u0018.\u0007(this.AU.W));
				this.TVR(Enumerable.ToList<CategoryCollection>(Enumerable.Cast<CategoryCollection>(this.IU)));
				if (list2 != null)
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
					List<string>.Enumerator enumerator = \u0013\u0008\u0007.\u000A(list2);
					try
					{
						while (\u0017\u0008\u0007.\u000A(ref enumerator))
						{
							ElementsWindowModel.\u0004\u0003 u0004_u = new ElementsWindowModel.\u0004\u0003();
							u0004_u.\u001F = \u0014\u0008\u0007.\u000A(ref enumerator);
							ICategoryModel categoryModel = Enumerable.FirstOrDefault<ICategoryModel>(\u001C\u0015\u0018.\u000A(this), new Func<ICategoryModel, bool>(u0004_u.\u000A));
							if (categoryModel != null)
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
								\u0013\u0013\u0018.\u000A(categoryModel, true);
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
					finally
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				\u0017\u0014\u0018.\u000A(this);
				ObservableCollection<ICategoryModel> observableCollection3 = \u001C\u0015\u0018.\u000A(this);
				List<ICategoryModel> u000A;
				if (observableCollection3 == null)
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
					u000A = \u0014\u000B\u000E.\u001F;
				}
				else
				{
					u000A = Enumerable.ToList<ICategoryModel>(observableCollection3);
				}
				\u000C\u0014\u0018.\u000A(this, u000A);
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\ElementsWindowModel.cs", "CategorySelectionChanged");
		}

		// Token: 0x060013BC RID: 5052 RVA: 0x0007E32C File Offset: 0x0007C52C
		[BindableMethod("ElementsSelectionChanged")]
		public void ElementsSelectionChanged()
		{
			ElementsWindow au = this.AU;
			bool flag;
			if (au == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindowModel.ElementsSelectionChanged()).MethodHandle;
				}
				flag = (null != null);
			}
			else
			{
				ElementNavigator k = au.K;
				if (k == null)
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
					flag = (null != null);
				}
				else
				{
					flag = (\u000E\u0015\u0018.\u0007(k) != null);
				}
			}
			if (flag)
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
				List<CategoryCollection> list = Enumerable.ToList<CategoryCollection>(Enumerable.Cast<CategoryCollection>(Enumerable.ToList<ICategoryModel>(\u000E\u0015\u0018.\u001D(this.AU.K))));
				\u0011\u000C\u0018.\u000A(\u001B\u0014\u0019.\u0007(\u0015\u001A\u0018.\u000A(this)));
				if (\u0020\u0014\u0018.\u000A(list) > 0)
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
					ProgressWindow u001F = \u0008\u000C\u0018.\u000A(\u001B\u000C\u0018.\u000A(\u0011\u0020\u000A.\u0007(this.ActiveDocument), \u0015\u001A\u0018.\u000A(this), list));
					\u0015\u000D\u001D.\u000A(u001F, \u0018\u000B\u0007.\u0007(this));
					\u0018\u0020\u000A.\u0007(u001F);
				}
				if (this.SW == null)
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
					this.SW = \u001F\u001B\u0019.\u000A();
				}
				\u000E\u000C\u0018.\u000A(this.ParametersModel, \u0018\u0014\u0019.\u000A(Enumerable.Where<RevitParameter>(\u001B\u0014\u0019.\u0007(\u0015\u001A\u0018.\u000A(this)), new Func<RevitParameter, bool>(this.GVR))));
				List<RevitParameter> u001F2 = \u000D\u000E\u0018.\u000A();
				\u000D\u0020\u0018.\u000A(u001F2, Enumerable.Where<RevitParameter>(\u001B\u0014\u0019.\u0007(\u0015\u001A\u0018.\u000A(this)), new Func<RevitParameter, bool>(this.FZR)));
				\u0010\u000C\u0018.\u000A(this.ParametersModel, \u0018\u0014\u0019.\u000A(u001F2));
				\u000E\u000A\u001D.\u000A(this.SW);
				\u0017\u0014\u0018.\u000A(this);
				ObservableCollection<ICategoryModel> observableCollection = \u001C\u0015\u0018.\u000A(this);
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
					u000A = \u0014\u000B\u000E.\u001F;
				}
				else
				{
					u000A = Enumerable.ToList<ICategoryModel>(observableCollection);
				}
				\u000C\u0014\u0018.\u000A(this, u000A);
			}
		}

		// Token: 0x170005AB RID: 1451
		// (get) Token: 0x060013BD RID: 5053 RVA: 0x0007E4E4 File Offset: 0x0007C6E4
		public CommandBase<ProfileUserControl> ProfileChangedCommand
		{
			get
			{
				return \u0009\u0014\u0018.\u000A(new Action<ProfileUserControl>(this.ProfileChanged), \u0015\u000B\u000E.\u001F);
			}
		}

		// Token: 0x060013BE RID: 5054 RVA: 0x0007E50C File Offset: 0x0007C70C
		public void ProfileChanged(ProfileUserControl profileControl)
		{
			\u0005\u0013\u0018.\u000A(this);
			TemplateInfo templateInfo = \u000C\u000B\u000E.\u001F(\u0018\u0013\u0018.\u0007(profileControl));
			\u0019\u0013\u0018.\u000A(this, 1);
			\u001D\u0013\u0018.\u000A(this, \u0004\u0013\u0018.\u000A(templateInfo));
			\u000A\u0013\u0018.\u000A(this, \u0007\u0013\u0018.\u000A(templateInfo));
			this.MVR(\u001F\u0013\u0018.\u0007(profileControl), templateInfo);
			this.AU.K.M();
		}

		// Token: 0x060013BF RID: 5055 RVA: 0x0007E574 File Offset: 0x0007C774
		private void MVR(Profile F, TemplateInfo R)
		{
			ElementsWindowModel.\u0001\u0012 u0001_u = new ElementsWindowModel.\u0001\u0012();
			u0001_u.\u001F = R;
			ObservableCollection<ICategoryModel> observableCollection = \u000E\u0015\u0018.\u001D(this.AU.K);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindowModel.MVR(Profile, TemplateInfo)).MethodHandle;
				}
			}
			else
			{
				\u001F\u001A\u0018.\u0007(observableCollection);
			}
			List<ProfileReport> list = \u0009\u0013\u0018.\u000A();
			object u001F = Enumerable.ToList<ICategoryModel>(\u0008\u0015\u0018.\u0007(this.AU.W));
			Action<ICategoryModel> u000A;
			if ((u000A = ElementsWindowModel.<>c.\u001D) == null)
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
				u000A = (ElementsWindowModel.<>c.\u001D = new Action<ICategoryModel>(ElementsWindowModel.<>c.\u001F.\u0014));
			}
			\u001B\u0015\u0018.\u000A(u001F, u000A);
			ICategoryModel categoryModel = Enumerable.FirstOrDefault<ICategoryModel>(\u0008\u0015\u0018.\u0007(this.AU.W), new Func<ICategoryModel, bool>(u0001_u.\u000A));
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
				\u001F\u001A\u0018.\u001D(\u000D\u0015\u0018.\u0007(this.AU.W));
				\u0014\u0013\u0018.\u000A(\u000D\u0015\u0018.\u0007(this.AU.W), categoryModel);
				\u001F\u000C\u0018.\u001D(this);
				List<long>.Enumerator enumerator = \u0015\u0013\u0018.\u000A(\u0001\u0013\u0018.\u000A(u0001_u.\u001F));
				try
				{
					while (\u0017\u0013\u0018.\u000A(ref enumerator))
					{
						ElementsWindowModel.\u0009\u0012 u0009_u = new ElementsWindowModel.\u0009\u0012();
						u0009_u.\u001F = (int)\u000C\u0013\u0018.\u000A(ref enumerator);
						ICategoryModel categoryModel2 = Enumerable.FirstOrDefault<ICategoryModel>(\u001C\u0015\u0018.\u000A(this), new Func<ICategoryModel, bool>(u0009_u.\u000A));
						if (categoryModel2 != null)
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
							\u0013\u0013\u0018.\u000A(categoryModel2, true);
							\u0014\u0013\u0018.\u000A(\u000E\u0015\u0018.\u001D(this.AU.K), categoryModel2);
						}
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
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				\u0001\u0014\u0018.\u000A(this, \u000E\u0015\u0018.\u001D(this.AU.K));
				List<RevitParameter> list2 = Enumerable.ToList<RevitParameter>(Enumerable.Cast<RevitParameter>(\u000E\u0013\u0018.\u0007(this.ParametersModel)));
				List<ParamExportInfo>.Enumerator enumerator2 = \u001E\u0013\u0018.\u000A(\u0020\u0013\u0018.\u000A(u0001_u.\u001F));
				try
				{
					while (\u000B\u0013\u0018.\u000A(ref enumerator2))
					{
						ElementsWindowModel.\u001F\u0003 u001F_u = new ElementsWindowModel.\u001F\u0003();
						u001F_u.\u001F = \u0011\u0013\u0018.\u000A(ref enumerator2);
						ElementsWindowModel.\u000A\u0003 u000A_u = new ElementsWindowModel.\u000A\u0003();
						ElementsWindowModel.\u000A\u0003 u000A_u2 = u000A_u;
						IEnumerable<BaseParameter> enumerable = Enumerable.Where<BaseParameter>(\u000E\u0013\u0018.\u0007(this.ParametersModel), new Func<BaseParameter, bool>(u001F_u.\u000A));
						Func<BaseParameter, string> func;
						if ((func = ElementsWindowModel.<>c.\u0004) == null)
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
							func = (ElementsWindowModel.<>c.\u0004 = new Func<BaseParameter, string>(ElementsWindowModel.<>c.\u001F.\u0013));
						}
						u000A_u2.\u001F = Enumerable.ToList<string>(Enumerable.Select<BaseParameter, string>(enumerable, func));
						u000A_u.\u000A = Enumerable.FirstOrDefault<RevitParameter>(list2, new Func<RevitParameter, bool>(u000A_u.\u0007));
						if (u000A_u.\u000A != null)
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
							if (Enumerable.FirstOrDefault<BaseParameter>(\u001B\u0013\u0018.\u000A(this.ParametersModel), new Func<BaseParameter, bool>(u000A_u.\u001D)) == null)
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
								\u0008\u0013\u0018.\u000A(\u001B\u0013\u0018.\u000A(this.ParametersModel), u000A_u.\u000A);
								\u0010\u0013\u0018.\u000A(\u000E\u0013\u0018.\u0007(this.ParametersModel), u000A_u.\u000A);
							}
						}
						else
						{
							ProfileReport profileReport = \u000D\u0013\u0018.\u000A();
							\u001C\u0013\u0018.\u000A(profileReport, \u0014\u0004\u0018.\u0007(u001F_u.\u001F));
							\u0020\u0014\u0007.\u000A(profileReport, ReportStates.Error);
							\u0006\u0013\u0018.\u000A(profileReport, \u000F\u0013\u0018.\u000A(\u0003\u0013\u0018.\u000A(), \u0014\u0004\u0018.\u0007(u001F_u.\u001F), \u0012\u0013\u0018.\u000A(F)));
							\u0002\u0013\u0018.\u000A(list, profileReport);
						}
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
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			\u0017\u0014\u0018.\u000A(this);
			\u0016\u0013\u0018.\u000A(this, list);
		}

		// Token: 0x060013C0 RID: 5056 RVA: 0x0007E948 File Offset: 0x0007CB48
		[BindableMethod("AddProfile")]
		public void AddProfile(ProfileUserControl profileControl)
		{
			this.VVR(profileControl);
		}

		// Token: 0x060013C1 RID: 5057 RVA: 0x0007E95C File Offset: 0x0007CB5C
		[BindableMethod("SaveProfile")]
		public void SaveProfile(ProfileUserControl profileControl)
		{
			this.VVR(profileControl);
		}

		// Token: 0x060013C2 RID: 5058 RVA: 0x0007E970 File Offset: 0x0007CB70
		private void VVR(ProfileUserControl F)
		{
			ElementsWindowModel.\u0007\u0003 u0007_u = new ElementsWindowModel.\u0007\u0003();
			u0007_u.\u001F = this;
			TemplateInfo templateInfo = \u0016\u001A\u0018.\u000A();
			if (this.IU != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindowModel.VVR(ProfileUserControl)).MethodHandle;
				}
				\u0011\u0015\u0018.\u000A(templateInfo, \u0017\u001C\u0018.\u000A(\u0002\u0015\u0018.\u000A(this.IU, 0)));
				ElementsWindowModel.\u0007\u0003 u0007_u2 = u0007_u;
				ObservableCollection<ICategoryModel> observableCollection = \u000E\u0015\u0018.\u001D(this.AU.K);
				List<CategoryCollection> u000A;
				if (observableCollection == null)
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
					u000A = \u0013\u000B\u000E.\u001F;
				}
				else
				{
					u000A = Enumerable.ToList<CategoryCollection>(Enumerable.Cast<CategoryCollection>(observableCollection));
				}
				u0007_u2.\u000A = u000A;
				object u001F = templateInfo;
				List<CategoryCollection> u000A2 = u0007_u.\u000A;
				List<long> u000A3;
				if (u000A2 == null)
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
					u000A3 = \u001A\u000B\u000E.\u001F;
				}
				else
				{
					Func<CategoryCollection, long> func;
					if ((func = ElementsWindowModel.<>c.\u0019) == null)
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
						func = (ElementsWindowModel.<>c.\u0019 = new Func<CategoryCollection, long>(ElementsWindowModel.<>c.\u001F.\u001A));
					}
					u000A3 = Enumerable.ToList<long>(Enumerable.Select<CategoryCollection, long>(u000A2, func));
				}
				\u0005\u001A\u0018.\u0007(u001F, u000A3);
				\u0018\u001A\u0018.\u0007(templateInfo, Enumerable.ToList<ParamExportInfo>(Enumerable.Select<BaseParameter, ParamExportInfo>(\u001B\u0013\u0018.\u000A(this.ParametersModel), new Func<BaseParameter, ParamExportInfo>(u0007_u.\u0007))));
				\u0004\u001A\u0018.\u000A(templateInfo, \u0019\u001A\u0018.\u000A(this));
				\u0007\u001A\u0018.\u000A(templateInfo, \u001D\u001A\u0018.\u000A(this));
			}
			\u000A\u001A\u0018.\u0007(F, templateInfo);
		}

		// Token: 0x060013C3 RID: 5059 RVA: 0x0007EAB0 File Offset: 0x0007CCB0
		private void OVR(List<ICategoryModel> F, MenuContext R)
		{
			List<ElementId> list = \u001C\u0013\u000A.\u000A();
			object u001F = list;
			Func<ICategoryModel, IEnumerable<ElementId>> func;
			if ((func = ElementsWindowModel.<>c.\u0005) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindowModel.OVR(List<ICategoryModel>, MenuContext)).MethodHandle;
				}
				func = (ElementsWindowModel.<>c.\u0005 = new Func<ICategoryModel, IEnumerable<ElementId>>(ElementsWindowModel.<>c.\u001F.\u000C));
			}
			\u000F\u0013\u000A.\u000A(u001F, Enumerable.SelectMany<ICategoryModel, ElementId>(F, func));
			try
			{
				if (\u001A\u0014\u000A.\u000A(list) > 0)
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
					if (R == MenuContext.Select)
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
						\u0020\u0015\u0018.\u000A(this, list);
					}
					else if (R == MenuContext.Show)
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
						\u001E\u0015\u0018.\u000A(this, list);
					}
					else if (R == MenuContext.Isolate)
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
						\u0017\u000D.\u000B\u000A(\u000F\u000B\u0004.\u0007(this.ActiveDocument), \u0018\u000B\u0007.\u0007(this), list);
						\u0019\u0015\u0018.\u000A(this, true);
					}
					else if (R == MenuContext.Unisolate)
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
						\u0017\u000D.\u0002\u000A(\u000F\u000B\u0004.\u0007(this.ActiveDocument));
						\u0019\u0015\u0018.\u000A(this, false);
					}
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\ElementsWindowModel.cs", "ContextMenuHandler");
			}
		}

		// Token: 0x060013C4 RID: 5060 RVA: 0x0007EBD0 File Offset: 0x0007CDD0
		public void SelectElements(List<ElementId> elementIds)
		{
			\u000D\u001E\u000A.\u000A(\u0010\u001E\u000A.\u0007(this.ActiveDocument), elementIds);
		}

		// Token: 0x060013C5 RID: 5061 RVA: 0x0007EBF0 File Offset: 0x0007CDF0
		public void ShowElements(List<ElementId> elementIds)
		{
			\u000D\u001E\u000A.\u000A(\u0010\u001E\u000A.\u0007(this.ActiveDocument), elementIds);
			\u000E\u0013\u000A.\u000A(this.ActiveDocument, elementIds);
		}

		// Token: 0x060013C6 RID: 5062 RVA: 0x0007EC1C File Offset: 0x0007CE1C
		private void TVR(List<CategoryCollection> F)
		{
			\u0017\u0015\u0018.\u000A(this, \u0007\u000C\u0018.\u000A(this.IVR(F)));
		}

		// Token: 0x060013C7 RID: 5063 RVA: 0x0007EC40 File Offset: 0x0007CE40
		public override void SetStatus()
		{
			List<BaseParameter> list = \u0006\u001A\u0018.\u000A(this.ParametersModel);
			bool u000A;
			if (list == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindowModel.SetStatus()).MethodHandle;
				}
				u000A = false;
			}
			else
			{
				u000A = (\u0002\u001A\u0018.\u000A(list) > 0);
			}
			\u001C\u001A\u0018.\u000A(this, u000A);
			if (this.IU != null)
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
				if (\u0006\u0015\u0018.\u000A(this.IU) > 0)
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
					string u001F = \u0013\u0015\u0018.\u000A();
					object[] array = \u0004\u0015\u0010.\u001F(4);
					int num = 0;
					ObservableCollection<ICategoryModel> observableCollection = \u001C\u0015\u0018.\u000A(this);
					int? num2;
					int? num3;
					if (observableCollection == null)
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
						\u000B\u0007\u000E.\u001F(ref num2);
						num3 = num2;
					}
					else
					{
						Func<ICategoryModel, bool> func;
						if ((func = ElementsWindowModel.<>c.\u0016) == null)
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
							func = (ElementsWindowModel.<>c.\u0016 = new Func<ICategoryModel, bool>(ElementsWindowModel.<>c.\u001F.\u0001));
						}
						num3 = new int?(Enumerable.Count<ICategoryModel>(observableCollection, func));
					}
					array[num] = num3;
					array[1] = \u000B\u0015\u0018.\u000A(\u0002\u0015\u0018.\u000A(this.IU, 0));
					array[2] = \u0012\u001A\u0018.\u0007(\u000E\u0013\u0018.\u0007(this.ParametersModel));
					int num4 = 3;
					List<BaseParameter> list2 = \u0006\u001A\u0018.\u000A(this.ParametersModel);
					int? num5;
					if (list2 == null)
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
						\u000B\u0007\u000E.\u001F(ref num2);
						num5 = num2;
					}
					else
					{
						num5 = new int?(\u0002\u001A\u0018.\u000A(list2));
					}
					array[num4] = num5;
					\u000B\u001A\u0018.\u000A(this, \u001C\u0015\u001D.\u000A(u001F, array));
					return;
				}
			}
			\u000B\u001A\u0018.\u000A(this, \u001E\u0007\u0007.\u000A(\u0014\u0015\u0018.\u000A(), 0, 0, 0));
		}

		// Token: 0x060013C8 RID: 5064 RVA: 0x0007EDC4 File Offset: 0x0007CFC4
		private List<CategoryCollection> IVR(List<CategoryCollection> F)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\ElementsWindowModel.cs", "GetCategoryAsTypes");
			List<CategoryCollection> list = \u0017\u0017\u0019.\u000A();
			List<Element> list2 = \u0016\u0016\u0004.\u000A();
			List<CategoryCollection>.Enumerator enumerator = \u0014\u0016\u0018.\u000A(F);
			try
			{
				while (\u001E\u0016\u0018.\u000A(ref enumerator))
				{
					CategoryCollection u001F = \u0017\u0016\u0018.\u000A(ref enumerator);
					\u0018\u0016\u0004.\u000A(list2, \u0008\u0013\u0019.\u000A(u001F));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindowModel.IVR(List<CategoryCollection>)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			IEnumerable<Element> enumerable = list2;
			Func<Element, long> func;
			if ((func = ElementsWindowModel.<>c.\u000B) == null)
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
				func = (ElementsWindowModel.<>c.\u000B = new Func<Element, long>(ElementsWindowModel.<>c.\u001F.\u0009));
			}
			IEnumerable<IGrouping<long, Element>> enumerable2 = Enumerable.GroupBy<Element, long>(enumerable, func);
			Func<IGrouping<long, Element>, long> func2;
			if ((func2 = ElementsWindowModel.<>c.\u0002) == null)
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
				func2 = (ElementsWindowModel.<>c.\u0002 = new Func<IGrouping<long, Element>, long>(ElementsWindowModel.<>c.\u001F.\u001F\u000A));
			}
			Func<IGrouping<long, Element>, List<Element>> func3;
			if ((func3 = ElementsWindowModel.<>c.\u0006) == null)
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
				func3 = (ElementsWindowModel.<>c.\u0006 = new Func<IGrouping<long, Element>, List<Element>>(ElementsWindowModel.<>c.\u001F.\u000A\u000A));
			}
			IEnumerable<KeyValuePair<long, List<Element>>> enumerable3 = Enumerable.ToDictionary<IGrouping<long, Element>, long, List<Element>>(enumerable2, func2, func3);
			Func<KeyValuePair<long, List<Element>>, IEnumerable<Element>> func4;
			if ((func4 = ElementsWindowModel.<>c.\u000F) == null)
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
				func4 = (ElementsWindowModel.<>c.\u000F = new Func<KeyValuePair<long, List<Element>>, IEnumerable<Element>>(ElementsWindowModel.<>c.\u001F.\u0007\u000A));
			}
			IEnumerable<IGrouping<string, Element>> enumerable4 = Enumerable.GroupBy<Element, string>(Enumerable.ToList<Element>(Enumerable.SelectMany<KeyValuePair<long, List<Element>>, Element>(enumerable3, func4)), new Func<Element, string>(this.QVR));
			Func<IGrouping<string, Element>, string> func5;
			if ((func5 = ElementsWindowModel.<>c.\u0012) == null)
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
				func5 = (ElementsWindowModel.<>c.\u0012 = new Func<IGrouping<string, Element>, string>(ElementsWindowModel.<>c.\u001F.\u001D\u000A));
			}
			Func<IGrouping<string, Element>, List<Element>> func6;
			if ((func6 = ElementsWindowModel.<>c.\u0003) == null)
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
				func6 = (ElementsWindowModel.<>c.\u0003 = new Func<IGrouping<string, Element>, List<Element>>(ElementsWindowModel.<>c.\u001F.\u0004\u000A));
			}
			Dictionary<string, List<Element>>.Enumerator enumerator2 = \u0008\u0017\u000A.\u000A(Enumerable.ToDictionary<IGrouping<string, Element>, string, List<Element>>(enumerable4, func5, func6));
			try
			{
				while (\u001C\u0017\u000A.\u000A(ref enumerator2))
				{
					KeyValuePair<string, List<Element>> keyValuePair = \u000E\u0017\u000A.\u000A(ref enumerator2);
					Element u001F2 = Enumerable.First<Element>(\u000D\u0017\u000A.\u000A(ref keyValuePair));
					CategoryCollection categoryCollection = \u001A\u0017\u0019.\u000A();
					\u0013\u0017\u0019.\u0007(categoryCollection, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F2)));
					\u0015\u0015\u0018.\u0007(categoryCollection, \u0010\u0017\u000A.\u000A(ref keyValuePair));
					\u0014\u0017\u0019.\u0007(categoryCollection, \u001F\u000B\u000E.\u001F);
					\u001B\u0013\u0019.\u000A(categoryCollection, false);
					\u000C\u0015\u0018.\u0007(categoryCollection, \u0008\u0019\u0007.\u000A(u001F2));
					\u0011\u0017\u0019.\u0007(categoryCollection, \u001A\u0015\u0018.\u000A(\u000D\u0017\u000A.\u000A(ref keyValuePair)));
					CategoryCollection u000A = categoryCollection;
					\u0020\u0017\u0019.\u000A(list, u000A);
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
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\ElementsWindowModel.cs", "GetCategoryAsTypes");
			IEnumerable<CategoryCollection> enumerable5 = list;
			Func<CategoryCollection, string> func7;
			if ((func7 = ElementsWindowModel.<>c.\u001C) == null)
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
				func7 = (ElementsWindowModel.<>c.\u001C = new Func<CategoryCollection, string>(ElementsWindowModel.<>c.\u001F.\u0019\u000A));
			}
			return Enumerable.ToList<CategoryCollection>(Enumerable.OrderBy<CategoryCollection, string>(enumerable5, func7));
		}

		// Token: 0x060013C9 RID: 5065 RVA: 0x0007F0A0 File Offset: 0x0007D2A0
		private string QVR(Element F)
		{
			string text = \u0005\u001E\u000A.\u000A(F);
			FamilyInstance familyInstance = \u000D\u000B\u000E.\u001F(F);
			if (familyInstance != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindowModel.QVR(Element)).MethodHandle;
				}
				if (!\u001A\u0006\u0007.\u000A(\u0001\u0015\u0018.\u0007(\u001C\u001B\u0018.\u001D(familyInstance))))
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
					if (\u001D\u0017\u000A.\u000A(\u0003\u000B\u001D.\u0007(\u0001\u0015\u0018.\u0007(\u001C\u001B\u0018.\u001D(familyInstance))), \u0003\u000B\u001D.\u0007(text)))
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
						text = \u0002\u0013\u000A.\u000A(\u0001\u0015\u0018.\u0007(\u001C\u001B\u0018.\u001D(familyInstance)), ":", \u0005\u001E\u000A.\u000A(\u001C\u001B\u0018.\u001D(familyInstance)));
					}
				}
			}
			else
			{
				if (\u000D\u0003\u0018.\u0007(F) != null)
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
					if (\u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u000D\u0003\u0018.\u0007(F))) == -2000220L)
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
						Element element = \u0011\u0017\u000A.\u0007(\u0008\u0019\u0007.\u000A(F), \u0004\u0013\u0007.\u000A(F));
						if (element == null)
						{
							return text;
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
						string text2 = \u0001\u0015\u0018.\u0007(\u000B\u0002\u000E.\u001F(element));
						string text3 = \u0005\u001E\u000A.\u000A(element);
						if (!\u001A\u0006\u0007.\u000A(text2))
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
							return text2;
						}
						if (!\u001A\u0006\u0007.\u000A(text3))
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
							return text3;
						}
						return text;
					}
				}
				if (\u000D\u0003\u0018.\u0007(F) != null)
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
					if (\u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u000D\u0003\u0018.\u0007(F))) == -2000279L)
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
						return \u001C\u001C\u0007.\u0007(\u0004\u0019\u000E.\u001F(F)).ToString();
					}
				}
				if (\u000D\u0003\u0018.\u0007(F) != null)
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
					if (\u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u000D\u0003\u0018.\u0007(F))) == -2000700L)
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
						return \u0009\u0015\u0018.\u000A(\u0002\u0002\u000E.\u001F(F));
					}
				}
				Element element2 = \u0011\u0017\u000A.\u0007(\u0008\u0019\u0007.\u000A(F), \u0004\u0013\u0007.\u000A(F));
				if (element2 != null)
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
					string u001F = \u0001\u0015\u0018.\u0007(\u000B\u0002\u000E.\u001F(element2));
					string text4 = \u0005\u001E\u000A.\u000A(element2);
					if (!\u001A\u0006\u0007.\u000A(u001F))
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
						if (\u001D\u0017\u000A.\u000A(\u0003\u000B\u001D.\u0007(u001F), \u0003\u000B\u001D.\u0007(text4)))
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
							return \u0002\u0013\u000A.\u000A(u001F, ":", text4);
						}
					}
					if (!\u001A\u0006\u0007.\u000A(text4))
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
						if (\u001D\u0017\u000A.\u000A(\u0003\u000B\u001D.\u0007(text4), \u0003\u000B\u001D.\u0007(text)))
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
							text = \u0002\u0013\u000A.\u000A(text4, ":", \u0005\u001E\u000A.\u000A(F));
						}
					}
				}
				else if (\u001A\u0006\u0007.\u000A(text))
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
					if (\u000D\u0003\u0018.\u0007(F) != null)
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
						text = \u0009\u0014\u000A.\u001D(\u000D\u0003\u0018.\u0007(F));
					}
				}
			}
			return text;
		}

		// Token: 0x060013CA RID: 5066 RVA: 0x0007F3F8 File Offset: 0x0007D5F8
		public override void ExportToExcel(IExportOption exportOption)
		{
			if (\u000E\u0015\u0018.\u001D(this.AU.K) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindowModel.ExportToExcel(IExportOption)).MethodHandle;
				}
				List<ICategoryModel> list = Enumerable.ToList<ICategoryModel>(\u000E\u0015\u0018.\u001D(this.AU.K));
				\u0010\u001A\u0018.\u000A(exportOption, \u0004\u000F.\u0018(\u000E\u001A\u0018.\u000A(this, list), false, true));
				\u000D\u001A\u0018.\u000A(this, Enumerable.ToList<CategoryCollection>(Enumerable.Cast<CategoryCollection>(list)), exportOption);
			}
		}

		// Token: 0x060013CB RID: 5067 RVA: 0x0007F474 File Offset: 0x0007D674
		public override void ExportToDrive(IExportOption exportOption)
		{
			if (\u000E\u0015\u0018.\u001D(this.AU.K) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindowModel.ExportToDrive(IExportOption)).MethodHandle;
				}
				List<ICategoryModel> list = Enumerable.ToList<ICategoryModel>(\u000E\u0015\u0018.\u001D(this.AU.K));
				\u001B\u001A\u0018.\u000A(exportOption, \u000E\u001A\u0018.\u000A(this, list));
				\u0008\u001A\u0018.\u000A(this, Enumerable.ToList<CategoryCollection>(Enumerable.Cast<CategoryCollection>(list)), exportOption);
			}
		}

		// Token: 0x060013CC RID: 5068 RVA: 0x0007F4E8 File Offset: 0x0007D6E8
		public override void ExportToMorta(IExportOption exportOption)
		{
		}

		// Token: 0x060013CD RID: 5069 RVA: 0x0007F4F8 File Offset: 0x0007D6F8
		public override void Reset()
		{
			\u001F\u0001\u0018.\u000A(this.AU.W);
			\u0010\u0015\u0018.\u000A(this.AU.K);
			\u0011\u001A\u0018.\u000A(this.AU.N);
		}

		// Token: 0x060013CE RID: 5070 RVA: 0x0007F538 File Offset: 0x0007D738
		public void GetData(Delegate showPreview)
		{
			if (\u000E\u0015\u0018.\u001D(this.AU.K) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindowModel.GetData(Delegate)).MethodHandle;
				}
				List<ICategoryModel> list = Enumerable.ToList<ICategoryModel>(\u000E\u0015\u0018.\u001D(this.AU.K));
				\u0020\u001A\u0018.\u000A(this, Enumerable.ToList<CategoryCollection>(Enumerable.Cast<CategoryCollection>(list)), showPreview, "");
			}
		}

		// Token: 0x060013CF RID: 5071 RVA: 0x0007F5A4 File Offset: 0x0007D7A4
		public override void EnableIsolateElements()
		{
			ObservableCollection<ICategoryModel> observableCollection = \u001C\u0015\u0018.\u000A(this);
			List<ICategoryModel> u000A;
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindowModel.EnableIsolateElements()).MethodHandle;
				}
				u000A = \u0014\u000B\u000E.\u001F;
			}
			else
			{
				u000A = Enumerable.ToList<ICategoryModel>(observableCollection);
			}
			\u000C\u0014\u0018.\u000A(this, u000A);
		}

		// Token: 0x060013D0 RID: 5072 RVA: 0x0007F5E4 File Offset: 0x0007D7E4
		public override void Isolate()
		{
			View u000A = \u000F\u000B\u0004.\u0007(this.ActiveDocument);
			Window u = \u0018\u000B\u0007.\u0007(this);
			IEnumerable<ICategoryModel> enumerable = \u001C\u0015\u0018.\u000A(this);
			Func<ICategoryModel, bool> func;
			if ((func = ElementsWindowModel.<>c.\u000D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindowModel.Isolate()).MethodHandle;
				}
				func = (ElementsWindowModel.<>c.\u000D = new Func<ICategoryModel, bool>(ElementsWindowModel.<>c.\u001F.\u0018\u000A));
			}
			IEnumerable<ICategoryModel> enumerable2 = Enumerable.Where<ICategoryModel>(enumerable, func);
			Func<ICategoryModel, IEnumerable<ElementId>> func2;
			if ((func2 = ElementsWindowModel.<>c.\u000E) == null)
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
				func2 = (ElementsWindowModel.<>c.\u000E = new Func<ICategoryModel, IEnumerable<ElementId>>(ElementsWindowModel.<>c.\u001F.\u0005\u000A));
			}
			\u0017\u001A\u0018.\u000A(this, u000A, u, Enumerable.ToList<ElementId>(Enumerable.SelectMany<ICategoryModel, ElementId>(enumerable2, func2)));
		}

		// Token: 0x060013D1 RID: 5073 RVA: 0x0007F684 File Offset: 0x0007D884
		public override void SectionBox()
		{
			IEnumerable<ICategoryModel> enumerable = \u001C\u0015\u0018.\u000A(this);
			Func<ICategoryModel, bool> func;
			if ((func = ElementsWindowModel.<>c.\u0008) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindowModel.SectionBox()).MethodHandle;
				}
				func = (ElementsWindowModel.<>c.\u0008 = new Func<ICategoryModel, bool>(ElementsWindowModel.<>c.\u001F.\u000B\u000A));
			}
			IEnumerable<ICategoryModel> enumerable2 = Enumerable.Where<ICategoryModel>(enumerable, func);
			Func<ICategoryModel, IEnumerable<Element>> func2;
			if ((func2 = ElementsWindowModel.<>c.\u0011) == null)
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
				func2 = (ElementsWindowModel.<>c.\u0011 = new Func<ICategoryModel, IEnumerable<Element>>(ElementsWindowModel.<>c.\u001F.\u0002\u000A));
			}
			\u000A\u0001\u0018.\u000A(this, Enumerable.ToList<Element>(Enumerable.SelectMany<ICategoryModel, Element>(enumerable2, func2)));
		}

		// Token: 0x060013D2 RID: 5074 RVA: 0x0007F710 File Offset: 0x0007D910
		private static List<CategoryCollection> AVR()
		{
			ElementsWindowModel.\u001D\u0003 u001D_u = new ElementsWindowModel.\u001D\u0003();
			u001D_u.\u001F = \u001F\u001B\u0019.\u000A();
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2009630L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2009633L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2009636L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2009639L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2009643L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2009641L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2009657L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2009645L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2008185L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2008090L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2009642L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2009640L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2003200L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2008037L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2001370L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2001100L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2000220L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, (long)\u0007\u0001\u0018.\u000A());
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2000240L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2003400L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2000095L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2000560L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2000160L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2003100L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2000996L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2008101L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2003600L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2000279L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2001260L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2000301L);
			\u0001\u000E\u0019.\u000A(u001D_u.\u001F, -2000530L);
			List<CategoryCollection> list = \u0017\u0017\u0019.\u000A();
			\u0011\u0020\u0018.\u000A(list, \u0014\u0014\u0019.\u000A());
			\u0011\u0020\u0018.\u000A(list, \u0009\u001B\u0018.\u000A());
			Func<CategoryCollection, string> func;
			if ((func = ElementsWindowModel.<>c.\u001E) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindowModel.AVR()).MethodHandle;
				}
				func = (ElementsWindowModel.<>c.\u001E = new Func<CategoryCollection, string>(ElementsWindowModel.<>c.\u001F.\u000F\u000A));
			}
			return Enumerable.ToList<CategoryCollection>(Enumerable.Where<CategoryCollection>(Enumerable.ToList<CategoryCollection>(Enumerable.OrderBy<CategoryCollection, string>(list, func)), new Func<CategoryCollection, bool>(u001D_u.\u000A)));
		}

		// Token: 0x060013D3 RID: 5075 RVA: 0x0007F9BC File Offset: 0x0007DBBC
		public override void CustomDispose()
		{
			RevitParametersModel parametersModel = this.ParametersModel;
			\u0014\u0014\u0018.\u000A(parametersModel, \u0020\u000B\u000E.\u001F(\u0012\u001E\u000A.\u000A(\u0013\u0014\u0018.\u0007(parametersModel), new ParameterBaseModel<BaseParameter>.CollectionChangedDelegate(this.SetStatus))));
			\u0013\u001A\u0018.\u000A(\u0018\u000B\u0007.\u0007(this), new EventHandler(this.NVR));
			this.AU = \u0016\u0002\u000E.\u001F;
			\u0014\u001A\u0018.\u0007(this);
		}

		// Token: 0x060013D4 RID: 5076 RVA: 0x0007FA24 File Offset: 0x0007DC24
		[CompilerGenerated]
		private bool GVR(RevitParameter F)
		{
			return !\u001A\u0008\u0019.\u000A(this.SW, \u0017\u000B\u0018.\u0007(F));
		}

		// Token: 0x060013D5 RID: 5077 RVA: 0x0007FA4C File Offset: 0x0007DC4C
		[CompilerGenerated]
		private bool FZR(RevitParameter F)
		{
			return \u001A\u0008\u0019.\u000A(this.SW, \u0017\u000B\u0018.\u0007(F));
		}

		// Token: 0x040007BA RID: 1978
		private ElementsWindow AU;

		// Token: 0x040007BB RID: 1979
		private ObservableCollection<ICategoryModel> LW;

		// Token: 0x040007BC RID: 1980
		private List<ICategoryModel> IU;

		// Token: 0x040007BD RID: 1981
		private List<long> SW;

		// Token: 0x020008C5 RID: 2245
		[CompilerGenerated]
		private sealed class \u0001\u0012
		{
			// Token: 0x06005057 RID: 20567 RVA: 0x001E6D00 File Offset: 0x001E4F00
			internal bool \u000A(ICategoryModel \u001F)
			{
				return \u0017\u001C\u0018.\u000A(\u001F) == \u001B\u0016\u0010.\u000A(this.\u001F);
			}

			// Token: 0x040022E5 RID: 8933
			public TemplateInfo \u001F;
		}

		// Token: 0x020008C6 RID: 2246
		[CompilerGenerated]
		private sealed class \u0009\u0012
		{
			// Token: 0x06005059 RID: 20569 RVA: 0x001E6D38 File Offset: 0x001E4F38
			internal bool \u000A(ICategoryModel \u001F)
			{
				return \u0017\u001C\u0018.\u000A(\u001F) == (long)this.\u001F;
			}

			// Token: 0x040022E6 RID: 8934
			public int \u001F;
		}

		// Token: 0x020008C7 RID: 2247
		[CompilerGenerated]
		private sealed class \u001F\u0003
		{
			// Token: 0x0600505B RID: 20571 RVA: 0x001E6D6C File Offset: 0x001E4F6C
			internal bool \u000A(BaseParameter \u001F)
			{
				return \u0010\u0016\u0010.\u000A(\u0018\u0012\u000E.\u001F(\u001F), this.\u001F);
			}

			// Token: 0x040022E7 RID: 8935
			public ParamExportInfo \u001F;
		}

		// Token: 0x020008C8 RID: 2248
		[CompilerGenerated]
		private sealed class \u000A\u0003
		{
			// Token: 0x0600505D RID: 20573 RVA: 0x001E6DA4 File Offset: 0x001E4FA4
			internal bool \u0007(RevitParameter \u001F)
			{
				return \u001F\u0020\u001D.\u000A(this.\u001F, \u000F\u0020\u0018.\u0007(\u001F));
			}

			// Token: 0x0600505E RID: 20574 RVA: 0x001E6DC8 File Offset: 0x001E4FC8
			internal bool \u001D(BaseParameter \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u000F\u0020\u0018.\u0007(\u001F), \u000F\u0020\u0018.\u0007(this.\u000A));
			}

			// Token: 0x040022E8 RID: 8936
			public List<string> \u001F;

			// Token: 0x040022E9 RID: 8937
			public RevitParameter \u000A;
		}

		// Token: 0x020008C9 RID: 2249
		[CompilerGenerated]
		private sealed class \u0007\u0003
		{
			// Token: 0x06005060 RID: 20576 RVA: 0x001E6E08 File Offset: 0x001E5008
			internal ParamExportInfo \u0007(BaseParameter \u001F)
			{
				return ParamExportInfo.\u001D(\u0015\u001A\u0018.\u000A(this.\u001F), \u0018\u0012\u000E.\u001F(\u001F), this.\u000A);
			}

			// Token: 0x040022EA RID: 8938
			public ElementsWindowModel \u001F;

			// Token: 0x040022EB RID: 8939
			public List<CategoryCollection> \u000A;
		}

		// Token: 0x020008CA RID: 2250
		[CompilerGenerated]
		private sealed class \u001D\u0003
		{
			// Token: 0x06005062 RID: 20578 RVA: 0x001E6E4C File Offset: 0x001E504C
			internal bool \u000A(CategoryCollection \u001F)
			{
				return !\u001A\u0008\u0019.\u000A(this.\u001F, \u0013\u000E\u0018.\u0007(\u001F));
			}

			// Token: 0x040022EC RID: 8940
			public List<long> \u001F;
		}

		// Token: 0x020008CB RID: 2251
		[CompilerGenerated]
		private sealed class \u0004\u0003
		{
			// Token: 0x06005064 RID: 20580 RVA: 0x001E6E88 File Offset: 0x001E5088
			internal bool \u000A(ICategoryModel \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u000B\u0015\u0018.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x040022ED RID: 8941
			public string \u001F;
		}
	}
}
