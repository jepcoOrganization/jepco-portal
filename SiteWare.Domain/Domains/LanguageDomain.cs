using SiteWare.DataAccess.Repositories;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Domain.Domains
{
    public static class LanguageDomain
    {

        public async static Task<ResultList<LanguageEntity>> GetLanguagesAll()
        {
            ResultList<LanguageEntity> result = new ResultList<LanguageEntity>();

            result = await LanguageRepository.SelectAll();

            return result;
        }
        public static ResultList<LanguageEntity> GetLanguagesAllNotAsync()
        {
            ResultList<LanguageEntity> result = new ResultList<LanguageEntity>();

            result = LanguageRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<LanguageEntity>> GetLanguageByID(int ID)
        {
            ResultEntity<LanguageEntity> result = new ResultEntity<LanguageEntity>();

            result = await LanguageRepository.Language_SelectByID(ID);

            return result;
        }
        public async static Task<ResultEntity<LanguageEntity>> UpdateLanguage(LanguageEntity entity)
        {
            ResultEntity<LanguageEntity> result = new ResultEntity<LanguageEntity>();

            result = await LanguageRepository.Language_Update(entity);

            return result;
        }

        public async static Task<ResultEntity<LanguageEntity>> InsertLanguage(LanguageEntity entity)
        {
            ResultEntity<LanguageEntity> result = new ResultEntity<LanguageEntity>();

            result = await LanguageRepository.Language_Insert(entity);

            return result;
        }

        public async static Task<ResultEntity<LanguageEntity>> DeleteLanguage(int ID)
        {
            ResultEntity<LanguageEntity> result = new ResultEntity<LanguageEntity>();

            result = await LanguageRepository.Language_Delete(ID);

            return result;
        }
    }
}
