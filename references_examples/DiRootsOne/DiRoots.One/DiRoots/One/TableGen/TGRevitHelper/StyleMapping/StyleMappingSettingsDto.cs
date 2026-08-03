using System;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.ExtensibleStorage;
using DiRoots.One.QuickViews.Models.Dto;

namespace DiRoots.One.TableGen.TGRevitHelper.StyleMapping
{
	// Token: 0x0200013A RID: 314
	[Schema("3D6F7A4E-2C18-4C9A-8B71-9F6E2A4D8C03", "DiRootsOneTableGen_StyleMappingSettingsDto")]
	public class StyleMappingSettingsDto : BaseDto<StyleMappingSettings>
	{
		// Token: 0x06000BB1 RID: 2993 RVA: 0x0004A314 File Offset: 0x00048514
		public static StyleMappingSettings GetEntity(Element element)
		{
			StyleMappingSettingsDto styleMappingSettingsDto = element.\u000A<StyleMappingSettingsDto>();
			if (styleMappingSettingsDto == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingSettingsDto.GetEntity(Element)).MethodHandle;
				}
				return null;
			}
			return \u0002\u000C\u0004.\u000A(styleMappingSettingsDto);
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x0004A34C File Offset: 0x0004854C
		public static void SetEntity(Element element, StyleMappingSettings settings)
		{
			StyleMappingSettingsDto styleMappingSettingsDto = \u000F\u000C\u0004.\u000A();
			\u0006\u000C\u0004.\u000A(styleMappingSettingsDto, settings);
			element.\u001F(styleMappingSettingsDto);
		}
	}
}
