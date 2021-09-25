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
        #endregion
    }
}
