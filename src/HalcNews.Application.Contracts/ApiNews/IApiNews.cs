using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HalcNews.Api
{
        public interface IApiNewsAppService : IApplicationService
        {
        Task<string> GetNews(string? Search);
        }
    }