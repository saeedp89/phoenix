using Newtonsoft.Json;
using Phoenix.UI.Data.Repositories;
using Phoenix.UI.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace Phoenix.UI.Services;

public class UserCommentService : IUserCommentService
{
    private readonly IUserCommentRepository _repository;
    private readonly HttpClient _httpClient;

    public UserCommentService(IHttpClientFactory httpClientFactory, IUserCommentRepository repository)
    {
        _repository = repository;

        _httpClient = httpClientFactory.CreateClient("parspack");
    }


    public IEnumerable<CommentDto> GetCommentsFromApi(string url)
    {
        var items = (_httpClient.GetFromJsonAsync<IEnumerable<CommentDto>>(url)).Result.Reverse();
        return items;
    }


    public IEnumerable<CommentDto> GetCommentsFromDb(int pageSize = 5, int pageIndex = 1, string searchTerm = "")
    {
        return _repository.Take(pageSize, pageSize * (pageIndex - 1), searchTerm: searchTerm).ToCommentDto();
    }

   

  

    public string PostData(CommentDto commentDto)
    {

        using var req = new HttpRequestMessage(new HttpMethod("POST"), "http://tasks.cloudsite.ir/api/");
        var mutlipart = new MultipartFormDataContent();
        mutlipart.Add(new StringContent(commentDto.Name),"name");
        mutlipart.Add(new StringContent(commentDto.Date),"date");
        mutlipart.Add(new StringContent(commentDto.Comment),"comment");
        req.Content=mutlipart;
        HttpResponseMessage httpResponse= new HttpClient().SendAsync(req).Result;
        var content=httpResponse.Content.ReadAsStringAsync().Result;
        if (httpResponse.IsSuccessStatusCode)
            return "Success";
        else
        {
            return "Failed";
        }


    }

    public void ClearLocalTable()
    {
        _repository.ClearTable();
    }

    public void SynchronizeDatabaseWithServer()
    {
        _repository.ClearTable();
        var data = GetCommentsFromApi("/api").ToList();
        _repository.AddRange(data.ToUserComment());        
        
    }


    private List<CommentDto> ReadJsonFile(string filePath)
    {
        string jsonContent = File.ReadAllText(filePath);
        var contentList = JsonConvert.DeserializeObject<List<CommentDto>>(jsonContent);
        var s = new Stack<CommentDto>();
        var list = new List<CommentDto>();
        foreach (var r in contentList)
        {
            s.Push(r);
        }

        var length = s.Count;
        for (int i = 0; i < length; i++)
        {
            list.Add(s.Pop());
        }

        return list;
    }
}