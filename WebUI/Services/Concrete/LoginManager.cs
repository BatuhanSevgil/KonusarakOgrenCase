using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebUI.Entities.Models;
using Newtonsoft.Json;
using WebUI.Services.Abstract;

namespace WebUI.Services.Concrete
{
  public class LoginManager : ILoginService
  {
    private HttpClient _http { get; set; }
    private AppStateManager _state { get; set; }
    public LoginManager(HttpClient http, AppStateManager state)
    {
      _http = http;
      _state = state;

    }

    public async Task<DataResult<User>> Login(Auth auth)
    {
      HttpResponseMessage response = await _http.PostAsJsonAsync("user/login", auth);

      if (response.IsSuccessStatusCode)
      {
        var json = await response.Content.ReadFromJsonAsync<DataResult<User>>();
        return json;
      }
      return null;
    }
  }
}
