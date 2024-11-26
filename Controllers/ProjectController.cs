using Container_App.Model.Projects;
using Container_App.Model.ProjectUserInvites;
using Container_App.Services.ProjectService;
using Container_App.utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Container_App.Controllers
{
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [Authorize] // Yêu cầu xác thực
        [HttpPost("create-project")]
        public async Task<ActionResult<Project>> CreateProject([FromBody] Project project)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value); // Lấy userId từ token

            try
            {
                var createdProject = await _projectService.CreateProjectAsync(project, userId);
                return CreatedAtAction(nameof(CreateProject), new { id = createdProject.ProjectId }, createdProject);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message); // Trả về lỗi 403 nếu không đủ quyền
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 cho các lỗi khác
            }
        }
        [HttpPost("islock-project")]
        public async Task<ActionResult<Project>> IsLockProject(int projectId)
        {
            try
            {
                var pro = await _projectService.IsLockProjectAsync(projectId);
                return Ok(pro);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 cho các lỗi khác
            }
        }

        [HttpPost("send-invites")]
        public async Task<IActionResult> SendProjectInvites([FromBody] InviteRequest request)
        {
            if (request.UserIds == null || request.UserIds.Count == 0)
                return BadRequest("User IDs are required.");

            await _projectService.SendProjectInvitesAsync(request.ProjectId, request.UserIds);
            return Ok("Invites sent successfully.");
        }

        [HttpPost("accept-invite/{inviteId}")]
        public async Task<IActionResult> AcceptInvite(int inviteId)
        {
            var result = await _projectService.AcceptInviteAsync(inviteId);
            if (!result)
                return NotFound("Invite not found or already accepted.");

            return Ok("Invite accepted successfully.");
        }

        [HttpPost("decline-invite/{inviteId}")]
        public async Task<IActionResult> DeclineInvite(int inviteId)
        {
            var result = await _projectService.DeclineInviteAsync(inviteId);
            if (!result)
                return NotFound("Invite not found or already declined.");

            return Ok("Invite declined successfully.");
        }
    }
}
