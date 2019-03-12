using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ModelApi.Domain.Interfaces.Service;
using ModelApi.Domain.Models;

//https://medium.com/@alexalves_85598/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686

namespace ModelApi.Application.Controllers
{
    [EnableCors("Cors")]
    [Route("api/Sample")]
    public class SampleController : BaseController
    {
        private readonly ISampleService _sampleService;

        public SampleController(ISampleService sampleAppService)
        {
            _sampleService = sampleAppService;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = _sampleService.Get();

                return await Response(result, null);
            }
            catch (Exception ex)
            {
                return await Response(null, new List<string> { "Sample" });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(Sample sample)
        {
            try
            {
                var result = _sampleService.Post(sample);

                return await Response(result, null);
            }
            catch (Exception ex)
            {
                return await Response(null, new List<string> { "Sample" });
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        //[HttpPut, Route("v1/banco")]
        //[Authorize(Policy = "UpdateParametros")]
        //public async Task<IActionResult> Put([FromBody]UpdateBancoCommand command)
        //{
        //    try
        //    {
        //        if (command == null)
        //            return await Response(null, new List<Notification> { new Notification("Banco", "Banco inválido") });

        //        var contract = new BancoContract(command);

        //        if (contract.Contract.Invalid)
        //        {
        //            Logger.Warning("Permissão: Banco, alterar com erros", JsonConvert.SerializeObject(command), JsonConvert.SerializeObject(contract.Contract.Notifications));
        //            return await Response(command, contract.Contract.Notifications);
        //        }

        //        var result = _bancoAppService.Update(command);

        //        return await Response(result, contract.Contract.Notifications);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error("Permissão: Banco, alterar", ex, JsonConvert.SerializeObject(command));
        //        return await Response(null, new List<Notification> { new Notification("Banco", ex.Message) });
        //    }
        //}
    }
}
