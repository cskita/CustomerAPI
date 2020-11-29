using System;
using System.Collections.Generic;
using System.Text;
using CustomerAPI.Framework.Domain;
using GenderModel = CustomerAPI.Core.Model.Gender;
using CustomerAPI.Core.Interface.Service.Gender;
using CustomerAPI.Core.Interface.Repository.Gender;

namespace CustomerAPI.Service.Gender
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public BaseResult<List<GenderModel.Gender>> Get()
        {
            try
            {
                var genders = _genderRepository.Get();

                return BaseResult<List<GenderModel.Gender>>.OK(genders);
            }
            catch (Exception e)
            {
                return BaseResult<List<GenderModel.Gender>>.NotOK(e.Message);
            }
        }

        public BaseResult<GenderModel.Gender> GetById(int id)
        {
            try
            {
                var gender = _genderRepository.GetById(id);

                return BaseResult<GenderModel.Gender>.OK(gender);
            }
            catch (Exception e)
            {
                return BaseResult<GenderModel.Gender>.NotOK(e.Message);
            }
        }
    }
}
