using AutoMapper;
using HalcNews.Fuentes;
using HalcNews.Noticias;
using HalcNews.Temas;
using HalcNews.Themes;
using HalcNews.ListaNoticias;
using HalcNews.News;
using HalcNews.NewsList;
using HalcNews.Lecturas;
using HalcNews.Alertas;
using HalcNews.Carpetas;
using HalcNews.ApiNews;

namespace HalcNews;

public class HalcNewsApplicationAutoMapperProfile : Profile
{
    public HalcNewsApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Theme, ThemeDto>().ReverseMap();
        CreateMap<New, NewDto>().ReverseMap();
        CreateMap<NewsListE, NewsListDto>().ReverseMap();
        CreateMap<Fuentes.Source, SourceDto>().ReverseMap();
        CreateMap<Lectury, LecturyDto>().ReverseMap();
        CreateMap<Alert, AlertDto>().ReverseMap();
        CreateMap<Folder, FolderDto>().ReverseMap();
        CreateMap<NewDto, ArticleDto>().ReverseMap();
    } 
}
