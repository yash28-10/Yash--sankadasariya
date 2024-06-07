﻿using Business_logic_Layer;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientMissionController : ControllerBase
    {
        private readonly BALMission _balMission;
        ResponseResult result = new ResponseResult();
        public ClientMissionController(BALMission balMission)
        {
            _balMission = balMission;
        }
        [HttpGet]
        [Route("ClientSideMissionList/{userId}")]
        public ResponseResult ClientSideMissionList(int userId)
        {
            try
            {
                result.Data = _balMission.ClientSideMissionList(userId);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("MissionClientList")]
        public ResponseResult MissionClientList(SortestData data)
        {
            try
            {
                result.Data = _balMission.MissionClientList(data);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("ApplyMission")]
        public ResponseResult ApplyMission(MissionApplication missionApplication)
        {
            try
            {
                result.Data = _balMission.ApplyMission(missionApplication);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("MissionDetailByMissionId")]
        [Authorize]
        public ResponseResult MissionDetailByMissionId(SortestData data)
        {
            try
            {
                result.Data = _balMission.MissionDetailByMissionId(data);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }



        [HttpGet]
        [Route("GetUserList/{userId}")]
        public ResponseResult GetUserList(int userId)
        {
            try
            {
                result.Data = _balMission.GetUserList(userId);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

    }
}
