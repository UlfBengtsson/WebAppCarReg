using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarReg.Models.Data;
using WebAppCarReg.Models.ViewModels;

namespace WebAppCarReg.Models.Services
{
    public class InsuranceService : IInsuranceService
    {
        readonly IInsuranceRepo _insuranceRepo;
        public InsuranceService(IInsuranceRepo insuranceRepo)
        {
            _insuranceRepo = insuranceRepo;
        }

        public Insurance Add(CreateInsuranceViewModel createInsuranceViewModel)
        {
            return _insuranceRepo.Create(createInsuranceViewModel.Name, createInsuranceViewModel.Price);
        }

        public List<Insurance> All()
        {
            return _insuranceRepo.Read();
        }

        public Insurance Edit(int id, CreateInsuranceViewModel insurance)
        {
            Insurance editedInsurance = new Insurance() { Id = id, Name = insurance.Name, Price = insurance.Price };

            return _insuranceRepo.Update(editedInsurance);
        }

        public Insurance FindBy(int id)
        {
            return _insuranceRepo.Read(id);
        }

        public bool Remove(int id)
        {
            return _insuranceRepo.Delete(FindBy(id));
        }
    }
}
