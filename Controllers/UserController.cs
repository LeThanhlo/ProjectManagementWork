using Container_App.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Container_App.utilities;
using Container_App.Model.Users;

namespace Container_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("get-all-user")]
        public async Task<ActionResult<List<Users>>> GetUsers(PagedResult page)
        {
            var users = await _userService.GetUsers(page);
            return Ok(users);
        }

        //[Authorize]
        [HttpGet("get-user-by-id/{id}")]
        public async Task<ActionResult<Users>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound(new ResponseModel(false, "Không tìm thấy user!"));
            return Ok(user);
        }


        //[Authorize]
        [HttpPost("create-user")]
        public async Task<ActionResult<ResponseModel>> CreateUser(Users user)
        {
            int rowsAffected = await _userService.CreateUser(user);

            if (rowsAffected > 0)
            {
                var response = new ResponseModel(
                    success: true,
                    message: "Thêm user thành công!",
                    data: user, // Trả về đối tượng user đã tạo
                    affectedRows: rowsAffected
                );

                return rowsAffected > 0 ? Ok(response) : NotFound(response);
            }
            return BadRequest(new ResponseModel(false, "Thêm user thất bại!"));
        }

        [Authorize]
        [HttpPut("update-user/{id}")]
        public async Task<ActionResult<ResponseModel>> UpdateUser(int id, Users user)
        {
            user.UserId = id; // Đảm bảo UserId được thiết lập
            int rowsAffected = await _userService.UpdateUser(user);

            var response = new ResponseModel(
                success: rowsAffected > 0,
                message: rowsAffected > 0 ? "Cập nhật user thành công!" : "Không tìm thấy user để cập nhật!",
                data: user, // Trả về đối tượng user đã cập nhật
                affectedRows: rowsAffected // Gửi số dòng bị ảnh hưởng
            );

            return rowsAffected > 0 ? Ok(response) : NotFound(response);
        }


        [Authorize]
        [HttpDelete("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            int rowsAffected = await _userService.DeleteUser(id);

            var response = new ResponseModel(
                success: rowsAffected > 0,
                message: rowsAffected > 0 ? "Xoá user thành công!" : "Không tìm thấy user để xóa!",
                affectedRows: rowsAffected // Gửi số dòng bị ảnh hưởng
            );

            return rowsAffected > 0 ? Ok(response) : NotFound(response);
        }
    }
}
