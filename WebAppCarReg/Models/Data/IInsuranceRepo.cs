using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarReg.Models.Data
{
    public interface IInsuranceRepo
    {
        Insurance Create(string name, double price);
        List<Insurance> Read();
        Insurance Read(int id);
        Insurance Update(Insurance insurance);
        bool Delete(Insurance insurance);
    }
}
