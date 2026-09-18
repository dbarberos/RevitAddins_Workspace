using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using A;
using DiRoots.One.SheetGen.Models;

namespace DiRoots.One.SheetGen.UI.ValidationRules
{
	// Token: 0x02000398 RID: 920
	public class CanSaveValidationProperties : DependencyObject
	{
		// Token: 0x17000A70 RID: 2672
		// (get) Token: 0x0600254F RID: 9551 RVA: 0x000E1754 File Offset: 0x000DF954
		// (set) Token: 0x06002550 RID: 9552 RVA: 0x000E1778 File Offset: 0x000DF978
		public ErrorType ErrorType
		{
			get
			{
				return \u000C\u000E\u000E.\u001F(\u0004\u0015\u000A.\u0007(this, CanSaveValidationProperties.ErrorTypeProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, CanSaveValidationProperties.ErrorTypeProperty, value);
			}
		}

		// Token: 0x17000A71 RID: 2673
		// (get) Token: 0x06002551 RID: 9553 RVA: 0x000E1798 File Offset: 0x000DF998
		// (set) Token: 0x06002552 RID: 9554 RVA: 0x000E17BC File Offset: 0x000DF9BC
		public ObservableCollection<Profile> Profiles
		{
			get
			{
				return \u001A\u000E\u000E.\u001F(\u0004\u0015\u000A.\u0007(this, CanSaveValidationProperties.ProfilesProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, CanSaveValidationProperties.SetsProperty, value);
			}
		}

		// Token: 0x17000A72 RID: 2674
		// (get) Token: 0x06002553 RID: 9555 RVA: 0x000E17D8 File Offset: 0x000DF9D8
		// (set) Token: 0x06002554 RID: 9556 RVA: 0x000E17FC File Offset: 0x000DF9FC
		public string ButtonContent
		{
			get
			{
				return \u0013\u0001\u0010.\u001F(\u0004\u0015\u000A.\u0007(this, CanSaveValidationProperties.ButtonContentProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, CanSaveValidationProperties.ButtonContentProperty, value);
			}
		}

		// Token: 0x06002555 RID: 9557 RVA: 0x000E1818 File Offset: 0x000DFA18
		private static void CallBackOnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BindingExpressionBase bindingExpressionBase = \u000D\u0006\u001D.\u000A(\u0013\u000E\u000E.\u001F(d), CanSaveValidationProperties.ButtonContentProperty);
			if (bindingExpressionBase == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveValidationProperties.CallBackOnChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				return;
			}
			\u001C\u0006\u001D.\u000A(bindingExpressionBase);
		}

		// Token: 0x17000A73 RID: 2675
		// (get) Token: 0x06002556 RID: 9558 RVA: 0x000E1858 File Offset: 0x000DFA58
		// (set) Token: 0x06002557 RID: 9559 RVA: 0x000E187C File Offset: 0x000DFA7C
		public bool ButtonIsEnabled
		{
			get
			{
				return \u001F\u0001\u0010.\u001F(\u0004\u0015\u000A.\u0007(this, CanSaveValidationProperties.ButtonIsEnabledProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, CanSaveValidationProperties.ButtonIsEnabledProperty, value);
			}
		}

		// Token: 0x06002558 RID: 9560 RVA: 0x000E189C File Offset: 0x000DFA9C
		private static void IsEnabledCallBackOnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BindingExpressionBase bindingExpressionBase = \u000D\u0006\u001D.\u000A(\u0013\u000E\u000E.\u001F(d), CanSaveValidationProperties.ButtonIsEnabledProperty);
			if (bindingExpressionBase == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveValidationProperties.IsEnabledCallBackOnChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				return;
			}
			\u001C\u0006\u001D.\u000A(bindingExpressionBase);
		}

		// Token: 0x17000A74 RID: 2676
		// (get) Token: 0x06002559 RID: 9561 RVA: 0x000E18DC File Offset: 0x000DFADC
		// (set) Token: 0x0600255A RID: 9562 RVA: 0x000E1900 File Offset: 0x000DFB00
		public ObservableCollection<ViewSheetSetInfo> Sets
		{
