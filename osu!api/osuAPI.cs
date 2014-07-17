using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace osu_api
{
    public class osuAPI
    {
        private readonly WebClient _client;
        private readonly string _apiKey;

        private const string ApiUrl = "https://osu.ppy.sh/";
        private const string GetBeatmapsURL = ApiUrl + "/api/get_beatmaps";
        private const string GetUserURL = ApiUrl + "/api/get_user";
        private const string GetScoresURL = ApiUrl + "/api/get_scores";
        private const string GetUserBestURL = ApiUrl + "/api/get_user_best";
        private const string GetUserRecentURL = ApiUrl + "/api/get_user_recent";
        private const string GetMatchURL = ApiUrl + "/api/get_match";

        /// <summary>
        /// Constructs the api class with the given key
        /// </summary>
        /// <param name="apiKey">The osu!Api key given from https://osu.ppy.sh/p/api </param>
        public osuAPI(string apiKey)
        {
            _apiKey = apiKey;
            _client = new WebClient();
        }


        /// <summary>
        /// Gets the beatmap of the specified ID
        /// </summary>
        /// <param name="beatmapId">The ID of the beatmap</param>
        /// <returns>The beatmap or null if none found with that ID</returns>
        public List<Beatmap> GetBeatmaps(int beatmapId)
        {
            var beatmapList = GetResults<Beatmap>(GetBeatmapsURL + "?k=" + _apiKey + "&b=" + beatmapId);
            return beatmapList;
        }

        /// <summary>
        /// Gets the beatmap set of the specified ID
        /// </summary>
        /// <param name="beatmapSetId">The ID of the beatmap set</param>
        /// <returns>The beatmap set or null if none found with that ID</returns>
        public List<Beatmap> GetBeatmapsSet(int beatmapSetId)
        {
            var beatmapList = GetResults<Beatmap>(GetBeatmapsURL + "?k=" + _apiKey + "&s=" + beatmapSetId);
            return beatmapList;
        }

        /// <summary>
        /// Gets the beatmap of the specified ID played by the user
        /// </summary>
        /// <param name="beatmapId">The ID of the beatmap</param>
        /// <param name="userId">The ID of the creator</param>
        /// <returns>The beatmap or null if none found with that ID</returns>
        public List<Beatmap> GetUserBeatmaps(int beatmapId, int userId)
        {
            var beatmapList = GetResults<Beatmap>(GetBeatmapsURL + "?k=" + _apiKey + "&b=" + beatmapId + "&u=" + userId);
            return beatmapList;
        }

        /// <summary>
        /// Gets the beatmap set of the specified ID by the user
        /// </summary>
        /// <param name="beatmapSetId">The ID of the beatmap set</param>
        /// <param name="userId">The ID of the creator</param>
        /// <returns>The beatmap set or null if none found with that ID</returns>
        public List<Beatmap> GetUserBeatmapsSet(int beatmapSetId, int userId)
        {
            var beatmapList = GetResults<Beatmap>(GetBeatmapsURL + "?k=" + _apiKey + "&s=" + beatmapSetId + "&u=" + userId);
            return beatmapList;
        }

        /// <summary>
        /// Gets the user with the specified username
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="mode">The game mode</param>
        /// <returns>The user associated with the username, otherwise null</returns>
        public User GetUser(string username, Mode mode)
        {
            var userList = GetResults<User>(GetUserURL + "?k=" + _apiKey + "&u=" + username + "&m=" + mode + "&type=string");
            return userList.Count > 0 ? userList[0] : null;
        }

        /// <summary>
        /// Gets the user with the specified id
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="mode">The game mode (0 = osu!, 1 = taiko, 2 = CtB, 3 = osu!mania)</param>
        /// <returns>The user associated with the id, otherwise null</returns>
        public User GetUser(int userId, Mode mode)
        {
            var userList = GetResults<User>(GetUserURL + "?k=" + _apiKey + "&u=" + userId + "&m=" + mode + "&type=id");
            return userList.Count > 0 ? userList[0] : null;
        }

        /// <summary>
        /// Gets the scores of a particular user on a beatmap
        /// </summary>
        /// <param name="beatmapId">The id of the beatmap</param>
        /// <param name="userId">The id of the user</param>
        /// <param name="mode">The game mod</param>
        /// <returns>A list of scores</returns>
        public List<Score> GetScores(int beatmapId, int userId, Mode mode)
        {
            var scoreList = GetResults<Score>(GetScoresURL + "?k=" + _apiKey + "&b=" + beatmapId + "&u=" + userId + "&m=" + mode);
            return scoreList;
        }

        /// <summary>
        /// Gets the top 10 scores for a user
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        /// <param name="mode">The game mode</param>
        /// <returns>A lost of scores</returns>
        public List<Score> GetUserBest(int userId, Mode mode)
        {
            return GetResults<Score>(GetUserBestURL + "?k=" + _apiKey + "&u=" + userId + "&m=" + mode + "&type=id");
        }

        /// <summary>
        /// Gets the top 10 scores for a user
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="mode">The game mode</param>
        /// <returns>A lost of scores</returns>
        public List<Score> GetUserBest(string username, Mode mode)
        {
            return GetResults<Score>(GetUserBestURL + "?k=" + _apiKey + "&u=" + username + "&m=" + mode + "&type=string");
        }

        /// <summary>
        /// Gets the multiplayer match details
        /// </summary>
        /// <param name="matchId">The ID of the multiplayer match</param>
        /// <returns>The multiplayer match by the specified ID</returns>
        public MultiplayerMatch GetMatch(int matchId)
        {
            return GetResult<MultiplayerMatch>(GetMatchURL + "?k=" + _apiKey + "&mp=" + matchId);
        }

        private List<T> GetResults<T>(string url)
        {
            var jsonResponse = _client.DownloadString(url);
            var listReturn = new List<T>();
            if (jsonResponse == "Please provide a valid API key.")
                throw new Exception("Invalid osu!Api key");
            var objectArray = JsonConvert.DeserializeObject<T[]>(jsonResponse);
            if (objectArray.Length < 1) return null;

            listReturn.AddRange(objectArray);
            return listReturn;
        }

        private T GetResult<T>(string url)
        {
            var jsonResponse = _client.DownloadString(url);
            if (jsonResponse == "Please provide a valid API key.")
                throw new Exception("Invalid osu!Api key");
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }

    public enum Mode
    {
        osu = 1,
        Taiko = 2,
        CtB = 3,
        Mania = 4
    }
}