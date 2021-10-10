using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Business.Enums;
using PhoneBook.Core.Repository;
using PhoneBook.Entities;

namespace PhoneBook.Business.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        #region Implementation of IContactService

        public int Update(Contact request)
        {
            int result = 0;

            if (UpdateContactValidations(request))
            {
                result = _contactRepository.Update(request);
            }
            else
            {
                result = (int)ResultCodeEnums.ModelStateNoValid;
            }

            return result;
        }

        public int Delete(Guid id)
        {
            int result = 0;

            if (DeleteContactValidations(id))
            {
                result = _contactRepository.Delete(id);
            }
            else
            {
                result = (int)ResultCodeEnums.ModelStateNoValid;
            }

            return result;
        }

       

        public List<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }
        public int Add(Contact entity)
        {
            int result = 0;

            if (ContactValidations(entity))
            {
                result = _contactRepository.Add(entity);
            }
            else
            {
                result = (int)ResultCodeEnums.ModelStateNoValid;
            }

            return result;
        }

        

        private bool ContactValidations(Contact entity)
        {
            return !string.IsNullOrEmpty(entity.Name)
                   && !string.IsNullOrEmpty(entity.Surname)
                   && !string.IsNullOrEmpty(entity.Number1);
        }

        private bool UpdateContactValidations(Contact entity)
        {
            return entity.Id != Guid.Empty
                && !string.IsNullOrEmpty(entity.Name)
                   && !string.IsNullOrEmpty(entity.Surname)
                   && !string.IsNullOrEmpty(entity.Number1);
        }
        private bool DeleteContactValidations(Guid id)
        {
            return id != Guid.Empty;
        }
        #endregion
    }
}
