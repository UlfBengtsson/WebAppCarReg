using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarReg.Models.ViewModels;

namespace WebAppCarReg.Models.Services
{
    public interface IInsuranceService
    {
        Insurance Add(CreateInsuranceViewModel createInsuranceViewModel);
        List<Insurance> All();
        Insurance FindBy(int id);
        Insurance Edit(int id, CreateInsuranceViewModel insurance);
        bool Remove(int id);
    }
}
