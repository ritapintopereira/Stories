# Stories API

## Overview
This API is returning the details of the first 20 best stories by using an external source, the Hacker News API, that returns data in near real time.

The goal of this API project was to test my skills as Senior Backend Developer. 

## Items

Stories are the items that are being returned.

Each story has the following properties:

Field | Description
------|------------
title | The title of the story. HTML.
uri | The URL of the story.
postedBy | The username of the item's author.
time | Creation date of the item, in [Unix Time](http://en.wikipedia.org/wiki/Unix_time).
score | The story's score.
commentCount | The total comment count.

For example, https://localhost:44332/api/Stories

```javascript
[
{
"title": "Amazon met with startups about investing, then launched competing products",
"url": "https://www.wsj.com/articles/amazon-tech-startup-echo-bezos-alexa-investment-fund-11595520249",
"by": "mgav",
"time": "1595521578",
"score": 1103,
"descendants": 342
},
{
"title": "Show HN: TinyPilot – Build a KVM over IP using a Raspberry Pi",
"url": "https://mtlynch.io/tinypilot/",
"by": "mtlynch",
"time": "1595512576",
"score": 735,
"descendants": 277
},
...
]
```

## Errors

In case of error a message will be shown. If it is a 404 error the error code is also returned.

Example 404 error

```javascript
{
"statusCode": 404,
"message": "Stories not found"
}
```


