namespace Container_App.utilities
{
    public class ResponseModel
    {
        public bool Success { get; set; } // Trạng thái thành công hay không
        public string Message { get; set; } // Thông báo gửi tới client
        public object Data { get; set; } // Dữ liệu trả về nếu cần (có thể null)
        public int AffectedRows { get; set; }

        public ResponseModel(bool success, string message, object data = null, int affectedRows = 0)
        {
            Success = success;
            Message = message;
            Data = data;
            AffectedRows = affectedRows;
        }
    }
}
