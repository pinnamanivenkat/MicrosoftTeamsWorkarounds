# Microsoft Teams WorkArounds
This repository is intended to provide you with workarounds for features you need in Microsoft Team. This is only meant for educational purposes.
## Reason behind this WPF Application
If you have ever used Microsoft Teams, In the **Chat** window we have **Contacts** section which containes **Favorites** as default group. In order to add members into a new or existing group, user has to type every single name, pick from suggestions and then add the person. This is laborious work. Instead, why can't we add people using DL?
Well, Teams group creation is possible from DL. My manager wanted a script to automate this process of creating a Contact group and adding people from DL.
The fastest way to do this is to perform a network call.
## Hurdles
There surely were hurdles when i was thinking to develop this application. 

 1. I wanted to make an intranet web application which would authorize and authenticate using Microsoft OAuth2. I don't know what the issue was, but i wasn't able to perform the network calls using that token as Authentication Bearer.
 2. Another idea was to create a Web Application and launch Microsoft Teams to read cookies. But, CORS doesn't allow that to happen.
 3. I could always launch a Web Browser and open Microsoft Teams as source. But, when to know that user has performed Login? There could be a button which user would press as soon as login. But again,  Microsoft teams doesn't support all the browser

![OAuth2 flow by Microsoft](https://docs.microsoft.com/en-us/azure/active-directory/develop/media/v1-protocols-oauth-code/active-directory-oauth-code-flow-native-app.png)

So, i came up with the idea of reading the cookies from the disk.
## Why cookies?
Microsoft Teams, in order to perform the token refresh, stores the Auth Bearer token in the browser cookies. That's all i need to perform a network call to Microsoft Teams API. So, I wrote a code to pick the cookies from the disk, decrypt it and extract the authentication bearer from that. Using that Auth Token, i performed the network call to the Teams API and got the job done. 
## How to run this Application?

 1. Fork this repository
 2. Clone it to a local folder
 3. Open the .sln file in the Visual Studio
 4. Start it. 
## How to use this application?
 1. Open Google Chrome browser, login into Microsoft Teams. 
 2. Run the exeuctable generated after building the project.
 3. As soon as the executable is run, you would see a button "Perform Check?". Press that button to check if the cookie has been generated.
 4. If the cookie is read properly, application would navigate to a screen containing two input fields
 5. First input field is for the name of Contact Group
 6. Second input field is for the DL Name. 
 7. As soon as user starts typing the DL name, suggestions would be populated in the bottom section of the screen. 
 8. Upon selection of any of the results, Submit button would be activate. 
 9. Click on the Submit button would create the Contact group in Microsoft teams, having members of DL as group members.
## Contact me
You can always write to me at pinnamanivenkat@gmail.com
If you think any more features could be added to this tool, please let me know i would love to work on it.

 

