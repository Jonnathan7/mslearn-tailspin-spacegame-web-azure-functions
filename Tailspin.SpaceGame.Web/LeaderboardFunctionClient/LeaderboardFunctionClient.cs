﻿using System.Text.Json;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System;

namespace TailSpin.SpaceGame.Web
{
    public class LeaderboardFunctionClient : ILeaderboardServiceClient
    {
        private string _functionUrl;

        public LeaderboardFunctionClient(string functionUrl)
        {
            this._functionUrl = functionUrl;
        }

        async public Task<LeaderboardResponse> GetLeaderboard(int page, int pageSize, string mode, string region)
        {
            Task<string> task = new HttpClient().GetStringAsync(new Uri($"{this._functionUrl}?page={page}&pageSize={pageSize}&mode={mode}&region={region}"));
            string json = await task;
             
             return JsonSerializer.Deserialize<LeaderboardResponse>(json);
            
            /*
            using (WebClient webClient = new WebClient())
            {
                string json = await webClient.DownloadStringTaskAsync($"{this._functionUrl}?page={page}&pageSize={pageSize}&mode={mode}&region={region}");                
                return JsonSerializer.Deserialize<LeaderboardResponse>(json);
            }
            */
        }
    }
}
