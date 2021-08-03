using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models.Process;
using TaskManager.Services.Models;
using TaskManager.Services.Services;
using TaskManagers.Common.Logging;
using TaskManagers.Web.Models;

namespace TaskManagers.Web.Controllers
{
    [ApiController]
    [Route("taskmanager/")]
    public class TaskManagerController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly ITaskManagerServices taskManagerServices;

        public TaskManagerController(ILogger logger, ITaskManagerServices taskManagerServices)
        {
            this.logger              = logger;
            this.taskManagerServices = taskManagerServices;
        }

        /// <summary>
        ///  Retrieve a TaskManager Processes
        /// </summary>
        /// <param name="sortOption"> The sort option of returned processes</param>
        /// <returns>List of task manager Processes</returns>
        /// <response code="200">Success: processes returned</response>
        /// <response code="500">Internal server error: the server was unable to process the request, due to a server error.</response>       
        //[SwaggerResponseExample(200, typeof(TaskManagerExamples))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<ProcessDto>>> Get([FromQuery] SortOption sortOption = SortOption.ById)
        {
            try
            {
                var result = await taskManagerServices.ListAsync(sortOption);
                return Ok(result);
            }
            catch (Exception ex)
            {
                await logger.LogErrorAsync(ErrorLevel.Major, ex, LogEvent.FailedToListTaskManagerProcesses.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<long>> AddProcess([FromBody] CreateProcessRequest request)
        {
            try
            {
                if(request == null)
                {
                    return BadRequest();
                }

                var result = await taskManagerServices.AddAsync(request.Priority, request.GroupName);
                if (result == null)
                {
                    return BadRequest("Failed to add more items");
                }
                return Created("", result);
            }
            catch (Exception ex)
            {
                await logger.LogErrorAsync(ErrorLevel.Major, ex, LogEvent.FailedToAddProcess.ToString());

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("killprocess/{processid}")]
        public async Task<ActionResult> KillProcess([FromRoute] long processid)
        {
            try
            {
                await taskManagerServices.KillIProcessAsync(processid);

                return Ok();
            }
            catch (Exception ex)
            {
                await logger.LogErrorAsync(ErrorLevel.Major, ex, LogEvent.FailedToKillProcess.ToString());

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("killall")]
        public async Task<ActionResult> KillAll()
        {
            try
            {
                await taskManagerServices.KillAllAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                await logger.LogErrorAsync(ErrorLevel.Major, ex, LogEvent.FailedToKillAll.ToString());

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("killprocessgroup/{groupname}")]
        public async Task<ActionResult> KillProcessGroup([FromRoute] string groupname)
        {
            try
            {
                if (string.IsNullOrEmpty(groupname))
                    return BadRequest();

                await taskManagerServices.KillIProcessGroupAsync(groupname);

                return Ok();
            }
            catch (Exception ex)
            {
                await logger.LogErrorAsync(ErrorLevel.Major, ex, LogEvent.FailedToKillProcessGroup.ToString());

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}