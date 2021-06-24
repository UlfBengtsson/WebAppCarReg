using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarReg.Models.Data
{
    public interface IGenericRepo<ModelType, CreateType>
    {
        //CRUD
        ModelType Create(CreateType create);

        ModelType Read(int id);
        List<ModelType> Read();

        ModelType Update(ModelType model);

        bool Delete(ModelType model);
    }
}
