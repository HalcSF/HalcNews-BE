using AutoMapper;
using HalcNews.Fuentes;
using HalcNews.Noticias;
using HalcNews.Source;
using HalcNews.Temas;
using HalcNews.Themes;

namespace HalcNews;

public class HalcNewsApplicationAutoMapperProfile : Profile
{
    public HalcNewsApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Theme, ThemeDto>();
        CreateMap<Noticia, NoticiaDto>();
        CreateMap<Fuente,FuenteDto>();
    }
}
