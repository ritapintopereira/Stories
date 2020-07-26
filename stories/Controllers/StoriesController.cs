using Microsoft.AspNetCore.Mvc;
using stories.Models;
using System.Collections.Generic;
using Stories.Utilities;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;
using Stories.ExternalApis;

namespace stories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        // GET api/stories
        [HttpGet]
        public async Task<IActionResult> GetBestHistories()
        {
            try
            {
                var bestStories = new List<Story>();
                var hackerNews = new HackerNews();
                //get the best stories Ids
                var storiesIds = await hackerNews.GetBestStoriesIds();
                //take the first 20 stories
                storiesIds = storiesIds.Take(20);
                //get the details for each story
                foreach (int storyId in storiesIds)
                {
                    var storyDetail = await hackerNews.GetStoryDetail(storyId);
                    bestStories.Add(storyDetail);
                }

                //check if no stories were found
                if (!bestStories.Any())
                {
                    //error
                    return NotFound(new ApiResponse(StatusCodes.Status404NotFound, "Stories not found"));
                }

                //success
                return Ok(bestStories.OrderByDescending(s => s.Score).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        
    }
}
