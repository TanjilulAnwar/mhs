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
            try
            {
                List<IPInfo> iPInfos = new List<IPInfo>();
                iPInfos = _unitOfWork.IPInfo.GetAll().ToList();
                if (iPInfos.Count != 0)
                    return Json(new { success = true, message = iPInfos });

                return Json(new { success = false, message = iPInfos });
            }
            catch(Exception e)
            {
                return Json(new { success = false, message = e.Message });
            }
            
        }


        [HttpPost]
        [Route("~/ipinfo/add")]
        public IActionResult Upsert([FromBody] IPInfo iPInfo)
        {
            if (ModelState.IsValid)
            {
              
                if (iPInfo.id == 0)
                {
                    iPInfo.code = _unitOfWork.IPInfo.GetIPCode();
                    iPInfo.created = DateTime.Now;
                    iPInfo.updated = DateTime.Now;
                    _unitOfWork.IPInfo.Add(iPInfo);

                }
                else
                {
                    iPInfo.updated = DateTime.Now;
                    _unitOfWork.IPInfo.Update(iPInfo);
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
