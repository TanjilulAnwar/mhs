using MHS.DataAccess.Repository.IRepository;
using MHS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MHS.Controllers
{
    public class IPInfoController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public IPInfoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        [HttpGet]
        [Route("~/ipinfo")]
        public IActionResult GetIpList()
        {
            List<IPInfo> iPInfos = new List<IPInfo>();
            iPInfos = _unitOfWork.IPInfo.GetAll().ToList();
            if (iPInfos.Count != 0)
                return Json(new { sucess = true, ipinfo = iPInfos });

            return Json(new { sucess = false, ipinfo = iPInfos });
        }


        [HttpPost]
        [Route("~/ipinfo/add")]
        public IActionResult Upsert([FromBody] IPInfo iPInfo)
        {
            if (ModelState.IsValid)
            {
              
                if (iPInfo.id == 0)
                {
                    iPInfo.code = "IP00000002";
                    iPInfo.created = DateTime.Now;
                    iPInfo.updated = DateTime.Now;
                    _unitOfWork.IPInfo.Add(iPInfo);

                }
                else
                {
                    iPInfo.updated = DateTime.Now;
                    _unitOfWork.IPInfo.Add(iPInfo);
                }
                _unitOfWork.Save();

                return Json(new { success = true, message = iPInfo });
            }
            else
            {
                return Json(new { success = false, message = "IP Add/Update Failed!" });
            }
            

        }




    }
        
}
