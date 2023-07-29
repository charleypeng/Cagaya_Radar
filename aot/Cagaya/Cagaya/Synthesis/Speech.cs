using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using LibVLCSharp.Shared;

namespace Cagaya.Synthesis;

public class Speech
{
    public string? Url { get; set; } = "http://localhost:5500/api/";
    public string? Ip { get; set; }
    public int?  Port { get; set; }
    private Uri uri { get; }
    
    public Speech(string url)
    {
        this.Url = url;
        this.uri = new Uri(Url);
    }
    public Speech()
    {
        this.uri = new Uri(Url);
    }
    private Uri? getUri(string? path)
    {
        if (Url == null)
        {
            return null!;
        }

        return string.IsNullOrWhiteSpace(path) ? new Uri(Url) : new Uri(Url + path);
    }
    
    private async Task<Stream?> getFromAPI(string? txt)
    {
        if (Url == null || string.IsNullOrWhiteSpace(txt))
        {
            return null!;
        }

        var client = new HttpClient();
        client.BaseAddress = uri;
        var response =
            await client.GetAsync(getUri(
                 $"tts?voice=coqui-tts%3Azh_baker&text={txt.Trim()}?vocoder=high&denoiserStrength=0.03&cache=false"));
        if (response.StatusCode != HttpStatusCode.OK)
            return null!;

        var data = await response.Content.ReadAsStreamAsync();
        return data;
    }
    
    public async Task Speek(string? txt)
    {
        var data = await getFromAPI(txt);
        if (data == null)
            return;
        //using var libvlc = new LibVLC(enableDebugLogs: true);
       // using var media = new StreamMediaInput(data);
        //media.Open();
    }
}