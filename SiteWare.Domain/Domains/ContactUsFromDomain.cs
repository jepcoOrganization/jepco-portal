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
    public static class ContactUsFormDomain
    {
        public static ResultList<ContactUsFormEntity> GetContactFormAllNotAsync()
        {
            ResultList<ContactUsFormEntity> result = new ResultList<ContactUsFormEntity>();

            result = ContactUsFormRepository.SelectAllNotAsync();

            return result;
        }
        public async static Task<ResultEntity<ContactUsFormEntity>> GetContactUsFormByID(int ID)
        {
            ResultEntity<ContactUsFormEntity> result = new ResultEntity<ContactUsFormEntity>();

            result = await ContactUsFormRepository.SelectByID(ID);

            return result;
        }
        public async static Task<ResultList<ContactUsFormEntity>> GetContactUsFormAll()
        {
            ResultList<ContactUsFormEntity> result = new ResultList<ContactUsFormEntity>();

            result = await ContactUsFormRepository.SelectAll();

            return result;
        }
        public static ResultEntity<ContactUsFormEntity> InsertContactUsForm(ContactUsFormEntity entity)
        {
            ResultEntity<ContactUsFormEntity> result = new ResultEntity<ContactUsFormEntity>();

            result = ContactUsFormRepository.Insert(entity);

            return result;
        }
        public async static Task<ResultEntity<ContactUsFormEntity>> UpdateContactUsByIsDeleted(ContactUsFormEntity entity)
        {
            ResultEntity<ContactUsFormEntity> result = new ResultEntity<ContactUsFormEntity>();

            result = await ContactUsFormRepository.UpdateByIsDeleted(entity);

            return result;
        }
    }
}
