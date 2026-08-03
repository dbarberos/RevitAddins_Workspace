using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml.Serialization;
using A;
using DiRoots.One.Commons.Enums;
using Microsoft.Win32;
using ProSheets;

namespace DiRoots.ProSheets.UI.DiProfiles
{
	// Token: 0x02000048 RID: 72
	public class ProfileControl : UserControl, IComponentConnector
	{
		// Token: 0x060002DD RID: 733 RVA: 0x00010AE8 File Offset: 0x0000ECE8
		public ProfileControl()
		{
			\u000C\u000A\u0014.\u0018(this);
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060002DE RID: 734 RVA: 0x00010B04 File Offset: 0x0000ED04
		// (remove) Token: 0x060002DF RID: 735 RVA: 0x00010B50 File Offset: 0x0000ED50
		public event ProfileControl.LoadProfileHandler LoadProfileEvent
		{
			[CompilerGenerated]
			add
			{
				ProfileControl.LoadProfileHandler loadProfileHandler = this.P;
				ProfileControl.LoadProfileHandler loadProfileHandler2;
				do
				{
					loadProfileHandler2 = loadProfileHandler;
					ProfileControl.LoadProfileHandler value2 = (ProfileControl.LoadProfileHandler)\u001C\u0019\u0018.\u0018(loadProfileHandler2, value);
					loadProfileHandler = Interlocked.CompareExchange<ProfileControl.LoadProfileHandler>(ref this.P, value2, loadProfileHandler2);
				}
				while (loadProfileHandler != loadProfileHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileControl.add_LoadProfileEvent(ProfileControl.LoadProfileHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ProfileControl.LoadProfileHandler loadProfileHandler = this.P;
				ProfileControl.LoadProfileHandler loadProfileHandler2;
				do
				{
					loadProfileHandler2 = loadProfileHandler;
					ProfileControl.LoadProfileHandler value2 = (ProfileControl.LoadProfileHandler)\u0013\u0019\u0018.\u0018(loadProfileHandler2, value);
					loadProfileHandler = Interlocked.CompareExchange<ProfileControl.LoadProfileHandler>(ref this.P, value2, loadProfileHandler2);
				}
				while (loadProfileHandler != loadProfileHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileControl.remove_LoadProfileEvent(ProfileControl.LoadProfileHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060002E0 RID: 736 RVA: 0x00010B9C File Offset: 0x0000ED9C
		// (remove) Token: 0x060002E1 RID: 737 RVA: 0x00010BE8 File Offset: 0x0000EDE8
		public event ProfileControl.GetProfileValuesHandler GetProfileValuesEvent
		{
			[CompilerGenerated]
			add
			{
				ProfileControl.GetProfileValuesHandler getProfileValuesHandler = this.Q;
				ProfileControl.GetProfileValuesHandler getProfileValuesHandler2;
				do
				{
					getProfileValuesHandler2 = getProfileValuesHandler;
					ProfileControl.GetProfileValuesHandler value2 = (ProfileControl.GetProfileValuesHandler)\u001C\u0019\u0018.\u0018(getProfileValuesHandler2, value);
					getProfileValuesHandler = Interlocked.CompareExchange<ProfileControl.GetProfileValuesHandler>(ref this.Q, value2, getProfileValuesHandler2);
				}
				while (getProfileValuesHandler != getProfileValuesHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileControl.add_GetProfileValuesEvent(ProfileControl.GetProfileValuesHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ProfileControl.GetProfileValuesHandler getProfileValuesHandler = this.Q;
				ProfileControl.GetProfileValuesHandler getProfileValuesHandler2;
				do
				{
					getProfileValuesHandler2 = getProfileValuesHandler;
					ProfileControl.GetProfileValuesHandler value2 = (ProfileControl.GetProfileValuesHandler)\u0013\u0019\u0018.\u0018(getProfileValuesHandler2, value);
					getProfileValuesHandler = Interlocked.CompareExchange<ProfileControl.GetProfileValuesHandler>(ref this.Q, value2, getProfileValuesHandler2);
				}
				while (getProfileValuesHandler != getProfileValuesHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileControl.remove_GetProfileValuesEvent(ProfileControl.GetProfileValuesHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x00010C34 File Offset: 0x0000EE34
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x00010C48 File Offset: 0x0000EE48
		public ExportTemPlateInfo CurrentTemplateInfo { get; set; }

		// Token: 0x060002E4 RID: 740 RVA: 0x00010C5C File Offset: 0x0000EE5C
		public void LoadProfile()
		{
			int num = 0;
			int u = 0;
			List<Profile>.Enumerator enumerator = \u0001\u0009\u0014.\u0018(Enumerable.ToList<Profile>(\u001B\u0009\u0014.\u0014(\u0005\u0009\u0014.\u0018())));
			try
			{
				while (\u0010\u0009\u0014.\u0018(ref enumerator))
				{
					Profile u000C = \u0008\u0009\u0014.\u0018(ref enumerator);
					\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.F), \u0006\u0009\u0014.\u0018(u000C));
					if (\u0003\u000A\u0014.\u0018(u000C))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileControl.LoadProfile()).MethodHandle;
						}
						u = num;
					}
					num++;
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
				((IDisposable)enumerator).Dispose();
			}
			\u0009\u0019\u0018.\u0018(this.F, u);
			if (\u0002\u000D\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.F)) == 0)
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
				Profile u2 = \u0014\u000A\u0014.\u0018();
				ProfileControl.LoadProfileHandler p = this.P;
				if (p == null)
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
				\u0018\u000A\u0014.\u0018(p, u2);
			}
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00010D60 File Offset: 0x0000EF60
		private void btnAddProfile_Click(object sender, RoutedEventArgs e)
		{
			NewProfile u000C = \u000D\u000A\u0014.\u0018();
			\u0012\u000A\u0014.\u0018(u000C, this);
			\u000F\u000A\u0014.\u0018(u000C, new NewProfile.TaskFinishedHandler(this.Y));
			\u001E\u0007\u0018.\u0014(u000C);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00010D98 File Offset: 0x0000EF98
		private void Y(NewProfile P, string Q, bool J, bool F)
		{
			if (F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileControl.Y(NewProfile, string, bool, bool)).MethodHandle;
				}
				OpenFileDialog u000C = \u0003\u0007\u0018.\u0018();
				\u0014\u0007\u0018.\u0018(u000C, "Xml Files (.xml)|*.xml");
				bool? flag = \u0018\u0007\u0018.\u0018(u000C);
				if (!\u000C\u0007\u0018.\u0018(ref flag))
				{
					return;
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
				try
				{
					string text = \u000E\u0019\u0018.\u0018(u000C);
					Profiles profiles = \u0008\u000A\u0014.\u0018(text);
					bool flag2 = false;
					bool flag3;
					if (profiles == null)
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
						flag3 = (null != null);
					}
					else
					{
						flag3 = (\u001B\u0009\u0014.\u0003(profiles) != null);
					}
					if (flag3)
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
						if (\u0006\u000A\u0014.\u0018(\u001B\u0009\u0014.\u0014(profiles)) > 0)
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
							flag2 = true;
						}
					}
					if (flag2)
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
						Profile profile = \u0010\u000A\u0014.\u0018(\u001B\u0009\u0014.\u0014(profiles), 0);
						\u001F\u000A\u0014.\u0018(profile, true);
						\u0011\u000A\u0014.\u0018(profile, Q);
						\u0020\u000A\u0014.\u0018(profile, text);
						int num = 0;
						bool flag4 = false;
						List<Profile>.Enumerator enumerator = \u0001\u0009\u0014.\u0018(\u001B\u0009\u0014.\u0014(\u0005\u0009\u0014.\u0018()));
						try
						{
							while (\u0010\u0009\u0014.\u0018(ref enumerator))
							{
								if (\u000F\u0002\u0018.\u0018(\u0006\u0009\u0014.\u0018(\u0008\u0009\u0014.\u0018(ref enumerator)), \u0006\u0009\u0014.\u0018(profile)))
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
									flag4 = true;
									goto IL_15C;
								}
								num++;
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
						IL_15C:
						enumerator = \u0001\u0009\u0014.\u0018(\u001B\u0009\u0014.\u0014(\u0005\u0009\u0014.\u0018()));
						try
						{
							while (\u0010\u0009\u0014.\u0018(ref enumerator))
							{
								\u001F\u000A\u0014.\u0018(\u0008\u0009\u0014.\u0018(ref enumerator), false);
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
						if (flag4)
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
							\u0007\u000A\u0014.\u0018(\u001B\u0009\u0014.\u0014(\u0005\u0009\u0014.\u0018()), num);
							\u0019\u000A\u0014.\u0018(\u001B\u0009\u0014.\u0014(\u0005\u0009\u0014.\u0018()), num, profile);
						}
						else
						{
							\u0009\u000A\u0014.\u0018(\u001B\u0009\u0014.\u0014(\u0005\u0009\u0014.\u0018()), profile);
						}
						\u000A\u000A\u0014.\u0018();
						bool flag5 = false;
						int num2 = 0;
						IEnumerator u000C2 = \u0016\u000F\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.F));
						try
						{
							while (\u001F\u001E\u0018.\u0018(u000C2))
							{
								if (\u000F\u0002\u0018.\u0018(\u001E\u0002\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C2)), \u0006\u0009\u0014.\u0018(profile)))
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
									flag5 = true;
									goto IL_28D;
								}
								num2++;
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
							IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C2);
							if (disposable != null)
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
								\u0020\u001E\u0018.\u0018(disposable);
							}
						}
						IL_28D:
						if (flag5)
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
							if (\u000D\u0007\u0018.\u0018(this.F) == num2)
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
								ProfileControl.LoadProfileHandler p = this.P;
								if (p == null)
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
								}
								else
								{
									\u0018\u000A\u0014.\u0018(p, profile);
								}
							}
							else
							{
								\u0009\u0019\u0018.\u0018(this.F, num2);
							}
						}
						else
						{
							\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.F), \u0006\u0009\u0014.\u0018(profile));
							\u0009\u0019\u0018.\u0018(this.F, \u0002\u000D\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.F)) - 1);
						}
					}
					else
					{
						\u0014\u001A\u0018.\u0018(\u001C\u0009\u0018.\u0002);
					}
					return;
				}
				catch (Exception)
				{
					\u0014\u001A\u0018.\u0018(\u001C\u0009\u0018.\u0004);
					return;
				}
			}
			try
			{
				SaveFileDialog u000C3 = \u000B\u000A\u0014.\u0018();
				\u001A\u000A\u0014.\u0018(u000C3, Q);
				\u001D\u000A\u0014.\u0018(u000C3, true);
				\u0014\u0007\u0018.\u0018(u000C3, "Xml Files(.xml)| *.xml");
				bool? flag = \u0018\u0007\u0018.\u0018(u000C3);
				if (\u000C\u0007\u0018.\u0018(ref flag))
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
					string text2 = \u000E\u0019\u0018.\u0018(u000C3);
					Profiles profiles2 = \u0004\u000A\u0014.\u0018();
					Profile profile2 = \u0002\u000A\u0014.\u0018();
					\u0011\u000A\u0014.\u0018(profile2, Q);
					\u001F\u000A\u0014.\u0018(profile2, true);
					\u0020\u000A\u0014.\u0018(profile2, text2);
					object u000C4 = \u001B\u0009\u0014.\u0014(\u0005\u0009\u0014.\u0018());
					Action<Profile> u;
					if ((u = ProfileControl.<>c.\u0018) == null)
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
						u = (ProfileControl.<>c.\u0018 = new Action<Profile>(ProfileControl.<>c.\u000C.\u0014));
					}
					\u001E\u000A\u0014.\u0018(u000C4, u);
					\u0009\u000A\u0014.\u0018(\u001B\u0009\u0014.\u0014(\u0005\u0009\u0014.\u0018()), profile2);
					if (J)
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
						ProfileControl.GetProfileValuesHandler q = this.Q;
						if (q == null)
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
						}
						else
						{
							\u0015\u000A\u0014.\u0018(q, \u0017\u000A\u0014.\u0018(profile2));
						}
					}
					else
					{
						profile2 = \u0014\u000A\u0014.\u0018();
						\u0011\u000A\u0014.\u0018(profile2, Q);
						\u001F\u000A\u0014.\u0018(profile2, true);
						\u0020\u000A\u0014.\u0018(profile2, text2);
					}
					\u000A\u000A\u0014.\u0018();
					\u0009\u000A\u0014.\u0018(\u001B\u0009\u0014.\u0014(profiles2), profile2);
					XmlSerializer u000C5 = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000A\u001A\u000F.\u000C()));
					XmlSerializerNamespaces xmlSerializerNamespaces = \u0019\u001D\u0018.\u0018();
					\u000B\u001D\u0018.\u0018(xmlSerializerNamespaces, "", "");
					TextWriter textWriter = \u001A\u001D\u0018.\u0018(text2);
					try
					{
						\u001D\u001D\u0018.\u0018(u000C5, textWriter, profiles2, xmlSerializerNamespaces);
						\u0004\u001D\u0018.\u0018(textWriter);
					}
					finally
					{
						if (textWriter != null)
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
							\u0020\u001E\u0018.\u0018(textWriter);
						}
					}
					\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.F), \u0006\u0009\u0014.\u0018(profile2));
					\u0009\u0019\u0018.\u0018(this.F, \u0002\u000D\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.F)) - 1);
				}
			}
			catch (Exception u2)
			{
				\u001C\u000A\u0014.\u0018(\u0013\u000A\u0014.\u0018(), u2, true);
			}
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00011380 File Offset: 0x0000F580
		private void btnSaveProfile_Click(object sender, RoutedEventArgs e)
		{
			if (\u0006\u000A\u0014.\u0018(\u001B\u0009\u0014.\u0014(\u0005\u0009\u0014.\u0018())) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileControl.btnSaveProfile_Click(object, RoutedEventArgs)).MethodHandle;
				}
				List<Profile>.Enumerator enumerator = \u0001\u0009\u0014.\u0018(\u001B\u0009\u0014.\u0014(\u0005\u0009\u0014.\u0018()));
				try
				{
					while (\u0010\u0009\u0014.\u0018(ref enumerator))
					{
						Profile u000C = \u0008\u0009\u0014.\u0018(ref enumerator);
						if (\u000F\u0002\u0018.\u0018(\u0006\u0009\u0014.\u0018(u000C), \u0005\u000A\u0014.\u0018(this.F)))
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
							SaveProfile u000C2 = \u001B\u000A\u0014.\u0018(\u0006\u0009\u0014.\u0018(u000C));
							\u0012\u000A\u0014.\u0018(u000C2, this);
							\u0001\u000A\u0014.\u0018(u000C2, new SaveProfile.SaveProfileEventHandler(this.O));
							\u001E\u0007\u0018.\u0014(u000C2);
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
					return;
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			\u0014\u001A\u0018.\u0018(\u001C\u0009\u0018.\u0008);
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00011478 File Offset: 0x0000F678
		private void O(SaveProfile P, string Q, bool J)
		{
			List<Profile>.Enumerator enumerator = \u0001\u0009\u0014.\u0018(\u001B\u0009\u0014.\u0014(\u0005\u0009\u0014.\u0018()));
			try
			{
				while (\u0010\u0009\u0014.\u0018(ref enumerator))
				{
					Profile profile = \u0008\u0009\u0014.\u0018(ref enumerator);
					\u0016\u0020\u0014.\u0018(profile, 1);
					if (\u000F\u0002\u0018.\u0018(\u0006\u0009\u0014.\u0018(profile), \u0005\u000A\u0014.\u0018(this.F)))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileControl.O(SaveProfile, string, bool)).MethodHandle;
						}
						ExportTemPlateInfo u = \u0003\u0020\u0014.\u0018();
						ProfileControl.GetProfileValuesHandler q = this.Q;
						if (q == null)
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
						}
						else
						{
							\u0015\u000A\u0014.\u0018(q, u);
						}
						if (J)
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
							SaveFileDialog u000C = \u000B\u000A\u0014.\u0018();
							\u001A\u000A\u0014.\u0018(u000C, \u0006\u0009\u0014.\u0018(profile));
							\u001D\u000A\u0014.\u0018(u000C, true);
							\u0014\u0007\u0018.\u0018(u000C, "Xml Files(.xml)| *.xml");
							bool? flag = \u0018\u0007\u0018.\u0018(u000C);
							if (\u000C\u0007\u0018.\u0018(ref flag))
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
								Profile profile2 = \u0009\u001A\u000F.\u000C(\u0014\u0020\u0014.\u0018(profile));
								\u0018\u0020\u0014.\u0018(profile2, u);
								\u0020\u000A\u0014.\u0018(profile2, \u000E\u0019\u0018.\u0018(u000C));
								Profiles profiles = \u0004\u000A\u0014.\u0018();
								\u0009\u000A\u0014.\u0018(\u001B\u0009\u0014.\u0014(profiles), profile2);
								XmlSerializer u000C2 = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000A\u001A\u000F.\u000C()));
								XmlSerializerNamespaces xmlSerializerNamespaces = \u0019\u001D\u0018.\u0018();
								\u000B\u001D\u0018.\u0018(xmlSerializerNamespaces, "", "");
								TextWriter textWriter = \u001A\u001D\u0018.\u0018(\u000E\u000A\u0014.\u0018(profile2));
								try
								{
									\u001D\u001D\u0018.\u0018(u000C2, textWriter, profiles, xmlSerializerNamespaces);
									\u0004\u001D\u0018.\u0018(textWriter);
								}
								finally
								{
									if (textWriter != null)
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
										\u0020\u001E\u0018.\u0018(textWriter);
									}
								}
								\u000A\u000A\u0014.\u0018();
								\u0014\u001A\u0018.\u0018(\u001C\u0009\u0018.\u001E);
							}
						}
						else
						{
							\u0018\u0020\u0014.\u0018(profile, u);
							\u000A\u000A\u0014.\u0018();
							Profiles profiles2 = \u0004\u000A\u0014.\u0018();
							\u0009\u000A\u0014.\u0018(\u001B\u0009\u0014.\u0014(profiles2), profile);
							try
							{
								if (\u000C\u001A\u0018.\u0018(\u000E\u000A\u0014.\u0018(profile)))
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
									\u000C\u0020\u0014.\u0018(\u000E\u000A\u0014.\u0018(profile));
								}
								XmlSerializer u000C3 = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u000A\u001A\u000F.\u000C()));
								XmlSerializerNamespaces xmlSerializerNamespaces2 = \u0019\u001D\u0018.\u0018();
								\u000B\u001D\u0018.\u0018(xmlSerializerNamespaces2, "", "");
								TextWriter textWriter2 = \u001A\u001D\u0018.\u0018(\u000E\u000A\u0014.\u0018(profile));
								try
								{
									\u001D\u001D\u0018.\u0018(u000C3, textWriter2, profiles2, xmlSerializerNamespaces2);
									\u0004\u001D\u0018.\u0018(textWriter2);
								}
								finally
								{
									if (textWriter2 != null)
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
										\u0020\u001E\u0018.\u0018(textWriter2);
									}
								}
							}
							catch (Exception)
							{
								\u000A\u000A\u0014.\u0018();
							}
						}
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
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00011784 File Offset: 0x0000F984
		private void btnDeleteProfile_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string u = \u0001\u0017\u0018.\u0018(\u0012\u0007\u0018.\u0018(this.F));
				if (\u0001\u0007\u0018.\u0018(\u001C\u001E\u0018.\u0018(\u001C\u0009\u0018.\u001D, \u0014\u001E\u0018.\u0018("\"", u, "\"")), MessageBoxButtons.YesNo))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileControl.btnDeleteProfile_Click(object, RoutedEventArgs)).MethodHandle;
					}
					List<Profile>.Enumerator enumerator = \u0001\u0009\u0014.\u0018(Enumerable.ToList<Profile>(\u001B\u0009\u0014.\u0014(\u0005\u0009\u0014.\u0018())));
					try
					{
						while (\u0010\u0009\u0014.\u0018(ref enumerator))
						{
							Profile profile = \u0008\u0009\u0014.\u0018(ref enumerator);
							if (\u000F\u0002\u0018.\u0018(\u0006\u0009\u0014.\u0018(profile), u))
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
								\u0012\u0020\u0014.\u0018(\u001B\u0009\u0014.\u0014(\u0005\u0009\u0014.\u0018()), profile);
								goto IL_D8;
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
					IL_D8:
					\u000F\u0020\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.F));
					enumerator = \u0001\u0009\u0014.\u0018(\u001B\u0009\u0014.\u0014(\u0005\u0009\u0014.\u0018()));
					try
					{
						while (\u0010\u0009\u0014.\u0018(ref enumerator))
						{
							Profile u000C = \u0008\u0009\u0014.\u0018(ref enumerator);
							\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.F), \u0006\u0009\u0014.\u0018(u000C));
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
					if (\u0002\u000D\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.F)) > 0)
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
						\u0009\u0019\u0018.\u0018(this.F, 0);
					}
					else
					{
						Profile u2 = \u0014\u000A\u0014.\u0018();
						ProfileControl.LoadProfileHandler p = this.P;
						if (p == null)
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
							\u0018\u000A\u0014.\u0018(p, u2);
						}
					}
					\u000A\u000A\u0014.\u0018();
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00011990 File Offset: 0x0000FB90
		private void cmbProfiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				List<Profile>.Enumerator enumerator = \u0001\u0009\u0014.\u0018(\u001B\u0009\u0014.\u0014(\u0005\u0009\u0014.\u0018()));
				try
				{
					while (\u0010\u0009\u0014.\u0018(ref enumerator))
					{
						Profile u000C = \u0008\u0009\u0014.\u0018(ref enumerator);
						\u001F\u000A\u0014.\u0018(u000C, \u000F\u0002\u0018.\u0018(\u0006\u0009\u0014.\u0018(u000C), \u0001\u0017\u0018.\u0018(\u0012\u0007\u0018.\u0018(this.F))));
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileControl.cmbProfiles_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				enumerator = \u0001\u0009\u0014.\u0018(\u001B\u0009\u0014.\u0014(\u0005\u0009\u0014.\u0018()));
				try
				{
					while (\u0010\u0009\u0014.\u0018(ref enumerator))
					{
						Profile profile = \u0008\u0009\u0014.\u0018(ref enumerator);
						if (\u000F\u0002\u0018.\u0018(\u0006\u0009\u0014.\u0018(profile), \u0001\u0017\u0018.\u0018(\u0012\u0007\u0018.\u0018(this.F))))
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
							Profile u = profile;
							try
							{
								if (\u000C\u001A\u0018.\u0018(\u000E\u000A\u0014.\u0018(profile)))
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
									Profiles u000C2 = \u0008\u000A\u0014.\u0018(\u000E\u000A\u0014.\u0018(profile));
									if (\u001B\u0009\u0014.\u0014(u000C2) != null)
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
										if (\u0006\u000A\u0014.\u0018(\u001B\u0009\u0014.\u0014(u000C2)) > 0)
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
											u = \u0010\u000A\u0014.\u0018(\u001B\u0009\u0014.\u0014(u000C2), 0);
										}
									}
								}
							}
							catch (Exception)
							{
							}
							ProfileControl.LoadProfileHandler p = this.P;
							if (p == null)
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
							}
							else
							{
								\u0018\u000A\u0014.\u0018(p, u);
							}
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
				\u000A\u000A\u0014.\u0018();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00011B90 File Offset: 0x0000FD90
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u000C\u0010\u0018.\u0018(\u0018\u0010\u0018.\u0018(\u0014\u0010\u0018.\u0018(this)));
			\u000E\u0007\u0018.\u0018(this);
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00011BB8 File Offset: 0x0000FDB8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		public void InitializeComponent()
		{
			if (this.M)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileControl.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.M = true;
			Uri u = \u0005\u000B\u0018.\u0018("/DiRoots.ProSheets;V2.1.2.0;component/ui/profile/profilecontrol.xaml", UriKind.Relative);
			\u001B\u000B\u0018.\u0018(this, u);
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00011C00 File Offset: 0x0000FE00
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.X(int P, object Q)
		{
			switch (P)
			{
			case 1:
				\u0018\u0019\u0018.\u0018(\u0013\u001A\u000F.\u000C(Q), new RoutedEventHandler(this.UserControl_Loaded));
				return;
			case 2:
				this.F = \u000F\u0004\u000F.\u000C(Q);
				\u0013\u000F\u0014.\u0018(this.F, new SelectionChangedEventHandler(this.cmbProfiles_SelectionChanged));
				return;
			case 3:
				this.H = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.H, new RoutedEventHandler(this.btnAddProfile_Click));
				return;
			case 4:
				this.N = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.N, new RoutedEventHandler(this.btnSaveProfile_Click));
				return;
			case 5:
				this.Z = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.Z, new RoutedEventHandler(this.btnDeleteProfile_Click));
				return;
			default:
				this.M = true;
				return;
			}
		}

		// Token: 0x04000159 RID: 345
		[CompilerGenerated]
		private ProfileControl.LoadProfileHandler P;

		// Token: 0x0400015A RID: 346
		[CompilerGenerated]
		private ProfileControl.GetProfileValuesHandler Q;

		// Token: 0x0400015B RID: 347
		[CompilerGenerated]
		private ExportTemPlateInfo J;

		// Token: 0x0400015C RID: 348
		internal ComboBox F;

		// Token: 0x0400015D RID: 349
		internal Button H;

		// Token: 0x0400015E RID: 350
		internal Button N;

		// Token: 0x0400015F RID: 351
		internal Button Z;

		// Token: 0x04000160 RID: 352
		private bool M;

		// Token: 0x0200016A RID: 362
		// (Invoke) Token: 0x06001084 RID: 4228
		public delegate bool LoadProfileHandler(Profile profile);

		// Token: 0x0200016B RID: 363
		// (Invoke) Token: 0x06001088 RID: 4232
		public delegate void GetProfileValuesHandler(ExportTemPlateInfo templateInfo);
	}
}
