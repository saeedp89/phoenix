using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Phoenix.UI.Models;

[Serializable]
public class CommentDto
{
    public long Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = "";

    [JsonProperty("date")] public string Date { get; set; } = "";


    [JsonProperty("userComment")]
    public string Comment { get; set; } = "";
}