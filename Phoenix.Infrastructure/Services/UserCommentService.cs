using System.Net.Http.Json;
using Newtonsoft.Json;
using Phoenix.Infrastructure.Abstractions;
using Phoenix.Infrastructure.Extensions;
using Phoenix.Infrastructure.Models.DataTransferObjects;

namespace Phoenix.Infrastructure.Services;

public class UserCommentService : IUserCommentService
{
    private readonly IUserCommentRepository _repository;
    private readonly HttpClient _httpClient;

    public UserCommentService(IHttpClientFactory httpClientFactory, IUserCommentRepository repository)
    {
        _repository = repository;
        _httpClient = httpClientFactory.CreateClient("pars-pack");
    }


    public async Task<IEnumerable<CommentDto>> GetCommentsFromApiAsync(string url)
    {
        var items = await new HttpClient().GetFromJsonAsync<IEnumerable<CommentDto>>("http://tasks.cloudsite.ir/api");
        return items;
    }


    public async Task<IEnumerable<CommentDto>> GetCommentsFromDbAsync(int pageSize = 5, int pageIndex = 1,
        string searchTerm = "")
    {
        var cms = (await _repository.SearchAsync(pageSize, pageSize * (pageIndex - 1), searchTerm: searchTerm))
            .ToCommentDto();
        return cms;
    }


    public async Task<string> PostDataAsync(CommentDto commentDto)
    {
        using var req = new HttpRequestMessage(new HttpMethod("POST"), "http://tasks.cloudsite.ir/api/");
        var multipartFormDataContent = new MultipartFormDataContent();
        multipartFormDataContent.Add(new StringContent(commentDto.Name), "name");
        multipartFormDataContent.Add(new StringContent(commentDto.Date), "date");
        multipartFormDataContent.Add(new StringContent(commentDto.Comment), "comment");
        req.Content = multipartFormDataContent;
        HttpResponseMessage httpResponse = await new HttpClient().SendAsync(req);
        return httpResponse.IsSuccessStatusCode ? "Success" : "Failed";
    }

    public async Task ClearLocalTableAsync()
    {
        await _repository.TruncateAsync();
    }

    public async Task SynchronizeDatabaseWithServerAsync()
    {
        await _repository.TruncateAsync();
        var data = await GetCommentsFromApiAsync("/api");
        await _repository.AddRangeAsync(data.ToUserComment());
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