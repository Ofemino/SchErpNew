using System.Net;

namespace SchoolERP.Domain.Dtos;

public class ResponseObject<T> where T : class
{
    public T? ObjectResponse { get; set; }
    public List<T>? ObjectResponseList { get; set; }
    public int ReturnedObjectCount { get; set; }
    public int StatusCode { get; set; }
    public string? ResponseMessage { get; set; }
    public bool HasRecords { get; set; }
}