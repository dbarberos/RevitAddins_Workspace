using System;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.ExtensibleStorage;
using DiRoots.One.QuickViews.Models.Dto;

namespace DiRoots.One.TableGen.TGRevitHelper.StyleMapping
{
	// Token: 0x0200013D RID: 317
	[Schema("1A6C4B3D-80C4-495D-BE85-0BAE0FF3A149", "DiRootsOneTableGen_TextNoteIdentityDto")]
	public class TextNoteIdentityDto : BaseDto<TextNoteIdentity>
	{
		// Token: 0x06000BBC RID: 3004 RVA: 0x0004A68C File Offset: 0x0004888C
		public static TextNoteIdentity GetEntity(Element element)
		{
			TextNoteIdentityDto textNoteIdentityDto = element.\u000A<TextNoteIdentityDto>();
			if (textNoteIdentityDto == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TextNoteIdentityDto.GetEntity(Element)).MethodHandle;
				}
				return null;
			}
			return \u0020\u000C\u0004.\u000A(textNoteIdentityDto);
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x0004A6C4 File Offset: 0x000488C4
		public static void SetEntity(Element element, TextNoteIdentity settings)
		{
			TextNoteIdentityDto textNoteIdentityDto = \u0014\u000C\u0004.\u000A();
			\u0017\u000C\u0004.\u000A(textNoteIdentityDto, settings);
			element.\u001F(textNoteIdentityDto);
		}
	}
}
