using Newtonsoft.Json;
using stories.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Stories.ExternalApis
{
    public class HackerNews
    {
        /// <summary>
        /// Calls an external API to get the ids of the best stories
        /// </summary>
        /// <returns>IEnumerable<int></returns>
        public async Task<IEnumerable<int>> GetBestStoriesIds()
        {
            List<int> storiesIds = new List<int>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://hacker-news.firebaseio.com/v0/beststories.json"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        storiesIds = JsonConvert.DeserializeObject<List<int>>(apiResponse);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return storiesIds;
        }

        /// <summary>
        /// Calls an external API to get the details of a story given an id 
        /// </summary>
        /// <param name="storyId">id of the story</param>
        /// <returns>Story object</returns>
        public async Task<Story> GetStoryDetail(int storyId)
        {
            Story storyDetail = new Story();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"https://hacker-news.firebaseio.com/v0/item/{storyId}.json"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        storyDetail = JsonConvert.DeserializeObject<Story>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return storyDetail;
        }
    }
}
