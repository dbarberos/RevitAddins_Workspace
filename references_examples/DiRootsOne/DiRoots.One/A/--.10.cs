using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Mechanical;
using DiRoots.RoomPro.Models;

namespace A
{
	// Token: 0x0200008C RID: 140
	internal class \u0013\u001D
	{
		// Token: 0x06000610 RID: 1552 RVA: 0x00021504 File Offset: 0x0001F704
		public \u0013\u001D(Document \u001F)
		{
			this.\u001F = \u001F;
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x00021520 File Offset: 0x0001F720
		public IEnumerable<Element> \u000A(BuiltInCategory \u001F)
		{
			return \u0001\u001E\u000A.\u0007(\u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(this.\u001F), \u001F)));
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x00021550 File Offset: 0x0001F750
		public List<RevitLinkInstance> \u0007()
		{
			List<RevitLinkInstance> list = \u001A\u000A\u001D.\u000A();
			IEnumerator<RevitLinkInstance> enumerator = \u0013\u000A\u001D.\u000A(Enumerable.OfType<RevitLinkInstance>(\u0001\u001E\u000A.\u0007(\u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(this.\u001F), -2001352L)))));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					RevitLinkInstance u000A = \u0014\u000A\u001D.\u000A(enumerator);
					\u0017\u000A\u001D.\u000A(list, u000A);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u0007()).MethodHandle;
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
			return list;
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x000215F4 File Offset: 0x0001F7F4
		public IEnumerable<SpatialElement> \u001D(BuiltInCategory \u001F)
		{
			IEnumerable<SpatialElement> enumerable = Enumerable.Cast<SpatialElement>(\u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(this.\u001F), \u001F)));
			Func<SpatialElement, bool> func;
			if ((func = \u0013\u001D.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u001D(BuiltInCategory)).MethodHandle;
				}
				func = (\u0013\u001D.<>c.\u000A = new Func<SpatialElement, bool>(\u0013\u001D.<>c.\u001F.\u0003\u000A));
			}
			return Enumerable.Where<SpatialElement>(enumerable, func);
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x00021660 File Offset: 0x0001F860
		public IEnumerable<SpatialElement> \u0004(BuiltInCategory \u001F)
		{
			IEnumerable<SpatialElement> enumerable = Enumerable.Cast<SpatialElement>(\u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u001A\u0018\u0007.\u000A(this.\u001F, \u0002\u001E\u000A.\u0007(\u0004\u0013\u000A.\u0007(this.\u001F))), \u001F)));
			Func<SpatialElement, bool> func;
			if ((func = \u0013\u001D.<>c.\u0007) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u0004(BuiltInCategory)).MethodHandle;
				}
				func = (\u0013\u001D.<>c.\u0007 = new Func<SpatialElement, bool>(\u0013\u001D.<>c.\u001F.\u001C\u000A));
			}
			return Enumerable.Where<SpatialElement>(enumerable, func);
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x000216E0 File Offset: 0x0001F8E0
		public List<Room> \u0019()
		{
			IEnumerable<SpatialElement> enumerable = this.\u001D(-2000160L);
			Func<SpatialElement, bool> func;
			if ((func = \u0013\u001D.<>c.\u001D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u0019()).MethodHandle;
				}
				func = (\u0013\u001D.<>c.\u001D = new Func<SpatialElement, bool>(\u0013\u001D.<>c.\u001F.\u000D\u000A));
			}
			IEnumerable<Room> enumerable2 = Enumerable.Cast<Room>(Enumerable.Where<SpatialElement>(enumerable, func));
			Func<Room, bool> func2;
			if ((func2 = \u0013\u001D.<>c.\u0004) == null)
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
				func2 = (\u0013\u001D.<>c.\u0004 = new Func<Room, bool>(\u0013\u001D.<>c.\u001F.\u0010\u000A));
			}
			return Enumerable.ToList<Room>(Enumerable.Where<Room>(enumerable2, func2));
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x00021774 File Offset: 0x0001F974
		public List<Space> \u0018()
		{
			IEnumerable<SpatialElement> enumerable = this.\u001D(-2003600L);
			Func<SpatialElement, bool> func;
			if ((func = \u0013\u001D.<>c.\u0019) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u0018()).MethodHandle;
				}
				func = (\u0013\u001D.<>c.\u0019 = new Func<SpatialElement, bool>(\u0013\u001D.<>c.\u001F.\u000E\u000A));
			}
			IEnumerable<Space> enumerable2 = Enumerable.Cast<Space>(Enumerable.Where<SpatialElement>(enumerable, func));
			Func<Space, bool> func2;
			if ((func2 = \u0013\u001D.<>c.\u0018) == null)
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
				func2 = (\u0013\u001D.<>c.\u0018 = new Func<Space, bool>(\u0013\u001D.<>c.\u001F.\u0008\u000A));
			}
			return Enumerable.ToList<Space>(Enumerable.Where<Space>(enumerable2, func2));
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x00021808 File Offset: 0x0001FA08
		public List<ModelRoom> \u0005()
		{
			IEnumerable<Room> enumerable = Enumerable.Cast<Room>(this.\u001D(-2000160L));
			Func<Room, bool> func;
			if ((func = \u0013\u001D.<>c.\u0005) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u0005()).MethodHandle;
				}
				func = (\u0013\u001D.<>c.\u0005 = new Func<Room, bool>(\u0013\u001D.<>c.\u001F.\u001B\u000A));
			}
			IEnumerable<Room> enumerable2 = Enumerable.Where<Room>(enumerable, func);
			Func<Room, ModelRoom> func2;
			if ((func2 = \u0013\u001D.<>c.\u0016) == null)
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
				func2 = (\u0013\u001D.<>c.\u0016 = new Func<Room, ModelRoom>(\u0013\u001D.<>c.\u001F.\u0011\u000A));
			}
			List<ModelRoom> list = Enumerable.ToList<ModelRoom>(Enumerable.Select<Room, ModelRoom>(enumerable2, func2));
			IEnumerable<Tuple<Room, RevitLinkInstance>> enumerable3 = this.\u000B();
			Func<Tuple<Room, RevitLinkInstance>, bool> func3;
			if ((func3 = \u0013\u001D.<>c.\u000B) == null)
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
				func3 = (\u0013\u001D.<>c.\u000B = new Func<Tuple<Room, RevitLinkInstance>, bool>(\u0013\u001D.<>c.\u001F.\u001E\u000A));
			}
			IEnumerable<Tuple<Room, RevitLinkInstance>> enumerable4 = Enumerable.Where<Tuple<Room, RevitLinkInstance>>(enumerable3, func3);
			Func<Tuple<Room, RevitLinkInstance>, bool> func4;
			if ((func4 = \u0013\u001D.<>c.\u0002) == null)
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
				func4 = (\u0013\u001D.<>c.\u0002 = new Func<Tuple<Room, RevitLinkInstance>, bool>(\u0013\u001D.<>c.\u001F.\u0020\u000A));
			}
			IEnumerable<Tuple<Room, RevitLinkInstance>> enumerable5 = Enumerable.Where<Tuple<Room, RevitLinkInstance>>(enumerable4, func4);
			Func<Tuple<Room, RevitLinkInstance>, ModelRoom> func5;
			if ((func5 = \u0013\u001D.<>c.\u0006) == null)
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
				func5 = (\u0013\u001D.<>c.\u0006 = new Func<Tuple<Room, RevitLinkInstance>, ModelRoom>(\u0013\u001D.<>c.\u001F.\u0017\u000A));
			}
			List<ModelRoom> u000A = Enumerable.ToList<ModelRoom>(Enumerable.Select<Tuple<Room, RevitLinkInstance>, ModelRoom>(enumerable5, func5));
			\u000C\u000A\u001D.\u000A(list, u000A);
			return list;
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x00021944 File Offset: 0x0001FB44
		public List<ModelSpace> \u0016()
		{
			IEnumerable<Space> enumerable = Enumerable.Cast<Space>(this.\u001D(-2003600L));
			Func<Space, bool> func;
			if ((func = \u0013\u001D.<>c.\u000F) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u0016()).MethodHandle;
				}
				func = (\u0013\u001D.<>c.\u000F = new Func<Space, bool>(\u0013\u001D.<>c.\u001F.\u0014\u000A));
			}
			IEnumerable<Space> enumerable2 = Enumerable.Where<Space>(enumerable, func);
			Func<Space, ModelSpace> func2;
			if ((func2 = \u0013\u001D.<>c.\u0012) == null)
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
				func2 = (\u0013\u001D.<>c.\u0012 = new Func<Space, ModelSpace>(\u0013\u001D.<>c.\u001F.\u0013\u000A));
			}
			List<ModelSpace> list = Enumerable.ToList<ModelSpace>(Enumerable.Select<Space, ModelSpace>(enumerable2, func2));
			IEnumerable<Tuple<Space, RevitLinkInstance>> enumerable3 = this.\u0002();
			Func<Tuple<Space, RevitLinkInstance>, bool> func3;
			if ((func3 = \u0013\u001D.<>c.\u0003) == null)
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
				func3 = (\u0013\u001D.<>c.\u0003 = new Func<Tuple<Space, RevitLinkInstance>, bool>(\u0013\u001D.<>c.\u001F.\u001A\u000A));
			}
			IEnumerable<Tuple<Space, RevitLinkInstance>> enumerable4 = Enumerable.Where<Tuple<Space, RevitLinkInstance>>(enumerable3, func3);
			Func<Tuple<Space, RevitLinkInstance>, bool> func4;
			if ((func4 = \u0013\u001D.<>c.\u001C) == null)
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
				func4 = (\u0013\u001D.<>c.\u001C = new Func<Tuple<Space, RevitLinkInstance>, bool>(\u0013\u001D.<>c.\u001F.\u000C\u000A));
			}
			IEnumerable<Tuple<Space, RevitLinkInstance>> enumerable5 = Enumerable.Where<Tuple<Space, RevitLinkInstance>>(enumerable4, func4);
			Func<Tuple<Space, RevitLinkInstance>, ModelSpace> func5;
			if ((func5 = \u0013\u001D.<>c.\u000D) == null)
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
				func5 = (\u0013\u001D.<>c.\u000D = new Func<Tuple<Space, RevitLinkInstance>, ModelSpace>(\u0013\u001D.<>c.\u001F.\u0015\u000A));
			}
			List<ModelSpace> u000A = Enumerable.ToList<ModelSpace>(Enumerable.Select<Tuple<Space, RevitLinkInstance>, ModelSpace>(enumerable5, func5));
			\u0015\u000A\u001D.\u000A(list, u000A);
			return list;
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x00021A80 File Offset: 0x0001FC80
		public List<Tuple<Room, RevitLinkInstance>> \u000B()
		{
			IEnumerable enumerable = \u0001\u001E\u000A.\u0007(\u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(this.\u001F), -2001352L)));
			List<Tuple<Room, RevitLinkInstance>> list = \u0007\u0007\u001D.\u000A();
			IEnumerator<RevitLinkInstance> enumerator = \u0013\u000A\u001D.\u000A(Enumerable.OfType<RevitLinkInstance>(enumerable));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					RevitLinkInstance revitLinkInstance = \u0014\u000A\u001D.\u000A(enumerator);
					Document document = \u000E\u0009\u0007.\u000A(revitLinkInstance);
					if (document != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u000B()).MethodHandle;
						}
						FilteredElementCollector filteredElementCollector = \u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(document), -2000160L));
						try
						{
							IEnumerator<Room> enumerator2 = \u000A\u0007\u001D.\u000A(Enumerable.Cast<Room>(filteredElementCollector));
							try
							{
								while (\u000A\u0017\u000A.\u000A(enumerator2))
								{
									Room u001F = \u001F\u0007\u001D.\u000A(enumerator2);
									\u0001\u000A\u001D.\u000A(list, \u0009\u000A\u001D.\u000A(u001F, revitLinkInstance));
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
										switch (6)
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
						finally
						{
							if (filteredElementCollector != null)
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
								\u001F\u0017\u000A.\u000A(filteredElementCollector);
							}
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
			return list;
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x00021BE4 File Offset: 0x0001FDE4
		public List<Tuple<Space, RevitLinkInstance>> \u0002()
		{
			IEnumerable enumerable = \u0001\u001E\u000A.\u0007(\u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(this.\u001F), -2001352L)));
			List<Tuple<Space, RevitLinkInstance>> list = \u0005\u0007\u001D.\u000A();
			IEnumerator<RevitLinkInstance> enumerator = \u0013\u000A\u001D.\u000A(Enumerable.OfType<RevitLinkInstance>(enumerable));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					RevitLinkInstance revitLinkInstance = \u0014\u000A\u001D.\u000A(enumerator);
					Document document = \u000E\u0009\u0007.\u000A(revitLinkInstance);
					if (document != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u0002()).MethodHandle;
						}
						FilteredElementCollector filteredElementCollector = \u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(document), -2003600L));
						try
						{
							IEnumerator<Space> enumerator2 = \u0018\u0007\u001D.\u000A(Enumerable.Cast<Space>(filteredElementCollector));
							try
							{
								while (\u000A\u0017\u000A.\u000A(enumerator2))
								{
									Space u001F = \u0019\u0007\u001D.\u000A(enumerator2);
									\u001D\u0007\u001D.\u000A(list, \u0004\u0007\u001D.\u000A(u001F, revitLinkInstance));
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
						}
						finally
						{
							if (filteredElementCollector != null)
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
								\u001F\u0017\u000A.\u000A(filteredElementCollector);
							}
						}
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
			return list;
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x00021D48 File Offset: 0x0001FF48
		public List<Tuple<SpatialElement, RevitLinkInstance>> \u0006()
		{
			IEnumerable enumerable = \u0001\u001E\u000A.\u0007(\u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u001A\u0018\u0007.\u000A(this.\u001F, \u0002\u001E\u000A.\u0007(\u0004\u0013\u000A.\u0007(this.\u001F))), -2001352L)));
			List<Tuple<SpatialElement, RevitLinkInstance>> list = \u000F\u0007\u001D.\u000A();
			IEnumerator<RevitLinkInstance> enumerator = \u0013\u000A\u001D.\u000A(Enumerable.OfType<RevitLinkInstance>(enumerable));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					RevitLinkInstance revitLinkInstance = \u0014\u000A\u001D.\u000A(enumerator);
					Document document = \u000E\u0009\u0007.\u000A(revitLinkInstance);
					if (document != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u0006()).MethodHandle;
						}
						FilteredElementCollector filteredElementCollector = \u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(document), -2003600L));
						try
						{
							IEnumerator<SpatialElement> enumerator2 = \u0006\u0007\u001D.\u000A(Enumerable.Cast<SpatialElement>(filteredElementCollector));
							try
							{
								while (\u000A\u0017\u000A.\u000A(enumerator2))
								{
									SpatialElement u001F = \u0002\u0007\u001D.\u000A(enumerator2);
									\u0016\u0007\u001D.\u000A(list, \u000B\u0007\u001D.\u000A(u001F, revitLinkInstance));
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
										switch (1)
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
						finally
						{
							if (filteredElementCollector != null)
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
								\u001F\u0017\u000A.\u000A(filteredElementCollector);
							}
						}
						FilteredElementCollector filteredElementCollector2 = \u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(document), -2000160L));
						try
						{
							IEnumerator<SpatialElement> enumerator2 = \u0006\u0007\u001D.\u000A(Enumerable.Cast<SpatialElement>(filteredElementCollector2));
							try
							{
								while (\u000A\u0017\u000A.\u000A(enumerator2))
								{
									SpatialElement u001F2 = \u0002\u0007\u001D.\u000A(enumerator2);
									\u0016\u0007\u001D.\u000A(list, \u000B\u0007\u001D.\u000A(u001F2, revitLinkInstance));
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
						finally
						{
							if (filteredElementCollector2 != null)
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
								\u001F\u0017\u000A.\u000A(filteredElementCollector2);
							}
						}
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return list;
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x00021FA4 File Offset: 0x000201A4
		public IEnumerable<ViewFamilyType> \u000F(ViewFamily \u001F)
		{
			\u0013\u001D.\u0017\u001D u0017_u001D = new \u0013\u001D.\u0017\u001D();
			u0017_u001D.\u001F = \u001F;
			return Enumerable.Where<ViewFamilyType>(Enumerable.Cast<ViewFamilyType>(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(this.\u001F), \u001E\u0011\u000A.\u000A(\u0003\u0007\u000E.\u001F()))), new Func<ViewFamilyType, bool>(u0017_u001D.\u000A));
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x00021FFC File Offset: 0x000201FC
		public IEnumerable<Phase> \u0012()
		{
			return Enumerable.Cast<Phase>(\u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(this.\u001F), -2000112L)));
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x00022034 File Offset: 0x00020234
		public IEnumerable<View> \u0003()
		{
			IEnumerable<View> enumerable = Enumerable.Cast<View>(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(this.\u001F), -2000279L));
			Func<View, bool> func;
			if ((func = \u0013\u001D.<>c.\u0010) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u0003()).MethodHandle;
				}
				func = (\u0013\u001D.<>c.\u0010 = new Func<View, bool>(\u0013\u001D.<>c.\u001F.\u0001\u000A));
			}
			IEnumerable<View> enumerable2 = Enumerable.Where<View>(enumerable, func);
			Func<View, bool> func2;
			if ((func2 = \u0013\u001D.<>c.\u000E) == null)
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
				func2 = (\u0013\u001D.<>c.\u000E = new Func<View, bool>(\u0013\u001D.<>c.\u001F.\u0009\u000A));
			}
			return Enumerable.Distinct<View>(Enumerable.Where<View>(enumerable2, func2));
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x000220D4 File Offset: 0x000202D4
		public IEnumerable<View> \u001C()
		{
			IEnumerable<View> enumerable = Enumerable.Cast<View>(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(this.\u001F), -2000279L));
			Func<View, bool> func;
			if ((func = \u0013\u001D.<>c.\u0008) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u001C()).MethodHandle;
				}
				func = (\u0013\u001D.<>c.\u0008 = new Func<View, bool>(\u0013\u001D.<>c.\u001F.\u001F\u0007));
			}
			IEnumerable<View> enumerable2 = Enumerable.Where<View>(enumerable, func);
			Func<View, bool> func2;
			if ((func2 = \u0013\u001D.<>c.\u001B) == null)
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
				func2 = (\u0013\u001D.<>c.\u001B = new Func<View, bool>(\u0013\u001D.<>c.\u001F.\u000A\u0007));
			}
			return Enumerable.Distinct<View>(Enumerable.Where<View>(enumerable2, func2));
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00022174 File Offset: 0x00020374
		public IEnumerable<ViewTemplate> \u000D()
		{
			IEnumerable<View> enumerable = Enumerable.Cast<View>(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(this.\u001F), -2000279L));
			Func<View, bool> func;
			if ((func = \u0013\u001D.<>c.\u0011) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u000D()).MethodHandle;
				}
				func = (\u0013\u001D.<>c.\u0011 = new Func<View, bool>(\u0013\u001D.<>c.\u001F.\u0007\u0007));
			}
			IEnumerable<View> enumerable2 = Enumerable.Where<View>(enumerable, func);
			Func<View, bool> func2;
			if ((func2 = \u0013\u001D.<>c.\u001E) == null)
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
				func2 = (\u0013\u001D.<>c.\u001E = new Func<View, bool>(\u0013\u001D.<>c.\u001F.\u001D\u0007));
			}
			IEnumerable<View> enumerable3 = Enumerable.Distinct<View>(Enumerable.Where<View>(enumerable2, func2));
			Func<View, ViewTemplate> func3;
			if ((func3 = \u0013\u001D.<>c.\u0020) == null)
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
				func3 = (\u0013\u001D.<>c.\u0020 = new Func<View, ViewTemplate>(\u0013\u001D.<>c.\u001F.\u0004\u0007));
			}
			IEnumerable<ViewTemplate> enumerable4 = Enumerable.Select<View, ViewTemplate>(enumerable3, func3);
			Func<ViewTemplate, string> func4;
			if ((func4 = \u0013\u001D.<>c.\u0017) == null)
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
				func4 = (\u0013\u001D.<>c.\u0017 = new Func<ViewTemplate, string>(\u0013\u001D.<>c.\u001F.\u0019\u0007));
			}
			List<ViewTemplate> list = Enumerable.ToList<ViewTemplate>(Enumerable.OrderBy<ViewTemplate, string>(enumerable4, func4));
			\u0012\u0007\u001D.\u000A(list, 0, \u0020\u000A\u001D.\u000A(\u0015\u0012\u0007.\u000A()));
			return list;
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00022290 File Offset: 0x00020490
		public IEnumerable<ViewTemplate> \u0010()
		{
			IEnumerable<View> enumerable = Enumerable.Cast<View>(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(this.\u001F), -2000279L));
			Func<View, bool> func;
			if ((func = \u0013\u001D.<>c.\u0014) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u0010()).MethodHandle;
				}
				func = (\u0013\u001D.<>c.\u0014 = new Func<View, bool>(\u0013\u001D.<>c.\u001F.\u0018\u0007));
			}
			IEnumerable<View> enumerable2 = Enumerable.Where<View>(enumerable, func);
			Func<View, bool> func2;
			if ((func2 = \u0013\u001D.<>c.\u0013) == null)
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
				func2 = (\u0013\u001D.<>c.\u0013 = new Func<View, bool>(\u0013\u001D.<>c.\u001F.\u0005\u0007));
			}
			IEnumerable<View> enumerable3 = Enumerable.Distinct<View>(Enumerable.Where<View>(enumerable2, func2));
			Func<View, ViewTemplate> func3;
			if ((func3 = \u0013\u001D.<>c.\u001A) == null)
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
				func3 = (\u0013\u001D.<>c.\u001A = new Func<View, ViewTemplate>(\u0013\u001D.<>c.\u001F.\u0016\u0007));
			}
			IEnumerable<ViewTemplate> enumerable4 = Enumerable.Select<View, ViewTemplate>(enumerable3, func3);
			Func<ViewTemplate, string> func4;
			if ((func4 = \u0013\u001D.<>c.\u000C) == null)
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
				func4 = (\u0013\u001D.<>c.\u000C = new Func<ViewTemplate, string>(\u0013\u001D.<>c.\u001F.\u000B\u0007));
			}
			List<ViewTemplate> list = Enumerable.ToList<ViewTemplate>(Enumerable.OrderBy<ViewTemplate, string>(enumerable4, func4));
			\u0012\u0007\u001D.\u000A(list, 0, \u0020\u000A\u001D.\u000A(\u0015\u0012\u0007.\u000A()));
			return list;
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x000223AC File Offset: 0x000205AC
		public IEnumerable<View> \u000E()
		{
			IEnumerable<View> enumerable = Enumerable.Cast<View>(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(this.\u001F), -2000279L));
			Func<View, bool> func;
			if ((func = \u0013\u001D.<>c.\u0015) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u000E()).MethodHandle;
				}
				func = (\u0013\u001D.<>c.\u0015 = new Func<View, bool>(\u0013\u001D.<>c.\u001F.\u0002\u0007));
			}
			return Enumerable.Distinct<View>(Enumerable.Where<View>(enumerable, func));
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x0002241C File Offset: 0x0002061C
		public IEnumerable<Parameter> \u0008()
		{
			Room room = Enumerable.FirstOrDefault<Room>(this.\u0019());
			if (room == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u0008()).MethodHandle;
				}
				return null;
			}
			IEnumerable<Parameter> enumerable = \u0003\u0007\u001D.\u000A(room, false);
			Func<Parameter, bool> func;
			if ((func = \u0013\u001D.<>c.\u0001) == null)
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
				func = (\u0013\u001D.<>c.\u0001 = new Func<Parameter, bool>(\u0013\u001D.<>c.\u001F.\u0006\u0007));
			}
			IEnumerable<Parameter> enumerable2 = Enumerable.Where<Parameter>(enumerable, func);
			Func<Parameter, bool> func2;
			if ((func2 = \u0013\u001D.<>c.\u0009) == null)
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
				func2 = (\u0013\u001D.<>c.\u0009 = new Func<Parameter, bool>(\u0013\u001D.<>c.\u001F.\u000F\u0007));
			}
			return Enumerable.Where<Parameter>(enumerable2, func2);
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x000224BC File Offset: 0x000206BC
		public IEnumerable<Parameter> \u001B()
		{
			List<Space> list = this.\u0018();
			if (!Enumerable.Any<Space>(list))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u001B()).MethodHandle;
				}
				return Enumerable.Empty<Parameter>();
			}
			Space space = Enumerable.FirstOrDefault<Space>(list);
			if (space == null)
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
				return null;
			}
			IEnumerable<Parameter> enumerable = \u0003\u0007\u001D.\u000A(space, false);
			Func<Parameter, bool> func;
			if ((func = \u0013\u001D.<>c.\u001F\u000A) == null)
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
				func = (\u0013\u001D.<>c.\u001F\u000A = new Func<Parameter, bool>(\u0013\u001D.<>c.\u001F.\u0012\u0007));
			}
			IEnumerable<Parameter> enumerable2 = Enumerable.Where<Parameter>(enumerable, func);
			Func<Parameter, bool> func2;
			if ((func2 = \u0013\u001D.<>c.\u000A\u000A) == null)
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
				func2 = (\u0013\u001D.<>c.\u000A\u000A = new Func<Parameter, bool>(\u0013\u001D.<>c.\u001F.\u0003\u0007));
			}
			return Enumerable.Where<Parameter>(enumerable2, func2);
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x00022578 File Offset: 0x00020778
		public IEnumerable<Parameter> \u0011()
		{
			IEnumerable<Parameter> enumerable = this.\u0008();
			List<Parameter> list;
			if (enumerable == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u0011()).MethodHandle;
				}
				list = \u0012\u0007\u000E.\u001F;
			}
			else
			{
				list = Enumerable.ToList<Parameter>(enumerable);
			}
			List<Parameter> list2 = list;
			if (list2 != null)
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
				\u000D\u0007\u001D.\u000A(list2, this.\u001B());
				return list2;
			}
			IEnumerable<Parameter> result;
			if ((result = this.\u001B()) == null)
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
				result = \u001C\u0007\u001D.\u000A();
			}
			return result;
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x000225F0 File Offset: 0x000207F0
		public IEnumerable<Parameter> \u001E()
		{
			IEnumerable<View> enumerable = Enumerable.Cast<View>(\u0011\u0011\u000A.\u001D(\u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(this.\u001F), -2000279L)), \u001E\u0011\u000A.\u000A(\u000F\u0007\u000E.\u001F())));
			Func<View, string> func;
			if ((func = \u0013\u001D.<>c.\u0007\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u001E()).MethodHandle;
				}
				func = (\u0013\u001D.<>c.\u0007\u000A = new Func<View, string>(\u0013\u001D.<>c.\u001F.\u001C\u0007));
			}
			List<View> list = Enumerable.ToList<View>(Enumerable.OrderBy<View, string>(enumerable, func));
			if (!Enumerable.Any<View>(list))
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
				return Enumerable.Empty<Parameter>();
			}
			IEnumerable<Parameter> enumerable2 = Enumerable.Distinct<Parameter>(\u0003\u0007\u001D.\u000A(Enumerable.FirstOrDefault<View>(list), false));
			Func<Parameter, bool> func2;
			if ((func2 = \u0013\u001D.<>c.\u001D\u000A) == null)
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
				func2 = (\u0013\u001D.<>c.\u001D\u000A = new Func<Parameter, bool>(\u0013\u001D.<>c.\u001F.\u000D\u0007));
			}
			IEnumerable<Parameter> enumerable3 = Enumerable.Where<Parameter>(enumerable2, func2);
			Func<Parameter, bool> func3;
			if ((func3 = \u0013\u001D.<>c.\u0004\u000A) == null)
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
				func3 = (\u0013\u001D.<>c.\u0004\u000A = new Func<Parameter, bool>(\u0013\u001D.<>c.\u001F.\u0010\u0007));
			}
			IEnumerable<Parameter> enumerable4 = Enumerable.Where<Parameter>(enumerable3, func3);
			Func<Parameter, string> func4;
			if ((func4 = \u0013\u001D.<>c.\u0019\u000A) == null)
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
				func4 = (\u0013\u001D.<>c.\u0019\u000A = new Func<Parameter, string>(\u0013\u001D.<>c.\u001F.\u000E\u0007));
			}
			return Enumerable.ToList<Parameter>(Enumerable.OrderBy<Parameter, string>(enumerable4, func4));
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x00022748 File Offset: 0x00020948
		public IEnumerable<NamingParameter> \u0020()
		{
			IEnumerable<Parameter> enumerable = this.\u0011();
			Func<Parameter, bool> func;
			if ((func = \u0013\u001D.<>c.\u0018\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u0020()).MethodHandle;
				}
				func = (\u0013\u001D.<>c.\u0018\u000A = new Func<Parameter, bool>(\u0013\u001D.<>c.\u001F.\u0008\u0007));
			}
			IEnumerable<Parameter> enumerable2 = Enumerable.Distinct<Parameter>(Enumerable.Where<Parameter>(enumerable, func), new \u000E\u0004());
			Func<Parameter, NamingParameter> func2;
			if ((func2 = \u0013\u001D.<>c.\u0005\u000A) == null)
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
				func2 = (\u0013\u001D.<>c.\u0005\u000A = new Func<Parameter, NamingParameter>(\u0013\u001D.<>c.\u001F.\u001B\u0007));
			}
			IEnumerable<NamingParameter> enumerable3 = Enumerable.Select<Parameter, NamingParameter>(enumerable2, func2);
			Func<NamingParameter, string> func3;
			if ((func3 = \u0013\u001D.<>c.\u0016\u000A) == null)
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
				func3 = (\u0013\u001D.<>c.\u0016\u000A = new Func<NamingParameter, string>(\u0013\u001D.<>c.\u001F.\u0011\u0007));
			}
			return Enumerable.OrderBy<NamingParameter, string>(enumerable3, func3);
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x00022804 File Offset: 0x00020A04
		public BrowserOrganization \u0017()
		{
			IEnumerable<BrowserOrganization> enumerable = Enumerable.Cast<BrowserOrganization>(\u0011\u0011\u000A.\u001D(\u0020\u0011\u000A.\u000A(this.\u001F), \u001E\u0011\u000A.\u000A(\u0006\u0007\u000E.\u001F())));
			Func<BrowserOrganization, bool> func;
			if ((func = \u0013\u001D.<>c.\u000B\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u0017()).MethodHandle;
				}
				func = (\u0013\u001D.<>c.\u000B\u000A = new Func<BrowserOrganization, bool>(\u0013\u001D.<>c.\u001F.\u001E\u0007));
			}
			return Enumerable.FirstOrDefault<BrowserOrganization>(Enumerable.Where<BrowserOrganization>(enumerable, func));
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0002287C File Offset: 0x00020A7C
		public IEnumerable<Parameter> \u0014()
		{
			IEnumerable<Parameter> enumerable = \u0003\u0007\u001D.\u000A(\u0013\u0013\u0007.\u000A(this.\u001F), false);
			Func<Parameter, bool> func;
			if ((func = \u0013\u001D.<>c.\u0002\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u0014()).MethodHandle;
				}
				func = (\u0013\u001D.<>c.\u0002\u000A = new Func<Parameter, bool>(\u0013\u001D.<>c.\u001F.\u0020\u0007));
			}
			IEnumerable<Parameter> enumerable2 = Enumerable.Where<Parameter>(enumerable, func);
			Func<Parameter, string> func2;
			if ((func2 = \u0013\u001D.<>c.\u0006\u000A) == null)
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
				func2 = (\u0013\u001D.<>c.\u0006\u000A = new Func<Parameter, string>(\u0013\u001D.<>c.\u001F.\u0017\u0007));
			}
			return Enumerable.OrderBy<Parameter, string>(enumerable2, func2);
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x00022908 File Offset: 0x00020B08
		public Level \u0013(Level \u001F)
		{
			\u0013\u001D.\u0014\u001D u0014_u001D = new \u0013\u001D.\u0014\u001D();
			IEnumerable<Level> enumerable = Enumerable.Cast<Level>(\u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(this.\u001F), -2000240L)));
			Func<Level, bool> func;
			if ((func = \u0013\u001D.<>c.\u000F\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u0013(Level)).MethodHandle;
				}
				func = (\u0013\u001D.<>c.\u000F\u000A = new Func<Level, bool>(\u0013\u001D.<>c.\u001F.\u0014\u0007));
			}
			IEnumerable<Level> enumerable2 = Enumerable.Where<Level>(enumerable, func);
			Func<Level, double> func2;
			if ((func2 = \u0013\u001D.<>c.\u0012\u000A) == null)
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
				func2 = (\u0013\u001D.<>c.\u0012\u000A = new Func<Level, double>(\u0013\u001D.<>c.\u001F.\u0013\u0007));
			}
			List<Level> list = Enumerable.ToList<Level>(Enumerable.OrderBy<Level, double>(enumerable2, func2));
			u0014_u001D.\u001F = \u000E\u0007\u001D.\u000A(\u001F);
			Level level = Enumerable.FirstOrDefault<Level>(list, new Func<Level, bool>(u0014_u001D.\u000A));
			if (level != null)
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
				return level;
			}
			Level level2 = Enumerable.FirstOrDefault<Level>(Enumerable.OrderBy<Level, double>(list, new Func<Level, double>(u0014_u001D.\u0007)));
			if (level2 == null)
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
				throw \u0008\u0013\u0007.\u000A(\u0010\u0007\u001D.\u000A());
			}
			return level2;
		}

		// Token: 0x0400024F RID: 591
		private readonly Document \u001F;

		// Token: 0x020007BC RID: 1980
		[CompilerGenerated]
		private sealed class \u0017\u001D
		{
			// Token: 0x06004C68 RID: 19560 RVA: 0x001DC208 File Offset: 0x001DA408
			internal bool \u000A(ViewFamilyType \u001F)
			{
				if (\u000C\u0020\u000A.\u0007(\u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u001D.\u0017\u001D.\u000A(ViewFamilyType)).MethodHandle;
					}
					return \u001D\u0013\u0007.\u000A(\u001F) == this.\u001F;
				}
				return false;
			}

			// Token: 0x04001F7F RID: 8063
			public ViewFamily \u001F;
		}

		// Token: 0x020007BD RID: 1981
		[CompilerGenerated]
		private sealed class \u0014\u001D
		{
			// Token: 0x06004C6A RID: 19562 RVA: 0x001DC258 File Offset: 0x001DA458
			internal bool \u000A(Level \u001F)
			{
				return \u0016\u001F\u0007.\u000A(\u000E\u0007\u001D.\u000A(\u001F), 5) == \u0016\u001F\u0007.\u000A(this.\u001F, 5);
			}

			// Token: 0x06004C6B RID: 19563 RVA: 0x001DC288 File Offset: 0x001DA488
			internal double \u0007(Level \u001F)
			{
				return \u0008\u001F\u0007.\u000A(\u000E\u0007\u001D.\u000A(\u001F) - this.\u001F);
			}

			// Token: 0x04001F80 RID: 8064
			public double \u001F;
		}
	}
}
