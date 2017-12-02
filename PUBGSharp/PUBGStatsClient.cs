﻿using System;
using System.Threading.Tasks;
using PUBGSharp.Data;
using PUBGSharp.Net;
using PUBGSharp.Net.Model;
namespace PUBGSharp
{
    public class PUBGStatsClient : IPUBGStatsClient, IDisposable
    {
        private readonly HttpRequester _httpRequester;

        /// <summary>
        /// Initialises a <see cref="PUBGStatsClient"/>.
        /// </summary>
        /// <param name="apiKey">Your tracker network API key. (https://pubgtracker.com/site-api)</param>
        /// <param name="throttle">
        /// Enable or disable throttling, pubgtracker wants to have ~1 request per sec. It is
        /// recommended to keep this enabled.
        /// </param>
        public PUBGStatsClient(string apiKey, bool throttle = true)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("API key cannot be empty.");
            }
            _httpRequester = throttle ? new HttpRequesterThrottle(apiKey) : new HttpRequester(apiKey);
        }


        /// <summary>
        /// Initialises a <see cref="PUBGStatsClient"/>.
        /// </summary>
        /// <param name="playerName">player name you search</param>
        /// <param name="region">region you search (NA, EU)</param>
        /// <param name="mode">Mode you search (Solo, Duo, solo-fpp)</param>
        public async Task<StatsResponse> GetPlayerStatsAsync(string playerName, Region region = Region.AGG, Mode mode = Mode.All)
        {
            if (string.IsNullOrEmpty(playerName))
            {
                throw new ArgumentException("Player name cannot be empty.");
            }
            return await _httpRequester.RequestAsyncS(playerName, region, mode).ConfigureAwait(false);
        }

        /// <summary>
        /// Initialises a <see cref="PUBGStatsClient"/>.
        /// </summary>
        /// <param name="playerName">player name you search</param>
        /// <param name="region">region you search (NA, EU)</param>
        /// <param name="mode">Mode you search (Solo, Duo, solo-fpp)</param>
        /// <param name="value">specific Stats you want (usage : Stats.XXX)</param>
        public async Task<StatModel> GetPlayerStatsValue(string playerName, Region region = Region.AGG, Mode mode = Mode.All, string value = null)
        {
            if (string.IsNullOrEmpty(playerName))
            {
                throw new ArgumentException("Player name cannot be empty.");
            }
            return await _httpRequester.RequestAsyncV(playerName, region, mode, value).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _httpRequester?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}