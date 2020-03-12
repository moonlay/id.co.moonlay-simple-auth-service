using Co.Id.Moonlay.Simple.Auth.Service.Lib.Utilities.BaseClass;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Utilities.BaseInterface;
using Com.Moonlay.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Co.Id.Moonlay.Simple.Auth.Service.Test.Utils
{
    public abstract class BaseDataUtil<TModel, TViewModel, TService>
        where TModel : StandardEntity, new()
        where TViewModel : BaseOldViewModel, IValidatableObject, new()
        where TService : class, IBaseService<TModel>
    {
        private readonly TService Service;
        public BaseDataUtil()
        {

        }
        public BaseDataUtil(TService service)
        {
            Service = service;
        }

        public async Task<TModel> GetTestData()
        {
            TModel model = GetNewData();
            await Service.CreateAsync(model);
            return await Service.ReadByIdAsync(model.Id);
        }

        public abstract TModel GetNewData();

        public abstract TViewModel GetNewViewModel();
    }
}
