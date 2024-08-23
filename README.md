# Weather Blazor App
 Blazor 8.0 weather app using OpenWeather API.

# How to setup
- Create the missing appsettings.json file.
- Add key OpenWeatherUrl in appsettings.json file with value:
https://api.open-meteo.com/v1/forecast?timezone=auto&current=temperature_2m,precipitation_probability,wind_speed_10m"
(Open-Meteo works without special API key. So this is just a reminder to keep sensitive data separate and not to load it to public repo.)
- Also need to install Telerik Blazor UI library.

#  Design decisions, areas of struggle, and challenges faced during the implementation.
First I needed to understand what are the differences then developing Blazor or other ASP.NET project.

There are some new thing in Blazor 8.0, like render mode and component based interactivity. And not being familiar with earlier versions of Blazor, I got confused sometimes, then I was searching information, to understand is this or that approach even up to date anymore.

There are still some weak points in Blazor, which I encountered on my path. Like when using rendermode InteractiveServer along with StreamRendering, it can cause the data to be loaded twice and cause visual flickering.
Or finding out that Visual Studio is not recognizing my components sometimes, which is also a well known issue. This issue stopped me to put most of the thing into separate components as I did it visually in Tile Layout for example.

I used naming for HttpClient to be able to add even more urls easily if needed, for example to access other apis too.

First I wanted to play around and tried to make everything work correctly. Then I started adding Telerik Blazor UI components I realized that I need to rebuild and change the approach how integrate Telerik and other components.

I was running out of time and did not create many tests. The checking data in code and logging service was implemented, which reduces the need to test everything via a testing framework.

Also, I would easily spend an other ten hours to play around with Telerik components and build up a nice stylish interactive UI.

I can be a good helper to integrate UI components with backend systems as I am a person with design background. And not only the good code, but also user experience is coming more important in software development. 