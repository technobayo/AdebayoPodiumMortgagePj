using System;

namespace AdebayoPodiumMortgagePj.Service.Repository
{
    public class ManagerResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime Time { get; set; }
    }
}
