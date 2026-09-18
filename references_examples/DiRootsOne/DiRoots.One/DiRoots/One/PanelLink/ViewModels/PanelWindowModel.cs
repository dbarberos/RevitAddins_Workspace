using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Excel;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.Services;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.PanelLink.Models;
using DiRoots.One.PanelLink.UI.Controls;
using DiRoots.One.PanelLink.UI.Windows;
using DiRoots.One.SheetLink.Core;
using DiRoots.One.SheetLink.Models;
using DiRoots.One.SheetLink.UI.Controls;
using DiRoots.One.SheetLink.UI.Windows;
using DiRoots.One.UIBehaviours.Extensions;

namespace DiRoots.One.PanelLink.ViewModels
{
	// Token: 0x02000198 RID: 408
	public class PanelWindowModel : ViewModelBase
	{
		// Token: 0x06000F05 RID: 3845 RVA: 0x0005F8FC File Offset: 0x0005DAFC
		public PanelWindowModel(UIDocument uidoc, PanelWindow parent)
		{
			this.XB = uidoc;
			\u000A\u000C\u0007.\u001D(this, parent);
			this.VB = parent.RH;
			this.ZB = parent.DH;
			\u001D\u0014\u0019.\u000A(this, new ObservableCollection<Panel>(\u0014\u0002.\u001F(\u0011\u0020\u000A.\u0007(uidoc), \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u000F\u000B\u0004.\u0007(uidoc))))));
			if (\u000A\u0014\u0019.\u000A(\u0007\u0014\u0019.\u000A(this)) != 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelWindowModel..ctor(UIDocument, PanelWindow)).MethodHandle;
				}
				this.MB = \u000E\u0002.\u0004(\u0011\u0020\u000A.\u0007(uidoc), \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u000F\u000B\u0004.\u0007(uidoc))));
			}
			PanelControl zb = this.ZB;
			\u0009\u0017\u0019.\u000A(zb, (PanelControl.ContextMenuDelegate)\u000F\u001E\u000A.\u000A(\u001F\u0014\u0019.\u0007(zb), new PanelControl.ContextMenuDelegate(this.OpenView)));
			\u0001\u0017\u0019.\u000A(this);
		}

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06000F06 RID: 3846 RVA: 0x0005F9E8 File Offset: 0x0005DBE8
		// (set) Token: 0x06000F07 RID: 3847 RVA: 0x0005F9FC File Offset: 0x0005DBFC
		public ObservableCollection<Panel> PanelItems { get; set; }

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06000F08 RID: 3848 RVA: 0x0005FA10 File Offset: 0x0005DC10
		// (set) Token: 0x06000F09 RID: 3849 RVA: 0x0005FA24 File Offset: 0x0005DC24
		public string StatusText
		{
			get
			{
				return this.PB;
			}
			set
			{
				this.PB = value;
				\u000D\u0020\u000A.\u000A(this, "StatusText");
			}
		}

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06000F0A RID: 3850 RVA: 0x0005FA44 File Offset: 0x0005DC44
		// (set) Token: 0x06000F0B RID: 3851 RVA: 0x0005FA58 File Offset: 0x0005DC58
		public bool IsExportable
		{
			get
			{
				return this.OB;
			}
			set
			{
				this.OB = value;
				\u000D\u0020\u000A.\u000A(this, "IsExportable");
			}
		}

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06000F0C RID: 3852 RVA: 0x0005FA78 File Offset: 0x0005DC78
		public CommandBase ExportCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.OnExportClicked), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x06000F0D RID: 3853 RVA: 0x0005FAA0 File Offset: 0x0005DCA0
		public CommandBase ImportExcelCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.OnImportExcelClicked), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x06000F0E RID: 3854 RVA: 0x0005FAC8 File Offset: 0x0005DCC8
		public CommandBase ImportFromGoogleDriveCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.OnImportFromGoogleDriveCommand), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x06000F0F RID: 3855 RVA: 0x0005FAF0 File Offset: 0x0005DCF0
		public CommandBase ResetCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.OnResetClicked), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x06000F10 RID: 3856 RVA: 0x0005FB18 File Offset: 0x0005DD18
		[BindableMethod("OnSelectionChanged")]
		public void OnSelectionChanged()
		{
			this.VMR();
			\u0001\u0017\u0019.\u000A(this);
		}

		// Token: 0x06000F11 RID: 3857 RVA: 0x0005FB34 File Offset: 0x0005DD34
		public void OpenView(string viewName)
		{
			if (!\u0004\u0010.\u0004(this.XB, 123, viewName))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelWindowModel.OpenView(string)).MethodHandle;
				}
				\u000F\u0005\u0019.\u000A(\u0004\u0014\u0019.\u000A(), \u0018\u000B\u0007.\u0007(this), MessageBoxButtons.OK);
			}
		}

		// Token: 0x06000F12 RID: 3858 RVA: 0x0005FB80 File Offset: 0x0005DD80
		private void VMR()
		{
			List<Element> list = \u0016\u0016\u0004.\u000A();
			try
			{
				IEnumerator<Panel> enumerator = \u000B\u0014\u0019.\u000A(\u0007\u0014\u0019.\u000A(this));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						Panel u001F = \u0016\u0014\u0019.\u000A(enumerator);
						if (\u0005\u0014\u0019.\u000A(u001F))
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(PanelWindowModel.VMR()).MethodHandle;
							}
							\u000C\u0017\u0019.\u000A(list, \u0016\u0011\u0019.\u000A(u001F));
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
					if (enumerator != null)
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
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
				this.NB = this.ZMR(this.MB, list);
				List<PanelParameter> u001F2 = \u0012\u001B\u0019.\u0007(this.NB);
				List<PanelParameter> u001F3 = \u0003\u001B\u0019.\u0007(this.NB);
				\u0019\u0014\u0019.\u000A(this.ZB.U, \u0018\u0014\u0019.\u000A(u001F3));
				\u0019\u0014\u0019.\u000A(this.ZB.W, \u0018\u0014\u0019.\u000A(u001F2));
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\ViewModels\\PanelWindowModel.cs", "SetParameters");
			}
		}

		// Token: 0x06000F13 RID: 3859 RVA: 0x0005FCA4 File Offset: 0x0005DEA4
		private PanelParameters ZMR(List<PanelParameters> F, List<Element> R)
		{
			List<PanelParameter> list = \u0007\u0011\u0019.\u000A();
			List<PanelParameter> list2 = \u0007\u0011\u0019.\u000A();
			List<ElementId> list3 = \u001C\u0013\u000A.\u000A();
			List<Element>.Enumerator enumerator = \u0001\u0010\u0007.\u000A(R);
			try
			{
				while (\u000C\u0010\u0007.\u000A(ref enumerator))
				{
					PanelScheduleView u001F = \u000C\u0005\u000E.\u001F(\u0015\u0010\u0007.\u000A(ref enumerator));
					\u0003\u0010\u0007.\u000A(list3, \u0005\u0011\u0019.\u000A(u001F));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelWindowModel.ZMR(List<PanelParameters>, List<Element>)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			list3 = Enumerable.ToList<ElementId>(Enumerable.Distinct<ElementId>(list3));
			List<PanelParameters>.Enumerator enumerator2 = \u001C\u0014\u0019.\u000A(F);
			try
			{
				while (\u0006\u0014\u0019.\u000A(ref enumerator2))
				{
					PanelParameters u001F2 = \u0003\u0014\u0019.\u000A(ref enumerator2);
					if (\u0014\u000E\u0007.\u000A(list3, \u0012\u0014\u0019.\u000A(u001F2)))
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
						\u000F\u0014\u0019.\u000A(list, \u0003\u001B\u0019.\u0007(u001F2));
						\u000F\u0014\u0019.\u000A(list2, \u0012\u001B\u0019.\u0007(u001F2));
					}
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
				((IDisposable)enumerator2).Dispose();
			}
			IEnumerable<PanelParameter> enumerable = list;
			Func<PanelParameter, long> func;
			if ((func = PanelWindowModel.<>c.\u000A) == null)
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
				func = (PanelWindowModel.<>c.\u000A = new Func<PanelParameter, long>(PanelWindowModel.<>c.\u001F.\u0008));
			}
			IEnumerable<IGrouping<long, PanelParameter>> enumerable2 = Enumerable.GroupBy<PanelParameter, long>(enumerable, func);
			Func<IGrouping<long, PanelParameter>, PanelParameter> func2;
			if ((func2 = PanelWindowModel.<>c.\u0007) == null)
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
				func2 = (PanelWindowModel.<>c.\u0007 = new Func<IGrouping<long, PanelParameter>, PanelParameter>(PanelWindowModel.<>c.\u001F.\u001B));
			}
			list = Enumerable.ToList<PanelParameter>(Enumerable.Select<IGrouping<long, PanelParameter>, PanelParameter>(enumerable2, func2));
			IEnumerable<PanelParameter> enumerable3 = list2;
			Func<PanelParameter, long> func3;
			if ((func3 = PanelWindowModel.<>c.\u001D) == null)
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
				func3 = (PanelWindowModel.<>c.\u001D = new Func<PanelParameter, long>(PanelWindowModel.<>c.\u001F.\u0011));
			}
			IEnumerable<IGrouping<long, PanelParameter>> enumerable4 = Enumerable.GroupBy<PanelParameter, long>(enumerable3, func3);
			Func<IGrouping<long, PanelParameter>, PanelParameter> func4;
			if ((func4 = PanelWindowModel.<>c.\u0004) == null)
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
				func4 = (PanelWindowModel.<>c.\u0004 = new Func<IGrouping<long, PanelParameter>, PanelParameter>(PanelWindowModel.<>c.\u001F.\u001E));
			}
			list2 = Enumerable.ToList<PanelParameter>(Enumerable.Select<IGrouping<long, PanelParameter>, PanelParameter>(enumerable4, func4));
			object u001F3 = list2;
			Comparison<PanelParameter> u000A;
			if ((u000A = PanelWindowModel.<>c.\u0019) == null)
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
				u000A = (PanelWindowModel.<>c.\u0019 = new Comparison<PanelParameter>(PanelWindowModel.<>c.\u001F.\u0020));
			}
			\u0002\u0014\u0019.\u000A(u001F3, u000A);
			object u001F4 = list;
			Comparison<PanelParameter> u000A2;
			if ((u000A2 = PanelWindowModel.<>c.\u0018) == null)
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
				u000A2 = (PanelWindowModel.<>c.\u0018 = new Comparison<PanelParameter>(PanelWindowModel.<>c.\u001F.\u0017));
			}
			\u0002\u0014\u0019.\u000A(u001F4, u000A2);
			PanelParameters panelParameters = \u0019\u0011\u0019.\u000A();
			\u000A\u0011\u0019.\u000A(panelParameters, list2);
			\u001D\u0011\u0019.\u000A(panelParameters, list);
			return panelParameters;
		}

		// Token: 0x06000F14 RID: 3860 RVA: 0x0005FF0C File Offset: 0x0005E10C
		public void OnExportClicked()
		{
			\u0019\u0013\u0019.\u000A(false);
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\ViewModels\\PanelWindowModel.cs", "OnExportClicked");
			IEnumerable<Panel> enumerable = \u0007\u0014\u0019.\u000A(this);
			Func<Panel, bool> func;
			if ((func = PanelWindowModel.<>c.\u0005) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelWindowModel.OnExportClicked()).MethodHandle;
				}
				func = (PanelWindowModel.<>c.\u0005 = new Func<Panel, bool>(PanelWindowModel.<>c.\u001F.\u0014));
			}
			IEnumerable<Panel> enumerable2 = Enumerable.Where<Panel>(enumerable, func);
			Func<Panel, Element> func2;
			if ((func2 = PanelWindowModel.<>c.\u0016) == null)
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
				func2 = (PanelWindowModel.<>c.\u0016 = new Func<Panel, Element>(PanelWindowModel.<>c.\u001F.\u0013));
			}
			List<Element> list = Enumerable.ToList<Element>(Enumerable.Select<Panel, Element>(enumerable2, func2));
			ExportOptions u001F = \u0004\u0013\u0019.\u000A(true, true, \u0019\u0016\u0004.\u0007(list) > 1);
			\u0015\u000D\u001D.\u000A(u001F, \u0018\u000B\u0007.\u0007(this));
			bool? flag = \u0018\u0020\u000A.\u0007(u001F);
			if (!\u0012\u0015\u000A.\u000A(ref flag))
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
				return;
			}
			List<string> list2 = \u0014\u000D\u0007.\u000A();
			string text = \u0004\u000F.\u0004();
			ExportOption exportOption = \u001D\u0013\u0019.\u000A(u001F);
			if (\u0007\u0013\u0019.\u000A(exportOption))
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
				if (!this.XMR(list, exportOption, ref text, list2))
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
					return;
				}
				\u000A\u0013\u0019.\u000A(\u0010\u0014\u0019.\u0007(this.VB), \u0018\u000B\u0007.\u0007(this));
				\u0009\u0014\u0019.\u000A(\u0010\u0014\u0019.\u0007(this.VB), \u0019\u0016\u0004.\u0007(list), \u0018\u000E\u0007.\u000A(\u001F\u0013\u0019.\u000A(), 1, 2));
				\u0001\u0014\u0019.\u000A(\u000A\u001E\u0019.\u000A(), list);
				\u0015\u0014\u0019.\u000A(\u000A\u001E\u0019.\u000A(), list2);
				\u000C\u0014\u0019.\u000A(\u000A\u001E\u0019.\u000A(), text);
				\u001A\u0014\u0019.\u000A(\u000A\u001E\u0019.\u000A(), exportOption);
				\u000A\u001E\u0019.\u000A().\u0007 += this.QMR;
				\u000A\u001E\u0019.\u000A().\u001D += \u0010\u0014\u0019.\u0007(this.VB).ShowProgress;
				\u0011\u001E\u000A.\u000A(\u0013\u0014\u0019.\u000A());
			}
			else
			{
				\u0015\u001C u0015_u001C = new \u0015\u001C();
				this.IMR(u0015_u001C, list);
				string u001F2 = this.XB.\u001F();
				string text2;
				if (!\u0017\u0014\u0019.\u000A(exportOption))
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
					text2 = \u001B\u0015\u001D.\u000A(text, \u0004\u001E\u000A.\u000A(u001F2, ".xlsx"));
				}
				else
				{
					text2 = \u0004\u000F.\u0018(u001F2, false, true);
				}
				string u000A = text2;
				IEnumerable<CategoryCollection> enumerable3 = \u0014\u0014\u0019.\u000A();
				Func<CategoryCollection, bool> func3;
				if ((func3 = PanelWindowModel.<>c.\u000B) == null)
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
					func3 = (PanelWindowModel.<>c.\u000B = new Func<CategoryCollection, bool>(PanelWindowModel.<>c.\u001F.\u001A));
				}
				List<CategoryCollection> list3 = Enumerable.ToList<CategoryCollection>(Enumerable.Where<CategoryCollection>(enumerable3, func3));
				CategoryCollection categoryCollection = \u001A\u0002.\u0007(\u0011\u0020\u000A.\u0007(this.XB), u0015_u001C, list);
				if (\u0019\u0016\u0004.\u0007(\u001E\u0017\u0019.\u0007(categoryCollection)) > 0)
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
					\u0020\u0017\u0019.\u000A(list3, categoryCollection);
				}
				if (!\u0017\u0014\u0019.\u000A(exportOption))
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
					\u001B\u0012.\u0005(list3);
				}
				if (\u0017\u0014\u0019.\u000A(exportOption))
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
					if (!\u0020\u0003.\u001F(list3, \u0018\u000B\u0007.\u0007(this), ref u000A))
					{
						goto IL_39E;
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
				\u0020\u0014\u0019.\u000A(exportOption, u000A);
				\u0017\u0010 u0017_u = new \u0017\u0010();
				\u001E\u0014\u0019.\u000A(u0017_u, u0015_u001C);
				\u0011\u0014\u0019.\u000A(u0017_u, list3);
				\u0008\u0014\u0019.\u000A(u0017_u, \u001B\u0014\u0019.\u0007(u0015_u001C));
				\u000E\u0014\u0019.\u000A(u0017_u, exportOption);
				\u0017\u0010 u0017_u2 = u0017_u;
				u0017_u2.\u001F += this.TaskFinishedV2;
				\u000D\u0014\u0019.\u000A(u0017_u2, \u0010\u0014\u0019.\u0007(this.VB));
				\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u0017_u2);
				\u0020\u0005\u0019.\u000A(\u0017\u001E\u000A.\u000A());
			}
			IL_39E:
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\ViewModels\\PanelWindowModel.cs", "OnExportClicked");
		}

		// Token: 0x06000F15 RID: 3861 RVA: 0x000602D0 File Offset: 0x0005E4D0
		private unsafe bool XMR(List<Element> F, ExportOption R, ref string D, List<string> H)
		{
			bool flag = true;
			StringBuilder stringBuilder = \u001A\u0013\u0007.\u000A();
			if (\u0019\u0016\u0004.\u0007(F) > 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelWindowModel.XMR(List<Element>, ExportOption, string*, List<string>)).MethodHandle;
				}
				if (\u0017\u0014\u0019.\u000A(R))
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
					FolderDiaglogOptions u001F = \u0016\u001D\u0019.\u000A();
					\u0005\u001D\u0019.\u000A(u001F, \u0018\u000B\u0007.\u0007(this));
					string text = \u0019\u001D\u0019.\u000A(u001F, \u0010\u0011\u000A.\u000A());
					if (\u001A\u0006\u0007.\u000A(text))
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
						return false;
					}
					D = text;
				}
				List<Element>.Enumerator enumerator = \u0001\u0010\u0007.\u000A(F);
				try
				{
					while (\u000C\u0010\u0007.\u000A(ref enumerator))
					{
						Element u001F2 = \u0015\u0010\u0007.\u000A(ref enumerator);
						string text2 = \u001B\u0015\u001D.\u000A(D, \u0004\u001E\u000A.\u000A(\u0005\u001E\u000A.\u000A(u001F2), ".xlsx"));
						\u001A\u0008\u0007.\u000A(H, text2);
						flag = PanelWindowModel.PMR(text2, stringBuilder);
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
							goto IL_158;
						}
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
					goto IL_158;
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			if (\u0019\u0016\u0004.\u0007(F) == 1)
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
				string text3 = PanelWindowModel.TMR(\u0005\u001E\u000A.\u000A(\u000B\u0013\u0019.\u000A(F, 0)), ref D, R);
				if (\u001A\u0006\u0007.\u000A(D))
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
					return false;
				}
				\u001A\u0008\u0007.\u000A(H, text3);
				flag = PanelWindowModel.PMR(text3, stringBuilder);
			}
			IL_158:
			if (!flag)
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
				string u001F3 = \u0016\u0013\u0019.\u000A();
				string u000A = " ";
				StringBuilder stringBuilder2 = stringBuilder;
				string u;
				if (stringBuilder2 == null)
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
					u = \u000F\u0015\u0010.\u001F;
				}
				else
				{
					u = \u001A\u000C\u000A.\u000A(stringBuilder2);
				}
				\u0005\u0013\u0019.\u000A(\u0002\u0013\u000A.\u000A(u001F3, u000A, u), \u0018\u000B\u0007.\u0007(this), 350.0);
				\u0018\u0013\u0019.\u000A(F);
			}
			return flag;
		}

		// Token: 0x06000F16 RID: 3862 RVA: 0x000604A4 File Offset: 0x0005E6A4
		private static bool PMR(string F, StringBuilder R)
		{
			bool result = true;
			try
			{
				if (\u0010\u0002\u001D.\u000A(F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(PanelWindowModel.PMR(string, StringBuilder)).MethodHandle;
					}
					\u0007\u0001\u001D.\u000A(F);
				}
			}
			catch (Exception)
			{
				result = false;
				if (\u0008\u0015\u0004.\u000A(R) == 0)
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
					\u001E\u0013\u0007.\u000A(R, \u0004\u001E\u000A.\u000A(": ", \u0012\u0015\u001D.\u000A(F)));
				}
				else
				{
					\u001E\u0013\u0007.\u000A(R, \u0004\u001E\u000A.\u000A(", ", \u0012\u0015\u001D.\u000A(F)));
				}
			}
			return result;
		}

		// Token: 0x06000F17 RID: 3863 RVA: 0x00060540 File Offset: 0x0005E740
		private void OMR(List<string> F, bool R = false)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\ViewModels\\PanelWindowModel.cs", "ShowDriveWindow");
			DriveSelection u001F = \u0006\u0013\u0019.\u000A(\u000F\u0013\u0019.\u000A(), F, R);
			\u0015\u000D\u001D.\u000A(u001F, \u0018\u000B\u0007.\u0007(this));
			\u0018\u0020\u000A.\u0007(u001F);
			List<string>.Enumerator enumerator = \u0013\u0008\u0007.\u000A(F);
			try
			{
				while (\u0017\u0008\u0007.\u000A(ref enumerator))
				{
					\u0020\u0008\u000A.\u001F(\u0014\u0008\u0007.\u000A(ref enumerator));
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelWindowModel.OMR(List<string>, bool)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u0002\u0013\u0019.\u0007(\u0010\u0014\u0019.\u0007(this.VB));
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\ViewModels\\PanelWindowModel.cs", "ShowDriveWindow");
		}

		// Token: 0x06000F18 RID: 3864 RVA: 0x0006060C File Offset: 0x0005E80C
		private unsafe static string TMR(string F, ref string R, ExportOption D)
		{
			string text;
			if (\u0017\u0014\u0019.\u000A(D))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelWindowModel.TMR(string, string*, ExportOption)).MethodHandle;
				}
				text = \u0004\u000F.\u0018(F, false, false);
				if (\u001D\u0017\u000A.\u000A(\u001B\u0002\u001D.\u000A(text), ".xlsx"))
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
					text = \u0004\u001E\u000A.\u000A(text, ".xlsx");
				}
				if (\u001A\u0006\u0007.\u000A(text))
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
					return "";
				}
			}
			else
			{
				text = \u001B\u0015\u001D.\u000A(R, \u0004\u001E\u000A.\u000A(F, ".xlsx"));
			}
			R = text;
			return text;
		}

		// Token: 0x06000F19 RID: 3865 RVA: 0x000606AC File Offset: 0x0005E8AC
		public void OnResetClicked()
		{
			\u0012\u0013\u0019.\u000A(this.ZB);
			\u0002\u0013\u0019.\u0007(\u0010\u0014\u0019.\u0007(this.VB));
			\u0001\u0017\u0019.\u000A(this);
		}

		// Token: 0x06000F1A RID: 3866 RVA: 0x000606DC File Offset: 0x0005E8DC
		public void SetStatus()
		{
			IEnumerable<Panel> enumerable = \u0007\u0014\u0019.\u000A(this);
			Func<Panel, bool> func;
			if ((func = PanelWindowModel.<>c.\u0002) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelWindowModel.SetStatus()).MethodHandle;
				}
				func = (PanelWindowModel.<>c.\u0002 = new Func<Panel, bool>(PanelWindowModel.<>c.\u001F.\u000C));
			}
			\u000E\u0013\u0019.\u000A(this, Enumerable.Any<Panel>(enumerable, func));
			IEnumerable<Panel> enumerable2 = \u0007\u0014\u0019.\u000A(this);
			Func<Panel, bool> func2;
			if ((func2 = PanelWindowModel.<>c.\u0006) == null)
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
				func2 = (PanelWindowModel.<>c.\u0006 = new Func<Panel, bool>(PanelWindowModel.<>c.\u001F.\u0015));
			}
			if (Enumerable.Any<Panel>(enumerable2, func2))
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
				string[] array = \u001B\u001F\u000E.\u001F(5);
				array[0] = \u000D\u0013\u0019.\u000A();
				int num = 1;
				string u001F = " {0} |";
				IEnumerable<Panel> enumerable3 = \u0007\u0014\u0019.\u000A(this);
				Func<Panel, bool> func3;
				if ((func3 = PanelWindowModel.<>c.\u000F) == null)
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
					func3 = (PanelWindowModel.<>c.\u000F = new Func<Panel, bool>(PanelWindowModel.<>c.\u001F.\u0001));
				}
				array[num] = \u0017\u0006\u0007.\u000A(u001F, Enumerable.Count<Panel>(enumerable3, func3));
				array[2] = " ";
				array[3] = \u001C\u0013\u0019.\u000A();
				int num2 = 4;
				string u001F2 = " {0}";
				PanelParameters nb = this.NB;
				int? num3;
				int? num4;
				if (nb == null)
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
					\u000B\u0007\u000E.\u001F(ref num3);
					num4 = num3;
				}
				else
				{
					num4 = new int?(\u0010\u0013\u0019.\u000A(\u0012\u001B\u0019.\u001D(nb)));
				}
				int? num5 = num4;
				PanelParameters nb2 = this.NB;
				int? num6;
				if (nb2 == null)
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
					\u000B\u0007\u000E.\u001F(ref num3);
					num6 = num3;
				}
				else
				{
					num6 = new int?(\u0010\u0013\u0019.\u000A(\u0003\u001B\u0019.\u001D(nb2)));
				}
				int? num7 = num6;
				int? num8;
				if (!(\u000A\u000A\u001D.\u000A(ref num5) & \u000A\u000A\u001D.\u000A(ref num7)))
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
					\u000B\u0007\u000E.\u001F(ref num3);
					num8 = num3;
				}
				else
				{
					num8 = new int?(\u0009\u001F\u001D.\u000A(ref num5) + \u0009\u001F\u001D.\u000A(ref num7));
				}
				array[num2] = \u0017\u0006\u0007.\u000A(u001F2, num8);
				\u0003\u0013\u0019.\u000A(this, \u0014\u0006\u001D.\u000A(array));
				return;
			}
			\u0003\u0013\u0019.\u000A(this, \u001E\u0020\u001D.\u000A(\u000D\u0013\u0019.\u000A(), " 0 | ", \u001C\u0013\u0019.\u000A(), " 0"));
		}

		// Token: 0x06000F1B RID: 3867 RVA: 0x000608D4 File Offset: 0x0005EAD4
		private void IMR(\u0015\u001C F, List<Element> R)
		{
			\u000B\u0012.\u0007();
			List<CategoryCollection> list = \u0014\u0014\u0019.\u000A();
			IEnumerable<PanelParameter> enumerable = \u0012\u001B\u0019.\u0007(this.NB);
			Func<PanelParameter, long> func;
			if ((func = PanelWindowModel.<>c.\u0012) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelWindowModel.IMR(\u0015\u001C, List<Element>)).MethodHandle;
				}
				func = (PanelWindowModel.<>c.\u0012 = new Func<PanelParameter, long>(PanelWindowModel.<>c.\u001F.\u0009));
			}
			List<long> list2 = Enumerable.ToList<long>(Enumerable.Select<PanelParameter, long>(enumerable, func));
			List<string> list3 = \u0014\u000D\u0007.\u000A();
			List<Element>.Enumerator enumerator = \u0001\u0010\u0007.\u000A(R);
			try
			{
				while (\u000C\u0010\u0007.\u000A(ref enumerator))
				{
					Element u001F = \u0015\u0010\u0007.\u000A(ref enumerator);
					\u001A\u0008\u0007.\u000A(list3, \u0005\u001E\u000A.\u000A(u001F));
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
				((IDisposable)enumerator).Dispose();
			}
			IEnumerable<CategoryCollection> enumerable2 = list;
			Func<CategoryCollection, bool> func2;
			if ((func2 = PanelWindowModel.<>c.\u0003) == null)
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
				func2 = (PanelWindowModel.<>c.\u0003 = new Func<CategoryCollection, bool>(PanelWindowModel.<>c.\u001F.\u001F\u000A));
			}
			IEnumerator<CategoryCollection> enumerator2 = \u001E\u0013\u0019.\u000A(Enumerable.Where<CategoryCollection>(enumerable2, func2));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator2))
				{
					CategoryCollection categoryCollection = \u0011\u0013\u0019.\u000A(enumerator2);
					\u001B\u0013\u0019.\u000A(categoryCollection, true);
					\u0011\u0017\u0019.\u0007(categoryCollection, F.\u0005(categoryCollection, list3, list2));
					try
					{
						object u001F2 = categoryCollection;
						IEnumerable<Element> enumerable3 = \u0008\u0013\u0019.\u000A(categoryCollection);
						Func<Element, string> func3;
						if ((func3 = PanelWindowModel.<>c.\u001C) == null)
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
							func3 = (PanelWindowModel.<>c.\u001C = new Func<Element, string>(PanelWindowModel.<>c.\u001F.\u000A\u000A));
						}
						\u0011\u0017\u0019.\u0007(u001F2, Enumerable.ToList<Element>(Enumerable.OrderBy<Element, string>(enumerable3, func3)));
					}
					catch (Exception u000A)
					{
						\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\ViewModels\\PanelWindowModel.cs", "SetCollection");
					}
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
				if (enumerator2 != null)
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
					\u001F\u0017\u000A.\u000A(enumerator2);
				}
			}
			List<long> list4 = \u001F\u001B\u0019.\u000A();
			enumerator = \u0001\u0010\u0007.\u000A(R);
			try
			{
				while (\u000C\u0010\u0007.\u000A(ref enumerator))
				{
					PanelScheduleView u001F3 = \u000C\u0005\u000E.\u001F(\u0015\u0010\u0007.\u000A(ref enumerator));
					\u0001\u000E\u0019.\u000A(list4, \u000B\u001E\u000A.\u000A(\u0013\u001E\u0019.\u000A(u001F3)));
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u000E\u000A\u001D.\u000A(list2);
			object u001F4 = list2;
			IEnumerable<PanelParameter> enumerable4 = \u0003\u001B\u0019.\u0007(this.NB);
			Func<PanelParameter, long> func4;
			if ((func4 = PanelWindowModel.<>c.\u000D) == null)
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
				func4 = (PanelWindowModel.<>c.\u000D = new Func<PanelParameter, long>(PanelWindowModel.<>c.\u001F.\u0007\u000A));
			}
			\u0009\u0008\u0019.\u000A(u001F4, Enumerable.ToList<long>(Enumerable.Select<PanelParameter, long>(enumerable4, func4)));
			IEnumerable<CategoryCollection> enumerable5 = list;
			Func<CategoryCollection, bool> func5;
			if ((func5 = PanelWindowModel.<>c.\u0010) == null)
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
				func5 = (PanelWindowModel.<>c.\u0010 = new Func<CategoryCollection, bool>(PanelWindowModel.<>c.\u001F.\u001D\u000A));
			}
			enumerator2 = \u001E\u0013\u0019.\u000A(Enumerable.Where<CategoryCollection>(enumerable5, func5));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator2))
				{
					CategoryCollection categoryCollection2 = \u0011\u0013\u0019.\u000A(enumerator2);
					\u001B\u0013\u0019.\u000A(categoryCollection2, true);
					\u0011\u0017\u0019.\u0007(categoryCollection2, F.\u0005(categoryCollection2, list4, list2));
					try
					{
						object u001F5 = categoryCollection2;
						IEnumerable<Element> enumerable6 = \u0008\u0013\u0019.\u000A(categoryCollection2);
						Func<Element, string> func6;
						if ((func6 = PanelWindowModel.<>c.\u000E) == null)
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
							func6 = (PanelWindowModel.<>c.\u000E = new Func<Element, string>(PanelWindowModel.<>c.\u001F.\u0004\u000A));
						}
						\u0011\u0017\u0019.\u0007(u001F5, Enumerable.ToList<Element>(Enumerable.OrderBy<Element, string>(enumerable6, func6)));
					}
					catch (Exception u000A2)
					{
						\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\ViewModels\\PanelWindowModel.cs", "SetCollection");
					}
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
			}
			finally
			{
				if (enumerator2 != null)
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
					\u001F\u0017\u000A.\u000A(enumerator2);
				}
			}
		}

		// Token: 0x06000F1C RID: 3868 RVA: 0x00060C80 File Offset: 0x0005EE80
		private void QMR(ITaskFinishedArgs F)
		{
			ExportFilesTaskArgs u001F = \u0001\u0005\u000E.\u001F(F);
			\u000A\u001E\u0019.\u000A().\u0007 -= this.QMR;
			\u000A\u001E\u0019.\u000A().\u001D -= \u0010\u0014\u0019.\u0007(this.VB).ShowProgress;
			List<PanelData> u001F2 = \u001A\u0011\u0019.\u001D(\u000A\u001E\u0019.\u000A());
			\u0009\u0014\u0019.\u000A(\u0010\u0014\u0019.\u0007(this.VB), \u0015\u0013\u0019.\u000A(u001F2), \u0018\u000E\u0007.\u000A(\u000C\u0013\u0019.\u000A(), 2, 2));
			string u000A = \u001A\u0013\u0019.\u000A(u001F);
			\u0009\u0002.\u0007(u001F2, u000A, new Action<int>(\u0010\u0014\u0019.\u0007(this.VB).ShowProgress));
			if (\u0013\u0013\u0019.\u000A(u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelWindowModel.QMR(ITaskFinishedArgs)).MethodHandle;
				}
				this.OMR(\u0014\u0013\u0019.\u000A(u001F), false);
			}
			else
			{
				\u0020\u0013\u0019.\u000A(this, u000A, \u0017\u0013\u0019.\u000A(u001F));
			}
			\u0002\u0013\u0019.\u0007(\u0010\u0014\u0019.\u0007(this.VB));
		}

		// Token: 0x06000F1D RID: 3869 RVA: 0x00060D8C File Offset: 0x0005EF8C
		public void TaskFinishedV2(ITaskFinishedArgs taskFinished)
		{
			ExportFilesTaskArgs u001F = \u0001\u0005\u000E.\u001F(taskFinished);
			if (\u0013\u0013\u0019.\u000A(u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelWindowModel.TaskFinishedV2(ITaskFinishedArgs)).MethodHandle;
				}
				this.OMR(\u0014\u0013\u0019.\u000A(u001F), true);
			}
			else
			{
				\u0020\u0013\u0019.\u000A(this, \u001A\u0013\u0019.\u000A(u001F), \u0017\u0013\u0019.\u000A(u001F));
			}
			\u0002\u0013\u0019.\u0007(\u0010\u0014\u0019.\u0007(this.VB));
		}

		// Token: 0x06000F1E RID: 3870 RVA: 0x00060DF8 File Offset: 0x0005EFF8
		protected void OpenFile(string filePath, bool openSpreadSheet)
		{
			if (openSpreadSheet)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelWindowModel.OpenFile(string, bool)).MethodHandle;
				}
				\u0004\u0019\u0019.\u000A(filePath);
				return;
			}
			\u000F\u0005\u0019.\u000A(\u0001\u0013\u0019.\u000A(), \u0018\u000B\u0007.\u0007(this), MessageBoxButtons.OK);
		}

		// Token: 0x06000F1F RID: 3871 RVA: 0x00060E3C File Offset: 0x0005F03C
		public void OnImportExcelClicked()
		{
			\u0020\u0003.\u0019(\u0004\u000F.\u0005(), \u0018\u000B\u0007.\u0007(this), \u0010\u0014\u0019.\u0007(this.VB), false);
		}

		// Token: 0x06000F20 RID: 3872 RVA: 0x00060E6C File Offset: 0x0005F06C
		public void OnImportFromGoogleDriveCommand()
		{
			DriveSelection u001F = \u001F\u001A\u0019.\u000A(\u000F\u0013\u0019.\u000A(), true);
			\u0015\u000D\u001D.\u000A(u001F, \u0018\u000B\u0007.\u0007(this));
			bool? flag = \u0018\u0020\u000A.\u0007(u001F);
			if (!\u0012\u0015\u000A.\u000A(ref flag))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelWindowModel.OnImportFromGoogleDriveCommand()).MethodHandle;
				}
				return;
			}
			string u001F2 = \u0009\u0013\u0019.\u000A(u001F);
			if (\u0010\u0002\u001D.\u000A(u001F2))
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
				InteropUtility.\u001F(\u0009\u0013\u0019.\u000A(u001F), \u0010\u0011\u000A.\u000A());
				\u0020\u0003.\u0019(u001F2, \u0018\u000B\u0007.\u0007(this), \u0010\u0014\u0019.\u0007(this.VB), true);
			}
		}

		// Token: 0x040005E7 RID: 1511
		private PanelParameters NB;

		// Token: 0x040005E8 RID: 1512
		private readonly List<PanelParameters> MB;

		// Token: 0x040005E9 RID: 1513
		private readonly CustomProgressBar VB;

		// Token: 0x040005EA RID: 1514
		private readonly PanelControl ZB;

		// Token: 0x040005EB RID: 1515
		private readonly UIDocument XB;

		// Token: 0x040005EC RID: 1516
		private string PB;

		// Token: 0x040005ED RID: 1517
		private bool OB;

		// Token: 0x040005EE RID: 1518
		[CompilerGenerated]
		private ObservableCollection<Panel> TB;
	}
}
